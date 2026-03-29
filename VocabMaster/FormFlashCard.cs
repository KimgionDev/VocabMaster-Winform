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
        private readonly List<TuVung> _danhSachTuVung;
        private int _viTriHienTai;
        private bool _daLatThe;
        private readonly SpeechSynthesizer _mayDoc;

        #region Khởi tạo & Dọn dẹp
        public FormFlashCard()
        {
            InitializeComponent();
            _danhSachTuVung = new List<TuVung>();

            _mayDoc = new SpeechSynthesizer
            {
                Volume = 100,
                Rate = 0
            };
            _mayDoc.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
        }

        private void FormFlashCard_Load(object sender, EventArgs e)
        {
            LoadDuLieuTuDatabase();

            if (_danhSachTuVung.Count == 0)
            {
                MessageBox.Show("Chưa có từ vựng để học flashcard.", "Thông báo");
                BeginInvoke(new Action(Close));
                return;
            }

            TronDanhSachTuVung();
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
        private void LoadDuLieuTuDatabase()
        {
            _danhSachTuVung.Clear();

            DatabaseHelper db = new DatabaseHelper();
            const string query = "SELECT IdTuVung, TiengAnh, PhienAm, TiengViet FROM TuVung";
            DataTable dt = db.LayDuLieu(query);

            foreach (DataRow row in dt.Rows)
            {
                _danhSachTuVung.Add(new TuVung
                {
                    IdTuVung = Convert.ToInt32(row["IdTuVung"]),
                    TiengAnh = row["TiengAnh"].ToString(),
                    PhienAm = row["PhienAm"].ToString(),
                    TiengViet = row["TiengViet"].ToString()
                });
            }
        }

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
            btnTiepTheo.Enabled = _viTriHienTai < _danhSachTuVung.Count - 1;
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
                return;
            }

            _viTriHienTai++;
            HienThiThe();
        }
        #endregion
    }
}