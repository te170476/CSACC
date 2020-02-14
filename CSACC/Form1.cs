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
        private input.fromCsv.ToEntityConverter toEntity    = new input.fromCsv.ToEntityConverter();
        private gateway.FromEntityConverter     fromEntity  = new gateway.FromEntityConverter();
        private gateway.Gateway                 gateway     = new gateway.Gateway();
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadCsv_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            new input.fromCsv.CsvReader().read(dialog.FileName)
                .SelectMany(it => toEntity.ToRequest(it))
                .Select(it => fromEntity.FromRequest(it))
                .ToList()
                .ForEach(it => gateway.Apply(it));
        }
    }
}
