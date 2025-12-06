using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using BookStoreBO;

namespace BookStoreDO
{
    public static class PublishersDB
    {
        // Connection string from configuration
        private static readonly string connString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
        
        // Method to get all publishers
        public static List<Publisher> GetAllPublishers()
        {
            // List to hold all publishers
            List<Publisher> list = new List<Publisher>();
            // sql query string
            string sql = "SELECT pub_id, pub_name, city, state, country FROM publishers";

            // Connect and perform query
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Add publisher to list
                    list.Add(new Publisher
                    {
                        PublisherID = reader["pub_id"].ToString(),
                        PublisherName = reader["pub_name"] == DBNull.Value ? null : reader["pub_name"].ToString(),
                        City = reader["city"] == DBNull.Value ? null : reader["city"].ToString(),
                        State = reader["state"] == DBNull.Value ? null : reader["state"].ToString(),
                        Country = reader["country"] == DBNull.Value ? "USA" : reader["country"].ToString()
                    });
                }
            }
            
            // Return list of publisher
            return list;
        }

        // Method to check if publisher exists
        public static bool PublisherExists(string pubID)
        {
            // sql query string
            string sql = "SELECT COUNT(*) FROM publishers WHERE pub_id = @PubID";
            // Connect and perform query
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PubID", pubID);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Method to add publisher
        public static void AddPublisher(Publisher p)
        {
            // sql query string
            string sql = @"INSERT INTO publishers
                           (pub_id, pub_name, city, state, country)
                           VALUES
                           (@PubID, @Name, @City, @State, @Country)";

            // Connect and perform query
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Add publisher with parameters
                cmd.Parameters.AddWithValue("@PubID", p.PublisherID);
                cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(p.PublisherName) ? (object)DBNull.Value : p.PublisherName);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(p.City) ? (object)DBNull.Value : p.City);
                cmd.Parameters.AddWithValue("@State", string.IsNullOrEmpty(p.State) ? (object)DBNull.Value : p.State);
                cmd.Parameters.AddWithValue("@Country", string.IsNullOrEmpty(p.Country) ? (object)DBNull.Value : p.Country);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update an existing publisher
        public static void UpdatePublisher(Publisher p)
        {
            // sql query string
            string sql = @"UPDATE publishers
                           SET pub_name = @Name,
                               city = @City,
                               state = @State,
                               country = @Country
                           WHERE pub_id = @PubID";

            // Connect and perform query
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Update publisher with parameters
                cmd.Parameters.AddWithValue("@PubID", p.PublisherID);
                cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(p.PublisherName) ? (object)DBNull.Value : p.PublisherName);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(p.City) ? (object)DBNull.Value : p.City);
                cmd.Parameters.AddWithValue("@State", string.IsNullOrEmpty(p.State) ? (object)DBNull.Value : p.State);
                cmd.Parameters.AddWithValue("@Country", string.IsNullOrEmpty(p.Country) ? (object)DBNull.Value : p.Country);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete a publisher
        public static void DeletePublisher(string pubID)
        {
            // sql query string
            string sql = "DELETE FROM publishers WHERE pub_id = @PubID";
            // Connect and perform query
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PubID", pubID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
