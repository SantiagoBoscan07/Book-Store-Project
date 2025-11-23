using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class frmStoresMaintenance : Form
    {
        public frmStoresMaintenance()
        {
            InitializeComponent();
        }

        // Event handler for the Close button click event, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isValidInput()
        {
            // Read and trim inputs
            string storeIdText = txtStoreID?.Text?.Trim() ?? string.Empty;

            // Validate that storeID is provided
            if (string.IsNullOrEmpty(storeIdText))
            {
                MessageBox.Show("Store ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreID?.Focus();
                return false;
            }

            // Validate that storeID is an integer
            if (!int.TryParse(storeIdText, out int storeId))
            {
                MessageBox.Show("Store ID must be a valid whole number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreID?.Focus();
                return false;
            }

            // Returns true if all validations pass
            return true;    
        }

        // Event handler to add a title
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidInput())
            {
                // Proceed with add operation
                MessageBox.Show("Input is valid. Proceeding with add operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler to update a title
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidInput())
            {
                // Proceed with update operation
                MessageBox.Show("Input is valid. Proceeding with update operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear input fields
            txtStoreID.Clear();
            txtStoreName.Clear();
            txtStoreAddress.Clear();
            txtStoreCity.Clear();
            txtStoreState.Clear();
            txtStoreZip.Clear();
        }
    }
}
