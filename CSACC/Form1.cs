using com.github.tcc170476.CSACC.adapter;
using com.github.tcc170476.CSACC.adapter.controller;
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


        ///* Methods is called from Adapter */
        //public void SetWriterIds(List<String> ids)
        //{
        //    writerIdComboBox.Items.Clear();
        //    if (ids.Count() == 0)
        //    {
        //        writerIdComboBox.Text = "";
        //        DialogResult dialogResult =
        //            MessageBox.Show($"新しく {writerNameTextBox.Text} さんのデータを追加しますか？"
        //                          , "履歴に存在しない社員名が入力されました"
        //                          , MessageBoxButtons.YesNo
        //                          , MessageBoxIcon.Question);
        //        if (dialogResult != DialogResult.Yes) return;
        //        adapter.AddWriter(writerNameTextBox.Text);
        //        return;
        //    }

        //    writerIdComboBox.Items.AddRange(ids.ToArray());
        //    writerIdComboBox.SelectedIndex = 0;
        //    if (ids.Count() > 1)
        //        writerIdComboBox.DroppedDown = true;
        //}
        //public void SetDepartmentIds(List<String> ids)
        //{
        //    departmentIdComboBox.Items.Clear();
        //    if (ids.Count() == 0)
        //    {
        //        departmentIdComboBox.Text = "";
        //        DialogResult dialogResult =
        //            MessageBox.Show($"新しく 部署:{departmentNameTextBox.Text} のデータを追加しますか？"
        //                          , "履歴に存在しない部署名が入力されました"
        //                          , MessageBoxButtons.YesNo
        //                          , MessageBoxIcon.Question);
        //        if (dialogResult != DialogResult.Yes) return;
        //        adapter.AddDepartment(departmentNameTextBox.Text);
        //        return;
        //    }

        //    departmentIdComboBox.Items.AddRange(ids.ToArray());
        //    departmentIdComboBox.SelectedIndex = 0;
        //    if (ids.Count() > 1)
        //        departmentIdComboBox.DroppedDown = true;
        //}
        //public void SetRequesterIds(List<String> ids)
        //{
        //    requesterIdComboBox.Items.Clear();
        //    if (ids.Count() == 0)
        //    {
        //        requesterIdComboBox.Text = "";
        //        DialogResult dialogResult =
        //            MessageBox.Show($"新しく {requesterNameTextBox.Text} さんのデータを追加しますか？"
        //                          , "履歴に存在しない社員名が入力されました"
        //                          , MessageBoxButtons.YesNo
        //                          , MessageBoxIcon.Question);
        //        if (dialogResult != DialogResult.Yes) return;
        //        adapter.AddRequester(requesterNameTextBox.Text);
        //        return;
        //    }

        //    requesterIdComboBox.Items.AddRange(ids.ToArray());
        //    requesterIdComboBox.SelectedIndex = 0;
        //    if (ids.Count() > 1)
        //        requesterIdComboBox.DroppedDown = true;
        //}
        //public void SetAddRequestResult(String message)
        //{
        //    Console.WriteLine($"AddRequest() is {message}.");
        //}
    }
}
