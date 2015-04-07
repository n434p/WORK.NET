using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContvarProj
{
    /// <summary>
    /// Тип возвращаемого занчения совпадает с типом пришедшим.
    /// Обобщенный интерфейсю Указанный тип должен соответствовать в нужных местахю 
    /// Т - гарантия подстановки правильного типа
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContainer<T> 
    {
        T GetItem();
    }

    /// <summary>
    /// Обобщенній интерфейс реализуетсґя только через обобщенній класс 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Container<T> : IContainer<T> 
    {
        private T item;

        public Container(T item)
        {
            this.item = item;
        }

        public T GetItem()
        {
            return this.item;
        }
    }

    public class Circle
    { 

    }

    public class Triangle
    {
 
    }

    class Program 
    {
        static void Main(string[] args)
        {
            #region COVAR&CONTRVAR BOXING&UNBOXING
            //string str = "www"; // Упаковка
            //object obj = str;

            //IEnumerable<string> listStrings = new List<string>(); // Covariation with ONLY generic types
            //IEnumerable<object> listObject = listStrings; // Covariation

            //Action<object> actObj = SetObject; /// ковариантность методов
            //Action<string> actStr = SetString;

            ///// Упаковка каждого элемента массива строк в массив обжект с элементами обчект содержащих строку
            //object[] mas = new String[10]; // Упаковка
            //foreach (var item in mas)
            //{
            //    Console.WriteLine(item + " + ");
            //}
            #endregion

            #region GENERIC INTERFACE CLASS
            Container<int> c1 = new Container<int>(55);
            Console.WriteLine(c1.GetItem());

            //Container<string> c2 = new Container<string>("str");
            //Console.WriteLine(c2.GetItem());

            ///-----------------------------------
            ///
            #endregion

            IContainer<Circle> c = new Container<Circle>(new Circle());
            Console.WriteLine(c.GetItem());

        }

        //static object GetObject()
        //{
        //    return null;
        //}
        //static string GetString()
        //{
        //    return "";
        //}
        //static void SetObject(object o)
        //{           
        //}
        //static void SetString(string s)
        //{          
        //}
    }
}
