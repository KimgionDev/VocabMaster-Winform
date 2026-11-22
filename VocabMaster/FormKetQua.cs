using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VocabMaster
{
    public enum KieuHocTap
    {
        TracNghiem,
        FlashCard
    }

    public enum CheDoFlashCard
    {
        TatCa,
        ChuaThuoc,
        TuKho
    }

    public partial class FormKetQua : Form
    {
        private List<TuVung> _danhSachTu;
        private KieuHocTap _kieuHocTap;
        private ComboBox _cboCheDoFlashCard;
        private string _thongDiepFlashCard;
        private string _thongDiepTracNghiem;

        #region Khởi tạo
        public FormKetQua(int soCauDung, int tongSoCau, List<TuVung> danhSachTu, bool chuaLamBai = false, KieuHocTap kieuHocTap = KieuHocTap.TracNghiem, CheDoFlashCard cheDoFlashCard = CheDoFlashCard.TatCa, bool isHoiTiengViet = false)
        {
            InitializeComponent();

            _danhSachTu = danhSachTu;
            _kieuHocTap = kieuHocTap;
            switchNgonNgu.Checked = isHoiTiengViet;

            if (_kieuHocTap == KieuHocTap.FlashCard)
            {
                lblHoiTiengAnh.Text = "Tất cả từ vựng";
                lblHoiTiengViet.Text = "Từ chưa thuộc";
                lblSoCauHoi.Text = "Nhập số flashcard:";

                if (chuaLamBai)
                {
                    lblDiem.Text = "Sẵn sàng học Flashcard chưa?";
                    btnLamLai.Text = "Bắt đầu học";
                }
                else
                {
                    lblDiem.Text = $"Bạn đã ôn tập xong {tongSoCau} thẻ Flashcard!";
                    btnLamLai.Text = "Học lại";
                }

                _thongDiepFlashCard = lblDiem.Text;
            }
            else
            {
                lblHoiTiengAnh.Text = "Hỏi Tiếng Anh";
                lblHoiTiengViet.Text = "Hỏi Tiếng Việt";
                lblSoCauHoi.Text = "Nhập số câu hỏi:";

                if (chuaLamBai)
                {
                    // Chế độ chờ làm bài lần đầu
                    lblDiem.Text = "Sẵn sàng ôn tập từ vựng chưa?";
                    btnLamLai.Text = "Bắt đầu làm bài";
                }
                else
                {
                    // Chế độ hiển thị kết quả
                    LuuKetQuaVaoLichSu(soCauDung, tongSoCau);
                    HienThiNhanXet(soCauDung, tongSoCau);
                    btnLamLai.Text = "Làm lại";
                }
            }

            nudSoCauHoi.Minimum = 1;
            nudSoCauHoi.Maximum = Math.Max(1, _danhSachTu.Count);
            nudSoCauHoi.Value = Math.Max(1, Math.Min(tongSoCau, nudSoCauHoi.Maximum));

            if (_kieuHocTap == KieuHocTap.FlashCard)
                TaoLuaChonCheDoFlashCard(cheDoFlashCard);
            else
            {
                _thongDiepTracNghiem = lblDiem.Text;
                switchNgonNgu.CheckedChanged += (sender, e) => CapNhatGioiHanTracNghiem();
                CapNhatGioiHanTracNghiem();
            }
        }
        #endregion

        private void CapNhatGioiHanTracNghiem()
        {
            int soCauHopLe = new LuyenTapService(_danhSachTu)
                .DemSoCauHoiHopLe(switchNgonNgu.Checked);
            bool duDieuKien = soCauHopLe >= 4;
            nudSoCauHoi.Minimum = duDieuKien ? 4 : 1;
            nudSoCauHoi.Maximum = duDieuKien ? soCauHopLe : 1;
            nudSoCauHoi.Value = Math.Max(nudSoCauHoi.Minimum,
                Math.Min(nudSoCauHoi.Value, nudSoCauHoi.Maximum));
            nudSoCauHoi.Enabled = duDieuKien;
            btnLamLai.Enabled = duDieuKien;
            lblDiem.Text = _thongDiepTracNghiem;
            if (!duDieuKien)
                lblDiem.Text += "\nChưa đủ bốn câu với lựa chọn phân biệt. Vui lòng bổ sung từ vựng có nghĩa khác nhau.";
        }
        #region Chọn nguồn thẻ Flashcard
        private void TaoLuaChonCheDoFlashCard(CheDoFlashCard cheDoBanDau)
        {
            flpNgonNgu.Visible = false;
            _cboCheDoFlashCard = new ComboBox
            {
                Name = "cboCheDoFlashCard",
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("K2D", 14F),
                Location = flpNgonNgu.Location,
                Size = new Size(407, 45),
                Anchor = AnchorStyles.None
            };
            _cboCheDoFlashCard.Items.AddRange(new object[]
            {
                "Tất cả từ vựng", "Từ chưa thuộc", "Luyện từ khó"
            });
            panel2.Controls.Add(_cboCheDoFlashCard);
            _cboCheDoFlashCard.BringToFront();
            _cboCheDoFlashCard.SelectedIndexChanged += (sender, e) => CapNhatGioiHanThe();
            _cboCheDoFlashCard.SelectedIndex = (int)cheDoBanDau;
        }

        private CheDoFlashCard CheDoDaChon => (CheDoFlashCard)_cboCheDoFlashCard.SelectedIndex;

        private List<TuVung> LayDanhSachTheTheoCheDo()
        {
            if (CheDoDaChon == CheDoFlashCard.ChuaThuoc)
                return _danhSachTu.Where(tu => !tu.DaThuoc).ToList();
            if (CheDoDaChon != CheDoFlashCard.TuKho)
                return new List<TuVung>(_danhSachTu);

            const string sql = @"
                SELECT t.IdTuVung, t.TiengAnh, t.TiengViet, t.PhienAm, t.LoaiTu, t.DaThuoc
                FROM TuVungKho tk
                INNER JOIN TuVung t ON t.IdTuVung = tk.IdTuVung
                WHERE tk.SoLanSai >= 1
                ORDER BY tk.SoLanSai DESC, tk.NgaySaiCuoiCung DESC, tk.IdTuVung ASC";

            DataTable bangTuKho = new DatabaseHelper().LayDuLieu(sql);
            return bangTuKho.Rows.Cast<DataRow>().Select(row => new TuVung
            {
                IdTuVung = Convert.ToInt32(row["IdTuVung"]),
                TiengAnh = row["TiengAnh"].ToString(),
                TiengViet = row["TiengViet"].ToString(),
                PhienAm = row["PhienAm"].ToString(),
                LoaiTu = row["LoaiTu"].ToString(),
                DaThuoc = Convert.ToBoolean(row["DaThuoc"])
            }).ToList();
        }

        private void CapNhatGioiHanThe()
        {
            try
            {
                int soThe = LayDanhSachTheTheoCheDo().Count;
                nudSoCauHoi.Maximum = Math.Max(1, soThe);
                nudSoCauHoi.Value = Math.Min(nudSoCauHoi.Value, nudSoCauHoi.Maximum);
                btnLamLai.Enabled = soThe > 0;
                lblDiem.Text = soThe == 0
                    ? (CheDoDaChon == CheDoFlashCard.TuKho
                        ? "Chưa có từ khó để luyện Flashcard."
                        : "Chưa có từ vựng phù hợp để học Flashcard.")
                    : _thongDiepFlashCard;
            }
            catch (Exception)
            {
                btnLamLai.Enabled = false;
                lblDiem.Text = "Không thể tải danh sách từ khó. Vui lòng kiểm tra kết nối dữ liệu.";
            }
        }
        #endregion

        #region Xử lý Kết quả & Lịch sử
        private void HienThiNhanXet(int soCauDung, int tongSoCau)
        {
            // Tính tỷ lệ phần trăm
            double tiLe = (double)soCauDung / tongSoCau * 100;
            string cauNhanXet = "";

            // Phân loại mốc điểm
            if (tiLe == 100)
            {
                cauNhanXet = "Thuộc hết rồi, làm tốt.";
            }
            else if (tiLe >= 80)
            {
                cauNhanXet = "Khá ổn, chỉ sai vài từ.";
            }
            else if (tiLe >= 50)
            {
                cauNhanXet = "Mức trung bình, bạn nên ôn lại.";
            }
            else
            {
                cauNhanXet = "Sai nhiều, hãy học lại từ vựng kỹ hơn.";
            }

            // Gán kết quả vào Label
            lblDiem.Text = $"Bạn đúng {soCauDung} / {tongSoCau} câu.\n{cauNhanXet}";
        }

        private void LuuKetQuaVaoLichSu(int soCauDung, int tongSoCau)
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                // Chỉ cần chèn SoCauDung và TongSoCau, NgayHoc và TiLe sẽ tự sinh trong DB
                string sql = $"INSERT INTO LichSuHocTap (SoCauDung, TongSoCau) VALUES ({soCauDung}, {tongSoCau})";
                db.ThucThiLenh(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lưu lịch sử: " + ex.Message);
            }
        }
        #endregion

        #region Các sự kiện Click
        private void btnLamLai_Click(object sender, EventArgs e)
        {
            if (_kieuHocTap == KieuHocTap.TracNghiem)
            {
                CapNhatGioiHanTracNghiem();
                if (!btnLamLai.Enabled) return;
            }
            int soCauMoi = (int)nudSoCauHoi.Value;
            bool trangThaiSwitch = switchNgonNgu.Checked;
            CheDoFlashCard cheDoFlashCard = CheDoFlashCard.TatCa;
            List<TuVung> danhSachThe = null;

            if (_kieuHocTap == KieuHocTap.FlashCard)
            {
                cheDoFlashCard = CheDoDaChon;
                try
                {
                    danhSachThe = LayDanhSachTheTheoCheDo();
                }
                catch (Exception)
                {
                    btnLamLai.Enabled = false;
                    lblDiem.Text = "Không thể tải danh sách từ khó. Vui lòng kiểm tra kết nối dữ liệu.";
                    return;
                }

                if (danhSachThe.Count == 0)
                {
                    CapNhatGioiHanThe();
                    return;
                }
                soCauMoi = Math.Min(soCauMoi, danhSachThe.Count);
            }

            // Ép kiểu an toàn giống FormTracNghiem để tránh lỗi văng app
            Panel panelChua = this.Parent as Panel;
            if (panelChua == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy Panel chứa giao diện.");
                this.Close();
                return;
            }

            Form formCon;
            if (_kieuHocTap == KieuHocTap.TracNghiem)
            {
                formCon = new FormTracNghiem(_danhSachTu, soCauMoi, trangThaiSwitch);
            }
            else
            {
                formCon = new FormFlashCard(_danhSachTu, danhSachThe, soCauMoi, cheDoFlashCard);
            }

            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            panelChua.Controls.Add(formCon);
            formCon.Show();
            formCon.BringToFront();

            this.Close();
        }
        #endregion
    }
}
