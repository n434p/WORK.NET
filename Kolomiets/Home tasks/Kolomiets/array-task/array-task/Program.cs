using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] arr = new int[r.Next(1, 10)];
            int temp = 0;

            Console.WriteLine("Random array:");

            for(int i=0; i< arr.Length; i++ )
            {
            arr[i]= r.Next(1,10);
            Console.Write(arr[i]+" ");
            }
            Console.WriteLine();

            for (int k = 0; k < arr.Length / 2; k++)
                {
                    temp = arr[2 * k];
                    arr[2 * k] = arr[2 * k + 1];
                    arr[2 * k + 1] = temp;
                 }

            Console.WriteLine("Modificated array:");
                             
              
            for(int k=0; k<arr.Length; k++)
            {
                Console.Write(arr[k]+" ");
            }
            Console.ReadKey();

        }
    }
}
