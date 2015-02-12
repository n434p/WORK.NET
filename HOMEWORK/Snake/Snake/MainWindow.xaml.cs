using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region INIT
        DispatcherTimer t = new DispatcherTimer();
        DispatcherTimer tc = new DispatcherTimer();
        List<Part> snake = new List<Part>();
        Label l = new Label();
        Part snakeHead;
        Part apple;
        Input input = new Input();
        string info;
        int score;
        int butSize;
        int time;
        float f;
        Direction Trace = Direction.right;
        Random r = new Random();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            t.Tick += Process;
            tc.Tick += OnControl;
            
            tc.Interval = TimeSpan.FromMilliseconds(50);
            canvas.Background = new ImageBrush() { 
                ImageSource = new BitmapImage((new Uri(@"..\..\Image\background.jpg", UriKind.Relative))) };
            Start();
            
        }
        public void Start()
        {
            f = 2f;
            t.Interval = TimeSpan.FromMilliseconds(500/f);
            butSize = 20;
            score = 0;
            snake.Clear();
            snakeHead = new Part(butSize * 2, butSize * 2, Parts.snakeHead, butSize);
            snake.Add(snakeHead);
            foreach (var item in snake)
            {
                canvas.Children.Add(item);
            }
            apple = new Part(0, 0,Parts.apple,butSize);
            canvas.Children.Add(apple);
            
            t.Start();
            tc.Start();
            GenApple();
            canvas.Children.Add(l);
        }
        public void GenApple() 
        {
            int a = (int)canvas.RenderSize.Width / butSize;
            int b = (int)canvas.RenderSize.Height / butSize;
            apple.X = r.Next(a)*butSize;
            Thread.Sleep(20);
            apple.Y = r.Next(b) * butSize;
        }
        void OnControl(object sender, EventArgs e)
        {
            bool body = false;
            if (snake.Count > 1) body = true;
            // Get direction for the snake's head
            if (input.Press(Key.Left))
            { if (!body || snakeHead.Move != Direction.right) Trace = Direction.left; }
            if (input.Press(Key.Up))
            { if (!body || snakeHead.Move != Direction.down) Trace = Direction.up; }
            if (input.Press(Key.Right))
            { if (!body || snakeHead.Move != Direction.left) Trace = Direction.right; }
            if (input.Press(Key.Down))
            { if (!body || snakeHead.Move != Direction.up) Trace = Direction.down; }
        }
        public void Process(object sender, EventArgs e)
        {

            l.Content = "Score: " + score;
            l.FontSize = 20;
            l.Foreground = Brushes.White;

            // Set direction for each part of snake's body
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].Move = snake[i - 1].Move;  
            }
            snakeHead.Move = Trace;
            // Check for eat apple. Grow snake's body
            if (snakeHead.X == apple.X && snakeHead.Y == apple.Y)
            {
                Part n = new Part(snake[snake.Count - 1].X, snake[snake.Count - 1].Y, Parts.snakeBody,butSize);
                n.Move = Direction.stop;
                score++;
                l.Content = "Score: " + score;
                if (500 / f > 75)
                {
                    t.Interval = TimeSpan.FromMilliseconds(500 / (f));
                    f += 0.5f;
                }
                GenApple();
                snake.Add(n);
                canvas.Children.Add(n);
            }

            //Redraw snake
            foreach (var item in snake)
            {
                switch (item.Move)
                {
                    case Direction.left: item.X -= butSize;
                        break;
                    case Direction.up: item.Y -= butSize;
                        break;
                    case Direction.right: item.X += butSize;
                        break;
                    case Direction.down: item.Y += butSize;
                        break;
                }

            }
            // Body eat issue
            if (snake.Count > 3)
            {
                for (int i = 3; i < snake.Count; i++)
                {
                    if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y && snake[i].Move != Direction.stop) { t.Stop(); info = "Snake bits her body!"; Reset(); }

                }
            }
            //Out of borders
           if (snake.Count >0)
           if (snake[0].X < 0 || snake[0].X > canvas.RenderSize.Width || snake[0].Y < 0 || snake[0].Y > canvas.RenderSize.Height)
           { t.Stop(); info = "Snake leaves garden!"; Reset(); }
        }
        public void Reset()
        {
            canvas.Children.Clear();
            input.ControlKey.Clear();
            snake.Clear();
            t.Stop();
            tc.Stop();
            Trace = Direction.right;
            if (MessageBox.Show(info+"\nYour score: "+score+"\nDo you want to start again?", "Game over!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) Start();
            else Close();
  
        }

        #region EVENTS
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            input.State(e.Key, true);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            input.State(e.Key, false);
        }
        #endregion
    }
}
