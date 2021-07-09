using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DeTaiPTUD_PhongTro
{
    public class clsQLHoaDon:clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsQLHoaDon()
        {
            dt = LayDuLieu();
        }

        

        public void TaoHoaDon(tblHoaDon hd)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblHoaDons.InsertOnSubmit(hd);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }


        public IEnumerable<LayDanhSachHoaDonResult> LayDSHoaDon(string strMaPhong)
        {
            IEnumerable<LayDanhSachHoaDonResult> dshd =  dt.LayDanhSachHoaDon(strMaPhong).OrderByDescending(x=>x.ngayLap);
            return dshd;
        }

        public void SuaHoaDon(string strMaHD, tblCT_HoaDon ctHDSua,string ghiChu)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                tblHoaDon h = (from n in dt.tblHoaDons
                                   where n.maHD.Equals(strMaHD)
                                   select n).FirstOrDefault();
                if (h != null)
                {
                    h.ghiChu = ghiChu;
                    tblCT_HoaDon cthd = (from n in dt.tblCT_HoaDons
                                         where n.maHD.Equals(h.maHD)
                                         select n).FirstOrDefault();
                    if (cthd != null)
                    {
                        cthd.tienDien = ctHDSua.tienDien;
                        cthd.tienNuoc = ctHDSua.tienNuoc;
                        cthd.tienWifi = ctHDSua.tienWifi;
                        cthd.tienGuiXe = ctHDSua.tienGuiXe;
                        cthd.phuPhi = ctHDSua.phuPhi;
                    }
                }
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch(Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không xác định " + ex.Message);
            }
        }


        public void ThanhToan(string strMaHD,string ghiChu)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                tblHoaDon h = (from n in dt.tblHoaDons
                               where n.maHD.Equals(strMaHD)
                               select n).FirstOrDefault();
                if (h != null)
                {
                    h.tinhTrangHD = true;
                    h.ngayTra = DateTime.Now;
                    h.ghiChu = ghiChu;
                }
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không xác định " + ex.Message);
            }
        }



        //public void ExportFile()
        //{
        //    try
        //    {
        //        SaveFileDialog savefile = new SaveFileDialog();
        //        savefile.FileName = "Response.xls";
        //        savefile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
        //        if (dset.Tables[0].Rows.Count > 0)
        //        {
        //            if (savefile.ShowDialog() == DialogResult.OK)
        //            {
        //                //using (StreamWriter sw = new StreamWriter(savefile.FileName))
        //                //    sw.WriteLine("Hello World!");
        //                StreamWriter wr = new StreamWriter(savefile.FileName);
        //                for (int i = 0; i < dset.Tables[0].Columns.Count; i++)
        //                {
        //                    wr.Write(dset.Tables[0].Columns[i].ToString().ToUpper() + "\t");
        //                }

        //                wr.WriteLine();

        //                //write rows to excel file
        //                for (int i = 0; i < (dset.Tables[0].Rows.Count); i++)
        //                {
        //                    for (int j = 0; j < dset.Tables[0].Columns.Count; j++)
        //                    {
        //                        if (dset.Tables[0].Rows[i][j] != null)
        //                        {
        //                            wr.Write(Convert.ToString(dset.Tables[0].Rows[i][j]) + "\t");
        //                        }
        //                        else
        //                        {
        //                            wr.Write("\t");
        //                        }
        //                    }
        //                    //go to next line
        //                    wr.WriteLine();
        //                }
        //                //close file
        //                wr.Close();
        //                MetroMessageBox.Show(this, "Data saved in Excel format at location " + savefile.FileName, "Successfully Saved", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //            }
        //        }
        //        else
        //        {
        //            MetroMessageBox.Show(this, "Zero record to export , perform a operation first", "Can't export file", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MetroMessageBox.Show(this, v1.PrintExceptionDetails(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        el.LogError(ex);
        //    }
        //}
    }
}
