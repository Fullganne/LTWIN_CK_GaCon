using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST_WinForm
{
    public partial class ProductModuleForm : Form
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
        public ProductModuleForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbbcate.Text == "")
            {
                MessageBox.Show("Empty category");
                return;
            }
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product ? ", "Saving Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tblProduct VALUES(@name,@quantity,@description,@category,@price)", conn);
                    cmd.Parameters.AddWithValue("@name", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@description", txtdesc.Text);
                    cmd.Parameters.AddWithValue("@category", cbbcate.Text);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
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
        public void ResetTextBox()
        {

            txtdesc.ResetText();
            txtPrice.ResetText();
            txtProductName.ResetText();
            txtQuantity.ResetText();
            cbbcate.Refresh();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(cbbcate.Text=="")
            {
                MessageBox.Show("Empty category");
                return;
            }    
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product ? ", "Updating Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand($"UPDATE tblProduct SET pname=@name,pqty=@quantity,pdescription=@description,pcategory=@category,pprice=@price WHERE pid= {lblID.Text}", conn);
                    cmd.Parameters.AddWithValue("@name", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@description", txtdesc.Text);
                    cmd.Parameters.AddWithValue("@category", cbbcate.Text);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ResetTextBox();
                    MessageBox.Show("Product has been successfully updated");
                    this.Dispose();
                }
            }
            catch (Exception ex)
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
        public void LoadcbbCategories()
        {
            cbbcate.Items.Clear();
            cmd = new SqlCommand("Select * from tblCategories", conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                cbbcate.Items.Add(rd["catName"].ToString());
            }
            rd.Close();
            conn.Close();
        }
        private void ProductModuleForm_Load(object sender, EventArgs e)
        {
            LoadcbbCategories();
        }
    }
}
