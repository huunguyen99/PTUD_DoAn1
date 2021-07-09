namespace DeTaiPTUD_PhongTro
{
    partial class frmDangKiThueMoi
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            ""}, -1);
            this.btnThoat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDangKiThue = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.lvwDSPhongTro = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwDSPhong = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txtSoNguoiHienTai = new System.Windows.Forms.TextBox();
            this.txtSoNguoiToiDa = new System.Windows.Forms.TextBox();
            this.txtGiaThue = new System.Windows.Forms.TextBox();
            this.txtTangLau = new System.Windows.Forms.TextBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tanglau = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(446, 133);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(106, 36);
            this.btnThoat.TabIndex = 20;
            this.btnThoat.Values.Text = "THOÁT";
            this.btnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // btnDangKiThue
            // 
            this.btnDangKiThue.Enabled = false;
            this.btnDangKiThue.Location = new System.Drawing.Point(256, 133);
            this.btnDangKiThue.Margin = new System.Windows.Forms.Padding(5);
            this.btnDangKiThue.Name = "btnDangKiThue";
            this.btnDangKiThue.Size = new System.Drawing.Size(106, 36);
            this.btnDangKiThue.TabIndex = 19;
            this.btnDangKiThue.Values.Text = "ĐĂNG KÝ THUÊ";
            this.btnDangKiThue.Click += new System.EventHandler(this.BtnDangKiThue_Click);
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.AutoSize = false;
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonWrapLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(769, 43);
            this.kryptonWrapLabel1.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.kryptonWrapLabel1.Text = "DANH SÁCH PHÒNG TRỌ";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwDSPhongTro
            // 
            this.lvwDSPhongTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDSPhongTro.HideSelection = false;
            this.lvwDSPhongTro.Location = new System.Drawing.Point(0, 0);
            this.lvwDSPhongTro.Margin = new System.Windows.Forms.Padding(4);
            this.lvwDSPhongTro.Name = "lvwDSPhongTro";
            this.lvwDSPhongTro.Size = new System.Drawing.Size(769, 227);
            this.lvwDSPhongTro.TabIndex = 0;
            this.lvwDSPhongTro.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số Người Hiện Tại";
            this.columnHeader5.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số người tối đa";
            this.columnHeader4.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá thuê";
            this.columnHeader3.Width = 113;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tầng lầu";
            this.columnHeader2.Width = 127;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã phòng";
            this.columnHeader1.Width = 86;
            // 
            // lvwDSPhong
            // 
            this.lvwDSPhong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwDSPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDSPhong.FullRowSelect = true;
            this.lvwDSPhong.GridLines = true;
            this.lvwDSPhong.HideSelection = false;
            this.lvwDSPhong.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.lvwDSPhong.Location = new System.Drawing.Point(0, 43);
            this.lvwDSPhong.Margin = new System.Windows.Forms.Padding(4);
            this.lvwDSPhong.Name = "lvwDSPhong";
            this.lvwDSPhong.Size = new System.Drawing.Size(769, 184);
            this.lvwDSPhong.TabIndex = 3;
            this.lvwDSPhong.UseCompatibleStateImageBehavior = false;
            this.lvwDSPhong.View = System.Windows.Forms.View.Details;
            this.lvwDSPhong.SelectedIndexChanged += new System.EventHandler(this.LvwDSPhong_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tên Phòng";
            this.columnHeader6.Width = 140;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvwDSPhong);
            this.splitContainer2.Panel1.Controls.Add(this.kryptonWrapLabel1);
            this.splitContainer2.Panel1.Controls.Add(this.lvwDSPhongTro);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.kryptonGroupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(769, 448);
            this.splitContainer2.SplitterDistance = 227;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 3;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtSoNguoiHienTai);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtSoNguoiToiDa);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtGiaThue);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtTangLau);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtTenPhong);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtMaPhong);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.tanglau);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnThoat);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnDangKiThue);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(769, 216);
            this.kryptonGroupBox1.TabIndex = 1;
            this.kryptonGroupBox1.Values.Heading = "THÔNG TIN CHI TIẾT";
            // 
            // txtSoNguoiHienTai
            // 
            this.txtSoNguoiHienTai.Location = new System.Drawing.Point(517, 91);
            this.txtSoNguoiHienTai.Name = "txtSoNguoiHienTai";
            this.txtSoNguoiHienTai.ReadOnly = true;
            this.txtSoNguoiHienTai.Size = new System.Drawing.Size(163, 22);
            this.txtSoNguoiHienTai.TabIndex = 47;
            // 
            // txtSoNguoiToiDa
            // 
            this.txtSoNguoiToiDa.Location = new System.Drawing.Point(517, 57);
            this.txtSoNguoiToiDa.Name = "txtSoNguoiToiDa";
            this.txtSoNguoiToiDa.ReadOnly = true;
            this.txtSoNguoiToiDa.Size = new System.Drawing.Size(163, 22);
            this.txtSoNguoiToiDa.TabIndex = 48;
            // 
            // txtGiaThue
            // 
            this.txtGiaThue.Location = new System.Drawing.Point(517, 23);
            this.txtGiaThue.Name = "txtGiaThue";
            this.txtGiaThue.ReadOnly = true;
            this.txtGiaThue.Size = new System.Drawing.Size(163, 22);
            this.txtGiaThue.TabIndex = 46;
            // 
            // txtTangLau
            // 
            this.txtTangLau.Location = new System.Drawing.Point(166, 90);
            this.txtTangLau.Name = "txtTangLau";
            this.txtTangLau.ReadOnly = true;
            this.txtTangLau.Size = new System.Drawing.Size(163, 22);
            this.txtTangLau.TabIndex = 44;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(166, 56);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.ReadOnly = true;
            this.txtTenPhong.Size = new System.Drawing.Size(163, 22);
            this.txtTenPhong.TabIndex = 45;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(166, 22);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.ReadOnly = true;
            this.txtMaPhong.Size = new System.Drawing.Size(163, 22);
            this.txtMaPhong.TabIndex = 43;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(396, 92);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(110, 20);
            this.kryptonLabel2.TabIndex = 37;
            this.kryptonLabel2.Values.Text = "Số Người Hiện Tại";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(396, 57);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(100, 20);
            this.kryptonLabel4.TabIndex = 38;
            this.kryptonLabel4.Values.Text = "Số Người Tối Đa";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(396, 22);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel3.TabIndex = 39;
            this.kryptonLabel3.Values.Text = "Giá Thuê";
            // 
            // tanglau
            // 
            this.tanglau.Location = new System.Drawing.Point(69, 92);
            this.tanglau.Margin = new System.Windows.Forms.Padding(5);
            this.tanglau.Name = "tanglau";
            this.tanglau.Size = new System.Drawing.Size(60, 20);
            this.tanglau.TabIndex = 40;
            this.tanglau.Values.Text = "Tầng Lầu";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(70, 57);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel5.TabIndex = 41;
            this.kryptonLabel5.Values.Text = "Tên Phòng";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(70, 22);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel1.TabIndex = 42;
            this.kryptonLabel1.Values.Text = "Mã Phòng";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(769, 448);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // frmDangKiThueMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(769, 448);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDangKiThueMoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ĐĂNG KÝ THUÊ MỚI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDangKiThueMoi_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThoat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDangKiThue;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private System.Windows.Forms.ListView lvwDSPhongTro;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvwDSPhong;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel tanglau;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TextBox txtSoNguoiHienTai;
        private System.Windows.Forms.TextBox txtSoNguoiToiDa;
        private System.Windows.Forms.TextBox txtGiaThue;
        private System.Windows.Forms.TextBox txtTangLau;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
    }
}