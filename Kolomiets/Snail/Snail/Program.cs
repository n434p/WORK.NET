using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snail
{
    class Program
    {
        public static void SnailInit(int size)
        {
            int[] arr = new int[(size)*(size)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i+1;
                Console.Write(arr[i] + "  ");
            }

            int[,] mas = new int[size, size];

            int upIndex = 0, botIndex = (size - 1) * 3, leftIndex = (size - 1) * 4 - 1, rightIndex = size;


            for (int n = 0; n < 2; n++)
           //int n = 0;
            {

                upIndex += leftIndex; botIndex = ((size - 1-n) * 3) + leftIndex; leftIndex += leftIndex; rightIndex += leftIndex;

                for (int i = 0+n; i < size-n; i++)
                {
                    for (int j = 0+n; j < size-n; j++)
                    {
                        if (i == 0+n)
                        {
                            mas[i, j] = arr[upIndex];
                            upIndex++;
                        }
                        if (i == size - 1-n)
                        {
                            mas[i, j] = arr[botIndex];
                            botIndex--;
                        }
                        if ((i < size - 1-n) & (i > 0+n) & (j == 0+n))
                        {
                            mas[i, j] = arr[leftIndex];
                            leftIndex--;
                        }
                        if ((i < size - 1-n) & (i > 0+n) & (j == size - 1-n))
                        {
                            mas[i, j] = arr[rightIndex];
                            rightIndex++;
                        }

                    }
                    Console.WriteLine();
                }
            }

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i, j]+"  ");
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            SnailInit(5);
            Console.ReadKey();
        }
    }
}
