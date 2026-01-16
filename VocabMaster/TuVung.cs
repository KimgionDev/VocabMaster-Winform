using System; // Thư viện cơ bản

namespace VocabMaster
{
    public class TuVung
    {
        public string TiengAnh { get; set; }
        public string PhienAm { get; set; }
        public string TiengViet { get; set; }
        public string LoaiTu { get; set; }
        public string ChuDe { get; set; }
        public bool DaThuoc { get; set; }

        public TuVung()
        {
            TiengAnh = "";
            TiengViet = "";
            PhienAm = "";
            LoaiTu = "";
            ChuDe = "";
            DaThuoc = false;
        }
    }
}