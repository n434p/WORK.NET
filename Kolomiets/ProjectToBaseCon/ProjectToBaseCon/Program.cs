using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectToBaseCon
{
    public enum Sex { male, female };
    public enum Color { red, green, blue, yellow};
    public enum Health { live, dead };


    class Human 
    {
        string firstName;
        string secondName;
        int age;
        Sex sex;

        public Human(string first = "Ivan", string second = "Ivanov", int age = 18, Sex s = Sex.male)
        {
            firstName = first;
            secondName = second;
            sex = s;
            this.age = age;     
        }

        
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", firstName, secondName, age, sex);
        }

    }

    class Student : Human
    {
        string nameGroup;

        public Student(string nameGroup, string first, string second, int age, Sex s)
            : base(first, second, age, s)
        {
            this.nameGroup = nameGroup;
        }

        public Student(string nameGr)
            : base()
        {
            nameGroup = nameGr;
        }


        public override string ToString()
        {
            return base.ToString() + " | " + nameGroup;
        }
    }

    class Plant 
    {
        protected string kind;
        protected string name;
        Color color;
        protected Health health;

        public Plant(string kind = "Nature", string name = "Patagoniya", Color c = Color.green, Health h = Health.live ) 
        {
            this.kind = kind;
            this.name = name;
            this.color = c;
            this.health = h;
        }

        public virtual void Feed() 
        {
            this.health = Health.live;
        }

        public void Kill() 
        {
            health = Health.dead;
        }

        public override string ToString()
        {
            return string.Format("{0}\t {1}\t {2}\t {3}", kind, name,color,health);
        }

    }

    class Flower: Plant
    {
        int numberOfLeaves;
        string requirements;
      

        public Flower(string req = "House keeping", int num = 5) : base("Hybrid","Ivy",Color.blue) 
        {
            numberOfLeaves = num;
            requirements = req;
            
        }

        public override void Feed()
        {
            numberOfLeaves += 1;
            base.Feed();
        }

        public void GrowLeaf(int leaf = 3) 
        {
            numberOfLeaves += leaf;
        }

        public override string ToString()
        {
 	         return base.ToString()+" | "+numberOfLeaves+" leaves, "+requirements;
        }
        

    }

    class Tree : Plant 
    {
        int height;
        

        public Tree(int height = 10) : base("Estetic","Oak") 
        {
            this.height = height;
        }

        public override void Feed()
        {
            height += 2;
            this.health = Health.live;
        }


        public override string ToString()
        {
            return base.ToString()+" | "+height+" m.";
        }

    }

    class Program
    {


        static void Main(string[] args)
        {
            //Console.WriteLine(MyColors.blue + (int)MyColors.green);

            //MyStruct ms = new MyStruct();//{a= 4, s = "123123"};
            //ms.Method();

            Human man = new Human();
            //man.Feed(); // inherited from Plant)
            //man.Kill();

            //Student st1 = new Student("net14/2", "Petr", "Petrov", 18, Sex.male);
            //Student st2 = new Student("net14/2");

            Plant plant = new Plant("Wild", "Tea", Color.green);
            Flower flower = new Flower();
            Tree tree = new Tree(15);

            //Plant plant = new Plant();
            //Flower flower = new Flower();
            //Tree tree = new Tree();

            flower.GrowLeaf();
            flower.Feed();
            tree.Feed();

            plant.Kill();

            

            Console.WriteLine(plant);
            Console.WriteLine(flower);
            Console.WriteLine(tree);

            Console.WriteLine(man);

            Console.ReadKey();

        }
    }
}
