using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadMatrix
{
    class Program
    {
        List<int> mas = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your option: ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("1. Read");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("2. Sort");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("3. Print");
                    break;
                default:
                break;
            }

            Thread t1 = new Thread(new ThreadStart(Read));
  
          
        }

        public void Read() 
        {
            using (FileStream fs = new FileStream(@"\..\..\1.txt",FileMode.Open,FileAccess.Read ))
            {
                StreamReader sr = new StreamReader(fs);
            
                while (!sr.EndOfStream) 
                {
                    Thread.Sleep(20);
                    mas.Add(sr.Read());
                }

            }
        }

        public void Sort() 
        {
            Thread.Sleep(50);
            mas.Sort();
        }
    }
}
