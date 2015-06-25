using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorSampleApp
{
    class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Cherry";
            this.m_Price = 2.0;
        }
    }
}
