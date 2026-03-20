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
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCauHoi)).BeginInit();
            this.flpChonSoCau.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDiem
            // 
            this.lblDiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiem.Font = new System.Drawing.Font("K2D", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiem.Location = new System.Drawing.Point(0, 0);
            this.lblDiem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(1087, 221);
            this.lblDiem.TabIndex = 0;
            this.lblDiem.Text = "IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII";
            this.lblDiem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nudSoCauHoi
            // 
            this.nudSoCauHoi.Font = new System.Drawing.Font("K2D", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoCauHoi.Location = new System.Drawing.Point(256, 3);
            this.nudSoCauHoi.Name = "nudSoCauHoi";
            this.nudSoCauHoi.Size = new System.Drawing.Size(120, 46);
            this.nudSoCauHoi.TabIndex = 1;
            this.nudSoCauHoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSoCauHoi
            // 
            this.lblSoCauHoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSoCauHoi.Font = new System.Drawing.Font("K2D", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoCauHoi.Location = new System.Drawing.Point(3, 0);
            this.lblSoCauHoi.Name = "lblSoCauHoi";
            this.lblSoCauHoi.Size = new System.Drawing.Size(247, 52);
            this.lblSoCauHoi.TabIndex = 3;
            this.lblSoCauHoi.Text = "Nhập số câu hỏi:";
            this.lblSoCauHoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLamLai
            // 
            this.btnLamLai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLamLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnLamLai.Font = new System.Drawing.Font("K2D SemiBold", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamLai.Location = new System.Drawing.Point(406, 469);
            this.btnLamLai.Name = "btnLamLai";
            this.btnLamLai.Radius = 8;
            this.btnLamLai.Size = new System.Drawing.Size(300, 80);
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
            this.flpChonSoCau.Location = new System.Drawing.Point(351, 224);
            this.flpChonSoCau.Name = "flpChonSoCau";
            this.flpChonSoCau.Size = new System.Drawing.Size(379, 52);
            this.flpChonSoCau.TabIndex = 5;
            this.flpChonSoCau.WrapContents = false;
            // 
            // FormKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 44F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 561);
            this.Controls.Add(this.flpChonSoCau);
            this.Controls.Add(this.btnLamLai);
            this.Controls.Add(this.lblDiem);
            this.Font = new System.Drawing.Font("K2D", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "FormKetQua";
            this.Text = "FormKetQua";
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCauHoi)).EndInit();
            this.flpChonSoCau.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.NumericUpDown nudSoCauHoi;
        private System.Windows.Forms.Label lblSoCauHoi;
        private AntdUI.Button btnLamLai;
        private AntdUI.In.FlowLayoutPanel flpChonSoCau;
    }
}