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
               Console.WriteLine("Order processing started...\n");
               await ProcessOrderAsync();
               Console.WriteLine("\nOrder processing completed.");
            }

            static async Task ProcessOrderAsync()
            {
               await VerifyPaymentAsync();
               await CheckInventoryAsync();
               await ConfirmOrderAsync();
            }
            static async Task VerifyPaymentAsync()
            {
               Console.WriteLine("Verifying payment...");
               await Task.Delay(2000);
               Console.WriteLine("Payment verified.");
            }
            static async Task CheckInventoryAsync()
            {
               Console.WriteLine("Checking inventory...");
               await Task.Delay(1500);
               Console.WriteLine("Inventory available.");
            }
            static async Task ConfirmOrderAsync()
            {
               Console.WriteLine("Confirming order...");
               await Task.Delay(1000);
               Console.WriteLine("Order confirmed.");

        }
    }
}