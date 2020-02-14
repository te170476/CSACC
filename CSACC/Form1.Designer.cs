namespace CSACC
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
            this.readCsv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // readCsv
            // 
            this.readCsv.Location = new System.Drawing.Point(221, 178);
            this.readCsv.Name = "readCsv";
            this.readCsv.Size = new System.Drawing.Size(75, 23);
            this.readCsv.TabIndex = 0;
            this.readCsv.Text = "readCSV";
            this.readCsv.UseVisualStyleBackColor = true;
            this.readCsv.Click += new System.EventHandler(this.ReadCsv_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.readCsv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button readCsv;
    }
}

