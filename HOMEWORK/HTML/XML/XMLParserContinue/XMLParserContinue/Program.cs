using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParserContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlTextReader reader = null;
            //try
            //{
            //    reader = new XmlTextReader("XMLCars.xml");
            //    reader.WhitespaceHandling = WhitespaceHandling.None;
            //    reader.Read();
            //    while (reader.Read()) 
            //    {
            //        if (reader.HasAttributes) {
            //            Console.WriteLine("Type = {0}\t Name= {1}\t Value={2}", reader.NodeType, reader.LocalName, reader.Value);
            //            while (reader.MoveToNextAttribute())
            //            {
            //               Console.WriteLine("Type = {0}\t Name= {1}\t Value={2}",reader.NodeType,reader.LocalName, reader.Value);
            //            }
            //            XmlReader r = reader.ReadSubtree();
            //            if (r != null)
            //            {
            //                Console.WriteLine(r.);
            //            }
                       
            //        }

            //        //Console.WriteLine("Type = {0}\t Name= {1}\t Value={2}",reader.NodeType,reader.LocalName, reader.Value);
            //        //if (reader.AttributeCount > 0) 
            //        //{
            //        //    while (reader.MoveToNextAttribute())
            //        //    {
            //        //       Console.WriteLine("Type = {0}\t Name= {1}\t Value={2}",reader.NodeType,reader.LocalName, reader.Value);
            //        //    }
            //        //}
            //    }
            //}
            //finally 
            //{
            //    if (reader != null) 
            //        reader.Close();
            //}

            XmlTextWriter wr = null;
            try
            {
                wr = new XmlTextWriter("Cars.xml", Encoding.Unicode);
                wr.Formatting = Formatting.Indented;
                wr.WriteStartDocument();
                wr.WriteStartElement("cars");
                wr.WriteStartElement("car");
                wr.WriteAttributeString("image", "image1.jpg");
                wr.WriteElementString("manufactured","Germany");
                wr.WriteElementString("model","VAZ");
                wr.WriteElementString("color","red");
                wr.WriteElementString("year","1234");
                wr.WriteElementString("speed","120");
                wr.WriteEndElement();
                wr.WriteEndElement();

            }
            finally 
            {
                if (wr != null) 
                    wr.Close();
            }
        }
    }
}
