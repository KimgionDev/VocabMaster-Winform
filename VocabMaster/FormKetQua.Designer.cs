namespace VocabMaster
{
    partial class FormKetQua
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
            this.lblDiem = new System.Windows.Forms.Label();
            this.nudSoCauHoi = new System.Windows.Forms.NumericUpDown();
            this.lblSoCauHoi = new System.Windows.Forms.Label();
            this.btnLamLai = new AntdUI.Button();
            this.flpChonSoCau = new AntdUI.In.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new AntdUI.Panel();
            this.panel2 = new AntdUI.Panel();
            this.flpNgonNgu = new AntdUI.In.FlowLayoutPanel();
            this.lblHoiTiengAnh = new System.Windows.Forms.Label();
            this.switchNgonNgu = new AntdUI.Switch();
            this.lblHoiTiengViet = new System.Windows.Forms.Label();
            this.panel1 = new AntdUI.Panel();
            this.object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949 = new AntdUI.Switch();
            this.object_8861273e_73e4_40ae_8691_704b4108b8c6 = new AntdUI.Switch();
            this.object_9b1c4593_eb87_426f_8c59_52d84795159f = new AntdUI.Switch();
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c = new AntdUI.In.FlowLayoutPanel();
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639 = new AntdUI.In.FlowLayoutPanel();
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21 = new AntdUI.In.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCauHoi)).BeginInit();
            this.flpChonSoCau.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flpNgonNgu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDiem
            // 
            this.lblDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiem.Font = new System.Drawing.Font("K2D", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiem.Location = new System.Drawing.Point(0, 0);
            this.lblDiem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(1081, 181);
            this.lblDiem.TabIndex = 0;
            this.lblDiem.Text = "IIIIIIIIIIIIIIIIIIIIIllllIIIIIIIIIIIIIIIIIIII";
            this.lblDiem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudSoCauHoi
            // 
            this.nudSoCauHoi.BackColor = System.Drawing.Color.White;
            this.nudSoCauHoi.Font = new System.Drawing.Font("K2D", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoCauHoi.Location = new System.Drawing.Point(266, 3);
            this.nudSoCauHoi.Name = "nudSoCauHoi";
            this.nudSoCauHoi.Size = new System.Drawing.Size(124, 46);
            this.nudSoCauHoi.TabIndex = 1;
            this.nudSoCauHoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSoCauHoi
            // 
            this.lblSoCauHoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSoCauHoi.Font = new System.Drawing.Font("K2D", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoCauHoi.Location = new System.Drawing.Point(3, 0);
            this.lblSoCauHoi.Name = "lblSoCauHoi";
            this.lblSoCauHoi.Size = new System.Drawing.Size(257, 52);
            this.lblSoCauHoi.TabIndex = 3;
            this.lblSoCauHoi.Text = "Nhập số câu hỏi:";
            this.lblSoCauHoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLamLai
            // 
            this.btnLamLai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLamLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnLamLai.Font = new System.Drawing.Font("K2D SemiBold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamLai.Location = new System.Drawing.Point(335, 21);
            this.btnLamLai.Name = "btnLamLai";
            this.btnLamLai.Radius = 8;
            this.btnLamLai.Size = new System.Drawing.Size(407, 95);
            this.btnLamLai.TabIndex = 4;
            this.btnLamLai.Text = "Làm lại";
            this.btnLamLai.Type = AntdUI.TTypeMini.Primary;
            this.btnLamLai.Click += new System.EventHandler(this.btnLamLai_Click);
            // 
            // flpChonSoCau
            // 
            this.flpChonSoCau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flpChonSoCau.AutoSize = true;
            this.flpChonSoCau.Controls.Add(this.lblSoCauHoi);
            this.flpChonSoCau.Controls.Add(this.nudSoCauHoi);
            this.flpChonSoCau.Location = new System.Drawing.Point(335, 28);
            this.flpChonSoCau.Name = "flpChonSoCau";
            this.flpChonSoCau.Size = new System.Drawing.Size(407, 52);
            this.flpChonSoCau.TabIndex = 5;
            this.flpChonSoCau.WrapContents = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1087, 561);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnLamLai);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 377);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1081, 181);
            this.panel3.TabIndex = 2;
            this.panel3.Text = "panel3";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.flpChonSoCau);
            this.panel2.Controls.Add(this.flpNgonNgu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 181);
            this.panel2.TabIndex = 1;
            this.panel2.Text = "panel2";
            // 
            // flpNgonNgu
            // 
            this.flpNgonNgu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flpNgonNgu.AutoSize = true;
            this.flpNgonNgu.Controls.Add(this.lblHoiTiengAnh);
            this.flpNgonNgu.Controls.Add(this.switchNgonNgu);
            this.flpNgonNgu.Controls.Add(this.lblHoiTiengViet);
            this.flpNgonNgu.Location = new System.Drawing.Point(335, 131);
            this.flpNgonNgu.Name = "flpNgonNgu";
            this.flpNgonNgu.Size = new System.Drawing.Size(407, 48);
            this.flpNgonNgu.TabIndex = 6;
            this.flpNgonNgu.WrapContents = false;
            // 
            // lblHoiTiengAnh
            // 
            this.lblHoiTiengAnh.Font = new System.Drawing.Font("K2D", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoiTiengAnh.Location = new System.Drawing.Point(3, 0);
            this.lblHoiTiengAnh.Name = "lblHoiTiengAnh";
            this.lblHoiTiengAnh.Size = new System.Drawing.Size(150, 45);
            this.lblHoiTiengAnh.TabIndex = 0;
            this.lblHoiTiengAnh.Text = "Hỏi Tiếng Anh";
            this.lblHoiTiengAnh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // switchNgonNgu
            // 
            this.switchNgonNgu.Location = new System.Drawing.Point(159, 0);
            this.switchNgonNgu.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.switchNgonNgu.Name = "switchNgonNgu";
            this.switchNgonNgu.Size = new System.Drawing.Size(88, 42);
            this.switchNgonNgu.TabIndex = 1;
            // 
            // lblHoiTiengViet
            // 
            this.lblHoiTiengViet.Font = new System.Drawing.Font("K2D", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoiTiengViet.Location = new System.Drawing.Point(253, 0);
            this.lblHoiTiengViet.Name = "lblHoiTiengViet";
            this.lblHoiTiengViet.Size = new System.Drawing.Size(150, 45);
            this.lblHoiTiengViet.TabIndex = 2;
            this.lblHoiTiengViet.Text = "Hỏi Tiếng Việt";
            this.lblHoiTiengViet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblDiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 181);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949
            // 
            this.object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949.Location = new System.Drawing.Point(159, 10);
            this.object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949.Name = "object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949";
            this.object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949.Size = new System.Drawing.Size(60, 35);
            this.object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949.TabIndex = 1;
            // 
            // object_8861273e_73e4_40ae_8691_704b4108b8c6
            // 
            this.object_8861273e_73e4_40ae_8691_704b4108b8c6.Location = new System.Drawing.Point(159, 10);
            this.object_8861273e_73e4_40ae_8691_704b4108b8c6.Name = "object_8861273e_73e4_40ae_8691_704b4108b8c6";
            this.object_8861273e_73e4_40ae_8691_704b4108b8c6.Size = new System.Drawing.Size(60, 35);
            this.object_8861273e_73e4_40ae_8691_704b4108b8c6.TabIndex = 1;
            // 
            // object_9b1c4593_eb87_426f_8c59_52d84795159f
            // 
            this.object_9b1c4593_eb87_426f_8c59_52d84795159f.Location = new System.Drawing.Point(159, 10);
            this.object_9b1c4593_eb87_426f_8c59_52d84795159f.Name = "object_9b1c4593_eb87_426f_8c59_52d84795159f";
            this.object_9b1c4593_eb87_426f_8c59_52d84795159f.Size = new System.Drawing.Size(60, 35);
            this.object_9b1c4593_eb87_426f_8c59_52d84795159f.TabIndex = 1;
            // 
            // object_4bd94a5d_1c7e_437b_a738_9c5e821c611c
            // 
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c.AutoSize = true;
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c.Location = new System.Drawing.Point(335, 73);
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c.Name = "object_4bd94a5d_1c7e_437b_a738_9c5e821c611c";
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c.Size = new System.Drawing.Size(407, 52);
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c.TabIndex = 5;
            this.object_4bd94a5d_1c7e_437b_a738_9c5e821c611c.WrapContents = false;
            // 
            // object_20ca7303_67ed_4ad7_a5e5_9be3f335a639
            // 
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639.AutoSize = true;
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639.Location = new System.Drawing.Point(335, 73);
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639.Name = "object_20ca7303_67ed_4ad7_a5e5_9be3f335a639";
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639.Size = new System.Drawing.Size(407, 52);
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639.TabIndex = 5;
            this.object_20ca7303_67ed_4ad7_a5e5_9be3f335a639.WrapContents = false;
            // 
            // object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21
            // 
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21.AutoSize = true;
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21.Location = new System.Drawing.Point(335, 73);
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21.Name = "object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21";
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21.Size = new System.Drawing.Size(407, 52);
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21.TabIndex = 5;
            this.object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21.WrapContents = false;
            // 
            // FormKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 44F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "FormKetQua";
            this.Text = "FormKetQua";
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCauHoi)).EndInit();
            this.flpChonSoCau.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flpNgonNgu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.NumericUpDown nudSoCauHoi;
        private System.Windows.Forms.Label lblSoCauHoi;
        private AntdUI.Button btnLamLai;
        private AntdUI.In.FlowLayoutPanel flpChonSoCau;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AntdUI.Panel panel3;
        private AntdUI.Panel panel2;
        private AntdUI.Panel panel1;
        private AntdUI.In.FlowLayoutPanel flpNgonNgu;
        private System.Windows.Forms.Label lblHoiTiengAnh;
        private AntdUI.Switch switchNgonNgu;
        private System.Windows.Forms.Label lblHoiTiengViet;
        private AntdUI.Switch object_ed7d36ae_0ae6_4c1e_a883_12c4eb3f2949;
        private AntdUI.Switch object_8861273e_73e4_40ae_8691_704b4108b8c6;
        private AntdUI.Switch object_9b1c4593_eb87_426f_8c59_52d84795159f;
        private AntdUI.In.FlowLayoutPanel object_4bd94a5d_1c7e_437b_a738_9c5e821c611c;
        private AntdUI.In.FlowLayoutPanel object_20ca7303_67ed_4ad7_a5e5_9be3f335a639;
        private AntdUI.In.FlowLayoutPanel object_c0766a8e_4762_4f1c_a9af_297ca6ab7e21;
    }
}