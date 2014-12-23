using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace collectionFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcd_вапвапвап~`!@#$%^&*()-=+|:;\",.<>?/12345";
            Regex regex = new Regex(@"\W");
            MatchCollection matchcollection = regex.Matches(s);
            string Text = "";
            for (int i = 0; i < matchcollection.Count; i++)
            {
                Text += matchcollection[i].Value + " ";
            }

            Console.WriteLine(Text);

        }
    }
}
