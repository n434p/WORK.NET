using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
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
            return string.Format("{0} S = {1} P = {2}", Name, GetSquare(), GetPerimetr ());
        }

    }

    class Triangle: Figure 
    {
        double height;
        double aSide, bSide, cSide;

        public Triangle(double h = 4,double a = 3,double b = 4,double c = 5 ):base("Triangle") 
        {
            height = h;
            aSide = a;
            bSide = b;
            cSide = c;
        }

        public override double GetPerimetr()
        {
            return aSide + bSide + cSide;
        }

        public override double GetSquare()
        {
            return  aSide * height/2;
        }
    }

    class Quad : Figure
    {
        
        double aSide;

        public Quad(double a = 3):base("Quad")
        {
            aSide = a;        
        }

        public override double GetPerimetr()
        {
            return aSide*4;
        }

        public override double GetSquare()
        {
            return  aSide * aSide;
        }
    }

    class Rectangle : Figure
    {

        double aSide;
        double bSide;

        public Rectangle(double a = 3, double b =4)
            : base("Rectangle")
        {
            aSide = a;
            bSide = b;
        }

        public override double GetPerimetr()
        {
            return (aSide+bSide) * 2;
        }

        public override double GetSquare()
        {
            return aSide * bSide;
        }
    }

    class Rhombus : Figure
    {

        double aSide;
        double height;

        public Rhombus(double a = 3, double h = 4)
            : base("Rhombus ")
        {
            aSide = a;
            height = h;
        }

        public override double GetPerimetr()
        {
            return 4*aSide;
        }

        public override double GetSquare()
        {
            return aSide*height;
        }
    }

    class Parallelogram : Figure
    {

        double baseSide;
        double leftSide;
        double height;

        public Parallelogram(double b = 3, double l =2, double h = 4)
            : base("Parallelogram")
        {
            baseSide = b;
            height = h;
        }

        public override double GetPerimetr()
        {
            return 2*(baseSide+leftSide);
        }

        public override double GetSquare()
        {
            return baseSide * height;
        }
    }

    class Trapezoid : Figure
    {

        double bottomSide;
        double topSide;
        double leftSide;
        double rightSide;
        double height;

        public Trapezoid(double b = 3, double t = 2, double l = 3, double r = 3, double h = 4)
            : base("Trapezoid ")
        {
            bottomSide = b;
            topSide = t;
            leftSide = l;
            rightSide = r;
            height = h;
        }

        public override double GetPerimetr()
        {
            return bottomSide + topSide+leftSide+rightSide ;
        }

        public override double GetSquare()
        {
            return (bottomSide+topSide)*2/height;
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
