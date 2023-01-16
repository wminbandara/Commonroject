using easyBAL;
using easyDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace easyPOSSolution
{
    public partial class FrmSendSMS : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        string to, message, apitoken, fromval, apikey, companyname, SMSUrl;

        #endregion

        #region Constructor

        public FrmSendSMS()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void SelectCustomerData()
        {
            try
            {
                    objBAL = new ClassCommonBAL();
                    objDAL = new ClassMasterDAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerBillRecord(objBAL);
                    dataGridView1.DataSource = null;
                    if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                        dataGridView1.Columns["CreditAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Columns["TotalPayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Columns["BalanceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //dataGridView1.Columns["BillNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dataGridView1.Columns["PaymentDueFrom"].Visible = false;
                    
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendSMS()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1["MessageSendStatus", i].Value) == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        objInvBAL.CustomerId = Convert.ToInt32(dataGridView1["CustomerId", i].Value.ToString());
                        WebClient client = new WebClient();

                        client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");

                        client.QueryString.Add("id", "94715278260");
                        client.QueryString.Add("pw", "1412");
                        client.QueryString.Add("to", dataGridView1["ContactNo", i].Value.ToString());
                        client.QueryString.Add("text", "Dear valued customer, please settle the overdue amount of Rs." + dataGridView1["BalanceAmount", i].Value.ToString() + ". It is overdue for " + dataGridView1["NoOfDueDays", i].Value.ToString() + " days. Ignore if already settled.Thank you. Scan Tech Office Automation.");
                        string baseurl = "http://www.textit.biz/sendmsg";
                        Stream data = client.OpenRead(baseurl);
                        StreamReader reader = new StreamReader(data);
                        string s = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.UpdateNextDueDays(objInvBAL);
                        Cursor.Current = Cursors.Default;
                    }
                    
                }
                //objInvBAL.BillNo = Convert.ToInt32(dataGridView1["BillNo", i].Value.ToString());
                //ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                //int count = objInvDAL.UpdateNextDueDays(objInvBAL);

                MessageBox.Show("Messages Sent Successfully.", "Messages Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SelectCustomerData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void updateNextDuedate()
        //{
        //    try
        //    {
        //         for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (Convert.ToBoolean(dataGridView1["MessageSendStatus", i].Value) == true)
        //            {
        //                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
        //                objInvBAL.BillNo = Convert.ToInt32(dataGridView1["BillNo", i].Value.ToString());
        //                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
        //                int count = objInvDAL.UpdateNextDueDays(objInvBAL);
        //            }
        //         }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
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
                        SMSUrl = (values[17].ToString().Trim());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendSMSApi()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1["MessageSendStatus", i].Value) == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {
                            try
                            {
                                string message2;
                                to = Convert.ToInt64(dataGridView1["ContactNo", i].Value.ToString()).ToString();
                                message2 = "Dear valued customer, please settle the overdue amount of Rs." + dataGridView1["BalanceAmount", i].Value.ToString() + ". It is overdue for " + dataGridView1["NoOfDueDays", i].Value.ToString() + " days. Ignore if already settled.Thank you. " + ". " + companyname.ToString() + ". " + DateTime.Now.ToString();


                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                    SecurityProtocolType.Tls11 |
                                                    SecurityProtocolType.Tls12;

                                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                                string url = SMSUrl + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;

                                //Call web api to send sms messages
                                string result = client.DownloadString(url);

                                //string url = "https://cloud.websms.lk/smsAPI?sendsms&apikey=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
                                ////Call web api to send sms messages
                                //string result = client.DownloadString(url);
                                //if (result.Contains("0"))
                                //    MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //else
                                //    MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //WebClient client = new WebClient();
                        //to = dataGridView1["ContactNo", i].Value.ToString();
                        //message = "Dear valued customer, please settle the overdue amount of Rs." + dataGridView1["BalanceAmount", i].Value.ToString() + ". It is overdue for " + dataGridView1["NoOfDueDays", i].Value.ToString() + " days. Ignore if already settled.Thank you. " + ". " + companyname.ToString() + ". " + DateTime.Now.ToString();

                        //string baseURL = "http://app.newsletters.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message;

                        //client.OpenRead(baseURL);

                        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.UpdateNextDueDays(objInvBAL);
                        Cursor.Current = Cursors.Default;

                    }

                }

                MessageBox.Show("Messages Sent Successfully.", "Messages Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SelectCustomerData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Events

        private void FrmSendSMS_Load(object sender, EventArgs e)
        {
            SelectCustomerData();
            SelectCompanyData();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //sendSMS();
            sendSMSApi();
        }

       

        #region Validation Methods



        #endregion
    }
}
