using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("2", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                //string str = "Привет группа Net 14-2";
                //byte[] strFile = Encoding.UTF8.GetBytes(str);
                //fs.Write(strFile, 0, strFile.Length);
                //fs.Flush();
                //fs.Seek(0, SeekOrigin.Begin);
                //byte[] strRead = new byte[(int)fs.Length];
                //fs.Read(strRead, 4,(int)fs.Length-4);
                //string strFin = Encoding.UTF8.GetString(strRead);
              
                //Console.WriteLine(strFin);
                
               // string str = "Привет группа Net 14-2";
               // StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
               // sw.Write(str);
               ////sw.Dispose();
               // fs.Flush();
               // fs.Seek(0, SeekOrigin.Begin);
               // StreamReader sr = new StreamReader(fs, Encoding.UTF8);
               // string strRead = sr.ReadLine();
               // Console.WriteLine(strRead);
               // sr.Close();
                //sw.Close();

              /*  string str = "Привет группа Net 14-2";
                int age = 24;
                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
                bw.Write(str);
                bw.Write(age);
              */
              /*  fs.Flush();
                fs.Seek(0, SeekOrigin.Begin);*/
                /*StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                string strRead = sr.ReadLine();
                Console.WriteLine(strRead);*/

                BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
                
                string str = br.ReadString();
                int a = br.ReadInt32();
                Console.WriteLine(str);
                Console.WriteLine(a);

            }
        }
    }
}
