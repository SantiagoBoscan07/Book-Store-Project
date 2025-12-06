using Microsoft.Data.SqlClient;
using BookStoreDO;

namespace GroupProject
{
    public static class SalesDB
    {

        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings[
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
                        s.ord_num,
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
                        OrderID = reader["ord_num"].ToString(),
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

        // Method to get the last order number from sales table
        public static string GetLastOrderNumber()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT MAX(ord_num) FROM sales";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result == DBNull.Value || result == null)
                    return "0000"; 
                else
                    return result.ToString();
            }
        }

        // Method to generate next order number
        public static string GenerateNextOrderNumber()
        {
            string lastOrder = GetLastOrderNumber();

            // Convert to integer and add 1
            int nextOrderInt = int.Parse(lastOrder) + 1;

            // Return zero padded 4 digit string
            return nextOrderInt.ToString("D4"); 
        }
    }
}
