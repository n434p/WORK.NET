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
using System.Configuration;

namespace ReversEntity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            string str = ConfigurationManager.ConnectionStrings["Example"].ConnectionString;
            ModelContainer db = new ModelContainer();  
            Departments d = new Departments(){Id_dep = 1, Name = "asdasd"};
            db.DepartmentsSet.Add(d);
            db.SaveChanges();
            lb.ItemsSource = (from dep in db.DepartmentsSet select dep.Name).ToList();
        }
    }
}
