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

namespace RandomButton
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button btn = new Button();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 11; i++)
            {
                Random r = new Random();
                Button b = new Button();
                //
                b.Width = 30;
                b.Height = 30;
                b.Margin = new Thickness(r.Next(100), r.Next(50), r.Next(100), r.Next(50));
                b.Content = i;
                
                MyGrid.Children.Add(b);
            }
        }
    }
}
