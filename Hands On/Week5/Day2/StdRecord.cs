namespace ConsoleApp2
{
    //record to store details
    public record Student(int RollNumber, string Name, string Course, int Marks);
    internal class Program
    {
        static void Main(string[] arg)
        {

            // List to store multiple student records
            List<Student> students = new List<Student>();

            int choice;

            do
            {
                // Menu
                Console.WriteLine("\n===== Student Record Management =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student by Roll Number");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Adding student records
                        Console.Write("Enter number of students: ");
                        int n = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"\nEnter details for student {i + 1}:");

                            int roll;
                            while (true)
                            {
                                Console.Write("Enter Roll Number: ");
                                if (int.TryParse(Console.ReadLine(), out roll) && roll > 0)
                                    break;
                                Console.WriteLine("Invalid Roll Number! Try again.");
                            }

                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Course: ");
                            string course = Console.ReadLine();

                            // validation for Marks
                            int marks;
                            while (true)
                            {
                                Console.Write("Enter Marks: ");
                                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                                    break;
                                Console.WriteLine("Invalid Marks! Enter between 0 and 100.");
                            }

                            // Create record and add to list
                            Student s = new Student(roll, name, course, marks);
                            students.Add(s);
                        }
                        break;

                    case 2:
                        // Display all student records
                        Console.WriteLine("\nStudent Records:");

                        if (students.Count == 0)
                        {
                            Console.WriteLine("No records found.");
                        }
                        else
                        {
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                            }
                        }
                        break;

                    case 3:
                        // Search student by Roll Number
                        Console.Write("\nEnter Roll Number to search: ");
                        int searchRoll = Convert.ToInt32(Console.ReadLine());

                        bool found = false;

                        foreach (var s in students)
                        {
                            if (s.RollNumber == searchRoll)
                            {
                                Console.WriteLine("\nStudent Found:");
                                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Student record not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 4);

        }
            
    }
}
