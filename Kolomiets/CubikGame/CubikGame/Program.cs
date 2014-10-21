using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubikGame
{
    class Program
    {
        static Random r = new Random();
        static char[,] InitCubik(int number)
        {
            char[,] cubik = new char[7, 7];
            for (int i = 0; i < cubik.GetLength(0); i++)
                for (int j = 0; j < cubik.GetLength(1); j++)
                    if (i == 0 || j == 0 || i == cubik.GetLength(0) - 1 || j == cubik.GetLength(1) - 1)
                        cubik[i, j] = '*';
                    else
                        cubik[i, j] = ' ';
            switch (number)
            {
                case 1:
                    cubik[3, 3] = '*';
                    break;
                case 2:
                    cubik[3, 2] = '*';
                    cubik[3, 4] = '*';
                    break;
                case 3:
                    cubik[2, 2] = '*';
                    cubik[3, 3] = '*';
                    cubik[4, 4] = '*';
                    break;
            }
            return cubik;
        }
        static int ShowCubik()
        {

            int number = r.Next(1, 4);
            char[,] cubik = InitCubik(number);
            for (int i = 0; i < cubik.GetLength(0); i++)
            {
                for (int j = 0; j < cubik.GetLength(1); j++)
                    Console.Write(cubik[i, j]);
                Console.WriteLine();
            }
            return number;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ShowCubik());
        }
    }
}
