using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listString = new List<string>() { "sdsd","sdsds1111", "2222222"};
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            listString.Add(str);
            foreach (var s in listString)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n\n");
            listString.Remove("s");
            try
            {
                string[] mas = { "1", "2", "3" };
                listString.CopyTo(mas);
                for (int i = 0; i < mas.Length; i++)
                {
                    Console.WriteLine(mas[i].ToString());
                }
            }
            catch
            {
                Console.WriteLine("Error");
              //  return;
            }

            Console.WriteLine("23534654757");
            //string strTest = "1234567890";
            if (str.Contains("12"))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        

           
        }
    }
}
