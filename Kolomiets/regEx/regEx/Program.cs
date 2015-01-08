using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace regEx
{
    class Button 
    {
        public string name;
        public event EventHandler Clicked;
        public Button(string n) 
        {
            name = n;
            this.Clicked += ButtonClicked;
        }

        public void Push() 
        {
        Clicked(this, EventArgs.Empty);
        }

        public void ButtonClicked(object ob, EventArgs e) 
        {
            Console.WriteLine(this.name +" - button is clcked!!!");
        }
    }
    class Student 
    {
        public string name;
        public Student(string n)
        { name = n; }
        public void AddStudent(object ob, EventArgs e) 
        {
            Student st = (Student) ob;
            Console.WriteLine("Hello "+st.name);
        }
    }
    class Group
    {
    public List<Student> group;
    public event EventHandler NewStudent;
    public Group() { group = new List<Student>(); }

    public void AddStud(Student ob) 
    {
        group.Add(ob);
        if (NewStudent != null) NewStudent(ob, EventArgs.Empty);
        this.NewStudent += ob.AddStudent;
    }
    
    }

    class FloatNumber 
    {
        public string incom;

        public FloatNumber(string num) { incom = num; }

        public void GetNum() 
        {
            string key = @"(\d*\.?\d{2}?){1}";
            Regex ex = new Regex(key,RegexOptions.IgnoreCase);

            MatchCollection mc = ex.Matches(incom);

            foreach (var item in mc)
            {
                Console.WriteLine(item);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Button b1 = new Button("1");
            //Button b2 = new Button("2");
            //Button b3 = new Button("3");
            //b1.Push();

            //Group gr = new Group();
            //Student st1 = new Student("Vasia");
            //Student st2 = new Student("Vas");
            //Student st3 = new Student("Van");

            //gr.AddStud(st1);
            //Console.WriteLine();
            //gr.AddStud(st2);
            //Console.WriteLine();
            //gr.AddStud(st3);

            FloatNumber fn = new FloatNumber("11.22.45 0.33");
            fn.GetNum();
        }
    }
}
