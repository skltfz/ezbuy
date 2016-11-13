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
    public partial class ProfitManager : Form
    {
        private int rowNo = -1;
        private db db = new EzBuy.db();
        public ProfitManager()
        {
            InitializeComponent();
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

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            dg1.DataSource = null;
            dg1.DataSource = purchase_dal.select_table(db, dateTimePicker1.Value, dgType.SelectedIndex);
            dg2.DataSource = null;
            dg2.DataSource = sale_dal.select_table(db, dateTimePicker1.Value, dgType.SelectedIndex);
            //dg1.Columns[2].Width=300;
            calculateTotal();
        }


        private void PurchaseManager_Load(object sender, EventArgs e)
        {
            dgType.SelectedIndex = 0;
            reload();
        }

        private void orderid_B_TextChanged(object sender, EventArgs e)
        {
            if (!search_B.Text.Equals(""))
            {
                (dg1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Product Name] LIKE '%{0}%'", search_B.Text);// + " OR " + string.Format("[Order ID] LIKE '%{0}%'", search_B.Text);
                (dg2.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Product] LIKE '%{0}%'", search_B.Text);  //" OR " + string.Format("[Order ID] LIKE '%{0}%'", search_B.Text);
            }
            else
            {
                (dg1.DataSource as DataTable).DefaultView.RowFilter = "";
                (dg2.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            calculateTotal();

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void dgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            reload();
        }
        private decimal calculateSold()
        {
            decimal sold = 0;
            foreach (DataGridViewRow tmp in dg2.Rows)
            {
                decimal quantity = tmp.Cells[(int)Sale.dgOrder.quantity] != null && !util.DataGridView_IsCellEmpty(tmp.Cells[(int)Sale.dgOrder.quantity]) ? Convert.ToDecimal(tmp.Cells[(int)Sale.dgOrder.quantity].Value) : 0;
                decimal price = tmp.Cells[(int)Sale.dgOrder.price] != null && !util.DataGridView_IsCellEmpty(tmp.Cells[(int)Sale.dgOrder.price]) ? Convert.ToDecimal(tmp.Cells[(int)Sale.dgOrder.price].Value) : 0;
                decimal discount = tmp.Cells[(int)Sale.dgOrder.discount] != null && !util.DataGridView_IsCellEmpty(tmp.Cells[(int)Sale.dgOrder.discount]) ? Convert.ToDecimal(tmp.Cells[(int)Sale.dgOrder.discount].Value) : 0;
                sold += quantity * price*  (1-(discount/100)) ;
                sold_B.Text = sold.ToString();
            }
            return sold;
        }
        private decimal calculatePurchase()
        {
            decimal purchase = 0;
            foreach (DataGridViewRow tmp in dg1.Rows)
            {
                decimal total = tmp.Cells[(int)Purchase.dgOrder.total] != null && !util.DataGridView_IsCellEmpty(tmp.Cells[(int)Purchase.dgOrder.total]) ? Convert.ToDecimal(tmp.Cells[(int)Purchase.dgOrder.total].Value) : 0;
                purchase += total; //cost * quantity;
                purchase_B.Text = purchase.ToString();
            }
            return purchase;
        }
        private decimal calculateTotal()
        {
            decimal total = (calculateSold() - calculatePurchase());
            if (total > 0)
            {
                profit_B.BackColor = Color.LawnGreen;
                profit_B.ForeColor = Color.White;
            }
            else
            {
                profit_B.BackColor = Color.GhostWhite;
                profit_B.ForeColor = Color.OrangeRed;
            }
            profit_B.Text = total.ToString();
            return total;            
        }

    }
}
