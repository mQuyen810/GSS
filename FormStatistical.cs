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
    public partial class FormStatistical : Form
    {
        string connStr = "Server=localhost;Database=SportStoreDB;Trusted_Connection=True;";

        public FormStatistical()
        {
            InitializeComponent();
            this.Load += FormStatistical_Load;
        }

        private void FormStatistical_Load(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadRecentOrders();
        }

        private void LoadStatistics()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    labelDonHang.Text = GetCount(conn, "Orders").ToString();
                    labelNhanVien.Text = GetCount(conn, "Employees").ToString();
                    labelSanPham.Text = GetCount(conn, "Products").ToString();
                    labelLoaiSp.Text = GetCount(conn, "Categories").ToString();
                    labelNCC.Text = GetCount(conn, "Suppliers").ToString();
                    labelKhachHang.Text = GetCount(conn, "Customers").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu thống kê: " + ex.Message);
                }
            }
        }

        private void LoadRecentOrders()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    
                    string query = @"SELECT o.OrderDate as Ngay, c.CustomerName as KhachHang, o.OrderID as MaHD, o.TotalAmount as TongTien 
                                     FROM Orders o
                                     JOIN Customers c ON o.CustomerID = c.CustomerID
                                     ORDER BY o.OrderDate DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(
                            Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy HH:mm"), 
                            row["KhachHang"],
                            row["MaHD"], 
                            row["TongTien"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách đơn hàng: " + ex.Message);
                }
            }
        }

        private int GetCount(SqlConnection conn, string tableName)
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void labelDonHang_Click(object sender, EventArgs e)
        {

        }

        private void labelNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void labelSanPham_Click(object sender, EventArgs e)
        {

        }

        private void labelLoaiSp_Click(object sender, EventArgs e)
        {

        }

        private void labelNCC_Click(object sender, EventArgs e)
        {

        }

        private void labelKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void FormStatistical_Load_1(object sender, EventArgs e)
        {

        }
    }
}
