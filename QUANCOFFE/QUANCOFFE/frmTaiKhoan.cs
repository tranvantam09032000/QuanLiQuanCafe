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
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnThoatTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            ThongTinNhanVien();
            txtMaNhanVien.ReadOnly = true;
            txtTenDangNhap.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtNgaySinh.ReadOnly = true;
            txtQueQuan.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtGioiTinh.ReadOnly = true;
            txtChuVu.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
        }

        public void ThongTinNhanVien()
        {
            int _ma = frmDangNhap.ma;
           
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaNhanVien,HoTen,TenDangNHap,NgaySinh,GioiTinh,SoDienThoai,QueQuan,DiaChi,ChucVu FROM NHANVIEN WHERE MaNhanVien = "+_ma+" AND TrangThai = 1", con);
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
                    if (reader.IsDBNull(2) != null)
                    {
                        txtTenDangNhap.Text = reader["TenDangNHap"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        txtNgaySinh.Text = reader["NgaySinh"].ToString();
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                       txtGioiTinh.Text= reader["GioiTinh"].ToString();
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        txtSoDienThoai.Text = reader["SoDienThoai"].ToString();
                    }
                    if (reader.IsDBNull(6) != null)
                    {
                        txtQueQuan.Text = reader["QueQuan"].ToString();
                    }
                    if (reader.IsDBNull(7) != null)
                    {
                        txtDiaChi.Text = reader["DiaChi"].ToString();
                    }
                    if (reader.IsDBNull(8) != null)
                    {
                        txtChuVu.Text = reader["ChucVu"].ToString();
                    }
                }
                reader.Close();
                con.Close();
            }
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
        }
    }
}
