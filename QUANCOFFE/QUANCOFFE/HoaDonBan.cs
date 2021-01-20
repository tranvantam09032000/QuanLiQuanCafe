using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QUANCOFFE
{
    class HoaDonBan
    {
        private int maHoaDonBan;
        private int maNhanVien;
        private string tenKhachHang;
        private string ngayLap;
        private float tongTien;
        private string ghiChu;
        private int trangThai;
        private string TenNhanVien;

        public int MaHoaDonBan { get => maHoaDonBan; set => maHoaDonBan = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string NgayLap { get => ngayLap; set => ngayLap = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string TenNhanVien1 { get => TenNhanVien; set => TenNhanVien = value; }

        public HoaDonBan() { }
        public HoaDonBan(int maHoaDonBan, int maNhanVien, string tenKhachHang, string ngayLap, float tongTien, string ghiChu, int trangThai,string tenNhanVien)
        {
            MaHoaDonBan = maHoaDonBan;
            MaNhanVien = maNhanVien;
            TenKhachHang = tenKhachHang;
            NgayLap = ngayLap;
            TongTien = tongTien;
            GhiChu = ghiChu;
            TrangThai = trangThai;
            TenNhanVien1 = tenNhanVien;
        }
        public HoaDonBan(int maHoaDonBan, string ghiChu)
        {
            MaHoaDonBan = maHoaDonBan;
            GhiChu = ghiChu;
        }
        public HoaDonBan(int maHoaDonBan, float tongTien)
        {
            MaHoaDonBan = maHoaDonBan;
            TongTien = tongTien;
        }
        public HoaDonBan( int maNhanVien, string tenKhachHang, string ngayLap, float tongTien, string ghiChu,string tenNhanVien)
        {
            MaNhanVien = maNhanVien;
            TenKhachHang = tenKhachHang;
            NgayLap = ngayLap;
            TongTien = tongTien;
            GhiChu = ghiChu;
            TenNhanVien1 = tenNhanVien;
        }


        public List<HoaDonBan> DSHoaDonBan()
        {
            List<HoaDonBan> dsHoaDonBan = new List<HoaDonBan>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT HDB.MaHoaDonBan,HDB.MaNhanVien,HDB.TenKhachHang,HDB.NgayLap,HDB.TongTien,HDB.GhiChu,NV.HoTen FROM HOADONBAN HDB,NHANVIEN NV WHERE HDB.MaNhanVien = NV.MaNhanVien AND HDB.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonBan hoaDon = new HoaDonBan();
                    if (reader.IsDBNull(0) != null)
                    {
                        hoaDon.MaHoaDonBan = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        hoaDon.MaNhanVien =int.Parse( reader["MaNhanVien"].ToString());
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        hoaDon.TenKhachHang = reader["TenKhachHang"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                       hoaDon.NgayLap = reader["NgayLap"].ToString();
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                       hoaDon.TongTien = float.Parse(reader["TongTien"].ToString());
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                       hoaDon.GhiChu = reader["GhiChu"].ToString();
                    }
                    if (reader.IsDBNull(6) != null)
                    {
                        hoaDon.TenNhanVien1 = reader["HoTen"].ToString();
                    }


                    dsHoaDonBan.Add(hoaDon);
                }
                reader.Close();
                con.Close();
            }
            return dsHoaDonBan;
        }

        public bool TaoHoaDon()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {

                SqlCommand com = new SqlCommand("TaoHoaDonBan", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                com.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
                com.Parameters.AddWithValue("@ngaylap", NgayLap);
                com.Parameters.AddWithValue("@TongTien",TongTien);
                com.Parameters.AddWithValue("@GhiChu", GhiChu);

                numberrows = com.ExecuteNonQuery();
            }
         
            if (numberrows > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool CapNhatHoaDonBan()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("CapNhatHoaDonBan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaHoaDonBan", maHoaDonBan);
                com.Parameters.AddWithValue("@GhiChu",GhiChu);
               
                numberrows = com.ExecuteNonQuery();
                con.Close();
            }

            if (numberrows > 0)
                return true;
            else
                return false;

        }
        public bool ThanhToanHoaDonBan()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("TongTienHoaDonBan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaHoaDonBan", maHoaDonBan);
                com.Parameters.AddWithValue("@TongTien", tongTien);

                numberrows = com.ExecuteNonQuery();
                con.Close();
            }

            if (numberrows > 0)
                return true;
            else
                return false;

        }
        public List<HoaDonBan> TimHoaDonBan(string ngayBatDau,string ngayKetThuc)
        {
            List<HoaDonBan> dsHoaDonBan = new List<HoaDonBan>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT HDB.MaHoaDonBan,HDB.MaNhanVien,HDB.TenKhachHang,HDB.NgayLap,HDB.TongTien,HDB.GhiChu,NV.HoTen FROM HOADONBAN HDB,NHANVIEN NV WHERE ( HDB.NgayLap BETWEEN '" + ngayBatDau + "' AND '" + ngayKetThuc +"') AND NV.MaNhanVien = HDB.MaNhanVien  AND HDB.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonBan hoaDon = new HoaDonBan();
                    if (reader.IsDBNull(0) != null)
                    {
                        hoaDon.MaHoaDonBan = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        hoaDon.MaNhanVien = int.Parse(reader["MaNhanVien"].ToString());
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        hoaDon.TenKhachHang = reader["TenKhachHang"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        hoaDon.NgayLap = reader["NgayLap"].ToString();
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        hoaDon.TongTien = float.Parse(reader["TongTien"].ToString());
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        hoaDon.GhiChu = reader["GhiChu"].ToString();
                    }
                    if (reader.IsDBNull(6) != null)
                    {
                        hoaDon.TenNhanVien1 = reader["HoTen"].ToString();
                    }


                    dsHoaDonBan.Add(hoaDon);
                }
                reader.Close();
                con.Close();
            }
            return dsHoaDonBan;
        }
        public bool XoaHoaDonBan()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("XoaHoaDon", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaHoaDonBan", maHoaDonBan);
                com.Parameters.AddWithValue("@TrangThai", 0);

                numberrows = com.ExecuteNonQuery();
                con.Close();
            }

            if (numberrows > 0)
                return true;
            else
                return false;

        }
        public List<HoaDonBan> DSHoaDonPhaChe()
        {
            List<HoaDonBan> dsHoaDonBan = new List<HoaDonBan>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT HDB.MaHoaDonBan,HDB.MaNhanVien,HDB.TenKhachHang,HDB.NgayLap,HDB.TongTien,NV.HoTen FROM HOADONBAN HDB,NHANVIEN NV WHERE (HDB.MaNhanVien = NV.MaNhanVien )AND (HDB.TrangThai = 1) AND HDB.GhiChu = '' ", con);// AND(HDB.NgayLap = '"+DateTime.Now+"')
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonBan hoaDon = new HoaDonBan();
                    if (reader.IsDBNull(0) != null)
                    {
                        hoaDon.MaHoaDonBan = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        hoaDon.MaNhanVien = int.Parse(reader["MaNhanVien"].ToString());
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        hoaDon.TenKhachHang = reader["TenKhachHang"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        hoaDon.NgayLap = reader["NgayLap"].ToString();
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        hoaDon.TongTien = float.Parse(reader["TongTien"].ToString());
                    }
                    if (reader.IsDBNull(5) != null)
                    {
                        hoaDon.TenNhanVien1 = reader["HoTen"].ToString();
                    }


                    dsHoaDonBan.Add(hoaDon);
                }
                reader.Close();
                con.Close();
            }
            return dsHoaDonBan;
        }
    }

}
