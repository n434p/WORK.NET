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
        public string Title { get; private set; }

        public static List<Book> BooksList { get; private set; }
        public static List<ReaderCard> ClientsList { get; private set; }

        public Library(string libName = "NET14/2")
        {
            Random r = new Random();
            Title = libName;
            BooksList = new List<Book>();
            ClientsList = new List<ReaderCard>();

            for (int i = 0; i < r.Next(2, 5); i++)
            {
                ClientsList.Add(new ReaderCard());
            }

            for (int j = 0; j < r.Next(5,15); j++)
                {
                   BooksList.Add(new Book("Library-" + Title + ":" + " Item #"+ (j+1)));
                }
                
        }

        /// <summary>
        /// Takes/returns given book.
        /// </summary>
        /// <param name="book"></param>
        /// <param name="reader"></param>
        public void GetBook(Book book,ReaderCard reader) 
        {
            ReaderCard Carrier = reader; // to keep reader link if book was borrowed.
            int count = 0;
            foreach (var item in Library.ClientsList) // finds book carrier.
            {
                if (item.ReaderList.Contains(book))
                {
                    count++;
                    Carrier = item;
                }
            }
            if (count != 0) 
            {
                Carrier.ReaderList.Remove(book); 
                book.ChangeStatus();
                Console.WriteLine("\"{0}\" returns \"{1}\"", Carrier.Name, book.Title);
            }
            else 
            { 
                Carrier.ReaderList.Add(book);
                book.ChangeStatus();
                Console.WriteLine("\"{0}\" takes \"{1}\"", Carrier.Name, book.Title);
            }
                       
        }

        /// <summary>
        /// Displays book list as red/green string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Console.WriteLine("Library \"{0}\".\n\n Total books count: {1}\n\n\t\t BOOKS LIST: \n",Title,BooksList.Count);
            int i = 1; // book list counter
            string status =""; // if book has carrier - status displays it.
            foreach (Book item in BooksList)
            {
                foreach (var client in ClientsList)
                {
                    if (client.ReaderList.Contains(item)) status = client.Name;
                }
                Console.ForegroundColor = (!item.Borrowed) ? ConsoleColor.Green : ConsoleColor.Red;
                status = (!item.Borrowed) ? "FREE" : status;
                Console.WriteLine("{0}\t{1}\t{2}",i++,item,status);
                Console.ResetColor();
            }
            return "\n\t\t********";
        }
         
    }

    class ReaderCard
    {
        public string Name { get; private set; }
        public static int CardNumber { get; private set; }
        public List<Book> ReaderList { get; private set; }

        public void MakeRec(Book book)
        {
            if (ReaderList.Contains(book)) ReaderList.Remove(book);           
            else ReaderList.Add(book);
            
        }

        public ReaderCard(string LibraryClient = "Reader")
        {
               ReaderList = new List<Book>();
               Name = LibraryClient + (++CardNumber).ToString();       
        }

        public override string ToString()
        {
            Console.WriteLine(" Current client: \"{0}\" Credit: {1} \n", Name, ReaderList.Count);
            int i = 1; // borrowed books counter
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Book item in ReaderList)
            {
                Console.WriteLine("{0}. Card #: {1} Item:  \"{2}\"",i++, CardNumber, item.Title );
            }
            Console.ResetColor();
            return "\t\t********";
        }
    }

    class Book 
    {
        
        public string Title { get; private set; }
        public string Genre { get; private set; }//= {"Science","Fiction","Study"};
        static string[] genres = {"Science","Fiction","Study  ","Comics  ","Magazine","Encyclopedy"};
        public bool Borrowed { get; private set; }
        public string Reader { get; private set; }

        public void ChangeStatus() 
        {
            Borrowed =!Borrowed;
        }
    
        public Book(string bookname= "Other book")
        {
            Title = bookname;
            Random r = new Random();
            Thread.Sleep(20);
            Genre = genres[r.Next(0,genres.Length-1)];
            Borrowed = false;          
        }

        public override string ToString()
        {
            
            return string.Format("Genre:\"{0}\" \t Book:\"{1}\"",Genre,Title);
            
        }
    }

    class Program
    {
        public static void Menu() 
        {
            Library lib = new Library();
            do
            {
            Console.Clear();
            Console.WriteLine("Welcome to our Library!\n\n");
            Console.WriteLine(lib);    
            Console.WriteLine("\n1. Library clients");
            Console.WriteLine("2. Take/Return book");
            Console.WriteLine("\n0. Exit");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D0:
                    return;
                case ConsoleKey.D1:// Library Clients
                    Console.Clear();
                    foreach (var item in Library.ClientsList)
                    {
                        Console.WriteLine(item);   
                    }
                    break;
                case ConsoleKey.D2:// Takes/returns book
                    {
                        Console.Clear();
                        Random r = new Random();
                        lib.GetBook(Library.BooksList[r.Next(Library.BooksList.Count)], Library.ClientsList[r.Next(Library.ClientsList.Count)]);
                        break;
                    }
                default:
                    break;
                    
            
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            } while (true);
        }

        static void Main(string[] args)
        {
            Menu();    
                       
           
        }
    }
}
