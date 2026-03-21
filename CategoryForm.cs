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

namespace GSS
{
    public partial class CategoryForm : Form
    {
        string connStr = "Server=localhost;Database=SportStoreDB;Trusted_Connection=True;";
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO Categories (CategoryName) VALUES (@name)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công!");

                LoadData();
            }
        }
        void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT CategoryID, CategoryName FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // 🔥 XÓA HẾT CỘT CŨ
                dataProduct.Columns.Clear();

                // 🔥 TỰ TẠO CỘT MỚI
                dataProduct.AutoGenerateColumns = true;

                // 🔥 GÁN DỮ LIỆU
                dataProduct.DataSource = dt;

                // 🔥 ĐỔI TÊN HIỂN THỊ
                dataProduct.Columns["CategoryID"].HeaderText = "Mã danh mục";
                dataProduct.Columns["CategoryName"].HeaderText = "Tên danh mục";
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM Categories WHERE CategoryID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtID.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công!");

                LoadData();
            }
        }

        private void dataProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
