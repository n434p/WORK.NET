using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FractionsCalc
{    
    
    class Program
    {
        public static bool error = false;

        public static void BoolOperations(Fraction frac1, Fraction frac2)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (frac1 == frac2) Console.WriteLine("Entered fractions are equals");
            if (frac1 != frac2) Console.WriteLine("Entered fractions are NOT equals");
            if (frac1 >= frac2) Console.WriteLine("First fraction is bigger or equals than second");
            if (frac1 <= frac2) Console.WriteLine("First fraction is smaller or equals than second");
            if (frac1 > frac2) Console.WriteLine("First fraction is bigger than second");
            if (frac1 < frac2) Console.WriteLine("First fraction is smaller than second");
            Console.ResetColor();
        }

        public static void Menu() 
        {
            ConsoleKey[] actions = { ConsoleKey.Add, ConsoleKey.Multiply, ConsoleKey.Divide, ConsoleKey.Subtract };
            while (true)
            {
                Console.Clear();
                error = false;
                Console.WriteLine("Fraction Calculator: \n Fraction must have next order: [IntPart] Numerator/Denumerator\n");

                Console.WriteLine("\nPlease enter 1-st fraction:  \n");
                Fraction frac1 = new Fraction().StrToFrac(Console.ReadLine());
                
                if (error) continue;

                Console.WriteLine("\nChoose any operation in: + - * /  \n");
                ConsoleKeyInfo operation = Console.ReadKey();

                if (!actions.Contains(operation.Key)) continue;

                Console.WriteLine("\nPlease enter 2-nd fraction:  \n");
                Fraction frac2 = new Fraction().StrToFrac(Console.ReadLine());

                if (error) continue;

                BoolOperations(frac1, frac2);

                Fraction resFrac = new Fraction();

                switch (operation.Key)
                {
                    case ConsoleKey.Add:
                        resFrac = frac1 + frac2;
                        break;
                    case ConsoleKey.Divide:
                        resFrac = frac1 / frac2;
                        break;
                    case ConsoleKey.Multiply:
                        resFrac = frac1 * frac2;
                        break;
                    case ConsoleKey.Subtract:
                        resFrac = frac1 - frac2;
                        break;
                }
                Console.WriteLine("\n\nYour result: {0}", !resFrac);

                Console.WriteLine("\nPress any key to try again. \nFor exit press q... ");
                if (Console.ReadKey().Key == ConsoleKey.Q) return;
                Console.Clear();
            }
        }
                
        static void Main(string[] args)
        {
            Menu();
            
    
        }
    }
}
