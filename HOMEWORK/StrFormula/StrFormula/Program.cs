using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrFormula
{
    class Program
    {
        static char[] validSigns = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '/', '*', '+', '-', '(', ')' };
        static char[] operations = { '/', '*', '+', '-' };

        /// <summary>
        /// Defines formula parts that have brackets. Calculates them and replaces with the result.
        /// </summary>
        /// <param name="numStr"></param>
        /// <returns></returns>
        public static string StrToFormula(string numStr)
        {
            int begBracket = 0, endBracket = 0;// initials placement of start & end bracket
            string currentStr = numStr;// sets current string to convertation
                       

            while (currentStr.Contains("(")) //while true it finds deepest bracket '(' in formula 
            {
                
                begBracket = currentStr.IndexOf('(');
                currentStr = currentStr.Substring(begBracket + 1, currentStr.Length - begBracket-1);
            
               
                if (!currentStr.Contains("("))
                {
                    endBracket = currentStr.IndexOf(')');
                    currentStr = currentStr.Remove(endBracket);
                    Console.ForegroundColor = ConsoleColor.DarkGray; 
                    Console.WriteLine("Current operation: "+currentStr);
                    // calculates expression into brackets and replaces it by result
                    currentStr = numStr.Replace(("(" + currentStr + ")"), CalcNoBrackets(currentStr));
                    numStr = currentStr;
                }
            }
        Console.ForegroundColor = ConsoleColor.Green;
        return CalcNoBrackets(numStr);
             
        }

        /// <summary>
        /// Calculates any expressions that contain defined operations (includes negative elements)
        /// </summary>
        /// <param name="numStr"></param>
        /// <returns></returns>
        public static string CalcNoBrackets(string numStr) 
        {
            numStr = numStr.Replace("*", "|*|");
            numStr = numStr.Replace("-", "|-|");
            numStr = numStr.Replace("+", "|+|");
            numStr = numStr.Replace("/", "|/|");

            List<string> formCode = numStr.Split('|').ToList();
            // Negative elements keep next order in List : "" "-" "element"
            // Solution: first element keeps negative element "-element".Second and third - removed.   
            while (formCode.Contains(""))
            {
                int negIndex = formCode.IndexOf("");
                formCode[negIndex] = formCode[negIndex + 1]+formCode[negIndex + 2];
                formCode.RemoveRange(negIndex + 1, 2); 
            }

            // Multiplication and divide have priority and work first.
            // Any operation replaces by result previous element and removes next two.
            
            int i = 0;
            while (i < formCode.Count)
            {
                switch (formCode[i])
                {   case "*":
                        formCode[i - 1] = Convert.ToString(Convert.ToDouble(formCode[i - 1]) * Convert.ToDouble(formCode[i + 1]));
                        formCode.RemoveRange(i, 2);
                        break;
                    case "/":
                        if (Convert.ToDouble(formCode[i + 1]) == 0) return "During calculation something divides by 0.";
                        formCode[i - 1] = Convert.ToString(Convert.ToDouble(formCode[i - 1]) / Convert.ToDouble(formCode[i + 1]));
                        formCode.RemoveRange(i, 2);
                        break;
                    default:
                        i++;
                        break;
                }
               
            }

            // operation as + and - goes one by one. 
            // By replacement expression will be shorter until first element will contain result.
                      
            while (formCode.Count >= 3) 
            {
                
                switch (formCode[1])
                {   case "+":
                        formCode[0] = Convert.ToString(Convert.ToDouble(formCode[0]) + Convert.ToDouble(formCode[2]));
                        formCode.RemoveRange(1, 2);
                        break;
                    case "-":
                        formCode[0] = Convert.ToString(Convert.ToDouble(formCode[0]) - Convert.ToDouble(formCode[2]));
                        formCode.RemoveRange(1, 2);
                        break;
                    default:
                        break;
                }

        
            }
            return Convert.ToString(formCode[0]);
        }

        /// <summary>
        /// Checks expression as formula.
        /// </summary>
        /// <param name="strCheck"></param>
        /// <returns></returns>
        public static bool StrValid(string strCheck)
        {
            strCheck = strCheck.Replace(" ", "");
            int countBracket = 0;
            /// not null.
            if (strCheck.Length == 0) return false;
            /// begins with '-' or number           
            if ((operations.Contains(strCheck[0]))&&(strCheck[0] != '-')) return false;
            /// last sign is operator.
            if ((operations.Contains(strCheck[strCheck.Length-1]))) return false;
            /// brackets placement and count.
            foreach (char item in strCheck)
            {
                switch (item)
                {
                    case '(': countBracket++; break;
                    case ')': countBracket--; break;
                    default: break;
                }
            }
            if ((countBracket != 0)||(strCheck.IndexOf('(') > strCheck.IndexOf('('))) return false;
            /// contains valid signs.     
            foreach (char item in strCheck)
            if (!validSigns.Contains(item)) return false;
            /// hasn't two operators.
            for (int i = 0; i < strCheck.Length-1; i++)
            {
                if ((strCheck[i] == strCheck[i + 1]) && (operations.Contains(strCheck[i])) && (strCheck[i] != '-')) return false;
                if (strCheck[i] == ')'&& (strCheck[i-1]=='('||operations.Contains(strCheck[i-1]))) return false;
            }
            return true;
        }

        /// <summary>
        /// Performs menu for the "String to formula" task.
        /// </summary>
        public static void Menu() 
        {

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine("Enter some string as formula  variation: \n You can use next operators:\n *, /, +, -, (, ) \n\n");
                string strExpression = Console.ReadLine();

                if (!StrValid(strExpression))
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("Your entry has mistakes! \n");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to try again...\n\n For quit press 'q'.");
                    if (Console.ReadKey().Key == ConsoleKey.Q) return;
                    Console.Clear();
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Green;                
                Console.WriteLine("\n Result: {0:F}", StrToFormula(strExpression));
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void Main(string[] args)
        {
            Menu();
   
        }
    }
}
