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

namespace LINQProj
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        LibraryDataContext db = new LibraryDataContext();

        public AddBook()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            var category = db.Categories.ToList();
            foreach (var item in category)
            {
                dbCAtegories.Items.Add(item.Name);
            }
            dbCAtegories.SelectedIndex = 0;

            var press = db.Press.ToList();
            foreach (var item in press)
            {
                dbPress.Items.Add(item.Name);
            }
            dbPress.SelectedIndex = 0;

            var themes = db.Themes.ToList();
            foreach (var item in themes)
            {
                dbThemes.Items.Add(item.Name);
            }
            dbThemes.SelectedIndex = 0;

            var autors = db.Authors.ToList();
            foreach (var item in autors)
            {
                dbAuthors.Items.Add(item.LastName);
            }
            dbAuthors.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Books b = new Books() { Name = tbName.Text, Comment = tbComment.Text, Pages = Convert.ToInt32(tbPages.Text), Quantity = Convert.ToInt32(tbQuantity.Text), YearPress = Convert.ToInt32(tbYearPress.Text) };
            b.Id_Category = (from c in db.Categories where c.Name == dbCAtegories.SelectedItem.ToString() select c.Id).Single();
            b.Id_Themes = (from t in db.Themes where t.Name == dbThemes.SelectedItem.ToString() select t.Id).Single();
            b.Id_Press = (from p in db.Press where p.Name == dbPress.SelectedItem.ToString() select p.Id).Single();
            b.Id_Author = db.Authors.Where(a => a.LastName.Contains(dbAuthors.SelectedItem.ToString())).Single().Id;
            db.Books.InsertOnSubmit(b);
            this.Close();

        }
    }
}
