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

namespace ImageProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int index;
        public int curIndex 
        {
            get { return index; }
            set 
            {
                index = value;
                if (value == 6) index = 1;
                if (value == 0) index = 5;
            }
        }

        public MainWindow()
        {

            InitializeComponent();

            index = 1;
            myGrid.Background = new ImageBrush()
            {
                ImageSource = new BitmapImage((new Uri(@"..\..\Image\background.jpg", UriKind.Relative)))
            };

        }

        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (sender as Button);
          //  imgCurrent.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(string.Format(@"..\..\Image\{0}.jpg", curIndex + 1));


            if (b.Content.ToString() == "Next")
            {
                curIndex++;
                imgPrev.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(string.Format(@"..\..\Image\{0}.jpg", --curIndex));
                curIndex++;
                imgCurrent.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(string.Format(@"..\..\Image\{0}.jpg", curIndex));
                imgNext.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(string.Format(@"..\..\Image\{0}.jpg", ++curIndex));
                curIndex--;
            }
            else
            {
                curIndex--;
                imgPrev.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(string.Format(@"..\..\Image\{0}.jpg", --curIndex));
                curIndex++;
                imgCurrent.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(string.Format(@"..\..\Image\{0}.jpg", curIndex));
                imgNext.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(string.Format(@"..\..\Image\{0}.jpg", ++curIndex));
                curIndex--;
            }
        }
    }
}
