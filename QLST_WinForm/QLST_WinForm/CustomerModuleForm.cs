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
    public partial class CustomerModuleForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        SqlConnection conn = new SqlConnection(@"Data Source=.\ANSERVER;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private void pnlhead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this customer ? ", "Saving Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tblCustomer VALUES(@name,@phone)", conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);

                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ResetTextBox();
                    MessageBox.Show("Customer has been successfully saved");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this customer ? ", "Updating Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand($"UPDATE tblCustomer SET cname=@name,cphone=@phone WHERE cid= {lblID.Text}", conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);

                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ResetTextBox();
                    MessageBox.Show("Customer has been successfully updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void ResetTextBox()
        {

            txtPhone.ResetText();
            txtName.ResetText();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetTextBox();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
