using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternProj
{
    class Bycycle
    {
        List<string> items = new List<string>();

        public void AddItem(string i)
        {
            items.Add(i);
        }


        public override string ToString()
        {
            string res = "";
            foreach (string item in items)
            {
                res += item + "\n";
            }

            return res;
        }
    }

    abstract class CycleBuilder
    {
        public abstract void AddWheel();
        public abstract void AddSadle();
        public abstract void AddControl();
        public abstract void AddPedals();

        public abstract Bycycle Return();
    }


    class UkraineCycle : CycleBuilder 
    {
        public override void AddWheel()
        {
            throw new NotImplementedException();
        }

        public override void AddSadle()
        {
            throw new NotImplementedException();
        }

        public override void AddControl()
        {
            throw new NotImplementedException();
        }

        public override void AddPedals()
        {
            throw new NotImplementedException();
        }

        public override Bycycle Return()
        {
            throw new NotImplementedException();
        }
    }


}
