using System;
using System.Linq;
using System.Text;
using LinqCodeTemplate;

namespace LinqCodeTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("--- System Drives Info ---\n");
                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        Console.WriteLine("Drive Name: " + drive.Name);

                        Console.WriteLine("Drive Type: " + drive.DriveType);

                        // Display total size in GB (convert from bytes)
                        double totalSizeGB = drive.TotalSize / (1024.0 * 1024 * 1024);
                        Console.WriteLine("Total Size: " + totalSizeGB.ToString("F2") + " GB");

                        // Display available free space in GB
                        double freeSpaceGB = drive.AvailableFreeSpace / (1024.0 * 1024 * 1024);
                        Console.WriteLine("Free Space: " + freeSpaceGB.ToString("F2") + " GB");

                        // 3. Display warning if free space < 15%
                        double freePercent = (double)drive.AvailableFreeSpace / drive.TotalSize * 100;
                        if (freePercent < 15)
                        {
                            Console.WriteLine("Warning: Low disk space!");
                        }

                        Console.WriteLine("-----------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
 }




