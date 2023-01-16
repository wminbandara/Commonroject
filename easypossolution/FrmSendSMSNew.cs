using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using easyBAL;
using easyDAL;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace easyPOSSolution
{
    public partial class FrmSendSMSNew : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        string to, message, apitoken, fromval, apikey, companyname;

        #endregion

        #region Constructor


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

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGridAllCustomers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllChequeCustomers(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                    dataGridView1.Columns["CustomerId"].Visible = false;
                }

                Cursor.Current = Cursors.Default;
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
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridView1["SelectCustomer", j].Value) == true)
                    {
                        WebClient client = new WebClient();

                        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                        client.QueryString.Add("id", "94718328293");
                        client.QueryString.Add("pw", "1923");
                        client.QueryString.Add("to", dataGridView1["CustomerTelNo", j].Value.ToString());

                        client.QueryString.Add("text", txtSMS.Text.Trim() + " " + " --Dayasri Auto Tech--");
                        string baseurl = "http://www.textit.biz/sendmsg";
                        Stream data = client.OpenRead(baseurl);
                        StreamReader reader = new StreamReader(data);
                        string s = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                    }
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Messages Sent Successfully.", "Messages Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Cursor.Current = Cursors.WaitCursor;
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dataGridView1["SelectCustomer", j].Value) == true)
                    {

                        WebClient client = new WebClient();
                        to = dataGridView1["CustomerTelNo", j].Value.ToString();
                        message = txtSMS.Text.Trim() + ". " + companyname.ToString() + ".";

                        string baseURL = "http://app.newsletters.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message;

                        client.OpenRead(baseURL);

                    }
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Messages Sent Successfully.", "Messages Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Events

        public FrmSendSMSNew()
        {
            InitializeComponent();
        }

        private void FrmSendSMS_Load(object sender, EventArgs e)
        {
            fillGridAllCustomers();
            SelectCompanyData();
        }

        private void btnSend_ItemClick(object sender, ItemClickEventArgs e)
        {
            //sendSMS();
            //sendSMSApi();
        }


        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.textit.biz/login.php");
            Process.Start(sInfo);
        }



        #region Validation Methods



        #endregion

        
    }
}