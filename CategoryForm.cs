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
        string connStr = "Server=DESKTOP-HQHA2ES\\SQLEXPRESS;Database=SportStoreDB;Trusted_Connection=True;";
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "INSERT INTO Categories (CategoryName) VALUES (@name)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công!");

                LoadData();
                txtName.Clear();
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
                dataProduct.Columns.Clear();
                dataProduct.AutoGenerateColumns = true;
                dataProduct.DataSource = dt;

                if (dataProduct.Columns.Contains("CategoryID"))
                    dataProduct.Columns["CategoryID"].HeaderText = "Mã danh mục";
                if (dataProduct.Columns.Contains("CategoryName"))
                    dataProduct.Columns["CategoryName"].HeaderText = "Tên danh mục";

                dataProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataProduct.MultiSelect = false;
                dataProduct.ReadOnly = true;

                dataProduct.ClearSelection();
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataProduct.Rows[e.RowIndex];

            var idVal = row.Cells["CategoryID"].Value;
            var nameVal = row.Cells["CategoryName"].Value;

            txtID.Text = idVal != null ? idVal.ToString() : string.Empty;
            txtName.Text = nameVal != null ? nameVal.ToString() : string.Empty;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (dataProduct.SelectedRows != null && dataProduct.SelectedRows.Count > 0)
            {
                var sel = dataProduct.SelectedRows[0];
                var cell = sel.Cells["CategoryID"].Value;
                if (cell == null || !int.TryParse(cell.ToString(), out id))
                {
                    MessageBox.Show("ID danh mục không hợp lệ.");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out id))
                {
                    MessageBox.Show("Vui lòng chọn danh mục!");
                    return;
                }
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "DELETE FROM Categories WHERE CategoryID=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                        MessageBox.Show("Xóa thành công!");
                    else
                        MessageBox.Show("Không tìm thấy danh mục hoặc đã bị xóa.");

                    LoadData();
                    txtID.Clear();
                    txtName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void dataProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống!");
                return;
            }

            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("ID danh mục không hợp lệ.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "UPDATE Categories SET CategoryName=@name WHERE CategoryID=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                        MessageBox.Show("Cập nhật thành công!");
                    else
                        MessageBox.Show("Cập nhật thất bại: không tìm thấy danh mục.");

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }
    }
}
