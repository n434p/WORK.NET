using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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

namespace DLLConstructor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button b = new Button() { Content = "Generate DLL", Width = 80, Height = 30, VerticalAlignment = VerticalAlignment.Bottom};
        List<object> varList = new List<object>();

        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 1; i <= 5; i++)
			{
                numFields.Items.Add(i);
			}
        }

        void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackVarPanel.Children.Clear();
            for (int i = 0; i < (int)numFields.SelectedValue; i++)
            {
                VarComboBox vbx = new VarComboBox();
                TextBox txb = new TextBox() { Text = "var" + i };
                vbx.SelectionChanged += vbx_SelectionChanged;
                vbx.ToolTip = txb.Text;
                StackVarPanel.Children.Add(txb);
                StackVarPanel.Children.Add(vbx);
                varList.Add(new object());
            }
            StackPanel.Children.Add(b);
            b.Click += (o, ee) => { Body(); };
        }

        void vbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VarComboBox vb = sender as VarComboBox;
            switch (vb.SelectedValue.ToString())
            {
                case "STR": vb.Tag = Convert.ToString(new object());   
                    break;
                case "BOOL": vb.Tag = Convert.ToBoolean(new object());  
                    break;
                case "INT": vb.Tag = Convert.ToInt32(new object());  
                    break;
            }

        }

        public void Body() 
        {
            try
            {
                // Динамическое создание Сборки с классом

                // создаем сборку
                // класс AssemblyName
                // затем AssemblyBilder - аоздает сборку

                AssemblyName an = new AssemblyName(textClass.Text+".dll");
                // версия сборки
                an.Version = new Version("1.0.0.0");

                //Конструируется сборка
                AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);

                //создаем модуль для сборки черезх нашу сборку
                ModuleBuilder mb = ab.DefineDynamicModule("MyModule", textClass.Text + ".dll");

                //создаем тип для модуля
                TypeBuilder tb = mb.DefineType(textClass.Text, TypeAttributes.Public);

                foreach (var item in StackVarPanel.Children)
                {
                    try
                    {
                        
                        VarComboBox vb = item as VarComboBox;
                        tb.DefineField(vb.ToolTip.ToString(), vb.Tag.GetType(), FieldAttributes.Public);
                    }
                    catch { }
                }
                

                Type[] parameters = { typeof(int) };

                ////нужно наполнять тип, изч  чего будет состоять класс.
                ////создадим конструктор и добавим туда код.
            //    ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);

                ////Добавим код в констурктор через IL генератор
                //ILGenerator il1 = cb1.GetILGenerator();
                //il1.EmitWriteLine("этот текст отобразится в консоли при создании экземпляра класса");

                //il1.Emit(OpCodes.Ldarg_0);


                ////необходимо выполнить завершение для IL конструкции
                //// Ret - return осуществляет выход из конструктора
                //il1.Emit(OpCodes.Ret);

                ////когда тип уже создан, создаем его
                tb.CreateType();

                //сохраняем сборку в файл
                ab.Save(textClass.Text + ".dll");
                MessageBox.Show("Your class builded!", "Success");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
