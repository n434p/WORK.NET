using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName an = new AssemblyName("MyAssembly");
            an.Version = new Version("1.0.0.1");

            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder mb = ab.DefineDynamicModule("MyModule", "MyAssembly.dll");

            TypeBuilder tb = mb.DefineType("MyClass", TypeAttributes.Public);

            FieldBuilder fb = tb.DefineField("number", typeof(int), FieldAttributes.Private);

            Type[] parametrs = {typeof(int)};

            ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,parametrs);

            ILGenerator il1 = cb1.GetILGenerator();
            il1.EmitWriteLine("MyConstructor");
            il1.Emit(OpCodes.Ldarg_0);
            il1.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            il1.Emit(OpCodes.Ldarg_0);
            il1.Emit(OpCodes.Ldarg_1);
            il1.Emit(OpCodes.Stfld, fb);
            il1.EmitWriteLine(fb);
            il1.Emit(OpCodes.Ret);

            tb.CreateType();

            ab.Save("MyAssembly.dll");
        }
    }
}
