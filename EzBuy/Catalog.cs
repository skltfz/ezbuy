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
    public partial class Catalog : Form
    {
        public static String SelectedCategory;
        private Boolean apply = false;
        private int rowNo = -1;
        private db db = new EzBuy.db();
        public Catalog(Boolean apply)
        {
            InitializeComponent();
            this.apply = apply;
        }

        private void category_Load(object sender, EventArgs e)
        {
            reload();            
        }
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // dataGridView1.Rows[e.RowIndex].Cells[0].Value = 44;
                String id = dg1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String name = dg1.Rows[e.RowIndex].Cells[1].Value.ToString();
                switch (id)
                {
                    case ""://create
                        if (!name.Equals("") && !category_dal.contain_byName(db, name))
                           category_dal.insert_record(db,category_dal.get_max_id(db).ToString(), name);
                        dg1.Rows[e.RowIndex].Cells[0].Value = category_dal.get_id(db, name);
                        break;
                    default:
                        if (!dg1_contain_byID(id))
                        {
                            if (category_dal.contain_byID(db, id))
                                category_dal.update_record(db, id, name);
                            else
                                category_dal.insert_record(db, id, name);
                        }
                        else
                            MessageBox.Show("ID is already exist.");
                        break;
                }
            }
            catch(Exception ex)
            {
                writelog.writeentry(1, ex.Message);
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
        private void refresh_btn_Click(object sender, EventArgs e)
        {
            reload();
        }       

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowNo = e.RowIndex;
            dg1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dg1.Rows[e.RowIndex].Selected = true;
            if (apply)
            {
                Catalog.SelectedCategory = dg1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (rowNo >= 0)
            {
                String firstColumn = dg1.Rows[rowNo].Cells[0].Value.ToString();
                String secondColumn = dg1.Rows[rowNo].Cells[1].Value.ToString();
                if (e.KeyCode == Keys.Delete && dg1.Rows[rowNo].Selected)
                {
                    category_dal.delete_record(db, firstColumn);
                    reload();
                }
            }
        }

        private void reload()
        {
            dg1.DataSource = category_dal.select_table(db);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (!search.Text.Equals(""))
                (dg1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Name] LIKE '%{0}%'", search.Text);// + " OR " + string.Format("[Order ID] LIKE '%{0}%'", search.Text);
            else
                (dg1.DataSource as DataTable).DefaultView.RowFilter = "";

        }
    }
}
