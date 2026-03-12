using System;

namespace ConsoleApp1
{
    class Student
    {
        public double CalculateAvg(int m1, int m2, int m3)
        {
            return (m1 + m2 + m3) / 3.0;
        }
    }
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 marks:");

            int m1 = int.Parse(Console.ReadLine());
            int m2 = int.Parse(Console.ReadLine());
            int m3 = int.Parse(Console.ReadLine());

            if (m1<0 || m2<0 || m3 < 0)
            {
                Console.WriteLine("Marks can't be Negative");
            }
            Grade obj=new Student();
            double avg=obj.CalculateAvg(m1, m2, m3);
            string grade;
            if (avg >= 90)
                grade = "A+";
            else if (avg >= 80)
                grade = "A";
            else if(avg >=70)
                grade = "B";
            else if(avg >=60)
                grade = "C";
            else 
                grade = "D";

            Console.WriteLine("Average = "+avg);
            Console.WriteLine("Grade = "+grade);
        }
    }
}
