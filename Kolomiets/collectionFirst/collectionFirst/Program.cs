using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace collectionFirst
{
    class Program
    {
        public delegate int BinOp(int x, int y);

        public class Simple 
        {
            public static int Add(int x, int y)
            {
                Console.WriteLine("First method processing...");
                return x + y;
            }

            public int Substract(int x, int y)
            {
                return x - y;
            }
        }

      

        static void Main(string[] args)
        {
            Simple s = new Simple();
            BinOp op = new BinOp(Simple.Add);
            op += new BinOp(s.Substract);

            Console.WriteLine("Result: {0}",op(10,10));
            foreach (BinOp item in op.GetInvocationList())
            {
                Console.WriteLine( item.Method);
                Console.WriteLine(item.Target);
            }
            Console.ReadKey();

        }
    }
}
