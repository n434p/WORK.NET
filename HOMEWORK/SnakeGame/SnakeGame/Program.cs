using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        private void KeyDown(object sender, ConsoleKeyInfo e) 
        {
            if (e.Key == ConsoleKey.M) Console.WriteLine("M is pressed!"); 
        }



        static void Main(string[] args)
        {
            Field field = new Field(10, 10,5,5);
          //  field.Color = ConsoleColor.Blue;
            Snake snake = new Snake();
          //  snake.Color = ConsoleColor.Green;
            Apple apple = new Apple();

            snake.MoveSnake();

            Console.WriteLine(field);
            Console.WriteLine(snake);
            Console.WriteLine(apple);

            
            

            snake.MoveSnake();
            
            Console.ReadKey();
        }
    }
}
