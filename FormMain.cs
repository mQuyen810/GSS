using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS
{
    public partial class FormMain : Form
    {   
        public FormMain()
        {
            InitializeComponent();
        }
        Button currentBtn;
        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private void LoadForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }
        private void ActivateButton(object senderBtn)
        {
            Button clickedBtn = senderBtn as Button;

            if (clickedBtn == null) return;

            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Silver;
                currentBtn.ForeColor = Color.Black;
            }

            currentBtn = clickedBtn;
            currentBtn.BackColor = Color.FromArgb(0, 120, 215); 
            currentBtn.ForeColor = Color.White;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {   
            ActivateButton(sender);
            LoadForm(new ProductForm());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadForm(new CategoryForm());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {   
            ActivateButton(sender);
            LoadForm(new SupplierForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadForm(new CustomerForm());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadForm(new EmployeeForm());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadForm(new OrderForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
            }

            this.Close();


        }
    }
}
