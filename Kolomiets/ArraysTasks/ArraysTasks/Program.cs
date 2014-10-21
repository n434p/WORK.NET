using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArraysTasks
{
    class Program
    {
        /// <summary>
        /// Replaces in each pair of array previous and next elements.
        /// </summary>

        static void PairReplace()
        {
            Random r = new Random();
            int[] arr = new int[r.Next(1, 10)];
            int temp = 0; // buffer variable to save previous value.
                       
            Console.WriteLine("Random array:");

            for (int i = 0; i < arr.Length; i++) // fills created array and displays it.
            {
                arr[i] = r.Next(1, 10);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            for (int k = 0; k < arr.Length / 2; k++) // replaces elements according to task.
            {
                temp = arr[2 * k];
                arr[2 * k] = arr[2 * k + 1];
                arr[2 * k + 1] = temp;
            }

            Console.WriteLine("Modificated array:");


            for (int k = 0; k < arr.Length; k++) // displays reult.
            {
                Console.Write(arr[k] + " ");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Replaces selected columns in array between each other.
        /// </summary>

        static void ColReplace()
        {
            int col1, col2, temp = 0; // indexes of first and second columns and buffer variable for store prrevious value.
            Random r = new Random();
            int[,] arr = new int[r.Next(1, 10), r.Next(1, 10)];

            Console.WriteLine("Your array:");

            for (int i = 0; i < arr.GetLength(0); i++) // fills and displays random array.
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(0, 10);
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }

            // Enters initial conditions.

            Console.WriteLine("1-st column number [1 - {0}] to change with:", arr.GetLength(1));
            col1 = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("2-nd column number [1 - {0}] to change with:", arr.GetLength(1));
            col2 = Convert.ToInt32(Console.ReadLine()) - 1;

            for (int i = 0; i < arr.GetLength(0); i++) // replaces elements between each other.
            {
                temp = arr[i, col1];
                arr[i, col1] = arr[i, col2];
                arr[i, col2] = temp;
            }
            Console.WriteLine();

            Console.WriteLine("Result:");

            for (int i = 0; i < arr.GetLength(0); i++) // displays result as array.
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Replaces all zero's elements in array to the right side ad change them as "-1'.
        /// </summary>

        static void ZerosToRight()
        {
            Random r = new Random();
            // Sets initial conditions:
            int[] arr = new int[10];
            int[] arrRes = new int[10]; // array for storing total result. 
            int count = 0; // variable for keep index of non-zero's element.

            // Fills arrays:
            Console.WriteLine("Initial array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(0, 4);
                Thread.Sleep(20);
                // Prepare new array with needed format. 
                // It will helpful in refactoring elements from "0" to "-1"
                arrRes[i] = -1;
                Console.Write(arr[i] + "  ");
            }
            // Each non-zero's element will be stored as current(count) element of second(arrRes) array.
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arrRes[count] = arr[i];
                    count++;
                }
            }
            Console.WriteLine("\n\nResult: ");

            foreach (int item in arrRes)
            {
                Console.Write(item + "  ");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Replaces all negative(positive) elements in array as the left(right)-sided and keep order between them.
        /// </summary>

        static void NegThanPos()
        {
            Random r = new Random();
            // Sets initial conditions:
            int[] arr = new int[10];
            int[] arrRes = new int[10]; // keeps final result.
            int count = 0; // stores current index of array.

            // Fills arrays:
            Console.WriteLine("Initial array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-10, 10);
                Thread.Sleep(20);
                arrRes[i] = 0;
                Console.Write(arr[i] + "  ");
            }
            // 1-st Part for replacing the negative elements in array 
            // according to the global 'count' as index of result array for both Parts:
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arrRes[count] = arr[i];
                    count++;
                }
            }
            // 2-nd Part for replacing the positive elements in array:
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    arrRes[count] = arr[i];
                    count++;
                }
            }

            Console.WriteLine("\n\nResult: ");

            foreach (int item in arrRes)
            {
                Console.Write(item + "  ");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Displays some statistic data about entered string
        /// </summary>

        static void StrStatistic()
        {
            int upperCount = 0, lowCount = 0, digCount = 0, spaceCount = 0, specCount = 0; // counters for each group of elements.

            Console.WriteLine("Enter some text: \n");
            string str = Console.ReadLine();

            Console.WriteLine("\n\n1. Total count: " + str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i])) upperCount++;
                if (char.IsLower(str[i])) lowCount++;
                if (char.IsDigit(str[i])) digCount++;
                if (char.IsWhiteSpace(str[i])) spaceCount++;
            }

            specCount = str.Length - upperCount - lowCount - digCount - spaceCount;
            Console.WriteLine("2. Upper case letters count: {0}\n3. Lower case letters count: {1}\n4. Digits count: {2}\n5. Space count: {3}\n6. Other count: {4}\n", upperCount, lowCount, digCount, spaceCount, specCount);
            Console.ReadKey();
        }

        /// <summary>
        /// Transforms entered string into opposite case.
        /// </summary>

        static void OppositeCase()
        {
            Console.WriteLine("Enter some text in upper and lower cases: \n");
            string str = Console.ReadLine();
            Console.WriteLine("\n\nResult: \n");
            for (int i = 0; i < str.Length; i++)
            {
                char ch = ' '; // temporary value for keep current char in needed case.
                if (char.IsUpper(str, i)) ch = char.ToLower(str[i]);
                if (char.IsLower(str, i)) ch = char.ToUpper(str[i]);
                Console.Write(ch);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Gets average mark for each subject in chart.
        /// </summary>

        static void AverageMark()
        {
            Random r = new Random();
            int numSubject = 5;
            double average = 0;

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
                average = marksChart[i].Average();
                // Averege marks that below 8 displays as red. Other marks displays as green.
                Console.ForegroundColor = average >= 8 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(" ||| Average mark: {0:F} \n", average);

                Thread.Sleep(50);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Removes from entered number all "1".
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>

        static int RemoveOne(int number)
        {
            Console.WriteLine(number);
            int decOrder = 1;
            int result = 0;

            while (true)
            {
                if (number % 10 != 1)
                {
                    result += decOrder * (number % 10);
                    decOrder *= 10;
                }
                number /= 10;
                if (number == 0)
                    break;
            }
            return result;
        }

        /// <summary>
        /// Checks entered number as palindrome.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>

        static bool Palindrome(int number)
        {
            int order = 1;
            int reverseNum = number;
            int numCopy = reverseNum;

            while (true)
            {
                reverseNum /= 10;
                if (reverseNum == 0)
                    break;
                order *= 10;
            }

            while (true)
            {
                reverseNum += (numCopy % 10) * order;
                order /= 10;
                numCopy /= 10;
                if (order == 0)
                    break;
            }
            return (reverseNum == number) ? true : false;
        }

        /// <summary>
        /// Checks the specified string with the reversed and returns boolean value.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public static bool StrCheck(string str)
        {
            if (str.Length <= 1)
                return true;

            return (str[str.Length - 1] == str[0]) & (StrCheck(str.Remove(0, 1).Remove(str.Length - 2, 1)));

        }

        static void Main(string[] args)
        {
            // Static methods without params.
            //PairReplace();
            //ColReplace();
            //ZerosToRight();
            //NegThanPos();
            //StrStatistic();
            //OppositeCase();
            //AverageMark();

            // Removes "1".
             Console.WriteLine(RemoveOne(2010231242));

            // Checks as palindrome.
             Console.WriteLine(Palindrome(122404221));

            // Boolean method based on recursion and returns true if string equals to reverse string.
            // Console.WriteLine(StrCheck("asdf gh jkj hg fdsa"));

            Console.ReadKey();
        }
    }
}
