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
  
    public partial class frmDangNhap : Form
    {
        string chucVu = "";
        public static int ma = -1;
        public frmDangNhap()
        {
            InitializeComponent();
        }
     
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ma = MaNhanVien();
            chucVu = ChucVu();
            if (chucVu.Equals("Quản Lý"))
            {

                frmQuanLy quanLy = new frmQuanLy();
                quanLy.ShowDialog();
                txtMatKhau.Text = "";
            }
            else if (chucVu.Equals("Nhân Viên Pha Chế"))
            {

                frmPhaChe phaChe = new frmPhaChe();
                phaChe.ShowDialog();
                txtMatKhau.Text = "";
            }
            else if (chucVu.Equals("Nhân Viên Thu Ngân"))
            {

               frmThuNgan f = new frmThuNgan();
               f.ShowDialog();
                txtMatKhau.Text = "";
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Thông Báo", MessageBoxButtons.OK);
                txtMatKhau.Text = "";
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát!", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        public string ChucVu()
        {

            string chucvu = "";

            SqlConnection con = KetNoi.taoketnoi();
            SqlCommand com = new SqlCommand("SELECT * FROM NHANVIEN WHERE TenDangNHap ='" + txtTenDangNhap.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS AND MatKhau ='" + txtMatKhau.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS  AND TrangThai = 1", con);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    chucvu = dr["ChucVu"].ToString();
                }
            }


            con.Close();

            return chucvu;

        }
        public int MaNhanVien()
        {
            int ma = -1;

            SqlConnection con = KetNoi.taoketnoi();
            SqlCommand com = new SqlCommand("SELECT * FROM NHANVIEN WHERE TenDangNHap ='" + txtTenDangNhap.Text + "' AND MatKhau='" + txtMatKhau.Text + "' AND TrangThai = 1", con);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ma = int.Parse(dr["MaNhanVien"].ToString());
                }
            }


            con.Close();

            return ma;

        }


    }
}
