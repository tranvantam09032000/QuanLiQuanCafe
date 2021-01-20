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
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void txtSoDT_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lab_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            CapNhatDSNhanVien();

            //cmbChucVu.DataSource = nv.DSNhanVien();
            //cmbChucVu.DisplayMember = "ChucVu";
            cmbChucVu.Items.Add("Quản Lý");
            cmbChucVu.Items.Add("Nhân Viên Thu Ngân");
            cmbChucVu.Items.Add("Nhân Viên Pha Chế");

            txtMaNhanVien.Enabled = false;

        }
        public void CapNhatDSNhanVien() 
        {
            NhanVien nv = new NhanVien();
            List<NhanVien> dsNhanVien = nv.DSNhanVien();
            dtgNhanVien.AutoGenerateColumns = false;
            dtgNhanVien.DataSource = nv.DSNhanVien();
            dtgNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgNhanVien.ReadOnly = true;
            btnCapNhatNhanVien.Enabled = false;
            btnXoaNhanVien.Enabled = false;
            dtgNhanVien.RowHeadersVisible = false;
            dtgNhanVien.AllowUserToAddRows = false;
            dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtNgaySinh.Value = DateTime.Now;
        }

        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemNhanVien.Enabled = false;
            txtMaNhanVien.ReadOnly = true;
            txtNhapLai.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            btnCapNhatNhanVien.Enabled = true;
            btnXoaNhanVien.Enabled = true;

            if (dtgNhanVien.SelectedRows.Count > 0)
            {

                NhanVien nv = (NhanVien)dtgNhanVien.SelectedRows[0].DataBoundItem;
                txtMaNhanVien.Text = nv.MaNhanVien.ToString();
                txtTenNhanVien.Text = nv.HoTen.ToString();
                txtTenDangNhap.Text = nv.TenDangNHap.ToString();
                dtNgaySinh.Text = nv.NgaySinh.ToString();
                if (nv.GioiTinh.ToString() == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }


                txtSoDT.Text = nv.SoDienThoai.ToString();
                txtQueQuan.Text = nv.QueQuan.ToString();
                txtDiaChi.Text = nv.DiaChi.ToString();

                cmbChucVu.Text = nv.ChucVu.ToString();

            }
        }

        private void btnXemNhanVien_Click(object sender, EventArgs e)
        {
           
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.ReadOnly =false;
            if (txtTenNhanVien.Text == "" || txtTenDangNhap.Text == "" || txtMatKhau.Text == "" || txtNhapLai.Text == "" || txtSoDT.Text == "" || txtQueQuan.Text == "" || txtDiaChi.Text == "" || cmbChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa Nhập Đầy Đủ Thông Tin!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if (txtMatKhau.Text == txtNhapLai.Text)
                {
                    string gioiTinh = "";
                    if (radNam.Checked == true)
                    {
                        gioiTinh += "Nam";
                    }
                    if (radNu.Checked == true)
                    {
                        gioiTinh += "Nữ";
                    }


                    NhanVien nhanVien = new NhanVien( txtTenNhanVien.Text, txtTenDangNhap.Text, txtMatKhau.Text, dtNgaySinh.Value.ToString("dd/MM/yyyy"), gioiTinh, txtSoDT.Text, txtQueQuan.Text, cmbChucVu.Text, txtDiaChi.Text);
                    if (nhanVien.ThemNhanVien())
                    {
                        MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                        txtMaNhanVien.Text = "";
                        txtTenNhanVien.Text = "";
                        txtTenDangNhap.Text = "";
                        txtMatKhau.Text = "";
                        txtNhapLai.Text = "";
                        txtSoDT.Text = "";
                        txtQueQuan.Text = "";
                        radNam.Checked = true;
                        txtDiaChi.Text = "";
                        CapNhatDSNhanVien();

                    }
                }

                else
                {
                    MessageBox.Show("Mật Khẩu Không Trùng Khớp!", "Thông Báo", MessageBoxButtons.OK);
                    txtMatKhau.Text = "";
                    txtNhapLai.Text = "";
                }

            }
        }

        private void btnResetNhanVien_Click(object sender, EventArgs e)
        {
            btnThemNhanVien.Enabled = true;
            dtNgaySinh.Value = DateTime.Now;
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtNhapLai.Text = "";
            txtSoDT.Text = "";
            txtQueQuan.Text = "";
            radNam.Checked = true;
            txtDiaChi.Text = "";
            txtMaNhanVien.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtNhapLai.ReadOnly = false;
            NhanVien nhanVien = new NhanVien();
            CapNhatDSNhanVien();
            txtNhapLai.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtMaNhanVien.ReadOnly = false;
            btnCapNhatNhanVien.Enabled = false;
            btnXoaNhanVien.Enabled = false;
        }
        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.SelectedRows.Count > 0)
            {

                NhanVien nhanVien = (NhanVien)this.dtgNhanVien.SelectedRows[0].DataBoundItem;
                
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + nhanVien.HoTen + " này", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    nhanVien.XoaNhanVien();

                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaNhanVien.Text = "";
                    txtTenNhanVien.Text = "";
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";
                    txtNhapLai.Text = "";
                    txtSoDT.Text = "";
                    txtQueQuan.Text = "";
                    radNam.Checked = true;
                    txtDiaChi.Text = "";
                    CapNhatDSNhanVien();

                }
            }
            btnThemNhanVien.Enabled = true;
            txtNhapLai.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtMaNhanVien.ReadOnly = false;
            btnCapNhatNhanVien.Enabled = false;
            btnXoaNhanVien.Enabled = false;

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if(txtTimNhanVien.Text != "")
            {
                TimNhanVien();
            }
            else
            {
                CapNhatDSNhanVien();
            }
            
        }
        public void TimNhanVien()
        {
            NhanVien nv = new NhanVien();
            List<NhanVien> timNhanVien = nv.TimNhanVien(txtTimNhanVien.Text);
            dtgNhanVien.DataSource = nv.TimNhanVien(txtTimNhanVien.Text);
            dtgNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgNhanVien.ReadOnly = true;
        }


        private void tHÔNGTINCÁNHÂNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan taiKhoan = new frmTaiKhoan();
            this.Hide();
            taiKhoan.ShowDialog();
            this.Show();
        }

        private void sẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham sanPham = new frmSanPham();
            this.Hide();
            sanPham.ShowDialog();
            this.Show();
        }

        private void đĂNGXUẤTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoDT_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnCapNhatNhanVien_Click_1(object sender, EventArgs e)
        {
            string gioiTinh = "";

            if (txtTenNhanVien.Text == "" || txtTenDangNhap.Text == "" || txtSoDT.Text == "" || txtQueQuan.Text == "" || txtDiaChi.Text == "" || cmbChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa Nhập Đầy Đủ Thông Tin!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if (radNam.Checked == true)
                {
                    gioiTinh += "Nam";
                }
                if (radNu.Checked == true)
                {
                    gioiTinh += "Nữ";
                }
                
                NhanVien nhanVien = new NhanVien(int.Parse(txtMaNhanVien.Text),txtTenNhanVien.Text, txtTenDangNhap.Text, txtMatKhau.Text, dtNgaySinh.Value.ToString("dd/MM/yyyy"), gioiTinh, txtSoDT.Text, txtQueQuan.Text, cmbChucVu.Text, txtDiaChi.Text);
                
                if (nhanVien.CapNhatNhanVien())
                {
                    MessageBox.Show("Cập Nhật Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                    txtMaNhanVien.Text = "";
                    txtTenNhanVien.Text = "";
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";
                    txtNhapLai.Text = "";
                    txtSoDT.Text = "";
                    txtQueQuan.Text = "";
                    radNam.Checked = true;
                    txtDiaChi.Text = "";
                    CapNhatDSNhanVien();

                }
                btnThemNhanVien.Enabled = true;
                txtNhapLai.ReadOnly = false;
                txtMatKhau.ReadOnly = false;
                txtMaNhanVien.ReadOnly = false;
                btnCapNhatNhanVien.Enabled = false;
                btnXoaNhanVien.Enabled = false;

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
