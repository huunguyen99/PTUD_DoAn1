using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace DeTaiPTUD_PhongTro
{
    public partial class frmThongKeTraPhongTheoThang : Form
    {
        public frmThongKeTraPhongTheoThang()
        {
            InitializeComponent();
        }

        private void frmThongKeTraPhongTheoThang_Load(object sender, EventArgs e)
        {
            DateTime DateNow = DateTime.Now;
            txtYear.Text = DateNow.Year.ToString();
            cboMonth.Text = DateNow.Month.ToString();
            fillChart(DateNow.Year, DateNow.Month);
        }
        private void fillChart(int year, int month)
        {
            SqlConnection con = new SqlConnection("Data Source=HOANGHUU\\SQLEXPRESS;Initial Catalog=PhongTroSV;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = null;

            adapt = new SqlDataAdapter("Exec ThongKeTraPhongTheoThang " + year + "," + month, con);

            adapt.Fill(ds);
            chartThongKeDoanhThuThang.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            chartThongKeDoanhThuThang.Series["Số lượng trả"].XValueMember = "Ngay";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chartThongKeDoanhThuThang.Series["Số lượng trả"].YValueMembers = "SoLuong";

            chartThongKeDoanhThuThang.Series["Số lượng trả"].IsValueShownAsLabel = true;

            chartThongKeDoanhThuThang.Titles.Clear();

            chartThongKeDoanhThuThang.Titles.Add("SL sinh viên trả phòng tháng " + month + " năm " + year);
            chartThongKeDoanhThuThang.Series["Số lượng trả"].Color = Color.LightGreen;

            chartThongKeDoanhThuThang.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            ChartArea CA = chartThongKeDoanhThuThang.ChartAreas[0];
            CA.CursorX.IsUserSelectionEnabled = true;

            CA.AxisX.ScaleView.Zoom(0, 8);
            CA.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;

            con.Close();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var year = Int32.Parse(txtYear.Text);
            var month = Int32.Parse(cboMonth.Text);
            fillChart(year, month);
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string typeName = "";
            string typeNameVi = "";

            typeName = "SLTraPhong";
            typeNameVi = "SL trả phòng";

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            for (int i = 0; i < chartThongKeDoanhThuThang.Series.Count; i++)
            {
                //xlWorkSheet.Cells[1, 1] = "";
                xlWorkSheet.Cells[1, 1] = "Ngày";//put your column heading here
                xlWorkSheet.Cells[1, 2] = typeNameVi;// put your column heading here

                for (int j = 0; j < chartThongKeDoanhThuThang.Series[i].Points.Count; j++)
                {
                    xlWorkSheet.Cells[j + 2, 1] = chartThongKeDoanhThuThang.Series[i].Points[j].XValue;
                    xlWorkSheet.Cells[j + 2, 2] = chartThongKeDoanhThuThang.Series[i].Points[j].YValues[0];
                }
            }

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(300, 40, 1500, 400);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("B1", "B32");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            var year = Int32.Parse(txtYear.Text);
            var month = Int32.Parse(cboMonth.Text);

            DateTime now = DateTime.Now;
            string fileNameTail = "Thang_" + month + "_Nam_" + year + "_" + typeName + "_" + now.ToString("yyyyMMddHHmmss");

            xlWorkBook.SaveAs(@"E:\Phat Trien Ung Dung\ThongKe\" + fileNameTail + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Xuất thành công");
        }

        private void chartThongKeDoanhThuThang_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            HitTestResult hitResult = this.chartThongKeDoanhThuThang.HitTest(me.X, me.Y);
            if (hitResult != null)
            {
                dynamic point = (object)hitResult.Object;

                if (hitResult.Series != null && point.YValues[0] != 0)
                {
                    if (hitResult.Series.Points != null) // null pointer exception here
                    {
                        //XYValue xYValue = (XYValue)hitResult.Object;
                        var xValue = hitResult.PointIndex + 1;

                        var year = Int32.Parse(txtYear.Text);
                        var month = Int32.Parse(cboMonth.Text);
                        SqlConnection con = new SqlConnection("Data Source=HOANGHUU\\SQLEXPRESS;Initial Catalog=PhongTroSV;Integrated Security=True");
                        DataSet ds = new DataSet();
                        con.Open();
                        SqlDataAdapter adapt = null;

                        adapt = new SqlDataAdapter("Exec ThongKeTraPhongTheoThang_ChiTiet " + xValue + "," + year + "," + month, con);

                        adapt.Fill(ds);
                        var label = "Chi tiết trả phòng " + xValue + "/" + month + "/" + year;
                        frmThongKeThueChiTiet frmChiTiet = new frmThongKeThueChiTiet(ds, label);
                        frmChiTiet.Show();
                    }
                }
            }
        }
    }
}
