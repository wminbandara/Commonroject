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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormCustomerCreditPayment : Form
    {
        #region Local Variables
        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();


        string FYear, ID, SMSmessage, payment;

        bool loadStatus, smssendconfirmation, AllowSMS;

        string to, apitoken, fromval, apikey, companyname, contact, SMSUrl;

        #endregion

        #region Constructor

        public FormCustomerCreditPayment()
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
                        //companydisc = Convert.ToDecimal(values[16].ToString().Trim());
                        SMSUrl = (values[17].ToString().Trim());
                        AllowSMS = Convert.ToBoolean(values[18]);

                    }
                }
                //textBoxTotDiscPerc.Text = companydisc.ToString();

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
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.CustomerCode = textBoxCustCode.Text;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
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

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchCustomerByInvoice()
        {
            try
            {
                comboBoxCustomer.SelectedIndex = -1;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(textBoxInvoice.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveCustomerInvoiceData(objInvBAL);
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
                        //textBoxCustMobile.Text = (values[4].ToString().Trim());

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
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.CustomerTelNo = textBoxCustMobile.Text;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void SelectCompanyData()
        //{
        //    try
        //    {
        //            objBAL = new ClassCommonBAL();
        //            objDAL = new ClassMasterDAL();
        //            objBAL.DtDataSet = objDAL.retreivecompanydata(objBAL);
        //            if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
        //            {
        //                List<ArrayList> newval = new List<ArrayList>();
        //                foreach (DataRow dRow in objBAL.DtDataSet.Tables[0].Rows)
        //                {
        //                    ArrayList values = new ArrayList();
        //                    values.Clear();
        //                    foreach (object value in dRow.ItemArray)
        //                        values.Add(value);
        //                    newval.Add(values);
        //                    companyname = (values[0].ToString().Trim());
        //                }
        //            }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void insertCheque()
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                try
                {
                    ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    //objInvBAL.SOHDId = InvoiceNo;
                    objInvBAL.SOHDId = 0;
                    objInvBAL.ChequeBank = comboBoxBank.Text.Trim();
                    objInvBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                    objInvBAL.ChequeNo = textBoxChequeNo.Text;
                    objInvBAL.ChequeAmount = Convert.ToDecimal(textBoxPayment.Text);
                    objInvBAL.ChequeExpDate = Convert.ToDateTime(dateTimePickerChqExpDate.Text);
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objInvBAL.CreditPayHDId = Convert.ToInt32(textBoxHDId.Text);
                    ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerChequeCreditPay(objInvBAL);

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
                    ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                    if (comboBoxCustomer.SelectedIndex == -1)
                    {
                        comboBoxCustomer.SelectedValue = 0;
                    }
                    objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
                    //objInvBAL.SOHDId = InvoiceNo;
                    objInvBAL.SOHDId = Convert.ToInt32(textBoxInvoiceNo.Text);
                    objInvBAL.ChequeBank = comboBoxBank.Text.Trim();
                    objInvBAL.ChequeNo = textBoxChequeNo.Text;
                    objInvBAL.ChequeAmount = Convert.ToDecimal(textBoxPayment.Text);
                    objInvBAL.CardType = comboBoxCardType.Text;
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertCustomerCard(objInvBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Reset()
        {
            textBoxCustomerName.Clear();
            textBoxAddress.Clear();
            textBoxTel.Clear();
            textBoxFax.Clear();
            textBoxEmail.Clear();
            textBoxNIC.Clear();
            textBoxRemarks.Clear();
            textBoxCustomerID.Clear();
            textBoxCreditAmount.Text = "0.00";
            textBoxTotalPayment.Text = "0.00";
            textBoxBalance.Text = "0.00";
            textBoxInvoiceNo.Clear();
            textBoxHDId.Text = "0";
            textBoxReciptNo.Clear();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }

        private void SelectCustomerData()
        {
            try
            {
                if (loadStatus == false && comboBoxCustomer.SelectedIndex != -1)
                {
                    objBAL = new ClassCommonBAL();
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objDAL = new ClassMasterDAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerDataByID(objBAL);
                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;
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
                            textBoxCustomerID.Text = (values[0].ToString().Trim());
                            textBoxCustomerName.Text = (values[1].ToString().Trim());
                            textBoxAddress.Text = (values[2].ToString().Trim());
                            textBoxTel.Text = (values[3].ToString().Trim());
                            textBoxFax.Text = (values[4].ToString().Trim());
                            textBoxEmail.Text = (values[5].ToString().Trim());
                            textBoxNIC.Text = (values[6].ToString().Trim());
                            textBoxRemarks.Text = (values[7].ToString().Trim());
                        }
                    }
                    if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                        dataGridView1.Columns["CreditAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (objBAL.DtDataSet.Tables[2].Rows.Count > 0)
                    {
                        dataGridView2.DataSource = objBAL.DtDataSet.Tables[2];
                        dataGridView2.Columns["PaymentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    FillSelectCustomerCreditData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillSelectCustomerCreditData()
        {
            try
            {
                if (loadStatus == false && comboBoxCustomer.SelectedIndex != -1)
                {
                    objBAL = new ClassCommonBAL();
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objDAL = new ClassMasterDAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerDataByID(objBAL);
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    textBoxPayTotal.Text = "0.00";
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
                            int n = dataGridView3.Rows.Add();

                            dataGridView3.Rows[n].Cells["BillNo"].Value = (values[0].ToString().Trim());
                            dataGridView3.Rows[n].Cells["CreditDate"].Value = Convert.ToDateTime(values[1].ToString().Trim()).ToString("yyyy/MM/dd");
                            dataGridView3.Rows[n].Cells["CreditAmount"].Value = (values[2].ToString().Trim());
                            dataGridView3.Rows[n].Cells["InvoiceCreditAmount"].Value = (values[3].ToString().Trim());
                            dataGridView3.Rows[n].Cells["PaymentAmount"].Value = "0";

                            dataGridView3.FirstDisplayedScrollingRowIndex = n;
                            dataGridView3.CurrentCell = dataGridView3.Rows[n].Cells[0];
                            dataGridView3.Rows[n].Selected = true;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcTotal()
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    decimal Total = 0;
                    int i = dataGridView3.RowCount;

                    for (int a = 0; a < i; a++)
                    {
                        Total += Convert.ToDecimal(dataGridView3.Rows[a].Cells["PaymentAmount"].Value.ToString());
                    }
                    textBoxPayTotal.Text = Total.ToString("0.00");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void fillItemTotalBalanceValue()
        {
            try
            {
                textBoxCreditAmount.Text = "0.00";

                if (dataGridView1.Rows.Count > 0)
                {
                    decimal total = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        total = Convert.ToDecimal(dataGridView1["CreditAmount", i].Value.ToString()) + total;
                    }
                    textBoxCreditAmount.Text = total.ToString();
                    textBoxBalance.Text = (Convert.ToDecimal(textBoxCreditAmount.Text) - Convert.ToDecimal(textBoxTotalPayment.Text)).ToString("0.00");
                }
                if (dataGridView2.Rows.Count > 0)
                {
                    decimal total = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        total = Convert.ToDecimal(dataGridView2["PaymentAmount", i].Value.ToString()) + total;
                    }
                    textBoxTotalPayment.Text = total.ToString();
                    textBoxBalance.Text = (Convert.ToDecimal(textBoxCreditAmount.Text) - Convert.ToDecimal(textBoxTotalPayment.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertCustomerCreditHD()
        {
            try
            {
                payment = "";
                SMSmessage = "";
                payment = textBoxPayment.Text;
                SMSmessage = (Convert.ToDecimal(textBoxCreditAmount.Text) - Convert.ToDecimal(textBoxPayment.Text)).ToString();

                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayment.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objBAL.ReciptNo = textBoxReciptNo.Text;
                if (comboBoxBank.SelectedIndex == -1)
                {
                    comboBoxBank.SelectedValue = 0;
                }
                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
               
                objDAL = new ClassMasterDAL();

                string count = objDAL.InsertCustomerCredPayHD(objBAL);
                textBoxHDId.Text = count.ToString();
                if (count != "")
                {
                    insertCustomerCredit();

                    if (AllowSMS == true && textBoxTel.Text != "")
                    {
                        DialogResult result = MessageBox.Show("Do you want to send thanking message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            sendThankingSMS();
                        }
                    }
                }
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

                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    string message2;
                    to = Convert.ToInt64(textBoxTel.Text.Trim()).ToString();
                    message2 = "Dear " + textBoxCustomerName.Text + ", Thank you for your payment of Rs. " + payment.ToString() + " " + " on " + dateTimePickerPaymentDate.Text.Trim() + " " + "Your Balance Amount is Rs. : " + SMSmessage.ToString() + ". " + companyname.ToString() + ".";
                    //message2 = "Dear " + textBoxCustomerName.Text + ", You are welcome to " + companyname.ToString() + ". Now you are our registered member. -- " + companyname.ToString() + "." + contact.ToString() + ".";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

                    //string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
                    string url = SMSUrl + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
                    //Call web api to send sms messages
                    string result = client.DownloadString(url);
                    if (result.Contains("0"))
                        MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void sendThankingSMS()
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        //SMSmessage = (Convert.ToDecimal(textBoxCreditAmount.Text) - Convert.ToDecimal(textBoxPayment.Text)).ToString();
        //        WebClient client = new WebClient();

        //        client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");

        //        client.QueryString.Add("id", "94715278260");
        //        client.QueryString.Add("pw", "1412");
        //        client.QueryString.Add("to", textBoxTel.Text.Trim());
        //        client.QueryString.Add("text", "Dear Customer, Thank you for your payment of Rs. " + payment.ToString() + " " + " on " + dateTimePickerPaymentDate.Text.Trim() + " " + "Your Balance Amount is Rs. : " + SMSmessage.ToString() + ". " + companyname.ToString() + ".");
        //        string baseurl = "http://www.textit.biz/sendmsg";
        //        Stream data = client.OpenRead(baseurl);
        //        StreamReader reader = new StreamReader(data);
        //        string s = reader.ReadToEnd();
        //        data.Close();
        //        reader.Close();
        //        Cursor.Current = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        bool savestate;
        private void insertCustomerCredit()
        {
            try
            {
                savestate = false;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value) > 0)
                    {
                        objBAL = new ClassCommonBAL();
                        objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                        objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                        objBAL.PaymentAmount = Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value);
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.PIHDId = Convert.ToInt32(dataGridView3.Rows[i].Cells["BillNo"].Value);
                        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                        objBAL.CreditPayHDId = Convert.ToInt32(textBoxHDId.Text);
                        objBAL.ChequeNo = textBoxChequeNo.Text;
                        objBAL.ReciptNo = textBoxReciptNo.Text;
                        if (comboBoxBank.SelectedIndex == -1)
                        {
                            comboBoxBank.SelectedValue = 0;
                        }
                        objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
                        objDAL = new ClassMasterDAL();
                        int count = objDAL.InsertCustomerCredPay(objBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }
                    
                }
                if (savestate == true)
                {
                    if (comboBoxPayMode.Text == "Cheque")
                    {
                        insertCheque();
                    }
                    if (comboBoxPayMode.Text == "Card")
                    {
                        insertCard();
                    }
                    MessageBox.Show("Customer Credit Payment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result = MessageBox.Show("Do you want to print this Payment Recipt ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        printInvoice();
                    }
                }

                //objBAL = new ClassCommonBAL();
                //objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                //objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                //objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayment.Text);
                //objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                //objBAL.PIHDId = Convert.ToInt32(textBoxInvoiceNo.Text);
                //objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                //objBAL.ChequeNo = textBoxChequeNo.Text;
                //objDAL = new ClassMasterDAL();
                //int count = objDAL.InsertCustomerCredPay(objBAL);
                ////if (count != 0)
                ////{
                //    MessageBox.Show("Customer Credit Payment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //DialogResult result = MessageBox.Show("Do you want to print this Payment Recipt ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    //if (result == DialogResult.Yes)
                //    //{
                //    //    printInvoice();
                //    //}
                ////}

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

                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportCustomerCreditPay rpt = new CrystalReportCustomerCreditPay();
                //CrystalReportCustCreditPay2in rpt = new CrystalReportCustCreditPay2in();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                objPOBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objPOBAL.CreditPayHDId = Convert.ToInt32(textBoxHDId.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveCustomerPaymentData(objPOBAL);
                rpt.SetDataSource(objPOBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                //REPORT.crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;
            
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
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
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

        #endregion

      
        #region Events

        private void FormCustomerCreditPayment_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxCustomer.DataSource = objDAL.retreiveAllCustomers(objBAL).Tables[0];
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerId";
                comboBoxCustomer.SelectedIndex = -1;

                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                if (objPODAL.retreivePOLoadingData(objPOBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[1];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 0;
                }
                loadBank();
                SelectCompanyData();
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateCustomer() && ValidatePaymentAmount() && ValidateGridSetoff();
            if (isValid)
            {
                if (Convert.ToDecimal(textBoxOutofBalance.Text) == 0)
                {
                    if ((comboBoxPayMode.Text == "Cheque") && (comboBoxBank.SelectedIndex == -1))
                    {
                        MessageBox.Show("Please Select the Bank.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        comboBoxBank.Focus();
                        comboBoxBank.Select();
                        return;
                    }
                    else
                    {
                        insertCustomerCreditHD();

                        SelectCustomerData();
                        fillItemTotalBalanceValue();
                        textBoxPayment.Text = "0.00";
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please setoff full amount.", "Invalid Setoff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
            SelectCustomerData();
            fillItemTotalBalanceValue();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Validation Methods

        //private void ValidateGridSetoff()
        //{
        //    try
        //    {
        //        if (dataGridView3.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dataGridView3.Rows.Count; i++)
        //            {
        //                if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value) > Convert.ToDecimal(dataGridView3.Rows[i].Cells["CreditAmount"].Value))
        //                {
        //                    MessageBox.Show("Invalid Payment Amount Contain", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        private bool ValidateGridSetoff()
        {
            //comboBoxCustomer.Text = comboBoxCustomer.Text.Trim();
            string errorCode = string.Empty;
            if (dataGridView3.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value) > Convert.ToDecimal(dataGridView3.Rows[i].Cells["CreditAmount"].Value))
                    {
                        errorCode = ("Invalid Payment Amount Contain");
                    }
                }
            }
            //if ((string.IsNullOrEmpty(comboBoxCustomer.Text)) || (comboBoxCustomer.Text.Trim().Equals(string.Empty)))
            //{
            //    errorCode = "Please Select Customer.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxPayment, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCustomer()
        {
            comboBoxCustomer.Text = comboBoxCustomer.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxCustomer.Text)) || (comboBoxCustomer.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Customer.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxCustomer, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePaymentAmount()
        {
            textBoxPayment.Text = textBoxPayment.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxPayment.Text)) || (textBoxPayment.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Cash amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxPayment.Text))
            {
                errorCode = "Invalid Cash Amount.";
            }
            else if (Convert.ToDecimal(textBoxPayment.Text) < 0)
            {
                errorCode = "Invalid Cash Amount.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxPayment, message);
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

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                label10.Visible = true;
                label10.Text = "Cheque No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Cheq. Date";
                dateTimePickerChqExpDate.Visible = true;
                comboBoxCardType.Visible = false;
                label11.Visible = true;
                label11.Text = "Cheque Amount";
                textBoxChqCardAmount.Visible = true;
            }
            else if (comboBoxPayMode.Text == "Bank Transfer")
            {
                //label10.Visible = true;
                //label10.Text = "Cheque No";
                //textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                //label27.Visible = true;
                //label27.Text = "Exp. Date";
                //dateTimePickerChqExpDate.Visible = true;
                //comboBoxCardType.Visible = false;
                //label11.Visible = true;
                //label11.Text = "Cheque Amount";
                //textBoxChqCardAmount.Visible = true;
            }
            else if (comboBoxPayMode.Text == "Card")
            {
                label10.Visible = true;
                label10.Text = "Card No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Card Type";
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = true;
                label11.Visible = true;
                label11.Text = "Card Amount";
                textBoxChqCardAmount.Visible = true;
            }
            else
            {
                label10.Visible = false;
                textBoxChequeNo.Visible = false;
                label25.Visible = false;
                comboBoxBank.Visible = false;
                label27.Visible = false;
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = false;
                label11.Visible = false;
                textBoxChqCardAmount.Visible = false;
            }
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
                textBoxPayTotal.Text = CellSum().ToString();
                //textBoxPayment.Text = CellSum().ToString();
        }

        private double CellSum()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; ++i)
            {
                double d = 0;
                Double.TryParse(dataGridView3.Rows[i].Cells[4].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private void textBoxPayTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //textBoxPayment.Text = textBoxPayTotal.Text;
                textBoxOutofBalance.Text = (Convert.ToDecimal(textBoxPayment.Text) - Convert.ToDecimal(textBoxPayTotal.Text)).ToString();

            }
            catch
            {
            }
                  
        }

        private void FormCustomerCreditPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                //textBoxCustCode.Select();
                FormSearchCustomer frm2 = new FormSearchCustomer();
                frm2.frm2 = this;
                frm2.form = 2;
                frm2.ShowDialog(this);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBoxOutofBalance.Text) >= Convert.ToDecimal(dataGridView3.CurrentRow.Cells[3].Value))
                {
                    if (Convert.ToDecimal(dataGridView3.CurrentRow.Cells[4].Value) == 0)
                    {
                        dataGridView3.CurrentRow.Cells[4].Value = dataGridView3.CurrentRow.Cells[3].Value.ToString();

                    }

                }
                else if (Convert.ToDecimal(textBoxOutofBalance.Text) < Convert.ToDecimal(dataGridView3.CurrentRow.Cells[3].Value))
                {
                    if (Convert.ToDecimal(dataGridView3.CurrentRow.Cells[4].Value) == 0)
                    {
                        dataGridView3.CurrentRow.Cells[4].Value = textBoxOutofBalance.Text;
                    }
                }
            }
            catch
            {
            }
            //MessageBox.Show( dataGridView3.CurrentRow.Cells[3].Value.ToString());
           
        }

        private void textBoxPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxOutofBalance.Text = (Convert.ToDecimal(textBoxPayment.Text) - Convert.ToDecimal(textBoxPayTotal.Text)).ToString();

            }
            catch
            {
            }
        }

        private void textBoxInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxInvoice.Text != "")
                {
                    searchCustomerByInvoice();
                }

            }
        }

        private void textBoxCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxCustCode.Text != "")
                {
                    searchCustomer();
                }
            }
        }

        private void textBoxCustMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxCustMobile.Text != "")
                {
                    searchCustomerByContactNo();
                }

            }
        }
    }
}
