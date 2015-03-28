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

namespace CinemaProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class SellWindow : Window
    {
        public void AddButton(string name, int butSize,Thickness m, string price)
        {

            Button b = new Button() { Content = name, Width = butSize, Height = butSize, Tag = price};
            b.Margin = m;
            b.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            int i = Convert.ToInt32(price);
  
            if (i <= 15)
	  	     b.Background = Brushes.Green;     
            else  b.Background = Brushes.Red;

            if (b.Content.ToString() == "0") { b.Opacity = 0; b.IsEnabled = false; }
            this.placesTable.Children.Add(b);
        }
    }


    public partial class MainWindow : Window
    {
        CinemaContext db = new CinemaContext();
        SellWindow sw;
        Dictionary<int, string> structure = new Dictionary<int, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Films f1 = new Films() { Name = "Godfather3"};
            //db.Films.Add(f1);
            //db.SaveChanges();
            lbFilms.ItemsSource = db.Films.ToList();
        }

        private void lbFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sw = new SellWindow();
            string s = (sender as ListBox).SelectedItem.ToString();
            Films film = db.Films.Where(name => name.Name == s).Single();
            lbHalls.ItemsSource = db.Halls.Where(d => d.FilmId == film.Id).ToList();
        }

        private void GetStructure(string source)
        {
            using (StreamReader sr = new StreamReader(source))
            {
                int i = 1;
                while (!sr.EndOfStream)
                {
                    structure[i] = sr.ReadLine();
                    i++;
                }               
            }
        }

        public void DrawStructure(Dictionary<int, string> s)
        {
            int placeNum = 1;
            int step = 25;
            Thickness t;
            string[] line;
            for (int i = 0; i < s.Keys.Count(); i++)
            {
                line = s.Values.ElementAt(i).Trim().Split(new char[] { ' ', ',' });

                for (int j = 0; j < line.Length; j++)
                {
                    t = new Thickness(step * j, step * i, 0, 0);
                    if (line[j] != "0")
                    {
                        sw.AddButton(placeNum.ToString(), step - 5, t, line[J]);
                        placeNum++;
                    }
                }
            }
        }

        private void lbHalls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = (sender as ListBox).SelectedItem.ToString();
            Halls h = db.Halls.Where(name => name.Name == s).Single();
            GetStructure(h.FileSource.ToString());
            DrawStructure(structure);
            sw.ShowDialog();
        }

    }
}
