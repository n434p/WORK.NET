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
        Button b = new Button() { Content = "Generate DLL", Width = 100, Height = 40, VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment=HorizontalAlignment.Center};
        List<FieldBuilder> varList = new List<FieldBuilder>();
        bool created = false;

        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 1; i <= 5; i++)
			{
                numFields.Items.Add(i);
			}
            b.BorderThickness = new Thickness(5);
            
        }

        void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackVarPanel.Children.Clear();
            for (int i = 0; i < (int)numFields.SelectedValue; i++)
            {
                VarComboBox vbx = new VarComboBox() { Width = 100, HorizontalAlignment = System.Windows.HorizontalAlignment.Center};
                TextBox txb = new TextBox() { Width = 100, HorizontalAlignment = System.Windows.HorizontalAlignment.Center };
                txb.Text = "var" + i ;
                vbx.SelectionChanged += vbx_SelectionChanged;
                vbx.ToolTip = txb.Text;
                StackVarPanel.Children.Add(txb);
                StackVarPanel.Children.Add(vbx); 
            }
            
        }

        void vbx_SelectionChanged(object sender, EventArgs e)
        {
            VarComboBox vbx = sender as VarComboBox;
            if (vbx.SelectedIndex != -1) 
            {
                bool flag = false;
                foreach (var item in StackVarPanel.Children)
                {
                    try
                    {
                        VarComboBox vcb = item as VarComboBox;
                        if (vcb.SelectedIndex == -1) flag = true;
                    }
                    catch { }
                }
                if (!flag && !created)
                {
                    StackVarPanel.Children.Add(b);
                   
                    b.Click += (o, ee) => { Body(); };
                }
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
                tb.DefineDefaultConstructor(MethodAttributes.Public);


                foreach (var item in StackVarPanel.Children)
                {
                    try
                    {
                        VarComboBox vb = item as VarComboBox;
                        switch ((VarType)vb.SelectedValue)
                        {
                            case VarType.INT: 
                                varList.Add(tb.DefineField(vb.ToolTip.ToString(), typeof(int), FieldAttributes.Public));
                                break;
                            case VarType.STR:
                                varList.Add(tb.DefineField(vb.ToolTip.ToString(), typeof(string), FieldAttributes.Public));
                                break;
                            case VarType.BOOL:
                                varList.Add(tb.DefineField(vb.ToolTip.ToString(), typeof(bool), FieldAttributes.Public));
                                break;
                            default:
                                break;
                        }      
                              
                        
                    }
                    catch { }
                }
                

                Type[] parameters = new Type[varList.Count];

                for (int i = 0; i < varList.Count; i++)
			{
			    parameters[i] = varList[i].FieldType;
			}
                Type objType = Type.GetType("System.Object");
                ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);
                ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameters);
               
                ILGenerator il1 = cb1.GetILGenerator();

                il1.EmitWriteLine("TEST 1");
                il1.Emit(OpCodes.Ldarg_0);
                il1.Emit(OpCodes.Call, objCtor);
                for (int i = 0; i < parameters.Length; i++)
                { 
                    il1.Emit(OpCodes.Ldarg_0);
                    il1.Emit(OpCodes.Ldarg);
                    il1.Emit(OpCodes.Stfld, varList[i]);
                }
                il1.Emit(OpCodes.Ret);


                MethodBuilder metB = tb.DefineMethod("Show", MethodAttributes.Public, CallingConventions.Standard, null, null);
                ILGenerator ilm = metB.GetILGenerator();
                string str = "";
                foreach (var item in varList)
                {
                    ilm.EmitWriteLine(item.FieldType+" "+item.Name+" = "+item);
                    //ilm.Emit(OpCodes.Ldarg_0);
                    //ilm.Emit(OpCodes.Ldarg,str);
                    //ilm.EmitWriteLine(str);
                }

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
