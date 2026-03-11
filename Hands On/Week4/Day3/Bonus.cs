namespace ConsoleApp2
{
internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Enter Experience: ");
        int exp = int.Parse(Console.ReadLine());

        if (salary < 0 || exp < 0)
        {
            Console.WriteLine("Invalid input. Salary and Experience cannot be negative.");
        }
        else
        {
            double bonusPercent;

            if (exp < 2)
                bonusPercent = 0.05;
            else if (exp <= 5)
                bonusPercent = 0.10;
            else
                bonusPercent = 0.15;

            double bonus = salary * bonusPercent;
            double finalSalary = salary + bonus;

            Console.WriteLine("Employee: " + name);
            Console.WriteLine("Bonus: " + bonus);
            Console.WriteLine("Final Salary: " + finalSalary);
        }
    }
}
}