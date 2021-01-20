using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace QUANCOFFE
{
    public class SanPham
    {
        public int maSanPham;
        public string tenSanPham;
        public string loai;
        public float giaBan;
        public string nhaSanXuat;
        public int trangThai;
        public int soLuong;


        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string Loai { get => loai; set => loai = value; }
        public float GiaBan { get => giaBan; set => giaBan = value; }
        public string NhaSanXuat { get => nhaSanXuat; set => nhaSanXuat = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public SanPham() { }
        public SanPham(int _maSanPham, string _tenSanPham, float _giaBan, string _loai, string _nhaSanXuat, int _trangThai,int _soLuong)
        {
            this.maSanPham = _maSanPham;
            this.tenSanPham = _tenSanPham;
            this.giaBan = _giaBan;
            this.loai = _loai;
            this.nhaSanXuat = _nhaSanXuat;
            this.trangThai = _trangThai;
            this.soLuong = _soLuong;
        }
        public SanPham(string _tenSanPham, float _giaBan, string _loai, string _nhaSanXuat,int _soLuong)
        {
            this.tenSanPham = _tenSanPham;
            this.giaBan = _giaBan;
            this.loai = _loai;
            this.nhaSanXuat = _nhaSanXuat;
            this.soLuong = _soLuong;
        }
        public SanPham(int _maSanPham, string _tenSanPham,  float _giaBan, string _loai, string _nhaSanXuat, int _soLuong)
        {
            this.maSanPham = _maSanPham;
            this.tenSanPham = _tenSanPham;
            this.giaBan = _giaBan;
            this.loai = _loai;
            this.nhaSanXuat = _nhaSanXuat;
            this.soLuong = _soLuong;
        }

        public SanPham(int _maSanPham, int _soLuong)
        {
            this.maSanPham = _maSanPham;
            this.soLuong = _soLuong;
        }
        public List<SanPham> DSSanPham()
        {
            List<SanPham> dsSanPham = new List<SanPham>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT sp.MaSanPham , sp.TenSanPham ,lsp.TenLoaiSP, sp.GiaBan,ncc.TenNhaCungCap,sp.SoLuongTon  FROM SANPHAM sp, LOAISANPHAM lsp, NHACUNGCAP ncc WHERE ( lsp.MaLoaiSP = sp.Loai AND ncc.MaNhaCungCap = sp.NhaSanXuat) AND sp.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sanPham = new SanPham();
                    if (reader.IsDBNull(0) != null)
                    {
                        sanPham.maSanPham = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        sanPham.tenSanPham = reader["TenSanPham"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        sanPham.loai= reader["TenLoaiSP"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        sanPham.giaBan =float.Parse(reader["GiaBan"].ToString());
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        sanPham.nhaSanXuat=reader["TenNhaCungCap"].ToString();
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        sanPham.soLuong =int.Parse( reader["SoLuongTon"].ToString());
                    }

                    dsSanPham.Add(sanPham);
                }
                reader.Close();
                con.Close();
            }
            return dsSanPham;
        }
        public bool ThemSanPham()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("ThemSanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TenSanPham", tenSanPham);
                com.Parameters.AddWithValue("@GiaBan",giaBan);
                com.Parameters.AddWithValue("@Loai", loai);
                com.Parameters.AddWithValue("@NhaSanXuat",nhaSanXuat);
                com.Parameters.AddWithValue("@SoLuongTon", soLuong);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
        public bool XoaSanPham()
        {

            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("XoaSanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaSanPham", maSanPham);
                com.Parameters.AddWithValue("@TrangThai", 0);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
        public bool CapNhatSanPham()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("CapNhatSanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaSanPham",maSanPham);
                com.Parameters.AddWithValue("@TenSanPham",tenSanPham);
                com.Parameters.AddWithValue("@GiaBan", GiaBan);
                com.Parameters.AddWithValue("@Loai", loai);
                com.Parameters.AddWithValue("@NhaSanXuat", NhaSanXuat);
                com.Parameters.AddWithValue("@SoLuongTon", soLuong);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }

        public bool CapNhatSoLuongTon()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("CapNhatSoLuongTon", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaSanPham", maSanPham);
                com.Parameters.AddWithValue("@SoLuongTon", soLuong);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
        public List<SanPham> TimSanPham(string tim )
        {
            List<SanPham> dsSanPham = new List<SanPham>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT sp.MaSanPham , sp.TenSanPham ,lsp.TenLoaiSP, sp.GiaBan,ncc.TenNhaCungCap,sp.SoLuongTon  FROM SANPHAM sp, LOAISANPHAM lsp, NHACUNGCAP ncc WHERE ( lsp.MaLoaiSP = sp.Loai AND ncc.MaNhaCungCap = sp.NhaSanXuat) AND (sp.MaSanPham  =  '"+ tim +"' or sp.TenSanPham LIKE 'N%" + tim + "%'or sp.GiaBan LIKE N'%" + tim + "%' or lsp.TenLoaiSP LIKE N'%" + tim + "%'or ncc.TenNhaCungCap LIKE N'%" + tim + "%' ) AND sp.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sanPham = new SanPham();
                    if (reader.IsDBNull(0) != null)
                    {
                        sanPham.maSanPham = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        sanPham.tenSanPham = reader["TenSanPham"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        sanPham.loai = reader["TenLoaiSP"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        sanPham.giaBan = float.Parse(reader["GiaBan"].ToString());
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        sanPham.nhaSanXuat = reader["TenNhaCungCap"].ToString();
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        sanPham.soLuong = int.Parse(reader["SoLuongTon"].ToString());
                    }

                    dsSanPham.Add(sanPham);
                }
                reader.Close();
                con.Close();
            }
            return dsSanPham;
        }
        public List<SanPham> cmbDSSanPham(string maLoai)
        {
            List<SanPham> dsSanPham = new List<SanPham>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT sp.MaSanPham , sp.TenSanPham ,lsp.TenLoaiSP, sp.GiaBan,ncc.TenNhaCungCap,sp.SoLuongTon  FROM SANPHAM sp, LOAISANPHAM lsp, NHACUNGCAP ncc WHERE Loai = '"+maLoai+"' AND ( lsp.MaLoaiSP = sp.Loai AND ncc.MaNhaCungCap = sp.NhaSanXuat) AND sp.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    SanPham sanPham = new SanPham();
                    if (reader.IsDBNull(0) != null)
                    {
                        sanPham.maSanPham = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        sanPham.tenSanPham = reader["TenSanPham"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        sanPham.loai = reader["TenLoaiSP"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        sanPham.giaBan = float.Parse(reader["GiaBan"].ToString());
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        sanPham.nhaSanXuat = reader["TenNhaCungCap"].ToString();
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        sanPham.soLuong = int.Parse(reader["SoLuongTon"].ToString());
                    }

                    dsSanPham.Add(sanPham);
                }
                reader.Close();
                con.Close();
            }
            return dsSanPham;
        }
    }

}
