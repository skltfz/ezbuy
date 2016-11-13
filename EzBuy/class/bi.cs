using EzBuy.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy
{

    public enum Currency { HKD,CNY }
    class bi
    {
        public static double rate = 1.18;
        public static decimal ConvertMoney(decimal input, Currency currency)
        {
            switch(currency)
            {
                case Currency.HKD:
                    return input * Convert.ToDecimal(rate);
                case Currency.CNY:
                    return input / Convert.ToDecimal(rate);
                default:
                    return 0;
            }
            
        }
        public static decimal getProfit(object price, object cost, object discount,object quantity)
        {
            if (price == null || util.DataGridView_IsCellEmpty(price)) return -1;
            if (cost == null || util.DataGridView_IsCellEmpty(cost)) cost = 0;
            if (quantity == null || util.DataGridView_IsCellEmpty(quantity)) quantity = 0;
            decimal portion= 1;
            if (discount != null && !util.DataGridView_IsCellEmpty(discount))
                portion = (1 - (Convert.ToDecimal(discount) / 100));
            return (Convert.ToDecimal(price) *portion - Convert.ToDecimal(cost)) * Convert.ToDecimal(quantity);
        }
        public static decimal getTotal(object price, object discount, object quantity)
        {
            if (price == null || util.DataGridView_IsCellEmpty(price)) return 0;
            if (quantity == null || util.DataGridView_IsCellEmpty(quantity)) quantity = 0;
            decimal portion = 1;
            if (discount != null && !util.DataGridView_IsCellEmpty(discount))
                portion = (1 - (Convert.ToDecimal(discount) / 100));
            return (Convert.ToDecimal(price) * portion) * Convert.ToDecimal(quantity);

        }
        public static decimal getProfitByMonth()
        {
            return 0;
        }
        public static decimal getCost()
        {
            return 0;
        }
    }
}
