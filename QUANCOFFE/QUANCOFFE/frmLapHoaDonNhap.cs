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

namespace QUANCOFFE
{
    public partial class frmLapHoaDonNhap : Form
    {
        public frmLapHoaDonNhap()
        {
            InitializeComponent();
        }

        private void frmLapHoaDonNhap_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            ThongTinNhanVien();
            CapNhatDSHoaDonNhap();
            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtMaHoaDon.Enabled = false;
        }
        public void loadDuLieu()
        {
            SanPham sp = new SanPham();
            List<SanPham> dsSanPham = sp.DSSanPham();
            LoaiSanPham loai = new LoaiSanPham();
            List<LoaiSanPham> dsLoaiSP = loai.DSLoaiSanPham();
            NhaCungCap ncc = new NhaCungCap();
            List<NhaCungCap> dsNhaCungCap = new List<NhaCungCap>();
            dtgHoaDonNhap.AutoGenerateColumns = false;
            dtgHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonNhap.ReadOnly = true;
            dtgHoaDonNhap.RowHeadersVisible = false;
            dtgHoaDonNhap.AllowUserToAddRows = false;
            cmbTenSanPham.DataSource = sp.DSSanPham();
            cmbTenSanPham.DisplayMember = "TenSanPham";
            cmbTenSanPham.ValueMember = "MaSanPham";
            cmbLoaiDoUong.DataSource = loai.DSLoaiSanPham();
            cmbLoaiDoUong.DisplayMember = "TenLoaiSP";
            cmbLoaiDoUong.ValueMember = "MaLoaiSP";
            cmbNhaCungCap.DataSource = ncc.DSNhaCungCap();
            cmbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cmbNhaCungCap.ValueMember = "MaNhaCungCap";
           
        }
        public void ThongTinNhanVien()
        {
            int _ma = frmDangNhap.ma;

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaNhanVien,HoTen FROM NHANVIEN WHERE MaNhanVien = " + _ma + " AND TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nhanVien = new NhanVien();
                    if (reader.IsDBNull(0) != null)
                    {
                        txtMaNhanVien.Text = reader[0].ToString();
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        txtTenNhanVien.Text = reader["HoTen"].ToString();
                    }

                }
                reader.Close();
                con.Close();
            }
        }
        public void CapNhatDSHoaDonNhap()
        {
            HoaDonNhap hd = new HoaDonNhap();
            List<HoaDonNhap> dsHoaDonNhap = hd.DSHoaDonNhap();
            dtgHoaDonNhap.AutoGenerateColumns = false;
            dtgHoaDonNhap.DataSource = hd.DSHoaDonNhap();
            dtgHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonNhap.ReadOnly = true;
            btnCapNhatHoaDon.Enabled = false;
            dtgHoaDonNhap.RowHeadersVisible = false;
            dtgHoaDonNhap.AllowUserToAddRows = false;
            dtNgayLap.CustomFormat = "dd/MM/yyyy";
            dtNgayLap.Value = DateTime.Now;
        }

        private void cmbTenSanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem != null)
            {
                SanPham sp = cb.SelectedItem as SanPham;
                txtDonGia.Text = sp.GiaBan.ToString();
                txtSoLuongTon.Text = sp.soLuong.ToString();
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string ghiChu = "";
            if (ckbLoi.Checked == true)
            {
                ghiChu = "Lỗi";
            }
            HoaDonNhap hdn = new HoaDonNhap(int.Parse(txtMaNhanVien.Text), cmbNhaCungCap.SelectedValue.ToString(), dtNgayLap.Text, float.Parse(txtTong_Tien.Text), ghiChu, txtTenNhanVien.Text);
            if (hdn.TaoHoaDon())
            {
                MessageBox.Show("Tạo Thành Công!", "Thông Báo", MessageBoxButtons.OK);
 
            }
            CapNhatDSHoaDonNhap();
        }

        private void dtgHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHoaDonNhap.SelectedRows.Count > 0)
            {

                HoaDonNhap nv = (HoaDonNhap)dtgHoaDonNhap.SelectedRows[0].DataBoundItem;


                txtMaHoaDon.Text = nv.MaHoaDonNhap.ToString();
              cmbNhaCungCap.Text = nv.MaNhaCungCap.ToString();
                if (nv.GhiChu == "" || nv.GhiChu == "Hoàn Thành")
                {
                    ckbLoi.Checked = false;
                }
                else
                {
                    ckbLoi.Checked = true;
                }


                btnCapNhatHoaDon.Enabled = true;
                btnTaoHoaDon.Enabled = false;
                CTHoaDonNhap hd = new CTHoaDonNhap();
                List<CTHoaDonNhap> dsCTHoaDonNhap = hd.DSCTHoaDonNhap(txtMaHoaDon.Text);
                dtgCTHoaDonNhap.AutoGenerateColumns = false;
                dtgCTHoaDonNhap.DataSource = hd.DSCTHoaDonNhap(txtMaHoaDon.Text);
                dtgCTHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                btnThem.Enabled = true;
                btnXoaMon.Enabled = true;
                txtTong_Tien.Text = "0";
                dtNgayLap.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CTHoaDonNhap hdb = new CTHoaDonNhap(cmbTenSanPham.SelectedValue.ToString(), int.Parse(numSoLuong.Value.ToString()), float.Parse(txtDonGia.Text), float.Parse(txtThanhTien.Text), int.Parse(txtMaHoaDon.Text));
            if (hdb.ThemSPVaoHoaDonBan())
            {
                MessageBox.Show("Thêm Thành công!", "Thông Báo", MessageBoxButtons.OK);
                HoaDonNhap nv = (HoaDonNhap)dtgHoaDonNhap.SelectedRows[0].DataBoundItem;
                int soLuong = int.Parse(numSoLuong.Value.ToString());
                int soLuongTon = int.Parse(txtSoLuongTon.Text);
                int soLuongMoi = soLuongTon + soLuong;
                txtSoLuongTon.Text = soLuongMoi.ToString();
                SanPham sp = new SanPham(int.Parse(cmbTenSanPham.SelectedValue.ToString()), int.Parse(txtSoLuongTon.Text));
                sp.CapNhatSoLuongTon();

                CTHoaDonNhap hd = new CTHoaDonNhap();
                List<CTHoaDonNhap> dsCTHoaDonBan = hd.DSCTHoaDonNhap(txtMaHoaDon.Text);
                dtgCTHoaDonNhap.AutoGenerateColumns = false;
                dtgCTHoaDonNhap.DataSource = hd.DSCTHoaDonNhap(txtMaHoaDon.Text);
                dtgCTHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                loadDuLieu();
            }
            txtThanhTien.Text = "0";
            numSoLuong.Value = 0;
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            float thanhTien;
            int soLuong = int.Parse(numSoLuong.Value.ToString());
            int donGia = int.Parse((txtDonGia.Text));
            thanhTien = soLuong * donGia;
 
            txtThanhTien.Text = thanhTien.ToString();

        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dtgCTHoaDonNhap.SelectedRows.Count > 0)
            {

                CTHoaDonNhap hd = (CTHoaDonNhap)this.dtgCTHoaDonNhap.SelectedRows[0].DataBoundItem;

                hd.XoaSP();
                SanPham sp = new SanPham(int.Parse(cmbTenSanPham.SelectedValue.ToString()), int.Parse(txtSoLuongTon.Text) - soLuong);
                sp.CapNhatSoLuongTon();
                CTHoaDonNhap cthd = new CTHoaDonNhap();
                List<CTHoaDonNhap> dsCTHoaDonBan = hd.DSCTHoaDonNhap(txtMaHoaDon.Text);
                dtgCTHoaDonNhap.AutoGenerateColumns = false;
                dtgCTHoaDonNhap.DataSource = hd.DSCTHoaDonNhap(txtMaHoaDon.Text);
                dtgCTHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                txtThanhTien.Text = "0";
                numSoLuong.Value = 0;
                loadDuLieu();
            }
        }

        private void btnCapNhatHoaDon_Click(object sender, EventArgs e)
        {
            string ghiChu = "";
            if (ckbLoi.Checked == true)
            {
                ghiChu = "Lỗi";
            }
            HoaDonNhap hd = new HoaDonNhap(int.Parse(txtMaHoaDon.Text), ghiChu);
            if (hd.CapNhatHoaDonBan())
            {
                MessageBox.Show("Yêu Cầu Đã ĐƯợc Gửi Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                ckbLoi.Checked = false;
                btnTaoHoaDon.Enabled = true;
                btnCapNhatHoaDon.Enabled = false;
                CapNhatDSHoaDonNhap();

            }
        }

        private void btnTongTien_Click(object sender, EventArgs e)
        {
            if( txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn !", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection con = KetNoi.taoketnoi();
                if (con != null)
                {
                    SqlCommand com = new SqlCommand("SELECT sum(DonGia) FROM CTHOADONNHAP WHERE MaHoaDonNhap =" + txtMaHoaDon.Text + "  AND TrangThai = 1", con);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        HoaDonNhap hoaDon = new HoaDonNhap();
                        if (reader.IsDBNull(0) != null)
                        {
                            txtTong_Tien.Text = reader[0].ToString();
                        }

                    }
                }
            }

            
        }
        static int soLuong;
        private void dtgCTHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCTHoaDonNhap.SelectedRows.Count > 0)
            {

                CTHoaDonNhap cTHoaDonNhap= (CTHoaDonNhap)dtgCTHoaDonNhap.SelectedRows[0].DataBoundItem;
                soLuong = cTHoaDonNhap.SoLuong1;
                numSoLuong.Value = int.Parse(cTHoaDonNhap.SoLuong1.ToString());
                cmbTenSanPham.Text = cTHoaDonNhap.MaSanPham1.ToString();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn !", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                HoaDonNhap hd = new HoaDonNhap(int.Parse(txtMaHoaDon.Text), float.Parse(txtTong_Tien.Text));
                if (hd.ThanhToanHoaDonNhap())
                {
                    MessageBox.Show("Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    CapNhatDSHoaDonNhap();
                    txtMaHoaDon.Text = "";
                    txtTong_Tien.Text = "0";
                    dtNgayLap.Value = DateTime.Now;
                    numSoLuong.Value = 0;
                    txtDonGia.Text = "0";
                    txtThanhTien.Text = "0";
                    dtNgayLap.Enabled = true;
                }
            }
        }

        private void cmbLoaiDoUong_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem != null)
            {
                LoaiSanPham loai = cb.SelectedItem as LoaiSanPham;
                SanPham sp = new SanPham();
                string maLoai = loai.MaLoaiSP.ToString();
                cmbTenSanPham.DataSource = sp.cmbDSSanPham(maLoai);
                cmbTenSanPham.DisplayMember = "TenSanPham";
                cmbTenSanPham.ValueMember = "MaSanPham";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ckbLoi.Checked = false;
            txtMaHoaDon.Text = "";
            txtThanhTien.Text = "0";
            txtTong_Tien.Text = "0";
            numSoLuong.Value = 0;
            dtNgayLap.Value = DateTime.Now;
            txtDonGia.Text = "0";
            btnTaoHoaDon.Enabled = true;
        }
    }
}
