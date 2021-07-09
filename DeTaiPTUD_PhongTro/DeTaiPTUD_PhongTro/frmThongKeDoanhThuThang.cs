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
    public partial class frmThongKeDoanhThuThang : Form
    {
        public frmThongKeDoanhThuThang()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThuThang_Load(object sender, EventArgs e)
        {
            DateTime DateNow = DateTime.Now;
            txtYear.Text = DateNow.Year.ToString();
            cboMonth.Text = DateNow.Month.ToString();
            //cboMonth.ValueMember = 1;
            MakeSourceCboType();
            fillChart(DateNow.Year, DateNow.Month,1);
        }

        private void MakeSourceCboType()
        {
            List<ItemChartType> items = new List<ItemChartType>()
            {
                new ItemChartType{ Value=1, Name="Tổng doanh thu"},
                new ItemChartType{ Value=2, Name="Phụ phí"},
                new ItemChartType{ Value=3, Name="Tiền điện"},
                new ItemChartType{ Value=4, Name="Tiền gửi xe"},
                new ItemChartType{ Value=5, Name="Tiền nước"},
                new ItemChartType{ Value=6, Name="Tiền phòng"},
                new ItemChartType{ Value=7, Name="Tiền Wifi"}
            };

            cboType.DataSource = items;
            cboType.DisplayMember = "Name";
            cboType.ValueMember = "Value";
            cboType.SelectedItem = items.FirstOrDefault();
        }
        private void fillChart(int year, int month, int type)
        {
            SqlConnection con = new SqlConnection("Data Source=HOANGHUU\\SQLEXPRESS;Initial Catalog=PhongTroSV;Integrated Security=True");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = null;
            if (type == 1)
            {
                adapt = new SqlDataAdapter("Exec LayTongDoanhThuThang " + year + "," + month, con);
            }
            if (type == 2)
            {
                adapt = new SqlDataAdapter("Exec LayTongDoanhThuThang_PhuPhi " + year + "," + month, con);
            }
            if (type == 3)
            {
                adapt = new SqlDataAdapter("Exec LayTongDoanhThuThang_TienDien " + year + "," + month, con);
            }
            if (type == 4)
            {
                adapt = new SqlDataAdapter("Exec LayTongDoanhThuThang_TienGuiXe " + year + "," + month, con);
            }
            if (type == 5)
            {
                adapt = new SqlDataAdapter("Exec LayTongDoanhThuThang_TienNuoc " + year + "," + month, con);
            }
            if (type == 6)
            {
                adapt = new SqlDataAdapter("Exec LayTongDoanhThuThang_TienPhong " + year + "," + month, con);
            }
            if (type == 7)
            {
                adapt = new SqlDataAdapter("Exec LayTongDoanhThuThang_TienWiFi " + year + "," + month, con);
            }
            adapt.Fill(ds);
            chartThongKeDoanhThuThang.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            chartThongKeDoanhThuThang.Series["Doanh thu"].XValueMember = "Ngay";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chartThongKeDoanhThuThang.Series["Doanh thu"].YValueMembers = "value";

            chartThongKeDoanhThuThang.Series["Doanh thu"].IsValueShownAsLabel = true;

            chartThongKeDoanhThuThang.Titles.Clear();
            if (type == 1)
            {
                chartThongKeDoanhThuThang.Titles.Add("Thống kê tổng doanh thu tháng " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Doanh thu"].Color = Color.LightGreen;
            }
            if (type == 2)
            {
                chartThongKeDoanhThuThang.Titles.Add("Thống kê doanh thu tháng (phụ phí) " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Doanh thu"].Color = Color.LightGray;
            }
            if (type == 3)
            {
                chartThongKeDoanhThuThang.Titles.Add("Thống kê doanh thu tháng (tiền điện) " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Doanh thu"].Color = Color.LightSlateGray;
            }
            if (type == 4)
            {
                chartThongKeDoanhThuThang.Titles.Add("Thống kê doanh thu tháng (tiền gửi xe) " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Doanh thu"].Color = Color.LightSteelBlue;
            }
            if (type == 5)
            {
                chartThongKeDoanhThuThang.Titles.Add("Thống kê doanh thu tháng (tiền nước) " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Doanh thu"].Color = Color.LightBlue;
            }
            if (type == 6)
            {
                chartThongKeDoanhThuThang.Titles.Add("Thống kê doanh thu tháng (tiền phòng) " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Doanh thu"].Color = Color.YellowGreen;
            }
            if (type == 7)
            {
                chartThongKeDoanhThuThang.Titles.Add("Thống kê doanh thu tháng (tiền Wifi) " + month + " năm " + year);
                chartThongKeDoanhThuThang.Series["Doanh thu"].Color = Color.Yellow;
            }
            chartThongKeDoanhThuThang.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            ChartArea CA = chartThongKeDoanhThuThang.ChartAreas[0];
            CA.CursorX.IsUserSelectionEnabled = true;

            CA.AxisX.ScaleView.Zoom(0, 8);
            CA.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;

            con.Close();

        }


        private void kryptonTextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            var year = Int32.Parse(txtYear.Text);
            var month = Int32.Parse(cboMonth.Text);
            var type = Int32.Parse(cboType.SelectedValue.ToString());
            fillChart(year,month, type);
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
                typeName = "TongDoanhThu";
                typeNameVi = "Tổng doanh thu";
            }
            if (type == 2)
            {
                typeName = "PhuPhi";
                typeNameVi = "Doanh thu (Phụ phí)";
            }
            if (type == 3)
            {
                typeName = "TienDien";
                typeNameVi = "Doanh thu (Tiền điện)";
            }
            if (type == 4)
            {
                typeName = "TienGuiXe";
                typeNameVi = "Doanh thu (Tiền gửi xe)";
            }
            if (type == 5)
            {
                typeName = "TienNuoc";
                typeNameVi = "Doanh thu (Tiền nước)";
            }
            if (type == 6)
            {
                typeName = "TienPhong";
                typeNameVi = "Doanh thu (Tiền phòng)";
            }
            if (type == 7)
            {
                typeName = "TienWiFi";
                typeNameVi = "Doanh thu (Tiền Wifi)";
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

    }
}
