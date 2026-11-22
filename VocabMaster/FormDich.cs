using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using Newtonsoft.Json;

namespace VocabMaster
{
    public partial class FormDich : Form
    {
        DatabaseHelper _db = new DatabaseHelper();
        System.Windows.Forms.Timer _timerTuDongDich;
        private bool _menuMoRong = false;
        private int _idTuDangChon = -1; // -1 nghĩa là chưa chọn từ nào

        private readonly SpeechSynthesizer _mayDoc;
        private readonly DichThuatService _dichService = new DichThuatService();
        private int _maLuotTraCuu;
        private bool _dangDongForm;
        private const int SoTuMoiTrang = 20;
        private int _trangHienTai = 1;
        private int _tongSoTrang;
        private bool _dangKhoiTaoBoLoc;
        private bool _dangGanDuLieu;
        private Button _btnTrangTruoc;
        private Button _btnTrangSau;
        private Label _lblThongTinTrang;

        #region Khởi tạo & Dọn dẹp
        public FormDich()
        {
            InitializeComponent();
            TaoThanhPhanTrang();
            spin1.Visible = false;
            _timerTuDongDich = new System.Windows.Forms.Timer();
            _timerTuDongDich.Interval = 500;
            _timerTuDongDich.Tick += TimerTuDongDich_Tick;
            KichHoatNut(btnTuDien);

            _mayDoc = new SpeechSynthesizer
            {
                Volume = 100,
                Rate = 0
            };
            _mayDoc.SelectVoiceByHints(VoiceGender.NotSet, VoiceAge.NotSet, 0, new System.Globalization.CultureInfo("en-US"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _dangKhoiTaoBoLoc = true;
            TaiDanhSachChuDe();
            TaiDanhSachTrangThai();
            _dangKhoiTaoBoLoc = false;
            TaiDuLieuLenBang();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _dangDongForm = true;
            VoHieuHoaLuotTraCuu();
            _timerTuDongDich.Tick -= TimerTuDongDich_Tick;
            _timerTuDongDich.Dispose();
            _mayDoc?.Dispose();
            base.OnFormClosed(e);
        }
        #endregion

        #region Tải dữ liệu & Lọc
        private void TaoThanhPhanTrang()
        {
            var thanhPhanTrang = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 42,
                Padding = new Padding(6, 5, 0, 0),
                BackColor = splitContainer1.Panel1.BackColor,
                WrapContents = false
            };
            _btnTrangTruoc = new Button { Text = "Trước", Width = 80, Height = 30 };
            _btnTrangSau = new Button { Text = "Sau", Width = 80, Height = 30 };
            _lblThongTinTrang = new Label
            {
                Text = "Trang 0/0 - 0 từ",
                Width = 225,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F)
            };
            _btnTrangTruoc.Click += (sender, e) => ChuyenTrang(-1);
            _btnTrangSau.Click += (sender, e) => ChuyenTrang(1);
            thanhPhanTrang.Controls.Add(_btnTrangTruoc);
            thanhPhanTrang.Controls.Add(_lblThongTinTrang);
            thanhPhanTrang.Controls.Add(_btnTrangSau);
            splitContainer1.Panel1.Controls.Add(thanhPhanTrang);
            dgvDanhSach.Height -= thanhPhanTrang.Height;
        }

        private void ChuyenTrang(int buoc)
        {
            int trangMoi = _trangHienTai + buoc;
            if (trangMoi < 1 || trangMoi > _tongSoTrang) return;
            _trangHienTai = trangMoi;
            TaiDuLieuLenBang();
        }

        private void TaiDuLieuLenBang()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa.Equals("Tìm kiếm", StringComparison.OrdinalIgnoreCase)) tuKhoa = "";
            string chuDe = cboLocChuDe.SelectedItem?.ToString();
            string trangThai = cboLocDaThuoc.SelectedItem?.ToString();

