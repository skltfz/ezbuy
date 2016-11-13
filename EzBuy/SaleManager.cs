using EzBuy.classes;
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
    public partial class SaleManager : Form
    {
        private int dginput_rowNo = -1;
        private int dg1_rowNo = -1;
        db db = new db();
        public SaleManager()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            reload_dg1();
            reload_dginput();                       
        }
        private void reload_dg1()
        {
            dg1.DataSource =  sale_dal.select_table(db);
        }
        private void reload_dginput()
        {
            dginput.DataSource = saleinput_dal.select_table(db);
            dginput.Columns[(int)SaleInput.dgOrder.id].Visible = false;
            dginput.Columns[(int)SaleInput.dgOrder.product_id].Visible = false;
            dginput.Columns[(int)SaleInput.dgOrder.producttype_id].Visible = false;
            computeTotal();
        }
        private void purchase_Click(object sender, EventArgs e)
        {
            var form = new PurchaseManager();
            form.Show();
        }


        private void stock_Click(object sender, EventArgs e)
        {
            var form = new StockManager();
            form.Show();
        }



        #region Sale
        private void dg1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dg1_rowNo = e.RowIndex;
            dg1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dg1.Rows[e.RowIndex].Selected = true;
        }
        private void dg1_KeyDown(object sender, KeyEventArgs e)
        {            
        }
        private void dg1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
            if (dg1_rowNo >= 0)
            {
                String id = dg1.Rows[dg1_rowNo].Cells[0].Value.ToString();
                if (DialogResult.OK == MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    sale_dal.delete_record(db, id);
                    reload_dg1();
                }
                else e.Cancel= true;             
            }

        }
        private void dg1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }        
        #endregion

        #region SALE INPUT
        private Boolean dginput_contain_byID(String id)
        {
            int count = 0;
            foreach (DataGridViewRow row in dginput.Rows)
            {
                if (!util.DataGridView_IsCellEmpty(row.Cells[1].Value) && row.Cells[1].Value!=null)//null is to handle the row that is the last new added row, it contains nothing
                {
                    if (row.Cells[1].Value.ToString().Equals(id))
                        count++;
                    if (count > 1) return true;
                }
            }
            return false;
        }
        private void dginput_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dginput_rowNo = e.RowIndex;
            dginput.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dginput.Rows[e.RowIndex].Selected = true;
        }

        private void dginput_KeyDown(object sender, KeyEventArgs e)
        {
            if (dginput_rowNo >= 0)
            {
                String id = dginput.Rows[dginput_rowNo].Cells[8].Value.ToString();
                if (e.KeyCode == Keys.Delete && dginput.Rows[dginput_rowNo].Selected)
                {
                    saleinput_dal.delete_record(db, id);
                    reload_dginput();
                }
            }
        }

        private void dginput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == (int)SaleInput.dgOrder.producttype_name || e.ColumnIndex == (int)SaleInput.dgOrder.product_name) && e.RowIndex >= 0)
            {
                using (var form = new ProductManager(1))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int product_id = ProductManager.SelectedProductID;
                        int producttype_id = ProductManager.SelectedProductTypeID;
                        dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.product_name].Value = ProductManager.SelectedProduct;
                        dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.product_id].Value = ProductManager.SelectedProductID;
                        dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.producttype_id].Value = ProductManager.SelectedProductTypeID;
                        dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.producttype_name].Value = ProductManager.SelectedProductType;

                        String price = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.price].Value.ToString();
                        Decimal cost = purchase_dal.get_cost(db,product_id,producttype_id);
                        if (price.Equals(""))
                        {
                            price = stock_dal.get_price(db, product_id,producttype_id).ToString();
                            dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.price].Value = price;
                        }
                        dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.cost].Value = cost;

                        Object quantity = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.quantity].Value;
                        Object discount = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.discount].Value;
                        Object id = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.id].Value;
                        Decimal profit = bi.getProfit(price, cost, discount,quantity);
                        dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.profit].Value = profit;
                        Decimal total = bi.getTotal(price, discount, quantity);
                        dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.total].Value = total;
                        if (saleinput_dal.contain_byID(db, id))
                        {                            
                                saleinput_dal.update_record(db,id, product_id, price, quantity, discount,cost,profit,total);
                        }
                        else if (!product_id.Equals("") && !price.Equals("") && !util.DataGridView_IsCellEmpty( quantity))
                        {
                            int generated_id = saleinput_dal.insert_record(db, product_id, producttype_id, price, quantity, discount, profit, total,cost);
                            dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.id].Value = generated_id;
                        }
                    }
                }
            }
            computeTotal();
        }        

        private void dginput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            String product_id = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.product_id].Value.ToString();
            String producttype_id = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.producttype_id].Value.ToString();
            Object price = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.price].Value;
            Object quantity = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.quantity].Value;
            Object discount = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.discount].Value;
            Object id = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.id].Value;
            Object cost = dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.cost].Value;
            Decimal profit = bi.getProfit(price, cost, discount, quantity);
            dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.profit].Value = profit;
            Decimal total = bi.getTotal(price, discount, quantity);
            dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.total].Value = total;
            if (saleinput_dal.contain_byID(db, id))
            { 
                    saleinput_dal.update_record(db,id, product_id, price, quantity, discount,cost,profit,total);
            }
            else if (!product_id.Equals("") && ! util.DataGridView_IsCellEmpty( price) && !util.DataGridView_IsCellEmpty(quantity))
            {
                int generated_id = saleinput_dal.insert_record(db, product_id,producttype_id, price, quantity, discount,profit,total,cost);
                dginput.Rows[e.RowIndex].Cells[(int)SaleInput.dgOrder.id].Value = generated_id;
            }
            computeTotal();
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            String transactionID = DateTime.Now.ToString("yyyyMMddHHmmss");
            sale_dal.insert_record_byInput(db,transactionID);
            reload_dg1();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            saleinput_dal.truncate_table(db);
            reload_dginput();
        }
        #endregion

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            reload_dginput();
            reload_dg1();
        }     
        private void computeTotal()
        {
            decimal total = 0;
            foreach(DataGridViewRow tmp in dginput.Rows)
            {
                try
                {
                    total += bi.getTotal(tmp.Cells[(int)SaleInput.dgOrder.price].Value, tmp.Cells[(int)SaleInput.dgOrder.discount].Value, tmp.Cells[(int)SaleInput.dgOrder.quantity].Value);
                }
                catch(Exception ex)
                {
                    writelog.writeentry(1, ex.Message);
                }                
            }
            total_B.Text = total.ToString();
        }

        private void search_B_TextChanged(object sender, EventArgs e)
        {
            if (!search_B.Text.Equals(""))
                (dg1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Product] LIKE '%{0}%'", search_B.Text) + " OR " + string.Format("[TID] LIKE '%{0}%'", search_B.Text);
            else
                (dg1.DataSource as DataTable).DefaultView.RowFilter = "";
        }       

        private void profit_Click(object sender, EventArgs e)
        {
            var form = new ProfitManager();
            form.Show();
        }
        #region menu
        private void category_menu_Click(object sender, EventArgs e)
        {
            var form = new Catalog(false);
            form.Show();
        }

        private void product_menu_Click(object sender, EventArgs e)
        {
            var form = new ProductManager(0);
            form.Show();
        }
        #endregion

        private void rateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Rate();
            form.Show();
        }
    }
}
