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
using System.Runtime.InteropServices;

namespace QLST_WinForm
{
    public partial class UserModuleForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd= new SqlCommand();
        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPassWord.Text!=txtConfirmPassword.Text)
            {
                MessageBox.Show("Password is not matched", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }    
            try
            {
                if(MessageBox.Show("Are you sure you want to save this user ? ","Saving Record",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tblUser(username,fullname,password,phone) VALUES(@username,@fullname,@password,@phone)",conn);
                    cmd.Parameters.AddWithValue("@username",txtUserName.Text);
                    cmd.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassWord.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ResetTextBox();
                    MessageBox.Show("User has been successfully saved");
                    this.Dispose();
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetTextBox();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        public void ResetTextBox()
        {
            txtFullName.ResetText();
            txtPassWord.ResetText();
            txtPhone.ResetText();
            txtUserName.ResetText();
            txtConfirmPassword.ResetText();
        }

        private void pnlhead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassWord.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password is not matched", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (MessageBox.Show("Are you sure you want to update this user ? ", "Updating Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand($"UPDATE tblUser SET fullname=@fullname,password=@password,phone=@phone where username='{txtUserName.Text}'",conn);
                    
                    cmd.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassWord.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ResetTextBox();
                    MessageBox.Show("User has been successfully updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
