using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    //  Console.Write(i + "  ");
                    count++;
                }
            }
            if (count == 1) Console.WriteLine("The number {0} is simple",number );
            else Console.WriteLine("The number {0} is NOT simple ",number );
            Console.ReadKey();



        }
    }
}
