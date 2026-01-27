using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabMaster
{
    internal class CauHoi
    {
        public TuVung TuChinh { get; set; }
        public List<TuVung> CacDapAnSai { get; set; }
        public CauHoi()
        {
            CacDapAnSai = new List<TuVung>();
        }
    }
}
