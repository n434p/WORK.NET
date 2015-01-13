using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Translator
{
    class Program
    {
        public static void Menu() 
        {
            bool flag = false;
            
            Vocabulary v = new Vocabulary(@"..\..\test.txt");
            while (!flag)
            {
            string entry="";
            Console.WriteLine("\t\t \"English-Russian Translator\"\n\n \t\t\tfor exit enter \"q\"\n\n");   
            Console.WriteLine("Enter some word for translation:\n\n");
            entry = Console.ReadLine();
            if (entry == "q") { flag = true; continue; }
            if (v.Translate(entry) == "")
            {
                Console.WriteLine("\nSorry! Vocabulary doesn't have any translation.\n");
                Console.WriteLine("Write any translation for \"{0}\" to save it. Or leave it blank:\n", entry); 
                v.Add(entry, Console.ReadLine());
            }
            else Console.Write(" - {0}", v.Translate(entry).ToUpper());
            Console.WriteLine("\n\nPress any key...");
            Console.ReadKey();
            Console.Clear();
            }
        }

        static void Main(string[] args)
        {

            Menu();
            
            

        }
    }
}
