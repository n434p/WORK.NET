using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Branch Branch1 = new Branch();

            SharpLeaf cir = new SharpLeaf();
            OvalLeaf OvalLeaf = new OvalLeaf();

            Branch1.Add(cir);
            Branch1.Add(OvalLeaf);

            Branch1.Print();

            Console.WriteLine("***************************");

            Branch Branch2 = new Branch();
            Branch2.AddRange(new List<SquareLeaf> {new SquareLeaf(), new SquareLeaf(), new SquareLeaf()});

            Branch1.Add(Branch2);
            Branch1.Print();


        }
    }

    /// <summary>
    /// Абстрактный класс - Leaf
    /// Объявляет поведение для компонуемых объектов
    /// </summary>
    public abstract class Leaf
    {
        public abstract void Print();
    }


    /// <summary>
    /// Branch - составной объект
    /// Хранит объекты-потомки класса Leaf
    /// Реализует поведение базового класса. Управляет потомками класса Leaf
    /// </summary>
    public class Branch : Leaf
    {
        /// <summary>
        /// Список Leaf'ов
        /// </summary>
        private List<Leaf> leaves = new List<Leaf>();

        /// <summary>
        /// Метод добавления нового "листа"
        /// </summary>
        /// <param name="obj">Простой потомок Leaf</param>
        public void Add(Leaf obj)
        {
           this.leaves.Add(obj);
        }

        /// <summary>
        /// Метод добавления новой коллекции(массива) "листов"
        /// </summary>
        /// <param name="obj">Коллекция(массив) потомков Leaf</param>
        public void AddRange(IEnumerable<Leaf> obj)
        {
            this.leaves.AddRange(obj);
        }

        /// <summary>
        /// Метод удаления "листа"
        /// </summary>
        /// <param name="obj">Простой потомок Leaf</param>
        public void Remove(Leaf obj)
        {
            this.leaves.Remove(obj);
        }


        /// <summary>
        /// Метод удаления коллекции(массива) "листов"
        /// </summary>
        /// <param name="obj">Коллекция(массив) потомков Leaf</param>
        public void RemoveRange(IEnumerable<Leaf> obj)
        {
            foreach (Leaf item in obj)
            {
                this.leaves.Remove(item);
            }
        }

        /// <summary>
        /// Метод управления потомками
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("Branch");
            foreach (Leaf item in this.leaves)
                item.Print();
        }
    }


    /// <summary>
    /// Простой потомок класса Leaf - "лист" дерева
    /// </summary>
    public class SharpLeaf : Leaf
    {
        public override void Print()
        {
            Console.WriteLine("SharpLeaf");
        }
    }

    /// <summary>
    /// Простой потомок класса Leaf - "лист" дерева
    /// </summary>
    public class OvalLeaf : Leaf
    {
        public override void Print()
        {
            Console.WriteLine("OvalLeaf");
        }
    }

    /// <summary>
    /// Простой потомок класса Leaf - "лист" дерева
    /// </summary>
    public class SquareLeaf : Leaf
    {
        public override void Print()
        {
            Console.WriteLine("SquareLeaf");
        }
    }
}
