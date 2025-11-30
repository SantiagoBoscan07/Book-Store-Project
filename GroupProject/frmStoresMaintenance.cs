using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace GroupProject
{
    public partial class frmStoresMaintenance : Form
    {
        private const string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        private List<Store> stores = new List<Store>();

        public frmStoresMaintenance()
        {
            InitializeComponent();
            this.Load += frmStoresMaintenance_Load;
        }


        private void frmStoresMaintenance_Load(object sender, EventArgs e)
        {
            LoadStoresGrid();
            grdStores.SelectionChanged += grdStores_SelectionChanged;
        }

        private void grdStores_SelectionChanged(object sender, EventArgs e)
        {
            if (grdStores.CurrentRow == null || grdStores.CurrentRow.DataBoundItem == null)
                return;

            Store s = grdStores.CurrentRow.DataBoundItem as Store;
            DisplayStore(s);
        }

        private void LoadStoresGrid()
        {
            stores.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"SELECT stor_id, stor_name, stor_address, city, state, zip
                                   FROM stores
                                   ORDER BY stor_name";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Store s = new Store
                            {
                                StoreID = Convert.ToInt32(dr["stor_id"]),
                                StoreName = dr["stor_name"].ToString(),
                                StoreAddress = dr["stor_address"].ToString(),
                                StoreCity = dr["city"].ToString(),
                                StoreState = dr["state"].ToString(),
                                StoreZip = dr["zip"].ToString()
                            };
                            stores.Add(s);
                        }
                    }
                }

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

        private bool isValidInput()
        {
            string storeIdText = txtStoreID?.Text?.Trim() ?? string.Empty;
            string name = txtStoreName?.Text?.Trim() ?? string.Empty;
            string address = txtStoreAddress?.Text?.Trim() ?? string.Empty;
            string city = txtStoreCity?.Text?.Trim() ?? string.Empty;
            string state = txtStoreState?.Text?.Trim() ?? string.Empty;
            string zip = txtStoreZip?.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(storeIdText))
            {
                MessageBox.Show("Store ID is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreID?.Focus();
                return false;
            }

            if (!int.TryParse(storeIdText, out _))
            {
                MessageBox.Show("Store ID must be a valid whole number.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreID?.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Store Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreName?.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Address is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreAddress?.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("City is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreCity?.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                MessageBox.Show("State is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreState?.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(zip))
            {
                MessageBox.Show("Zip is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreZip?.Focus();
                return false;
            }

            return true;
        }

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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"INSERT INTO stores
                           (stor_id, stor_name, stor_address, city, state, zip)
                           VALUES (@id, @name, @addr, @city, @state, @zip)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", s.StoreID);
                    cmd.Parameters.AddWithValue("@name", s.StoreName);
                    cmd.Parameters.AddWithValue("@addr", s.StoreAddress);
                    cmd.Parameters.AddWithValue("@city", s.StoreCity);
                    cmd.Parameters.AddWithValue("@state", s.StoreState);
                    cmd.Parameters.AddWithValue("@zip", s.StoreZip);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Store added successfully.",
                                "Add Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStoresGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding store: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"UPDATE stores
                           SET stor_name = @name,
                               stor_address = @addr,
                               city = @city,
                               state = @state,
                               zip = @zip
                           WHERE stor_id = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", s.StoreID);
                    cmd.Parameters.AddWithValue("@name", s.StoreName);
                    cmd.Parameters.AddWithValue("@addr", s.StoreAddress);
                    cmd.Parameters.AddWithValue("@city", s.StoreCity);
                    cmd.Parameters.AddWithValue("@state", s.StoreState);
                    cmd.Parameters.AddWithValue("@zip", s.StoreZip);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Store updated successfully.",
                                "Update Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStoresGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating store: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM stores WHERE stor_id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", storeId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Store deleted successfully.",
                                "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
                LoadStoresGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting store: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void grdStores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= grdStores.Rows.Count) return;

            Store selected = grdStores.Rows[e.RowIndex].DataBoundItem as Store;
            DisplayStore(selected);
        }

        private bool StoreExists(int storeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM stores WHERE stor_id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", storeId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

    }
}