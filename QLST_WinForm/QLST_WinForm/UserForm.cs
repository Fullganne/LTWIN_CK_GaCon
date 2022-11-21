using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST_WinForm
{
    public partial class UserForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\ANSERVER;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public UserForm()
        {
            InitializeComponent();
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadUser();
        }
        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tblUser", conn);
            conn.Open();
            dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i.ToString(), dr["username"].ToString(), dr["fullname"].ToString(), dr["password"].ToString(), dr["phone"].ToString());
                    
            }
            dr.Close();
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForm usermoduleform = new UserModuleForm();
            //Set button from UserModuleForm (Remember button Modifies = public) 
            usermoduleform.btnSave.Enabled = true;
            usermoduleform.btnUpdate.Enabled = false;
            usermoduleform.ShowDialog();
            LoadUser();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = dgvUser.Columns[e.ColumnIndex].Name;
            if(collname=="Edit")
            {
                UserModuleForm usermodule = new UserModuleForm();
                usermodule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                usermodule.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                usermodule.txtPassWord.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                usermodule.txtConfirmPassword.Text= dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                usermodule.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                usermodule.btnSave.Enabled=false;
                usermodule.btnUpdate.Enabled = true;
                usermodule.txtUserName.Enabled = false;
                usermodule.ShowDialog();

            }    
            else if(collname=="Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this user ?","Information",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    string user = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                    conn.Open();
                    cmd = new SqlCommand($"DELETE FROM tblUser where username = '{user}'",conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Delete Successfully");
                }    
            }
            LoadUser();
        }
    }
}
