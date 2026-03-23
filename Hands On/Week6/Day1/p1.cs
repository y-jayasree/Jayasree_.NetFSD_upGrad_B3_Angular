using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static async Task Main()
        {
               Console.WriteLine("Loading...\n");
               //calling async method
               Task t1 = WriteLogAsync("User logged in");
               Task t2 = WriteLogAsync("File uploaded");
               Task t3 = WriteLogAsync("Data processed");

               // wait for tasks to complete
               await Task.WhenAll(t1, t2, t3);
               Console.WriteLine("\n Login completed");
            }
            // asynchronous method 
            public static async Task WriteLogAsync(string message)
            {
               Console.WriteLine($"start writing log:{message}");
               await Task.Delay(2000);
               Console.WriteLine($"log completed:{message}");

        }
    }
}