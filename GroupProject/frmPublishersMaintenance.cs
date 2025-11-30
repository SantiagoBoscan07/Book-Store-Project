using Microsoft.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class frmPublishersMaintenance : Form
    {
        public frmPublishersMaintenance()
        {
            InitializeComponent();
            // Load publishers into the DataGridView when the form loads.
            LoadGrid();
            // Attach event handler for DataGridView selection change.
            grdPublishers.SelectionChanged += grdPublishers_SelectionChanged;
            // Set default value for Publisher Country combo box
            cboPublisherCountry.SelectedIndex = 0;
        }

        // Method to load Publisher from the database and display them in the DataGridView.
        private void LoadGrid()
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
                        PublisherName = reader["pub_name"].ToString(),
                        City = reader["city"].ToString(),
                        State = reader["state"].ToString(),
                        Country = reader["country"].ToString(),
                    };
                    // Add the Publishers object to the list
                    publishers.Add(p);
                    grdPublishers.ClearSelection();
                }
            }

            // Bind the list to the DataGridView
            grdPublishers.DataSource = publishers;
        }

        // Method to validate user input before database operations.
        private bool isValidInput()
        {
            // Trim Publisher ID input
            string pubId = txtPublisherID.Text.Trim();

            // Check if Publisher ID is empty
            if (string.IsNullOrWhiteSpace(pubId))
            {
                MessageBox.Show("Publisher ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Define valid fixed Publisher IDs
            string[] validFixedIds = { "1756", "1622", "0877", "0736", "1389" };

            // Check if Publisher ID matches fixed values or the pattern 99##
            bool matchesFixed = validFixedIds.Contains(pubId);
            bool matchesPattern = Regex.IsMatch(pubId, @"^99\d\d$");

            // Validate Publisher ID
            if (!matchesFixed && !matchesPattern)
            {
                MessageBox.Show("Publisher ID must be one of the following: 1756, 1622, 0877, 0736, 1389, or follow the numeric pattern 99##.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // All validations passed
            return true;
        }

        // Event handler for the Close button click event, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for the Add button click event.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate user input
            if (!isValidInput())
                return;

            // Creates new publisher object from input fields
            Publisher newPublisher = new Publisher
            {
                PublisherID = txtPublisherID.Text.Trim(),
                PublisherName = txtPublisherName.Text.Trim(),
                City = txtPublisherCity.Text.Trim(),
                State = txtPublisherState.Text.Trim(),
                Country = cboPublisherCountry.SelectedItem?.ToString() ?? "USA"
            };

            try
            {
                // Add the new publisher to the database
                AddPublisherToDatabase(newPublisher);

                // List to hold current publishers in the DataGridView
                List<Publisher> currentPublishers = grdPublishers.DataSource as List<Publisher>;
                if (currentPublishers == null)
                    currentPublishers = new List<Publisher>();

                // Add the new publisher to the list and refresh the DataGridView
                currentPublishers.Add(newPublisher);
                grdPublishers.DataSource = null;
                grdPublishers.DataSource = currentPublishers;

                // Display success message
                MessageBox.Show("Publisher added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
            }
            // Catch any exceptions and display an error message
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding publisher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Update button click event.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate user input
            if (!isValidInput())
                return;

            // Get the Publisher ID from input
            string pubID = txtPublisherID.Text.Trim();

            // Check if the publisher exists
            if (!PublisherExists(pubID))
            {
                MessageBox.Show($"Cannot update: Publisher ID '{pubID}' does not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a row is selected in the DataGridView
            if (grdPublishers.CurrentRow == null || grdPublishers.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected Publisher object
            Publisher selectedPublisher = grdPublishers.CurrentRow.DataBoundItem as Publisher;

            // Update the selected publisher's properties with input values
            selectedPublisher.PublisherID = txtPublisherID.Text.Trim();
            selectedPublisher.PublisherName = txtPublisherName.Text.Trim();
            selectedPublisher.City = txtPublisherCity.Text.Trim();
            selectedPublisher.State = txtPublisherState.Text.Trim();
            selectedPublisher.Country = cboPublisherCountry.SelectedItem?.ToString() ?? "USA";

            // Attempt to update the publisher in the database
            try
            {
                // Update the publisher in the database
                UpdatePublisherInDatabase(selectedPublisher);

                // Refresh the DataGridView to reflect changes
                List<Publisher> currentPublishers = grdPublishers.DataSource as List<Publisher>;
                grdPublishers.DataSource = null;
                grdPublishers.DataSource = currentPublishers;

                // Show success message
                MessageBox.Show("Publisher updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Catch any exceptions and display an error message
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating publisher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Clear button click event.
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear DataGridView selection
            grdPublishers.ClearSelection();

            // Clear all input fields
            txtPublisherID.Clear();
            txtPublisherName.Clear();
            txtPublisherCity.Clear();
            txtPublisherState.Clear();

            // Set value of Publisher Country to Default Value "USA"
            cboPublisherCountry.SelectedIndex = 0;
        }

        // Event handler for the Delete button click event.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Gets trimmed Publisher ID from input field
            string pubID = txtPublisherID.Text.Trim();

            // Validate Publisher ID input
            if (string.IsNullOrWhiteSpace(pubID))
            {
                MessageBox.Show("Please enter a Publisher ID to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPublisherID.Focus();
                return;
            }

            // Check if the publisher exists
            if (!PublisherExists(pubID))
            {
                MessageBox.Show($"Cannot delete: Publisher ID '{pubID}' does not exist.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a row is selected in the DataGridView
            if (grdPublishers.CurrentRow == null || grdPublishers.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion with the user
            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete publisher '{txtPublisherName.Text}' (ID: {pubID})?","Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            // If user does not confirm, exit the method
            if (confirm != DialogResult.Yes)
                return;

            // Attempt to delete the publisher from the database
            try
            {
                // Delete the publisher from the database
                DeletePublisherFromDatabase(new Publisher { PublisherID = pubID });

                // List of current publishers in the DataGridView
                List<Publisher> currentPublishers = grdPublishers.DataSource as List<Publisher>;
                if (currentPublishers != null)
                {
                    // Find and remove the deleted publisher from the list
                    Publisher toRemove = currentPublishers.FirstOrDefault(p => p.PublisherID == pubID);
                    if (toRemove != null)
                    {
                        currentPublishers.Remove(toRemove);
                        grdPublishers.DataSource = null;
                        grdPublishers.DataSource = currentPublishers;
                    }
                }

                // Show success message
                MessageBox.Show("Publisher deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
            }
            // Catch any exceptions and display an error message
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting publisher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Event handler for DataGridView selection change to populate input fields.
        private void grdPublishers_SelectionChanged(object sender, EventArgs e)
        {
            // Get the selected Title object
            Publisher selectedPublisher = grdPublishers.CurrentRow.DataBoundItem as Publisher;

            // Check if a Publisher is selected, cancel if none is selected
            if (selectedPublisher == null)
                return;

            // Populate input fields
            txtPublisherID.Text = selectedPublisher.PublisherID;
            txtPublisherName.Text = selectedPublisher.PublisherName;
            txtPublisherCity.Text = selectedPublisher.City;
            txtPublisherState.Text = selectedPublisher.State;

            // Set the Publisher Country combo box
            cboPublisherCountry.SelectedItem = selectedPublisher.Country ?? "USA";
        }

        // Method to check if a publisher exists in the database.
        private bool PublisherExists(string publisherID)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

            // SQL Query to check for publisher existence
            string query = "SELECT COUNT(*) FROM publishers WHERE pub_id = @PubID";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Add parameter to the SQL command
                cmd.Parameters.AddWithValue("@PubID", publisherID);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Method to add a new publisher to the database.
        private void AddPublisherToDatabase(Publisher newPublisher)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

            // SQL Query to insert a new publisher
            string insertQuery = @"INSERT INTO publishers
                           (pub_id, pub_name, city, state, country)
                           VALUES
                           (@PubID, @Name, @City, @State, @Country)";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                // Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@PubID", newPublisher.PublisherID);
                cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(newPublisher.PublisherName) ? (object)DBNull.Value : newPublisher.PublisherName);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(newPublisher.City) ? (object)DBNull.Value : newPublisher.City);
                cmd.Parameters.AddWithValue("@State", string.IsNullOrEmpty(newPublisher.State) ? (object)DBNull.Value : newPublisher.State);
                cmd.Parameters.AddWithValue("@Country", string.IsNullOrEmpty(newPublisher.Country) ? (object)DBNull.Value : newPublisher.Country);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update an existing publisher in the database.
        private void UpdatePublisherInDatabase(Publisher updatedPublisher)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

            // SQL Query to update a publisher
            string updateQuery = @"UPDATE publishers
                           SET pub_name = @Name,
                               city = @City,
                               state = @State,
                               country = @Country
                           WHERE pub_id = @PubID";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                // Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@PubID", updatedPublisher.PublisherID);
                cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(updatedPublisher.PublisherName) ? (object)DBNull.Value : updatedPublisher.PublisherName);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(updatedPublisher.City) ? (object)DBNull.Value : updatedPublisher.City);
                cmd.Parameters.AddWithValue("@State", string.IsNullOrEmpty(updatedPublisher.State) ? (object)DBNull.Value : updatedPublisher.State);
                cmd.Parameters.AddWithValue("@Country", string.IsNullOrEmpty(updatedPublisher.Country) ? (object)DBNull.Value : updatedPublisher.Country);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete a publisher from the database.
        private void DeletePublisherFromDatabase(Publisher publisherToDelete)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

            // SQL Query to delete a publisher
            string deleteQuery = "DELETE FROM publishers WHERE pub_id = @PubID";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                // Add parameter to the SQL command
                cmd.Parameters.AddWithValue("@PubID", publisherToDelete.PublisherID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
