using System;
using System.Linq;
using System.Text;
using LinqCodeTemplate;

namespace LinqCodeTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
               Console.WriteLine("Enter Employee Name:");
               string name = Console.ReadLine();

               Console.WriteLine("Enter Monthly Sales Amount:");
               double sales = Convert.ToDouble(Console.ReadLine());

               Console.WriteLine("Enter Customer Rating (1-5):");
               int rating = Convert.ToInt32(Console.ReadLine());
               var empData = GetEmployeeData(sales, rating);

               // 3. Pattern Matching 
               string performance = empData switch
               {
                   ( >= 100000, >= 4) => "High Performer",
                   ( >= 50000, >= 3) => "Average Performer",
                   _ => "Needs Improvement"
               };
               Console.WriteLine("\nEmployee Name: " + name);
               Console.WriteLine("Sales Amount: " + empData.sales);
               Console.WriteLine("Rating: " + empData.rating);
               Console.WriteLine("Performance: " + performance);
            }
            // Method return multiple values using Tuple
            static (double sales, int rating) GetEmployeeData(double sales, int rating)
            {
               return (sales, rating);

        }
    }
 }




