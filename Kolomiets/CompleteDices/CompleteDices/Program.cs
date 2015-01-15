using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteDices
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            //if (File.Exists("save.0"))
            //{
            //    Console.WriteLine("Do you want to continue previous game?\n");
            //    switch (Console.ReadKey().Key)
            //    {
            //        case ConsoleKey.Y:
            //            Game contGame = Status.ReadStatus();
            //            contGame.GameMenu();
            //            break;
            //        case ConsoleKey.N:
            //            Game newGame = new Game();
            //            newGame.GameMenu();
            //            break;
            //        default:
            //            break;
            //    }

            game.GameMenu();

            //Thread tr = Status.ReadStatus(); 
            //tr.Resume();

            }
        }
    }
}
