﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Puzzle15
{
    class Cube
    {
        public Point center,target,goal;
        public int Number { get; set; }
        public List<byte> children = new List<byte>();
        public List<Point> Points = new List<Point>();

        
        public Cube()
        {
            
        }

        


    }
}
