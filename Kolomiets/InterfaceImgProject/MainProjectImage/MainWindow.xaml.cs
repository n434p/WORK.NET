using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using InterfaceImgProject;

namespace MainProjectImage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, InterfaceImgProject.IMainProject
    {
        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();  
        public MainWindow()
        {
            InitializeComponent();
            FindPlugins();
        }

        public BitmapImage MyImage 
        {
            get { return (BitmapImage)myImage.Source; }
            set { myImage.Source = value; }
        }

        private void FindPlugins() 
        {
            //выбор папки для поиска плагинов
            string myFolder = System.AppDomain.CurrentDomain.BaseDirectory;
            //MessageBox.Show(myFolder);
            // ищем все библиотеке в каталоге
            string[] files = Directory.GetFiles(myFolder, "*.dll");
            foreach (string f in files)
            {
                try
                {
                    //загружаем метаданные файла
                    Assembly asm = Assembly.LoadFile(f);
                    //циклом перебирая проверяем наш тип принадлежит соответ интерфейсу
                    foreach (Type t in asm.GetTypes())
                    {
                        Type iType = t.GetInterface("InterfaceImgProject.IPlugin");
                        if (iType != null)
                        {
                            //создаем обьект плагина
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(t);
                            //добавляем в список плагинов
                            plugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("Error during load plugin\n" + ex.Message); }
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            BitmapImage bt = new BitmapImage();
            bt.BeginInit();
            bt.UriSource = new Uri("D:/Kolomiets/WORK.NET/Kolomiets/IntrfaceImageProject/IntrfaceImageProject/bin/Debug/1.jpg");
            bt.EndInit();
            myImage.Source = bt;

            FindPlugins();
            MessageBox.Show(plugins.Count.ToString());
            foreach (string item in plugins.Keys)
            {
                lbNamePlugin.Items.Add(item);
            }
        }
    }
}
