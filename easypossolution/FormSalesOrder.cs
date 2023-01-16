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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace easyPOSSolution
{
    public partial class FormSalesOrder : Form
    {
        #region Local Variables

        ClassDataAccess objDataAccess = new ClassDataAccess();

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();

        ArrayList alistOption = new ArrayList();
        ArrayList alistForm = new ArrayList();

        bool press, loadStatus, datafillStatus, addChgsPercStatus, totDiscPercStatus, addStatus, VATStatus, FreeIssueStatus, addtoGrid, PrintBalance;
        int Invoice, Sohdid, InvoiceNo, FreeIssueEffectFrom, FreeIssueQty, TempId, TempSohdid;
        public string mFormState;
        decimal availableQty, lineDiscount, totDisc, totAddChgs, grossTot, defaultDiscount, specialPrice, defaultPRice, spPriceEffect, OriginalPrice, EditedPrice, TotalLineDisc, TotalLineDiscTotal, SelPriceDisc, SelPriceDiscTotal;
        bool blnSave, savestate, PrintInvoiceStatus, PrintDetailWithLogo, PrintDetailWithoutLogo, PrintDetailWithLogoSinhala, PrintDetailWithoutLogoSinhala, PrintwithoutDetailWithLogo, PrintwithoutDetailWithoutLogo, PrintWithoutDetailWithLogoSinhala, PrintWithoutDetailWithoutLogoSinhala;
        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7;
        string lDiscString, message;
        public bool blnPaid, newItem;
        public decimal CreditPay = 0;
        decimal purchasePrice, DiscRate;
        bool AllowSMS, autocomplete;

        string to, apitoken, fromval, apikey, companyname, SMSUrl;

        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

        #endregion

        #region Constructor
        public FormSalesOrder()
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
                        companyname = (values[0].ToString().Trim());
                        to = (values[3].ToString().Trim());
                        apikey = (values[12].ToString().Trim());
                        apitoken = (values[13].ToString().Trim());
                        fromval = (values[14].ToString().Trim());
                        SMSUrl = (values[17].ToString().Trim());
                        AllowSMS = Convert.ToBoolean(values[18]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AutoCompleteCustContact()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveCustContacts(objInvBAL);

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
                        textBoxCustMobile.AutoCompleteCustomSource.Add(values[0].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchCustomerByContactNo()
        {
            try
            {
                textBoxCustCode.Clear();
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.CustomerTelNo = textBoxCustMobile.Text;
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveCustomerContactData(objInvBAL);
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
                        textBoxCustCode.Text = (values[0].ToString().Trim());
                    }
                    searchCustomer();
                    txtItemCode.Select();
                }
                else
                {
                    simpleButton3.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadInvoiceStatus()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxInvoiceStatus.DataSource = objDAL.retreiveInvoiceStatus(objBAL).Tables[0];
                comboBoxInvoiceStatus.DisplayMember = "InvoiceStatus";
                comboBoxInvoiceStatus.ValueMember = "InvoiceStatusId";
                comboBoxInvoiceStatus.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertInvoiceCustomer()
        {
            if (textBoxCustCode.Text == "")
            {
                createCustomerCode();
            }

            InsertCustomer();
        }

        private void createCustomerCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string ID = "";

                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveMaxCustIdData(objBAL);
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
                        ID = (Convert.ToInt32(values[0])).ToString("0000");
                    }
                }
                textBoxCustCode.Text = "C1" + (ID).ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void InsertCustomer()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CustomerName = textBoxCustName.Text.Trim();
                objBAL.CustomerAddress = "";
                objBAL.CustomerTelNo = textBoxCustMobile.Text.Trim();
                objBAL.CustomerFaxNo = "";
                objBAL.CustomerEmail = "";
                objBAL.CustomerNICNo = "";
                objBAL.Remarks = "";
                objBAL.VATCustomer = false;
                objBAL.ContactPerson = textBoxCustCode.Text;
                objBAL.BalanceAmount = 0;
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.PriceMode = "Retail";

                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);

                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] data = ms.GetBuffer();
                //MySqlParameter p = new MySqlParameter("@d22", SqlDbType.Image);
                //p.Value = data;
                //cmd.Parameters.Add(p);
                objBAL.CustomerImage = data;
                objBAL.AreaId = 1;
                objBAL.NewAreaId = 1;
                objBAL.CreditLimit = 0;

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertCustomer(objBAL);
                if (count != 0)
                {
                    LoadCustomerCombo();
                    MessageBox.Show("Customer Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    searchCustomer();
                    txtItemCode.Select();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCustomerCombo()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                if (objInvDAL.retreiveCustomerComboData(objInvBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxCustomer.DataSource = objInvDAL.retreiveCustomerComboData(objInvBAL).Tables[0];
                    comboBoxCustomer.DisplayMember = "CustomerName";
                    comboBoxCustomer.ValueMember = "CustomerId";
                    comboBoxCustomer.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillCustomerTypePrice()
        {
            try
            {
                if (comboBoxCustomer.SelectedIndex != -1 && DiscRate > 0)
                {
                    txtSellingPrice.Text = (purchasePrice + (purchasePrice * DiscRate / 100)).ToString("0.00");

                    decimal decamt = 0;
                    decamt = Math.Round(Convert.ToDecimal(txtSellingPrice.Text) * 2, MidpointRounding.ToEven) / 2;
                    txtSellingPrice.Text = decamt.ToString("0.00");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void fillDiscRate()
        {
            try
            {
                DiscRate = 0;
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                ClassMasterDAL objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveCustomerDiscRate(objBAL);
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
                        DiscRate = Convert.ToDecimal(values[0].ToString());
                    }

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
                if (txtItemId.Text != "")
                {
                    lblNetTotal.Text = "0.00";
                    textBoxReceivable.Text = "0.00";
                    //lblCashTender.Text = "0.00";
                    //lblChange.Text = "0.00";
                    if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                    {
                        txtQuantity.Text = "1";
                    }
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";
                    //lblCashTender.Text = "0.00";

                    SearchItem();
                    //SearchItemByID();
                    //if (Convert.ToDecimal(txtQuantity.Text) > spPriceEffect)
                    //{
                    //    txtSellingPrice.Text = specialPrice.ToString("0.00");
                    //    //textBoxLDiscAmt.Text = (defaultPRice - specialPrice).ToString("0.00");
                    //}
                    if (newItem == true)
                    {
                        txtItemName.Select();
                    }
                    else
                    {
                        addStatus = true;
                        calculateTotal();
                        if (txtItemCode.Text == "111")
                        {
                            txtSellingPrice.ReadOnly = false;
                            txtSellingPrice.Select();
                        }
                        else
                        {
                            //txtSellingPrice.ReadOnly = true;
                            //txtQuantity.Select();
                            txtSellingPrice.Select();
                        }
                    }


                }
                //else if (txtItemCode.Text == "" && dgView.Rows.Count > 0)
                //{
                //    lblCashTender.Select();
                //}
                else
                {
                    txtSellingPrice.Select();
                }
            }
            catch (Exception)
            {

                throw;
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

        private void GenerateInvoice()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                Invoice = Convert.ToInt32(objInvDAL.SelectMaxSOHD(objInvBAL).Tables[1].Rows[0][0]) + 1;
                Sohdid = Convert.ToInt32(objInvDAL.SelectMaxSOHD(objInvBAL).Tables[0].Rows[0][0]);
                txtInvoiceNo.Text = Invoice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ResetEntry()
        {
            comboBoxCustomer.SelectedIndex = -1;
            cmbSalesRep.SelectedIndex = -1;
            //textBoxChequeNo.Clear();
            //comboBoxBank.Text = "";
            //dateTimePickerChqExpDate.Value = DateTime.Today;
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today;
            txtItemCode.Text = "";
            txtItemName.Text = "";
            textBoxInternalNo.Text = "";
            textBoxItemSinhala.Text = "";
            txtQuantity.Text = "1";
            txtSellingPrice.Text = "0.00";
            txtDisc.Text = "0";
            textBoxLDiscAmt.Text = "0.00";
            txtSubtotals.Text = "0.00";
            txtGross.Text = "0.00";

            lblStatus.Text = "";
            lblSubTotal.Text = "0.00";
            lblItemDiscount.Text = "0.00";
            lblGrossTot.Text = "0.00";
            textBoxReturn.Text = "0.00";
            txtTotDiscRate.Text = "0.00";
            textBoxVAT.Text = "0.00";
            textBoxNBT.Text = "0.00";
            textBoxAddChgs.Text = "0.00";
            textBoxAddChgPer.Text = "0";
            textBoxTotDiscPerc.Text = "0";
            //lblNetTotal.Text = "0.00";
            //lblCashTender.Text = "0.00";
            //lblChange.Text = "0.00";
            txtComment.Clear();
            checkBoxVAT.Checked = false;
            checkBoxNBT.Checked = false;
            dgView.Rows.Clear();
            txtItemCode.Focus();
            textBoxPriceDisc.Text = "0.00";
            textBoxCustMobile.Clear();
            textBoxCustCode.Clear();
            textBoxSerial.Clear();
            //textBoxCustCredit.Text = "0.00";
            comboBoxWarranty.Text = "No Warranty";
            checkBoxReturn.Checked = false;
            DiscRate = 0;
            CreditPay = 0;
        }

        void ItemAutoComplete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
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
                        txtItemCode.AutoCompleteCustomSource.Add(values[1].ToString());
                        txtItemName.AutoCompleteCustomSource.Add(values[2].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchCustomer()
        {
            try
            {
                comboBoxCustomer.SelectedIndex = -1;
                textBoxCustMobile.Clear();
                //textBoxCustCredit.Text = "0.00";
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.CustomerCode = textBoxCustCode.Text;
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveCustomerCodeData(objInvBAL);
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

                        comboBoxCustomer.SelectedValue = (values[0].ToString().Trim());
                        textBoxCustMobile.Text = (values[4].ToString().Trim());
                        textBoxCustName.Text = (values[1].ToString().Trim());
                        //textBoxCustCredit.Text = (values[10].ToString().Trim());
                    }
                    //lblCashTender.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchItemByID()
        {
            try
            {
                txtItemName.Clear();
                dateTimePickerFrom.Value = DateTime.Today;
                dateTimePickerTo.Value = DateTime.Today;
                textBoxInternalNo.Text = "";
                textBoxItemSinhala.Clear();
                availableQty = 0;
                txtSellingPrice.Text = "0.00";
                specialPrice = 0;
                defaultPRice = 0;
                //txtItemId.Clear();
                txtItemCode.Clear();
                comboBoxItemCat.SelectedIndex = -1;
                txtDisc.Text = "0";
                textBoxLDiscAmt.Text = "0.00";
                defaultDiscount = 0;
                FreeIssueEffectFrom = 0;
                spPriceEffect = 0;
                OriginalPrice = 0;
                purchasePrice = 0;
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemIDData(objInvBAL);
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

                        txtItemName.Text = (values[0].ToString().Trim());
                        //if (Convert.ToDecimal(values[1].ToString()) > 0)
                        //{
                        //    txtSellingPrice.ReadOnly = true;
                        //}
                        //if (Convert.ToDecimal(values[1].ToString()) == 0)
                        //{
                        //    txtSellingPrice.ReadOnly = false;
                        //}
                        txtSellingPrice.Text = (values[1].ToString().Trim());
                        txtItemCode.Text = (values[2].ToString().Trim());
                        availableQty = Convert.ToDecimal(values[3].ToString().Trim());
                        comboBoxItemCat.SelectedValue = Convert.ToInt32(values[4].ToString());
                        dateTimePickerFrom.Value = Convert.ToDateTime(values[5].ToString());
                        dateTimePickerTo.Value = Convert.ToDateTime(values[6].ToString());
                        if (((dateTimePickerFrom.Value <= DateTime.Today) && (dateTimePickerTo.Value >= DateTime.Today)) || ((dateTimePickerFrom.Value == Convert.ToDateTime("1753-01-01")) && (dateTimePickerTo.Value == Convert.ToDateTime("1753-01-01"))))
                        {
                            //textBoxLDiscAmt.Text = ((Convert.ToDecimal(values[7].ToString()) / 100) * (Convert.ToDecimal(values[1].ToString()))).ToString("0.00");
                            //defaultDiscount = ((Convert.ToDecimal(values[7].ToString()) / 100) * (Convert.ToDecimal(values[1].ToString())));

                            textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                            defaultDiscount = Convert.ToDecimal(values[7].ToString());
                        }
                        textBoxItemSinhala.Text = (values[8].ToString().Trim());
                        FreeIssueEffectFrom = Convert.ToInt32(values[9].ToString());
                        defaultPRice = Convert.ToDecimal(values[1].ToString());
                        specialPrice = Convert.ToDecimal(values[10].ToString());
                        spPriceEffect = Convert.ToDecimal(values[11].ToString());
                        purchasePrice = Convert.ToDecimal(values[12].ToString());
                    }
                    OriginalPrice = Convert.ToDecimal(txtSellingPrice.Text);
                    txtSellingPrice.Select();
                    //txtQuantity.Select();

                }
                //else
                //{
                //    DialogResult result = MessageBox.Show("Item not exist in the Stock Do you want to add it?", "New Item.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (result == DialogResult.Yes)
                //    {
                //        txtItemName.Select();
                //        newItem = true;
                //    }
                //    else
                //    {
                //        txtItemCode.Select();
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchItem()
        {
            try
            {
                txtItemName.Clear();
                dateTimePickerFrom.Value = DateTime.Today;
                dateTimePickerTo.Value = DateTime.Today;
                textBoxInternalNo.Text = "";
                textBoxItemSinhala.Clear();
                availableQty = 0;
                txtSellingPrice.Text = "0.00";
                specialPrice = 0;
                defaultPRice = 0;
                txtItemId.Clear();
                comboBoxItemCat.SelectedIndex = -1;
                txtDisc.Text = "0";
                textBoxLDiscAmt.Text = "0.00";
                defaultDiscount = 0;
                FreeIssueEffectFrom = 0;
                spPriceEffect = 0;
                OriginalPrice = 0;
                purchasePrice = 0;
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemCode = txtItemCode.Text;
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsData(objInvBAL);
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

                        txtItemName.Text = (values[0].ToString().Trim());
                        txtSellingPrice.Text = (values[1].ToString().Trim());
                        txtItemId.Text = (values[2].ToString().Trim());
                        availableQty = Convert.ToDecimal(values[3].ToString().Trim());
                        comboBoxItemCat.SelectedValue = Convert.ToInt32(values[4].ToString());
                        dateTimePickerFrom.Value = Convert.ToDateTime(values[5].ToString());
                        dateTimePickerTo.Value = Convert.ToDateTime(values[6].ToString());
                        if (((dateTimePickerFrom.Value <= DateTime.Today) && (dateTimePickerTo.Value >= DateTime.Today)) || ((dateTimePickerFrom.Value == Convert.ToDateTime("1753-01-01")) && (dateTimePickerTo.Value == Convert.ToDateTime("1753-01-01"))))
                        {
                            textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                            defaultDiscount = Convert.ToDecimal(values[7].ToString());
                        }
                        textBoxItemSinhala.Text = (values[8].ToString().Trim());
                        FreeIssueEffectFrom = Convert.ToInt32(values[9].ToString());
                        defaultPRice = Convert.ToDecimal(values[1].ToString());
                        specialPrice = Convert.ToDecimal(values[10].ToString());
                        spPriceEffect = Convert.ToDecimal(values[11].ToString());
                        purchasePrice = Convert.ToDecimal(values[12].ToString());
                    }
                    OriginalPrice = Convert.ToDecimal(txtSellingPrice.Text);
                    fillCustomerTypePrice();
                    txtSellingPrice.Select();
                    //txtQuantity.Select();

                }
                else
                {
                    txtItemCode.Select();
                    FormItemSearch frm4 = new FormItemSearch();
                    frm4.frm4 = this;
                    frm4.form = 4;
                    frm4.ShowDialog(this);
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
                if (checkBoxItemBal.Checked == false)
                {
                    if (availableQty < Convert.ToDecimal(txtQuantity.Text))
                    {
                        MessageBox.Show("Sorry item is out of stock.\n Please select other item..", "Transaction Failed.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtItemCode.Focus();
                        return;
                    }
                    else if (availableQty <= 0)
                    {
                        MessageBox.Show("Sorry item is out of stock.\n Please select other item..", "Transaction Failed.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtItemCode.Focus();
                        return;
                    }
                }
                if (txtItemCode.Text == "" || txtItemName.Text == "")
                {
                    MessageBox.Show("Please enter item to purchase before you can save this record.", "Front Desk Module", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                else
                {
                    addtoGrid = true;
                    calculateTotal();
                    addtoGrid = false;
                    FreeIssueStatus = false;
                    

                    int n = dgView.Rows.Add();

                    dgView.Rows[n].Cells["ItemCode"].Value = txtItemCode.Text;
                    dgView.Rows[n].Cells["ItemName"].Value = txtItemName.Text;
                    dgView.Rows[n].Cells["InternalNo"].Value = textBoxInternalNo.Text;
                    dgView.Rows[n].Cells["ItemNameSinhala"].Value = textBoxItemSinhala.Text;
                    dgView.Rows[n].Cells["Qty"].Value = txtQuantity.Text;
                    dgView.Rows[n].Cells["Price"].Value = txtSellingPrice.Text;
                    dgView.Rows[n].Cells["Amount"].Value = txtGross.Text;
                    dgView.Rows[n].Cells["Discount"].Value = textBoxLDiscAmt.Text;
                    dgView.Rows[n].Cells["NetAmount"].Value = txtSubtotals.Text;
                    dgView.Rows[n].Cells["ItemsId"].Value = txtItemId.Text;
                    dgView.Rows[n].Cells["ItemCatID"].Value = comboBoxItemCat.SelectedValue.ToString();
                    dgView.Rows[n].Cells["FreeIssue"].Value = FreeIssueQty.ToString();
                    dgView.Rows[n].Cells["PriceDisc"].Value = SelPriceDisc.ToString();
                    dgView.Rows[n].Cells["Warranty"].Value = comboBoxWarranty.Text;
                    dgView.Rows[n].Cells["SerialNo"].Value = textBoxSerial.Text;
                    if (checkBoxReturn.Checked == true)
                    {
                        dgView.Rows[n].Cells["Rtn"].Value = "1";
                    }
                    else
                    {
                        dgView.Rows[n].Cells["Rtn"].Value = "0";
                    }

                    dgView.FirstDisplayedScrollingRowIndex = n;
                    dgView.CurrentCell = dgView.Rows[n].Cells[0];
                    dgView.Rows[n].Selected = true;

                    checkReturn();

                    txtItemCode.Text = "";
                    txtItemName.Text = "";
                    dateTimePickerFrom.Value = DateTime.Today;
                    dateTimePickerTo.Value = DateTime.Today;
                    textBoxInternalNo.Text = "";
                    textBoxItemSinhala.Clear();
                    txtQuantity.Text = "1";
                    txtSellingPrice.Text = "0.00";
                    txtGross.Text = "0.00";
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";
                    txtSubtotals.Text = "0.00";
                    txtItemId.Text = "0";
                    textBoxSerial.Clear();
                    SelPriceDisc = 0;
                    comboBoxItemCat.SelectedIndex = -1;
                    comboBoxWarranty.Text = "No Warranty";
                    addStatus = false;
                    CalculateTotal();
                }
                txtItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkReturn()
        {
            try
            {
                if (dgView.Rows.Count > 0)
                {
                    for (int i = 0; i < dgView.Rows.Count; i++)
                    {
                        if ((dgView["Rtn", i].Value.ToString()) == "1")
                        {
                            dgView.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                            //dgView.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemEdit()
        {
            try
            {
                if (dgView.SelectedRows.Count > 0)
                {
                    int selectedrowindex = dgView.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgView.Rows[selectedrowindex];

                    string a = Convert.ToString(selectedRow.Cells["ItemCode"].Value);
                    string q = Convert.ToString(selectedRow.Cells["Qty"].Value);
                    string p = Convert.ToString(selectedRow.Cells["Price"].Value);
                    string r = Convert.ToString(selectedRow.Cells["ItemsId"].Value);
                    // MessageBox.Show(a.ToString());
                    txtItemCode.Text = a.ToString();
                    txtItemId.Text = r.ToString();

                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";

                    //SearchItem();
                    SearchItemByID();
                    txtQuantity.Text = q.ToString();
                    txtSellingPrice.Text = p.ToString();
                    calculateTotal();
                    //  AddtoGrid();
                    //txtQuantity.Select();

                    dgView.Rows.RemoveAt(dgView.SelectedRows[0].Index);
                    CalculateTotal();


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void CalculateTotal()
        {
            try
            {
                decimal SubTotal = 0;
                decimal ItemDiscount = 0;
                decimal GrossTot = 0;
                decimal PriceDisc = 0;
                decimal RtnTot = 0;
                TotalLineDiscTotal = 0;

                int i = dgView.RowCount;

                for (int a = 0; a < i; a++)
                {
                    try
                    {
                        if (dgView.Rows[a].Cells["Rtn"].Value.ToString() == "0")
                        {
                            SubTotal += Convert.ToDecimal(dgView.Rows[a].Cells["Amount"].Value.ToString());
                            ItemDiscount += Convert.ToDecimal(dgView.Rows[a].Cells["Discount"].Value.ToString());
                            GrossTot += Convert.ToDecimal(dgView.Rows[a].Cells["NetAmount"].Value.ToString());
                            PriceDisc += Convert.ToDecimal(dgView.Rows[a].Cells["PriceDisc"].Value.ToString());
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
                lblSubTotal.Text = SubTotal.ToString("0.00");
                lblItemDiscount.Text = ItemDiscount.ToString("0.00");
                lblGrossTot.Text = GrossTot.ToString("0.00");
                textBoxPriceDisc.Text = PriceDisc.ToString("0.00");
                textBoxReturn.Text = RtnTot.ToString("0.00");
                lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text))).ToString("0.00");
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text))).ToString("0.00");


                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void StockChecker()
        {
            try
            {
                availableQty = 0;
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemCode = txtItemCode.Text;
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsData(objInvBAL);
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
                        availableQty = Convert.ToDecimal(values[3].ToString().Trim());
                    }
                }
                //txtQuantity.Select();
                txtSellingPrice.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSOHDNew()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                if (comboBoxCustomer.SelectedIndex == -1)
                {
                    comboBoxCustomer.SelectedValue = 0;
                }
                objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
                if (cmbSalesRep.SelectedIndex == -1)
                {
                    cmbSalesRep.SelectedValue = 0;
                }
                objInvBAL.RepId = Convert.ToInt32(cmbSalesRep.SelectedValue);
                objInvBAL.PayModeId = 0;
                objInvBAL.BillNo = Convert.ToInt32(txtInvoiceNo.Text);
                objInvBAL.SOGrossTotal = Convert.ToDecimal(lblGrossTot.Text);
                objInvBAL.SODiscount = Convert.ToDecimal(txtTotDiscRate.Text);
                objInvBAL.SONetTotal = Convert.ToDecimal(lblNetTotal.Text);
                objInvBAL.Remarks = txtComment.Text;
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objInvBAL.Cash = 0;
                objInvBAL.AdditionalChgs = Convert.ToDecimal(textBoxPriceDisc.Text);
                objInvBAL.VAT = Convert.ToDecimal(textBoxVAT.Text);
                objInvBAL.NBT = Convert.ToDecimal(textBoxNBT.Text);
                objInvBAL.InternalNo = textBoxInternalNo.Text;
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    comboBoxBranch.SelectedValue = 0;
                }
                objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                objInvBAL.ReturnTotal = Convert.ToDecimal(textBoxReturn.Text);
                objInvBAL.CreditPay = Convert.ToDecimal(CreditPay.ToString());
                objInvBAL.CreditTotal = 0;
                objInvBAL.CompletedDate = dateTimePickerCompletedDate.Value;
                objInvBAL.InvoiceStatusId = Convert.ToInt32(comboBoxInvoiceStatus.SelectedValue);
                if (checkBoxIsRepair.Checked == true)
                {
                    objInvBAL.RepairBill = true;
                }
                if (checkBoxIsRepair.Checked == false)
                {
                    objInvBAL.RepairBill = false;
                }

                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.Insertsorderhd(objInvBAL);
                txtInvoiceNo.Text = count.ToString();

                //int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != "")
                {
                    //GenerateInvoice();
                    SaveSODT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SaveSODT()
        {
            try
            {

                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    if (dgView.Rows[i].Cells["Rtn"].Value.ToString() == "1")
                    {
                        objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);//lblUserId.Tex
                        objInvBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                        objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value);
                        objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value);
                        objInvBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value);
                        objInvBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                        objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                        objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                        objInvBAL.Warranty = dgView.Rows[i].Cells["Warranty"].Value.ToString().Trim();
                        objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                        objInvBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                        objInvBAL.InternalNo = "0";
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);

                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertSORtn(objInvBAL);
                    }
                    else
                    {
                        objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);//lblUserId.Tex
                        objInvBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                        objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value);
                        objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value);
                        objInvBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value);
                        objInvBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                        objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                        objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                        objInvBAL.Warranty = dgView.Rows[i].Cells["Warranty"].Value.ToString().Trim();
                        objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                        objInvBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                        objInvBAL.InternalNo = "0";
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);

                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertSorderDt(objInvBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }

                }

                if (savestate == true)
                {
                    MessageBox.Show("Sales Order Saved Successfully", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (AllowSMS == true)
                    {
                        DialogResult result1 = MessageBox.Show("Do you want to send Order detail to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1 == DialogResult.Yes && textBoxCustMobile.Text != "")
                        {
                            sendCustomerMessage();
                        }
                    }
                    
                    ResetEntry();
                    blnPaid = false;
                    txtItemCode.Select();
                    GenerateInvoice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void sendCustomerMessage()
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string message2;
                    to = Convert.ToInt64(textBoxCustMobile.Text).ToString();
                    message2 = "Dear " + textBoxCustName.Text + " Your Order Details are, Ref No is: " + txtInvoiceNo.Text + ". Expected Complete Date is : " + dateTimePickerCompletedDate.Value.ToShortDateString() + ". " + companyname.ToString() + ". Thank you.";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

                    //string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=" + apikey + "&destination=94" + to +"&message=" + message2 + "&from=" + fromval;
                    //string url = "https://cloud.websms.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
                    string url = SMSUrl + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
                    //Call web api to send sms messages
                    string result = client.DownloadString(url);
                    if (result.Contains("0"))
                        MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void SaveRecord()
        {
            try
            {
                PrintBalance = false;
                string ItemNo = string.Empty;
                string Description = string.Empty;
                string UnitPrice = string.Empty;
                string Qty = string.Empty;
                string Amount = string.Empty;
                string Discount = string.Empty;

                if (dgView.Rows.Count == 0)
                {
                    MessageBox.Show("Please add items.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtItemCode.Focus();
                    txtItemCode.Select();
                    return;
                }   
                else
                {

                    if (comboBoxCustomer.SelectedIndex != -1)
                    {
                        PrintBalance = true;
                    }
                    Sohdid = 0;
                    //SaveSOHD();
                    //SaveTempSales();
                    SaveSOHDNew();
                    GenerateInvoice();
                    ResetEntry();
                    blnPaid = false;
                    txtItemCode.Select();
                    //displyThank();
                    //displayClear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void calculateTotal()
        {
            decimal Total = 0;
            decimal sum = 0;
            totDisc = 0;
            decimal quantity = 1;
            FreeIssueQty = 0;
            SelPriceDisc = 0;

            if (txtQuantity.Text.Equals("") || txtDisc.Text.Equals(""))
            {
                txtSubtotals.Text = "0.00";
            }
            else
            {
                try
                {
                    decimal unitprice = Convert.ToDecimal(txtSellingPrice.Text);
                    decimal discount = decimal.Parse(txtDisc.Text);
                    decimal Qty = Convert.ToDecimal(txtQuantity.Text);

                    if (addtoGrid == true)
                    {
                        if (FreeIssueEffectFrom > 0)
                        {
                            FreeIssueStatus = true;
                            FreeIssueQty = Convert.ToInt32(txtQuantity.Text) / FreeIssueEffectFrom;
                            quantity = decimal.Parse(txtQuantity.Text);
                            txtQuantity.Text = quantity.ToString("0.00");
                        }
                    }

                    if (addStatus == true)
                    {
                        if ((string.IsNullOrEmpty(textBoxLDiscAmt.Text)) || (textBoxLDiscAmt.Text.Trim().Equals(string.Empty)))
                        {
                            textBoxLDiscAmt.Text = "0.00";
                        }
                        unitprice = Convert.ToDecimal(txtSellingPrice.Text);
                        discount = decimal.Parse(txtDisc.Text);
                        Total = decimal.Parse(txtSellingPrice.Text) * decimal.Parse(txtQuantity.Text);
                        txtGross.Text = Total.ToString("0.00");
                        if (defaultDiscount > 0)
                        {
                            totDisc = (defaultDiscount * (Convert.ToDecimal(txtQuantity.Text)));
                        }
                        if (defaultDiscount <= 0 && discount > 0)
                        {
                            totDisc = (((Total / 100) * Convert.ToDecimal(txtDisc.Text)));
                        }
                        if (defaultDiscount <= 0 && discount <= 0 && Convert.ToDecimal(textBoxLDiscAmt.Text) > 0)
                        {
                            totDisc = ((Convert.ToDecimal(textBoxLDiscAmt.Text)));
                        }

                        textBoxLDiscAmt.Text = totDisc.ToString("0.00");
                        sum = Convert.ToDecimal(Total - totDisc);
                        txtSubtotals.Text = sum.ToString("0.00");
                        if (txtItemCode.Text != "111")
                        {
                            SelPriceDisc = ((OriginalPrice - Convert.ToDecimal(txtSellingPrice.Text)) * Convert.ToDecimal(txtQuantity.Text));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void calcNet()
        {
            try
            {
                if (checkBoxVAT.Checked == true && checkBoxNBT.Checked == false)
                {
                    textBoxVAT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 11) / 100).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == false && checkBoxNBT.Checked == true)
                {
                    textBoxNBT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 2) / 100).ToString("0.00");
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + +Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == true && checkBoxNBT.Checked == true)
                {
                    textBoxNBT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 2) / 100).ToString("0.00");
                    textBoxVAT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxNBT.Text)) * 11) / 100).ToString("0.00");
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == false && checkBoxNBT.Checked == false)
                {
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text))).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
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
                        //if (alistForm[i].ToString().Trim() == "ChangePrice")
                        //{
                        //    txtSellingPrice.ReadOnly = false;
                        //}
                        if (alistForm[i].ToString().Trim() == "VAT Invoice")
                        {
                            label45.Visible = true;
                            label40.Visible = true;
                            checkBoxVAT.Visible = true;
                            checkBoxNBT.Visible = true;
                            textBoxVAT.Visible = true;
                            textBoxNBT.Visible = true;
                            VATStatus = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Discount")
                        {
                            txtDisc.ReadOnly = false;
                            textBoxLDiscAmt.ReadOnly = false;
                        }
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



        #endregion

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FreeIssueStatus == false)
                {
                    if ((string.IsNullOrEmpty(txtQuantity.Text)) || (txtQuantity.Text.Trim().Equals(string.Empty)))
                    {
                        txtQuantity.Text = "0";
                    }
                    if (Convert.ToDecimal(txtSellingPrice.Text) > 0)
                    {
                        SelPriceDisc = 0;
                        if (txtItemCode.Text != "111")
                        {
                            SelPriceDisc = ((OriginalPrice - EditedPrice) * Convert.ToDecimal(txtQuantity.Text));
                        }

                    }
                    calculateTotal();

                }
            }
            catch (Exception)
            {

            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                if (txtItemCode.Text != "")
                {
                    lblNetTotal.Text = "0.00";
                    if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                    {
                        txtQuantity.Text = "1";
                    }
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";

                    SearchItem();
                    if (newItem == true)
                    {
                        txtItemName.Select();
                    }
                    else
                    {
                        addStatus = true;
                        calculateTotal();
                        if (txtItemCode.Text == "111")
                        {
                            txtSellingPrice.ReadOnly = false;
                            txtSellingPrice.Select();
                        }
                        else
                        {
                            txtSellingPrice.Select();
                        }
                    }


                }
                else if (txtItemCode.Text == "" && dgView.Rows.Count > 0)
                {
                    cmdSave.Select();
                }
                else
                {
                    txtItemCode.Select();
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceNo.Text == "")
                {
                    MessageBox.Show("Please enter Order No.");
                    txtItemCode.Focus();
                    return;
                }
                else if (dgView.RowCount < 1)
                {
                    MessageBox.Show("Please enter item to purchase before you can save this record.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtItemCode.Focus();
                    return;
                }
                else
                {
                    SaveRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillImage()
        {
            pictureBox1.Image = Properties.Resources.Person;
        }

        private void FormSalesOrder_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                txtItemCode.Select();
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();

                if (objDAL.retreivePOLoadingData(objBAL).Tables[3].Rows.Count > 0)
                {
                    comboBoxItemCat.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[3];
                    comboBoxItemCat.DisplayMember = "ItemCatName";
                    comboBoxItemCat.ValueMember = "ItemCatId";
                    comboBoxItemCat.SelectedIndex = -1;
                }
                if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
                {
                    comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.ValueMember = "BranchId";
                    comboBoxBranch.SelectedIndex = 0;
                }

                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                if (objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                    comboBoxCustomer.DisplayMember = "CustomerName";
                    comboBoxCustomer.ValueMember = "CustomerId";
                    comboBoxCustomer.SelectedIndex = -1;
                }

                BALClass objUSBAL = new BALClass();
                DALClass objUSDAL = new DALClass();
                if (objUSDAL.retreiveEmployeeName(objUSBAL).Tables[1].Rows.Count > 0)
                {
                    cmbSalesRep.DataSource = objUSDAL.retreiveEmployeeName(objUSBAL).Tables[1];
                    cmbSalesRep.DisplayMember = "EmployeeName";
                    cmbSalesRep.ValueMember = "EmployeeID";
                    cmbSalesRep.SelectedIndex = -1;
                }


                GenerateInvoice();
                //ItemAutoComplete();

                //this.KeyPreview = true;
                //this.KeyDown += new KeyEventHandler(frmInvoice_KeyDown);

                loadStatus = false;
                //displayClear();
                checkBoxItemBal.Checked = true;
                fillImage();
                loadInvoiceStatus();
                SelectCompanyData();
                txtItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDecimal(txtQuantity.Text) > spPriceEffect && spPriceEffect != 0)
                {
                    txtSellingPrice.Text = specialPrice.ToString();
                    TotalLineDisc = 0;
                    TotalLineDisc = ((OriginalPrice - specialPrice) * Convert.ToDecimal(txtQuantity.Text));
                }
                else
                {
                    TotalLineDisc = 0;
                    TotalLineDisc = ((OriginalPrice - EditedPrice) * Convert.ToDecimal(txtQuantity.Text));
                }
                AddtoGrid();
            }
        }

        private void txtDisc_Validating(object sender, CancelEventArgs e)
        {
            calculateTotal();
        }

        private void dgView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dgView.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dgView.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void txtTotDiscRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtTotDiscRate.Text)) || (txtTotDiscRate.Text.Trim().Equals(string.Empty)))
                {
                    txtTotDiscRate.Text = "0.00";
                }
                //grossTot = Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text);
                //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text))).ToString("0.00");

                //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSellingPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSellingPrice.Text != "")
                {
                    //decimal decamt = 0;
                    //decamt = Math.Round(Convert.ToDecimal(txtSellingPrice.Text) * 2, MidpointRounding.ToEven) / 2;
                    //txtSellingPrice.Text = decamt.ToString("0.00");
                    SelPriceDisc = 0;
                    if (txtItemCode.Text != "111")
                    {
                        SelPriceDisc = ((OriginalPrice - Convert.ToDecimal(txtSellingPrice.Text)) * Convert.ToDecimal(txtQuantity.Text));
                    }
                    calculateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormSalesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                DialogResult result = MessageBox.Show("Do you want to Clear All?", "Reset Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    GenerateInvoice();
                    ResetEntry();
                    blnPaid = false;
                    txtItemCode.Select();
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                txtItemCode.Select();
                FormItemSearch frm4 = new FormItemSearch();
                frm4.frm4 = this;
                frm4.form = 4;
                frm4.wh = 1;
                frm4.lblUser.Text = lblUser.Text;
                frm4.lblUserId.Text = "3";
                frm4.ShowDialog(this);
            }
            else if (e.KeyCode == Keys.F3)
            {
                textBoxLDiscAmt.Select();
            }
            else if (e.KeyCode == Keys.F4)
            {
                cmdSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                DialogResult result = MessageBox.Show("Do you want to Remove Selected Item?", "Remove Item Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    RemoveItem();
                }
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (txtItemCode.Text == "")
                {
                    addStatus = true;
                    ItemEdit();
                }

                txtQuantity.Select();
            }
            else if (e.KeyCode == Keys.F7)
            {
                textBoxCustCode.Select();
                FormSearchCustomer frm1 = new FormSearchCustomer();
                frm1.frm1 = this;
                frm1.form = 1;
                frm1.ShowDialog(this);
            }
            else if (e.KeyCode == Keys.F8)
            {
                DialogResult result = MessageBox.Show("Do you want to Close The Window?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                //exitCashier();
            }
            else if (e.KeyCode == Keys.F10)
            {
                totDiscPercStatus = false;
                txtTotDiscRate.ReadOnly = false;
                textBoxTotDiscPerc.ReadOnly = true;
                txtTotDiscRate.Select();
            }
            else if (e.KeyCode == Keys.F11)
            {

            }
            else if (e.KeyCode == Keys.F12)
            {

            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelPriceDisc = 0;
                addStatus = true;
                calculateTotal();
                txtQuantity.Select();
            }
        }

        private void txtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddtoGrid();
            }
        }

        private void textBoxTotDiscPerc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxTotDiscPerc.Text != "")
                {
                    if (Convert.ToDecimal(textBoxTotDiscPerc.Text) > 0)
                    {
                        txtTotDiscRate.Text = ((Convert.ToDecimal(textBoxTotDiscPerc.Text) / 100) * Convert.ToDecimal(lblGrossTot.Text)).ToString("0.00");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you want to Close The Window?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    this.Close();
            //}
            sendCustomerMessage();

            //using (System.Net.WebClient client = new System.Net.WebClient())
            //{
            //    try
            //    {
            //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
            //                           SecurityProtocolType.Tls11 |
            //                           SecurityProtocolType.Tls12;

            //        string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=ae91ec87d474c19&destination=94719249743&message=test&from=SPEEDWAY-TH";
            //        //Call web api to send sms messages
            //        string result = client.DownloadString(url);
            //        if (result.Contains("0"))
            //            MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        else
            //            MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (addStatus == true)
                {
                    decimal Total;
                    decimal sum = 0;

                    if ((string.IsNullOrEmpty(txtDisc.Text)) || (txtDisc.Text.Trim().Equals(string.Empty)))
                    {
                        txtDisc.Text = "0";
                    }
                    decimal unitprice = Convert.ToDecimal(txtSellingPrice.Text);
                    decimal discount = decimal.Parse(txtDisc.Text);
                    Total = decimal.Parse(txtSellingPrice.Text) * decimal.Parse(txtQuantity.Text);
                    txtGross.Text = Total.ToString("0.00");
                    totDisc = (((Total / 100) * Convert.ToDecimal(txtDisc.Text)));
                    //totDisc = (((Total / 100) * Convert.ToDecimal(txtDisc.Text)) * Convert.ToDecimal(txtQuantity.Text));
                    textBoxLDiscAmt.Text = totDisc.ToString();
                    sum = Convert.ToDecimal(Total - totDisc);
                    txtSubtotals.Text = sum.ToString("0.00");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxLDiscAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (addStatus == true)
                {
                    if ((string.IsNullOrEmpty(textBoxLDiscAmt.Text)) || (textBoxLDiscAmt.Text.Trim().Equals(string.Empty)))
                    {
                        textBoxLDiscAmt.Text = "0.00";
                    }
                    decimal Total;
                    decimal sum = 0;
                    totDisc = 0;
                    decimal unitprice = Convert.ToDecimal(txtSellingPrice.Text);
                    decimal discount = decimal.Parse(txtDisc.Text);
                    Total = decimal.Parse(txtSellingPrice.Text) * decimal.Parse(txtQuantity.Text);
                    txtGross.Text = Total.ToString("0.00");
                    totDisc = (Convert.ToDecimal(textBoxLDiscAmt.Text));
                    //textBoxLDiscAmt.Text = totDisc.ToString("0.00");
                    sum = Convert.ToDecimal(Total - totDisc);
                    txtSubtotals.Text = sum.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxLDiscAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddtoGrid();
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
            AutoCompleteCustContact();
            if (autocomplete == true)
            {
                ItemAutoComplete();

            }
        }

        private void txtSellingPrice_Validating(object sender, CancelEventArgs e)
        {
            //EditedPrice = 0;
            //EditedPrice = Convert.ToDecimal(txtSellingPrice.Text);
            //if (purchasePrice > Convert.ToDecimal(txtSellingPrice.Text))
            //{
            //    DialogResult result = MessageBox.Show("Your Selling Price is less than Purchase Price. Do you want to Change the Price?", "Purchase Price Alert.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        txtQuantity.Select();
            //        txtSellingPrice.Select();
            //        return;
            //    }
            //    else
            //    {
            //        txtQuantity.Select();
            //    }
            //}
        }

        private void textBoxCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxCustCode.Text != "")
                {
                    searchCustomer();
                    txtItemCode.Select();
                }
                else
                {
                    textBoxCustCode.Select();
                    FormSearchCustomer frm1 = new FormSearchCustomer();
                    frm1.frm1 = this;
                    frm1.form = 1;
                    frm1.ShowDialog(this);
                }
            }
        }

        private void textBoxTotDiscPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmdSave.Select();
            }
        }

        private void txtTotDiscRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cmdSave.Select();
            }
        }

        private void checkBoxReturn_CheckedChanged(object sender, EventArgs e)
        {
            txtItemCode.Select();
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxCustomer.SelectedIndex != -1)
            {
                fillDiscRate();
                textBoxCustName.Text = comboBoxCustomer.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReprintInvoice();
        }

        private void ReprintInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportA4SOCr rpt = new CrystalReportA4SOCr();
                objBAL = new ClassPOBAL();
                objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveTAWSOData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                rpt.PrintOptions.PrinterName = "";
                rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;
                //if (Option2 == true)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    CrystalReportA4SOCr rpt = new CrystalReportA4SOCr();
                //    objBAL = new ClassPOBAL();
                //    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                //    objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //    rpt.PrintOptions.PrinterName = "";
                //    rpt.PrintToPrinter(1, false, 0, 0);
                //    Cursor.Current = Cursors.Default;
                //}
                //else if (Option3 == true)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    CrystalReportA4InvoiceSCr rpt = new CrystalReportA4InvoiceSCr();
                //    objBAL = new ClassPOBAL();
                //    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                //    objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //    rpt.PrintOptions.PrinterName = "";
                //    rpt.PrintToPrinter(1, false, 0, 0);
                //    Cursor.Current = Cursors.Default;
                //}
                //else if (Option4 == true)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    CrystalReportInvoice5in3 rpt = new CrystalReportInvoice5in3();
                //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                //    objBAL = new ClassPOBAL();
                //    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                //    objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //    rpt.PrintOptions.PrinterName = "";
                //    rpt.PrintToPrinter(1, false, 0, 0);
                //    Cursor.Current = Cursors.Default;

                //}
                //else if (Option5 == true)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    CrystalReportInvoice5in3S rpt = new CrystalReportInvoice5in3S();
                //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                //    objBAL = new ClassPOBAL();
                //    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                //    objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //    rpt.PrintOptions.PrinterName = "";
                //    rpt.PrintToPrinter(1, false, 0, 0);
                //    Cursor.Current = Cursors.Default;
                //}
                //else if (Option6 == true)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    CrystalReportInvoice2inLogoE rpt = new CrystalReportInvoice2inLogoE();
                //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                //    objBAL = new ClassPOBAL();
                //    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                //    objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //    rpt.PrintOptions.PrinterName = "";
                //    rpt.PrintToPrinter(1, false, 0, 0);
                //    Cursor.Current = Cursors.Default;
                //}
                //else if (Option7 == true)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    CrystalReportInvoice2inLogoS rpt = new CrystalReportInvoice2inLogoS();
                //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                //    objBAL = new ClassPOBAL();
                //    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                //    objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //    rpt.PrintOptions.PrinterName = "";
                //    rpt.PrintToPrinter(1, false, 0, 0);
                //    Cursor.Current = Cursors.Default;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ReprintInvoice();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            insertInvoiceCustomer();
        }

        private void comboBoxCustomer_TextChanged(object sender, EventArgs e)
        {
            textBoxCustName.Text = comboBoxCustomer.Text;
        }

        private void textBoxSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Select();
            }
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSellingPrice.Select();
            }
        }

        private void textBoxCustMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxCustMobile.Text != "")
                {
                    searchCustomerByContactNo();
                    if (textBoxCustCode.Text == "")
                    {
                        simpleButton3.Select();
                    }
                    else
                    {
                        txtItemCode.Select();
                    }
                }
                if (textBoxCustCode.Text == "")
                {
                    simpleButton3.Select();
                }
                else
                {
                    txtItemCode.Select();
                }

            }
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}
