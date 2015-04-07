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
        public SellWindow sw;
        Dictionary<int, string> structure = new Dictionary<int, string>();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //db.Database.Delete();
            //db.Films.Add(new Film() { Name = "Godfather1" });
            //db.Films.Add(new Film() { Name = "Godfather2" });
            //db.Films.Add(new Film() { Name = "Godfather3" });
            //db.Halls.Add(new Hall() { FileSource = "1.txt", FilmId = 1, Name = "Favorite" });
            //db.Halls.Add(new Hall() { FileSource = "1.txt", FilmId = 2, Name = "Favorite" });
            //db.SaveChanges();
            lbFilms.ItemsSource = db.Films.ToList();
        }

        private void lbFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Film f = ((sender as ListBox).SelectedItem) as Film;
            lbHalls.ItemsSource = db.Halls.Where(d => d.FilmId == f.Id).Distinct().ToList();
        }

        private void GetStructure(string source)
        {
            if (!File.Exists(source)) return;
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
            int maxWidth = 0;
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
                        sw.AddButton(placeNum.ToString(), step - 5, t, line[j]);
                        placeNum++;
                    }
                    if (j>=maxWidth) maxWidth = j+1;
                }
            }
            sw.placesTable.Height = sw.buyBtn.Height = step * s.Count;
            sw.placesTable.Width = step * maxWidth;
            sw.placesTable.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            sw.buyBtn.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
        }

        private void lbHalls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbHalls.SelectedItem == null) return;

            Hall h = ((sender as ListBox).SelectedItem) as Hall;
            if (h.FileSource == null) return;
            sw = new SellWindow();
            sw.IdFilm = h.FilmId;
            sw.IdHall = h.Id;
            structure.Clear();
            GetStructure(h.FileSource.ToString());
            if (structure.Count == 0)
            {
                MessageBox.Show("Can't find proper structure file for the selected hall:\n\n\t" + h.FileSource.ToString(), "Missing file");
                return;
            }
            sw.DBSet(ref db);
            DrawStructure(structure);
            sw.ShowDialog();
        }

        private void CinemaWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Database.Connection.Close();
        }

    }
}
