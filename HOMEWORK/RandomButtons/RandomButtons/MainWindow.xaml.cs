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
        List<object> ConMenu = new List<object>();
        Random r = new Random();
        Slider s1;
        Slider s2;
        Slider s3;
        int level = 1;
        int num = 1;
        int count=10;
        int score = 0;
        int interval = 10;
        int roundTime=20;
        double levelSpeed = 1;
        double btnSize = 40;

        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += ChangePosition;
            
            round.Tick += RunProgress;
            s1 = new Slider { Width =60,Minimum = 10, Maximum = 60, SmallChange = 1, Value = count};
            s2 = new Slider {  Width = 60, Minimum = 10, Maximum = count*2, SmallChange = 1 ,Value = roundTime};
            s3 = new Slider {  Width = 60, Minimum = 0, Maximum = 3, LargeChange = 0.25 ,Value = levelSpeed};
            Label l1 = new Label { Content = string.Format("Count: {0:##}",count)};
            Label l2 = new Label { Content = string.Format("Round: {0:##}", roundTime) };
            Label l3 = new Label { Content = "Speed: " };
            
            ConMenu.Add(l1);
            ConMenu.Add(s1);
            ConMenu.Add(l2);
            ConMenu.Add(s2);
            ConMenu.Add(l3);
            ConMenu.Add(s3);

            ContextMenu.ItemsSource = ConMenu;
            s1.ValueChanged += (o, e) => { count = (int)e.NewValue; l1.Content = string.Format("Count: {0}", count); s2.Maximum = 2 * count; };
            s2.ValueChanged += (o, e) => { roundTime = (int)e.NewValue; l2.Content = string.Format("Round: {0}", roundTime); };
            s3.ValueChanged += (o, e) => { levelSpeed = (int)e.NewValue; };
            ContextMenu.Closed += (o, e) =>
            {
                Reset();
                btnSize = 40;
                score = 0;
                level = 1; 
                Game();
            };
            ContextMenu.Opened += (o, e) => { round.Stop(); };

            Game();
        }
     

        void ChangePosition(object sender, EventArgs e)
        {

            foreach (GameButton b in btnList)
                {
                Thickness t = b.Margin;

                if (t.Left <= 10) 
                {
                   
                b.Track = (b.Track == Direction.UpLeft) ? Direction.UpRight : Direction.DownRight;
                b.Bound = true;
                }
                if (t.Top <= 10)
                    
                { b.Track = (b.Track == Direction.UpLeft) ? Direction.DownLeft : Direction.DownRight;
                b.Bound = true;
                }
                if (t.Left >= MyGrid.RenderSize.Width-b.Height)
                   
                { b.Track = (b.Track == Direction.DownRight) ? Direction.DownLeft : Direction.UpLeft;
                b.Bound = true;
                }
                if (t.Top >= MyGrid.RenderSize.Height-b.Height)
                  
                { b.Track = (b.Track == Direction.DownRight) ? Direction.UpRight : Direction.UpLeft;
                b.Bound = true;
                }
                switch (b.Track)
                {
                    case Direction.UpLeft: t.Left -=levelSpeed; t.Top-=levelSpeed;
                        break;
                    case Direction.UpRight:t.Left+=levelSpeed; t.Top-=levelSpeed;
                        break;
                    case Direction.DownLeft:t.Left-=levelSpeed; t.Top+=levelSpeed;
                        break;
                    case Direction.DownRight:t.Left+=levelSpeed; t.Top+=levelSpeed;
                        break;
                }
                if (b.Bound)
                {
                    b.Speed -= 0.005;
                    if (b.Track == Direction.DownLeft||b.Track == Direction.DownRight)
                    b.Angle += 2 * b.Speed;
                    else
                    b.Angle -= 2 * b.Speed;
                    if (b.Speed <=0) { b.Bound = false; b.Speed = levelSpeed; }
                    b.Rotate(b.Angle, b.RenderTransformOrigin.X + btnSize / 2, b.RenderTransformOrigin.Y + btnSize / 2);
                }

                b.Margin = t;
            }
            
        }

        private void Game() 
        {
            for (int i = (int)count; i >= 1; i--)
            {
                GameButton b = new GameButton(i,btnSize,levelSpeed);
                b.Click += b_Click;
                b.GotFocus += (o,e) =>
                {
                    GameButton but = o as GameButton;
                    switch (r.Next(3))
                    {
                        case 0: but.Track = Direction.DownLeft;
                            break;
                        case 1: but.Track = Direction.DownRight;
                            break;
                        case 2: but.Track = Direction.UpLeft;
                            break;
                        case 3: but.Track = Direction.UpRight;
                            break;
                    }
                };
                b.Margin = this.RandomLocation();
                b.TabIndex = i;
                btnList.Add(b);
                MyGrid.Children.Add(b);
            }
            dt.Interval = TimeSpan.FromMilliseconds(interval);
            round.Interval = TimeSpan.FromSeconds(1);
            ProgBar.Value = 0;
            ProgBar.Maximum = roundTime+1;
            ProgBar.Minimum = 0;
            Score.Content = "SCORE: " + score;
            Level.Content = "LEVEL: " + level;
            round.Start();
            dt.Start();
            
        }

        void RunProgress(object sender, EventArgs e)
        {
            if (ProgBar.Value == ProgBar.Maximum && btnList.Count != 0)
            {
                MessageBox.Show("You lose!");
                Reset();
                btnSize = 40;
                score = 0;
                level = 1;
                Game();
               
            }
            if (btnList.Count == 0)
            {
                level++;
                
                Reset();
                if (btnSize > 20) { btnSize -= 4; Game(); }
                else
                {
                    MessageBox.Show("Game by NET14/2...Thank you!");
                    Close();
                }
            }
            ProgBar.Value++;

            TimeInd.Content = roundTime;
            roundTime--;
            
        }        

        public void Reset() 
        {
            round.Stop();
            dt.Stop();
            TimeInd.Content = "";
            ProgBar.Value = 0;
            roundTime = (int)s2.Value;
            num = 1;
            levelSpeed = s3.Value;

            foreach (var item in btnList)
            {
                MyGrid.Children.Remove(item);
            }
            btnList.Clear();
            
        }

        void b_Click(object sender, EventArgs e)
        {
            GameButton b = sender as GameButton;
            if ((int)b.Tag == num)
            {
                MyGrid.Children.Remove(b);
                btnList.Remove(b);
                if (levelSpeed !=0 )levelSpeed += 0.1;
                score += (levelSpeed == 0) ? 1 : (int)(level + s3.Value);
                Score.Content = "SCORE: " + score;
                Level.Content = "LEVEL: " + level;
                num++;
            }
            MyGrid.Focus();
        }

        public Thickness RandomLocation()
        {
            Thickness t = new Thickness();

            if (MyGrid.RenderSize.Width != 0)
            {
                t.Left = r.Next((int)(MyGrid.RenderSize.Width-btnSize));
                t.Top = r.Next((int)(MyGrid.RenderSize.Height-btnSize));
            }
            else 
            {
                t.Left = r.Next((int)(300-btnSize));
                t.Top = r.Next((int)(180-btnSize));
            }
                t.Right = 0;
                t.Bottom = 0;

            return t;
        }

        private void MainWindow1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.Height < 300 || this.Width < 400)
            {
                this.Height = 300;
                this.Width = 400;
            }

        }

       
 
    }
}
