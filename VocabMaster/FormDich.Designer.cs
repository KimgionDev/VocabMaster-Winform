namespace VocabMaster
{
    partial class FormDich
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDich));
            this.cboLocChuDe = new System.Windows.Forms.ComboBox();
            this.btnLoa = new System.Windows.Forms.Button();
            this.txtLoaiTu = new System.Windows.Forms.TextBox();
            this.lblLoaiTu = new System.Windows.Forms.Label();
            this.txtPhienAm = new System.Windows.Forms.TextBox();
            this.lblPhienAm = new System.Windows.Forms.Label();
            this.txtTiengViet = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTiengAnh = new System.Windows.Forms.TextBox();
            this.lblTiengAnh = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboLocDaThuoc = new System.Windows.Forms.ComboBox();
            this.lblDanhSachTuVung = new System.Windows.Forms.Label();
            this.cboChonChuDe = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.lblTiengViet = new System.Windows.Forms.Label();
            this.lblChuDe = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnNhapFile = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnTracNghiem = new System.Windows.Forms.Button();
            this.btnTuDien = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.btnFlashCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboLocChuDe
            // 
            this.cboLocChuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocChuDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLocChuDe.Font = new System.Drawing.Font("K2D SemiBold", 8.5F, System.Drawing.FontStyle.Bold);
            this.cboLocChuDe.FormattingEnabled = true;
            this.cboLocChuDe.Location = new System.Drawing.Point(349, 60);
            this.cboLocChuDe.Name = "cboLocChuDe";
            this.cboLocChuDe.Size = new System.Drawing.Size(150, 35);
            this.cboLocChuDe.TabIndex = 16;
            this.cboLocChuDe.Text = "Lọc chủ đề";
            this.cboLocChuDe.SelectedIndexChanged += new System.EventHandler(this.cboLocChuDe_SelectedIndexChanged);
            // 
            // btnLoa
            // 
            this.btnLoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(180)))));
            this.btnLoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoa.FlatAppearance.BorderSize = 0;
            this.btnLoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoa.ForeColor = System.Drawing.Color.White;
            this.btnLoa.Location = new System.Drawing.Point(319, 190);
            this.btnLoa.Name = "btnLoa";
            this.btnLoa.Size = new System.Drawing.Size(70, 40);
            this.btnLoa.TabIndex = 14;
            this.btnLoa.Text = "Loa";
            this.btnLoa.UseVisualStyleBackColor = false;
            this.btnLoa.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // txtLoaiTu
            // 
            this.txtLoaiTu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoaiTu.BackColor = System.Drawing.Color.White;
            this.txtLoaiTu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLoaiTu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtLoaiTu.Location = new System.Drawing.Point(10, 277);
            this.txtLoaiTu.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtLoaiTu.Multiline = true;
            this.txtLoaiTu.Name = "txtLoaiTu";
            this.txtLoaiTu.Size = new System.Drawing.Size(379, 40);
            this.txtLoaiTu.TabIndex = 13;
            // 
            // lblLoaiTu
            // 
            this.lblLoaiTu.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiTu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.lblLoaiTu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoaiTu.Location = new System.Drawing.Point(10, 236);
            this.lblLoaiTu.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.lblLoaiTu.Name = "lblLoaiTu";
            this.lblLoaiTu.Size = new System.Drawing.Size(220, 35);
            this.lblLoaiTu.TabIndex = 12;
            this.lblLoaiTu.Text = "Từ loại";
            this.lblLoaiTu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhienAm
            // 
            this.txtPhienAm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhienAm.BackColor = System.Drawing.Color.White;
            this.txtPhienAm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhienAm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtPhienAm.Location = new System.Drawing.Point(10, 190);
            this.txtPhienAm.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtPhienAm.Multiline = true;
            this.txtPhienAm.Name = "txtPhienAm";
            this.txtPhienAm.Size = new System.Drawing.Size(303, 40);
            this.txtPhienAm.TabIndex = 11;
            // 
            // lblPhienAm
            // 
            this.lblPhienAm.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhienAm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.lblPhienAm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhienAm.Location = new System.Drawing.Point(10, 149);
            this.lblPhienAm.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.lblPhienAm.Name = "lblPhienAm";
            this.lblPhienAm.Size = new System.Drawing.Size(245, 35);
            this.lblPhienAm.TabIndex = 2;
            this.lblPhienAm.Text = "Phiên âm";
            this.lblPhienAm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTiengViet
            // 
            this.txtTiengViet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTiengViet.BackColor = System.Drawing.Color.White;
            this.txtTiengViet.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtTiengViet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtTiengViet.Location = new System.Drawing.Point(10, 364);
            this.txtTiengViet.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtTiengViet.Multiline = true;
            this.txtTiengViet.Name = "txtTiengViet";
            this.txtTiengViet.Size = new System.Drawing.Size(379, 85);
            this.txtTiengViet.TabIndex = 10;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(269, 537);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 35);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(180)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(269, 455);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 35);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTiengAnh
            // 
            this.txtTiengAnh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTiengAnh.BackColor = System.Drawing.Color.White;
            this.txtTiengAnh.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtTiengAnh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtTiengAnh.Location = new System.Drawing.Point(10, 53);
            this.txtTiengAnh.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtTiengAnh.Multiline = true;
            this.txtTiengAnh.Name = "txtTiengAnh";
            this.txtTiengAnh.Size = new System.Drawing.Size(379, 85);
            this.txtTiengAnh.TabIndex = 3;
            this.txtTiengAnh.TextChanged += new System.EventHandler(this.txtTiengAnh_TextChanged);
            // 
            // lblTiengAnh
            // 
            this.lblTiengAnh.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiengAnh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.lblTiengAnh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTiengAnh.Location = new System.Drawing.Point(10, 12);
            this.lblTiengAnh.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.lblTiengAnh.Name = "lblTiengAnh";
            this.lblTiengAnh.Size = new System.Drawing.Size(326, 35);
            this.lblTiengAnh.TabIndex = 0;
            this.lblTiengAnh.Text = "Tiếng Anh";
            this.lblTiengAnh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.AllowUserToResizeRows = false;
            this.dgvDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("K2D", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.EnableHeadersVisualStyles = false;
            this.dgvDanhSach.Location = new System.Drawing.Point(6, 98);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(612, 474);
            this.dgvDanhSach.TabIndex = 1;
            this.dgvDanhSach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellDoubleClick);
            this.dgvDanhSach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellValueChanged);
            this.dgvDanhSach.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDanhSach_CurrentCellDirtyStateChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(14, 12);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(604, 35);
            this.txtTimKiem.TabIndex = 15;
            this.txtTimKiem.Text = "Tìm kiếm";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.splitContainer1.Panel1.Controls.Add(this.cboLocDaThuoc);
            this.splitContainer1.Panel1.Controls.Add(this.lblDanhSachTuVung);
            this.splitContainer1.Panel1.Controls.Add(this.cboLocChuDe);
            this.splitContainer1.Panel1.Controls.Add(this.txtTimKiem);
            this.splitContainer1.Panel1.Controls.Add(this.dgvDanhSach);
            this.splitContainer1.Panel1MinSize = 550;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.cboChonChuDe);
            this.splitContainer1.Panel2.Controls.Add(this.btnSua);
            this.splitContainer1.Panel2.Controls.Add(this.btnXoa);
            this.splitContainer1.Panel2.Controls.Add(this.btnLoa);
            this.splitContainer1.Panel2.Controls.Add(this.lblLoaiTu);
            this.splitContainer1.Panel2.Controls.Add(this.txtTiengAnh);
            this.splitContainer1.Panel2.Controls.Add(this.lblTiengAnh);
            this.splitContainer1.Panel2.Controls.Add(this.btnThem);
            this.splitContainer1.Panel2.Controls.Add(this.txtPhienAm);
            this.splitContainer1.Panel2.Controls.Add(this.txtTiengViet);
            this.splitContainer1.Panel2.Controls.Add(this.lblPhienAm);
            this.splitContainer1.Panel2.Controls.Add(this.lblTiengViet);
            this.splitContainer1.Panel2.Controls.Add(this.txtLoaiTu);
            this.splitContainer1.Panel2.Controls.Add(this.lblChuDe);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel2MinSize = 350;
            this.splitContainer1.Size = new System.Drawing.Size(1052, 583);
            this.splitContainer1.SplitterDistance = 621;
            this.splitContainer1.TabIndex = 17;
            // 
            // cboLocDaThuoc
            // 
            this.cboLocDaThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocDaThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLocDaThuoc.Font = new System.Drawing.Font("K2D SemiBold", 8.5F, System.Drawing.FontStyle.Bold);
            this.cboLocDaThuoc.FormattingEnabled = true;
            this.cboLocDaThuoc.Location = new System.Drawing.Point(505, 60);
            this.cboLocDaThuoc.Name = "cboLocDaThuoc";
            this.cboLocDaThuoc.Size = new System.Drawing.Size(113, 35);
            this.cboLocDaThuoc.TabIndex = 17;
            this.cboLocDaThuoc.Text = "Lọc đã thuộc";
            this.cboLocDaThuoc.SelectedIndexChanged += new System.EventHandler(this.cboLocDaThuoc_SelectedIndexChanged);
            // 
            // lblDanhSachTuVung
            // 
            this.lblDanhSachTuVung.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachTuVung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.lblDanhSachTuVung.Location = new System.Drawing.Point(6, 60);
            this.lblDanhSachTuVung.Margin = new System.Windows.Forms.Padding(3);
            this.lblDanhSachTuVung.Name = "lblDanhSachTuVung";
            this.lblDanhSachTuVung.Size = new System.Drawing.Size(188, 35);
            this.lblDanhSachTuVung.TabIndex = 15;
            this.lblDanhSachTuVung.Text = "Danh sách từ vựng";
            this.lblDanhSachTuVung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboChonChuDe
            // 
            this.cboChonChuDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboChonChuDe.Font = new System.Drawing.Font("K2D SemiBold", 8.5F, System.Drawing.FontStyle.Bold);
            this.cboChonChuDe.FormattingEnabled = true;
            this.cboChonChuDe.Location = new System.Drawing.Point(10, 496);
            this.cboChonChuDe.Name = "cboChonChuDe";
            this.cboChonChuDe.Size = new System.Drawing.Size(164, 35);
            this.cboChonChuDe.TabIndex = 18;
            this.cboChonChuDe.Text = "Nhập chủ đề";
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(180)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(269, 496);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 35);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // lblTiengViet
            // 
            this.lblTiengViet.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiengViet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.lblTiengViet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTiengViet.Location = new System.Drawing.Point(10, 323);
            this.lblTiengViet.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.lblTiengViet.Name = "lblTiengViet";
            this.lblTiengViet.Size = new System.Drawing.Size(326, 35);
            this.lblTiengViet.TabIndex = 1;
            this.lblTiengViet.Text = "Tiếng Việt";
            this.lblTiengViet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChuDe
            // 
            this.lblChuDe.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.lblChuDe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChuDe.Location = new System.Drawing.Point(10, 455);
            this.lblChuDe.Margin = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.lblChuDe.Name = "lblChuDe";
            this.lblChuDe.Size = new System.Drawing.Size(101, 35);
            this.lblChuDe.TabIndex = 19;
            this.lblChuDe.Text = "Chủ đề";
            this.lblChuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMenu.Controls.Add(this.btnNhapFile);
            this.pnlMenu.Controls.Add(this.btnXuatFile);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.btnFlashCard);
            this.pnlMenu.Controls.Add(this.btnTracNghiem);
            this.pnlMenu.Controls.Add(this.btnTuDien);
            this.pnlMenu.Controls.Add(this.btnMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.ForeColor = System.Drawing.Color.Black;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.pnlMenu.Size = new System.Drawing.Size(50, 583);
            this.pnlMenu.TabIndex = 22;
            this.pnlMenu.TabStop = true;
            // 
            // btnNhapFile
            // 
            this.btnNhapFile.BackColor = System.Drawing.Color.White;
            this.btnNhapFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhapFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapFile.FlatAppearance.BorderSize = 0;
            this.btnNhapFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapFile.ForeColor = System.Drawing.Color.Black;
            this.btnNhapFile.Image = global::VocabMaster.Properties.Resources.ic_import_json;
            this.btnNhapFile.Location = new System.Drawing.Point(5, 255);
            this.btnNhapFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhapFile.Name = "btnNhapFile";
            this.btnNhapFile.Size = new System.Drawing.Size(40, 40);
            this.btnNhapFile.TabIndex = 26;
            this.btnNhapFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNhapFile.UseVisualStyleBackColor = false;
            this.btnNhapFile.Click += new System.EventHandler(this.btnNhapFile_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.BackColor = System.Drawing.Color.White;
            this.btnXuatFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXuatFile.FlatAppearance.BorderSize = 0;
            this.btnXuatFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatFile.ForeColor = System.Drawing.Color.Black;
            this.btnXuatFile.Image = global::VocabMaster.Properties.Resources.ic_export_json;
            this.btnXuatFile.Location = new System.Drawing.Point(5, 215);
            this.btnXuatFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(40, 40);
            this.btnXuatFile.TabIndex = 25;
            this.btnXuatFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXuatFile.UseVisualStyleBackColor = false;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.Image = global::VocabMaster.Properties.Resources.ic_btn_dashboard;
            this.btnDashboard.Location = new System.Drawing.Point(5, 175);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(40, 40);
            this.btnDashboard.TabIndex = 27;
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnTracNghiem
            // 
            this.btnTracNghiem.BackColor = System.Drawing.Color.White;
            this.btnTracNghiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTracNghiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTracNghiem.FlatAppearance.BorderSize = 0;
            this.btnTracNghiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTracNghiem.ForeColor = System.Drawing.Color.Black;
            this.btnTracNghiem.Image = global::VocabMaster.Properties.Resources.btn_trac_nghiem;
            this.btnTracNghiem.Location = new System.Drawing.Point(5, 95);
            this.btnTracNghiem.Margin = new System.Windows.Forms.Padding(0);
            this.btnTracNghiem.Name = "btnTracNghiem";
            this.btnTracNghiem.Size = new System.Drawing.Size(40, 40);
            this.btnTracNghiem.TabIndex = 28;
            this.btnTracNghiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTracNghiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTracNghiem.UseVisualStyleBackColor = false;
            this.btnTracNghiem.Click += new System.EventHandler(this.btnTracNghiem_Click);
            // 
            // btnTuDien
            // 
            this.btnTuDien.BackColor = System.Drawing.Color.White;
            this.btnTuDien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuDien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTuDien.FlatAppearance.BorderSize = 0;
            this.btnTuDien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuDien.ForeColor = System.Drawing.Color.Black;
            this.btnTuDien.Image = global::VocabMaster.Properties.Resources.btn_chuyen_doi_en_vi;
            this.btnTuDien.Location = new System.Drawing.Point(5, 55);
            this.btnTuDien.Margin = new System.Windows.Forms.Padding(0);
            this.btnTuDien.Name = "btnTuDien";
            this.btnTuDien.Size = new System.Drawing.Size(40, 40);
            this.btnTuDien.TabIndex = 24;
            this.btnTuDien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTuDien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTuDien.UseVisualStyleBackColor = false;
            this.btnTuDien.Click += new System.EventHandler(this.btnTuDien_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.White;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.Black;
            this.btnMenu.Image = global::VocabMaster.Properties.Resources.btn_menu;
            this.btnMenu.Location = new System.Drawing.Point(5, 15);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(40, 40);
            this.btnMenu.TabIndex = 22;
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.Controls.Add(this.splitContainer1);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(50, 0);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Size = new System.Drawing.Size(1052, 583);
            this.pnlNoiDung.TabIndex = 23;
            // 
            // btnFlashCard
            // 
            this.btnFlashCard.BackColor = System.Drawing.Color.White;
            this.btnFlashCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlashCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFlashCard.FlatAppearance.BorderSize = 0;
            this.btnFlashCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlashCard.ForeColor = System.Drawing.Color.Black;
            this.btnFlashCard.Image = global::VocabMaster.Properties.Resources.ic_btn_flashcard;
            this.btnFlashCard.Location = new System.Drawing.Point(5, 135);
            this.btnFlashCard.Margin = new System.Windows.Forms.Padding(0);
            this.btnFlashCard.Name = "btnFlashCard";
            this.btnFlashCard.Size = new System.Drawing.Size(40, 40);
            this.btnFlashCard.TabIndex = 29;
            this.btnFlashCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlashCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFlashCard.UseVisualStyleBackColor = false;
            this.btnFlashCard.Click += new System.EventHandler(this.btnFlashCard_Click);
            // 
            // FormDich
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1102, 583);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("K2D", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDich";
            this.Text = "VocabMaster";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlNoiDung.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Label lblTiengAnh;
        private System.Windows.Forms.Label lblPhienAm;
        private System.Windows.Forms.TextBox txtTiengAnh;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTiengViet;
        private System.Windows.Forms.TextBox txtPhienAm;
        private System.Windows.Forms.TextBox txtLoaiTu;
        private System.Windows.Forms.Label lblLoaiTu;
        private System.Windows.Forms.Button btnLoa;
        private System.Windows.Forms.ComboBox cboLocChuDe;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblDanhSachTuVung;
        private System.Windows.Forms.ComboBox cboLocDaThuoc;
        private System.Windows.Forms.ComboBox cboChonChuDe;
        private System.Windows.Forms.Label lblChuDe;
        private System.Windows.Forms.Label lblTiengViet;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnTuDien;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnNhapFile;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnTracNghiem;
        private System.Windows.Forms.Button btnFlashCard;
    }
}

