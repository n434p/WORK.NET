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
            Console.ReadKey();
            car.Driver = true;
            Console.ReadKey();
            car.SeatBelt = true;
            Console.ReadKey();
            car.SeatBelt = true;
            Console.ReadKey();
            car.HandBrake = false;
            Console.ReadKey();
            car.KeyEngine = false;
            Console.ReadKey();
            car.Drive();
            
            
           
            Console.ReadKey();
        }
    }
}
