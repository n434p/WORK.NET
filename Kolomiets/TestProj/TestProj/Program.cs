using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj
{
    public interface IPrintable 
    {
        void Print();
    }

    class Person: IPrintable
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public Person(string n="John", string sn = "Doe")
        {
            Name = n;
            SurName = sn;
        }

        void IPrintable.Print()
        {
            Console.WriteLine("Person: {0} - {1} - IPrintable", Name, SurName);
        }

        public void Print()
        {
            Console.WriteLine("Person: {0} - {1} ", Name, SurName);
        }


    }

    class Student : Person, IPrintable 
    {
        public string GroupName { get; set; }

        public Student(string n="John", string sn="Doe", string g = "NET14/2"):base(n,sn)
        {
            GroupName = g;
        }

        void IPrintable.Print()
        {
            Console.WriteLine("Student: {0} - {1} - {2} - IPrintable", Name, SurName, GroupName);
        }

        public new void Print() 
        {
            Console.WriteLine("Student: {0} - {1} - {2}", Name, SurName, GroupName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Ivan", "Petrov");
            Student st = new Student("Ivan", "Petrov", "Other Group");

            p.Print();
            st.Print();

            Console.WriteLine("Explicit: \n");

            ((IPrintable) p).Print();
            
            ((IPrintable) st).Print();

            Console.WriteLine();

            IPrintable obj1 = new Person();
            obj1.Print();

            IPrintable obj2 = new Student();
            obj2.Print();

            List<IPrintable> studList = new List<IPrintable>() { p, st, obj1, obj2 };
            
            Console.WriteLine();

            foreach (var item in studList)
            {
                item.Print();
            }

            
        }
    }
}
