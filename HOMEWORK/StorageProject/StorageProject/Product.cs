using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageProject
{

    abstract class Product
    {
        public string Name { get; set; }
        public Group ProductGroup;
        public bool TimeLimit { get; set; }
        public bool Fragile { get; set; }
        public bool Excise { get; set; }
        public Product(string name = "Some product", Group g = Group.Food, bool timelim=false,bool fragile=false,bool excise=false)
        {
            Name = name;
            ProductGroup = g;
            TimeLimit = timelim;
            Fragile = fragile;
            Excise = excise;
        }

        public override string ToString()
        {
            return string.Format("ITEM: {0} \tGROUP: {1} \t\nTimeLimit: {2}\t Fragile: {3}\t Excise: {4}\n",Name,ProductGroup,TimeLimit,Fragile,Excise);
        }
    }

    class FoodOne: Product
    {
        public DateTime Date { get; protected set; }
        public int EvalDays { get; protected set; }
        
        public FoodOne(string n = "Some food", int  eval = 90): base(n, Group.Food,true)
        {
            Date = DateTime.Now;
            Date = Date.AddDays(new Random().Next(-(Date.DayOfYear-1),0) ) ;
            EvalDays = eval;
        }

        public override string ToString()
        {
            return base.ToString()+"\n"+"\t DATE: "+Date.ToShortDateString()+"\tEVAL: "+EvalDays+" days";
        }
    }
    class AdultOne: Product
    {
        public AdultOne(string n = "Some excise product") : base (n, Group.AdultStuff,false,true,true)
        {    
        }
    }
    class HouseChemical: Product
    {
        public HouseChemical(string n = "House chemical product"): base(n, Group.HouseChemical) 
        {       
            
        } 
    }
}
