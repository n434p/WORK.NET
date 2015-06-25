using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorSampleApp
{
    public abstract class BakeryComponent
    {
        public abstract string GetName();
        public abstract double GetPrice();
    }
}
