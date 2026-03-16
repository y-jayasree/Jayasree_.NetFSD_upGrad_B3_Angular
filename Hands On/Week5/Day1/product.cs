using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Product
    {
        private string name;
        private double price;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property for Price with validation
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative");
                }
                else
                {
                    price = value;
                }
            }
        }
        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    // Derived class for Electronics products
    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            double discount = Price * 0.05;
            double finalPrice = Price - discount;
            return finalPrice;
        }
    }
    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            double discount = Price * 0.15;
            double finalPrice = Price - discount;
            return finalPrice;
        }
    }
}

internal class Program
{
        static void Main(string[] arg)
    {
        Product p1 = new Electronics();
        Product p2 = new Clothing();
        p1.Name = "Laptop";
        p1.Price = 20000;

        p2.Name = "T-Shirt";
        p2.Price = 2000;
        double electronicsPrice = p1.CalculateDiscount();
        double clothingPrice = p2.CalculateDiscount();

        Console.WriteLine("Electronics Final Price after 5% discount = " + electronicsPrice);
        Console.WriteLine("Clothing Final Price after 15% discount = " + clothingPrice);
        Console.ReadLine();

    }
}