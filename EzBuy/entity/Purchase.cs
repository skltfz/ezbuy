using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.entity
{
    class Purchase
    {
        public enum dgOrder {
            id=0,
            date =1,
            productid=2,
            productname=3,
            producttype_id = 4,
            producttype_name = 5,
            productcost = 6,
            quantity = 7,
            shipmentcost = 8,
            total = 9,
            cost = 10,
            orderid = 11,
            shop=12 ,
            buyer= 13,
           }
        public static String dtn = "purchase";
        public static String cn_purchase_id = "purchase_id";
        public static String cn_date = "date";
        public static String cn_product_id = "product_id";
        public static String cn_producttype_id = "producttype_id";
        public static String cn_producttype_name = "producttype_name";
        public static String cn_cost = "cost";
        public static String cn_shipment_cost = "shipment_cost";
        public static String cn_product_cost = "product_cost";
        public static String cn_total = "total";
        public static String cn_quantity = "quantity";
        public static String cn_order_id = "order_id";
        public static String cn_shop_name = "shop_name";
        //public class Row
        //{
        //    public int purchase_id;
        //    public DateTime date;
        //    public int item_id;
        //    public decimal cost;
        //    public decimal shipmentcost;
        //    public decimal productcost;
        //    public decimal total;
        //    public int quantity;
        //    public string order_id;
        //    public string shop_name;
        //    public Row(int purchase_id,DateTime date, int item_id,decimal cost,int quantity,decimal total, string order_id, string shop_name,decimal shipmentcost,decimal productcost)
        //    {
        //        this.purchase_id = purchase_id;
        //        this.date = date;
        //        this.item_id = item_id;
        //        this.cost = cost;
        //        this.total = total;
        //        this.quantity = quantity;
        //        this.order_id = order_id;
        //        this.shop_name = shop_name;
        //        this.shipmentcost = shipmentcost;
        //        this.productcost = productcost;
                
        //    }
        //}
    }
}
