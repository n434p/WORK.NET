using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteDices
{
    [Serializable]
    class Game
    {
        static Random r = new Random();

        char[,] InitDice(int number)
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
                case 4:
                    cubik[2, 2] = cubik[2, 4] = cubik[4, 2] = cubik[4, 4] = '*';
                    break;
                case 5:
                    cubik[2, 2] = cubik[2, 4] = cubik[4, 2] = cubik[4, 4] = cubik[3, 3] = '*';
                    break;
                case 6:
                    cubik[2, 2] = cubik[2, 4] = cubik[3, 2] = cubik[3, 4] = cubik[4, 2] = cubik[4, 4] = '*';
                    break;

            }
            return cubik;
        }

        int ShowDice()
        {
            int number = r.Next(1, 7);
            char[,] cubik = InitDice(number);
            for (int i = 0; i < cubik.GetLength(0); i++)
            {
                for (int j = 0; j < cubik.GetLength(1); j++)
                    Console.Write(cubik[i, j]);
                Console.WriteLine();
            }
            return number;
        }

        public void GameMenu()
        {
            bool restart = false;
            bool isSaved = false;
            int start = 1;

            while (!restart)
            {

                int pcSum = 0, youSum = 0;

                Console.Clear();
                Console.WriteLine("Begin game: ");
                Console.WriteLine("Who will start [1 - you / 2 - PC]? ");
                int turn = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i < 4; i++)
                {
                    switch (turn)
                    {
                        
  
                        case 1:
                            Console.WriteLine("Your's {0} turn: ", i);
                            youSum += ShowDice() + ShowDice();
                            Thread.Sleep(20);
                            Console.WriteLine("PC's {0} turn: ", i);
                            pcSum += ShowDice() + ShowDice();
                            

                            break;
                        case 2:
                            Console.WriteLine("PC's {0} turn: ", i);
                            pcSum += ShowDice() + ShowDice();
                            Thread.Sleep(20);
                            Console.WriteLine("Your's {0} turn: ", i);
                            youSum += ShowDice() + ShowDice();
                            break;
                    }
                    
                    

                }
                Console.WriteLine("\n\n PC result: {0}\n You result: {1}\n", pcSum, youSum);

               
                Status.WriteStatus(Thread.CurrentThread);

                if (youSum == pcSum) Console.WriteLine("Draw game!");

                if (youSum > pcSum) Console.WriteLine("You win!");
                else Console.WriteLine("You lost!");


                Console.WriteLine("We will start again if you press '1'. For exit press '0': ");
                start = Convert.ToInt32(Console.ReadLine());
                if (start == 0) break;

            }

        }

    }
}
