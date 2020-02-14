using CSACC2.adapter;
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

namespace CSACC2
{
    public partial class Form1 : Form
    {
        RequestController RequestController = new RequestController();
        OleDbConnection connection;

        EmployeeForm EmployeeForm = new EmployeeForm();

        string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CSDB.accdb";

        public Form1()
        {
            InitializeComponent();

            connection = new OleDbConnection(strAccessConn);
            connection.Open();
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            var employee = EmployeeForm.Name.Text;
            var division = divisionTextBox.Text;
            var workPlan = workPlanTextBox.Text;
            var restPlan = restPlanTextBox.Text;
            RequestController.Add(employee, division, workPlan, restPlan);
            //var orderText = "INSERT INTO test (content) VALUES ('button_insert')";
            //var insertOrder = new OleDbCommand(orderText, connection);
            //insertOrder.ExecuteNonQuery();

            //var selectCommand = new OleDbCommand("SELECT @@IDENTITY", connection);
            //label1.Text = selectCommand.ExecuteScalar().ToString();
        }
    }
}
