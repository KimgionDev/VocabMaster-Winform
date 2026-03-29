using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VocabMaster
{
    public partial class FormKetQua : Form
    {
        private List<TuVung> _danhSachTu;

        #region Khởi tạo
        public FormKetQua(int soCauDung, int tongSoCau, List<TuVung> danhSachTu, bool chuaLamBai = false)
        {
            InitializeComponent();

            _danhSachTu = danhSachTu;

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

            nudSoCauHoi.Minimum = 4;
            nudSoCauHoi.Maximum = _danhSachTu.Count;
            nudSoCauHoi.Value = Math.Min(tongSoCau, _danhSachTu.Count);
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
            int soCauMoi = (int)nudSoCauHoi.Value;

            // Ép kiểu an toàn giống FormTracNghiem để tránh lỗi văng app
            Panel panelChua = this.Parent as Panel;
            if (panelChua == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy Panel chứa giao diện.");
                this.Close();
                return;
            }

            FormTracNghiem frmTracNghiem = new FormTracNghiem(_danhSachTu, soCauMoi);
            frmTracNghiem.TopLevel = false;
            frmTracNghiem.FormBorderStyle = FormBorderStyle.None;
            frmTracNghiem.Dock = DockStyle.Fill;

            panelChua.Controls.Add(frmTracNghiem);
            frmTracNghiem.Show();
            frmTracNghiem.BringToFront();

            this.Close();
        }
        #endregion
    }
}