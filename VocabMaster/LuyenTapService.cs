using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VocabMaster
{
    internal class LuyenTapService
    {
        private readonly List<TuVung> _danhSachTuVung;
        private readonly Random _random = new Random();
        private readonly Dictionary<int, string> _tiengAnh;
        private readonly Dictionary<int, string> _tiengViet;
        private readonly Dictionary<string, HashSet<string>> _nghiaTheoTiengAnh;
        private readonly Dictionary<string, HashSet<string>> _tuTheoTiengViet;

        public LuyenTapService(List<TuVung> danhSachTu)
        {
            _danhSachTuVung = (danhSachTu ?? new List<TuVung>())
                .Where(t => t != null && !string.IsNullOrWhiteSpace(t.TiengAnh)
                    && !string.IsNullOrWhiteSpace(t.TiengViet))
                .GroupBy(t => t.IdTuVung).Select(g => g.First()).ToList();
            _tiengAnh = _danhSachTuVung.ToDictionary(t => t.IdTuVung, t => ChuanHoa(t.TiengAnh));
            _tiengViet = _danhSachTuVung.ToDictionary(t => t.IdTuVung, t => ChuanHoa(t.TiengViet));
            _nghiaTheoTiengAnh = NhomDapAnTheoCauHoi(_tiengAnh, _tiengViet);
            _tuTheoTiengViet = NhomDapAnTheoCauHoi(_tiengViet, _tiengAnh);
        }

        private static Dictionary<string, HashSet<string>> NhomDapAnTheoCauHoi(
            Dictionary<int, string> cauHoi, Dictionary<int, string> dapAn)
        {
            return cauHoi.GroupBy(cap => cap.Value, cap => dapAn[cap.Key])
                .ToDictionary(nhom => nhom.Key, nhom => new HashSet<string>(nhom, StringComparer.Ordinal));
        }

        private static string ChuanHoa(string noiDung)
        {
            return Regex.Replace((noiDung ?? "").Trim(), @"\s+", " ").ToUpperInvariant();
        }

        private string NoiDungDapAn(TuVung tu, bool isHoiTiengViet)
        {
            return isHoiTiengViet ? _tiengAnh[tu.IdTuVung] : _tiengViet[tu.IdTuVung];
        }

        private IEnumerable<TuVung> LayDapAnNhieu(TuVung tuChinh, bool isHoiTiengViet)
        {
            var dapAnDung = isHoiTiengViet
                ? _tuTheoTiengViet[_tiengViet[tuChinh.IdTuVung]]
                : _nghiaTheoTiengAnh[_tiengAnh[tuChinh.IdTuVung]];
            var noiDungDaChon = new HashSet<string>(StringComparer.Ordinal);
            foreach (var tu in _danhSachTuVung)
            {
                string noiDung = NoiDungDapAn(tu, isHoiTiengViet);
                if (!dapAnDung.Contains(noiDung) && noiDungDaChon.Add(noiDung))
                    yield return tu;
            }
        }
        private List<TuVung> LayTuLamCauHoi(bool isHoiTiengViet)
        {
            return _danhSachTuVung.Where(t => LayDapAnNhieu(t, isHoiTiengViet).Take(3).Count() == 3).ToList();
        }

        public int DemSoCauHoiHopLe(bool isHoiTiengViet = false)
        {
            return LayTuLamCauHoi(isHoiTiengViet).Count;
        }

        public List<CauHoi> TaoDeThi(int soLuongCauHoi, bool isHoiTiengViet = false)
        {
            var tuHopLe = LayTuLamCauHoi(isHoiTiengViet);
            if (soLuongCauHoi < 1 || soLuongCauHoi > tuHopLe.Count)
                return new List<CauHoi>();

            var deThi = new List<CauHoi>();
            foreach (var tuChinh in tuHopLe.OrderBy(t => _random.Next()).Take(soLuongCauHoi))
            {
                var cauHoi = new CauHoi { TuChinh = tuChinh };
                cauHoi.CacTuVungSai = LayDapAnNhieu(tuChinh, isHoiTiengViet)
                    .OrderBy(t => _random.Next()).Take(3).ToList();
                cauHoi.CacDapAnTuVung = cauHoi.CacTuVungSai.Concat(new[] { tuChinh })
                    .OrderBy(t => _random.Next()).ToList();
                deThi.Add(cauHoi);
            }
            return deThi;
        }
    }
}
