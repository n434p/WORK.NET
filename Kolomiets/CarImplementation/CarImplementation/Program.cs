using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CarImplementation
{
    class Program
    {
     

        static void Main(string[] args)
        {
            Car car = new Car();
            car.ChangeInfo += car.ShowInfo;
            Timer t = new Timer(200);
            t.Start();
            t.Elapsed += car.OnTimer;  
            t.Enabled = true;

            for (; ; )
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S: car.Driver = !car.Driver;
                        break;
                    case ConsoleKey.Z: car.SeatBelt = !car.SeatBelt;
                        break;
                    case ConsoleKey.T: car.ThrottlePedal = !car.ThrottlePedal;
                        break;
                    case ConsoleKey.C: car.ClutchPedal = !car.ClutchPedal;
                        break;
                    case ConsoleKey.B: car.BrakePedal = !car.BrakePedal;
                        break;
                    case ConsoleKey.H: car.HandBrake = !car.HandBrake;
                        break;
                    case ConsoleKey.K: car.KeyEngine = !car.KeyEngine;
                        break;
                    case ConsoleKey.N: car.Gear = Car.Transmission.N;
                        break;
                    case ConsoleKey.R: car.Gear = Car.Transmission.R;
                        break;
                    case ConsoleKey.D1: car.Gear = Car.Transmission.G1;
                        break;
                    case ConsoleKey.D2: car.Gear = Car.Transmission.G2;
                        break;
                    case ConsoleKey.D3: car.Gear = Car.Transmission.G3;
                        break;
                    case ConsoleKey.D4: car.Gear = Car.Transmission.G4;
                        break;
                    case ConsoleKey.Spacebar: return;
                }
            }

            

            
        }

      
    }
}
