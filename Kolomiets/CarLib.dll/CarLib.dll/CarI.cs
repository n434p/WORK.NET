using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLib.dll
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
        private string info;
        private bool driver, seatBelt, handBrake, keyEngine, clutchPedal, stopPedal, throttlePedal;
        public int velocity;

        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                ChangeInfo(this, new CarEvents(Info));
            }
        }
        public enum Transmission { R, N, T1, T2, T3, T4 }
        public Transmission gear;

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
                if (value == handBrake)
                    Info = (handBrake) ? "\nYou are already up handbrake...\n" : "\nYou are even not down handbrake\n";
                else
                {
                    Info = (value) ? "\nOn handbrake...\n" : "\nOff handbrake...\n";
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
                if (value == keyEngine)
                    Info = (keyEngine) ? "\nYou are already start engine...\n" : "\nYou are even not start engine\n";
                else
                {
                    Info = (value) ? "\nStarting engine...\n" : "\nStopping engine...\n";
                    keyEngine = value;
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
                if (value == clutchPedal)
                    Info = (clutchPedal) ? "\nYou are already pushing clutch pedal...\n" : "\nYou are even not pushing clutch pedal\n";
                else
                {
                    Info = (value) ? "\nPushing clutch pedal...\n" : "\nReleasing clutch pedal...\n";
                    if (value) IsClutch(this, new CarEvents(""));
                    clutchPedal = value;
                }
            }
        }
        public bool StopPedal
        {
            get
            {
                Info = (stopPedal) ? "\nStop pedal pushed\n" : "\nStop pedal released\n";
                return stopPedal;
            }
            set
            {
                if (value == stopPedal)
                    Info = (stopPedal) ? "\nYou are already pushing stop pedal...\n" : "\nYou are even not pushing stop pedal\n";
                else
                {
                    Info = (value) ? "\nPushing stop pedal...\n" : "\nReleasing stop pedal...\n";
                    if (value) IsStop(this, new CarEvents(""));
                    stopPedal = value;
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
                if (value == throttlePedal)
                    Info = (throttlePedal) ? "\nYou are already pushing throttle pedal...\n" : "\nYou are even not pushing throttle pedal\n";
                else
                {
                    Info = (value) ? "\nPushing throttle pedal...\n" : "\nReleasing throttle pedal...\n";
                    if (value) IsThrottle(this, new CarEvents(""));
                    throttlePedal = value;
                }
            }
        }

        public Car()
        {

        }
        #endregion

        #region events
        public event EventHandler<CarEvents> ChangeInfo;
        public event EventHandler<CarEvents> IsStop;
        public event EventHandler<CarEvents> IsThrottle;
        public event EventHandler<CarEvents> IsClutch;
        #endregion

        public void Drive()
        {
            if (!Driver) { ChangeInfo(this, new CarEvents("Please sit in the car...")); return; }
            else if (!SeatBelt) { ChangeInfo(this, new CarEvents("Please check the seatbelt...")); return; }
            else if (HandBrake) { ChangeInfo(this, new CarEvents("Please check the handbrake...")); return; }
            else if (!KeyEngine) { ChangeInfo(this, new CarEvents("Please start the engine...")); return; }
            else { }


        }

        public void OnThrottle()
        {
            if (gear == Transmission.N) ChangeInfo(this, new CarEvents("Missing gear..."));
            else { Acceleration(); }
        }
        public void Acceleration()
        {
            velocity += 20;
        }
        public void OnClutch(Transmission t)
        {

            if (gear != Transmission.N)
            {
                ChangeInfo(this, new CarEvents(string.Format("Changing {} gear to {}... ", gear, t)));
                gear = t;
            }
        }
        public void OnStop()
        {

        }

        public Transmission GearShift(Transmission current)
        {
            if (current != gear) return current;
            return gear;
        }

        public void ShowInfo(object ob, CarEvents e)
        {
            Console.WriteLine("{0}", e.mes);
        }

    }
}
