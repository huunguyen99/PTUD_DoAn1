using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeTaiPTUD_PhongTro
{
    public class clsKetNoiData
    {
        private QLThueTroSVDataContext dt;
        public QLThueTroSVDataContext LayDuLieu()
        {
            string str = @"Data Source=HOANGHUU\SQLEXPRESS;Initial Catalog=PhongTroSV;Integrated Security=True";
            dt = new QLThueTroSVDataContext(str);
            dt.Connection.Open();
            return dt;
        }
    }
}
