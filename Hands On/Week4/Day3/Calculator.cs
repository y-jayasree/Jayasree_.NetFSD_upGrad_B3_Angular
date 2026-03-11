namespace ConsoleApp2
{
internal class Program
{
    static void Main(String[]args)
    {
        Console.Write("Enter First Number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.Write("Enter Operator (+, -, *, /): ");
        char op = char.Parse(Console.ReadLine());

        double result = 0;

        switch (op)
        {
            case '+':
                result = num1 + num2;
                Console.WriteLine("Result: " + result);
                break;

            case '-':
                result = num1 - num2;
                Console.WriteLine("Result: " + result);
                break;

            case '*':
                result = num1 * num2;
                Console.WriteLine("Result: " + result);
                break;

            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Division by zero not allowed");
                }
                else
                {
                    result = num1 / num2;
                    Console.WriteLine("Result: " + result);
                }
                break;

            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
}