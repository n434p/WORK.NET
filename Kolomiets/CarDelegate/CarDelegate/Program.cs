using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Program
    {
        public class Car
        {
        public delegate void CarEngineHandler(string msgForCaller);
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

        public void Accelerate(int delta)
        {
        // Если этот автомобиль сломан,  отправить сообщение об этом, 
        if  (carlsDead)
        {
        if  (listOfHandlers != null)
        listOfHandlers ("Sorry,  this car is dead...");
        }
        else        {
        CurrentSpeed += delta;
        // Автомобиль почти сломан?
        if  (10 >=  (MaxSpeed - CurrentSpeed)
        && listOfHandlers  != null)
        {
        listOfHandlers("Careful buddy! Gonna blow!");
        }
        if  (CurrentSpeed >= MaxSpeed) 
        carlsDead = true; 
        else
        Console.WriteLine("CurrentSpeed = {0}",  CurrentSpeed);
        }
        }
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
         //   Console.WriteLine("*************************************");
        }

        public static void TestEngineEvent(string msg)
        {
            
            Console.WriteLine("\n"); 
            Console.WriteLine("To upper!!!");
            Console.WriteLine("*************************************");
        }

        static void Main(string[] args)
        {
        Console.WriteLine("***** Delegates as event enablers *****\n");
        // Сначала создать объект Car.
        Car cl = new Car ("SlugBug",  100,  10);
        // Теперь сообщить ему, какой метод вызывать,
        // когда он захочет отправить сообщение.
        cl.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
        cl.RegisterWithCarEngine(new Car.CarEngineHandler(TestEngineEvent));
        cl.UnRegisterWithCarEngine(new Car.CarEngineHandler(TestEngineEvent));
        // Ускорить (это инициирует события) .
        Console.WriteLine ("***** Speeding up *****"); 
        for  (int i = 0;  i < 9;  i++) 
        cl.Accelerate(12);
        Console.ReadLine();
        
        
        }
    }
}
