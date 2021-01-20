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
using DevComponents.Editors.DateTimeAdv;

namespace QUANCOFFE
{
    public partial class frmLapHoaDonBan : Form
    {

        string chucVu;

        public frmLapHoaDonBan()
        {
            InitializeComponent();
        }
        public frmLapHoaDonBan(string _chucVu)
        {
            InitializeComponent();
            this.chucVu = _chucVu;
        }

        public void loadDuLieu()
        {
            SanPham sp = new SanPham();
            List<SanPham> dsSanPham = sp.DSSanPham();
            LoaiSanPham loai = new LoaiSanPham();
            List<LoaiSanPham> dsLoaiSP = loai.DSLoaiSanPham();
            dtgHoaDonBan.AutoGenerateColumns = false;
            dtgHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonBan.ReadOnly = true;
            dtgHoaDonBan.RowHeadersVisible = false;
            dtgHoaDonBan.AllowUserToAddRows = false;
            cmbTenSanPham.DataSource = sp.DSSanPham();
            cmbTenSanPham.DisplayMember = "TenSanPham";
            cmbTenSanPham.ValueMember = "MaSanPham";
            cmbLoaiDoUong.DataSource = loai.DSLoaiSanPham();
            cmbLoaiDoUong.DisplayMember = "TenLoaiSP";
            cmbLoaiDoUong.ValueMember = "MaLoaiSP";
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

        private void frmLapHoaDonBan_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            ThongTinNhanVien();
            loadHoaDonBan();
            CapNhatDSHoaDonBan();
            txtMaHoaDon.Enabled = false;
            dtgCTHoaDonBan.ReadOnly = true;
            btnThem.Enabled = false;
            btnXoaMon.Enabled = false;
            dtgCTHoaDonBan.RowHeadersVisible = false;
            dtgCTHoaDonBan.AllowUserToAddRows = false;
            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;

        }
        public void CapNhatDSHoaDonBan()
        {
            HoaDonBan hd = new HoaDonBan();
            List<HoaDonBan> dsNhanVien = hd.DSHoaDonBan();
            dtgHoaDonBan.AutoGenerateColumns = false;
            dtgHoaDonBan.DataSource = hd.DSHoaDonBan();
            dtgHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHoaDonBan.ReadOnly = true;
            btnCapNhatHoaDon.Enabled = false;
            dtgHoaDonBan.RowHeadersVisible = false;
            dtgHoaDonBan.AllowUserToAddRows = false;
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

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text == "")
            {
                MessageBox.Show("Chưa nhập tên khách hàng", "Thông Báo", MessageBoxButtons.OK);

            }
            string ghiChu = "";
            if(ckbLoi.Checked == true)
            {
                ghiChu = "Lỗi";
            }
            HoaDonBan hdb = new HoaDonBan(int.Parse(txtMaNhanVien.Text), txtTenKhachHang.Text, dtNgayLap.Text, float.Parse(txtTong_Tien.Text), ghiChu,txtTenNhanVien.Text);
            if (hdb.TaoHoaDon())
            {
                MessageBox.Show("Tạo Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                txtTenKhachHang.Text = "";
                ckbLoi.Checked = false;
            }
            CapNhatDSHoaDonBan();
        }
        public void loadHoaDonBan()
        {
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                DataTable tb = new DataTable();
                SqlDataAdapter dt = new SqlDataAdapter("SELECT * FROM HOADONBAN WHERE TrangThai = 1", con);
                dt.Fill(tb);
                dtgHoaDonBan.DataSource = tb;
            }
            con.Close();
        }
   
     
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn !", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                HoaDonBan hd = new HoaDonBan(int.Parse(txtMaHoaDon.Text), float.Parse(txtTong_Tien.Text));
                if (hd.ThanhToanHoaDonBan())
                {
                    MessageBox.Show("Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    CapNhatDSHoaDonBan();
                    txtMaHoaDon.Text = "";
                    txtTong_Tien.Text = "0";
                    txtTenKhachHang.Text = "";
                    dtNgayLap.Value = DateTime.Now;
                    numSoLuong.Value = 0;
                    txtDonGia.Text = "0";
                    txtThanhTien.Text = "0";
                    dtNgayLap.Enabled = true;
                }
            }
        }
        private void dtgHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHoaDonBan.SelectedRows.Count > 0)
            {

                HoaDonBan nv = (HoaDonBan)dtgHoaDonBan.SelectedRows[0].DataBoundItem;
                txtMaHoaDon.Text = nv.MaHoaDonBan.ToString();
                txtTenKhachHang.Text = nv.TenKhachHang.ToString();
                if(nv.GhiChu == "" || nv.GhiChu == "Hoàn Thành")
                {
                    ckbLoi.Checked = false;
                }
                else
                {
                    ckbLoi.Checked = true;
                }
                
                btnCapNhatHoaDon.Enabled = true;
                btnTaoHoaDon.Enabled = false;
                CTHoaDonBan hd = new CTHoaDonBan();
                List<CTHoaDonBan> dsCTHoaDonBan = hd.DSCTHoaDonBan(txtMaHoaDon.Text);
                dtgCTHoaDonBan.AutoGenerateColumns = false;
                dtgCTHoaDonBan.DataSource = hd.DSCTHoaDonBan(txtMaHoaDon.Text);
                dtgCTHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                btnThem.Enabled = true;
                btnXoaMon.Enabled = true;
                txtTong_Tien.Text = "0";
                dtNgayLap.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        { 
            CTHoaDonBan hdb = new CTHoaDonBan(cmbTenSanPham.SelectedValue.ToString(), int.Parse(numSoLuong.Value.ToString()), float.Parse(txtDonGia.Text), float.Parse(txtThanhTien.Text),int.Parse(txtMaHoaDon.Text));
            if(numSoLuong.Value == 0)
            {
                MessageBox.Show("Nhập Số Lượng!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if (hdb.ThemSPVaoHoaDonBan())
                {
                    MessageBox.Show("Thêm Thành công!", "Thông Báo", MessageBoxButtons.OK);
                    int soLuong = int.Parse(numSoLuong.Value.ToString());
                    int soLuongTon = int.Parse(txtSoLuongTon.Text);
                    int soLuongConLai = soLuongTon - soLuong;
                    txtSoLuongTon.Text = soLuongConLai.ToString();
                    HoaDonBan nv = (HoaDonBan)dtgHoaDonBan.SelectedRows[0].DataBoundItem;
                    SanPham sp = new SanPham(int.Parse(cmbTenSanPham.SelectedValue.ToString()), int.Parse(txtSoLuongTon.Text));
                    sp.CapNhatSoLuongTon();

                    CTHoaDonBan hd = new CTHoaDonBan();
                    List<CTHoaDonBan> dsCTHoaDonBan = hd.DSCTHoaDonBan(txtMaHoaDon.Text);
                    dtgCTHoaDonBan.AutoGenerateColumns = false;
                    dtgCTHoaDonBan.DataSource = hd.DSCTHoaDonBan(txtMaHoaDon.Text);
                    dtgCTHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    loadDuLieu();

                }
            }
            
            txtThanhTien.Text = "0";
            numSoLuong.Value = 0;
            
     
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            
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
            if (dtgCTHoaDonBan.SelectedRows.Count > 0)
            {

               CTHoaDonBan hd = (CTHoaDonBan)this.dtgCTHoaDonBan.SelectedRows[0].DataBoundItem;

                hd.XoaSP();
                SanPham sp = new SanPham(int.Parse(cmbTenSanPham.SelectedValue.ToString()), int.Parse(txtSoLuongTon.Text)+soLuong);
                sp.CapNhatSoLuongTon();
                CTHoaDonBan cthd = new CTHoaDonBan();
                List<CTHoaDonBan> dsCTHoaDonBan = hd.DSCTHoaDonBan(txtMaHoaDon.Text);
                dtgCTHoaDonBan.AutoGenerateColumns = false;
                dtgCTHoaDonBan.DataSource = hd.DSCTHoaDonBan(txtMaHoaDon.Text);
                dtgCTHoaDonBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            HoaDonBan hd = new HoaDonBan(int.Parse(txtMaHoaDon.Text),ghiChu );
            if (hd.CapNhatHoaDonBan())
            {
                MessageBox.Show("Yêu Cầu Đã ĐƯợc Gửi Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                btnTaoHoaDon.Enabled = true;
                btnCapNhatHoaDon.Enabled = false;
                CapNhatDSHoaDonBan();

            }
        }

        private void btnTongTien_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn !", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
                {
                SqlCommand com = new SqlCommand("SELECT sum(DongGia) FROM CTHOADONBAN WHERE MaHoaDonBan ="+txtMaHoaDon.Text+"  and TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        HoaDonBan hoaDon = new HoaDonBan();
                        if (reader.IsDBNull(0) != null)
                        {
                            txtTong_Tien.Text = reader[0].ToString();
                        }

                    }  
                }
            }
        }

        private void txtTong_Tien_TextChanged(object sender, EventArgs e)
        {
        }
        static int soLuong;
        private void dtgCTHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHoaDonBan.SelectedRows.Count > 0)
            {

                CTHoaDonBan cTHoaDonBan = (CTHoaDonBan)dtgCTHoaDonBan.SelectedRows[0].DataBoundItem;
                 soLuong = cTHoaDonBan.SoLuong1;
                 numSoLuong.Value = int.Parse(cTHoaDonBan.SoLuong1.ToString());
                cmbTenSanPham.Text = cTHoaDonBan.MaSanPham1.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "";
            txtMaHoaDon.Text = "";
            txtTong_Tien.Text = "0";
            txtThanhTien.Text = "0";
            dtNgayLap.Value = DateTime.Now;
            txtDonGia.Text = "0";
            numSoLuong.Value = 0;
            btnTaoHoaDon.Enabled = true;
        }
    }
}
 
