using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QUANCOFFE
{
    class KetNoi
    {
        public static string chuoiKetNoi = @"Data Source = DESKTOP-R56L2FG\SQLEXPRESS; Initial Catalog = QUANCOFFE; Integrated Security = true";

        public static SqlConnection taoketnoi()
        {
            //tạo kết nối
            SqlConnection conn = null;
            try
            {// khởi tạo 
                conn = new SqlConnection(chuoiKetNoi);
                conn.Open();

            }
            catch (Exception ex)
            {
                return null;
            }
            return conn;
        }
    }
}
