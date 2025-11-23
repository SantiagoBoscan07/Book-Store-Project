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
    public partial class frmAuthorMaintenance : Form
    {
        public frmAuthorMaintenance()
        {
            InitializeComponent();
        }

        // Method to validate user input before database operations.
        private bool isValidInput()
        {
            // Trim all inputs
            string firstName = txtAuthorFirstName.Text.Trim();
            string lastName = txtAuthorLastName.Text.Trim();

            // Check required field author ID
            if (!txtAuthorID.MaskFull)
            {
                MessageBox.Show("Author ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required field first name
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required field last name
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required field phone number
            if (!txtAuthorPhoneNumber.MaskFull)
            {
                MessageBox.Show("Phone number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check required radio buttons selection for contracted status
            if (!rdoAuthorContracted.Checked && !rdoAuthorNotContracted.Checked)
            {
                MessageBox.Show("Please select Contracted or Not Contracted.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Return if all inputs are valid
            return true;
        }

        // Event handler for the add button click, validates input before proceeding.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidInput())
            {
                // Proceed with add operation
                MessageBox.Show("Input is valid. Proceeding with add operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Event handler for Close button click, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for Update button click, validates input before proceeding.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Input validation
            if (isValidInput())
            {
                // Proceed with update operation
                MessageBox.Show("Input is valid. Proceeding with update operation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for Clear button click, clears all input fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear TextBoxes
            txtAuthorID.Clear();
            txtAuthorFirstName.Clear();
            txtAuthorLastName.Clear();
            txtAuthorPhoneNumber.Clear();   
            txtAuthorAddress.Clear();
            txtAuthorCity.Clear();
            txtAuthorState.Clear();
            txtAuthorZip.Clear();

            // Clear Radio Buttons Selection
            rdoAuthorContracted.Checked = false;
            rdoAuthorNotContracted.Checked = false;
        }
    }
}
