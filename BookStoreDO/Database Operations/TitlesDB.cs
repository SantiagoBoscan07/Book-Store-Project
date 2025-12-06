using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using BookStoreBO;

namespace BookStoreDO
{
    public static class TitlesDB
    {
        // Connection string
        private static readonly string connString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

        // Method to get all titles
        public static List<Title> GetAllTitles()
        {
            // Creates list to hold titles
            List<Title> list = new List<Title>();
            // String for query
            string sql = "SELECT title_id, title, type, pub_id, price, notes, pubdate FROM titles";

            // Connects to sql
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Adds elements to title object
                    list.Add(new Title
                    {
                        TitleID = reader["title_id"].ToString().Trim(),
                        Name = reader["title"].ToString().Trim(),
                        Type = reader["type"].ToString().Trim(),
                        PublisherID = reader["pub_id"]?.ToString().Trim(),
                        Price = reader["price"] == DBNull.Value ? null : (decimal?)reader["price"],
                        Notes = reader["notes"]?.ToString(),
                        PublishedDate = (DateTime)reader["pubdate"]
                    });
                }
            }
            return list;
        }

        // Method to check if a title exists
        public static bool TitleExists(string titleID)
        {
            // Trims ID
            string cleanedID = titleID?.Trim();
            // Gets all titles
            string sql = "SELECT COUNT(*) FROM titles WHERE title_id = @TitleID";

            // Connects to sql
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TitleID", cleanedID);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Method to add a new title
        public static void AddTitle(Title t)
        {
            // sql query string
            string sql = @"INSERT INTO titles
                           (title_id, title, type, pub_id, price, notes, pubdate)
                           VALUES (@TitleID, @Title, @Type, @PubID, @Price, @Notes, @PubDate)";

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Adds properties to the title object
                cmd.Parameters.AddWithValue("@TitleID", t.TitleID.Trim());
                cmd.Parameters.AddWithValue("@Title", t.Name.Trim());
                cmd.Parameters.AddWithValue("@Type", t.Type?.Trim() ?? "UNDECIDED");
                cmd.Parameters.AddWithValue("@PubID", string.IsNullOrWhiteSpace(t.PublisherID) ? (object)DBNull.Value : t.PublisherID.Trim());
                cmd.Parameters.AddWithValue("@Price", t.Price.HasValue ? (object)t.Price.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(t.Notes) ? (object)DBNull.Value : t.Notes.Trim());
                cmd.Parameters.AddWithValue("@PubDate", t.PublishedDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update an existing title
        public static void UpdateTitle(Title t)
        {
            // sql query
            string sql = @"UPDATE titles SET
                               title = @Title,
                               type = @Type,
                               pub_id = @PubID,
                               price = @Price,
                               notes = @Notes,
                               pubdate = @PubDate
                           WHERE title_id = @TitleID";

            // Connects to sql
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Properties for the title object
                cmd.Parameters.AddWithValue("@TitleID", t.TitleID.Trim());
                cmd.Parameters.AddWithValue("@Title", t.Name.Trim());
                cmd.Parameters.AddWithValue("@Type", t.Type?.Trim() ?? "UNDECIDED");
                cmd.Parameters.AddWithValue("@PubID", string.IsNullOrWhiteSpace(t.PublisherID) ? (object)DBNull.Value : t.PublisherID.Trim());
                cmd.Parameters.AddWithValue("@Price", t.Price.HasValue ? (object)t.Price.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(t.Notes) ? (object)DBNull.Value : t.Notes.Trim());
                cmd.Parameters.AddWithValue("@PubDate", t.PublishedDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete a title
        public static void DeleteTitle(string titleID)
        {
            // Trims ID
            string cleanedID = titleID?.Trim();
            // sql query string
            string sql = "DELETE FROM titles WHERE title_id = @TitleID";

            // connects to sql and performs delete query
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TitleID", cleanedID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
