using EzBuy.dal;
using EzBuy.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EzBuy
{
    public partial class StockManager : Form
    {
        private enum dataType {byCategory,byProduct }
        private dataType type = dataType.byProduct;
        private db db = new EzBuy.db();
        private decimal expected_profit;
        public StockManager()
        {
            InitializeComponent();
        }

        private void category_Load(object sender, EventArgs e)
        {
            expected_profit = master_dal.get_expectedRevenue(db);
            reload();                       
        }
        private Boolean dg1_contain_byID(String id)
        {
            int count = 0;
            foreach(DataGridViewRow row in dg1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString().Equals(id))
                        count++;
                    if (count > 1) return true;
                }
            }
            return false;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // dataGridView1.Rows[e.RowIndex].Cells[0].Value = 44;
                Object id = dg1.Rows[e.RowIndex].Cells[(int)Stock.dgOrder.product_id].Value;
                Object type_id = dg1.Rows[e.RowIndex].Cells[(int)Stock.dgOrder.producttype_id].Value;
                Object price = dg1.Rows[e.RowIndex].Cells[(int)Stock.dgOrder.price].Value;
                Object quantity = dg1.Rows[e.RowIndex].Cells[(int)Stock.dgOrder.quantity].Value;
                Object producttype_id = dg1.Rows[e.RowIndex].Cells[(int)Stock.dgOrder.producttype_id].Value;
                Object soldout = dg1.Rows[e.RowIndex].Cells[(int)Stock.dgOrder.soldout].Value;
                dg1.Rows[e.RowIndex].Cells[(int)Stock.dgOrder.value].Value = (Convert.ToInt16(quantity) -  Convert.ToInt16(soldout)) * Convert.ToDouble( price);
                stock_dal.update_price(db, id,producttype_id, price);
                decimal stock_value = stock_dal.currentStockValue(db);
                value_B.Text = stock_value.ToString();
                if (stock_value - expected_profit >= 0)
                {
                    res_L.ForeColor = Color.Green;
                }
                else res_L.ForeColor = Color.Red;
                res_L.Text = "= " + (stock_value - expected_profit).ToString();
            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
            }
        }  

        private void reload()
        {
            decimal stock_value = stock_dal.currentStockValue(db);            
            dg1.DataSource = null;
            if (type == dataType.byCategory)
                dg1.DataSource = stock_dal.select_table_byCategory(db);
            else
                dg1.DataSource = stock_dal.select_table(db);
            value_B.Text = stock_value.ToString();
            expectedprofit_B.Text = expected_profit.ToString();
            try
            {
               
                if (stock_value - expected_profit >= 0)
                {
                    res_L.ForeColor = Color.Green;
                }
                else res_L.ForeColor = Color.Red;
                res_L.Text = "= "+(stock_value - expected_profit).ToString();

                dg1.Columns[(int)Stock.dgOrder.producttype_name].ReadOnly = true;
                dg1.Columns[(int)Stock.dgOrder.product_name].ReadOnly = true;
                dg1.Columns[(int)Stock.dgOrder.producttype_id].ReadOnly = true;
                dg1.Columns[(int)Stock.dgOrder.product_id].ReadOnly = true;
                dg1.Columns[(int)Stock.dgOrder.quantity].ReadOnly = true;
                dg1.Columns[(int)Stock.dgOrder.value].ReadOnly = true;
                dg1.Columns[(int)Stock.dgOrder.soldout].ReadOnly = true;

                dg1.Columns[(int)Stock.dgOrder.producttype_id].Visible = false;
                dg1.Columns[(int)Stock.dgOrder.product_id].Visible = false;


            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
            }

        }
        
        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void byProduct_Click(object sender, EventArgs e)
        {
            type = dataType.byProduct;
            reload();
        }

        private void byCategory_Click(object sender, EventArgs e)
        {
            type = dataType.byCategory;
            reload();
        }

    }
}
