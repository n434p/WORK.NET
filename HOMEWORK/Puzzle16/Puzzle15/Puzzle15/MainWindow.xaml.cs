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
        Canvas puzzleField ;
        Slider speedReg ;
        Button runBtn ;
        /// <summary>
        /// Contains sequence of moves
        /// </summary>
        List<Point> queue = new List<Point>();
        int btnSize;
        /// <summary>
        /// Current move in solve sequence
        /// </summary>
        int move = 0;
        /// <summary>
        /// move + additional moves from user
        /// </summary>
        int total = 0;
        Button space;
        Button target;
        /// <summary>
        /// Location of target place
        /// </summary>
        Thickness moveGoal;
        /// <summary>
        /// Keeps base(first) timer status
        /// </summary>
        bool ticking;
        /// <summary>
        ///  Initial array of cells
        /// </summary>
        byte[] mas = new byte[16];      
        /// <summary>
        /// Base(first) timer - Invoking Run() process
        /// </summary>
        DispatcherTimer dt1 = new DispatcherTimer();
        /// <summary>
        /// Optional(Second) timer - Invokes animation process while cells are swapped 
        /// </summary>
        DispatcherTimer dt2 = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            dt1.Tick += Run;
            dt2.Tick += (o, e) =>
            {
                if (target != null && space != null)
                {
                    Thickness t = target.Margin;
                    Thickness s = space.Margin;
                    if ((new Point(t.Left, t.Top) - new Point(s.Left, s.Top)).Length > 5)
                    {
                        if (s.Top > t.Top) t = new Thickness(t.Left, t.Top + speedReg.Value, 0, 0);
                        if (s.Top < t.Top) t = new Thickness(t.Left, t.Top - speedReg.Value, 0, 0);
                        if (s.Left > t.Left) t = new Thickness(t.Left + speedReg.Value, t.Top, 0, 0);
                        if (s.Left < t.Left) t = new Thickness(t.Left - speedReg.Value, t.Top, 0, 0);
                        target.Margin = t;

                    }
                    else
                    {
                        dt2.Stop();
                        target.Margin = space.Margin;
                        space.Margin = moveGoal;
                        if (ticking) dt1.Start();
                    }
                }
            };
        }


        /// <summary>
        /// Initiates new parameters and sequence for current array - mas[].
        /// </summary>
        public void Start() 
        {
            puzzleField.Children.Clear();
            space = null;
            target = null;

            dt1.Interval = TimeSpan.FromMilliseconds(500 / speedReg.Value);
            dt2.Interval = TimeSpan.FromMilliseconds(15 / speedReg.Value);

            move = 0;

            btnSize = g.btnSize;
            foreach (var item in g.table)
            {
                Button b = new Button();
                b.Click += (o, e) =>
                {
                    if (!dt1.IsEnabled && !dt2.IsEnabled)
                    {
                        target = o as Button;
                        if ((new Point(target.Margin.Left, target.Margin.Top) - new Point(space.Margin.Left, space.Margin.Top)).Length == btnSize)
                        {
                            Swap();
                            runBtn.IsEnabled = true;
                            // Checks main goal - if cells order is right 
                            bool notEq = false;
                            for (int i = 0; i < mas.Length; i++)
                            {
                                if (mas[i] != g.order[i]) notEq = true;   
                            }
                            if (!notEq) Restart(); 
                        }
                    }
                };
                b.Height = b.Width = btnSize;
                b.Content = item.Value;
                b.Margin = new Thickness(item.Key.X,item.Key.Y,0,0);
                if (b.Content.ToString() == "0") {b.Opacity = 0; space = b;}
                puzzleField.Children.Add(b);
            }

            queue = g.Process();
        }
        private void runBtn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (dt1.IsEnabled||ticking)
            {
                dt1.Stop();
                ticking = false;
                b.Content = "START";            
            }
            else
            {
                g = new Game(mas);
                total = move;
                move = 0;
                Start();
                dt1.Start();
                b.Content = "STOP"; 
            }
        }
        /// <summary>
        /// Swaps target and space button locations between each other
        /// </summary>
        void Swap() 
        {
            byte indT = 0; byte indS = 0; byte T = 0;
            for (byte i = 0; i < mas.Length; i++)
            {
                if (mas[i] == (byte)target.Content) indT = i;
                if (mas[i] == (byte)space.Content) indS = i;
            }
            T = mas[indT];
            mas[indT] = 0;
            mas[indS] = T;

            moveGoal = target.Margin;
            ticking=dt1.IsEnabled;

            dt1.Stop();
            dt2.Start();
            
            move++;
            window.Title = "Puzzle15 MOVE: " + (total + move);
        }
        private void Run(object sender, EventArgs e)
        {
            if (move < queue.Count)
            {
                Button b = new Button();
                foreach (var item in puzzleField.Children)
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
            if (ticking)
            MessageBox.Show("TOAL MOVES: " + (move+total) + "\n * overlaps: "+g.mistakes, "Puzzle complete!");
            else
            MessageBox.Show("TOAL MOVES: " + (move + total), "Puzzle complete!");
            ticking = false;
            runBtn.Content = "START";
            move = 0;
            total = 0;
            g = new Game(mas);
            Start();
            runBtn.IsEnabled = false;
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (!dt1.IsEnabled)
            {
                if (stackPnl.Children.Count > 1) stackPnl.Children.RemoveRange(1, stackPnl.Children.Count - 1);
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.InitialDirectory = Environment.CurrentDirectory;
                ofd.Filter = "(*.txt)|*.txt";
                ofd.ShowDialog();
                if (ofd.CheckFileExists && ofd.FileName != "")
                {
                    try
                    {
                        string str = "";
                        using (StreamReader sr = new StreamReader(ofd.FileName))
                        {
                            while (!sr.EndOfStream)
                            {
                                str += sr.ReadLine();
                            }
                            string[] lsd = str.Trim().Split(new char[] { ' ', ',' });

                            if (lsd.Length != 16) throw new Exception("Bad format of array");
                            Dictionary<byte, byte> test = new Dictionary<byte, byte>();
                            byte zero = 0;
                            for (byte i = 0; i < lsd.Length; i++)
                            {
                                mas[i] = Convert.ToByte(lsd[i]);
                                if (mas[i] >= 16 && mas[i] < 0) throw new Exception("Elements of array don't proper");
                                test[mas[i]] = mas[i];
                                if (test.Count != i + 1) throw new Exception("Some elements are the same in the array");
                                if (mas[i] == 0) zero = i;
                            }
                            byte sum = 0;
                            for (int i = 0; i < mas.Length - 1; i++)
                            {
                                byte n = 0;
                                for (int j = i + 1; j < mas.Length; j++)
                                {
                                    if (mas[j] != 0 && mas[j] < mas[i]) n++;
                                }
                                sum += n;
                            }
                            if ((sum + zero / 4 + 1) % 2 != 0) throw new Exception("Array doesn't have solution...");
                        }

                        g = new Game(mas);
                        g.IsIssue += IssueRecorder;

                        puzzleField = new Canvas()
                        {
                            Height = 160,
                            Width = 160,
                            Background = Brushes.BurlyWood,
                            Margin = new Thickness(20)
                        };
                        speedReg = new Slider()
                        {
                            Width = 160,
                            Minimum = 1,
                            Maximum = 6,
                            Value = 1,
                            SmallChange = 0.5
                        };
                        runBtn = new Button()
                        {
                            Margin = new Thickness(10),
                            Width = 160,
                            Height = 30,
                            Content = "START"
                        };

                        speedReg.ValueChanged += (o, ee) =>
                        {
                            dt1.Interval = TimeSpan.FromMilliseconds(500 / ee.NewValue);
                            dt2.Interval = TimeSpan.FromMilliseconds(15 / ee.NewValue);
                        };

                        runBtn.Click += runBtn_Click;

                        stackPnl.Children.Add(puzzleField);
                        stackPnl.Children.Add(speedReg);
                        stackPnl.Children.Add(runBtn);

                        Start();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("During load file...\n" + ex.Message, "Error");
                    }
                }
            }
        }

        private void IssueRecorder(object o, EventArgs e)
        {
            MessageBox.Show("We sorry for this situation. Browse another file.", "Bug Exception");
            using (FileStream sr = new FileStream("Issue-" + DateTime.Now.Millisecond + ".txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(sr, Encoding.UTF8);
                for (int i = 0; i < (mas.Length-1); i++)
                {
                    sw.Write(mas[i] + ",");
                }
                sw.Write(mas[mas.Length-1]);
                sw.Close();
            }
            loadBtn_Click(o,EventArgs.Empty);
            
        }
       
    }
}
