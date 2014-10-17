using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Snail
{
    class Program
    {
        /// <summary>
        /// Transforms initial square array inti snail wiev.
        /// </summary>
        /// <param name="square array"></param>
        /// <param name="clockwise placement"></param>
        /// <param name="random filling"></param>
        /// <returns></returns>
        
        public static int[,] SnailInit(int[,] arrQuadr, bool clockwise = true)
        {
            
            int size = arrQuadr.GetLength(0);
            
            int[] arr = new int[(size) * (size)];// all elements from square array will be stored in new stripe array;
            int n = 0; // counter for natural sequence mode;
            for (int i = 0; i < arrQuadr.GetLength(0); i++) 
                for (int j = 0; j < arrQuadr.GetLength(1); j++)
                {
                    arr[n] = arrQuadr[i, j];
                    n++;
                }
            Array.Sort(arr);
            if (!clockwise) Array.Reverse(arr);

            int row = 0, col = 0, ind = 0;// position (row,col) for array element[ind]
            n = 0; // current contour for snail movement.

            while (ind < arr.Length)
            {
                n++;

                if ((col == row) & (col == size / 2)) 
                {
                    arrQuadr[row, row] = arr[ind];
                    break;
                }

                for (int i = col; i < size - n; i++) // fills current row(top side) except last element
                {
                    arrQuadr[row, i] = arr[ind];
                    ind++;
                }
                col = size - n; // fills last element in current row

                for (int i = row; i < size - n; i++) // fills current col(left side) except last element
                {
                    arrQuadr[i, col] = arr[ind];
                    ind++;
                }
                row = size - n; // fills last element in current col

                for (int i = col; i >= n; i--)  // fills current row(bottom side) except first element
                {
                    arrQuadr[row, i] = arr[ind];
                    ind++;
                }
                col = n - 1; // fills first element in current row

                for (int i = row; i >= n; i--)  // fills current col(right side) except first element
                {
                    arrQuadr[i, col] = arr[ind];
                    ind++;
                }
                col = n;
                row = n;  // replaces cursor for the next contour
            }
            return arrQuadr;
        }

        /// <summary>
        /// Returns order of num.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int NumOrder(int num)
        {
            int count = 1;
            while (num / 10 != 0)
            {
                num /= 10;
                count++;
            }
            return count;
        }

        /// <summary>
        /// Displays elements of array in better case. 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="space"></param>
        public static void DisplayArr(int[,] arr, int space = 5)
        {
            try
            {
                if (space <= 3) throw new Exception(); // space - distance between elements in rows including num order
            }
            catch
            {
                space = 5;
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    // Calculates step for the color. Enum has 16 built-in elements. 
                    // We use next 8 colors after seventh. 
                    int color = (arr[i, j] * 8) / (arr.GetLength(0)*arr.GetLength(1)); 
                    Console.ForegroundColor = (ConsoleColor) color+7; 
                    Console.Write(arr[i, j]);
                    // Builds table's template that has distance between elements in a row equals to 'space'
                    Console.SetCursorPosition(Console.CursorLeft + space - NumOrder(arr[i, j]), Console.CursorTop);
                }

                Console.WriteLine();
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Performs menu for the snail task that contains options as square array size,
        /// clockwise direction for elements statement and randomize filling.
        /// </summary>
        public static void Menu()
        {
            bool quit = false;
            Random r = new Random();

            while (!quit)
            {
                Console.WriteLine("Transformation any quadrant array into snail view...");
                Console.WriteLine("\nPlease enter number as array's size: ");
                int size;
                bool clockwise, random;
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                    if ((size == 0)||(size >= 16)) throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Your entry doesn't fit our requirements. \nWe will use standart [size=5] in this case.");
                    size = 5;
                }

                int[,] arrQuadr = new int[size, size];
               
                Console.WriteLine("\nClockwise direction?:[y-default/n]");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        clockwise = true;
                        break;
                    case ConsoleKey.N:
                        clockwise = false;
                        break;

                    default:
                        Console.WriteLine("\nClockwise direction.");
                        clockwise = true;
                        break;
                }

                Console.WriteLine("\nRandom array?:[y/n-default] ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        random = true;
                        break;
                    case ConsoleKey.N:
                        random = false;
                        break;

                    default:
                        Console.WriteLine("\nNatural sequence.");
                        random = false;
                        break;
                }
                Console.Clear();
                Console.WriteLine("Your configuration:\n Array size: {0} \n Clockwise: {1} \n Random: {2} \n", size, clockwise, random);

                int n = 0; // counter for natural sequence mode
                for (int i = 0; i < arrQuadr.GetLength(0); i++)// fills array 
                    for (int j = 0; j < arrQuadr.GetLength(1); j++)
                    {
                        Thread.Sleep(5);
                        if (random) arrQuadr[i, j] = r.Next(1, size*size);// random case
                        else
                        arrQuadr[i, j]  = n + 1; // natural sequence
                        n++;
                    }

                DisplayArr(SnailInit(arrQuadr, clockwise)); // Displays snail array

                Console.WriteLine("\nPress any key to try again...\n\n For quit press [q]: \n");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Q:
                        Console.WriteLine("\nBye!");
                        quit = true;
                        break;

                    default:
                        Console.Clear();
                        break;
                }

            }
        }

        static void Main(string[] args)
        {
           Menu();
        }
    }
}
