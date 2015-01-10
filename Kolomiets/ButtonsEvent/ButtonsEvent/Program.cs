using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonsEvent
{
    class Button
    {
        public event EventHandler Clicked;

        public string name;

        public Button(string n) 
        {
            name = n;
        }

        public void Push() 
        {
            if (Clicked != null)
            {
                Clicked(this, EventArgs.Empty);
            }
        }

        public void Click(object ob, EventArgs e) 
        {
            Console.WriteLine(this.name+" button clicked!!!");
        }

        public void ButtonClicked()
        {
            this.Clicked += Click;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Button b1 = new Button("1");
            Button b2 = new Button("2");
            Button b3 = new Button("3");
            
            b1.ButtonClicked();
            b1.Push();
            b2.Push();
            
        }
    }
}
