using DeTaiPTUD_PhongTro.Model;
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
    public partial class ThongKeThuePhongTheoThang : Form
    {
        public ThongKeThuePhongTheoThang()
        {
            InitializeComponent();
        }

       

        private void ThongKeThuePhongTheoThang_Load(object sender, EventArgs e)
        {
            DateTime DateNow = DateTime.Now;
            txtYear.Text = DateNow.Year.ToString();
            cboMonth.Text = DateNow.Month.ToString();
            //cboMonth.ValueMember = 1;
            MakeSourceCboType();
            fillChart(DateNow.Year, DateNow.Month, 1);
        }


        private void fillChart(int year, int month, int type)
        {
            SqlConnection con = new SqlConnection("Data Source=HOANGHUU\\SQLEXPRESS;Initial Catalog=PhongTroSV;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = null;
            if (type == 1)
            {
                adapt = new SqlDataAdapter("Exec ThongKeThuePhongTheoThang " + year + "," + month + "," + 1, con);
            }
            if (type == 2)
            {
                adapt = new SqlDataAdapter("Exec ThongKeThuePhongTheoThang " + year + "," + month + "," + 2, con);
            }
            if (type == 3)
            {
                adapt = new SqlDataAdapter("Exec ThongKeThuePhongTheoThang " + year + "," + month + "," + 3, con);
            }
            adapt.Fill(ds);
            chartThongKeDoanhThuThang.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            chartThongKeDoanhThuThang.Series["Số lượng thuê"].XValueMember = "Ngay";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chartThongKeDoanhThuThang.Series["Số lượng thuê"].YValueMembers = "SoLuong";

            chartThongKeDoanhThuThang.Series["Số lượng thuê"].IsValueShownAsLabel = true;

            chartThongKeDoanhThuThang.Titles.Clear();
            if (type == 1)
            {
                chartThongKeDoanhThuThang.Titles.Add("SL sinh viên thuê phòng (chưa trả phòng) tháng " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Số lượng thuê"].Color = Color.LightGreen;
            }
            if (type == 2)
            {
                chartThongKeDoanhThuThang.Titles.Add("SL sinh viên thuê phòng (đã trả phòng) tháng" + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Số lượng thuê"].Color = Color.LightGray;
            }
            if (type == 3)
            {
                chartThongKeDoanhThuThang.Titles.Add("SL sinh viên thuê phòng tháng " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Số lượng thuê"].Color = Color.LightSlateGray;
            }
            
            chartThongKeDoanhThuThang.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            ChartArea CA = chartThongKeDoanhThuThang.ChartAreas[0];
            CA.CursorX.IsUserSelectionEnabled = true;

            CA.AxisX.ScaleView.Zoom(0, 8);
            CA.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;

            con.Close();

        }

        private void MakeSourceCboType()
        {
            List<ItemChartType> items = new List<ItemChartType>()
            {
                new ItemChartType{ Value=1, Name="Chưa trả phòng"},
                new ItemChartType{ Value=2, Name="Đã trả phòng"},
                new ItemChartType{ Value=3, Name="Tất cả"},
            };

            cboType.DataSource = items;
            cboType.DisplayMember = "Name";
            cboType.ValueMember = "Value";
            cboType.SelectedItem = items.FirstOrDefault();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            var year = Int32.Parse(txtYear.Text);
            var month = Int32.Parse(cboMonth.Text);
            var type = Int32.Parse(cboType.SelectedValue.ToString());
            fillChart(year, month, type);
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

        //Export Excel

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
            int type = Int32.Parse(cboType.SelectedValue.ToString());
            string typeName = "";
            string typeNameVi = "";
            if (type == 1)
            {
                typeName = "SLThue-ChuaTraPhong";
                typeNameVi = "SL thuê (chưa trả phòng)";
            }
            if (type == 2)
            {
                typeName = "SLThue-DaTraPhong";
                typeNameVi = "SL thuê (đã trả phòng)";
            }
            if (type == 3)
            {
                typeName = "SLThue";
                typeNameVi = "SL thuê phòng";
            }
            
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

                        int type = Int32.Parse(cboType.SelectedValue.ToString());
                        var year = Int32.Parse(txtYear.Text);
                        var month = Int32.Parse(cboMonth.Text);
                        SqlConnection con = new SqlConnection("Data Source=HOANGHUU\\SQLEXPRESS;Initial Catalog=PhongTroSV;Integrated Security=True");
                        DataSet ds = new DataSet();
                        con.Open();
                        SqlDataAdapter adapt = null;
                        if (type == 1)
                        {
                            adapt = new SqlDataAdapter("Exec ThongKeThuePhongTheoThang_ChiTiet " + xValue + "," + year + "," + month + "," + 1, con);
                        }
                        if (type == 2)
                        {
                            adapt = new SqlDataAdapter("Exec ThongKeThuePhongTheoThang_ChiTiet " + xValue + "," + year + "," + month + "," + 2, con);
                        }
                        if (type == 3)
                        {
                            adapt = new SqlDataAdapter("Exec ThongKeThuePhongTheoThang_ChiTiet " + xValue + "," + year + "," + month + "," + 3, con);
                        }
                        adapt.Fill(ds);
                        var label = "Chi tiết thuê phòng "+ xValue + "/" + month + "/" + year;
                        frmThongKeThueChiTiet frmChiTiet = new frmThongKeThueChiTiet(ds, label);
                        frmChiTiet.Show();
                    }
                }
            }
        }
    }
    
}
