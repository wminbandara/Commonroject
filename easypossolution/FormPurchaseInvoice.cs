using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
using Microsoft.VisualBasic.FileIO;
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
    public partial class FormPurchaseInvoice : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        string FYear, ID;

        bool loadStatus, insertDTStatus, newStatus, poLoadStatus, NewPurchase, AddtoBarcode, autocomplete, duplicatestatus;
        public int POID = 0;
        public decimal CreditPay = 0;
        decimal TotDiscPer, VATPer, NBTPer, ChargePer;
        ArrayList alistForm = new ArrayList();
        int TransferHDIdNew;

        private ListBox listSuggest;
        private List<string> allItems = new List<string>();
        private TextBox activeTextBox;
        private bool isUpdatingText = false;
        private bool suggestBoxInitialized = false;

        #endregion

        #region Constructor
        public FormPurchaseInvoice()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void SelectCompanyData()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreivecompanydata(objBAL);
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
                        //companyname = (values[0].ToString().Trim());
                        //to = (values[3].ToString().Trim());
                        //apikey = (values[12].ToString().Trim());
                        //apitoken = (values[13].ToString().Trim());
                        //fromval = (values[14].ToString().Trim());
                        //companydisc = Convert.ToDecimal(values[16].ToString().Trim());
                        //SMSUrl = (values[17].ToString().Trim());
                        //AllowSMS = Convert.ToBoolean(values[18]);
                        //TotDiscPer = Convert.ToDecimal(values[20].ToString().Trim());
                        VATPer = Convert.ToDecimal(values[21].ToString().Trim());
                        NBTPer = Convert.ToDecimal(values[22].ToString().Trim());
                        //ChargePer = Convert.ToDecimal(values[23].ToString().Trim());
                        //PriceMode = (values[24].ToString().Trim());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillCodeData()
        {
            if (textBoxItemCode.Text != "")
            {
                try
                {
                    bool namestatus = false;
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    ClassPODAL objPODAL = new ClassPODAL();
                    objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
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
                            textBoxDefPurchasePrice.Text = (values[4].ToString().Trim());
                            textBoxSellingPrice.Text = (values[5].ToString().Trim());
                            textBoxMinQty.Text = (values[6].ToString().Trim());
                            textBoxItemId.Text = (values[7].ToString().Trim());
                            textBoxQty.Text = "0";
                            textBoxFreeIssue.Text = (values[12].ToString().Trim());
                            textBoxWholesalePrice.Text = (values[13].ToString().Trim());
                            textBoxShopPrice.Text = (values[21].ToString().Trim());
                            SearchBranchQty();
                        }
                        textBoxItemCode.Select();
                    }
                    else
                    {
                        comboBoxItemCategory.Select();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                textBoxCash.Select();
            }
        }

        private void SearchBranchQty()
        {
            try
            {
                textBoxAvailableQty.Text = "0.00";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
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

        void SearchItemByName()
        {
            try
            {
                textBoxItemCode.Clear();
                //availableQty = 0;
                //txtSellingPrice.Text = "0.00";
                //txtItemId.Clear();
                //comboBoxItemCat.SelectedIndex = -1;
                //txtDisc.Text = "0";
                //textBoxLDiscAmt.Text = "0.00";
                //FreeIssueEffectFrom = 0;
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

        private void SelectuserGRNPrint()
        {
            try
            {
                //comboBoxGRNPrint.Text = "No";
                BALUser objUser = new BALUser();
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveuserGRNPrint(objUser);
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
                        comboBoxGRNPrint.SelectedValue = (values[0].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadGRNOptions()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxGRNPrint.DataSource = objDAL.retreiveGRNPrintOptions(objBAL).Tables[0];
                comboBoxGRNPrint.DisplayMember = "OptionName";
                comboBoxGRNPrint.ValueMember = "GRNPrintId";
                comboBoxGRNPrint.SelectedIndex = 0;

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
                buttonGetData.Enabled = false;
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
                        //if (alistForm[i].ToString().Trim() == "ChangePrice")
                        //{
                        //    txtSellingPrice.ReadOnly = false;
                        //}
                        if (alistForm[i].ToString().Trim() == "GRN GetData")
                        {
                            buttonGetData.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Auto Complete")
                        {
                            autocomplete = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Discount")
                        //{
                        //    txtDisc.ReadOnly = false;
                        //    textBoxLDiscAmt.ReadOnly = false;
                        //    textBoxUnitDisc.ReadOnly = false;
                        //}
                        //if (alistForm[i].ToString().Trim() == "VisibleCost")
                        //{
                        //    label58.Visible = true;
                        //    textBoxCostPrice.Visible = true;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcProfit()
        {
            try
            {
                textBoxRPProfitAmount.Text = (Convert.ToDecimal(textBoxSellingPrice.Text) - Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                if (Convert.ToDecimal(textBoxSellingPrice.Text) > 0)
                {
                    textBoxRPProfitPer.Text = ((Convert.ToDecimal(textBoxRPProfitAmount.Text) / Convert.ToDecimal(textBoxSellingPrice.Text)) * 100).ToString("0");
                }
                textBoxWSProfitAmount.Text = (Convert.ToDecimal(textBoxWholesalePrice.Text) - Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                if (Convert.ToDecimal(textBoxWholesalePrice.Text) > 0)
                {
                    textBoxWSProfitPer.Text = ((Convert.ToDecimal(textBoxWSProfitAmount.Text) / Convert.ToDecimal(textBoxWholesalePrice.Text)) * 100).ToString("0");
                }
            }
            catch
            {
            }
        }

        private void SearchItemsIDData()
        {
            try
            {
                bool namestatus = false;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text.Trim());
                //objPOBAL.Wharehouse = "Wharehouse1";
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveItemsIdData(objPOBAL);
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
                        textBoxDefPurchasePrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxMinQty.Text = (values[6].ToString().Trim());
                        textBoxItemCode.Text = (values[7].ToString().Trim());
                        textBoxQty.Text = "0";
                        textBoxFreeIssue.Text = (values[12].ToString().Trim());
                        textBoxWholesalePrice.Text = (values[13].ToString().Trim());
                        textBoxShopPrice.Text = (values[21].ToString().Trim());
                    }
                    textBoxQty.Select();
                }
                else
                {
                    comboBoxItemCategory.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PrintPI()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportPInvoice rpt = new CrystalReportPInvoice();
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePIData(objBAL);
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

        public void formLoad()
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                if (comboBoxSupplier.Text == "")
                {
                    fillSuppliers();
                }

                if (objDAL.retreiveAllCategoryData(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxItemCategory.DataSource = objDAL.retreiveAllCategoryData(objBAL).Tables[0];
                    comboBoxItemCategory.DisplayMember = "ItemCatName";
                    comboBoxItemCategory.ValueMember = "ItemCatId";
                    comboBoxItemCategory.SelectedIndex = -1;
                }

                if (objDAL.retreivePaymentModes(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objDAL.retreivePaymentModes(objBAL).Tables[0];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 0;
                }

                //comboBoxPayMode.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[1];
                //comboBoxPayMode.DisplayMember = "PayMode";
                //comboBoxPayMode.ValueMember = "PayModeId";
                //comboBoxPayMode.SelectedIndex = 0;
                if (objDAL.retreiveAllBranches(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxBranch.DataSource = objDAL.retreiveAllBranches(objBAL).Tables[0];
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.ValueMember = "BranchId";
                    comboBoxBranch.SelectedValue = lblBranchID.Text;
                }

                loadBank();
                loadNewSupplierType();
                //loadGRNOptions();
                dgView.EditingControlShowing += dgView_EditingControlShowing;
                loadStatus = false;
                textBoxItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadNewSupplierType()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxSupplierType.DataSource = objDAL.retreiveAllSupplierTypes(objBAL).Tables[0];
                comboBoxSupplierType.DisplayMember = "SupplierType";
                comboBoxSupplierType.ValueMember = "SupplierTypeId";
                comboBoxSupplierType.SelectedIndex = -1;

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
                        //textBoxDiscount.Text = (values[2].ToString().Trim());
                        comboBoxUnit.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxDefPurchasePrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxMinQty.Text = (values[6].ToString().Trim());
                        textBoxItemId.Text = (values[7].ToString().Trim());
                        textBoxQty.Text = "0";
                        //labelQty.Text = (values[8].ToString().Trim());
                        //comboBoxItemMode.Text = (values[9].ToString().Trim());
                        //textBoxItemNameS.Text = (values[10].ToString().Trim());
                        //textBoxWarranty.Text = (values[11].ToString().Trim());
                        textBoxFreeIssue.Text = (values[12].ToString().Trim());
                        //textBoxPrice2.Text = (values[13].ToString().Trim());
                        //textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                        //dateTimePickerInWarrStart.Value = Convert.ToDateTime(values[15]);
                        //dateTimePickerInWarrEnd.Value = Convert.ToDateTime(values[16]);
                        textBoxWholesalePrice.Text = (values[13].ToString().Trim());
                        textBoxShopPrice.Text = (values[21].ToString().Trim());
                    }
                    textBoxQty.Select();
                }
                else
                {
                    comboBoxItemCategory.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeSuggestBox()
        {
            if (suggestBoxInitialized) return;

            listSuggest = new ListBox();
            listSuggest.Visible = false;
            listSuggest.Height = 150;
            listSuggest.SelectionMode = SelectionMode.One;
            listSuggest.Font = new Font("Cambria", 11.25F, FontStyle.Bold);
            listSuggest.DoubleClick += ListSuggest_DoubleClick;
            listSuggest.KeyDown += ListSuggest_KeyDown;

            textBoxItemName.TextChanged += TextBox_TextChanged;
            textBoxItemCode.TextChanged += TextBox_TextChanged;
            textBoxItemName.Enter += TextBox_Enter;
            textBoxItemCode.Enter += TextBox_Enter;
            textBoxItemName.Leave += TextBox_Leave;
            textBoxItemCode.Leave += TextBox_Leave;

            textBoxItemName.AutoCompleteMode = AutoCompleteMode.None;
            textBoxItemCode.AutoCompleteMode = AutoCompleteMode.None;

            activeTextBox = textBoxItemName;
            suggestBoxInitialized = true;
        }

        private void ListSuggest_DoubleClick(object sender, EventArgs e)
        {
            SelectSuggestedItem(activeTextBox);
        }

        private void ListSuggest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectSuggestedItem(activeTextBox);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                listSuggest.Visible = false;
                if (activeTextBox != null)
                {
                    activeTextBox.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up && listSuggest.SelectedIndex == 0)
            {
                if (activeTextBox != null)
                {
                    activeTextBox.Focus();
                }
                e.Handled = true;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            activeTextBox = sender as TextBox;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated) return;

            this.BeginInvoke(new Action(() =>
            {
                if (listSuggest != null && this.ActiveControl != listSuggest && this.ActiveControl != textBoxItemCode && this.ActiveControl != textBoxItemName)
                {
                    listSuggest.Visible = false;
                }
            }));
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isUpdatingText) return;

            TextBox tb = sender as TextBox;
            if (tb == null) return;

            string query = tb.Text;
            if (string.IsNullOrEmpty(query))
            {
                listSuggest.Visible = false;
                return;
            }

            var matches = allItems
                .Where(item => item.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (matches.Count > 0)
            {
                listSuggest.DataSource = null;
                listSuggest.DataSource = matches;

                if (listSuggest.Parent != this)
                {
                    if (listSuggest.Parent != null)
                        listSuggest.Parent.Controls.Remove(listSuggest);
                    this.Controls.Add(listSuggest);
                }

                Point screenPoint = tb.PointToScreen(new Point(0, 0));
                Point clientPoint = this.PointToClient(screenPoint);

                listSuggest.Left = clientPoint.X;
                listSuggest.Top = clientPoint.Y + tb.Height;
                listSuggest.Width = Math.Max(tb.Width, 350);
                listSuggest.Height = Math.Min(150, matches.Count * 22 + 5);
                listSuggest.Visible = true;
                listSuggest.BringToFront();
            }
            else
            {
                listSuggest.Visible = false;
            }
        }

        private void SelectSuggestedItem(TextBox tb)
        {
            if (listSuggest.SelectedItem == null) return;

            string selected = listSuggest.SelectedItem.ToString();
            int closeBracket = selected.IndexOf(']');
            if (selected.StartsWith("[") && closeBracket > 0)
            {
                string code = selected.Substring(1, closeBracket - 1).Trim();
                string name = selected.Substring(closeBracket + 1).Replace("- ", "").Trim();

                isUpdatingText = true;
                textBoxItemCode.Text = code;
                textBoxItemName.Text = name;
                listSuggest.Visible = false;

                // Programmatically trigger code keydown lookup logic
                textBoxItemCode_KeyDown(textBoxItemCode, new KeyEventArgs(Keys.Enter));

                isUpdatingText = false;
            }
        }

        private void ItemAutoComplete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                InitializeSuggestBox();

                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreivePurchaseItemName(objInvBAL);

                allItems.Clear();
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
                    {
                        string code = dRow[1].ToString().Trim();
                        string name = dRow[2].ToString().Trim();
                        string formatted = string.Format("[{0}] - {1}", code, name);
                        allItems.Add(formatted);
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertSupplierBankDeposit()
        {
            if (comboBoxPayMode.Text == "Bank Transfer")
            {
                bool isValid = ValidateBank();
                if (isValid)
                {
                    try
                    {
                        objBAL = new ClassPOBAL();
                        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                        objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                        objBAL.ChequeBank = comboBoxBank.Text.Trim();
                        objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                        //objBAL.ChequeNo = textBoxChequeNo.Text.Trim();
                        objBAL.ChequeAmount = Convert.ToDecimal(textBoxBalance.Text);
                        //objBAL.ChequeExpDate = dateTimePickerChqExpDate.Value;
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                        objDAL = new ClassPODAL();
                        int count = objDAL.InsertSupplierBankDeposit(objBAL);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        private void insertSupplierCheque()
        {
            if (comboBoxPayMode.Text == "Cheque")
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
                        objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                        objBAL.ChequeNo = textBoxChequeNo.Text.Trim();
                        objBAL.ChequeAmount = Convert.ToDecimal(textBoxBalance.Text);
                        objBAL.ChequeExpDate = dateTimePickerChqExpDate.Value;
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                        objBAL.CreditPayHDId = 0;
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
            if (comboBoxPayMode.Text == "Credit")
            {
                try
                {
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                    objBAL.CreditAmount = Convert.ToDecimal(textBoxBalance.Text);
                    objBAL.BalanceAmount = Convert.ToDecimal(textBoxBalance.Text);
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
                    objDAL = new ClassPODAL();
                    int count = objDAL.InsertSupplierCredit(objBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public void fillSuppliers()
        {
            objBAL = new ClassPOBAL();
            objDAL = new ClassPODAL();
            comboBoxSupplier.DataSource = objDAL.retreiveAllSupplierCombo(objBAL).Tables[0];
            comboBoxSupplier.DisplayMember = "SupplierName";
            comboBoxSupplier.ValueMember = "SupplierId";
            comboBoxSupplier.SelectedIndex = 0;
        }

        public void resettoNew()
        {
            newStatus = true;
            formLoad();
            DeleteAll();
            dgView1.Rows.Clear();
            Reset();
            ButtonSave.Enabled = true;
            button2.Enabled = true;
            textBoxItemCode.Select();
            //if (textBoxPOID.Text == "")
            //{
            //createPONo();
            //}
           
            newStatus = false;
        }

        private void DeleteAll()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteAllBarcode(objInvBAL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Reset()
        {
            DeleteAll();
            dgView1.Rows.Clear();
            textBoxPOID.Clear();
            textBoxPONo.Clear();
            textBoxSuppInv.Clear();
            dateTimePickerPODate.Value = DateTime.Today;
            comboBoxSupplier.SelectedIndex = 0;
            //comboBoxBranch.SelectedIndex = -1;
            textBoxContactPerson.Clear();
            textBoxAddress.Clear();
            textBoxRemarks.Clear();
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxFreeIssue.Text = "0.00";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxWholesalePrice.Text = "0.00";
            textBoxShopPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxLocation.Clear();
            textBoxTotGrosse.Text = "0.00";
            textBoxTotDiscount.Text = "0.00";
            textBoxTotNet.Text = "0.00";
            textBoxCash.Text = "0.00";
            textBoxBalance.Text = "0.00";
            ButtonSave.Enabled = true;
            dgView.Rows.Clear();
            comboBoxPayMode.SelectedIndex = 0;
            comboBoxBank.Enabled = false;
            comboBoxBank.Text = "";
            textBoxChequeNo.Enabled = false;
            textBoxChequeNo.Clear();
            textBoxDiscPer.Text = "0";
            textBoxDiscAmount.Text = "0.00";
            textBoxDefPurchasePrice.Text = "0.00";
            dateTimePickerChqExpDate.Enabled = false;
            textBoxPath.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            textBoxReturn.Text = "0.00";
            checkBoxReturn.Checked = false;
            CreditPay = 0;
            textBoxRPProfitPer.Text = "0";
            textBoxRPProfitAmount.Text = "0.00";
            textBoxWSProfitPer.Text = "0";
            textBoxWSProfitAmount.Text = "0.00";
            textBoxCreditDueDays.Text = "0";
            textBoxAvailableQty.Text = "0.00";
            textBoxItemCode.Select();
            textBoxFromBranchId.Text = "0";
            textBoxVAT.Text = "0.00";
            checkBoxVAT.Checked = false;
            TransferHDIdNew = 0;
            button2.Enabled = true;
            ButtonSave.Enabled = true;
        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxFreeIssue.Text = "0.00";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxWholesalePrice.Text = "0.00";
            textBoxShopPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxLocation.Clear();
            textBoxDiscPer.Text = "0";
            textBoxDiscAmount.Text = "0.00";
            textBoxDefPurchasePrice.Text = "0.00";
            textBoxAvailableQty.Text = "0.00";
            textBoxSerial.Clear();
            textBoxFromBranchId.Text = "0";
            TransferHDIdNew = 0;
        }

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemName.Clear();
            textBoxLocation.Clear();
            comboBoxUnit.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxWholesalePrice.Text = "0.00";
            textBoxShopPrice.Text = "0.00";
            textBoxMinQty.Text = "0.00";
            textBoxFreeIssue.Text = "0.00";
        }

        public void ResetToDuplicate()
        {
            DeleteAll();
            //dgView1.Rows.Clear();
            textBoxPOID.Clear();
            textBoxPONo.Clear();
            textBoxSuppInv.Clear();
            dateTimePickerPODate.Value = DateTime.Today;
            comboBoxSupplier.SelectedIndex = 0;
            //comboBoxBranch.SelectedIndex = -1;
            textBoxContactPerson.Clear();
            textBoxAddress.Clear();
            textBoxRemarks.Clear();
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxFreeIssue.Text = "0.00";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxWholesalePrice.Text = "0.00";
            textBoxShopPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxLocation.Clear();
            //textBoxTotGrosse.Text = "0.00";
            //textBoxTotDiscount.Text = "0.00";
            //textBoxTotNet.Text = "0.00";
            textBoxCash.Text = "0.00";
            //textBoxBalance.Text = "0.00";
            ButtonSave.Enabled = true;
            //dgView.Rows.Clear();
            comboBoxPayMode.SelectedIndex = 0;
            comboBoxBank.Enabled = false;
            comboBoxBank.Text = "";
            textBoxChequeNo.Enabled = false;
            textBoxChequeNo.Clear();
            textBoxDiscPer.Text = "0";
            textBoxDiscAmount.Text = "0.00";
            textBoxDefPurchasePrice.Text = "0.00";
            dateTimePickerChqExpDate.Enabled = false;
            textBoxPath.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            textBoxReturn.Text = "0.00";
            checkBoxReturn.Checked = false;
            CreditPay = 0;
            textBoxRPProfitPer.Text = "0";
            textBoxRPProfitAmount.Text = "0.00";
            textBoxWSProfitPer.Text = "0";
            textBoxWSProfitAmount.Text = "0.00";
            textBoxCreditDueDays.Text = "0";
            textBoxAvailableQty.Text = "0.00";
            textBoxItemCode.Select();
            textBoxFromBranchId.Text = "0";
            TransferHDIdNew = 0;
        }

        private void DeleteAllBarcode()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteAllBarcode(objInvBAL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPIHD()
        {
            try
            {
                //DialogResult result = MessageBox.Show("Do you want to Add these Items to Print Barcode?", "Print Barcode Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{
                //    AddtoBarcode = true;
                //    DeleteAllBarcode();
                //}
                NewPurchase = true;
                objBAL = new ClassPOBAL();
                //objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                objBAL.PONo = textBoxPONo.Text.Trim();
                objBAL.SupplierInvoiceNo = textBoxSuppInv.Text.Trim();
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());                
                objBAL.PurchaseDate = dateTimePickerPODate.Value;
                objBAL.ContactPerson = textBoxContactPerson.Text.Trim();
                objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.PODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
                objBAL.PONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
                objBAL.POCash = Convert.ToDecimal(textBoxCash.Text);
                objBAL.POBalance = Convert.ToDecimal(textBoxBalance.Text);
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objBAL.ReturnTotal = Convert.ToDecimal(textBoxReturn.Text);
                objBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
                objBAL.VATPer = VATPer;
                objBAL.VATAmount = Convert.ToDecimal(textBoxVAT.Text);

                objDAL = new ClassPODAL();
                string count = objDAL.InsertNewPIHD(objBAL);
                textBoxPOID.Text = count.ToString();

                //int count = objDAL.InsertPIHD(objBAL);
                if (count != "")
                {
                    //SaveBarcode();
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
                        if (dgView.Rows[i].Cells["Rtn"].Value.ToString() == "1")
                        {
                            objBAL = new ClassPOBAL();
                            objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                            objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                            objBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                            objBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                            objBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                            objBAL.ItemUnit = dgView.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();
                            //objBAL.ItemLocation = dgView["ItemLocation", i].Value.ToString();
                            objBAL.PurchaseQty = Convert.ToDecimal(dgView.Rows[i].Cells["PurchaseQty"].Value);
                            objBAL.TotalQty = dgView.Rows[i].Cells["TotalQty"].Value != null ? Convert.ToDecimal(dgView.Rows[i].Cells["TotalQty"].Value) : 0;
                            objBAL.BagWeight = dgView.Rows[i].Cells["BagWeight"].Value != null ? Convert.ToDecimal(dgView.Rows[i].Cells["BagWeight"].Value) : 0;
                            objBAL.MinQty = Convert.ToDecimal(dgView.Rows[i].Cells["MinQty"].Value);
                            objBAL.FreeIssue = Convert.ToDecimal(dgView.Rows[i].Cells["FreeIssue"].Value.ToString());
                            objBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value.ToString());
                            objBAL.PurchasePrice = Convert.ToDecimal(dgView.Rows[i].Cells["PurchasePrice"].Value);
                            objBAL.SellingPrice = Convert.ToDecimal(dgView.Rows[i].Cells["SellingPrice"].Value);
                            //objBAL.Discount = Convert.ToDecimal(dgView["Discount", i].Value.ToString());
                            objBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                            objBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                            objBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                            
                            objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                            objBAL.PurchaseDate = dateTimePickerPODate.Value;
                            objDAL = new ClassPODAL();
                            int count = objDAL.InsertPIDTRtn(objBAL);
                        }
                        else
                        {
                            objBAL = new ClassPOBAL();
                            objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                            objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                            objBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                            objBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                            objBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                            objBAL.ItemUnit = dgView.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();
                            //objBAL.ItemLocation = dgView["ItemLocation", i].Value.ToString();
                            objBAL.PurchaseQty = Convert.ToDecimal(dgView.Rows[i].Cells["PurchaseQty"].Value);
                            objBAL.TotalQty = dgView.Rows[i].Cells["TotalQty"].Value != null ? Convert.ToDecimal(dgView.Rows[i].Cells["TotalQty"].Value) : 0;
                            objBAL.BagWeight = dgView.Rows[i].Cells["BagWeight"].Value != null ? Convert.ToDecimal(dgView.Rows[i].Cells["BagWeight"].Value) : 0;
                            objBAL.MinQty = Convert.ToDecimal(dgView.Rows[i].Cells["MinQty"].Value);
                            objBAL.FreeIssue = Convert.ToDecimal(dgView.Rows[i].Cells["FreeIssue"].Value.ToString());
                            objBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value.ToString());
                            objBAL.PurchasePrice = Convert.ToDecimal(dgView.Rows[i].Cells["PurchasePrice"].Value);
                            objBAL.SellingPrice = Convert.ToDecimal(dgView.Rows[i].Cells["SellingPrice"].Value);
                            //objBAL.Discount = Convert.ToDecimal(dgView["Discount", i].Value.ToString());
                            objBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                            objBAL.WholesalePrice = Convert.ToDecimal(dgView.Rows[i].Cells["WholesalePrice"].Value);
                            objBAL.ShopPrice = Convert.ToDecimal(dgView.Rows[i].Cells["ShopPrice"].Value);
                            objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                            objBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                            objBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                            objBAL.PurchaseDate = dateTimePickerPODate.Value;
                            if (AddtoBarcode == true)
                            {
                                objBAL.AddBarcode = true;
                            }
                            else
                            {
                                objBAL.AddBarcode = false;
                            }
                            objBAL.TransferHDId = Convert.ToInt32(dgView.Rows[i].Cells["TransferHDId"].Value);
                            objBAL.FromBranchId = Convert.ToInt32(dgView.Rows[i].Cells["FromBranchId"].Value);

                            objDAL = new ClassPODAL();
                            int count = objDAL.InsertPIDT(objBAL);
                            if (count != 0)
                            {
                                insertDTStatus = true;
                            }
                        }
                       

                    }

                    
                }
                else if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        objBAL = new ClassPOBAL();
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                        objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                        objBAL.ItemCode = dataGridView2.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                        objBAL.PurchaseQty = Convert.ToDecimal(dataGridView2.Rows[i].Cells["PurchaseQty"].Value);
                        objBAL.Discount = Convert.ToDecimal(dataGridView2.Rows[i].Cells["Discount"].Value.ToString());
                        objBAL.PurchasePrice = Convert.ToDecimal(dataGridView2.Rows[i].Cells["CostPrice"].Value);
                        objBAL.NetAmount = Convert.ToDecimal(dataGridView2.Rows[i].Cells["NetAmount"].Value);
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.PurchaseDate = dateTimePickerPODate.Value;
                        objDAL = new ClassPODAL();
                        int count = objDAL.ImportPIDT(objBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }
                }
                if (insertDTStatus == true)
                {
                    resetDetail();
                    insertSupplierCheque();
                    insertSupplierCredit();
                    insertSupplierBankDeposit();
                    MessageBox.Show("Purchasing Invoice Details Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonSave.Enabled = false;
                    DialogResult result = MessageBox.Show("Do you want to Print this Purchase Invoice?", "Printing Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (comboBoxGRNPrint.SelectedValue.ToString() == "1")
                        {
                            PrintGRNNewEngA4();
                        }
                        else if (comboBoxGRNPrint.SelectedValue.ToString() == "2")
                        {
                            PrintGRNNewSinA4();
                        }
                        else if (comboBoxGRNPrint.SelectedValue.ToString() == "3")
                        {
                            PrintGRNNewEng4In();
                        }
                        else if (comboBoxGRNPrint.SelectedValue.ToString() == "4")
                        {
                            PrintGRNNewSin4In();
                        }
                        else if (comboBoxGRNPrint.SelectedValue.ToString() == "5")
                        {
                            PrintGRNNew3inEng();
                        }
                        else if (comboBoxGRNPrint.SelectedValue.ToString() == "6")
                        {
                            PrintGRNNew3inEngEpson();
                        }
                    }
                    Reset();
                    //if (AddtoBarcode == true)
                    //{
                    //    fillBarcodeGrid();
                    //    ExporttoCSV();
                    //    dataGridView3.DataSource = null;
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintGRNNewEngA4()
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportA4GRNCr rpt = new CrystalReportA4GRNCr();
            objBAL = new ClassPOBAL();
            objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            //crystalReportViewer1.PrintReport();
            rpt.PrintOptions.PrinterName = "";
            rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Dispose();
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void PrintGRNNewSinA4()
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportA4GRNCrS rpt = new CrystalReportA4GRNCrS();
            objBAL = new ClassPOBAL();
            objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            //crystalReportViewer1.PrintReport();
            rpt.PrintOptions.PrinterName = "";
            rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Dispose();
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void PrintGRNNewEng4In()
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportGRN4in rpt = new CrystalReportGRN4in();
            objBAL = new ClassPOBAL();
            objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            //crystalReportViewer1.PrintReport();
            rpt.PrintOptions.PrinterName = "";
            rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Dispose();
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void PrintGRNNewSin4In()
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportGRN4inS rpt = new CrystalReportGRN4inS();
            objBAL = new ClassPOBAL();
            objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            //crystalReportViewer1.PrintReport();
            rpt.PrintOptions.PrinterName = "";
            rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Dispose();
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void PrintGRNNew3inEng()
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportPI3in3ex rpt = new CrystalReportPI3in3ex();
            objBAL = new ClassPOBAL();
            objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            //crystalReportViewer1.PrintReport();
            rpt.PrintOptions.PrinterName = "";
            rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Dispose();
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void PrintGRNNew3inEngEpson()
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportPI5in3 rpt = new CrystalReportPI5in3();
            objBAL = new ClassPOBAL();
            objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            //crystalReportViewer1.PrintReport();
            rpt.PrintOptions.PrinterName = "";
            rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Dispose();
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void insertPIHDReturn()
        {
            try
            {
                if ((comboBoxPayMode.Text == "Credit"))
                {
                    if (comboBoxSupplier.SelectedIndex != -1)
                    {
                        FormSupplierRtnCredit frm = new FormSupplierRtnCredit();
                        frm.frm = this;
                        frm.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                        frm.lblUser.Text = lblUser.Text.Trim();
                        frm.lblUserId.Text = lblUserId.Text.Trim();
                        frm.textBoxReturn.Text = textBoxTotNet.Text;
                        frm.ShowDialog(this);
                    }
                }
                if ((CreditPay != Convert.ToDecimal(textBoxTotNet.Text)) && (comboBoxPayMode.Text == "Credit"))
                {
                    MessageBox.Show("Incorrect credit settlement.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxItemCode.Focus();
                    return;
                }
                else
                {
                    NewPurchase = true;
                    objBAL = new ClassPOBAL();
                    //objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                    objBAL.PONo = textBoxPONo.Text.Trim();
                    objBAL.SupplierInvoiceNo = textBoxSuppInv.Text.Trim();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objBAL.PurchaseDate = dateTimePickerPODate.Value;
                    objBAL.ContactPerson = textBoxContactPerson.Text.Trim();
                    objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                    objBAL.PODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
                    objBAL.PONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
                    objBAL.POCash = Convert.ToDecimal(textBoxCash.Text);
                    objBAL.POBalance = Convert.ToDecimal(textBoxBalance.Text);
                    objBAL.Remarks = textBoxRemarks.Text.Trim();
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objBAL.ReturnTotal = Convert.ToDecimal(textBoxReturn.Text);

                    objDAL = new ClassPODAL();
                    string count = objDAL.InsertNewPIHDReturn(objBAL);
                    textBoxPOID.Text = count.ToString();
                    if (count != "")
                    {
                        insertPIDTReturn();
                    }
                    NewPurchase = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPIDTReturn()
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
                        objBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                        objBAL.ItemUnit = dgView.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();
                        //objBAL.ItemLocation = dgView["ItemLocation", i].Value.ToString();
                        objBAL.PurchaseQty = Convert.ToDecimal(dgView.Rows[i].Cells["PurchaseQty"].Value);
                        objBAL.MinQty = Convert.ToDecimal(dgView.Rows[i].Cells["MinQty"].Value);
                        objBAL.FreeIssue = Convert.ToDecimal(dgView.Rows[i].Cells["FreeIssue"].Value.ToString());
                        objBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value.ToString());
                        objBAL.PurchasePrice = Convert.ToDecimal(dgView.Rows[i].Cells["PurchasePrice"].Value);
                        objBAL.SellingPrice = Convert.ToDecimal(dgView.Rows[i].Cells["SellingPrice"].Value);
                        //objBAL.Discount = Convert.ToDecimal(dgView["Discount", i].Value.ToString());
                        objBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                        objBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.PurchaseDate = dateTimePickerPODate.Value;
                        objBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                        if (AddtoBarcode == true)
                        {
                            objBAL.AddBarcode = true;
                        }
                        else
                        {
                            objBAL.AddBarcode = false;
                        }
                        objDAL = new ClassPODAL();
                        int count = objDAL.InsertPIDTReturn(objBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }


                    }


                }
                //else if (dataGridView2.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                //    {
                //        objBAL = new ClassPOBAL();
                //        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                //        objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                //        objBAL.ItemCode = dataGridView2.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                //        objBAL.PurchaseQty = Convert.ToDecimal(dataGridView2.Rows[i].Cells["PurchaseQty"].Value);
                //        objBAL.Discount = Convert.ToDecimal(dataGridView2.Rows[i].Cells["Discount"].Value.ToString());
                //        objBAL.PurchasePrice = Convert.ToDecimal(dataGridView2.Rows[i].Cells["CostPrice"].Value);
                //        objBAL.NetAmount = Convert.ToDecimal(dataGridView2.Rows[i].Cells["NetAmount"].Value);
                //        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                //        objBAL.PurchaseDate = dateTimePickerPODate.Value;
                //        objBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                //        objDAL = new ClassPODAL();
                //        int count = objDAL.ImportPIDT(objBAL);
                //        if (count != 0)
                //        {
                //            insertDTStatus = true;
                //        }
                //    }
                //}
                if (insertDTStatus == true)
                {
                    resetDetail();
                    MessageBox.Show("Purchase Return Details Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonSave.Enabled = false;
                    Reset();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillBarcodeGrid()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView3.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveBarcodeItems(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView3.DataSource = objInvBAL.DtDataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void ExporttoCSV()
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        //Build the CSV file data as a Comma separated string.
        //        string csv = string.Empty;

        //        //Add the Header row for CSV file.
        //        foreach (DataGridViewColumn column in dataGridView3.Columns)
        //        {
        //            csv += column.HeaderText + ',';
        //        }

        //        //Add new line.
        //        csv += "\r\n";

        //        //Adding the Rows
        //        foreach (DataGridViewRow row in dataGridView3.Rows)
        //        {
        //            foreach (DataGridViewCell cell in row.Cells)
        //            {
        //                //Add the Data rows.
        //                csv += cell.Value.ToString().Replace(",", ";") + ',';
        //            }

        //            //Add new line.
        //            csv += "\r\n";
        //        }

        //        //Exporting to CSV.
        //        string folderPath = "C:\\CSV\\";
        //        File.WriteAllText(folderPath + "BarcodeFile.csv", csv);
        //        MessageBox.Show("Ready to Print.");
        //        Cursor.Current = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}

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
                            //if (dgView.Rows[a].Cells["Rtn"].Value == null)
                            //{
                            //    dgView.Rows[a].Cells["Rtn"].Value = "0";
                            //}
                            if (dgView.Rows[a].Cells["Rtn"].Value.ToString() == "0")
                            {
                                GrossTot += Convert.ToDecimal(dgView.Rows[a].Cells["NetAmount"].Value.ToString());
                            }
                            else
                            {
                                RtnTot += Convert.ToDecimal(dgView.Rows[a].Cells["NetAmount"].Value.ToString());
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                textBoxTotGrosse.Text = GrossTot.ToString("0.00");
                textBoxReturn.Text = RtnTot.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calculateBalance()
        {
            try
            {
                textBoxTotNet.Text = ((Convert.ToDecimal(textBoxTotGrosse.Text) + Convert.ToDecimal(textBoxVAT.Text)) - Convert.ToDecimal(textBoxTotDiscount.Text)).ToString("0.00");
                textBoxBalance.Text = ((Convert.ToDecimal(textBoxTotNet.Text) - Convert.ToDecimal(textBoxReturn.Text)) - Convert.ToDecimal(textBoxCash.Text)).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calculateVAT()
        {
            try
            {
                textBoxVAT.Text = (((Convert.ToDecimal(textBoxTotGrosse.Text) - Convert.ToDecimal(textBoxTotDiscount.Text)) * VATPer) / 100).ToString("0.00");
            }
            catch
            {
            }
        }

        public void fillPOHDIdData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                poLoadStatus = true;
                fillSuppliers();
                poLoadStatus = false;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = POID;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePOrderHDIdData(objBAL);
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
                        //textBoxPOID.Text = (values[0].ToString().Trim());
                        //textBoxPONo.Text = (values[1].ToString().Trim());
                        //dateTimePickerPODate.Value = Convert.ToDateTime(values[2].ToString());
                        comboBoxSupplier.SelectedValue = (values[3]);
                        textBoxAddress.Text = (values[4].ToString().Trim());
                        textBoxContactPerson.Text = (values[5].ToString().Trim());
                        textBoxTotGrosse.Text = (values[6].ToString().Trim());
                        textBoxRemarks.Text = (values[7].ToString().Trim());
                        //comboBoxBranch.SelectedValue = (values[8]);
                    }
                }
                
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void fillPODtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = POID;
                objDAL = new ClassPODAL();
                dgView.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePOHeaderIdData(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        int n = dgView.Rows.Add();

                        dgView.Rows[n].Cells["ItemsId"].Value = (values[2].ToString().Trim());
                        dgView.Rows[n].Cells["Rtn"].Value = "0";
                        dgView.Rows[n].Cells["ItemCode"].Value = (values[3].ToString().Trim());
                        dgView.Rows[n].Cells["ItemCatId"].Value = (values[4].ToString().Trim());
                        dgView.Rows[n].Cells["ItemUnit"].Value = (values[5].ToString().Trim());
                        dgView.Rows[n].Cells["TotalQty"].Value = (values[6].ToString().Trim());
                        dgView.Rows[n].Cells["BagWeight"].Value = "0.00";
                        dgView.Rows[n].Cells["PurchaseQty"].Value = (values[6].ToString().Trim());
                        dgView.Rows[n].Cells["MinQty"].Value = (values[7].ToString().Trim());
                        dgView.Rows[n].Cells["PurchasePrice"].Value = (values[8].ToString().Trim());
                        dgView.Rows[n].Cells["Discount"].Value = "0.00";
                        dgView.Rows[n].Cells["SellingPrice"].Value = (values[9].ToString().Trim());
                        dgView.Rows[n].Cells["FreeIssue"].Value = (values[10].ToString().Trim());
                        dgView.Rows[n].Cells["NetAmount"].Value = (values[11].ToString().Trim());
                        dgView.Rows[n].Cells["ItemName"].Value = (values[12].ToString().Trim());
                        dgView.Rows[n].Cells["WholesalePrice"].Value = (values[13].ToString().Trim());
                        dgView.Rows[n].Cells["ShopPrice"].Value = (values[14].ToString().Trim());
                        dgView.Rows[n].Cells["SerialNo"].Value = "";
                        dgView.Rows[n].Cells["TransferHDId"].Value = "0";
                        dgView.Rows[n].Cells["FromBranchId"].Value = "0";

                        
                        dgView.FirstDisplayedScrollingRowIndex = n;
                        dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        dgView.Rows[n].Selected = true;

                        textBoxItemCode.Text = "";
                        textBoxItemName.Text = "";
                        comboBoxUnit.Text = "";
                        textBoxQty.Text = "1";
                        textBoxMinQty.Text = "0";
                        textBoxFreeIssue.Text = "0";
                        textBoxUnitCostPrice.Text = "0.00";
                        textBoxSellingPrice.Text = "0";
                        textBoxWholesalePrice.Text = "0.00";
                        textBoxShopPrice.Text = "0.00";
                        textBoxNetAmount.Text = "0.00";
                        textBoxItemId.Text = "0";
                        comboBoxItemCategory.SelectedIndex = -1;
                        CalculateTotal();
                    }

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
                objBAL.DtDataSet = objDAL.retreivePIId(objBAL);
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
                textBoxPONo.Text = ("PI/" + FYear + "/" + ID).ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createPORtnNo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                newStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePIId(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[1].Rows)
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
                textBoxPONo.Text = ("PRtn/" + FYear + "/" + ID).ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillPIHDIdData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePIHDIdData(objBAL);
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
                        textBoxPOID.Text = (values[0].ToString().Trim());
                        textBoxPONo.Text = (values[1].ToString().Trim());
                        dateTimePickerPODate.Value = Convert.ToDateTime(values[2].ToString());
                        comboBoxSupplier.SelectedValue = (values[3]);
                        textBoxAddress.Text = (values[4].ToString().Trim());
                        textBoxContactPerson.Text = (values[5].ToString().Trim());
                        textBoxTotGrosse.Text = (values[6].ToString().Trim());
                        textBoxRemarks.Text = (values[7].ToString().Trim());
                        textBoxTotDiscount.Text = (values[8].ToString().Trim());
                        textBoxTotNet.Text = (values[9].ToString().Trim());
                        textBoxCash.Text = (values[10].ToString().Trim());
                        textBoxBalance.Text = (values[11].ToString().Trim());
                        comboBoxPayMode.SelectedValue = (values[12].ToString().Trim());
                        textBoxSuppInv.Text = (values[13].ToString().Trim());
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void fillPIDtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                dgView.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePIDTIdData(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        int n = dgView.Rows.Add();
                        //int intQtyOrdered = int.Parse(txtQty.Text);

                        dgView.Rows[n].Cells["ItemsId"].Value = (values[2].ToString().Trim());
                        dgView.Rows[n].Cells["Rtn"].Value = "0";
                        dgView.Rows[n].Cells["ItemCode"].Value = (values[3].ToString().Trim());
                        dgView.Rows[n].Cells["ItemCatId"].Value = (values[4].ToString().Trim());
                        dgView.Rows[n].Cells["ItemUnit"].Value = (values[5].ToString().Trim());
                        dgView.Rows[n].Cells["TotalQty"].Value = (values[18].ToString().Trim());
                        dgView.Rows[n].Cells["BagWeight"].Value = (values[19].ToString().Trim());
                        dgView.Rows[n].Cells["PurchaseQty"].Value = (values[6].ToString().Trim());
                        dgView.Rows[n].Cells["MinQty"].Value = (values[7].ToString().Trim());
                        dgView.Rows[n].Cells["Discount"].Value = (values[13].ToString().Trim());                        
                        dgView.Rows[n].Cells["PurchasePrice"].Value = (values[8].ToString().Trim());
                        dgView.Rows[n].Cells["SellingPrice"].Value = (values[9].ToString().Trim());
                        dgView.Rows[n].Cells["FreeIssue"].Value = (values[10].ToString().Trim());
                        dgView.Rows[n].Cells["NetAmount"].Value = (values[11].ToString().Trim());
                        dgView.Rows[n].Cells["ItemName"].Value = (values[12].ToString().Trim());

                        dgView.Rows[n].Cells["WholesalePrice"].Value = (values[14].ToString().Trim());
                        dgView.Rows[n].Cells["ShopPrice"].Value = (values[15].ToString().Trim());
                        dgView.Rows[n].Cells["SerialNo"].Value = (values[16].ToString().Trim());
                        dgView.Rows[n].Cells["TransferHDId"].Value = "0";
                        dgView.Rows[n].Cells["FromBranchId"].Value = (values[17].ToString().Trim());

                        
                        dgView.FirstDisplayedScrollingRowIndex = n;
                        dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        dgView.Rows[n].Selected = true;

                        textBoxItemCode.Text = "";
                        textBoxItemName.Text = "";
                        comboBoxUnit.Text = "";
                        textBoxQty.Text = "1";
                        textBoxMinQty.Text = "0";
                        textBoxFreeIssue.Text = "0";
                        textBoxUnitCostPrice.Text = "0.00";
                        textBoxDiscAmount.Text = "0.00";
                        textBoxSellingPrice.Text = "0";
                        textBoxWholesalePrice.Text = "0.00";
                        textBoxShopPrice.Text = "0.00";
                        textBoxNetAmount.Text = "0.00";
                        textBoxItemId.Text = "0";
                        comboBoxItemCategory.SelectedIndex = -1;
                        CalculateTotal();
                    }

                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void fillMinItemsGridAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[3].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[3];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void fillItemsGridByCat()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByCat(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["ItemUnit"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void fillItemsGridByCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByCode(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["ItemUnit"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void fillItemsGridByName()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemName = textBoxSearchName.Text.Trim();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByName(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["ItemUnit"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        void AddtoBarcodeGrid()
        {
            try
            {
                int n = dgView1.Rows.Add();
                //int intQtyOrdered = int.Parse(txtQty.Text);

                dgView1.Rows[n].Cells["ItemCode1"].Value = textBoxItemCode.Text;
                dgView1.Rows[n].Cells["ItemName1"].Value = textBoxItemName.Text;
                dgView1.Rows[n].Cells["InternalNo"].Value = "";
                dgView1.Rows[n].Cells["BCQty"].Value = textBoxQty.Text;
                dgView1.Rows[n].Cells["BCPrice"].Value = textBoxSellingPrice.Text;
                dgView1.Rows[n].Cells["BCStart"].Value = "0";
                dgView1.Rows[n].Cells["BCEnd"].Value = "0";
                dgView1.Rows[n].Cells["ItemsId1"].Value = textBoxItemId.Text;
                dgView1.FirstDisplayedScrollingRowIndex = n;
                dgView1.CurrentCell = dgView1.Rows[n].Cells[0];
                dgView1.Rows[n].Selected = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTransfergrid()
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        textBoxFromBranchId.Text = "0";
                        textBoxItemCode.Text = dataGridView2.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                        FillCodeData();
                        textBoxQty.Text = dataGridView2.Rows[i].Cells["Qty"].Value.ToString();
                        textBoxDefPurchasePrice.Text = dataGridView2.Rows[i].Cells["CostPrice"].Value.ToString();
                        TransferHDIdNew = Convert.ToInt32(dataGridView2.Rows[i].Cells["TransferHDId"].Value.ToString());
                        //dateTimePickerExpDate.Value = Convert.ToDateTime(dataGridView2.Rows[i].Cells["ExpDate"].Value);
                        textBoxFromBranchId.Text = dataGridView2.Rows[i].Cells["FromBranchId"].Value.ToString().Trim();
                        //textBoxSupplierName.Text = dataGridView2.Rows[i].Cells["SupplierName"].Value.ToString().Trim();
                        textBoxSellingPrice.Text = dataGridView2.Rows[i].Cells["SellingPrice"].Value.ToString();
                        AddtoGrid();
                    }
                }


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
                if (checkBoxReturn.Checked == true)
                {
                    dgView.Rows[n].Cells["Rtn"].Value = "1";
                }
                else
                {
                    dgView.Rows[n].Cells["Rtn"].Value = "0";
                }
                dgView.Rows[n].Cells["ItemCode"].Value = textBoxItemCode.Text;
                dgView.Rows[n].Cells["ItemCatId"].Value = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                dgView.Rows[n].Cells["ItemUnit"].Value = comboBoxUnit.Text;
                dgView.Rows[n].Cells["TotalQty"].Value = textBoxQty.Text;
                dgView.Rows[n].Cells["BagWeight"].Value = "0.00";
                dgView.Rows[n].Cells["PurchaseQty"].Value = textBoxQty.Text;
                dgView.Rows[n].Cells["MinQty"].Value = textBoxMinQty.Text;
                dgView.Rows[n].Cells["Discount"].Value = textBoxDiscAmount.Text;
                dgView.Rows[n].Cells["PurchasePrice"].Value = textBoxUnitCostPrice.Text;
                dgView.Rows[n].Cells["SellingPrice"].Value = textBoxSellingPrice.Text;
                dgView.Rows[n].Cells["FreeIssue"].Value = textBoxFreeIssue.Text;
                dgView.Rows[n].Cells["NetAmount"].Value = textBoxNetAmount.Text;
                dgView.Rows[n].Cells["ItemName"].Value = textBoxItemName.Text;
                dgView.Rows[n].Cells["WholesalePrice"].Value = textBoxWholesalePrice.Text;
                dgView.Rows[n].Cells["ShopPrice"].Value = textBoxShopPrice.Text;
                dgView.Rows[n].Cells["SerialNo"].Value = textBoxSerial.Text;
                dgView.Rows[n].Cells["TransferHDId"].Value = TransferHDIdNew.ToString();
                dgView.Rows[n].Cells["FromBranchId"].Value = textBoxFromBranchId.Text;

                dgView.FirstDisplayedScrollingRowIndex = n;
                dgView.CurrentCell = dgView.Rows[n].Cells[0];
                dgView.Rows[n].Selected = true;

                textBoxItemId.Text = "0";
                textBoxItemCode.Text = "";
                comboBoxItemCategory.SelectedIndex = -1;
                comboBoxUnit.Text = "";
                textBoxQty.Text = "0";
                textBoxMinQty.Text = "0";
                textBoxUnitCostPrice.Text = "0";
                textBoxSellingPrice.Text = "0.00";
                textBoxWholesalePrice.Text = "0.00";
                textBoxShopPrice.Text = "0.00";
                textBoxFreeIssue.Text = "0.00";
                textBoxNetAmount.Text = "0.00";
                textBoxDiscPer.Text = "0";
                textBoxDiscAmount.Text = "0.00";
                textBoxItemName.Text = "";
                textBoxDefPurchasePrice.Text = "0.00";
                textBoxUnitCostPrice.Text = "0.00";
                CalculateTotal();
                textBoxCash.Text = "0.00";
                textBoxItemCode.Select();
                textBoxSerial.Clear();
                textBoxFromBranchId.Text = "0";
                TransferHDIdNew = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddtoGridSerial()
        {
            try
            {
                int n = dgView.Rows.Add();

                dgView.Rows[n].Cells["ItemsId"].Value = textBoxItemId.Text;
                if (checkBoxReturn.Checked == true)
                {
                    dgView.Rows[n].Cells["Rtn"].Value = "1";
                }
                else
                {
                    dgView.Rows[n].Cells["Rtn"].Value = "0";
                }
                dgView.Rows[n].Cells["ItemCode"].Value = textBoxItemCode.Text;
                dgView.Rows[n].Cells["ItemCatId"].Value = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                dgView.Rows[n].Cells["ItemUnit"].Value = comboBoxUnit.Text;
                dgView.Rows[n].Cells["TotalQty"].Value = "1.00";
                dgView.Rows[n].Cells["BagWeight"].Value = "0.00";
                dgView.Rows[n].Cells["PurchaseQty"].Value = "1.00";
                dgView.Rows[n].Cells["MinQty"].Value = textBoxMinQty.Text;
                dgView.Rows[n].Cells["Discount"].Value = textBoxDiscAmount.Text;
                dgView.Rows[n].Cells["PurchasePrice"].Value = textBoxUnitCostPrice.Text;
                dgView.Rows[n].Cells["SellingPrice"].Value = textBoxSellingPrice.Text;
                dgView.Rows[n].Cells["FreeIssue"].Value = textBoxFreeIssue.Text;
                dgView.Rows[n].Cells["NetAmount"].Value = textBoxNetAmount.Text;
                dgView.Rows[n].Cells["ItemName"].Value = textBoxItemName.Text;
                dgView.Rows[n].Cells["WholesalePrice"].Value = textBoxWholesalePrice.Text;
                dgView.Rows[n].Cells["ShopPrice"].Value = textBoxShopPrice.Text;
                dgView.Rows[n].Cells["SerialNo"].Value = textBoxSerial.Text;
                dgView.Rows[n].Cells["TransferHDId"].Value = TransferHDIdNew.ToString();
                dgView.Rows[n].Cells["FromBranchId"].Value = textBoxFromBranchId.Text;

                dgView.FirstDisplayedScrollingRowIndex = n;
                dgView.CurrentCell = dgView.Rows[n].Cells[0];
                dgView.Rows[n].Selected = true;

                //textBoxItemId.Text = "0";
                //textBoxItemCode.Text = "";
                //comboBoxItemCategory.SelectedIndex = -1;
                //comboBoxUnit.Text = "";
                //textBoxQty.Text = "0";
                //textBoxMinQty.Text = "0";
                //textBoxUnitCostPrice.Text = "0";
                //textBoxSellingPrice.Text = "0.00";
                //textBoxWholesalePrice.Text = "0.00";
                //textBoxShopPrice.Text = "0.00";
                //textBoxFreeIssue.Text = "0.00";
                //textBoxNetAmount.Text = "0.00";
                //textBoxDiscPer.Text = "0";
                //textBoxDiscAmount.Text = "0.00";
                //textBoxItemName.Text = "";
                //textBoxDefPurchasePrice.Text = "0.00";
                //textBoxUnitCostPrice.Text = "0.00";
                //CalculateTotal();
                //textBoxCash.Text = "0.00";
                //textBoxItemCode.Select();
                textBoxSerial.Clear();
                //textBoxFromBranchId.Text = "0";
                //TransferHDIdNew = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddtoGridWithSerialGenerator()
        {
            try
            {

                int val;
                int qty;

                val = int.Parse(textBoxStartSerial.Text);
                qty = int.Parse(textBoxQty.Text);

                for (int i = val; i <= (val + qty - 1); i++)
                {

                    string ser = i.ToString();
                    int n = dgView.Rows.Add();
                    textBoxSerial.Text = ser.ToString();

                    dgView.Rows[n].Cells["ItemsId"].Value = textBoxItemId.Text;
                    if (checkBoxReturn.Checked == true)
                    {
                        dgView.Rows[n].Cells["Rtn"].Value = "1";
                    }
                    else
                    {
                        dgView.Rows[n].Cells["Rtn"].Value = "0";
                    }
                    dgView.Rows[n].Cells["ItemCode"].Value = textBoxItemCode.Text;
                    dgView.Rows[n].Cells["ItemCatId"].Value = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    dgView.Rows[n].Cells["ItemUnit"].Value = comboBoxUnit.Text;
                    dgView.Rows[n].Cells["TotalQty"].Value = "1.00";
                    dgView.Rows[n].Cells["BagWeight"].Value = "0.00";
                    dgView.Rows[n].Cells["PurchaseQty"].Value = "1.00";
                    dgView.Rows[n].Cells["MinQty"].Value = textBoxMinQty.Text;
                    dgView.Rows[n].Cells["Discount"].Value = textBoxDiscAmount.Text;
                    dgView.Rows[n].Cells["PurchasePrice"].Value = textBoxUnitCostPrice.Text;
                    dgView.Rows[n].Cells["SellingPrice"].Value = textBoxSellingPrice.Text;
                    dgView.Rows[n].Cells["FreeIssue"].Value = textBoxFreeIssue.Text;
                    dgView.Rows[n].Cells["NetAmount"].Value = textBoxNetAmount.Text;
                    dgView.Rows[n].Cells["ItemName"].Value = textBoxItemName.Text;
                    dgView.Rows[n].Cells["WholesalePrice"].Value = textBoxWholesalePrice.Text;
                    dgView.Rows[n].Cells["ShopPrice"].Value = textBoxShopPrice.Text;
                    dgView.Rows[n].Cells["SerialNo"].Value = textBoxSerial.Text;
                    dgView.Rows[n].Cells["TransferHDId"].Value = TransferHDIdNew.ToString();
                    dgView.Rows[n].Cells["FromBranchId"].Value = textBoxFromBranchId.Text;

                    dgView.FirstDisplayedScrollingRowIndex = n;
                    dgView.CurrentCell = dgView.Rows[n].Cells[0];
                    dgView.Rows[n].Selected = true;

                    CalculateTotal();

                }

                textBoxItemId.Text = "0";
                textBoxItemCode.Text = "";
                comboBoxItemCategory.SelectedIndex = -1;
                comboBoxUnit.Text = "";
                textBoxQty.Text = "0";
                textBoxMinQty.Text = "0";
                textBoxUnitCostPrice.Text = "0";
                textBoxSellingPrice.Text = "0.00";
                textBoxWholesalePrice.Text = "0.00";
                textBoxShopPrice.Text = "0.00";
                textBoxFreeIssue.Text = "0.00";
                textBoxNetAmount.Text = "0.00";
                textBoxDiscPer.Text = "0";
                textBoxDiscAmount.Text = "0.00";
                textBoxItemName.Text = "";
                textBoxDefPurchasePrice.Text = "0.00";
                textBoxUnitCostPrice.Text = "0.00";
                CalculateTotal();
                textBoxCash.Text = "0.00";
                textBoxItemCode.Select();
                textBoxSerial.Clear();
                textBoxFromBranchId.Text = "0";
                TransferHDIdNew = 0;
                textBoxStartSerial.Clear();
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
                    //CalculateTotal();
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

        private void loadBank()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxBank.DataSource = objDAL.retreiveBanks(objBAL).Tables[0];
                comboBoxBank.DisplayMember = "BankName";
                comboBoxBank.ValueMember = "BankId";
                comboBoxBank.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveBarcode()
        {
            SaveSODT();
            fillGrid();
            ExporttoCSV();
            DeleteAll();
        }

        private void ExporttoCSV()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridView4.Columns)
                {
                    csv += column.HeaderText + ',';
                }

                //Add new line.
                csv += "\r\n";

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //Add the Data rows.
                        csv += cell.Value.ToString().Replace(",", ";") + ',';
                    }

                    //Add new line.
                    csv += "\r\n";
                }

                //Exporting to CSV.
                string folderPath = "C:\\CSV\\";
                File.WriteAllText(folderPath + "BarcodeFile.csv", csv);
                MessageBox.Show("Ready to Print.");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void fillGrid()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView4.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveBarcodeItems(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView4.DataSource = objInvBAL.DtDataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool savestate;
        private void SaveSODT()
        {
            try
            {

                for (int i = 0; i < dgView1.Rows.Count; i++)
                {
                    ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.ItemCode = dgView1.Rows[i].Cells["ItemCode1"].Value.ToString().Trim();
                    objInvBAL.ItemName = (dgView1.Rows[i].Cells["ItemName1"].Value.ToString());
                    objInvBAL.InternalNo = (dgView1.Rows[i].Cells["InternalNo"].Value.ToString());
                    objInvBAL.SalesQty = Convert.ToDecimal(dgView1.Rows[i].Cells["BCQty"].Value);
                    objInvBAL.SalesPrice = Convert.ToDecimal(dgView1.Rows[i].Cells["BCPrice"].Value);
                    objInvBAL.BCStart = Convert.ToInt32(dgView1.Rows[i].Cells["BCStart"].Value);
                    objInvBAL.BCEnd = Convert.ToInt32(dgView1.Rows[i].Cells["BCEnd"].Value);
                    objInvBAL.ItemsId = Convert.ToInt32(dgView1.Rows[i].Cells["ItemsId1"].Value);
                    ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertBarcodeItem(objInvBAL);
                    if (count != 0)
                    {
                        savestate = true;

                    }
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
            else if ((comboBoxSupplier.SelectedIndex == -1) && ((comboBoxPayMode.Text == "Credit") || (comboBoxPayMode.Text == "Cheque")))
            {
                MessageBox.Show("Please Select Supplier.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxSupplier.Focus();
                comboBoxSupplier.Select();
                return;
            }
            if ((comboBoxPayMode.Text == "Cash") && Convert.ToDecimal(textBoxBalance.Text) > 0)
            {
                MessageBox.Show("Please Enter correct Cash Amount.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxCash.Focus();
                textBoxCash.Select();
                return;
            }
            else if (((Convert.ToDecimal(textBoxBalance.Text) < 0)) && (comboBoxPayMode.Text != "Cash"))
            {
                MessageBox.Show("Please Select correct Payment Method.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxPayMode.Focus();
                comboBoxPayMode.Select();
                return;
            }
            else
            {
                //if (textBoxPOID.Text == "")
                //{
                //    createPONo();
                //}
                insertPIHD();
            }
            
        }

        private void textBoxSearchItemCode_TextChanged(object sender, EventArgs e)
        {
            comboBoxCategorySearch.SelectedIndex = -1;
            if (textBoxSearchItemCode.Text == "")
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                fillItemsGridByCode();
            }
        }

        private void comboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxCategorySearch.SelectedIndex != -1)
            {
                fillItemsGridByCat();
            }
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            comboBoxCategorySearch.SelectedIndex = -1;
            if (textBoxSearchName.Text == "")
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                fillItemsGridByName();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillMinItemsGridAll();
        }
 

        private void FormPurchaseInvoice_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            resetDetail();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you want print barcode for this item?", "Print Barcode Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    AddtoBarcodeGrid();
            //}
            errorProvider1.Clear();
            bool isValid = ValidateQty() &&
                            ValidateMinQty() &&
                            ValidateFreeIssue() &&
                            ValidatePurchasePrice() &&
                            ValidateDiscPer() &&
                            ValidateDiscAmount() &&
                            ValidateUnitCost() &&
                            ValidateRetailPrice() &&
                            ValidateShopPrice() &&
                            ValidateWholesalePrice();
            if (isValid)
            {
                AddtoGrid();
                textBoxItemCode.Select();
            }
        }

        private void ButtonDeleteLine_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this PI Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RemoveItem();
            }
        }

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listSuggest != null && listSuggest.Visible)
            {
                listSuggest.Focus();
                if (listSuggest.Items.Count > 0)
                    listSuggest.SelectedIndex = 0;
                e.Handled = true;
                return;
            }
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && listSuggest != null && listSuggest.Visible && listSuggest.Items.Count > 0)
            {
                SelectSuggestedItem(sender as TextBox);
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxItemCode.Text != "")
                {
                    try
                    {
                        bool namestatus = false;
                        ClassPOBAL objPOBAL = new ClassPOBAL();
                        objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                        //objPOBAL.Wharehouse = "Wharehouse1";
                        ClassPODAL objPODAL = new ClassPODAL();
                        objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
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
                                    FormItemNames frm3 = new FormItemNames();
                                    frm3.frm3 = this;
                                    frm3.ItemCode = textBoxItemCode.Text;
                                    frm3.form = 3;
                                    frm3.ShowDialog(this);
                                    SearchItemsIDData();
                                }
                                else
                                {
                                    comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                                    textBoxItemName.Text = (values[1].ToString().Trim());
                                    //textBoxDiscount.Text = (values[2].ToString().Trim());
                                    comboBoxUnit.Text = (values[3].ToString().Trim());
                                    textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                                    textBoxDefPurchasePrice.Text = (values[4].ToString().Trim());
                                    textBoxSellingPrice.Text = (values[5].ToString().Trim());
                                    textBoxMinQty.Text = (values[6].ToString().Trim());
                                    textBoxItemId.Text = (values[7].ToString().Trim());
                                    textBoxQty.Text = "0";
                                    //labelQty.Text = (values[8].ToString().Trim());
                                    //comboBoxItemMode.Text = (values[9].ToString().Trim());
                                    //textBoxItemNameS.Text = (values[10].ToString().Trim());
                                    //textBoxWarranty.Text = (values[11].ToString().Trim());
                                    textBoxFreeIssue.Text = (values[12].ToString().Trim());
                                    //textBoxPrice2.Text = (values[13].ToString().Trim());
                                    //textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                                    //dateTimePickerInWarrStart.Value = Convert.ToDateTime(values[15]);
                                    //dateTimePickerInWarrEnd.Value = Convert.ToDateTime(values[16]);
                                    textBoxWholesalePrice.Text = (values[13].ToString().Trim());
                                    textBoxShopPrice.Text = (values[21].ToString().Trim());
                                    SearchBranchQty();
                                }
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
                else
                {
                    textBoxCash.Select();
                }
                
            }
        }

        private void textBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateQty();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxMinQty.Select();
                }
            }
            
        }

        private void textBoxMinQty_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateMinQty();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxFreeIssue.Select();
                }
            }
        }

        private void textBoxUnitCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateUnitCost();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxSellingPrice.Select();
                }
            }
        }

        private void textBoxSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateRetailPrice();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxWholesalePrice.Select();
                }
            }
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateQty();
                if (isValid)
                {
                    if ((string.IsNullOrEmpty(textBoxDiscPer.Text)) || (textBoxDiscPer.Text.Trim().Equals(string.Empty)))
                    {
                        textBoxDiscPer.Text = "0";
                        textBoxDiscAmount.Text = "0.00";
                    }
                    else if (Convert.ToDecimal(textBoxDiscPer.Text) > 0)
                    {
                        textBoxDiscAmount.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) * (Convert.ToDecimal(textBoxDiscPer.Text) / 100)).ToString("0.00");
                        textBoxUnitCostPrice.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) - Convert.ToDecimal(textBoxDiscAmount.Text)).ToString("0.00");
                        textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    }
                    textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBoxUnitCostPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateUnitCost();
                if (isValid)
                {
                    if ((string.IsNullOrEmpty(textBoxDiscPer.Text)) || (textBoxDiscPer.Text.Trim().Equals(string.Empty)))
                    {
                        textBoxDiscPer.Text = "0";
                        textBoxDiscAmount.Text = "0.00";
                    }
                    else if (Convert.ToDecimal(textBoxDiscPer.Text) > 0)
                    {
                        textBoxDiscAmount.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) * (Convert.ToDecimal(textBoxDiscPer.Text) / 100)).ToString("0.00");
                        textBoxUnitCostPrice.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) - Convert.ToDecimal(textBoxDiscAmount.Text)).ToString("0.00");
                        textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    }
                    textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    CalcProfit();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (loadStatus == false && comboBoxSupplier.SelectedIndex != -1 && poLoadStatus == false)
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
                            textBoxContactPerson.Text = (values[1].ToString().Trim());
                            comboBoxSupplierType.SelectedValue = (values[2].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Duplicate this GRN?", "GRN Duplicate Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                newStatus = true;
                duplicatestatus = true;
                formLoad();
                ResetToDuplicate();
                textBoxItemCode.Select();
                newStatus = false;
                duplicatestatus = false;
                ButtonSave.Enabled = true;
                comboBoxSupplier.Select();
            }

            
        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            FormPIRecord frm = new FormPIRecord();
            frm.ReturnStatus = false;
            frm.frm = this;
            frm.lblUser.Text = lblUser.Text.Trim();
            frm.lblUserId.Text = lblUserId.Text.Trim();
            frm.ShowDialog(this);
        }

        private void textBoxPONo_TextChanged(object sender, EventArgs e)
        {
            if (newStatus == false && textBoxPOID.Text != "")
            {
                fillPOHDIdData();
                fillPODtRec();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to print Original GRN?", "GRN Print Format Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (comboBoxGRNPrint.SelectedValue.ToString() == "1")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportA4GRNCr rpt = new CrystalReportA4GRNCr();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "2")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportA4GRNCrS rpt = new CrystalReportA4GRNCrS();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "3")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportGRN4in rpt = new CrystalReportGRN4in();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "4")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportGRN4inS rpt = new CrystalReportGRN4inS();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "5")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportPI3in3ex rpt = new CrystalReportPI3in3ex();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "6")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportPI5in3 rpt = new CrystalReportPI5in3();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    if (comboBoxGRNPrint.SelectedValue.ToString() == "1")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportA4GRNSellingriceCr rpt = new CrystalReportA4GRNSellingriceCr();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "2")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportA4GRNSellingriceCr rpt = new CrystalReportA4GRNSellingriceCr();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "3")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportA4GRNSellingriceCr rpt = new CrystalReportA4GRNSellingriceCr();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "4")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportA4GRNSellingriceCr rpt = new CrystalReportA4GRNSellingriceCr();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "5")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportPI3in3exSellingrice rpt = new CrystalReportPI3in3exSellingrice();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else if (comboBoxGRNPrint.SelectedValue.ToString() == "6")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportPI3in3exSellingrice rpt = new CrystalReportPI3in3exSellingrice();
                        objBAL = new ClassPOBAL();
                        objBAL.PIHDId = Convert.ToInt32(textBoxPOID.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                }
                
                //if (comboBoxGRNPrint.SelectedValue.ToString() == "1")
                //{
                //    CrystalReportA4GRNCr rpt = new CrystalReportA4GRNCr();
                //}
                //else if (comboBoxGRNPrint.SelectedValue.ToString() == "2")
                //{
                //    CrystalReportA4GRNCrS rpt = new CrystalReportA4GRNCrS();
                //}
                //else if (comboBoxGRNPrint.SelectedValue.ToString() == "3")
                //{
                //    CrystalReportGRN4in rpt = new CrystalReportGRN4in();
                //}
                //else if (comboBoxGRNPrint.SelectedValue.ToString() == "4")
                //{
                //    CrystalReportGRN4inS rpt = new CrystalReportGRN4inS();
                //}
                //CrystalReportPInvoice rpt = new CrystalReportPInvoice();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNew_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Clear the GRN Window?", "GRN Reset Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                resettoNew();
                ButtonSave.Enabled = true;
                comboBoxSupplier.Select();
            }
        }

        private void textBoxTotGrosse_TextChanged(object sender, EventArgs e)
        {
            calculateBalance();
        }

        private void textBoxTotDiscount_TextChanged(object sender, EventArgs e)
        {
            calculateBalance();
        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            calculateBalance();
        }

        private void textBoxFreeIssue_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateFreeIssue();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxDefPurchasePrice.Select();
                }
            }
        }

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false)
            {
                errorProvider1.Clear();
                comboBoxBank.Enabled = false;
                textBoxChequeNo.Enabled = false;
                dateTimePickerChqExpDate.Enabled = false;
                button2.Enabled = false;

                if (comboBoxPayMode.Text == "Cheque" && loadStatus == false)
                {
                    comboBoxBank.Enabled = true;
                    textBoxChequeNo.Enabled = true;
                    dateTimePickerChqExpDate.Enabled = true;
                }
                else if (comboBoxPayMode.Text == "Bank Transfer" && loadStatus == false)
                {
                    comboBoxBank.Enabled = true;
                    //textBoxChequeNo.Enabled = true;
                    //dateTimePickerChqExpDate.Enabled = true;
                }
                else if (comboBoxPayMode.Text == "Cash" && loadStatus == false)
                {
                    button2.Enabled = true;
                }
                else if (comboBoxPayMode.Text == "Credit" && loadStatus == false)
                {
                    button2.Enabled = true;
                }
                textBoxCash.Text = "0.00";
            }
            
        }

        private void textBoxPOID_TextChanged(object sender, EventArgs e)
        {
            if (newStatus == false && textBoxPOID.Text != "" && NewPurchase == false && duplicatestatus == false)
            {
                //fillPOHDIdData();
                //fillPODtRec();
                fillPIHDIdData();
                dgView.Rows.Clear();
                fillPIDtRec();
                ButtonSave.Enabled = false;
                button2.Enabled = false;
            }
        }


        #region Events



        #endregion



        #region Validation Methods

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

        private void comboBoxSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxContactPerson.Select();
            }
        }

        private void textBoxContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxRemarks.Select();
            }
        }

        private void textBoxRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxItemCode.Select();
            }
        }

        private void FormPurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm1 = new FormItemSearch();
                frm1.frm1 = this;
                frm1.form = 1;
                frm1.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                frm1.lblUser.Text = lblUser.Text.Trim();
                frm1.lblUserId.Text = lblUserId.Text;
                frm1.ShowDialog(this);
            }
        }

        private void textBoxDiscPer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateDiscPer();
                if (isValid)
                {
                    if ((string.IsNullOrEmpty(textBoxDiscPer.Text)) || (textBoxDiscPer.Text.Trim().Equals(string.Empty)))
                    {
                        textBoxDiscPer.Text = "0";
                        textBoxDiscAmount.Text = "0.00";
                    }
                    else if ((Convert.ToDecimal(textBoxDiscPer.Text) == 0) && (textBoxItemCode.Text != ""))
                    {
                        textBoxDiscAmount.Text = "0.00";
                        textBoxUnitCostPrice.Text = textBoxDefPurchasePrice.Text;
                    }
                    else if (Convert.ToDecimal(textBoxDiscPer.Text) > 0)
                    {
                        textBoxDiscAmount.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) * (Convert.ToDecimal(textBoxDiscPer.Text) / 100)).ToString("0.00");
                        textBoxUnitCostPrice.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) - Convert.ToDecimal(textBoxDiscAmount.Text)).ToString("0.00");
                        textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBoxDiscPer_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateDiscPer();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxSellingPrice.Select();
                }
            }
        }

        private void textBoxDefPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidatePurchasePrice();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToDecimal(textBoxUnitCostPrice.Text) == 0)
                    {
                        textBoxUnitCostPrice.Text = textBoxDefPurchasePrice.Text;
                    }
                    textBoxDiscPer.Select();
                }
            }
        }

        private void textBoxDefPurchasePrice_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDecimal(textBoxUnitCostPrice.Text) == 0)
            {
                textBoxUnitCostPrice.Text = textBoxDefPurchasePrice.Text;
            }
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // To list only csv files, we need to add this filter
            openFileDialog.Filter = "|*.csv";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxPath.Text = openFileDialog.FileName;
            }
        }

        private void simpleButtonImport_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = GetDataTableFromCSVFile(textBoxPath.Text);
                CalculateTotal();
                CalculateImportTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private static DataTable GetDataTableFromCSVFile(string csvfilePath)
        {
            DataTable csvData = new DataTable();
            using (TextFieldParser csvReader = new TextFieldParser(csvfilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                //Read columns from CSV file, remove this line if columns not exits  
                string[] colFields = csvReader.ReadFields();

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            return csvData;
        }

        void CalculateImportTotal()
        {
            try
            {

                decimal GrossTot = 0;

                int i = dataGridView2.RowCount;

                for (int a = 0; a < i; a++)
                {
                    try
                    {
                        GrossTot += Convert.ToDecimal(dataGridView2.Rows[a].Cells["NetAmount"].Value.ToString());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                textBoxTotGrosse.Text = GrossTot.ToString("0.00");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancell_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Cancel this GRN?", "Cancellation Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (textBoxPOID.Text != "")
                {
                    insertCamcellation();
                }
            }
        }

        private void insertCamcellation()
        {
            try
            {
                ClassSOBAL objBAL = new ClassSOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                ClassSODAL objDAL = new ClassSODAL();
                int count = objDAL.InsertPurchaseCancellation(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Invoice Cancellation Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //fillSODtRec();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isGridUpdating = false;

        private void dgView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isGridUpdating) return;
            if (dgView.Rows.Count == 0 || e.RowIndex < 0) return;

            string colName = dgView.Columns[e.ColumnIndex].Name;

            if (colName == "TotalQty" || colName == "BagWeight" || colName == "PurchaseQty" || colName == "PurchasePrice")
            {
                try
                {
                    isGridUpdating = true;
                    var row = dgView.Rows[e.RowIndex];

                    decimal totalQty = 0;
                    decimal bagWeight = 0;

                    if (row.Cells["TotalQty"].Value != null)
                        decimal.TryParse(row.Cells["TotalQty"].Value.ToString(), out totalQty);

                    if (row.Cells["BagWeight"].Value != null)
                        decimal.TryParse(row.Cells["BagWeight"].Value.ToString(), out bagWeight);

                    if (colName == "TotalQty" || colName == "BagWeight")
                    {
                        decimal purchaseQty = totalQty - bagWeight;
                        row.Cells["PurchaseQty"].Value = purchaseQty.ToString("0.00");
                    }

                    decimal finalPurchaseQty = 0;
                    if (row.Cells["PurchaseQty"].Value != null)
                        decimal.TryParse(row.Cells["PurchaseQty"].Value.ToString(), out finalPurchaseQty);

                    decimal purchasePrice = 0;
                    if (row.Cells["PurchasePrice"].Value != null)
                        decimal.TryParse(row.Cells["PurchasePrice"].Value.ToString(), out purchasePrice);

                    row.Cells["NetAmount"].Value = (finalPurchaseQty * purchasePrice).ToString("0.00");

                    textBoxTotGrosse.Text = GetGridTotalGrosse().ToString("0.00");
                    CalculateTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    isGridUpdating = false;
                }
            }
        }

        private double GetGridTotalGrosse()
        {
            double sum = 0;
            for (int i = 0; i < dgView.Rows.Count; ++i)
            {
                if (dgView.Rows[i].Cells["NetAmount"].Value != null)
                {
                    double d = 0;
                    Double.TryParse(dgView.Rows[i].Cells["NetAmount"].Value.ToString(), out d);
                    sum += d;
                }
            }
            return sum;
        }

        private void dgView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress -= NumericCell_KeyPress;
                if (dgView.CurrentCell != null)
                {
                    string colName = dgView.Columns[dgView.CurrentCell.ColumnIndex].Name;
                    if (colName == "TotalQty" || colName == "BagWeight" || colName == "PurchaseQty")
                    {
                        tb.KeyPress += NumericCell_KeyPress;
                    }
                }
            }
        }

        private void NumericCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            TextBox txt = sender as TextBox;
            if (txt != null && (e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxDefPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidatePurchasePrice();
                if (isValid)
                {
                    if ((string.IsNullOrEmpty(textBoxDiscPer.Text)) || (textBoxDiscPer.Text.Trim().Equals(string.Empty)))
                    {
                        textBoxDiscPer.Text = "0";
                        textBoxDiscAmount.Text = "0.00";
                    }
                    else if ((Convert.ToDecimal(textBoxDiscPer.Text) == 0) && (textBoxItemCode.Text != ""))
                    {
                        textBoxDiscAmount.Text = "0.00";
                        textBoxUnitCostPrice.Text = textBoxDefPurchasePrice.Text;
                    }
                    else if (Convert.ToDecimal(textBoxDiscPer.Text) > 0)
                    {
                        textBoxDiscAmount.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) * (Convert.ToDecimal(textBoxDiscPer.Text) / 100)).ToString("0.00");
                        textBoxUnitCostPrice.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) - Convert.ToDecimal(textBoxDiscAmount.Text)).ToString("0.00");
                        textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBoxReturn_TextChanged(object sender, EventArgs e)
        {
            calculateBalance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgView.RowCount < 1)
            {
                MessageBox.Show("Please enter item to return before you can save this record.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxItemCode.Focus();
                return;
            }
            else if (((comboBoxPayMode.Text == "Cheque") || (comboBoxPayMode.Text == "Card") || (comboBoxPayMode.Text == "CheckInHand") || (comboBoxPayMode.Text == "Advance") || (comboBoxPayMode.Text == "Bank Transfer") || (comboBoxPayMode.Text == "Loyalty Point") || (comboBoxPayMode.Text == "Return Note")))
            {
                MessageBox.Show("Please Select Correct payment mode.", "Invalid Payment mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxSupplier.Focus();
                comboBoxSupplier.Select();
                return;
            }
            else if ((comboBoxSupplier.SelectedIndex == -1) && ((comboBoxPayMode.Text == "Credit")))
            {
                MessageBox.Show("Please Select Supplier.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxSupplier.Focus();
                comboBoxSupplier.Select();
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to Save this Return Note?", "Saving Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    createPORtnNo();
                    insertPIHDReturn();
                }
            }
        }

        private void textBoxWholesalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateWholesalePrice();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxShopPrice.Select();
                }
            }
        }

        private void textBoxShopPrice_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateShopPrice();
            if (isValid)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxSerial.Select();
                }
            }
        }

        private void textBoxSellingPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateRetailPrice();
                if (isValid)
                {
                    CalcProfit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBoxWholesalePrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateWholesalePrice();
                if (isValid)
                {
                    CalcProfit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
            loadGRNOptions();
            SelectuserGRNPrint();
            SelectCompanyData();
            if (autocomplete == true)
            {
                ItemAutoComplete();
            }
        }

        private void textBoxSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxSerial.Text != "")
                {
                    AddtoGridSerial();
                    textBoxSerial.Select();
                }
                else
                {
                    ButtonAdd.Select();

                }
            }
        }

        private void textBoxCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonSave_Click(sender, e);
            }
        }

        private void textBoxItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listSuggest != null && listSuggest.Visible)
            {
                listSuggest.Focus();
                if (listSuggest.Items.Count > 0)
                    listSuggest.SelectedIndex = 0;
                e.Handled = true;
                return;
            }
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && listSuggest != null && listSuggest.Visible && listSuggest.Items.Count > 0)
            {
                SelectSuggestedItem(sender as TextBox);
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxItemName.Text != "")
                {
                    SearchItemByName();
                    textBoxItemCode_KeyDown(sender, e);
                }
            }
        }

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedValue = lblBranchID.Text;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // To list only csv files, we need to add this filter
            openFileDialog.Filter = "|*.csv";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxPath.Text = openFileDialog.FileName;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = GetDataTableFromCSVFile(textBoxPath.Text);
                FillTransfergrid();
                //CalculateTotal();
                //CalculateImportTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void checkBoxReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReturn.Checked == true)
            {
                button2.Enabled = false;
            }
            else if (checkBoxReturn.Checked == false)
            {
                if (dgView.RowCount < 1)
                {
                    button2.Enabled = true;
                }
                
            }
        }

        private void simpleButton_Click(object sender, EventArgs e)
        {
            AddtoGridWithSerialGenerator();
        }

        private void checkBoxVAT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVAT.Checked == false)
            {
                textBoxVAT.Text = "0.00";
            }
            else
            {
                if (dgView.Rows.Count > 0)
                {
                    calculateVAT();
                    calculateBalance();
                }
            }
        }

        private bool ValidateQty()
        {
            textBoxQty.Text = textBoxQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxQty.Text)) || (textBoxQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Qty.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxQty.Text))
            {
                errorCode = "Invalid Qty.";
            }
            else if (Convert.ToDecimal(textBoxQty.Text) < 0)
            {
                errorCode = "Invalid Qty.";
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
                errorCode = "Please Enter Min Qty.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxMinQty.Text))
            {
                errorCode = "Invalid Min Qty.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
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

        private bool ValidateFreeIssue()
        {
            textBoxFreeIssue.Text = textBoxFreeIssue.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxFreeIssue.Text)) || (textBoxFreeIssue.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Feee Issue Qty.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxFreeIssue.Text))
            {
                errorCode = "Invalid Feee Issue Qty.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxFreeIssue, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePurchasePrice()
        {
            textBoxDefPurchasePrice.Text = textBoxDefPurchasePrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxDefPurchasePrice.Text)) || (textBoxDefPurchasePrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Feee Issue Qty.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxDefPurchasePrice.Text))
            {
                errorCode = "Invalid Feee Issue Qty.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxDefPurchasePrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateDiscPer()
        {
            textBoxDiscPer.Text = textBoxDiscPer.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxDiscPer.Text)) || (textBoxDiscPer.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Disc Per.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxDiscPer.Text))
            {
                errorCode = "Invalid Disc Per.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxDiscPer, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateDiscAmount()
        {
            textBoxDiscAmount.Text = textBoxDiscAmount.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxDiscAmount.Text)) || (textBoxDiscAmount.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Disc Amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxDiscAmount.Text))
            {
                errorCode = "Invalid Disc Amount.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxDiscAmount, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateUnitCost()
        {
            textBoxUnitCostPrice.Text = textBoxUnitCostPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUnitCostPrice.Text)) || (textBoxUnitCostPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Unit Cost.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxUnitCostPrice.Text))
            {
                errorCode = "Invalid Unit Cost.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
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

        private bool ValidateRetailPrice()
        {
            textBoxSellingPrice.Text = textBoxSellingPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxSellingPrice.Text)) || (textBoxSellingPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Retail Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxSellingPrice.Text))
            {
                errorCode = "Invalid Retail Price.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
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

        private bool ValidateWholesalePrice()
        {
            textBoxWholesalePrice.Text = textBoxWholesalePrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxWholesalePrice.Text)) || (textBoxWholesalePrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Wholesale Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxWholesalePrice.Text))
            {
                errorCode = "Invalid Wholesale Price.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxWholesalePrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateShopPrice()
        {
            textBoxShopPrice.Text = textBoxShopPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxShopPrice.Text)) || (textBoxShopPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Shop Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxShopPrice.Text))
            {
                errorCode = "Invalid Shop Price.";
            }
            //else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            //{
            //    errorCode = "Invalid Min Qty.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxShopPrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void textBoxDiscAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateDiscAmount();
                if (isValid)
                {
                    textBoxUnitCostPrice.Text = (Convert.ToDecimal(textBoxDefPurchasePrice.Text) - Convert.ToDecimal(textBoxDiscAmount.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
