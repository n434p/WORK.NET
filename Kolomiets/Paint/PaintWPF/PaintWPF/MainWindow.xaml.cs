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

namespace PaintWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Line l;
        bool flag = false;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs er)
        {
            Button bt = (Button)sender;
            string text = bt.Content.ToString();
            if (text == "Линия")
            {
                Line l1 = new Line() ;
                l1.StrokeThickness = 12;
                l1.Stroke = Brushes.Blue;
                l1.X1 = myCanvas.Margin.Left + 50;
                l1.Y1 = myCanvas.Margin.Top + 50;
                l1.X2 = myCanvas.Margin.Left + 100;
                l1.Y2 = myCanvas.Margin.Top + 100;
                l1.MouseDown+=l1_MouseDown;
                myCanvas.Children.Add(l1);
                Ellipse e1 = new Ellipse();
                e1.Stroke = Brushes.Brown;
                e1.Fill = Brushes.Brown;
                e1.Width = 13;
                e1.Height = 13;
                e1.Margin = new Thickness(l1.X1-5, l1.Y1-5, 0, 0);
                Ellipse e2 = new Ellipse();
                e2.Stroke = Brushes.Brown;
                e2.Fill = Brushes.Brown;
                e2.Width = 13;
                e2.Height = 13;
                e2.Margin = new Thickness(l1.X2-5, l1.Y2-5, 0, 0);
                e2.MouseDown += e2_MouseDown;
                myCanvas.Children.Add(e1);
                myCanvas.Children.Add(e2);

            }
            else 
            {
                if (text == "Эллипс")
                {
                    Ellipse e = new Ellipse();
                    e.Stroke = Brushes.Brown;
                    e.Fill = Brushes.CadetBlue;
                    e.StrokeThickness = 5;
                    e.Width = 100;
                    e.Height = 100;
                    e.Margin = new Thickness(200, 200, 100, 100);
                    myCanvas.Children.Add(e);
                }
                else
                {
                    Polygon p = new Polygon();
                    p.Points = new PointCollection(new List<Point>(){new Point(){X=150,Y=150},new Point(){X=200,Y=200},new Point(){X=150,Y=200}});
                    p.Stroke = Brushes.Coral;
                    p.StrokeThickness = 3;
                    myCanvas.Children.Add(p);
 
                }
            }
        }

        void e2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("point 2");
        }

       
           

        void l1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Line l2 = (Line)sender;

            myCanvas.Children.Remove(l2);   
            
        }

        

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas c = e.Source as Canvas;
            if (c != null)
            {
                l = new Line();
                l.StrokeThickness = 2;
                l.Stroke = Brushes.Blue;
                Point p = Mouse.GetPosition(myCanvas);
                l.X1 = p.X;
                l.Y1 = p.Y;
                myCanvas.Children.Add(l);
            }
            
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (l != null)
            {
                Point p = Mouse.GetPosition(myCanvas);
                l.X2 = p.X;
                l.Y2 = p.Y;
            }
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
           
            l = null;
        }

       
    }
}
