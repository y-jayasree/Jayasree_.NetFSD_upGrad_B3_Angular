using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    // Base cls
    internal class Vehicle
    {
        private string brand;
        private double rentalRatePerDay;

        // Property for Brand
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Rental rate cannot be negative");
                }
                else
                {
                    rentalRatePerDay = value;
                }
            }
        }
        public virtual double CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }

    // Derived class Car
    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }
            double total = RentalRatePerDay * days;
            total = total + 500; // insurance charge

            return total;
        }
    }

    // Derived class Bike
    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }

            double total = RentalRatePerDay * days;
            double discount = total * 0.05;

            return total - discount;
        }
    }
}

    internal class Program
    {
            static void Main(string[] arg)
        {
            Vehicle v1 = new Car();
            Vehicle v2 = new Bike();
            v1.Brand = "Toyota";
            v1.RentalRatePerDay = 2000;

            v2.Brand = "Yamaha";
            v2.RentalRatePerDay = 800;
            double carRental = v1.CalculateRental(3);
            double bikeRental = v2.CalculateRental(3);
            Console.WriteLine("Car Total Rental = " + carRental);
            Console.WriteLine("Bike Total Rental = " + bikeRental);
            Console.ReadLine();
        }
    }
