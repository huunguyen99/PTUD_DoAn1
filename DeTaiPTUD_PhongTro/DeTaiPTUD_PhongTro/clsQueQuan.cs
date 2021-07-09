using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiPTUD_PhongTro
{
    public class clsQueQuan:clsKetNoiData
    {
        QLThueTroSVDataContext dt;
        public clsQueQuan()
        {
            dt = new QLThueTroSVDataContext();
        }
        public IEnumerable<tblQueQuan> LayDSQueQuan()
        {
            IEnumerable<tblQueQuan> ds = from n in dt.tblQueQuans
                                         select n;
            return ds;
        }
    }
}
