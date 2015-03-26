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
    public partial class MainWindow : Window
    {
        CinemaContext db = new CinemaContext();
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
            SellWindow sl = new SellWindow();
            string s = (sender as ListBox).SelectedItem.ToString();
            Films film = db.Films.Where(name => name.Name == s).Single();
            Halls h = db.Halls.Where(id => id.FilmId == film.Id).Single();
            GetStructure(h.FileSource.ToString());
            sl.ShowDialog();
        }

        private void GetStructure(string source)
        {
            string str = "";
            using (StreamReader sr = new StreamReader(source))
            {
                int i = 1;
                while (!sr.EndOfStream)
                {
                    structure[i] = sr.ReadLine();
                }               
            }
        }

        public void DrawStructure(Dictionary<int, string> s)
        {
            int placeNum = 1;
            for (int i = 0; i < s.Keys.Count(); i++)
            {
                string[] line = s.Values.ElementAt(i).Trim().Split(new char[] { ' ', ',' });
                Button b = new Button() { Content = placeNum.ToString(), Width = Height = 10 };
                for (int j = 0; j < line.Length.; j++)
                {
                b.Margin = new Thickness(b.Width*,item.Key.Y,0,0);
                if (b.Content.ToString() == "0") {b.Opacity = 0; space = b;}
                puzzleField.Children.Add(b);

                }
            }
        }

    }
}
