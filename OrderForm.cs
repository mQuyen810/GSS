using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSS
{
    public partial class OrderForm : Form
    {
        string connStr = "Server=localhost;Database=SportStoreDB;Trusted_Connection=True;";

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            
            dataProduct.Columns.Clear();
            dataProduct.Columns.Add("MaHoaDon", "Mã Hóa Đơn");
            dataProduct.Columns.Add("KhachHang", "Tên Khách Hàng");
            dataProduct.Columns.Add("ProductID", "Mã Sản Phẩm");
            dataProduct.Columns.Add("SanPham", "Tên Sản Phẩm");
            dataProduct.Columns.Add("SoLuong", "Số Lượng");
            dataProduct.Columns.Add("Gia", "Giá");
            dataProduct.Columns.Add("ThanhTien", "Thành Tiền");
            dataProduct.Columns.Add("NgayThanhToan", "Ngày Thanh Toán");
            dataProduct.Columns.Add("CustomerID", "CustomerID");

            dataProduct.Columns["ProductID"].Visible = false;
            dataProduct.Columns["CustomerID"].Visible = false;
            dataProduct.Columns["MaHoaDon"].Visible = false; 
            
            dataProduct.ReadOnly = true;
            dataProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadCustomers();
            LoadProducts();
        }

        private void LoadCustomers()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, CustomerName FROM Customers", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "CustomerName";
                    comboBox1.ValueMember = "CustomerID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
                }
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT ProductID, ProductName FROM Products", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "ProductName";
                    comboBox2.ValueMember = "ProductID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
                }
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataProduct.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null && decimal.TryParse(row.Cells["ThanhTien"].Value.ToString(), out decimal subTotal))
                {
                    total += subTotal;
                }
            }
            txtTotal.Text = total.ToString();
        }

        private decimal GetProductPrice(int productId)
        {
            decimal price = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Price FROM Products WHERE ProductID = @pd", conn);
                cmd.Parameters.AddWithValue("@pd", productId);
                object res = cmd.ExecuteScalar();
                if (res != null) price = Convert.ToDecimal(res);
            }
            return price;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng và sản phẩm!");
                return;
            }

            int customerId = (int)comboBox1.SelectedValue;
            string customerName = comboBox1.Text;
            int productId = (int)comboBox2.SelectedValue;
            string productName = comboBox2.Text;
            int quantity = (int)numericUpDown1.Value;
            DateTime orderDate = dateTimePicker1.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0");
                return;
            }

            decimal price = GetProductPrice(productId);
            decimal subTotal = price * quantity;

            
            bool exists = false;
            foreach (DataGridViewRow row in dataProduct.Rows)
            {
                if (row.Cells["ProductID"].Value != null && (int)row.Cells["ProductID"].Value == productId)
                {
                    int currentQty = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    row.Cells["SoLuong"].Value = currentQty + quantity;
                    row.Cells["ThanhTien"].Value = price * (currentQty + quantity);
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                dataProduct.Rows.Add("", customerName, productId, productName, quantity, price, subTotal, orderDate.ToString("yyyy-MM-dd HH:mm:ss"), customerId);
            }

            UpdateTotalAmount();
        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataProduct.Rows[e.RowIndex].Cells["ProductID"].Value != null)
            {
                try {
                    comboBox1.SelectedValue = dataProduct.Rows[e.RowIndex].Cells["CustomerID"].Value;
                    comboBox2.SelectedValue = dataProduct.Rows[e.RowIndex].Cells["ProductID"].Value;
                    numericUpDown1.Value = Convert.ToDecimal(dataProduct.Rows[e.RowIndex].Cells["SoLuong"].Value);
                    
                    if (DateTime.TryParse(dataProduct.Rows[e.RowIndex].Cells["NgayThanhToan"].Value.ToString(), out DateTime dt)) {
                        dateTimePicker1.Value = dt;
                    }
                } catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dataProduct.CurrentRow != null && dataProduct.CurrentRow.Index >= 0 && dataProduct.CurrentRow.Cells["ProductID"].Value != null)
            {
                int quantity = (int)numericUpDown1.Value;
                if (quantity <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                    return;
                }

                decimal price = Convert.ToDecimal(dataProduct.CurrentRow.Cells["Gia"].Value);
                dataProduct.CurrentRow.Cells["SoLuong"].Value = quantity;
                dataProduct.CurrentRow.Cells["ThanhTien"].Value = price * quantity;
                dataProduct.CurrentRow.Cells["KhachHang"].Value = comboBox1.Text;
                dataProduct.CurrentRow.Cells["CustomerID"].Value = comboBox1.SelectedValue;
                dataProduct.CurrentRow.Cells["NgayThanhToan"].Value = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

                UpdateTotalAmount();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (dataProduct.CurrentRow != null && !dataProduct.CurrentRow.IsNewRow)
            {
                dataProduct.Rows.Remove(dataProduct.CurrentRow);
                UpdateTotalAmount();
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            
            if (dataProduct.Rows.Count == 0 || (dataProduct.Rows.Count == 1 && dataProduct.Rows[0].IsNewRow))
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            int customerId = Convert.ToInt32(dataProduct.Rows[0].Cells["CustomerID"].Value);
            DateTime orderDate = Convert.ToDateTime(dataProduct.Rows[0].Cells["NgayThanhToan"].Value);
            decimal totalAmount = 0;
            if (decimal.TryParse(txtTotal.Text, out decimal t)) totalAmount = t;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                       
                        string insertOrder = "INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, TotalAmount) OUTPUT INSERTED.OrderID VALUES (@cID, 1, @date, @total)";
                        SqlCommand cmdOrder = new SqlCommand(insertOrder, conn, trans);
                        cmdOrder.Parameters.AddWithValue("@cID", customerId);
                        cmdOrder.Parameters.AddWithValue("@date", orderDate);
                        cmdOrder.Parameters.AddWithValue("@total", totalAmount);

                        int orderId = (int)cmdOrder.ExecuteScalar();

                        
                        foreach (DataGridViewRow row in dataProduct.Rows)
                        {
                            if (row.IsNewRow) continue;

                            int pId = Convert.ToInt32(row.Cells["ProductID"].Value);
                            int qty = Convert.ToInt32(row.Cells["SoLuong"].Value);
                            decimal price = Convert.ToDecimal(row.Cells["Gia"].Value);
                            decimal subT = Convert.ToDecimal(row.Cells["ThanhTien"].Value);

                            string insertDetail = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price, SubTotal) VALUES (@oID, @pID, @qty, @price, @subT)";
                            SqlCommand cmdDetail = new SqlCommand(insertDetail, conn, trans);
                            cmdDetail.Parameters.AddWithValue("@oID", orderId);
                            cmdDetail.Parameters.AddWithValue("@pID", pId);
                            cmdDetail.Parameters.AddWithValue("@qty", qty);
                            cmdDetail.Parameters.AddWithValue("@price", price);
                            cmdDetail.Parameters.AddWithValue("@subT", subT);
                            cmdDetail.ExecuteNonQuery();

                            
                            SqlCommand cmdUpdateQty = new SqlCommand("UPDATE Products SET Quantity = Quantity - @q WHERE ProductID = @pid", conn, trans);
                            cmdUpdateQty.Parameters.AddWithValue("@q", qty);
                            cmdUpdateQty.Parameters.AddWithValue("@pid", pId);
                            cmdUpdateQty.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Thanh toán thành công! Mã Hóa Đơn: " + orderId);

                        
                        dataProduct.Rows.Clear();
                        txtTotal.Text = "0";
                    }
                    catch (Exception exTrans)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi thanh toán: " + exTrans.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                dataProduct.Rows.Clear();
                txtTotal.Text = "0";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT o.OrderID, c.CustomerName, c.CustomerID, p.ProductID, p.ProductName, od.Quantity, od.Price, od.SubTotal, o.OrderDate
                                     FROM Orders o
                                     JOIN Customers c ON o.CustomerID = c.CustomerID
                                     JOIN OrderDetails od ON o.OrderID = od.OrderID
                                     JOIN Products p ON od.ProductID = p.ProductID
                                     WHERE CAST(o.OrderID AS VARCHAR) LIKE @kw OR c.CustomerName LIKE @kw";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataProduct.Rows.Clear();
                    dataProduct.Columns["MaHoaDon"].Visible = true; // Show OrderID when searching

                    decimal grandTotal = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataProduct.Rows.Add(
                            dr["OrderID"], 
                            dr["CustomerName"], 
                            dr["ProductID"], 
                            dr["ProductName"], 
                            dr["Quantity"], 
                            dr["Price"], 
                            dr["SubTotal"], 
                            Convert.ToDateTime(dr["OrderDate"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            dr["CustomerID"]
                        );
                        grandTotal += Convert.ToDecimal(dr["SubTotal"]);
                    }

                    txtTotal.Text = grandTotal.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                }
            }
        }

        
        private void label3_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void btnDelete_Click(object sender, EventArgs e) { }
        private void btnEdit_Click(object sender, EventArgs e) { }
        private void txtTotal_TextChanged(object sender, EventArgs e) { }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
