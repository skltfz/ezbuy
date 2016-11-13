using EzBuy.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.dal
{
    class category_dal
    {
        public static DataTable select_table(db db)
        {
            return db.power("select category_id as ID,category_name as 'Name' from category");
        }

        public static void update_record(db db,String id, String name)
        {
            db.power(
                            "update category set " +
                            Category.cn_category_name + "=" + db.nseb(name) +
                            " where category_id=" + id);
            return;
        }


        public static void insert_record(db db,String id,String name)
        {
            db.power("insert into " + Category.dtn +" "+
                                "SELECT "+ db.Wrap(id, DbType.Number) + "," + db.Wrap(name,DbType.String) + ""
                            );
            return;
        }
        public static void delete_record(db db, String id)
        {
            db.power("delete from " + Category.dtn + " where " + Category.cn_category_id + "=" + id);
            return;
        }
        public static Boolean contain_byID(db db,String id)
        {
            String sql_string = "SELECT COUNT(1) from " + Category.dtn + " where " + Category.cn_category_id + "=" + db.Wrap(id,DbType.Number);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }
        public static Boolean contain_byName(db db, String name)
        {
            String sql_string = "SELECT COUNT(1) from " + Category.dtn + " where " + Category.cn_category_name + "=" + db.Wrap(name, DbType.String);
            DataTable ret = db.power(sql_string);
            return Convert.ToInt32(ret.Rows[0][0].ToString()) > 0;
        }
        public static int get_max_id(db db)
        {
            try
            {
                String sql_string = "SELECT ISNULL(max(" + Category.cn_category_id + "),0)+1 from " + Category.dtn ;
                DataTable ret = db.power(sql_string);
                return Convert.ToInt32(ret.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
                return -1;
            }
        }
        public static int get_id(db db,String name)
        {
            try
            {
                String sql_string = "SELECT " + Category.cn_category_id + " from " + Category.dtn + " where " + Category.cn_category_name + "=" + db.nseb(name);
                DataTable ret = db.power(sql_string);
                return Convert.ToInt32(ret.Rows[0][0].ToString());
            }
            catch(Exception ex)
            {
                writelog.writeentry(1, ex.Message);
                return -1;
            }
        }
    }
}
