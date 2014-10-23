using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FractionsCalc
{    
    class Fraction
    {
        int num;
        int denum;
        int intPart;

        public Fraction(int num = 0, int denum = 1, int intPart = 0)
        {
            this.num = num;
            this.denum = denum;
            this.intPart = intPart;
        }

        public int Num
        {
            get { return this.num; }
            set { this.num = value; }
        }

        public int Denum
        {
            get { return this.denum; }
            set
            {
                if (value == 0) this.denum = 1;
                else this.denum = value;
            }
        }

        public int IntPart
        {
            get { return this.intPart; }
            set { this.intPart = value; }
        }

        public Fraction Sum(Fraction frac1, Fraction frac2)
        {
            num = frac1.Num * frac2.Denum + frac2.Num * frac1.Denum;
            denum = frac1.Denum * frac2.Denum;
            return this;
        }

        public Fraction Subtract(Fraction frac1, Fraction frac2)
        {
            num = frac1.Num * frac2.Denum - frac2.Num * frac1.Denum;
            denum = frac1.Denum * frac2.Denum;
            return this;
        }

        public Fraction Multiplication(Fraction frac1, Fraction frac2)
        {
            num = frac1.Num * frac2.Num;
            denum = frac1.Denum * frac2.Denum;
            return this;
        }

        public Fraction Division(Fraction frac1, Fraction frac2)
        {

            num = frac1.num * frac2.denum;
            denum = frac1.denum * frac2.num;
            return this;
        }

        public override string ToString()
        {   
            // The biggest delimeter for the both elements (numerator and denumerator) is a result of count down cycle.
            // it avoids from another/next division.
            int sign = (num  <0)?-1:1;
            num *= sign;

            int param = num > denum ? denum : num;
            for (int i = param; i > 1; i--)
            {
                if (num % i == 0 && denum % i == 0)
                {
                    this.num /= i;
                    this.denum /= i;
                }
            }
            // transforms in proper fraction form.
            if (num >= denum)
            {
                intPart = num / denum;
                num -= intPart * denum;
            }
             
            // displays result for each case(only integer part, without integer part, whole fraction) of fraction.
            if (num == 0) return (intPart*sign).ToString() ;
            else if (intPart == 0) return string.Format("{0}/{1}", num*sign, denum);
            else return string.Format("{0} {1}/{2}", intPart*sign, num, denum);
        }


    }

    class Program
    {
        static bool error = false;

        /// <summary>
        /// Converts string into improper fraction
        /// </summary>
        /// <param name="strFrac"></param>
        /// <returns></returns>
        static Fraction StrToFrac(string strFrac) 
        {
            Fraction resFrac = new Fraction();
            try 
            {   // Checks for the right entry.
                //foreach (char item in strFrac)
                //{
                //    if (!char.IsDigit(item) || item != ' ' || item != '/') throw new Exception();
                //}


                List<string> frac = strFrac.Split('-',' ', '/').ToList();
                switch (frac.Count)
                {   case 1:
                        resFrac.IntPart = Convert.ToInt32(frac[0]);
                        break;
                    case 2:
                        if (!strFrac.Contains('/')) throw new Exception();
                        resFrac.Num = Convert.ToInt32(frac[0]);
                        resFrac.Denum = Convert.ToInt32(frac[1]);
                        break;
                    case 3:
                        resFrac.IntPart = Convert.ToInt32(frac[0]);
                        resFrac.Num = Convert.ToInt32(frac[1]);
                        resFrac.Denum = Convert.ToInt32(frac[2]);
                        break;
                }

            }
            catch
            {  
                Console.WriteLine("Wrong fraction!");
                error = true;
            }

            resFrac.Num += resFrac.Denum * resFrac.IntPart;
            resFrac.IntPart = 0;

            return resFrac;

        }
                
        static void Main(string[] args)
        {
          
            while (true)
            {
                error = false;
                Console.WriteLine("Fraction Calculator: \n Fraction must have next order: IntPart Numerator/Denumerator\n Negative fractions are not allowed to enter.\n");

                Console.WriteLine("\nPlease enter 1-st fraction:  ");
                Fraction frac1 = StrToFrac(Console.ReadLine());
                 

                Console.WriteLine("\nPlease enter 2-nd fraction:  ");
                Fraction frac2 = StrToFrac(Console.ReadLine());

                // Checks for the zero denumerators.
                if (error) 
                {
                    Console.WriteLine("Your entry has mistakes");
                    Console.Clear();
                    return;
                }

                Fraction resFrac = new Fraction();

                Console.WriteLine("Choose any operation in: + - * /  ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Add:
                        resFrac.Sum(frac1, frac2);
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
                    default: Console.Clear(); continue;
                        break;
                }
                Console.WriteLine("\n\nYour result: {0}", resFrac);

                Console.WriteLine("\nPress any key to try again. \nFor exit press q... ");
                if (Console.ReadKey().Key == ConsoleKey.Q) return;
                Console.Clear();
            }
        }
    }
}
