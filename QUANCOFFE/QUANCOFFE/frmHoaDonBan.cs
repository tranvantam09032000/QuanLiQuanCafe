using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QUANCOFFE
{
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        public void CapNhatDSHoaDonBan()
        {
            HoaDonBan hd = new HoaDonBan();
            List<HoaDonBan> dsHoaDon = hd.DSHoaDonBan();
            dtgHoaDonBan.AutoGenerateColumns = false;
            dtgHoaDonBan.DataSource = hd.DSHoaDonBan();
            dtgHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonBan.ReadOnly = true;
            dtgHoaDonBan.RowHeadersVisible = false;
            dtgHoaDonBan.AllowUserToAddRows = false;
            dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            DateTime today = DateTime.Now;
            dtNgayBatDau.Value = new DateTime(today.Year, today.Month, 1);
            dtNgayKetThuc.Value = dtNgayKetThuc.Value.AddMonths(today.Month).AddDays(-1).AddYears(today.Year-1);
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            CapNhatDSHoaDonBan();
            btnXoaHoaDon.Enabled = false;

        }

        private void dtgHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHoaDonBan.SelectedRows.Count > 0)
            {

                HoaDonBan nv = (HoaDonBan)dtgHoaDonBan.SelectedRows[0].DataBoundItem;
                btnXoaHoaDon.Enabled = true;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(dtNgayKetThuc.Text == "" || dtNgayBatDau.Text == "")
            {
                CapNhatDSHoaDonBan();
            }
            HoaDonBan hd = new HoaDonBan();
            List<HoaDonBan> dsHoaDon = hd.TimHoaDonBan(dtNgayBatDau.Text,dtNgayKetThuc.Text);
            dtgHoaDonBan.AutoGenerateColumns = false;
            dtgHoaDonBan.DataSource = hd.TimHoaDonBan(dtNgayBatDau.Text, dtNgayKetThuc.Text);
            dtgHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonBan.ReadOnly = true;
            dtgHoaDonBan.RowHeadersVisible = false;
            dtgHoaDonBan.AllowUserToAddRows = false;
            dtNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtNgayKetThuc.CustomFormat = "dd/MM/yyyy";
      

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CapNhatDSHoaDonBan();
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (dtgHoaDonBan.SelectedRows.Count > 0)
            {

                HoaDonBan hd = (HoaDonBan)this.dtgHoaDonBan.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn " + hd.MaHoaDonBan + " này", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    hd.XoaHoaDonBan();

                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    if(dtNgayBatDau.Text =="" && dtNgayBatDau.Text == "")
                    {
                        CapNhatDSHoaDonBan();
                    }
                    HoaDonBan hdb = new HoaDonBan();
                    List<HoaDonBan> dsHoaDon = hdb.TimHoaDonBan(dtNgayBatDau.Text, dtNgayKetThuc.Text);
                    dtgHoaDonBan.AutoGenerateColumns = false;
                    dtgHoaDonBan.DataSource = hdb.TimHoaDonBan(dtNgayBatDau.Text, dtNgayKetThuc.Text);
                    dtgHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dtgHoaDonBan.ReadOnly = true;
                    dtgHoaDonBan.RowHeadersVisible = false;
                    dtgHoaDonBan.AllowUserToAddRows = false;
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
