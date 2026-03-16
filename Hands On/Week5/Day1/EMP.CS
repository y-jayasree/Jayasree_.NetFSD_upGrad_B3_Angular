namespace ConsoleApp2
{
    // base class
    internal class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }
    // Derived class Manager
    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            double bonus = BaseSalary * 0.20;
            return BaseSalary + bonus;
        }
    }
    class Developer : Employee
    {
        public override double CalculateSalary()
        {
            double bonus = BaseSalary * 0.10;
            return BaseSalary + bonus;
        }
    }
}

internal class Program
{
        static void Main(string[] arg)
    {
// Using base class reference (Polymorphism)
        Employee emp1 = new Manager();
        Employee emp2 = new Developer();
        emp1.BaseSalary = 50000;
        emp2.BaseSalary = 50000;

        double managerSalary = emp1.CalculateSalary();
        double developerSalary = emp2.CalculateSalary();
        
        Console.WriteLine("Manager Salary = " + managerSalary);
        Console.WriteLine("Developer Salary = " + developerSalary);

        Console.ReadLine();

    }
}