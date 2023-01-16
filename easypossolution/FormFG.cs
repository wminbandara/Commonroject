﻿using easyBAL;
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
    public partial class FormFG : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        string FYear, ID;

        bool loadStatus, insertDTStatus, newStatus, poLoadStatus, NewPurchase, AddtoBarcode;
        public int POID = 0;
        public decimal CreditPay = 0;

        #endregion

        public FormFG()
        {
            InitializeComponent();
        }

        #region Methods

        public void formLoad()
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();

                comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedIndex = 0;

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ItemCodeKeyDown()
        {
            try
            {

                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                //objPOBAL.Wharehouse = "Wharehouse1";
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxItemName.Text = (values[1].ToString().Trim());
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxItemId.Text = (values[7].ToString().Trim());
                        textBoxQty.Text = "0";
                    }
                    textBoxQty.Select();
                }
                else
                {
                    textBoxItemCode.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void resettoNew()
        {
            newStatus = true;
            formLoad();
            Reset();
            newStatus = false;
        }

        public void Reset()
        {
            textBoxPOID.Clear();
            textBoxRemarks.Clear();
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            textBoxQty.Text = "0";
            textBoxNetAmount.Text = "0.00";
            textBoxTotGrosse.Text = "0.00";
            ButtonSave.Enabled = true;
            dgView.Rows.Clear();
            textBoxUnitCostPrice.Text = "0.00";
        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            textBoxQty.Text = "0";
            textBoxNetAmount.Text = "0.00";
            textBoxUnitCostPrice.Text = "0.00";
        }

        private void resetItemCodeData()
        {
            textBoxItemName.Clear();
        }

        private void insertPIHD()
        {
            try
            {
                NewPurchase = true;
                objBAL = new ClassPOBAL();
                objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());

                objDAL = new ClassPODAL();
                string count = objDAL.InsertNewFGHD(objBAL);
                textBoxPOID.Text = count.ToString();

                if (count != "")
                {
                    insertPIDT();
                }
                NewPurchase = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPIDT()
        {
            try
            {
                if (dgView.Rows.Count > 0)
                {
                    for (int i = 0; i < dgView.Rows.Count; i++)
                    {

                        objBAL = new ClassPOBAL();
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                        objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                        objBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                        objBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                        objBAL.PurchaseQty = Convert.ToDecimal(dgView.Rows[i].Cells["PurchaseQty"].Value);
                        objBAL.PurchasePrice = Convert.ToDecimal(dgView.Rows[i].Cells["PurchasePrice"].Value);
                        objBAL.SellingPrice = Convert.ToDecimal(dgView.Rows[i].Cells["SellingPrice"].Value);
                        objBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objDAL = new ClassPODAL();
                        int count = objDAL.InsertFGDT(objBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }


                    }


                }

                if (insertDTStatus == true)
                {
                    resetDetail();
                    MessageBox.Show("FG Details Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonSave.Enabled = false;
                    Reset();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemNetValue()
        {
            textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
        }

        void CalculateTotal()
        {
            try
            {

                decimal GrossTot = 0;
                decimal RtnTot = 0;

                int i = dgView.RowCount;

                if (dgView.Rows.Count > 0)
                {
                    for (int a = 0; a < i; a++)
                    {
                        try
                        {
                            GrossTot += Convert.ToDecimal(dgView.Rows[a].Cells["NetAmount"].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                textBoxTotGrosse.Text = GrossTot.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AddtoGrid()
        {
            try
            {
                int n = dgView.Rows.Add();

                dgView.Rows[n].Cells["ItemsId"].Value = textBoxItemId.Text;
                dgView.Rows[n].Cells["ItemCode"].Value = textBoxItemCode.Text;
                dgView.Rows[n].Cells["PurchaseQty"].Value = textBoxQty.Text;
                dgView.Rows[n].Cells["PurchasePrice"].Value = textBoxUnitCostPrice.Text;
                dgView.Rows[n].Cells["SellingPrice"].Value = textBoxSellingPrice.Text;
                dgView.Rows[n].Cells["NetAmount"].Value = textBoxNetAmount.Text;
                dgView.Rows[n].Cells["ItemName"].Value = textBoxItemName.Text;


                dgView.FirstDisplayedScrollingRowIndex = n;
                dgView.CurrentCell = dgView.Rows[n].Cells[0];
                dgView.Rows[n].Selected = true;

                textBoxItemId.Text = "0";
                textBoxItemCode.Text = "";
                textBoxQty.Text = "0";
                textBoxUnitCostPrice.Text = "0";
                textBoxNetAmount.Text = "0.00";
                textBoxItemName.Text = "";
                textBoxUnitCostPrice.Text = "0.00";
                CalculateTotal();
                textBoxItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void RemoveItem()
        {
            try
            {
                if (dgView.SelectedRows.Count > 0)
                {
                    dgView.Rows.RemoveAt(dgView.SelectedRows[0].Index);
                    CalculateTotal();
                }
                else
                {
                    MessageBox.Show("Select one item to remove!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dgView.RowCount < 1)
            {
                MessageBox.Show("Please enter item to before you can save this record.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxItemCode.Focus();
                return;
            }
            else
            {
                insertPIHD();
            }
        }

        private void FormFG_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            resetDetail();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddtoGrid();
        }

        private void ButtonDeleteLine_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RemoveItem();
            }
        }

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    ClassPODAL objPODAL = new ClassPODAL();
                    objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    {
                        List<ArrayList> newval = new List<ArrayList>();
                        foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[1].Rows)
                        {
                            ArrayList values = new ArrayList();
                            values.Clear();
                            foreach (object value in dRow.ItemArray)
                                values.Add(value);
                            newval.Add(values);
                            textBoxItemName.Text = (values[1].ToString().Trim());
                            textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                            textBoxSellingPrice.Text = (values[5].ToString().Trim());
                            textBoxItemId.Text = (values[7].ToString().Trim());
                            textBoxQty.Text = "0";
                        }
                        textBoxQty.Select();
                    }
                    else
                    {
                        textBoxItemCode.Select();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxUnitCostPrice.Select();
            }
        }

        private void textBoxUnitCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxSellingPrice.Select();
            }
        }

        private void textBoxSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAdd.Select();
            }
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
            }
            catch
            {
            }
        }

        private void textBoxUnitCostPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
            }
            catch
            {
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            resettoNew();
        }

        private void FormFG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm12 = new FormItemSearch();
                frm12.frm12 = this;
                frm12.form = 12;
                frm12.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                frm12.lblUser.Text = lblUser.Text.Trim();
                frm12.lblUserId.Text = lblUserId.Text;
                frm12.ShowDialog(this);
            }
        }
    }
}
