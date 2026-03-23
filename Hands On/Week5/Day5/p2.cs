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
                    Console.WriteLine("Enter folder path:");
                    string folderPath = Console.ReadLine();

                    if (!Directory.Exists(folderPath))
                    {
                        Console.WriteLine("Invalid folder path!");
                        return;
                    }

                    //  DirectoryInfo object 
                    DirectoryInfo dir = new DirectoryInfo(folderPath);
                    FileInfo[] files = dir.GetFiles();
                    int count = 0;

                    foreach (FileInfo file in files)
                    {
                        Console.WriteLine("File Name: " + file.Name);

                        Console.WriteLine("File Size: " + file.Length + " bytes");

                        Console.WriteLine("Created On: " + file.CreationTime);

                        Console.WriteLine("------------------------");

                        count++;
                    }

                    Console.WriteLine("Total Files: " + count);
                }
                catch (UnauthorizedAccessException ex)
                {

                    Console.WriteLine("Access denied: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.ReadLine();
            }
     }
 }




