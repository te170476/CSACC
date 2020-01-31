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
        private ToEntityConverter           toEntity    = new ToEntityConverter();
        private gateway.FromEntityConverter fromEntity  = new gateway.FromEntityConverter();
        private gateway.Gateway             gateway     = new gateway.Gateway();
        public Form1()
        {
            InitializeComponent();

            new CsvReader().read(Config.CsvPath)
                .SelectMany(it=> toEntity.ToRequest(it))
                .Select(it=> fromEntity.FromRequest(it))
                .ToList()
                .ForEach(it=> gateway.Apply(it));
        }
    }
}
