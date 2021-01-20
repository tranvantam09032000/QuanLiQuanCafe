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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void btnThoatHoaDonBan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtGhiChuCTHDBan.Text = "";
            txtGhiChuBan.Text = "";
            txtMaChiTietHDBan.Text = "";
            txtMaHoaDonBan.Text = "";
            txtTimHoaDonBan.Text = "";
            dtHoaDonBan.Text = DateTime.Now.ToString();
            cmbLoaiNuocUong.Text = "";
            cmbSanPham.Text = "";
            cmbNhanVienBan.Text = "";
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            numThanhGia.Value = 0;
        }
    }
}
