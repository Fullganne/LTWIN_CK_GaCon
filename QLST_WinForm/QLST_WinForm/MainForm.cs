using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST_WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        // to show child form in parent form
        public Form activeForm = null;
        public void OpenChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserForm userform = new UserForm();
            OpenChildForm(userform);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            OpenChildForm(customer);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoriesForm categories = new CategoriesForm();
            OpenChildForm(categories);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            OpenChildForm(product);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderForm odr = new OrderForm();
            OpenChildForm(odr);
        }
    }   
}
