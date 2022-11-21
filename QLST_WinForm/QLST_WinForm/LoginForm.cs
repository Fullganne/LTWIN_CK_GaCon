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
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\ANSERVER;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd = null;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void chkHienmk_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHienmk.Checked) txtMatKhau.UseSystemPasswordChar = false;
            else txtMatKhau.UseSystemPasswordChar = true; 
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblRefresh_Click(object sender, EventArgs e)
        {
            
            txtMatKhau.ResetText();
            txtTenDangNhap.ResetText();
        }

        private void lblRefresh_MouseHover(object sender, EventArgs e)
        {
            lblRefresh.ForeColor = Color.FromArgb(194, 125, 1);
        }

        private void lblRefresh_MouseLeave(object sender, EventArgs e)
        {
            lblRefresh.ForeColor = Color.Orange;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtMatKhau.Text=="" || txtTenDangNhap.Text=="")
            {
                lblnoti.Visible = true;
                lblnoti.Text = "Fill full infor please !";
            }
            else
            {
                bool flag= false;
                string tk = txtTenDangNhap.Text.Trim();
                string mk = txtMatKhau.Text.Trim();
                conn.Open();
                cmd = new SqlCommand("Select * from tblUser", conn);
                rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    if (tk == rd["username"].ToString() && mk == rd["password"].ToString())
                    {
                        flag = true;
                        txtMatKhau.ResetText();
                        txtTenDangNhap.ResetText();
                    }
                }
                rd.Close();
                conn.Close();
                if(!flag)
                {
                    lblnoti.Visible = true;
                    lblnoti.Text = "User name or pasword is not correct !";
                }
                else
                {
                    MainForm m = new MainForm();
                    m.ShowDialog();
                }
            }
        }

        private void txtTenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblnoti.Visible = false;
        }
    }
}
