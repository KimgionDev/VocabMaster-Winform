using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocabMaster
{
    public partial class FormTracNghiem : Form
    {
        private LuyenTapService _luyenTapService;
        private List<CauHoi> _deThi;
        private int _chiSoCauHoiHienTai = 0;
        public FormTracNghiem(List<TuVung> danhSachTu)
        {
            InitializeComponent();
            _luyenTapService = new LuyenTapService(danhSachTu);
            try
            {
                _deThi = _luyenTapService.TaoDeThi(10);
                HienThiCauHoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Dùng BeginInvoke để tránh lỗi crash khi đóng Form lúc đang khởi tạo
                this.BeginInvoke(new Action(() => this.Close()));
            }
            lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
        }
        private void HienThiCauHoi()
        {
            if (_chiSoCauHoiHienTai >= _deThi.Count)
            {
                MessageBox.Show("Hoàn thành bài tập!");
                return;
            }

            CauHoi cauHienTai = _deThi[_chiSoCauHoiHienTai];
            lblCauHoi.Text = cauHienTai.TuChinh.TiengAnh;

            btnA.Text = cauHienTai.CacDapAnTuVung[0].TiengViet;
            btnB.Text = cauHienTai.CacDapAnTuVung[1].TiengViet;
            btnC.Text = cauHienTai.CacDapAnTuVung[2].TiengViet;
            btnD.Text = cauHienTai.CacDapAnTuVung[3].TiengViet;
        }

        public bool KiemTraDapAn(string dapAnNguoiDung)
        {
            CauHoi cauHienTai = _deThi[_chiSoCauHoiHienTai];
            return cauHienTai.TuChinh.TiengViet.Equals(dapAnNguoiDung, StringComparison.OrdinalIgnoreCase);
        }

        public void XuLyDapAn(string dapAnDaChon)
        {
            bool ketQua = KiemTraDapAn(dapAnDaChon);
            if(ketQua)
            {
                MessageBox.Show("Đáp án đúng!");
            }
            else
            {
                MessageBox.Show($"Đáp án sai! Đáp án đúng là: { _deThi[_chiSoCauHoiHienTai].TuChinh.TiengViet}");
            }
            if (_chiSoCauHoiHienTai + 1 < _deThi.Count)     _chiSoCauHoiHienTai++;
            lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
            HienThiCauHoi();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnA.Text);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnB.Text);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnC.Text);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnD.Text);
        }
    }
}
