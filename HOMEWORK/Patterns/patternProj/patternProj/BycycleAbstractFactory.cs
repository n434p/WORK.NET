using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternProj
{
    public abstract class BycycleFactory
    {
        public abstract AbstractCycle CreateCycle();
        public abstract AbstractWheels CreateWheels();
    }

    public abstract class AbstractCycle
    {
        public abstract void WheelCount(AbstractWheels wheels);
    }

    public abstract class AbstractWheels
    {
        public int wheelsCount;
    }

    class UkraineBycycle : AbstractCycle
    {
        public override void WheelCount(AbstractWheels wheels)
        {
            Console.WriteLine("Wheels count ={0}", wheels.wheelsCount.ToString());
        }
    }

    class UkraineWheels : AbstractWheels 
    {
        public UkraineWheels()
        {
            wheelsCount = 2;
        }
    }

    class BabyBycycle : AbstractCycle
    {
        public override void WheelCount(AbstractWheels wheels)
        {
            Console.WriteLine("Wheels count ={0}", wheels.wheelsCount.ToString());
        }
    }

    class BabyWheels : AbstractWheels
    {
        public BabyWheels()
        {
            wheelsCount = 3;
        }
    }

    class UkraineCycleFactory : BycycleFactory 
    {

        public override AbstractCycle CreateCycle()
        {
            return new UkraineBycycle();
        }

        public override AbstractWheels CreateWheels()
        {
            return new UkraineWheels();
        }
    }

    class BabyCycleFactory : BycycleFactory
    {

        public override AbstractCycle CreateCycle()
        {
            return new BabyBycycle();
        }

        public override AbstractWheels CreateWheels()
        {
            return new BabyWheels();
        }
    }


    class CycleClient
    {
        private AbstractCycle abstractCycle;
        private AbstractWheels abstractWheels;

        public CycleClient(BycycleFactory cycleFactory)
        {
            abstractCycle = cycleFactory.CreateCycle();
            abstractWheels = cycleFactory.CreateWheels();
        }

        public void Info()
        {
            abstractCycle.WheelCount(abstractWheels);
        }
    }
}
