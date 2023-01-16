using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormInvoiceTuch : Form
    {
        #region Local Variables
        private TextBox lastTB = null;

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
        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9, Option10, Option11, Option12, Option13, Option14, Option15, Option16, Option17, Option18, Option19, Option20, Option21, Option22;
        string lDiscString, message;
        public bool blnPaid, newItem;
        public decimal CreditPay = 0;
        decimal purchasePrice, DiscRate, MinSellingPrice, CreditLimit, AdvanceAmount, balance, totBal, cashbalance;
        string pdfFileSales = "C:\\Rpt\\Invoice.pdf";
        string pdfFileDayEnd = "C:\\Rpt\\DayEndReport.pdf";


        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

        #endregion

        #region Constructor
        public FormInvoiceTuch()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public static Control FindFocusedControl(Control control)
        {
            //try
            //{
                ContainerControl container = control as ContainerControl;
                while (container != null)
                {
                    control = container.ActiveControl;
                    container = control as ContainerControl;
                }
                return control;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        private void GenerateInvoice()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                Invoice = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]) + 1;
                Sohdid = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[0].Rows[0][0]);
                txtInvoiceNo.Text = Invoice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillOptions()
        {
            try
            {
                BALUser objUser = new BALUser();
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveAllOptions(objUser);
                if (objUser.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objUser.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        alistOption.Add(values[0].ToString());

                    }
                    for (int i = 0; i < alistOption.Count; i++)
                    {
                        if (alistOption[i].ToString().Trim() == "1")
                        {
                            //PrintInvoiceStatus = true;
                            Option1 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "2")
                        {
                            Option2 = true;
                            //PrintDetailWithLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "3")
                        {
                            Option3 = true;
                            //PrintDetailWithoutLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "4")
                        {
                            Option4 = true;
                            //PrintDetailWithLogoSinhala = true;
                        }
                        if (alistOption[i].ToString().Trim() == "5")
                        {
                            Option5 = true;
                            //PrintDetailWithoutLogoSinhala = true;
                        }
                        if (alistOption[i].ToString().Trim() == "6")
                        {
                            Option6 = true;
                            //PrintwithoutDetailWithLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "7")
                        {
                            Option7 = true;
                            //PrintwithoutDetailWithoutLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "8")
                        {
                            Option8 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "9")
                        {
                            Option9 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "10")
                        {
                            Option10 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "11")
                        {
                            Option11 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "12")
                        {
                            Option12 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "13")
                        {
                            Option13 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "14")
                        {
                            Option14 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "15")
                        {
                            Option15 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "16")
                        {
                            Option16 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "17")
                        {
                            Option17 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "18")
                        {
                            Option18 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "19")
                        {
                            Option19 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "20")
                        {
                            Option20 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "21")
                        {
                            Option21 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "22")
                        {
                            Option22 = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void fillCashBalance()
        //{
        //    try
        //    {
        //        objInvBAL = new ClassInvoiceBAL();
        //        objInvDAL = new ClassInvoiveDAL();
        //        objInvBAL.UserId = Convert.ToInt32(lblUserId.Text.Trim());
        //        objInvBAL.DtDataSet = objInvDAL.SelectCashBalnce(objInvBAL);
        //        if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            lblopenbalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][0].ToString()).ToString("0.00");
        //            lblreciveAmount.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][1].ToString()).ToString("0.00");
        //            lblPayments.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][2].ToString()).ToString("0.00");
        //            lblCashBalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][3].ToString()).ToString("0.00");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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

        private void calculateTotal()
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
                        if (FreeIssueEffectFrom > 0 && Convert.ToDecimal(textBoxFree.Text) == 0)
                        {
                            FreeIssueStatus = true;
                            FreeIssueQty = Convert.ToInt32(txtQuantity.Text) / FreeIssueEffectFrom;
                            quantity = decimal.Parse(txtQuantity.Text);
                            textBoxFree.Text = FreeIssueQty.ToString("0");
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
                        //if (Convert.ToDecimal(textBoxLDiscAmt.Text) == 0)
                        //{
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
                        if (Convert.ToDecimal(textBoxUnitDisc.Text) > 0)
                        {
                            textBoxUnitDiscTextChanged();
                            totDisc = ((Convert.ToDecimal(textBoxLDiscAmt.Text)));
                        }
                        //if (Convert.ToDecimal(textBoxLDiscAmt.Text) > 0)
                        //{
                        //    totDisc = ((Convert.ToDecimal(textBoxLDiscAmt.Text)));
                        //}


                        //}
                        textBoxLDiscAmt.Text = totDisc.ToString("0.00");
                        sum = Convert.ToDecimal(Total - totDisc);
                        txtSubtotals.Text = sum.ToString("0.00");
                        //if (txtItemCode.Text != "111")
                        //{
                        SelPriceDisc = ((OriginalPrice - Convert.ToDecimal(txtSellingPrice.Text)) * Convert.ToDecimal(txtQuantity.Text));
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void textBoxUnitDiscTextChanged()
        {
            try
            {
                if (addStatus == true)
                {
                    if ((string.IsNullOrEmpty(textBoxUnitDisc.Text)) || (textBoxUnitDisc.Text.Trim().Equals(string.Empty)))
                    {
                        textBoxUnitDisc.Text = "0.00";
                    }
                    if (Convert.ToDecimal(textBoxUnitDisc.Text) > 0)
                    {
                        decimal Total;
                        decimal sum = 0;
                        totDisc = 0;
                        decimal unitprice = Convert.ToDecimal(txtSellingPrice.Text);
                        decimal discount = decimal.Parse(textBoxUnitDisc.Text);
                        Total = decimal.Parse(txtSellingPrice.Text) * decimal.Parse(txtQuantity.Text);
                        txtGross.Text = Total.ToString("0.00");
                        totDisc = (Convert.ToDecimal(textBoxUnitDisc.Text) * Convert.ToDecimal(txtQuantity.Text));
                        textBoxLDiscAmt.Text = totDisc.ToString("0.00");
                        //textBoxLDiscAmt.Text = totDisc.ToString("0.00");
                        sum = Convert.ToDecimal(Total - totDisc);
                        txtSubtotals.Text = sum.ToString("0.00");
                    }

                }
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
                textBoxUnitDisc.Text = "0.00";
                defaultDiscount = 0;
                FreeIssueEffectFrom = 0;
                spPriceEffect = 0;
                OriginalPrice = 0;
                purchasePrice = 0;
                MinSellingPrice = 0;
                textBoxCostPrice.Text = "0.00";
                textBoxAvailableQty.Text = "0.00";
                textBoxFree.Text = "0";
                bool namestatus = false;
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

                        objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.ItemCode = txtItemCode.Text;
                        objInvDAL = new ClassInvoiveDAL();
                        objInvBAL.DtDataSet = objInvDAL.retreiveExistItemVariantData(objInvBAL);
                        if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0 && namestatus == false)
                        {
                            namestatus = true;
                            FormItemNames frm5 = new FormItemNames();
                            frm5.frm5 = this;
                            frm5.form = 5;
                            frm5.ItemCode = txtItemCode.Text;
                            frm5.ShowDialog(this);
                            SearchItemsIDData();
                        }
                        else
                        {

                            txtItemName.Text = (values[0].ToString().Trim());
                            txtItemId.Text = (values[2].ToString().Trim());

                            if (comboBoxPriceMethod.Text == "Retail")
                            {
                                objInvBAL = new ClassInvoiceBAL();
                                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                                objInvDAL = new ClassInvoiveDAL();
                                dataGridView1.DataSource = null;
                                objInvBAL.DtDataSet = objInvDAL.retreiveRetailPrices(objInvBAL);
                                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                                {
                                    FormRetailPrices frm1 = new FormRetailPrices();
                                    frm1.frm1 = this;
                                    frm1.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm1.PriceMode = 1;
                                    frm1.form = 1;
                                    frm1.ShowDialog(this);
                                }
                                else
                                {
                                    txtSellingPrice.Text = (values[1].ToString().Trim());
                                }

                            }
                            else if (comboBoxPriceMethod.Text == "Wholesale")
                            {
                                objInvBAL = new ClassInvoiceBAL();
                                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                                objInvDAL = new ClassInvoiveDAL();
                                dataGridView1.DataSource = null;
                                objInvBAL.DtDataSet = objInvDAL.retreiveWholesalePrices(objInvBAL);
                                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                                {
                                    FormRetailPrices frm1 = new FormRetailPrices();
                                    frm1.frm1 = this;
                                    frm1.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm1.PriceMode = 2;
                                    frm1.form = 1;
                                    frm1.ShowDialog(this);
                                }
                                else
                                {
                                    txtSellingPrice.Text = (values[10].ToString().Trim());
                                }

                            }
                            else
                            {
                                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                                objInvDAL = new ClassInvoiveDAL();
                                dataGridView1.DataSource = null;
                                objInvBAL.DtDataSet = objInvDAL.retreiveShopPrices(objInvBAL);
                                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                                {
                                    FormRetailPrices frm1 = new FormRetailPrices();
                                    frm1.frm1 = this;
                                    frm1.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm1.PriceMode = 3;
                                    frm1.form = 1;
                                    frm1.ShowDialog(this);
                                }
                                else
                                {
                                    txtSellingPrice.Text = (values[15].ToString().Trim());
                                }
                            }
                            availableQty = Convert.ToDecimal(values[3].ToString().Trim());
                            textBoxAvailableQty.Text = (values[3].ToString().Trim());
                            comboBoxItemCat.SelectedValue = Convert.ToInt32(values[4].ToString());
                            dateTimePickerFrom.Value = Convert.ToDateTime(values[5].ToString());
                            dateTimePickerTo.Value = Convert.ToDateTime(values[6].ToString());
                            if (((dateTimePickerFrom.Value <= DateTime.Today) && (dateTimePickerTo.Value >= DateTime.Today)) || ((dateTimePickerFrom.Value == Convert.ToDateTime("1753-01-01")) && (dateTimePickerTo.Value == Convert.ToDateTime("1753-01-01"))))
                            {
                                if (comboBoxPriceMethod.Text == "Retail")
                                {
                                    if ((Convert.ToDecimal((values[7].ToString().Trim()))) > 0)
                                    {
                                        textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                                        textBoxUnitDisc.Text = (values[7].ToString().Trim());
                                        defaultDiscount = Convert.ToDecimal(values[7].ToString());
                                    }
                                    else
                                    {
                                        txtDisc.Text = (values[16].ToString().Trim());
                                        //defaultDiscount = Convert.ToDecimal(values[7].ToString());
                                    }

                                }
                                else if (comboBoxPriceMethod.Text == "Wholesale")
                                {
                                    if ((Convert.ToDecimal((values[14].ToString().Trim()))) > 0)
                                    {
                                        textBoxLDiscAmt.Text = (values[14].ToString().Trim());
                                        textBoxUnitDisc.Text = (values[14].ToString().Trim());
                                        defaultDiscount = Convert.ToDecimal(values[14].ToString());
                                    }
                                    else
                                    {
                                        txtDisc.Text = (values[17].ToString().Trim());
                                    }
                                }
                                else
                                {
                                    textBoxLDiscAmt.Text = "0";
                                    textBoxUnitDisc.Text = "0";
                                    defaultDiscount = 0;
                                }

                            }
                            textBoxItemSinhala.Text = (values[8].ToString().Trim());
                            FreeIssueEffectFrom = Convert.ToInt32(values[9].ToString());
                            defaultPRice = Convert.ToDecimal(values[1].ToString());
                            specialPrice = Convert.ToDecimal(values[10].ToString());
                            spPriceEffect = Convert.ToDecimal(values[11].ToString());
                            purchasePrice = Convert.ToDecimal(values[12].ToString());
                            textBoxCostPrice.Text = (values[12].ToString().Trim());
                            MinSellingPrice = Convert.ToDecimal(values[13].ToString());
                        }

                        OriginalPrice = Convert.ToDecimal(txtSellingPrice.Text);
                        fillCustomerTypePrice();
                        txtSellingPrice.Select();
                        //txtQuantity.Select();
                    }

                }
                else
                {
                    FormItemSearch frm15 = new FormItemSearch();
                    frm15.frm15 = this;
                    frm15.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    frm15.form = 15;
                    frm15.ShowDialog(this);
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

        private void SearchItemsIDData()
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
                txtItemCode.Clear();
                comboBoxItemCat.SelectedIndex = -1;
                txtDisc.Text = "0";
                textBoxLDiscAmt.Text = "0.00";
                textBoxUnitDisc.Text = "0.00";
                defaultDiscount = 0;
                FreeIssueEffectFrom = 0;
                spPriceEffect = 0;
                OriginalPrice = 0;
                purchasePrice = 0;
                MinSellingPrice = 0;
                textBoxCostPrice.Text = "0.00";
                textBoxAvailableQty.Text = "0.00";
                bool namestatus = false;
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsIdDataInv(objInvBAL);
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
                        txtItemCode.Text = (values[2].ToString().Trim());

                        if (comboBoxPriceMethod.Text == "Retail")
                        {
                            objInvBAL = new ClassInvoiceBAL();
                            objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                            objInvDAL = new ClassInvoiveDAL();
                            dataGridView1.DataSource = null;
                            objInvBAL.DtDataSet = objInvDAL.retreiveRetailPrices(objInvBAL);
                            if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                            {
                                FormRetailPrices frm1 = new FormRetailPrices();
                                frm1.frm1 = this;
                                frm1.ItemId = Convert.ToInt32(txtItemId.Text);
                                frm1.PriceMode = 1;
                                frm1.form = 1;
                                frm1.ShowDialog(this);
                            }
                            else
                            {
                                txtSellingPrice.Text = (values[1].ToString().Trim());
                            }

                        }
                        else if (comboBoxPriceMethod.Text == "Wholesale")
                        {
                            objInvBAL = new ClassInvoiceBAL();
                            objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                            objInvDAL = new ClassInvoiveDAL();
                            dataGridView1.DataSource = null;
                            objInvBAL.DtDataSet = objInvDAL.retreiveWholesalePrices(objInvBAL);
                            if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                            {
                                FormRetailPrices frm1 = new FormRetailPrices();
                                frm1.frm1 = this;
                                frm1.ItemId = Convert.ToInt32(txtItemId.Text);
                                frm1.PriceMode = 2;
                                frm1.form = 1;
                                frm1.ShowDialog(this);
                            }
                            else
                            {
                                txtSellingPrice.Text = (values[10].ToString().Trim());
                            }

                        }
                        else
                        {
                            objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                            objInvDAL = new ClassInvoiveDAL();
                            dataGridView1.DataSource = null;
                            objInvBAL.DtDataSet = objInvDAL.retreiveShopPrices(objInvBAL);
                            if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                            {
                                FormRetailPrices frm1 = new FormRetailPrices();
                                frm1.frm1 = this;
                                frm1.ItemId = Convert.ToInt32(txtItemId.Text);
                                frm1.PriceMode = 3;
                                frm1.form = 1;
                                frm1.ShowDialog(this);
                            }
                            else
                            {
                                txtSellingPrice.Text = (values[15].ToString().Trim());
                            }
                        }


                        availableQty = Convert.ToDecimal(values[3].ToString().Trim());
                        textBoxAvailableQty.Text = (values[3].ToString().Trim());
                        comboBoxItemCat.SelectedValue = Convert.ToInt32(values[4].ToString());
                        dateTimePickerFrom.Value = Convert.ToDateTime(values[5].ToString());
                        dateTimePickerTo.Value = Convert.ToDateTime(values[6].ToString());
                        if (((dateTimePickerFrom.Value <= DateTime.Today) && (dateTimePickerTo.Value >= DateTime.Today)) || ((dateTimePickerFrom.Value == Convert.ToDateTime("1753-01-01")) && (dateTimePickerTo.Value == Convert.ToDateTime("1753-01-01"))))
                        {
                            //textBoxLDiscAmt.Text = ((Convert.ToDecimal(values[7].ToString()) / 100) * (Convert.ToDecimal(values[1].ToString()))).ToString("0.00");
                            //defaultDiscount = ((Convert.ToDecimal(values[7].ToString()) / 100) * (Convert.ToDecimal(values[1].ToString())));
                            if (comboBoxPriceMethod.Text == "Retail")
                            {
                                if ((Convert.ToDecimal((values[7].ToString().Trim()))) > 0)
                                {
                                    textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                                    textBoxUnitDisc.Text = (values[7].ToString().Trim());
                                    defaultDiscount = Convert.ToDecimal(values[7].ToString());
                                }
                                else
                                {
                                    txtDisc.Text = (values[16].ToString().Trim());
                                    //defaultDiscount = Convert.ToDecimal(values[7].ToString());
                                }

                            }
                            else if (comboBoxPriceMethod.Text == "Wholesale")
                            {
                                if ((Convert.ToDecimal((values[14].ToString().Trim()))) > 0)
                                {
                                    textBoxLDiscAmt.Text = (values[14].ToString().Trim());
                                    textBoxUnitDisc.Text = (values[14].ToString().Trim());
                                    defaultDiscount = Convert.ToDecimal(values[14].ToString());
                                }
                                else
                                {
                                    txtDisc.Text = (values[17].ToString().Trim());
                                }
                            }
                            else
                            {
                                textBoxLDiscAmt.Text = "0";
                                textBoxUnitDisc.Text = "0";
                                defaultDiscount = 0;
                            }

                        }
                        textBoxItemSinhala.Text = (values[8].ToString().Trim());
                        FreeIssueEffectFrom = Convert.ToInt32(values[9].ToString());
                        defaultPRice = Convert.ToDecimal(values[1].ToString());
                        specialPrice = Convert.ToDecimal(values[10].ToString());
                        spPriceEffect = Convert.ToDecimal(values[11].ToString());
                        purchasePrice = Convert.ToDecimal(values[12].ToString());
                        textBoxCostPrice.Text = (values[12].ToString().Trim());
                        MinSellingPrice = Convert.ToDecimal(values[13].ToString());
                    }

                    OriginalPrice = Convert.ToDecimal(txtSellingPrice.Text);
                    fillCustomerTypePrice();
                    txtSellingPrice.Select();
                    //txtQuantity.Select();
                    //}

                }
                else
                {
                    FormItemSearch frm15 = new FormItemSearch();
                    frm15.frm15 = this;
                    frm15.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    frm15.form = 15;
                    frm15.ShowDialog(this);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                if ((Convert.ToDecimal(lblCashTender.Text) <= 0) && (comboBoxPayMode.Text == "Cash") && Convert.ToDecimal(textBoxReceivable.Text) > 0)
                {
                    MessageBox.Show("Please Enter Cash Amount.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblCashTender.Focus();
                    lblCashTender.Select();
                    return;
                }
                else if (((Convert.ToDecimal(lblCashTender.Text) < Convert.ToDecimal(textBoxReceivable.Text))) && (comboBoxPayMode.Text == "Cash"))
                {
                    MessageBox.Show("Please Enter Correct Cash Amount.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblCashTender.Focus();
                    lblCashTender.Select();
                    return;
                }

                else if ((comboBoxCustomer.SelectedIndex == -1) && ((comboBoxPayMode.Text == "Credit") || (comboBoxPayMode.Text == "Cheque")))
                {
                    MessageBox.Show("Please Select Customer.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxCustCode.Focus();
                    textBoxCustCode.Select();
                    return;
                }

                //else if ((Convert.ToDecimal(lblChange.Text) < 0) && (comboBoxPayMode.Text == "Cash"))
                //{
                //    MessageBox.Show("Please Select Correct Payment Method.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    comboBoxPayMode.Focus();
                //    comboBoxPayMode.Select();
                //    return;
                //}
                else if ((Convert.ToDecimal(lblCashTender.Text) >= Convert.ToDecimal(textBoxReceivable.Text)) && (comboBoxPayMode.Text == "Credit"))
                {
                    MessageBox.Show("Please Select Correct Payment Method.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxPayMode.Focus();
                    comboBoxPayMode.Select();
                    return;
                }
                else if ((Convert.ToDecimal(lblCashTender.Text) >= Convert.ToDecimal(textBoxReceivable.Text)) && (comboBoxPayMode.Text == "Cheque"))
                {
                    MessageBox.Show("Please Select Correct Payment Method.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxPayMode.Focus();
                    comboBoxPayMode.Select();
                    return;
                }
                else if ((Convert.ToDecimal(lblCashTender.Text) >= Convert.ToDecimal(textBoxReceivable.Text)) && (comboBoxPayMode.Text == "Bank Transfer"))
                {
                    MessageBox.Show("Please Select Correct Payment Method.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxPayMode.Focus();
                    comboBoxPayMode.Select();
                    return;
                }
                else if ((Convert.ToDecimal(lblCashTender.Text) >= Convert.ToDecimal(textBoxReceivable.Text)) && (comboBoxPayMode.Text == "Card"))
                {
                    MessageBox.Show("Please Select Correct Payment Method.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxPayMode.Focus();
                    comboBoxPayMode.Select();
                    return;
                }
                else if (dgView.Rows.Count == 0)
                {
                    MessageBox.Show("Please add items.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtItemCode.Focus();
                    //if (autocomplete == true)
                    //{
                    //    txtItemName.Select();
                    //}
                    //else
                    //{
                        txtItemCode.Select();
                    //}
                    return;
                }
                else if ((comboBoxPayMode.Text == "Cheque") && (textBoxChequeNo.Text == ""))
                {
                    MessageBox.Show("Please Enter Cheque No.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxChequeNo.Focus();
                    textBoxChequeNo.Select();
                    return;
                }
                else if ((comboBoxPayMode.Text == "Cheque") && (comboBoxBank.SelectedIndex == -1))
                {
                    MessageBox.Show("Please Select the Bank.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxBank.Focus();
                    comboBoxBank.Select();
                    return;
                }
                else if ((comboBoxPayMode.Text == "Bank Transfer") && (comboBoxBank.SelectedIndex == -1))
                {
                    MessageBox.Show("Please Select the Bank.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxBank.Focus();
                    comboBoxBank.Select();
                    return;
                }
                else if ((comboBoxPayMode.Text == "Card") && (textBoxChequeNo.Text == ""))
                {
                    MessageBox.Show("Please Enter Card No.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBoxChequeNo.Focus();
                    textBoxChequeNo.Select();
                    return;
                }
                else if (((Convert.ToDecimal(textBoxCustCredit.Text) + Convert.ToDecimal(textBoxReceivable.Text)) >= CreditLimit) && (comboBoxPayMode.Text == "Credit") && CreditLimit != 0)
                {
                    MessageBox.Show("Customer Credit Limit Is Exceeded.", "Credit Limit Is Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxPayMode.Focus();
                    comboBoxPayMode.Select();
                    return;
                }
                else
                {
                    //createMessage();
                    if ((Convert.ToDecimal(lblCashTender.Text) > 0) && (comboBoxPayMode.Text != "Cash"))
                    {
                        DialogResult result = MessageBox.Show("Are You sure customer pay this Cash Amount?", "Cash Amount Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            lblCashTender.Focus();
                            lblCashTender.Select();
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
                            //if (autocomplete == true)
                            //{
                            //    txtItemName.Select();
                            //}
                            //else
                            //{
                                txtItemCode.Select();
                            //}
                            displyThank();
                            displayClear();
                        }
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
                        //if (autocomplete == true)
                        //{
                        //    txtItemName.Select();
                        //}
                        //else
                        //{
                            txtItemCode.Select();
                        //}
                        displyThank();
                        displayClear();
                    }
                }

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
                    comboBoxCustomer.SelectedValue = 1;
                }
                objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
                if (cmbSalesRep.SelectedIndex == -1)
                {
                    cmbSalesRep.SelectedValue = 0;
                }
                objInvBAL.RepId = Convert.ToInt32(cmbSalesRep.SelectedValue);
                objInvBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objInvBAL.BillNo = Convert.ToInt32(txtInvoiceNo.Text);
                objInvBAL.SOGrossTotal = Convert.ToDecimal(lblGrossTot.Text);
                objInvBAL.SODiscount = Convert.ToDecimal(txtTotDiscRate.Text);
                objInvBAL.SONetTotal = Convert.ToDecimal(lblNetTotal.Text);
                objInvBAL.Remarks = txtComment.Text;
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objInvBAL.Cash = Convert.ToDecimal(lblCashTender.Text);
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
                objInvBAL.CreditTotal = Convert.ToDecimal(textBoxCustCredit.Text);
                objInvBAL.RefNo = Convert.ToInt32(textBoxOrderNo.Text);
                objInvBAL.ReferanceNo = textBoxRefNo.Text;
                objInvBAL.TerminalNo = Convert.ToInt32(comboBoxTerminal.Text);
                objInvBAL.VoucherNo = Convert.ToInt32(textBoxVoucherNo.Text);
                objInvBAL.VoucherAmount = Convert.ToDecimal(textBoxVoucherAmount.Text);
                objInvBAL.ReceivableAmount = Convert.ToDecimal(textBoxReceivable.Text);
                objInvBAL.CustomerName = comboBoxCustomer.Text;
                objInvBAL.Charges = 0;
                objInvBAL.CreditDueDays = 0;
                objInvBAL.CompletedDate = DateTime.Today;
                objInvBAL.InvoiceStatusId = 1;
                //if (checkBoxIsRepair.Checked == true)
                //{
                //    objInvBAL.RepairBill = true;
                //}
                //if (checkBoxIsRepair.Checked == false)
                //{
                    objInvBAL.RepairBill = false;
                //}
                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.InsertNewsohd(objInvBAL);
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
                        objInvBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                        objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value);
                        objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value);
                        objInvBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value);
                        objInvBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                        objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                        objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                        objInvBAL.Warranty = dgView.Rows[i].Cells["Warranty"].Value.ToString().Trim();
                        objInvBAL.InternalNo = "0";
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                        objInvBAL.Damage = Convert.ToInt32(dgView.Rows[i].Cells["Damage"].Value);
                        objInvBAL.SerialNo = "";
                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertSalesRtn(objInvBAL);
                    }
                    else
                    {
                        objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);//lblUserId.Tex
                        objInvBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                        objInvBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                        objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value);
                        objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value);
                        objInvBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value);
                        objInvBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                        objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                        objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                        objInvBAL.Warranty = dgView.Rows[i].Cells["Warranty"].Value.ToString().Trim();
                        objInvBAL.InternalNo = "0";
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                        objInvBAL.FreeIssue = Convert.ToInt32(dgView.Rows[i].Cells["FreeIssue"].Value);
                        objInvBAL.SerialNo = "";
                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertSoDt(objInvBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }

                }

                if (savestate == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to Print this Invoice?", "Printing Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{
                    //    printInvoice();
                    //}
                    if ((comboBoxPayMode.Text == "Credit"))
                    {
                        insertCustomerCredit();
                    }
                    if (comboBoxPayMode.Text == "Cheque")
                    {
                        insertCheque();
                    }
                    if (comboBoxPayMode.Text == "Card")
                    {
                        insertCard();
                    }
                    if (comboBoxPayMode.Text == "Bank Transfer")
                    {
                        insertBankDeposit();
                    }

                    if (result == DialogResult.Yes)
                    {
                        printInvoice();
                    }
                    insertcsv();

                    //DialogResult result1 = MessageBox.Show("Do you want to send thanking message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result1 == DialogResult.Yes && textBoxCustMobile.Text != "")
                    //{
                    //    //sendThankingSMS();
                    //    if (textBoxCustMobile.Text != "")
                    //    {
                    //        sendCustomerMessage();
                    //    }
                    //}

                    //DialogResult result1 = MessageBox.Show("Do you want to send thanking message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result1 == DialogResult.Yes && textBoxCustMobile.Text != "")
                    //{
                    //    sendThankingSMS();
                    //}
                    //if (VATStatus == true)
                    //{
                    //    printVATInvoice();
                    //}
                    //if (VATStatus == false)
                    //{
                    //    printInvoice();
                    //}
                    ResetEntry();
                    blnPaid = false;
                    //if (autocomplete == true)
                    //{
                    //    txtItemName.Select();
                    //}
                    //else
                    //{
                        txtItemCode.Select();
                    //}
                    GenerateInvoice();
                    //fillCashBalance();
                    //sendSalesReportmail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void fillCashBalance()
        //{
        //    try
        //    {
        //        objInvBAL = new ClassInvoiceBAL();
        //        objInvDAL = new ClassInvoiveDAL();
        //        objInvBAL.UserId = Convert.ToInt32(lblUserId.Text.Trim());
        //        objInvBAL.DtDataSet = objInvDAL.SelectCashBalnce(objInvBAL);
        //        if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            lblopenbalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][0].ToString()).ToString("0.00");
        //            lblreciveAmount.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][1].ToString()).ToString("0.00");
        //            lblPayments.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][2].ToString()).ToString("0.00");
        //            lblCashBalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][3].ToString()).ToString("0.00");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void insertBankDeposit()
        {
            if (comboBoxPayMode.Text == "Bank Transfer")
            {
                try
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    objInvBAL.ChequeBank = comboBoxBank.Text.Trim();
                    objInvBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                    //objInvBAL.ChequeNo = textBoxChequeNo.Text;
                    if (Convert.ToDecimal(lblCashTender.Text) == 0)
                    {
                        objInvBAL.ChequeAmount = Convert.ToDecimal(textBoxReceivable.Text);
                    }
                    if (Convert.ToDecimal(lblCashTender.Text) > 0)
                    {
                        objInvBAL.ChequeAmount = Convert.ToDecimal(lblChange.Text) * -1;
                    }

                    //objInvBAL.ChequeExpDate = Convert.ToDateTime(dateTimePickerChqExpDate.Text);
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    if (comboBoxBranch.SelectedIndex == -1)
                    {
                        comboBoxBranch.SelectedValue = 0;
                    }
                    objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerBankDeposit(objInvBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ResetEntry()
        {
            comboBoxCustomer.SelectedIndex = -1;
            cmbSalesRep.SelectedIndex = -1;
            textBoxChequeNo.Clear();
            comboBoxBank.Text = "";
            dateTimePickerChqExpDate.Value = DateTime.Today;
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today;
            txtItemCode.Text = "";
            txtItemName.Text = "";
            textBoxInternalNo.Text = "";
            textBoxItemSinhala.Text = "";
            txtQuantity.Text = "1";
            textBoxFree.Text = "0";
            txtSellingPrice.Text = "0.00";
            txtDisc.Text = "0";
            textBoxLDiscAmt.Text = "0.00";
            textBoxUnitDisc.Text = "0.00";
            txtSubtotals.Text = "0.00";
            txtGross.Text = "0.00";

            lblStatus.Text = "";
            lblSubTotal.Text = "0.00";
            lblItemDiscount.Text = "0.00";
            lblGrossTot.Text = "0.00";
            textBoxReturn.Text = "0.00";
            txtTotDiscRate.Text = "0.00";
            textBoxVoucherAmount.Text = "0.00";
            textBoxVAT.Text = "0.00";
            textBoxNBT.Text = "0.00";
            textBoxAddChgs.Text = "0.00";
            textBoxAddChgPer.Text = "0";
            textBoxTotDiscPerc.Text = "0";
            textBoxVoucherNo.Text = "0";
            txtComment.Clear();
            checkBoxVAT.Checked = false;
            checkBoxNBT.Checked = false;
            dgView.Rows.Clear();
            txtItemCode.Focus();
            textBoxPriceDisc.Text = "0.00";
            textBoxCustCode.Clear();
            textBoxCustCredit.Text = "0.00";
            textBoxCustChq.Text = "0.00";
            comboBoxWarranty.Text = "No Warranty";
            checkBoxReturn.Checked = false;
            DiscRate = 0;
            CreditPay = 0;
            textBoxOrderNo.Text = "0";
            textBoxCostPrice.Text = "0.00";
            textBoxAvailableQty.Text = "0.00";
            textBoxRefNo.Clear();
            textBoxMessage.Clear();
            textBoxCustMobile.Clear();
            textBoxNoOfItems.Text = "0";
            textBoxTotItem.Text = "0";
        }

        private void displyThank()
        {
            try
            {
                if (comboBox1.Text != "No")
                {
                    SerialPort sp = new SerialPort();
                    sp.PortName = comboBox1.Text;
                    sp.BaudRate = 9600;
                    sp.Parity = Parity.None;
                    sp.DataBits = 8;
                    sp.StopBits = StopBits.One;
                    sp.Open();
                    sp.Write(Convert.ToString((char)12));
                    sp.WriteLine("--- THANK YOU ---");
                    sp.WriteLine((char)13 + "COME AGAIN ...");

                    sp.Close();
                    sp.Dispose();
                    sp = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayClear()
        {
            try
            {
                if (comboBox1.Text != "No")
                {
                    SerialPort sp = new SerialPort();
                    sp.PortName = comboBox1.Text;
                    sp.BaudRate = 9600;
                    sp.Parity = Parity.None;
                    sp.DataBits = 8;
                    sp.StopBits = StopBits.One;
                    sp.Open();
                    sp.Write(Convert.ToString((char)12));
                    sp.WriteLine("< YOU ARE WELCOME >");
                    sp.WriteLine((char)13 + "NEXT CUSTOMER PLEASE");

                    sp.Close();
                    sp.Dispose();
                    sp = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertCustomerCredit()
        {
            if (comboBoxPayMode.Text == "Credit")
            {
                try
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    //objInvBAL.BillNo = InvoiceNo;
                    objInvBAL.BillNo = Convert.ToInt32(txtInvoiceNo.Text);
                    if (Convert.ToDecimal(lblCashTender.Text) == 0)
                    {
                        //objInvBAL.CreditAmount = Convert.ToDecimal(lblNetTotal.Text);
                        objInvBAL.CreditAmount = Convert.ToDecimal(textBoxReceivable.Text);
                    }
                    if (Convert.ToDecimal(lblCashTender.Text) > 0)
                    {
                        objInvBAL.CreditAmount = Convert.ToDecimal(lblChange.Text) * -1;
                    }

                    //objInvBAL.BalanceAmount = Convert.ToDecimal(textBoxBalance.Text)*-1;
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerCredit(objInvBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void insertCheque()
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                try
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    //objInvBAL.SOHDId = InvoiceNo;
                    objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    objInvBAL.ChequeBank = comboBoxBank.Text.Trim();
                    objInvBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                    objInvBAL.ChequeNo = textBoxChequeNo.Text;
                    if (Convert.ToDecimal(lblCashTender.Text) == 0)
                    {
                        //objInvBAL.ChequeAmount = Convert.ToDecimal(lblNetTotal.Text);
                        objInvBAL.ChequeAmount = Convert.ToDecimal(textBoxReceivable.Text);
                    }
                    if (Convert.ToDecimal(lblCashTender.Text) > 0)
                    {
                        objInvBAL.ChequeAmount = Convert.ToDecimal(lblChange.Text) * -1;
                    }

                    objInvBAL.ChequeExpDate = Convert.ToDateTime(dateTimePickerChqExpDate.Text);
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerCheque(objInvBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void insertCard()
        {
            if (comboBoxPayMode.Text == "Card")
            {
                try
                {
                    objInvBAL = new ClassInvoiceBAL();
                    if (comboBoxCustomer.SelectedIndex == -1)
                    {
                        comboBoxCustomer.SelectedValue = 0;
                    }
                    objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
                    //objInvBAL.SOHDId = InvoiceNo;
                    objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    objInvBAL.ChequeBank = comboBoxBank.Text.Trim();
                    objInvBAL.ChequeNo = textBoxChequeNo.Text;
                    if (Convert.ToDecimal(lblCashTender.Text) == 0)
                    {
                        //objInvBAL.ChequeAmount = Convert.ToDecimal(lblNetTotal.Text); 
                        objInvBAL.ChequeAmount = Convert.ToDecimal(textBoxReceivable.Text);
                    }
                    if (Convert.ToDecimal(lblCashTender.Text) > 0)
                    {
                        objInvBAL.ChequeAmount = Convert.ToDecimal(lblChange.Text) * -1;
                    }

                    objInvBAL.CardType = comboBoxCardType.Text;
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerCard(objInvBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void printInvoice()
        {
            try
            {
                if (Option1 == true)
                {
                    if (Option2 == true)
                    {
                        //if (PrintBalance == true)
                        //{
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportA4InvoiceCr rpt = new CrystalReportA4InvoiceCr();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                        //}
                        //else
                        //{
                        //    Cursor.Current = Cursors.WaitCursor;
                        //    CrystalReportA4Invoice rpt = new CrystalReportA4Invoice();
                        //    objBAL = new ClassPOBAL();
                        //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        //    objDAL = new ClassPODAL();
                        //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                        //    rpt.SetDataSource(objBAL.DtDataSet);
                        //    crystalReportViewer1.ReportSource = rpt;
                        //    crystalReportViewer1.Refresh();
                        //    //crystalReportViewer1.PrintReport();
                        //    rpt.PrintOptions.PrinterName = "";
                        //    rpt.PrintToPrinter(1, false, 0, 0);
                        //    Cursor.Current = Cursors.Default;
                        //}

                    }
                    else if (Option3 == true)
                    {
                        //if (PrintBalance == true)
                        //{
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportA4InvoiceSCr rpt = new CrystalReportA4InvoiceSCr();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                        //}
                        //else
                        //{
                        //    Cursor.Current = Cursors.WaitCursor;
                        //    CrystalReportA4InvoiceS rpt = new CrystalReportA4InvoiceS();
                        //    objBAL = new ClassPOBAL();
                        //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        //    objDAL = new ClassPODAL();
                        //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                        //    rpt.SetDataSource(objBAL.DtDataSet);
                        //    crystalReportViewer1.ReportSource = rpt;
                        //    crystalReportViewer1.Refresh();
                        //    //crystalReportViewer1.PrintReport();
                        //    rpt.PrintOptions.PrinterName = "";
                        //    rpt.PrintToPrinter(1, false, 0, 0);
                        //    Cursor.Current = Cursors.Default;
                        //}

                    }
                    else if (Option4 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3 rpt = new CrystalReportInvoice5in3();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option5 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3S rpt = new CrystalReportInvoice5in3S();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option6 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //CrystalReportInvoice3in3 rpt = new CrystalReportInvoice3in3();
                        //CrystalReportInvoice2inLogoE rpt = new CrystalReportInvoice2inLogoE();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        CrystalReportInvoice3in3ex rpt = new CrystalReportInvoice3in3ex();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option7 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //CrystalReportInvoice2inLogoS rpt = new CrystalReportInvoice2inLogoS();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        //CrystalReportInvoice2inch rpt = new CrystalReportInvoice2inch();
                        CrystalReportInvoice3in3exs rpt = new CrystalReportInvoice3in3exs();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option8 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3Lo rpt = new CrystalReportInvoice5in3Lo();
                        //CrystalReportInvoice2inLogoE rpt = new CrystalReportInvoice2inLogoE();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option9 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3SLo rpt = new CrystalReportInvoice5in3SLo();
                        //CrystalReportInvoice2inLogoS rpt = new CrystalReportInvoice2inLogoS();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option10 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3LF rpt = new CrystalReportInvoice5in3LF();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option11 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3SLF rpt = new CrystalReportInvoice5in3SLF();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option12 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportA4InvoiceCrNLo rpt = new CrystalReportA4InvoiceCrNLo();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option13 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportA4InvoiceSCrNLo rpt = new CrystalReportA4InvoiceSCrNLo();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option14 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice2in2ex rpt = new CrystalReportInvoice2in2ex();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option15 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice2in2exs rpt = new CrystalReportInvoice2in2exs();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option16 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice3in3ext rpt = new CrystalReportInvoice3in3ext();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option17 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3T rpt = new CrystalReportInvoice5in3T();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option18 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice3in3exLogo rpt = new CrystalReportInvoice3in3exLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option19 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice3in3exsLogo rpt = new CrystalReportInvoice3in3exsLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option20 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice3in3exTLogo rpt = new CrystalReportInvoice3in3exTLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option21 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReport5InInvoiceCr rpt = new CrystalReport5InInvoiceCr();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                    else if (Option22 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReport5InInvoiceCrS rpt = new CrystalReport5InInvoiceCrS();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertcsv()
        {
            try
            {
                int n = dataGridView3.Rows.Add();
                //int intQtyOrdered = int.Parse(txtQty.Text);

                dataGridView3.Rows[n].Cells["SOHDId1"].Value = txtInvoiceNo.Text;

                dataGridView3.FirstDisplayedScrollingRowIndex = n;
                dataGridView3.CurrentCell = dataGridView3.Rows[n].Cells[0];
                dataGridView3.Rows[n].Selected = true;

                ExporttoCSV();
                dataGridView3.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExporttoCSV()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    csv += column.HeaderText + ',';
                }

                //Add new line.
                csv += "\r\n";

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridView3.Rows)
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
                File.WriteAllText(folderPath + "Invoice.csv", csv);
                //MessageBox.Show("Ready to Print.");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSOHDNewReturn()
        {
            try
            {
                //if ((comboBoxPayMode.Text == "Credit"))
                //{
                //    if (comboBoxCustomer.SelectedIndex != -1)
                //    {
                //        FormCustInvCreditPay frm = new FormCustInvCreditPay();
                //        frm.frm = this;
                //        frm.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                //        frm.lblUser.Text = lblUser.Text.Trim();
                //        frm.lblUserId.Text = lblUserId.Text.Trim();
                //        frm.textBoxReturn.Text = textBoxReceivable.Text;
                //        frm.ShowDialog(this);
                //    }
                //}

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
                objInvBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objInvBAL.BillNo = Convert.ToInt32(txtInvoiceNo.Text);
                objInvBAL.SOGrossTotal = Convert.ToDecimal(lblGrossTot.Text);
                objInvBAL.SODiscount = Convert.ToDecimal(txtTotDiscRate.Text);
                objInvBAL.SONetTotal = Convert.ToDecimal(lblNetTotal.Text);
                objInvBAL.Remarks = txtComment.Text;
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objInvBAL.Cash = Convert.ToDecimal(lblCashTender.Text);
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
                objInvBAL.CreditTotal = Convert.ToDecimal(textBoxCustCredit.Text);
                objInvBAL.RefNo = Convert.ToInt32(textBoxOrderNo.Text);
                objInvBAL.ReferanceNo = textBoxRefNo.Text;
                objInvBAL.TerminalNo = Convert.ToInt32(comboBoxTerminal.Text);
                objInvBAL.VoucherNo = Convert.ToInt32(textBoxVoucherNo.Text);
                objInvBAL.VoucherAmount = Convert.ToDecimal(textBoxVoucherAmount.Text);
                objInvBAL.ReceivableAmount = Convert.ToDecimal(textBoxReceivable.Text);
                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.InsertNewsohdReturn(objInvBAL);
                txtInvoiceNo.Text = count.ToString();

                //int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != "")
                {
                    //GenerateInvoice();
                    SaveSODTReturn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SaveSODTReturn()
        {
            try
            {

                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);//lblUserId.Tex
                    objInvBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    objInvBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                    objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value);
                    objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value);
                    objInvBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value);
                    objInvBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                    objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                    objInvBAL.Warranty = dgView.Rows[i].Cells["Warranty"].Value.ToString().Trim();
                    objInvBAL.InternalNo = "0";
                    if (comboBoxBranch.SelectedIndex == -1)
                    {
                        comboBoxBranch.SelectedValue = 0;
                    }
                    objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    objInvBAL.Damage = Convert.ToInt32(dgView.Rows[i].Cells["Damage"].Value);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertSoDtReturn(objInvBAL);
                    if (count != 0)
                    {
                        savestate = true;

                    }

                }

                if (savestate == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to Print this Return Note?", "Printing Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        printInvoiceReturn();
                    }
                    ResetEntry();
                    blnPaid = false;
                    //if (autocomplete == true)
                    //{
                    //    txtItemName.Select();
                    //}
                    //else
                    //{
                        txtItemCode.Select();
                    //}
                    GenerateInvoice();
                    //fillCashBalance();
                    //sendSalesReportmail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printInvoiceReturn()
        {
            try
            {
                if (Option1 == true)
                {
                    if (Option2 == true)
                    {
                        //if (PrintBalance == true)
                        //{
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportA4InvoiceCrRtn rpt = new CrystalReportA4InvoiceCrRtn();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;


                    }
                    else if (Option3 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportA4InvoiceCrRtn rpt = new CrystalReportA4InvoiceCrRtn();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;
                    }
                    else if (Option4 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3Rtn rpt = new CrystalReportInvoice5in3Rtn();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;

                    }
                    else if (Option5 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportInvoice5in3Rtn rpt = new CrystalReportInvoice5in3Rtn();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;
                    }
                    //else if (Option6 == true)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    CrystalReportInvoice2inLogoE rpt = new CrystalReportInvoice2inLogoE();
                    //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    //    objBAL = new ClassPOBAL();
                    //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    //    objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    crystalReportViewer1.ReportSource = rpt;
                    //    crystalReportViewer1.Refresh();
                    //    //crystalReportViewer1.PrintReport();
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
                    //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    //    objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    crystalReportViewer1.ReportSource = rpt;
                    //    crystalReportViewer1.Refresh();
                    //    //crystalReportViewer1.PrintReport();
                    //    rpt.PrintOptions.PrinterName = "";
                    //    rpt.PrintToPrinter(1, false, 0, 0);
                    //    Cursor.Current = Cursors.Default;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemCodeKeyDown()
        {
            if (txtItemCode.Text != "")
            {
                if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                {
                    txtQuantity.Text = "1";
                }
                txtDisc.Text = "0";
                textBoxLDiscAmt.Text = "0.00";
                textBoxUnitDisc.Text = "0.00";

                SearchItem();

                if (newItem == true)
                {
                    txtItemName.Select();
                }
                else
                {
                    addStatus = true;
                    calculateTotal();
                    txtQuantity.Select();
                }


            }
            else if (txtItemCode.Text == "" && dgView.Rows.Count > 0)
            {
                lblCashTender.Select();
            }
            else
            {
                txtItemCode.Select();
            }
        }

        private void AddtoGrid()
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
                if (MinSellingPrice > Convert.ToDecimal(txtSellingPrice.Text))
                {
                    MessageBox.Show("Minimum Selling Price Validation..", "Invalid Selling Price.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSellingPrice.Focus();
                    return;
                }
                if (txtItemCode.Text == "")
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
                    //int intQtyOrdered = int.Parse(txtQty.Text);

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
                    dgView.Rows[n].Cells["FreeIssue"].Value = textBoxFree.Text;
                    //dgView.Rows[n].Cells["FreeIssue"].Value = FreeIssueQty.ToString();textBoxFree.Text
                    dgView.Rows[n].Cells["PriceDisc"].Value = SelPriceDisc.ToString();
                    dgView.Rows[n].Cells["Warranty"].Value = comboBoxWarranty.Text;
                    if (checkBoxReturn.Checked == true)
                    {
                        dgView.Rows[n].Cells["Rtn"].Value = "1";
                    }
                    else
                    {
                        dgView.Rows[n].Cells["Rtn"].Value = "0";
                    }
                    if (checkBoxDamage.Checked == true)
                    {
                        dgView.Rows[n].Cells["Damage"].Value = "1";
                    }
                    else
                    {
                        dgView.Rows[n].Cells["Damage"].Value = "0";
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
                    textBoxFree.Text = "0";
                    txtSellingPrice.Text = "0.00";
                    txtGross.Text = "0.00";
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";
                    textBoxUnitDisc.Text = "0.00";
                    txtSubtotals.Text = "0.00";
                    txtItemId.Text = "0";
                    SelPriceDisc = 0;
                    comboBoxItemCat.SelectedIndex = -1;
                    comboBoxWarranty.Text = "No Warranty";

                    lblNetTotal.Text = "0.00";
                    textBoxReceivable.Text = "0.00";
                    lblCashTender.Text = "0.00";
                    lblChange.Text = "0.00";
                    textBoxNoOfItems.Text = dgView.Rows.Count.ToString();

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

        private void CalculateTotal()
        {
            try
            {
                decimal SubTotal = 0;
                decimal ItemDiscount = 0;
                decimal GrossTot = 0;
                decimal PriceDisc = 0;
                decimal RtnTot = 0;
                decimal TotQty = 0;
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
                            TotQty += Convert.ToDecimal(dgView.Rows[a].Cells["Qty"].Value.ToString());
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
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");
                textBoxTotItem.Text = TotQty.ToString("0.00");

                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == false && checkBoxNBT.Checked == true)
                {
                    textBoxNBT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 2) / 100).ToString("0.00");
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == true && checkBoxNBT.Checked == true)
                {
                    textBoxNBT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 2) / 100).ToString("0.00");
                    textBoxVAT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxNBT.Text)) * 11) / 100).ToString("0.00");
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == false && checkBoxNBT.Checked == false)
                {
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
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
                textBoxUnitDisc.Text = "0.00";
                defaultDiscount = 0;
                FreeIssueEffectFrom = 0;
                spPriceEffect = 0;
                OriginalPrice = 0;
                purchasePrice = 0;
                MinSellingPrice = 0;
                textBoxCostPrice.Text = "0.00";
                textBoxAvailableQty.Text = "0.00";
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
                        txtSellingPrice.Text = (values[1].ToString().Trim());
                        txtItemCode.Text = (values[2].ToString().Trim());
                        availableQty = Convert.ToDecimal(values[3].ToString().Trim());
                        comboBoxItemCat.SelectedValue = Convert.ToInt32(values[4].ToString());
                        dateTimePickerFrom.Value = Convert.ToDateTime(values[5].ToString());
                        dateTimePickerTo.Value = Convert.ToDateTime(values[6].ToString());
                        if (((dateTimePickerFrom.Value <= DateTime.Today) && (dateTimePickerTo.Value >= DateTime.Today)) || ((dateTimePickerFrom.Value == Convert.ToDateTime("1753-01-01")) && (dateTimePickerTo.Value == Convert.ToDateTime("1753-01-01"))))
                        {
                            if (comboBoxPriceMethod.Text == "Retail")
                            {
                                textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                                textBoxUnitDisc.Text = (values[7].ToString().Trim());
                                defaultDiscount = Convert.ToDecimal(values[7].ToString());
                            }
                            else
                            {
                                textBoxLDiscAmt.Text = (values[14].ToString().Trim());
                                textBoxUnitDisc.Text = (values[14].ToString().Trim());
                                defaultDiscount = Convert.ToDecimal(values[14].ToString());
                            }
                        }
                        textBoxItemSinhala.Text = (values[8].ToString().Trim());
                        FreeIssueEffectFrom = Convert.ToInt32(values[9].ToString());
                        defaultPRice = Convert.ToDecimal(values[1].ToString());
                        specialPrice = Convert.ToDecimal(values[10].ToString());
                        spPriceEffect = Convert.ToDecimal(values[11].ToString());
                        purchasePrice = Convert.ToDecimal(values[12].ToString());
                        MinSellingPrice = Convert.ToDecimal(values[13].ToString());
                        textBoxCostPrice.Text = (values[12].ToString().Trim());
                        textBoxAvailableQty.Text = (values[3].ToString().Trim());
                    }
                    OriginalPrice = Convert.ToDecimal(txtSellingPrice.Text);
                    txtSellingPrice.Select();
                    //txtQuantity.Select();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveItem()
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
                    textBoxUnitDisc.Text = "0.00";
                    lblCashTender.Text = "0.00";

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
                //    else
                //{
                //    //MessageBox.Show("Select one item to remove!");
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void loadcontrol()
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                if (objDAL.retreivePOLoadingData(objBAL).Tables[3].Rows.Count > 0)
                {
                    comboBoxItemCat.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[3];
                    comboBoxItemCat.DisplayMember = "ItemCatName";
                    comboBoxItemCat.ValueMember = "ItemCatId";
                    comboBoxItemCat.SelectedIndex = -1;
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

                loadStatus = false;
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
                textBoxCustCredit.Text = "0.00";
                textBoxCustChq.Text = "0.00";
                CreditLimit = 0;
                AdvanceAmount = 0;
                textBoxCustMobile.Clear();
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
                        textBoxCustCredit.Text = (values[10].ToString().Trim());
                        textBoxCustChq.Text = (values[11].ToString().Trim());
                        CreditLimit = Convert.ToDecimal((values[12].ToString().Trim()));
                        comboBoxPriceMethod.Text = (values[13].ToString().Trim());
                        AdvanceAmount = Convert.ToDecimal((values[14].ToString().Trim()));
                        textBoxCustMobile.Text = (values[4].ToString().Trim());
                    }
                    lblCashTender.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitCashier()
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Exit this Invoice Window", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.UserId = Convert.ToInt32(lblUserId.Text);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.DeleteCashBalance(objInvBAL);
                    if (count != 0)
                    {
                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Events

        private void btnA_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnA.Text.Trim();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnB.Text.Trim();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnC.Text.Trim();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnD.Text.Trim();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnE.Text.Trim();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnF.Text.Trim();
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnG.Text.Trim();
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnH.Text.Trim();
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnI.Text.Trim();
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnJ.Text.Trim();
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnK.Text.Trim();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnL.Text.Trim();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnM.Text.Trim();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnN.Text.Trim();
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnO.Text.Trim();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnP.Text.Trim();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnQ.Text.Trim();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnR.Text.Trim();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnS.Text.Trim();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnT.Text.Trim();
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnU.Text.Trim();
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnV.Text.Trim();
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnW.Text.Trim();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnX.Text.Trim();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnY.Text.Trim();
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnZ.Text.Trim();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn0.Text.Trim();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn1.Text.Trim();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn2.Text.Trim();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn3.Text.Trim();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn4.Text.Trim();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn5.Text.Trim();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn6.Text.Trim();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn7.Text.Trim();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn8.Text.Trim();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn9.Text.Trim();
        }

        private void btnCent_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnCent.Text.Trim();
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            lastTB.Text += btndot.Text.Trim();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lastTB.Text += " ";
        }

        private void btnPounds_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnPounds.Text.Trim();
        }

        private void btnDollar_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnDollar.Text.Trim();
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (lastTB.Text.Length > 0)
            {
                //CONTINUE TO CLEAR TEXT UNTIL NOTHING IS REMAIN
                lastTB.Text = lastTB.Text.Substring(0, lastTB.Text.Length - 1);

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lastTB.ToString());
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void txtSellingPrice_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxFree_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void txtDisc_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxLDiscAmt_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxRefNo_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxCustCode_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxChequeNo_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxTotDiscPerc_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void txtTotDiscRate_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxVoucherNo_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void lblCashTender_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void FormInvoiceTuch_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                txtItemCode.Select();
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                if (objDAL.retreivePOLoadingData(objBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[1];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 0;
                }

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

                this.KeyPreview = true;
                //this.KeyDown += new KeyEventHandler(frmInvoice_KeyDown);

                loadStatus = false;
                //fillOptions();

                //fillCashBalance();
                //if (Convert.ToDecimal(lblCashBalance.Text) <= 0)
                //{
                //    frmOpeningBalance frm = new frmOpeningBalance();
                //    frm.frm = this;
                //    frm.lblUser.Text = lblUser.Text;
                //    frm.lblUserId.Text = lblUserId.Text;
                //    frm.ShowDialog(this);
                //}
                //fillHoldGrid();
                //displayClear();
                checkBoxItemBal.Checked = true;
                loadBank();
                txtItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            //SendKeys.Send("{ENTER}");
            
            if (lastTB == txtQuantity)
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
            else if (lastTB == txtSellingPrice)
            {
                errorProvider1.Clear();
                bool isValid = ValidatePrice();
                if (isValid)
                {
                    SelPriceDisc = 0;
                    if (newItem == true)
                    {
                        //insertItem();
                        SearchItemByID();
                        //SearchItem();
                        newItem = false;
                    }

                    addStatus = true;
                    calculateTotal();
                    txtQuantity.Select();
                }
            }
            else if (lastTB == textBoxUnitDisc)
            {
                textBoxLDiscAmt.Select();
            }
            else if (lastTB == txtDisc)
            {
                AddtoGrid();
            }
            else if (lastTB == textBoxLDiscAmt)
            {
                AddtoGrid();
            }
            else if (lastTB == textBoxCustCode)
            {
                if (textBoxCustCode.Text != "")
                {
                    searchCustomer();
                    txtItemCode.Select();
                }
                else
                {
                    textBoxCustCode.Select();
                }
            }
            else if (lastTB == txtTotDiscRate)
            {
                lblCashTender.Select();
            }
            else if (lastTB == txtItemName)
            {
                txtSellingPrice.Select();
            }
            else if (lastTB == txtItemCode)
            {
                ItemCodeKeyDown();
                txtSellingPrice.Select();
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (txtItemCode.Text != "")
                    {
                        if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                        {
                            txtQuantity.Text = "1";
                        }
                        txtDisc.Text = "0";
                        textBoxLDiscAmt.Text = "0.00";
                        textBoxUnitDisc.Text = "0.00";

                        SearchItem();

                        if (newItem == true)
                        {
                            txtItemName.Select();
                        }
                        else
                        {
                            addStatus = true;
                            calculateTotal();
                            txtSellingPrice.Select();
                        }


                    }
                    else if (txtItemCode.Text == "" && dgView.Rows.Count > 0)
                    {
                        lblCashTender.Select();
                    }
                    else
                    {
                        txtItemCode.Select();
                    }
                }
                //txtQuantity.Select();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FreeIssueStatus == false)
                {
                    if (txtQuantity.Text != "")
                    {
                        if ((string.IsNullOrEmpty(txtQuantity.Text)) || (txtQuantity.Text.Trim().Equals(string.Empty)))
                        {
                            txtQuantity.Text = "0";
                        }
                        if (Convert.ToDecimal(txtSellingPrice.Text) > 0)
                        {
                            SelPriceDisc = 0;
                            //if (txtItemCode.Text != "111")
                            //{
                            SelPriceDisc = ((OriginalPrice - EditedPrice) * Convert.ToDecimal(txtQuantity.Text));
                            //}

                        }
                        textBoxUnitDisc_TextChanged(sender, e);
                        //textBoxLDiscAmt.Text = TotalLineDisc.ToString();
                        calculateTotal();
                    }
                    

                }
            }
            catch (Exception)
            {

            }
        }

        private void textBoxUnitDisc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (addStatus == true)
                {
                    if (textBoxUnitDisc.Text != "")
                    {
                        if ((string.IsNullOrEmpty(textBoxUnitDisc.Text)) || (textBoxUnitDisc.Text.Trim().Equals(string.Empty)))
                        {
                            textBoxUnitDisc.Text = "0.00";
                        }
                        if (Convert.ToDecimal(textBoxUnitDisc.Text) > 0)
                        {
                            decimal Total;
                            decimal sum = 0;
                            totDisc = 0;
                            decimal unitprice = Convert.ToDecimal(txtSellingPrice.Text);
                            decimal discount = decimal.Parse(textBoxUnitDisc.Text);
                            Total = decimal.Parse(txtSellingPrice.Text) * decimal.Parse(txtQuantity.Text);
                            txtGross.Text = Total.ToString("0.00");
                            totDisc = (Convert.ToDecimal(textBoxUnitDisc.Text) * Convert.ToDecimal(txtQuantity.Text));
                            textBoxLDiscAmt.Text = totDisc.ToString("0.00");
                            //textBoxLDiscAmt.Text = totDisc.ToString("0.00");
                            sum = Convert.ToDecimal(Total - totDisc);
                            txtSubtotals.Text = sum.ToString("0.00");
                        }
                    }
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceNo.Text == "")
                {
                    MessageBox.Show("Please enter Cash Slip.");
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

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                label23.Visible = true;
                label23.Text = "Cheque No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Exp. Date";
                dateTimePickerChqExpDate.Visible = true;
                comboBoxCardType.Visible = false;
            }
            else if (comboBoxPayMode.Text == "Card")
            {
                label23.Visible = true;
                label23.Text = "Card No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Card Type";
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = true;
            }
            else
            {
                label23.Visible = false;
                textBoxChequeNo.Visible = false;
                label25.Visible = false;
                comboBoxBank.Visible = false;
                label27.Visible = false;
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgView.RowCount < 1)
            {
                MessageBox.Show("Please enter item to purchase before you can save this record.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtItemCode.Focus();
                return;
            }
            else if ((comboBoxCustomer.SelectedIndex == -1) && ((comboBoxPayMode.Text == "Credit") || (comboBoxPayMode.Text == "Cheque")))
            {
                MessageBox.Show("Please Select Customer.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxCustCode.Focus();
                textBoxCustCode.Select();
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want Save this Return Note?", "Saving Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveSOHDNewReturn();
                }
            }
        }

        private void simpleButtonF1_Click(object sender, EventArgs e)
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

        private void simpleButtonF2_Click(object sender, EventArgs e)
        {
            txtItemCode.Select();
            FormItemSearch frm15 = new FormItemSearch();
            frm15.frm15 = this;
            frm15.form = 15;
            frm15.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            frm15.lblUser.Text = lblUser.Text.Trim();
            frm15.lblUserId.Text = lblUserId.Text.Trim();
            frm15.ShowDialog(this);
        }

        private void simpleButtonF3_Click(object sender, EventArgs e)
        {
            textBoxUnitDisc.Select();
        }

        private void simpleButtonF4_Click(object sender, EventArgs e)
        {
            FormPayMode frm1 = new FormPayMode();
            frm1.frm1 = this;
            frm1.form = 1;
            frm1.ShowDialog(this);
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

        private void dgView_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Remove Selected Item?", "Remove Item Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RemoveItem();
            }
        }

        private void simpleButtonF12_Click(object sender, EventArgs e)
        {
            lblCashTender.Select();
        }

        private void simpleButtonF5_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text == "")
            {
                addStatus = true;
                ItemEdit();
            }

            txtQuantity.Select();
        }

        private void simpleButtonF6_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemCode.Text == "")
                {
                    addStatus = true;
                    ItemEdit();
                }

                txtSellingPrice.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButtonF7_Click(object sender, EventArgs e)
        {
            loadcontrol();
            textBoxCustCode.Select();
            FormSearchCustomer frm3 = new FormSearchCustomer();
            frm3.frm3 = this;
            frm3.form = 3;
            frm3.ShowDialog(this);
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
                }
            }
        }

        private void simpleButtonF8_Click(object sender, EventArgs e)
        {
            txtItemName.Select();
        }

        private void simpleButtonF9_Click(object sender, EventArgs e)
        {
            exitCashier();
        }

        private void simpleButtonF10_Click(object sender, EventArgs e)
        {
            txtTotDiscRate.Select();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            txtItemCode.Select();
        }

        #endregion



       


        #region Validation Methods

        private bool ValidateCash()
        {
            lblCashTender.Text = lblCashTender.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(lblCashTender.Text)) || (lblCashTender.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Cash Amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(lblCashTender.Text))
            {
                errorCode = "Invalid Cash Amount.";
            }
            //else if (Convert.ToDecimal(lblCashTender.Text) < 0)
            //{
            //    errorCode = "Invalid Cash Amount.";
            //}
            string message = errorCode;
            errorProvider1.SetError(lblCashTender, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePrice()
        {
            txtSellingPrice.Text = txtSellingPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(txtSellingPrice.Text)) || (txtSellingPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(txtSellingPrice.Text))
            {
                errorCode = "Invalid Price.";
            }
            else if (Convert.ToDecimal(txtSellingPrice.Text) < 0)
            {
                errorCode = "Invalid Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(txtSellingPrice, message);
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
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");

                //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblCashTender_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateCash();
                if (isValid)
                {
                    if (lblCashTender.Text == "")
                    {
                        lblChange.Text = "0.00";
                        blnPaid = false;
                    }
                    else
                    {
                        lblChange.Text = (Convert.ToDecimal(lblCashTender.Text) - Convert.ToDecimal(textBoxReceivable.Text)).ToString("0.00");
                        blnPaid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (lastTB.Text.Length > 0)
            {
                //CONTINUE TO CLEAR TEXT UNTIL NOTHING IS REMAIN
                lastTB.Text = "";
                lastTB.Select();

            }
        }

        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
            if (txtDisc.Text != "")
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
            
        }

        private void textBoxLDiscAmt_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLDiscAmt.Text != "")
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
            
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            //userPermission();
            //Selectusercomport();
            fillOptions();
        }

        

        


    }
}
