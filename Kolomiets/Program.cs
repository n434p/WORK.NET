using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugProject
{
    class People
    {
        string firstName = "zxcfsf";
        string lastName = "dsfdsf";
        int age = 12;
        public int Age
        {
            get 
            {
                return this.age;
            }
            set 
            {
                if (value >= 18 && value <= 60)
                    this.age = value;
                else
                    Console.WriteLine("Возраст не валидный!");
            }
        }
        public int Qwerty
        {
            get {
                return (2 * 3) / 4;
            }
        }
        /*public People()
        {
            firstName = "Иван";
            lastName = "Иванов";
            age = 18;
        }*/
        public People(string firstName = "Иван", string lastName = "Иванов", int age = 18)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        //public void Show()
        //{
        //    Console.WriteLine("FirstName:\t{0}\nLastName:\t{1}\nAge:\t\t{2}", this.firstName, this.lastName, this.age);
        //}
        public override string ToString()
        {
            return string.Format("FirstName:\t{0}\nLastName:\t{1}\nAge:\t\t{2}", this.firstName, this.lastName, this.age);
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public Animal(string str)
        {
            this.Name = str;
        }
        public string EditName
        {
            set 
            {
                if (value == "qwerty")
                    this.Name = value;
                else
                    Console.WriteLine("Sorry, error!!!!");
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }

    class Plants
    {
        public string Type { get; set; }
        public string Name { get; set; }
        static Plants()
        {
            Console.WriteLine("Static");
        }
        public override string ToString()
        {
            return string.Format("Type:{0}\nName:{1}",this.Type,this.Name);
        }
    }

    class Bank
    {
        static int balance = 10000;
        public string NameFilial { get; private set; }
        public int CountClientFilial { get; set; }

        public Bank(string nameFilial)
        {
            this.NameFilial = nameFilial;
            this.CountClientFilial = 0;
        }
        public int Give(int summa)
        {
            this.CountClientFilial++;
            if (summa <= Bank.balance)
            {
                Bank.balance -= summa;
            }
            else
                Console.WriteLine("Недостаточно средств у банка!!!!");
            return summa;
        }
        public int BalanceBank
        {
            get 
            {
                return Bank.balance;
            }
        }
        public static int CountClients(Bank[] filials)
        {
            int count = 0;
            foreach (Bank b in filials)
            {
                count += b.CountClientFilial;
            }
            return count;
        }
        public static Bank[] SummaClients
        {
            set
            {
                int sum = 0;
                foreach (var b in value)
                {
                    sum += b.CountClientFilial;
                }
                Console.WriteLine(sum);
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            //Plants p = new Plants() { Type = "Flower", Name = "Rose" };
            //Console.WriteLine(p);
            //Animal a = new Animal() { Name = "qwerty" };
            //Console.WriteLine(a);
            //a.Name = "asdf";
            //Console.WriteLine(a);
            //Console.WriteLine(a.Name);

            //Animal a = new Animal("asd");
            //Console.WriteLine(a);
            //Console.WriteLine(a.Name);
            //a.EditName = "qwerty";
            //Console.WriteLine(a);

            //People p1 = new People();
            //People p2 = new People("Петр", "Петров", 23);
            ////p1.Show();
            ////p2.Show();
            //Console.WriteLine(p1.ToString());
            //p2.Age = 12; 
            //Console.WriteLine(p2.Age);
            //Console.WriteLine(p2.Qwerty);
            int choose = 0, indexFilial=0;
            Random r = new Random();
            Bank[] filials = new Bank[4];
            for (int i = 0; i < filials.Length; i++)
            {
                filials[i] = new Bank("Филиал №" + (i + 1));
            }

            do
            {
                indexFilial = r.Next(0, 4);
                Console.WriteLine(filials[indexFilial].NameFilial);
                Console.WriteLine("1 - Выдача кредита\n2 - Получить баланс банка\n0 - Выход");
                choose = Convert.ToInt32(Console.ReadLine());
                switch(choose)
                {
                    case 1:
                       
                        Console.WriteLine("Сумма кредита:{0}\n",filials[indexFilial].Give(r.Next(100, 10000)));
                        break;
                    case 2:
                        Console.WriteLine("Баланс банка:{0}",filials[indexFilial].BalanceBank);
                        break;
                    case 0:
                        Console.WriteLine("Прощайте!");
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            } while (choose != 0);

            foreach (Bank b in filials)
            {
                Console.WriteLine(b.NameFilial + " : " + b.CountClientFilial);
            }
            Console.WriteLine("Clients bank:{0}\n\n\n", Bank.CountClients(filials));
            Bank.SummaClients = filials;



        }
    }
}
