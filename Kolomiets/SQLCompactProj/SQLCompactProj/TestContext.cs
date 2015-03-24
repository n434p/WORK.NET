using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace SQLCompactProj
{
    class TestContext: DbContext
    {
        public TestContext() : base("Test")
        { }

        public DbSet<People> Peoples {get;set;}
    }

    class People
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
