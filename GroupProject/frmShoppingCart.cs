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
    public partial class frmShoppingCart : Form
    {
        public frmShoppingCart()
        {
            InitializeComponent();
        }

        // Method to validate user input before database operations.
        private bool isValidInput()
        {
            // Check required fields

            // Check for empty Order Num
            if (string.IsNullOrWhiteSpace(txtOrderNum.Text))
            {
                MessageBox.Show("Order Num cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Check for empty Title
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            // If all validations pass, return
            return true;
        }

        private bool isValidOrder()
        {
            // First validate general input
            if (!isValidInput())
                return false;

            // Check for empty Quantity and valid integer value
            if (string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                !int.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Quantity cannot be empty and it must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        // Event handler for Close button click, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for Add Item button click
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidOrder())
            {
                // Proceed with update operation
                MessageBox.Show("Input is valid. Proceeding with add operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for Update Item button click
        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidOrder())
            {
                // Proceed with update operation
                MessageBox.Show("Input is valid. Proceeding with update operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for Commit Order button click
        private void btnCommitOrder_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidOrder())
            {
                // Proceed with update operation
                MessageBox.Show("Input is valid. Proceeding with commit operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for Search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidInput())
            {
                // Proceed with update operation
                MessageBox.Show("Input is valid. Proceeding with search operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
