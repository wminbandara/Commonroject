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
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Mail;
using easyPOSSolution.Utility;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace easyPOSSolution
{
    public partial class frmInvoice : Form
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
        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9, Option10, Option11, Option12, Option13, Option14, Option15, Option16, Option17, Option18, Option19, Option20, Option21, Option22;
        string lDiscString, message;
        public bool blnPaid, newItem, autocomplete, insertDTStatus, AllowSMS;
        public decimal CreditPay = 0;
        decimal purchasePrice, DiscRate, MinSellingPrice, CreditLimit, AdvanceAmount, balance, totBal, cashbalance, LoyaltyPercentage, LoyaltyAmount, InvoiceLoyaltyAmount, companydisc, CP, MinQty;
        string pdfFileSales = "C:\\Rpt\\Invoice.pdf";
        string pdfFileDayEnd = "C:\\Rpt\\DayEndReport.pdf";

        bool scaleitem = false;
        string to, apitoken, fromval, apikey, companyname, SMSUrl;

        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

        #endregion

        #region Constructor
        public frmInvoice()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        private void UpdateAllGiftVouchers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView4.GetRowCellValue(i, "VoucherStatus").ToString()) == true)
                    {
                        ClassPOBAL objPOBAL = new ClassPOBAL();
                        objPOBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objPOBAL.VoucherNo = Convert.ToInt32(gridView4.GetRowCellValue(i, "VoucherNo").ToString());

                        ClassPODAL objPODAL = new ClassPODAL();
                        int count = objPODAL.UpdateUsedVoucher(objPOBAL);

                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }

                }
                //if (insertDTStatus == true)
                //{
                //    MessageBox.Show("Items Updated Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    gridControl1.DataSource = null;
                //}
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalculateVoucherTotal()
        {
            try
            {
                decimal SubTotal = 0;

                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView4.GetRowCellValue(i, "VoucherStatus").ToString()) == true)
                    {
                        SubTotal += Convert.ToDecimal(gridView4.GetRowCellValue(i, "VoucherAmount").ToString());
                    }
                }
                textBoxVoucherAmount.Text = SubTotal.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillAvailableGiftVouchers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                //objBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                //objBAL.date2 = dateTimePicker3.Value;
                objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreiveAvailableVouchers(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView4.OptionsView.ColumnAutoWidth = false;
                    gridView4.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteDTData()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteDTData(objInvBAL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteHoldData()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteHoldData(objInvBAL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSODTHold()
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
                    objInvBAL.FreeIssue = Convert.ToInt32(dgView.Rows[i].Cells["FreeIssue"].Value);
                    objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                    objInvBAL.PriceMethod = dgView.Rows[i].Cells["PriceMethod"].Value.ToString().Trim();
                    objInvBAL.DiscPer = Convert.ToDecimal(dgView.Rows[i].Cells["DiscPer"].Value);

                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertSoDtHold(objInvBAL);
                    if (count != 0)
                    {
                        savestate = true;

                    }

                }

                if (savestate == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to Print this Invoice?", "Printing Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        printInvoiceHold();
                    }
                    insertcsv();


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
                    fillPendingGrid();
                    fillCashBalance();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTableRecord()
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

                comboBoxPayMode.Text = "Save";
                lblCashTender.Text = "0.00";

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
                            calcInvoiceLoyaltyAmount();
                            SaveSOHDNewHold();
                            //GenerateInvoice();
                            //ResetEntry();
                            //blnPaid = false;
                            //if (autocomplete == true)
                            //{
                            //    txtItemName.Select();
                            //}
                            //else
                            //{
                            //    txtItemCode.Select();
                            //}
                            //displyThank();
                            //displayClear();
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
                        calcInvoiceLoyaltyAmount();
                        SaveSOHDNewHold();
                        //GenerateInvoice();
                        //ResetEntry();
                        //blnPaid = false;
                        //if (autocomplete == true)
                        //{
                        //    txtItemName.Select();
                        //}
                        //else
                        //{
                        //    txtItemCode.Select();
                        //}
                        //displyThank();
                        //displayClear();
                    }
                    comboBoxPayMode.Text = "Cash";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSOHDNewHold()
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
                objInvBAL.CustomerName = textBoxCustName.Text;
                objInvBAL.Charges = Convert.ToDecimal(textBoxChargesAmount.Text);
                objInvBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
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
                objInvBAL.LoyaltyPoints = Convert.ToDecimal(InvoiceLoyaltyAmount.ToString());
                objInvBAL.LoyaltyBalance = Convert.ToDecimal(textBoxLoyalty.Text);
                objInvBAL.ReturnNoteNo = Convert.ToInt32(textBoxReturnId.Text);
                objInvBAL.ReturnNoteAmount = Convert.ToDecimal(textBoxReturnNoteAmount.Text);
                objInvBAL.CashBalance = Convert.ToDecimal(lblChange.Text);

                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.InsertNewsohdHold(objInvBAL);
                txtInvoiceNo.Text = count.ToString();

                //int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != "")
                {
                    SaveSODTHold();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printInvoiceHold()
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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
                        objBAL.DtDataSet = objDAL.retreiveTAWInvoiceHoldData(objBAL);
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

        private void SaveSODTHoldComplete()
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
                    objInvBAL.FreeIssue = Convert.ToInt32(dgView.Rows[i].Cells["FreeIssue"].Value);
                    objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                    objInvBAL.PriceMethod = dgView.Rows[i].Cells["PriceMethod"].Value.ToString().Trim();
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertSoDtHold(objInvBAL);
                    if (count != 0)
                    {
                        savestate = true;

                    }

                }

                if (savestate == true)
                {
                    SaveHoldRecord();
                    fillPendingGrid();
                    txtItemName.Select();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveHoldRecord()
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
                            calcInvoiceLoyaltyAmount();
                            SaveSOHDHoldNew();
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
                        calcInvoiceLoyaltyAmount();
                        SaveSOHDHoldNew();
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

        private void SaveSOHDHoldNew()
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
                objInvBAL.CustomerName = textBoxCustName.Text;
                objInvBAL.Charges = Convert.ToDecimal(textBoxChargesAmount.Text);
                objInvBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
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
                objInvBAL.LoyaltyPoints = Convert.ToDecimal(InvoiceLoyaltyAmount.ToString());
                objInvBAL.LoyaltyBalance = Convert.ToDecimal(textBoxLoyalty.Text);
                objInvBAL.ReturnNoteNo = Convert.ToInt32(textBoxReturnId.Text);
                objInvBAL.ReturnNoteAmount = Convert.ToDecimal(textBoxReturnNoteAmount.Text);
                objInvBAL.CashBalance = Convert.ToDecimal(lblChange.Text);

                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.InsertHoldNewsohd(objInvBAL);
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

        private void fillPendingGrid()
        {
            ClassSOBAL objBAL = new ClassSOBAL();
            ClassSODAL objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllPendingInvoices(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
            }
        }

        private void FillBalance()
        {
            try
            {
                textBoxBalance.Text = (Convert.ToDecimal(textBoxCash.Text) - Convert.ToDecimal(textBoxNetAmount.Text)).ToString("0.00");
            }
            catch
            {
            }
        }

        private void fillInv()
        {
            textBoxInvoice.Text = (this.gridView1.GetFocusedRowCellValue("BillNo").ToString());
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("BillNo").ToString());
            txtInvoiceNo.Text = (this.gridView1.GetFocusedRowCellValue("BillNo").ToString());
            FindNetAmount();
            textBoxCash.Select();
        }

        public void FindNetAmount()
        {
            try
            {
                textBoxNetAmount.Text = "0.00";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxInvoice.Text);
                objInvBAL.DocTypeId = 1;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveInvDisc(objInvBAL);
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

                        textBoxNetAmount.Text = (values[6].ToString());
                        textBoxCash.Text = (values[6].ToString());
                    }

                    //textBoxNetAmount.Text = ((Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxCharges.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillHoldHDData()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxInvoice.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveInvHoldDH(objInvBAL);
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

                        comboBoxCustomer.SelectedValue = (values[0].ToString());
                        cmbSalesRep.SelectedValue = (values[1].ToString());
                        txtTotDiscRate.Text = (values[2].ToString());
                        txtComment.Text = (values[3].ToString());
                        comboBoxBranch.SelectedValue = (values[4].ToString());
                        textBoxRefNo.Text = (values[5].ToString());
                        comboBoxTerminal.Text = (values[6].ToString());
                        textBoxCustName.Text = (values[7].ToString());
                        textBoxChargesAmount.Text = (values[8].ToString());
                        comboBoxInvoiceStatus.SelectedValue = (values[9].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillHoldDTData()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxInvoice.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveInvHoldDT(objInvBAL);
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

                        addtoGrid = true;
                        calculateTotal();
                        addtoGrid = false;
                        FreeIssueStatus = false;

                        int n = dgView.Rows.Add();
                        //int intQtyOrdered = int.Parse(txtQty.Text);

                        dgView.Rows[n].Cells["ItemCode"].Value = (values[0].ToString());
                        dgView.Rows[n].Cells["ItemName"].Value = (values[1].ToString());
                        dgView.Rows[n].Cells["InternalNo"].Value = (values[2].ToString());
                        dgView.Rows[n].Cells["ItemNameSinhala"].Value = "";
                        dgView.Rows[n].Cells["Qty"].Value = (values[3].ToString());
                        dgView.Rows[n].Cells["Price"].Value = (values[4].ToString());
                        dgView.Rows[n].Cells["Amount"].Value = (values[5].ToString());
                        dgView.Rows[n].Cells["Discount"].Value = (values[6].ToString());
                        dgView.Rows[n].Cells["NetAmount"].Value = (values[7].ToString());
                        dgView.Rows[n].Cells["ItemsId"].Value = (values[8].ToString());
                        dgView.Rows[n].Cells["ItemCatID"].Value = (values[9].ToString());
                        dgView.Rows[n].Cells["FreeIssue"].Value = (values[10].ToString());
                        dgView.Rows[n].Cells["PriceDisc"].Value = 0;
                        dgView.Rows[n].Cells["Warranty"].Value = (values[11].ToString());
                        dgView.Rows[n].Cells["Rtn"].Value = "0";
                        dgView.Rows[n].Cells["Damage"].Value = "0";
                        dgView.Rows[n].Cells["SerialNo"].Value = (values[12].ToString());
                        dgView.Rows[n].Cells["PriceMethod"].Value = (values[13].ToString());
                        dgView.Rows[n].Cells["DiscPer"].Value = 0;

                        dgView.FirstDisplayedScrollingRowIndex = n;
                        dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        dgView.Rows[n].Selected = true;

                        textBoxNoOfItems.Text = dgView.Rows.Count.ToString();

                        addStatus = false;
                        CalculateTotal();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillExistHDData()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxExInvoiceNo.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveInvExistDH(objInvBAL);
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

                        comboBoxCustomer.SelectedValue = (values[0].ToString());
                        cmbSalesRep.SelectedValue = (values[1].ToString());
                        txtTotDiscRate.Text = (values[2].ToString());
                        txtComment.Text = (values[3].ToString());
                        comboBoxBranch.SelectedValue = (values[4].ToString());
                        textBoxRefNo.Text = (values[5].ToString());
                        comboBoxTerminal.Text = (values[6].ToString());
                        textBoxCustName.Text = (values[7].ToString());
                        textBoxChargesAmount.Text = (values[8].ToString());
                        comboBoxInvoiceStatus.SelectedValue = (values[9].ToString());
                        comboBoxPayMode.SelectedValue = (values[10].ToString());
                        textBoxCustName.Text = (values[11].ToString());
                        textBoxCreditDueDays.Text = (values[12].ToString());
                        dateTimePickerCompletedDate.Value = Convert.ToDateTime(values[13].ToString());

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillExistDTData()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxExInvoiceNo.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveInvExistDT(objInvBAL);
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

                        addtoGrid = true;
                        calculateTotal();
                        addtoGrid = false;
                        FreeIssueStatus = false;

                        int n = dgView.Rows.Add();
                        //int intQtyOrdered = int.Parse(txtQty.Text);

                        dgView.Rows[n].Cells["ItemCode"].Value = (values[0].ToString());
                        dgView.Rows[n].Cells["ItemName"].Value = (values[1].ToString());
                        dgView.Rows[n].Cells["InternalNo"].Value = (values[2].ToString());
                        dgView.Rows[n].Cells["ItemNameSinhala"].Value = "";
                        dgView.Rows[n].Cells["Qty"].Value = (values[3].ToString());
                        dgView.Rows[n].Cells["Price"].Value = (values[4].ToString());
                        dgView.Rows[n].Cells["Amount"].Value = (values[5].ToString());
                        dgView.Rows[n].Cells["Discount"].Value = (values[6].ToString());
                        dgView.Rows[n].Cells["NetAmount"].Value = (values[7].ToString());
                        dgView.Rows[n].Cells["ItemsId"].Value = (values[8].ToString());
                        dgView.Rows[n].Cells["ItemCatID"].Value = (values[9].ToString());
                        dgView.Rows[n].Cells["FreeIssue"].Value = (values[10].ToString());
                        dgView.Rows[n].Cells["PriceDisc"].Value = 0;
                        dgView.Rows[n].Cells["Warranty"].Value = (values[11].ToString());
                        dgView.Rows[n].Cells["Rtn"].Value = "0";
                        dgView.Rows[n].Cells["Damage"].Value = "0";
                        dgView.Rows[n].Cells["SerialNo"].Value = (values[12].ToString());
                        dgView.Rows[n].Cells["PriceMethod"].Value = (values[13].ToString());
                        dgView.Rows[n].Cells["DiscPer"].Value = "0";

                        dgView.FirstDisplayedScrollingRowIndex = n;
                        dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        dgView.Rows[n].Selected = true;

                        textBoxNoOfItems.Text = dgView.Rows.Count.ToString();

                        addStatus = false;
                        CalculateTotal();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateHoldNewHD()
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
                objInvBAL.CustomerName = textBoxCustName.Text;
                objInvBAL.Charges = Convert.ToDecimal(textBoxChargesAmount.Text);
                objInvBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
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
                objInvBAL.LoyaltyPoints = Convert.ToDecimal(InvoiceLoyaltyAmount.ToString());
                objInvBAL.LoyaltyBalance = Convert.ToDecimal(textBoxLoyalty.Text);
                objInvBAL.ReturnNoteNo = Convert.ToInt32(textBoxReturnId.Text);
                objInvBAL.ReturnNoteAmount = Convert.ToDecimal(textBoxReturnNoteAmount.Text);
                objInvBAL.CashBalance = Convert.ToDecimal(lblChange.Text);

                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.UpdateHoldNewhd(objInvBAL);
                txtInvoiceNo.Text = count.ToString();

                //int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != "")
                {
                    SaveSODTHold();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void FillAvailableSerial()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                //objBAL.date2 = dateTimePicker3.Value;
                objDAL = new ClassPODAL();
                gridControl11.DataSource = null;
                if (objDAL.retreiveAvailableSerial(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl11.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView11.OptionsView.ColumnAutoWidth = false;
                    gridView11.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CodeKeydown()
        {
            try
            {
                if (txtItemCode.Text != "")
                {
                    scaleitem = false;
                    if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                    {
                        txtQuantity.Text = "1";
                    }
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";
                    textBoxUnitDisc.Text = "0.00";
                    //textBoxSerial.Clear();
                    if (txtItemCode.Text.Length == 11)
                    {
                        CheckScaleItem();
                        if (scaleitem == true)
                        {

                            string code = txtItemCode.Text;

                            string itmcode = code.Substring(0, 6);
                            string qty = code.Substring(6, 2) + "." + code.Substring(8, 3);

                            txtQuantity.Text = qty.ToString();
                            txtItemCode.Text = itmcode.ToString();
                            SearchItem();
                            txtQuantity.Text = qty.ToString();

                            addStatus = true;
                            calculateTotal();
                            txtQuantity.Select();
                        }
                        else
                        {
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

                    }
                    else
                    {
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
                    FillAvailableSerial();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchSerialData()
        {
            try
            {
                txtItemCode.Clear();
                //comboBoxColour.SelectedIndex = 0;
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SerialNo = textBoxSerial.Text;
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveSerialItemCode(objInvBAL);
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

                        txtItemCode.Text = (values[0].ToString().Trim());
                        CP = Convert.ToDecimal(values[1].ToString());
                        //comboBoxColour.SelectedValue = (values[2].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchReturn()
        {
            try
            {
                textBoxReturnNoteAmount.Text = "0.00";
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ReturnNo = Convert.ToInt32(textBoxReturnId.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveReturnnoData(objInvBAL);
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

                        textBoxReturnNoteAmount.Text = (values[1].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calcInvoiceLoyaltyAmount()
        {
            try
            {
                if (LoyaltyPercentage > 0)
	            {
                    InvoiceLoyaltyAmount = Convert.ToDecimal(textBoxReceivable.Text) * (LoyaltyPercentage / 100);
	            }
                else if (LoyaltyAmount > 0)
                {
                    InvoiceLoyaltyAmount = Convert.ToDecimal(textBoxReceivable.Text) / LoyaltyAmount;
                }
                else
                {
                    InvoiceLoyaltyAmount = 0;
                }
                
            }
            catch
            {
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

        public void sendOwnerMessage()
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string message2;
                    to = "768719743";
                    message2 = "Invoice generated to " + textBoxCustName.Text + " ,Invoice No : " + txtInvoiceNo.Text + " Payment Mode : " + comboBoxPayMode.Text + " Invoice Total : " + lblNetTotal.Text + " Date : " + DateTime.Now.ToString() + ". Created User " + lblUser.Text + ".";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                    string url = SMSUrl + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
                    //string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;

                    //Call web api to send sms messages
                    string result = client.DownloadString(url);
                    //if (result.Contains("0"))
                    //    MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //else
                    //    MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //string url = "https://cloud.websms.lk/smsAPI?sendsms&apikey=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
                    ////Call web api to send sms messages
                    //string result = client.DownloadString(url);
                    //if (result.Contains("0"))
                    //    MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //else
                    //    MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    message2 = "Dear " + textBoxCustName.Text + " Your Invoice details are, Invoice No : " + txtInvoiceNo.Text + " Payment Mode : " + comboBoxPayMode.Text + " Invoice Total : " + lblNetTotal.Text + " Date : " + DateTime.Now.ToString() + ". " + companyname.ToString() + ". Thank you come again.";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                    string url = SMSUrl + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
                    //string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;

                    //Call web api to send sms messages
                    string result = client.DownloadString(url);
                    if (result.Contains("0"))
                        MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //string url = "https://cloud.websms.lk/smsAPI?sendsms&apikey=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
                    ////Call web api to send sms messages
                    //string result = client.DownloadString(url);
                    //if (result.Contains("0"))
                    //    MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //else
                    //    MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //public void sendCustomerMessage()
        //{
        //    using (System.Net.WebClient client = new System.Net.WebClient())
        //    {
        //        try
        //        {
        //            string message2;
        //            to = textBoxCustMobile.Text;
        //            message2 = "Dear " + textBoxCustName.Text + " Your Invoice details are, Invoice No : " + txtInvoiceNo.Text + " Payment Mode : " + comboBoxPayMode.Text + " Invoice Total : " + lblNetTotal.Text + " Date : " + DateTime.Now.ToString() + ". " + companyname.ToString() + ". Thank you come again.";

        //            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
        //                                SecurityProtocolType.Tls11 |
        //                                SecurityProtocolType.Tls12;

        //            string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
        //            //Call web api to send sms messages
        //            string result = client.DownloadString(url);
        //            if (result.Contains("0"))
        //                MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            else
        //                MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    //try
        //    //{
        //    //    WebClient client = new WebClient();
        //    //    //string to, message, apitoken, fromval, apikey;
        //    //    string message2;
        //    //    to = textBoxCustMobile.Text;
        //    //    message2 = "Dear " + textBoxCustName.Text + " Your Invoice details are, Invoice No : " + txtInvoiceNo.Text + " Payment Mode : " + comboBoxPayMode.Text + " Invoice Total : " + lblNetTotal.Text + " Date : " + DateTime.Now.ToString() + ". " + companyname.ToString() + ". Thank you come again.";

        //    //    string baseURL = "http://app.newsletters.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;

        //    //    client.OpenRead(baseURL);
        //    //    //MessageBox.Show("Successfully sent message");
        //    //}
        //    //catch (Exception exp)
        //    //{
        //    //    MessageBox.Show(exp.ToString());
        //    //}
        //}

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
                        companydisc = Convert.ToDecimal(values[16].ToString().Trim());
                        SMSUrl = (values[17].ToString().Trim());
                        AllowSMS = Convert.ToBoolean(values[18]);
                    }
                }
                textBoxTotDiscPerc.Text = companydisc.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChargesPer()
        {
            try
            {
                if (textBoxChargesPer.Text != "")
                {
                    if (Convert.ToDecimal(textBoxChargesPer.Text) == 0)
                    {
                        textBoxChargesAmount.Text = "0.00";
                    }
                    else if (Convert.ToDecimal(textBoxChargesPer.Text) > 0)
                    {
                        textBoxChargesAmount.Text = ((Convert.ToDecimal(textBoxChargesPer.Text) / 100) * Convert.ToDecimal(lblGrossTot.Text)).ToString("0.00");
                    }
                }
            }
            catch (Exception)
            {

                throw;
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
                objBAL.PriceMode = comboBoxPriceMethod.Text;

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
                objBAL.CustomerTypeId = 0;
                objBAL.LoyaltyPercentage = 0;
                objBAL.LoyaltyAmount = 0;

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertCustomer(objBAL);
                if (count != 0)
                {
                    LoadCustomerCombo();
                    MessageBox.Show("Customer Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    searchCustomer();

                    if (AllowSMS == true)
                    {
                        DialogResult result1 = MessageBox.Show("Do you want to send thanking message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1 == DialogResult.Yes && textBoxCustMobile.Text != "")
                        {
                            //sendThankingSMS();
                            if (textBoxCustMobile.Text != "")
                            {
                                sendCustomerwelcomeMessage();
                            }
                        }
                    }
                    

                    //if (autocomplete == true)
                    //{
                    //    txtItemName.Select();
                    //}
                    //else
                    //{
                    txtItemCode.Select();
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void sendCustomerwelcomeMessage()
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string message2;
                    to = Convert.ToInt64(textBoxCustMobile.Text).ToString();
                    message2 = "Dear " + textBoxCustName.Text + " Thank you for registering with us. You are welcome to " + " " + companyname.ToString() + ". Thank you.";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                    string url = SMSUrl + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
                    //string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;

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

            //try
            //{
            //    WebClient client = new WebClient();
            //    //string to, message, apitoken, fromval, apikey;
            //    string message2;
            //    to = Convert.ToInt64(textBoxCustMobile.Text).ToString();
            //    message2 = "Dear " + textBoxCustName.Text + " Thank you for registering with us. You are welcome to " + " " + companyname.ToString() + ". Thank you.";

            //    //string url = "http://app.newsletters.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
            //    string url = "https://cloud.websms.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;

            //    //Call web api to send sms messages
            //    string result = client.DownloadString(url);
            //    if (result.Contains("0"))
            //        MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    else
            //        MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.ToString());
            //}

            //try
            //{
            //    WebClient client = new WebClient();
            //    //string to, message, apitoken, fromval, apikey;
            //    string message2;
            //    to = textBoxTel.Text;
            //    message2 = "Dear " + textBoxCustomerName.Text + " Thank you for giving us an opportunity to contact you and grateful consideration. We are expecting to join you for our clientele and serve our Best Software products. Your contact person is " + comboBoxContactPerson.Text + ". TAJOPC TEAM";

            //    string baseURL = "http://app.newsletters.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;

            //    client.OpenRead(baseURL);
            //    //MessageBox.Show("Successfully sent message");
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.ToString());
            //}
        }

        private void CheckScaleItem()
        {
            try
            {
                string code = txtItemCode.Text;

                string itmcode = code.Substring(0, 6);

                scaleitem = false;
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemCode = itmcode.ToString();
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsData(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        scaleitem = Convert.ToBoolean(values[6]);

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Selectusercomport()
        {
            try
            {
                comboBox1.Text = "No";
                BALUser objUser = new BALUser();
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveusercomport(objUser);
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
                        comboBox1.Text = (values[0].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchvoucher()
        {
            try
            {
                textBoxVoucherAmount.Text = "0.00";
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.VoucherNo = Convert.ToInt32(textBoxVoucherNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreivevauchernoData(objInvBAL);
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

                        textBoxVoucherAmount.Text = (values[4].ToString().Trim());
                    }
                }
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
                if ((comboBoxPayMode.Text == "Credit"))
                {
                    if (comboBoxCustomer.SelectedIndex != -1)
                    {
                        FormCustInvCreditPay frm = new FormCustInvCreditPay();
                        frm.frm = this;
                        frm.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                        frm.lblUser.Text = lblUser.Text.Trim();
                        frm.lblUserId.Text = lblUserId.Text.Trim();
                        frm.textBoxReturn.Text = textBoxReceivable.Text;
                        frm.ShowDialog(this);
                    }
                }

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
                    objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
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
                    fillCashBalance();
                    //sendSalesReportmail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchOrderHeader()
        {
            try
            {
                textBoxCustCode.Clear();
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxOrderNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveSOrderHeader(objInvBAL);
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
                        cmbSalesRep.SelectedValue = (values[1].ToString().Trim());
                        dateTimePickerCompletedDate.Value = Convert.ToDateTime(values[2]);
                        comboBoxInvoiceStatus.SelectedValue = (values[3].ToString().Trim());
                        checkBoxIsRepair.Checked = false;
                        if (Convert.ToBoolean(values[4]) == true)
                        {
                            checkBoxIsRepair.Checked = true;
                        }
                        txtComment.Text = (values[5].ToString().Trim());
                        searchCustomer();
                    }
                }
                textBoxCustCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchOrderDetail()
        {
            try
            {
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

                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxOrderNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveSOrderHeader(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        txtItemCode.Text = (values[0].ToString().Trim());
                        txtItemName.Text = (values[1].ToString().Trim());
                        textBoxInternalNo.Text = (values[2].ToString().Trim());
                        textBoxItemSinhala.Text = (values[3].ToString().Trim());
                        txtQuantity.Text = (values[4].ToString().Trim());
                        txtSellingPrice.Text = (values[5].ToString().Trim());
                        txtGross.Text = (values[6].ToString().Trim());
                        textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                        txtSubtotals.Text = (values[8].ToString().Trim());
                        txtItemId.Text = (values[9].ToString().Trim());
                        comboBoxItemCat.SelectedValue = (values[10].ToString().Trim());
                        FreeIssueQty = 0;
                        textBoxFree.Text = "0";
                        SelPriceDisc = 0;
                        comboBoxWarranty.Text = (values[12].ToString().Trim());
                        textBoxSerial.Text = (values[13].ToString().Trim());
                        checkBoxReturn.Checked = false;
                        AddtoGrid();   
                    }
                }
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                txtItemCode.Select();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchOrderReturnDetail()
        {
            try
            {
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

                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxOrderNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveSOrderHeader(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[2].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        txtItemCode.Text = (values[0].ToString().Trim());
                        txtItemName.Text = (values[1].ToString().Trim());
                        textBoxInternalNo.Text = (values[2].ToString().Trim());
                        textBoxItemSinhala.Text = (values[3].ToString().Trim());
                        txtQuantity.Text = (values[4].ToString().Trim());
                        txtSellingPrice.Text = (values[5].ToString().Trim());
                        txtGross.Text = (values[6].ToString().Trim());
                        textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                        txtSubtotals.Text = (values[8].ToString().Trim());
                        txtItemId.Text = (values[9].ToString().Trim());
                        comboBoxItemCat.SelectedValue = (values[10].ToString().Trim());
                        FreeIssueQty = 0;
                        textBoxFree.Text = "0";
                        SelPriceDisc = 0;
                        comboBoxWarranty.Text = (values[12].ToString().Trim());
                        checkBoxReturn.Checked = true;
                        AddtoGrid();
                    }
                }
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                txtItemCode.Select();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchQuotationHeader()
        {
            try
            {
                textBoxCustCode.Clear();
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxRefNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveQuotationHeader(objInvBAL);
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
                        cmbSalesRep.SelectedValue = (values[1].ToString().Trim());
                        dateTimePickerCompletedDate.Value = Convert.ToDateTime(values[2]);
                        comboBoxInvoiceStatus.SelectedValue = (values[3].ToString().Trim());
                        checkBoxIsRepair.Checked = false;
                        if (Convert.ToBoolean(values[4]) == true)
                        {
                            checkBoxIsRepair.Checked = true;
                        }
                        txtComment.Text = (values[5].ToString().Trim());
                        searchCustomer();
                    }
                }
                textBoxCustCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchQuotationDetail()
        {
            try
            {
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

                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxRefNo.Text);
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveQuotationHeader(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        txtItemCode.Text = (values[0].ToString().Trim());
                        txtItemName.Text = (values[1].ToString().Trim());
                        textBoxInternalNo.Text = (values[2].ToString().Trim());
                        textBoxItemSinhala.Text = (values[3].ToString().Trim());
                        txtQuantity.Text = (values[4].ToString().Trim());
                        txtSellingPrice.Text = (values[5].ToString().Trim());
                        txtGross.Text = (values[6].ToString().Trim());
                        textBoxLDiscAmt.Text = (values[7].ToString().Trim());
                        txtSubtotals.Text = (values[8].ToString().Trim());
                        txtItemId.Text = (values[9].ToString().Trim());
                        comboBoxItemCat.SelectedValue = (values[10].ToString().Trim());
                        FreeIssueQty = 0;
                        textBoxFree.Text = "0";
                        SelPriceDisc = 0;
                        comboBoxWarranty.Text = (values[12].ToString().Trim());
                        textBoxSerial.Text = (values[13].ToString().Trim());
                        checkBoxReturn.Checked = false;
                        AddtoGrid();
                    }
                }
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                txtItemCode.Select();
                //}
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
                    //txtSellingPrice.Text = (purchasePrice + (purchasePrice * DiscRate / 100)).ToString("0.00");

                    //decimal decamt = 0;
                    //decamt = Math.Round(Convert.ToDecimal(txtSellingPrice.Text) * 2, MidpointRounding.ToEven) / 2;
                    //txtSellingPrice.Text = decamt.ToString("0.00");

                    txtDisc.Text = DiscRate.ToString("0.00");
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

        //public void searchCustomer()
        //{
        //    try
        //    {
        //        comboBoxCustomer.SelectedIndex = -1;
        //        textBoxCustCredit.Text = "0.00";
        //        objInvBAL = new ClassInvoiceBAL();
        //        objInvBAL.CustomerCode = textBoxCustCode.Text;
        //        objInvDAL = new ClassInvoiveDAL();
        //        objInvBAL.DtDataSet = objInvDAL.retreiveCustomerCodeData(objInvBAL);
        //        if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            List<ArrayList> newval = new List<ArrayList>();
        //            foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
        //            {
        //                ArrayList values = new ArrayList();
        //                values.Clear();
        //                foreach (object value in dRow.ItemArray)
        //                    values.Add(value);
        //                newval.Add(values);

        //                comboBoxCustomer.SelectedValue = (values[0].ToString().Trim());
        //                textBoxCustCredit.Text = (values[10].ToString().Trim());
        //            }
        //            lblCashTender.Select();
        //        }
        //        else
        //        {
        //            FormSearchCustomer frm = new FormSearchCustomer();
        //            frm.frm = this;
        //            frm.ShowDialog(this);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public void ItemcodeKeyDown()
        {
            try
            {
                if (txtItemId.Text != "")
                {
                    //lblNetTotal.Text = "0.00";
                    //textBoxReceivable.Text = "0.00";
                    //lblCashTender.Text = "0.00";
                    //lblChange.Text = "0.00";
                    if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                    {
                        txtQuantity.Text = "1";
                    }
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";
                    textBoxUnitDisc.Text = "0.00";
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
                        //if (txtItemCode.Text == "111")
                        //{
                        //    txtSellingPrice.ReadOnly = false;
                        //    txtSellingPrice.Select();
                        //}
                        //else
                        //{
                            //txtSellingPrice.ReadOnly = true;
                            //txtQuantity.Select();
                            txtSellingPrice.Select();
                        //}
                    }


                }
                else if (txtItemCode.Text == "" && dgView.Rows.Count > 0)
                {
                    lblCashTender.Select();
                }
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

        private void insertItem()
        {
            try
            {
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemStatus = "New";
                objPOBAL.ItemCode = txtItemCode.Text.Trim();
                objPOBAL.ItemCatId = 1;
                objPOBAL.ItemName = txtItemName.Text.Trim();
                objPOBAL.SItemName = "";
                objPOBAL.Discount = 0;
                objPOBAL.ItemUnit = "Nos";
                objPOBAL.CostPrice = 0;
                objPOBAL.SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
                objPOBAL.SellingPrice2 = 0;
                objPOBAL.SPPRiceEffectFrom = 0;
                objPOBAL.MinQty = 0;
                objPOBAL.AvailableQty = 0;
                // objPOBAL.ItemMode = comboBoxItemMode.Text.Trim();
                objPOBAL.ItemMode = "COMMON STOCK";
                objPOBAL.OpenBalDate = DateTime.Today;
                objPOBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                //objPOBAL.Wharehouse = "Wharehouse1";
                objPOBAL.SupplierId = 0;
                objPOBAL.WarrantyPeriod = "";
                objPOBAL.FreeIssueEffectFrom = 0;
                //if (Convert.ToDecimal(labelNetDiff.Text) > 0)
                //{
                //    objPOBAL.InValue = Convert.ToDecimal(labelNetDiff.Text);
                //    objPOBAL.OutValue = 0;
                //}
                //if (Convert.ToDecimal(labelNetDiff.Text) < 0)
                //{
                //    objPOBAL.OutValue = (Convert.ToDecimal(labelNetDiff.Text) * -1);
                //    objPOBAL.InValue = 0;
                //}
                //if (Convert.ToDecimal(labelQtyDiff.Text) > 0)
                //{
                //    objPOBAL.InQty = Convert.ToDecimal(labelQtyDiff.Text);
                //    objPOBAL.OutQty = 0;
                //}
                //if (Convert.ToDecimal(labelQtyDiff.Text) < 0)
                //{
                //    objPOBAL.OutQty = (Convert.ToDecimal(labelQtyDiff.Text) * -1);
                //    objPOBAL.InQty = 0;
                //}
                //if (radioButtonOpen.Checked == true)
                //{
                //    objPOBAL.OpenStates = 1;
                //}
                //if (radioButtonNew.Checked == true || radioButtonAdjust.Checked == true)
                //{
                //    objPOBAL.OpenStates = 0;
                //}
                objPOBAL.OpenStates = 0;
                ClassPODAL objPODAL = new ClassPODAL();
                int count = objPODAL.InsertUpdateStock(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateTempHDNo()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                //Invoice = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[2].Rows[0][0]) + 1;
                TempSohdid = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[2].Rows[0][0]) + 1;
                //txtInvoiceNo.Text = Invoice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTemp()
        {
            try
            {
                GenerateTempHDNo();

                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.SOHDId = Convert.ToInt32(TempSohdid);//lblUserId.Tex
                    objInvBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    objInvBAL.ItemName = dgView.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                    objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value);
                    objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value);
                    objInvBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value);
                    objInvBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    if ((dgView.Rows[i].Cells["ItemsId"].Value.ToString()) == "")
                    {
                        objInvBAL.ItemsId = 0;
                    }
                    if ((dgView.Rows[i].Cells["ItemsId"].Value.ToString()) != "")
                    {
                        objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                    }
                    if ((dgView.Rows[i].Cells["ItemCatID"].Value.ToString()) == "")
                    {
                        objInvBAL.ItemCatId = 0;
                    }
                    if ((dgView.Rows[i].Cells["ItemCatID"].Value.ToString()) != "")
                    {
                        objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                    }
                    objInvBAL.Warranty = dgView.Rows[i].Cells["Warranty"].Value.ToString().Trim();
                    // objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells[8].Value);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertTempSoDt(objInvBAL);
                    if (count != 0)
                    {
                        savestate = true;

                    }
                }

                if (savestate == true)
                {
                    fillHoldGrid();
                    // MessageBox.Show("Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteTemp()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteTemp(objInvBAL);
                //if (count != 0)
                //{
                //    fillHoldGrid();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillTempIdData()
        {
            try
            {
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.SOHDId = TempId;
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveHoldData(objPOBAL);
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

                        int n = dgView.Rows.Add();
                        //int intQtyOrdered = int.Parse(txtQty.Text);

                        dgView.Rows[n].Cells["ItemCode"].Value = (values[2].ToString().Trim());
                        dgView.Rows[n].Cells["ItemName"].Value = (values[3].ToString().Trim());
                        dgView.Rows[n].Cells["Qty"].Value = (values[4].ToString().Trim());
                        dgView.Rows[n].Cells["Price"].Value = (values[5].ToString().Trim());
                        dgView.Rows[n].Cells["Amount"].Value = (values[6].ToString().Trim());
                        dgView.Rows[n].Cells["Discount"].Value = (values[7].ToString().Trim());
                        dgView.Rows[n].Cells["NetAmount"].Value = (values[8].ToString().Trim());
                        dgView.Rows[n].Cells["ItemsId"].Value = (values[1].ToString().Trim());
                        dgView.Rows[n].Cells["ItemCatID"].Value = (values[9].ToString().Trim());
                        dgView.FirstDisplayedScrollingRowIndex = n;
                        dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        dgView.Rows[n].Selected = true;

                        txtItemCode.Text = "";
                        txtItemName.Text = "";
                        txtQuantity.Text = "1";
                        textBoxFree.Text = "0";
                        txtSellingPrice.Text = "0";
                        txtGross.Text = "0.00";
                        txtDisc.Text = "0";
                        txtSubtotals.Text = "0.00";
                        txtItemId.Text = "0";
                        comboBoxItemCat.SelectedIndex = -1;
                        comboBoxWarranty.Text = "No Warranty";
                        textBoxNoOfItems.Text = dgView.Rows.Count.ToString();
                        CalculateTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteTempSelected()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = TempId;
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteTempId(objInvBAL);
                if (count != 0)
                {
                    fillHoldGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillHoldGrid()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                dataGridView1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveHoldBills(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objInvBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["HoldNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void fillDayEndData()
        //{
        //    try
        //    {
        //        message = "";
        //        string TotalSale, SalesReturn, TotalNetSale, TotalCashSale, TotalChequeSale, TotalCreditSale, Expenses, TranDate;
        //        objBAL = new ClassPOBAL();
        //        objDAL = new ClassPODAL();
        //        objBAL.DtDataSet = objDAL.retreiveDayEndData(objBAL);
        //        if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            List<ArrayList> newval = new List<ArrayList>();
        //            foreach (DataRow dRow in objBAL.DtDataSet.Tables[0].Rows)
        //            {
        //                ArrayList values = new ArrayList();
        //                values.Clear();
        //                foreach (object value in dRow.ItemArray)
        //                    values.Add(value);
        //                newval.Add(values);
        //                TotalSale = "Total Sale = " + (values[0].ToString().Trim());
        //                SalesReturn = "SalesReturn = " + (values[1].ToString().Trim());
        //                TotalNetSale = "TotalNetSale = " + (values[2].ToString().Trim());
        //                TotalCashSale = "TotalCashSale = " + (values[3].ToString().Trim());
        //                TotalChequeSale = "TotalChequeSale = " + (values[4].ToString().Trim());
        //                TotalCreditSale = "TotalCreditSale = " + (values[5].ToString().Trim());
        //                Expenses = "Expenses = " + (values[6].ToString().Trim());
        //                TranDate = "Date = " + (values[7].ToString().Trim());

        //                message = TranDate + " " + TotalSale + " " + SalesReturn + " " + TotalNetSale + " " + TotalCashSale + " " + TotalChequeSale + " " + TotalCreditSale + " " + Expenses;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        

        string message1;

        private void fillDayEndData()
        {
            try
            {
                message1 = "";
                string TotalSale, SalesReturn, TotalNetSale, TotalCashSale, TotalChequeSale, TotalCreditSale, TotalCardSale, Expenses, CashIn, BankDeposit, IssuedGiftVoucher, LastCashBalance, TranDate;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveDayEndData(objBAL);
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
                        TotalSale = "Total Sale = " + (values[0].ToString().Trim());
                        SalesReturn = "Sales Return = " + (values[1].ToString().Trim());
                        TotalNetSale = "Total Net Sale = " + (values[2].ToString().Trim());
                        TotalCashSale = "Total Cash Sale = " + (values[3].ToString().Trim());
                        TotalChequeSale = "Total Cheque Sale = " + (values[4].ToString().Trim());
                        TotalCreditSale = "Total Credit Sale = " + (values[5].ToString().Trim());
                        TotalCardSale = "Total Card Sale = " + (values[6].ToString().Trim());
                        Expenses = "Expenses = " + (values[7].ToString().Trim());
                        CashIn = "CashIn = " + (values[12].ToString().Trim());
                        BankDeposit = "Bank Transfer = " + (values[14].ToString().Trim());
                        IssuedGiftVoucher = "Issued Gift Voucher = " + (values[16].ToString().Trim());
                        LastCashBalance = "Last Cash Balance = " + (values[15].ToString().Trim());
                        TranDate = "Date = " + (values[13].ToString().Trim());

                        message1 = "DAY END SUMMARY " + TranDate + " " + TotalSale + " " + SalesReturn + " " + TotalNetSale + " " + TotalCashSale + " " + TotalChequeSale + " " + TotalCreditSale + " " + TotalCardSale + " " + Expenses + " " + CashIn + " " + BankDeposit + " " + IssuedGiftVoucher + " " + LastCashBalance;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendSummarySMS()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fillDayEndData();
                WebClient client = new WebClient();

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                client.QueryString.Add("id", "94715278260");
                client.QueryString.Add("pw", "1412");
                client.QueryString.Add("to", "94717356916");
                client.QueryString.Add("text", message1);
                string baseurl = "http://www.textit.biz/sendmsg";
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                //MessageBox.Show("Dayend Report Sent Successfully", "Send Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    WebClient client = new WebClient();

            //    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            //    client.QueryString.Add("id", "94777815285");
            //    client.QueryString.Add("pw", "2940");
            //    client.QueryString.Add("to", "94777815285");
            //    client.QueryString.Add("text", message);
            //    string baseurl = "http://www.textit.biz/sendmsg";
            //    Stream data = client.OpenRead(baseurl);
            //    StreamReader reader = new StreamReader(data);
            //    string s = reader.ReadToEnd();
            //    data.Close();
            //    reader.Close();
            //    MessageBox.Show("Dayend Report Sent Successfully", "Send Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void openDrawer()
        {
            try
            {
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
                pd.BeginPrint += new System.Drawing.Printing.PrintEventHandler(pd_BeginPrint);
                pd.EndPrint += new System.Drawing.Printing.PrintEventHandler(pd_EndPrint);
                pd.Print();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("--- Open Drawer ---", new Font("Arial", 10f), new SolidBrush(Color.Red), new PointF(20, 20));

        }
        void pd_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        void pd_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void display()
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
                    sp.WriteLine(cmbSalesRep.Text);
                    //sp.WriteLine("< YOU ARE WELCOME >");
                    sp.WriteLine((char)13 + "TOTAL : " + textBoxReceivable.Text);

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

        void exitCashier()
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
                Invoice = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]) + 1;
                Sohdid = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[0].Rows[0][0]);
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
            textBoxChargesPer.Text = "0.00";
            textBoxChargesAmount.Text = "0.00";
            
            textBoxVoucherAmount.Text = "0.00";
            textBoxVAT.Text = "0.00";
            textBoxNBT.Text = "0.00";
            textBoxAddChgs.Text = "0.00";
            textBoxAddChgPer.Text = "0";
            textBoxTotDiscPerc.Text = "0";
            textBoxVoucherNo.Text = "0";
            //lblNetTotal.Text = "0.00";
            //lblCashTender.Text = "0.00";
            //lblChange.Text = "0.00";
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
            textBoxCustName.Clear();
            textBoxSerial.Clear();
            textBoxCreditDueDays.Text = "0";
            textBoxLoyalty.Text = "0.00";
            LoyaltyPercentage = 0;
            LoyaltyAmount = 0;
            InvoiceLoyaltyAmount = 0;
            textBoxTotDiscPerc.Text = companydisc.ToString();
            textBoxReturnId.Text = "0";
            textBoxReturnNoteAmount.Text = "0.00";
            textBoxInvoice.Clear();
            textBoxNetAmount.Text = "0.00";
            textBoxCash.Text = "0.00";
            textBoxBalance.Text = "0.00";
            comboBoxPriceMethod.Text = "Retail";
            textBoxExInvoiceNo.Text = "0";
            cmdSave.Enabled = true;
            lblCashTender.Enabled = true;
            gridControl4.DataSource = null;
        }

        private void ItemAutoComplete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemNameInvoice(objInvBAL);

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
                txtItemName.Select();
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

        private void SearchBranchQty()
        {
            try
            {
                textBoxAvailableQty.Text = "0.00";
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objInvDAL = new ClassInvoiveDAL();
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
                LoyaltyPercentage = 0;
                LoyaltyAmount = 0;
                textBoxLoyalty.Text = "0.00";
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
                        textBoxCustName.Text = (values[1].ToString().Trim());
                        textBoxLoyalty.Text = (values[15].ToString().Trim());
                        LoyaltyPercentage = Convert.ToDecimal((values[16].ToString().Trim()));
                        LoyaltyAmount = Convert.ToDecimal((values[17].ToString().Trim()));
                    }
                    lblCashTender.Select();
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
                textBoxUnitDisc.Text = "0.00";
                defaultDiscount = 0;
                FreeIssueEffectFrom = 0;
                spPriceEffect = 0;
                OriginalPrice = 0;
                purchasePrice = 0;
                MinSellingPrice = 0;
                MinQty = 0;
                textBoxCostPrice.Text = "0.00";
                textBoxAvailableQty.Text = "0.00";
                textBoxFree.Text = "0";
                //textBoxSerial.Clear();
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
                            FormItemNames frm = new FormItemNames();
                            frm.frm = this;
                            frm.ItemCode = txtItemCode.Text;
                            frm.ShowDialog(this);
                            SearchItemsIDData();
                        }
                        else
                        {

                            txtItemName.Text = (values[0].ToString().Trim());
                            txtItemId.Text = (values[2].ToString().Trim());
                            //if (Convert.ToDecimal(values[1].ToString()) > 0)
                            //{
                            //    txtSellingPrice.ReadOnly = true;
                            //}
                            //if (Convert.ToDecimal(values[1].ToString()) == 0)
                            //{
                            //    txtSellingPrice.ReadOnly = false;
                            //}



                            if (comboBoxPriceMethod.Text == "Retail")
                            {
                                objInvBAL = new ClassInvoiceBAL();
                                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                                objInvDAL = new ClassInvoiveDAL();
                                dataGridView1.DataSource = null;
                                objInvBAL.DtDataSet = objInvDAL.retreiveRetailPrices(objInvBAL);
                                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                                {
                                    FormRetailPrices frm = new FormRetailPrices();
                                    frm.frm = this;
                                    frm.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm.PriceMode = 1;
                                    frm.ShowDialog(this);
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
                                    FormRetailPrices frm = new FormRetailPrices();
                                    frm.frm = this;
                                    frm.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm.PriceMode = 2;
                                    frm.ShowDialog(this);
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
                                    FormRetailPrices frm = new FormRetailPrices();
                                    frm.frm = this;
                                    frm.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm.PriceMode = 3;
                                    frm.ShowDialog(this);
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
                            MinQty = Convert.ToDecimal(values[19].ToString());
                        }

                        OriginalPrice = Convert.ToDecimal(txtSellingPrice.Text);
                        fillCustomerTypePrice();
                        txtSellingPrice.Select();
                        //txtQuantity.Select();
                    }
                    SearchBranchQty();

                }
                else if (objInvBAL.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[2].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        txtItemCode.Text = (values[0].ToString().Trim());
                    }
                    SearchItem();
                }
                else
                {
                    FormItemSearch frm = new FormItemSearch();
                    frm.frm = this;
                    frm.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    frm.ShowDialog(this);
                    //DialogResult result = MessageBox.Show("Item not exist in the Stock Do you want to add it?", "New Item.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{
                    //    txtItemName.Select();
                    //    newItem = true;
                    //}
                    //else
                    //{
                    //    txtItemCode.Select();
                    //}
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

                        //objInvBAL = new ClassInvoiceBAL();
                        //objInvBAL.ItemCode = txtItemCode.Text;
                        //objInvDAL = new ClassInvoiveDAL();
                        //objInvBAL.DtDataSet = objInvDAL.retreiveItemVariantData(objInvBAL);
                        //if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1 && namestatus == false)
                        //{
                        //    namestatus = true;
                        //    FormItemNames frm = new FormItemNames();
                        //    frm.frm = this;
                        //    frm.ItemCode = txtItemCode.Text;
                        //    frm.ShowDialog(this);
                        //    SearchItemsIDData();
                        //}
                        //else
                        //{

                            txtItemName.Text = (values[0].ToString().Trim());
                            txtItemCode.Text = (values[2].ToString().Trim());
                            //if (Convert.ToDecimal(values[1].ToString()) > 0)
                            //{
                            //    txtSellingPrice.ReadOnly = true;
                            //}
                            //if (Convert.ToDecimal(values[1].ToString()) == 0)
                            //{
                            //    txtSellingPrice.ReadOnly = false;
                            //}



                            if (comboBoxPriceMethod.Text == "Retail")
                            {
                                objInvBAL = new ClassInvoiceBAL();
                                objInvBAL.ItemsId = Convert.ToInt32(txtItemId.Text);
                                objInvDAL = new ClassInvoiveDAL();
                                dataGridView1.DataSource = null;
                                objInvBAL.DtDataSet = objInvDAL.retreiveRetailPrices(objInvBAL);
                                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 1)
                                {
                                    FormRetailPrices frm = new FormRetailPrices();
                                    frm.frm = this;
                                    frm.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm.PriceMode = 1;
                                    frm.ShowDialog(this);
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
                                    FormRetailPrices frm = new FormRetailPrices();
                                    frm.frm = this;
                                    frm.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm.PriceMode = 2;
                                    frm.ShowDialog(this);
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
                                    FormRetailPrices frm = new FormRetailPrices();
                                    frm.frm = this;
                                    frm.ItemId = Convert.ToInt32(txtItemId.Text);
                                    frm.PriceMode = 3;
                                    frm.ShowDialog(this);
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
                    FormItemSearch frm = new FormItemSearch();
                    frm.frm = this;
                    frm.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    frm.ShowDialog(this);
                    //DialogResult result = MessageBox.Show("Item not exist in the Stock Do you want to add it?", "New Item.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{
                    //    txtItemName.Select();
                    //    newItem = true;
                    //}
                    //else
                    //{
                    //    txtItemCode.Select();
                    //}
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
                txtItemCode.Clear();
                //availableQty = 0;
                //txtSellingPrice.Text = "0.00";
                //txtItemId.Clear();
                //comboBoxItemCat.SelectedIndex = -1;
                //txtDisc.Text = "0";
                //textBoxLDiscAmt.Text = "0.00";
                //FreeIssueEffectFrom = 0;
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemName = txtItemName.Text.Trim();
                objInvDAL = new ClassInvoiveDAL();
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
                        txtItemCode.Text = (values[0].ToString().Trim());
                        ////if (Convert.ToDecimal(values[1].ToString()) > 0)
                        ////{
                        ////    txtSellingPrice.ReadOnly = true;
                        ////}
                        ////if (Convert.ToDecimal(values[1].ToString()) == 0)
                        ////{
                        ////    txtSellingPrice.ReadOnly = false;
                        ////}
                        //txtSellingPrice.Text = (values[1].ToString().Trim());
                        //txtItemId.Text = (values[2].ToString().Trim());
                        //availableQty = Convert.ToDecimal(values[3].ToString().Trim());
                        //comboBoxItemCat.SelectedValue = Convert.ToInt32(values[4].ToString());
                        //FreeIssueEffectFrom = Convert.ToInt32(values[5].ToString());
                        //txtDisc.Text = (values[5].ToString().Trim());
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

        void AddtoGrid()
        {
            try
            {
                if (checkBoxItemBal.Checked == false)
                {
                    if (Convert.ToDecimal(textBoxAvailableQty.Text) < Convert.ToDecimal(txtQuantity.Text))
                    {
                        MessageBox.Show("Sorry item is out of stock.\n Please select other item..", "Transaction Failed.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtItemCode.Focus();
                        return;
                    }
                    else if (Convert.ToDecimal(textBoxAvailableQty.Text) <= 0)
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
                if (txtItemCode.Text == "" || txtItemName.Text == "")
                {
                    MessageBox.Show("Please enter item to purchase before you can save this record.", "Front Desk Module", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                //if (MinQty <= (Convert.ToDecimal(textBoxAvailableQty.Text) - Convert.ToDecimal(txtQuantity.Text)))
                //{
                //    MessageBox.Show("Item Reached to Reorderlevel.", "Reorder level.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                
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
                    dgView.Rows[n].Cells["SerialNo"].Value = textBoxSerial.Text;
                    dgView.Rows[n].Cells["PriceMethod"].Value = comboBoxPriceMethod.Text;
                    dgView.Rows[n].Cells["DiscPer"].Value = txtDisc.Text;
                    

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
                    textBoxSerial.Clear();

                    lblNetTotal.Text = "0.00";
                    textBoxReceivable.Text = "0.00";
                    lblCashTender.Text = "0.00";
                    lblChange.Text = "0.00";

                    textBoxNoOfItems.Text = dgView.Rows.Count.ToString();

                    addStatus = false;
                    CalculateTotal();
                }
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                txtItemCode.Select();
                //}
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
                        string s = Convert.ToString(selectedRow.Cells["SerialNo"].Value);
                        string n = Convert.ToString(selectedRow.Cells["ItemName"].Value);

                       // MessageBox.Show(a.ToString());
                        txtItemCode.Text = a.ToString();
                        txtItemId.Text = r.ToString();
                        textBoxSerial.Text = s.ToString();
                        
                        txtDisc.Text = "0";
                        textBoxLDiscAmt.Text = "0.00";
                        textBoxUnitDisc.Text = "0.00";
                        lblCashTender.Text = "0.00";

                        SearchItem();
                        //SearchItemByID();
                        txtQuantity.Text = q.ToString();
                        txtSellingPrice.Text = p.ToString();
                        txtItemName.Text = n.ToString();
                        textBoxSerial.Text = s.ToString();
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

        void CalculateTotal()
        {
            try
            {
                ////Initial Amount
                //decimal total_amount = 0;
                //decimal total_cramount = 0;
                ////decimal tAX = 0;
                ////decimal tVat = 0;
                ////Quantity
                //decimal Quan = 0;
                //decimal Quant = 0;
                //decimal Quanti = 0;
                //string ans;
                ////Discount
                //decimal cDAmount = 0;
                //decimal price = 0;
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
                        
                        //NetTotal = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                        //Initial Total of items in list
                        //total_amount += decimal.Parse(dgView.Rows[a].Cells[4].Value.ToString());
                        //total_cramount += decimal.Parse(dgView.Rows[a].Cells[6].Value.ToString());
                        ////Total Quantity of items in list
                        //Quan += decimal.Parse(dgView.Rows[a].Cells[2].Value.ToString());
                        ////Total Price
                        //price += decimal.Parse(dgView.Rows[a].Cells[3].Value.ToString());
                        ////Total Discount of items in list
                        //cDAmount = cDAmount + Convert.ToDecimal((Convert.ToDecimal(dgView.Rows[a].Cells[5].Value.ToString()) / 100) * (Convert.ToDecimal(Quan) * Convert.ToDecimal(price)));

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
                lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text))).ToString("0.00");
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");
                textBoxTotItem.Text = TotQty.ToString("0.00");
                //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                //Quanti = Quant + Quan;
                ////tAX = (total_cramount / 1.12m);
                ////tVat = total_cramount - Convert.ToDecimal(tAX);

                //ans = Quanti.ToString();

                //lblItemDiscount.Text = cDAmount.ToString("0.00");

                //lblSubTotal.Text = String.Format("{0:0.00}", total_amount);
                //lblGrossTot.Text = String.Format("{0:0.00}", total_cramount);

                disccal();
                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disccal()
        {
            try
            {
                if (textBoxTotDiscPerc.Text != "")
                {
                    if (Convert.ToDecimal(textBoxTotDiscPerc.Text) > 0)
                    {
                        txtTotDiscRate.Text = ((Convert.ToDecimal(textBoxTotDiscPerc.Text) / 100) * Convert.ToDecimal(lblGrossTot.Text)).ToString("0.00");

                        lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                        textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");

                        calcNet();
                    }
                }
            }
            catch (Exception)
            {

                throw;
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


        private void SaveSOHD()
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

                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != 0)
                {
                    GenerateInvoice();
                    SaveSODT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveQuotationHDNew()
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
                string count = objInvDAL.InsertNewQuotationhd(objInvBAL);
                txtInvoiceNo.Text = count.ToString();

                //int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != "")
                {
                    //GenerateInvoice();
                    SaveQuotationDT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SaveQuotationDT()
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
                        objInvBAL.FreeIssue = Convert.ToInt32(dgView.Rows[i].Cells["FreeIssue"].Value);

                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertQuotationDt(objInvBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }

                }

                if (savestate == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to Print this Quotation?", "Printing Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        printQuotation();
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
                    fillCashBalance();
                    //sendSalesReportmail();
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
                Cursor.Current = Cursors.WaitCursor;
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
                objInvBAL.CustomerName = textBoxCustName.Text;
                objInvBAL.Charges = Convert.ToDecimal(textBoxChargesAmount.Text);
                objInvBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
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
                objInvBAL.LoyaltyPoints = Convert.ToDecimal(InvoiceLoyaltyAmount.ToString());
                objInvBAL.LoyaltyBalance = Convert.ToDecimal(textBoxLoyalty.Text);
                objInvBAL.ReturnNoteNo = Convert.ToInt32(textBoxReturnId.Text);
                objInvBAL.ReturnNoteAmount = Convert.ToDecimal(textBoxReturnNoteAmount.Text);
                objInvBAL.CashBalance = Convert.ToDecimal(lblChange.Text);

                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.InsertNewsohd(objInvBAL);
                txtInvoiceNo.Text = count.ToString();
                Cursor.Current = Cursors.Default;
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
                Cursor.Current = Cursors.WaitCursor;
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
                        objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                        objInvBAL.PriceMethod = dgView.Rows[i].Cells["PriceMethod"].Value.ToString().Trim();
                        objInvBAL.DiscPer = Convert.ToDecimal(dgView.Rows[i].Cells["DiscPer"].Value);

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
                        objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                        objInvBAL.PriceMethod = dgView.Rows[i].Cells["PriceMethod"].Value.ToString().Trim();
                        objInvBAL.DiscPer = Convert.ToDecimal(dgView.Rows[i].Cells["DiscPer"].Value);

                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertSoDt(objInvBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    } 
                    
                }

                Cursor.Current = Cursors.Default;

                if (savestate == true)
                {
                    if (Convert.ToDecimal(textBoxVoucherAmount.Text) > 0)
                    {
                        UpdateAllGiftVouchers();
                    }
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

                    if (AllowSMS == true)
                    {
                        //sendOwnerMessage();

                        DialogResult result1 = MessageBox.Show("Do you want to send thanking message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1 == DialogResult.Yes && textBoxCustMobile.Text != "")
                        {
                            //sendThankingSMS();
                            if (textBoxCustMobile.Text != "")
                            {
                                sendCustomerMessage();
                            }
                        }
                    }

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

                    fillPendingGrid();
                    fillCashBalance();
                    //sendSalesReportmail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSOHDNew()
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
                objInvBAL.BillNo = Convert.ToInt32(textBoxExInvoiceNo.Text);
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
                objInvBAL.CustomerName = textBoxCustName.Text;
                objInvBAL.Charges = Convert.ToDecimal(textBoxChargesAmount.Text);
                objInvBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
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
                objInvBAL.LoyaltyPoints = Convert.ToDecimal(InvoiceLoyaltyAmount.ToString());
                objInvBAL.LoyaltyBalance = Convert.ToDecimal(textBoxLoyalty.Text);
                objInvBAL.ReturnNoteNo = Convert.ToInt32(textBoxReturnId.Text);
                objInvBAL.ReturnNoteAmount = Convert.ToDecimal(textBoxReturnNoteAmount.Text);
                objInvBAL.CashBalance = Convert.ToDecimal(lblChange.Text);

                objInvDAL = new ClassInvoiveDAL();
                string count = objInvDAL.UpdateNewsohd(objInvBAL);
                txtInvoiceNo.Text = count.ToString();

                //int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != "")
                {
                    DeleteDTData();
                    UpdateSODT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSODT()
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
                        objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                        objInvBAL.PriceMethod = dgView.Rows[i].Cells["PriceMethod"].Value.ToString().Trim();
                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.UpdateSalesRtn(objInvBAL);
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
                        objInvBAL.SerialNo = dgView.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                        objInvBAL.PriceMethod = dgView.Rows[i].Cells["PriceMethod"].Value.ToString().Trim();
                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.UpdateSoDt(objInvBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }

                }

                if (savestate == true)
                {
                    DialogResult result = MessageBox.Show("Do you want to Print this Invoice?", "Printing Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        printInvoice();
                    }

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

                    fillPendingGrid();
                    fillCashBalance();
                    //sendSalesReportmail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createMessage()
        {
            try
            {
                if ((string.IsNullOrEmpty(textBoxCustCredit.Text)) || (textBoxCustCredit.Text.Trim().Equals(string.Empty)))
                {
                    textBoxCustCredit.Text = "0";
                }
                message = "";
                balance = 0;
                totBal = 0;
                cashbalance = 0;
                cashbalance = Convert.ToDecimal(lblCashTender.Text) - Convert.ToDecimal(textBoxReceivable.Text);
                totBal = Convert.ToDecimal(textBoxCustCredit.Text);

                if (comboBoxCustomer.SelectedIndex != -1)
                {
                    if (cashbalance < 0)
                    {
                        balance = (cashbalance * -1);
                        totBal = (cashbalance * -1) + (Convert.ToDecimal(textBoxCustCredit.Text));
                        message = "Dear Customer, Thank you for your payment of Rs. " + lblCashTender.Text.Trim() + " for Bill No. " + txtInvoiceNo.Text.Trim() + " Your balance amount for this bill is Rs. " + balance.ToString() + " And Your Total Credit Balance is Rs. " + totBal.ToString() + ". Scan Tech Office Automation.";
                    }
                    else if (cashbalance >= 0)
                    {
                        if (totBal > 0)
                        {
                            message = "Dear Customer, Thank you for your payment of Rs. " + lblNetTotal.Text.Trim() + " for Bill No. " + txtInvoiceNo.Text.Trim() + " Your Total Credit Balance is Rs." + totBal.ToString() + ". Scan Tech Office Automation.";
                        }
                        else
                        {
                            message = "Dear Customer, Thank you for your payment of Rs. " + lblNetTotal.Text.Trim() + " for Bill No. " + txtInvoiceNo.Text.Trim() + ". Scan Tech Office Automation.";
                        }
                    }
                }
                textBoxMessage.Text = message.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void sendThankingSMS()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WebClient client = new WebClient();

                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");

                client.QueryString.Add("id", "94715278260");
                client.QueryString.Add("pw", "1412");
                client.QueryString.Add("to", textBoxCustMobile.Text.Trim());
                client.QueryString.Add("text", textBoxMessage.Text.Trim());
                string baseurl = "http://www.textit.biz/sendmsg";
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTempSales()
        {
            try
            {
                DeleteTempSales();

                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                    objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value);
                    objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value);
                    objInvBAL.Discount = Convert.ToDecimal(dgView.Rows[i].Cells["Discount"].Value);
                    objInvBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objInvBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    objInvBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                    objInvBAL.InternalNo = dgView.Rows[i].Cells["InternalNo"].Value.ToString().Trim();
                    objInvBAL.FreeIssue = Convert.ToInt32(dgView.Rows[i].Cells["FreeIssue"].Value);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertTempSales(objInvBAL);
                    //if (count != 0)
                    //{
                    //    savestate = true;

                    //}
                }

                //if (savestate == true)
                //{
                    SaveSales();
                    GetInvoiceNo();
                    if (InvoiceNo > 0)
                    {
                        if (comboBoxPayMode.Text == "Credit")
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
                        if (VATStatus == true)
                        {
                            printVATInvoice();
                        }
                        if (VATStatus == false)
                        {
                            printInvoice();
                        }
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
                    fillCashBalance();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSales()
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
                objInvBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objInvBAL.SOGrossTotal = Convert.ToDecimal(lblGrossTot.Text);
                objInvBAL.SODiscount = Convert.ToDecimal(txtTotDiscRate.Text);
                objInvBAL.SONetTotal = Convert.ToDecimal(lblNetTotal.Text);
                objInvBAL.Remarks = txtComment.Text;
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objInvBAL.Cash = Convert.ToDecimal(lblCashTender.Text);
                objInvBAL.AdditionalChgs = Convert.ToDecimal(textBoxAddChgs.Text);
                objInvBAL.VAT = Convert.ToDecimal(textBoxVAT.Text);
                objInvBAL.NBT = Convert.ToDecimal(textBoxNBT.Text);
                objInvBAL.InternalNo = textBoxInternalNo.Text;
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.InsertSales(objInvBAL);
                if (count != 0)
                {
                    GenerateInvoice();
                    //SaveSODT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteTempSales()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteTempSales(objInvBAL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTaxSales()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.UpdateTaxSales(objInvBAL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetInvoiceNo()
        {
            InvoiceNo = 0;
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objInvDAL = new ClassInvoiveDAL();
                InvoiceNo = Convert.ToInt32(objInvDAL.SelectInvoice(objInvBAL).Tables[0].Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printVATInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportVATInvoice rpt = new CrystalReportVATInvoice();
                objBAL = new ClassPOBAL();
                objBAL.SOHDId = Convert.ToInt32(Sohdid);
                //objBAL.SOHDId = InvoiceNo;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveVATInvoiceData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                //crystalReportViewer1.PrintReport();
                rpt.PrintOptions.PrinterName = "";
                rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendDayEndReportmail()
        {
            try
            {
                // Cursor.Current = Cursors.WaitCursor;
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("easysolutionsrilanka@gmail.com", "nuwan1984");
                MailMessage msg = new MailMessage();
                msg.To.Add("agampodir@gmail.com");
                msg.From = new MailAddress("easysolutionsrilanka@gmail.com");
                msg.Subject = "Day End Report On " + DateTime.Today.ToString() + "";
                msg.Body = "This is the Day End Report of Alien Dreams.";
                Attachment data = new Attachment(pdfFileDayEnd);
                msg.Attachments.Add(data);
                client.Send(msg);
                // MessageBox.Show("Successfully Sent Sales Report.");
                // Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sendSalesReportmail()
        {
            try
            {
                // Cursor.Current = Cursors.WaitCursor;
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("easysolutionsrilanka@gmail.com", "nuwan1984");
                MailMessage msg = new MailMessage();
                msg.To.Add("agampodir@gmail.com");
                msg.From = new MailAddress("easysolutionsrilanka@gmail.com");
                msg.Subject = "Invoice " + Sohdid.ToString() + "";
                msg.Body = "This is an Invoice of Alien Dreams.";
                Attachment data = new Attachment(pdfFileSales);
                msg.Attachments.Add(data);
                client.Send(msg);
                // MessageBox.Show("Successfully Sent Sales Report.");
                // Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    else if (Option6 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportReturn3in3ex rpt = new CrystalReportReturn3in3ex();
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
                    else if (Option7 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportReturn3in3ex rpt = new CrystalReportReturn3in3ex();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void printQuotation()
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
                        CrystalReportA4QuotationCr rpt = new CrystalReportA4QuotationCr();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;

                    }
                    //else if (Option3 == true)
                    //{
                    //    //if (PrintBalance == true)
                    //    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    CrystalReportA4InvoiceSCr rpt = new CrystalReportA4InvoiceSCr();
                    //    objBAL = new ClassPOBAL();
                    //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    //    objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    crystalReportViewer1.ReportSource = rpt;
                    //    crystalReportViewer1.Refresh();
                    //    //crystalReportViewer1.PrintReport();
                    //    rpt.PrintOptions.PrinterName = "";
                    //    rpt.PrintToPrinter(1, false, 0, 0);
                    //    Cursor.Current = Cursors.Default;

                    //}
                    else if (Option4 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportQuotation5in3 rpt = new CrystalReportQuotation5in3();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;

                    }
                    //else if (Option5 == true)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    CrystalReportInvoice5in3S rpt = new CrystalReportInvoice5in3S();
                    //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    //    objBAL = new ClassPOBAL();
                    //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    //    objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    crystalReportViewer1.ReportSource = rpt;
                    //    crystalReportViewer1.Refresh();
                    //    //crystalReportViewer1.PrintReport();
                    //    rpt.PrintOptions.PrinterName = "";
                    //    rpt.PrintToPrinter(1, false, 0, 0);
                    //    Cursor.Current = Cursors.Default;
                    //}
                    else if (Option6 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportQuotation3in3 rpt = new CrystalReportQuotation3in3();
                        //CrystalReportInvoice2inLogoE rpt = new CrystalReportInvoice2inLogoE();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;
                    }
                    else if (Option7 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //CrystalReportInvoice2inLogoS rpt = new CrystalReportInvoice2inLogoS();
                        //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                        CrystalReportInvoice2inch rpt = new CrystalReportInvoice2inch();
                        objBAL = new ClassPOBAL();
                        objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        //crystalReportViewer1.PrintReport();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;
                    }
                    //else if (Option8 == true)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    CrystalReportInvoice5in3Lo rpt = new CrystalReportInvoice5in3Lo();
                    //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    //    objBAL = new ClassPOBAL();
                    //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    //    objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    crystalReportViewer1.ReportSource = rpt;
                    //    crystalReportViewer1.Refresh();
                    //    //crystalReportViewer1.PrintReport();
                    //    rpt.PrintOptions.PrinterName = "";
                    //    rpt.PrintToPrinter(1, false, 0, 0);
                    //    Cursor.Current = Cursors.Default;

                    //}
                    //else if (Option9 == true)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    CrystalReportInvoice5in3SLo rpt = new CrystalReportInvoice5in3SLo();
                    //    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    //    objBAL = new ClassPOBAL();
                    //    objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                    //    objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveTAWQuotationData(objBAL);
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


        private void ReprintInvoice()
        {
            try
            {
                if (Option2 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceCr rpt = new CrystalReportA4InvoiceCr();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option3 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceSCr rpt = new CrystalReportA4InvoiceSCr();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option4 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3 rpt = new CrystalReportInvoice5in3();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;

                }
                else if (Option5 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3S rpt = new CrystalReportInvoice5in3S();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
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
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
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
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option8 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3Lo rpt = new CrystalReportInvoice5in3Lo();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;

                }
                else if (Option9 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3SLo rpt = new CrystalReportInvoice5in3SLo();
                    //CrystalReportInvoice2inLogoS rpt = new CrystalReportInvoice2inLogoS();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option10 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3LF rpt = new CrystalReportInvoice5in3LF();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;

                }
                else if (Option11 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3SLF rpt = new CrystalReportInvoice5in3SLF();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option12 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceCrNLo rpt = new CrystalReportA4InvoiceCrNLo();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option13 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceSCrNLo rpt = new CrystalReportA4InvoiceSCrNLo();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option14 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice2in2ex rpt = new CrystalReportInvoice2in2ex();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option15 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice2in2exs rpt = new CrystalReportInvoice2in2exs();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option16 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3ext rpt = new CrystalReportInvoice3in3ext();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option17 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3T rpt = new CrystalReportInvoice5in3T();
                    //CrystalReportInvoice3in3eTest rpt = new CrystalReportInvoice3in3eTest();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option18 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3exLogo rpt = new CrystalReportInvoice3in3exLogo();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option19 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3exsLogo rpt = new CrystalReportInvoice3in3exsLogo();
                    //CrystalReportInvoice3in3eTest rpt = new CrystalReportInvoice3in3eTest();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option20 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3exTLogo rpt = new CrystalReportInvoice3in3exTLogo();
                    //CrystalReportInvoice3in3eTest rpt = new CrystalReportInvoice3in3eTest();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option21 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReport5InInvoiceCr rpt = new CrystalReport5InInvoiceCr();
                    //CrystalReportInvoice3in3eTest rpt = new CrystalReportInvoice3in3eTest();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option22 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReport5InInvoiceCrS rpt = new CrystalReport5InInvoiceCrS();
                    //CrystalReportInvoice3in3eTest rpt = new CrystalReportInvoice3in3eTest();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    if (comboBoxBranch.SelectedIndex == -1)
                    {
                        comboBoxBranch.SelectedValue = 0;
                    }
                    objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
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
                    objInvBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerCard(objInvBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

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
                    objInvBAL.CreditDueDays = Convert.ToInt32(textBoxCreditDueDays.Text);
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerCredit(objInvBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        void SaveQuotation()
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
                
                else
                {
                        if (comboBoxCustomer.SelectedIndex != -1)
                        {
                            PrintBalance = true;
                        }
                        Sohdid = 0;
                        SaveQuotationHDNew();
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
                            calcInvoiceLoyaltyAmount();
                            SaveSOHDNew();
                            //GenerateInvoice();
                            //ResetEntry();
                            //blnPaid = false;
                            //if (autocomplete == true)
                            //{
                            //    txtItemName.Select();
                            //}
                            //else
                            //{
                            //    txtItemCode.Select();
                            //}
                            //displyThank();
                            //displayClear();
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
                        calcInvoiceLoyaltyAmount();
                        SaveSOHDNew();
                        //GenerateInvoice();
                        //ResetEntry();
                        //blnPaid = false;
                        //if (autocomplete == true)
                        //{
                        //    txtItemName.Select();
                        //}
                        //else
                        //{
                        //    txtItemCode.Select();
                        //}
                        //displyThank();
                        //displayClear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void UpdateRecord()
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
                            //calcInvoiceLoyaltyAmount();
                            UpdateSOHDNew();
                            //GenerateInvoice();
                            //ResetEntry();
                            //blnPaid = false;
                            //if (autocomplete == true)
                            //{
                            //    txtItemName.Select();
                            //}
                            //else
                            //{
                            //    txtItemCode.Select();
                            //}
                            //displyThank();
                            //displayClear();
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
                        calcInvoiceLoyaltyAmount();
                        UpdateSOHDNew();
                        //GenerateInvoice();
                        //ResetEntry();
                        //blnPaid = false;
                        //if (autocomplete == true)
                        //{
                        //    txtItemName.Select();
                        //}
                        //else
                        //{
                        //    txtItemCode.Select();
                        //}
                        //displyThank();
                        //displayClear();
                    }
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
                        if (FreeIssueEffectFrom > 0 && Convert.ToDecimal(textBoxFree.Text) == 0)
                        {
                            FreeIssueStatus = true;
                            FreeIssueQty = Convert.ToInt32(txtQuantity.Text) / FreeIssueEffectFrom;
                            quantity = decimal.Parse(txtQuantity.Text);
                            textBoxFree.Text = FreeIssueQty.ToString("0");
                            txtQuantity.Text = quantity.ToString("0.00");
                        }
                        //else
                        //{
                        //    quantity = decimal.Parse(txtQuantity.Text);
                        //    txtQuantity.Text = quantity.ToString("0.00");
                        //}
                    }
                    //Total = (decimal.Parse(txtSellingPrice.Text) * decimal.Parse(txtQuantity.Text)) - (decimal.Parse(txtSellingPrice.Text) * FreeIssueQty);
                    //txtGross.Text = Total.ToString("0.00");

                    //sum = Convert.ToDecimal(Total - lineDiscount);
                    //txtSubtotals.Text = sum.ToString("0.00");

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

        public void fillCashBalance()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.UserId = Convert.ToInt32(lblUserId.Text.Trim());
                objInvBAL.DtDataSet = objInvDAL.SelectCashBalnce(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    lblopenbalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][0].ToString()).ToString("0.00");
                    lblreciveAmount.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][1].ToString()).ToString("0.00");
                    lblPayments.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][2].ToString()).ToString("0.00");
                    lblCashBalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][3].ToString()).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void display()
        //{
        //    try
        //    {
        //        SerialPort sp = new SerialPort();

        //        sp.PortName = "COM6";
        //        sp.BaudRate = 9600;
        //        sp.Parity = Parity.None;
        //        sp.DataBits = 8;
        //        sp.StopBits = StopBits.One;
        //        sp.Open();
        //        sp.WriteLine("                                        ");
        //        //sp.WriteLine("Hi welocme here");
        //        sp.WriteLine(lblNetTotal.Text);
        //        sp.Close();
        //        sp.Dispose();
        //        sp = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void calcNet()
        {
            try
            {
                if (checkBoxVAT.Checked == true && checkBoxNBT.Checked == false)
                {
                    textBoxVAT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 11) / 100).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text) + Convert.ToDecimal(textBoxReturnNoteAmount.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == false && checkBoxNBT.Checked == true)
                {
                    textBoxNBT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 2) / 100).ToString("0.00");
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text) + Convert.ToDecimal(textBoxReturnNoteAmount.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == true && checkBoxNBT.Checked == true)
                {
                    textBoxNBT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)) * 2) / 100).ToString("0.00");
                    textBoxVAT.Text = ((((Convert.ToDecimal(lblGrossTot.Text)) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxNBT.Text)) * 11) / 100).ToString("0.00");
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text) + Convert.ToDecimal(textBoxReturnNoteAmount.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) - Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                }
                else if (checkBoxVAT.Checked == false && checkBoxNBT.Checked == false)
                {
                    //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text)) + Convert.ToDecimal(textBoxVAT.Text) + Convert.ToDecimal(textBoxNBT.Text)).ToString("0.00");
                    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                    textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text) + Convert.ToDecimal(textBoxReturnNoteAmount.Text))).ToString("0.00");
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
                label58.Visible = false;
                textBoxCostPrice.Visible = false;
                txtDisc.ReadOnly = true;
                textBoxLDiscAmt.ReadOnly = true;
                textBoxUnitDisc.ReadOnly = true;
                checkBoxItemBal.Checked = false;
                checkBoxItemBal.Enabled = false;
                comboBoxPriceMethod.Enabled = false;
                button8.Visible = false;
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
                            textBoxUnitDisc.ReadOnly = false;
                        }
                        if (alistForm[i].ToString().Trim() == "VisibleCost")
                        {
                            label58.Visible = true;
                            textBoxCostPrice.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Skip Item Balance Checking")
                        {
                            checkBoxItemBal.Checked = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Change Srip Item Balance Checking")
                        {
                            checkBoxItemBal.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Change Price Mode")
                        {
                            comboBoxPriceMethod.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Auto Complete")
                        {
                            autocomplete = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Update Tax Invoice")
                        {
                            button8.Visible = true;
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

        #region Events

        private void frmInvoice_KeyDown(object sender, KeyEventArgs e)
        {

        }

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
                    //if (Convert.ToDecimal(txtQuantity.Text) > spPriceEffect)
                    //{
                    //    txtSellingPrice.Text = specialPrice.ToString("0.00");
                    //}
                    //else if (Convert.ToDecimal(txtQuantity.Text) <= spPriceEffect)
                    //{
                    //    txtSellingPrice.Text = defaultPRice.ToString("0.00");
                    //}
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
            catch (Exception)
            {
                
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //txtSellingPrice.ReadOnly = true;
                //if (e.KeyCode == Keys.Enter && e.Control)
                //    e.SuppressKeyPress = false;
                //else
                //    e.SuppressKeyPress = true;

                //MessageBox.Show(e.SuppressKeyPress.ToString());

                if (txtItemCode.Text != "")
                {
                    scaleitem = false;
                    //lblNetTotal.Text = "0.00";
                    //lblCashTender.Text = "0.00";
                    //lblChange.Text = "0.00";
                   if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                    {
                        txtQuantity.Text = "1";
                    }
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";
                    textBoxUnitDisc.Text = "0.00";
                    //textBoxSerial.Clear();
                    //lblCashTender.Text = "0.00";

                    
                    //string mystring = txtItemCode.Text;
                    //if (Convert.ToInt32((mystring.Length).ToString())>6)
                    //{
                    //    string last4 = mystring.Substring(mystring.Length - 6, 6);
                    //    txtItemCode.Text = last4.ToString();
                    //}
                    if (txtItemCode.Text.Length == 11)
                    {
                        CheckScaleItem();
                        if (scaleitem == true)
                        {

                            string code = txtItemCode.Text;

                            string itmcode = code.Substring(0, 6);
                            string qty = code.Substring(6, 2) + "." + code.Substring(8, 3);

                            txtQuantity.Text = qty.ToString();
                            txtItemCode.Text = itmcode.ToString();
                            SearchItem();
                            txtQuantity.Text = qty.ToString();

                            addStatus = true;
                            calculateTotal();
                            txtQuantity.Select();
                        }
                        else
                        {
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
                                txtQuantity.Select();
                            }
                        }

                    }
                    else
                    {
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
                    FillAvailableSerial();
                }
                else if (txtItemCode.Text == "" && dgView.Rows.Count > 0)
                {
                    lblCashTender.Select();
                }
                else
                {
                    //if (autocomplete == true)
                    //{
                    //    txtItemName.Select();
                    //}
                    //else
                    //{
                    txtItemCode.Select();
                    //}
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceNo.Text == "")
                {
                    MessageBox.Show("Please enter Cash Slip.");
                    txtItemCode.Focus();
                    return;
                }
                //else if (blnPaid == false)
                //{
                //    lblStatus.Text = "Transaction not yet paid.";
                //    txtItemCode.Focus();
                //    return;
                //}
                else if (dgView.RowCount < 1)
                {
                    MessageBox.Show("Please enter item to purchase before you can save this record.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtItemCode.Focus();
                    return;
                }
                else
                {
                    //if (txtInvoiceNo.Text == textBoxInvoice.Text)
                    //{
                    //    DeleteHoldData();
                    //    SaveSODTHold();
                    //}
                    //else if (textBoxExInvoiceNo.Text != "0" && textBoxExInvoiceNo.Text != "")
                    //{
                    //    DialogResult result = MessageBox.Show("Do you want to Update this Invoice?", "Invoice Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (result == DialogResult.Yes)
                    //    {
                    //        UpdateRecord();
                    //    }
                    //}
                    //else
                    //{
                    cmdSave.Enabled = false;
                    lblCashTender.Enabled = false;
                        SaveRecord();
                    cmdSave.Enabled = true;
                    lblCashTender.Enabled = true;
                    //}
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



        private void frmInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                txtItemCode.Select();
                //}
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                if (objDAL.retreivePaymentModes(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objDAL.retreivePaymentModes(objBAL).Tables[0];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 0;
                }

                if (objDAL.retreiveAllCategoryData(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxItemCat.DataSource = objDAL.retreiveAllCategoryData(objBAL).Tables[0];
                    comboBoxItemCat.DisplayMember = "ItemCatName";
                    comboBoxItemCat.ValueMember = "ItemCatId";
                    comboBoxItemCat.SelectedIndex = -1;
                }
                if (objDAL.retreiveAllBranches(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxBranch.DataSource = objDAL.retreiveAllBranches(objBAL).Tables[0];
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.ValueMember = "BranchId";
                    comboBoxBranch.SelectedValue = lblBranchID.Text;
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
                this.KeyDown += new KeyEventHandler(frmInvoice_KeyDown);
                LoadCustomerCombo();
                loadStatus = false;
                //fillOptions();

                fillCashBalance();
                if (Convert.ToDecimal(lblopenbalance.Text) <= 0)
                {
                    frmOpeningBalance frm = new frmOpeningBalance();
                    frm.frm = this;
                    frm.lblUser.Text = lblUser.Text;
                    frm.lblUserId.Text = lblUserId.Text;
                    frm.lblBranchID.Text = lblBranchID.Text.Trim();
                    frm.ShowDialog(this);
                }
                fillHoldGrid();
                displayClear();
                //checkBoxItemBal.Checked = true;
                
                loadBank();
                fillImage();
                SelectCompanyData();
                loadInvoiceStatus();
                fillPendingGrid();
                comboBoxPriceMethod.Text = "Retail";
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                txtItemCode.Select();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;
            simpleButton2.Enabled = true;
            lblCashTender.Text = "0.00";

            if (comboBoxPayMode.Text == "Cheque")
            {
                label23.Visible = true;
                label23.Text = "Cheque No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Cheq. Date";
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
            else if (comboBoxPayMode.Text == "Bank Transfer")
            {
                //label23.Visible = true;
                //label23.Text = "Card No";
                //textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                //label27.Visible = true;
                //label27.Text = "Card Type";
                dateTimePickerChqExpDate.Visible = false;
                //comboBoxCardType.Visible = true;
            }
            else if (comboBoxPayMode.Text == "Return Note")
            {
                cmdSave.Enabled = false;
                simpleButton2.Enabled = false;
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

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtItemName.Text != "")
                {
                    txtSellingPrice.Select();
                    SearchItemByName();
                    if (Convert.ToDecimal(txtQuantity.Text) <= 0)
                    {
                        txtQuantity.Text = "1";
                    }
                    txtDisc.Text = "0";
                    textBoxLDiscAmt.Text = "0.00";
                    lblCashTender.Text = "0.00";

                    SearchItem();
                    addStatus = true;
                    calculateTotal();
                    //txtQuantity.Select();
                    txtSellingPrice.Select();
                }
                else if (txtItemName.Text == "" && dgView.Rows.Count > 0)
                {
                    lblCashTender.Select();
                }

            ////    txtQuantity.Text = "1";
            ////    txtDisc.Text = "0";
            ////    textBoxLDiscAmt.Text = "0.00";
            ////    //lblCashTender.Text = "0.00";
            //    if (newItem == true)
            //    {
            //        txtSellingPrice.Select();
            //    }
            //    else
            //    {
            //        SearchItemByName();
            //        if (Convert.ToDecimal(txtQuantity.Text) <= 0)
            //        {
            //            txtQuantity.Text = "1";
            //        }
            //        txtDisc.Text = "0";
            //        textBoxLDiscAmt.Text = "0.00";
            //        lblCashTender.Text = "0.00";

            //        SearchItem();
            //        addStatus = true;
            //        calculateTotal();
            //        //txtQuantity.Select();
            //        txtSellingPrice.Select();
            //    }
                

            ////    calculateTotal();
            ////    AddtoGrid();
            ////    txtItemCode.Select();
            ////    //txtQuantity.Select();
            ////    //StockChecker(txtStockID.Text);


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
                
                //textBoxLDiscAmt.Text = TotalLineDisc.ToString();
                //textBoxFree.Select();
                AddtoGrid();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                textBoxUnitDisc.Select();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtItemCode_Validating(object sender, CancelEventArgs e)
        {
            //txtQuantity.Text = "1";
            //txtDisc.Text = "0";

            //SearchItem();
            //calculateTotal();
            //AddtoGrid();
            //txtItemCode.Select();
        }

        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            //txtQuantity.Text = "1";
            //txtDisc.Text = "0";
            //textBoxLDiscAmt.Text = "0.00";
            ////lblCashTender.Text = "0.00";

            //SearchItemByName();
            //calculateTotal();
            //AddtoGrid();
            //txtItemCode.Select();
            //txtQuantity.Select();
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
                lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");

                //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReprintInvoice();
        }

        private void txtSellingPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidatePrice();
                if (isValid)
                {
                    if (txtSellingPrice.Text != "")
                    {
                        //decimal decamt = 0;
                        //decamt = Math.Round(Convert.ToDecimal(txtSellingPrice.Text) * 2, MidpointRounding.ToEven) / 2;
                        //txtSellingPrice.Text = decamt.ToString("0.00");
                        SelPriceDisc = 0;
                        //if (txtItemCode.Text != "111")
                        //{
                        SelPriceDisc = ((OriginalPrice - Convert.ToDecimal(txtSellingPrice.Text)) * Convert.ToDecimal(txtQuantity.Text));
                        //}
                        textBoxUnitDisc_TextChanged(sender, e);
                        calculateTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you want to Hold this Bill?", "Bill Holding Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    if (dgView.Rows.Count > 0)
            //    {
            //        SaveTemp();
            //    }
            //}
            DialogResult result = MessageBox.Show("Do you want to Clear All?", "Reset Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
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
            }
            
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (autocomplete == true)
            //{
            //    txtItemName.Select();
            //}
            //else
            //{
            txtItemCode.Select();
            //}
            FormItemSearch frm = new FormItemSearch();
            frm.frm = this;
            frm.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            frm.lblUser.Text = lblUser.Text.Trim();
            frm.lblUserId.Text = lblUserId.Text.Trim();
            frm.ShowDialog(this);
            //txtSellingPrice.Select();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxUnitDisc.Select();
            //textBoxLDiscAmt.Select();
            //addChgsPercStatus = false;
            //textBoxAddChgs.ReadOnly = false;
            //textBoxAddChgPer.ReadOnly = true;
            //textBoxAddChgs.Select();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddtoGrid();
            //comboBoxPayMode.Select();
            FormPayMode frm = new FormPayMode();
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Do you want to Remove Selected Item?", "Remove Item Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {
                 RemoveItem();
             }
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemCode.Text == "")
                {
                    addStatus = true;
                    ItemEdit();
                }
                
                txtSellingPrice.Select();
                //decimal qty = 0;
                //if (Convert.ToInt32(txtQuantity.Text) < 1)
                //{ lblStatus.Text = "Error while enter Quantity..."; txtQuantity.Text = "1"; }
                //else
                //{
                //    qty = Convert.ToInt32(txtQuantity.Text);
                //    qty = qty - 1;
                //    txtQuantity.Text = qty.ToString();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadcontrol();
            textBoxCustCode.Select();
            FormSearchCustomer frm = new FormSearchCustomer();
            frm.frm = this;
            frm.ShowDialog(this);
            //try
            //{
            //    decimal qty = 0;
            //    qty = Convert.ToInt32(txtQuantity.Text);
            //    qty = qty + 1;
            //    txtQuantity.Text = qty.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxSerial.Select();
            //txtItemName.Select();
            //DialogResult result = MessageBox.Show("Do you want to Close The Window?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            totDiscPercStatus = false;
            txtTotDiscRate.ReadOnly = false;
            textBoxTotDiscPerc.ReadOnly = true;
            txtTotDiscRate.Select();
            //exitCashier();
            //textBoxSerial.Select();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //totDiscPercStatus = false;
            //txtTotDiscRate.ReadOnly = false;
            //textBoxTotDiscPerc.ReadOnly = true;
            //txtTotDiscRate.Select();
        }

        private void comboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (loadStatus == false && comboBoxCategorySearch.SelectedIndex != -1)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                    objInvDAL = new ClassInvoiveDAL();
                    dataGridView2.DataSource = null;
                    objInvBAL.DtDataSet = objInvDAL.retreiveItemByCategory(objInvBAL);
                    if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        dataGridView2.DataSource = objInvBAL.DtDataSet.Tables[0];
                        dataGridView2.Columns["ItemsId"].Visible = false;
                        dataGridView2.Columns["SellingPrice"].Visible = false;
                        dataGridView2.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView2.Columns["ItemCatId"].Visible = false;
                        dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                        dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSearchItemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemName = textBoxSearchItemName.Text;
                objInvDAL = new ClassInvoiveDAL();
                dataGridView2.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsName(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objInvBAL.DtDataSet.Tables[0];
                    dataGridView2.Columns["ItemsId"].Visible = false;
                    dataGridView2.Columns["SellingPrice"].Visible = false;
                    dataGridView2.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["ItemCatId"].Visible = false;
                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text == textBoxInvoice.Text)
            {
                DeleteHoldData();
                SaveSODTHoldComplete();
                //SaveSODTHold();
            }
        }

        private void f11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxCustName.Select();
            ////SaveRecord();

            //if (dgView.RowCount < 1)
            //{
            //    MessageBox.Show("Please add items to save this record.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtItemCode.Focus();
            //    return;
            //}
            //else
            //{
            //    if (txtInvoiceNo.Text == textBoxInvoice.Text)
            //    {
            //        DeleteHoldData();
            //        UpdateHoldNewHD();
            //        //SaveSODTHold();
            //    }
            //    else
            //    {
            //        SaveTableRecord();
            //    }
            //}

        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                bool isValid = ValidatePrice();
                if (isValid)
                {
                    SelPriceDisc = 0;
                    if (newItem == true)
                    {
                        insertItem();
                        SearchItemByID();
                        //SearchItem();
                        newItem = false;
                    }

                    addStatus = true;
                    calculateTotal();
                    txtQuantity.Select();
                }
            }
        }

        private void txtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddtoGrid();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                textBoxLDiscAmt.Select();
            }
        }

        private void textBoxAddChgs_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if ((string.IsNullOrEmpty(textBoxAddChgs.Text)) || (textBoxAddChgs.Text.Trim().Equals(string.Empty)))
            //    {
            //        textBoxAddChgs.Text = "0.00";
            //    }
            //    lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
            //    //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void f31ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addChgsPercStatus = true;
            textBoxAddChgs.ReadOnly = true;
            textBoxAddChgPer.ReadOnly = false;
            textBoxAddChgPer.Select();
        }

        private void f101ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblCashTender.Select();
            //totDiscPercStatus = true;
            //txtTotDiscRate.ReadOnly = true;
            //textBoxTotDiscPerc.ReadOnly = false;
            //textBoxTotDiscPerc.Select();
        }

        private void textBoxAddChgPer_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if ((string.IsNullOrEmpty(textBoxAddChgPer.Text)) || (textBoxAddChgPer.Text.Trim().Equals(string.Empty)))
            //    {
            //        textBoxAddChgPer.Text = "0";
            //    }
            //    totAddChgs = Convert.ToDecimal((Convert.ToDecimal(lblGrossTot.Text) / 100) * Convert.ToDecimal(textBoxAddChgPer.Text));
            //    textBoxAddChgs.Text = totAddChgs.ToString("0.00");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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
            //try
            //{
            //    if ((string.IsNullOrEmpty(textBoxTotDiscPerc.Text)) || (textBoxTotDiscPerc.Text.Trim().Equals(string.Empty)))
            //    {
            //        textBoxTotDiscPerc.Text = "0";
            //    }
            //    grossTot = Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text);
            //    totDisc = ((grossTot / 100) * Convert.ToDecimal(textBoxTotDiscPerc.Text));
            //    txtTotDiscRate.Text = totDisc.ToString("0.00");
            //    calcNet();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void lblCashTender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //if (txtInvoiceNo.Text == textBoxInvoice.Text)
                //{
                //    DeleteHoldData();
                //    SaveSODTHoldComplete();
                //    //SaveSODTHold();
                //}
                //else
                //{
                cmdSave.Enabled = false;
                lblCashTender.Enabled = false;

                    if (lblCashTender.Text.Trim().Length == textBoxReceivable.Text.Trim().Length)
                    {
                        errorProvider1.Clear();
                        bool isValid = ValidateCash();
                        if (isValid)
                        {
                            cmdSave_Click(sender, e);
                        }
                    }
                    else if (lblCashTender.Text.Trim().Length < textBoxReceivable.Text.Trim().Length)
                    {
                        errorProvider1.Clear();
                        bool isValid = ValidateCash();
                        if (isValid)
                        {
                            cmdSave_Click(sender, e);
                        }
                    }
                    else if (lblCashTender.Text.Trim().Length > 8)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to enter this cash amount?", "Cash Amount Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            errorProvider1.Clear();
                            bool isValid = ValidateCash();
                            if (isValid)
                            {
                                cmdSave_Click(sender, e);
                            }
                        }
                        else
                        {
                            lblCashTender.Text = "0.00";
                            //if (autocomplete == true)
                            //{
                            //    txtItemName.Select();
                            //}
                            //else
                            //{
                            txtItemCode.Select();
                            //}
                        }

                    }
                //}
                    cmdSave.Enabled = true;
                    lblCashTender.Enabled = true;
            }
        }

        private void eSCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemF5_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text == "")
            {
                addStatus = true;
                ItemEdit();
            }
            
            txtQuantity.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sendSummarySMS();
            //DialogResult result = MessageBox.Show("Do you want to Close The Window?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    this.Close();
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

        private void checkBoxVAT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVAT.Checked == false)
            {
                textBoxVAT.Text = "0.00";
            }
            if (dgView.Rows.Count > 0)
            {
                calcNet();
            }
        }

        private void checkBoxNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNBT.Checked == false)
            {
                textBoxNBT.Text = "0.00";
            }
            if (dgView.Rows.Count > 0)
            {
                calcNet();
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
            Selectusercomport();
            fillOptions();
            AutoCompleteCustContact();
            if (autocomplete == true)
            {
                ItemAutoComplete();
                
            }
        }

        private void buttonCashDrawer_Click(object sender, EventArgs e)
        {
            openDrawer();
        }

        #endregion        

        private void frmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UpdateTaxSales();
            displayClear();
        }

        private void lblNetTotal_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblNetTotal.Text) > 0)
            {
                //display();
            }
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblChange.Text = "0.00";
            if (e.KeyChar.ToString() == "*")
            {
                txtQuantity.Text = Convert.ToDecimal(txtItemCode.Text).ToString("0.00");
                press = true;
            }
        }

        private void frmInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (press == true)
            {
                txtItemCode.Clear();
                press = false;

            }
        }

        private void buttonDayEnd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("If you want to print summary select Yes, To view select No.?", "Printing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSummary5in rpt = new CrystalReportSummary5in();
                    objBAL = new ClassPOBAL();
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSummaryData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportSummary5in rpt = new CrystalReportSummary5in();
                    objBAL = new ClassPOBAL();
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSummaryData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Cursor.Current = Cursors.WaitCursor;
            //CrystalReportSummary rpt = new CrystalReportSummary();
            //objBAL = new ClassPOBAL();
            //objDAL = new ClassPODAL();
            //objBAL.DtDataSet = objDAL.retreiveSummaryData(objBAL);
            //rpt.SetDataSource(objBAL.DtDataSet);
            //crystalReportViewer1.ReportSource = rpt;
            //crystalReportViewer1.Refresh();
            //rpt.PrintOptions.PrinterName = "";
            //rpt.PrintToPrinter(1, false, 0, 0);
            //ReportDocument cryRpt = new ReportDocument();

            //cryRpt = rpt;

            //crystalReportViewer1.ReportSource = cryRpt;

            //crystalReportViewer1.Refresh();

            //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Rpt\DayEndReport.pdf");

            //sendDayEndReportmail();
            //fillDayEndData();
            //sendSummarySMS();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to Invoice this Hold Bill?", "Hold Bill Invoicing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    TempId = Convert.ToInt32(dataGridView1["HoldNo", e.RowIndex].Value.ToString());
                    fillTempIdData();
                    DeleteTempSelected();
                }
            }
        }

        private void txtSellingPrice_Validating(object sender, CancelEventArgs e)
        {
            EditedPrice = 0;
            EditedPrice = Convert.ToDecimal(txtSellingPrice.Text);
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

        private void buttonNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CustomerName = comboBoxCustomer.Text.Trim();
                objBAL.CustomerAddress = "";
                objBAL.CustomerTelNo = "";
                objBAL.CustomerFaxNo = "";
                objBAL.CustomerEmail = "";
                objBAL.CustomerNICNo = "";
                objBAL.Remarks = "";
                objBAL.VATCustomer = false;
                objBAL.ContactPerson = "";
                objBAL.BalanceAmount = 0;
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertCustomer(objBAL);
                if (count != 0)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvDAL = new ClassInvoiveDAL();
                    if (objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1].Rows.Count > 0)
                    {
                        comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                        comboBoxCustomer.DisplayMember = "CustomerName";
                        comboBoxCustomer.ValueMember = "CustomerId";
                        comboBoxCustomer.SelectedIndex = -1;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    textBoxChequeNo.Select();
                }
                else if (comboBoxPayMode.Text == "Card")
                {
                    textBoxChequeNo.Select();
                }
                else if (comboBoxPayMode.Text == "Credit")
                {
                    textBoxCustCode.Select();
                }
                else if (comboBoxPayMode.Text == "Bank Transfer")
                {
                    comboBoxBank.Select();
                }
                else
                {
                    lblCashTender.Select();
                }
                
            }
        }

        private void comboBoxCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                lblCashTender.Select();
            }
        }

        private void textBoxChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    comboBoxBank.Select();
                }
                else if (comboBoxPayMode.Text == "Card")
                {
                    comboBoxBank.Select();
                }

            }
        }

        private void comboBoxBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    dateTimePickerChqExpDate.Select();
                }
                else if (comboBoxPayMode.Text == "Card")
                {
                    comboBoxCardType.Select();
                }
                else
                {
                    //if (autocomplete == true)
                    //{
                    //    txtItemName.Select();
                    //}
                    //else
                    //{
                    txtItemCode.Select();
                    //}
                }

            }
        }

        private void comboBoxCardType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                txtItemCode.Select();
                //}
            }
        }

        private void dateTimePickerChqExpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxCustCode.Select();
            }
        }

        private void textBoxCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxCustCode.Text != "")
                {
                    searchCustomer();
                    //if (autocomplete == true)
                    //{
                    //    txtItemName.Select();
                    //}
                    //else
                    //{
                    txtItemCode.Select();
                    //}
                }
                else
                {
                    FormSearchCustomer frm = new FormSearchCustomer();
                    frm.frm = this;
                    frm.ShowDialog(this);
                }
            }
        }

        private void comboBoxWarranty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtSellingPrice.Select();
            }
        }

        private void textBoxTotDiscPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                lblCashTender.Select();
            }
        }

        private void txtTotDiscRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                lblCashTender.Select();
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            openDrawer();
        }

        private void checkBoxReturn_CheckedChanged(object sender, EventArgs e)
        {
            //if (autocomplete == true)
            //{
            //    txtItemName.Select();
            //}
            //else
            //{
            txtItemCode.Select();
            //}
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxCustomer.SelectedIndex != -1)
            {
                fillDiscRate();
                textBoxCustName.Text = comboBoxCustomer.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedIndex != -1)
            {
                FormCustInvCreditPay frm = new FormCustInvCreditPay();
                frm.frm = this;
                frm.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.ShowDialog(this);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Get Sales Order?", "View Sales Orders Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetEntry();
                FormSORecord frm = new FormSORecord();
                frm.frm = this;
                frm.ShowDialog(this);
            }
        }

        private void textBoxOrderNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOrderNo.Text != "0" && textBoxOrderNo.Text != "")
            {
                SearchOrderHeader();
                SearchOrderDetail();
                SearchOrderReturnDetail();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBox1.Text != "No")
            {
                displayClear();
            }
        }

        private void textBoxReceivable_TextChanged(object sender, EventArgs e)
        {
            lblCashTender.Text = textBoxReceivable.Text;
            if (Convert.ToDecimal(textBoxReceivable.Text) > 0 && txtInvoiceNo.Text == textBoxInvoice.Text)
            {
                textBoxNetAmount.Text = textBoxReceivable.Text;
                textBoxCash.Text = textBoxReceivable.Text;

            }
            if (Convert.ToDecimal(lblNetTotal.Text) > 0)
            {
                //lblCashTender.Text = textBoxReceivable.Text;
                display();
            }
        }

        private void simpleButton1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construction !");
        }

        private void simpleButtonReturn_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = true;
            //if (autocomplete == true)
            //{
            //    txtItemName.Select();
            //}
            //else
            //{
            txtItemCode.Select();
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button7.Visible = false;
            //if (autocomplete == true)
            //{
            //    txtItemName.Select();
            //}
            //else
            //{
            txtItemCode.Select();
            //}
        }

        private void textBoxVoucherAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(textBoxVoucherAmount.Text)) || (textBoxVoucherAmount.Text.Trim().Equals(string.Empty)))
                {
                    textBoxVoucherAmount.Text = "0.00";
                }
                //grossTot = Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text);
                //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");

                //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                searchvoucher();
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgView.RowCount < 1)
                {
                    MessageBox.Show("Please enter item before you save this record.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtItemCode.Focus();
                    return;
                }
                else
                {
                    SaveQuotation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxUnitDisc_TextChanged(object sender, EventArgs e)
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

        private void textBoxUnitDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxLDiscAmt.Select();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtDisc.Select();
            }
        }

        private void textBoxFree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddtoGrid();
            }
        }

        

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

        private void comboBoxCustomer_TextChanged(object sender, EventArgs e)
        {
            textBoxCustName.Text = comboBoxCustomer.Text;
        }

        private void textBoxCustName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //if (autocomplete == true)
                //{
                //    txtItemName.Select();
                //}
                //else
                //{
                    textBoxCustMobile.Select();
                //}
            }
        }

        private void textBoxSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxSerial.Text != "")
                {
                    searchSerialData();
                    CodeKeydown();
                    textBoxCostPrice.Text = CP.ToString();
                    txtSellingPrice.Select();
                }
                else
                {
                    txtQuantity.Select();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (textBoxCustName.Text != "")
            {
                insertInvoiceCustomer();
            }
            
        }

        private void textBoxChargesPer_TextChanged(object sender, EventArgs e)
        {
            ChargesPer();
        }

        private void textBoxChargesAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(textBoxChargesAmount.Text)) || (textBoxChargesAmount.Text.Trim().Equals(string.Empty)))
                {
                    textBoxChargesAmount.Text = "0.00";
                }
                //grossTot = Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text);
                //lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text))).ToString("0.00");

                //lblCashTender.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxAddChgs.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                //if (textBoxCustMobile.Text != "")
                //{
                //    searchCustomerByContactNo();
                //}
                //else
                //{
                //    simpleButton3.Select();
                //}
            //}

        }

        private void textBoxReturnId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                searchReturn();
            }
        }

        private void textBoxReturnNoteAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(textBoxReturnNoteAmount.Text)) || (textBoxReturnNoteAmount.Text.Trim().Equals(string.Empty)))
                {
                    textBoxReturnNoteAmount.Text = "0.00";
                }
                lblNetTotal.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                textBoxReceivable.Text = (Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxChargesAmount.Text) - (Convert.ToDecimal(txtTotDiscRate.Text) + Convert.ToDecimal(textBoxReturn.Text) + Convert.ToDecimal(textBoxVoucherAmount.Text) + Convert.ToDecimal(textBoxReturnNoteAmount.Text))).ToString("0.00");

                calcNet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView11_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView11.GetFocusedRowCellValue("SerialNo") == null)
                return;
            textBoxSerial.Text = this.gridView11.GetFocusedRowCellValue("SerialNo").ToString();
            if (textBoxSerial.Text != "")
            {
                searchSerialData();
                CodeKeydown();
                textBoxCostPrice.Text = CP.ToString();
                txtSellingPrice.Select();
            }
        }

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedValue = lblBranchID.Text;
        }

        private void textBoxCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SaveHoldRecord();
                fillPendingGrid();
                txtItemName.Select();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SaveHoldRecord();
            fillPendingGrid();
            txtItemName.Select();
        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            FillBalance();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (textBoxInvoice.Text != "")
            {
                MessageBox.Show("Please Updated the selected Invoice.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxCash.Focus();
                textBoxCash.Select();
                return;
            }
            else
            {
                if (this.gridView1.GetFocusedRowCellValue("BillNo") == null)
                    return;
                fillInv();
                if (Convert.ToInt32(dgView.Rows.Count.ToString()) == 0)
                {
                    FillHoldHDData();
                    FillHoldDTData();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmInvoice frm = new frmInvoice();
            frm.lblUser.Text = lblUser.Text.Trim();
            frm.lblUserId.Text = lblUserId.Text.Trim();
            frm.lblBranchID.Text = lblBranchID.Text.Trim();
            frm.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            fillPendingGrid();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Get Sales Invoices?", "View Sales Invoices Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetEntry();
                FormInvoiceRecords frm = new FormInvoiceRecords();
                frm.frm = this;
                frm.ShowDialog(this);
            }
        }

        private void textBoxExInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgView.Rows.Count.ToString()) == 0)
            {
                if (textBoxExInvoiceNo.Text != "0" && textBoxExInvoiceNo.Text != "")
                {
                    FillExistHDData();
                    FillExistDTData();
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            FillAvailableGiftVouchers();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            CalculateVoucherTotal();
        }

        private void textBoxRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxRefNo.Text != "")
                {
                    DialogResult result = MessageBox.Show("Do you want to Get this reference Quotation Details?", "Get Quotation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SearchQuotationHeader();
                        SearchQuotationDetail();
                    }
                }
            }
        }

        private void toolStripMenuItemCtrlL_Click(object sender, EventArgs e)
        {
            txtReprint.Text = (Convert.ToInt32(txtInvoiceNo.Text) - 1).ToString();
            ReprintInvoice();
        }

        private void toolStripMenuItemCTRLD_Click(object sender, EventArgs e)
        {
            openDrawer();
        }

        

    }
}
