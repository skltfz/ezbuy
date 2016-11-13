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
    public partial class Rate : Form
    {
        public Rate()
        {
            InitializeComponent();
        }

        private void hkd_B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cny_B.Text = bi.ConvertMoney(Convert.ToDecimal(hkd_B.Text), Currency.HKD).ToString();
            }
            catch (Exception ex)
            { }

        }

        private void cny_B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hkd_B.Text = bi.ConvertMoney(Convert.ToDecimal(cny_B.Text),Currency.CNY).ToString();
            }
            catch (Exception ex)
            { }
        }

        private void kg_B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(kg_B.Text) > 1)
                {
                    kgcost_B.Text = (12 + ((Convert.ToDouble(kg_B.Text) - 1 )* 8)).ToString();
                }
                else
                {
                    kgcost_B.Text = (Convert.ToDouble(kg_B.Text) * 12).ToString();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
