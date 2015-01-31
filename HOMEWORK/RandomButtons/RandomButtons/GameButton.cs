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

        public void f(double angle)
        {
            RotateTransform rt = new RotateTransform(angle, this.Margin.Top + (this.Height / 2), this.Margin.Left + (this.Width / 2));
            this.RenderTransform = rt;
        }
        
    }
}
