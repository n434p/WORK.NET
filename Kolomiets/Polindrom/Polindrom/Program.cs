using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polindrom
{
    class Program
    {
        static string Polindrom(int number) 
        {
        
        int temp = number;
        int count =0;

        while (temp/10 != 0)
	{
        count++;
	    temp /= 10;   
   
	}
        int left = temp;
        int right = number % 10;

        if ((count == 0) || (number == temp))
        {
            return "Your number is polindrom.";
        }
        
        if (left == right) Polindrom((number- (int)(Math.Pow(10, count)) * left) / 10);
        else return  "Your number is NOT polindrom.";


        return "Your number is polindrom.";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("POLINDROM: ");
            Console.WriteLine(Polindrom(1201));
            Console.ReadKey();
        }
    }
}
