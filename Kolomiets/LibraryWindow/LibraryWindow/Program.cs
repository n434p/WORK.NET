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
                   BooksList.Add(new Book("Library-" + Title + ":" + " Item #"+ j));
                }
                
        }

        public void GetBook(int bookIndex,int clientIndex) 
        {
            ClientsList[clientIndex].MakeRec(BooksList[bookIndex]);
        }

        public override string ToString()
        {
            Console.WriteLine("Library \"{0}\".\n Total books count: {1}\n\t\t LIST: \n",Title,BooksList.Count);
            int i = 1;
            string status ="";
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
            return "\t\t********";
        }

    }

    class ReaderCard
    {
        public static int TotalNumber { get; private set; }
        public string Name { get; private set; }
        public int CardNumber { get; private set; }
        public List<Book> ReaderList { get; private set; }

        public void MakeRec(Book book)
        {
            if (ReaderList.Contains(book)) ReaderList.Remove(book);           
            else ReaderList.Add(book);
            book.ChangeStatus();
        }

        public ReaderCard(string LibraryClient = "Reader ")
        {
               
               ReaderList = new List<Book>();
               Name = LibraryClient + TotalNumber.ToString();
               CardNumber = TotalNumber;
               TotalNumber++;
                   
        }

        public override string ToString()
        {
            Console.WriteLine(" Current client: {0} Credit: {1} \n", Name, ReaderList.Count);
            int i = 1;
            foreach (Book item in ReaderList)
            {
                Console.WriteLine("{0} Card #: {1} Item:  {2}",i++, CardNumber, item);
            }
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


        static void Main(string[] args)
        {
            Random r = new Random();

            Library lib1 = new Library();

            ReaderCard rc1 = new ReaderCard();

            Book book1 = new Book("MATH for dummies");

            Console.WriteLine(lib1);
            foreach (var item in Library.ClientsList)
            {
                Console.WriteLine(item);
            }
            lib1.GetBook(1, 1);
            
            //lib1.GetBook(1, 1);
            Console.WriteLine(lib1);
            foreach (var item in Library.ClientsList)
            {
                Console.WriteLine(item);
            }
                       
                        
            Console.ReadKey();
        }
    }
}
