using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST_WinForm
{
    public partial class ListCustomerReport : Form
    {
        public ListCustomerReport()
        {
            InitializeComponent();
        }

        private void ListCustomerReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iMSDBDataSet.tblCustomer' table. You can move, or remove it, as needed.
            this.tblCustomerTableAdapter.Fill(this.iMSDBDataSet.tblCustomer);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
