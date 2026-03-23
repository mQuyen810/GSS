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

namespace GSS
{
    public partial class CustomerForm : Form
    {
        string connStr = "Server=THANG\\MANHTHANG;Database=SportStoreDB;Trusted_Connection=True;";

        public CustomerForm()
        {
            InitializeComponent();
        }

        // 📥 Load form
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // 📊 Load dữ liệu
        void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Customers";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataProduct.DataSource = dt;
            }
        }

        // ➕ THÊM (KHÔNG insert ID vì là IDENTITY)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Customers (CustomerName, Phone, Address) VALUES (@CustomerName, @Phone, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@CustomerName", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm thành công 🎉");
                LoadData();
                ClearData();
            }
        }

        // ✏️ SỬA
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Customers SET CustomerName=@CustomerName, Phone=@Phone, Address=@Address WHERE CustomerID=@CustomerID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@CustomerID", txtID.Text);
                cmd.Parameters.AddWithValue("@CustomerName", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Cập nhật thành công ✏️");
                LoadData();
                ClearData();
            }
        }

        // ❌ XÓA
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không?",
                                                 "Xác nhận",
                                                 MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@CustomerID", txtID.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Xóa thành công 💥");
                    LoadData();
                    ClearData();
                }
            }
        }

        // 🖱️ Click DataGridView → đổ dữ liệu lên textbox
        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataProduct.Rows[e.RowIndex];

                txtID.Text = row.Cells[0].Value.ToString();   // 🔥 sửa lại
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
            }
        }

        // 🧹 Xóa dữ liệu textbox
        void ClearData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
        }
    }
}
