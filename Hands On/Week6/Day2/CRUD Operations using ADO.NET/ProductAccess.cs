using Microsoft.Data.SqlClient;
using System;
using System.Data;
//using ConsoleApp1.Models;

namespace ConsoleApp1.Data
{
    internal class ProductDataAccess
    {
        private readonly string _connStr;

        // Constructor reads connection string
        public ProductDataAccess(string connStr)
        {
            _connStr = connStr;
        }

        // INSERT PRODUCT
        public void InsertProduct(Product p)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameterized query to prevent SQL Injection
            cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = p.ProductName });
            cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar) { Value = p.Category });
            cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal) { Value = p.Price });

            conn.Open();
            cmd.ExecuteNonQuery(); // Executes the INSERT stored procedure
        }

        // VIEW ALL PRODUCTS
        public void ViewProducts()
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader(); // Executes SELECT stored procedure
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["ProductId"]}, Name: {reader["ProductName"]}, Category: {reader["Category"]}, Price: {reader["Price"]}");
            }
        }

        // UPDATE PRODUCT
        public void UpdateProduct(Product p)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = p.ProductId });
            cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = p.ProductName });
            cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar) { Value = p.Category });
            cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal) { Value = p.Price });

            conn.Open();
            cmd.ExecuteNonQuery(); // Executes UPDATE stored procedure
        }

        // DELETE PRODUCT
        public void DeleteProduct(int id)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

            conn.Open();
            cmd.ExecuteNonQuery();// Executes DELETE stored procedure
        }
            // GET PRODUCT BY ID
         public Product GetProductById(int id)
         {
            using SqlConnection conn = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("sp_GetProductById", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Product
                {
                    ProductId = (int)reader["ProductId"],
                    ProductName = reader["ProductName"].ToString(),
                    Category = reader["Category"].ToString(),
                    Price = (decimal)reader["Price"]
                };
            }
            else
            {
                return null; // No product found
            }
        }

    }
}

