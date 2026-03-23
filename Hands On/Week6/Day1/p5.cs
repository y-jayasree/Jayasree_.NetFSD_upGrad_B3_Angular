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
               Trace.Listeners.Clear();
               Trace.Listeners.Add(new TextWriterTraceListener("OrderLog.txt"));
               Trace.AutoFlush = true;

               Console.WriteLine("Order processing started...\n");

               try
               {
                   ValidateOrder();
                   ProcessPayment();
                   UpdateInventory();
                   GenerateInvoice();

                   Trace.TraceInformation("Order processed successfully.");
               }
               catch (Exception ex)
               {
                   Trace.WriteLine("ERROR: " + ex.Message);
               }

               Console.WriteLine("Order processing completed. Check OrderLog.txt");
            }
            static void ValidateOrder()
            {
               Trace.WriteLine("Step 1: Validating order...");
               Console.WriteLine("Validating order...");
            }

            static void ProcessPayment()
            {
               Trace.WriteLine("Step 2: Processing payment...");
               Console.WriteLine("Processing payment...");
            }

            static void UpdateInventory()
            {
               Trace.WriteLine("Step 3: Updating inventory...");
               Console.WriteLine("Updating inventory...");
            }

            static void GenerateInvoice()
            {
               Trace.WriteLine("Step 4: Generating invoice...");
               Console.WriteLine("Generating invoice...");
        }
    }
}