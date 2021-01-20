using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANCOFFE
{
    class CTHoaDonNhap
    {
        private int MaCTHoaDonNhap;
        private int MaHoaDonNhap;
        private string MaSanPham;
        private int SoLuong;
        private float DongGia;
        private float ThanhTien;
        private string GhiChu;
        private int TrangThai;
        public CTHoaDonNhap() { }
        public CTHoaDonNhap(int maCTHoaDonNhap, int maHoaDonNhap, string maSanPham, int soLuong, float dongGia, float thanhTien, string ghiChu, int trangThai)
        {
            MaCTHoaDonNhap = maCTHoaDonNhap;
            MaHoaDonNhap = maHoaDonNhap;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            DongGia = dongGia;
            ThanhTien = thanhTien;
            GhiChu = ghiChu;
            TrangThai = trangThai;
        }
        public CTHoaDonNhap(string maSanPham, int soLuong, float dongGia, float thanhTien, int maHoaDonNhap)
        {
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            DongGia = dongGia;
            ThanhTien = thanhTien;
            MaHoaDonNhap = maHoaDonNhap;
        }
        public int MaCTHoaDonNhap1 { get => MaCTHoaDonNhap; set => MaCTHoaDonNhap = value; }
        public int MaHoaDonNhap1 { get => MaHoaDonNhap; set => MaHoaDonNhap = value; }
        public string MaSanPham1 { get => MaSanPham; set => MaSanPham = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public float DongGia1 { get => DongGia; set => DongGia = value; }
        public float ThanhTien1 { get => ThanhTien; set => ThanhTien = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }
        public int TrangThai1 { get => TrangThai; set => TrangThai = value; }

        public List<CTHoaDonNhap> DSCTHoaDonNhap(string maHoaDon)
        {
            List<CTHoaDonNhap> dsCTHoaDonNhap = new List<CTHoaDonNhap>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT HD.MaCTHoaDonNhap,SP.TenSanPham,HD.SoLuong,HD.DonGia,HD.ThanhTien FROM CTHOADONNHAP HD,SANPHAM SP WHERE SP.MaSanPham = HD.MaSanPham AND HD.MaHoaDonNhap = '" + maHoaDon + "' AND  HD.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    CTHoaDonNhap CThoaDon = new CTHoaDonNhap();
                    if (reader.IsDBNull(0) != null)
                    {
                        CThoaDon.MaCTHoaDonNhap1 = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        CThoaDon.MaSanPham1 = reader["TenSanPham"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        CThoaDon.SoLuong1 = int.Parse(reader["SoLuong"].ToString());
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        CThoaDon.DongGia1 = float.Parse(reader["DonGia"].ToString());
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        CThoaDon.ThanhTien1 = float.Parse(reader["ThanhTien"].ToString());
                    }


                    dsCTHoaDonNhap.Add(CThoaDon);
                }
                reader.Close();
                con.Close();
            }
            return dsCTHoaDonNhap;
        }
        public bool ThemSPVaoHoaDonBan()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {


                SqlCommand com = new SqlCommand("ThemSPHoaDonNhap", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaSanPham", MaSanPham1);
                com.Parameters.AddWithValue("@SoLuong", SoLuong1);
                com.Parameters.AddWithValue("@DongGia", DongGia1);
                com.Parameters.AddWithValue("@ThanhTien", ThanhTien1);
                com.Parameters.AddWithValue("@MaHoaDonNhap", MaHoaDonNhap1);

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
        public bool XoaSP()
        {

            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("XoaSPHoaDonNhap", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaCTHoaDonNhap", MaCTHoaDonNhap1);
                com.Parameters.AddWithValue("@TrangThai", 0);
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
