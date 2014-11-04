using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1,1);
            Complex c2 = new Complex() ;

            c2 = c1 - (c1 * c1 * c1 - 1) / (3 * c1 * c1);

            Console.WriteLine(c2);
            Console.ReadKey();
        }
    }
}
