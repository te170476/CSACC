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
            Adapter.GetWriterId(writerNameTextBox.Text);
        }
        private void GetDepartmentIdButton_Click(object sender, EventArgs e)
        {
            Adapter.GetDepartmentId(departmentNameTextBox.Text);
        }
        private void GetRequesterIdButton_Click(object sender, EventArgs e)
        {
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

        public void OnSuccessAddWriter(int writerId)
        {
            SetSucceedLabel("Succeed to add writer.");
            requesterIdComboBox.Text = writerId.ToString();
        }
        public void OnFailureAddWriter()
        {
            SetFailureLabel("Failed to add writer.");
        }
        public void OnSuccessGetWriterId(int writerId)
        {
            SetSucceedLabel("get writer id.");
            requesterIdComboBox.Text = writerId.ToString();
        }
        public void OnFailureGetWriterId()
        {
            SetFailureLabel("get writer id.");
            Adapter.AddRequester(requesterNameTextBox.Text);
        }
        public void OnSuccessAddDepartment(int departmentId)
        {
            SetSucceedLabel("Succeed to add department.");
            departmentIdComboBox.Text = departmentId.ToString();
        }
        public void OnFailureAddDepartment()
        {
            SetFailureLabel("Failed to add department.");
        }
        public void OnSuccessGetDepartmentId(int departmentId)
        {
            SetSucceedLabel("get department id.");
            departmentIdComboBox.Text = departmentId.ToString();
        }
        public void OnFailureGetDepartmentId()
        {
            SetFailureLabel("get department id.");
            Adapter.AddDepartment(departmentNameTextBox.Text);
        }
        public void OnSuccessAddRequester(int requesterId)
        {
            SetSucceedLabel("Succeed to add requester.");
            requesterIdComboBox.Text = requesterId.ToString();
        }
        public void OnFailureAddRequester()
        {
            SetFailureLabel("Failed to add requester.");
        }
        public void OnSuccessGetRequesterId(int requesterId)
        {
            SetSucceedLabel("get requester id.");
            requesterIdComboBox.Text = requesterId.ToString();
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


        void usage()
        {
            var builder = new Builder();
            var str = "testStr";
            var dateTime = new DateTime();

            var convertedStr = builder.Convert(str);
            var convertedDateTime = builder.Convert(dateTime);
        }
    }

    class Builder
    {
        public String Convert(String value)
        {
            return $"'{value}'";
        }
        public String Convert(DateTime value)
        {
            return $"#{value}#";
        }
    }

}
