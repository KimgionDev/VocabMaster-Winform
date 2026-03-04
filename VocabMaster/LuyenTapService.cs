using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (_danhSachTuVung.Count < 4 || soLuongCauHoi > _danhSachTuVung.Count)
            {
                MessageBox.Show("Không đủ từ vựng để tạo đề thi. Vui lòng thêm nhiều từ hơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return deThi;
            }
            var danhSachTuDaTron = _danhSachTuVung
                                  .OrderBy(t => _random.Next())
                                  .Take(soLuongCauHoi)  // Lấy số luọng câu hỏi yêu cầu, ví dụ 3 câu thì lấy 3 từ đã được trộn ngẫu nhiên.
                                  .ToList();            // 3 từ này sẽ là từ chính trong 3 câu hỏi của đề thi.
            foreach (var tuChinh in danhSachTuDaTron)
            {
                CauHoi cauHoi = new CauHoi();
                cauHoi.TuChinh = tuChinh;
                cauHoi.CacTuVungSai = _danhSachTuVung
                                    .Where(t => t.IdTuVung != tuChinh.IdTuVung 
                                    && t.TiengAnh.ToLower() != tuChinh.TiengAnh.ToLower())
                                    .OrderBy(t => _random.Next())
                                    .Take(3)
                                    .ToList();
                var tatCaTuVung = new List<TuVung>();
                tatCaTuVung.AddRange(cauHoi.CacTuVungSai);  // AddRange là thêm tất cả phần tử của danh sách vào danh sách hiện tại 
                tatCaTuVung.Add(cauHoi.TuChinh);            // trong khi Add chỉ thêm một phần tử duy nhất.
                tatCaTuVung= tatCaTuVung.OrderBy(t => _random.Next()).ToList(); // Trộn lại tất cả các từ (bao gồm cả từ chính) để tạo thành 4 lựa chọn cho câu hỏi.
                cauHoi.CacDapAnTuVung = tatCaTuVung;
                deThi.Add(cauHoi);
                
            }
            return deThi;
        }
    }
}
