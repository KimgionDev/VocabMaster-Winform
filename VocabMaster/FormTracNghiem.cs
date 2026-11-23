using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabMaster
{
    public partial class FormTracNghiem : Form
    {
        private readonly List<CauHoi> _deThi;
        private int _chiSoCauHoiHienTai;
        private bool _dangXuLyDapAn;
        private bool _daRoiManHinh;
        private bool _daChuyenKetQua;
        private int _soCauDung;
        private readonly List<TuVung> _danhSachTu;
        private readonly SpeechSynthesizer _mayDoc;
        private readonly bool _isHoiTiengViet;
        private readonly CancellationTokenSource _huyXuLy = new CancellationTokenSource();

        public FormTracNghiem(List<TuVung> danhSachTu, int soLuongCau = 4, bool isHoiTiengViet = false)
        {
            // Từ chối đề không hợp lệ trước khi tạo control hoặc tài nguyên phát âm.
            _danhSachTu = danhSachTu ?? new List<TuVung>();
            _isHoiTiengViet = isHoiTiengViet;
            _deThi = new LuyenTapService(_danhSachTu).TaoDeThi(soLuongCau, isHoiTiengViet);
            if (_deThi.Count == 0)
                throw new ArgumentException("Chưa đủ lựa chọn phân biệt để tạo đề thi. Vui lòng bổ sung từ vựng.");

            InitializeComponent();
            Disposed += (sender, e) =>
            {
                HuyXuLyDapAn();
                _huyXuLy.Dispose();
                _mayDoc?.Dispose();
            };
            _mayDoc = new SpeechSynthesizer { Volume = 100, Rate = 0 };
            _mayDoc.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0,
                new System.Globalization.CultureInfo("en-US"));
            HienThiCauHoi();
        }

        private void HuyXuLyDapAn()
        {
            if (_daRoiManHinh) return;
            _daRoiManHinh = true;
            _huyXuLy.Cancel();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            HuyXuLyDapAn();
            base.OnFormClosing(e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent == null && _dangXuLyDapAn) HuyXuLyDapAn();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!Visible && _dangXuLyDapAn) HuyXuLyDapAn();
        }

        private bool ConHoatDong(Panel panelChua)
        {
            return !_daRoiManHinh && !IsDisposed && !Disposing && Visible
                && panelChua != null && !panelChua.IsDisposed && !panelChua.Disposing
                && ReferenceEquals(Parent, panelChua) && panelChua.Controls.Contains(this)
                && panelChua.Controls.GetChildIndex(this) == 0;
        }

        private AntdUI.Button[] CacNutDapAn => new[] { btnA, btnB, btnC, btnD };

        private void HienThiCauHoi()
        {
            CauHoi cauHoi = _deThi[_chiSoCauHoiHienTai];
            lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
            lblCauHoi.Text = _isHoiTiengViet ? cauHoi.TuChinh.TiengViet : cauHoi.TuChinh.TiengAnh;
            btnPhatAm.Visible = !_isHoiTiengViet;
            for (int i = 0; i < CacNutDapAn.Length; i++)
            {
                TuVung dapAn = cauHoi.CacDapAnTuVung[i];
                CacNutDapAn[i].Tag = dapAn.IdTuVung;
                CacNutDapAn[i].Text = (_isHoiTiengViet ? dapAn.TiengAnh : dapAn.TiengViet).Trim();
                CacNutDapAn[i].ForeColor = Color.Black;
            }
        }

        public bool KiemTraDapAn(int idTuVung)
        {
            return _chiSoCauHoiHienTai < _deThi.Count
                && _deThi[_chiSoCauHoiHienTai].TuChinh.IdTuVung == idTuVung;
        }

        public async void XuLyDapAn(AntdUI.Button dapAnDaChon)
        {
            Panel panelChua = Parent as Panel;
            if (_dangXuLyDapAn || _daChuyenKetQua || !ConHoatDong(panelChua)
                || !CacNutDapAn.Contains(dapAnDaChon) || !(dapAnDaChon.Tag is int)) return;
            _dangXuLyDapAn = true;
            foreach (var nut in CacNutDapAn) nut.BackHover = Color.FromArgb(245, 247, 250);

            bool ketQua = KiemTraDapAn((int)dapAnDaChon.Tag);
            if (ketQua)
            {
                dapAnDaChon.Text += " ✅";
                dapAnDaChon.ForeColor = Color.LimeGreen;
                _soCauDung++;
            }
            else
            {
                TuVung tuChinh = _deThi[_chiSoCauHoiHienTai].TuChinh;
                lblCauHoi.Text += $" (Đáp án đúng: {(_isHoiTiengViet ? tuChinh.TiengAnh : tuChinh.TiengViet)})";
                dapAnDaChon.Text += " ❎";
                dapAnDaChon.ForeColor = Color.Red;
                foreach (var nut in CacNutDapAn.Where(nut => KiemTraDapAn((int)nut.Tag)))
                {
                    nut.Text += " ✅";
                    nut.ForeColor = Color.LimeGreen;
                }
                CapNhatTuVungKho(tuChinh.IdTuVung);
            }

            try
            {
                await Task.Delay(2000, _huyXuLy.Token);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            // Sau await, không đụng control cho tới khi xác nhận màn hình vẫn hiện hành.
            if (!ConHoatDong(panelChua)) return;
            btnA.BackHover = Color.FromArgb(255, 77, 79);
            btnB.BackHover = Color.FromArgb(82, 196, 26);
            btnC.BackHover = Color.FromArgb(250, 173, 20);
            btnD.BackHover = Color.FromArgb(24, 144, 255);
            _chiSoCauHoiHienTai++;
            if (_chiSoCauHoiHienTai < _deThi.Count)
            {
                HienThiCauHoi();
                _dangXuLyDapAn = false;
            }
            else
                ChuyenSangFormKetQua(panelChua);
        }

        private void ChuyenSangFormKetQua(Panel panelChua)
        {
            if (_daChuyenKetQua || !ConHoatDong(panelChua)) return;
            _daChuyenKetQua = true;
            var frmKetQua = new FormKetQua(_soCauDung, _deThi.Count, _danhSachTu, isHoiTiengViet: _isHoiTiengViet)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            panelChua.Controls.Add(frmKetQua);
            frmKetQua.Show();
            frmKetQua.BringToFront();
            Close();
        }

        private void CapNhatTuVungKho(int idTuVung)
        {
            // Cập nhật số lần sai nếu từ đã có trong bảng, ngược lại thì chèn mới
            DatabaseHelper db = new DatabaseHelper();
            string sql = $@"
                IF EXISTS (SELECT 1 FROM TuVungKho WHERE IdTuVung = {idTuVung})
                    UPDATE TuVungKho SET SoLanSai = SoLanSai + 1, NgaySaiCuoiCung = GETDATE() WHERE IdTuVung = {idTuVung}
                ELSE
                    INSERT INTO TuVungKho (IdTuVung, SoLanSai, NgaySaiCuoiCung) VALUES ({idTuVung}, 1, GETDATE())";

            db.ThucThiLenh(sql);
        }

        private void btnA_Click(object sender, EventArgs e) { XuLyDapAn(btnA); }
        private void btnB_Click(object sender, EventArgs e) { XuLyDapAn(btnB); }
        private void btnC_Click(object sender, EventArgs e) { XuLyDapAn(btnC); }
        private void btnD_Click(object sender, EventArgs e) { XuLyDapAn(btnD); }

        private void btnPhatAm_Click(object sender, EventArgs e)
        {
            if (_daRoiManHinh || _chiSoCauHoiHienTai >= _deThi.Count) return;
            _mayDoc.SpeakAsyncCancelAll();
            _mayDoc.SpeakAsync(_deThi[_chiSoCauHoiHienTai].TuChinh.TiengAnh);
        }
    }
}