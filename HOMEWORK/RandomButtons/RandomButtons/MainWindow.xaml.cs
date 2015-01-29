using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RandomButtons
{

   
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer round = new DispatcherTimer();
        List<GameButton> btnList = new List<GameButton>();
        Random r = new Random();
        int lives = 3;
        int Score = 1;
        int count = 10;
        long interval = 500000;
        double speed = 5;


        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += ChangePosition;
            round.Tick += RunProgress;
            Game();
        }

        void ChangePosition(object sender, EventArgs e)
        {
           
         
            foreach (GameButton b in btnList)
                {
                Thickness t = b.Margin;
               
                if (t.Left < -150 ) b.Track = (b.Track == Direction.UpLeft) ? Direction.UpRight : Direction.DownRight;
                if (t.Top < -125) b.Track = (b.Track == Direction.UpLeft) ? Direction.DownLeft : Direction.DownRight;
                if (t.Left > 200) b.Track = (b.Track == Direction.DownRight) ? Direction.DownLeft : Direction.UpLeft;
                if (t.Top > 125) b.Track = (b.Track == Direction.DownRight) ? Direction.UpRight : Direction.UpLeft;
                switch (b.Track)
                {
                    case Direction.UpLeft: t.Left--; t.Top--;
                        break;
                    case Direction.UpRight:t.Left++; t.Top--;
                        break;
                    case Direction.DownLeft:t.Left--; t.Top++;
                        break;
                    case Direction.DownRight:t.Left++; t.Top++;
                        break;
                }
                b.Margin = t;
            }
            
        }

        private void Game() 
        {
            for (int i = count; i >= 1; i--)
            {
                this.CreateBtn(i);
            }
            ProgBar.Maximum = count*2;
            ProgBar.Minimum = 0;
            ProgBar.Value = 0;


            dt.Interval = new TimeSpan(0,0,0,0,1);
            round.Interval = new TimeSpan(0, 0, 1);
            

            dt.Start();
            round.Start();
        }

        void RunProgress(object sender, EventArgs e)
        {
            if (ProgBar.Value == ProgBar.Maximum && btnList.Count != 0)
            {
                MessageBox.Show("You lose!");
                Reset();
                speed = 25;
                Game();
            }
            if (ProgBar.Value != ProgBar.Maximum && btnList.Count == 0)
            {
                MessageBox.Show("You win!");
                Reset();
                speed += 5;
                Game();
            }
            ProgBar.Value++;
            
        }

        public void Reset() 
        {
            dt.Stop();
            round.Stop();
            ProgBar.Value = 0;
            Score = 1;
            foreach (var item in btnList)
            {
                MyGrid.Children.Remove(item);
            }
            btnList.Clear();
            
        }
       

        

        public void CreateBtn(int current) 
        {
            GameButton b = new GameButton();
            b.Height = 30;
            b.Width = 30;
            b.Content = current;
            b.Track = Direction.DownLeft;
            b.Tag = current;
            b.Click += b_Click;
            b.MouseMove += (o, e) =>
            {
                switch (r.Next(3))
                {
                    case 0: b.Track = Direction.DownLeft;
                        break;
                    case 1: b.Track = Direction.DownRight;
                        break;
                    case 2: b.Track = Direction.UpLeft;
                        break;
                    case 3: b.Track = Direction.UpRight;
                        break;
                }
            };
            b.Margin = this.RandomLocation();
            btnList.Add(b);
            MyGrid.Children.Add(b);
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            GameButton b = sender as GameButton;
            if ((int)b.Tag == Score)
            {
                MyGrid.Children.Remove(b);
                btnList.Remove(b);
                Score++;
            }
            else lives--;
        }

        public Thickness RandomLocation()
        {
            Thickness t = new Thickness();

                t.Left = r.Next(-100,100);
                t.Top = r.Next(-100, 100);
                t.Right = r.Next(-100,100);
                t.Bottom = r.Next(-100,100);

                //foreach (GameButton b in btnList)
                //{
                //    if (Math.Abs(b.Margin.Left - t.Left) <= 10 || Math.Abs(b.Margin.Top - t.Top) <= 10)
                //    {
                //        equal = true;
                //    }
                //}     
          
            return t;
        }

       
    }
}
