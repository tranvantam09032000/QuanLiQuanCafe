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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnThoatDoiMK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ThongTinNhanVien()
        {
            int _ma = frmDangNhap.ma;

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT TenDangNhap FROM NHANVIEN WHERE MaNhanVien = " + _ma + " AND TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nhanVien = new NhanVien();
                    if (reader.IsDBNull(0) != null)
                    {
                        txtMaNhanVien.Text = reader[0].ToString();
                    }
                   
                }
                reader.Close();
                con.Close();
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            ThongTinNhanVien();
            txtMaNhanVien.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            int _ma = frmDangNhap.ma;

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT * FROM NHANVIEN WHERE MaNhanVien = " + _ma + " AND TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    if(txtMatKhauCu.Text == reader[3].ToString())
                    {
                        reader.Close();
                        if (txtMatKhauMoi.Text == txtNhapLaiMK.Text)
                        {
                            int numberrows = 0;
                            if (con != null)
                            {
                                SqlCommand comm = new SqlCommand("UPDATE NHANVIEN SET MatKhau =@MatKhauMoi WHERE MaNhanVien = '"+_ma+"'", con);
                                comm.Parameters.AddWithValue("@MatKhauMoi", txtMatKhauMoi.Text);
                                numberrows = comm.ExecuteNonQuery();
                                con.Close();
                            }
                            if(numberrows > 0)
                            {
                                MessageBox.Show("Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                                txtMatKhauCu.Text = "";
                                txtMatKhauMoi.Text = "";
                                txtNhapLaiMK.Text = "";
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lưu Không Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                                txtMatKhauCu.Text = "";
                                txtMatKhauMoi.Text = "";
                                txtNhapLaiMK.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật Khẩu xác nhận không đúng!", "Thông Báo", MessageBoxButtons.OK);
                            txtMatKhauCu.Text = "";
                            txtMatKhauMoi.Text = "";
                            txtNhapLaiMK.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Cũ Không Chính Xác!", "Thông Báo", MessageBoxButtons.OK);
                        txtMatKhauCu.Text = "";
                    }
                }
             
                con.Close();
            }

        }
        
    }
}
