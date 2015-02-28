using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Puzzle15
{
    class Cube
    {
        public Point center, goal;
        public byte targ;
        public int Number { get; set; }
        public List<Point> Points = new List<Point>();
    }
}
