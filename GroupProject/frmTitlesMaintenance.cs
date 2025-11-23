using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace GroupProject
{
    public partial class frmTitlesMaintenance : Form
    {
        public frmTitlesMaintenance()
        {
            InitializeComponent();
            cboType.SelectedIndex = 0;
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

            // Validate TitleID (required, integer)
            if (string.IsNullOrEmpty(titleIdText))
            {
                MessageBox.Show("Title ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitleID?.Focus();
                return false;
            }

            if (!int.TryParse(titleIdText, NumberStyles.Integer, CultureInfo.CurrentCulture, out int titleId))
            {
                MessageBox.Show("Title ID must be a valid whole number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Event handler to clear all input fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
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
    }
}
