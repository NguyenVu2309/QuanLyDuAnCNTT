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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                Connection cn = new Connection();
                SqlConnection conn = new SqlConnection(cn.ketnoi);
                conn.Open();

                String tk = txtTaiKhoan.Text;
                String mk = txtMatKhau.Text;
                String sql = "Select count(*) from NguoiDung where TaiKhoan = @tk and MatKhau = @mk";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@tk", tk));
                cmd.Parameters.Add(new SqlParameter("@mk", mk));

                int count = (int)cmd.ExecuteScalar();

                conn.Close();

                if (count == 1)
                {
                   MessageBox.Show("Đăng nhập thành công");
                   HeThong ht = new HeThong();
                   ht.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi: " + ex);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
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
    }
}
