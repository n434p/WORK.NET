using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        double x;
        double y;

        public Complex() 
        {
            x = 0;
            y = 0;
        } 

        public Complex(double x, double y) 
        {
            this.x = x;
            this.y = y;
        } 

        public static Complex operator +(Complex com1, Complex com2)
            {
            Complex com = new Complex();
            com.x = com1.x + com2.x;
            com.y = com1.y + com2.y;
            return com;
            }

        public static Complex operator +(double com1, Complex com2)
        {
            Complex com = new Complex();
            com.x = com2.x + com1;
            com.y = com2.y;
            return com;
        }

        public static Complex operator +(Complex com1, double com2)
        {
            Complex com = new Complex();
            com.x = com1.x + com2;
            com.y = com1.y;
            return com;
        }

        public static Complex operator -(Complex com1, Complex com2)
        {
            Complex com = new Complex();
            com.x = com1.x - com2.x;
            com.y = com1.y - com2.y;
            return com;
        }

        public static Complex operator -(Complex com1, double com2)
        {
            Complex com = new Complex();
            com.x = com1.x - com2;
            com.y = com1.y;
            return com;
        }

        public static Complex operator -(double com1, Complex com2)
        {
            Complex com = new Complex();
            com.x = com2.x - com1;
            com.y = -com2.y;
            return com;
        }

        public static Complex operator *(Complex com1, Complex com2)
        {
            Complex com = new Complex();
            com.x = com1.x*com2.x - com1.y*com2.y;
            com.y = com1.y * com2.x + com1.x * com2.y;
            return com;
        }

        public static Complex operator *(double com1, Complex com2)
        {
            Complex com = new Complex();
            com.x = com2.x*com1;
            com.y = com2.y*com1;
            return com;
        }

        public static Complex operator *(Complex com1, double com2)
        {
            Complex com = new Complex();
            com.x = com1.x * com2;
            com.y = com1.y * com2;
            return com;
        }

        public static Complex operator /(Complex com1, Complex com2)
        {
            Complex com = new Complex();
            com.x = (com1.x * com2.x + com1.y * com2.y)/(com2.x*com2.x+com2.y*com2.y);
            com.y = (com1.y * com2.x - com1.x * com2.y) /(com2.x * com2.x + com2.y * com2.y);
            return com;
        }

        public static Complex operator /(double com1, Complex com2)
        {
            Complex com = new Complex();
            com.x = com2.x / com1;
            com.y = com2.y / com1;
            return com;
        }

        public static Complex operator /(Complex com1, double com2)
        {
            Complex com = new Complex();
            com.x = com1.x / com2;
            com.y = com1.y / com2;
            return com;
        }


        public override string ToString()
        {
            
            return string.Format("z = {0} {2} {1}*i ",x,y,(y<0)?"-":"+");
        }

    }
}
