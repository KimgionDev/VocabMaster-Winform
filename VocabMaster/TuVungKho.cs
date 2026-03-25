using System;

namespace VocabMaster
{
    public class TuVungKho
    {
        public int IdTuVung { get; set; }
        public int SoLanSai { get; set; }
        public DateTime NgaySaiCuoiCung { get; set; }

        public TuVungKho()
        {
            NgaySaiCuoiCung = DateTime.Now;
            SoLanSai = 0;
        }
    }
}