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
        public FormTracNghiem(List<TuVung> danhSachTu)
        {
            InitializeComponent();
            _luyenTapService = new LuyenTapService(danhSachTu);
            try
            {
                _deThi = _luyenTapService.TaoDeThi(5);
                HienThiCauHoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Dùng BeginInvoke để tránh lỗi crash khi đóng Form lúc đang khởi tạo
                this.BeginInvoke(new Action(() => this.Close()));
            }
            lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
            pnlKetQua.Visible = false; // Ẩn bảng điểm ban đầu
        }
        private void HienThiCauHoi()
        {
            if (_chiSoCauHoiHienTai >= _deThi.Count)
            {
                // Giấu giao diện thi
                panelTop.Visible = false;
                tableLayoutPanelBot.Visible = false;

                // Bật bảng điểm lên
                pnlKetQua.Visible = true;
                pnlKetQua.Dock = DockStyle.Fill;
                pnlKetQua.BringToFront(); // Bê nó lên lớp trên cùng
                btnLamLai.Size = new Size(240, 80);
                btnLamLai.Location = new Point((pnlKetQua.Width - btnLamLai.Width) / 2, (pnlKetQua.Height - btnLamLai.Height) / 2 + 50);

                lblDiem.Text = "";
                string loiNhan = _soCauDung >= 8 ? "Tuyệt vời, giữ vững phong độ nhé!" : "Bạn cần ôn tập thêm bộ từ này!";

                // Gộp nội dung thành nhiều dòng
                string thongBao = $"Hoàn thành bài tập!\n" +
                                  $"Kết quả: {_soCauDung} / {_deThi.Count} câu.\n" +
                                  $"{loiNhan}";
                lblDiem.Text += thongBao;
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
            if (_dangXuLyDapAn) return; // Ngăn chặn việc chọn nhiều đáp án cùng lúc
                _dangXuLyDapAn = true;
            bool ketQua = KiemTraDapAn(dapAnDaChon.Text);
            if(ketQua)
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

            await Task.Delay(1000); // Đợi 1.5 giây để người dùng nhìn thấy kết quả trước khi chuyển câu hỏi tiếp theo
            _dangXuLyDapAn = false; // Cho phép chọn đáp án cho câu hỏi tiếp theo
            btnA.ForeColor = Color.Black;       // Reset màu sắc về mặc định
            btnB.ForeColor = Color.Black;
            btnC.ForeColor = Color.Black;
            btnD.ForeColor = Color.Black;

            if (_chiSoCauHoiHienTai < _deThi.Count)     _chiSoCauHoiHienTai++;
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

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            // Reset điểm và chỉ số câu hỏi
            _chiSoCauHoiHienTai = 0;
            _soCauDung = 0;

            // Ẩn bảng điểm, hiện lại khung thi
            pnlKetQua.Visible = false;
            panelTop.Visible = true;
            tableLayoutPanelBot.Visible = true;

            // Tạo đề mới và hiển thị
            _deThi = _luyenTapService.TaoDeThi(5);
            lblSoThuTu.Text = $"Câu hỏi {_chiSoCauHoiHienTai + 1} / {_deThi.Count}";
            HienThiCauHoi();
        }
    }
}
