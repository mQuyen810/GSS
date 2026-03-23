using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace GSS
{
    public partial class LoginForm : Form
    {
        //string connStr = "Server=localhost;Database=SportStoreDB;Trusted_Connection=True;";
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
            //registerForm registerForm = new registerForm();
            this.Hide();
            //registerForm.ShowDialog();
            this.Show();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string connStr = "Server=DESKTOP-HQHA2ES\\SQLEXPRESS;Database=SportStoreDB;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {   
        try
        {
            conn.Open();

            string query = "SELECT COUNT(*) FROM Users WHERE Username=@user AND Password=@pass";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@user", txt_Login.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txt_Password.Text.Trim());

            int result = (int)cmd.ExecuteScalar();

            if (result > 0)
            {
                MessageBox.Show("Đăng nhập thành công!");

                FormMain main = new FormMain();
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
        }
            }

        }

        private void txt_Login_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
