using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checked_Example
{
    class Program
    {
        
        public static void BoxPost()
           {
               try
               {
                   Console.WriteLine("Enter box weight in [kg] to send: \n If box weight will be more than 255. You can't use our service for free.\n");
                   Console.WriteLine("Box with weight {0}[kg] will be send ASAP. ", Convert.ToByte(Console.ReadLine()));
               }
               catch
               {
                   Console.WriteLine("Your box weight is to much! Please pay extra money for sending.");
               }
            
            Console.ReadKey();
          }

        public static void LetterSend() 

            {
                try
                    {
                        Console.WriteLine("\n\n Write down letter to send: \n If letter lenght will be more than 25. You can't use our service for free.\n");

                        string str = Console.ReadLine();

                        if (str.Length  > 25) throw new Exception();
                        Console.WriteLine("Your Letter will be send ASAP.{0}", str.Length);

                    }
                    catch
                    {
                        Console.WriteLine("Your letter's length is to much! Please pay extra money for sending.");
                    }

                
                Console.ReadKey();
            }


        static void Main(string[] args)
        {
            // BoxPost();
            LetterSend();
        }
    }
}
