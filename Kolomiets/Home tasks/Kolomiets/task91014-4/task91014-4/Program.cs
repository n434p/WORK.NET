using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task91014_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Task 1
            //// Replace all zero's elements in array to the right side ad change them as "-1'.

            //Random r = new Random();
            //// Set initial conditions:
            //int[] arr = new int[10];
            //int[] arrRes = new int[10];
            //int count = 0;

            //// Fill arrays:
            //Console.WriteLine("Initial array: ");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = r.Next(0, 4);
            //    Thread.Sleep(20);
            //    // Prepare new array with needed format. 
            //    // It will helpful in refactoring elements from "0" to "-1"
            //    arrRes[i] = -1;
            //    Console.Write(arr[i] + "  ");
            //}
            //// Each non-zero's element will be stored as current(count) element of second(arrRes) array.
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] != 0)
            //    {
            //        arrRes[count] = arr[i];
            //        count++;
            //    }
            //}
            //Console.WriteLine("\n\nResult: ");

            //foreach (int item in arrRes)
            //{
            //    Console.Write(item + "  ");
            //}

            //Console.ReadKey();
            
            ////------------------------------------------------------------------------------

            //// Task 2
            //// Replace all negative(positive) elements in array as the left(right)-sided and keep order between them.


            //Random r = new Random();
            //// Set initial conditions:
            //int[] arr = new int[10];
            //int[] arrRes = new int[10];
            //int count = 0;

            //// Fill arrays:
            //Console.WriteLine("Initial array: ");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = r.Next(-10, 10);
            //    Thread.Sleep(20);
            //    arrRes[i] = 0;
            //    Console.Write(arr[i] + "  ");
            //}
            //// 1-st Part for replacing the negative elements in array 
            ////(according to the global 'count' as index of result array for both Parts):
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] < 0)
            //    {
            //        arrRes[count] = arr[i];
            //        count++;
            //    }
            //}
            //// 2-nd Part for replacing the positive elements in array:
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] >= 0)
            //    {
            //        arrRes[count] = arr[i];
            //        count++;
            //    }
            //}

            //Console.WriteLine("\n\nResult: ");

            //foreach (int item in arrRes)
            //{
            //    Console.Write(item + "  ");
            //}

            //Console.ReadKey();

            ////------------------------------------------------------------------------------

            //// Task 3
            //// Display some statistic data about entered string

            //int upperCount = 0, lowCount = 0, digCount = 0, spaceCount = 0, otherCount = 0;

            //Console.WriteLine("Enter some text: \n");
            //string str = Console.ReadLine();

            //Console.WriteLine("\n\n1. Total count: " + str.Length);
            //for (int i = 0; i < str.Length; i++)
            //{
            //    char ch = str[i];
            //    if (char.IsUpper(str[i])) upperCount++;
            //    if (char.IsLower(str[i])) lowCount++;
            //    if (char.IsDigit(str[i])) digCount++;
            //    if (char.IsWhiteSpace(str[i])) spaceCount++;
            //}

            //otherCount = str.Length - upperCount - lowCount - digCount - spaceCount;
            //Console.WriteLine("2. Upper case letters count: {0}\n3. Lower case letters count: {1}\n4. Digits count: {2}\n5. Space count: {3}\n6. Other count: {4}\n", upperCount, lowCount, digCount, spaceCount, otherCount);
            //Console.ReadKey();


            ////------------------------------------------------------------------------------

            //// Task 4
            //// Transform entered string into opposite case.

            //Console.WriteLine("Enter some text in upper and lower cases: \n");
            //string str = Console.ReadLine();
            //Console.WriteLine("\n\nResult: \n");
            //for (int i = 0; i < str.Length; i++)
            //{
            //    char ch = ' ';
            //    if (char.IsUpper(str, i)) ch = char.ToLower(str[i]);
            //    if (char.IsLower(str, i)) ch = char.ToUpper(str[i]);
            //    Console.Write(ch);
            //}

            //Console.ReadKey();

            ////------------------------------------------------------------------------------

            // Task 5
            // Calculate average mark for each subject.

            Random r = new Random();
            int numSubject = 5;
            int[][] marksChart = new int[numSubject][];

            for (int i = 0; i < marksChart.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                marksChart[i] = new int[r.Next(3, 15)];
                Console.Write("\n{0}. Subject: ", i + 1);
                for (int j = 0; j < marksChart[i].Length; j++)
                {
                    marksChart[i][j] = r.Next(1, 12);
                    Console.Write(marksChart[i][j] + " ");
                }
                Console.ForegroundColor = marksChart[i].Average() >= 8 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(" ||| Average mark: {0:F} \n", marksChart[i].Average());

                Thread.Sleep(50);
            }

            Console.ReadKey();

        }
    }
}
