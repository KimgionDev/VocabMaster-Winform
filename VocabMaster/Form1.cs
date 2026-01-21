using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace VocabMaster
{
    public partial class Form1 : Form
    {
        KhoDuLieuJSON _kho = new KhoDuLieuJSON();
        List<TuVung> _danhSachTuVung = new List<TuVung>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TaiDuLieuLenBang();
            TaiDanhSachChuDe();
            TaiDanhSachTrangThai();
        }

        private void TaiDuLieuLenBang()
        {
            // Đọc dữ liệu từ file lên
            _danhSachTuVung = _kho.DocDuLieu();

            // Gán null trước để reset bảng, tránh lỗi không cập nhật
            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = _danhSachTuVung;

            if (dgvDanhSach.Columns.Count > 0)
            {
                dgvDanhSach.Columns["TiengAnh"].HeaderText = "Từ Tiếng Anh";
                dgvDanhSach.Columns["PhienAm"].HeaderText = "Phiên Âm";
                dgvDanhSach.Columns["TiengViet"].HeaderText = "Nghĩa Tiếng Việt";
                dgvDanhSach.Columns["LoaiTu"].HeaderText = "Loại Từ";
                dgvDanhSach.Columns["ChuDe"].HeaderText = "Chủ Đề";
                dgvDanhSach.Columns["DaThuoc"].HeaderText = "Đã Thuộc";
            }
        }

        private async void btnDich_Click(object sender, EventArgs e)
        {
            string tu = txtTiengAnh.Text.Trim();
            if (string.IsNullOrEmpty(tu)) return;

            btnDich.Text = "..."; // Báo hiệu đang chạy
            btnDich.Enabled = false;

            // Gọi class dịch vụ
            DichThuatService service = new DichThuatService();
            var ketQua = await service.TraCuuTuDayDu(tu);

            // Điền dữ liệu vào các ô
            txtTiengViet.Text = ketQua.NghiaTiengViet;
            txtPhienAm.Text = ketQua.PhienAm;
            txtLoaiTu.Text = ketQua.CacLoaiTu;

            if (string.IsNullOrEmpty(txtLoaiTu.Text) && txtTiengAnh.Text.Contains(" ")) // Nếu không tìm được loại từ và từ nhập vào là cụm từ hoặc câu
            {
                txtLoaiTu.Text = "";
            }

            btnDich.Text = "Dịch";
            btnDich.Enabled = true;
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            string cauCanDoc = txtTiengAnh.Text.Trim();
            if (string.IsNullOrEmpty(cauCanDoc)) return;

            // Tạo máy đọc
            SpeechSynthesizer mayDoc = new SpeechSynthesizer();
            mayDoc.Volume = 100; // Âm lượng max
            mayDoc.Rate = 0;     // Tốc độ bình thường
            mayDoc.SelectVoiceByHints(VoiceGender.NotSet, VoiceAge.NotSet, 0, new System.Globalization.CultureInfo("en-US")); // Giọng Anh-Mỹ

            // Đọc bất chấp (chạy ngầm)
            mayDoc.SpeakAsync(cauCanDoc);
        }

        private string VietHoaChuCaiDauTien(string vanBan)
        {
            vanBan = vanBan.Trim();
            if (string.IsNullOrEmpty(vanBan)) return vanBan;
            vanBan = char.ToUpper(vanBan[0]) + vanBan.Substring(1);
            return vanBan;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTiengAnh.Text == "" || txtTiengViet.Text == "")
            {
                MessageBox.Show("Chưa nhập gì ní ơi!", "Cảnh báo");
                return;
            }

            bool daTonTai = _danhSachTuVung.Any(tu => (tu.TiengAnh.ToLower() == txtTiengAnh.Text.Trim().ToLower()) &&  (tu.TiengViet.ToLower() == txtTiengViet.Text.Trim().ToLower()));
            if(daTonTai)
            {
                MessageBox.Show("Từ này đã có trong từ điển rồi nè!", "Cảnh báo");
                return;
            }

            TuVung tuMoi = new TuVung();
            tuMoi.TiengAnh = VietHoaChuCaiDauTien(txtTiengAnh.Text);
            tuMoi.TiengViet = VietHoaChuCaiDauTien(txtTiengViet.Text);
            tuMoi.LoaiTu = txtLoaiTu.Text; // Lấy luôn loại từ vừa dịch được
            tuMoi.PhienAm = txtPhienAm.Text; // Lấy luôn phiên âm vừa dịch được
            tuMoi.DaThuoc = false;
            string chuDe = cboChonChuDe.Text.Trim();
            if (string.IsNullOrEmpty(chuDe))
            {
                chuDe = "Khác";
            }
            else
            {
                chuDe = VietHoaChuCaiDauTien(chuDe);
            }
            tuMoi.ChuDe = chuDe;

            _danhSachTuVung.Insert(0, tuMoi); // Thêm vào đầu danh sách
            _kho.LuuDuLieu(_danhSachTuVung);

            TaiDuLieuLenBang();
            TaiDanhSachChuDe(); // Cập nhật lại danh sách chủ đề

            // Reset ô nhập
            txtTiengAnh.Text = "";
            txtTiengViet.Text = "";
            txtLoaiTu.Text = "";
            txtPhienAm.Text = ""; // Reset luôn ô phiên âm

            txtTiengAnh.Focus();

            if(dgvDanhSach.Rows.Count > 0)
            {
                dgvDanhSach.FirstDisplayedScrollingRowIndex = 0; // Cuộn lên đầu bảng
                dgvDanhSach.Rows[0].Selected = true; // Chọn dòng đầu tiên
                dgvDanhSach.CurrentCell = dgvDanhSach.Rows[0].Cells[0]; // Đặt con trỏ vào dòng đầu tiên
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Xóa thiệt hả?", "Hỏi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int chiSo = dgvDanhSach.SelectedRows[0].Index;
                _danhSachTuVung.RemoveAt(chiSo);

                _kho.LuuDuLieu(_danhSachTuVung);
                TaiDuLieuLenBang();

                // Xóa trắng ô nhập
                txtTiengAnh.Text = "";
                txtTiengViet.Text = "";
                txtLoaiTu.Text = "";
                txtPhienAm.Text = "";
            }
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _kho.LuuDuLieu(_danhSachTuVung);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void TaiDanhSachChuDe()
        {
            var danhSachChuDe = _danhSachTuVung
                                .Select(dscd => dscd.ChuDe)
                                .Distinct()
                                .ToList();
            danhSachChuDe.Insert(0, "Tất cả chủ đề");  // Thêm mục "Tất cả" vào đầu danh sách
            cboLocChuDe.DataSource = danhSachChuDe;
            cboChonChuDe.DataSource = danhSachChuDe.Where(cd => cd != "Tất cả chủ đề").ToList(); // Loại bỏ "Tất cả chủ đề" khỏi cboChonChuDe
        }

        private void cboLocChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            IEnumerable<TuVung> ketQua = _danhSachTuVung;
            var chuDeDaChon = cboLocChuDe.SelectedItem?.ToString();     // selectedItem? là null check nhưng vẫn có thể rỗng
            var tuKhoa = txtTimKiem.Text.Trim().ToLower();

            if (tuKhoa == "tìm kiếm")
            {
                tuKhoa = "";
            }

            switch(cboLocDaThuoc.Text)
            {
                case "Đã thuộc":
                    ketQua = ketQua.Where(tu => tu.DaThuoc == true);
                    break;
                case "Chưa thuộc":
                    ketQua = ketQua.Where(tu => tu.DaThuoc == false);
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(chuDeDaChon) && chuDeDaChon != "Tất cả chủ đề")
            {
                ketQua = ketQua.Where(cd => cd.ChuDe == chuDeDaChon);
            }

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                ketQua = ketQua.Where(tu => tu.TiengAnh.ToLower().Contains(tuKhoa) || tu.TiengViet.ToLower().Contains(tuKhoa)).ToList();
            }

            dgvDanhSach.DataSource = null;  // Reset bảng
            dgvDanhSach.DataSource = ketQua.ToList();
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dongDaChon = dgvDanhSach.Rows[e.RowIndex];
                txtTiengAnh.Text = dongDaChon.Cells["TiengAnh"].Value?.ToString();
                txtTiengViet.Text = dongDaChon.Cells["TiengViet"].Value?.ToString();
                txtPhienAm.Text = dongDaChon.Cells["PhienAm"].Value?.ToString();
                txtLoaiTu.Text = dongDaChon.Cells["LoaiTu"].Value?.ToString();
            }
        }

        private void TaiDanhSachTrangThai()
        {
            cboLocDaThuoc.Items.Clear();
            cboLocDaThuoc.Items.Add("Tất cả trạng thái");
            cboLocDaThuoc.Items.Add("Đã thuộc");
            cboLocDaThuoc.Items.Add("Chưa thuộc");
            cboLocDaThuoc.SelectedIndex = 0; // Mặc định chọn "Tất cả"
        }

        private void cboLocDaThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }
    }
}
