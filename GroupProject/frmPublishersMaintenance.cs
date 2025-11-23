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
            cboPublisherCountry.SelectedIndex = 0;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidInput())
            {
                // Proceed with add operation
                MessageBox.Show("Input is valid. Proceeding with add operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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
            // Clear all input fields
            txtPublisherID.Clear();
            txtPublisherName.Clear();
            txtPublisherCity.Clear();
            txtPublisherState.Clear();

            // Set value of Publisher Country to Default Value "USA"
            cboPublisherCountry.SelectedIndex = 0;
        }
    }
}
