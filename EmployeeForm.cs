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
    public partial class EmployeeForm : Form
    {
        string connStr = "Server=THANG\\MANHTHANG;Database=SportStoreDB;Trusted_Connection=True;";

        public EmployeeForm()
        {
            InitializeComponent();
        }

        // 📥 Load form
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadData();
            txtID.Enabled = false; // không cho nhập ID
        }

        // 📊 Load dữ liệu
        void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Employees";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataProduct.AutoGenerateColumns = true;
                dataProduct.DataSource = null;
                dataProduct.DataSource = dt;
            }
        }

        // ➕ THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Employees (EmployeeName, Phone, Address) VALUES (@Name, @Phone, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
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
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Employees SET EmployeeName=@Name, Phone=@Phone, Address=@Address WHERE EmployeeID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
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
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?",
                                                 "Xác nhận",
                                                 MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "DELETE FROM Employees WHERE EmployeeID=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", txtID.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Xóa thành công 💥");
                    LoadData();
                    ClearData();
                }
            }
        }

        // 🖱️ Click DataGridView
        private void dataEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
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

        // 🧹 Clear dữ liệu
        void ClearData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
        }
    }
}
