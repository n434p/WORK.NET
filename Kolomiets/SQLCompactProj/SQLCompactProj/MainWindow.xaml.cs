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

namespace SQLCompactProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestContext db = new TestContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            People p = new People() { Name = tbName.Text, Age = Convert.ToInt32(tbAge.Text) };
            tbName.Clear();
            tbAge.Clear();
            db.Peoples.Add(p);
            db.SaveChanges();
            lb.ItemsSource = db.Peoples.ToList();
           
        }
    }
}
