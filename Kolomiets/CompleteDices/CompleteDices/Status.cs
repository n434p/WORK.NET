using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompleteDices
{
    class Status
    {
        public static void WriteStatus(Thread g) 
        {
            using (FileStream fs = new FileStream("save.0", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs,g);
            }
        }

        public static Thread ReadStatus()
        {
            using (FileStream fs = new FileStream("save.0", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (Thread) bf.Deserialize(fs);
            }
        }
    }
}
