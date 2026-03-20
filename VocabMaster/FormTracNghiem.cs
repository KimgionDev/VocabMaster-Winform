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
        private bool _dangXuLyDapAn = false;
        private int _soCauDung = 0;
        private List<TuVung> _danhSachTu;

        public FormTracNghiem(List<TuVung> danhSachTu, int soLuongCau = 4)
        {
            InitializeComponent();
            _danhSachTu = danhSachTu; // Lưu lại
            _luyenTapService = new LuyenTapService(_danhSachTu);
            try
            {
                _deThi = _luyenTapService.TaoDeThi(soLuongCau);
                HienThiCauHoi();
                lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }

        private void HienThiCauHoi()
        {
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
            if (_dangXuLyDapAn) return; // Ngăn chặn việc chọn nhiều đáp án cùng lúc
            _dangXuLyDapAn = true;
            btnA.BackHover = Color.FromArgb(245, 247, 250); // Tạm thời vô hiệu hóa hover để tránh nhầm lẫn
            btnB.BackHover = Color.FromArgb(245, 247, 250);
            btnC.BackHover = Color.FromArgb(245, 247, 250);
            btnD.BackHover = Color.FromArgb(245, 247, 250);

            bool ketQua = KiemTraDapAn(dapAnDaChon.Text);
            if (ketQua)
            {
                dapAnDaChon.Text += " ✅";
                dapAnDaChon.ForeColor = Color.LimeGreen;
                _soCauDung++;
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

            await Task.Delay(2000); // Đợi 3 giây để người dùng nhìn thấy kết quả trước khi chuyển câu hỏi tiếp theo
            _dangXuLyDapAn = false; // Cho phép chọn đáp án cho câu hỏi tiếp theo
            btnA.ForeColor = Color.Black;       // Reset màu sắc về mặc định
            btnB.ForeColor = Color.Black;
            btnC.ForeColor = Color.Black;
            btnD.ForeColor = Color.Black;

            btnA.BackHover = Color.FromArgb(255, 77, 79); // Kích hoạt lại hover
            btnB.BackHover = Color.FromArgb(82, 196, 26);
            btnC.BackHover = Color.FromArgb(250, 173, 20);
            btnD.BackHover = Color.FromArgb(24, 144, 255);

            _chiSoCauHoiHienTai++;
            if (_chiSoCauHoiHienTai < _deThi.Count)
            {
                // Nếu còn câu hỏi thì hiển thị tiếp
                lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
                HienThiCauHoi();
            }
            else
            {
                // Nếu hết câu hỏi thì chuyển sang FormKetQua
                ChuyenSangFormKetQua();
            }
        }

        private void ChuyenSangFormKetQua()
        {
            Panel panelChua = (Panel)this.Parent;

            FormKetQua frmKetQua = new FormKetQua(_soCauDung, _deThi.Count, _danhSachTu);
            frmKetQua.TopLevel = false;
            frmKetQua.FormBorderStyle = FormBorderStyle.None;
            frmKetQua.Dock = DockStyle.Fill;

            // Thêm vào panel và đưa lên trên cùng
            panelChua.Controls.Add(frmKetQua);
            frmKetQua.Show();
            frmKetQua.BringToFront();

            // Đóng form trắc nghiệm này lại để giải phóng RAM
            this.Close();
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
