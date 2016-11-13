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
    class saleinput_dal
    {
        public static DataTable select_table(db db)
        {
            return db.power(@"select product_name as 'Product Name',A.product_id as 'Product ID',
                                C.name as 'Product Type Name', producttype_id as 'Product Type ID', 
                                price as 'Price', 
                                quantity as Quantity,
                                discount as 'Discount',
                                total as 'Total',
                                cost as 'Cost', 
                                profit as 'Profit',
                                A.id as 'id'
                                from saleinput A
                                left outer join product B on                                
                                A.product_id = B.product_id
                                left outer join producttype C 
                                on A.producttype_id = C.id and A.product_id = C.product_id");
        }
        public static DataTable select_table_byCategory(db db)
        {
            return db.power(@"select category_name as 'Category Name', SUM((quantity-soldout)*price) as Value From category A
                            left outer join product B
                            on A.category_id = B.category_id
                            left outer join stock C on B.product_id = C.product_id
                            group by category_name");
        }
        
        public static decimal currentStockValue(db db)
        {
            return Convert.ToDecimal( db.power("select SUM((quantity-soldout)*price) from "+ Stock.dtn).Rows[0][0].ToString());
        }
        public static void update_record(db db, Object id, Object product_id, Object price, Object quantity, Object discount, Object cost, Object profit, Object total)
        {
            List<String> parameters = new List<String>();
            if (!util.DataGridView_IsCellEmpty( price))
                parameters.Add(SaleInput.cn_price + "=" + db.Wrap(price, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(quantity))
                parameters.Add(SaleInput.cn_quantity + "=" + db.Wrap(quantity, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(discount))
                parameters.Add(SaleInput.cn_discount + "=" + db.Wrap(discount, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(cost))
                parameters.Add(SaleInput.cn_cost + "=" + db.Wrap(cost, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(profit))
                parameters.Add(SaleInput.cn_profit + "=" + db.Wrap(profit, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(product_id))
                parameters.Add(SaleInput.cn_product_id + "=" + db.Wrap(product_id, DbType.Number));
            if (!util.DataGridView_IsCellEmpty(total))
                parameters.Add(SaleInput.cn_total + "=" + db.Wrap(total, DbType.Number));
            db.power(
                            "update "+SaleInput.dtn+" set " +
                               String.Join(",", parameters) +
                            " where " + SaleInput.cn_id+"=" + db.Wrap(id,DbType.Number));
            return;
        }


        public static int insert_record(db db, Object product_id, Object producttype_id,Object price,Object quantity,Object discount,Object profit, Object total,Object cost)//returning identitifer
        {
            string query = @"insert into " + SaleInput.dtn + " " + (util.DataGridView_IsCellEmpty(discount) ? "(product_id,producttype_id,price,quantity,profit,total,cost)" : "(product_id,producttype_id,price,quantity,discount,profit,total,cost)") +
                                "SELECT "
                                + db.Wrap(product_id, DbType.Number) + ","
                                + db.Wrap(producttype_id, DbType.Number) + ","
                                + db.Wrap(price, DbType.Number) + ","
                                + db.Wrap(quantity, DbType.Number)
                                + (util.DataGridView_IsCellEmpty(discount) ? "" : "," + db.Wrap(discount, DbType.Number))+","
                                + db.Wrap(profit, DbType.Number) + ","
                                + db.Wrap(total, DbType.Number) + ","
                                + db.Wrap(cost, DbType.Number) 
                                + ";select @@IDENTITY;";
            DataTable ret = db.power(query);
            return Convert.ToInt16(ret.Rows[0][0]);
        }
        public static void delete_record(db db, String id)
        {
            db.power("delete from " + SaleInput.dtn + " where " + SaleInput.cn_id + "=" + id);
            return;
        }
        public static Boolean contain_byID(db db,Object id)
        {
            if (id == null || util.DataGridView_IsCellEmpty(id)) return false;
            String sql_string = "SELECT COUNT(1) from " + SaleInput.dtn + " where " + SaleInput.cn_id + "=" + db.Wrap(id, DbType.Number);
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
        public static void truncate_table(db db)
        {
            db.power("Truncate table saleinput");            
        }
    }
}
