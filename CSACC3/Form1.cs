using CSACC3.gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSACC3
{
    public partial class Form1 : Form
    {
        Adapter adapter;
        public Form1()
        {
            InitializeComponent();

            adapter = new Adapter(this);
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            Console.WriteLine($"csv {dialog.FileName}");
        }
        private void GetWriterIdButton_Click(object sender, EventArgs e)
        {
            adapter.GetWriterIdFromName(writerNameTextBox.Text);
        }
        private void GetDepartmentIdButton_Click(object sender, EventArgs e)
        {
            adapter.GetDepartmentIdFromName(departmentNameTextBox.Text);
        }
        private void GetRequesterIdButton_Click(object sender, EventArgs e)
        {
            adapter.GetRequesterIdFromName(requesterNameTextBox.Text);
        }
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var writerId = int.Parse(writerIdComboBox.Text);
            var departmentId = int.Parse(departmentIdComboBox.Text);
            var requesterId = int.Parse(requesterIdComboBox.Text);
            var workDate = DateTime.Parse(workDatePicker.Text);
            var workTime = workTimeComboBox.Text;
            var restDate = DateTime.Parse(restDatePicker.Text);
            var restTime = restTimeComboBox.Text;
            adapter.AddRequest(writerId, departmentId, requesterId, workDate, workTime, restDate, restTime);
        }


        /* Methods is called from Adapter */
        public void SetWriterIds(List<String> ids)
        {
            writerIdComboBox.Items.Clear();
            if (ids.Count() == 0)
            {
                writerIdComboBox.Text = "";
                DialogResult dialogResult =
                    MessageBox.Show($"新しく {writerNameTextBox.Text} さんのデータを追加しますか？"
                                  , "履歴に存在しない社員名が入力されました"
                                  , MessageBoxButtons.YesNo
                                  , MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                adapter.AddWriter(writerNameTextBox.Text);
                return;
            }

            writerIdComboBox.Items.AddRange(ids.ToArray());
            writerIdComboBox.SelectedIndex = 0;
            if (ids.Count() > 1)
                writerIdComboBox.DroppedDown = true;
        }
        public void SetDepartmentIds(List<String> ids)
        {
            departmentIdComboBox.Items.Clear();
            if (ids.Count() == 0)
            {
                departmentIdComboBox.Text = "";
                DialogResult dialogResult =
                    MessageBox.Show($"新しく 部署:{departmentNameTextBox.Text} のデータを追加しますか？"
                                  , "履歴に存在しない部署名が入力されました"
                                  , MessageBoxButtons.YesNo
                                  , MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                adapter.AddDepartment(departmentNameTextBox.Text);
                return;
            }

            departmentIdComboBox.Items.AddRange(ids.ToArray());
            departmentIdComboBox.SelectedIndex = 0;
            if (ids.Count() > 1)
                departmentIdComboBox.DroppedDown = true;
        }
        public void SetRequesterIds(List<String> ids)
        {
            requesterIdComboBox.Items.Clear();
            if (ids.Count() == 0)
            {
                requesterIdComboBox.Text = "";
                DialogResult dialogResult =
                    MessageBox.Show($"新しく {requesterNameTextBox.Text} さんのデータを追加しますか？"
                                  , "履歴に存在しない社員名が入力されました"
                                  , MessageBoxButtons.YesNo
                                  , MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                adapter.AddRequester(requesterNameTextBox.Text);
                return;
            }

            requesterIdComboBox.Items.AddRange(ids.ToArray());
            requesterIdComboBox.SelectedIndex = 0;
            if (ids.Count() > 1)
                requesterIdComboBox.DroppedDown = true;
        }

    }
}
