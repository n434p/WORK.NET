using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionsCalc
{
    class Fraction
    {
        public Fraction(int num = 0, int denum = 1, int intPart = 0)
        {
            Num = num;
            Denum = denum;
            IntPart = intPart;
        }

        public int Num { get; private set; }

        public int Denum { get; private set; }

        public int IntPart { get; private set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true; 
            Fraction frac = new Fraction();
            frac = (Fraction)obj;
            return ((this - frac).Num == 0);
        }

        public static bool operator ==(Fraction frac1, Fraction frac2)
        {
            return (frac1.Equals(frac2));
        }

        public static bool operator !=(Fraction frac1, Fraction frac2)
        {

            return !(frac1 == frac2);
        }

        public static bool operator <(Fraction frac1, Fraction frac2) 
        {
            Fraction frac = frac1 - frac2;
            if (frac.Num < 0) return true;
            return false;
        }

        public static bool operator >(Fraction frac1, Fraction frac2)
        {
            Fraction frac = frac1 - frac2;
            if (frac.Num > 0) return true;
            return false;
        }

        public static bool operator >=(Fraction frac1, Fraction frac2) 
        {
            return (frac1 > frac2 || frac1 == frac2);
        }

        public static bool operator <=(Fraction frac1, Fraction frac2)
        {
            return (frac1 < frac2 || frac1 == frac2);
        }

        public override int GetHashCode()
        {
            return Num ^ Denum ^ IntPart;
        }
               
        public static Fraction operator +(Fraction frac1, Fraction frac2)
        {
            Fraction frac = new Fraction();
            frac.Num = frac1.Num * frac2.Denum + frac2.Num * frac1.Denum;
            frac.Denum = frac1.Denum * frac2.Denum;
            return frac;
        }

        public static Fraction operator -(Fraction frac1, Fraction frac2)
        {
            Fraction frac = new Fraction();
            frac.Num = frac1.Num * frac2.Denum - frac2.Num * frac1.Denum;
            frac.Denum = frac1.Denum * frac2.Denum;
            return frac;
        }

        public static Fraction operator *(Fraction frac1, Fraction frac2)
        {
            Fraction frac = new Fraction();
            frac.Num = frac1.Num * frac2.Num;
            frac.Denum = frac1.Denum * frac2.Denum;
            return frac;
        }

        public static Fraction operator /(Fraction frac1, Fraction frac2)
        {
            Fraction frac = new Fraction();
            frac.Num = frac1.Num * frac2.Denum;
            frac.Denum = frac1.Denum * frac2.Num;
            return frac;
        }

        /// <summary>
        /// Returns fraction into proper form.
        /// </summary>
        /// <param name="frac"></param>
        /// <returns></returns>
        public static Fraction operator !(Fraction frac)
        {
            // The biggest delimeter for the both elements (numerator and denumerator) is a result of count down cycle.
            // it avoids from another/next division.
            int sign = (frac.Num < 0 || frac.IntPart < 0) ? -1 : 1;
            frac.Num *= sign;
            frac.IntPart *= sign;

            if (frac.IntPart != 0)
            {
                frac.Num += frac.Denum * frac.IntPart;
                frac.IntPart = 0;
            }

            int param = frac.Num > frac.Denum ? frac.Denum : frac.Num;
            for (int i = param; i > 1; i--)
            {
                if (frac.Num % i == 0 && frac.Denum % i == 0)
                {
                    frac.Num /= i;
                    frac.Denum /= i;
                }
            }
            // transforms in proper fraction form.
            if (frac.Num >= frac.Denum)
            {
                frac.IntPart = frac.Num / frac.Denum;
                frac.Num -= frac.IntPart * frac.Denum;
            }
            frac.Num *= sign;
            frac.IntPart *= sign;

            return frac;
        }

        /// <summary>
        /// Converts string into improper fraction
        /// </summary>
        /// <param name="strFrac"></param>
        /// <returns></returns>
        public Fraction StrToFrac(string strFrac)
        {
            Fraction resFrac = new Fraction();
            try
            {

                List<string> frac = strFrac.Split(' ', '/').ToList();
                switch (frac.Count)
                {
                    case 1:
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
                if ((resFrac.Num < 0 && resFrac.IntPart != 0) || resFrac.Denum < 0) throw new Exception();
            }
            catch
            {
                Console.WriteLine("Wrong fraction!");
                Program.error = true;
            }

            if (resFrac.IntPart < 0) resFrac.Num *= -1;
            resFrac.Num += resFrac.Denum * resFrac.IntPart;
            resFrac.IntPart = 0;

            return resFrac;
        }

        public override string ToString()
        {
            // displays result for each case(only integer part, without integer part, whole fraction) of fraction.
            if (Num == 0) return (IntPart).ToString();
            else if (IntPart == 0) return string.Format("{0}/{1}", Num , Denum);
            else return string.Format("{0} {1}/{2}", IntPart, (Num <0)?-Num:Num, Denum);
        }


    }
}
