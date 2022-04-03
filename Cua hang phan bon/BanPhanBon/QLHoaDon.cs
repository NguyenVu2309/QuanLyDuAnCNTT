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
    public partial class QLHoaDon : Form
    {
        Connection cn = new Connection();
        public QLHoaDon()
        {
            InitializeComponent();
        }

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            getCMB();
            getData();
        }

        public void getData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cn.ketnoi);
                String sql = "select * from HoaDon";
                SqlDataAdapter adt = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adt.Fill(ds, "Hóa đơn");
                dataGridView1.DataSource = ds.Tables["Hóa đơn"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }
        public void getCMB()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cn.ketnoi);
                String sql = "select * from SanPham";
                SqlDataAdapter adt = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adt.Fill(ds, "Loại");
                comboBox1.DataSource = ds.Tables["Loại"];
                comboBox1.DisplayMember = "TenSP";
                comboBox1.ValueMember = "MaSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }
        public void Clear()
        {
            txtGia.Text = "";
            txtMaHD.Text = "";
            txtSoLuong.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHD = txtMaHD.Text;
                if (MaHD == "")
                {
                    MessageBox.Show("Không được để trống mã mã hóa đơn");
                }
                else
                {
                    string Gia = txtGia.Text;
                    string MaSP = comboBox1.SelectedValue.ToString();
                    string SoLuong = txtSoLuong.Text;
                    string NgayTao = dateTimePicker1.Value.ToString();
                    String query = "insert into HoaDon (MaHD,MaSP,SoLuong,Gia,NgayTao)" +
                        " values('" + MaHD + "','" + MaSP + "'," + SoLuong + "," + Gia + ",'" + NgayTao + "')";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    String query2 = "select count(*) from HoaDon where MaHD = '" + MaHD + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    int count = (int)cmd2.ExecuteScalar();

                    if (count == 1)
                    {
                        MessageBox.Show("Mã hóa đơn đã tồn tại");
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

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHD = txtMaHD.Text;
                if (MaHD == "")
                {
                    MessageBox.Show("Không được để trống mã mã hóa đơn");
                }
                else
                {
                    string Gia = txtGia.Text;
                    string MaSP = comboBox1.SelectedValue.ToString();
                    string SoLuong = txtSoLuong.Text;
                    string NgayTao = dateTimePicker1.Value.ToString();
                    String query = "update HoaDon set MaSP = '" + MaSP + "', SoLuong = " + SoLuong + ", Gia = " + Gia + ", NgayTao = '" + NgayTao +  "' where MaHD = '" + MaHD + "'";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    String query2 = "select count(*) from HoaDon where MaHD = '" + MaHD + "'";
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
                        MessageBox.Show("Mã hóa đơn không tồn tại");
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
                string MaHD = txtMaHD.Text;
                if (MaHD == "")
                {
                    MessageBox.Show("Không được để trống mã mã hóa đơn");
                }
                else
                {
                    String query = "delete HoaDon where MaHD = " + MaHD + "";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    String query2 = "select count(*) from HoaDon where MaHD = '" + MaHD + "'";
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
                        MessageBox.Show("Mã hóa đơn không tồn tại");
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
                string MaHD = txtMaHD.Text;
                String query = "select * from HoaDon where MaHD = '" + MaHD + "'";

                SqlConnection conn = new SqlConnection(cn.ketnoi);
                SqlDataAdapter adt = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adt.Fill(ds, "Sản phẩm");
                dataGridView1.DataSource = ds.Tables["Sản phẩm"];
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
                txtMaHD.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[index].Cells[1].Value;
                txtSoLuong.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txtGia.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            }
        }
    }
}
