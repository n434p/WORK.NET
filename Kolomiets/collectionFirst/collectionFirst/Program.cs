using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectionFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList sort = new SortedList();
            sort.Add("1", "sdf");
            sort.Add("2", "sdf");
            sort.Add("3", "sdf");
            sort.Add("4", "sdfd");

            foreach (SortedList item in sort)
            {
                Console.WriteLine(item.Count);
            }
            
            //ArrayList strArray = new ArrayList();
            //strArray.AddRange(new string[] { "First", "Second", "Third" });
            
            //// Отобразить количество элементов в ArrayList.
            //Console.WriteLine("This collection has {0} items.", strArray.Count);
            //Console.WriteLine();
            //// Добавить новый элемент и отобразить текущее их количество.
            //strArray.Add("Fourth!");
            //Console.WriteLine("This collection has {0} items.", strArray.Count);
            //// Отобразить содержимое.
            //foreach (string s in strArray)
            //{
            //    Console.WriteLine("Entry: {0}", s);
            //}
            //Console.WriteLine();
        }
    }
}
