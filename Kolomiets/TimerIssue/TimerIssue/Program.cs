using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(1000);
            t.Start();
            
            t.Elapsed += OnTimer;
            t.Enabled = true;

            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        private static void OnTimer(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("DATE: "+Environment.TickCount);
        }
    }
}
