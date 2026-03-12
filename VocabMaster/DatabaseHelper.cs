using System;
using System.Data;
using System.Data.SqlClient;

namespace VocabMaster
{
    public class DatabaseHelper
    {
        // Chuỗi kết nối SQL Server
        private string _chuoiKetNoi = "Server=.;Database=VocabMasterDB;Integrated Security=True;TrustServerCertificate=True;";

        // Hàm chạy lệnh SELECT, trả về một bảng dữ liệu (DataTable)
        public DataTable LayDuLieu(string cauLenhSql)
        {
            DataTable bangDuLieu = new DataTable();
            using (SqlConnection ketNoi = new SqlConnection(_chuoiKetNoi))
            {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand(cauLenhSql, ketNoi))
                {
                    using (SqlDataAdapter boChuyenDoi = new SqlDataAdapter(lenh))
                    {
                        boChuyenDoi.Fill(bangDuLieu);
                    }
                }
            }
            return bangDuLieu;
        }

        // Hàm chạy lệnh INSERT, UPDATE, DELETE
        public int ThucThiLenh(string cauLenhSql)
        {
            int soDongAnhHuong = 0;
            using (SqlConnection ketNoi = new SqlConnection(_chuoiKetNoi))
            {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand(cauLenhSql, ketNoi))
                {
                    soDongAnhHuong = lenh.ExecuteNonQuery();
                }
            }
            return soDongAnhHuong;
        }
    }
}