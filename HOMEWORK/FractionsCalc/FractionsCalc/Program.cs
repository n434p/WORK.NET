using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FractionsCalc
{
    class Fraction
    {
        int numerator;
        int denumerator;
        int intPart;

        public Fraction(int numerator = 1, int denumerator = 1, int intPart = 0)
        {
            this.numerator = numerator;
            this.denumerator = denumerator;
            this.intPart = intPart;
        }

        public int Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public int Denumerator
        {
            get { return this.denumerator; }
            set
            {
                if (value == 0) this.denumerator = 1;
                else this.denumerator = value;
            }
        }

        public int IntPart
        {
            get { return this.intPart; }
            set { this.intPart = value; }
        }

        public Fraction Sum(Fraction frac1, Fraction frac2)
        {
            Fraction res = new Fraction();
            res.numerator = frac1.numerator * frac2.denumerator + frac2.numerator * frac1.denumerator;
            res.denumerator = frac1.denumerator * frac2.denumerator;
            return res;
        }

        public Fraction Subtract(Fraction frac1, Fraction frac2)
        {
            Fraction res = new Fraction();
            res.numerator = frac1.numerator * frac2.denumerator - frac2.numerator * frac1.denumerator;
            res.denumerator = frac1.denumerator * frac2.denumerator;
            return res;
        }

        public Fraction Multiplication(Fraction frac1, Fraction frac2)
        {
            Fraction res = new Fraction();
            res.numerator = frac1.numerator * frac2.numerator;
            res.denumerator = frac1.denumerator * frac2.denumerator;
            return res;
        }

        public Fraction Division(Fraction frac1, Fraction frac2)
        {
            Fraction res = new Fraction();
            res.numerator = frac1.numerator * frac2.denumerator;
            res.denumerator = frac1.denumerator * frac2.numerator;
            return res;
        }

        

        public override string ToString()
        {
            int param = Numerator > Denumerator ? Denumerator : Numerator;
            for (int i = param; i > 1; i--)
            {
                if (Numerator % i == 0 && Denumerator % i == 0)
                {
                    Numerator /= i;
                    Denumerator /= i;
                }
            }
            if (Numerator > Denumerator)
            {
                IntPart = Numerator / Denumerator;
                Numerator -= IntPart * Denumerator;
            }
            return string.Format("{0} {1}/{2}", IntPart, Numerator, Denumerator);
        }


    }

    class Program
    {
        static Fraction StrToFrac(string strFrac) 
        {
            Fraction resFrac = new Fraction();
            try 
            {
            List<string> frac = strFrac.Split(' ', '/').ToList();
            if (frac.Count == 2)
            {
                resFrac.Numerator = Convert.ToInt32(frac[0]);
                resFrac.Denumerator = Convert.ToInt32(frac[1]);
            }
            if (frac.Count == 3)
            {
                resFrac.IntPart = Convert.ToInt32(frac[0]);
                resFrac.Numerator = Convert.ToInt32(frac[1]);
                resFrac.Denumerator = Convert.ToInt32(frac[2]);
            }
            }
            catch
            { Console.WriteLine("Your entry has mistakes."); }
            return resFrac;

        }

        static void CalcForm(ref Fraction frac)
        {
            frac.Numerator = frac.Numerator + frac.IntPart * frac.Denumerator;
            frac.IntPart = 0;
        }

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Fraction Calculator: \n Fraction must have next order: IntPart_Numerator/Denumerator\n Negative fractions are not allowed to enter.\n");
                Console.WriteLine("\nPlease enter 1-st fraction:  ");
                Fraction frac1 = StrToFrac(Console.ReadLine());


                Console.WriteLine("\nPlease enter 2-st fraction:  ");
                Fraction frac2 = StrToFrac(Console.ReadLine());
                Fraction resFrac = new Fraction();

                CalcForm(ref frac1);
                CalcForm(ref frac2);

                Console.WriteLine("Choose any operation in: + - * /  ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Add:
                        resFrac.Sum(frac1, frac2);
                        Console.WriteLine(resFrac);
                        break;
                    case ConsoleKey.Divide:
                        resFrac.Division(frac1, frac2);
                        break;
                    case ConsoleKey.Multiply:
                        resFrac.Multiplication(frac1, frac2);
                        break;
                    case ConsoleKey.Subtract:
                        resFrac.Subtract(frac1, frac2);
                        break;
                    default: return ;
                        break;
                }
                Console.WriteLine("Your result: {0}",resFrac);

            } 
        }
    }
}
