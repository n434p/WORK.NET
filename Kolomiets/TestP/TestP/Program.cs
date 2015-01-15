using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TestP
{
     [Serializable]
    class Temp
    {
        string s;
        public int a; 
        double d;

        public Temp(string ss="sdfsd", int aa = 10, double dd=5)
        {
            s = ss;
            a = aa;
            d = dd;
        }
        public override string ToString()
        {
                    return string.Format("s -{0} a - {1} d - {2}",s,a,d);
        }
    }

    class Program 
    {
        static void Main(string[] args)
        {
        
            Temp t = new Temp();
            Temp t2 = new Temp("s1123",123,55);

            using (FileStream fs = new FileStream("1",FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
               // bf.Serialize(fs,t);
               // bf.Serialize(fs, t2);
                Temp t3 = (Temp)bf.Deserialize(fs);
                Console.WriteLine(t3);

                fs.Close();
            }
        }
    }
}
