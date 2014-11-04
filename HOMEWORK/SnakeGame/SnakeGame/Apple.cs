using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Apple: Controls
    {
        public ConsoleColor Color { get; set; }

        public Apple(int x = 15,int y=15) 
        {
            Color = ConsoleColor.Red;
            X = x;
            Y = y;          
        }

        public override string ToString()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write('Q');
            Console.ResetColor();
            return "";
        }
    }
}
