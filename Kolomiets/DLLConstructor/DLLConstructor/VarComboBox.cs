using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DLLConstructor
{
    public enum VarType { INT =1, STR ,BOOL}
    class VarComboBox: System.Windows.Controls.ComboBox
    {
        public VarComboBox()
        {
            Width = 150;
            this.Items.Add(VarType.INT);
            this.Items.Add(VarType.STR);
            this.Items.Add(VarType.BOOL);
        }
    }
}
