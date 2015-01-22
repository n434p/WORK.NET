using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarImplementation
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Car car = new Car();
            car.ChangeInfo += car.ShowInfo;

            car.Driver = true;
            car.SeatBelt = true;
            car.SeatBelt = true;
            car.HandBrake = false;
            car.KeyEngine = false;
            car.Drive();
            
            
           
            Console.ReadKey();
        }
    }
}
