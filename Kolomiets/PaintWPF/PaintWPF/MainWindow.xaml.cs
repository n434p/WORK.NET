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
        Point p;
        Point start;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void field_MouseDown(object sender, MouseButtonEventArgs e)
        {
                if (field.Children.Count ==3) field.Children.Clear();

                if (field.Children.Count == 0) start = Mouse.GetPosition(field);
                l = new Line();
                l.StrokeThickness = 12;
                l.Stroke = Brushes.Blue;

                p = Mouse.GetPosition(field);
                l.X1 = p.X;
                l.Y1 = p.Y;
                if ( field.Children.Count == 2) 
                {          
                    l.X2 = start.X;
                    l.Y2 = start.Y;
                }

                field.Children.Add(l);
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
             if (l != null)
            {
                l.Stroke = Brushes.Blue;
                p = Mouse.GetPosition(field);
                if (field.Children.Count <= 2)
                {
                    l.X2 = p.X;
                    l.Y2 = p.Y;
                }
            }
        }

        private void field_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (field.Children.Count != 3)
            l.Stroke = Brushes.Red;
        }


    }
}
