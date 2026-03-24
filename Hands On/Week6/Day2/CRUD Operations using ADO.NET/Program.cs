using ConsoleApp1.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
 namespace ConsoleApp1
{
    class program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            string connStr = config.GetConnectionString("DefaultConnection");

            ProductDataAccess dataAccess = new ProductDataAccess(connStr);

            while (true)
            {
                Console.WriteLine("\n1.Insert 2.View 3.Update 4.Delete 5.Get By ID 6.Exit");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Product p = new Product();
                    Console.Write("Name: "); p.ProductName = Console.ReadLine();
                    Console.Write("Category: "); p.Category = Console.ReadLine();
                    Console.Write("Price: "); p.Price = decimal.Parse(Console.ReadLine());

                    dataAccess.InsertProduct(p);
                    Console.WriteLine("Inserted Successfully");
                }
                else if (choice == 2)
                {
                    dataAccess.ViewProducts();
                }
                else if (choice == 3)
                {
                    Product p = new Product();
                    Console.Write("ID: "); p.ProductId = int.Parse(Console.ReadLine());
                    Console.Write("Name: "); p.ProductName = Console.ReadLine();
                    Console.Write("Category: "); p.Category = Console.ReadLine();
                    Console.Write("Price: "); p.Price = decimal.Parse(Console.ReadLine());

                    dataAccess.UpdateProduct(p);
                    Console.WriteLine("Updated Successfully");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    dataAccess.DeleteProduct(id);
                    Console.WriteLine("Deleted Successfully");
                }
                else if (choice == 5)
                {
                    Console.Write("Enter Product ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Product p = dataAccess.GetProductById(id);

                    if (p != null)
                        Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Category: {p.Category}, Price: {p.Price}");
                    else
                        Console.WriteLine("Product not found");
                }
                else
                {
                    break;
                }
            }
        }
    }
}