using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Input
    {
        public Dictionary<Key, bool> ControlKey = new Dictionary<Key, bool>();

        public bool Press(Key key) 
        {
            if (!ControlKey.ContainsKey(key)) ControlKey[key] = false;
            return ControlKey[key];
        }

        public void State(Key key,bool state)
        {
            ControlKey[key] = state;
        }
    }
}
