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
    public partial class FormDich : Form
    {
        KhoDuLieuJSON _kho = new KhoDuLieuJSON();
        List<TuVung> _danhSachTuVung = new List<TuVung>();
        TuVung _tuDangChon = null;
        System.Windows.Forms.Timer _timerTuDongDich;
        private FormTracNghiem frmTracNghiem;
        private bool _menuMoRong = false;

        public FormDich()
        {
            InitializeComponent();
            _timerTuDongDich = new System.Windows.Forms.Timer();
            _timerTuDongDich.Interval = 500;
            _timerTuDongDich.Tick += TimerTuDongDich_Tick;
            KichHoatNut(btnTuDien);
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
            _danhSachTuVung = _danhSachTuVung.OrderBy(tu => tu.TiengAnh).ToList(); // Sắp xếp từ A-Z

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

        private async void Dich()
        {
            string tu = txtTiengAnh.Text.Trim();
            if (string.IsNullOrEmpty(tu)) return;
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
        }

        private void TimerTuDongDich_Tick(object sender, EventArgs e)
        {
            _timerTuDongDich.Stop();    // Dừng timer để tránh gọi liên tục
            Dich();
        }

        private void txtTiengAnh_TextChanged(object sender, EventArgs e)
        {
            _timerTuDongDich.Stop();    // Dừng timer nếu người dùng vẫn đang gõ
            _timerTuDongDich.Start();   // Bắt đầu đếm ngược
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            string cauCanDoc = txtTiengAnh.Text.Trim();
            if (string.IsNullOrEmpty(cauCanDoc)) return;

            btnLoa.Text = "..."; // Báo hiệu đang chạy
            btnLoa.Enabled = false;

            // Tạo máy đọc
            SpeechSynthesizer mayDoc = new SpeechSynthesizer();
            mayDoc.Volume = 100; // Âm lượng max
            mayDoc.Rate = 0;     // Tốc độ bình thường
            mayDoc.SelectVoiceByHints(VoiceGender.NotSet, VoiceAge.NotSet, 0, new System.Globalization.CultureInfo("en-US")); // Giọng Anh-Mỹ
            // Đọc bất chấp (chạy ngầm)
            mayDoc.SpeakAsync(cauCanDoc);
            btnLoa.Text = "Loa";
            btnLoa.Enabled = true;
        }

        private string VietHoaChuCaiDauTien(string vanBan)
        {
            vanBan = vanBan.Trim();
            if (string.IsNullOrEmpty(vanBan)) return vanBan;
            vanBan = char.ToUpper(vanBan[0]) + vanBan.Substring(1);
            return vanBan;
        }

        private ChuDe ChuDeDaTonTai()
        {
            string tenChuDe = cboChonChuDe.Text.Trim();
            if (string.IsNullOrEmpty(tenChuDe) || tenChuDe.Equals("Nhập chủ đề"))
            {
                tenChuDe = "Chưa phân loại";
            }
            else
            {
                tenChuDe = VietHoaChuCaiDauTien(tenChuDe);
            }
            ChuDe chuDeDaTonTai = _danhSachTuVung
                                    .Select(cd => cd.ChuDe)     // FirstOrDefault chỉ lấy chủ đề đầu tiên tìm thấy
                                    .FirstOrDefault(cd => cd != null && cd.TenChuDe.Equals(tenChuDe));
            ChuDe objChuDeFinal;
            if (chuDeDaTonTai != null)
            {
                objChuDeFinal = chuDeDaTonTai;
            }
            else
            {
                objChuDeFinal = new ChuDe();
                objChuDeFinal.IdChuDe = Guid.NewGuid().ToString();
                objChuDeFinal.TenChuDe = tenChuDe;
            }
            return objChuDeFinal;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTiengAnh.Text == "" || txtTiengViet.Text == "")
            {
                MessageBox.Show("Chưa nhập gì ní ơi!", "Cảnh báo");
                return;
            }

            bool daTonTai = _danhSachTuVung.Any(tu => (tu.TiengAnh.ToLower() == txtTiengAnh.Text.Trim().ToLower()) && (tu.TiengViet.ToLower() == txtTiengViet.Text.Trim().ToLower()));
            if (daTonTai)
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
            tuMoi.ChuDe = ChuDeDaTonTai();

            _danhSachTuVung.Insert(0, tuMoi); // Thêm vào đầu danh sách
            _kho.LuuDuLieu(_danhSachTuVung);

            TaiDuLieuLenBang();
            TaiDanhSachChuDe(); // Cập nhật lại danh sách chủ đề

            // Reset ô nhập
            txtTiengAnh.Text = "";
            txtTiengViet.Text = "";
            txtLoaiTu.Text = "";
            txtPhienAm.Text = ""; // Reset luôn ô phiên âm
            cboChonChuDe.Text = "Nhập chủ đề";

            txtTiengAnh.Focus();

            if (dgvDanhSach.Rows.Count > 0)
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void TaiDanhSachChuDe()
        {
            var danhSachChuDe = _danhSachTuVung
                                .Select(dscd => dscd.ChuDe?.TenChuDe)
                                .Distinct()
                                .ToList();
            danhSachChuDe.Insert(0, "Tất cả chủ đề");   // Thêm mục "Tất cả" vào đầu danh sách
            cboLocChuDe.DataSource = danhSachChuDe;     // Gán danh sách chủ đề cho cboLocChuDe
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

            switch (cboLocDaThuoc.Text)
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
                ketQua = ketQua.Where(cd => cd.ChuDe?.TenChuDe == chuDeDaChon);
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
                DataGridViewRow dongDuocChon = dgvDanhSach.Rows[e.RowIndex];
                txtTiengAnh.Text = dongDuocChon.Cells["TiengAnh"].Value?.ToString();
                txtTiengViet.Text = dongDuocChon.Cells["TiengViet"].Value?.ToString();
                txtPhienAm.Text = dongDuocChon.Cells["PhienAm"].Value?.ToString();
                txtLoaiTu.Text = dongDuocChon.Cells["LoaiTu"].Value?.ToString();
                cboChonChuDe.Text = dongDuocChon.Cells["ChuDe"].Value?.ToString();
                MessageBox.Show("Chỉnh sửa và nhấn nút Sửa để lưu lại.", "Thông báo");
                txtTiengAnh.Focus();
                _tuDangChon = _danhSachTuVung
                              .Find(tu => tu.TiengAnh == txtTiengAnh.Text && tu.TiengViet == txtTiengViet.Text);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_tuDangChon == null)
            {
                MessageBox.Show("Chưa chọn từ để sửa. Nhấn đúp vào một từ trong bảng để chọn.", "Cảnh báo");
                return;
            }

            btnSua.Text = "...";
            btnSua.Enabled = false;

            _tuDangChon.TiengAnh = VietHoaChuCaiDauTien(txtTiengAnh.Text);
            _tuDangChon.TiengViet = VietHoaChuCaiDauTien(txtTiengViet.Text);
            _tuDangChon.LoaiTu = txtLoaiTu.Text;
            _tuDangChon.PhienAm = txtPhienAm.Text;
            _tuDangChon.ChuDe = ChuDeDaTonTai();

            _kho.LuuDuLieu(_danhSachTuVung);
            TaiDuLieuLenBang();
            TaiDanhSachChuDe();

            _tuDangChon = null; // Reset từ đang chọn   
            btnSua.Text = "Sửa";
            btnSua.Enabled = true;

            MessageBox.Show("Sửa từ thành công!", "Thông báo");
        }

        private void ResetMauNut()
        {
            btnTuDien.BackColor = Color.White;
            btnTracNghiem.BackColor = Color.White;
        }

        private void KichHoatNut(Button nutDangChon)
        {
            ResetMauNut();
            nutDangChon.BackColor = Color.LightSkyBlue;
        }

        private void btnTuDien_Click(object sender, EventArgs e)
        {
            KichHoatNut(btnTuDien);
            if (frmTracNghiem != null)
            {
                frmTracNghiem.Hide();
            }

            splitContainer1.Visible = true;
            splitContainer1.BringToFront();
        }

        private void btnTracNghiem_Click(object sender, EventArgs e)
        {
            KichHoatNut(btnTracNghiem);
            splitContainer1.Visible = false;

            if (frmTracNghiem == null || frmTracNghiem.IsDisposed)
            {
                frmTracNghiem = new FormTracNghiem(_danhSachTuVung);

                frmTracNghiem.TopLevel = false;
                frmTracNghiem.FormBorderStyle = FormBorderStyle.None;
                frmTracNghiem.Dock = DockStyle.Fill;

                pnlNoiDung.Controls.Add(frmTracNghiem);
            }

            frmTracNghiem.Show();
            frmTracNghiem.BringToFront();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (_menuMoRong)
            {
                pnlMenu.Width = 50;
                btnMenu.Text = "";
                btnTuDien.Text = "";
                btnTracNghiem.Text = "";
                _menuMoRong = false;
            }
            else
            {
                pnlMenu.Width = 200;
                btnMenu.Text = "    Mở rộng";
                btnTuDien.Text = "  Từ vựng";
                btnTracNghiem.Text = "  Trắc nghiệm";
                _menuMoRong = true;
            }
        }
    }
}
