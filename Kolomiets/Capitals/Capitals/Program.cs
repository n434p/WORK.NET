using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capitals;



namespace Capitals
{
    class Program
    {
        static void Main(string[] args)
        {

            Country1.Town1 t1 = new Country1.Town1();
            Country2.Town2 t2 = new Country2.Town2();

            if (t1 > t2) Console.WriteLine("first town bigger!");
            else Console.WriteLine("Second town bigger!");
        }
    }

    public class Capital 
    {
        public string Name { get; set; }
        protected int Population;

        public static bool operator >(Capital c1, Capital c2) 
        {
            if (c1.Population > c2.Population) return true;
            return false;
        }

        public static bool operator <(Capital c1, Capital c2)
        {
            return !(c1 > c2);
        }

        public override string ToString()
        {
            return "Capital: "+Name+" Population: "+Population;
        }
    }
}

namespace Country1 

{
    class Town1: Capital 
    {
        public Town1() 
        {
            Name = "First country";
            Population = 100;
        }   
    }
}

namespace Country2
{
    class Town2 : Capital 
    {
        public Town2() 
        {
            Name = "Second country";
            Population = 200;
        }   
    }

}

namespace Country3
{
    class Town3: Capital
    {
        public Town3() 
        {
            Name = "Third country";
            Population = 3000;
        }   
    }

}
