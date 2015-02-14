using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsProj
{
    public delegate void TickEventHandler(object sendfer, TickArgs args);

    public class TickArgs: EventArgs
    {
        public int Tick {get;set;}

    }

    public class SecondTicker
    {
        Ticker t;
        public SecondTicker(Ticker ticker)
        {
            // init t - ticker
            this.t = ticker;
            // дополняем в т еще одну подписку на другой обработчик
            t.TickEvent += ticker_a;
           
        }
        void ticker_a(object sender, TickArgs args)
        {
            Console.WriteLine("Class \"SecondTicker\"\t Current tick: {0} \tTime :{1}", args.Tick, DateTime.Now.TimeOfDay);
        }
    }
    
    public class Ticker 
    {
        // Вспомогательное поле для останова
        // int count = 0;
        public string Name { get; set; }
        public event TickEventHandler TickEvent;
        public bool IsEnabled { get; set; }
        int ticks = 0;
        public int Delay { get; set; }
        
        public void RunTicker() 
        {
            while (IsEnabled && TickEvent != null)
            {
                this.ticks++;
                //вызов события для экземпляра данного класса
                //вызов события запустит все обработчики на который есть подпись
                TickEvent(this, new TickArgs(){ Tick = this.ticks});
                // Thread.Sleep() - определяет ТЕКУЩИЙ! поток и замедляет его
                Thread.Sleep(Delay);

                // Stop ticker
                //count++;
                //if (count == 100) IsEnabled = false;
            }
        }
    }

    class Program
    {
        // по завершению тела мэйн(длительность 150мс). 
        //Начнет запускаться второй поток( по 10мс) - 15 раз
        static void Main(string[] args)
        {
            #region CLASS
            //Ticker t = new Ticker() { IsEnabled = false };
            //t.TickEvent += t_TickEvent;

            //SecondTicker st = new SecondTicker(t);
            //t.IsEnabled = true;
            //// Работа двух потоков

            ////создаем новый поток(параллельный) и запускаем в нем тикер 
            ////По завершению метода поток уничтожается
            //Thread thr = new Thread(new ThreadStart(t.RunTicker));
            //thr.Start();

            
            ////останавливаем основной поток
            //Thread.Sleep(150);
            //// после 150 мс останоновится поток. 
            ////За 150 мс новый пток проработает 15 раз
            //t.IsEnabled = false;
            #endregion

            Ticker t1 = new Ticker() { Name="First", IsEnabled= false, Delay =500 };
            Ticker t2 = new Ticker() { Name="Second", IsEnabled = false, Delay =1000 };
            t1.TickEvent += t_TickEvent;
            t2.TickEvent += t_TickEvent;
            t1.IsEnabled = true;
            t2.IsEnabled = true;

            Thread th1 = new Thread(new ThreadStart(t1.RunTicker));
            Thread th2 = new Thread(new ThreadStart(t2.RunTicker));

            th1.Name = "1";
            th2.Name = "2";
            

            th1.Start();
            th2.Start();


        }

        static void t_TickEvent(object sender, TickArgs args)
        {
            Ticker t = sender as Ticker;
            // Сработал обработчик описанный в классе Program
            //Console.WriteLine("Class \"Program     \"\t Current tick: {0} \tTime: {1}", args.Tick,DateTime.Now.TimeOfDay );
            Console.WriteLine("{0}\t {1}\t {2}\t{3}", t.Name,Thread.CurrentThread.Name,args.Tick,DateTime.Now.TimeOfDay);
            if (args.Tick == 10) t.IsEnabled = false;
        }
    }
}
