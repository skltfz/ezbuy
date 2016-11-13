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
    public partial class PurchaseManager : Form
    {
        private int rowNo = -1;
        private db db = new EzBuy.db();
        public PurchaseManager()
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

        
 
        private void PurchaseManager_Load(object sender, EventArgs e)
        {
            reload();
        }
        #region dg1Operation
        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == (int)Purchase.dgOrder.productname || e.ColumnIndex == (int)Purchase.dgOrder.producttype_name) && e.RowIndex >= 0)
            {
                using (var form = new ProductManager(1))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productid].Value = ProductManager.SelectedProductID;
                        dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productname].Value = ProductManager.SelectedProduct;
                        dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.producttype_id].Value = ProductManager.SelectedProductTypeID;
                        dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.producttype_name].Value = ProductManager.SelectedProductType;
                        String id = dg1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        String date = "";
                        if (dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.date].Value != null && !util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.date].Value))
                            date = ((DateTime)dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.date].Value).ToString("yyyy-MM-dd");
                        String product_id = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productid].Value.ToString();
                        Object producttype_id = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.producttype_id].Value;
                        decimal product_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.cost].Value);
                        decimal shipment_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shipmentcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.cost].Value);
                        decimal cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.cost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.cost].Value);
                        decimal quantity = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value);
                        decimal total = cost * quantity;//aa
                        String order_id = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.orderid].Value.ToString();
                        String shop_name = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shop].Value.ToString();
                        String today = DateTime.Now.ToString("yyyy-MM-dd");
                        if (!id.Equals(""))
                        {
                            if (dg1_contain_byID(id))
                            {
                                MessageBox.Show("ID is exists");
                                return;
                            }
                            else
                                purchase_dal.update_record(db, id, date, product_id,producttype_id,product_cost,shipment_cost, cost, quantity, total, order_id, shop_name);
                        }
                        else if (!product_id.Equals("") && 
                            !util.DataGridView_IsCellEmpty(quantity) && 
                            !util.DataGridView_IsCellEmpty(cost) && 
                            !util.DataGridView_IsCellEmpty(total))
                        {
                            purchase_dal.insert_record_withID(db, purchase_dal.get_max_id(db).ToString(), (date.Equals("") ? today : date), product_id,producttype_id,product_cost,shipment_cost, cost, quantity,total, order_id, shop_name);
                            reload();
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // dataGridView1.Rows[e.RowIndex].Cells[0].Value = 44;
                String id = dg1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String date = "";
                if (dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.date].Value != null && !util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.date].Value))
                    date = ((DateTime)dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.date].Value).ToString("yyyy-MM-dd");
                String product_id = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productid].Value.ToString();
                String producttype_id = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.producttype_id].Value.ToString();
                String order_id = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.orderid].Value.ToString();
                String shop_name = dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shop].Value.ToString();
                String today = DateTime.Now.ToString("yyyy-MM-dd");
                //aa
                decimal product_cost = 0;
                decimal shipment_cost = 0;
                decimal cost = 0;
                decimal quantity = 0;
                decimal total = 0;
                if (e.ColumnIndex == (int)Purchase.dgOrder.productcost || e.ColumnIndex == (int)Purchase.dgOrder.shipmentcost || e.ColumnIndex == (int)Purchase.dgOrder.quantity)
                {
                    shipment_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shipmentcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shipmentcost].Value);
                    product_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productcost].Value);
                    quantity = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value);
                    total = (product_cost*quantity)  + shipment_cost;
                    cost = total / quantity;
                    setDGV(e.RowIndex, Purchase.dgOrder.cost,cost);
                    setDGV(e.RowIndex, Purchase.dgOrder.total, total);
                }
                else if (e.ColumnIndex == (int)Purchase.dgOrder.total )//6 total , 5 quantity, 4,cost
                {
                    if (!util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value))
                    {
                        quantity = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value);
                        shipment_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shipmentcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shipmentcost].Value);
                        product_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productcost].Value);
                        total = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.total].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.total].Value);
                        if (quantity > 0)
                        {                            
                            product_cost = (total - shipment_cost) /quantity;
                            cost = total / quantity;
                            setDGV(e.RowIndex, Purchase.dgOrder.productcost, product_cost);
                            setDGV(e.RowIndex, Purchase.dgOrder.cost, cost);
                        }
                    }
                }
                else
                {
                    cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.cost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.cost].Value);
                    quantity = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.quantity].Value);
                    total = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.total].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.total].Value);
                    shipment_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shipmentcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.shipmentcost].Value);
                    product_cost = util.DataGridView_IsCellEmpty(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productcost].Value) ? 0 : Convert.ToDecimal(dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.productcost].Value);
                }
                //                String total = dg1.Rows[e.RowIndex].Cells[5].Value.ToString();               
                switch (id)
                {
                    case ""://create
                        if (
                            !util.DataGridView_IsCellEmpty(quantity) &&
                            !util.DataGridView_IsCellEmpty(cost) &&
                            !util.DataGridView_IsCellEmpty(total)
                        )
                        {
                            purchase_dal.insert_record_withID(db, purchase_dal.get_max_id(db).ToString(), (date.Equals("") ? today : date), product_id,producttype_id, product_cost, shipment_cost, cost, quantity,total, order_id, shop_name);
                            dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.id].Value = purchase_dal.get_id(db, date, product_id, order_id);
                            dg1.Rows[e.RowIndex].Cells[(int)Purchase.dgOrder.date].Value = today;
                        }
                        break;
                    default:
                        if (!dg1_contain_byID(id))
                        {
                            if (purchase_dal.contain_byID(db, id))
                                purchase_dal.update_record(db, id, date, product_id,producttype_id,product_cost,shipment_cost, cost, quantity, total, order_id, shop_name);
                            else
                            {
                                purchase_dal.insert_record_withID(db, id, today, product_id,producttype_id, product_cost, shipment_cost,cost, quantity,total, order_id, shop_name);
                            }
                        }
                        else
                            MessageBox.Show("ID is contained in the database already.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (rowNo >= 0)
            {
                String id = dg1.Rows[rowNo].Cells[(int)Purchase.dgOrder.id].Value.ToString();
                if (e.KeyCode == Keys.Delete && dg1.Rows[rowNo].Selected)
                {
                    purchase_dal.delete_record_byID(db, id);
                    reload();
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowNo = e.RowIndex;
            dg1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dg1.Rows[e.RowIndex].Selected = true;
        }

        #endregion
        #region topmenu
        private void refresh_Click(object sender, EventArgs e)
        {
            reload();
        }
        private void orderid_B_TextChanged(object sender, EventArgs e)
        {
            if (!search_B.Text.Equals(""))
                (dg1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Product Name] LIKE '%{0}%'", search_B.Text) + " OR " + string.Format("[Order ID] LIKE '%{0}%'", search_B.Text);
            else
                (dg1.DataSource as DataTable).DefaultView.RowFilter = "";


        }
        #endregion
        #region function
        private void reload()
        {
            dg1.DataSource = purchase_dal.select_table(db);
            dg1.Columns[(int)Purchase.dgOrder.id].Width = GridConstant.get(GridConstantType.smallid);//id
            dg1.Columns[(int)Purchase.dgOrder.shipmentcost].Width = GridConstant.get(GridConstantType.smallno);//id
            dg1.Columns[(int)Purchase.dgOrder.productcost].Width = GridConstant.get(GridConstantType.smallno);//id
            dg1.Columns[(int)Purchase.dgOrder.cost].Width = GridConstant.get(GridConstantType.smallno);//id
            dg1.Columns[(int)Purchase.dgOrder.quantity].Width = GridConstant.get(GridConstantType.smallno);//id
            dg1.Columns[(int)Purchase.dgOrder.date].Width = GridConstant.get(GridConstantType.date);
            dg1.Columns[(int)Purchase.dgOrder.cost].ReadOnly = true;

            dg1.Columns[(int)Purchase.dgOrder.producttype_id].Visible = false;//
            dg1.Columns[(int)Purchase.dgOrder.productid].Visible = false;//GridConstant.get(GridConstantType.smallid);//id

        }
        private void setDGV(int row, Purchase.dgOrder column, Object value)
        {            
            dg1.Rows[row].Cells[(int)column].Value = value;
        }
        #endregion

    }
}
