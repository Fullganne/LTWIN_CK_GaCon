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
    public partial class OrderModuleForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd = null;
        public static int qty = 0;
        public OrderModuleForm()
        {
            InitializeComponent();
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
                dgvCustomer.Rows.Add(i.ToString(), rd["cid"].ToString(), rd["cname"].ToString(), rd["cphone"].ToString());
            }
            rd.Close();
            conn.Close();


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
        private void OrderModuleForm_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadProduct();
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pnlhead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void txtSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearchProduct.Text == "")
                LoadProduct();
            else
            {
                dgvProducts.Rows.Clear();
                int i = 0;
                conn.Open();
                cmd = new SqlCommand($"Select * from tblProduct where pname like '%{txtSearchProduct.Text}%'", conn);
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

        private void txtSearchCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearchCustomer.Text == "")
            {
                LoadCustomer();
            }
            else
            {
                dgvCustomer.Rows.Clear();
                int i = 0;
                conn.Open();
                cmd = new SqlCommand($"Select * from tblCustomer where cname like '%{txtSearchCustomer.Text}%'", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    i++;
                    dgvCustomer.Rows.Add(i, rd["cid"].ToString(), rd["cname"].ToString());
                }
                rd.Close();
                conn.Close();
            }


        }


        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCustomerID.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductID.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void nudquantity_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if (txtPrice.Text != "")
                txtTotal.Text = (int.Parse(nudquantity.Value.ToString()) * int.Parse(txtPrice.Text.ToString())).ToString();
            if (int.Parse(nudquantity.Value.ToString()) > qty)
            {
                nudquantity.Value -= 1;
                MessageBox.Show("Not enough quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text == "" || txtCustomerName.Text == "")
            {
                MessageBox.Show("Customer is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtProductID.Text == "")
            {
                MessageBox.Show("Product is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudquantity.Value == 0)
            {
                MessageBox.Show("Quantiy have to greater 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (MessageBox.Show("Are you sure you want to insert this order ? ", "Inserting Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tblOrder VALUES(@date,@pID,@cID,@qty,@price,@total)", conn);
                    cmd.Parameters.AddWithValue("@date", dtpkDate.Text);
                    cmd.Parameters.AddWithValue("@pID", int.Parse(txtProductID.Text));
                    cmd.Parameters.AddWithValue("@cID", int.Parse(txtCustomerID.Text));
                    cmd.Parameters.AddWithValue("@qty", int.Parse(nudquantity.Value.ToString()));
                    cmd.Parameters.AddWithValue("@price", int.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@total", int.Parse(txtPrice.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand($"UPDATE tblProduct SET pqty= {qty - int.Parse(nudquantity.Value.ToString())} where pID= {txtProductID.Text} ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ResetTextBox();
                    MessageBox.Show("Order has been successfully Inserted");
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
            txtCustomerID.ResetText();
            txtCustomerName.ResetText();
            txtProductID.ResetText();
            txtProductName.ResetText();
            txtPrice.ResetText();
            txtTotal.ResetText();
            nudquantity.Value = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetTextBox();
            btnInsert.Enabled = true;
            
        }

        public void GetQty()
        {
            cmd = new SqlCommand($"Select pqty from tblProduct where pid = '{txtProductID.Text}' ", conn);
            conn.Open();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                qty = int.Parse(rd[0].ToString());
            }
            rd.Close();

            conn.Close();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
