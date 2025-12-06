using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using BookStoreDO;

namespace BookStoreBO
{
    public static class StoresDB
    {
        // Connection string to the local SQL Server database
        private const string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        // Get all stores
        public static List<Store> GetAllStores()
        {
            List<Store> stores = new List<Store>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"SELECT stor_id, stor_name, stor_address, city, state, zip
                                   FROM stores
                                   ORDER BY stor_name";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Store s = new Store
                            {
                                StoreID = Convert.ToInt32(dr["stor_id"]),
                                StoreName = dr["stor_name"].ToString(),
                                StoreAddress = dr["stor_address"].ToString(),
                                StoreCity = dr["city"].ToString(),
                                StoreState = dr["state"].ToString(),
                                StoreZip = dr["zip"].ToString()
                            };
                            stores.Add(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving stores: " + ex.Message);
            }

            return stores;
        }

        // Check if a store exists by ID
        public static bool StoreExists(int storeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM stores WHERE stor_id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", storeId);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Add a new store
        public static void AddStore(Store s)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO stores
                               (stor_id, stor_name, stor_address, city, state, zip)
                               VALUES (@id, @name, @addr, @city, @state, @zip)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", s.StoreID);
                    cmd.Parameters.AddWithValue("@name", s.StoreName);
                    cmd.Parameters.AddWithValue("@addr", s.StoreAddress);
                    cmd.Parameters.AddWithValue("@city", s.StoreCity);
                    cmd.Parameters.AddWithValue("@state", s.StoreState);
                    cmd.Parameters.AddWithValue("@zip", s.StoreZip);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update existing store
        public static void UpdateStore(Store s)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE stores
                               SET stor_name = @name,
                                   stor_address = @addr,
                                   city = @city,
                                   state = @state,
                                   zip = @zip
                               WHERE stor_id = @id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", s.StoreID);
                    cmd.Parameters.AddWithValue("@name", s.StoreName);
                    cmd.Parameters.AddWithValue("@addr", s.StoreAddress);
                    cmd.Parameters.AddWithValue("@city", s.StoreCity);
                    cmd.Parameters.AddWithValue("@state", s.StoreState);
                    cmd.Parameters.AddWithValue("@zip", s.StoreZip);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete a store by ID
        public static void DeleteStore(int storeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM stores WHERE stor_id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", storeId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
