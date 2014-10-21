using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathString
{
    class Program
    {
        static  char [] operators ={'/','*','+','-'}; 
        static  char [] numbers ={'0','1','2','3','4','5','6','7','8','9'}; 


        public static void PerformFormula(string numStr) 
        {
            numStr = numStr.Replace(" ", "");
            //numStr = numStr.Replace("*", "|*|");
            //numStr = numStr.Replace("-", "|-|");
            //numStr = numStr.Replace("+", "|+|");
            //numStr = numStr.Replace("/", "|/|");
         
            List<string> formCode = numStr.Split('|').ToList();
            List<int> numCode = (int) numStr.Split(operators).ToList();
            List<string> numCode = numStr.Split(numbers).ToList();




           
            while (formCode.Count >= 3) 
            {
                if (formCode[1] == "*") 
                {
                    formCode[0] = Convert.ToString(Convert.ToInt32(formCode[0]) * Convert.ToInt32(formCode[2]));
                    formCode.RemoveRange(1, 2);
                    
                }
                if (formCode[1] == "/")
                {
                    formCode[0] = Convert.ToString(Convert.ToInt32(formCode[0]) / Convert.ToInt32(formCode[2]));
                    formCode.RemoveRange(1, 2);
                   
                }
                if (formCode[1] == "+")
                {
                    formCode[0] = Convert.ToString(Convert.ToInt32(formCode[0]) + Convert.ToInt32(formCode[2]));
                    formCode.RemoveRange(1, 2);
                   
                }
                if (formCode[1] == "-")
                {
                    formCode[0] = Convert.ToString(Convert.ToInt32(formCode[0]) - Convert.ToInt32(formCode[2]));
                    formCode.RemoveRange(1, 2);
                 
                }
        
            }
                        

            foreach (var item in formCode)
            {
                Console.WriteLine("Result: \n");
                Console.Write(item);
            }
       

        }

        public static void Method(string numStr)
        {
        
        }

        static void Main(string[] args)
        {
            PerformFormula("3+5*9-4");
            Console.ReadKey();
        }
    }
}
