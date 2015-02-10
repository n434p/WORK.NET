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
        HeadedTriangle trian,trianCopy;
        Ellipse ell;
        bool flag = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void field_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

                if (trian == null)
                {
                    ell = null;
                    trian = new HeadedTriangle();
                    trian.Start = Mouse.GetPosition(field);
                    field.Children.Add(trian.path);
                }
                else if (flag == true)
                {
                    if (trian.gGroup.Children.Count == 6) { trian = null; flag = false; return; }
                    trian.Mid = Mouse.GetPosition(field);

                    ell = new Ellipse() { StrokeThickness = 20, Width = 20, Height = 20, Fill = Brushes.Gold };
                    ell.Margin = new Thickness(trian.Mid.X - 10, trian.Mid.Y - 10, 0, 0);
                    ell.MouseLeftButtonDown += (o, ee) =>
                    {
                        ell = o as Ellipse;
                        field.Children.Remove(ell);
                        ell = null;
                        trian.gGroup.Children.Add(trian.l1);
                        trian.gGroup.Children.Add(trian.l2);
                        trian.gGroup.Children.Add(trian.mid);
                    };
                    
                    field.Children.Add(ell);

                
            }
        }

        private void field_MouseMove(object sender, MouseEventArgs e)
        {
            if (trian != null && trian.path.Stroke == Brushes.Blue)
            { 
            trian.End = Mouse.GetPosition(field);
            }

        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (field.Children.Count > 1)
            {
                if (field.Children[field.Children.Count - 1] is Ellipse) flag = true;
                field.Children.RemoveAt((field.Children.Count) - 1);
            }
            else
                field.Children.Clear();
                trian = null;
        }

        private void field_MouseLeave(object sender, MouseEventArgs e)
        {
            if (trian != null) trian.path.Stroke = Brushes.Red;
        }

        private void field_MouseEnter(object sender, MouseEventArgs e)
        {
           if (trian != null) trian.path.Stroke = Brushes.Blue;
        }

        

        private void field_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ell == null && trian != null)
            {
                if (trian != null && trian.path.Stroke != Brushes.Red)
                { trian.path.Stroke = Brushes.Green; flag = true; }
                else
                { field.Children.Remove(trian.path); trian = null; }
            }
        }


    }
}
