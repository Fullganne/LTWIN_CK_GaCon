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
    public partial class OrderForm : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=.\ANSERVER;Initial Catalog=IMSDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd = null;
        public OrderForm()
        {
            InitializeComponent();

        }
        public void LoadOrder()
        {
            dgvOrder.Rows.Clear();
            int i = 0;
            int sum = 0;
            conn.Open();
            cmd = new SqlCommand($"SELECT * FROM tblOrder AS O Join tblCustomer AS C ON O.cID = C.cId JOIN tblProduct AS P On P.pID=O.pID", conn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, rd["oId"].ToString(), Convert.ToDateTime(rd["odate"].ToString()).ToString("dd/MM/yyyy"), rd["pID"].ToString(), rd["pname"].ToString(), rd["cID"].ToString(), rd["cname"].ToString(), rd["qty"].ToString(), rd["price"].ToString(), rd["total"].ToString());
                sum += int.Parse(rd["total"].ToString());
            }
            rd.Close();
            conn.Close();
            lblQty.Text = i.ToString();
            lblTotal.Text = sum.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm orderModule = new OrderModuleForm();
            orderModule.btnInsert.Enabled = true;
            orderModule.ShowDialog();
            LoadOrder();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = dgvOrder.Columns[e.ColumnIndex].Name;
            if (collname == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Order", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string idOrder = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string idproduct = dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int qtyorder = int.Parse(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString());
                    int quantitmaxofproduct = -1;
                    cmd = new SqlCommand($"DELETE FROM tblOrder WHERE oId='{idOrder}'", conn);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand($"Select pqty from tblProduct where pID={idproduct}", conn);
                    rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        quantitmaxofproduct = int.Parse(rd[0].ToString());
                    }
                    rd.Close();
                    cmd = new SqlCommand($"UPDATE tblProduct SET pqty= {qtyorder + quantitmaxofproduct} where pID= {idproduct} ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Delete successfully", "Notification", MessageBoxButtons.OK);
                }
            }
            LoadOrder();
        }

        private void txtOrderSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtOrderSearch.Text != "")
            {
                /*where concat(O.oId, O.odate, O.pId, P.pname, C.cname, O.qty, O.price) LIKE '%{txtOrderSearch.Text}%'*/
                dgvOrder.Rows.Clear();
                int i = 0;
                conn.Open();
                cmd = new SqlCommand($"SELECT * FROM tblOrder AS O Join tblCustomer AS C ON O.cID = C.cId JOIN tblProduct AS P On P.pID=O.pID where P.pID LIKE '%{txtOrderSearch.Text}%' or C.cname LIKE '%{txtOrderSearch.Text}%'", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    i++;
                    dgvOrder.Rows.Add(i, rd["oId"].ToString(), Convert.ToDateTime(rd["odate"].ToString()).ToString("dd/MM/yyyy"), rd["pID"].ToString(), rd["pname"].ToString(), rd["cID"].ToString(), rd["cname"].ToString(), rd["qty"].ToString(), rd["price"].ToString(), rd["total"].ToString());
                }
                rd.Close();
                conn.Close();
                lblQty.Text = i.ToString();
                if (txtOrderSearch.Text == "")
                {
                    LoadOrder();
                }
            }
            else
            {
                LoadOrder();
            }
        }
    }
}
