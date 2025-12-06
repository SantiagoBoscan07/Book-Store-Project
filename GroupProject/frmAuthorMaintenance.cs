using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreDO;
using BookStoreBO;

namespace GroupProject
{
    public partial class frmAuthorMaintenance : Form
    {

        public frmAuthorMaintenance()
        {
            InitializeComponent();
            // Load Authors into the DataGridView on form load
            LoadGrid();
            // Attach event handler for DataGridView selection change
            grdAuthors.SelectionChanged += grdAuthors_SelectionChanged;
        }

        // Method to load Authors from the database and display them in the DataGridView.
        private void LoadGrid()
        {
            // Load authors from the database
            grdAuthors.DataSource = AuthorDB.GetAllAuthors();
            grdAuthors.ClearSelection();
        }


        // Method to validate user input before database operations.
        private bool isValidInput()
        {
            // Validate input using AuthorValidator
            var (isValid, message) = Validator.ValidateAuthorInput(txtAuthorID.Text.Trim(),txtAuthorFirstName.Text.Trim(),txtAuthorLastName.Text.Trim(),txtAuthorPhoneNumber.Text.Trim(),rdoAuthorContracted.Checked || rdoAuthorNotContracted.Checked, txtAuthorZip.Text.Trim());

            // If validation fails, show message and set focus to the relevant field
            if (!isValid)
            {
                // Show validation message
                MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Set focus to the relevant input field based on the message
                if (message.Contains("ID"))
                    txtAuthorID.Focus();
                else if (message.Contains("First"))
                    txtAuthorFirstName.Focus();
                else if (message.Contains("Last"))
                    txtAuthorLastName.Focus();
                else if (message.Contains("Phone"))
                    txtAuthorPhoneNumber.Focus();

                // Return false if validation fails
                return false;
            }

            // Return true if all validations pass
            return true;
        }

        // Event handler for Add button click, adds a new author to the database.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!isValidInput()) 
                return;

