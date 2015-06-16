using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load("..//..//test.xml");
            //XmlNodeList list = doc.GetElementsByTagName("car");
            //foreach (XmlNode node in list)
            //{
            //    Console.WriteLine("{0} {1}", node["manufactured"].InnerText, node["model"].InnerText);
            //}

            try
            {
                //XmlDocument doc = new XmlDocument();
                //doc.Load("..//..//test.xml");
                //ShowNode(doc.DocumentElement);
                //XmlNode root = doc.DocumentElement;
                //root.RemoveChild(root.LastChild);
                //Console.WriteLine("\n\n");
                //ShowNode(doc.DocumentElement);
                //Console.WriteLine("\n\n");
                //XmlNode bike = doc.CreateElement("motorcycle");

                //XmlNode el1 = doc.CreateElement("manufactured");
                //XmlNode el2 = doc.CreateElement("model");
                //XmlNode el3 = doc.CreateElement("year");
                //XmlNode el4 = doc.CreateElement("color");
                //XmlNode el5 = doc.CreateElement("engine");


                //XmlNode text1 = doc.CreateTextNode("YAMAHA");
                //XmlNode text2 = doc.CreateTextNode("YMH-300");
                //XmlNode text3 = doc.CreateTextNode("2002");
                //XmlNode text4 = doc.CreateTextNode("yellow");
                //XmlNode text5 = doc.CreateTextNode("370 HP");

                //el1.AppendChild(text1);
                //el2.AppendChild(text2);
                //el3.AppendChild(text3);
                //el4.AppendChild(text4);
                //el5.AppendChild(text5);

                //bike.AppendChild(el1);
                //bike.AppendChild(el2);
                //bike.AppendChild(el3);
                //bike.AppendChild(el4);
                //bike.AppendChild(el5);

                //root.AppendChild(bike);

                //doc.Save("edited.xml");

                //doc.Load("edited.xml");
                //ShowNode(doc.DocumentElement);

                AddElem();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AddElem()
        {
            XmlDocument doc = new XmlDocument();

            string path = "Cart.xml";

            if (File.Exists(path)) doc.Load(path);
            else doc.AppendChild(doc.CreateElement("goods"));

            XmlElement root = doc.DocumentElement;
            XmlNode good = doc.CreateElement("good");

            XmlNode el1 = doc.CreateElement("Name");
            XmlNode el2 = doc.CreateElement("Code");
            XmlNode el3 = doc.CreateElement("Price");
            XmlNode el4 = doc.CreateElement("Quantity");
            XmlNode el5 = doc.CreateElement("Cell");

            Console.WriteLine("Enter next fields to add element in cart: \n");
            Console.WriteLine("Name: \n");
            XmlNode text1 = doc.CreateTextNode(Console.ReadLine());
            Console.WriteLine("Code: \n");
            XmlNode text2 = doc.CreateTextNode(Console.ReadLine());
            Console.WriteLine("Price: \n");
            XmlNode text3 = doc.CreateTextNode(Console.ReadLine());
            Console.WriteLine("Quantity: \n");
            XmlNode text4 = doc.CreateTextNode(Console.ReadLine());
            Console.WriteLine("Cell: \n");
            XmlNode text5 = doc.CreateTextNode(Console.ReadLine());


            el1.AppendChild(text1);
            el2.AppendChild(text2);
            el3.AppendChild(text3);
            el4.AppendChild(text4);
            el5.AppendChild(text5);

            good.AppendChild(el1);
            good.AppendChild(el2);
            good.AppendChild(el3);
            good.AppendChild(el4);
            good.AppendChild(el5);

            root.AppendChild(good);

            Good g = new Good(good.ChildNodes);
            Console.WriteLine("------------------------\n Next item added to cart:");
            Console.WriteLine(g);

            doc.Save(path);

            doc.Load(path);
            ShowCart(doc.DocumentElement);
        }

        static void ShowCart(XmlNode node, Boolean completeList=true)
        {
            if (completeList) Console.WriteLine("Cart items: \n");    
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.LocalName == "good")
                {
                    Good g = new Good(n.ChildNodes);
                    Console.WriteLine(g);
                }
            } 
          


        }


        static void ShowNode(XmlNode node)
        {
            Console.WriteLine("Type = {0}\t Name={1}\t Value={2}\n", node.NodeType, node.Name, node.Value);
            if (node.Attributes != null)
            {
                foreach (XmlAttribute a in node.Attributes)
                {
                    Console.WriteLine("Type = {0}\t Name={1}\t Value={2}\n", a.NodeType, a.Name, a.Value);
                }
            }
            if (node.HasChildNodes)
            {
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode n in children)
                {
                    ShowNode(n);
                }

            }
        }

        class Good
        {
            public string Name, Code, Price, Quantity, Cell;

            public Good(XmlNodeList n)
            {
                Name = n.Item(0).InnerText;
                Code = n.Item(1).InnerText;
                Price = n.Item(2).InnerText;
                Quantity = n.Item(3).InnerText;
                Cell = n.Item(4).InnerText;
            }

            public override string ToString()
            {
                Console.WriteLine("------------------------");
                return string.Format("Name={0}\t Code={1}\t Price={2}\t Quantity={3}\t Cell={4}", Name, Code, Price, Quantity, Cell);
            }
        }
    }
}
