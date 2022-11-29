namespace QLST_WinForm
{
    partial class CreditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lbgroupname = new System.Windows.Forms.Label();
            this.pnlhead = new System.Windows.Forms.Panel();
            this.lblname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlhead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.lbgroupname);
            this.panel1.Controls.Add(this.pnlhead);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 373);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(12, 97);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1086, 263);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "Thành viên:\n- Nguyễn Đức Ân\n- Phan Lương Thùy Dương\n- Nguyễn Trần Ánh Linh\n- Võ K" +
    "iến Phú\n- Võ Nguyễn Đình Quân";
            // 
            // lbgroupname
            // 
            this.lbgroupname.AutoSize = true;
            this.lbgroupname.Font = new System.Drawing.Font("Comic Sans MS", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgroupname.ForeColor = System.Drawing.Color.Black;
            this.lbgroupname.Location = new System.Drawing.Point(12, 53);
            this.lbgroupname.Name = "lbgroupname";
            this.lbgroupname.Size = new System.Drawing.Size(159, 31);
            this.lbgroupname.TabIndex = 1;
            this.lbgroupname.Text = "Nhóm Gà Con";
            // 
            // pnlhead
            // 
            this.pnlhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.pnlhead.Controls.Add(this.lblname);
            this.pnlhead.Location = new System.Drawing.Point(0, 0);
            this.pnlhead.Name = "pnlhead";
            this.pnlhead.Size = new System.Drawing.Size(1110, 38);
            this.pnlhead.TabIndex = 0;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.White;
            this.lblname.Location = new System.Drawing.Point(3, 1);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(146, 34);
            this.lblname.TabIndex = 8;
            this.lblname.Text = "About US!";
            // 
            // CreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 372);
            this.Controls.Add(this.panel1);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Credit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlhead.ResumeLayout(false);
            this.pnlhead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlhead;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lbgroupname;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}