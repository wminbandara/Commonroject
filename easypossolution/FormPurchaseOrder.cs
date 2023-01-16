using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
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
    public partial class FormPurchaseOrder : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        string FYear, ID;

        bool loadStatus, insertDTStatus;
        public bool existPOStatus = false;
        int row = 0;

        #endregion

        #region Constructor
        public FormPurchaseOrder()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        public void Reset()
        {
            textBoxPOID.Clear();
            textBoxPONo.Clear();
            dateTimePickerPODate.Value = DateTime.Today;
            dateTimePickerChqExpDate.Value = DateTime.Today;
            comboBoxSupplier.SelectedIndex = -1;
            textBoxInvoiceNo.Clear();
            comboBoxPayMode.SelectedIndex = -1;
            textBoxAddress.Clear();
            textBoxRemarks.Clear();
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxLocation.Clear();
            comboBoxBank.Text = "";
            textBoxChequeNo.Text = "";
            comboBoxBank.Enabled = false;
            textBoxChequeNo.Enabled = false;
            dateTimePickerChqExpDate.Enabled = false;
            comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxGross.Text = "0.00";
            textBoxDiscount.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxTotGrosse.Text = "0.00";
            textBoxTotDiscount.Text = "0.00";
            textBoxTotNet.Text = "0.00";
            textBoxCash.Text = "0.00";
            textBoxBalance.Text = "0.00";
            dataGridView1.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Visible = true;
            row = 0;
            dataGridView1.Visible = false;
            ButtonSave.Enabled = true;
            existPOStatus = false;

        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxUnit.Text = "";
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxLocation.Clear();
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxGross.Text = "0.00";
            textBoxDiscount.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            dataGridView1.Visible = false;
            dataGridView3.Visible = true;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            //dataGridView3.DataSource = null;
            //dataGridView3.Rows.Clear();
            //row = 0;
        }

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemName.Clear();
            textBoxLocation.Clear();
            comboBoxUnit.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxMinQty.Text = "0.00";
        }

        private void insertSupplierCheque()
        {
            if (comboBoxPayMode.Text == "Cheque" && existPOStatus == false)
            {
                bool isValid = ValidateBank() && ValidateChqNo();
                if (isValid)
                {
                    try
                    {
                        objBAL = new ClassPOBAL();
                        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                        objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                        objBAL.ChequeBank = comboBoxBank.Text.Trim();
                        objBAL.ChequeNo = textBoxChequeNo.Text.Trim();
                        objBAL.ChequeAmount = Convert.ToDecimal(textBoxBalance.Text);
                        objBAL.ChequeExpDate = dateTimePickerChqExpDate.Value;
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objDAL = new ClassPODAL();
                        int count = objDAL.InsertSupplierCheque(objBAL);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        private void insertSupplierCredit()
        {
            if (comboBoxPayMode.Text == "Credit" && existPOStatus == false)
            {
                try
                {
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                    objBAL.CreditAmount = Convert.ToDecimal(textBoxBalance.Text);
                    objBAL.BalanceAmount = Convert.ToDecimal(textBoxBalance.Text);
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objDAL = new ClassPODAL();
                    int count = objDAL.InsertSupplierCredit(objBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        //private void insertPOHD()
        //{
        //    try
        //    {
        //        objBAL = new ClassPOBAL();
        //        objBAL.POHDId = 0;
        //        objBAL.PONo = textBoxPONo.Text.Trim();
        //        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
        //        objBAL.PurchaseDate = dateTimePickerPODate.Value;
        //        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
        //        objBAL.InvoiceNo = textBoxInvoiceNo.Text.Trim();
        //        objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
        //        objBAL.PODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
        //        objBAL.PONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
        //        objBAL.POCash = Convert.ToDecimal(textBoxCash.Text);
        //        objBAL.POBalance = Convert.ToDecimal(textBoxBalance.Text);
        //        objBAL.Remarks = textBoxRemarks.Text.Trim();
        //        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
        //        objDAL = new ClassPODAL();
        //        int count = objDAL.InsertPOHD(objBAL);
        //        if (count != 0)
        //        {
        //            insertPODT();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void insertPOHD()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.POHDId = 0;
                objBAL.PONo = textBoxPONo.Text.Trim();
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objBAL.PurchaseDate = dateTimePickerPODate.Value;
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objBAL.InvoiceNo = textBoxInvoiceNo.Text.Trim();
                objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.PODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
                objBAL.PONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
                objBAL.POCash = Convert.ToDecimal(textBoxCash.Text);
                objBAL.POBalance = Convert.ToDecimal(textBoxBalance.Text);
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassPODAL();
                int count = objDAL.InsertPOHD(objBAL);
                if (count != 0)
                {
                    insertPODT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPODT()
        {
            try
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    objBAL = new ClassPOBAL();
                    objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                    objBAL.ItemCode = dataGridView3["ItemCode", i].Value.ToString();
                    objBAL.ItemCatId = Convert.ToInt32(dataGridView3["ItemCatId", i].Value.ToString());
                    objBAL.ItemName = dataGridView3["ItemName", i].Value.ToString();
                    objBAL.ItemLocation = dataGridView3["ItemLocation", i].Value.ToString();
                    objBAL.PurchaseQty = Convert.ToDecimal(dataGridView3["PurchaseQty", i].Value.ToString());
                    objBAL.MinQty = Convert.ToDecimal(dataGridView3["MinQty", i].Value.ToString());
                    objBAL.PurchasePrice = Convert.ToDecimal(dataGridView3["PurchasePrice", i].Value.ToString());
                    objBAL.Discount = Convert.ToDecimal(dataGridView3["Discount", i].Value.ToString());
                    objBAL.NetAmount = Convert.ToDecimal(dataGridView3["NetAmount", i].Value.ToString());
                    objBAL.SellingPrice = Convert.ToDecimal(dataGridView3["SellingPrice", i].Value.ToString());
                    objBAL.ItemUnit = dataGridView3["ItemUnit", i].Value.ToString();
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objBAL.PurchaseDate = dateTimePickerPODate.Value;
                    objDAL = new ClassPODAL();
                    int count = objDAL.InsertPODT(objBAL);
                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }

                }

                if (insertDTStatus == true)
                {
                    resetDetail();
                    fillPODtRec();
                    //fillItemTotalBalanceValue();
                    insertSupplierCheque();
                    insertSupplierCredit();
                    MessageBox.Show("Purchasing Details Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonSave.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void updatePOHD()
        //{
        //    try
        //    {
        //        objBAL = new ClassPOBAL();
        //        objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
        //        objBAL.PONo = textBoxPONo.Text.Trim();
        //        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
        //        objBAL.PurchaseDate = dateTimePickerPODate.Value;
        //        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
        //        objBAL.InvoiceNo = textBoxInvoiceNo.Text.Trim();
        //        objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
        //        objBAL.PODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
        //        objBAL.PONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
        //        objBAL.POCash = Convert.ToDecimal(textBoxCash.Text);
        //        objBAL.POBalance = Convert.ToDecimal(textBoxBalance.Text);
        //        objBAL.Remarks = textBoxRemarks.Text.Trim();
        //        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
        //        objDAL = new ClassPODAL();
        //        int count = objDAL.InsertPOHD(objBAL);
        //        if (count != 0)
        //        {
        //            insertPODT();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void insertPODT()
        //{
        //    try
        //    {
        //        objBAL = new ClassPOBAL();
        //        objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
        //        objBAL.ItemCode = textBoxItemCode.Text.Trim();
        //        objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
        //        objBAL.ItemName = textBoxItemName.Text.Trim();
        //        objBAL.ItemLocation = textBoxLocation.Text.Trim();
        //        objBAL.PurchaseQty = Convert.ToDecimal(textBoxQty.Text);
        //        objBAL.MinQty = Convert.ToDecimal(textBoxMinQty.Text);
        //        objBAL.PurchasePrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
        //        objBAL.Discount = Convert.ToDecimal(textBoxDiscount.Text);
        //        objBAL.NetAmount = Convert.ToDecimal(textBoxNetAmount.Text);
        //        objBAL.SellingPrice = Convert.ToDecimal(textBoxSellingPrice.Text);
        //        objBAL.ItemUnit = comboBoxUnit.Text.Trim();
        //        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
        //        objDAL = new ClassPODAL();
        //        int count = objDAL.InsertPODT(objBAL);
        //        if (count != 0)
        //        {
        //            MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            resetDetail();
        //            fillPODtRec();
        //            fillItemTotalBalanceValue();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void fillGridTempDTRec()
        {
            try
            {
                dataGridView1.Visible = false;
                dataGridView3.Rows.Add();
                dataGridView3.Rows[row].Cells[0].Value = textBoxItemCode.Text.Trim();
                dataGridView3.Rows[row].Cells[1].Value = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                dataGridView3.Rows[row].Cells[2].Value = comboBoxItemCategory.Text;
                dataGridView3.Rows[row].Cells[3].Value = textBoxItemName.Text.Trim();
                dataGridView3.Rows[row].Cells[4].Value = comboBoxUnit.Text.Trim();
                dataGridView3.Rows[row].Cells[5].Value = textBoxLocation.Text.Trim();
                dataGridView3.Rows[row].Cells[6].Value = textBoxQty.Text;
                dataGridView3.Rows[row].Cells[7].Value = textBoxMinQty.Text;
                dataGridView3.Rows[row].Cells[8].Value = textBoxUnitCostPrice.Text;
                dataGridView3.Rows[row].Cells[9].Value = textBoxSellingPrice.Text;
                dataGridView3.Rows[row].Cells[10].Value = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString(); ;
                dataGridView3.Rows[row].Cells[11].Value = textBoxDiscount.Text;
                dataGridView3.Rows[row].Cells[12].Value = ((Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)) - Convert.ToDecimal(textBoxDiscount.Text)).ToString();
                row++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void updatePOHDOnly()
        //{
        //    try
        //    {
        //        objBAL = new ClassPOBAL();
        //        objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
        //        objBAL.PONo = textBoxPONo.Text.Trim();
        //        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
        //        objBAL.PurchaseDate = dateTimePickerPODate.Value;
        //        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
        //        objBAL.InvoiceNo = textBoxInvoiceNo.Text.Trim();
        //        objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
        //        objBAL.PODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
        //        objBAL.PONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
        //        objBAL.POCash = Convert.ToDecimal(textBoxCash.Text);
        //        objBAL.POBalance = Convert.ToDecimal(textBoxBalance.Text);
        //        objBAL.Remarks = textBoxRemarks.Text.Trim();
        //        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
        //        objDAL = new ClassPODAL();
        //        int count = objDAL.InsertPOHD(objBAL);
        //        if (count != 0)
        //        {
        //            insertSupplierCheque();
        //            insertSupplierCredit();
        //            MessageBox.Show("Purchasing Details Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            ButtonSave.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void updatePOHDOnly1()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objBAL.PONo = textBoxPONo.Text.Trim();
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objBAL.PurchaseDate = dateTimePickerPODate.Value;
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objBAL.InvoiceNo = textBoxInvoiceNo.Text.Trim();
                objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.PODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
                objBAL.PONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
                objBAL.POCash = Convert.ToDecimal(textBoxCash.Text);
                objBAL.POBalance = Convert.ToDecimal(textBoxBalance.Text);
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassPODAL();
                int count = objDAL.InsertPOHD(objBAL);
                if (count != 0)
                {
                    insertSupplierCheque();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSumaryToDelete()
        {
            try
            {
                objBAL = new ClassPOBAL();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    objBAL.PODTId = Convert.ToInt32(dataGridView1["PODTId", i].Value.ToString());
                    objBAL.PurchaseQty = Convert.ToDecimal(dataGridView1["PurchaseQty", i].Value.ToString());
                    objDAL = new ClassPODAL();
                    int count = objDAL.UpdateSumaryToDeletePO(objBAL);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletePOHD()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objBAL.BalanceAmount = Convert.ToDecimal(textBoxBalance.Text);
                objDAL = new ClassPODAL();
                int count = objDAL.DeletePOHD(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Record Deleted Successfully.", "Delete Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletePODT()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.PODTId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objBAL.PurchaseQty = Convert.ToDecimal(textBoxQty.Text);
                objDAL = new ClassPODAL();
                int count = objDAL.DeletePODT(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Record Deleted Successfully.", "Delete Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetDetail();
                    fillPODtRec();
                    fillItemTotalBalanceValue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemNetValue()
        {
            textBoxGross.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
            textBoxNetAmount.Text = ((Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)) - Convert.ToDecimal(textBoxDiscount.Text)).ToString("0.00");
        }

        private void fillItemTotalBalanceValue()
        {
            try
            {
                if (dataGridView3.Rows.Count > 0)
                {
                    decimal total = 0;
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        total = Convert.ToDecimal(dataGridView3["NetAmount", i].Value.ToString()) + total;
                    }
                    textBoxTotGrosse.Text = total.ToString();
                    textBoxTotNet.Text = (Convert.ToDecimal(textBoxTotGrosse.Text) - Convert.ToDecimal(textBoxTotDiscount.Text)).ToString("0.00");
                    textBoxBalance.Text = (Convert.ToDecimal(textBoxTotNet.Text) - Convert.ToDecimal(textBoxCash.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillPODtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePOHDIdData(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridView3.Visible = false;
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                    dataGridView1.Columns["PODTId"].Visible = false;
                    dataGridView1.Columns["POHDId"].Visible = false;
                    dataGridView1.Columns["ItemCatId"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["ItemLocation"].Visible = false;
                    dataGridView1.Columns["PurchaseQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["PurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["GrossAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["NetAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.Columns["GrossAmount"].DefaultCellStyle.Format = "0.00";
                    dataGridView1.Columns["NetAmount"].DefaultCellStyle.Format = "0.00";
                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillPOHDIdData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePOHDIdData(objBAL);
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
                        textBoxPONo.Text = (values[0].ToString().Trim());
                        textBoxInvoiceNo.Text = (values[1].ToString().Trim());
                        dateTimePickerPODate.Value = Convert.ToDateTime(values[2].ToString());
                        comboBoxSupplier.SelectedValue = (values[3]);
                        comboBoxPayMode.SelectedValue = (values[4]);
                        comboBoxBank.Text = (values[5].ToString().Trim());
                        textBoxChequeNo.Text = (values[6].ToString().Trim());
                        if (comboBoxBank.Text != "")
                        {
                            dateTimePickerChqExpDate.Value = Convert.ToDateTime(values[7].ToString());
                        }
                        textBoxRemarks.Text = (values[8].ToString().Trim());
                        textBoxTotGrosse.Text = Convert.ToDecimal(values[9].ToString()).ToString("0.00");
                        textBoxTotDiscount.Text = Convert.ToDecimal(values[10].ToString()).ToString("0.00");
                        textBoxTotNet.Text = Convert.ToDecimal(values[11].ToString()).ToString("0.00");
                        textBoxCash.Text = Convert.ToDecimal(values[12].ToString()).ToString("0.00");
                        textBoxBalance.Text = Convert.ToDecimal(values[13].ToString()).ToString("0.00");
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridByCat()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveItemsByCat(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                    //dataGridView2.Columns["ItemLocation"].Visible = false;
                    //dataGridView2.Columns["SellingPrice"].Visible = false;
                    dataGridView2.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridByCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
                objDAL = new ClassPODAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveItemsByCode(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                    //dataGridView2.Columns["ItemLocation"].Visible = false;
                    //dataGridView2.Columns["SellingPrice"].Visible = false;
                    dataGridView2.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridByName()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.ItemName = textBoxSearchName.Text.Trim();
                objDAL = new ClassPODAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveItemsByName(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                    //dataGridView2.Columns["ItemLocation"].Visible = false;
                    //dataGridView2.Columns["SellingPrice"].Visible = false;
                    dataGridView2.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createPONo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePOId(objBAL);
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
                        textBoxPOID.Text = (values[0]).ToString();
                        ID = (Convert.ToInt32(values[0])).ToString("00000");
                    }
                }
                FYear = DateTime.Now.Year.ToString();
                textBoxPONo.Text = ("PO/" + FYear + "/" + ID).ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void FormPurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                comboBoxSupplier.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierId";
                comboBoxSupplier.SelectedIndex = -1;

                comboBoxPayMode.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[1];
                comboBoxPayMode.DisplayMember = "PayMode";
                comboBoxPayMode.ValueMember = "PayModeId";
                comboBoxPayMode.SelectedIndex = -1;

                comboBoxItemCategory.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

                comboBoxCategorySearch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                comboBoxCategorySearch.DisplayMember = "ItemCatName";
                comboBoxCategorySearch.ValueMember = "ItemCatId";
                comboBoxCategorySearch.SelectedIndex = -1;

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxPayMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxItemCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxCategorySearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            resetDetail();
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (loadStatus == false && comboBoxSupplier.SelectedIndex != -1)
                {
                    textBoxAddress.Clear();
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSupplierAddress(objBAL);
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
                            textBoxAddress.Text = (values[0].ToString().Trim());
                            textBoxAddress.Text = (values[0].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid =  ValidatePaymode() && ValidateItemCode() &&
                            ValidateItemName() &&
                            ValidateIteCategory() &&
                            ValidateQty() &&
                            ValidateMinQty() &&
                            ValidateCostPrice() &&
                            ValidateSellPrice() &&
                            ValidateDiscount();
            if (isValid)
            {
                if (textBoxPOID.Text == "")
                {
                    createPONo();
                }
                fillGridTempDTRec();
                fillItemTotalBalanceValue();
                resetDetail();
            }

        }

        private void textBoxQty_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValue();
        }

        private void textBoxUnitCostPrice_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValue();
        }

        private void textBoxDiscount_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValue();
        }

        private void ButtonDeleteLine_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this Purchase Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                errorProvider1.Clear();
                DeletePODT();
                updatePOHDOnly1();
            }

        }

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            comboBoxBank.Enabled = false;
            textBoxChequeNo.Enabled = false;
            dateTimePickerChqExpDate.Enabled = false;

            if (comboBoxPayMode.Text == "Cheque" && loadStatus == false)
            {
                comboBoxBank.Enabled = true;
                textBoxChequeNo.Enabled = true;
                dateTimePickerChqExpDate.Enabled = true;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateSupplier() && ValidatePONo() && ValidatePaymode();
            if (isValid)
            {
                //updatePOHDOnly();
                insertPOHD();
            }
        }

        private void textBoxTotDiscount_Validating(object sender, CancelEventArgs e)
        {
            fillItemTotalBalanceValue();
        }

        private void textBoxCash_Validating(object sender, CancelEventArgs e)
        {
            fillItemTotalBalanceValue();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                textBoxItemId.Text = dataGridView1["PODTId", e.RowIndex].Value.ToString();
                textBoxItemCode.Text = dataGridView1["ItemCode", e.RowIndex].Value.ToString();
                textBoxItemName.Text = dataGridView1["ItemName", e.RowIndex].Value.ToString();
                comboBoxUnit.Text = dataGridView1["ItemUnit", e.RowIndex].Value.ToString();
                comboBoxItemCategory.SelectedValue = dataGridView1["ItemCatId", e.RowIndex].Value.ToString();
                textBoxLocation.Text = dataGridView1["ItemLocation", e.RowIndex].Value.ToString();
                textBoxQty.Text = dataGridView1["PurchaseQty", e.RowIndex].Value.ToString();
                textBoxMinQty.Text = dataGridView1["MinQty", e.RowIndex].Value.ToString();
                textBoxUnitCostPrice.Text = dataGridView1["PurchasePrice", e.RowIndex].Value.ToString();
                textBoxSellingPrice.Text = dataGridView1["SellingPrice", e.RowIndex].Value.ToString();
                textBoxGross.Text = Convert.ToDecimal(dataGridView1["GrossAmount", e.RowIndex].Value.ToString()).ToString("0.00");
                textBoxDiscount.Text = dataGridView1["Discount", e.RowIndex].Value.ToString();
                textBoxNetAmount.Text = Convert.ToDecimal(dataGridView1["NetAmount", e.RowIndex].Value.ToString()).ToString("0.00");
            }
        }

        private void comboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxCategorySearch.SelectedIndex != -1)
            {
                fillItemsGridByCat();
            }
        }

        private void textBoxSearchItemCode_TextChanged(object sender, EventArgs e)
        {
            comboBoxCategorySearch.SelectedIndex = -1;
            if (textBoxSearchItemCode.Text == "")
            {
                dataGridView2.DataSource = null;
            }
            else
            {
                fillItemsGridByCode();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportPO rpt = new CrystalReportPO();
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePurchaseData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            comboBoxCategorySearch.SelectedIndex = -1;
            if (textBoxSearchName.Text == "")
            {
                dataGridView2.DataSource = null;
            }
            else
            {
                fillItemsGridByName();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;

        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this Purchase Record?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                errorProvider1.Clear();
                bool isValid = ValidatePONo();
                if (isValid)
                {
                    UpdateSumaryToDelete();
                    DeletePOHD();
                }
            }
        }

        private void textBoxItemCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                resetItemCodeData();
                objBAL = new ClassPOBAL();
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCodeData(objBAL);
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
                        comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                        textBoxItemName.Text = (values[1].ToString().Trim());
                        //textBoxLocation.Text = (values[2].ToString().Trim());
                        comboBoxUnit.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxMinQty.Text = (values[6].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonGetData_Click(object sender, EventArgs e)
        {
            FormPurchaseRecord frm = new FormPurchaseRecord();
            frm.ReturnStatus = false;
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void textBoxPOID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPOID.Text != "")
            {
                fillPOHDIdData();
                fillPODtRec();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                try
                {
                    resetItemCodeData();
                    objBAL = new ClassPOBAL();
                    objBAL.ItemCode = textBoxItemCode.Text.Trim();
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveItemCodeData(objBAL);
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
                            comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                            textBoxItemName.Text = (values[1].ToString().Trim());
                            //textBoxLocation.Text = (values[2].ToString().Trim());
                            comboBoxUnit.Text = (values[3].ToString().Trim());
                            textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                            textBoxSellingPrice.Text = (values[5].ToString().Trim());
                            textBoxMinQty.Text = (values[6].ToString().Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView3_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this Purchase Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataGridView3.Rows.RemoveAt(e.RowIndex);
                row--;
                fillItemTotalBalanceValue();
            }
        }

        #endregion

        #region Validation Methods

        private bool ValidatePONo()
        {
            textBoxPONo.Text = textBoxPONo.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxPONo.Text)) || (textBoxPONo.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Add some Purchase record or select PO Record.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxPONo, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateItemID()
        {
            textBoxItemId.Text = textBoxItemId.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemId.Text)) || (textBoxItemId.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please select an Item.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemId, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateItemCode()
        {
            textBoxItemCode.Text = textBoxItemCode.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemCode.Text)) || (textBoxItemCode.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Item Code.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemCode, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateItemName()
        {
            textBoxItemName.Text = textBoxItemName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemName.Text)) || (textBoxItemName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Item Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateIteCategory()
        {
            comboBoxItemCategory.Text = comboBoxItemCategory.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxItemCategory.Text)) || (comboBoxItemCategory.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Item Category.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxItemCategory, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateQty()
        {
            textBoxQty.Text = textBoxQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxQty.Text)) || (textBoxQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Quentity.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxQty.Text))
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxQty.Text) < 0)
            {
                errorCode = "Invalid Quentity.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxQty, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateMinQty()
        {
            textBoxMinQty.Text = textBoxMinQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxMinQty.Text)) || (textBoxMinQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Minimum Quentity.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxMinQty.Text))
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            {
                errorCode = "Invalid Quentity.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxMinQty, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCostPrice()
        {
            textBoxUnitCostPrice.Text = textBoxUnitCostPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUnitCostPrice.Text)) || (textBoxUnitCostPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Cost Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxUnitCostPrice.Text))
            {
                errorCode = "Invalid Price.";
            }
            else if (Convert.ToDecimal(textBoxUnitCostPrice.Text) < 0)
            {
                errorCode = "Invalid Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUnitCostPrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSellPrice()
        {
            textBoxSellingPrice.Text = textBoxSellingPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxSellingPrice.Text)) || (textBoxSellingPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Selling Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxSellingPrice.Text))
            {
                errorCode = "Invalid Price.";
            }
            else if (Convert.ToDecimal(textBoxSellingPrice.Text) < 0)
            {
                errorCode = "Invalid Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxSellingPrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateDiscount()
        {
            textBoxDiscount.Text = textBoxDiscount.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxDiscount.Text)) || (textBoxDiscount.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Discount amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxDiscount.Text))
            {
                errorCode = "Invalid Discount.";
            }
            else if (Convert.ToDecimal(textBoxDiscount.Text) < 0)
            {
                errorCode = "Invalid Discount.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxDiscount, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateTotalDiscount()
        {
            textBoxTotDiscount.Text = textBoxTotDiscount.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxTotDiscount.Text)) || (textBoxTotDiscount.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Discount amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxTotDiscount.Text))
            {
                errorCode = "Invalid Discount.";
            }
            else if (Convert.ToDecimal(textBoxTotDiscount.Text) < 0)
            {
                errorCode = "Invalid Discount.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxTotDiscount, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCash()
        {
            textBoxCash.Text = textBoxCash.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxCash.Text)) || (textBoxCash.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Cash amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxCash.Text))
            {
                errorCode = "Invalid Cash Amount.";
            }
            else if (Convert.ToDecimal(textBoxCash.Text) < 0)
            {
                errorCode = "Invalid Cash Amount.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxCash, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSupplier()
        {
            comboBoxSupplier.Text = comboBoxSupplier.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxSupplier.Text)) || (comboBoxSupplier.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Supplier.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxSupplier, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePaymode()
        {
            comboBoxPayMode.Text = comboBoxPayMode.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxPayMode.Text)) || (comboBoxPayMode.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Payment Mode.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxPayMode, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateBank()
        {
            comboBoxBank.Text = comboBoxBank.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxBank.Text)) || (comboBoxBank.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Bank.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxBank, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateChqNo()
        {
            textBoxChequeNo.Text = textBoxChequeNo.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxChequeNo.Text)) || (textBoxChequeNo.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Cheque No.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxChequeNo, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        

    }
}
