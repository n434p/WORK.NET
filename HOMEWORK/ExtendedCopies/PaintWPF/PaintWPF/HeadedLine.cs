using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintWPF
{
    class HeadedTriangle
    {
        public Path path;
        public GeometryGroup gGroup;
        public LineGeometry l,l1,l2;
        public EllipseGeometry st,en,mid;
        public Point Start 
        {
            get { return l.StartPoint; }
            set { l.StartPoint = l1.StartPoint =st.Center = value; } 
        }
        public Point End 
        {
            get { return l.EndPoint; }
            set { l.EndPoint = l2.StartPoint = en.Center = value; } 
        }
        public Point Mid
        {
            get { return mid.Center; }
            set { mid.Center=l1.EndPoint=l2.EndPoint= value; }
        }
        public HeadedTriangle()
        {
            path = new Path();
            gGroup = new GeometryGroup();
            path.Stroke = Brushes.Blue;
            path.StrokeThickness = 10;
            l = new LineGeometry();
            l1 = new LineGeometry();
            l2 = new LineGeometry();
            st = new EllipseGeometry();
            en = new EllipseGeometry();
            mid = new EllipseGeometry();
            
            st.RadiusX = en.RadiusX = 5;
            st.RadiusY = en.RadiusY =5;
            mid.RadiusX = 5;
            mid.RadiusY = 5;
            
            gGroup.Children.Add(l);
            gGroup.Children.Add(st);
            gGroup.Children.Add(en);
            path.Data = gGroup;
        }
       
    }
}
