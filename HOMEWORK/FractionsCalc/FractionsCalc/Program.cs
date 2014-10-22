using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FractionsCalc
{
    class Program
    {
        class Fraction
        {
            int numerator;
            int denumerator;
            int intPart;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter some string: \n");
            string str = Console.ReadLine();
            //Console.WriteLine("{0} {1} {2} {3}",p, Console.BufferWidth, Console.In, Console.Out);
            Console.WriteLine("\n Edit your string: \n");
            Console.Write(str);
            foreach (var item in str)
            {
                Console.Write(item);
            }
            Console.SetCursorPosition(0, Console.CursorTop);
            str  = Console.ReadLine();
        }
    }
}
