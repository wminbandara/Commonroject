using DevExpress.XtraGrid.Views.Grid;
using easyBAL;
using easyDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormTechniciansEntry : Form
    {
        int DocTypeId = 1;
        bool AllowSMS;
        string to, apitoken, fromval, apikey, companyname, SMSUrl;

        public FormTechniciansEntry()
        {
            InitializeComponent();
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

                comboBoxInvoiceStatusSearch.DataSource = objDAL.retreiveInvoiceStatus(objBAL).Tables[0];
                comboBoxInvoiceStatusSearch.DisplayMember = "InvoiceStatus";
                comboBoxInvoiceStatusSearch.ValueMember = "InvoiceStatusId";
                comboBoxInvoiceStatusSearch.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                //objBAL.date1 = dateTimePickerFrom1.Value;
                //objBAL.date2 = dateTimePickerTo1.Value;
                ClassPODAL objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreiveAllInvoiceStatusReport(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView4.Columns["InvoiceStatusId"].Visible = false;
                    gridView4.Columns["DocTypeId"].Visible = false;
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

        private void SearchInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.InvoiceStatusId = Convert.ToInt32(comboBoxInvoiceStatusSearch.SelectedValue.ToString());
                //objBAL.date2 = dateTimePickerTo1.Value;
                ClassPODAL objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreivSearchInvoiceStatusReport(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView4.Columns["InvoiceStatusId"].Visible = false;
                    gridView4.Columns["DocTypeId"].Visible = false;
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

        private void fillInv()
        {
            txtReprint.Text = (this.gridView4.GetFocusedRowCellValue("InvoiceNo").ToString());
            textBoxContactNo.Text = (this.gridView4.GetFocusedRowCellValue("CustomerTelNo").ToString());
            textBoxCustName.Text = (this.gridView4.GetFocusedRowCellValue("CustomerName").ToString());
            DocTypeId = Convert.ToInt32(this.gridView4.GetFocusedRowCellValue("DocTypeId").ToString());
            FillInvoiceDetail();
            AllRemarks();
           
        }

        public void FillInvoiceDetail()
        {
            try
            {
                //lblGrossTot.Text = "0.00";
                //txtTotDiscRate.Text = "0.00";
                //textBoxCharges.Text = "0.00";
                //textBoxNetAmount.Text = "0.00";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                objInvBAL.DocTypeId = Convert.ToInt32(DocTypeId.ToString());
                
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

                        comboBoxInvoiceStatus.SelectedValue = (values[5].ToString());

                        //lblGrossTot.Text = (values[0].ToString().Trim());
                        //txtTotDiscRate.Text = (values[1].ToString().Trim());
                        //textBoxCharges.Text = (values[2].ToString().Trim());
                        //textBoxNetAmount.Text = (values[3].ToString().Trim());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllRemarks()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                objBAL.DocTypeId = Convert.ToInt32(DocTypeId.ToString());
                //objBAL.date1 = dateTimePickerFrom1.Value;
                //objBAL.date2 = dateTimePickerTo1.Value;
                ClassPODAL objDAL = new ClassPODAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllRemarks(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView1.Columns["RemarkId"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateInvoiceStatus()
        {
            try
            {
                ClassInvoiceBAL objBAL = new ClassInvoiceBAL();
                objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                objBAL.InvoiceStatusId = Convert.ToInt32(comboBoxInvoiceStatus.SelectedValue);
                objBAL.Remarks = txtComment.Text;
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.DocTypeId = Convert.ToInt32(DocTypeId.ToString());
                ClassInvoiveDAL objDAL = new ClassInvoiveDAL();
                int count = objDAL.UpdateInvRemarks(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("InvoiceStatus Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormTechniciansEntry_Load(object sender, EventArgs e)
        {
            loadInvoiceStatus();
            SelectCompanyData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllInvoice();
        }

        private void gridView4_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    int stats = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["InvoiceStatusId"]));
                    if (stats == 1)
                    {
                        e.Appearance.BackColor = Color.LightBlue;
                        //e.Appearance.BackColor2 = Color.White;
                    }
                    if (stats == 2)
                    {
                        e.Appearance.BackColor = Color.CornflowerBlue;
                    }
                    if (stats == 3)
                    {
                        e.Appearance.BackColor = Color.LightCoral;
                    }
                    if (stats == 4)
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                    }
                    if (stats == 5)
                    {
                        e.Appearance.BackColor = Color.HotPink;
                    }
                    //if (deletestatus == 1)
                    //{
                    //    e.Appearance.BackColor = Color.YellowGreen;
                    //}
                }
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxInvoiceStatusSearch.SelectedIndex != -1)
            {
                SearchInvoice();
            }
        }

        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {
            if (this.gridView4.GetFocusedRowCellValue("InvoiceNo") == null)
                return;
            fillInv();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateInvoiceStatus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Do you want to send Mobile Service completed message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes && textBoxContactNo.Text != "" && AllowSMS == true)
            {
                 sendCustomerMessage();
            }
        }

        public void sendCustomerMessage()
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string message2;
                    to = Convert.ToInt64(textBoxContactNo.Text).ToString();
                    message2 = "Dear " + textBoxCustName.Text + " Your Device Repair is completed, Your Ref No is: " + txtReprint.Text + " Date : " + DateTime.Now.ToString() + ". " + companyname.ToString() + ".You can come and collect your device. Thank you.";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

                    string url = SMSUrl + apikey + "&destination=94" + to + "&message=" + message2 + "&from=" + fromval;
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
            //    to = textBoxContactNo.Text;
            //    message2 = "Dear " + textBoxCustName.Text + " Your Mobile Repair is completed, Your Ref No is: " + txtReprint.Text + " Date : " + DateTime.Now.ToString() + ". " + companyname.ToString() + ".You can come and collect your mobile. Thank you.";

            //    string baseURL = "http://app.newsletters.lk/smsAPI?sendsms&apikey=" + apikey + "&apitoken=" + apitoken + "&type=sms" + "&from=" + fromval + "&to=94" + to + "&text=" + message2;

            //    client.OpenRead(baseURL);
            //    //MessageBox.Show("Successfully sent message");
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.ToString());
            //}
        }
    }
}
