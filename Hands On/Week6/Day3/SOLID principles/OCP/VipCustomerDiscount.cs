using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
        public class VipCustomerDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double amount)
            {
                return amount * 0.20;
            }
        }
}
