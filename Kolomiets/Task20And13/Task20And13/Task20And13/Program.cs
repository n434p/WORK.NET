using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task20And13
{
    class Program
    {
        static void Main(string[] args)
        {
            //int numberCurrent = 0, numberPrev = 0, i = 0, count = 0;
            //while (i < 10)
            //{
            //    numberCurrent = Convert.ToInt32(Console.ReadLine());
            //    if (i != 0 && numberPrev > numberCurrent)
            //        count++;
            //    i++;
            //    numberPrev = numberCurrent;
            //}
            //Console.WriteLine("Количество инверсий = {0}", count);

            int number = 0, count = 1, max = 0;
            Console.WriteLine("Введите натуральное число");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Последовательность Хееса:");
            Console.Write(number + " ");
            max = number;
            for(int i = number;i != 1;count++)
            {
                if (i % 2 == 0)
                    i /= 2;
                else
                    i = (i * 3 + 1);
                if (i > max)
                    max = i;
                Console.Write(i + " ");

            }
            Console.WriteLine("\nКоличество элементов в последовательности = {0}\nВершина Хееса = {1}", count, max);



        }
    }
}
