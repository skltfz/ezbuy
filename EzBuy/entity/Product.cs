using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.entity
{
    class Product
    {
        public enum dgOrder
        {
            product_id = 0,
            product_name = 1,
            product_desc = 2,
            category_id = 3
        }
        public static String dtn = "product";
        public static String cn_product_id = "product_id";
        public static String cn_product_name = "product_name";
        public static String cn_product_desc = "product_desc";
        public static String cn_category_id = "category_id";
        //public class Row
        //{
        //    public int product_id;
        //    public String product_name;
        //    public String product_desc;
        //    public int category_id;
        //    public Row(int product_id,String product_name,int category_id, String product_desc)
        //    {
        //        this.product_id = product_id;
        //        this.product_name = product_name;
        //        this.product_desc = product_desc;
        //        this.category_id = category_id;
        //    }
        //}
    }
}
