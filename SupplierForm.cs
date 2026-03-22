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
    public partial class SupplierForm : Form
    {
        string connStr = "Server=DESKTOP-HQHA2ES\\SQLEXPRESS;Database=SportStoreDB;Trusted_Connection=True;";
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO Suppliers (SupplierName, Phone, Address) 
                         VALUES (@name, @phone, @address)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm nhà cung cấp thành công!");

                LoadData();

                txtID.Clear();
                txtName.Clear();
                txtPhone.Clear();
                txtAddress.Clear();
            }
        }

        void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Return original column names so code can reference columns by those names
                string query = "SELECT SupplierID, SupplierName, Phone, Address FROM Suppliers";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataSupplier.Columns.Clear();
                dataSupplier.AutoGenerateColumns = true;
                dataSupplier.DataSource = dt;

                if (dataSupplier.Columns.Contains("SupplierID"))
                    dataSupplier.Columns["SupplierID"].HeaderText = "Mã NCC";
                if (dataSupplier.Columns.Contains("SupplierName"))
                    dataSupplier.Columns["SupplierName"].HeaderText = "Tên nhà cung cấp";
                if (dataSupplier.Columns.Contains("Phone"))
                    dataSupplier.Columns["Phone"].HeaderText = "Số điện thoại";
                if (dataSupplier.Columns.Contains("Address"))
                    dataSupplier.Columns["Address"].HeaderText = "Địa chỉ";

                dataSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataSupplier.MultiSelect = false;
                dataSupplier.ReadOnly = true;

                // Clear selection so text boxes are not filled with stale data
                dataSupplier.ClearSelection();
            }
        }

        private void dataSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataSupplier.Rows[e.RowIndex];

            var idVal = row.Cells["SupplierID"].Value;
            var nameVal = row.Cells["SupplierName"].Value;
            var phoneVal = row.Cells["Phone"].Value;
            var addrVal = row.Cells["Address"].Value;

            txtID.Text = idVal != null ? idVal.ToString() : string.Empty;
            txtName.Text = nameVal != null ? nameVal.ToString() : string.Empty;
            txtPhone.Text = phoneVal != null ? phoneVal.ToString() : string.Empty;
            txtAddress.Text = addrVal != null ? addrVal.ToString() : string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Prefer selected row
            int id;
            if (dataSupplier.SelectedRows != null && dataSupplier.SelectedRows.Count > 0)
            {
                var sel = dataSupplier.SelectedRows[0];
                var cell = sel.Cells["SupplierID"].Value;
                if (cell == null || !int.TryParse(cell.ToString(), out id))
                {
                    MessageBox.Show("ID nhà cung cấp không hợp lệ.");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out id))
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!");
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

                    string query = "DELETE FROM Suppliers WHERE SupplierID=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                        MessageBox.Show("Xóa thành công!");
                    else
                        MessageBox.Show("Không tìm thấy nhà cung cấp hoặc đã bị xóa.");

                    LoadData();

                    txtID.Clear();
                    txtName.Clear();
                    txtPhone.Clear();
                    txtAddress.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("ID nhà cung cấp không hợp lệ!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"UPDATE Suppliers 
                         SET SupplierName=@name, Phone=@phone, Address=@address
                         WHERE SupplierID=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                    int affected = cmd.ExecuteNonQuery();

                    if (affected > 0)
                        MessageBox.Show("Cập nhật thành công!");
                    else
                        MessageBox.Show("Cập nhật thất bại: không tìm thấy nhà cung cấp.");

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
