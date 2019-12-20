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
            Adapter.GetRequesterId(requesterNameTextBox.Text);
        }
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var writerId     = writerIdComboBox.Text;
            var departmentId = departmentIdComboBox.Text;
            var requesterId  = requesterIdComboBox.Text;

            switch (requestDivisionComboBox.Text)
            {
                case "新規":
                    {
                        var request = new AddRequest(
                              writerId
                            , departmentId
                            , requesterId
                            , workDatePicker.Text
                            , workTimeComboBox.Text
                            , restDatePicker.Text
                            , restTimeComboBox.Text);
                        Adapter.Request(request);
                    }
                    break;
                case "変更":
                    {
                        var request = new UpdateRequest(
                              writerId
                            , departmentId
                            , requesterId
                            , workDatePicker.Text
                            , workTimeComboBox.Text
                            , restDatePicker.Text
                            , restTimeComboBox.Text);
                        Adapter.Request(request);
                    }
                    break;
                case "取消":
                    {
                        var request = new DeleteRequest(
                              writerId
                            , departmentId
                            , requesterId
                            , workDatePicker.Text
                            , workTimeComboBox.Text);
                        Adapter.Request(request);
                    }
                    break;
            }
        }


        public void OnSuccessAddRequester(int employeeId)
        {
            SetSucceedLabel("Succeed to add requester.");
            requesterIdComboBox.Text = employeeId.ToString();
        }
        public void OnFailureAddRequester()
        {
            SetFailureLabel("Failed to add requester.");
        }
        public void OnSuccessGetRequesterId(int employeeId)
        {
            SetSucceedLabel("get requester id.");
            requesterIdComboBox.Text = employeeId.ToString();
        }
        public void OnFailureGetRequesterId()
        {
            SetFailureLabel("get requester id.");
            Adapter.AddRequester(requesterNameTextBox.Text);
        }

        public void OnSuccessAddRequest()
        {
            SetSucceedLabel("Request added.");
        }
        public void OnFailureAddRequest()
        {
            SetFailureLabel("Request is not added.");
        }
        public void OnSuccessUpdateRequest()
        {
            SetSucceedLabel("Request updated.");
        }
        public void OnFailureUpdateRequest()
        {
            SetFailureLabel("Request is not updated.");
        }
        public void OnSuccessDeleteRequest()
        {
            SetSucceedLabel("Request deleted.");
        }
        public void OnFailureDeleteRequest()
        {
            SetFailureLabel("Request is not deleted.");
        }


        private void SetSucceedLabel(String message)
        {
            label1.ForeColor = Color.Black;
            label1.Text = $"Success: {message}";
        }
        private void SetFailureLabel(String message)
        {
            label1.ForeColor = Color.Red;
            label1.Text = $"Failure: {message}";
        }

    }
}
