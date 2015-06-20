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

            CarFactory BMW = new BWMFactory();
            CarFactory Audi = new AudiFactory();

            Client c1 = new Client(BMW);
            Client c2 = new Client(Audi);

            c1.Run();
            c2.Run();

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

}
