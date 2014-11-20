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
        object Current { get; set; }
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
            set { Current = value; } 
        }
        public int Counter { get; set; }

        object[] arr;

        public SomeArray(params object [] arg)
        {
            object [] arr = arg;
            Counter = 0;
            Length = arr.Length;
        }

        public void Next() 
        {
            if (Counter < arr.Length) Counter++;
            else this.Reset();
        }

        public void Reset() 
        {
            Counter = 0;
        }

        public override string ToString()
        {
            return Convert.ToString(this.Current);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
