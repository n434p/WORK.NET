using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto a = new Auto();
            Console.WriteLine(a);
            a.Drive();
            Console.WriteLine(a);
            Plane p = new Plane();
            Console.WriteLine(p);
            p.Fly();
            Console.WriteLine(p);
            p.Drive();
            Console.WriteLine(p);
        }
    }
}
