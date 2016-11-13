using EzBuy.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.dal
{
    class product_dal
    {
        public static DataTable select_table(db db)
        {
            return db.power(@"SELECT 
                    product_id as ID, 
                    product_name as Name, 
                    product_desc as Description, 
                    category_name as Category 
                    from product A left outer join category B on A.category_id = B.category_id  order by category,id");
        }
        public static DataTable select_table_by_category(db db)
        {
            return db.power(@"select category_name,COUNT(1) as '產品總數' from product A left outer join category B on A.category_id = B.category_id group by category_name");
        }
        public static void update_record(db db,String id, String name,String desc, int category)
        {
            db.power(       "update "+Product.dtn+" set " +
                            Product.cn_category_id + "=" + db.Wrap(category,DbType.Number) + "," +
                            Product.cn_product_name + "=" + db.Wrap(name,DbType.String) + "," +
                            Product.cn_product_desc + "=" + db.Wrap(desc,DbType.String) +
                            " where "+Product.cn_product_id+"=" + db.Wrap(id,DbType.Number));
            return;
        }


        public static void insert_record_withID(db db, String id, String name, String desc, int category)
        {
            db.power("INSERT INTO " + Product.dtn + " SELECT " +
                    db.Wrap(id, DbType.Number) + "," 
                    + db.Wrap(name, DbType.String) + "," 
                    + db.Wrap(desc, DbType.String) + "," 
                    + db.Wrap(category, DbType.Number));
            return;
        }

        public static DataTable delete_record(db db, String id)
        {
            return db.power("delete from " + Product.dtn + " where " + Product.cn_product_id + "=" + id);
            
        }
        public static Boolean contain_byName(db db,String name)
        {
            String sql_string = "SELECT COUNT(1) from " + Product.dtn + " where " + Product.cn_product_name + "=" + db.nseb(name);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }
        public static Boolean contain_byID(db db, String id)
        {
            String sql_string = "SELECT COUNT(1) from " + Product.dtn + " where " + Product.cn_product_id + "=" + id;
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }
        public static int get_id(db db,String name)
        {
            String sql_string = "SELECT " + Product.cn_product_id + " from " + Product.dtn + " where " + Product.cn_product_name + "=" + db.nseb(name);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString());
        }
        public static int get_max_id(db db)
        {
            String sql_string = "SELECT ISNULL(max(" + Product.cn_product_id + "),0)+1 from " + Product.dtn;
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString());
        }
    }
}
