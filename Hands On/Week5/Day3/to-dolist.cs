
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            List<string> tasks = new List<string>();
            while (true)
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Choose option:");
                string choice= Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Console.Write("enter task:");
                        string task=Console.ReadLine();
                        if (string.IsNullOrEmpty(task))
                        {
                            Console.WriteLine("Task can't be empty");
                        }
                        else
                        {
                            tasks.Add(task);
                            Console.WriteLine("Task added");
                        }
                        break;
                    case "2":
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("no tasks available");
                        }
                        else
                        {
                            Console.WriteLine("Tasks:");
                            for(int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine((i + 1) +" " + tasks[i]);
                            }
                        }
                        break;
                    case "3":
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks to remove.");
                            break;
                        }

                        Console.Write("Enter task number to remove: ");
                        int num;
                        if (int.TryParse(Console.ReadLine(), out num))
                        {
                            int index = num - 1;
                            if (index >= 0 && index < tasks.Count)
                            {
                                Console.WriteLine("Removed: " + tasks[index]);

                                tasks.RemoveAt(index);
                            }
                            else
                            {
                                Console.WriteLine("Invalid task number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Enter a number.");
                        }

                        break;

                    case "4":
                        Console.WriteLine("existing application");
                        return;
                    default:
                        Console.WriteLine("Invalid choice,please select 1-4");
                        break;
                }
            }
            
        }
            
    }
}
