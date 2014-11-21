using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageProject
{
    interface IExcise
    {
        bool Excise { get; set; }
        Status Check(Product p);
    }
}
