using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLST_WinForm
{
    public partial class ProductForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd = null;
        public ProductForm()
        {
            InitializeComponent();
        }
        public void LoadProduct()
        {
            dgvProducts.Rows.Clear();
            int i = 0;
            conn.Open();
            cmd = new SqlCommand($"Select * from tblProduct", conn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                i++;
                dgvProducts.Rows.Add(i, rd["pId"].ToString(), rd["pname"].ToString(), rd["pqty"].ToString(), rd["pprice"].ToString(), rd["pdescription"].ToString(), rd["pcategory"].ToString());
            }
            rd.Close();
            conn.Close();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            ProductModuleForm productModule = new ProductModuleForm();
            productModule.btnUpdate.Enabled = false;
            productModule.btnSave.Enabled = true;
            productModule.ShowDialog();
            LoadProduct();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = dgvProducts.Columns[e.ColumnIndex].Name;
            if (collname == "Edit")
            {
                ProductModuleForm productModule = new ProductModuleForm();
                productModule.lblID.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtQuantity.Text = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtdesc.Text = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.cbbcate.Text = dgvProducts.Rows[e.RowIndex].Cells[6].Value.ToString();

                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;
                productModule.ShowDialog();

            }
            else if (collname == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string idproduct = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmd = new SqlCommand($"DELETE FROM tblProduct WHERE pId='{idproduct}'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK);
                }
            }
            LoadProduct();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtSearch.Text=="")
                LoadProduct();
            else
            {
                dgvProducts.Rows.Clear();
                int i = 0;
                conn.Open();
                cmd = new SqlCommand($"Select * from tblProduct where pname like '%{txtSearch.Text}%'", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    i++;
                    dgvProducts.Rows.Add(i, rd["pId"].ToString(), rd["pname"].ToString(), rd["pqty"].ToString(), rd["pprice"].ToString(), rd["pdescription"].ToString(), rd["pcategory"].ToString());
                }
                rd.Close();
                conn.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ListProductReport ListProductReport = new ListProductReport();
            ListProductReport.Show();

        }
    }
}
