using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Query to retrieve publishers
            string query = "SELECT title_id, title, type, pub_id, price, advance, notes, pubdate FROM titles";

            // Create a list to hold Title objects
            List<Title> titles = new List<Title>();
            titles.Clear();

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Create and execute the SQL command
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Create a new Title object and populate its properties
                    Title t = new Title
                    {
                        TitleID = reader["title_id"].ToString(),
                        Name = reader["title"].ToString(),
                        Type = reader["type"].ToString(),
                        PublisherID = reader["pub_id"].ToString(),
                        Price = reader["price"] == DBNull.Value ? null : (decimal?)reader["price"],
                        Notes = reader["notes"].ToString(),
                        PublishedDate = (DateTime)reader["pubdate"]
                    };
                    // Add the Title object to the list
                    titles.Add(t);
                    grdTitles.ClearSelection();
                }
            }

            // Bind the list to the DataGridView
            grdTitles.DataSource = titles;
        }

        // Method to load publisher IDs into the combo box.
        private void LoadPublisherIDs()
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Query to retrieve publishers
            string query = "SELECT pub_id, pub_name, city, state, country FROM publishers";

            // Create a list to hold Publisher objects
            List<Publisher> publishers = new List<Publisher>();

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
                    Publisher p = new Publisher
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
            // Read and trim inputs
            string titleIdText = txtTitleID?.Text?.Trim() ?? string.Empty;
            string title = txtTitle?.Text?.Trim() ?? string.Empty;
            string priceText = txtPrice?.Text?.Trim() ?? string.Empty;

            // Validate TitleID (required)
            if (string.IsNullOrEmpty(titleIdText))
            {
                MessageBox.Show("Title ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitleID?.Focus();
                return false;
            }

            // Validate Title (required)
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle?.Focus();
                return false;
            }

            // Checks that the price is not a negative number
            if (!string.IsNullOrEmpty(priceText))
            {
                if (!decimal.TryParse(priceText, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal price))
                {
                    MessageBox.Show("Price must be a valid number (e.g. 12.99).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice?.Focus();
                    return false;
                }

                if (price < 0m)
                {
                    MessageBox.Show("Price cannot be negative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice?.Focus();
                    return false;
                }
            }

            // Return if all validations are passed.
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
                AddTitleToDatabase(newTitle);

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

        // Method to check if a title exists in the database
        private bool TitleExists(string titleID)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Query to check if the titleID is in the database
            string query = "SELECT COUNT(*) FROM titles WHERE title_id = @TitleID";

            // Execute the query
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TitleID", titleID);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
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
            if (!TitleExists(titleID))
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
                UpdateTitleInDatabase(selectedTitle);

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

        // Update method in database
        private void UpdateTitleInDatabase(Title updatedTitle)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Update query
            string updateQuery = @"UPDATE titles
                           SET title = @Title,
                               type = @Type,
                               pub_id = @PubID,
                               price = @Price,
                               notes = @Notes,
                               pubdate = @PubDate
                           WHERE title_id = @TitleID";
            // Execute the update command
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@TitleID", updatedTitle.TitleID);
                cmd.Parameters.AddWithValue("@Title", updatedTitle.Name);
                cmd.Parameters.AddWithValue("@Type", updatedTitle.Type);
                cmd.Parameters.AddWithValue("@PubID", string.IsNullOrEmpty(updatedTitle.PublisherID) ? (object)DBNull.Value : updatedTitle.PublisherID);
                cmd.Parameters.AddWithValue("@Price", updatedTitle.Price.HasValue ? (object)updatedTitle.Price.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(updatedTitle.Notes) ? (object)DBNull.Value : updatedTitle.Notes);
                cmd.Parameters.AddWithValue("@PubDate", updatedTitle.PublishedDate);

                conn.Open();
                cmd.ExecuteNonQuery();
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

            // Clear selection of combox box (back to default "Undefined" value)
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
            if (!TitleExists(titleID))
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
                DeleteTitleFromDatabase(new Title { TitleID = titleID });

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

        // Method to delete a Title object from the database
        private void DeleteTitleFromDatabase(Title titleToDelete)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

            // SQL Delete query
            string deleteQuery = "DELETE FROM titles WHERE title_id = @TitleID";

            // Execute the delete command
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                // Add parameter to prevent SQL injection
                cmd.Parameters.AddWithValue("@TitleID", titleToDelete.TitleID);
                conn.Open();
                cmd.ExecuteNonQuery();
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
