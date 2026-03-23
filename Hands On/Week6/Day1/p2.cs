using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static async Task Main()
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            // Breakpoint to check input values
            double finalPrice = CalculateFinalPrice(price, discount);

            Console.WriteLine("\nProduct: " + productName);
            Console.WriteLine("Original Price: " + price);
            Console.WriteLine("Discount: " + discount + "%");
            Console.WriteLine("Final Price: " + finalPrice);
        }
        static double CalculateFinalPrice(double price, double discount)
        {
            double discountAmount = (price * discount) / 100;
            double finalPrice = price - discountAmount;
            return finalPrice;
        }
    }
}