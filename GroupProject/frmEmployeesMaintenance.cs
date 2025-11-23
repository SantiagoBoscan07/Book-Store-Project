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
    public partial class frmEmployeesMaintenance : Form
    {
        public frmEmployeesMaintenance()
        {
            InitializeComponent();
            cboPubID.SelectedIndex = 0;
        }

        private bool isValidInput()
        {
            // Retrieve input values and trim whitespace
            string empId = txtEmpID.Text.Trim();
            string firstName = txtEmpFirstName.Text.Trim();
            string lastName = txtEmpLastName.Text.Trim();
            string jobIdText = txtJobID.Text.Trim();
            string jobLevelText = txtJobLevel.Text.Trim();
            string pubId = cboPubID.Text.Trim(); 
            DateTime hireDate = dtpHireDate.Value;

            // Validate Employee ID
            if (string.IsNullOrWhiteSpace(empId))
            {
                MessageBox.Show("Employee ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check for valid Employee ID patterns
            bool empPattern1 = Regex.IsMatch(empId, @"^[A-Z]{3}[1-9][0-9]{4}[FM]$");
            bool empPattern2 = Regex.IsMatch(empId, @"^[A-Z]-[A-Z][1-9][0-9]{4}[FM]$");

            // If neither pattern matches, show error
            if (!empPattern1 && !empPattern2)
            {
                MessageBox.Show("Employee ID format is invalid.\nValid patterns:\nABC12345F or A-B12345F", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate First Name
            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Last name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Job ID
            if (string.IsNullOrWhiteSpace(jobIdText))
            {
                MessageBox.Show("Job ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if Job ID is a valid short integer
            if (!short.TryParse(jobIdText, out short jobId))
            {
                MessageBox.Show("Job ID must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Job Level if provided
            if (!string.IsNullOrWhiteSpace(jobLevelText))
            {
                if (!byte.TryParse(jobLevelText, out byte jobLvl))
                {
                    MessageBox.Show("Job Level must be a valid number (0–255).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // If all validations pass, return true
            return true;
        }

        // Event handler for the Close button click event, closes the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            // Clear all input fields
            txtEmpID.Clear();
            txtEmpFirstName.Clear();
            txtEmpLastName.Clear();
            txtEmpMidInitial.Clear();
            txtJobID.Clear();
            txtJobLevel.Clear();

            // Set PubID combo box to default selection
            cboPubID.SelectedIndex = 0;

            // Clear date picker (set to current date)
            dtpHireDate.Value = DateTime.Now;
        }
    }
}
