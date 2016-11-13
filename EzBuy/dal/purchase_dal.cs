using EzBuy.classes;
using EzBuy.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.dal
{
    class purchase_dal
    {
        public static DataTable select_table(db db)
        {
            return db.power(@"select purchase_id as 'ID',
                                date as 'Date',
                                A.product_id as 'Product ID',
                                product_name as 'Product Name',
                                producttype_id as 'Product Type ID',
                                C.name as 'Product Type Name',
                                product_cost as 'Product cost',
                                quantity as 'Quantity',
                                shipment_cost as 'Shipment cost',
                                total as 'Total',
                                cost as 'Cost Per Item',
                                order_id as 'Order ID',
                                shop_name as 'Shop'
                                from purchase A left outer join 
                                product B on A.product_id = B.product_id
                                left outer join producttype C on
                                A.product_id = C.product_id and A.producttype_id = C.id order by date desc
                                ");
        }
        public static DataTable select_table(db db, DateTime date, int type)
        {
            String sql = "";
            switch (type)
            {
                case 0:
                    sql = @"select purchase_id as 'ID',
                                date as 'Date',
                                A.product_id as 'Product ID',
                                product_name as 'Product Name',
                                producttype_id as 'Product Type ID',
                                C.name as 'Product Type Name',
                                product_cost as 'Product cost',
                                quantity as 'Quantity',
                                shipment_cost as 'Shipment cost',
                                total as 'Total',
                                cost as 'Cost Per Item',
                                order_id as 'Order ID',
                                shop_name as 'Shop'
                                from purchase A left outer join 
                                product B on A.product_id = B.product_id
                                left outer join producttype C on
                                A.product_id = C.product_id and A.producttype_id = C.id
                                where date = " + db.Wrap(date.ToString("yyyy-MM-dd"),DbType.Date) + "  order by date desc";
                    break;
                case 1:
                    sql = @"select purchase_id as 'ID',
                                date as 'Date',
                                A.product_id as 'Product ID',
                                product_name as 'Product Name',
                                producttype_id as 'Product Type ID',
                                C.name as 'Product Type Name',
                                product_cost as 'Product cost',
                                quantity as 'Quantity',
                                shipment_cost as 'Shipment cost',
                                total as 'Total',
                                cost as 'Cost Per Item',
                                order_id as 'Order ID',
                                shop_name as 'Shop'
                                from purchase A left outer join 
                                product B on A.product_id = B.product_id
                                left outer join producttype C on
                                A.product_id = C.product_id and A.producttype_id = C.id
                                where YEAR(date)=" + db.Wrap(date.Year,DbType.Number)+
                                " and MONTH(date)=" + db.Wrap(date.Month,DbType.Number) + "  order by date desc"
                    ;
                    break;
                case 2:
                    sql = @"select purchase_id as 'ID',
                                date as 'Date',
                                A.product_id as 'Product ID',
                                product_name as 'Product Name',
                                producttype_id as 'Product Type ID',
                                C.name as 'Product Type Name',
                                product_cost as 'Product cost',
                                quantity as 'Quantity',
                                shipment_cost as 'Shipment cost',
                                total as 'Total',
                                cost as 'Cost Per Item',
                                order_id as 'Order ID',
                                shop_name as 'Shop'
                                from purchase A left outer join 
                                product B on A.product_id = B.product_id
                                left outer join producttype C on
                                A.product_id = C.product_id and A.producttype_id = C.id
                                where YEAR(date)=" + db.Wrap(date.Year, DbType.Number) + " order by date desc";
                    break;
                default:
                    sql = @"select purchase_id as 'ID',
                                date as 'Date',
                                A.product_id as 'Product ID',
                                product_name as 'Product Name',
                                producttype_id as 'Product Type ID',
                                C.name as 'Product Type Name',
                                product_cost as 'Product cost',
                                quantity as 'Quantity',
                                shipment_cost as 'Shipment cost',
                                total as 'Total',
                                cost as 'Cost Per Item',
                                order_id as 'Order ID',
                                shop_name as 'Shop'
                                from purchase A left outer join 
                                product B on A.product_id = B.product_id
                                left outer join producttype C on
                                A.product_id = C.product_id and A.producttype_id = C.id
                     order by date desc";
                    break;
            }
            return db.power(sql);
        }
        public static void update_record(db db, String id, Object date, Object product_id,Object producttype_id,Object product_cost, Object shipment_cost, Object cost, Object quantity,Object total, Object order_id, Object shop_name)
        {
            List<String> parameters = new List<String>();
            if (!util.DataGridView_IsCellEmpty( date))
                parameters.Add(Purchase.cn_date + "=" + db.Wrap(date, DbType.Date));
            if (!util.DataGridView_IsCellEmpty(product_id))
                parameters.Add(Purchase.cn_product_id + "=" + db.Wrap(product_id, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(producttype_id))
                parameters.Add(Purchase.cn_producttype_id + "=" + db.Wrap(producttype_id, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(cost))
                parameters.Add(Purchase.cn_cost + "=" + db.Wrap(cost, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(product_cost))
                parameters.Add(Purchase.cn_product_cost + "=" + db.Wrap(product_cost, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(shipment_cost))
                parameters.Add(Purchase.cn_shipment_cost + "=" + db.Wrap(shipment_cost, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(total))
                parameters.Add(Purchase.cn_total + "=" + db.Wrap(total, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(quantity))
                parameters.Add(Purchase.cn_quantity + "=" + db.Wrap(quantity, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(order_id))
                parameters.Add(Purchase.cn_order_id + "=" + db.Wrap(order_id, DbType.String));
            if (!util.DataGridView_IsCellEmpty(shop_name))
                parameters.Add(Purchase.cn_shop_name + "=" + db.Wrap(shop_name, DbType.String));
            db.power(       "update "+Purchase.dtn+" set " +
                            String.Join(",",parameters)+
                            " where " + Purchase.cn_purchase_id+"=" + db.Wrap(id,DbType.Number));
            return;
        }

        public static void insert_record_withID(db db,String id,Object date, Object product_id,Object producttype_id, Object product_cost,Object shipment_cost,Object cost, Object quantity,Object total, Object order_id, Object shop_name)
        {            
            db.power("INSERT INTO " + Purchase.dtn + " SELECT " +
                db.Wrap(id,DbType.Number)+"," + 
                db.Wrap(date, DbType.Date) + "," +
                db.Wrap(product_id, DbType.Number) + "," +
                db.Wrap(producttype_id, DbType.Number) + "," +
                db.Wrap(product_cost, DbType.Number) + "," +
                db.Wrap(shipment_cost, DbType.Number) + "," +
                db.Wrap(cost, DbType.Number) + "," +
                db.Wrap(quantity, DbType.Number) + "," +
                db.Wrap(total, DbType.Number) + "," +
                db.Wrap(order_id, DbType.String) + "," +
                db.Wrap(shop_name, DbType.String) +","+
                db.Wrap(buyer_dal.get_master_id(),DbType.Number)                            
                );
            return;
        }
        
        public static void delete_record_byID(db db, String id)
        {
            db.power("delete from " + Purchase.dtn + " where " + Purchase.cn_purchase_id + "=" + db.Wrap(id,DbType.Number));
            return;
        }
        public static void delete_record_byOrderID(db db, String orderid)
        {
            db.power("delete from " + Purchase.dtn + " where " + Purchase.cn_order_id + "=" +db.Wrap(orderid, DbType.String));
            return;
        }

        public static Boolean contain_byID(db db, String id)
        {
            String sql_string = "SELECT COUNT(1) from " + Purchase.dtn + " where " + Purchase.cn_purchase_id + "=" + db.Wrap(id,DbType.Number);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }

        public static Boolean contain_byProductID(db db,String id)
        {
            String sql_string = "SELECT COUNT(1) from " + Purchase.dtn + " where " + Purchase.cn_product_id + "=" + db.Wrap(id, DbType.Number);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }

        public static int get_id(db db,object date, object product_id,object order_id)
        {
            String sql_string = "SELECT purchase_id from " + Purchase.dtn +" where date="+DbType.Date+" and product_id=" + db.Wrap(product_id,DbType.Number) +" and order_id="+ db.Wrap(order_id,DbType.String);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString());
        }

        public static int get_max_id(db db)
        {
            String sql_string = "SELECT ISNULL(max(" + Purchase.cn_purchase_id + "),0)+1 from " + Purchase.dtn;
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString());
        }

        public static decimal get_cost(db db, object product_id,object producttype_id)
        {
            try
            {
                return Convert.ToDecimal(db.power(
                    @"select TOP(1) ISNULL(cost,0) from purchase 
                    where product_id=" + db.Wrap(product_id, DbType.Number) + " and producttype_id=" + db.Wrap(producttype_id,DbType.Number) +
                        "order by date desc"
                    ).Rows[0][0].ToString());
            }
            catch (Exception ex) { return 0; }
        }
    }
}
