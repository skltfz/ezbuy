using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.dal
{
    class master_dal
    {
        public static decimal get_expectedRevenue(db db)
        {            
            return Convert.ToDecimal( db.power("SELECT expectedProfit from master").Rows[0][0].ToString());
        }
    }
}
