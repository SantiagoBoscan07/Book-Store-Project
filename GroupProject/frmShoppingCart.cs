using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class frmShoppingCart : Form
    {
        // Instantiate ShoppingCart to manage order items
        private ShoppingCart cart = new ShoppingCart();
        // Database connection string
        private string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

        public frmShoppingCart()
        {
            InitializeComponent();
            // Load titles into the search results grid on form load
            LoadTitles();
            //  Setup the order grid
            SetupOrderGrid();
        }

        // Load all titles from the database into the search results grid.
        private void LoadTitles()
        {
            // List of titles to bind to the grid
            List<Title> titles = new List<Title>();

            // Fetch titles from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to select title details
                string sql = "SELECT title_id, title, price FROM titles ORDER BY title ASC";
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    // Open connection and execute query
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Add each title to the list
                        titles.Add(new Title
                        {
                            TitleID = reader["title_id"].ToString(),
                            Name = reader["title"].ToString(),
                            Price = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0
                        });
                    }
                }
                // Handle any errors that occur during data retrieval
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading titles: " + ex.Message);
                }
            }

            // Bind only needed columns to the grid
            grdTitleSearchResult.DataSource = titles.Select(t => new
            {
                t.TitleID,
                t.Name,
                t.Price
            }).ToList();

            // Set column headers for better readability
            grdTitleSearchResult.Columns["TitleID"].HeaderText = "Title ID";
            grdTitleSearchResult.Columns["Name"].HeaderText = "Title Name";
            grdTitleSearchResult.Columns["Price"].HeaderText = "Price";

            // Auto-resize columns to fit content
            grdTitleSearchResult.AutoResizeColumns();
        }

        // Setup the order grid to display current order items.
        private void SetupOrderGrid()
        {
            RefreshOrderGrid();
        }


        // Method to validate user input before database operations.
        private bool isValidSearch()
        {
            // Check for empty Title
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // If all validations pass, return
            return true;
        }

        // Method to validate order input before adding or updating items.
        private bool isValidOrder()
        {
            // Check for empty Quantity and valid integer value
            if (string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                !int.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Quantity cannot be empty and it must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if title was selected
            if (string.IsNullOrWhiteSpace(txtSelectedTitle.Text))
            {
                MessageBox.Show("Please select a title before proceeding.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // If all validations pass, return
            return true;
        }

        // Event handler for Search Title button click, performs title search.
        private void btnSearchTitle_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!isValidSearch())
            {
                // Invalid input, do not proceed
                return;
            }

            // Get search text
            string searchText = txtTitle.Text.Trim();

            // List to hold search results
            List<Title> results = new List<Title>();

            // Fetch matching titles from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to search titles by name
                string sql = "SELECT title_id, title, price FROM titles WHERE title LIKE @title + '%' ORDER BY title ASC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", searchText);

                try
                {
                    // Open connection and execute query
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read and add matching titles to results
                    while (reader.Read())
                    {
                        results.Add(new Title
                        {
                            // Populate title details
                            TitleID = reader["title_id"].ToString(),
                            Name = reader["title"].ToString(),
                            Price = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0
                        });
                    }
                }
                // Handle any errors that occur during data retrieval
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching titles: " + ex.Message);
                    return;
                }
            }

            // Bind only needed columns
            grdTitleSearchResult.DataSource = results.Select(t => new
            {
                t.TitleID,
                t.Name,
                t.Price
            }).ToList();

            // Set column headers for better readability
            grdTitleSearchResult.AutoResizeColumns();
        }

        // Event handler for Select Title button click, selects a title from search results.
        private void btnSelectTitle_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (grdTitleSearchResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a title first.", "Select Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row
            DataGridViewRow row = grdTitleSearchResult.SelectedRows[0];

            // Retrieve title details from the selected row
            string selectedName = row.Cells["Name"].Value.ToString();
            string selectedID = row.Cells["TitleID"].Value.ToString();
            decimal selectedPrice = Convert.ToDecimal(row.Cells["Price"].Value);

            // Display selected title details
            txtSelectedTitle.Text = selectedName;
            txtTitle.Text = selectedName;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Validate order input
            if (!isValidOrder())
                return;

            // Retrieve details for the new sale item
            string titleID = grdTitleSearchResult.SelectedRows[0].Cells["TitleID"].Value.ToString();
            string titleName = txtSelectedTitle.Text.Trim();
            int quantity = int.Parse(txtQuantity.Text);

            // Get price from selected title
            decimal price = 0;
            // Checks if a row is selected to avoid errors and convert price value
            if (grdTitleSearchResult.SelectedRows.Count > 0)
            {
                price = Convert.ToDecimal(grdTitleSearchResult.SelectedRows[0].Cells["Price"].Value);
            }

            // Create new Sales object
            Sales newSale = new Sales
            {
                TitleID = titleID,
                TitleName = titleName,
                Quantity = quantity,
                Price = price
            };

            // Add to ShoppingCart
            cart.AddItem(newSale);

            // Refresh order grid and totals display
            RefreshOrderGrid();
            UpdateTotalsDisplay();

            // Clear quantity textbox for next input
            txtQuantity.Clear();
        }

        // Refresh the order grid to display current items in the cart.
        private void RefreshOrderGrid()
        {
            // Clear existing data source
            grdCurrentOrderItem.DataSource = null;

            // Bind updated cart items to the grid with subtotal calculation
            grdCurrentOrderItem.DataSource = cart.Items.Select(s => new
            {
                s.TitleID,
                s.TitleName,
                s.Quantity,
                s.Price,
                Subtotal = s.Quantity * s.Price
            }).ToList();

            // Set column headers for better readability
            grdCurrentOrderItem.Columns[0].HeaderText = "Title";
            grdCurrentOrderItem.AutoResizeColumns();
        }

        // Update totals from ShoppingCart
        private void UpdateTotalsDisplay()
        {
            // Display subtotal, tax, and total in currency format
            txtSubtotal.Text = cart.Subtotal.ToString("C");
            txtTax.Text = cart.Tax.ToString("C");
            txtTotal.Text = cart.Total.ToString("C");
        }

        // Event handler for Update Item button click, updates quantity of selected item.
        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            // Validate order input
            if (!isValidOrder())
                return;

            // Retrieve selected title and new quantity
            string selectedTitleName = txtSelectedTitle.Text.Trim();
            int quantity = int.Parse(txtQuantity.Text);

            // Find the item in the cart by TitleName
            var item = cart.Items.FirstOrDefault(i => i.TitleName.Equals(selectedTitleName, StringComparison.OrdinalIgnoreCase));

            // If item exists, update its quantity
            if (item != null)
            {
                // Update quantity using ShoppingCart method
                Sales updatedSale = new Sales
                {
                    TitleID = item.TitleID,
                    TitleName = item.TitleName,
                    Quantity = quantity,
                    Price = item.Price
                };

                // Update item in ShoppingCart
                cart.UpdateItem(updatedSale);

                // Refresh order grid and totals display
                RefreshOrderGrid();
                UpdateTotalsDisplay();

                // Display success message
                MessageBox.Show("Quantity updated successfully.", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Clear();
            }
            // If item not found, show error message
            else
            {
                MessageBox.Show("This title is not in the current order. Please add it first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Commit Order button click, saves the order to the database.
        private void btnCommitOrder_Click(object sender, EventArgs e)
        {
            // Ensure there are items in the cart before committing
            if (cart.Items.Count == 0)
            {
                MessageBox.Show("Your order is empty. Please add items before committing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate a random 6 digit order number
            Random rnd = new Random();
            string orderNumber = rnd.Next(100000, 1000000).ToString();

            try
            {
                // Insert each item in the cart into the sales table
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Loop through each item in the cart and insert into database
                    foreach (var item in cart.Items)
                    {
                        string sql = @"
                    INSERT INTO sales (stor_id, ord_num, ord_date, qty, payterms, title_id)
                    VALUES (@stor_id, @ord_num, @ord_date, @qty, @payterms, @title_id)";

                        // Execute the insert command
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@stor_id", "8042");
                            cmd.Parameters.AddWithValue("@ord_num", orderNumber);
                            cmd.Parameters.AddWithValue("@ord_date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@qty", item.Quantity);
                            cmd.Parameters.AddWithValue("@payterms", "Net 30"); 
                            cmd.Parameters.AddWithValue("@title_id", item.TitleID); 

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                // Show success message with order number
                MessageBox.Show($"Order committed successfully! Your order number is: {orderNumber}",
                                "Order Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear cart after committing
                cart.Items.Clear();
                RefreshOrderGrid();
                UpdateTotalsDisplay();
                txtSelectedTitle.Clear();
                txtQuantity.Clear();
            }
            // Handle any errors that occur during database operations
            catch (Exception ex)
            {
                MessageBox.Show("Error committing order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Close button click, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for Clear Item button click, clears the selected title textbox.
        private void btnClearItem_Click(object sender, EventArgs e)
        {
            // Clear selected title and quantity textboxes
            txtSelectedTitle.Clear();
            txtQuantity.Clear();
        }

        // Event handler for Clear Title button click, clears the title search textbox and reloads titles.
        private void btnClearTitle_Click(object sender, EventArgs e)
        {
            // Clear title search textbox and reload titles
            txtTitle.Clear();
            LoadTitles();
            grdTitleSearchResult.ClearSelection();
        }

        // Event handler for Delete Item button click, deletes the selected item from the cart.
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            // Validate that a title is selected
            if (string.IsNullOrWhiteSpace(txtSelectedTitle.Text))
            {
                MessageBox.Show("Please select a title to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve selected title name
            string selectedTitleName = txtSelectedTitle.Text.Trim();

            // Find the item in the cart by TitleName
            var item = cart.Items.FirstOrDefault(i => i.TitleName.Equals(selectedTitleName, StringComparison.OrdinalIgnoreCase));

            // If item exists, proceed to delete
            if (item != null)
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete '{selectedTitleName}' from the order?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // If user confirms, delete the item
                if (result == DialogResult.Yes)
                {
                    // Remove from ShoppingCart
                    cart.RemoveItem(item); 
                    RefreshOrderGrid();
                    UpdateTotalsDisplay();
                    txtQuantity.Clear();
                    txtSelectedTitle.Clear();
                    MessageBox.Show("Item deleted successfully.", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // If item not found, show error message
            else
            {
                MessageBox.Show("This title is not in the current order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
