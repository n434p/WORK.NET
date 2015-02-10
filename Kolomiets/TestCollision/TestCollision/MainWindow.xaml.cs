using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TestCollision
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Timer t;
        Button b;

        public MainWindow()
        {
            InitializeComponent();
            t = new Timer(500);
            t.Elapsed += (o,e) =>
            {
                if (b == null) { b = new Button(); grid.Children.Add(b); }
                b.Content = DateTime.Now.ToLongTimeString();
                b.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                b.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                
            };
            
            
        }


        public void Method(object o) 
        {
           // button.Content = DateTime.Now.ToLongTimeString();


            //ThreadPool.ReferenceEquals(o, this);
            //if (b == null) {b = new Button(); grid.Children.Add(b);}
            //b.Content = DateTime.Now.ToLongTimeString();
            //b.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            //b.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            t.Start();
            
            
        }
    }
}
