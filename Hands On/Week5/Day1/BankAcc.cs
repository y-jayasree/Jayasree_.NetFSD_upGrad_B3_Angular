namespace ConsoleApp2
{
    internal class BankAccount
    {
        //class BankAccount
        
            private int accountNumber;
            private double balance;
            public int AccountNumber
            {
                get { return accountNumber; }
                set { accountNumber = value; }
            }
            public double Balance
            {
                get { return balance; }
            }
            public void Deposit(double amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid deposit amount");
                    return;
                }
                balance += amount;
                Console.WriteLine("Amount deposited: " + amount);
                Console.WriteLine("Current balance : " + balance);
            }
            public void Withdraw(double amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid withdrawal");
                    return;
                }
                if (amount > balance)
                {
                    Console.WriteLine("Insufficient balance");
                    return;
                }
                balance -= amount;
                Console.WriteLine("Amount withdrawn: " + amount);
                Console.WriteLine("Current balance : " + balance);

            }
        }
    }

namespace ConsoleApp2
{
    internal class Program
    {
            static void Main(string[] arg)
        {
            BankAccount acc = new BankAccount();
           
            acc.AccountNumber = 101;

            acc.Deposit(5000);   
            acc.Withdraw(2000);  
            Console.WriteLine("Final Balance = " + acc.Balance);

            Console.ReadLine();
        }
    }
}
