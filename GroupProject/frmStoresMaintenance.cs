using BookStoreBO;
using BookStoreDO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class frmStoresMaintenance : Form
    {
        // Connection string to the local SQL Server database
        private const string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        // List to hold store records
        private List<Store> stores = new List<Store>();

        public frmStoresMaintenance()
        {
            InitializeComponent();
            // Event handler for form load
            this.Load += frmStoresMaintenance_Load;
        }

        // Event handler for form load
        private void frmStoresMaintenance_Load(object sender, EventArgs e)
        {
            LoadStoresGrid();
            grdStores.SelectionChanged += grdStores_SelectionChanged;

            // Select the firts row and display information on input fields if the grid has rows
            if (grdStores.Rows.Count > 0)
            {
                grdStores.Rows[0].Selected = true;
                Store firstStore = grdStores.Rows[0].DataBoundItem as Store;
                DisplayStore(firstStore);
            }
        }

        // Event handler for grid selection change
        private void grdStores_SelectionChanged(object sender, EventArgs e)
        {
            if (grdStores.CurrentRow == null || grdStores.CurrentRow.DataBoundItem == null)
                return;

            Store s = grdStores.CurrentRow.DataBoundItem as Store;
            DisplayStore(s);
        }

        // Method to load stores into the grid
        private void LoadStoresGrid()
        {
            try
            {
                stores = StoresDB.GetAllStores();
                grdStores.DataSource = null;
                grdStores.AutoGenerateColumns = true;
                grdStores.DataSource = stores;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stores: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Method to clear input fields
        private void ClearInputs()
        {
            txtStoreID.Clear();
            txtStoreName.Clear();
            txtStoreAddress.Clear();
            txtStoreCity.Clear();
            txtStoreState.Clear();
            txtStoreZip.Clear();
            txtStoreID.Focus();
        }

        // Method to validate user input
        private bool isValidInput()
        {
            var (isValid, message) = Validator.ValidateStoreInput(txtStoreID.Text,txtStoreName.Text,txtStoreAddress.Text,txtStoreCity.Text,txtStoreState.Text,txtStoreZip.Text);

            if (!isValid)
            {
                // Display validation message
                MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Focus the field based on message
                if (message.Contains("Store ID")) txtStoreID.Focus();
                else if (message.Contains("Store Name")) txtStoreName.Focus();
                else if (message.Contains("Address")) txtStoreAddress.Focus();
                else if (message.Contains("City")) txtStoreCity.Focus();
                else if (message.Contains("State")) txtStoreState.Focus();
                else if (message.Contains("ZIP")) txtStoreZip.Focus();

                // Return if failed validation
                return false;
            }

            // Return if all inputs are valid
            return true;
        }

        // Method to build a Store object from form inputs
        private Store BuildStoreFromForm()
        {
            return new Store
            {
                StoreID = int.Parse(txtStoreID.Text.Trim()),
                StoreName = txtStoreName.Text.Trim(),
                StoreAddress = txtStoreAddress.Text.Trim(),
                StoreCity = txtStoreCity.Text.Trim(),
                StoreState = txtStoreState.Text.Trim(),
                StoreZip = txtStoreZip.Text.Trim()
            };
        }

        // Method to display store details in the form
        private void DisplayStore(Store s)
        {
            if (s == null) return;

            txtStoreID.Text = s.StoreID.ToString();
            txtStoreName.Text = s.StoreName;
            txtStoreAddress.Text = s.StoreAddress;
            txtStoreCity.Text = s.StoreCity;
            txtStoreState.Text = s.StoreState;
            txtStoreZip.Text = s.StoreZip;
        }


        // Event handler for Close button click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for Clear button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        // Event handler for Add button click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isValidInput()) return;

            Store s = BuildStoreFromForm();

            if (StoreExists(s.StoreID))
            {
                MessageBox.Show($"Store ID {s.StoreID} already exists.",
                                "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                StoresDB.AddStore(s); 
                MessageBox.Show("Store added successfully.", "Add Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStoresGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding store: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Update button click
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isValidInput()) return;

            Store s = BuildStoreFromForm();

            if (!StoreExists(s.StoreID))
            {
                MessageBox.Show($"Cannot update: Store ID {s.StoreID} does not exist.",
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                StoresDB.UpdateStore(s); 
                MessageBox.Show("Store updated successfully.", "Update Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStoresGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating store: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Event handler for Delete button click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStoreID.Text))
            {
                MessageBox.Show("Please enter a Store ID to delete.",
                                "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStoreID.Text.Trim(), out int storeId))
            {
                MessageBox.Show("Store ID must be a valid number.",
                                "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!StoreExists(storeId))
            {
                MessageBox.Show($"Cannot delete: Store ID {storeId} does not exist.",
                                "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (grdStores.CurrentRow == null || grdStores.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to delete.",
                                "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Are you sure you want to delete Store {storeId}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                StoresDB.DeleteStore(storeId); 
                MessageBox.Show("Store deleted successfully.", "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadStoresGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting store: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for grid cell content click
        private void grdStores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= grdStores.Rows.Count) return;

            Store selected = grdStores.Rows[e.RowIndex].DataBoundItem as Store;
            DisplayStore(selected);
        }

        // Method to check if a store exists by Store ID
        private bool StoreExists(int storeId)
        {
            return StoresDB.StoreExists(storeId);
        }

    }
}