using System;
using System.Collections.Generic;
using System.Data;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace VocabMaster
{
    public partial class FormFlashCard : Form
    {
        private static readonly Random _random = new Random();
        private List<TuVung> _danhSachTuVung;
        private List<TuVung> _toanBoDanhSachTu;
        private int _viTriHienTai;
        private bool _daLatThe;
        private readonly SpeechSynthesizer _mayDoc;
        private int _soLuongThe;
        private bool _chiHocTuChuaThuoc;

        #region Khởi tạo & Dọn dẹp
        public FormFlashCard(List<TuVung> danhSachTu, int soLuongThe, bool chiHocTuChuaThuoc)
        {
            InitializeComponent();
            
            _toanBoDanhSachTu = danhSachTu;
            _soLuongThe = soLuongThe;
            _chiHocTuChuaThuoc = chiHocTuChuaThuoc;

            _mayDoc = new SpeechSynthesizer
            {
                Volume = 100,
                Rate = 0
            };
            _mayDoc.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
        }

        private void FormFlashCard_Load(object sender, EventArgs e)
        {
            // Lọc danh sách nếu cần
            if (_chiHocTuChuaThuoc)
            {
                _danhSachTuVung = new List<TuVung>();
                foreach (var tu in _toanBoDanhSachTu)
                {
                    if (!tu.DaThuoc)
                    {
                        _danhSachTuVung.Add(tu);
                    }
                }
            }
            else
            {
                _danhSachTuVung = new List<TuVung>(_toanBoDanhSachTu);
            }

            if (_danhSachTuVung.Count == 0)
            {
                MessageBox.Show("Chưa có từ vựng nào phù hợp để học flashcard.", "Thông báo");
                
                // Trở về form kết quả
                Panel panelChua = this.Parent as Panel;
                if (panelChua != null)
                {
                    FormKetQua frmKetQua = new FormKetQua(0, _toanBoDanhSachTu.Count, _toanBoDanhSachTu, true, KieuHocTap.FlashCard);
                    frmKetQua.TopLevel = false;
                    frmKetQua.FormBorderStyle = FormBorderStyle.None;
                    frmKetQua.Dock = DockStyle.Fill;
                    panelChua.Controls.Add(frmKetQua);
                    frmKetQua.Show();
                    frmKetQua.BringToFront();
                }
                
                BeginInvoke(new Action(Close));
                return;
            }

            TronDanhSachTuVung();
            
            // Giới hạn số lượng thẻ
            if (_soLuongThe < _danhSachTuVung.Count)
            {
                _danhSachTuVung = _danhSachTuVung.GetRange(0, _soLuongThe);
            }

            _viTriHienTai = 0;
            HienThiThe();
        }

        // Dọn dẹp bộ nhớ máy đọc khi đóng Form
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mayDoc?.Dispose();
            base.OnFormClosed(e);
        }
        #endregion

        #region Xử lý dữ liệu
        private void TronDanhSachTuVung()
        {
            for (int i = _danhSachTuVung.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (_danhSachTuVung[i], _danhSachTuVung[j]) = (_danhSachTuVung[j], _danhSachTuVung[i]);
            }
        }
        #endregion

        #region Xử lý giao diện thẻ
        private void HienThiThe()
        {
            if (_danhSachTuVung.Count == 0)
            {
                return;
            }

            _daLatThe = false;
            TuVung tuHienTai = _danhSachTuVung[_viTriHienTai];

            lblNoiDungChinh.Text = tuHienTai.TiengAnh;
            lblNoiDungPhu.Text = string.Empty;

            prgTienDo.Value = (float)(_viTriHienTai + 1) / _danhSachTuVung.Count;

            btnQuayLai.Enabled = _viTriHienTai > 0;
            
            if (_viTriHienTai >= _danhSachTuVung.Count - 1)
            {
                btnTiepTheo.Text = "Kết thúc";
            }
            else
            {
                btnTiepTheo.Text = "Tiếp theo >>";
            }
            btnTiepTheo.Enabled = true; // Luôn bật để người dùng có thể bấm kết thúc
        }

        private void ThucHienLatThe()
        {
            if (_danhSachTuVung.Count == 0)
            {
                return;
            }

            _daLatThe = !_daLatThe;
            TuVung tuHienTai = _danhSachTuVung[_viTriHienTai];

            if (_daLatThe)
            {
                lblNoiDungChinh.Text = tuHienTai.TiengViet;
                lblNoiDungPhu.Text = tuHienTai.PhienAm;
            }
            else
            {
                lblNoiDungChinh.Text = tuHienTai.TiengAnh;
                lblNoiDungPhu.Text = string.Empty;
            }
        }
        #endregion

        #region Các sự kiện Click
        private void pnlFlashcard_Click(object sender, EventArgs e) => ThucHienLatThe();

        private void lblNoiDungChinh_Click(object sender, EventArgs e) => ThucHienLatThe();

        private void lblNoiDungPhu_Click(object sender, EventArgs e) => ThucHienLatThe();

        private void btnPhatAm_Click(object sender, EventArgs e)
        {
            if (_danhSachTuVung.Count == 0) // Kiểm tra nếu không có từ vựng nào
            {
                return;
            }

            _mayDoc.SpeakAsyncCancelAll();
            _mayDoc.SpeakAsync(_danhSachTuVung[_viTriHienTai].TiengAnh);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (_viTriHienTai <= 0)
            {
                return;
            }

            _viTriHienTai--;
            HienThiThe();
        }

        private void btnTiepTheo_Click(object sender, EventArgs e)
        {
            if (_viTriHienTai >= _danhSachTuVung.Count - 1)
            {
                Panel panelChua = this.Parent as Panel;
                if (panelChua != null)
                {
                    FormKetQua frmKetQua = new FormKetQua(0, _danhSachTuVung.Count, _toanBoDanhSachTu, false, KieuHocTap.FlashCard);
                    frmKetQua.TopLevel = false;
                    frmKetQua.FormBorderStyle = FormBorderStyle.None;
                    frmKetQua.Dock = DockStyle.Fill;
                    panelChua.Controls.Add(frmKetQua);
                    frmKetQua.Show();
                    frmKetQua.BringToFront();
                }
                this.Close();
                return;
            }

            _viTriHienTai++;
            HienThiThe();
        }
        #endregion
    }
}