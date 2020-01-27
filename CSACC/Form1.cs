using CSACC.input.fromCsv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSACC
{
    public partial class Form1 : Form
    {
        private ToEntityConverter converter = new ToEntityConverter();
        public Form1()
        {
            InitializeComponent();

            new CsvReader().read(Config.CsvPath)
                .SelectMany(it=> converter.ToRequest(it))
                .ToList()
                .ForEach(it=> Console.WriteLine(it));
        }
    }
}
