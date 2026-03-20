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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lb_dNhap_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void link_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerForm registerForm = new registerForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            FormMain productForm = new FormMain();
            this.Hide();
            productForm.ShowDialog();
            this.Show();
        }
    }
}
