using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using BookStoreBO;

namespace BookStoreDO
{
    public static class AuthorsDB
    {
        // Connection string from configuration
        private static readonly string connString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

        // Method to get all authors
        public static List<Author> GetAllAuthors()
        {
            // Create list to hold authors
            List<Author> list = new List<Author>();

            // SQL query to select all authors
            string sql = "SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors";

            // Execute query and read results
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                // Read each record and add to list
                while (reader.Read())
                {
                    list.Add(new Author
                    {
                        AuthorID = reader["au_id"].ToString().Trim(),
                        AuthorLastName = reader["au_lname"].ToString().Trim(),
                        AuthorFirstName = reader["au_fname"].ToString().Trim(),
                        Phone = reader["phone"].ToString().Trim(),
                        Address = reader["address"]?.ToString().Trim(),
                        City = reader["city"]?.ToString().Trim(),
                        State = reader["state"]?.ToString().Trim(),
                        Zip = reader["zip"]?.ToString().Trim(),
                        isContracted = (bool)reader["contract"]
                    });
                }
            }
            // Return the list of authors
            return list;
        }

        // Method to check if author exists
        public static bool AuthorExists(string authorID)
        {
            // SQL query to count authors with given ID
            string sql = "SELECT COUNT(*) FROM authors WHERE au_id = @ID";

            // Execute query to check existence
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", authorID);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Method to add a new author
        public static void AddAuthor(Author a)
        {
            // Clean and validate inputs
            string cleanedZip = a.Zip?.Trim().Replace("_", "");

            // Validate ZIP against DB constraints
            if (!string.IsNullOrWhiteSpace(cleanedZip) && !System.Text.RegularExpressions.Regex.IsMatch(cleanedZip, @"^\d{5}$"))
                throw new Exception("ZIP must be 5 digits");

            // SQL insert statement
            string sql = @"INSERT INTO authors
                        (au_id, au_lname, au_fname, phone, address, city, state, zip, contract)
                        VALUES (@ID, @LName, @FName, @Phone, @Address, @City, @State, @Zip, @Contract)";

            // Execute insert command
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Add parameters with cleaned values
                cmd.Parameters.AddWithValue("@ID", a.AuthorID.Trim());
                cmd.Parameters.AddWithValue("@LName", a.AuthorLastName.Trim());
                cmd.Parameters.AddWithValue("@FName", a.AuthorFirstName.Trim());
                cmd.Parameters.AddWithValue("@Phone", a.Phone.Trim());
                cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(a.Address) ? (object)DBNull.Value : a.Address.Trim());
                cmd.Parameters.AddWithValue("@City", string.IsNullOrWhiteSpace(a.City) ? (object)DBNull.Value : a.City.Trim());
                cmd.Parameters.AddWithValue("@State", string.IsNullOrWhiteSpace(a.State) ? (object)DBNull.Value : a.State.Trim());
                cmd.Parameters.AddWithValue("@Zip", string.IsNullOrWhiteSpace(cleanedZip) ? (object)DBNull.Value : cleanedZip);
                cmd.Parameters.AddWithValue("@Contract", a.isContracted);
                // Open connection and execute
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update an existing author
        public static void UpdateAuthor(Author a)
        {
            // Clean and validate inputs
            string cleanedZip = a.Zip?.Trim().Replace("_", "");

            // Validate ID and ZIP against DB constraints
            if (!string.IsNullOrWhiteSpace(cleanedZip) && !System.Text.RegularExpressions.Regex.IsMatch(cleanedZip, @"^\d{5}$"))
                throw new Exception("ZIP must be 5 digits");

            // Clean author ID
            string sql = @"UPDATE authors SET
                        au_lname = @LName,
                        au_fname = @FName,
                        phone = @Phone,
                        address = @Address,
                        city = @City,
                        state = @State,
                        zip = @Zip,
                        contract = @Contract
                        WHERE au_id = @ID";

            // Execute update command
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Add parameters with cleaned values
                cmd.Parameters.AddWithValue("@ID", a.AuthorID.Trim());
                cmd.Parameters.AddWithValue("@LName", a.AuthorLastName.Trim());
                cmd.Parameters.AddWithValue("@FName", a.AuthorFirstName.Trim());
                cmd.Parameters.AddWithValue("@Phone", a.Phone.Trim());
                cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(a.Address) ? (object)DBNull.Value : a.Address.Trim());
                cmd.Parameters.AddWithValue("@City", string.IsNullOrWhiteSpace(a.City) ? (object)DBNull.Value : a.City.Trim());
                cmd.Parameters.AddWithValue("@State", string.IsNullOrWhiteSpace(a.State) ? (object)DBNull.Value : a.State.Trim());
                cmd.Parameters.AddWithValue("@Zip", string.IsNullOrWhiteSpace(cleanedZip) ? (object)DBNull.Value : cleanedZip);
                cmd.Parameters.AddWithValue("@Contract", a.isContracted);
                // Open connection and execute
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete an author
        public static void DeleteAuthor(string authorID)
        {
            // Clean author ID
            string cleanedID = authorID?.Trim().Replace("_", "");
            string sql = "DELETE FROM authors WHERE au_id = @ID";

            // Execute delete command
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", cleanedID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
