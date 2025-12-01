using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace GroupProject
{
    public static class SalesDB
    {
        // Retrieve connection string from App.config
        private static readonly string connString =
            ConfigurationManager.ConnectionStrings[
                "GroupProject.Properties.Settings.BookStoreDBConnectionString"
            ].ConnectionString;
        
        // Method to get sales report data
        public static List<Sales> GetSalesReport(string storeID, DateTime startDate, DateTime endDate)
        {
            // Initialize list to hold sales data
            List<Sales> salesList = new List<Sales>();

            // Establish database connection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // SQL query to retrieve sales data
                string sql = @"
                    SELECT
                        s.stor_id,
                        s.title_id,
                        t.title AS TitleName,
                        t.price AS Price,
                        s.qty AS Quantity,
                        s.ord_date AS OrderDate
                    FROM sales s
                    INNER JOIN titles t ON s.title_id = t.title_id
                    WHERE s.stor_id = @stor_id
                      AND s.ord_date >= @startDate
                      AND s.ord_date <= @endDate
                    ORDER BY s.ord_date ASC";

                // Prepare SQL command with parameters
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stor_id", storeID);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                // Read data and populate sales list
                while (reader.Read())
                {
                    // Create Sales object and populate properties
                    Sales sale = new Sales
                    {
                        StoreID = reader["stor_id"].ToString(),
                        TitleID = reader["title_id"].ToString(),
                        TitleName = reader["TitleName"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Price = reader["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Price"]),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"])
                    };

                    salesList.Add(sale);
                }
            }

            return salesList;
        }
    }
}
