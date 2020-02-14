using CSACC.input;
using CSACC.gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSACC.input.FromCSV;

namespace CSACC
{
    public partial class Form1 : Form
    {
        private static String strAccessConn = $"Provider={Config.DbProvider};Data Source={Config.DbSource}";
        private OleDbConnection Connection = new OleDbConnection(strAccessConn);

        public Form1()
        {
            InitializeComponent();

            Connection.Open();
            var csvLines = readCsv(Config.CsvPath);
            foreach (CSVLine csvLine in csvLines)
            {
                Console.WriteLine(csvLine);
                csvLine.ToRequest()
                    .SelectMany(it=> Plan.FromRequest(it))
                    .ToList()
                    .ForEach(it=> toDatabase(it.ToString()));
            }
        }
        private List<CSVLine> readCsv(String path)
        {
            var lines = System.IO.File.ReadAllLines(path, Encoding.Default);
            var csvLines
                = lines.Skip(1)
                    .Select(line =>
                    {
                        var columns = line.Split(',');
                        return new CSVLine(columns);
                    });
            return csvLines.ToList();
        }
        private void toDatabase(String data)
        {
            var tableName =  "`log`";
            var rows      =  "`data`";
            var values    = $"'{data}'";
            var order   = $"INSERT INTO {tableName}({rows}) VALUES ({values})";
            var command = new OleDbCommand(order, Connection);
            command.ExecuteNonQuery();
        }
    }
    
        //public String Writer            { get; private set; }
        //public String Department        { get; private set; }
        //public String RequestDateTime   { get; private set; }
}
