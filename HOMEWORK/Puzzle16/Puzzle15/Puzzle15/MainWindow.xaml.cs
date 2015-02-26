using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Puzzle15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int btnSize;
        int move = 0;
        Button space;
        Button target;
        Game g = new Game();
        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            Init();
            dt.Interval = TimeSpan.FromMilliseconds(1000/speedSlider.Value); 
            dt.Tick += Run;
            
                
        }

        public void Init() 
        {
            move = 0;
            field.Children.Clear();
            btnSize = g.btnSize;
            foreach (var item in g.table)
            {
                Button b = new Button();
                b.Click += b_Click;
                b.Height = b.Width = btnSize;
                b.Content = item.Value;
                b.Margin = new Thickness(item.Key.X,item.Key.Y,0,0);
                if (b.Content.ToString() == "0") {b.Opacity = 0; space = b;}
                field.Children.Add(b);
            }
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            if (!dt.IsEnabled)
            {
                target = sender as Button;
                Swap();
                if (g.Win()) MessageBox.Show("You win!", "Congrats!");
            }
        }

        void Swap() 
        {   
            //logical
            g.space = new Point(space.Margin.Left, space.Margin.Top);
            g.target = new Point(target.Margin.Left, target.Margin.Top);
            if (g.Swap()) 
            {
            // visual
            Thickness s = target.Margin;
            target.Margin = space.Margin;
            space.Margin = s;

            move++;
            window.Title = "Puzzle15 MOVE: " + move;
            }
           
            
        }

        private void Run(object sender, EventArgs e)
        {
            g.Rotation();
            spaceL.Content = "SPACE: " + g.space;
            targetL.Content = "TARGET: " + g.target;
            goalL.Content = "GOAL: " + g.goal;

            Button b = new Button();
            foreach (var item in field.Children)
            {
                b = item as Button;
                if (b.Margin.Left == g.target.X && b.Margin.Top == g.target.Y) break;
            }
            target = b;


            Swap();


            if (g.Win())
            {
                dt.Stop();
                MessageBox.Show("TOAL MOVES: "+ move, "Puzzle complete!");
                g = new Game();
                Init();
                nextBtn.Content = "START";
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
            if (dt.IsEnabled)
            {
                dt.Stop();
                nxtBtn.IsEnabled = true;
                nextBtn.Content = "START";            
            }
            else 
            {
                dt.Start();
                nxtBtn.IsEnabled = false;
                nextBtn.Content = "STOP"; 
            }
        }

        private void speedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dt.Interval = TimeSpan.FromMilliseconds(1000 / speedSlider.Value);
        }

    
       
    }
}
