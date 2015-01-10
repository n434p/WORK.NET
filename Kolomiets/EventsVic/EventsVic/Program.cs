using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsVic
{
    class Group 
    {
        public event EventHandler NewStudent;

        List<Student> group;

        public Group()
        {
            List<Student> groupList = new List<Student>();
        }

        public void AddStud(Student obj) 
        {
            group.Add(obj);  
            this.NewStudent += obj.SayHello;
        }
    }

    class Student
    {
        public string name;

        public Student(string n) 
        {
            name = n;
        }


        public void SayHello(object obj, EventArgs e) 
        {

            Console.WriteLine("Hello "+this.name);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Group gr = new Group();
            Student st1 = new Student("Max1");
            Student st2 = new Student("Max2");
            Student st3 = new Student("Max3");
            gr.AddStud(st1);
            gr.AddStud(st2);
            gr.AddStud(st3);
        }
    }
}
