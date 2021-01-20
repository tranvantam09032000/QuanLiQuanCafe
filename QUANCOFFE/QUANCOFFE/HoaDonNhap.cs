using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QUANCOFFE
{
    class HoaDonNhap
    {
        private int maHoaDonNhap;
        private int maNhanVien;
        private string maNhaCungCap;
        private string ngayLap;
        private float tongTien;
        private string ghiChu;
        private int trangThai;
        private string tenNhanVien;

        public int MaHoaDonNhap { get => maHoaDonNhap; set => maHoaDonNhap = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }
        public string NgayLap { get => ngayLap; set => ngayLap = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }

        public HoaDonNhap() { }
        public HoaDonNhap(int maHoaDonNhap, int maNhanVien, string maNhaCungCap, string ngayLap, float tongTien, string ghiChu, int trangThai, string tenNhanVien)
        {
            MaHoaDonNhap = maHoaDonNhap;
            MaNhanVien = maNhanVien;
            MaNhaCungCap = maNhaCungCap;
            NgayLap = ngayLap;
            TongTien = tongTien;
            GhiChu = ghiChu;
            TrangThai = trangThai;
            TenNhanVien = tenNhanVien;
        }
        public HoaDonNhap(int maHoaDonNhap, string ghiChu)
        {
            MaHoaDonNhap = maHoaDonNhap;
            GhiChu = ghiChu;
        }
        public HoaDonNhap(int maHoaDonNhap, float tongTien)
        {
            MaHoaDonNhap = maHoaDonNhap;
            TongTien = tongTien;
        }
        public HoaDonNhap(int maNhanVien, string maNhaCungCap, string ngayLap, float tongTien, string ghiChu, string tenNhanVien)
        {
            MaNhanVien = maNhanVien;
            MaNhaCungCap = maNhaCungCap;
            NgayLap = ngayLap;
            TongTien = tongTien;
            GhiChu = ghiChu;
            TenNhanVien = tenNhanVien;
        }


        public List<HoaDonNhap> DSHoaDonNhap()
        {
            List<HoaDonNhap> dsHoaDonNhap = new List<HoaDonNhap>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT HDN.MaHoaDonNhap,HDN.MaNhanVien,CC.TenNhaCungCap,HDN.NgayLap,HDN.TongTien,HDN.GhiChu,NV.HoTen FROM HOADONNHAP HDN,NHANVIEN NV,NHACUNGCAP CC WHERE HDN.MaNhaCungCap = CC.MaNhaCungCap AND HDN.MaNhanVien = NV.MaNhanVien AND HDN.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonNhap hoaDon = new HoaDonNhap();
                    if (reader.IsDBNull(0) != null)
                    {
                        hoaDon.MaHoaDonNhap = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        hoaDon.MaNhanVien = int.Parse(reader["MaNhanVien"].ToString());
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        hoaDon.MaNhaCungCap = reader["TenNhaCungCap"].ToString();
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
                        hoaDon.TenNhanVien = reader["HoTen"].ToString();
                    }


                    dsHoaDonNhap.Add(hoaDon);
                }
                reader.Close();
                con.Close();
            }
            return dsHoaDonNhap;
        }

        public bool TaoHoaDon()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {

                SqlCommand com = new SqlCommand("TaoHoaDonNhap", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                com.Parameters.AddWithValue("@TenNhanVien", TenNhanVien);
                com.Parameters.AddWithValue("@MaNhaCungCap",MaNhaCungCap);
                com.Parameters.AddWithValue("@Ngaylap", NgayLap);
                com.Parameters.AddWithValue("@TongTien", TongTien);
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
                SqlCommand com = new SqlCommand("CapNhatHoaDonNhap", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaHoaDonNhap", MaHoaDonNhap);
                com.Parameters.AddWithValue("@GhiChu", GhiChu);

                numberrows = com.ExecuteNonQuery();
                con.Close();
            }

            if (numberrows > 0)
                return true;
            else
                return false;

        }
        public bool ThanhToanHoaDonNhap()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("TongTienHoaDonNhap", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaHoaDonNhap", MaHoaDonNhap);
                com.Parameters.AddWithValue("@TongTien", TongTien);

                numberrows = com.ExecuteNonQuery();
                con.Close();
            }

            if (numberrows > 0)
                return true;
            else
                return false;

        }
        
        public bool XoaHoaDonBan()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("XoaHoaDonNhap", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaHoaDonNhap", MaHoaDonNhap);
                com.Parameters.AddWithValue("@TrangThai", 0);

                numberrows = com.ExecuteNonQuery();
                con.Close();
            }

            if (numberrows > 0)
                return true;
            else
                return false;

        }
        public List<HoaDonNhap> TimHoaDonNhap(string ngayBatDau , string ngayKetThuc)
        {
            List<HoaDonNhap> dsHoaDonNhap = new List<HoaDonNhap>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT HDN.MaHoaDonNhap,HDN.MaNhanVien,CC.TenNhaCungCap,HDN.NgayLap,HDN.TongTien,HDN.GhiChu,NV.HoTen FROM HOADONNHAP HDN,NHANVIEN NV ,NHACUNGCAP CC  WHERE( HDN.MaNhaCungCap = CC.MaNhaCungCap AND HDN.MaNhanVien = NV.MaNhanVien) AND (NgayLap BETWEEN '" + ngayBatDau+"' AND '"+ngayKetThuc+"' ) AND HDN.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    HoaDonNhap hoaDon = new HoaDonNhap();
                    if (reader.IsDBNull(0) != null)
                    {
                        hoaDon.MaHoaDonNhap = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        hoaDon.MaNhanVien = int.Parse(reader["MaNhanVien"].ToString());
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        hoaDon.MaNhaCungCap = reader["TenNhaCungCap"].ToString();
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
                        hoaDon.TenNhanVien = reader["HoTen"].ToString();
                    }


                    dsHoaDonNhap.Add(hoaDon);
                }
                reader.Close();
                con.Close();
            }
            return dsHoaDonNhap;
        }

    }
}
