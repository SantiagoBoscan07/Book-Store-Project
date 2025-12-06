using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BookStoreDO;
using BookStoreBO;

namespace GroupProject
{
    public partial class frmTitlesMaintenance : Form
    {
        // Constructor to initialize the form and load data.
        public frmTitlesMaintenance()
        {
            InitializeComponent();
            //  Load data into the DataGridView and ComboBox on form load.
            LoadGrid();
            LoadPublisherIDs();
            // Attach event handler for DataGridView selection change
            grdTitles.SelectionChanged += grdTitles_SelectionChanged;
            // Set default selection for type combo box
            cboType.SelectedIndex = 0;
        }

        // Method to load titles from the database and display them in the DataGridView.
        private void LoadGrid()
        {
            var titles = TitlesDB.GetAllTitles();
            grdTitles.DataSource = titles;
            grdTitles.ClearSelection();
        }


        // Method to load publisher IDs into the combo box.
        private void LoadPublisherIDs()
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Query to retrieve publishers
            string query = "SELECT pub_id, pub_name, city, state, country FROM publishers";

            // Create a list to hold Publisher objects
            List<BookStoreDO.Publisher> publishers = new List<BookStoreDO.Publisher>();

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Create and execute the SQL command
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Create a new Publisher object and populate its properties
                    BookStoreDO.Publisher p = new BookStoreDO.Publisher
                    {
                        PublisherID = reader["pub_id"].ToString(),
                        PublisherName = reader["pub_name"] == DBNull.Value ? null : reader["pub_name"].ToString(),
                        City = reader["city"] == DBNull.Value ? null : reader["city"].ToString(),
                        State = reader["state"] == DBNull.Value ? null : reader["state"].ToString(),
                        Country = reader["country"] == DBNull.Value ? "USA" : reader["country"].ToString()
                    };
                    // Add the Publisher object to the list
                    publishers.Add(p);
                }
            }

            // Bind the publishers ID to the combo box
            cboTitlesPubID.DisplayMember = "PublisherID";
            cboTitlesPubID.ValueMember = "PublisherID";
            cboTitlesPubID.DataSource = publishers;
        }

        // Event handler for the Close button click event, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to validate user input before database operations.
        private bool isValidInput()
        {
            // Call the TitleValidator to validate inputs
            var (isValid, message) = Validator.ValidateTitleInput(txtTitleID.Text,txtTitle.Text,txtPrice.Text);

            // If validation fails, show message and set focus
            if (!isValid)
            {
                // Show validation message
                MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // set focus to appropriate field
                if (message.Contains("Title ID"))
                    txtTitleID?.Focus();
                else if (message.Contains("Title is required"))
                    txtTitle?.Focus();
                else if (message.Contains("Price"))
                    txtPrice?.Focus();

                // Return false indicating invalid input
                return false;
            }

            // Return true indicating valid input
            return true;
        }

        // Method to add a new title to the database.
        private void AddTitleToDatabase(Title newTitle)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

            // SQL Insert query
            string insertQuery = @"INSERT INTO titles
                           (title_id, title, type, pub_id, price, notes, pubdate)
                           VALUES
                           (@TitleID, @Title, @Type, @PubID, @Price, @Notes, @PubDate)";

            // Execute the insert command
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@TitleID", newTitle.TitleID);
                cmd.Parameters.AddWithValue("@Title", newTitle.Name);
                cmd.Parameters.AddWithValue("@Type", newTitle.Type);
                cmd.Parameters.AddWithValue("@PubID", string.IsNullOrEmpty(newTitle.PublisherID) ? (object)DBNull.Value : newTitle.PublisherID);
                cmd.Parameters.AddWithValue("@Price", newTitle.Price.HasValue ? (object)newTitle.Price.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(newTitle.Notes) ? (object)DBNull.Value : newTitle.Notes);
                cmd.Parameters.AddWithValue("@PubDate", newTitle.PublishedDate);
                // Open connection and execute
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Event handler to add a title
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Input validation
            if (!isValidInput())
            {
                // Invalid input. Exit the method
                return;
            }

            // Create a new Title object from user input
            Title newTitle = new Title
            {
                TitleID = txtTitleID.Text.Trim(),
                Name = txtTitle.Text.Trim(),
                Type = cboType.SelectedItem?.ToString() ?? "UNDECIDED",
                PublisherID = cboTitlesPubID.SelectedValue?.ToString(),
                Price = string.IsNullOrWhiteSpace(txtPrice.Text) ? null : (decimal?)decimal.Parse(txtPrice.Text),
                Notes = txtNote.Text.Trim(),
                PublishedDate = dtpPubDate.Value
            };

            try
            {
                // Insert into database
                TitlesDB.AddTitle(newTitle);

                // Update DataGridView 
                List<Title> currentTitles = grdTitles.DataSource as List<Title>;
                if (currentTitles == null)
                    currentTitles = new List<Title>();

                // Add the new title to the current list and refresh the grid
                currentTitles.Add(newTitle);
                grdTitles.DataSource = null;         
                grdTitles.DataSource = currentTitles;

                // Show success message
                MessageBox.Show("Title added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after add
                btnClear_Click(null, null);
            }
            // Catch any exceptions during database operations
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding title: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrid();
        }

        // Event handler to update a title
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate inputs first
            if (!isValidInput())
                return;

            // Get TitleID from input
            string titleID = txtTitleID.Text.Trim();

            // Calls method to check if titleID exists in database
            if (!TitlesDB.TitleExists(titleID))
            {
                MessageBox.Show($"Cannot update: Title ID '{titleID}' does not exist in the database.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get current DataGridView selection
            if (grdTitles.CurrentRow == null || grdTitles.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update object with new values
            Title selectedTitle = grdTitles.CurrentRow.DataBoundItem as Title;
            selectedTitle.TitleID = txtTitleID.Text.Trim();
            selectedTitle.Name = txtTitle.Text.Trim();
            selectedTitle.Type = cboType.SelectedItem?.ToString() ?? "UNDECIDED";
            selectedTitle.PublisherID = cboTitlesPubID.SelectedValue?.ToString();
            selectedTitle.Price = string.IsNullOrWhiteSpace(txtPrice.Text) ? null : (decimal?)decimal.Parse(txtPrice.Text);
            selectedTitle.Notes = txtNote.Text.Trim();
            selectedTitle.PublishedDate = dtpPubDate.Value;

            // Update database
            try
            {
                // Calls method to update the database
                TitlesDB.UpdateTitle(selectedTitle);

                // Refresh DataGridView
                List<Title> currentTitles = grdTitles.DataSource as List<Title>;
                grdTitles.DataSource = null;
                grdTitles.DataSource = currentTitles;
                // Show success message
                MessageBox.Show("Title updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Catch any exceptions during database operations
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating title: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler to clear all input fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear DataGridView selection
            grdTitles.ClearSelection();

            // Clear all textboxes
            txtNote.Clear();
            txtPrice.Clear();
            txtTitle.Clear();
            txtTitleID.Clear();

            // Clear selection of combox box, default value for combo box
            cboTitlesPubID.SelectedIndex = -1;
            cboType.SelectedIndex = 0;

            // Clear date picker (set to current date)
            dtpPubDate.Value = DateTime.Now;
        }

        // Event handler to delete a title
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get TitleID from input
            string titleID = txtTitleID.Text.Trim();

            // Validate that a TitleID is entered
            if (string.IsNullOrEmpty(titleID))
            {
                // Error message for empty TitleID
                MessageBox.Show("Please enter a Title ID to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitleID.Focus();
                return;
            }

            // Check if title exists in the database
            if (!TitlesDB.TitleExists(titleID))
            {
                MessageBox.Show($"Cannot delete: Title ID '{titleID}' does not exist in the database.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get current DataGridView selection
            if (grdTitles.CurrentRow == null || grdTitles.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion with the user
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the title '{txtTitle.Text}' (ID: {titleID})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // If user selects No, exit the method
            if (result != DialogResult.Yes)
                return; 

            try
            {
                // Delete from database
                TitlesDB.DeleteTitle(titleID);

                // Remove from DataGridView
                List<Title> currentTitles = grdTitles.DataSource as List<Title>;
                if (currentTitles != null)
                {
                    Title toRemove = currentTitles.FirstOrDefault(t => t.TitleID == titleID);
                    if (toRemove != null)
                    {
                        // Remove the title from the current list and refresh the grid
                        currentTitles.Remove(toRemove);
                        grdTitles.DataSource = null;
                        grdTitles.DataSource = currentTitles;
                    }
                }
                // Show success message
                MessageBox.Show("Title deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields
                btnClear_Click(null, null);
            }
            // Catch any exceptions during database operations
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting title: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for DataGridView selection change to populate input fields.
        private void grdTitles_SelectionChanged(object sender, EventArgs e)
        {
            // Get the selected Title object
            Title selectedTitle = grdTitles.CurrentRow.DataBoundItem as Title;
            if (selectedTitle == null)
                return;

            // Populate input fields
            txtTitleID.Text = selectedTitle.TitleID;
            txtTitle.Text = selectedTitle.Name;
            cboType.SelectedItem = selectedTitle.Type ?? "UNDECIDED";
            cboTitlesPubID.SelectedValue = selectedTitle.PublisherID;
            txtPrice.Text = selectedTitle.Price?.ToString() ?? string.Empty;
            txtNote.Text = selectedTitle.Notes;
            dtpPubDate.Value = selectedTitle.PublishedDate;
        }
    }
}
