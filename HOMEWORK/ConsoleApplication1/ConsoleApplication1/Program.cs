using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Worker 
    {
        static List<Worker> list = new List<Worker>();

        int code;
        string Name;

        public double salaryPh{get; private set;};

        public Worker(double d, string N)
        {
            code = Worker.list.Count + 1;
            Name =N;
            salaryPh = d;
        }

        public abstract double GetSalary(double ind);

        public override string ToString()
        {
            return string.Format("Code - {0}\t Name - {1}\t Salary - {2}",code,Name,salaryPh);
        }
    }

    public class Worker1: Worker 
    {
        public Worker1(double d, string n) : base(d,n) { }

        public override double GetSalary(double ind)
        {
            return salaryPh*20.8*8;
        }

    }

    public class Worker2 : Worker, I
    {
        public Worker2(double d, string n) : base(d, n) { }

        public override double GetSalary(double ind)
        {
            return salaryPh;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
           



        }
    }
}
