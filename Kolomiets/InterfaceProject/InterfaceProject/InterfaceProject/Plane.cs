using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProject
{
    class Plane : IMoveFly
    {
        public double Distance
        {
            get;
            set;
        }
        public void Fly()
        {
            Distance += 100; 
            
        }
        public void Drive()
        {
            Distance += 5; 
        }
        public override string ToString()
        {
            return "Plane: " + Distance + "\n";
        }
    }
}
