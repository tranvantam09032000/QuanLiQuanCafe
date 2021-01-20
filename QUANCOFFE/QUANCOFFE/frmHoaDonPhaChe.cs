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
    public partial class frmHoaDonPhaChe : Form
    {
        public frmHoaDonPhaChe()
        {
            InitializeComponent();
        }

        private void frmHoaDonPhaChe_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.ReadOnly = true;
            btnHoanThanh.Enabled = false;
            dtgCTHoaDonBan.AllowUserToAddRows = false;
            dtgCTHoaDonBan.ReadOnly = true;
            dtgCTHoaDonBan.RowHeadersVisible = false;
            CapNhatDSHoaDonBan();
        }
        public void CapNhatDSHoaDonBan()
        {
            HoaDonBan hd = new HoaDonBan();
            List<HoaDonBan> dsNhanVien = hd.DSHoaDonPhaChe();
            dtgHoaDonBan.AutoGenerateColumns = false;
            dtgHoaDonBan.DataSource = hd.DSHoaDonPhaChe();
            dtgHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonBan.ReadOnly = true;
            dtgHoaDonBan.RowHeadersVisible = false;
            dtgHoaDonBan.AllowUserToAddRows = false;

        }
        string ma = "";
        private void dtgHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHoaDonBan.SelectedRows.Count > 0)
            {

                HoaDonBan nv = (HoaDonBan)dtgHoaDonBan.SelectedRows[0].DataBoundItem;
                ma = dtgHoaDonBan["MaHoaDonBan", e.RowIndex].Value.ToString();

                txtMaHoaDon.Text = nv.MaHoaDonBan.ToString();
                CTHoaDonBan hd = new CTHoaDonBan();
                List<CTHoaDonBan> dsCTHoaDonBan = hd.DSCTHoaDonBan(ma);
                dtgCTHoaDonBan.AutoGenerateColumns = false;
                dtgCTHoaDonBan.DataSource = hd.DSCTHoaDonBan(ma);
                dtgCTHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtgCTHoaDonBan.AllowUserToAddRows = false;
                dtgCTHoaDonBan.ReadOnly = true;
                dtgCTHoaDonBan.RowHeadersVisible = false;
                btnHoanThanh.Enabled = true;
            }
        }

        private void dtgCTHoaDonBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string ghiChu = "Hoàn Thành";
            HoaDonBan hd = new HoaDonBan(int.Parse(txtMaHoaDon.Text), ghiChu);
            if (hd.CapNhatHoaDonBan())
            {
                MessageBox.Show("Hoàn Thành!", "Thông Báo", MessageBoxButtons.OK);
                btnHoanThanh.Enabled = false;
                txtMaHoaDon.Text = "";
                CapNhatDSHoaDonBan();

            }
        }
    }
}
