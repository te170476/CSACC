﻿using CSACC3.extensions;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC3.gateway
{
    class Employee
    {
        String TableName = "employee";
        private OleDbConnection Connection;
        public Employee(OleDbConnection connection)
        {
            Connection = connection;
        }
        public Option<String> Search(EmployeeId id)
        {
            var order = $"SELECT `name` FROM {TableName} WHERE `id` = '{id.Value}'";
            var command = new OleDbCommand(order, Connection);
            var result = command.ExecuteScalar();
            if (result == null)
            {
                return new None<String>();
            }
            return new Some<String>(result.ToString());
        }
        public List<int> Search(EmployeeName name)
        {
            var order = $"SELECT `ID` FROM {TableName} WHERE `name` = '{name.Value}'";
            var command = new OleDbCommand(order, Connection);
            var reader = command.ExecuteReader();
            if (reader == null)
            {
                return new List<int>();
            }
            return reader.GetLines().SelectMany(it=>it).Select(it => (int)it).ToList();
        }
        public int Insert(EmployeeName name)
        {
            var order = $"INSERT INTO `{TableName}`(`name`) VALUES ('{name.Value}')";
            var command = new OleDbCommand(order, Connection);
            command.ExecuteNonQuery();

            var selectCommand = new OleDbCommand("SELECT @@IDENTITY", Connection);
            return (int)selectCommand.ExecuteScalar();
        }
    }
}
