using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Employee
        {
            private string _fullName;
            private int _age;
            private decimal _salary;
            private readonly string _employeeId;

            // Property for FullName
            public string FullName
            {
                get { return _fullName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException("Name can't be Empty ");
                    _fullName = value.Trim();

                }
            }
            // property for age
            public int Age
            {
                get { return _age; }
                set
                {
                    if (value < 18 || value > 80)
                        throw new ArgumentException("Age must be Betwwen 18 and 80");
                    _age = value;
                }
            }
            // salry property
            public decimal Salary
            {
                get { return _salary; }
                private set
                {
                    if (value < 1000)
                        throw new ArgumentException("Salary atleast 1000");
                    _salary = value;
                }
            }
            //empid property
            public string EmployeeId
            {
                get { return _employeeId; }

            }
            //constructor
            public Employee(string fullName, int age, decimal salary)
            {
                _employeeId = "E" + Guid.NewGuid().ToString().Substring(0, 5);
                FullName = fullName;
                Age = age;
                Salary = salary;
            }
            //method to raise sal
            public void GiveRaise(decimal percentage)
            {
                if (percentage <= 0 || percentage > 30)
                    throw new ArgumentException("raise b/w 1% and 30%");
                decimal increase = _salary * percentage / 100;
                Salary += increase;
                Console.WriteLine("Raise Applied....");
                Console.WriteLine("New salary: " + _salary);
            }
            // penalty method
            public bool DeductPenalty(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invali Penalty amount");
                    return false;
                }
                if (_salary - amount < 1000)
                {
                    Console.WriteLine("No penalty, Salary can't go below 1000");
                    return false;
                }
                Salary = _salary - amount;
                Console.WriteLine("penalty applied");
                Console.WriteLine("New salary : " + _salary);
                return true;
            }
        }
    }

  

namespace ConsoleApp2
{
    internal class Program
    {
            static void Main(string[] args)
            {
            Employee emp = new Employee("Marko Horvat", 35, 4500m);
            

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Name: " + emp.FullName);
            Console.WriteLine("Salary: " + emp.Salary);

            emp.GiveRaise(10);
           
            emp.DeductPenalty(200);

            emp.FullName = "Marko Horvat Jr.";

            Console.WriteLine("Updated Name: " + emp.FullName);
            Console.WriteLine(emp.Age);

        }
    }
}
