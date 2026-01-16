using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GTranslate.Translators;
using Newtonsoft.Json.Linq;

namespace VocabMaster
{
    public class DichThuatService
    {
        private AggregateTranslator _boDich = new AggregateTranslator();
        private HttpClient _httpClient = new HttpClient();

        public class KetQuaTraCuu
        {
            public string NghiaTiengViet { get; set; } = "";
            public string PhienAm { get; set; } = "";
            public string CacLoaiTu { get; set; } = ""; // Ví dụ: "noun, verb"
        }

        // Hàm chính: Vừa dịch vừa tra từ điển
        public async Task<KetQuaTraCuu> TraCuuTuDayDu(string tuTiengAnh)
        {
            KetQuaTraCuu ketQua = new KetQuaTraCuu();

            // --- PHẦN 1: DỊCH NGHĨA (Quan trọng nhất - Chạy riêng) ---
            try
            {
                var googleResult = await _boDich.TranslateAsync(tuTiengAnh, "vi", "en");
                ketQua.NghiaTiengViet = googleResult.Translation;
            }
            catch
            {
                ketQua.NghiaTiengViet = "Lỗi mạng hoặc không dịch được";
            }

            // --- PHẦN 2: TRA TỪ ĐIỂN (Phụ - Chạy riêng) ---
            // Nếu nhập cả câu, phần này sẽ lỗi -> Kệ nó, không làm ảnh hưởng phần 1
            try
            {
                // Nếu thấy có dấu cách (tức là cụm từ hoặc câu), 
                // thì khỏi gọi API từ điển
                if (tuTiengAnh.Trim().Contains(" "))
                {
                    return ketQua; // Trả về luôn kết quả dịch, bỏ qua đoạn dưới
                }

                string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{Uri.EscapeDataString(tuTiengAnh)}";
                string jsonResponse = await _httpClient.GetStringAsync(url);

                JArray duLieu = JArray.Parse(jsonResponse);
                var entryDauTien = duLieu[0];

                // a. Lấy phiên âm
                var textPhienAm = entryDauTien["phonetic"]?.ToString();
                if (string.IsNullOrEmpty(textPhienAm))
                {
                    textPhienAm = entryDauTien["phonetics"]?.FirstOrDefault(x => x["text"] != null)?["text"]?.ToString();
                // ?["text"]?.ToString()    ? thứ 1: textPhienAm có khác null không, ? thứ 2: lấy text rồi xem nó không null thì ToString()
                }
                ketQua.PhienAm = textPhienAm ?? "";

                // b. Lấy loại từ
                var meanings = entryDauTien["meanings"] as JArray;
                if (meanings != null)
                {
                    var listLoaiTu = meanings
                                     .Select(m => m["partOfSpeech"]?.ToString())
                                     .Where(s => !string.IsNullOrEmpty(s))
                                     .Distinct()
                                     .ToList();
                    ketQua.CacLoaiTu = string.Join(", ", listLoaiTu);
                }
            }
            catch
            {
                // Nếu phần này lỗi (do không tìm thấy từ), cứ lờ đi
                // Để nguyên các ô Phiên âm/Loại từ là rỗng
            }

            return ketQua;
        }
    }
}