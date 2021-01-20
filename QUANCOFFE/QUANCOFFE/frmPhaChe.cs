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
    public partial class frmPhaChe : Form
    {
        public frmPhaChe()
        {
            InitializeComponent();
        }

        private void đĂNGXUẤTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangNhap = new frmDangNhap();
            this.Hide();
            dangNhap.Show();
        }

        private void tHÔNGTINCÁNHÂNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan f = new frmTaiKhoan();
            f.MdiParent = this;
            f.Show();
        }

        private void lẬPHÓAĐƠNNHẬPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonPhaChe f = new frmHoaDonPhaChe();
            f.MdiParent = this;
            f.Show();
        }

        private void DoiMatKhautoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.MdiParent = this;
            f.Show();
        }
    }
}
