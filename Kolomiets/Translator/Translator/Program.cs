using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class Program
    {
        class Translate 
        {

            public void FillDictionary() 
            {
                using (FileStream fs = new FileStream("2", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {

                    Dictionary<string, string> dic = new Dictionary<string, string>();

                    StreamReader sr = new StreamReader(fs, Encoding.Default);

                    while (!sr.EndOfStream)
                    {
                        dic.Add(sr.ReadLine(), sr.ReadLine());
                    }

                      foreach (var item in dic)
                {
                    Console.WriteLine(item.Key+" - "+item.Value);
                }
                }
            }
            

        }

        static void Main(string[] args)
        {

        

            

        }
    }
}
