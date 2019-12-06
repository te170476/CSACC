using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3.document.entity
{
    class Department
    {
        public String Name;
        public Department(String name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"department({Name})";
        }
    }
}
