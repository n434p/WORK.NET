using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProject
{
    interface IMoveDrive
    {
        double Distance { get; set; }
        void Drive();
    }
    interface IMoveFly:IMoveDrive
    {
        void Fly();
    }
}
