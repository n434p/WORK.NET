﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryWindow
{
    class Library
    {
        public static int[] countChartBooks { get; private set;}
        string[] genres = {"Science","Fiction","Study"};

        List<Book> LibraryList;

        public static int MaxClientsNumber { get; private set;}

        public Library(string libName = "NET14/2")
        {
            Random r = new Random();
            LibraryList = new List<Book>();
            MaxClientsNumber = r.Next(1,5);
            for (int i = 0; i < genres.Length; i++)
            {
                int count = r.Next(1, 5);
                for (int j = 0; j < count; j++)
                {
                   LibraryList.Add(new Book("Library-" + libName + ":" + genres[i] + " Book" + j));
                }
                countChartBooks[i] = count;
            }
        }

        public int TotalBooks() 
        {
            int total = 0;
            foreach (var item in countChartBooks)
            {
                total += item;
            }
            return total;
        }

        public void GiveBook(Book book) 
        {
            if (LibraryList.Contains(book)) LibraryList.Remove(book);
            else Console.WriteLine("We can't find your book. Maybe someone borrows it. Sorry!");
        }

        public void 

        public override string ToString()
        {
            Console.WriteLine("Library \"{0}\" has {1} directions.\n Total books count: {2}\n\t\t LIST: \n",LibraryName,genres.Length,TotalBooks());
            foreach (Book item in LibraryList)
            {
                Console.WriteLine(item);
            }
            return "********";
        }

    }

    class ReaderCard
    {
        public static int CardNumber { get; private set; }
         
        public int BorrowBooks { get; private set; }
        public string Name { get; private set; }
        
        
        List<Book> ReaderList { get; private set; }

        public void TakeBook()
        {

        }

        public ReaderCard(string LibraryClient = "Simple client")
        {
            ReaderList = new List<Book>();
            Name = LibraryClient;
            BorrowBooks = 0;
            if (CardNumber < Library.MaxClientsNumber) CardNumber++;
            else Console.WriteLine("Library can't take you. Sorry!");
           
        }

        public override string ToString()
        {
            Console.WriteLine(" Current client: {0} Credit: {1} \n", Name, BorrowBooks);
            //foreach (Book item in ReaderList )
            //{
            //    Console.WriteLine("Card #: {0} Title:  {1}",CardNumber,item);
            //}
            return "******";
        }
    }

    class Book 
    {
        public string Title { get; private set; }

        public Book(string bookname= "Other book")
        {
            Title = bookname;
        }

        public override string ToString()
        {
            return Title;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            Library lib1 = new Library();

            ReaderCard rc1 = new ReaderCard("Maksim");

            

            Console.WriteLine(rc1);

                       
                        
            Console.ReadKey();
        }
    }
}
