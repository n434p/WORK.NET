using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageProject
{
    enum Group { Food, AdultStuff, HouseChemical };
    enum Status { Ok, NotAvailable, Expired, Broken };
    enum Food { Bread, Meat, Fish, Butter, Milk, Cake, Cheese, Eggs}
    enum Adult { Whiskey, Vodka, Cognac, Beer, Vine, Cigarettes, Cigar, Tobacco, Weed}
    enum Chemical { Cleaner, AllSurfaceCleaner, DishwashingCleaner, Bleach, Detergent, AirFreshener, Soap, Conditioner}

    class Storage
    {
        List<Product> prodList; 

        public void ReciveProduct(int GroupIndex=-1) 
        {
            Random r = new Random();
            string[] arrFood = Enum.GetNames(typeof(Food));
            string[] arrAdult = Enum.GetNames(typeof(Adult));
            string[] arrChem = Enum.GetNames(typeof(Chemical));
            try
            {
                switch ((GroupIndex == -1) ? r.Next(0, 2) : GroupIndex)
                {
                    case 0: prodList.Add(new FoodOne(arrFood[r.Next(arrFood.Length - 1)], r.Next(30)));
                        break;
                    case 1: prodList.Add(new AdultOne(arrAdult[r.Next(arrAdult.Length - 1)]));
                        break;
                    case 2: prodList.Add(new HouseChemical(arrChem[r.Next(arrChem.Length - 1)]));
                        break;
                    default: throw new ProductException("Wrong group index!");
                }
            }
            catch (ProductException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Storage()
        {
            prodList = new List<Product>();
        }

        public override string ToString()
        {
            Console.WriteLine("STORAGE: \n\n");
            foreach (var item in prodList)
            {
                Console.WriteLine("{0} \n",item);
            }
            return "*****************\n";
        }

        //public Status Check(Product p)
        //{
        //    try
        //    {
        //        if (DateTime.Now.DayOfYear > Date.DayOfYear + EvalDays)
        //        {
        //            p.ProductStatus = Status.Expired;
        //            throw new ProductException(string.Format("\n {0} is expired!", p.Name));
        //        }
        //    }
        //    catch (ProductException pEx)
        //    {
        //        Console.WriteLine(pEx.Message);
        //    }
        //    return p.ProductStatus;
        //}
    }
}
