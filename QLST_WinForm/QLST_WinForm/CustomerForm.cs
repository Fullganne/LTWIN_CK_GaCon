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
    public partial class CustomerForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd = null;
        public CustomerForm()
        {
            InitializeComponent();
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            dgvCustomer.Rows.Clear();   
            int i = 0;
            conn.Open();
            cmd = new SqlCommand("Select * from tblCustomer", conn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i.ToString(), rd["cId"].ToString(), rd["cname"].ToString(), rd["cphone"].ToString());
            }
            rd.Close();
            conn.Close();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerModuleForm customerModule = new CustomerModuleForm();
            customerModule.btnSave.Enabled = true;
            customerModule.btnUpdate.Enabled = false;
            customerModule.ShowDialog();
            LoadCustomer();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = dgvCustomer.Columns[e.ColumnIndex].Name;
            if(collname=="Edit")
            {
                CustomerModuleForm customerModule = new CustomerModuleForm();
                customerModule.lblID.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                customerModule.txtName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customerModule.txtPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                

                customerModule.btnSave.Enabled = false;
                customerModule.btnUpdate.Enabled = true;
                customerModule.ShowDialog();
                
            }   
            else if(collname=="Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this customer","Notification",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    conn.Open();
                    string idcustomer = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmd = new SqlCommand($"DELETE FROM tblCustomer WHERE cId='{idcustomer}'",conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK);
                }    
            }
            LoadCustomer();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ListCustomerReport listCustomerReport = new ListCustomerReport();
            listCustomerReport.Show();
        }
    }
}
