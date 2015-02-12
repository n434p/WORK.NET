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

namespace ListView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Ager = "sdfg"; 

        public MainWindow()
        {
            InitializeComponent();
            ListViewItem Age = new ListViewItem();
        
            Age.Content = Ager;
            listView.Items.Add(Age);
            ListView.Properties.Resources.ResourceManager.
        }
    }
}
