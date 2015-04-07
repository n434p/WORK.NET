using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypesProj
{
    class People
    {
        public string Name { get { return "Jason"; } }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            //// Annonymous methods
            //People p = new People();
            //var obj = new { Human = p, Age = 23 };
            //Console.WriteLine(obj.Age+"  "+obj.Human.Name);

            //var mas = new[] { new {A="1", B=2 }, new { A= "34", B= 45 } };

            //foreach (var item in mas)
            //{
            //    Console.WriteLine(item.A+"  "+item.B);
            //}

            //LibraryDataContext db = new LibraryDataContext();
            //var list = from b in db.Books select new { b.Name, b.YearPress };

            //foreach (var item in list)
            //{
            //    Console.WriteLine("Name = {0}\t\nYearPress = {1}\n",item.Name,item.YearPress);
            //}

            List<Product> list = new List<Product>();
            list.Add( new Product( "bread", 12, 3 ));
            list.Add( new Product("butter", 12, 3 ));
            Console.WriteLine(list.GetAllSum());
            Console.WriteLine(ExtensionClass.GetAllSum(list));
            list.ConvertUSD();
            Console.WriteLine(list.GetAllSum());

            System.GC.

        }
    }

    class Product
    {
        string name;
        int price;
        int quantity;

        public Product(string n, int p, int q)
        {
            name = n;
            price = p;
            quantity = q;
        }

        public string Name
        {
            get { return name; }
            set { value = name; }
        }

        public int Price
        {
            get { return price; }
            set { value = price; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { value = quantity; }
        }
    }

    static class ExtensionClass
    {
        public static int GetAllSum(this List<Product> list)
        {
            var sum = (from l in list select l.Price * l.Quantity).Sum();
            return sum;
        }

        public static void ConvertUSD(this List<Product> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(Convert.ToDouble(item.Price /= 25));
            }
        }
    }
}
