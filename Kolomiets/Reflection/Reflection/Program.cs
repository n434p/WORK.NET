using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace Reflection
{
    class Test 
    {
        public void MyMethod(int a) 
        {
            Console.WriteLine(a);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Type t = Type.GetType("Reflection.Test");
            //var test = Activator.CreateInstance(t);
            //test.GetType().GetMethod("MyMethod").Invoke(test, new object[1] {123});
      

            //MethodInfo mf = test.GetType().GetMethod("MyMethod");

            //mf.Invoke(test, new object[1] {123});

            Assembly asm = Assembly.LoadFile("D:/Kolomiets/ClassLibrary2.dll");
            Console.WriteLine(asm.FullName);

            Type[] type = asm.GetTypes();

            foreach (var item in type)
            {
                
                var obj = Activator.CreateInstance(item);
                
                
               
             //   obj.GetType().GetMethods()
             //    item.GetMethods()  


                if (item.GetMethods().Length != 0) Console.WriteLine("Method: ");
                foreach (MethodInfo mi in obj.GetType().GetMethods())
                {
                    Console.WriteLine(mi.Name);
                    if (mi.GetParameters().Length != 0)
                    {
                        Console.WriteLine("Parameters: ");

                        object[] objTemp = null;
                        int i = 0;

                        foreach (ParameterInfo pi in mi.GetParameters())
                        {
                            Console.WriteLine(pi.Name + " " + pi.ParameterType);
                            Console.WriteLine("****************\n");
                            objTemp[i] = new pi.DefaultValue;

                        }

                        Console.WriteLine("\n*\n" + Convert.ToString(mi.Invoke(obj, objTemp)) + "\n*\n");

                    }


                }
            }
            Console.ReadKey();
        }
    }
}
