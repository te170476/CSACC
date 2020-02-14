namespace CSACC2
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
            this.addButton = new System.Windows.Forms.Button();
            this.employeeBox = new System.Windows.Forms.GroupBox();
            this.divisionBox = new System.Windows.Forms.GroupBox();
            this.divisionTextBox = new System.Windows.Forms.TextBox();
            this.workPlanBox = new System.Windows.Forms.GroupBox();
            this.workPlanTextBox = new System.Windows.Forms.TextBox();
            this.restPlanBox = new System.Windows.Forms.GroupBox();
            this.restPlanTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.employeeNameBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.employeeBox.SuspendLayout();
            this.divisionBox.SuspendLayout();
            this.workPlanBox.SuspendLayout();
            this.restPlanBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(398, 283);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // employeeBox
            // 
            this.employeeBox.Controls.Add(this.button1);
            this.employeeBox.Controls.Add(this.employeeNameBox);
            this.employeeBox.Controls.Add(this.textBox1);
            this.employeeBox.Location = new System.Drawing.Point(282, 75);
            this.employeeBox.Name = "employeeBox";
            this.employeeBox.Size = new System.Drawing.Size(242, 38);
            this.employeeBox.TabIndex = 5;
            this.employeeBox.TabStop = false;
            this.employeeBox.Text = "社員";
            // 
            // divisionBox
            // 
            this.divisionBox.Controls.Add(this.divisionTextBox);
            this.divisionBox.Location = new System.Drawing.Point(273, 149);
            this.divisionBox.Name = "divisionBox";
            this.divisionBox.Size = new System.Drawing.Size(200, 35);
            this.divisionBox.TabIndex = 6;
            this.divisionBox.TabStop = false;
            this.divisionBox.Text = "部署";
            // 
            // divisionTextBox
            // 
            this.divisionTextBox.Location = new System.Drawing.Point(94, 10);
            this.divisionTextBox.Name = "divisionTextBox";
            this.divisionTextBox.Size = new System.Drawing.Size(100, 19);
            this.divisionTextBox.TabIndex = 1;
            // 
            // workPlanBox
            // 
            this.workPlanBox.Controls.Add(this.workPlanTextBox);
            this.workPlanBox.Location = new System.Drawing.Point(273, 190);
            this.workPlanBox.Name = "workPlanBox";
            this.workPlanBox.Size = new System.Drawing.Size(200, 35);
            this.workPlanBox.TabIndex = 6;
            this.workPlanBox.TabStop = false;
            this.workPlanBox.Text = "休日出勤届";
            // 
            // workPlanTextBox
            // 
            this.workPlanTextBox.Location = new System.Drawing.Point(94, 10);
            this.workPlanTextBox.Name = "workPlanTextBox";
            this.workPlanTextBox.Size = new System.Drawing.Size(100, 19);
            this.workPlanTextBox.TabIndex = 1;
            // 
            // restPlanBox
            // 
            this.restPlanBox.Controls.Add(this.restPlanTextBox);
            this.restPlanBox.Location = new System.Drawing.Point(273, 231);
            this.restPlanBox.Name = "restPlanBox";
            this.restPlanBox.Size = new System.Drawing.Size(200, 35);
            this.restPlanBox.TabIndex = 6;
            this.restPlanBox.TabStop = false;
            this.restPlanBox.Text = "振替休日届";
            // 
            // restPlanTextBox
            // 
            this.restPlanTextBox.Location = new System.Drawing.Point(94, 10);
            this.restPlanTextBox.Name = "restPlanTextBox";
            this.restPlanTextBox.Size = new System.Drawing.Size(100, 19);
            this.restPlanTextBox.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(3, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 19);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "id";
            // 
            // employeeNameBox
            // 
            this.employeeNameBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.employeeNameBox.Location = new System.Drawing.Point(72, 15);
            this.employeeNameBox.Name = "employeeNameBox";
            this.employeeNameBox.Size = new System.Drawing.Size(119, 19);
            this.employeeNameBox.TabIndex = 4;
            this.employeeNameBox.Text = "name";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(191, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "決定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.divisionBox);
            this.Controls.Add(this.workPlanBox);
            this.Controls.Add(this.restPlanBox);
            this.Controls.Add(this.employeeBox);
            this.Controls.Add(this.addButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.employeeBox.ResumeLayout(false);
            this.employeeBox.PerformLayout();
            this.divisionBox.ResumeLayout(false);
            this.divisionBox.PerformLayout();
            this.workPlanBox.ResumeLayout(false);
            this.workPlanBox.PerformLayout();
            this.restPlanBox.ResumeLayout(false);
            this.restPlanBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox employeeBox;
        private System.Windows.Forms.GroupBox divisionBox;
        private System.Windows.Forms.TextBox divisionTextBox;
        private System.Windows.Forms.GroupBox workPlanBox;
        private System.Windows.Forms.TextBox workPlanTextBox;
        private System.Windows.Forms.GroupBox restPlanBox;
        private System.Windows.Forms.TextBox restPlanTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox employeeNameBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

