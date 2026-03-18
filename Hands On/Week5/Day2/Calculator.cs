using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Calculator
    {
        // method for divide
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine($"Result:{result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("error: can't devide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }

        }
    }
}

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            //// obj for class

            Calculator calc = new Calculator();

            Console.Write("Enter Numerator: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Denominator: ");
            int den = Convert.ToInt32(Console.ReadLine());

            calc.Divide(num, den);

        }
            
    }
}
