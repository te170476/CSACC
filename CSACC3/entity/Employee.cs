using System;
using System.Data.OleDb;

namespace CSACC3.document.entity
{
    class Employee
    {
        public String Name;
        public Employee(String name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"employee({Name})";
        }
    }
}
