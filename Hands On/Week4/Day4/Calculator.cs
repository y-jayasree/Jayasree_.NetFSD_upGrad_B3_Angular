
using System;

namespace ConsoleApp1
{
    class Calculator
    {
        // add Method
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter 1st no :");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("enter 2nd no :");
            int b = int.Parse(Console.ReadLine());

            Calculator obj = new Calculator();
            int addresult = obj.Add(a, b);
            int subresult = obj.Sub(a, b);

            Console.WriteLine("Addition=" + addresult);
            Console.WriteLine("Subtraction=" + subresult);
        }
    }
}
