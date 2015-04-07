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
using System.Windows.Shapes;

namespace CinemaProj
{
    /// <summary>
    /// Логика взаимодействия для SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        CinemaContext dbc;
        List<object> tickets = new List<object>();
        public int IdFilm, IdHall;

        public SellWindow()
        {
            InitializeComponent();
            
            
        }

        public void DBSet(ref CinemaContext db)
        { dbc = db; }

        public void AddButton(string counter, int butSize, Thickness m, string price)
        {
            Button b = new Button() { Content = counter, Width = butSize, Height = butSize, Tag = price };
            b.Click += b_Click;
            b.Margin = m;
            int temp = Convert.ToInt32(counter);
            var occup = from t in dbc.Tickets
                        where t.IdFilm == IdFilm && t.IdHall == IdHall && t.place == temp
                        select t.Id;
            if (occup.Count() > 0)
            {
                b.IsEnabled = false;
            }
            else
            {
                b.Background = Brushes.Green;
            }
            this.placesTable.Children.Add(b);
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Background == Brushes.YellowGreen)
            {
                b.Background = Brushes.Green;
            }
            else
            {
                b.Background = Brushes.YellowGreen;
            }
            buyBtn.IsEnabled = IsAnyPlaces();
        }

        bool IsAnyPlaces()
        {
            foreach (Button item in placesTable.Children)
            {
                if (item.Background == Brushes.YellowGreen) return true;
            }
            return false;
        }

        private void buyBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckSummary cs = new CheckSummary();
            try
            {
                foreach (Button item in placesTable.Children)
                {
                    if (item.Background == Brushes.YellowGreen)
                    {
                        Ticket t = new Ticket()
                        {
                            IdFilm = IdFilm,
                            IdHall = IdHall,
                            place = Convert.ToInt32(item.Content),
                            price = Convert.ToInt32(item.Tag)
                        };
                        dbc.Tickets.Add(t);
                        item.IsEnabled = false;
                        dbc.SaveChanges();
                        tickets.Add(new
                        {
                            Ticket_Code = dbc.Tickets.Local.Last().Id.ToString(),
                            Film = (from f in dbc.Films where f.Id == t.IdFilm select f.Name).Single(),
                            Hall = (from h in dbc.Halls where h.Id == t.IdHall select h.Name).Single(),
                            Price = t.price
                        });
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }


            cs.dgSumm.Columns.Add(new DataGridTextColumn()
            {
                Header = "Ticket #",
                Binding = new Binding("Ticket_Code")
            });
            cs.dgSumm.Columns.Add(new DataGridTextColumn()
            {
                Header = "Film",
                Binding = new Binding("Film")
            });
            cs.dgSumm.Columns.Add(new DataGridTextColumn()
            {
                Header = "Hall",
                Binding = new Binding("Hall")
            });
            cs.dgSumm.Columns.Add(new DataGridTextColumn()
            {
                Header = "Price",
                Binding = new Binding("Price")
            });
            cs.dgSumm.ItemsSource = tickets;
            cs.ShowDialog();
        }

    }
}
