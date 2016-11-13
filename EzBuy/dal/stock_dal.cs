using EzBuy.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.dal
{
    class stock_dal
    {
        public static DataTable select_table(db db)
        {
            return db.power(@"select A.product_id as Id,product_name as 'Product',
                                    A.producttype_id as 'Product Type Id',name as 'Type',
                quantity as 'Quantity', soldout as 'SoldOut',price as 'Price', (quantity-soldout)*price as 'Value',X.cost as 'Reference Cost'
                from " + Stock.dtn +
                @" A left outer join product B on A.product_id = B.product_id 
                left outer join producttype C on A.product_id = C.product_id and A.producttype_id = C.id
                cross apply (select CAST( AVG(cost) as decimal(18,1)) as cost from purchase X where X.product_id = A.product_id and A.producttype_id = X.producttype_id) X
                "
                   );
        }
        public static DataTable select_table_byCategory(db db)
        {
            return db.power(@"select category_name as 'Category Name', SUM((quantity-soldout)*price) as Value From category A
                            left outer join product B
                            on A.category_id = B.category_id
                            left outer join stock C on B.product_id = C.product_id
                            group by category_name");
        }
        public static void update_price(db db, object id,object producttype_id, object price)
        {
            db.power(
                            "update stock set " +
                            Stock.cn_price +" = "+db.Wrap(price, DbType.Number) +
                            " where " + Stock.cn_product_id + "=" + db.Wrap(id, DbType.Number) + " and "+ Stock.cn_producttype_id+" = "+ db.Wrap(producttype_id,DbType.Number));
            return;
        }

        public static decimal currentStockValue(db db)
        {
            return Convert.ToDecimal( db.power("select SUM((quantity-soldout)*price) from "+ Stock.dtn).Rows[0][0].ToString());
        }
        public static void update_record(db db,String id,Object price, Object quantity, Object soldout)
        {
            List<String> parameters = new List<String>();
            if (price != null)
                parameters.Add(Stock.cn_price + "=" + db.Wrap(price, DbType.Date));
            if (quantity != null)
                parameters.Add(Stock.cn_quantity + "=" + db.Wrap(quantity, DbType.Number));
            if (soldout != null)
                parameters.Add(Stock.cn_soldout + "=" + db.Wrap(soldout, DbType.Number));
           
            db.power(
                            "update stock set " +
                               String.Join(",", parameters) +
                            " where " + Stock.cn_product_id+"=" + id);
            return;
        }


        public static void insert_record(db db, String id, Object price, Object quantity, Object soldout)
        {
            db.power("insert into " + Stock.dtn +" "+
                                "SELECT "+ db.Wrap(id, DbType.Number) + "," + db.Wrap(price, DbType.String) + "," + db.Wrap(quantity, DbType.String) + "," + db.Wrap(soldout, DbType.String) 
            );
            return;
        }
        public static void delete_record(db db, String id)
        {
            db.power("delete from " + Stock.dtn + " where " + Stock.cn_product_id + "=" + id);
            return;
        }
        public static Boolean contain_byID(db db,String id)
        {
            String sql_string = "SELECT COUNT(1) from " + Stock.dtn + " where " + Stock.cn_product_id + "=" + db.Wrap(id,DbType.Number);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }
        public static int get_max_id(db db)
        {
            try
            {
                String sql_string = "SELECT ISNULL(max(" + Stock.cn_product_id + "),0)+1 from " + Stock.dtn ;
                DataTable ret = db.power(sql_string);
                return Convert.ToInt32(ret.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
                return -1;
            }
        }
        public static Decimal get_price(db db,object product_id,object producttype_id)
        {
            try
            {
                String sql_string = "SELECT ISNULL(" + Stock.cn_price + ",0) from " + Stock.dtn + " where product_id=" + db.Wrap(product_id,DbType.Number) + " and producttype_id= "+ db.Wrap(producttype_id,DbType.Number) ;
                DataTable ret = db.power(sql_string);
                return Convert.ToDecimal(ret.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
                return -1;
            }
        }
    }
}
