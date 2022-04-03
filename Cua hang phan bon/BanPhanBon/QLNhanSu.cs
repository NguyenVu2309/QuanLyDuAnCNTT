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

namespace BanPhanBon
{
    public partial class QLNhanSu : Form
    {
        private Connection cn = new Connection();
        public QLNhanSu()
        {
            InitializeComponent();
        }

        public void getData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cn.ketnoi);
                String sql = "select * from NhanSu";
                SqlDataAdapter adt = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adt.Fill(ds, "Nhân sự");
                dataGridView1.DataSource = ds.Tables["Nhân sự"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }

        public void Clear()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtLuong.Text = "";
            txtChucVu.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txtMaNV.Text;
                if (MaNV == "")
                {
                    MessageBox.Show("Không được để trống mã sản phẩm");
                }
                else
                {
                    string TenNV = txtTenNV.Text;
                    string SDT = txtSDT.Text;
                    string Luong = txtLuong.Text;
                    string DiaChi = txtDiaChi.Text;
                    string ChucVu = txtChucVu.Text;
                    String query = "insert into NhanSu (MaNhanVien,TenNhanVien,SDT,ChucVu,Luong,DiaChi)" +
                        " values('" + MaNV + "',N'" + TenNV + "','" + SDT + "',N'" + ChucVu + "'," + Luong + ",'" + DiaChi + "')";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    String query2 = "select count(*) from NhanSu where MaNhanVien = '" + MaNV + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    int count = (int)cmd2.ExecuteScalar();

                    if (count == 1)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại");
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        getData();
                        Clear();
                        MessageBox.Show("thêm thành công");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }

        private void QLNhanSu_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txtMaNV.Text;
                if (MaNV == "")
                {
                    MessageBox.Show("Không được để trống mã sản phẩm");
                }
                else
                {
                    string TenNV = txtTenNV.Text;
                    string SDT = txtSDT.Text;
                    string Luong = txtLuong.Text;
                    string DiaChi = txtDiaChi.Text;
                    string ChucVu = txtChucVu.Text;
                    String query = "update NhanSu set TenNhanVien = N'" + TenNV + "', SDT = '" + SDT + "', ChucVu = N'" + ChucVu + "', Luong = " + Luong + ", DiaChi = N'" + DiaChi + "' where MaNhanVien = '" + MaNV + "'";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    String query2 = "select count(*) from NhanSu where MaNhanVien = '" + MaNV + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    int count = (int)cmd2.ExecuteScalar();

                    if (count == 1)
                    {
                        
                        cmd.ExecuteNonQuery();
                        getData();
                        Clear();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại tồn tại");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txtMaNV.Text;
                if (MaNV == "")
                {
                    MessageBox.Show("Không được để trống mã sản phẩm");
                }
                else
                {
                    String query = "delete NhanSu where MaNhanVien = " + MaNV + "";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    String query2 = "select count(*) from NhanSu where MaNhanVien = '" + MaNV + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    int count = (int)cmd2.ExecuteScalar();

                    if (count == 1)
                    {

                        cmd.ExecuteNonQuery();
                        getData();
                        Clear();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại tồn tại");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txtMaNV.Text;
                String query = "select * from NhanSu where MaNhanVien = '" + MaNV + "'";

                SqlConnection conn = new SqlConnection(cn.ketnoi);
                SqlDataAdapter adt = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adt.Fill(ds, "Nhân viên");
                dataGridView1.DataSource = ds.Tables["Nhân viên"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }

        private void btnLoadLai_Click(object sender, EventArgs e)
        {
            Clear();
            getData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaNV.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txtTenNV.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txtSDT.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txtChucVu.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txtLuong.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            }
        }
    }
}
