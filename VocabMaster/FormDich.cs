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

        #region Khởi tạo & Dọn dẹp
        public FormDich()
        {
            InitializeComponent();
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
            TaiDuLieuLenBang();
            TaiDanhSachChuDe();
            TaiDanhSachTrangThai();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mayDoc?.Dispose();
            base.OnFormClosed(e);
        }
        #endregion

        #region Tải dữ liệu & Lọc
        private void TaiDuLieuLenBang()
        {
            string sql = @"
                SELECT 
                    t.IdTuVung, 
                    t.TiengAnh, 
                    t.PhienAm, 
                    t.TiengViet, 
                    t.LoaiTu, 
                    c.TenChuDe AS ChuDe, 
                    t.DaThuoc 
                FROM TuVung t
                LEFT JOIN ChuDe c ON t.IdChuDe = c.IdChuDe
                ORDER BY t.TiengAnh ASC";

            DataTable dt = _db.LayDuLieu(sql);

            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = dt;

            if (dgvDanhSach.Columns.Count > 0)
            {
                dgvDanhSach.Columns["IdTuVung"].Visible = false;
                dgvDanhSach.Columns["TiengAnh"].HeaderText = "Từ Tiếng Anh";
                dgvDanhSach.Columns["PhienAm"].HeaderText = "Phiên Âm";
                dgvDanhSach.Columns["TiengViet"].HeaderText = "Nghĩa Tiếng Việt";
                dgvDanhSach.Columns["LoaiTu"].HeaderText = "Loại Từ";
                dgvDanhSach.Columns["ChuDe"].HeaderText = "Chủ Đề";
                dgvDanhSach.Columns["DaThuoc"].HeaderText = "Đã Thuộc";
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LocDuLieu();
        }

        private void TaiDanhSachChuDe()
        {
            string sql = "SELECT TenChuDe FROM ChuDe ORDER BY TenChuDe ASC";
            DataTable dt = _db.LayDuLieu(sql);

            List<string> danhSachChuDe = new List<string>();
            danhSachChuDe.Add("Tất cả chủ đề");

            foreach (DataRow row in dt.Rows)
            {
                danhSachChuDe.Add(row["TenChuDe"].ToString());
            }

            cboLocChuDe.DataSource = danhSachChuDe;

            List<string> danhSachChon = new List<string>(danhSachChuDe);
            danhSachChon.Remove("Tất cả chủ đề");
            cboChonChuDe.DataSource = danhSachChon;
        }

        private void cboLocChuDe_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            LocDuLieu();
        }

        private void LocDuLieu()
        {
            string tuKhoa = txtTimKiem.Text.Trim().Replace("'", "''");
            if (tuKhoa.ToLower() == "tìm kiếm")
            {
                tuKhoa = "";
            }

            string chuDeDaChon = cboLocChuDe.SelectedItem?.ToString();
            string trangThai = cboLocDaThuoc.Text;

            string sql = @"
                SELECT 
                    t.IdTuVung, 
                    t.TiengAnh, 
                    t.PhienAm, 
                    t.TiengViet, 
                    t.LoaiTu, 
                    c.TenChuDe AS ChuDe, 
                    t.DaThuoc 
                FROM TuVung t
                LEFT JOIN ChuDe c ON t.IdChuDe = c.IdChuDe
                WHERE 1=1 ";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += $" AND (t.TiengAnh LIKE N'%{tuKhoa}%' OR t.TiengViet LIKE N'%{tuKhoa}%') ";
            }

            if (trangThai == "Đã thuộc")
            {
                sql += " AND t.DaThuoc = 1 ";
            }
            else if (trangThai == "Chưa thuộc")
            {
                sql += " AND t.DaThuoc = 0 ";
            }

            if (!string.IsNullOrEmpty(chuDeDaChon) && chuDeDaChon != "Tất cả chủ đề")
            {
                sql += $" AND c.TenChuDe = N'{chuDeDaChon}' ";
            }

            sql += " ORDER BY t.TiengAnh ASC";

            DataTable dt = _db.LayDuLieu(sql);
            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = dt;

            if (dgvDanhSach.Columns.Count > 0)
            {
                dgvDanhSach.Columns["IdTuVung"].Visible = false;
                dgvDanhSach.Columns["TiengAnh"].HeaderText = "Từ Tiếng Anh";
                dgvDanhSach.Columns["PhienAm"].HeaderText = "Phiên Âm";
                dgvDanhSach.Columns["TiengViet"].HeaderText = "Nghĩa Tiếng Việt";
                dgvDanhSach.Columns["LoaiTu"].HeaderText = "Loại Từ";
                dgvDanhSach.Columns["ChuDe"].HeaderText = "Chủ Đề";
                dgvDanhSach.Columns["DaThuoc"].HeaderText = "Đã Thuộc";
            }
            dgvDanhSach.ReadOnly = false;

            foreach (DataGridViewColumn cot in dgvDanhSach.Columns)
            {
                if (cot.Name == "DaThuoc")
                {
                    cot.ReadOnly = false;
                }
                else
                {
                    cot.ReadOnly = true;
                }
            }
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

            TaiDuLieuLenBang();
            TaiDanhSachChuDe();

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

            TaiDuLieuLenBang();
            TaiDanhSachChuDe();

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

                TaiDuLieuLenBang();
                TaiDanhSachChuDe();

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
            if (e.RowIndex >= 0 && dgvDanhSach.Columns[e.ColumnIndex].Name == "DaThuoc")
            {
                int idTuVung = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["IdTuVung"].Value);
                bool daThuoc = Convert.ToBoolean(dgvDanhSach.Rows[e.RowIndex].Cells["DaThuoc"].Value);

                int trangThai = daThuoc ? 1 : 0;
                string sqlSuaTrangThai = $"UPDATE TuVung SET DaThuoc = {trangThai} WHERE IdTuVung = {idTuVung}";
                _db.ThucThiLenh(sqlSuaTrangThai);
            }
        }
        private bool _isDichAnhViet = true;

        #endregion

        #region Xử lý Dịch thuật & Phát âm
        private async Task DichAnhViet()
        {
            string tu = txtTiengAnh.Text.Trim();
            if (string.IsNullOrEmpty(tu)) return;

            try
            {
                var ketQua = await _dichService.TraCuuTuDayDu(tu);

                if (txtTiengAnh.Text.Trim() != tu) return;

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
                if (txtTiengAnh.Text.Trim() == tu)
                    txtTiengViet.Text = "Lỗi mạng hoặc dịch vụ API...";
            }
        }

        private async Task DichVietAnh()
        {
            string tu = txtTiengViet.Text.Trim();
            if (string.IsNullOrEmpty(tu)) return;

            try
            {
                var ketQua = await _dichService.TraCuuTuVietAnh(tu);

                if (txtTiengViet.Text.Trim() != tu) return;

                txtTiengAnh.Text = ketQua.TuTiengAnh;
                txtPhienAm.Text = ketQua.PhienAm;
                txtLoaiTu.Text = ketQua.CacLoaiTu;
            }
            catch (Exception)
            {
                if (txtTiengViet.Text.Trim() == tu)
                    txtTiengAnh.Text = "Lỗi mạng hoặc dịch vụ API...";
            }
        }

        private void btnDaoChieu_Click(object sender, EventArgs e)
        {
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
        }

        private async void TimerTuDongDich_Tick(object sender, EventArgs e)
        {
            _timerTuDongDich.Stop();
            if (_isDichAnhViet)
            {
                await DichAnhViet();
            }
            else
            {
                await DichVietAnh();
            }
        }

        private void txtTiengAnh_TextChanged(object sender, EventArgs e)
        {
            if (!_isDichAnhViet || !txtTiengAnh.Focused) return;
            _timerTuDongDich.Stop();
            _timerTuDongDich.Start();
        }

        private void txtTiengViet_TextChanged(object sender, EventArgs e)
        {
            if (_isDichAnhViet || !txtTiengViet.Focused) return;
            _timerTuDongDich.Stop();
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
            KichHoatNut(btnDashboard);
            splitContainer1.Visible = false;

            MoFormCon(new FormDashboard());
        }

        private void btnFlashCard_Click(object sender, EventArgs e)
        {
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

                    TaiDuLieuLenBang();
                    TaiDanhSachChuDe();
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