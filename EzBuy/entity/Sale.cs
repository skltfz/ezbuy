using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.entity
{
    class Sale
    {        
        public enum dgOrder
        {
            sale_id = 0,
            date = 1,
            product_name = 2,
            producttype_name = 3,
            price = 4,
            quantity = 5,
            discount = 6,
            total = 7,
            transaction_id = 8  
        }
        public static String dtn = "sale";
        public static String cn_sale_id = "sale_id";
        public static String cn_date = "date";
        public static String cn_product_id = "product_id";
        public static String cn_producttype_id = "producttype_id";
        public static String cn_price = "price";
        public static String cn_quantity = "quantity";
        public static String cn_total = "total";
        public static String cn_discount = "discount";
        public static String cn_transaction_id = "transaction_id";
        //public class Row
        //{
        //    public DateTime date;
        //    public int sale_id;
        //    public int item_id;
        //    public decimal price;
        //    public decimal total;
        //    public int quantity;
        //    public int discount;
        //    public String transaction_id;
        //    public Row(int sale_id,DateTime date, int item_id, decimal price, int quantity,int discount,decimal total,
        //        String transaction_id)
        //    {
        //        this.sale_id = sale_id;
        //        this.date = date;
        //        this.item_id = item_id;
        //        this.price = price;
        //        this.total = total;
        //        this.quantity = quantity;
        //        this.discount = discount;
        //        this.transaction_id = transaction_id;
        //    }
        //}
    }
}
