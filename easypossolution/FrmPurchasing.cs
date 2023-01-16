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
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace easyPOSSolution
{
    public partial class FrmPurchasing : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        string to, message, apitoken, fromval, apikey, companyname, SMSUrl;
        bool AllowSMS;

        #endregion

        #region Constructor

        public FrmPurchasing()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void SelectData()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveNewStock(objBAL);
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["ItemsId"].Visible = false;
                    dataGridView1.Columns["ItemCode"].Visible = false;
                }
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[1];
                    dataGridView2.Columns["CustomerId"].Visible = false;
                    //dataGridView2.Columns["CustomerTelNo"].Visible = false;
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
                Cursor.Current = Cursors.WaitCursor;
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridView2["SelectCust", j].Value) == true)
                    {
                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {
                            try
                            {
                                string message2;
                                to = Convert.ToInt64(dataGridView2["CustomerTelNo", j].Value.ToString()).ToString();
                                message2 = textBoxMessage.Text.Trim() + " Date : " + DateTime.Now.ToString() + ". " + companyname.ToString() + ". Thank you.";

                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                                    SecurityProtocolType.Tls11 |
                                                    SecurityProtocolType.Tls12;

                                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };


                                string url = SMSUrl + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;
                                //string url = "https://richcommunication.dialog.lk/api/sms/inline/send?q=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
                                //Call web api to send sms messages
                                string result = client.DownloadString(url);

                                //string url = "https://cloud.websms.lk/smsAPI?sendsms&apikey=" + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
                                ////Call web api to send sms messages
                                //string result = client.DownloadString(url);
                                ////if (result.Contains("0"))
                                ////    MessageBox.Show("Your message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ////else
                                ////    MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        //WebClient client = new WebClient();

                        //client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");

                        //client.QueryString.Add("id", "94715278260");
                        //client.QueryString.Add("pw", "1412");
                        //client.QueryString.Add("to", dataGridView2["CustomerTelNo", j].Value.ToString());

                        //client.QueryString.Add("text", textBoxMessage.Text.Trim() + " " + "Thank you. Scan Tech Office Automation.");
                        //string baseurl = "http://www.textit.biz/sendmsg";
                        //Stream data = client.OpenRead(baseurl);
                        //StreamReader reader = new StreamReader(data);
                        //string s = reader.ReadToEnd();
                        //data.Close();
                        //reader.Close();                                
                    }
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Messages Sent Successfully.", "Messages Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SelectData();
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

        #endregion


        #region Events

        private void FrmPurchasing_Load(object sender, EventArgs e)
        {
            //SelectData();
            //SelectCompanyData();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (AllowSMS == true)
            {
                sendSMS();
            }
        }

        #endregion

        string messageHD, messageDT, createdMSG;


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            textBoxMessage.Clear();
            messageHD = "Dear valued customer, now you can purchase the below items from us for under mentioned reasonable prices from today, ";
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dataGridView1["SelectItem", i].Value) == true)
                            {
                                messageDT =" | " + "Item : " + dataGridView1["ItemName", i].Value.ToString() + "  " + "  Price : " + dataGridView1["SellingPrice", i].Value.ToString();
                                createdMSG += messageDT;
                            }

                        }
                textBoxMessage.Text = (messageHD + " , " + createdMSG).ToString();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1["SelectItem", i].Value) == true)
                    {
                        ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.ItemsId = Convert.ToInt32(dataGridView1["ItemsId", i].Value.ToString());
                        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.UpdateNewStock(objInvBAL);
                    }
                }

                SelectData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            SelectData();
            SelectCompanyData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells["SelectCust"]).Value = true;
                }
            }
            catch
            {
            }
        }


        #region Validation Methods



        #endregion

    }
}
