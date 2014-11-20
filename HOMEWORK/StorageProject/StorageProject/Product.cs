using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageProject
{
    enum Group { Food, AdultStuff, HouseChemical};
    enum Status { Ok, NotAvailable, Expired, Broken};
    abstract class Product
    {
        public string Name { get; set; }
        public Group ProductGroup;
        public Status ProductStatus;       
        public Product(string name = "Some product", Group group= Group.Food, Status status = Status.OK)
        {
            Name = name;
            ProductGroup = group;
            ProductStatus = status;
        }

        public override string ToString()
        {
            return string.Format("ITEM: {0} \tGROUP: {1} \tSTATUS: {2}\t\n",Name,ProductGroup,ProductStatus);
        }
    }

    class FoodOne: Product, IExpire 
    {
        public DateTime Date { get; set; }
        public int EvalDays { get; set; }
        
        public FoodOne(string n = "Some food", int eval = 90)
            : base(n, Group.Food)
        {
            Name = n;
            Date = DateTime.Now;
            Date.AddDays(new Random().Next(-120, -30));
            EvalDays = eval;
        }

        public Status Check(Product p) 
        {
            try
            {
                if (DateTime.Now.DayOfYear > Date.DayOfYear + EvalDays)
                {
                    p.ProductStatus = Status.Expired;
                    throw new ProductException(string.Format("\n {0} is expired!", p.Name));
                }
            }
            catch (ProductException pEx) 
            {
                Console.WriteLine(pEx.Message);
            }
            return p.ProductStatus;
        }

        public override string ToString()
        {
            return base.ToString()+"\n"+"\t DATE: "+Date.ToShortDateString()+"\tEVAL: "+EvalDays+" days";
        }
    }
    class AdultOne: Product
    {

    }
    class HouseChemicalOne: Product
    {

    }
}
