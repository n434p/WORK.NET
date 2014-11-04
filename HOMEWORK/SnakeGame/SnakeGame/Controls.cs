using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Controls
    {
        public int Speed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public bool Direction { get; set; }

        public int Down { set { Y++; } }
        public int Up { set { Y--; } }
        public int Left { set { X--; } }
        public int Right { set { X++; } }

        public void Move(int [] arr)
        {
            
        }
    }
}
