using BookStoreBO;
using BookStoreDB;
using BookStoreDO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            //  Load Employee into the DataGridView when the form loads
            LoadGrid();
            // Load publisher IDs into the combo box
            LoadPublisherIDs();
            // Attach event handler for DataGridView selection change
            grdEmployees.SelectionChanged += grdEmployees_SelectionChanged;
            cboPubID.SelectedIndex = 0;
        }

        // Method to load Employee from the database and display them in the DataGridView.
        private void LoadGrid()
        {
            // Get all employees from EmployeesDB
            List<Employee> employees = EmployeesDB.GetAllEmployees();

            // Bind to DataGridView
            grdEmployees.DataSource = employees;
            grdEmployees.ClearSelection();
        }

        // Method to load publisher IDs into the combo box.
        private void LoadPublisherIDs()
        {
            // Get all publishers from PublisherDB
            List<BookStoreDO.Publisher> publishers = PublishersDB.GetAllPublishers();

            if (publishers == null)
                publishers = new List<BookStoreDO.Publisher>();

            // Bind the publishers ID to the combo box
            cboPubID.DisplayMember = "PublisherID";
            cboPubID.ValueMember = "PublisherID";
            cboPubID.DataSource = publishers;
        }

        private bool isValidInput()
        {
            // Calls the validator method
            var (isValid, message) = Validator.ValidateEmployeeInput(txtEmpID.Text,txtEmpFirstName.Text,txtEmpLastName.Text,txtEmpMidInitial.Text,txtJobID.Text,txtJobLevel.Text,cboPubID.Text,dtpHireDate.Value);

            // Checks validation
            if (!isValid)
            {
                // Sends validation message
                MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Focus on corresponding fields
                if (message.Contains("Employee ID")) txtEmpID.Focus();
                else if (message.Contains("First name")) txtEmpFirstName.Focus();
                else if (message.Contains("Last name")) txtEmpLastName.Focus();
                else if (message.Contains("Job ID")) txtJobID.Focus();
                else if (message.Contains("Job Level")) txtJobLevel.Focus();
                else if (message.Contains("Publisher ID")) cboPubID.Focus();
                else if (message.Contains("Hire date")) dtpHireDate.Focus();

                // Fails validation
                return false;
            }

            // All validation passes
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
            // Check for validation
            if (!isValidInput()) return;

            // New employee object
            Employee newEmp = new Employee
            {
                EmployeeID = txtEmpID.Text.Trim(),
                FirstName = txtEmpFirstName.Text.Trim(),
                MiddleInitial = string.IsNullOrWhiteSpace(txtEmpMidInitial.Text) ? ' ' : txtEmpMidInitial.Text.Trim()[0],
                LastName = txtEmpLastName.Text.Trim(),
                JobID = short.Parse(txtJobID.Text.Trim()),
                JobLevel = byte.Parse(txtJobLevel.Text.Trim()),
                PublisherID = cboPubID.SelectedValue.ToString(),
                HireDate = dtpHireDate.Value
            };

            try
            {
                // Calls method to add employee to the database
                EmployeesDB.AddEmployee(newEmp);
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
                LoadGrid();
            }
            // Display errors while adding to the database
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler to update a title
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validation
            if (!isValidInput()) return;

            // Trimps Employee ID
            string empID = txtEmpID.Text.Trim();

            // Checks if employee ID exists in the database
            if (!EmployeeExists(empID))
            {
                MessageBox.Show($"Cannot update: Employee ID '{empID}' does not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Creates object to update
            Employee selectedEmp = grdEmployees.CurrentRow?.DataBoundItem as Employee;
            if (selectedEmp == null) return;

            // Gets properties of object
            selectedEmp.EmployeeID = empID;
            selectedEmp.FirstName = txtEmpFirstName.Text.Trim();
            selectedEmp.MiddleInitial = string.IsNullOrWhiteSpace(txtEmpMidInitial.Text) ? ' ' : txtEmpMidInitial.Text.Trim()[0];
            selectedEmp.LastName = txtEmpLastName.Text.Trim();
            selectedEmp.JobID = short.Parse(txtJobID.Text.Trim());
            selectedEmp.JobLevel = byte.Parse(txtJobLevel.Text.Trim());
            selectedEmp.PublisherID = cboPubID.SelectedValue.ToString();
            selectedEmp.HireDate = dtpHireDate.Value;

            // Updates the object in the database with new values
            try
            {
                EmployeesDB.UpdateEmployee(selectedEmp);
                MessageBox.Show("Employee updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
            }
            // Display error message
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear DataGridView selection
            grdEmployees.ClearSelection();

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

        // Event handler to delete en employee
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Trims employee ID
            string empID = txtEmpID.Text.Trim();
            // Checks input field for ID
            if (string.IsNullOrWhiteSpace(empID))
            {
                MessageBox.Show("Please enter an Employee ID to delete.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Checks if ID is in the database
            if (!EmployeeExists(empID))
            {
                MessageBox.Show($"Cannot delete: Employee ID '{empID}' does not exist.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (grdEmployees.CurrentRow == null || grdEmployees.CurrentRow.DataBoundItem == null) return;

            // Confirms operation with user
            if (MessageBox.Show($"Are you sure you want to delete Employee '{txtEmpFirstName.Text} {txtEmpLastName.Text}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Deletes the entry from the database
            try
            {
                EmployeesDB.DeleteEmployee(empID);
                MessageBox.Show("Employee deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
                LoadGrid();
            }
            // Display error
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for DataGridView selection change to populate input fields.
        private void grdEmployees_SelectionChanged(object sender, EventArgs e)
        {
            // Get the selected Title object
            Employee selectedEmployee = grdEmployees.CurrentRow.DataBoundItem as Employee;

            // Check if a Publisher is selected, cancel if none is selected
            if (selectedEmployee == null)
                return;

            // Populate input fields
            txtEmpID.Text = selectedEmployee.EmployeeID;
            txtEmpFirstName.Text = selectedEmployee.FirstName;
            txtEmpLastName.Text = selectedEmployee.LastName;
            txtEmpMidInitial.Text = selectedEmployee.MiddleInitial.ToString();
            txtJobID.Text = selectedEmployee.JobID.ToString() ?? "1";
            txtJobLevel.Text = selectedEmployee.JobLevel.ToString() ?? "10";
            cboPubID.Text = selectedEmployee.PublisherID ?? "9952";
            dtpHireDate.Value = selectedEmployee.HireDate != default(DateTime) ? selectedEmployee.HireDate : DateTime.Now;
        }

        // Method to check if employee exists
        private bool EmployeeExists(string empID)
        {
            // Calls method from the employees database operation
            return EmployeesDB.EmployeeExists(empID);
        }
    }
}
