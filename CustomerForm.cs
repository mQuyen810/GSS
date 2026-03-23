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
       // string connStr = "Server=THANG\\MANHTHANG;Database=SportStoreDB;Trusted_Connection=True;";
        string connStr = "Server=localhost;Database=SportStoreDB;Trusted_Connection=True;";

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadData();
            txtID.Enabled = false;
            // wire search events
            btnSearch.Click += BtnSearch_Click;
            textBox1.KeyDown += TextBox1_KeyDown;
        }

        void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadData(textBox1.Text);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadData(textBox1.Text);
            }
        }

        void LoadData(string nameFilter = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Customers";
                if (!string.IsNullOrWhiteSpace(nameFilter))
                {
                    query += " WHERE CustomerName LIKE @Name";
                }
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrWhiteSpace(nameFilter))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Name", "%" + nameFilter.Trim() + "%");
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataProduct.Columns.Clear();
                dataProduct.AutoGenerateColumns = true;
                dataProduct.DataSource = dt;
                dataProduct.Columns["CustomerID"].HeaderText = "Mã khách hàng";
                dataProduct.Columns["CustomerName"].HeaderText = "Tên khách hàng";
                dataProduct.Columns["Phone"].HeaderText = "Số điện thoại";
                dataProduct.Columns["Address"].HeaderText = "Địa chỉ";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                return;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
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

                MessageBox.Show("Thêm thành công!");
                LoadData();
                ClearData();
            }
        }

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

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
                ClearData();
            }
        }

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

                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearData();
                }
            }
        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataProduct.Rows[e.RowIndex];

                txtID.Text = row.Cells[0].Value.ToString();  
                txtName.Text = row.Cells[1].Value.ToString();
                txtPhone.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
            }
        }

        void ClearData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
        }
    }
}
