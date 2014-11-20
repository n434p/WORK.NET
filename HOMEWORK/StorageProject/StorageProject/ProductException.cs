using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageProject
{
    class ProductException: ApplicationException
    {
        public ProductException(string m) : base(m) { }
  
    }
}
