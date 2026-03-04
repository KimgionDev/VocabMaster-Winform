using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabMaster
{
    internal class CauHoi
    {
        public TuVung TuChinh { get; set; }                 // Từ chính là từ đúng trong câu hỏi
        public List<TuVung> CacTuVungSai { get; set; }      // Danh sách các từ sai (3 từ sai)
        public List<TuVung> CacDapAnTuVung { get; set; }    // Danh sách tất cả các đáp án (1 từ đúng + 3 từ sai), đã được trộn ngẫu nhiên
        public CauHoi()
        {
            CacTuVungSai = new List<TuVung>();
            CacDapAnTuVung = new List<TuVung>();
        }
    }
}
