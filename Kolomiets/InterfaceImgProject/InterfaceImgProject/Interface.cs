using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Windows.Media.Imaging;

namespace InterfaceImgProject
{
    public interface IMainProject
    {
       
        BitmapImage MyImage {get ;set ;}
        
        
    }

    public interface IPlugin
    {
       string Name {get;}
       string Version {get;}
       string Author {get;}

       void Transform(IMainProject pr);
    }
}
