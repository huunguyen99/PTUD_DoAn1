using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DeTaiPTUD_PhongTro
{
    public static class RangBuocDuLieu
    {
        public static Boolean KtraEmail(this string s)
        {
            return Regex.Match(s, @"^([A-Za-z][A-Za-z0-9]+[@][g][m][a][i][l][.][c][o][m])$").Success;
        }

        public static Boolean KtraTenTK(this string s)
        {
            return Regex.Match(s, @"^([A-Za-z][A-Za-z0-9]{5,})$").Success;
        }
        public static Boolean KtraMatKhau(this string s)
        {
            return Regex.Match(s, @"^([A-Za-z][A-Za-z0-9]{7,})$").Success;
        }
        public static Boolean KtraSDT(this string s)
        {
            return Regex.Match(s, @"^[0][13579]\d{8}$").Success;
        }

        public static Boolean KtraSCMND(this string s)
        {
            return Regex.Match(s, @"^[1-9]\d{8}$").Success;
        }
    }
}
