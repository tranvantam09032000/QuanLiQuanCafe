using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QUANCOFFE
{
    class NhaCungCap
    {
        public int maNhaCungCap;
        public string tenNhaCungCap;
        public string soDienThoai;
        public string diaChi;
        public int trangThai;

        public int MaNhaCungCap { get => maNhaCungCap; set => maNhaCungCap = value; }
        public string TenNhaCungCap { get => tenNhaCungCap; set => tenNhaCungCap = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }

        public NhaCungCap()
        {

        }
        public NhaCungCap(int maNhaCungCap, string tenNhaCungCap, string soDienThoai, string diaChi, int trangThai)
        {
            this.MaNhaCungCap = maNhaCungCap;
            this.TenNhaCungCap = tenNhaCungCap;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.TrangThai = trangThai;
        }
        public NhaCungCap(int maNhaCungCap, string tenNhaCungCap, string soDienThoai, string diaChi)
        {
            this.MaNhaCungCap = maNhaCungCap;
            this.TenNhaCungCap = tenNhaCungCap;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
        }
        public NhaCungCap( string tenNhaCungCap, string soDienThoai, string diaChi)
        {
       
            this.TenNhaCungCap = tenNhaCungCap;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
           
        }
        public List<NhaCungCap> DSNhaCungCap()
        {
            List<NhaCungCap> dsNhaCungCap = new List<NhaCungCap>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT MaNhaCungCap,TenNhaCungCap,SoDienThoai,DiaChi FROM NHACUNGCAP WHERE TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCap nhaCungCap = new NhaCungCap();
                    if (reader.IsDBNull(0) != null)
                    {
                        nhaCungCap.maNhaCungCap = int.Parse( reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                       nhaCungCap.tenNhaCungCap = reader["TenNhaCungCap"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        nhaCungCap.soDienThoai = reader["SoDienThoai"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        nhaCungCap.diaChi= reader["DiaChi"].ToString();
                    }
                    dsNhaCungCap.Add(nhaCungCap);
                }
                reader.Close();
                con.Close();
            }
            return dsNhaCungCap;
        }
       
        public bool ThemNhaCungCap()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("ThemNhaCungCap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TenNhaCungCap", tenNhaCungCap);
                com.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                com.Parameters.AddWithValue("@DiaChi", diaChi);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
        public bool CapNhatNhaCungCap()
        {
            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("CapNhatNhaCungCap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap);
                com.Parameters.AddWithValue("@TenNhaCungCap", tenNhaCungCap);
                com.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                com.Parameters.AddWithValue("@DiaChi", diaChi);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }

        public bool XoaNhaCungCap()
        {

            int numberrows = 0;
            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("XoaNhaCungCap", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MaNhaCungCap",maNhaCungCap);
                com.Parameters.AddWithValue("@TrangThai", 0);
                numberrows = com.ExecuteNonQuery();
            }
            if (numberrows > 0)
                return true;
            else
                return false;
            con.Close();
        }
        public List<NhaCungCap> TimNhaCungCap(string tim)
        {
            List<NhaCungCap> dsNhaCungCap = new List<NhaCungCap>();

            SqlConnection con = KetNoi.taoketnoi();
            if (con != null)
            {
                SqlCommand com = new SqlCommand("SELECT * FROM NHACUNGCAP WHERE (MaNhaCungCap = '" + tim + "' or TenNhaCungCap LIKE N'%" + tim + "%' or DiaChi LIKE N'%" + tim + "%') AND TrangThai = 1", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCap nhaCungCap = new NhaCungCap();
                    if (reader.IsDBNull(0) != null)
                    {
                        nhaCungCap.maNhaCungCap = int.Parse(reader[0].ToString());
                    }
                    if (reader.IsDBNull(1) != null)
                    {
                        nhaCungCap.tenNhaCungCap = reader["TenNhaCungCap"].ToString();
                    }
                    if (reader.IsDBNull(2) != null)
                    {
                        nhaCungCap.soDienThoai = reader["SoDienThoai"].ToString();
                    }
                    if (reader.IsDBNull(3) != null)
                    {
                        nhaCungCap.diaChi = reader["DiaChi"].ToString();
                    }

                    if (reader.IsDBNull(4) != null)
                    {
                        nhaCungCap.trangThai = (int)reader["TrangThai"];
                    }

                    dsNhaCungCap.Add(nhaCungCap);
                }
                reader.Close();
                con.Close();
            }
            return dsNhaCungCap;
        }
    }
}
