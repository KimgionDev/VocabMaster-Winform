using System;
using System.Data;
using System.Data.SqlClient;

namespace VocabMaster {
    public class DatabaseHelper {
        // Chuỗi kết nối SQL Server
        private readonly string _chuoiKetNoi =
            Environment.GetEnvironmentVariable("VOCABMASTER_CONNECTION_STRING")
            ?? "Server=.;Database=VocabMasterDB;Integrated Security=True;TrustServerCertificate=True;";
        
        // Hàm chạy lệnh SELECT, trả về một bảng dữ liệu (DataTable)
        public DataTable LayDuLieu(string cauLenhSql) {
            return LayDuLieu(cauLenhSql, Array.Empty<SqlParameter>());
        }

        public DataTable LayDuLieu(string cauLenhSql, params SqlParameter[] thamSo) {
            DataTable bangDuLieu = new DataTable();
            using (SqlConnection ketNoi = new SqlConnection(_chuoiKetNoi)) {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand(cauLenhSql, ketNoi)) {
                    lenh.Parameters.AddRange(thamSo);
                    using (SqlDataAdapter boChuyenDoi = new SqlDataAdapter(lenh)) {
                        boChuyenDoi.Fill(bangDuLieu);
                    }
                }
            }
            
            return bangDuLieu;
        }
        
        // Hàm chạy lệnh INSERT, UPDATE, DELETE
        public int ThucThiLenh(string cauLenhSql) {
            int soDongAnhHuong = 0;
            using (SqlConnection ketNoi = new SqlConnection(_chuoiKetNoi)) {
                ketNoi.Open();
                using (SqlCommand lenh = new SqlCommand(cauLenhSql, ketNoi)) {
                    soDongAnhHuong = lenh.ExecuteNonQuery();
                }
            }
            
            return soDongAnhHuong;
        }
    }
}
