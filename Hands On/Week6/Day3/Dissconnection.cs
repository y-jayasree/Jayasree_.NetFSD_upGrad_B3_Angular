using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get connection string
            string connStr = config.GetConnectionString("DefaultConnection");

            // Infinite loop for menu
            while (true)
            {
                Console.WriteLine("\n1.Insert 2.View 3.Update 4.Delete 5.Exit");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                // CREATE CONNECTION (used for all operations)
                using SqlConnection conn = new SqlConnection(connStr);

                // DataAdapter → bridge between DB and memory
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products1", conn);

                // Auto generate Insert/Update/Delete commands
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter);

                // DataTable (Disconnected)
                DataTable table = new DataTable();

                // Fill data from DB 
                adapter.Fill(table);

                // INSERT
                if (choice == 1)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    // Create new row in memory
                    DataRow row = table.NewRow();
                    row["ProductName"] = name;
                    row["Category"] = category;
                    row["Price"] = price;

                    // Add row to table
                    table.Rows.Add(row);

                    // Update DB
                    adapter.Update(table);

                    Console.WriteLine("Inserted Successfully");
                }

                // VIEW
                else if (choice == 2)
                {
                    // Loop through DataTable
                    foreach (DataRow row in table.Rows)
                    {
                        Console.WriteLine(
                            $"ID: {row["ProductId"]}, " +
                            $"Name: {row["ProductName"]}, " +
                            $"Category: {row["Category"]}, " +
                            $"Price: {row["Price"]}"
                        );
                    }
                }

                // UPDATE
                else if (choice == 3)
                {
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    // Find row using Select
                    DataRow[] rows = table.Select($"ProductId = {id}");

                    if (rows.Length > 0)
                    {
                        // Update values in memory
                        rows[0]["ProductName"] = name;
                        rows[0]["Category"] = category;
                        rows[0]["Price"] = price;

                        // Update DB
                        adapter.Update(table);

                        Console.WriteLine("Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                    }
                }

                // DELETE
                else if (choice == 4)
                {
                    Console.Write("Enter Id: ");
                    int id = int.Parse(Console.ReadLine());

                    // Find row
                    DataRow[] rows = table.Select($"ProductId = {id}");

                    if (rows.Length > 0)
                    {
                        // Mark row as deleted
                        rows[0].Delete();
                        adapter.Update(table);

                        Console.WriteLine("Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
