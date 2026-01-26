using System;
using System.ComponentModel;    // Thêm thư viện này để dùng [Description]

namespace VocabMaster
{
    public class TuVung
    {
        [Browsable(false)] public string IdTuVung { get; set; } // Ẩn trong DataGridView
        public string TiengAnh { get; set; }
        public string PhienAm { get; set; }
        public string TiengViet { get; set; }
        public string LoaiTu { get; set; }
        public ChuDe ChuDe { get; set; }
        public bool DaThuoc { get; set; }

        public TuVung()
        {
            IdTuVung = Guid.NewGuid().ToString();
            TiengAnh = "";
            TiengViet = "";
            PhienAm = "";
            LoaiTu = "";
            ChuDe = null;
            DaThuoc = false;
        }
    }
}