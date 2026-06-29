using easyBAL;
using easyDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormSecondScreen : Form
    {
        public FormSecondScreen()
        {
            InitializeComponent();
        }

        public void AddItemToGrid(ItemModel item)
        {
            if (item.ShowSinhalaName == false)
            {
                dgView.Columns["ItemNameSinhala"].Visible = false;
            }
            dgView.Rows.Add(item.ItemCode, item.ItemName, item.ItemNameSinhala, item.Qty, item.Price, item.Amount, item.Discount,
            item.NetAmount, item.FreeIssue, item.Warranty, item.SerialNo, item.OurPrice, item.Rtn, item.ShowSinhalaName);
        }

        public void RemoveItemByItemCode(string itemCode)
        {
            foreach (DataGridViewRow row in dgView.Rows)
            {
                if (row.Cells["ItemCode"].Value.ToString() == itemCode)
                {
                    dgView.Rows.Remove(row);
                    break;
                }
            }
        }

        public void UpdateTotals(decimal subTotal, decimal itemDisc, decimal grossTotal, decimal returnTotal, decimal netTotal, decimal receivable, decimal totDisc, decimal vat, decimal cash, decimal change)
        {
            lblSubTotal.Text = subTotal.ToString("0.00");
            lblItemDiscount.Text = itemDisc.ToString("0.00");
            lblGrossTot.Text = grossTotal.ToString("0.00");
            textBoxReturn.Text = returnTotal.ToString("0.00");
            lblNetTotal.Text = netTotal.ToString("0.00");
            textBoxReceivable.Text = receivable.ToString("0.00");
            txtTotDiscRate.Text = receivable.ToString("0.00");
            textBoxVAT.Text = vat.ToString("0.00");
            lblCashTender.Text = cash.ToString("0.00");
            lblChange.Text = change.ToString("0.00");
        }

        public void clearAll()
        {
            dgView.Rows.Clear();
            lblSubTotal.Text = "0.00";
            lblItemDiscount.Text = "0.00";
            lblGrossTot.Text = "0.00";
            textBoxReturn.Text = "0.00";
            lblNetTotal.Text = "0.00";
            textBoxReceivable.Text = "0.00";
            txtTotDiscRate.Text = "0.00";
            textBoxVAT.Text = "0.00";
            lblCashTender.Text = "0.00";
            lblChange.Text = "0.00";
        }

        private void FormSecondScreen_Load(object sender, EventArgs e)
        {
            fillCompanyInfo();
        }

        private void fillCompanyInfo()
        {
            try
            {
                BALUser objUser = new BALUser();
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveCompanyInfo(objUser);
                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objUser.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        label1.Text = (values[1].ToString());
                        byte[] data = (byte[])(values[6]);
                        MemoryStream ms = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(ms);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
