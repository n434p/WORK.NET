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

            List<FieldBuilder> fb = new List<FieldBuilder>();
            fb.Add(tb.DefineField("number", typeof(int), FieldAttributes.Private));
            fb.Add(tb.DefineField("str", typeof(string), FieldAttributes.Private));

            Type[] parametrs = {typeof(int),typeof(string)};

            ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,parametrs);
            
            ILGenerator il1 = cb1.GetILGenerator();
            il1.EmitWriteLine("MyConstructor");
            il1.Emit(OpCodes.Ldarg_0);
            il1.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            
            for (byte i = 0; i < parametrs.Length; i++)
            {
                il1.Emit(OpCodes.Ldarg_0);
                il1.Emit(OpCodes.Ldarg_S, i+1);
                il1.Emit(OpCodes.Stfld, fb[i]);
                il1.EmitWriteLine(fb[i]);
                
            }
            il1.Emit(OpCodes.Ret);

            MethodBuilder mb1 = tb.DefineMethod("Test", MethodAttributes.Public, typeof(void), null);
            ILGenerator ilMethod = mb1.GetILGenerator();
            for(int i=0;i<parametrs.Length;i++)
                ilMethod.EmitWriteLine(fb[i]);
            ilMethod.Emit(OpCodes.Ret);

            tb.CreateType();

            ab.Save("MyAssembly.dll");


          
        }
    }
}
