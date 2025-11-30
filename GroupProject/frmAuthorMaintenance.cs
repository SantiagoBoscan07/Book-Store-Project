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
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Query to retrieve Authors
            string query = "SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors";

            // Create a list to hold Author objects
            List<Author> authors = new List<Author>();
            authors.Clear();

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Create and execute the SQL command
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Create a new Author object and populate its properties
                    Author a = new Author()
                    {
                        AuthorID = reader["au_id"].ToString(),
                        AuthorLastName = reader["au_lname"].ToString(),
                        AuthorFirstName = reader["au_fname"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["address"].ToString(),
                        City = reader["city"].ToString(),
                        State = reader["state"].ToString(),
                        Zip = reader["zip"].ToString(),
                        isContracted = (bool)reader["contract"]
                    };
                    // Add the Author object to the list
                    authors.Add(a);
                    grdAuthors.ClearSelection();
                }
            }

            // Bind the list to the DataGridView
            grdAuthors.DataSource = authors;
        }


        // Method to validate user input before database operations.
        private bool isValidInput()
        {
            // Trim all inputs
            string firstName = txtAuthorFirstName.Text.Trim();
            string lastName = txtAuthorLastName.Text.Trim();

            // Check required field author ID
            if (!txtAuthorID.MaskFull)
            {
                MessageBox.Show("Author ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required field first name
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required field last name
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required field phone number
            if (!txtAuthorPhoneNumber.MaskFull)
            {
                MessageBox.Show("Phone number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required radio buttons selection for contracted status
            if (!rdoAuthorContracted.Checked && !rdoAuthorNotContracted.Checked)
            {
                MessageBox.Show("Please select Contracted or Not Contracted.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Return if all inputs are valid
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
                AddAuthorToDatabase(newAuthor);

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
                UpdateAuthorInDatabase(updatedAuthor);

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
                DeleteAuthorFromDatabase(authorID);

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

        // Check if author exists
        private bool AuthorExists(string authorID)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            string query = "SELECT COUNT(*) FROM authors WHERE au_id = @AuthorID";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Parameterize query to prevent SQL injection
                cmd.Parameters.AddWithValue("@AuthorID", authorID);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Add author to database
        private void AddAuthorToDatabase(Author newAuthor)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Insert query
            string insertQuery = @"INSERT INTO authors
                                   (au_id, au_lname, au_fname, phone, address, city, state, zip, contract)
                                   VALUES (@ID, @LName, @FName, @Phone, @Address, @City, @State, @Zip, @Contract)";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                // Parameterize query to prevent SQL injection
                cmd.Parameters.AddWithValue("@ID", newAuthor.AuthorID);
                cmd.Parameters.AddWithValue("@LName", newAuthor.AuthorLastName);
                cmd.Parameters.AddWithValue("@FName", newAuthor.AuthorFirstName);
                cmd.Parameters.AddWithValue("@Phone", newAuthor.Phone ?? "UNKNOWN");
                cmd.Parameters.AddWithValue("@Address", (object)newAuthor.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@City", (object)newAuthor.City ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@State", (object)newAuthor.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Zip", (object)newAuthor.Zip ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract", newAuthor.isContracted);
                // Execute the insert command
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Update author in database
        private void UpdateAuthorInDatabase(Author updatedAuthor)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Update query
            string updateQuery = @"UPDATE authors SET
                                   au_lname = @LName,
                                   au_fname = @FName,
                                   phone = @Phone,
                                   address = @Address,
                                   city = @City,
                                   state = @State,
                                   zip = @Zip,
                                   contract = @Contract
                                   WHERE au_id = @ID";
            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                // Parameterize query to prevent SQL injection
                cmd.Parameters.AddWithValue("@ID", updatedAuthor.AuthorID);
                cmd.Parameters.AddWithValue("@LName", updatedAuthor.AuthorLastName);
                cmd.Parameters.AddWithValue("@FName", updatedAuthor.AuthorFirstName);
                cmd.Parameters.AddWithValue("@Phone", updatedAuthor.Phone ?? "UNKNOWN");
                cmd.Parameters.AddWithValue("@Address", (object)updatedAuthor.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@City", (object)updatedAuthor.City ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@State", (object)updatedAuthor.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Zip", (object)updatedAuthor.Zip ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Contract", updatedAuthor.isContracted);
                // Execute the update command
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete author from database
        private void DeleteAuthorFromDatabase(string authorID)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Delete query
            string deleteQuery = "DELETE FROM authors WHERE au_id = @ID";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                // Parameterize query to prevent SQL injection
                cmd.Parameters.AddWithValue("@ID", authorID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
