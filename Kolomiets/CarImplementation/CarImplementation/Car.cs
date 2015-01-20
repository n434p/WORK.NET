using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarImplementation
{
    class Car
    {
        enum Transmission { N0,T1,T2,T3,T4 }
        public bool IsDriver { get; set; }
        public bool Passed { get; set; }
        public bool Braker { get; set; }
        public bool KeyEngine { get; set; }
        public bool GridPedal { get; set; }
        public bool StopPedal { get; set; }
        public bool ThrottlePedal { get; set; }

        public int velocity;

        public Car() 
        {

        }

        public void Drive(bool action) 
        {
            if (!IsDriver) { }
            else if (!Braker)
        }


    }

    
}
