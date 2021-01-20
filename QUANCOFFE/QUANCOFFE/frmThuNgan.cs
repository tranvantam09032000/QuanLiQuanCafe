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
    public partial class frmThuNgan : Form
    {
        public frmThuNgan()
        {
            InitializeComponent();
        }
        private void frmThuNgan_Load(object sender, EventArgs e)
        {

        }

        private void đĂNGXUẤTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDangNhap dangNhap = new frmDangNhap();
            this.Hide();
            dangNhap.Show();
        }

        private void hÓAĐƠNBÁNToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void LapHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLapHoaDonBan f = new frmLapHoaDonBan();
            f.MdiParent = this;
            f.Show();
        }

        private void CTHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmLapHoaDonNhap f = new frmLapHoaDonNhap();
            f.MdiParent = this;
            f.Show();
        }

        private void ThongTinCaNhanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmTaiKhoan f = new frmTaiKhoan();
            f.MdiParent = this;
            f.Show();
        }

        private void DoiMatKhautoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.MdiParent = this;
            f.Show();
        }

        private void BaoCaotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBaoCao f = new frmBaoCao();
            f.MdiParent = this;
            f.Show();
        }
    }
}
