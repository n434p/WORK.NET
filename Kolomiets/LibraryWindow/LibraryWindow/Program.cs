using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryWindow
{
    class Library
    { 
    
    }

    class Book
    {
       public string Name { get; set;}
       public string Author { get; set; }
       public int Year { get; set; }

       Random r = new Random();

       public Book()
       {
           Author = "Petrov"+r.Next(1,15).ToString();
           Name = "C# for dummies v."+r.Next(1,5).ToString();
           Year = r.Next(1970, 2014);
       }

        //public string SetAuthor()
        //{
        //    set { Author += r.Next(1,15);};
        //}

       public override string ToString()
       {
           return string.Format("Book: {0}  Author: {1} Year: {2}",Name, Author , Year);
       }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Book[] Library = new Book[r.Next(1,10)];

            for (int i = 0; i < Library.Length; i++)
            {
                Thread.Sleep(20);
                Library[i] = new Book();
            }

            //do
            //{
            //    indexFilial = r.Next(0, 4);
            //    Console.WriteLine(filials[indexFilial].NameFilial);
            //    Console.WriteLine("1 - Выдача кредита\n2 - Получить баланс банка\n0 - Выход");
            //    choose = Convert.ToInt32(Console.ReadLine());
            //    switch(choose)
            

            foreach (Book item in Library)
	{
		 Console.WriteLine(item);
	}
            
                        
            Console.ReadKey();
        }
    }
}
