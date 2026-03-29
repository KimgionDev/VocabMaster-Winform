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
            this.panel1 = new AntdUI.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCauHoi)).BeginInit();
            this.flpChonSoCau.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.flpChonSoCau.Location = new System.Drawing.Point(335, 73);
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 181);
            this.panel2.TabIndex = 1;
            this.panel2.Text = "panel2";
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
    }
}