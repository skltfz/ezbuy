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
    public partial class ProductManager : Form
    {
        private int rowNo = -1;
        private int rowNo_type = -1;
        private db db = new EzBuy.db();
        public static String SelectedProduct;
        public static String SelectedProductType;
        public static int SelectedProductID;
        public static int SelectedProductTypeID;
        private int apply = 0;
        public ProductManager(int apply)
        {
            InitializeComponent();
            this.apply = apply;
        }
        private void category_Load(object sender, EventArgs e)
        {
            reload();                       
        }              
        private void refresh_btn_Click(object sender, EventArgs e)
        {
            reload();
        }
        private void query_B_TextChanged(object sender, EventArgs e)
        {
            if (!search.Text.Equals(""))
                (dg1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Name] LIKE '%{0}%'", query_B.Text);// + " OR " + string.Format("[Order ID] LIKE '%{0}%'", search.Text);
            else
                (dg1.DataSource as DataTable).DefaultView.RowFilter = "";
        }
        #region grid 1
        private void dg1_pointToRowByID(int id)
        {
            foreach (DataGridViewRow row in dg1.Rows)
            {
                if (row.Cells[(int)Product.dgOrder.product_id].Value != null)
                {
                    if (row.Cells[(int)Product.dgOrder.product_id].Value.ToString().Equals(id.ToString()))
                    {
                        try
                        {
                            dg1.SelectedRows.Clear();
                        }
                        catch (Exception ex) { }
                        row.Selected = true;
                        setProduct((int)row.Cells[(int)Product.dgOrder.product_id].Value, (string)row.Cells[(int)Product.dgOrder.product_name].Value);
                        return;
                    }
                }
            }
        }
        private void dg1_pointToRowByName(String name)
        {
            foreach (DataGridViewRow row in dg1.Rows)
            {
                if (row.Cells[(int)Product.dgOrder.product_id].Value != null)
                {
                    if (row.Cells[(int)Product.dgOrder.product_name].Value.ToString().Equals(name))
                    {
                        try
                        {
                            dg1.SelectedRows.Clear();
                        }
                        catch (Exception ex) { }
                        dg1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                        row.Selected = true;
                        setProduct((int)row.Cells[(int)Product.dgOrder.product_id].Value, name);
                        return;
                    }
                }
            }
        }
        private Boolean dg1_contain_byID(String id)
        {
            int count = 0;
            foreach (DataGridViewRow row in dg1.Rows)
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
        private void dg1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // dataGridView1.Rows[e.RowIndex].Cells[0].Value = 44;
                String id = dg1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String name = dg1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String desc = dg1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String category = dg1.Rows[e.RowIndex].Cells[3].Value.ToString();
                int category_id = category_dal.get_id(db, category);
                switch (id)
                {
                    case ""://create
                        if (!name.Equals("") && !product_dal.contain_byName(db, name))
                        {
                            product_dal.insert_record_withID(db, product_dal.get_max_id(db).ToString(), name, desc, category_id);
                            dg1.Rows[e.RowIndex].Cells[0].Value = product_dal.get_id(db, name);
                        }
                        else
                        {
                            MessageBox.Show("Name is existed!Please add the product type");
                            reload();
                            dg1_pointToRowByName(name);
                            loaddg_type(SelectedProductID);
                        }
                        break;
                    default:
                        if (!dg1_contain_byID(id))
                        {
                            if (product_dal.contain_byID(db, id))
                                product_dal.update_record(db, id, name, desc, category_id);
                            else
                                product_dal.insert_record_withID(db, id, name, desc, category_id);
                        }
                        else
                            MessageBox.Show("ID is contained in the database already.");
                        break;
                }
            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
            }
        }
        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                using (var form = new Catalog(true))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        dg1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Catalog.SelectedCategory;
                        String id = dg1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        String name = dg1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        String desc = dg1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        String category = dg1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        int category_id = category_dal.get_id(db, category);
                        if (!id.Equals("") && !name.Equals(""))
                        {
                            product_dal.update_record(db, id, name, desc, category_id);
                        }
                        else if (!name.Equals(""))
                        {
                            product_dal.insert_record_withID(db, product_dal.get_max_id(db).ToString(), name, desc, category_id);
                        }
                    }
                }
            }
        }
        private void dg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (rowNo >= 0)
            {
                String firstColumn = dg1.Rows[rowNo].Cells[0].Value.ToString();
                String secondColumn = dg1.Rows[rowNo].Cells[1].Value.ToString();
                if (e.KeyCode == Keys.Delete && dg1.Rows[rowNo].Selected)
                {
                    DataTable error = product_dal.delete_record(db, firstColumn);
                    if (error.Rows.Count > 0)
                    {
                        MessageBox.Show(error.Rows[0][0].ToString());
                    }

                    reload();
                }
            }
        }
        private void dg1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                setProduct((int)dg1.Rows[e.RowIndex].Cells[(int)Product.dgOrder.product_id].Value, dg1.Rows[e.RowIndex].Cells[(int)Product.dgOrder.product_name].Value.ToString());
            }

            catch (Exception EX)
            { return; }
            loaddg_type(ProductManager.SelectedProductID);
            try
            {
                setProductType((int)dg_type.Rows[0].Cells[(int)Producttype.dgOrder.id].Value, (String)dg_type.Rows[0].Cells[(int)Producttype.dgOrder.name].Value);
            }
            catch(Exception ex)
            {

            }
            rowNo = e.RowIndex;
            dg1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dg1.Rows[e.RowIndex].Selected = true;
            if (apply>0)
            {
                //if(dg_type.Rows.Count==2)
                //{
                //    ProductManager.SelectedProductTypeID = (int)dg_type.Rows[0].Cells[(int)Producttype.dgOrder.id].Value;
                //    ProductManager.SelectedProductType = (String)dg_type.Rows[0].Cells[(int)Producttype.dgOrder.name].Value;
                //    this.DialogResult = DialogResult.OK;
                //    this.Close();

                //}
                apply = 2;
            }
        }
        #endregion
        #region grid(type)
        private Boolean dg_type_contain_byID(String id)
        {
            int count = 0;
            foreach (DataGridViewRow row in dg_type.Rows)
            {
                if (row.Cells[(int)Producttype.dgOrder.id].Value != null)
                {
                    if (row.Cells[(int)Producttype.dgOrder.id].Value.ToString().Equals(id))
                        count++;
                    if (count > 1) return true;
                }
            }
            return false;
        }
        
        private void dg_type_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // dataGridView1.Rows[e.RowIndex].Cells[0].Value = 44;
                Object product_id = SelectedProductID;
                Object id = dg_type.Rows[e.RowIndex].Cells[(int)Producttype.dgOrder.id].Value;
                Object name = dg_type.Rows[e.RowIndex].Cells[(int)Producttype.dgOrder.name].Value;
                Object remarks = dg_type.Rows[e.RowIndex].Cells[(int)Producttype.dgOrder.remarks].Value;
                if (util.DataGridView_IsCellEmpty(id))
                {
                    if (!util.DataGridView_IsCellEmpty(name) && !producttype_dal.contain_byName(db,product_id, name))
                    {
                        int generatedid = producttype_dal.get_max_id(db, product_id);
                        producttype_dal.insert_record(db, product_id, generatedid.ToString(), name, remarks);
                        dg_type.Rows[e.RowIndex].Cells[(int)Producttype.dgOrder.id].Value = generatedid;
                    }
                }
                else
                {
                    if(!dg_type_contain_byID(id.ToString()))
                    {
                        if(producttype_dal.contain_byID(db,product_id,id.ToString()))
                            producttype_dal.update_record(db, product_id, id, name, remarks);
                        else
                            producttype_dal.insert_record(db, product_id, id, name, remarks);
                    }
                    else
                    {
                        dg_type.Rows[e.RowIndex].Cells[(int)Producttype.dgOrder.id].Value = DBNull.Value;
                       MessageBox.Show("已存在同樣ID, 請改另一個");
                    }
                }

                /*if (!dg1_contain_byID(id))
                {
                    if (product_dal.contain_byID(db, id))
                        product_dal.update_record(db, id, name, desc, category_id);
                    else
                        product_dal.insert_record_withID(db, id, name, desc, category_id);
                }
                else
                    MessageBox.Show("ID is contained in the database already.");*/
                
            }
            catch (Exception ex)
            {
                writelog.writeentry(1, ex.Message);
            }
        }
        private void dg_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (rowNo_type >= 0)
            {
                int product_id = SelectedProductID;
                try
                {
                    int id = (int)dg_type.Rows[rowNo_type].Cells[(int)Producttype.dgOrder.id].Value;
                    if (e.KeyCode == Keys.Delete && dg_type.Rows[rowNo_type].Selected)
                    {
                        DataTable error = producttype_dal.delete_record(db, product_id, id);
                        if (error.Rows.Count > 0)
                        {
                            MessageBox.Show(error.Rows[0][0].ToString());
                        }
                        reload();
                    }
                }
                catch(Exception ex) { }
            }
        }
        private void dg_type_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                setProductType((int)dg_type.Rows[e.RowIndex].Cells[(int)Producttype.dgOrder.id].Value, (String)dg_type.Rows[e.RowIndex].Cells[(int)Producttype.dgOrder.name].Value);
            }

            catch (Exception ex) { return; }
            rowNo_type = e.RowIndex;
            dg_type.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dg_type.Rows[e.RowIndex].Selected = true;
            if (apply>1) //selected option is done
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion
        #region functions
        private void constructReadOnly()
        {
            readonly_B.Text = SelectedProduct + "_"+SelectedProductType;
        }
        private void setProduct(int id,string name)
        {
            ProductManager.SelectedProductID = id;
            ProductManager.SelectedProduct = name;            
            constructReadOnly();
        }
        private void setProductType(int id,string name)
        {
            ProductManager.SelectedProductTypeID = id;
            ProductManager.SelectedProductType = name;
            constructReadOnly();
        }
        private void reload()
        {
            dg_count.DataSource = product_dal.select_table_by_category(db);
            dg1.DataSource = product_dal.select_table(db);
            dg1.Columns[(int)Product.dgOrder.product_desc].Width = GridConstant.get(GridConstantType.remarks);
            dg1.Columns[(int)Product.dgOrder.product_id].Width = GridConstant.get(GridConstantType.smallid);
            if (dg1.Rows.Count > 0)
            {
                if (SelectedProductID > 0)
                {
                    dg1_pointToRowByID(SelectedProductID);
                    loaddg_type(SelectedProductID);
                   
                }
                else
                {
                    setProduct((int)dg1.Rows[0].Cells[(int)Product.dgOrder.product_id].Value, (String)dg1.Rows[0].Cells[(int)Product.dgOrder.product_name].Value);
                     //         dg1.SelectedRows.Clear();
                    dg1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    dg1.Rows[0].Selected = true;
                    loaddg_type(SelectedProductID);
                }
            }
        }
        private void loaddg_type(object id)
        {
            dg_type.DataSource = producttype_dal.select_table(db,id);
        }
        #endregion

       
    }
}
