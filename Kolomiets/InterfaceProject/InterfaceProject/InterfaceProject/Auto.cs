using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProject
{
    class Auto:IMoveDrive
    {
        public double Distance
        {
            get;
            set;
        }
        //void IMove.Fly()
        //{
        //   Console.WriteLine("не может летать!!!!");
        //}

        public void Drive()
        {
            Distance += 10;
        }
        public override string ToString()
        {
            return "Auto: " + Distance + "\n";
        }
    }
}
