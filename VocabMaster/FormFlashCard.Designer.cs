namespace VocabMaster
{
    partial class FormFlashCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFlashcard = new AntdUI.Panel();
            this.lblNoiDungPhu = new AntdUI.Label();
            this.btnPhatAm = new AntdUI.Button();
            this.lblNoiDungChinh = new AntdUI.Label();
            this.panel2 = new AntdUI.Panel();
            this.btnTiepTheo = new AntdUI.ButtonShadow();
            this.btnQuayLai = new AntdUI.ButtonShadow();
            this.prgTienDo = new AntdUI.Progress();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlFlashcard.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlFlashcard, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1111, 534);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlFlashcard
            // 
            this.pnlFlashcard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlFlashcard.Back = System.Drawing.Color.White;
            this.pnlFlashcard.Controls.Add(this.lblNoiDungPhu);
            this.pnlFlashcard.Controls.Add(this.btnPhatAm);
            this.pnlFlashcard.Controls.Add(this.lblNoiDungChinh);
            this.pnlFlashcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlFlashcard.Location = new System.Drawing.Point(405, 67);
            this.pnlFlashcard.Name = "pnlFlashcard";
            this.pnlFlashcard.Radius = 15;
            this.pnlFlashcard.Shadow = 10;
            this.pnlFlashcard.ShadowColor = System.Drawing.Color.Black;
            this.pnlFlashcard.ShadowOffsetX = 3;
            this.pnlFlashcard.ShadowOffsetY = 3;
            this.pnlFlashcard.ShadowOpacity = 0.4F;
            this.pnlFlashcard.Size = new System.Drawing.Size(300, 400);
            this.pnlFlashcard.TabIndex = 0;
            this.pnlFlashcard.Text = "panel1";
            this.pnlFlashcard.Click += new System.EventHandler(this.pnlFlashcard_Click);
            // 
            // lblNoiDungPhu
            // 
            this.lblNoiDungPhu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoiDungPhu.BackColor = System.Drawing.Color.White;
            this.lblNoiDungPhu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNoiDungPhu.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoiDungPhu.Location = new System.Drawing.Point(15, 181);
            this.lblNoiDungPhu.Name = "lblNoiDungPhu";
            this.lblNoiDungPhu.Size = new System.Drawing.Size(270, 25);
            this.lblNoiDungPhu.TabIndex = 3;
            this.lblNoiDungPhu.Text = "hello";
            this.lblNoiDungPhu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoiDungPhu.Click += new System.EventHandler(this.pnlFlashcard_Click);
            // 
            // btnPhatAm
            // 
            this.btnPhatAm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPhatAm.BackActive = System.Drawing.Color.Transparent;
            this.btnPhatAm.BackColor = System.Drawing.Color.Transparent;
            this.btnPhatAm.BackHover = System.Drawing.Color.Transparent;
            this.btnPhatAm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhatAm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(239)))));
            this.btnPhatAm.ForeHover = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(169)))));
            this.btnPhatAm.Location = new System.Drawing.Point(15, 212);
            this.btnPhatAm.Name = "btnPhatAm";
            this.btnPhatAm.Size = new System.Drawing.Size(270, 30);
            this.btnPhatAm.TabIndex = 2;
            this.btnPhatAm.Text = "🔊";
            this.btnPhatAm.Type = AntdUI.TTypeMini.Primary;
            this.btnPhatAm.Click += new System.EventHandler(this.btnPhatAm_Click);
            // 
            // lblNoiDungChinh
            // 
            this.lblNoiDungChinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoiDungChinh.BackColor = System.Drawing.Color.White;
            this.lblNoiDungChinh.Font = new System.Drawing.Font("K2D", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDungChinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(169)))));
            this.lblNoiDungChinh.Location = new System.Drawing.Point(15, 125);
            this.lblNoiDungChinh.Name = "lblNoiDungChinh";
            this.lblNoiDungChinh.Size = new System.Drawing.Size(270, 50);
            this.lblNoiDungChinh.TabIndex = 0;
            this.lblNoiDungChinh.Text = "Hello";
            this.lblNoiDungChinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoiDungChinh.Click += new System.EventHandler(this.pnlFlashcard_Click);
            // 
            // panel2
            // 
            this.panel2.Back = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnTiepTheo);
            this.panel2.Controls.Add(this.btnQuayLai);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 473);
            this.panel2.Name = "panel2";
            this.panel2.Radius = 0;
            this.panel2.ShadowOpacity = 0F;
            this.panel2.Size = new System.Drawing.Size(1105, 58);
            this.panel2.TabIndex = 1;
            this.panel2.Text = "panel2";
            // 
            // btnTiepTheo
            // 
            this.btnTiepTheo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTiepTheo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(169)))));
            this.btnTiepTheo.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(239)))));
            this.btnTiepTheo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTiepTheo.ForeColor = System.Drawing.Color.White;
            this.btnTiepTheo.Location = new System.Drawing.Point(886, -2);
            this.btnTiepTheo.Name = "btnTiepTheo";
            this.btnTiepTheo.Radius = 20;
            this.btnTiepTheo.Shadow = 5;
            this.btnTiepTheo.ShadowOffsetY = 3;
            this.btnTiepTheo.ShadowOpacity = 0.3F;
            this.btnTiepTheo.Size = new System.Drawing.Size(210, 60);
            this.btnTiepTheo.TabIndex = 2;
            this.btnTiepTheo.Text = "Tiếp theo >>";
            this.btnTiepTheo.Type = AntdUI.TTypeMini.Primary;
            this.btnTiepTheo.WaveSize = 5;
            this.btnTiepTheo.Click += new System.EventHandler(this.btnTiepTheo_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(169)))));
            this.btnQuayLai.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(239)))));
            this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(9, -2);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Radius = 20;
            this.btnQuayLai.Shadow = 5;
            this.btnQuayLai.ShadowOffsetY = 3;
            this.btnQuayLai.ShadowOpacity = 0.3F;
            this.btnQuayLai.Size = new System.Drawing.Size(210, 60);
            this.btnQuayLai.TabIndex = 1;
            this.btnQuayLai.Text = "<< Quay lại";
            this.btnQuayLai.Type = AntdUI.TTypeMini.Primary;
            this.btnQuayLai.WaveSize = 5;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // prgTienDo
            // 
            this.prgTienDo.Dock = System.Windows.Forms.DockStyle.Top;
            this.prgTienDo.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(92)))), ((int)(((byte)(169)))));
            this.prgTienDo.Location = new System.Drawing.Point(0, 0);
            this.prgTienDo.Margin = new System.Windows.Forms.Padding(0);
            this.prgTienDo.Name = "prgTienDo";
            this.prgTienDo.Padding = new System.Windows.Forms.Padding(50);
            this.prgTienDo.Radius = 5;
            this.prgTienDo.Size = new System.Drawing.Size(1111, 44);
            this.prgTienDo.TabIndex = 0;
            this.prgTienDo.Text = "";
            // 
            // FormFlashCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1111, 578);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.prgTienDo);
            this.Font = new System.Drawing.Font("K2D", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "FormFlashCard";
            this.Text = "FormFlashCard";
            this.Load += new System.EventHandler(this.FormFlashCard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlFlashcard.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AntdUI.Panel pnlFlashcard;
        private AntdUI.Panel panel2;
        private AntdUI.ButtonShadow btnQuayLai;
        private AntdUI.ButtonShadow btnTiepTheo;
        private AntdUI.Progress prgTienDo;
        private AntdUI.Button btnPhatAm;
        private AntdUI.Label lblNoiDungChinh;
        private AntdUI.Label lblNoiDungPhu;
    }
}