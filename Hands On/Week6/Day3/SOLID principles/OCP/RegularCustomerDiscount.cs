using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
        public class RegularCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                return amount * 0.05;
            }
        }

}
