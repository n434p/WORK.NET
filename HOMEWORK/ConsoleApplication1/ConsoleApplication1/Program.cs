using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Worker : IComparable<Worker>
    {
        public static List<Worker> list = new List<Worker>();
        public int code;
        public string Name;

        public double salaryPh{get; private set;}

        public Worker(double d, string N)
        {
            code = Worker.list.Count + 1;
            Name =N;
            salaryPh = d;
            list.Add(this);
        }

        public abstract double GetSalary();

        public static List<Worker> GetSalaryList()
        {
            List<Worker> newList = list;
            newList.Sort();
            return list;
        }


        public static List<string> GetFirstFiveNames()
        {
            List<Worker> newList = list;
            newList.Sort();
            return newList.Select(w => w.Name).Take(5).ToList();
        }

        public static List<int> GetLastThreeId()
        {
            List<Worker> newList = list;
            newList.Sort();
            return newList.Select(w => w.code).Skip(list.Count-3).ToList();
        }


        public override string ToString()
        {
            return string.Format("Code - {0}\t Name - {1}\t",code,Name);
        }

        public int CompareTo(Worker other)
        {
            if (this.GetSalary() == other.GetSalary()) return this.Name.CompareTo(other.Name);
            else return other.GetSalary().CompareTo(this.GetSalary());
        }
    }

    public class Worker1: Worker 
    {
        public Worker1(double d, string n) : base(d,n) { }

        public override double GetSalary()
        {
            return salaryPh*20.8*8;
        }

    }

    public class Worker2 : Worker
    {
        public Worker2(double d, string n) : base(d, n) { }

        public override double GetSalary()
        {
            return salaryPh;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            Worker w1 = new Worker1(200, "John");
            Worker w2 = new Worker2(1500, "James");
            Worker w3 = new Worker1(200, "Johnie");
            Worker w4 = new Worker2(1500, "James");
            Worker w5 = new Worker1(200, "Jessie");
            Worker w6 = new Worker2(1500, "Jane");
            Worker w7 = new Worker1(200, "Jessica");
            Worker w8 = new Worker2(1500, "Jon");

            //IEnumerable<Worker> FirstFiveNames = Worker.list.OrderByDescending(t => t.GetSalary()).ThenBy(n => n.Name).Take(5);

            //foreach (var item in FirstFiveNames)
            //{
            //        Console.WriteLine(item+"\t"+item.GetSalary());
            //}

            //Console.WriteLine();

            //IEnumerable<Worker> LastThreeId = Worker.list.OrderByDescending(t => t.GetSalary()).ThenBy(n => n.Name).Skip(Worker.list.Count - 3);

            //foreach (var item in LastThreeId)
            //{
            //    Console.WriteLine(item + "\t"+item.GetSalary());
            //}


            Console.WriteLine("Task1: \n");
            foreach (var item in Worker.GetSalaryList())
            {
                Console.WriteLine(item + "\t" + item.GetSalary());
            }

            Console.WriteLine("Task2: \n");
            foreach (var item in Worker.GetFirstFiveNames())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Task3: \n");
            foreach (var item in Worker.GetLastThreeId())
            {
                Console.WriteLine(item);
            }


        }

    }

}
