using System;

namespace VocabMaster
{
    public class LichSuHocTap
    {
        public int IdLichSu { get; set; }
        public DateTime NgayHoc { get; set; }
        public int SoCauDung { get; set; }
        public int TongSoCau { get; set; }
        public double TiLePhanTram { get; set; }

        public LichSuHocTap()
        {
            NgayHoc = DateTime.Now;
        }
    }
}