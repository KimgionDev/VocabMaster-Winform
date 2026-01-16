namespace VocabMaster
{
    partial class Form1
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
            this.cboLocChuDe = new System.Windows.Forms.ComboBox();
            this.btnLoa = new System.Windows.Forms.Button();
            this.txtLoaiTu = new System.Windows.Forms.TextBox();
            this.lblLoaiTu = new System.Windows.Forms.Label();
            this.txtPhienAm = new System.Windows.Forms.TextBox();
            this.lblPhienAm = new System.Windows.Forms.Label();
            this.txtTiengViet = new System.Windows.Forms.TextBox();
            this.btnDich = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTiengAnh = new System.Windows.Forms.TextBox();
            this.lblTiengViet = new System.Windows.Forms.Label();
            this.lblTiengAnh = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cboLocDaThuoc = new System.Windows.Forms.ComboBox();
            this.lblDanhSachTuVung = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboLocChuDe
            // 
            this.cboLocChuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocChuDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLocChuDe.Font = new System.Drawing.Font("K2D", 8.5F);
            this.cboLocChuDe.FormattingEnabled = true;
            this.cboLocChuDe.Location = new System.Drawing.Point(278, 60);
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
            this.btnLoa.Font = new System.Drawing.Font("K2D", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoa.ForeColor = System.Drawing.Color.White;
            this.btnLoa.Location = new System.Drawing.Point(363, 190);
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
            this.txtLoaiTu.Size = new System.Drawing.Size(423, 40);
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
            this.txtPhienAm.Size = new System.Drawing.Size(347, 40);
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
            this.txtTiengViet.Size = new System.Drawing.Size(423, 85);
            this.txtTiengViet.TabIndex = 10;
            // 
            // btnDich
            // 
            this.btnDich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(180)))));
            this.btnDich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDich.FlatAppearance.BorderSize = 0;
            this.btnDich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDich.Font = new System.Drawing.Font("K2D", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDich.ForeColor = System.Drawing.Color.White;
            this.btnDich.Location = new System.Drawing.Point(313, 144);
            this.btnDich.Name = "btnDich";
            this.btnDich.Size = new System.Drawing.Size(120, 40);
            this.btnDich.TabIndex = 9;
            this.btnDich.Text = "Dịch";
            this.btnDich.UseVisualStyleBackColor = false;
            this.btnDich.Click += new System.EventHandler(this.btnDich_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("K2D", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(313, 524);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
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
            this.btnThem.Font = new System.Drawing.Font("K2D", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(313, 461);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 40);
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
            this.txtTiengAnh.Size = new System.Drawing.Size(423, 85);
            this.txtTiengAnh.TabIndex = 3;
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
            this.dgvDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("K2D", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.EnableHeadersVisualStyles = false;
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 97);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(535, 467);
            this.dgvDanhSach.TabIndex = 1;
            this.dgvDanhSach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellDoubleClick);
            this.dgvDanhSach.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellEndEdit);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimKiem.Location = new System.Drawing.Point(12, 15);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(535, 35);
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
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnXoa);
            this.splitContainer1.Panel2.Controls.Add(this.btnLoa);
            this.splitContainer1.Panel2.Controls.Add(this.lblLoaiTu);
            this.splitContainer1.Panel2.Controls.Add(this.btnDich);
            this.splitContainer1.Panel2.Controls.Add(this.txtTiengAnh);
            this.splitContainer1.Panel2.Controls.Add(this.lblTiengAnh);
            this.splitContainer1.Panel2.Controls.Add(this.btnThem);
            this.splitContainer1.Panel2.Controls.Add(this.txtPhienAm);
            this.splitContainer1.Panel2.Controls.Add(this.txtTiengViet);
            this.splitContainer1.Panel2.Controls.Add(this.lblPhienAm);
            this.splitContainer1.Panel2.Controls.Add(this.lblTiengViet);
            this.splitContainer1.Panel2.Controls.Add(this.txtLoaiTu);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel2MinSize = 350;
            this.splitContainer1.Size = new System.Drawing.Size(999, 576);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.TabIndex = 17;
            // 
            // cboLocDaThuoc
            // 
            this.cboLocDaThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocDaThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLocDaThuoc.Font = new System.Drawing.Font("K2D", 8.5F);
            this.cboLocDaThuoc.FormattingEnabled = true;
            this.cboLocDaThuoc.Location = new System.Drawing.Point(434, 60);
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
            this.lblDanhSachTuVung.Location = new System.Drawing.Point(12, 56);
            this.lblDanhSachTuVung.Margin = new System.Windows.Forms.Padding(3);
            this.lblDanhSachTuVung.Name = "lblDanhSachTuVung";
            this.lblDanhSachTuVung.Size = new System.Drawing.Size(160, 35);
            this.lblDanhSachTuVung.TabIndex = 15;
            this.lblDanhSachTuVung.Text = "Danh sách từ vựng";
            this.lblDanhSachTuVung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.Font = new System.Drawing.Font("K2D", 8.5F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 461);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 35);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.Text = "Chọn chủ đề";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(999, 576);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("K2D", 10F);
            this.Name = "Form1";
            this.Text = "VocabMaster";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Label lblTiengAnh;
        private System.Windows.Forms.Label lblTiengViet;
        private System.Windows.Forms.Label lblPhienAm;
        private System.Windows.Forms.TextBox txtTiengAnh;
        private System.Windows.Forms.Button btnDich;
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

