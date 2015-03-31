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

namespace WPFEntity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        library db = new library();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = db.Categories.ToList();
            dgMain.Columns[2].Visibility = System.Windows.Visibility.Hidden;
        }

        private void dgMain_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
            MessageBox.Show((dgMain.CurrentCell.Item as Categories).Id.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Categories c = new Categories() { Name = tbName.Text };
            db.Categories.Add(c);
            db.ChangeTracker.DetectChanges();
            db.SaveChanges();
            dgMain.
            tbName.Text = "";
            
           // dgMain.ItemsSource = db.Categories.ToList();
        }
    }
}
