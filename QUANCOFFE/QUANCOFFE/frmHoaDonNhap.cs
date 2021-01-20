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
    public partial class frmHoaDonNhap : Form
    {
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {

            CapNhatDSHoaDonNhap();
            btnXoaHoaDon.Enabled = false;
        }
        public void CapNhatDSHoaDonNhap()
        {
            HoaDonNhap hd = new HoaDonNhap();
            List<HoaDonNhap> dsHoaDon = hd.DSHoaDonNhap();
            dtgHoaDonNhap.AutoGenerateColumns = false;
            dtgHoaDonNhap.DataSource = hd.DSHoaDonNhap();
            dtgHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonNhap.ReadOnly = true;
            dtgHoaDonNhap.RowHeadersVisible = false;
            dtgHoaDonNhap.AllowUserToAddRows = false;
            dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            DateTime today = DateTime.Now;
            dtNgayBatDau.Value = new DateTime(today.Year, today.Month, 1);
            dtNgayKetThuc.Value = dtNgayKetThuc.Value.AddMonths(today.Month).AddDays(-1).AddYears(today.Year - 1);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            CapNhatDSHoaDonNhap();
        }

        private void dtgHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHoaDonNhap.SelectedRows.Count > 0)
            {

                HoaDonNhap nv = (HoaDonNhap)dtgHoaDonNhap.SelectedRows[0].DataBoundItem;
                btnXoaHoaDon.Enabled = true;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtNgayKetThuc.Text == "" || dtNgayBatDau.Text == "")
            {
                CapNhatDSHoaDonNhap();
            }
            HoaDonNhap hd = new HoaDonNhap();
            List<HoaDonNhap> dsHoaDon = hd.TimHoaDonNhap(dtNgayBatDau.Text, dtNgayKetThuc.Text);
            dtgHoaDonNhap.AutoGenerateColumns = false;
            dtgHoaDonNhap.DataSource = hd.TimHoaDonNhap(dtNgayBatDau.Text, dtNgayKetThuc.Text);
            dtgHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonNhap.ReadOnly = true;
            dtgHoaDonNhap.RowHeadersVisible = false;
            dtgHoaDonNhap.AllowUserToAddRows = false;
            dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (dtgHoaDonNhap.SelectedRows.Count > 0)
            {

                HoaDonNhap hd = (HoaDonNhap)this.dtgHoaDonNhap.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn " + hd.MaHoaDonNhap + " này", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    hd.XoaHoaDonBan();

                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    if (dtNgayBatDau.Text == "" && dtNgayBatDau.Text == "")
                    {
                        CapNhatDSHoaDonNhap();
                    }
                    HoaDonBan hdb = new HoaDonBan();
                    List<HoaDonBan> dsHoaDon = hdb.TimHoaDonBan(dtNgayBatDau.Text, dtNgayKetThuc.Text);
                    dtgHoaDonNhap.AutoGenerateColumns = false;
                    dtgHoaDonNhap.DataSource = hdb.TimHoaDonBan(dtNgayBatDau.Text, dtNgayKetThuc.Text);
                    dtgHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dtgHoaDonNhap.ReadOnly = true;
                    dtgHoaDonNhap.RowHeadersVisible = false;
                    dtgHoaDonNhap.AllowUserToAddRows = false;
                    dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
                    dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
                    btnXoaHoaDon.Enabled = false;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
