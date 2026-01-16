using System;
using System.Collections.Generic;
using System.IO; // Để thao tác với File
using Newtonsoft.Json;

namespace VocabMaster
{
    public class KhoDuLieuJSON
    {
        private string _duongDanFile = "dulieu_tuvung.json";
        // Hàm Đọc: Lấy dữ liệu từ file lên RAM
        public List<TuVung> DocDuLieu()
        {
            if (!File.Exists(_duongDanFile))
            {
                return new List<TuVung>();
            }

            string noiDungFile = File.ReadAllText(_duongDanFile);

            // Biến đóng chữ đó thành danh sách TuVung (Deserialize)
            var ketQua = JsonConvert.DeserializeObject<List<TuVung>>(noiDungFile);

            return ketQua ?? new List<TuVung>(); // Nếu lỗi thì trả về rỗng
        }

        // 3. Hàm Lưu: Ghi dữ liệu từ RAM xuống file
        public void LuuDuLieu(List<TuVung> danhSachTu)
        {
            // Biến danh sách thành chuỗi JSON (Serialize)
            // Formatting.Indented giúp thụt file cho đẹp
            string noiDungJson = JsonConvert.SerializeObject(danhSachTu, Formatting.Indented);

            // Ghi đè vào file
            File.WriteAllText(_duongDanFile, noiDungJson);
        }
    }
}