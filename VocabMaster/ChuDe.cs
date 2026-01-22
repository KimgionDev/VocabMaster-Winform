using System;

namespace VocabMaster
{
    public class ChuDe
    {
        public String IdChuDe { get; set; }
        public String TenChuDe { get; set; }

        public ChuDe()
        {
            IdChuDe = "";
            TenChuDe = "";
        }

        public override string ToString()
        {
            return TenChuDe;
        }
    }
}