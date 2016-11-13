using EzBuy.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBuy.dal
{
    class sale_dal
    {
        public static DataTable select_table(db db, DateTime date, int type)
        {
            String sql = "";
            switch (type)
            {
                case 0:
                    sql = @"select 
                    sale_id as 'Sale ID',
                    date as 'Date',
                    product_name+' ('+ convert(varchar, A.product_id)+')' as 'Product',
                    C.name+' ('+ convert(varchar, A.producttype_id)+')' as 'Product Type',
                    price as 'Price',
                    quantity as 'Quantity',
                    discount as 'Discount',
                    total as 'Total' ,
                    transaction_id as 'TID'
                    from sale A
                    left outer join product B                    
                    on A.product_id = B.product_id 
                    left outer join producttype C                    
                    on A.product_id = C.product_id and A.producttype_id = C.id                     
                    where CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, date))) = " + db.Wrap(date.ToString("yyyy-MM-dd"),DbType.Date)+
                    " order by date desc";
                    break;
                case 1:
                    sql = @"select 
                    sale_id as 'Sale ID',
                    date as 'Date',
                    product_name+' ('+ convert(varchar, A.product_id)+')' as 'Product',
                    C.name+' ('+ convert(varchar, A.producttype_id)+')' as 'Product Type',                    
                    price as 'Price',
                    quantity as 'Quantity',
                    discount as 'Discount',
                    total as 'Total' ,
                    transaction_id as 'TID'
                    from sale A
                    left outer join product B                    
                    on A.product_id = B.product_id
                    left outer join producttype C                    
                    on A.product_id = C.product_id and A.producttype_id = C.id                  
                    where YEAR(date)=" + db.Wrap(date.Year, DbType.Number) +
                                " and MONTH(date)=" + db.Wrap(date.Month, DbType.Number) +
                    " order by date desc";
                    break;
                case 2:
                    sql = @"select 
                    sale_id as 'Sale ID',
                    date as 'Date',
                    product_name+' ('+ convert(varchar, A.product_id)+')' as 'Product',
                    C.name+' ('+ convert(varchar, A.producttype_id)+')' as 'Product Type',
                    price as 'Price',
                    quantity as 'Quantity',
                    discount as 'Discount',
                    total as 'Total' ,
                    transaction_id as 'TID'
                    from sale A
                    left outer join product B                    
                    on A.product_id = B.product_id 
                    left outer join producttype C                    
                    on A.product_id = C.product_id and A.producttype_id = C.id         
                    where YEAR(date)=" + db.Wrap(date.Year, DbType.Number) +                               
                    " order by date desc";
                    break;
                default:
                    sql = @"select 
                    sale_id as 'Sale ID',
                    date as 'Date',
                    product_name+' ('+ convert(varchar, A.product_id)+')' as 'Product',
                    C.name+' ('+ convert(varchar, A.producttype_id)+')' as 'Product Type',
                    price as 'Price',
                    quantity as 'Quantity',
                    discount as 'Discount',
                    total as 'Total' ,
                    transaction_id as 'TID'
                    from sale A
                    left outer join product B
                    on A.product_id = B.product_id 
                    left outer join producttype C                    
                    on A.product_id = C.product_id and A.producttype_id = C.id         
                    order by date desc";
                    break;
            }
            return db.power(sql);
        }
        public static DataTable select_table(db db)
        {
            return db.power(@"select 
                    sale_id as 'Sale ID',
                    date as 'Date',
                    product_name+' ('+ convert(varchar, A.product_id)+')' as 'Product',
                    C.name+' ('+ convert(varchar, A.producttype_id)+')' as 'Product Type',
                    price as 'Price',
                    quantity as 'Quantity',
                    discount as 'Discount',
                    total as 'Total' ,
                    transaction_id as 'TID'
                    from sale A
                    left outer join product B                      
                    on A.product_id = B.product_id 
                    left outer join producttype C
                    on A.product_id = C.product_id and A.producttype_id = C.id
                    order by date desc");
        }
        public static void insert_record_byInput(db db,String transactionID)
        {
            DataTable records = saleinput_dal.select_table(db);
            String now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            foreach(DataRow tmp in records.Rows)
            {
                List<String> parameterSet = new List<String>();
                parameterSet.Add(db.Wrap(now,DbType.Date));
                parameterSet.Add(db.Wrap(tmp[(int)SaleInput.dgOrder.product_id].ToString(), DbType.Number));
                parameterSet.Add(db.Wrap(tmp[(int)SaleInput.dgOrder.producttype_id].ToString(), DbType.Number));
                parameterSet.Add(db.Wrap(tmp[(int)SaleInput.dgOrder.price].ToString(), DbType.Number));
                parameterSet.Add(db.Wrap(tmp[(int)SaleInput.dgOrder.quantity].ToString(), DbType.Number));
                parameterSet.Add(db.Wrap(
                    (tmp[(int)SaleInput.dgOrder.discount].ToString().Equals("") ? "0" : tmp[(int)SaleInput.dgOrder.discount].ToString())
                    , DbType.Number));
                parameterSet.Add(db.Wrap(
                    (tmp[(int)SaleInput.dgOrder.total].ToString().Equals("") ? "0" : tmp[(int)SaleInput.dgOrder.total].ToString())
                    , DbType.Number));
                parameterSet.Add(db.Wrap(transactionID, DbType.String));
                String parameters = String.Join(",", parameterSet);
                db.power("INSERT INTO sale (date,product_id,producttype_id,price,quantity,discount,total,transaction_id) SELECT " + parameters);
            }
        }
        public static void update_price(db db, object id, object price)
        {
            db.power(
                            "update stock set " +
                            Stock.cn_price +" = "+db.Wrap(price, DbType.Number) +
                            " where " + Stock.cn_product_id + "=" + id);
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
            db.power("delete from " + Sale.dtn + " where " + Sale.cn_sale_id + "=" + id);
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
                String sql_string = "SELECT ISNULL(max(" + Sale.cn_sale_id + "),0)+1 from " + Sale.dtn ;
                DataTable ret = db.power(sql_string);
                return Convert.ToInt32(ret.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
                return -1;
            }
        }
    }
}
