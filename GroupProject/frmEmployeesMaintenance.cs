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
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Query to retrieve Employee
            string query = "SELECT emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date FROM employee";

            // Create a list to hold Employee objects
            List<Employee> employees = new List<Employee>();
            employees.Clear();

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Create and execute the SQL command
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Create a new Employee object and populate its properties
                    Employee e = new Employee()
                    {
                        EmployeeID = reader["emp_id"].ToString(),
                        FirstName = reader["fname"].ToString(),
                        LastName = reader["lname"].ToString(),
                        MiddleInitial = Convert.ToChar(reader["minit"]),
                        JobID = Convert.ToInt16(reader["job_id"]),
                        JobLevel = Convert.ToByte(reader["job_lvl"]),
                        PublisherID = reader["pub_id"].ToString(),
                        HireDate = Convert.ToDateTime(reader["hire_date"])
                    };
                    // Add the Employee object to the list
                    employees.Add(e);
                    grdEmployees.ClearSelection();
                }
            }

            // Bind the list to the DataGridView
            grdEmployees.DataSource = employees;
        }

        // Method to load publisher IDs into the combo box.
        private void LoadPublisherIDs()
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
            // SQL Query to retrieve publishers
            string query = "SELECT pub_id, pub_name, city, state, country FROM publishers";

            // Create a list to hold Publisher objects
            List<Publisher> publishers = new List<Publisher>();

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Create and execute the SQL command
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Create a new Publisher object and populate its properties
                    Publisher p = new Publisher
                    {
                        PublisherID = reader["pub_id"].ToString(),
                        PublisherName = reader["pub_name"] == DBNull.Value ? null : reader["pub_name"].ToString(),
                        City = reader["city"] == DBNull.Value ? null : reader["city"].ToString(),
                        State = reader["state"] == DBNull.Value ? null : reader["state"].ToString(),
                        Country = reader["country"] == DBNull.Value ? "USA" : reader["country"].ToString()
                    };
                    // Add the Publisher object to the list
                    publishers.Add(p);
                }
            }

            // Bind the publishers ID to the combo box
            cboPubID.DisplayMember = "PublisherID";
            cboPubID.ValueMember = "PublisherID";
            cboPubID.DataSource = publishers;
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
            // Validate input fields
            if (!isValidInput())
                return;

            // Employee object to hold new employee data
            Employee newEmp = new Employee
            {
                // Populate properties from input fields
                EmployeeID = txtEmpID.Text.Trim(),
                FirstName = txtEmpFirstName.Text.Trim(),
                MiddleInitial = string.IsNullOrWhiteSpace(txtEmpMidInitial.Text)
                                ? ' ' : txtEmpMidInitial.Text.Trim()[0],
                LastName = txtEmpLastName.Text.Trim(),
                JobID = short.Parse(txtJobID.Text.Trim()),
                JobLevel = byte.Parse(txtJobLevel.Text.Trim()),
                PublisherID = cboPubID.SelectedValue.ToString(),
                HireDate = dtpHireDate.Value
            };

            try
            {
                // Check if Employee ID already exists
                AddEmployeeToDatabase(newEmp);

                // Update DataGridView with new employee
                List<Employee> currentEmployees = grdEmployees.DataSource as List<Employee>;
                if (currentEmployees == null)
                    currentEmployees = new List<Employee>();

                // Add the new employee to the list
                currentEmployees.Add(newEmp);

                // Refresh the DataGridView
                grdEmployees.DataSource = null;
                grdEmployees.DataSource = currentEmployees;

                // Show success message
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(null, null);
            }
            // Handle any exceptions that occur during the database operation
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reload the DataGridView to reflect changes
            LoadGrid();
        }

        // Event handler to update a title
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (!isValidInput())
                return;

            // Get Employee ID from input field
            string empID = txtEmpID.Text.Trim();

            // Check if Employee ID exists in the database
            if (!EmployeeExists(empID))
            {
                MessageBox.Show($"Cannot update: Employee ID '{empID}' does not exist in the database.",
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a row is selected in the DataGridView
            if (grdEmployees.CurrentRow == null || grdEmployees.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected Employee object
            Employee selectedEmp = grdEmployees.CurrentRow.DataBoundItem as Employee;

            // Update properties from input fields
            selectedEmp.EmployeeID = txtEmpID.Text.Trim();
            selectedEmp.FirstName = txtEmpFirstName.Text.Trim();
            selectedEmp.MiddleInitial = string.IsNullOrWhiteSpace(txtEmpMidInitial.Text)
                                        ? ' ' : txtEmpMidInitial.Text.Trim()[0];
            selectedEmp.LastName = txtEmpLastName.Text.Trim();
            selectedEmp.JobID = short.Parse(txtJobID.Text.Trim());
            selectedEmp.JobLevel = byte.Parse(txtJobLevel.Text.Trim());
            selectedEmp.PublisherID = cboPubID.SelectedValue.ToString();
            selectedEmp.HireDate = dtpHireDate.Value;

            // Attempt to update the employee in the database
            try
            {
                //  Update the employee in the database
                UpdateEmployeeInDatabase(selectedEmp);

                // Refresh the DataGridView to reflect changes
                List<Employee> employees = grdEmployees.DataSource as List<Employee>;
                grdEmployees.DataSource = null;
                grdEmployees.DataSource = employees;

                // Show success message
                MessageBox.Show("Employee updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Handle any exceptions that occur during the database operation
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
            // Get Employee ID from input field
            string empID = txtEmpID.Text.Trim();

            // Validate Employee ID input
            if (string.IsNullOrWhiteSpace(empID))
            {
                MessageBox.Show("Please enter an Employee ID to delete.", "Delete Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if Employee ID exists in the database
            if (!EmployeeExists(empID))
            {
                MessageBox.Show($"Cannot delete: Employee ID '{empID}' does not exist in the database.",
                                "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a row is selected in the DataGridView
            if (grdEmployees.CurrentRow == null || grdEmployees.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("No entry selected to delete.", "Delete Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion with the user
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete Employee '{txtEmpFirstName.Text} {txtEmpLastName.Text}' (ID: {empID})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // If user selects No, cancel deletion
            if (result != DialogResult.Yes)
                return;

            // Attempt to delete the employee from the database
            try
            {
                // Connection string to the BookStoreDB database
                string connectionString = ConfigurationManager
                    .ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"]
                    .ConnectionString;

                // Open a connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM employee WHERE emp_id = @EmpID";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@EmpID", empID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Show success message
                MessageBox.Show("Employee deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields and reload DataGridView
                btnClear_Click(null, null);
                LoadGrid();
            }
            // Handle any exceptions that occur during the database operation
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

        // Method to check if an Employee ID exists in the database.
        private bool EmployeeExists(string empID)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager
                .ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"]
                .ConnectionString;

            // SQL Query to check for Employee ID existence
            string query = "SELECT COUNT(*) FROM employee WHERE emp_id = @EmpID";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            // Create and execute the SQL command
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Add parameter to prevent SQL injection
                cmd.Parameters.AddWithValue("@EmpID", empID);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Method to add a new Employee to the database.
        private void AddEmployeeToDatabase(Employee emp)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager
                .ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"]
                .ConnectionString;

            // SQL Insert query to add a new Employee
            string insertQuery = @"INSERT INTO employee
                           (emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date)
                           VALUES
                           (@EmpID, @FirstName, @Minit, @LastName, @JobID, @JobLevel, @PubID, @HireDate)";

            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            // Create and execute the SQL command
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@EmpID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@Minit",
                    string.IsNullOrWhiteSpace(emp.MiddleInitial.ToString()) ? (object)DBNull.Value : emp.MiddleInitial);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@JobID", emp.JobID);
                cmd.Parameters.AddWithValue("@JobLevel", emp.JobLevel);
                cmd.Parameters.AddWithValue("@PubID", emp.PublisherID);
                cmd.Parameters.AddWithValue("@HireDate", emp.HireDate);
                // Open the connection and execute the insert command
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update an existing Employee in the database.
        private void UpdateEmployeeInDatabase(Employee emp)
        {
            // Connection string to the BookStoreDB database
            string connectionString = ConfigurationManager
                .ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"]
                .ConnectionString;
            // SQL Update query to modify an existing Employee
            string updateQuery = @"UPDATE employee
                           SET fname = @FirstName,
                               minit = @Minit,
                               lname = @LastName,
                               job_id = @JobID,
                               job_lvl = @JobLevel,
                               pub_id = @PubID,
                               hire_date = @HireDate
                           WHERE emp_id = @EmpID";
            // Open a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@EmpID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@Minit",
                    string.IsNullOrWhiteSpace(emp.MiddleInitial.ToString()) ? (object)DBNull.Value : emp.MiddleInitial);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@JobID", emp.JobID);
                cmd.Parameters.AddWithValue("@JobLevel", emp.JobLevel);
                cmd.Parameters.AddWithValue("@PubID", emp.PublisherID);
                cmd.Parameters.AddWithValue("@HireDate", emp.HireDate);
                // Open the connection and execute the update command
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
