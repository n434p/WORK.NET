using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RandomButtons
{
    enum Direction { UpLeft=0, UpRight, DownLeft, DownRight}
    class GameButton:System.Windows.Controls.Button

    {
        public Direction Track { get; set; }
        public double Angle { get; set; }
        public double Speed { get; set; }
        public bool Bound { get; set; }


        public GameButton(int butNum,double size, double speed)
        {
            Height = size;
            Width = size;
            FontSize = size-10;
            Content = (butNum == 6||butNum == 9)?butNum+".":butNum.ToString();
            Track = Direction.DownLeft;
            Tag = butNum;
            Angle = 0;
            Bound = false;
            Speed = speed;

            HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
        }

        public void Rotate(double angle, double x, double y)
        {
            RotateTransform rt = new RotateTransform(angle, x, y);
            this.RenderTransform = rt;
        }

        public override string ToString()
        {
            return " " + Tag + " \nLeft " + this.Margin.Left +
                               " \nTop " + this.Margin.Top+
                               " \nRight " + this.Margin.Right+
                               " \nBottom "+this.Margin.Bottom;
        }
        
    }
}
