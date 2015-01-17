using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Translator
{
    class Vocabulary
    {
        Dictionary<string, string> vocabulary; 

        public string Path {get; protected set;}

        public Vocabulary(string path) 
        {
            vocabulary = new Dictionary<string, string>();
            Path = path;

            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                StreamReader sr = new StreamReader(fs, Encoding.Default);

                while (!sr.EndOfStream)
                {
                    vocabulary.Add(sr.ReadLine(), sr.ReadLine());
                }
            }
        }

        public void Add(string phrase, string translation)
        { 
            if (Translate(phrase) != "" || Translate(translation) !="") return;
            Regex engEx = new Regex("^[A-Z]+$",RegexOptions.IgnoreCase);
            Regex rusEx = new Regex("^[А-Я]+$",RegexOptions.IgnoreCase);
            if ((!engEx.IsMatch(phrase)) || (!rusEx.IsMatch(translation)) ) return;
            using (FileStream fs = new FileStream(Path,FileMode.Open,FileAccess.Write, FileShare.ReadWrite))
            {   
                fs.Seek(0,SeekOrigin.End);
                StreamWriter sw = new StreamWriter(fs,Encoding.Default);
                sw.AutoFlush = true;     
                sw.WriteLine(phrase);
                sw.WriteLine(translation);
                vocabulary.Add(phrase, translation);
                Console.WriteLine("Next pair was added:\t {0} - {1}", phrase,translation);
            }
        }

        public override string ToString()
        {
            Console.WriteLine("Vocabulary contains:\n");
            foreach (var item in vocabulary)
            {
                Console.WriteLine(item.Key+"\t"+item.Value );
            }
            return "*******************";
        }

        public string Translate(string word) 
        {
            foreach (KeyValuePair<string,string> item in vocabulary)
            {
                if (item.Key == word.ToLower()) return item.Value;
                if (item.Value == word.ToLower()) return item.Key;
            }
            return "";
        }
        
       
        
    }
}
