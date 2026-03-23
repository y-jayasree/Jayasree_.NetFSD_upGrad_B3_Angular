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
            string folderpath = "Logs";
            if (!Directory.Exists(folderpath))
            {
               Directory.CreateDirectory(folderpath);
            }
            string logpath = Path.Combine(folderpath, "file1.txt");
            try
            {
               Console.WriteLine("enter message:");
               string message = Console.ReadLine();
               byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);
               using (FileStream fs = new FileStream(logpath, FileMode.Append, FileAccess.Write))
               {
                   fs.Write(data, 0, data.Length);
                   fs.Flush();
               }
               Console.WriteLine("Message written successfully!");
            }
            catch (UnauthorizedAccessException ex)
            {
               Console.WriteLine("Access denied:" + ex.Message);
            }
            catch (IOException ex)
            {
               Console.WriteLine("file error:" + ex.Message);
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error:"+ex.Message);
            }
            }
     }
 }




