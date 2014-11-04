using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMatrix
{
    class Program
    {
        public static int[] Met(char[,] arr, char ch) 
        {
            for (int i = 0; i < arr.GetLength(0); i++)

                for (int j = 0; j < arr.GetLength(1); j++)

                    if (arr[i, j] == ch) return new int[2] { i, j };
            return 
             }

        public static void  Metod()
        {
             char[,] arr = new char[5, 5];  

            string [] strArr = new string[5]{"polte","rwyms","oaipt","bdanr", "lemes"};

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = strArr[i].ToCharArray()[j];
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

            string[] strWords = new string[3] { "olympiad", "problem", "test" };

            int index = 0;

            do
            {
                



            } while (true);
            




            
	
        }


        static void Main(string[] args)
        {
            Metod();
            Console.ReadKey();
           
        }
    }
}