            string dieuKien = " FROM TuVung t LEFT JOIN ChuDe c ON t.IdChuDe = c.IdChuDe WHERE 1=1";
            if (tuKhoa.Length > 0)
                dieuKien += " AND (t.TiengAnh LIKE @TuKhoa OR t.TiengViet LIKE @TuKhoa)";
            if (!string.IsNullOrEmpty(chuDe) && chuDe != "Tất cả chủ đề")
                dieuKien += " AND c.TenChuDe = @ChuDe";
            if (trangThai == "Đã thuộc" || trangThai == "Chưa thuộc")
                dieuKien += " AND t.DaThuoc = @DaThuoc";

            DataTable bangDem = _db.LayDuLieu("SELECT COUNT(*) AS TongSoTu" + dieuKien,
                TaoThamSoLoc(tuKhoa, chuDe, trangThai).ToArray());
            int tongSoTu = Convert.ToInt32(bangDem.Rows[0]["TongSoTu"]);
            _tongSoTrang = (tongSoTu + SoTuMoiTrang - 1) / SoTuMoiTrang;
            _trangHienTai = _tongSoTrang == 0 ? 0 : Math.Max(1, Math.Min(_trangHienTai, _tongSoTrang));

            string sql = @"SELECT t.IdTuVung, t.TiengAnh, t.PhienAm, t.TiengViet,
                    t.LoaiTu, c.TenChuDe AS ChuDe, t.DaThuoc"
                + dieuKien + " ORDER BY t.TiengAnh ASC, t.IdTuVung ASC OFFSET @BoQua ROWS FETCH NEXT @GioiHan ROWS ONLY";
            var thamSo = TaoThamSoLoc(tuKhoa, chuDe, trangThai);
            thamSo.Add(new SqlParameter("@BoQua", SqlDbType.Int) { Value = _trangHienTai == 0 ? 0 : (_trangHienTai - 1) * SoTuMoiTrang });
            thamSo.Add(new SqlParameter("@GioiHan", SqlDbType.Int) { Value = SoTuMoiTrang });
            DataTable dt = _db.LayDuLieu(sql, thamSo.ToArray());

