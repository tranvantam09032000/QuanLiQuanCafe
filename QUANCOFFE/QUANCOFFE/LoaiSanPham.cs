using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QUANCOFFE
{
    class LoaiSanPham
    {
        public int maLoaiSP;
        public string tenLoaiSP;
        public string trangThai;

        public int MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        public string TenLoaiSP { get => tenLoaiSP; set => tenLoaiSP = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }

        public LoaiSanPham()
        {
           
        }
        public LoaiSanPham(int maLoaiSP, string tenLoaiSP, string trangThai)
        {
            this.maLoaiSP = maLoaiSP;
            this.tenLoaiSP = tenLoaiSP;
            this.trangThai = trangThai;
        }
        public LoaiSanPham( string tenLoaiSP)
        {
            this.tenLoaiSP = tenLoaiSP;
        }
        public LoaiSanPham(int maLoaiSP, string tenLoaiSP)
        {
            this.maLoaiSP = maLoaiSP;
            this.tenLoaiSP = tenLoaiSP;
        }
        public List<LoaiSanPham> DSLoaiSanPham()
        {
            List<LoaiSanPham> dsLoaiSanPham = new List<LoaiSanPham>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaLoaiSP,TenLoaiSP FROM LOAISANPHAM WHERE TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    LoaiSanPham loai = new LoaiSanPham();
                    if (reader.IsDBNull(0) != null)
                    {
                       loai.maLoaiSP =int.Parse( reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        loai.tenLoaiSP = reader["TenLoaiSP"].ToString();
                    }
                    dsLoaiSanPham.Add(loai);
                }
                reader.Close();
                con.Close();
            }
            return dsLoaiSanPham;
        }
        public bool ThemLoaiSP()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("ThemLoaiSanPham", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TenLoaiSP", tenLoaiSP);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
        public bool CapNhatLoaiSP()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("CapNhatLoaiSP", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                com.Parameters.AddWithValue("@TenLoaiSP", tenLoaiSP);
              
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }

        public bool XoaLoaiSP()
        {

            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("XoaLoaiSP", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaLoaiSP", maLoaiSP);
                com.Parameters.AddWithValue("@TrangThai", 0);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
        public List<LoaiSanPham> TimLoaiSP(string tim)
        {
            List<LoaiSanPham> dsLoaiSP = new List<LoaiSanPham>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaLoaiSP, TenLoaiSP FROM LOAISANPHAM WHERE( MaLoaiSP = '"+tim+ "' OR TenLoaiSP LIKE N'%" + tim + "%' ) AND TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    
                    LoaiSanPham loai = new LoaiSanPham();
                    if (reader.IsDBNull(0) != null)
                    {
                        loai.maLoaiSP = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        loai.tenLoaiSP = reader["TenLoaiSP"].ToString();
                    }

                    dsLoaiSP.Add(loai);
                }
                reader.Close();
                con.Close();
            }
            return dsLoaiSP;
        }
    }
}
