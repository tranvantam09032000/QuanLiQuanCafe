using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QUANCOFFE
{
    class CTHoaDonBan
    {
        private int MaCTHoaDonBan;
        private int MaHoaDonBan;
        private string MaSanPham;
        private int SoLuong;
        private float DongGia;
        private float ThanhTien;
        private string GhiChu;
        private int TrangThai;
        public CTHoaDonBan() { }
        public CTHoaDonBan(int maCTHoaDonBan, int maHoaDonBan, string maSanPham, int soLuong, float dongGia, float thanhTien, string ghiChu, int trangThai)
        {
            MaCTHoaDonBan = maCTHoaDonBan;
            MaHoaDonBan = maHoaDonBan;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            DongGia = dongGia;
            ThanhTien = thanhTien;
            GhiChu = ghiChu;
            TrangThai = trangThai;
        }
        public CTHoaDonBan( string maSanPham, int soLuong, float dongGia, float thanhTien,int maHoaDonBan)
        {
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            DongGia = dongGia;
            ThanhTien = thanhTien;
            MaHoaDonBan = maHoaDonBan;
        }
        public int MaCTHoaDonBan1 { get => MaCTHoaDonBan; set => MaCTHoaDonBan = value; }
        public int MaHoaDonBan1 { get => MaHoaDonBan; set => MaHoaDonBan = value; }
        public string MaSanPham1 { get => MaSanPham; set => MaSanPham = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public float DongGia1 { get => DongGia; set => DongGia = value; }
        public float ThanhTien1 { get => ThanhTien; set => ThanhTien = value; }
        public string GhiChu1 { get => GhiChu; set => GhiChu = value; }
        public int TrangThai1 { get => TrangThai; set => TrangThai = value; }

        public List<CTHoaDonBan> DSCTHoaDonBan(string maHoaDon)
        {
            List<CTHoaDonBan> dsCTHoaDonBan = new List<CTHoaDonBan>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaCTHoaDonBan,sp.TenSanPham,SoLuong,DongGia,ThanhTien FROM CTHOADONBAN HD,SANPHAM SP WHERE SP.MaSanPham = hd.MaSanPham AND MaHoaDonBan = '"+maHoaDon+"' AND  HD.TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    CTHoaDonBan CThoaDon = new CTHoaDonBan();
                    if (reader.IsDBNull(0) != null)
                    {
                        CThoaDon.MaCTHoaDonBan1 =int.Parse(reader[0].ToString());
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
                        CThoaDon.DongGia1 = float.Parse(reader["DongGia"].ToString());
                    }
                    if (reader.IsDBNull(4) != null)
                    {
                        CThoaDon.ThanhTien1 =float.Parse( reader["ThanhTien"].ToString());
                    }
        

                    dsCTHoaDonBan.Add(CThoaDon);
                }
                reader.Close();
                con.Close();
            }
            return dsCTHoaDonBan;
        }
        public bool ThemSPVaoHoaDonBan()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
             

                SqlCommand com = new SqlCommand("ThemSPHoaDonBan", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaHoaDonBan", MaHoaDonBan);
                com.Parameters.AddWithValue("@MaSanPham", MaSanPham);
                com.Parameters.AddWithValue("@SoLuong", SoLuong);
                com.Parameters.AddWithValue("@DongGia",DongGia);
                com.Parameters.AddWithValue("@ThanhTien", ThanhTien);
           

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
                SqlCommand com = new SqlCommand("XoaSPHoaDonBan", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaCTHoaDonBan", MaCTHoaDonBan);
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
