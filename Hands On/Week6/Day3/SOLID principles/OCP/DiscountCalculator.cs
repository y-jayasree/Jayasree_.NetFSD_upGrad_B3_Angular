using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{ 
        public class DiscountCalculator
        {
            private IDiscountStrategy strategy;

            public DiscountCalculator(IDiscountStrategy strategy)
            {
                this.strategy = strategy;
            }

            public double GetFinalAmount(double amount)
            {
                double discount = strategy.CalculateDiscount(amount);
                return amount - discount;
            }
        }
}
