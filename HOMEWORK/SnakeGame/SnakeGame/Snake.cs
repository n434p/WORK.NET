using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Snake: Controls
    {
        public static int Lives { get; set; }
        
        public List<Apple> Body {get; set;}

        public ConsoleColor Color { get; set; }

        public Snake() 
        {
           Body = new List<Apple>();
           Color = ConsoleColor.Green;
           Lives = 3;
        
           Body.Add(new Apple(7,7));
           
        }

        public void Test(int[] arr)
        {
            if (arr[0] == 0 && arr[1] == 0) Body[0].Left=1;
            if (arr[0] == 0 && arr[1] == 1) Body[0].Right = 1;
            if (arr[0] == 1 && arr[1] == 0) Body[0].Down = 1;
            if (arr[0] == 1 && arr[1] == 1) Body[0].Up = 1;
        }


        public void MoveSnake()
        {
            int[] arr = { 0, 0 };
 
            ConsoleKeyInfo action = new ConsoleKeyInfo();

            while (action.Key != ConsoleKey.Q)
            {
                action = Console.ReadKey(true);
                Console.WriteLine(this);
                Test(arr);
              

                switch (action.Key)
                {
                    case ConsoleKey.UpArrow:
                        arr = new int[] { 1, 1 };
                        break;
                    case ConsoleKey.DownArrow:
                        arr = new int[] { 1, 0 };
                        break;
                    case ConsoleKey.LeftArrow:
                        arr = new int[] { 0, 0 };
                        break;
                    case ConsoleKey.RightArrow:
                        arr = new int[] { 0, 1 };
                        break;


                    default: break;
                }
                
            }
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in Body)
            {
                Console.SetCursorPosition(item.X,item.Y);
                Console.Write("S");  
            }
            Console.ResetColor();
            return "";
        }
    }
}
