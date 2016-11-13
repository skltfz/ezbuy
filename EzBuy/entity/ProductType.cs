using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.entity
{
    class Producttype
    {
        public enum dgOrder
        {           
            id = 0,
            name = 1,
            remarks = 2
        }
        public static String dtn = "producttype";
        public static String cn_product_id = "product_id";
        public static String cn_id = "id";
        public static String cn_name = "name";
        public static String cn_remarks = "remarks";
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
