namespace com.github.tcc170476.CSACC
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.readButton = new System.Windows.Forms.Button();
            this.getWriterIdButton = new System.Windows.Forms.Button();
            this.writerNameTextBox = new System.Windows.Forms.TextBox();
            this.writerIdComboBox = new System.Windows.Forms.ComboBox();
            this.writerNameLabel = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.departmentIdComboBox = new System.Windows.Forms.ComboBox();
            this.departmentNameTextBox = new System.Windows.Forms.TextBox();
            this.getDepartmentIdButton = new System.Windows.Forms.Button();
            this.requestDivisionComboBox = new System.Windows.Forms.ComboBox();
            this.requestDivisionLabel = new System.Windows.Forms.Label();
            this.requesterNameLabel = new System.Windows.Forms.Label();
            this.requesterIdComboBox = new System.Windows.Forms.ComboBox();
            this.requesterNameTextBox = new System.Windows.Forms.TextBox();
            this.getRequesterIdButton = new System.Windows.Forms.Button();
            this.workDatePicker = new System.Windows.Forms.DateTimePicker();
            this.workTimeComboBox = new System.Windows.Forms.ComboBox();
            this.restDatePicker = new System.Windows.Forms.DateTimePicker();
            this.restTimeComboBox = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(14, 238);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 0;
            this.readButton.Text = "read csv";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // getWriterIdButton
            // 
            this.getWriterIdButton.Location = new System.Drawing.Point(167, 13);
            this.getWriterIdButton.Name = "getWriterIdButton";
            this.getWriterIdButton.Size = new System.Drawing.Size(44, 23);
            this.getWriterIdButton.TabIndex = 1;
            this.getWriterIdButton.Text = "get ID";
            this.getWriterIdButton.UseVisualStyleBackColor = true;
            this.getWriterIdButton.Click += new System.EventHandler(this.GetWriterIdButton_Click);
            // 
            // writerNameTextBox
            // 
            this.writerNameTextBox.Location = new System.Drawing.Point(61, 15);
            this.writerNameTextBox.Name = "writerNameTextBox";
            this.writerNameTextBox.Size = new System.Drawing.Size(100, 19);
            this.writerNameTextBox.TabIndex = 2;
            // 
            // writerIdComboBox
            // 
            this.writerIdComboBox.FormattingEnabled = true;
            this.writerIdComboBox.Location = new System.Drawing.Point(217, 15);
            this.writerIdComboBox.Name = "writerIdComboBox";
            this.writerIdComboBox.Size = new System.Drawing.Size(76, 20);
            this.writerIdComboBox.TabIndex = 4;
            // 
            // writerNameLabel
            // 
            this.writerNameLabel.AutoSize = true;
            this.writerNameLabel.Location = new System.Drawing.Point(12, 18);
            this.writerNameLabel.Name = "writerNameLabel";
            this.writerNameLabel.Size = new System.Drawing.Size(43, 12);
            this.writerNameLabel.TabIndex = 5;
            this.writerNameLabel.Text = "担当者:";
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(12, 44);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(43, 12);
            this.departmentLabel.TabIndex = 9;
            this.departmentLabel.Text = "部署名:";
            // 
            // departmentIdComboBox
            // 
            this.departmentIdComboBox.FormattingEnabled = true;
            this.departmentIdComboBox.Location = new System.Drawing.Point(217, 41);
            this.departmentIdComboBox.Name = "departmentIdComboBox";
            this.departmentIdComboBox.Size = new System.Drawing.Size(76, 20);
            this.departmentIdComboBox.TabIndex = 8;
            // 
            // departmentNameTextBox
            // 
            this.departmentNameTextBox.Location = new System.Drawing.Point(61, 41);
            this.departmentNameTextBox.Name = "departmentNameTextBox";
            this.departmentNameTextBox.Size = new System.Drawing.Size(100, 19);
            this.departmentNameTextBox.TabIndex = 7;
            // 
            // getDepartmentIdButton
            // 
            this.getDepartmentIdButton.Location = new System.Drawing.Point(167, 39);
            this.getDepartmentIdButton.Name = "getDepartmentIdButton";
            this.getDepartmentIdButton.Size = new System.Drawing.Size(44, 23);
            this.getDepartmentIdButton.TabIndex = 6;
            this.getDepartmentIdButton.Text = "get ID";
            this.getDepartmentIdButton.UseVisualStyleBackColor = true;
            this.getDepartmentIdButton.Click += new System.EventHandler(this.GetDepartmentIdButton_Click);
            // 
            // requestDivisionComboBox
            // 
            this.requestDivisionComboBox.FormattingEnabled = true;
            this.requestDivisionComboBox.Items.AddRange(new object[] {
            "新規",
            "変更",
            "削除"});
            this.requestDivisionComboBox.Location = new System.Drawing.Point(87, 105);
            this.requestDivisionComboBox.Name = "requestDivisionComboBox";
            this.requestDivisionComboBox.Size = new System.Drawing.Size(93, 20);
            this.requestDivisionComboBox.TabIndex = 10;
            // 
            // requestDivisionLabel
            // 
            this.requestDivisionLabel.AutoSize = true;
            this.requestDivisionLabel.Location = new System.Drawing.Point(29, 108);
            this.requestDivisionLabel.Name = "requestDivisionLabel";
            this.requestDivisionLabel.Size = new System.Drawing.Size(55, 12);
            this.requestDivisionLabel.TabIndex = 11;
            this.requestDivisionLabel.Text = "申請区分:";
            // 
            // requesterNameLabel
            // 
            this.requesterNameLabel.AutoSize = true;
            this.requesterNameLabel.Location = new System.Drawing.Point(38, 145);
            this.requesterNameLabel.Name = "requesterNameLabel";
            this.requesterNameLabel.Size = new System.Drawing.Size(43, 12);
            this.requesterNameLabel.TabIndex = 15;
            this.requesterNameLabel.Text = "申請者:";
            // 
            // requesterIdComboBox
            // 
            this.requesterIdComboBox.FormattingEnabled = true;
            this.requesterIdComboBox.Location = new System.Drawing.Point(236, 142);
            this.requesterIdComboBox.Name = "requesterIdComboBox";
            this.requesterIdComboBox.Size = new System.Drawing.Size(76, 20);
            this.requesterIdComboBox.TabIndex = 14;
            // 
            // requesterNameTextBox
            // 
            this.requesterNameTextBox.Location = new System.Drawing.Point(87, 142);
            this.requesterNameTextBox.Name = "requesterNameTextBox";
            this.requesterNameTextBox.Size = new System.Drawing.Size(93, 19);
            this.requesterNameTextBox.TabIndex = 13;
            // 
            // getRequesterIdButton
            // 
            this.getRequesterIdButton.Location = new System.Drawing.Point(186, 140);
            this.getRequesterIdButton.Name = "getRequesterIdButton";
            this.getRequesterIdButton.Size = new System.Drawing.Size(44, 23);
            this.getRequesterIdButton.TabIndex = 12;
            this.getRequesterIdButton.Text = "get ID";
            this.getRequesterIdButton.UseVisualStyleBackColor = true;
            this.getRequesterIdButton.Click += new System.EventHandler(this.GetRequesterIdButton_Click);
            // 
            // workDatePicker
            // 
            this.workDatePicker.Location = new System.Drawing.Point(124, 184);
            this.workDatePicker.Name = "workDatePicker";
            this.workDatePicker.Size = new System.Drawing.Size(106, 19);
            this.workDatePicker.TabIndex = 16;
            // 
            // workTimeComboBox
            // 
            this.workTimeComboBox.FormattingEnabled = true;
            this.workTimeComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.workTimeComboBox.Items.AddRange(new object[] {
            "午前",
            "午後",
            "一日"});
            this.workTimeComboBox.Location = new System.Drawing.Point(236, 183);
            this.workTimeComboBox.Name = "workTimeComboBox";
            this.workTimeComboBox.Size = new System.Drawing.Size(76, 20);
            this.workTimeComboBox.TabIndex = 17;
            // 
            // restDatePicker
            // 
            this.restDatePicker.Location = new System.Drawing.Point(124, 209);
            this.restDatePicker.Name = "restDatePicker";
            this.restDatePicker.Size = new System.Drawing.Size(106, 19);
            this.restDatePicker.TabIndex = 20;
            // 
            // restTimeComboBox
            // 
            this.restTimeComboBox.FormattingEnabled = true;
            this.restTimeComboBox.Items.AddRange(new object[] {
            "午前",
            "午後",
            "一日"});
            this.restTimeComboBox.Location = new System.Drawing.Point(236, 208);
            this.restTimeComboBox.Name = "restTimeComboBox";
            this.restTimeComboBox.Size = new System.Drawing.Size(76, 20);
            this.restTimeComboBox.TabIndex = 22;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(322, 38);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 24;
            this.applyButton.Text = "apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.restTimeComboBox);
            this.Controls.Add(this.restDatePicker);
            this.Controls.Add(this.workTimeComboBox);
            this.Controls.Add(this.workDatePicker);
            this.Controls.Add(this.requesterNameLabel);
            this.Controls.Add(this.requesterIdComboBox);
            this.Controls.Add(this.requesterNameTextBox);
            this.Controls.Add(this.getRequesterIdButton);
            this.Controls.Add(this.requestDivisionLabel);
            this.Controls.Add(this.requestDivisionComboBox);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.departmentIdComboBox);
            this.Controls.Add(this.departmentNameTextBox);
            this.Controls.Add(this.getDepartmentIdButton);
            this.Controls.Add(this.writerNameLabel);
            this.Controls.Add(this.writerIdComboBox);
            this.Controls.Add(this.writerNameTextBox);
            this.Controls.Add(this.getWriterIdButton);
            this.Controls.Add(this.readButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button getWriterIdButton;
        private System.Windows.Forms.TextBox writerNameTextBox;
        private System.Windows.Forms.ComboBox writerIdComboBox;
        private System.Windows.Forms.Label writerNameLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.ComboBox departmentIdComboBox;
        private System.Windows.Forms.TextBox departmentNameTextBox;
        private System.Windows.Forms.Button getDepartmentIdButton;
        private System.Windows.Forms.ComboBox requestDivisionComboBox;
        private System.Windows.Forms.Label requestDivisionLabel;
        private System.Windows.Forms.Label requesterNameLabel;
        private System.Windows.Forms.ComboBox requesterIdComboBox;
        private System.Windows.Forms.TextBox requesterNameTextBox;
        private System.Windows.Forms.Button getRequesterIdButton;
        private System.Windows.Forms.DateTimePicker workDatePicker;
        private System.Windows.Forms.ComboBox workTimeComboBox;
        private System.Windows.Forms.DateTimePicker restDatePicker;
        private System.Windows.Forms.ComboBox restTimeComboBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label1;
    }
}

