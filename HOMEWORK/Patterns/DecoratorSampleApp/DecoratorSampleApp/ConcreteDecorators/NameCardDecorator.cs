using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorSampleApp
{
    class NameCardDecorator : Decorator
    {
        private int m_DiscountRate = 5;

        public NameCardDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Name Card";
            this.m_Price = 4.0;
        }

        public override string GetName()
        {
            return base.GetName() + 
                string.Format("\n(Please Collect your discount card for {0}%)", 
                m_DiscountRate);
        }        
    }
}
