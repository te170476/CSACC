using com.github.tcc170476.CSACC.adapter;
using com.github.tcc170476.CSACC.adapter.controller;
using com.github.tcc170476.CSACC.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.github.tcc170476.CSACC
{
    public partial class Form1 : Form, IView
    {
        Adapter Adapter;
        public Form1()
        {
            InitializeComponent();
            Adapter = new Adapter(this);
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            Console.WriteLine($"csv {dialog.FileName}");
        }
        private void GetWriterIdButton_Click(object sender, EventArgs e)
        {
            //adapter.GetWriterIdFromName(writerNameTextBox.Text);
        }
        private void GetDepartmentIdButton_Click(object sender, EventArgs e)
        {
            //adapter.GetDepartmentIdFromName(departmentNameTextBox.Text);
        }
        private void GetRequesterIdButton_Click(object sender, EventArgs e)
        {
            //adapter.GetRequesterIdFromName(requesterNameTextBox.Text);
        }
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var request = new Request(
                  writerIdComboBox.Text
                , departmentIdComboBox.Text
                , requestDivisionComboBox.Text
                , requesterIdComboBox.Text
                , workDatePicker.Text
                , workTimeComboBox.Text
                , restDatePicker.Text
                , restTimeComboBox.Text
                );

            switch (request.Division)
            {
                case "新規":
                    Adapter.Add(request);
                    break;
                case "変更":
                    Adapter.Update(request);
                    break;
                case "取消":
                    Adapter.Delete(request);
                    break;
            }
        }

        public void OnAddRequest(Result result)
        {
            if (result.isFailure())
                { SetFailureLabel("Request is not added."); return; }
            SetSucceedLabel("Request added.");
        }
        public void OnUpdateRequest(Result result)
        {
            if (result.isFailure())
            { SetFailureLabel("Request is not updated."); return; }
            SetSucceedLabel("Request updated.");
        }




        private void SetSucceedLabel(String message)
        {
            label1.ForeColor = Color.Black;
            label1.Text = $"Success: Request added.";
        }
        private void SetFailureLabel(String message)
        {
            label1.ForeColor = Color.Red;
            label1.Text = $"Failure: {message}";
        }

    }
}
