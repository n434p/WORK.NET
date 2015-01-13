using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parcer
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = ".23.15 3.45  5.6.8 ee15.2tt 65.e45e 44e.11 11.88";
            Regex rx = new Regex(@"(?<!\.)(?<number>[\d]+\.[\d]+)(?!\.)");
            MatchCollection mc = rx.Matches(str);
            foreach (Match item in mc)
            {
                // GroupCollection g = item.Groups;
                //Console.WriteLine(item.Groups["0"].Value);
                //Console.WriteLine(item.Groups["1"].Value);
                Console.WriteLine(item.Groups["0"].Value);
                Console.WriteLine(item.Groups["number"].Value);


                Console.WriteLine("***********");
            }

            foreach (var item in rx.GetGroupNames())
            {
                Console.WriteLine(item );
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
