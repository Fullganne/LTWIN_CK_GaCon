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
            this.tblProductTableAdapter1.Fill(this.imsdbDataSet1.tblProduct);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
