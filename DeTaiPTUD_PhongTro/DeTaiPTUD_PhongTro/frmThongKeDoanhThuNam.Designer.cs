namespace DeTaiPTUD_PhongTro
{
    partial class frmThongKeDoanhThuNam
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnFind = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtYear = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.chartThongKeDoanhThuThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeDoanhThuThang)).BeginInit();
            this.SuspendLayout();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnExport);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonLabel4);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.cboType);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.btnFind);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonLabel3);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonLabel2);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.txtYear);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.chartThongKeDoanhThuThang);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(1028, 502);
            this.kryptonSplitContainer1.SplitterDistance = 108;
            this.kryptonSplitContainer1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(676, 66);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 25);
            this.btnExport.TabIndex = 7;
            this.btnExport.Values.Text = "Xuất file";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(233, 71);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Loại thống kê";
            // 
            // cboType
            // 
            this.cboType.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboType.DropDownWidth = 121;
            this.cboType.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cboType.Location = new System.Drawing.Point(329, 70);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(91, 21);
            this.cboType.TabIndex = 5;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(505, 66);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(71, 25);
            this.btnFind.TabIndex = 4;
            this.btnFind.Values.Text = "Tìm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(22, 71);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Năm";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 71);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Năm";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(66, 71);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 1;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // chartThongKeDoanhThuThang
            // 
            chartArea5.Name = "ChartArea1";
            this.chartThongKeDoanhThuThang.ChartAreas.Add(chartArea5);
            this.chartThongKeDoanhThuThang.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chartThongKeDoanhThuThang.Legends.Add(legend5);
            this.chartThongKeDoanhThuThang.Location = new System.Drawing.Point(0, 0);
            this.chartThongKeDoanhThuThang.Name = "chartThongKeDoanhThuThang";
            series5.ChartArea = "ChartArea1";
            series5.IsXValueIndexed = true;
            series5.Legend = "Legend1";
            series5.Name = "Doanh thu";
            this.chartThongKeDoanhThuThang.Series.Add(series5);
            this.chartThongKeDoanhThuThang.Size = new System.Drawing.Size(1028, 389);
            this.chartThongKeDoanhThuThang.TabIndex = 1;
            this.chartThongKeDoanhThuThang.Text = "chart1";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.AutoSize = false;
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonWrapLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(1028, 39);
            this.kryptonWrapLabel1.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.kryptonWrapLabel1.Text = "Thống kê doanh thu năm";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmThongKeDoanhThuNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 502);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "frmThongKeDoanhThuNam";
            this.Text = "THỐNG KÊ DOANH THU NĂM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKeDoanhThuNam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeDoanhThuThang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboType;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFind;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKeDoanhThuThang;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
    }
}