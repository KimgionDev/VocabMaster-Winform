using System;

namespace VocabMaster
{
    public class TuVungKho
    {
        public int IdTuVung { get; set; }
        public int SoLanSai { get; set; }
        public DateTime NgaySaiCuoiCung { get; set; }

        // Navigation property để lấy thông tin chi tiết từ vựng nếu cần
        public TuVung ThongTinTuVung { get; set; }

        public TuVungKho()
        {
            NgaySaiCuoiCung = DateTime.Now;
            SoLanSai = 0;
        }
    }
}