using System;

namespace NumMethods
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool flag = false;

            do
            {
                Console.WriteLine("Chose a task, please: ");
                Console.WriteLine("\n1) Mirrored number - Enter \"1\" ");
                Console.WriteLine("2) Simple number- Enter \"2\"  ");
                Console.WriteLine("3) Perfect numbers - Enter \"3\" ");
                Console.WriteLine("\nFor quit enter \"q\"");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        MirrorNum2();    

                        break;
                    case "2":
                        Console.Clear();
                        SimpleNum();

                        break;
                    case "3":
                        Console.Clear();
                        PerfectNum();
                        break;
                    case "q":
                        flag = true;
                        break;

                    default:
                        Console.Clear();
                        break;
                }



            } while (!flag);



        }

        static void MirrorNum1()
        {
            Console.Write("Enter number: ");
            string num = Console.ReadLine();
            for (int i = num.Length; i > 0; i--)
            {
                Console.Write(num[i - 1]);
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
            Console.Clear();
        }

        static void MirrorNum2()
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            for (; ;)
            {
                Console.Write(num % 10);
                num /= 10;
                if (num / 10 == 0)
                {
                    Console.Write(num);
                    break;
                }      
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
            Console.Clear();
        }

        static void SimpleNum()
        {
            string negAns = "Your number isn't simple. Sorry...";
            string posAns = "Your number is simple. Great!!!";
            int count = 0;
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                    count++;
            }
            Console.WriteLine((count > 2) ? negAns : posAns);
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
            Console.Clear();
        }

        static void PerfectNum()
        {
            int sum = 0;
            bool flag = false;
            string sorry = "There are not any perfect numbers. Sorry...";

            Console.WriteLine("Enter lower point: ");
            int low = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter upper point: ");
            int up = int.Parse(Console.ReadLine());

            for (int i = low; i < up; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                        sum += j;
                }
                if (i == sum)
                {
                    Console.WriteLine("Number {0} is perfect!", i);
                    flag = true;
                }
                sum = 0;
            }
            if (!flag)
                Console.WriteLine(sorry);
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
            Console.Clear();
        }
    
    }
}
