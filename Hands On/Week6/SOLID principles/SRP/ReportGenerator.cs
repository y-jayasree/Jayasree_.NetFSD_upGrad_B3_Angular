using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("Student Report:");

            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.StudentId}");
                Console.WriteLine($"Name: {s.StudentName}");
                Console.WriteLine($"Marks: {s.Marks}");

                string result = s.Marks >= 40 ? "Pass" : "Fail";
                Console.WriteLine($"Result: {result}");
                Console.WriteLine("--------------------------");
            }
        }
    }
}
