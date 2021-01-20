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
using System.Globalization;
using Microsoft.SqlServer.Server;

namespace QUANCOFFE
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            CapNhatDSNhaCungCap();
            CapNhatDSSanPham();
            CapNhatDSLoaiSP();
            Load_cmb();

        }

        private void dtgSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemSP.Enabled = false;
            txtMaSP.ReadOnly = true;
            if (dtgSanPham.Rows.Count > 0)
            {
                SanPham sp = (SanPham)dtgSanPham.SelectedRows[0].DataBoundItem;
                txtMaSP.Text = sp.MaSanPham.ToString();
                txtTenSP.Text = sp.TenSanPham.ToString();
                cmbLoaiSP.Text = sp.Loai.ToString();
                txtGiaBan.Text = sp.GiaBan.ToString();
                cmbNhaSanXuat.Text = sp.NhaSanXuat.ToString();
                numSoLuong.Value = int.Parse(sp.SoLuong.ToString());

                btnCapNhatSP.Enabled = true;
                btnXoaSP.Enabled = true;
            }
        }
        public void Load_cmb()
        {
            txtMaLoaiSanPham.Enabled = false;
            txtMaNhaCungCap.Enabled = false;
            txtMaSP.Enabled = false;
            LoaiSanPham loai = new LoaiSanPham();
            List<LoaiSanPham> dsLoaiSanPham = new List<LoaiSanPham>();
            NhaCungCap ncc = new NhaCungCap();
            List<NhaCungCap> dsNhaCungCap = ncc.DSNhaCungCap();
            cmbNhaSanXuat.DataSource = ncc.DSNhaCungCap();
            cmbNhaSanXuat.DisplayMember = "TenNhaCungCap";
            cmbNhaSanXuat.ValueMember = "MaNhaCungCap";
            cmbLoaiSP.DataSource = loai.DSLoaiSanPham();
            cmbLoaiSP.DisplayMember = "TenLoaiSP";
            cmbLoaiSP.ValueMember = "MaLoaiSP";
            btnCapNhatNhaCungCap.Enabled = false;
            btnXoaNhaCungCap.Enabled = false;

        }
        public void CapNhatDSSanPham()
        {
            SanPham sanPham = new SanPham();
            List<SanPham> dsSanPham = sanPham.DSSanPham();
            dtgSanPham.AutoGenerateColumns = false;
            dtgSanPham.DataSource = sanPham.DSSanPham();
            dtgSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgSanPham.ReadOnly = true;
            dtgSanPham.RowHeadersVisible = false;
            dtgSanPham.AllowUserToAddRows = false;
            btnCapNhatSP.Enabled = false;
            btnXoaSP.Enabled = false;
        }
        public void CapNhatDSLoaiSP()
        {
            LoaiSanPham loai = new LoaiSanPham();
            List<LoaiSanPham> dsLoaiSP = loai.DSLoaiSanPham();
            dtgLoaiSanPham.AutoGenerateColumns = false;
            dtgLoaiSanPham.DataSource = loai.DSLoaiSanPham();
            dtgLoaiSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgLoaiSanPham.ReadOnly = true;
            dtgLoaiSanPham.RowHeadersVisible = false;
            dtgLoaiSanPham.AllowUserToAddRows = false;
            btnXoaLoaiSanPham.Enabled = false;
            btnCapNhatLoaiSanPham.Enabled = false;
        }
       
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == ""||txtGiaBan.Text == "")
            {
                MessageBox.Show("Chưa Nhập Đầy Đủ Thông Tin!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {

                SanPham sp = new SanPham( txtTenSP.Text, float.Parse(txtGiaBan.Text), cmbLoaiSP.SelectedValue.ToString(), cmbNhaSanXuat.SelectedValue.ToString(), int.Parse(numSoLuong.Value.ToString()));
                if (sp.ThemSanPham())
                {
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaSP.Text = "";
                    txtTenSP.Text = "";
                    txtGiaBan.Text = "";
                    cmbLoaiSP.Text = "";
                    cmbNhaSanXuat.Text = "";
                    numSoLuong.Value = 0;
                    CapNhatDSSanPham();
                }
            }
            
        }

        private void btnCapNhatSP_Click(object sender, EventArgs e)
        {
           

                if ( txtTenSP.Text != "" || txtGiaBan.Text !="")
                {
                SanPham sp = new SanPham(int.Parse(txtMaSP.Text), txtTenSP.Text, float.Parse(txtGiaBan.Text),cmbLoaiSP.SelectedValue.ToString(), cmbNhaSanXuat.SelectedValue.ToString(),int.Parse(numSoLuong.Value.ToString()));
                if (sp.CapNhatSanPham())
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaSP.Text = "";
                    txtTenSP.Text = "";
                    txtGiaBan.Text = "";
                    cmbLoaiSP.Text = "";
                    cmbNhaSanXuat.Text = "";
                    numSoLuong.Value = 0;
                    CapNhatDSSanPham();
                }
                    btnThemSP.Enabled = true;
                    txtMaSP.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("Chưa nhập  đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK);
                }
          
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dtgSanPham.SelectedRows.Count > 0)
            {

               SanPham sp = (SanPham)this.dtgSanPham.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa  " + sp.TenSanPham + " này", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    sp.XoaSanPham();

                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaSP.Text = "";
                    txtTenSP.Text = "";
                    txtGiaBan.Text = "";
                    cmbLoaiSP.Text = "";
                    cmbNhaSanXuat.Text = "";
                    numSoLuong.Value = 0;
                    CapNhatDSSanPham();
                    Load_cmb();

                }
            }
            btnThemSP.Enabled = true;
            txtMaSP.ReadOnly = false;

        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if(txtTimSP.Text == "")
            {
                CapNhatDSSanPham();
            }
            else
            {
                TimSanPham();
            }
        }
        public void TimSanPham()
        {
            SanPham sanPham = new SanPham();
            List<SanPham> dsSanPham = sanPham.TimSanPham(txtTimSP.Text);
            dtgSanPham.AutoGenerateColumns = false;
            dtgSanPham.DataSource = sanPham.TimSanPham(txtTimSP.Text);
            dtgSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgSanPham.ReadOnly = true;
            dtgSanPham.RowHeadersVisible = false;
            dtgSanPham.AllowUserToAddRows = false;
            btnCapNhatSP.Enabled = false;
            btnXoaSP.Enabled = false;

        }


        public void CapNhatDSNhaCungCap()
        {
            NhaCungCap ncc = new NhaCungCap();
            List<NhaCungCap> dsNhaCungCap = ncc.DSNhaCungCap();
            dtgNhaCungCap.AutoGenerateColumns = false;
            dtgNhaCungCap.DataSource = ncc.DSNhaCungCap();
            dtgNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgNhaCungCap.ReadOnly = true;
            dtgNhaCungCap.RowHeadersVisible = false;
            dtgNhaCungCap.AllowUserToAddRows = false;
        }
      
        private void btnXoaNhaCungCap_Click(object sender, EventArgs e)
        {
            if (dtgNhaCungCap.SelectedRows.Count > 0)
            {

                NhaCungCap ncc = (NhaCungCap)this.dtgNhaCungCap.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa  " + ncc.TenNhaCungCap + " này", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    ncc.XoaNhaCungCap();

                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaNhaCungCap.Text = "";
                    txtTenNhaCungCap.Text = "";
                    txtDiaChiNhaCungCap.Text = "";
                    txtSdtNhaCungCap.Text = "";
                    CapNhatDSNhaCungCap();

                }
            }
            btnThemNhaCungCap.Enabled = true;
            txtMaNhaCungCap.ReadOnly = false;
            btnCapNhatNhaCungCap.Enabled = false;
            btnXoaLoaiSanPham.Enabled = false;

        }


        private void dtgNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemNhaCungCap.Enabled = false;
            btnCapNhatNhaCungCap.Enabled = true;
            btnXoaNhaCungCap.Enabled = true;
            if (dtgNhaCungCap.Rows.Count > 0)
            {
                NhaCungCap ncc = (NhaCungCap)dtgNhaCungCap.SelectedRows[0].DataBoundItem;
                txtMaNhaCungCap.Text = ncc.MaNhaCungCap.ToString();
                txtTenNhaCungCap.Text = ncc.TenNhaCungCap.ToString();
                txtDiaChiNhaCungCap.Text = ncc.DiaChi.ToString();
                txtSdtNhaCungCap.Text = ncc.SoDienThoai.ToString();
             

            }
        }

        private void txtSdtNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            if(txtMaNhaCungCap.Text != "" || txtTenNhaCungCap.Text !="" || txtSdtNhaCungCap.Text != "" || txtDiaChiNhaCungCap.Text != "")
            {
                NhaCungCap ncc = new NhaCungCap(txtTenNhaCungCap.Text,txtSdtNhaCungCap.Text,txtDiaChiNhaCungCap.Text);
                if (ncc.ThemNhaCungCap())
                {
                    MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaNhaCungCap.Text = "";
                    txtDiaChiNhaCungCap.Text = "";
                    txtTenNhaCungCap.Text = "";
                    txtSdtNhaCungCap.Text = "";
                    CapNhatDSNhaCungCap();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập  đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnCapNhatNhaCungCap_Click(object sender, EventArgs e)
        {
           
            if (txtTenNhaCungCap.Text != "" || txtSdtNhaCungCap.Text != "" || txtDiaChiNhaCungCap.Text != "")
            {
                NhaCungCap ncc = new NhaCungCap(int.Parse(txtMaNhaCungCap.Text ),txtTenNhaCungCap.Text, txtSdtNhaCungCap.Text, txtDiaChiNhaCungCap.Text);
                if (ncc.CapNhatNhaCungCap())
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaNhaCungCap.Text = "";
                    txtDiaChiNhaCungCap.Text = "";
                    txtTenNhaCungCap.Text = "";
                    txtSdtNhaCungCap.Text = "";
                    CapNhatDSNhaCungCap();
                }
                btnThemNhaCungCap.Enabled = false;
                btnCapNhatNhaCungCap.Enabled =true;
                btnXoaNhaCungCap.Enabled = true;
            }
            else
            {
                MessageBox.Show("Chưa nhập  đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnResetNhaCungCap_Click(object sender, EventArgs e)
        {
            btnThemNhaCungCap.Enabled = true;
            txtMaNhaCungCap.Text = "";
            txtDiaChiNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtSdtNhaCungCap.Text = "";
            txtTimNhaCungCap.Text = "";
            CapNhatDSNhaCungCap();
            btnThemNhaCungCap.Enabled = true;
            btnCapNhatNhaCungCap.Enabled = false;
            btnXoaNhaCungCap.Enabled = false;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }

        private void btnTimNhaCungCap_Click(object sender, EventArgs e)
        {
            if(txtTimNhaCungCap.Text != "")
            {
                TimNhaCungCap();
            }
            else
            {
                CapNhatDSNhaCungCap();
            }
        }
        public void TimNhaCungCap()
        {
            NhaCungCap ncc = new NhaCungCap();
            List<NhaCungCap> dsNhaCungCap = ncc.TimNhaCungCap(txtTimNhaCungCap.Text);
            dtgNhaCungCap.DataSource = ncc.TimNhaCungCap(txtTimNhaCungCap.Text);
            dtgNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgNhaCungCap.ReadOnly = true;
            btnThemNhaCungCap.Enabled = false;
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void btnResetSanPham_Click(object sender, EventArgs e)
        {
            btnThemSP.Enabled = true;
            txtMaSP.ReadOnly = false;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
            txtTimSP.Text = "";
            numSoLuong.Value = 0;
            CapNhatDSSanPham();

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnThoatSanPham_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnThemLoaiSanPham_Click(object sender, EventArgs e)
        {
            if(txtTenLoaiSanPham.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin đầy đủ!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                LoaiSanPham loai = new LoaiSanPham(txtTenLoaiSanPham.Text);
                if (loai.ThemLoaiSP())
                {
                    MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    txtTenLoaiSanPham.Text = "";
                    txtMaLoaiSanPham.Text = "";
                    btnCapNhatLoaiSanPham.Enabled = false;
                    btnXoaLoaiSanPham.Enabled = false;
                    CapNhatDSLoaiSP();
                }
            }
        }

        private void dtgLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemLoaiSanPham.Enabled = false;
            btnCapNhatLoaiSanPham.Enabled = true;
            btnXoaLoaiSanPham.Enabled = true;
            if (dtgLoaiSanPham.Rows.Count > 0)
            {
               LoaiSanPham loai = (LoaiSanPham)dtgLoaiSanPham.SelectedRows[0].DataBoundItem;
                txtMaLoaiSanPham.Text = loai.maLoaiSP.ToString();
                txtTenLoaiSanPham.Text = loai.tenLoaiSP.ToString();
            }
        }

        private void btnResetLoaiSanPham_Click(object sender, EventArgs e)
        {
            txtTenLoaiSanPham.Text = "";
            txtMaLoaiSanPham.Text = "";
            txtTimLoaiSanPham.Text = "";
            btnThemLoaiSanPham.Enabled = true;
            btnCapNhatLoaiSanPham.Enabled = false;
            btnXoaLoaiSanPham.Enabled = false;
        }

        private void btnTimLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (txtTimLoaiSanPham.Text == "")
            {
                CapNhatDSLoaiSP();
            }
            else
            {
                TimLoaiSP();
            }
        }
        public void TimLoaiSP()
        {
            LoaiSanPham loai = new LoaiSanPham();
            List<LoaiSanPham> dsLoaiSP = loai.TimLoaiSP(txtTimLoaiSanPham.Text);
            dtgLoaiSanPham.AutoGenerateColumns = false;
            dtgLoaiSanPham.DataSource = loai.TimLoaiSP(txtTimLoaiSanPham.Text);
            dtgLoaiSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgLoaiSanPham.ReadOnly = true;
            dtgLoaiSanPham.RowHeadersVisible = false;
            dtgLoaiSanPham.AllowUserToAddRows = false;
            btnXoaLoaiSanPham.Enabled = false;
            btnCapNhatLoaiSanPham.Enabled = false;
        }

        private void btnCapNhatLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiSanPham.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin đầy đủ!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                LoaiSanPham loai = new LoaiSanPham(int.Parse(txtMaLoaiSanPham.Text), txtTenLoaiSanPham.Text);
                if (loai.CapNhatLoaiSP())
                {
                    MessageBox.Show("Cập Nhật Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    txtTenLoaiSanPham.Text = "";
                    txtMaLoaiSanPham.Text = "";
                    btnCapNhatLoaiSanPham.Enabled = false;
                    btnXoaLoaiSanPham.Enabled = false;
                    btnThemLoaiSanPham.Enabled = true;
                    CapNhatDSLoaiSP();
                }
            }
        }

        private void btnXoaLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (dtgLoaiSanPham.SelectedRows.Count > 0)
            {

                LoaiSanPham loai = (LoaiSanPham)this.dtgLoaiSanPham.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa  " + loai.tenLoaiSP + " này", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    loai.XoaLoaiSP();

                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaLoaiSanPham.Text = "";
                    txtTenLoaiSanPham.Text = "";
                  
                    CapNhatDSLoaiSP();

                }
            }
            btnThemLoaiSanPham.Enabled = true;
            txtMaNhaCungCap.ReadOnly = false;
            btnCapNhatLoaiSanPham.Enabled = false;
            btnXoaLoaiSanPham.Enabled = false;
        }
    }
}
