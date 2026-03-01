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

        public async void XuLyDapAn(AntdUI.Button dapAnDaChon)
        {
            bool ketQua = KiemTraDapAn(dapAnDaChon.Text);
            if(ketQua)
            {
                dapAnDaChon.Text += " ✅";
                dapAnDaChon.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblCauHoi.Text += $" (Đáp án đúng: {_deThi[_chiSoCauHoiHienTai].TuChinh.TiengViet})";
                dapAnDaChon.Text += " ❎";
                dapAnDaChon.ForeColor = Color.Red;

                if (KiemTraDapAn(btnA.Text)) { btnA.Text += " ✅"; btnA.ForeColor = Color.LimeGreen; }
                if (KiemTraDapAn(btnB.Text)) { btnB.Text += " ✅"; btnB.ForeColor = Color.LimeGreen; }
                if (KiemTraDapAn(btnC.Text)) { btnC.Text += " ✅"; btnC.ForeColor = Color.LimeGreen; }
                if (KiemTraDapAn(btnD.Text)) { btnD.Text += " ✅"; btnD.ForeColor = Color.LimeGreen; }
            }

            await Task.Delay(10000); // Đợi 1.5 giây để người dùng nhìn thấy kết quả trước khi chuyển câu hỏi tiếp theo

            dapAnDaChon.ForeColor = Color.White;
            if (_chiSoCauHoiHienTai + 1 < _deThi.Count)     _chiSoCauHoiHienTai++;
            lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
            HienThiCauHoi();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnA);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnB);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnC);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            XuLyDapAn(btnD);
        }
    }
}
