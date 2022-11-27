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
    public partial class ListProductReport : Form
    {
        public ListProductReport()
        {
            InitializeComponent();
        }

        private void ListProductReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iMSDBDataSet.tblProduct' table. You can move, or remove it, as needed.
            this.tblProductTableAdapter.Fill(this.iMSDBDataSet.tblProduct);
            this.reportViewer1.RefreshReport();
        }
    }
}
