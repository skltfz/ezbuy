using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.classes
{
    public enum GridConstantType { smallid,smallno, date, remarks }
    public class GridConstant {
        public static int defaultLength = 150;
        public static int remarks = 230;
        public static int date = 80;
        public static int smallid = 48;
        public static int smallno = 60;
        public static int get(GridConstantType type)
        {
            switch (type)
            {
                case GridConstantType.date:
                    return date;
                case GridConstantType.smallid:
                    return smallid;
                case GridConstantType.smallno:
                    return smallno;
                case GridConstantType.remarks:
                    return remarks;
                default:
                    return defaultLength;
            }
        }
    }
}
