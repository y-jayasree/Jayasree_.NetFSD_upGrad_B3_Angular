namespace ConsoleApp3
{
   internal class Program
   {
       static void Main(string[] args)
       {
           Console.Write("Enter Name: ");
           string name = Console.ReadLine();

           Console.Write("Enter Marks: ");
           int marks = int.Parse(Console.ReadLine());

           if (marks < 0 || marks > 100)
           {
               Console.WriteLine("Invalid Marks");
           }
           else
           {
               string grade;

               if (marks >= 90)
                   grade = "A";
               else if (marks >= 75)
                   grade = "B";
               else if (marks >= 60)
                   grade = "C";
               else if (marks >= 40)
                   grade = "D";
               else
                   grade = "Fail";

               Console.WriteLine("Student: " + name);
               Console.WriteLine("Grade: " + grade);
           }
       }
   }
}
