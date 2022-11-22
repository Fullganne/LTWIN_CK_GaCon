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
    public partial class CategoriesForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd = null;
        public CategoriesForm()
        {
            InitializeComponent();
        }
        public void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            int i = 0;
            conn.Open();
            cmd = new SqlCommand("Select * from tblCategories", conn);
            rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                i++;
                dgvCategories.Rows.Add(i, rd["catid"].ToString(), rd["catname"].ToString());
            }
            rd.Close();
            conn.Close();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoriesModuleForm categoriesModule = new CategoriesModuleForm();
            categoriesModule.btnUpdate.Enabled = false;
            categoriesModule.btnSave.Enabled = true;
            categoriesModule.ShowDialog();
            LoadCategories();
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = dgvCategories.Columns[e.ColumnIndex].Name;
            if(collname=="Edit")
            {
                CategoriesModuleForm categoriesModule = new CategoriesModuleForm();
                categoriesModule.lblID.Text = dgvCategories.Rows[e.RowIndex].Cells[1].Value.ToString();
                categoriesModule.txtName.Text = dgvCategories.Rows[e.RowIndex].Cells[2].Value.ToString();
                categoriesModule.btnUpdate.Enabled = true;
                categoriesModule.btnSave.Enabled = false;
                categoriesModule.ShowDialog();
            }   
            else if(collname=="Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string idcustomer = dgvCategories.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmd = new SqlCommand($"DELETE FROM tblCategories WHERE catId='{idcustomer}'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK);
                }
            }
            LoadCategories();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
