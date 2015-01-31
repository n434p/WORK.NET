using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceImgProject;
using System.Windows.Media.Imaging;

namespace PluginImageProject
{
    public class RandomTransform: IPlugin
    {
        public string Name 
        {
            get { return "Random transformation"; }
        }
        public string Version
        {
            get { return "1.0"; }
        }
        public string Author
        {
            get { return "Author NET14/2"; }
        }

        public void Transform(IMainProject pr) 
        {
            BitmapImage bt = pr.MyImage;
            Random r = new Random(DateTime.Now.Millisecond);
            int px = (int)(0.1 * bt.Width * bt.Height);
            for (int i = 0; i < px; i++)
            {
                BitmapImage bs = new BitmapImage();
                
               // bt.PixelWidth = r.Next(Convert.ToInt32(bt.Width)-1);
            }
            
        }
    }
}
