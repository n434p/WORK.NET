using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumProject
{
    public interface IEnum 
    {
        int Length { get; set; }
        object Current { get; }
        int Counter { get; set; }
        void Next();
        void Reset();
    }

    class SomeArray: IEnum 
    {
        public int Length { get; set; }
        public object Current 
        {
            get { return arr[Counter]; }
            
        }
        public int Counter { get; set; }

        object[] arr;

        public SomeArray(params object [] arg)
        {
            arr = arg;
            Counter = 0;
            Length = arr.Length;
        }
        public void Next()
        {
            if (Counter < Length - 1) Counter++;
            else this.Reset();
        }

        public void Reset() 
        {
            Counter = 0;
        }

        public override string ToString()
        {
            return this.Counter + " " + this.Current + " " ;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            SomeArray sa = new SomeArray("11", "22", "33", "44");
            
            for (int i = 0; i < sa.Length+5; i++)
            {
                Console.WriteLine(sa);
                sa.Next();
            }

       
           
        }
    }
}
