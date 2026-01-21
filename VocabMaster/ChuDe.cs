using System;

namespace VocabMaster
{
    public class ChuDe
    {
        public String IdChuDe { get; set; }
        public String TenChuDe { get; set; }
        public String MoTa { get; set; }   // Mô tả thêm về chủ đề. Ví dụ: Toeic, Ielts, Giao tiếp,...

        public ChuDe()
        {
            IdChuDe = "";
            TenChuDe = "";
            MoTa = ""; 
        }
    }
}