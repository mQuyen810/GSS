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
    public partial class ProductForm : Form
    {
        //string connStr = "Server=DESKTOP-HQHA2ES\\SQLEXPRESS;Database=SportStoreDB;Trusted_Connection=True;";
        string connStr = "Server=localhost;Database=SportStoreDB;Trusted_Connection=True;";
        public ProductForm()
        {
            InitializeComponent();
        }

        private void lbProduct_Click(object sender, EventArgs e)
        {

        }

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadSuppliers();
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return;
            }

            if (cbCategory.SelectedValue == null || !int.TryParse(cbCategory.SelectedValue.ToString(), out int categoryId))
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!");
                return;
            }

            if (cbSupplier.SelectedValue == null || !int.TryParse(cbSupplier.SelectedValue.ToString(), out int supplierId))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá không hợp lệ!");
                return;
            }

            int qty = Convert.ToInt32(numQuantity.Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO Products (ProductName, CategoryID, SupplierID, Price, Quantity) VALUES (@name, @cat, @sup, @price, @qty)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@cat", categoryId);
                        cmd.Parameters.AddWithValue("@sup", supplierId);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@qty", qty);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm sản phẩm thành công!");
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return;
            }

            if (cbCategory.SelectedValue == null || !int.TryParse(cbCategory.SelectedValue.ToString(), out int categoryId))
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!");
                return;
            }

            if (cbSupplier.SelectedValue == null || !int.TryParse(cbSupplier.SelectedValue.ToString(), out int supplierId))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá không hợp lệ!");
                return;
            }

            int qty = Convert.ToInt32(numQuantity.Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE Products SET ProductName=@name, CategoryID=@cat, SupplierID=@sup, Price=@price, Quantity=@qty WHERE ProductID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@cat", categoryId);
                        cmd.Parameters.AddWithValue("@sup", supplierId);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@id", id);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected >0)
                            MessageBox.Show("Cập nhật sản phẩm thành công!");
                        else
                            MessageBox.Show("Cập nhật thất bại: không tìm thấy sản phẩm.");
                    }
                }

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (dataProduct.SelectedRows != null && dataProduct.SelectedRows.Count >0)
            {
                var sel = dataProduct.SelectedRows[0];
                var cell = sel.Cells["ID"].Value;
                if (cell == null || !int.TryParse(cell.ToString(), out id))
                {
                    MessageBox.Show("ID sản phẩm không hợp lệ.");
                    return;
                }
            }
            else
            {
                if (!int.TryParse(txtID.Text, out id))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa!");
                    return;
                }
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Products WHERE ProductID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int affected = cmd.ExecuteNonQuery();
                        if (affected >0)
                            MessageBox.Show("Xóa sản phẩm thành công!");
                        else
                            MessageBox.Show("Xóa thất bại: không tìm thấy sản phẩm.");
                    }
                }

                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        private void dataProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <0) return;

            var row = dataProduct.Rows[e.RowIndex];

            txtID.Text = row.Cells["ID"].Value?.ToString() ?? string.Empty;
            txtName.Text = row.Cells["nameProduct"].Value?.ToString() ?? string.Empty;

            if (int.TryParse(row.Cells["ID"].Value?.ToString(), out int productId))
            {
                PopulateInputsFromProduct(productId);
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT p.ProductID, p.ProductName, c.CategoryName, p.Price, p.Quantity, s.SupplierName
                                FROM Products p
                                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                                LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataProduct.Columns.Clear();
                dataProduct.AutoGenerateColumns = true;
                dataProduct.DataSource = dt;

                if (dataProduct.Columns.Contains("ID"))
                    dataProduct.Columns["ID"].HeaderText = "Mã SP";
                if (dataProduct.Columns.Contains("ProductName"))
                    dataProduct.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                if (dataProduct.Columns.Contains("CategoryName"))
                    dataProduct.Columns["CategoryName"].HeaderText = "Loại sản phẩm";
                if (dataProduct.Columns.Contains("Price"))
                    dataProduct.Columns["Price"].HeaderText = "Giá";
                if (dataProduct.Columns.Contains("Quantity"))
                    dataProduct.Columns["Quantity"].HeaderText = "Số lượng";
                if (dataProduct.Columns.Contains("SupplierName"))
                    dataProduct.Columns["SupplierName"].HeaderText = "Nhà cung cấp";

                dataProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataProduct.MultiSelect = false;
                dataProduct.ReadOnly = true;

                dataProduct.ClearSelection();
            }
        }

        private void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT CategoryID, CategoryName FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryID";
                cbCategory.DataSource = dt;
                cbCategory.SelectedIndex = -1;
            }
        }

        private void LoadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT SupplierID, SupplierName FROM Suppliers";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbSupplier.DisplayMember = "SupplierName";
                cbSupplier.ValueMember = "SupplierID";
                cbSupplier.DataSource = dt;
                cbSupplier.SelectedIndex = -1;
            }
        }

        private void PopulateInputsFromProduct(int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT ProductName, CategoryID, SupplierID, Price, Quantity FROM Products WHERE ProductID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                txtName.Text = r["ProductName"]?.ToString() ?? string.Empty;
                                object cat = r["CategoryID"];
                                object sup = r["SupplierID"];
                                if (cat != DBNull.Value && cat != null)
                                    cbCategory.SelectedValue = Convert.ToInt32(cat);
                                else
                                    cbCategory.SelectedIndex = -1;

                                if (sup != DBNull.Value && sup != null)
                                    cbSupplier.SelectedValue = Convert.ToInt32(sup);
                                else
                                    cbSupplier.SelectedIndex = -1;

                                txtPrice.Text = r["Price"]?.ToString() ?? string.Empty;
                                numQuantity.Value = r["Quantity"] != DBNull.Value ? Convert.ToDecimal(r["Quantity"]) :0;
                                txtID.Text = productId.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc dữ liệu sản phẩm: " + ex.Message);
            }
        }

        private void ClearInputs()
        {
            txtID.Clear();
            txtName.Clear();
            txtPrice.Clear();
            numQuantity.Value =0;
            cbCategory.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
