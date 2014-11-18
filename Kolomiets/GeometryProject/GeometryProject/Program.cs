using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    interface IInit 
    {
        double Height { get; set; }
        double[] Side { get; set; }
    }

    abstract class Figure
    {
        public string Name { get; set; }
        
        public Figure(string n = "Some figure") 
        {
            Name = n;
        }

        
        public abstract double GetSquare();
        public abstract double GetPerimetr();


        public override string ToString()
        {
            return string.Format("{0} S = {1:F} P = {2:F}", Name, GetSquare(), GetPerimetr ());
        }

    }


    class Triangle: Figure, IInit
    {

        public double Height { get; set; }
        
        public double[] Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="h"> triangle height</param>
        /// <param name="a"> 1st sidde</param>
        /// <param name="b"> 2nd side</param>
        /// <param name="c"> 3rd side</param>
        public Triangle(double h = 4,double a = 3,double b = 4,double c = 5 ):base("Triangle") 
        {
            
            Height = h;
            Side = new double[3] {a,b,c};
         
        }

        public override double GetPerimetr()
        {
            return Side[0] + Side[1] + Side[2];
        }

        public override double GetSquare()
        {
            return  Side[0] * Height/2;
        }
    }

    class Quad : Figure,  IInit
    {

        public double Height { get; set; }
        public double[] Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"> basis side </param>
        public Quad(double a = 3):base("Quad")
        {
            Height = a;      
        }

        public override double GetPerimetr()
        {
            return Height*4;
        }

        public override double GetSquare()
        {
            return Height * Height;
        }
    }

    class Rectangle : Figure , IInit
    {
        public double Height { get; set; }
        public double[] Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"> long side</param>
        /// <param name="b"> short side</param>
        public Rectangle(double a = 3, double b =4)
            : base("Rectangle")
        {
            Height = a;
            Side = new double [1]{b};
        }

        public override double GetPerimetr()
        {
            return (Height+Side[0]) * 2;
        }

        public override double GetSquare()
        {
            return Side[0] * Height;
        }
    }

    class Rhombus : Figure, IInit
    {

        public double Height { get; set; }
        public double[] Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"> basis side</param>
        /// <param name="h"> height </param>
        public Rhombus(double a = 3, double h = 4)
            : base("Rhombus ")
        {
            Height = h;
            Side = new double[1] { a };
        }

        public override double GetPerimetr()
        {
            return 4*Side[0];
        }

        public override double GetSquare()
        {
            return Side[0]*Height;
        }
    }

    class Parallelogram : Figure, IInit
    {

        public double Height { get; set; }
        public double[] Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"> basis line</param>
        /// <param name="l"> left side </param>
        /// <param name="h"> height </param>
        public Parallelogram(double b = 3, double l =2, double h = 4)
            : base("Parallelogram")
        {
            Side = new double[2]{b,l} ;
            Height = h;
        }

        public override double GetPerimetr()
        {
            return 2*(Side[0]+Side[1]);
        }

        public override double GetSquare()
        {
            return Side[0] * Height;
        }
    }

    class Trapezoid : Figure, IInit
    {

        public double Height { get; set; }
        public double[] Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"> bottom side</param>
        /// <param name="t"> top side</param>
        /// <param name="l"> left side</param>
        /// <param name="r"> right side</param>
        /// <param name="h"> height </param>
        public Trapezoid(double b = 3, double t = 2, double l = 3, double r = 3, double h = 4)
            : base("Trapezoid ")
        {
            Side = new double [4]{b, t,l,r};
            Height = h;
        }

        public override double GetPerimetr()
        {
            return Side[0] + Side[1]+Side[2]+Side[3] ;
        }

        public override double GetSquare()
        {
            return (Side[0]+Side[1])*2/Height;
        }
    }

    class Circle : Figure
    {

        double radius;
    
        public Circle(double r = 3)
            : base("Circle")
        {
           radius = r;
        }

        public override double GetPerimetr()
        {
            return 2*radius*Math.PI;
        }

        public override double GetSquare()
        {
            return Math.PI*radius*radius;
        }
    }

    class Ellipse : Figure
    {

        double aAxis;
        double bAxis;

        public Ellipse(double a = 3, double b = 4)
            : base("Ellipse ")
        {
            aAxis = a;
            bAxis = b;
        }

        public override double GetPerimetr()
        {
            return Math.PI*(aAxis+bAxis);
        }

        public override double GetSquare()
        {
            return Math.PI * aAxis * bAxis;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Triangle());
            Console.WriteLine(new Quad());
            Console.WriteLine(new Rectangle());
            Console.WriteLine(new Rhombus());
            Console.WriteLine(new Parallelogram());
            Console.WriteLine(new Trapezoid());
            Console.WriteLine(new Circle());
            Console.WriteLine(new Ellipse());

            Console.ReadKey();
        }
    }

}
