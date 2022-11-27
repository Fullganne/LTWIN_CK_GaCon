namespace QLST_WinForm
{
    partial class ListProductReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.iMSDBDataSet = new QLST_WinForm.IMSDBDataSet();
            this.tblProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblProductTableAdapter = new QLST_WinForm.IMSDBDataSetTableAdapters.tblProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblProductBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLST_WinForm.ListProductReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(7, 7);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1058, 542);
            this.reportViewer1.TabIndex = 0;
            // 
            // iMSDBDataSet
            // 
            this.iMSDBDataSet.DataSetName = "IMSDBDataSet";
            this.iMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblProductBindingSource
            // 
            this.tblProductBindingSource.DataMember = "tblProduct";
            this.tblProductBindingSource.DataSource = this.iMSDBDataSet;
            // 
            // tblProductTableAdapter
            // 
            this.tblProductTableAdapter.ClearBeforeFill = true;
            // 
            // ListProductReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListProductReport";
            this.Text = "ListProductReport";
            this.Load += new System.EventHandler(this.ListProductReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProductBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private IMSDBDataSet iMSDBDataSet;
        private System.Windows.Forms.BindingSource tblProductBindingSource;
        private IMSDBDataSetTableAdapters.tblProductTableAdapter tblProductTableAdapter;
    }
}