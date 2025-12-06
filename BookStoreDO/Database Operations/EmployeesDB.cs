using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using BookStoreDO;

namespace BookStoreDB
{
    public static class EmployeesDB
    {
        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

        // Method to get all employees
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string query = "SELECT emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date FROM employee";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee e = new Employee
                        {
                            EmployeeID = reader["emp_id"].ToString(),
                            FirstName = reader["fname"].ToString(),
                            MiddleInitial = reader["minit"] != DBNull.Value ? Convert.ToChar(reader["minit"]) : ' ',
                            LastName = reader["lname"].ToString(),
                            JobID = Convert.ToInt16(reader["job_id"]),
                            JobLevel = Convert.ToByte(reader["job_lvl"]),
                            PublisherID = reader["pub_id"].ToString(),
                            HireDate = Convert.ToDateTime(reader["hire_date"])
                        };
                        employees.Add(e);
                    }
                }
            }
            return employees;
        }

        // Method to check if employee exists
        public static bool EmployeeExists(string empID)
        {
            string query = "SELECT COUNT(*) FROM employee WHERE emp_id = @EmpID";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", empID);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Method to add a new employee
        public static void AddEmployee(Employee emp)
        {
            string insertQuery = @"INSERT INTO employee
                                   (emp_id, fname, minit, lname, job_id, job_lvl, pub_id, hire_date)
                                   VALUES
                                   (@EmpID, @FirstName, @Minit, @LastName, @JobID, @JobLevel, @PubID, @HireDate)";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@Minit", string.IsNullOrWhiteSpace(emp.MiddleInitial.ToString()) ? (object)DBNull.Value : emp.MiddleInitial);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@JobID", emp.JobID);
                cmd.Parameters.AddWithValue("@JobLevel", emp.JobLevel);
                cmd.Parameters.AddWithValue("@PubID", emp.PublisherID);
                cmd.Parameters.AddWithValue("@HireDate", emp.HireDate.Date);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update an existing employee
        public static void UpdateEmployee(Employee emp)
        {
            string updateQuery = @"UPDATE employee
                                   SET fname = @FirstName,
                                       minit = @Minit,
                                       lname = @LastName,
                                       job_id = @JobID,
                                       job_lvl = @JobLevel,
                                       pub_id = @PubID,
                                       hire_date = @HireDate
                                   WHERE emp_id = @EmpID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@Minit", string.IsNullOrWhiteSpace(emp.MiddleInitial.ToString()) ? (object)DBNull.Value : emp.MiddleInitial);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@JobID", emp.JobID);
                cmd.Parameters.AddWithValue("@JobLevel", emp.JobLevel);
                cmd.Parameters.AddWithValue("@PubID", emp.PublisherID);
                cmd.Parameters.AddWithValue("@HireDate", emp.HireDate.Date);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete an employee
        public static void DeleteEmployee(string empID)
        {
            string deleteQuery = "DELETE FROM employee WHERE emp_id = @EmpID";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
            {
                cmd.Parameters.AddWithValue("@EmpID", empID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