            _dangGanDuLieu = true;
            try
            {
                dgvDanhSach.DataSource = null;
                dgvDanhSach.DataSource = dt;
                DinhDangBangTuVung();
                dgvDanhSach.ClearSelection();
            }
            finally
            {
                _dangGanDuLieu = false;
            }
            _idTuDangChon = -1;
            _lblThongTinTrang.Text = $"Trang {_trangHienTai}/{_tongSoTrang} - {tongSoTu} từ";
            _btnTrangTruoc.Enabled = _trangHienTai > 1;
            _btnTrangSau.Enabled = _trangHienTai > 0 && _trangHienTai < _tongSoTrang;
        }

        private List<SqlParameter> TaoThamSoLoc(string tuKhoa, string chuDe, string trangThai)
        {
            var thamSo = new List<SqlParameter>();
            if (tuKhoa.Length > 0)
                thamSo.Add(new SqlParameter("@TuKhoa", SqlDbType.NVarChar, 255) { Value = "%" + tuKhoa + "%" });
            if (!string.IsNullOrEmpty(chuDe) && chuDe != "Tất cả chủ đề")
                thamSo.Add(new SqlParameter("@ChuDe", SqlDbType.NVarChar, 100) { Value = chuDe });
            if (trangThai == "Đã thuộc" || trangThai == "Chưa thuộc")
                thamSo.Add(new SqlParameter("@DaThuoc", SqlDbType.Bit) { Value = trangThai == "Đã thuộc" });
            return thamSo;
        }

        private void DinhDangBangTuVung()
        {
            if (dgvDanhSach.Columns.Count == 0) return;
            dgvDanhSach.Columns["IdTuVung"].Visible = false;
            dgvDanhSach.Columns["TiengAnh"].HeaderText = "Từ Tiếng Anh";
            dgvDanhSach.Columns["PhienAm"].HeaderText = "Phiên Âm";
            dgvDanhSach.Columns["TiengViet"].HeaderText = "Nghĩa Tiếng Việt";
            dgvDanhSach.Columns["LoaiTu"].HeaderText = "Loại Từ";
            dgvDanhSach.Columns["ChuDe"].HeaderText = "Chủ Đề";
            dgvDanhSach.Columns["DaThuoc"].HeaderText = "Đã Thuộc";
            dgvDanhSach.ReadOnly = false;
            foreach (DataGridViewColumn cot in dgvDanhSach.Columns)
                cot.ReadOnly = cot.Name != "DaThuoc";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void TaiDanhSachChuDe()
        {
            string chuDeDangLoc = cboLocChuDe.SelectedItem?.ToString();
            string sql = "SELECT TenChuDe FROM ChuDe ORDER BY TenChuDe ASC";
            DataTable dt = _db.LayDuLieu(sql);

            List<string> danhSachChuDe = new List<string>();
            danhSachChuDe.Add("Tất cả chủ đề");

            foreach (DataRow row in dt.Rows)
            {
                danhSachChuDe.Add(row["TenChuDe"].ToString());
            }

            bool dangKhoiTao = _dangKhoiTaoBoLoc;
            _dangKhoiTaoBoLoc = true;
            try
            {
                cboLocChuDe.DataSource = danhSachChuDe;
                if (danhSachChuDe.Contains(chuDeDangLoc))
                    cboLocChuDe.SelectedItem = chuDeDangLoc;
            }
            finally
            {
                _dangKhoiTaoBoLoc = dangKhoiTao;
            }

            List<string> danhSachChon = new List<string>(danhSachChuDe);
            danhSachChon.Remove("Tất cả chủ đề");
            cboChonChuDe.DataSource = danhSachChon;
        }

        private void cboLocChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangKhoiTaoBoLoc) return;
            LocDuLieu();
        }

        private void TaiDanhSachTrangThai()
        {
            cboLocDaThuoc.Items.Clear();
            cboLocDaThuoc.Items.Add("Tất cả trạng thái");
            cboLocDaThuoc.Items.Add("Đã thuộc");
            cboLocDaThuoc.Items.Add("Chưa thuộc");
            cboLocDaThuoc.SelectedIndex = 0;
        }

        private void cboLocDaThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangKhoiTaoBoLoc) return;
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            if (_dangKhoiTaoBoLoc || !IsHandleCreated) return;
            _trangHienTai = 1;
            TaiDuLieuLenBang();
        }
        #endregion

        #region Thao tác Dữ liệu (Thêm, Sửa, Xóa)
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTiengAnh.Text == "" || txtTiengViet.Text == "")
            {
                MessageBox.Show("Chưa nhập gì ní ơi!", "Cảnh báo");
                return;
            }

            string tiengAnh = VietHoaChuCaiDauTien(txtTiengAnh.Text).Replace("'", "''");
            string tiengViet = VietHoaChuCaiDauTien(txtTiengViet.Text).Replace("'", "''");
            string loaiTu = txtLoaiTu.Text.Replace("'", "''");
            string phienAm = txtPhienAm.Text.Replace("'", "''");

            string sqlKiemTra = $"SELECT * FROM TuVung WHERE TiengAnh = N'{tiengAnh}' AND TiengViet = N'{tiengViet}'";
            DataTable dtKiemTra = _db.LayDuLieu(sqlKiemTra);
            if (dtKiemTra.Rows.Count > 0)
            {
                MessageBox.Show("Từ này đã có trong từ điển rồi nè!", "Cảnh báo");
                return;
            }

            int idChuDe = XuLyChuDe();

            string sqlThemTu = $"INSERT INTO TuVung (TiengAnh, TiengViet, LoaiTu, PhienAm, DaThuoc, IdChuDe) " +
                               $"VALUES (N'{tiengAnh}', N'{tiengViet}', N'{loaiTu}', N'{phienAm}', 0, {idChuDe})";
            _db.ThucThiLenh(sqlThemTu);

            TaiDanhSachChuDe();
            TaiDuLieuLenBang();

            txtTiengAnh.Text = "";
            txtTiengViet.Text = "";
            txtLoaiTu.Text = "";
            txtPhienAm.Text = "";
            cboChonChuDe.Text = "Nhập chủ đề";
            txtTiengAnh.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idTuDangChon == -1)
            {
                MessageBox.Show("Chưa chọn từ để sửa. Nhấn đúp vào một từ trong bảng để chọn.", "Cảnh báo");
                return;
            }

            btnSua.Text = "...";
            btnSua.Enabled = false;

            string tiengAnh = VietHoaChuCaiDauTien(txtTiengAnh.Text).Replace("'", "''");
            string tiengViet = VietHoaChuCaiDauTien(txtTiengViet.Text).Replace("'", "''");
            string loaiTu = txtLoaiTu.Text.Replace("'", "''");
            string phienAm = txtPhienAm.Text.Replace("'", "''");

            int idChuDe = XuLyChuDe();

            string sqlSua = $"UPDATE TuVung SET TiengAnh = N'{tiengAnh}', TiengViet = N'{tiengViet}', LoaiTu = N'{loaiTu}', PhienAm = N'{phienAm}', IdChuDe = {idChuDe} WHERE IdTuVung = {_idTuDangChon}";
            _db.ThucThiLenh(sqlSua);

            TaiDanhSachChuDe();
            TaiDuLieuLenBang();

            _idTuDangChon = -1;
            btnSua.Text = "Sửa";
            btnSua.Enabled = true;

            txtTiengAnh.Text = "";
            txtTiengViet.Text = "";
            txtLoaiTu.Text = "";
            txtPhienAm.Text = "";
            cboChonChuDe.Text = "Nhập chủ đề";

            MessageBox.Show("Sửa từ thành công!", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Xóa thiệt hả?", "Hỏi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int idXoa = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["IdTuVung"].Value);

                string sqlXoa = $"DELETE FROM TuVung WHERE IdTuVung = {idXoa}";
                _db.ThucThiLenh(sqlXoa);

                TaiDanhSachChuDe();
                TaiDuLieuLenBang();

                txtTiengAnh.Text = "";
                txtTiengViet.Text = "";
                txtLoaiTu.Text = "";
                txtPhienAm.Text = "";
                cboChonChuDe.Text = "Nhập chủ đề";
                _idTuDangChon = -1;
            }
        }
        #endregion

        #region Xử lý Giao diện DataGridView
        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dong = dgvDanhSach.Rows[e.RowIndex];

                _idTuDangChon = Convert.ToInt32(dong.Cells["IdTuVung"].Value);

                txtTiengAnh.Text = dong.Cells["TiengAnh"].Value?.ToString();
                txtTiengViet.Text = dong.Cells["TiengViet"].Value?.ToString();
                txtPhienAm.Text = dong.Cells["PhienAm"].Value?.ToString();
                txtLoaiTu.Text = dong.Cells["LoaiTu"].Value?.ToString();
                cboChonChuDe.Text = dong.Cells["ChuDe"].Value?.ToString();

                MessageBox.Show("Chỉnh sửa và nhấn nút Sửa để lưu lại.", "Thông báo");
                txtTiengAnh.Focus();
            }
        }

        private void dgvDanhSach_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.IsCurrentCellDirty && dgvDanhSach.CurrentCell.OwningColumn.Name == "DaThuoc")
            {
                dgvDanhSach.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_dangGanDuLieu && e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvDanhSach.Columns[e.ColumnIndex].Name == "DaThuoc")
            {
                int idTuVung = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["IdTuVung"].Value);
                bool daThuoc = Convert.ToBoolean(dgvDanhSach.Rows[e.RowIndex].Cells["DaThuoc"].Value);

                int trangThai = daThuoc ? 1 : 0;
                string sqlSuaTrangThai = $"UPDATE TuVung SET DaThuoc = {trangThai} WHERE IdTuVung = {idTuVung}";
                _db.ThucThiLenh(sqlSuaTrangThai);
                BeginInvoke(new Action(() =>
                {
                    if (!_dangDongForm && !IsDisposed) TaiDuLieuLenBang();
                }));
            }
        }
        private bool _isDichAnhViet = true;

        #endregion

        #region Xử lý Dịch thuật & Phát âm
        private void VoHieuHoaLuotTraCuu()
        {
            _maLuotTraCuu++;
            _timerTuDongDich.Stop();
            if (!spin1.IsDisposed)
                spin1.Visible = false;
        }

        private bool LaLuotTraCuuHienHanh(int maLuot, bool dichAnhViet)
        {
            return !_dangDongForm && !IsDisposed && !Disposing
                && maLuot == _maLuotTraCuu && dichAnhViet == _isDichAnhViet;
        }

        private async Task DichAnhViet(string tu, int maLuot)
        {
            try
            {
                var ketQua = await _dichService.TraCuuTuDayDu(tu);

                if (!LaLuotTraCuuHienHanh(maLuot, true) || txtTiengAnh.Text.Trim() != tu) return;

                txtTiengViet.Text = ketQua.NghiaTiengViet;
                txtPhienAm.Text = ketQua.PhienAm;
                txtLoaiTu.Text = ketQua.CacLoaiTu;

                if (string.IsNullOrEmpty(txtLoaiTu.Text) && txtTiengAnh.Text.Contains(" "))
                {
                    txtLoaiTu.Text = "";
                }
            }
            catch (Exception)
            {
                if (LaLuotTraCuuHienHanh(maLuot, true) && txtTiengAnh.Text.Trim() == tu)
                    txtTiengViet.Text = "Lỗi mạng hoặc dịch vụ API...";
            }
        }

        private async Task DichVietAnh(string tu, int maLuot)
        {
            try
            {
                var ketQua = await _dichService.TraCuuTuVietAnh(tu);

                if (!LaLuotTraCuuHienHanh(maLuot, false) || txtTiengViet.Text.Trim() != tu) return;

                txtTiengAnh.Text = ketQua.TuTiengAnh;
                txtPhienAm.Text = ketQua.PhienAm;
                txtLoaiTu.Text = ketQua.CacLoaiTu;
            }
            catch (Exception)
            {
                if (LaLuotTraCuuHienHanh(maLuot, false) && txtTiengViet.Text.Trim() == tu)
                    txtTiengAnh.Text = "Lỗi mạng hoặc dịch vụ API...";
            }
        }

        private void btnDaoChieu_Click(object sender, EventArgs e)
        {
            VoHieuHoaLuotTraCuu();
            _isDichAnhViet = !_isDichAnhViet;

            Point viTriLabelTren = new Point(10, 12);
            Point viTriTextTren = new Point(10, 53);
            Point viTriLabelDuoi = new Point(10, 323);
            Point viTriTextDuoi = new Point(10, 364);

            if (_isDichAnhViet)
            {
                lblTiengAnh.Location = viTriLabelTren;
                txtTiengAnh.Location = viTriTextTren;
                
                lblTiengViet.Location = viTriLabelDuoi;
                txtTiengViet.Location = viTriTextDuoi;
                
                txtTiengAnh.Focus();
            }
            else
            {
                lblTiengViet.Location = viTriLabelTren;
                txtTiengViet.Location = viTriTextTren;
                
                lblTiengAnh.Location = viTriLabelDuoi;
                txtTiengAnh.Location = viTriTextDuoi;
                
                txtTiengViet.Focus();
            }

            txtTiengAnh.Clear();
            txtTiengViet.Clear();
            txtPhienAm.Clear();
            txtLoaiTu.Clear();
            _timerTuDongDich.Stop();
        }

        private async void TimerTuDongDich_Tick(object sender, EventArgs e)
        {
            _timerTuDongDich.Stop();
            int maLuot = _maLuotTraCuu;
            bool dichAnhViet = _isDichAnhViet;
            string tu = (dichAnhViet ? txtTiengAnh.Text : txtTiengViet.Text).Trim();
            if (string.IsNullOrEmpty(tu) || !LaLuotTraCuuHienHanh(maLuot, dichAnhViet)) return;

            spin1.Visible = true;
            try
            {
                if (dichAnhViet)
                    await DichAnhViet(tu, maLuot);
                else
                    await DichVietAnh(tu, maLuot);
            }
            finally
            {
                if (LaLuotTraCuuHienHanh(maLuot, dichAnhViet))
                    spin1.Visible = false;
            }
        }

        private void txtTiengAnh_TextChanged(object sender, EventArgs e)
        {
            if (!_isDichAnhViet || !txtTiengAnh.Focused) return;
            VoHieuHoaLuotTraCuu();
            if (!string.IsNullOrWhiteSpace(txtTiengAnh.Text))
                _timerTuDongDich.Start();
        }

        private void txtTiengViet_TextChanged(object sender, EventArgs e)
        {
            if (_isDichAnhViet || !txtTiengViet.Focused) return;
            VoHieuHoaLuotTraCuu();
            if (!string.IsNullOrWhiteSpace(txtTiengViet.Text))
                _timerTuDongDich.Start();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            string cauCanDoc = txtTiengAnh.Text.Trim();
            if (string.IsNullOrEmpty(cauCanDoc)) return;

            btnLoa.Text = "...";
            btnLoa.Enabled = false;

            _mayDoc.SpeakAsyncCancelAll();
            _mayDoc.SpeakAsync(cauCanDoc);

            btnLoa.Text = "🔊";
            btnLoa.Enabled = true;
        }
        #endregion

        #region Điều hướng Menu & Trắc Nghiệm
        private void MoFormCon(Form frmCon)
        {
            foreach (Form frm in pnlNoiDung.Controls.OfType<Form>().ToList())
            {
                frm.Close();
            }

            frmCon.TopLevel = false;
            frmCon.FormBorderStyle = FormBorderStyle.None;
            frmCon.Dock = DockStyle.Fill;

            pnlNoiDung.Controls.Add(frmCon);
            frmCon.Show();
            frmCon.BringToFront();
        }

        private void ResetMauNut()
        {
            btnTuDien.BackColor = Color.White;
            btnTracNghiem.BackColor = Color.White;
            btnDashboard.BackColor = Color.White;
            btnFlashCard.BackColor = Color.White;
        }

        private void KichHoatNut(Button nutDangChon)
        {
            ResetMauNut();
            nutDangChon.BackColor = Color.LightSkyBlue;
        }

        private void btnTuDien_Click(object sender, EventArgs e)
        {
            KichHoatNut(btnTuDien);

            foreach (Form frm in pnlNoiDung.Controls.OfType<Form>().ToList())
            {
                frm.Close();
            }

            splitContainer1.Visible = true;
            splitContainer1.BringToFront();
        }

        private void btnTracNghiem_Click(object sender, EventArgs e)
        {
            VoHieuHoaLuotTraCuu();
            KichHoatNut(btnTracNghiem);
            splitContainer1.Visible = false;

            List<TuVung> danhSachMoiNhat = LayDanhSachTuVungTuDB();
            MoFormCon(new FormKetQua(0, 5, danhSachMoiNhat, true));
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (_menuMoRong)
            {
                pnlMenu.Width = 50;
                btnMenu.Text = "";
                btnTuDien.Text = "";
                btnXuatFile.Text = "";
                btnNhapFile.Text = "";
                btnTracNghiem.Text = "";
                btnFlashCard.Text = "";
                btnDashboard.Text = "";
                _menuMoRong = false;
            }
            else
            {
                pnlMenu.Width = 200;
                btnMenu.Text = "Mở rộng";
                btnTuDien.Text = "Từ vựng";
                btnXuatFile.Text = "Xuất file";
                btnNhapFile.Text = "Nhập file";
                btnFlashCard.Text = "Flashcard";
                btnTracNghiem.Text = "Trắc nghiệm";
                btnDashboard.Text = "Thống kê";
                _menuMoRong = true;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            VoHieuHoaLuotTraCuu();
            KichHoatNut(btnDashboard);
            splitContainer1.Visible = false;

            MoFormCon(new FormDashboard());
        }

        private void btnFlashCard_Click(object sender, EventArgs e)
        {
            VoHieuHoaLuotTraCuu();
            KichHoatNut(btnFlashCard);
            splitContainer1.Visible = false;

            List<TuVung> danhSachMoiNhat = LayDanhSachTuVungTuDB();
            MoFormCon(new FormKetQua(0, 5, danhSachMoiNhat, true, KieuHocTap.FlashCard));
        }
        #endregion

        #region Tiện ích & Nhập Xuất File
        private string VietHoaChuCaiDauTien(string vanBan)
        {
            vanBan = vanBan.Trim();
            if (string.IsNullOrEmpty(vanBan)) return vanBan;
            vanBan = char.ToUpper(vanBan[0]) + vanBan.Substring(1);
            return vanBan;
        }

        private int XuLyChuDe()
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
            tenChuDe = tenChuDe.Replace("'", "''");

            string sqlKiemTra = $"SELECT IdChuDe FROM ChuDe WHERE TenChuDe = N'{tenChuDe}'";
            DataTable dtChuDe = _db.LayDuLieu(sqlKiemTra);

            if (dtChuDe.Rows.Count > 0)
            {
                return Convert.ToInt32(dtChuDe.Rows[0]["IdChuDe"]);
            }
            else
            {
                string sqlThem = $"INSERT INTO ChuDe (TenChuDe) VALUES (N'{tenChuDe}'); SELECT SCOPE_IDENTITY() AS NewId;";
                DataTable dtMoi = _db.LayDuLieu(sqlThem);
                return Convert.ToInt32(dtMoi.Rows[0]["NewId"]);
            }
        }

        private List<TuVung> LayDanhSachTuVungTuDB()
        {
            List<TuVung> danhSach = new List<TuVung>();
            string sql = @"
                SELECT t.IdTuVung, t.TiengAnh, t.TiengViet, t.PhienAm, t.LoaiTu, c.TenChuDe, t.DaThuoc 
                FROM TuVung t 
                LEFT JOIN ChuDe c ON t.IdChuDe = c.IdChuDe";

            DataTable dt = _db.LayDuLieu(sql);

            foreach (DataRow row in dt.Rows)
            {
                TuVung tu = new TuVung();
                tu.IdTuVung = Convert.ToInt32(row["IdTuVung"]);
                tu.TiengAnh = row["TiengAnh"].ToString();
                tu.TiengViet = row["TiengViet"].ToString();
                tu.PhienAm = row["PhienAm"].ToString();
                tu.LoaiTu = row["LoaiTu"].ToString();
                tu.DaThuoc = Convert.ToBoolean(row["DaThuoc"]);

                tu.ChuDe = new ChuDe();
                tu.ChuDe.TenChuDe = row["TenChuDe"]?.ToString() ?? "Chưa phân loại";

                danhSach.Add(tu);
            }
            return danhSach;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog hopThoaiLuu = new SaveFileDialog();
            hopThoaiLuu.Filter = "JSON Files (*.json)|*.json";
            hopThoaiLuu.FileName = "BoTuVung.json";

            if (hopThoaiLuu.ShowDialog() == DialogResult.OK)
            {
                List<TuVung> danhSachXuat = LayDanhSachTuVungTuDB();
                string json = JsonConvert.SerializeObject(danhSachXuat, Formatting.Indented);
                File.WriteAllText(hopThoaiLuu.FileName, json);

                MessageBox.Show("Xuất file thành công!", "Thông báo");
            }
        }

        private void btnNhapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog hopThoaiMo = new OpenFileDialog();
            hopThoaiMo.Filter = "JSON Files (*.json)|*.json";

            if (hopThoaiMo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(hopThoaiMo.FileName);
                    List<TuVung> danhSachNhap = JsonConvert.DeserializeObject<List<TuVung>>(json);

                    if (danhSachNhap == null || danhSachNhap.Count == 0)
                    {
                        MessageBox.Show("File trống hoặc không chứa dữ liệu từ vựng.", "Lỗi");
                        return;
                    }

                    int soTuThemThanhCong = 0;
                    foreach (var tu in danhSachNhap)
                    {
                        if (string.IsNullOrWhiteSpace(tu.TiengAnh) || string.IsNullOrWhiteSpace(tu.TiengViet))
                            continue;

                        string tiengAnh = tu.TiengAnh.Replace("'", "''");
                        string tiengViet = tu.TiengViet.Replace("'", "''");
                        string loaiTu = tu.LoaiTu != null ? tu.LoaiTu.Replace("'", "''") : "";
                        string phienAm = tu.PhienAm != null ? tu.PhienAm.Replace("'", "''") : "";
                        int daThuoc = tu.DaThuoc ? 1 : 0;

                        string tenChuDe = (tu.ChuDe != null && !string.IsNullOrWhiteSpace(tu.ChuDe.TenChuDe))
                                          ? tu.ChuDe.TenChuDe.Replace("'", "''") : "Chưa phân loại";

                        string sqlKiemTraCD = $"SELECT IdChuDe FROM ChuDe WHERE TenChuDe = N'{tenChuDe}'";
                        DataTable dtCD = _db.LayDuLieu(sqlKiemTraCD);
                        int idChuDe;
                        if (dtCD.Rows.Count > 0)
                        {
                            idChuDe = Convert.ToInt32(dtCD.Rows[0]["IdChuDe"]);
                        }
                        else
                        {
                            string sqlThemCD = $"INSERT INTO ChuDe (TenChuDe) VALUES (N'{tenChuDe}'); SELECT SCOPE_IDENTITY() AS NewId;";
                            idChuDe = Convert.ToInt32(_db.LayDuLieu(sqlThemCD).Rows[0]["NewId"]);
                        }

                        string sqlKiemTraTu = $"SELECT IdTuVung FROM TuVung WHERE TiengAnh = N'{tiengAnh}' AND TiengViet = N'{tiengViet}'";
                        if (_db.LayDuLieu(sqlKiemTraTu).Rows.Count == 0)
                        {
                            string sqlThemTu = $"INSERT INTO TuVung (TiengAnh, TiengViet, LoaiTu, PhienAm, DaThuoc, IdChuDe) " +
                                               $"VALUES (N'{tiengAnh}', N'{tiengViet}', N'{loaiTu}', N'{phienAm}', {daThuoc}, {idChuDe})";
                            _db.ThucThiLenh(sqlThemTu);
                            soTuThemThanhCong++;
                        }
                    }

                    TaiDanhSachChuDe();
                    TaiDuLieuLenBang();
                    MessageBox.Show($"Đã nhập thành công {soTuThemThanhCong} từ hợp lệ vào hệ thống!", "Hoàn tất");
                }
                catch (Exception)
                {
                    MessageBox.Show("File không đúng cấu trúc.\nVui lòng chọn file xuất ra từ ứng dụng.", "Từ chối nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
