using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.entity
{
    class SaleInput
    {
        public enum dgOrder
        {
            product_name = 0,
            product_id = 1,
            producttype_name = 2,
            producttype_id = 3,
            price = 4,
            quantity = 5,
            discount = 6,
            total = 7,
            cost = 8,
            profit = 9,
            id = 10
        }
        public static String dtn = "saleinput";
        public static String cn_product_id = "product_id";
        public static String cn_producttype_id = "producttype_id";
        public static String cn_price = "price";
        public static String cn_quantity = "quantity";
        public static String cn_discount = "discount";
        public static String cn_total = "total";
        public static String cn_profit = "profit";
        public static String cn_cost = "cost";
        public static String cn_id = "id";
        public class Row
        {
            public DateTime date;
            public int sale_id;
            public int item_id;
            public decimal price;
            public int quantity;
            public int discount;
            public decimal profit;
            public decimal cost;
            public decimal total;
            public int id ;
            //public Row(int sale_id,DateTime date, int item_id, decimal price, int quantity,int discount,decimal total,
            //     decimal cost,decimal profit, int id)
            //{
            //    this.sale_id = sale_id;
            //    this.date = date;
            //    this.item_id = item_id;
            //    this.price = price;
            //    this.quantity = quantity;
            //    this.discount = discount;
            //    this.total = total;
            //    this.profit = profit;
            //    this.cost = cost;
            //    this.id = id;
            //}
        }
    }
}
