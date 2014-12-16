using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Person 
    {
       public string Name { get; set; }
       public  string Surname { get; set; }
       public int Age { get; set; }
       
        public Person ()
        {
            Name = "Vasia";
            Surname = "Sidorov";
            Age = 20;
        }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}", Name, Surname, Age);
        }
     
    }

    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            if (first.Age > second.Age)
            {
                return 1;
            }
            if (first.Age < second.Age)
            {
                return -1;
            }
            else return 0;
        }
    }

    //public class PeopleColection : IEnumerable
    //{
    //    public ArrayList arPeople = new ArrayList();

              
    //    public Person GetPerson(int pos)
    //    {
    //        return (Person)arPeople[pos];
    //    }

    //    public void SetPerson(Person p)
    //    {
    //        arPeople.Add(p);
    //    }

    //    public void ClearPeople()
    //    {
    //        arPeople.Clear();

    //    }

    //    public int Count()
    //    {
    //        return arPeople.Count;
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return arPeople.GetEnumerator();
    //    }



    //}

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> listarr = new List<Person>();

            listarr.Add(new Person());
            listarr.Add(new Person("Petr", "Ivanov", 30));

            Stack<Person> stPerson = new Stack<Person>();

            stPerson.Push(new Person("Oleg", "Sidorov", 40));
            stPerson.Push(new Person("Andrey", "Petrov", 20));
            stPerson.Push(new Person());

            //Queue<Person> quPerson = new Queue<Person>();
            //quPerson.Enqueue(new Person("First", "Temp", 20));
            //quPerson.Enqueue(new Person("Andrey", "Petrov", 30));
            //quPerson.Enqueue(new Person());
            
            //Console.WriteLine(quPerson.Dequeue().ToString());
            //Console.WriteLine(quPerson.Dequeue().ToString());
            //Console.WriteLine(quPerson.Dequeue().ToString());
            //Console.WriteLine("Name: {0}", stPerson.Peek());
            //Person temp = stPerson.Pop();
            //Console.WriteLine("Name: {0}", stPerson.Peek());
           // stPerson.Pop();
          //  Console.WriteLine("Name: {0}", stPerson.Peek());
            foreach (Person pr in stPerson)
            {
                pr.Name = "Ivan";
                Console.WriteLine(pr.ToString());
            }

            foreach (Person pr in stPerson)
            {
                Console.WriteLine(pr.ToString());
            }

            //Console.WriteLine(stPerson.Count);

            Console.WriteLine();

            SortedSet<Person> sort = new SortedSet<Person>()
            {

            };



            sort.Add(new Person("Ole", "Ppp", 16));

            #region Test
            //PeopleColection arrPeople = new PeopleColection();

            //arrPeople.SetPerson(new Person());

            //arrPeople.SetPerson(new Person());
            //arrPeople.SetPerson(new Person());
            //arrPeople.SetPerson(new Person());
            //arrPeople.SetPerson(new Person());
            //arrPeople.SetPerson(new Person());
            //arrPeople.SetPerson(new Person());
            #endregion

            foreach (Person pr in sort)
            {
                Console.WriteLine(pr.ToString());
            }

            Console.ReadLine();

        }
    }
}
