using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageProject
{
    interface IExpire
    {
        DateTime Date { get; set; }
        int EvalDays { get; set; }

        Status Check(Product p);
    }
}
