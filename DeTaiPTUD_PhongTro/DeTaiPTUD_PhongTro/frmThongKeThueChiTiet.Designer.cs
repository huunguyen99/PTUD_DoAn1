namespace DeTaiPTUD_PhongTro
{
    partial class frmThongKeThueChiTiet
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeThueChiTiet));
            this.lblTKThueChiTiet = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.lvwDSChiTiet = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTKThueChiTiet
            // 
            this.lblTKThueChiTiet.AutoSize = false;
            this.lblTKThueChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTKThueChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTKThueChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblTKThueChiTiet.Location = new System.Drawing.Point(0, 0);
            this.lblTKThueChiTiet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTKThueChiTiet.Name = "lblTKThueChiTiet";
            this.lblTKThueChiTiet.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.lblTKThueChiTiet.Size = new System.Drawing.Size(1065, 39);
            this.lblTKThueChiTiet.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTKThueChiTiet.Text = "Chi tiết thuê phòng theo ";
            this.lblTKThueChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.lblTKThueChiTiet);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.lvwDSChiTiet);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1065, 450);
            this.kryptonSplitContainer1.SplitterDistance = 44;
            this.kryptonSplitContainer1.TabIndex = 3;
            // 
            // lvwDSChiTiet
            // 
            this.lvwDSChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader1,
            this.columnHeader21,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.lvwDSChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDSChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDSChiTiet.FullRowSelect = true;
            this.lvwDSChiTiet.GridLines = true;
            this.lvwDSChiTiet.HideSelection = false;
            this.lvwDSChiTiet.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwDSChiTiet.Location = new System.Drawing.Point(0, 0);
            this.lvwDSChiTiet.Name = "lvwDSChiTiet";
            this.lvwDSChiTiet.Size = new System.Drawing.Size(1065, 401);
            this.lvwDSChiTiet.TabIndex = 9;
            this.lvwDSChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvwDSChiTiet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tên sinh viên";
            this.columnHeader12.Width = 160;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "CMND Sinh viên";
            this.columnHeader13.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Giới tính";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Tên trường";
            this.columnHeader21.Width = 320;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Mã phòng";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Tên phòng";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Giá thuê";
            this.columnHeader16.Width = 110;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Tên nhân viên";
            this.columnHeader17.Width = 160;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "CMND Nhân viên";
            this.columnHeader18.Width = 120;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Ngày thuê";
            this.columnHeader19.Width = 105;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Ngày trả";
            this.columnHeader20.Width = 105;
            // 
            // frmThongKeThueChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 450);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThongKeThueChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHI TIẾT THUÊ PHÒNG";
            this.Load += new System.EventHandler(this.frmThongKeThueChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblTKThueChiTiet;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private System.Windows.Forms.ListView lvwDSChiTiet;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}