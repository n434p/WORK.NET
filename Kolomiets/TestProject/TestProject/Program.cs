using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> digits = new List<int>();
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter num: ");
            int num = Convert.ToInt32(Console.ReadLine());
            double sum =0;
            int temp;
            int a = 0;
            

            for (int i = (int)Math.Pow(10,num-1); i < (int)Math.Pow(10,num); i++)
            {
                a = i;
                temp = (int)i;
                sum = 0;
                digits.Clear();
                while (i > 0)
                {
                    digits.Add((int)i % 10);
                    i /= 10;
                }

                for (int j = 0; j < digits.Count; j++)
                {
                    sum += (double)Math.Pow(digits[j], digits.Count);
                }
                if (sum == temp) numbers.Add(temp);
                i = a;
            }

            if (numbers.Count == 0) Console.WriteLine("EMPTY");

            foreach (var item in numbers)
            {
                Console.Write(item+"  \t");
                
            }

        }
    }
}
