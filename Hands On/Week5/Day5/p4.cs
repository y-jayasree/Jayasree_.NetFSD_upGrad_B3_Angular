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
               Console.WriteLine("Enter Root Directory Path:");
               string rootPath = Console.ReadLine();
               if (!Directory.Exists(rootPath))
               {
                   Console.WriteLine("Invalid Directory Path!");
                   return; 
               }
               DirectoryInfo rootDir = new DirectoryInfo(rootPath);

               // 2. get subdirectories
               DirectoryInfo[] subDirs = rootDir.GetDirectories();
               Console.WriteLine("\n--- Directory Details ---");
               foreach (DirectoryInfo dir in subDirs)
               {
                   Console.WriteLine("Folder Name: " + dir.Name);
                   FileInfo[] files = dir.GetFiles();
                   Console.WriteLine("Number of Files: " + files.Length);

                   Console.WriteLine("---------------------------");
               }
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error: " + ex.Message);
            }   
        }
    }
 }




