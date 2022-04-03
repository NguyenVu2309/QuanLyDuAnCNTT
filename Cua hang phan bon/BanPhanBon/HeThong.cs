using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanPhanBon
{
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLHoaDon hd = new QLHoaDon();
            hd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLNhanSu hd = new QLNhanSu();
            hd.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLSanPham hd = new QLSanPham();
            hd.Show();
        }
    }
}
