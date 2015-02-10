using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Snake
{
    enum Parts { snakeHead, snakeBody, apple, enemyB, enemyW };
    enum Direction { left = 0, up, right, down, stop };
    class Part: System.Windows.Controls.Button
    {
        public Direction Move = Direction.right;
        public double X
        {
            get { return Margin.Left; }
            set { Margin = new Thickness(value, Margin.Top, 0, 0); }
        }
        public double Y
        {
            get { return Margin.Top; }
            set { Margin = new Thickness(Margin.Left, value, 0, 0); }
        }

        public Parts Color { get; set; }
        public int Size;
        public Part(double x, double y, Parts c, int size = 10) 
        {
            Size = size;
            Width = Height = Size;
            X = x;
            Y = y;
         //   IsEnabled = false;
            Color = c;
            switch (c)
            {
                case Parts.snakeHead: 
                    Background = Brushes.Gold;
                    break;
                case Parts.snakeBody:
                    Background = Brushes.YellowGreen;
                    break;
                case Parts.apple:    
                    Background = Brushes.OrangeRed;
                    break;
                case Parts.enemyB:
                    Background = Brushes.Black;
                    break;
                case Parts.enemyW:
                    Background = Brushes.White;
                    break;  
            }
            

        
        }

    }
}
