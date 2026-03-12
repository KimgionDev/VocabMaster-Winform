using System;

namespace VocabMaster
{
    public class ChuDe
    {
        public int IdChuDe { get; set; }
        public String TenChuDe { get; set; }

        public ChuDe()
        {
            TenChuDe = "";
        }

        public override string ToString()
        {
            return TenChuDe;
        }
    }
}