            // Check if Author ID already exists
            if (AuthorExists(txtAuthorID.Text))
            {
                MessageBox.Show("Author ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new Author object from input fields
            Author newAuthor = new Author
            {
                AuthorID = txtAuthorID.Text.Trim(),
                AuthorFirstName = txtAuthorFirstName.Text.Trim(),
                AuthorLastName = txtAuthorLastName.Text.Trim(),
                Phone = txtAuthorPhoneNumber.Text.Trim(),
                Address = txtAuthorAddress.Text.Trim(),
                City = txtAuthorCity.Text.Trim(),
                State = txtAuthorState.Text.Trim(),
                Zip = txtAuthorZip.Text.Trim(),
                isContracted = rdoAuthorContracted.Checked
            };

            // Try to add the new author to the database
            try
            {
                // Add author to database
                AuthorDB.AddAuthor(newAuthor);

                // Update DataGridView
                List<Author> authors = grdAuthors.DataSource as List<Author> ?? new List<Author>();
                authors.Add(newAuthor);
                grdAuthors.DataSource = null;
                grdAuthors.DataSource = authors;
                // Notify user of success
                MessageBox.Show("Author added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
            }
            // Catch and display any errors
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding author: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Reload the grid to reflect changes
            LoadGrid();
        }

        // Event handler for Close button click, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for Update button click, updates an existing author in the database.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!isValidInput()) 
                return;

            // Check if Author ID exists
            if (!AuthorExists(txtAuthorID.Text))
            {
                MessageBox.Show("Author ID does not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if a row is selected in the DataGridView
            if (grdAuthors.CurrentRow == null || grdAuthors.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create an Author object from input fields
            Author updatedAuthor = grdAuthors.CurrentRow.DataBoundItem as Author;
            updatedAuthor.AuthorFirstName = txtAuthorFirstName.Text.Trim();
            updatedAuthor.AuthorLastName = txtAuthorLastName.Text.Trim();
            updatedAuthor.Phone = txtAuthorPhoneNumber.Text.Trim();
            updatedAuthor.Address = txtAuthorAddress.Text.Trim();
            updatedAuthor.City = txtAuthorCity.Text.Trim();
            updatedAuthor.State = txtAuthorState.Text.Trim();
            updatedAuthor.Zip = txtAuthorZip.Text.Trim();
            updatedAuthor.isContracted = rdoAuthorContracted.Checked;

            // Try to update the author in the database
            try
            {
                // Update author in database
                AuthorDB.UpdateAuthor(updatedAuthor);

                // Refresh DataGridView
                List<Author> authors = grdAuthors.DataSource as List<Author>;
                grdAuthors.DataSource = null;
                grdAuthors.DataSource = authors;
                // Notify user of success
                MessageBox.Show("Author updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
            }
            // Catch and display any errors
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating author: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Clear button click, clears all input fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear DataGridView selection
            grdAuthors.ClearSelection();

            // Clear TextBoxes
            txtAuthorID.Clear();
            txtAuthorFirstName.Clear();
            txtAuthorLastName.Clear();
            txtAuthorPhoneNumber.Clear();
            txtAuthorAddress.Clear();
            txtAuthorCity.Clear();
            txtAuthorState.Clear();
            txtAuthorZip.Clear();

            // Clear Radio Buttons Selection
            rdoAuthorContracted.Checked = false;
            rdoAuthorNotContracted.Checked = false;
        }

        // Event handler for DataGridView selection change to populate input fields.
        private void grdAuthors_SelectionChanged(object sender, EventArgs e)
        {
            // Get the selected Title object
            Author selectedAuthor = grdAuthors.CurrentRow.DataBoundItem as Author;

            // Check if a Publisher is selected, cancel if none is selected
            if (selectedAuthor == null)
                return;

            // Populate input fields
            txtAuthorID.Text = selectedAuthor.AuthorID.ToString();
            txtAuthorFirstName.Text = selectedAuthor.AuthorFirstName.ToString();
            txtAuthorLastName.Text = selectedAuthor.AuthorLastName.ToString();
            txtAuthorPhoneNumber.Text = selectedAuthor.Phone.ToString() ?? "UKNOWN";
            txtAuthorAddress.Text = selectedAuthor.Address.ToString();
            txtAuthorCity.Text = selectedAuthor.City.ToString();
            txtAuthorState.Text = selectedAuthor.State.ToString();
            txtAuthorZip.Text = selectedAuthor.Zip.ToString();

            // Set contracted status radio buttons
            if (selectedAuthor.isContracted)
            {
                rdoAuthorContracted.Checked = true;
            }
            else
            {
                rdoAuthorNotContracted.Checked = true;
            }

        }

        // Event handler for Delete button click, deletes an author from the database.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Validate Author ID input
            string authorID = txtAuthorID.Text.Trim();

            // Check required field author ID
            if (string.IsNullOrWhiteSpace(authorID))
            {
                MessageBox.Show("Please enter an Author ID to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthorID.Focus();
                return;
            }

            // Check if Author ID exists
            if (!AuthorExists(authorID))
            {
                MessageBox.Show($"Cannot delete: Author ID '{authorID}' does not exist.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if a row is selected in the DataGridView
            if (grdAuthors.CurrentRow == null || grdAuthors.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion with the user
            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete author '{txtAuthorLastName.Text}' (ID: {authorID})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user selects No, cancel deletion
            if (confirm != DialogResult.Yes) 
                return;

            // Try to delete the author from the database
            try
            {
                // Delete author from database
                AuthorDB.DeleteAuthor(authorID);

                // Update DataGridView
                List<Author> authors = grdAuthors.DataSource as List<Author>;
                Author toRemove = authors?.FirstOrDefault(a => a.AuthorID == authorID);
                if (toRemove != null)
                {
                    authors.Remove(toRemove);
                    grdAuthors.DataSource = null;
                    grdAuthors.DataSource = authors;
                }
                // Notify user of success
                MessageBox.Show("Author deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
            }
            // Catch and display any errors
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting author: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to check if author exists
        private bool AuthorExists(string authorID) => AuthorDB.AuthorExists(authorID);
    }
}
