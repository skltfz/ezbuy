using EzBuy.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.dal
{
    class producttype_dal
    {
        public static DataTable select_table(db db,object id)
        {
            return db.power(String.Format(@"select id as ID, name as Name,remarks as Remarks from producttype where product_id= {0}", db.Wrap(id,DbType.Number)));
        }

        public static String update_record(db db,Object product_id, Object id, Object name,Object remarks)
        {
            String error = "";
            DataTable errorTb =
            db.power("update " + Producttype.dtn + " set " +
                            Producttype.cn_remarks + "=" + db.Wrap(remarks, DbType.String) + "," +
                            Producttype.cn_name + "=" + db.Wrap(name, DbType.String) +
                            " where " + Producttype.cn_product_id + "=" + db.Wrap(product_id, DbType.Number)
                            + " and id = " + db.Wrap(id,DbType.Number))
                            ;
            if (errorTb.Rows.Count > 0) error = errorTb.Rows[0][0].ToString();
            return error;
        }

        public static void insert_record(db db, object product_id, object id, object name, object remarks)
        {
            db.power(String.Format(@"INSERT INTO producttype 
                        SELECT 
                        {0},
                        {1},
                        {2},
                        {3}", db.Wrap(product_id, DbType.Number), db.Wrap(id, DbType.Number), db.Wrap(name, DbType.String), db.Wrap(remarks, DbType.String)
                        ).ToString()
                        );
            return;
        }

        public static DataTable delete_record(db db, object product_id, object id)
        {
            return db.power("delete from " + Producttype.dtn + " where " + Producttype.cn_product_id + "=" + db.Wrap(product_id, DbType.Number) + " and " + Producttype.cn_id + " = " + db.Wrap(id, DbType.Number)); 

        }
        public static Boolean contain_byName(db db,Object product_id,Object name)
        {
            String sql_string = "SELECT COUNT(1) from " + Producttype.dtn + " where " + Producttype.cn_name + "=" + db.Wrap(name,DbType.String) +" and product_id =" + db.Wrap(product_id, DbType.Number);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }
        public static Boolean contain_byID(db db, object product_id, String id)
        {
            String sql_string = "SELECT COUNT(1) from " + Producttype.dtn + " where " + Producttype.cn_product_id + "=" + db.Wrap(product_id,DbType.Number) +" and id="+ db.Wrap(id,DbType.Number);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }
        public static int get_id(db db,String name)
        {
            String sql_string = "SELECT " + Product.cn_product_id + " from " + Product.dtn + " where " + Product.cn_product_name + "=" + db.nseb(name);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString());
        }
        public static int get_max_id(db db,object product_id)
        {
            String sql_string = "SELECT ISNULL(max(" + Producttype.cn_id + "),0)+1 from " + Producttype.dtn + " where product_id=" + db.Wrap(product_id,DbType.Number) ;
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString());
        }
    }
}
