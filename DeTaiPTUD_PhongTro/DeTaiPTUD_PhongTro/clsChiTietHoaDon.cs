using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DeTaiPTUD_PhongTro
{
    public class clsChiTietHoaDon:clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsChiTietHoaDon()
        {
            dt = LayDuLieu();
        }
        
        
        public void TaoChiTietHoaDon(tblCT_HoaDon cthd)
        {
            DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                dt.tblCT_HoaDons.InsertOnSubmit(cthd);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi " + ex.Message);
            }
        }
    }
}
