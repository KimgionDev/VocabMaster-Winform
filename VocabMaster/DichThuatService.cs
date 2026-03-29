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

            try
            {
                var googleResult = await _boDich.TranslateAsync(tuTiengAnh, "vi", "en");
                ketQua.NghiaTiengViet = googleResult.Translation;
            }
            catch
            {
                ketQua.NghiaTiengViet = "Lỗi mạng hoặc không dịch được";
            }

            try
            {
                // Nếu thấy có dấu cách (tức là cụm từ hoặc câu)
                // thì khỏi gọi API từ điển
                if (tuTiengAnh.Trim().Contains(" "))
                {
                    return ketQua;
                }
                // Gọi API từ điển
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
                // Nếu lỗi (ví dụ: không tìm thấy từ), thì để trống phần phiên âm và loại từ
            }

            return ketQua;
        }
    }
}