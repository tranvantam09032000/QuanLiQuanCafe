using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANCOFFE
{
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangNhap = new frmDangNhap();
            this.Hide();
            dangNhap.Show();
        }

        private void sanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham f = new frmSanPham();
            f.MdiParent = this;
            f.Show();
        }

        private void tHÔNGTINCÁNHÂNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan f = new frmTaiKhoan();
            f.MdiParent = this;
            f.Show();
        }

        private void qUẢNLÝNHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmQuanLyNhanVien f = new frmQuanLyNhanVien();
            f.MdiParent = this;
            f.Show();
        }

        private void HoaDonBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonBan f = new frmHoaDonBan();
            f.MdiParent = this;
            f.Show();
        }

        private void HoaDonNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmHoaDonNhap f = new frmHoaDonNhap();
            f.MdiParent = this;
            f.Show();
        }

        private void DoiMatKhauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.MdiParent = this;
            f.Show();
        }
    }
}
