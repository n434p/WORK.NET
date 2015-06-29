using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us create a Simple Cake Base first
            CakeBase cBase = new CakeBase();
            PrintProductDetails(cBase);

            // Lets add cream to the cake
            CreamDecorator creamCake = new CreamDecorator(cBase);
            PrintProductDetails(creamCake);

            // Let now add a Cherry on it
            CherryDecorator cherryCake = new CherryDecorator(creamCake);
            PrintProductDetails(cherryCake);

            // Lets now add Scent to it
            ArtificialScentDecorator scentedCake = new ArtificialScentDecorator(cherryCake);
            PrintProductDetails(scentedCake);

            // Finally add a Name card on the cake
            NameCardDecorator nameCardOnCake = new NameCardDecorator(scentedCake);
            PrintProductDetails(nameCardOnCake);

            // Lets now create a simple Pastry
            PastryBase pastry = new PastryBase();
            PrintProductDetails(pastry);

            // Lets just add cream and cherry only on the pastry 
            CreamDecorator creamPastry = new CreamDecorator(pastry);
            CherryDecorator cherryPastry = new CherryDecorator(creamPastry);
            PrintProductDetails(cherryPastry);
        }

        private static void PrintProductDetails(BakeryComponent product)
        {
            Console.WriteLine(); // some whitespace for readability
            Console.WriteLine("Item: {0}, Price: {1}", product.GetName(), product.GetPrice());
        }
    }


    public abstract class BakeryComponent
    {
        public abstract string GetName();
        public abstract double GetPrice();
    }

    class CakeBase : BakeryComponent
    {
        // In real world these values will typically come from some data store
        private string m_Name = "Cake Base";
        private double m_Price = 200.0;

        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }

    class PastryBase : BakeryComponent
    {
        // In real world these values will typically come from some data store
        private string m_Name = "Pastry Base";
        private double m_Price = 20.0;

        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }

    public abstract class Decorator : BakeryComponent
    {
        BakeryComponent m_BaseComponent = null;

        protected string m_Name = "Undefined Decorator";
        protected double m_Price = 0.0;

        protected Decorator(BakeryComponent baseComponent)
        {
            m_BaseComponent = baseComponent;
        }

        public override string GetName()
        {
            return string.Format("{0}, {1}", m_BaseComponent.GetName(), m_Name);
        }

        public override double GetPrice()
        {
            return m_Price + m_BaseComponent.GetPrice();
        }
    }

    class ArtificialScentDecorator : Decorator
    {
        public ArtificialScentDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Artificial Scent";
            this.m_Price = 3.0;
        }
    }

    class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Cherry";
            this.m_Price = 2.0;
        }
    }

    class CreamDecorator : Decorator
    {
        public CreamDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Cream";
            this.m_Price = 1.0;
        }
    }

    class NameCardDecorator : Decorator
    {
        private int m_DiscountRate = 10;

        public NameCardDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Name Card";
            this.m_Price = 4.0;
        }

        public override string GetName()
        {
            return base.GetName() +
                string.Format("\n(Please Collect your discount card for {0}%)",
                m_DiscountRate);
        }
    }






 
  
}
