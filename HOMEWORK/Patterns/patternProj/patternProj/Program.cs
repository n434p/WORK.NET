using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternProj
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Singletone
            //Earth e = Earth.Instance();
            //Earth e1 = Earth.Instance();

            //if (Equals(e,e1)) Console.WriteLine("true");
            //else Console.WriteLine("false");

            #endregion

            #region Builder
            //BigHappyMealBuilder big = new BigHappyMealBuilder();
            //HappyMealBuilder hm = new HappyMealBuilder();

            //Director d1 = new Director();
            //d1.Constructor(big);
            //d1.Constructor(hm);

            //HappyMeal meal = big.Return();
            //Console.WriteLine("Big: \n");
            //Console.WriteLine(meal);
            //meal = hm.Return();
            //Console.WriteLine("Usual: \n");
            //Console.WriteLine(meal);

            #endregion

            #region Abstract Factory

            //CarFactory BMW = new BWMFactory();
            //CarFactory Audi = new AudiFactory();

            //Client c1 = new Client(BMW);
            //Client c2 = new Client(Audi);

            //c1.Run();
            //c2.Run();

            #endregion

            #region Factory Method

            //Creator[] creators = { new ManagerCreator(), new DeveloperCreator()};

            //foreach (var item in creators)
            //{
            //    Emloyee empl = item.FactoryMethod();
            //    empl.Salary();
            //    empl.Status();
            //}

            #endregion

            #region Prototype

            //ConcreteAudi audi = new ConcreteAudi();
            //ConcreteAudi audiCopy = audi.Clone() as ConcreteAudi;

            //Console.WriteLine(audi+"\n"+audiCopy);

            //ConcreteBMW bmw = new ConcreteBMW();
            //ConcreteBMW bmwCopy = bmw.Clone() as ConcreteBMW;

            //Console.WriteLine(bmw + "\n" + bmwCopy);

            //if (Object.ReferenceEquals(audi.Date, audiCopy.Date)) Console.WriteLine("true");

            #endregion

            #region Cycle

            #region AbstractFactory_Cycle

            //BabyCycleFactory babyCycle = new BabyCycleFactory();
            //UkraineCycleFactory ukraineCycle = new UkraineCycleFactory();

            //CycleClient c1 = new CycleClient(babyCycle);
            //CycleClient c2 = new CycleClient(ukraineCycle);

            //c1.Info();
            //c2.Info();

            #endregion

            #region Singletone_Cycle

            BycycleSingletone cycle = BycycleSingletone.Instance;
            BycycleSingletone cycle2 = BycycleSingletone.Instance;

            if (object.ReferenceEquals(cycle, cycle2)) Console.WriteLine("true");
            else Console.WriteLine("false");


            #endregion

            #region Builder



            #endregion


            #endregion

        }
    }

    #region Singletone
    /// <summary>
    /// Class implements Singletone pattern
    /// </summary>
    class Earth 
    {
        static Earth instance;
        
        public static Earth Instance() 
        {
            if (instance == null) instance = new Earth();
            return instance;
        }

        private Earth() { }
    }

    #endregion

    #region Builder

    /// <summary>
    /// part needed to implement build pattern;
    /// </summary>
    class HappyMeal
    {
        ArrayList set = new ArrayList();

        public void AddItem(string i) 
        {
            set.Add(i);
        }


        public override string ToString()
        {
            string res = "";
            foreach (string item in set)
            {
                res += item + "\n";
            }

            return res;
        }
    }
    /// <summary>
    /// Builder pattern class
    /// </summary>
    abstract class Builder 
    {
        public abstract void AddChips();
        public abstract void AddDrink();
        public abstract void AddBurger();
        public abstract void AddToy();

        public abstract HappyMeal Return();
    }

    /// <summary>
    /// Builder pattern part
    /// </summary>
    class BigHappyMealBuilder : Builder 
    {
        HappyMeal res = new HappyMeal();

        public override void AddChips()
        {
            res.AddItem("Big chips");
        }

        public override void AddDrink()
        {
            res.AddItem("Big Cola");
        }

        public override void AddBurger()
        {
            res.AddItem("Big tasty");
        }

        public override void AddToy()
        {
            res.AddItem("Toy");
        }

        public override HappyMeal Return()
        {
            return res;
        }
    }

    /// <summary>
    /// Builder pattern part
    /// </summary>
    class HappyMealBuilder : Builder
    {
        HappyMeal res = new HappyMeal();

        public override void AddChips()
        {
            res.AddItem("Chips");
        }

        public override void AddDrink()
        {
            res.AddItem("Cola");
        }

        public override void AddBurger()
        {
            res.AddItem("Burger");
        }

        public override void AddToy()
        {
            res.AddItem("Toy");
        }

        public override HappyMeal Return()
        {
            return res;
        }
    }

    /// <summary>
    /// Builder pattern part
    /// </summary>
    class Director 
    {
        public void Constructor(Builder obj) 
        {
            obj.AddChips();
            obj.AddBurger();
            obj.AddDrink();
            obj.AddToy();            
        }
    }
    #endregion

    #region Abstract Factory

    public abstract class CarFactory 
    {
        public abstract AbstractCar CreateCar();
        public abstract AbstractEngine CreateEngine();
    }

    public abstract class AbstractCar
    {
        public abstract void MaxSpeed(AbstractEngine engine);
    }

    public abstract class AbstractEngine
    {
        public int maxSpeed;
    }

    class BMWCar: AbstractCar
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("Max speed ={0}",engine.maxSpeed.ToString());   
        }
    }

    class BMWEngine : AbstractEngine 
    {
        public BMWEngine()
        {
            maxSpeed = 200;
        }
    }

    class AudiCar : AbstractCar 
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("Max speed ={0}", engine.maxSpeed.ToString());   
        }
    }

    class AudiEngine : AbstractEngine
    {
        public AudiEngine()
        {
            maxSpeed = 250;
        }
    }

    class BWMFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new BMWCar();
        }

        public override AbstractEngine CreateEngine()
        {
            return new BMWEngine();
        }
    }

    class AudiFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new AudiCar();
        }

        public override AbstractEngine CreateEngine()
        {
            return new AudiEngine();
        }
    }

    class Client 
    {
        private AbstractCar abstractCar;
        private AbstractEngine abstractEngine;

        public Client(CarFactory carFactory)
        {
            abstractCar = carFactory.CreateCar();
            abstractEngine = carFactory.CreateEngine();
        }

        public void Run() 
        {
            abstractCar.MaxSpeed(abstractEngine);
        }
    }

    #endregion

    #region Factory Method

    /// <summary>
    /// Implements (fake)Interface (Product) like shown on schema
    /// </summary>
    abstract class Emloyee 
    {
        public abstract void Status();
        public abstract void Salary();
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    class Manager : Emloyee 
    {
        public override void Status()
        {
            Console.WriteLine("Manager status");
        }

        public override void Salary()
        {
            Console.WriteLine("Manager salary");
        }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    class Developer : Emloyee
    {
        public override void Status()
        {
            Console.WriteLine("Developer status");
        }

        public override void Salary()
        {
            Console.WriteLine("Developer salary");
        }
    }

    abstract class Creator 
    {
        public abstract Emloyee FactoryMethod();

    }

    class ManagerCreator: Creator
    {
        public override Emloyee FactoryMethod()
        {
            return new Manager();
        }
    }

    class DeveloperCreator : Creator
    {
        public override Emloyee FactoryMethod()
        {
            return new Developer();
        }
    }

    #endregion

    #region Prototype


    /// <summary>
    /// implements interface Prototype (on pattern scheme)
    /// </summary>
    abstract class Car 
    {
         string model;
         string year;
         int topSpeed;
         string color;

         object date;

        

         public Car(string c,string m, string y, int s)
         {
             model = m;
             year = y;
             topSpeed = s;
             color = c;
             date = new object();
             date = "test";
         }

        public string Model { get { return model; } }
        public string Year { get { return year; } }
        public string Color { get { return color; } }
        public int TopSpeed { get { return topSpeed; } }
        public object Date { get { return date; } }


         public override string ToString()
         {
             return string.Format("Model= {0}\t Year= {1}\t Top speed= {2}\t Color= {3}\t Date={4}",model,year,topSpeed,color,date);
         }

         public abstract Car Clone();


    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    class ConcreteAudi : Car
    {
        public ConcreteAudi(string c = "red", string m = "Audi", string y = "1999", int s = 220) : base(c, m, y, s) { }

        public override Car Clone()
        {
            return this.MemberwiseClone() as Car;
        }
    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    class ConcreteBMW : Car
    {
        public ConcreteBMW(string c = "green", string m = "BMW", string y = "2000", int s = 220) : base(c, m, y, s) { }

        public override Car Clone()
        {
            return this.MemberwiseClone() as Car;
        }
    }



    #endregion

}
