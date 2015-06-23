using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternProj
{
    class BycycleSingletone
    {
        static BycycleSingletone instance;
        int wheelsCount;
        string manufacturer;

        static BycycleSingletone() 
        {
            instance = new BycycleSingletone();
        }

        private BycycleSingletone() {
            wheelsCount = 2;
            manufacturer = "Ukraine";
        }

        public static BycycleSingletone Instance { get { return instance; } }
        public int WheelCount { get { return wheelsCount; } }
        public string Manufacturer { get { return manufacturer; } }

        public override string ToString()
        {
            return string.Format("wheels count = {0}\t manufac = {1}\t",wheelsCount,manufacturer);
        }
    }
}
