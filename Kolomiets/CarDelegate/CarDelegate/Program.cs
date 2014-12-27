using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }

    class Program
    {
        

        public class Car
        {
        //public delegate void CarEngineHandler(string msgForCaller);
        public delegate void CarEngineHandler(object obj, CarEventArgs e);

        //public event CarEngineHandler Exploded;
        //public event CarEngineHandler ToBlow;

        public event EventHandler<CarEventArgs> ToBlow;
        public event EventHandler<CarEventArgs> Exploded;

        # region Car Body;

        private CarEngineHandler listOfHandlers;        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
        listOfHandlers += methodToCall;
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
        // Данные состояния.
        public int CurrentSpeed { get; set;  } 
        public int MaxSpeed { get; set;  } 
        public string PetName { get; set;  }
        // Исправен ли автомобиль? 
        private bool carlsDead;         // Конструкторы класса.
        public Car()  { MaxSpeed = 100;  }
        public Car(string name,  int maxSp,  int currSp)
        {
        CurrentSpeed = currSp;
        MaxSpeed = maxSp;
        PetName = name;
        
        }

        public override string ToString()
        {
            return "Car: "+PetName;
        }
        # endregion

        public void Accelerate(int delta)
        {
        // Если этот автомобиль сломан,  отправить сообщение об этом, 
        if  (carlsDead)
        {
        if  (Exploded != null)
            Exploded(this, new CarEventArgs("Car is dead!!!"));
        }
        else        {
        CurrentSpeed += delta;
        // Автомобиль почти сломан?
        if  (10 >=  (MaxSpeed - CurrentSpeed)
        && ToBlow != null)
        {
        ToBlow(this,new CarEventArgs("Gonna to blow!!!"));
        }
        if  (CurrentSpeed >= MaxSpeed) 
        carlsDead = true; 
        else
        Console.WriteLine("CurrentSpeed = {0}",  CurrentSpeed);
        }
        }
        }

        public static void OnCarEngineEvent(object obj, CarEventArgs e)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", e.msg);
            Console.WriteLine("*************************************");
        }

        //public static void TestEngineEvent(string msg)
        //{
            
        //    Console.WriteLine("\n"); 
        //    Console.WriteLine("To upper!!!");
        //    Console.WriteLine("*************************************");
        //}

        static void Main(string[] args)
        {
        Console.WriteLine("***** Delegates as event enablers *****\n");
        Car cl = new Car ("SlugBug",  100,  10);

        //cl.Exploded += new Car.CarEngineHandler(OnCarEngineEvent);
        //cl.ToBlow += new Car.CarEngineHandler(OnCarEngineEvent);

        // cl.Exploded -= OnCarEngineEvent;

        cl.ToBlow += delegate (object ob, CarEventArgs e) { Console.WriteLine("Annonymous dlegate working {0} - {1}",Convert.ToString((Car) ob), e.msg); };
        cl.Exploded += OnCarEngineEvent;

        //EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(OnCarEngineEvent);
        //cl.Exploded += d;

        cl.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

        //cl.RegisterWithCarEngine(new Car.CarEngineHandler(TestEngineEvent));
        //cl.UnRegisterWithCarEngine(new Car.CarEngineHandler(TestEngineEvent));

        Console.WriteLine ("***** Speeding up *****"); 
        for  (int i = 0;  i < 6;  i++) 
        cl.Accelerate(20);
        Console.ReadLine();
        
        
        }
    }
}
