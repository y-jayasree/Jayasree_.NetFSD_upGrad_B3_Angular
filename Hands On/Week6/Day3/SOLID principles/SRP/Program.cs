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
            StudentRepository repo = new StudentRepository();

            // Adding students
            repo.AddStudent(new Student { StudentId = 1, StudentName = "Jaya", Marks = 75 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Raji", Marks = 35 });

            // Generate report
            ReportGenerator report = new ReportGenerator();
            report.GenerateReport(repo.GetAllStudents());
        }
    }
}
