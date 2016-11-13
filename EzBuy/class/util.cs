using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzBuy.classes
{
    class util
    {
        public static string replaceNewline(string s)
        {
            string rq = s.Replace(System.Environment.NewLine, "");
            rq = rq.Replace("\n", "");
            rq = rq.Replace("\r\n", "");
            rq = rq.Replace("\t", "");
            return rq;
        }   
        public static Boolean DataGridView_IsCellEmpty(Object cellValue)
        {
            return cellValue == System.DBNull.Value|| cellValue==null;
        }
    }
}
