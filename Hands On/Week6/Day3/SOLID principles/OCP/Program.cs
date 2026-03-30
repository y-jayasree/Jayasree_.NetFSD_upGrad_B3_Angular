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
            double amount = 1000;

            // Regular Customer
            DiscountCalculator regular = new DiscountCalculator(new RegularCustomerDiscount());
            Console.WriteLine("Regular Final Price: " + regular.GetFinalAmount(amount));

            // Premium Customer
            DiscountCalculator premium = new DiscountCalculator(new PremiumCustomerDiscount());
            Console.WriteLine("Premium Final Price: " + premium.GetFinalAmount(amount));

            // VIP Customer
            DiscountCalculator vip = new DiscountCalculator(new VipCustomerDiscount());
            Console.WriteLine("VIP Final Price: " + vip.GetFinalAmount(amount));
        }
    }
}
