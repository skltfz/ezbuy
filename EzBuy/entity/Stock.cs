using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.entity
{
    class Stock
    {
        public enum dgOrder
        {
            product_id = 0,
            product_name = 1,
            producttype_id = 2,
            producttype_name = 3,
            quantity = 4,
            soldout = 5,
            price = 6,
            value = 7,
            cost = 8
        }
        public static String dtn = "stock";
        public static String cn_product_id = "product_id";
        public static String cn_producttype_id = "producttype_id";
        public static String cn_quantity = "quantity";
        public static String cn_soldout = "soldout";
        public static String cn_price = "price";
        //public class Row
        //{
        //    public int item_id;
        //    public int quantity;
        //    public decimal price;
        //    public Row(int item_id, int quantity,decimal price)
        //    {
        //        this.item_id = item_id;
        //        this.quantity = quantity;
        //        this.price = price;
        //    }
        //}
    }
}
