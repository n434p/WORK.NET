using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file mask:\n\n");
            string mask = Console.ReadLine();
            string path = "";

            //foreach (var item in Environment.GetLogicalDrives())
            //{
            //    Console.WriteLine(item);
            //}
            //int i = Convert.ToInt16(Console.ReadLine());
            //path = Environment.GetLogicalDrives()[i-1];
           
            Directory.SetCurrentDirectory(@"D:\");
            DirectoryInfo di = new DirectoryInfo(".");
            foreach (var item in di.EnumerateFiles(mask, SearchOption.AllDirectories))

            {
                Console.WriteLine(item.Name+"\t\t"+item.DirectoryName);
            }
            Console.ReadKey();
        }
    }
}
