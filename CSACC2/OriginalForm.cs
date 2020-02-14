using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSACC2
{
    class EmployeeForm
    {
        public TextBox Id   = new TextBox();
        public TextBox Name = new TextBox();
        public Button SearchButton = new Button();

        public EmployeeForm(){
            SearchButton.Click += Search;
        }
        private void Search(object sender, EventArgs e)
        {

        }
    }
}
