using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VocabMaster
{
    public partial class FormKetQua : Form
    {
        private List<TuVung> _danhSachTu;

        #region Khởi tạo
        public FormKetQua(int soCauDung, int tongSoCau, List<TuVung> danhSachTu)
        {
            InitializeComponent();
            lblDiem.Left = (this.ClientSize.Width - lblDiem.Width) / 2;
            btnLamLai.Left = (this.ClientSize.Width - btnLamLai.Width) / 2;
            flpChonSoCau.Left = (this.ClientSize.Width - flpChonSoCau.Width) / 2;

            _danhSachTu = danhSachTu;

            // Hiển thị kết quả
            HienThiNhanXet(soCauDung, tongSoCau);

            // Cài đặt thông số mặc định cho ô nhập số lượng câu
            nudSoCauHoi.Minimum = 4; // LuyenTapService yêu cầu ít nhất 4 từ
            nudSoCauHoi.Maximum = _danhSachTu.Count;
            nudSoCauHoi.Value = tongSoCau; // Gợi ý lại số câu vừa làm
        }
        #endregion

        #region Xử lý Kết quả
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

        #region Sự kiện
        private void btnLamLai_Click(object sender, EventArgs e)
        {
            int soCauMoi = (int)nudSoCauHoi.Value;
            Panel panelChua = (Panel)this.Parent;

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