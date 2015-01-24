using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Динамическое создание Сборки с классом

            // создаем сборку
            // класс AssemblyName
            // затем AssemblyBilder - аоздает сборку

            AssemblyName an = new AssemblyName("MyAssembly");
            // версия сборки
            an.Version = new Version("1.0.0.0");

            //Конструируется сборка
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);

            //создаем модуль для сборки черезх нашу сборку
            ModuleBuilder mb = ab.DefineDynamicModule("MyModule", "MyAssembly.dll");

            //создаем тип для модуля
            TypeBuilder tb = mb.DefineType("MyClass", TypeAttributes.Public);

            FieldBuilder fb = tb.DefineField("Number", typeof(int), FieldAttributes.Private);

            Type[] parameters = {typeof(int)};

            //нужно наполнять тип, изч  чего будет состоять класс.
            //создадим конструктор и добавим туда код.
            ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);

            //Добавим код в констурктор через IL генератор
            ILGenerator il1 = cb1.GetILGenerator();
            il1.EmitWriteLine("этот текст отобразится в консоли при создании экземпляра класса");

            il1.Emit(OpCodes.Ldarg_0);


            //необходимо выполнить завершение для IL конструкции
            // Ret - return осуществляет выход из конструктора
            il1.Emit(OpCodes.Ret);

            //когда тип уже создан, создаем его
            tb.CreateType();

            //сохраняем сборку в файл
            ab.Save("MyAssembly.dll");
        }
    }
}
