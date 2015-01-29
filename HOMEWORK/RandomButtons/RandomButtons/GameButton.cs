using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomButtons
{
    enum Direction { UpLeft=0, UpRight, DownLeft, DownRight}
    class GameButton:System.Windows.Controls.Button
    {
        public Direction Track { get; set; }
        

        
    }
}
