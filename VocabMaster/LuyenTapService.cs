using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabMaster
{
    internal class LuyenTapService
    {
        private List<TuVung> _danhSachTuVung;
        private Random _random = new Random();
        public LuyenTapService(List<TuVung> danhSachTu)
        {
            _danhSachTuVung = danhSachTu;
        }

        public List<CauHoi> TaoDeThi(int soLuongCauHoi)
        {
            List<CauHoi> deThi = new List<CauHoi>();
            var danhSachTuDaThuoc = _danhSachTuVung.Where(t => t.DaThuoc).ToList();
            if (danhSachTuDaThuoc.Count < 4 || soLuongCauHoi > danhSachTuDaThuoc.Count)
            {
                return deThi;
            }
            var danhSachTuDaTron = danhSachTuDaThuoc
                                  .OrderBy(t => _random.Next())
                                  .Take(soLuongCauHoi)
                                  .ToList();
            foreach (var tuChinh in danhSachTuDaTron)
            {
                CauHoi cauHoi = new CauHoi();
                cauHoi.TuChinh = tuChinh;
                cauHoi.CacDapAnSai = _danhSachTuVung
                                    .Where(t => t.IdTuVung != tuChinh.IdTuVung)
                                    .OrderBy(t => _random.Next())
                                    .Take(3)
                                    .ToList();
                deThi.Add(cauHoi);
            }
            return deThi;
        }
    }
}
