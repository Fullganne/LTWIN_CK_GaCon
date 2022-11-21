namespace QLST_WinForm
{
    partial class ListCustomerReport
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
            this.tblCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblCustomerTableAdapter = new QLST_WinForm.IMSDBDataSetTableAdapters.tblCustomerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblCustomerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLST_WinForm.ListCustomerReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(11, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(827, 523);
            this.reportViewer1.TabIndex = 0;
            // 
            // iMSDBDataSet
            // 
            this.iMSDBDataSet.DataSetName = "IMSDBDataSet";
            this.iMSDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblCustomerBindingSource
            // 
            this.tblCustomerBindingSource.DataMember = "tblCustomer";
            this.tblCustomerBindingSource.DataSource = this.iMSDBDataSet;
            // 
            // tblCustomerTableAdapter
            // 
            this.tblCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // ListCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 547);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ListCustomerReport";
            this.Text = "ListCustomerReport";
            this.Load += new System.EventHandler(this.ListCustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private IMSDBDataSet iMSDBDataSet;
        private System.Windows.Forms.BindingSource tblCustomerBindingSource;
        private IMSDBDataSetTableAdapters.tblCustomerTableAdapter tblCustomerTableAdapter;
    }
}