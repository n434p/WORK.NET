using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StorageProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //FoodOne food = new FoodOne("Bread", 7);
            //AdultOne ad = new AdultOne("Cigarettes");
            //HouseChemical hCh = new HouseChemical("Domestos");
            //List<Product> prodList = new List<Product>() { food, ad, hCh };
            //foreach (var item in prodList)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("--------------");
            //string[] arrFood = Enum.GetNames(typeof(Food));
            //for (int i = 0; i < arrFood.Length; i++)
            //{
            //    //  prodList.Add(new FoodOne(Convert.ToString(Food[r.Next(7)])))
            //    Console.WriteLine(arrFood[i]);
            //}

            Storage store = new Storage();
            for (int i = 0; i < 5; i++)
            {
               Thread.Sleep(20);
               store.ReciveProduct(); 
            }
            store.ReciveProduct(5);
            Console.WriteLine(store);
        }
    }
}
