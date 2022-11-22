using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLST_WinForm
{
    public partial class CategoriesModuleForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        private void pnlhead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public CategoriesModuleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this category ? ", "Saving Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tblCategories VALUES(@name)", conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ResetTextBox();
                    MessageBox.Show("Category has been successfully saved");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this category ? ", "Updating Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand($"UPDATE tblCategories SET catname=@name  WHERE catid= {lblID.Text}", conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);

                    
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

        private void CategoriesModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
 