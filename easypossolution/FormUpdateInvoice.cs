using easyBAL;
using easyDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormUpdateInvoice : Form
    {
        public FormUpdateInvoice()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            textBoxCustomer.Clear();
            lblGrossTot.Text = "0.00";
            textBoxTotDiscPerc.Text = "0";
            txtTotDiscRate.Text = "0.00";
            textBoxChargesPer.Text = "0";
            textBoxChargesAmount.Text = "0.00";
            lblNetTotal.Text = "0.00";
        }

        private void fillBillData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassSOBAL objBAL = new ClassSOBAL();
                objBAL.BillNo = Convert.ToInt32(textBoxBillNo.Text);
                ClassSODAL objDAL = new ClassSODAL();
                objBAL.DtDataSet = objDAL.retreiveBillDataForUpdate(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxCustomer.Text = (values[2].ToString().Trim());
                        lblGrossTot.Text = (values[3].ToString().Trim());
                        txtTotDiscRate.Text = (values[4].ToString().Trim());
                        textBoxChargesAmount.Text = (values[5].ToString().Trim());
                        lblNetTotal.Text = (values[6].ToString().Trim());

                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetNetAmount()
        {
            try
            {
                if (Convert.ToDecimal(textBoxTotDiscPerc.Text) > 0)
                {
                    txtTotDiscRate.Text = (Convert.ToDecimal(lblGrossTot.Text) * (Convert.ToDecimal(textBoxTotDiscPerc.Text) / 100)).ToString("0.00");
                }
                if (Convert.ToDecimal(textBoxChargesPer.Text) > 0)
                {
                    textBoxChargesAmount.Text = (Convert.ToDecimal(lblGrossTot.Text) * (Convert.ToDecimal(textBoxChargesPer.Text) / 100)).ToString("0.00");
                }

                lblNetTotal.Text = ((Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)) + Convert.ToDecimal(textBoxChargesAmount.Text)).ToString("0.00");

            }
            catch
            {
            }
        }


        private void textBoxBillNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBillNo.Text != "")
            {
                Reset();
                fillBillData();
            }
            else if (textBoxBillNo.Text == "")
            {
                Reset();
            }
        }

        private void textBoxTotDiscPerc_TextChanged(object sender, EventArgs e)
        {
            SetNetAmount();
        }

        private void txtTotDiscRate_TextChanged(object sender, EventArgs e)
        {
            SetNetAmount();
        }

        private void textBoxChargesPer_TextChanged(object sender, EventArgs e)
        {
            SetNetAmount();
        }

        private void textBoxChargesAmount_TextChanged(object sender, EventArgs e)
        {
            SetNetAmount();
        }

        private void simpleButtonReturn_Click(object sender, EventArgs e)
        {
            if (textBoxBillNo.Text != "")
            {
                insertDisc();
            }
            
        }

        private void insertDisc()
        {
            try
            {
                ClassInvoiceBAL objBAL = new ClassInvoiceBAL();
                objBAL.SOHDId = Convert.ToInt32(textBoxBillNo.Text);
                objBAL.SOGrossTotal = Convert.ToDecimal(lblGrossTot.Text);
                objBAL.SODiscount = Convert.ToDecimal(txtTotDiscRate.Text);
                objBAL.Charges = Convert.ToDecimal(textBoxChargesAmount.Text);
                objBAL.SONetTotal = Convert.ToDecimal(lblNetTotal.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);

                ClassInvoiveDAL objDAL = new ClassInvoiveDAL();
                int count = objDAL.UpdateInvoice(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Invoice Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
