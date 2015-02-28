using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        Game g;
        List<Point> queue = new List<Point>();
        int btnSize;
        int move = 0;
        Button space;
        Button target;
        byte[] mas = new byte[16]; 
            /// {12,7,3,8,2,13,15,0,1,5,4,10,6,14,11,9}
            /// {3,2,4,7,1,11,6,5,13,0,9,12,10,15,8,14}
            /// {1,2,3,4,5,6,7,8,9,10,15,12,13,0,11,14} - issue bw (after move determinates block and returns)
            /// {5,7,3,10,4,8,6,2,0,1,14,11,9,12,15,13} - bw issue
            /// {1,2,3,4,5,6,7,8,9,0,11,15,14,10,13,12}
            /// {5,7,3,10,4,8,6,2,0,1,14,11,9,12,15,13}
            /// {7,1,15,6,10,9,5,4,13,2,0,3,14,8,12,11}
            /// {7,1,15,6,10,9,5,4,13,2,0,3,14,8,12,11}
            /// {14,9,6,12,13,1,15,7,4,0,10,11,5,3,2,8}
            /// {7,11,0,3,1,6,10,9,5,2,4,8,14,13,15,12}
        
        DispatcherTimer dt1 = new DispatcherTimer();
        DispatcherTimer dt2 = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            dt1.Tick += Run;
            dt2.Tick += (o, e) =>
            {

            };
        }

        public void Init() 
        {
            space = null;
            target = null;
            dt1.Interval = TimeSpan.FromMilliseconds(1000/speedSlider.Value);
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
            Game temp = new Game(mas);
            
            queue = temp.Process();
        }
        private void Button_Click(object sender, EventArgs e)
        { 
            if (dt1.IsEnabled)
            {
                dt1.Stop();
                nextBtn.Content = "START";            
            }
            else
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    Button b = field.Children[i] as Button;
                    mas[i] = (byte)b.Content;
                }
                
                g = new Game(mas);
                Init();
                dt1.Start();
                nextBtn.Content = "STOP"; 
            }
        }
        void b_Click(object sender, RoutedEventArgs e)
        {
            if (!dt1.IsEnabled)
            {
                target = sender as Button;
                Swap();
            }
        }
        void Swap() 
        {   
            //logical
            g.space = new Point(space.Margin.Left, space.Margin.Top);
            g.target = new Point(target.Margin.Left, target.Margin.Top);
            if (g.Swap()) 
            {
             //visual
            Thickness s = target.Margin;
            target.Margin = space.Margin;
            space.Margin = s;
            move++;
            window.Title = "Puzzle15 MOVE: " + move;
            } 
        }
        private void Run(object sender, EventArgs e)
        {
            if (move < queue.Count)
            {
                Button b = new Button();
                foreach (var item in field.Children)
                {
                    b = item as Button;
                    if (b.Margin.Left == queue[move].X && b.Margin.Top == queue[move].Y) break;
                }
                target = b;
                Swap();
            }
            else
            {
                Restart();
            }
        }
        public void Restart()
        {
            dt1.Stop();
            window.Title = "Puzzle15";
            MessageBox.Show("TOAL MOVES: " + move + "\n * overlaps: "+g.mistakes, "Puzzle complete!");
            g = new Game(mas);
            Init();
            nextBtn.Content = "START";
        }
        private void speedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dt1.Interval = TimeSpan.FromMilliseconds(1000 / speedSlider.Value);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!dt1.IsEnabled)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.InitialDirectory = Environment.CurrentDirectory;
                ofd.Filter = "(*.txt)|*.txt";
                ofd.ShowDialog();
                if (ofd.CheckFileExists && ofd.FileName != "")
                {
                    string str = "";
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            str += sr.ReadLine();
                        }
                        string[] lsd = str.Trim().Split(new char[] { ' ', ',', '-' });
                        try
                        {
                            for (int i = 0; i < lsd.Length; i++)
                            {
                                mas[i] = Convert.ToByte(lsd[i]);
                            }
                            g = new Game(mas);
                            Init();
                        }
                        catch
                        {
                            MessageBox.Show("Can't load file...", "Error");
                        }
                    }
                }
            }
        }

    
       
    }
}
