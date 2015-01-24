using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CarImplementation
{
    class CarEvents : EventArgs
    {
        public readonly string mes;
        public CarEvents(string message)
        {
            mes = message;
        }
    }
    class Car
    {
        #region Init
        private string info = "";
        private bool driver, seatBelt, handBrake, keyEngine, clutchPedal, brakePedal, throttlePedal;
        public int velocity;
        public int gearRatio;
        public enum Transmission {R=-1,N,G1,G2,G3,G4}

        private Transmission gear;
        public Transmission Gear 
        { 
            get { return gear; }
            set
            {
                if (ClutchPedal&&Driver)
                {
                    switch (value)
                    {
                        case Transmission.R:
                            if (velocity == 0) { gear = value; gearRatio = (int)gear; Info = Info = gear + " - gear shifted to - " + value; }
                            else { Info = "You must stop car before reverse driving!"; }
                            break;
                        case Transmission.N: gearRatio = (int)gear; Info = gear + " - gear shifted to - " + value; gear = value;
                            break;
                        case Transmission.G1: gearRatio = (int)gear; Info = gear + " - gear shifted to - " + value; gear = value;
                            break;
                        case Transmission.G2: gearRatio = (int)gear; Info = gear + " - gear shifted to - " + value; gear = value;
                            break;
                        case Transmission.G3: gearRatio = (int)gear; Info = gear + " - gear shifted to - " + value; gear = value;
                            break;
                        case Transmission.G4: gearRatio = (int)gear; Info = gear + " - gear shifted to - " + value; gear = value;
                            break;
                    }
                }
                
            }
        }

        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                if (ChangeInfo != null)
                ChangeInfo(this, new CarEvents(info));    
            }
        }
        public bool Driver
        {
            get
            {
                Info = (driver) ? "\nYou are driver...\n" : "\nPlease sit in the car...\n";
                return driver;
            }
            set
            {
                if (value == driver)
                {
                    Info = (driver) ? "\nYou are already in the car...\n" : "\nYou are even not in the car to leave from\n";
                }
                else
                {
                    Info = (value) ? "\nSitting in the car...\n" : "\nLeaving car...\n";
                    driver = value;
                }
            }
        }
        public bool SeatBelt
        {
            get
            {
                Info = (seatBelt) ? "\nSeatbelt is locked\n" : "\nSeatbelt is not locked\n";
                return seatBelt;
            }
            set
            {
                if (!Driver) return;
                if (value == seatBelt)
                    Info = (seatBelt) ? "\nYou are already lock seatbelt...\n" : "\nYou are even not lock seatbelt\n";
                else
                {
                    Info = (value) ? "\nLocking seatbelt...\n" : "\nUnlocking seatbelt...\n";
                    seatBelt = value;
                }
            }
        }
        public bool HandBrake
        {
            get
            {
                Info = (handBrake) ? "\nHandbrake is up\n" : "\nHandbrake is down\n";
                return handBrake;
            }
            set
            {
                if (!Driver) return;
                if (value == handBrake)
                    Info = (handBrake) ? "\nYou are already up handbrake...\n" : "\nYou are even not down handbrake\n";
                else
                {
                    Info = (value) ? "\nOn handbrake...\n" : "\nOff handbrake...\n";
                    if (value && gearRatio != 0) { gearRatio = 0; }
                    gearRatio = (int)Gear;
                    handBrake = value;
                }
            }
        }
        public bool KeyEngine
        {
            get
            {
                Info = (keyEngine) ? "\nEngine started\n" : "\nEngine not started\n";
                return keyEngine;
            }
            set
            {
                if (!Driver) return;
                if (value == keyEngine)
                    Info = (keyEngine) ? "\nYou are already start engine...\n" : "\nYou are even not start engine\n";
                else
                {
                    Info = (value) ? "\nStarting engine...\n" : "\nStopping engine...\n";
                    if (value && Gear != Transmission.N) Info = "You car stalled. Replace gear shift to - N.\n";
                    else keyEngine = value;
                }
            }
        }
        public bool ClutchPedal
        {
            get
            {
                Info = (clutchPedal) ? "\nClutch pedal pushed\n" : "\nClutch pedal released\n";
                return clutchPedal;
            }
            set
            {
                if (!Driver) return;
                if (value == clutchPedal)
                    Info = (clutchPedal) ? "\nYou are already pushing clutch pedal...\n" : "\nYou are even not pushing clutch pedal\n";
                else
                {
                    Info = (value) ? "\nPushing clutch pedal...\n" : "\nReleasing clutch pedal...\n";
                    if (gearRatio != 0 && value) { gearRatio = 0; }
                    if (!value) gearRatio = (int)Gear;
                    clutchPedal = value;
                }
            }
        }
        public bool BrakePedal
        {
            get
            {
                Info = (brakePedal) ? "\nStop pedal pushed\n" : "\nStop pedal released\n";
                return brakePedal;
            }
            set
            {
                if (!Driver) return;
                if (value == brakePedal)
                    Info = (brakePedal) ? "\nYou are already pushing stop pedal...\n" : "\nYou are even not pushing stop pedal\n";
                else
                {
                    Info = (value) ? "\nPushing stop pedal...\n" : "\nReleasing stop pedal...\n";
                    if (value) {  OnBrake(); }

                    brakePedal = value;
                }
            }
        }
        public bool ThrottlePedal
        {
            get
            {
                Info = (throttlePedal) ? "\nThrottle pedal pushed\n" : "\nThrottle pedal released\n";
                return throttlePedal;
            }
            set
            {
                if (!Driver) return;
                if (value == throttlePedal)
                    Info = (throttlePedal) ? "\nYou are already pushing throttle pedal...\n" : "\nYou are even not pushing throttle pedal\n";
                else
                {
                    Info = (value) ? "\nPushing throttle pedal...\n" : "\nReleasing throttle pedal...\n";
                    if (value) { OnThrottle();}
                    throttlePedal = value;
                }
            }
        }

        public Car()
        {
            velocity = 0;
          
            
        }
        #endregion

        #region events
        public event EventHandler<CarEvents> ChangeInfo;
        public event ElapsedEventHandler TimeHand;


        #endregion

        public void Drive()
        {
            bool error = false;
            if (!Driver) { Info = "Please sit in the car..."; return;}
            if (!SeatBelt) { Info = "Please check the seatbelt..."; error = true; }
            if (HandBrake) { Info = "Please check the handbrake..."; error = true; gearRatio = 0; velocity /= 2; }
            if (!KeyEngine) { Info = "Please start the engine..."; return; }
            if (ThrottlePedal) OnThrottle();
            if (ClutchPedal) gearRatio = 0;
            if (error) Info="Attention. You have some problems...";
        }

        public void OnThrottle() 
        {
           if(!ClutchPedal) velocity += 5 * gearRatio;
        }
       
        public void OnClutch()
        {
            
        }

        public void OnBrake()
        {
            velocity /= 2;
            if (velocity == 0 && Gear != Transmission.N) { Info = "You car stalled. Turn on engine key."; KeyEngine = false; }
        }

        public void GearShift(Transmission t) 
        {
            Gear = t;
        }

        public void ShowInfo(object ob, CarEvents e)
        {
            Console.Write("{0}",e.mes);
        }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Car: \n\n");
            Console.WriteLine("Velocity: \t\t "+velocity);
            Console.WriteLine("\nINFO: "+Info.ToUpper());
            Console.WriteLine("GEAR **** {0}",Gear);
            Console.WriteLine((ThrottlePedal)?"PUSHED":" - ");
            Console.WriteLine((BrakePedal) ? "PUSHED" : " - ");
            Console.WriteLine((ClutchPedal) ? "PUSHED" : " - ");
            Console.WriteLine((HandBrake) ? "ON" : " - ");
            Console.WriteLine((KeyEngine) ? "YES" : " - ");
            Console.WriteLine((SeatBelt) ? "OK" : " - ");
            Console.ResetColor();
            return "";
        }

        public void OnTimer(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(this);
            if (Driver) Drive();
        }

      
    }


}
