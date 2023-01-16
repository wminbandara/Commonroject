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
    public partial class FormStockTransfer : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        string TransferHDId = "0";

        bool loadStatus, insertDTStatus, autocomplete;

        ArrayList alistOption = new ArrayList();
        ArrayList alistForm = new ArrayList();

        #endregion

        #region Constructor
        public FormStockTransfer()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void SearchItemByName()
        {
            try
            {
                textBoxItemCode.Clear();
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemName = textBoxItemName.Text.Trim();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsDataByName(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxItemCode.Text = (values[0].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userPermission()
        {
            try
            {
                autocomplete = false;
                BALUser objUser = new BALUser();
                //objUser.FORM_NAME = "User Registration";
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveUserPermission(objUser);
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
                        alistForm.Add(values[0].ToString());

                    }
                    for (int i = 0; i < alistForm.Count; i++)
                    {
                        
                        if (alistForm[i].ToString().Trim() == "Auto Complete")
                        {
                            autocomplete = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemAutoComplete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemName(objInvBAL);

                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxItemCode.AutoCompleteCustomSource.Add(values[1].ToString());
                        textBoxItemName.AutoCompleteCustomSource.Add(values[2].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillTransferGrid()
        {
            ClassSOBAL objBAL = new ClassSOBAL();
            objBAL.TransferHDId = Convert.ToInt32(TransferHDId);
            ClassSODAL objDAL = new ClassSODAL();
            gridControl2.DataSource = null;
            if (objDAL.retreiveAllStockTransferByID(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl2.DataSource = objBAL.DtDataSet.Tables[0];
                //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                //gridView1.Columns["CustAccountId"].Visible = false;
                //gridView1.Columns["BranchId"].Visible = false;
                //gridView1.Columns["Status"].Visible = false;
                gridView2.OptionsView.ColumnAutoWidth = false;
                gridView2.BestFitColumns();
            }
        }

        private void SearchBranchQty()
        {
            try
            {
                textBoxAvailableQty.Text = "0.00";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objInvBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveBranchQty(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        textBoxAvailableQty.Text = (values[0].ToString().Trim());

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchItemsIDData()
        {
            try
            {
                comboBoxItemCategory.SelectedIndex = -1;
                textBoxItemName.Text = "";
                comboBoxUnit.Text = "";
                textBoxUnitCostPrice.Text = "0.00";
                textBoxSellingPrice.Text = "0.00";
                textBoxMinQty.Text = "0";
                textBoxItemCode.Text = "0";
                bool namestatus = false;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text.Trim());
                //objPOBAL.Wharehouse = "Wharehouse1";
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveItemsIdTransData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        
                        comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                        textBoxItemName.Text = (values[1].ToString().Trim());
                        comboBoxUnit.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxMinQty.Text = (values[6].ToString().Trim());
                        textBoxItemCode.Text = (values[7].ToString().Trim());
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

        public void ItemcodeKeyDown()
        {
            try
            {
                comboBoxItemCategory.SelectedIndex = -1;
                textBoxItemName.Text = "";
                comboBoxUnit.Text = "";
                textBoxUnitCostPrice.Text = "0.00";
                textBoxSellingPrice.Text = "0.00";
                textBoxMinQty.Text = "0";
                textBoxItemId.Text = "0";

                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                //objPOBAL.Wharehouse = "Wharehouse1";
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveItemCodeTransData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                        textBoxItemName.Text = (values[1].ToString().Trim());
                        comboBoxUnit.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxMinQty.Text = (values[6].ToString().Trim());
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

        private void fillGrid()
        {
            ClassSOBAL objBAL = new ClassSOBAL();
            objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
            ClassSODAL objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllAvbleStk(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                gridView1.Columns["ItemsId"].Visible = false;
                //gridView1.Columns["BranchId"].Visible = false;
                //gridView1.Columns["Status"].Visible = false;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
            }
        }


        public void Reset()
        {
            dateTimePickerPODate.Value = DateTime.Today;
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxUnit.Text = "NOs";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            ButtonSave.Enabled = true;
            dgView.Rows.Clear();
        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxUnit.Text = "NOs";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";

        }

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemName.Clear();
            comboBoxUnit.Text = "NOs";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxMinQty.Text = "0.00";
        }

        private void SaveHDNew()
        {
            try
            {
                TransferHDId = "0";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.FromBranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objInvBAL.ToBranchId = Convert.ToInt32(comboBoxWarehouseTo.SelectedValue.ToString());
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);

                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.InsertStockTransferhd(objInvBAL);
                TransferHDId = count.ToString();

                //int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != "")
                {
                    //GenerateInvoice();
                    insertPIDT();
                }
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
                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    objBAL = new ClassPOBAL();
                    objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                    objBAL.ToBranchId = Convert.ToInt32(comboBoxWarehouseTo.SelectedValue.ToString());
                    objBAL.PurchaseDate = dateTimePickerPODate.Value;
                    objBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                    objBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    objBAL.PurchaseQty = Convert.ToDecimal(dgView.Rows[i].Cells["PurchaseQty"].Value);
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objBAL.TransferHDId = Convert.ToInt32(TransferHDId);
                    
                    objDAL = new ClassPODAL();
                    int count = objDAL.InsertStockTransfer(objBAL);
                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }

                }

                if (insertDTStatus == true)
                {
                    resetDetail();
                    MessageBox.Show("Stock Transfered Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTransferGrid();
                    ExportToExcell();
                    print();
                    Reset();
                    fillGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportToExcell()
        {
            string exportFilePath = "C:\\CSV\\StockTransfer\\ExcelTransferTemplate" + TransferHDId.ToString() + ".xls";
            gridControl2.ExportToXls(exportFilePath);
            System.Diagnostics.Process.Start(exportFilePath);
        }

        private void print()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportStockTransfer rpt = new CrystalReportStockTransfer();
                objBAL = new ClassPOBAL();
                objBAL.TransferHDId = Convert.ToInt32(TransferHDId);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveTransferData(objBAL);
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

        private void fillItemNetValue()
        {
            textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
        }

        void AddtoGrid()
        {
            try
            {
                int n = dgView.Rows.Add();

                dgView.Rows[n].Cells["ItemsId"].Value = textBoxItemId.Text;
                dgView.Rows[n].Cells["ItemCode"].Value = textBoxItemCode.Text;
                dgView.Rows[n].Cells["ItemCatId"].Value = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                dgView.Rows[n].Cells["ItemUnit"].Value = comboBoxUnit.Text;
                dgView.Rows[n].Cells["PurchaseQty"].Value = textBoxQty.Text;
                dgView.Rows[n].Cells["MinQty"].Value = textBoxMinQty.Text;
                dgView.Rows[n].Cells["PurchasePrice"].Value = textBoxUnitCostPrice.Text;
                dgView.Rows[n].Cells["SellingPrice"].Value = textBoxSellingPrice.Text;
                dgView.Rows[n].Cells["FreeIssue"].Value = "0";
                dgView.Rows[n].Cells["NetAmount"].Value = textBoxNetAmount.Text;
                dgView.Rows[n].Cells["ItemName"].Value = textBoxItemName.Text;

                dgView.FirstDisplayedScrollingRowIndex = n;
                dgView.CurrentCell = dgView.Rows[n].Cells[0];
                dgView.Rows[n].Selected = true;

                textBoxItemId.Text = "0";
                textBoxItemCode.Text = "";
                comboBoxItemCategory.SelectedIndex = -1;
                comboBoxUnit.Text = "NOs";
                textBoxQty.Text = "0";
                textBoxMinQty.Text = "0";
                textBoxUnitCostPrice.Text = "0";
                textBoxSellingPrice.Text = "0.00";
                textBoxNetAmount.Text = "0.00";
                textBoxItemName.Text = "";
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
            SaveHDNew();
            //insertPIDT();
            
            
        }

        private void FormStockTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();

                comboBoxItemCategory.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

                if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
                {
                    comboBoxWarehouse.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                    comboBoxWarehouse.DisplayMember = "BranchName";
                    comboBoxWarehouse.ValueMember = "BranchId";
                    comboBoxWarehouse.SelectedIndex = 0;
                }

                if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
                {
                    comboBoxWarehouseTo.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                    comboBoxWarehouseTo.DisplayMember = "BranchName";
                    comboBoxWarehouseTo.ValueMember = "BranchId";
                    comboBoxWarehouseTo.SelectedIndex = 0;
                }

                //ItemAutoComplete();
                //comboBoxWarehouse.Text = "";
                fillGrid();

                loadStatus = false;
                comboBoxUnit.Text = "NOs";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            resetDetail();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateQty();
            if (isValid)
            {
                AddtoGrid();
            }
            
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
                if (textBoxItemCode.Text != "")
                {

                    try
                    {
                        comboBoxItemCategory.SelectedIndex = -1;
                        textBoxItemName.Text = "";
                        comboBoxUnit.Text = "";
                        textBoxUnitCostPrice.Text = "0.00";
                        textBoxSellingPrice.Text = "0.00";
                        textBoxMinQty.Text = "0";
                        textBoxItemId.Text = "0";
                        bool namestatus = false;
                        ClassPOBAL objPOBAL = new ClassPOBAL();
                        objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                        //objPOBAL.Wharehouse = "Wharehouse1";
                        ClassPODAL objPODAL = new ClassPODAL();
                        objPOBAL.DtDataSet = objPODAL.retreiveItemCodeTransData(objPOBAL);
                        if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                        {
                            List<ArrayList> newval = new List<ArrayList>();
                            foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                            {
                                ArrayList values = new ArrayList();
                                values.Clear();
                                foreach (object value in dRow.ItemArray)
                                    values.Add(value);
                                newval.Add(values);
                                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                                objInvBAL.ItemCode = textBoxItemCode.Text;
                                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                                objInvBAL.DtDataSet = objInvDAL.retreiveExistItemVariantData(objInvBAL);
                                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0 && namestatus == false)
                                {
                                    namestatus = true;
                                    FormItemNames frm1 = new FormItemNames();
                                    frm1.frm1 = this;
                                    frm1.ItemCode = textBoxItemCode.Text;
                                    frm1.form = 1;
                                    frm1.ShowDialog(this);
                                    SearchItemsIDData();
                                }
                                else
                                {
                                    comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                                    textBoxItemName.Text = (values[1].ToString().Trim());
                                    comboBoxUnit.Text = (values[3].ToString().Trim());
                                    textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                                    textBoxSellingPrice.Text = (values[5].ToString().Trim());
                                    textBoxMinQty.Text = (values[6].ToString().Trim());
                                    textBoxItemId.Text = (values[7].ToString().Trim());
                                    textBoxQty.Text = "0";
                                }
                            }
                            SearchBranchQty();
                            textBoxQty.Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    textBoxItemName.Select();
                }
            }
        }

        private void textBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAdd.Select();
                //textBoxItemCode.Select();
            }
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");

            }
            catch (Exception)
            {

            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Reset();
        }


        #region Events



        #endregion



        #region Validation Methods

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
            //else if ((comboBoxWarehouse.Text == "1") && (Convert.ToDecimal(textBoxQty.Text) > Convert.ToDecimal(textBoxWH1Qty.Text)))
            //{
            //    errorCode = "Warehouse Available Qty not enough to transfer this Qty.";
            //}
            //else if ((comboBoxWarehouse.Text == "2") && (Convert.ToDecimal(textBoxQty.Text) > Convert.ToDecimal(textBoxWH2Qty.Text)))
            //{
            //    errorCode = "Warehouse Available Qty not enough to transfer this Qty.";
            //}
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

        #endregion

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false)
            {
                fillGrid();
            }
        }

        private void FormStockTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm5 = new FormItemSearch();
                frm5.frm5 = this;
                frm5.form = 5;
                frm5.wh = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                frm5.lblUser.Text = lblUser.Text.Trim();
                frm5.lblUserId.Text = lblUserId.Text.Trim();
                frm5.ShowDialog(this);
            }
        }

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxWarehouse.SelectedValue = lblBranchID.Text;
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
            if (autocomplete == true)
            {
                ItemAutoComplete();
            }
        }

        private void textBoxItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxItemName.Text != "")
                {
                    SearchItemByName();
                    textBoxItemCode_KeyDown(sender, e);
                }

            }
        }


    }
}
