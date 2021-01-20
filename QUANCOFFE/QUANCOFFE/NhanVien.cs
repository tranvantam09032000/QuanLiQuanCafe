using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace QUANCOFFE
{
    public class NhanVien
    {
        public int maNhanVien;
        public string hoTen;
        public string tenDangNHap;
        public string matKhau;
        public string ngaySinh;
        public string gioiTinh;
        public string soDienThoai;
        public string queQuan;
        public string chucVu;
        public int trangThai;
        public string diaChi;


        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string TenDangNHap { get => tenDangNHap; set => tenDangNHap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public NhanVien() { }
        public NhanVien(int _maNhanVien, string _hoTen, string _tenDangNHap, string _matKhau, string _ngaySinh, string _gioiTinh, string _soDienThoai, string _queQuan, string _chucVu, int _trangThai, string _diaChi)
        {
            this.MaNhanVien = _maNhanVien;
            this.HoTen = _hoTen;
            this.TenDangNHap = _tenDangNHap;
            this.MatKhau = _matKhau;
            this.NgaySinh = _ngaySinh;
            this.GioiTinh = _gioiTinh;
            this.SoDienThoai = _soDienThoai;
            this.QueQuan = _queQuan;
            this.ChucVu = _chucVu;
            this.TrangThai = _trangThai;
            this.DiaChi = _diaChi;
        }

        public NhanVien(int _maNhanVien, string _hoTen, string _tenDangNHap, string _matKhau, string _ngaySinh, string _gioiTinh, string _soDienThoai, string _queQuan, string _chucVu, string _diaChi)
        {
            this.maNhanVien = _maNhanVien;
            this.HoTen = _hoTen;
            this.TenDangNHap = _tenDangNHap;
            this.MatKhau = _matKhau;
            this.NgaySinh = _ngaySinh;
            this.GioiTinh = _gioiTinh;
            this.SoDienThoai = _soDienThoai;
            this.QueQuan = _queQuan;
            this.ChucVu = _chucVu;
            this.DiaChi = _diaChi;
        }
        public NhanVien(int _maNhanVien, string _matKhau)
        {
            this.maNhanVien = _maNhanVien;
            this.MatKhau = _matKhau;
          
        }

        public NhanVien( string _hoTen, string _tenDangNHap, string _matKhau, string _ngaySinh, string _gioiTinh, string _soDienThoai, string _queQuan, string _chucVu, string _diaChi)
        {
            this.HoTen = _hoTen;
            this.TenDangNHap = _tenDangNHap;
            this.MatKhau = _matKhau;
            this.NgaySinh = _ngaySinh;
            this.GioiTinh = _gioiTinh;
            this.SoDienThoai = _soDienThoai;
            this.QueQuan = _queQuan;
            this.ChucVu = _chucVu;
            this.DiaChi = _diaChi;
        }


        public List<NhanVien> DSNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaNhanVien,HoTen,TenDangNHap,NgaySinh,GioiTinh,SoDienThoai,QueQuan,DiaChi,ChucVu FROM NHANVIEN WHERE TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nhanVien = new NhanVien();
                    if (reader.IsDBNull(0) != null)
                    {
                        nhanVien.maNhanVien = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        nhanVien.hoTen = reader["HoTen"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        nhanVien.tenDangNHap = reader["TenDangNHap"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        nhanVien.ngaySinh = reader["NgaySinh"].ToString();
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        nhanVien.GioiTinh = reader["GioiTinh"].ToString();
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        nhanVien.soDienThoai = reader["SoDienThoai"].ToString();
                    }
                    if (reader.IsDBNull(6) != null)
                    {
                        nhanVien.queQuan = reader["QueQuan"].ToString();
                    }
                    if (reader.IsDBNull(7) != null)
                    {
                        nhanVien.diaChi = reader["DiaChi"].ToString();
                    }
                    if (reader.IsDBNull(8) != null)
                    {
                        nhanVien.chucVu = reader["ChucVu"].ToString();
                    }
                   
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
                con.Close();
            }
            return dsNhanVien;
        }

       

        public bool ThemNhanVien()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("ThemNhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@HoTen", hoTen);
                com.Parameters.AddWithValue("@TenDangNHap", tenDangNHap);
                com.Parameters.AddWithValue("@MatKhau", matKhau);
                com.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                com.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                com.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                com.Parameters.AddWithValue("@QueQuan", QueQuan);
                com.Parameters.AddWithValue("@DiaChi", DiaChi);
                com.Parameters.AddWithValue("@ChucVu", chucVu);

                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }

        public bool CapNhatNhanVien()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("CapNhatNhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaNhanVien",maNhanVien);
                com.Parameters.AddWithValue("@HoTen",hoTen);
                com.Parameters.AddWithValue("@TenDangNHap",tenDangNHap);
                com.Parameters.AddWithValue("@NgaySinh",ngaySinh);
                com.Parameters.AddWithValue("@GioiTinh",gioiTinh);
                com.Parameters.AddWithValue("@SoDienThoai",soDienThoai);
                com.Parameters.AddWithValue("@QueQuan",queQuan);
                com.Parameters.AddWithValue("@DiaChi",diaChi);
                com.Parameters.AddWithValue("@ChucVu",chucVu);
                numberrows = com.ExecuteNonQuery();
                con.Close();
            }
         
            if (numberrows > 0)
                return true;
            else
                return false;
           
        }

        public bool XoaNhanVien()
        {

            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("XoaNhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                com.Parameters.AddWithValue("@TrangThai", 0);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }

        public List<NhanVien> TimNhanVien(string tim)
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaNhanVien,HoTen,TenDangNHap,NgaySinh,GioiTinh,SoDienThoai,QueQuan,DiaChi,ChucVu FROM NHANVIEN WHERE (MaNhanVien = " + tim +" or HoTen LIKE 'N%" + tim + "%'or GioiTinh LIKE N'%" + tim + "%' or QueQuan LIKE N'%" + tim + "%'or DiaChi LIKE N'%" + tim + "%' or ChucVu LIKE N'%" + tim + "%' ) AND TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nhanVien = new NhanVien();
                    if (reader.IsDBNull(0) != null)
                    {
                        nhanVien.maNhanVien = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        nhanVien.hoTen = reader["HoTen"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        nhanVien.tenDangNHap = reader["TenDangNHap"].ToString();
                    }
                 
                    if (reader.IsDBNull(3) != null)
                    {
                        nhanVien.ngaySinh = reader["NgaySinh"].ToString();
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        nhanVien.GioiTinh = reader["GioiTinh"].ToString();
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        nhanVien.soDienThoai = reader["SoDienThoai"].ToString();
                    }
                    if (reader.IsDBNull(6) != null)
                    {
                        nhanVien.queQuan = reader["QueQuan"].ToString();
                    }
                    if (reader.IsDBNull(7) != null)
                    {
                        nhanVien.diaChi = reader["DiaChi"].ToString();
                    }
                    if (reader.IsDBNull(8) != null)
                    {
                        nhanVien.chucVu = reader["ChucVu"].ToString();
                    }
                  
                    dsNhanVien.Add(nhanVien);
                }
                reader.Close();
                con.Close();
            }
            return dsNhanVien;
        }
   
        public bool DoiMatKhau()
        {

            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("DoiMatKhauNhanVien", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                com.Parameters.AddWithValue("@MatKhau", matKhau);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
    }
       
}
