using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorSampleApp
{
    class PastryBase : BakeryComponent
    {
        // In real world these values will typically come from some data store
        private string m_Name = "Pastry Base";
        private double m_Price = 20.0;

        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }
}
