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
    public partial class QLSanPham : Form
    {
        Connection cn = new Connection();
        public QLSanPham()
        {
            InitializeComponent();
        }

        private void QLSanPham_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cn.ketnoi);
                String sql = "select * from SanPham";
                SqlDataAdapter adt = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adt.Fill(ds, "Sản phẩm");
                dataGridView1.DataSource = ds.Tables["Sản phẩm"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi" + ex.ToString());
            }
        }
        public void Clear()
        {
            txtDonGia.Text = "";
            txtMaSP.Text = "";
            txtMoTa.Text = "";
            txtSoLuongTon.Text = "";
            txtTenSP.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSP = txtMaSP.Text;
                if (MaSP == "")
                {
                    MessageBox.Show("Không được để trống mã sản phẩm");
                }
                else
                {
                    string TenSP = txtTenSP.Text;
                    string DonGia = txtDonGia.Text;
                    string MoTa = txtMoTa.Text;
                    string SoLuongTon = txtSoLuongTon.Text;
                    String query = "insert into SanPham (MaSP,TenSP,SoLuongTon,DonGia,MoTa)" +
                        " values('" + MaSP + "',N'" + TenSP + "'," + SoLuongTon + "," + DonGia + ",'" + MoTa + "')";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);


                    String query2 = "select count(*) from SanPham where MaSP = '" + MaSP + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    int count = (int)cmd2.ExecuteScalar();

                    if (count == 1)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại");
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
                string MaSP = txtMaSP.Text;
                if (MaSP == "")
                {
                    MessageBox.Show("Không được để trống mã sản phẩm");
                }
                else
                {
                    string TenSP = txtTenSP.Text;
                    string DonGia = txtDonGia.Text;
                    string MoTa = txtMoTa.Text;
                    string SLTon = txtSoLuongTon.Text;
                    String query = "update SanPham set TenSP = N'" + TenSP + "', SoLuongTon = " + SLTon + ", DonGia = " + DonGia + ", MoTa = '" + MoTa + "'  where MaSP = '" + MaSP + "'";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    String query2 = "select count(*) from SanPham where MaSP = '" + MaSP + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    int count = (int)cmd2.ExecuteScalar();

                    if (count == 1)
                    {
                        cmd.ExecuteNonQuery();
                        getData();
                        Clear();
                        MessageBox.Show("sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm không tồn tại");
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
                string MaSP = txtMaSP.Text;
                if (MaSP == "")
                {
                    MessageBox.Show("Không được để trống mã sản phẩm");
                }
                else
                {
                    String query = "delete SanPham where MaSP = '" + MaSP + "'";

                    SqlConnection conn = new SqlConnection(cn.ketnoi);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    String query2 = "select count(*) from SanPham where MaSP = '" + MaSP + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    int count = (int)cmd2.ExecuteScalar();

                    if (count == 1)
                    {
                        cmd.ExecuteNonQuery();
                        getData();
                        Clear();
                        MessageBox.Show("xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Mã sản phẩm không tồn tại");
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
                string MaSP = txtMaSP.Text;
                String query = "select * from SanPham where MaSP = '" + MaSP + "'";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSoLuongTon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaSP.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txtTenSP.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txtSoLuongTon.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txtDonGia.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txtMoTa.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            }
        }
    }
}
