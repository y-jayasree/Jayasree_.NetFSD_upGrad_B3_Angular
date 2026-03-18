using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    //Custom exception cls
    public class InsufficientBalanceException : Exception
    {
        //constrctor
        public InsufficientBalanceException(string message) : base(message) { }
    }

    internal class BankAccount
    {
        private double _balance;

        //class
        public BankAccount(double balance)
        {
            _balance = balance;
        }

        //method
        public void Withdraw(double amount)
        {
            if (amount > _balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            _balance -= amount;
            Console.WriteLine($"Withdraw success, remaining balance: {_balance}");
        }
    }
   
}


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            try
            {
                Console.Write("Enter balance: ");
                double balance = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter withdraw amount: ");
                double withdraw = Convert.ToDouble(Console.ReadLine());
                
                //obj for cls
                BankAccount account = new BankAccount(balance);
                account.Withdraw(withdraw);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction completed");
            }
        }
            
    }
}
