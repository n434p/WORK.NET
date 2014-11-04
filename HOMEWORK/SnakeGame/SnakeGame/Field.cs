using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Field
    {
        public static int Length { get; set; }
        public static int Width { get; set; }
        public static int Left { get; set; }
        public static int Right { get { return Left + Width; } }      
        public static int Top { get; set; }
        public static int Bottom { get { return Top + Length; } }

        public ConsoleColor Color { get; set; }

        public Field(int length, int width,int startTop=10, int startLeft=0) 
        {
            Left = startLeft;
            Top = startTop;
            Length = length;
            Width = width;

            Color = ConsoleColor.White;
                           
        }

        public override string ToString()
        {
            Console.ForegroundColor = Color;
            for (int i = Top; i <= Bottom; i++)
            
                for (int j = Left; j <= Right; j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (i == Top || i == Bottom || j == Left || j == Right) Console.Write('#');
                    else Console.Write('.');
                }
            Console.ResetColor();
            return "";
        }
       

        
        

    }
}
