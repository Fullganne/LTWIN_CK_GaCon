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
            this.tblCustomerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblCustomerTableAdapter = new QLST_WinForm.IMSDBDataSetTableAdapters.tblCustomerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iMSDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLST_WinForm.ListCustomerReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 11);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // tblCustomerbindingSource
            // 
            this.tblCustomerbindingSource.AllowNew = true;
            this.tblCustomerbindingSource.DataSource = this.iMSDBDataSet;
            this.tblCustomerbindingSource.Position = 0;
            // 
            // tblCustomerTableAdapter
            // 
            this.tblCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // ListCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 546);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListCustomerReport";
            this.Text = "ListCustomerReport";
            this.Load += new System.EventHandler(this.ListCustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iMSDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomerbindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private IMSDBDataSet iMSDBDataSet;
        private System.Windows.Forms.BindingSource tblCustomerbindingSource;
        private IMSDBDataSetTableAdapters.tblCustomerTableAdapter tblCustomerTableAdapter;
    }
}