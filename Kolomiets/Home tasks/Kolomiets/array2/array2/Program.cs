using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array2
{
    class Program
    {
        static void Main(string[] args)
        {
            int col1, col2, temp=0;
            Random r = new Random();
            int[,] arr = new int[r.Next(1, 10), r.Next(1, 10)];
           
            Console.WriteLine("Your array:");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(0, 10);
                    Console.Write(arr[i,j] + "  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("1-st column number [1 - {0}] to change with:", arr.GetLength(1));
            col1 = Convert.ToInt32(Console.ReadLine())-1;
            Console.WriteLine("2-nd column number [1 - {0}] to change with:", arr.GetLength(1));
            col2 = Convert.ToInt32(Console.ReadLine())-1;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                temp = arr[i, col1];
                arr[i,col1] = arr[i,col2];
                arr[i,col2] = temp;
                }
                Console.WriteLine();

             Console.WriteLine("Result:");

             for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                   Console.Write(arr[i,j] + "  ");
                }
                Console.WriteLine();
            }



            


            Console.ReadKey();
        }
    }
}
