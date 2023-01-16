using CrystalDecisions.CrystalReports.Engine;
using easyBAL;
using easyDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormMain : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        ArrayList alistForm = new ArrayList();
        public bool TaxReport, correctpassword, AllowSMS, AllowEmail;
        int InvoiceNo = 0;

        string to, apitoken, fromval, apikey, companyname, SMSUrl, Email;

        string pdfFileDayEnd = "C:\\Rpt\\POSDayEndReport.pdf";


        #endregion

        #region Constructor

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

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
                        //CompanyInfoId = Convert.ToInt32(values[0].ToString());
                        label4.Text = (values[1].ToString());
                        //textBoxAdd1.Text = (values[2].ToString());
                        //textBoxAdd2.Text = (values[3].ToString());
                        //textBoxCon1.Text = (values[4].ToString());
                        //textBoxCon2.Text = (values[5].ToString());
                        //textBoxFMsg1.Text = (values[7].ToString());
                        //textBoxFMsg2.Text = (values[9].ToString());
                        //textBoxVAT.Text = (values[8].ToString());
                        //textBoxBRNo.Text = (values[10].ToString());
                        //textBoxWeb.Text = (values[11].ToString());
                        //textBoxEmail.Text = (values[12].ToString());
                        //byte[] data = (byte[])(values[6]);
                        //MemoryStream ms = new MemoryStream(data);
                        //pictureBox1.Image = Image.FromStream(ms);
                        //comboBoxArea.SelectedValue = (values[13].ToString());
                        //textBoxDiscRate.Text = (values[14].ToString());
                        //textBoxSMSUrl.Text = (values[15].ToString());
                        //textBoxAPIKey.Text = (values[16].ToString());
                        //textBoxAPIToken.Text = (values[17].ToString());
                        //textBoxSenderId.Text = (values[18].ToString());
                        //textBoxCommissionRate.Text = (values[19].ToString());
                        //checkBoxAllowSMS.Checked = false;
                        //if (Convert.ToBoolean(values[20]) == true)
                        //{
                        //    checkBoxAllowSMS.Checked = true;
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillstockreport()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.BranchId = Convert.ToInt32(lblBranchID.Text);
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveAvailableItemStockBranch(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                ReportDocument cryRpt = new ReportDocument();
                cryRpt = rpt;
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
                string FileName = @"C:\StockReport\StockReport - " + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".pdf";
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, FileName.ToString());
                //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Rpt\POSDayEndReport.pdf");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
                        //companydisc = Convert.ToDecimal(values[16].ToString().Trim());
                        SMSUrl = (values[17].ToString().Trim());
                        AllowSMS = Convert.ToBoolean(values[18]);
                        AllowEmail = Convert.ToBoolean(values[19]);
                        Email = (values[11].ToString().Trim());
                    }
                }
                //textBoxTotDiscPerc.Text = companydisc.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DayEndReport()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                //CrystalReportSummary5in rpt = new CrystalReportSummary5in();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerChqExpDate.Value;
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                //rpt.PrintOptions.PrinterName = "";
                //rpt.PrintToPrinter(1, false, 0, 0);

                ReportDocument cryRpt = new ReportDocument();

                cryRpt = rpt;

                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.Refresh();

                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Rpt\POSDayEndReport.pdf");

                sendDayEndReportmail();

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
                client.Credentials = new NetworkCredential("umindzsolution@gmail.com", "1984Indika");
                MailMessage msg = new MailMessage();
                msg.To.Add(Email.ToString());
                //msg.To.Add("easysolutionsrilanka@gmail.com");
                msg.From = new MailAddress("umindzsolution@gmail.com");
                msg.Subject = "Day End Report On " + DateTime.Today.ToString() + "";
                msg.Body = "This is the Day End Report from Synack POS System.";
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

        private void GenerateInvoice()
        {
            try
            {
                InvoiceNo = 0;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                InvoiceNo = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]);
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
                GenerateInvoice();
                int n = dataGridView3.Rows.Add();
                //int intQtyOrdered = int.Parse(txtQty.Text);

                dataGridView3.Rows[n].Cells["SOHDId1"].Value = InvoiceNo.ToString();

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

        private void UpdateDueDays()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.UpdateDueDays(objInvBAL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disableTiles()
        {
            InvoicetileItem.Visible = false;
            SalesRtntileItem.Visible = false;
            InvCantileItem.Visible = false;
            ExpensestileItem.Visible = false;
            CompanyInfotileItem.Visible = false;
            OptiontileItem.Visible = false;
            BackuptileItem.Visible = false;
            CustomertileItem.Visible = false;
            CustCreditPaytileItem.Visible = false;
            SupplierstileItem.Visible = false;
            ChequetileItem.Visible = false;
            StocktileItem.Visible = false;
            SpoilagetileItem.Visible = false;
            DiscounttileItem.Visible = false;
            UserRegtileItem.Visible = false;
            ResetPasstileItem.Visible = false;
            UserPermissiontileItem.Visible = false;
            EmployeestileItem.Visible = false;
            EmployeeAdvtileItem.Visible = false;
            EmployeeSalarytileItem.Visible = false;
            SalesReporttileItem.Visible = false;
            StockRpttileItem.Visible = false;
            BILLDETAILRPTtileItem.Visible = false;
            ChequeRpttileItem.Visible = false;
            ExpensesRpttileItem.Visible = false;
            CreditDetailRpttileItem.Visible = false;
            GrossProfitRpttileItem.Visible = false;
            PurchasingRpttileItem.Visible = false;
            SpoilageRpttileItem.Visible = false;
            FreeIssueRpttileItem.Visible = false;
            MasterEntrytileItem.Visible = false;
            tileItemCustomerImages.Visible = false;
            tileItemDashboard.Visible = false;
            tileItemPO.Visible = false;
            tileItemPI.Visible = false;
            tileItemBarcode.Visible = false;
            tileItemNetProfit.Visible = false;
            tileItemBranches.Visible = false;
            tileItemStockTransfer.Visible = false;
            tileItemSupplierCreditPayment.Visible = false;
            ChngePasstileItem.Visible = false;
            tileItemSearhInv.Visible = false;
            tileItemImport.Visible = false;
            tileItemSalesOrder.Visible = false;
            tileItemInvoiceSelection.Visible = false;
            tileItemInquiry.Visible = false;
            tileItemReprintCustCrPay.Visible = false;
            tileItemReprintStkTran.Visible = false;
            tileItemSyncDB.Visible = false;
            tileItemAdminFunction.Visible = false;
            tileItemReturnChq.Visible = false;
            tileItemLoan.Visible = false;
            tileItemProductConversion.Visible = false;
            tileItemGIN.Visible = false;
            tileItemFG.Visible = false;
            tileItemRPrintFG.Visible = false;
            tileItemGINReprint.Visible = false;
            tileItemFGGIN.Visible = false;
            tileItemCashIn.Visible = false;
            tileItemPriceUpdate.Visible = false;
            tileItemBankBalance.Visible = false;
            tileItemDetailReport.Visible = false;
            tileItemStockAdjustment.Visible = false;
            tileItemAssetDepreciation.Visible = false;
            tileItemFixedAsset.Visible = false;
            tileItemTrialBalance.Visible = false;
            tileItemBalanceSheet.Visible = false;
            tileItemGiftVoucher.Visible = false;
            tileItemSearchQuotation.Visible = false;
            tileItemTuchInvoice.Visible = false;
            tileItemUserInvoiceReport.Visible = false;
            tileItemReprintExpenses.Visible = false;
            tileItemCatSalesDashboard.Visible = false;
            tileItemReprintSupplierCreditPay.Visible = false;
            tileItemTechnicianEntry.Visible = false;
            tileItemVehicleReg.Visible = false;
            tileItemVehicleMilage.Visible = false;
            tileItemReprintVehicleMilageLog.Visible = false;
            tileItemReprintStockAdjustment.Visible = false;
            tileItemUpdateDayStock.Visible = false;
            tileItemUpdateEmployeeLeave.Visible = false;
            tileItemEmployeeAttendance.Visible = false;
            tileItemNewItemNotification.Visible = false;
            tileItemLatePaymentSMS.Visible = false;
            tileItemReprintPurchaseReturn.Visible = false;
        }

        private void userPermission()
        {
            try
            {
                disableTiles();
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
                        if (alistForm[i].ToString().Trim() == "Invoicing")
                        {
                            InvoicetileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Sales Return")
                        {
                            SalesRtntileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Invoice Cancellation")
                        {
                            InvCantileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Expenses")
                        {
                            ExpensestileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "CompanyInfo")
                        {
                            CompanyInfotileItem.Visible = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Print Options")
                        //{
                        //    OptiontileItem.Visible = true;
                        //}
                        if (alistForm[i].ToString().Trim() == "Backup")
                        {
                            BackuptileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Customers")
                        {
                            CustomertileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Customer Credit Payment")
                        {
                            CustCreditPaytileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Suppliers")
                        {
                            SupplierstileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Supplier Credit Payment")
                        {
                            tileItemSupplierCreditPayment.Visible = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Cheque Entering")
                        //{
                        //    ChequetileItem.Visible = true;
                        //}
                        if (alistForm[i].ToString().Trim() == "Stock Entering")
                        {
                            StocktileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Item Damage")
                        {
                            SpoilagetileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Change Password")
                        {
                            ChngePasstileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "User Registration")
                        {
                            UserRegtileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Reset Password")
                        {
                            ResetPasstileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "User Permission")
                        {
                            UserPermissiontileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Employee Registration")
                        {
                            EmployeestileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Salary Advance")
                        {
                            EmployeeAdvtileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Employee Salary")
                        {
                            EmployeeSalarytileItem.Visible = true;
                        }                       
                        if (alistForm[i].ToString().Trim() == "Sales Report")
                        {
                            SalesReporttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Employee Commission SalesReport")
                        {
                            SalesReporttileItem.Visible = true;
                            TaxReport = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Stock Report")
                        {
                            StockRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Bill Details Report")
                        {
                            BILLDETAILRPTtileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Cheque Details Report")
                        {
                            ChequeRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Expenses Report")
                        {
                            ExpensesRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Credit Detail")
                        {
                            CreditDetailRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Gross Profit")
                        {
                            GrossProfitRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Purchasing Report")
                        {
                            PurchasingRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Item Damage Report")
                        {
                            SpoilageRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Search Invoice")
                        {
                            tileItemSearhInv.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Purchase Invoice")
                        {
                            tileItemPI.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Purchase Order")
                        {
                            tileItemPO.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Print Barcode")
                        {
                            tileItemBarcode.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Net Profit Report")
                        {
                            tileItemNetProfit.Visible = true;
                            //tileItemDashboard.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Item FreeIssue Report")
                        {
                            FreeIssueRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Dashbord")
                        {
                            tileItemCatSalesDashboard.Visible = true;
                            tileItemDashboard.Visible = true;
                            //FreeIssueRpttileItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Import Stock")
                        {
                            tileItemImport.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Sales Order")
                        {
                            tileItemSalesOrder.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Branches")
                        {
                            tileItemBranches.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Stock Transfer")
                        {
                            tileItemStockTransfer.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Invoice Selection")
                        {
                            tileItemInvoiceSelection.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Inquiry Report")
                        {
                            tileItemInquiry.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Reprint Stock Transfer")
                        {
                            tileItemReprintStkTran.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Reprint Customer Credit Pay")
                        {
                            tileItemReprintCustCrPay.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "SyncDB")
                        {
                            tileItemSyncDB.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "AdminFunction")
                        {
                            tileItemAdminFunction.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Cheque Return")
                        {
                            tileItemReturnChq.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Loan")
                        {
                            tileItemLoan.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Product Conversion")
                        {
                            tileItemLoan.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "BOM")
                        {
                            tileItemGIN.Visible = true;
                            tileItemGINReprint.Visible = true;
                            tileItemFGGIN.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Production")
                        {
                            tileItemFG.Visible = true;
                            tileItemRPrintFG.Visible = true;
                            tileItemFGGIN.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "CashIn")
                        {
                            tileItemCashIn.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "PriceUpdate")
                        {
                            tileItemPriceUpdate.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "BankBalanceReport")
                        {
                            tileItemBankBalance.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "DetailReport")
                        {
                            tileItemDetailReport.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "StockAdjustmment")
                        {
                            tileItemStockAdjustment.Visible = true;
                            tileItemReprintStockAdjustment.Visible = false;
                        }
                        if (alistForm[i].ToString().Trim() == "FixedAsset")
                        {
                            tileItemAssetDepreciation.Visible = true;
                            tileItemFixedAsset.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "TrialBalance")
                        {
                            tileItemTrialBalance.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "BalanceSheet")
                        {
                            tileItemBalanceSheet.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Issue Gift Voucher")
                        {
                            tileItemGiftVoucher.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Search Quotation")
                        {
                            tileItemSearchQuotation.Visible = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Tuch Invoice")
                        //{
                        //    tileItemTuchInvoice.Visible = true;
                        //}
                        if (alistForm[i].ToString().Trim() == "UserReport")
                        {
                            tileItemUserInvoiceReport.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Expense Reprint")
                        {
                            tileItemReprintExpenses.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Reprint Supplier Credit Pay")
                        {
                            tileItemReprintSupplierCreditPay.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Technician Entry")
                        {
                            tileItemTechnicianEntry.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Vehicle Register")
                        {
                            tileItemVehicleReg.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Vehicle Milage Log")
                        {
                            tileItemVehicleMilage.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Print Vehicle Log")
                        {
                            tileItemReprintVehicleMilageLog.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Cancell Milage Log")
                        {
                            tileItemReprintVehicleMilageLog.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Update Opening Stock")
                        {
                            tileItemUpdateDayStock.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Update Employee Leave")
                        {
                            tileItemUpdateEmployeeLeave.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Update Employee Attendance")
                        {
                            tileItemEmployeeAttendance.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "New Item Notification SMS")
                        {
                            tileItemNewItemNotification.Visible = true;

                        }
                        if (alistForm[i].ToString().Trim() == "Late Payment SMS")
                        {
                            tileItemLatePaymentSMS.Visible = true;

                        }
                        if (alistForm[i].ToString().Trim() == "Reprint Purchase Return")
                        {
                            tileItemReprintPurchaseReturn.Visible = true;

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

        private void InvoicetileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmInvoice frm = new frmInvoice();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "frmInvoice");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("frmInvoice"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void SalesRtntileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSalesReturn frm = new FormSalesReturn();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSalesReturn");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSalesReturn"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void InvCantileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            InvoiceCancellation frm = new InvoiceCancellation();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "InvoiceCancellation");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("InvoiceCancellation"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void ExpensestileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormExpenses frm = new FormExpenses();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormExpenses");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormExpenses"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void CompanyInfotileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmCompanyInfo frm = new FrmCompanyInfo();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmCompanyInfo");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmCompanyInfo"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void OptiontileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmOptions frm = new FrmOptions();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmOptions");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmOptions"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void BackuptileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            //if (correctpassword == true)
            //{
                Process.Start(@"Release\\MySqlBackupTestApp.exe");
                //correctpassword = false;
            //}
            //else
            //{
            //    FormBackupPassword frm = new FormBackupPassword();
            //    frm.frm = this;
            //    frm.lblUser.Text = lblUser.Text.Trim();
            //    frm.lblUserId.Text = lblUserId.Text.Trim();
            //    frm.ShowDialog(this);
            //}
            
        }

        private void LogouttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            
            Cursor.Current = Cursors.WaitCursor;
            insertcsv();
            DialogResult result = MessageBox.Show("Do you want to Proceed Auto backup?", "Auto backup Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start(@"Release1\\MySqlBackupTestApp.exe");
            }
            if (AllowEmail == true)
            {
                DayEndReport();
            }
            
            Cursor.Current = Cursors.Default;
            Application.Exit();
        }

        private void CustomertileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormCustomer frm = new FormCustomer();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCustomer");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormCustomer"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void CustCreditPaytileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormCustomerCreditPayment frm = new FormCustomerCreditPayment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCustomerCreditPayment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormCustomerCreditPayment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void SupplierstileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSuppliers frm = new FormSuppliers();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSuppliers");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSuppliers"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void ChequetileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmCheques frm = new FrmCheques();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmCheques");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmCheques"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void StocktileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormStock frm = new FormStock();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormStock");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormStock"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void SpoilagetileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FRMItemSpoilage frm = new FRMItemSpoilage();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FRMItemSpoilage");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FRMItemSpoilage"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void DiscounttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormItemDiscount frm = new FormItemDiscount();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormItemDiscount");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormItemDiscount"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void UserRegtileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormUserRegistration frm = new FormUserRegistration();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormUserRegistration");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormUserRegistration"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void ChngePasstileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormChangePassword frm = new FormChangePassword();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormChangePassword");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormChangePassword"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void ResetPasstileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormResetPassword frm = new FormResetPassword();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormResetPassword");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormResetPassword"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void UserPermissiontileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormUserPermission frm = new FormUserPermission();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormUserPermission");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormUserPermission"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void EmployeestileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            EmployeeRegistration frm = new EmployeeRegistration();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "EmployeeRegistration");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("EmployeeRegistration"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void EmployeeAdvtileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            EmployeeAdvance frm = new EmployeeAdvance();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "EmployeeAdvance");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("EmployeeAdvance"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void EmployeeSalarytileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            EmployeePayment frm = new EmployeePayment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "EmployeePayment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("EmployeePayment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void SalesReporttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (TaxReport == true)
            {
                FormTaxSalesReport frm = new FormTaxSalesReport();
                bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSalesReport");

                if (formOpen)
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name.Equals("FormSalesReport"))
                        {
                            f.WindowState = FormWindowState.Normal;
                            f.BringToFront();
                            f.Activate();
                        }
                    }
                }
                else
                {
                    //frm.lblUser.Text = lblUser.Text.Trim();
                    //frm.lblUserId.Text = lblUserId.Text.Trim();
                    frm.Show();
                }
            }
            else
            {
                FormSalesReport frm = new FormSalesReport();
                bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSalesReport");

                if (formOpen)
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name.Equals("FormSalesReport"))
                        {
                            f.WindowState = FormWindowState.Normal;
                            f.BringToFront();
                            f.Activate();
                        }
                    }
                }
                else
                {
                    //frm.lblUser.Text = lblUser.Text.Trim();
                    //frm.lblUserId.Text = lblUserId.Text.Trim();
                    frm.Show();
                }
            }
            
        }

        private void StockRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            StockDetails frm = new StockDetails();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "StockDetails");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("StockDetails"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }

            //StockDetails frm = new StockDetails();
            //bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "StockDetails");

            //if (formOpen)
            //{
            //    foreach (Form f in Application.OpenForms)
            //    {
            //        if (f.Name.Equals("StockDetails"))
            //        {
            //            f.WindowState = FormWindowState.Normal;
            //            f.BringToFront();
            //            f.Activate();
            //        }
            //    }
            //}
            //else
            //{
            //    //frm.lblUser.Text = lblUser.Text.Trim();
            //    //frm.lblUserId.Text = lblUserId.Text.Trim();
            //    frm.Show();
            //}
        }

        private void BILLDETAILRPTtileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            BillDetails frm = new BillDetails();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "BillDetails");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("BillDetails"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void ChequeRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormChequeDetailsReport frm = new FormChequeDetailsReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormChequeDetailsReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormChequeDetailsReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void ExpensesRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormExpensesReport frm = new FormExpensesReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormExpensesReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormExpensesReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void CreditDetailRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormCreditReport frm = new FormCreditReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCreditReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormCreditReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void GrossProfitRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormGrossProfitReport frm = new FormGrossProfitReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormGrossProfitReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormGrossProfitReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void PurchasingRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormPurchaseRecord frm = new FormPurchaseRecord();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPurchaseRecord");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPurchaseRecord"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void SpoilageRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSpoilageReport frm = new FormSpoilageReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSpoilageReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSpoilageReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void FreeIssueRpttileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FreeIssueReport frm = new FreeIssueReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FreeIssueReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FreeIssueReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void MasterEntrytileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormMasterEntry frm = new FormMasterEntry();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormMasterEntry");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormMasterEntry"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
            fillCompanyInfo();
        }


        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = (60 * 180 * 1000); // 180 Min
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            lblTime.Text = DateTime.Now.ToString();
            DialogResult result = MessageBox.Show("Do you want to Proceed Auto backup?", "Auto backup Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start(@"Release1\\MySqlBackupTestApp.exe");
            }
            UpdateDueDays();
            SelectCompanyData();
            Cursor.Current = Cursors.Default;
        }

        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DialogResult result = MessageBox.Show("Do you want to Proceed Auto backup?", "Auto backup Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start(@"Release1\\MySqlBackupTestApp.exe");
            }
            Cursor.Current = Cursors.Default;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblTime.Text = DateTime.Now.ToString();
            DialogResult result = MessageBox.Show("Do you want to Proceed Auto backup?", "Auto backup Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start(@"Release1\\MySqlBackupTestApp.exe");
            }
            Cursor.Current = Cursors.Default;
            //refresh here...
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void tileItemCustomerImages_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            //FormCustImages frm = new FormCustImages();
            //bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCustImages");

            //if (formOpen)
            //{
            //    foreach (Form f in Application.OpenForms)
            //    {
            //        if (f.Name.Equals("FormCustImages"))
            //        {
            //            f.WindowState = FormWindowState.Normal;
            //            f.BringToFront();
            //            f.Activate();
            //        }
            //    }
            //}
            //else
            //{
            //    //frm.lblUser.Text = lblUser.Text.Trim();
            //    //frm.lblUserId.Text = lblUserId.Text.Trim();
            //    frm.Show();
            //}
        }

        private void tileItemDashboard_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            //NewDashbord frm = new NewDashbord();
            DashBordViewer frm = new DashBordViewer();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "DashBordViewer");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("DashBordViewer"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemPO_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormPO frm = new FormPO();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPO");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPO"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemPI_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormPurchaseInvoice frm = new FormPurchaseInvoice();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPurchaseInvoice");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPurchaseInvoice"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemSupplierCreditPayment_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSupplierCreditPayment frm = new FormSupplierCreditPayment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSupplierCreditPayment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSupplierCreditPayment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemNetProfit_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormProfitandLReport frm = new FormProfitandLReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormProfitandLReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormProfitandLReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemSearhInv_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSearchInvoice frm = new FormSearchInvoice();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSearchInvoice");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSearchInvoice"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemBarcode_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmBarcode frm = new FrmBarcode();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmBarcode");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmBarcode"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemBranches_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormBranch frm = new FormBranch();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormBranch");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormBranch"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemStockTransfer_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

            FormStockTransfer frm = new FormStockTransfer();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormStockTransfer");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormStockTransfer"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemImport_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormImportDatacs frm = new FormImportDatacs();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormImportDatacs");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormImportDatacs"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
            //    frm.lblUser.Text = lblUser.Text.Trim();
            //    frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemSalesOrder_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSalesOrder frm = new FormSalesOrder();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSalesOrder");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSalesOrder"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemInvoiceSelection_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmInvoiceSelection frm = new FrmInvoiceSelection();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmInvoiceSelection");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmInvoiceSelection"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemInquiry_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSummaryReport frm = new FormSummaryReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSummaryReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSummaryReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemReprintCustCrPay_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormReprintCustCreditPay frm = new FormReprintCustCreditPay();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormReprintCustCreditPay");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormReprintCustCreditPay"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemReprintStkTran_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormReprintStockTransfer frm = new FormReprintStockTransfer();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormReprintStockTransfer");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormReprintStockTransfer"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemSyncDB_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DialogResult result = MessageBox.Show("Do you want to Proceed Auto backup?", "Auto backup Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Process.Start(@"Release1\\MySqlBackupTestApp.exe");
            }
            Cursor.Current = Cursors.Default;
        }

        private void tileItemAdminFunction_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormAdminFunction frm = new FormAdminFunction();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormAdminFunction");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormAdminFunction"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemReturnChq_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormReturnCheque frm = new FormReturnCheque();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormReturnCheque");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormReturnCheque"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemLoan_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormLoan frm = new FormLoan();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormLoan");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormLoan"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemProductConversion_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormProductConversion frm = new FormProductConversion();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormProductConversion");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormProductConversion"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemGIN_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormGIN frm = new FormGIN();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormGIN");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormGIN"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemFG_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormProduction frm = new FormProduction();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormProduction");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormProduction"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemRPrintFG_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormPrintFG frm = new FormPrintFG();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPrintFG");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPrintFG"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemGINReprint_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormGINReprint frm = new FormGINReprint();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormGINReprint");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormGINReprint"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemFGGIN_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormFGGINReport frm = new FormFGGINReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormFGGINReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormFGGINReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemCashIn_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormPaidIn frm = new FormPaidIn();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPaidIn");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPaidIn"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemPriceUpdate_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormPriceUpdate frm = new FormPriceUpdate();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPriceUpdate");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPriceUpdate"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemBankBalance_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormBankTransactions frm = new FormBankTransactions();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormBankTransactions");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormBankTransactions"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemDetailReport_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormBranchwiseReports frm = new FormBranchwiseReports();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormBranchwiseReports");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormBranchwiseReports"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemStockAdjustment_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormStockAdjustment frm = new FormStockAdjustment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormStockAdjustment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormStockAdjustment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.lblBranchID.Text = lblBranchID.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemNewItemNotification_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmPurchasing frm = new FrmPurchasing();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmPurchasing");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmPurchasing"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemLatePaymentSMS_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmSendSMS frm = new FrmSendSMS();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmSendSMS");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmSendSMS"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemFixedAsset_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormFixedAsset frm = new FormFixedAsset();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormFixedAsset");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormFixedAsset"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemAssetDepreciation_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormFixedAssetDepreciation frm = new FormFixedAssetDepreciation();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormFixedAssetDepreciation");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormFixedAssetDepreciation"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemTrialBalance_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormTrialBalance frm = new FormTrialBalance();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormTrialBalance");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormTrialBalance"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemBalanceSheet_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormBalanceSheet frm = new FormBalanceSheet();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormBalanceSheet");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormBalanceSheet"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemGiftVoucher_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmIssueGiftVoucher frm = new FrmIssueGiftVoucher();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmIssueGiftVoucher");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmIssueGiftVoucher"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemSearchQuotation_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormViewQuotation frm = new FormViewQuotation();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormViewQuotation");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormViewQuotation"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemTuchInvoice_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormInvoiceTuch frm = new FormInvoiceTuch();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormInvoiceTuch");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormInvoiceTuch"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemUserInvoiceReport_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormUserInvoiceReport frm = new FormUserInvoiceReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormUserInvoiceReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormUserInvoiceReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            insertcsv();
            fillstockreport();

        }

        private void tileItemReprintExpenses_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormReprintExpenses frm = new FormReprintExpenses();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormReprintExpenses");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormReprintExpenses"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemCatSalesDashboard_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormCategoryDashboardViewer frm = new FormCategoryDashboardViewer();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCategoryDashboardViewer");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormCategoryDashboardViewer"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemReprintSupplierCreditPay_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormReprintSupplierCreditPay frm = new FormReprintSupplierCreditPay();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormReprintSupplierCreditPay");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormReprintSupplierCreditPay"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemTechnicianEntry_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormTechniciansEntry frm = new FormTechniciansEntry();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormTechniciansEntry");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormTechniciansEntry"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemVehicleReg_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormVehicle frm = new FormVehicle();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormVehicle");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormVehicle"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemVehicleMilage_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormVehicleMilageLog frm = new FormVehicleMilageLog();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormVehicleMilageLog");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormVehicleMilageLog"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemReprintVehicleMilageLog_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormSearchVehicleMilage frm = new FormSearchVehicleMilage();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSearchVehicleMilage");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSearchVehicleMilage"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemEmployeeAttendance_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormAttendance frm = new FormAttendance();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormAttendance");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormAttendance"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemReprintStockAdjustment_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormReprintStockAdjustment frm = new FormReprintStockAdjustment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormReprintStockAdjustment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormReprintStockAdjustment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemUpdateDayStock_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want Update Opening Stock", "Opening Stock Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                insertOpeningStock();
            }
        }

        private void insertOpeningStock()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertOpeningStock(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Opening Stock Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tileItemUpdateEmployeeLeave_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormEmployeeLeave frm = new FormEmployeeLeave();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormEmployeeLeave");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormEmployeeLeave"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void tileItemReprintPurchaseReturn_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FormReprintPurchaseReturn frm = new FormReprintPurchaseReturn();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormReprintPurchaseReturn");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormReprintPurchaseReturn"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        #region Validation Methods



        #endregion

    }
}
