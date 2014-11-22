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

    class Student : Person, IPrintable, IComparable
    {
        public string GroupName { get; set; }
        public enum Criteries { name, group, surname };
        static public Criteries SortKey { get; set; }

        public Student(string n="John", string sn="Doe", string g = "NET14/2"):base(n,sn)
        {
            GroupName = g;
        }

        public int CompareTo(object obj) 
        {
            Student st = (Student) obj;
            switch (SortKey)
            {
                case Criteries.name:
                    if (this.Name.CompareTo(st.Name) < 0) return -1;
                    if (this.Name.CompareTo(st.Name) > 0) return 1;
                    return 0;
                    
                case Criteries.group:
                    if (this.GroupName.CompareTo(st.GroupName) < 0) return -1;
                    if (this.GroupName.CompareTo(st.GroupName) > 0) return 1;
                    return 0;
                    
                case Criteries.surname:
                    if (this.SurName.CompareTo(st.SurName) < 0) return -1;
                    if (this.SurName.CompareTo(st.SurName) > 0) return 1;
                    return 0;
                    
                default:
                    return 0;
            }
        }

        public class StudentComparer :  IComparer<Student> 
        {
            
            public StudentComparer(Criteries key) 
            {
                SortKey = key;
            }

            int IComparer<Student>.Compare(Student st1, Student st2)
            {
              switch (SortKey)
            {
                case Criteries.name:
                    if (st1.Name.CompareTo(st2.Name) < 0) return -1;
                    if (st1.Name.CompareTo(st2.Name) > 0) return 1;
                    return 0;
                    
                case Criteries.group:
                    if (st1.GroupName.CompareTo(st2.GroupName) < 0) return -1;
                    if (st1.GroupName.CompareTo(st2.GroupName) > 0) return 1;
                    return 0;
                    
                case Criteries.surname:
                    if (st1.SurName.CompareTo(st2.SurName) < 0) return -1;
                    if (st1.SurName.CompareTo(st2.SurName) > 0) return 1;
                    return 0;
                    
                default:
                    return 0;
            }
            }
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
            Student st1 = new Student("Ivan", "Petrov", "Other Group");
            Student st2 = new Student("Ivannna", "Petrova", "1-st Group");
            Student st3 = new Student("Victor", "Sidorov", "Next Group");

            Student [] studList= new Student[3] { st1, st2,st3 };

            //Student.SortKey = Student.Criteries.name; 
            //Array.Sort(studList);

            Array.Sort(studList, new Student.StudentComparer(Student.Criteries.surname));
            Array.Reverse(studList);


            Console.WriteLine();

            foreach (var item in studList)
            {
                item.Print();
            }

            
        }
    }
}
