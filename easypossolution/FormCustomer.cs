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
    public partial class FormCustomer : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();
        bool loadStatus, AllowSMS;

        string to, apitoken, fromval, apikey, companyname, SMSUrl;

        #endregion

        #region Constructor
        public FormCustomer()
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

        private void ResetCustomerLoyalty()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(textBoxCustomerID.Text);
                objDAL = new ClassMasterDAL();
                int count = objDAL.ResetCustomerLoyaltyPoints(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Customer Loyalty Points Reset Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetAllCustomerLoyalty()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                //objBAL.CustomerId = Convert.ToInt32(textBoxCustomerID.Text);
                objDAL = new ClassMasterDAL();
                int count = objDAL.ResetAllCustomersLoyaltyPoints(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Customers Loyalty Points Reset Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertNewCustomerType()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CustomerType = textBoxNewCustomerType.Text.Trim();

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertNewCustomerType(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("New Area Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCustomerType();
                    textBoxNewCustomerType.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadCustomerType()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxCustomerType.DataSource = objDAL.retreiveAllCustomerTypes(objBAL).Tables[0];
                comboBoxCustomerType.DisplayMember = "CustomerType";
                comboBoxCustomerType.ValueMember = "CustomerTypeId";
                comboBoxCustomerType.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadCustomercontact()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxContactPerson.DataSource = objDAL.retreiveAllCustomercontactper(objBAL).Tables[0];
                comboBoxContactPerson.DisplayMember = "EmployeeName";
                comboBoxContactPerson.ValueMember = "EmployeeID";
                comboBoxContactPerson.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadArea()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxArea.DataSource = objDAL.retreiveAllareas(objBAL).Tables[0];
                comboBoxArea.DisplayMember = "AreaName";
                comboBoxArea.ValueMember = "AreaId";
                comboBoxArea.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadNewArea()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxNewArea.DataSource = objDAL.retreiveAllareas(objBAL).Tables[1];
                comboBoxNewArea.DisplayMember = "AreaName";
                comboBoxNewArea.ValueMember = "AreaId";
                comboBoxNewArea.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertCategory()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.AreaName = textBoxArea.Text.Trim();
                objBAL.DiscRate = Convert.ToDecimal(textBoxDisc.Text);

                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertArea(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("New Billing Type Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadArea();
                    textBoxArea.Clear();
                    textBoxDisc.Text = "0.00";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertArea()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.AreaName = textBoxNewArea.Text.Trim();

                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertNewArea(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("New Area Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadNewArea();
                    textBoxNewArea.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillDiscRate()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.AreaId = Convert.ToInt32(comboBoxArea.SelectedValue.ToString());
                objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveDiscRate(objBAL);
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
                        textBoxDiscRate.Text = (values[0].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillCustomer()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(this.gridView1.GetFocusedRowCellValue("CustomerId").ToString());
                objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveCustomerData(objBAL);
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
                        textBoxCustomerID.Text = (values[0].ToString());
                        textBoxCustomerName.Text = (values[1].ToString());
                        textBoxContactPerson.Text = (values[2].ToString());
                        textBoxAddress.Text = (values[3].ToString());
                        textBoxTel.Text = (values[4].ToString());
                        textBoxFax.Text = (values[5].ToString());
                        textBoxEmail.Text = (values[6].ToString());
                        textBoxNIC.Text = (values[7].ToString());
                        textBoxRemarks.Text = (values[8].ToString());
                        byte[] data = (byte[])(values[9]);
                        MemoryStream ms = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(ms);
                        comboBoxArea.SelectedValue = (values[10].ToString());
                        comboBoxNewArea.SelectedValue = (values[11].ToString());
                        textBoxCreditLimit.Text = (values[12].ToString());
                        comboBoxPriceMode.Text = (values[13].ToString());
                        comboBoxCustomerType.SelectedValue = (values[14].ToString());
                        comboBoxContactPerson.SelectedValue = (values[17].ToString());
                        textBoxLoyaltyPercentage.Text = (values[15].ToString());
                        textBoxLoyaltyAmount.Text = (values[16].ToString());

                    }

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

        private void createCustomerCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string ID = "";

                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
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
                textBoxContactPerson.Text = "C1" + (ID).ToString();
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
                objBAL = new ClassCommonBAL();
                objBAL.CustomerName = textBoxCustomerName.Text.Trim();
                objBAL.CustomerAddress = textBoxAddress.Text.Trim();
                objBAL.CustomerTelNo = textBoxTel.Text.Trim();
                objBAL.CustomerFaxNo = textBoxFax.Text.Trim();
                objBAL.CustomerEmail = textBoxEmail.Text.Trim();
                objBAL.CustomerNICNo = textBoxNIC.Text.Trim();
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                if (checkBoxVATCustomer.Checked == true)
                {
                    objBAL.VATCustomer = true;
                }
                if (checkBoxVATCustomer.Checked == false)
                {
                    objBAL.VATCustomer = false;
                }
                objBAL.ContactPerson = textBoxContactPerson.Text;
                objBAL.BalanceAmount = Convert.ToDecimal(textBoxOpenCredit.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.PriceMode = comboBoxPriceMode.Text;

                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);

                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] data = ms.GetBuffer();
                //MySqlParameter p = new MySqlParameter("@d22", SqlDbType.Image);
                //p.Value = data;
                //cmd.Parameters.Add(p);
                objBAL.CustomerImage = data;
                objBAL.AreaId = Convert.ToInt32(comboBoxArea.SelectedValue.ToString());
                objBAL.NewAreaId = Convert.ToInt32(comboBoxNewArea.SelectedValue.ToString());
                objBAL.CreditLimit = Convert.ToDecimal(textBoxCreditLimit.Text);
                if (comboBoxCustomerType.SelectedIndex == -1)
                {
                    comboBoxCustomerType.SelectedValue = 0;
                }
                objBAL.CustomerTypeId = Convert.ToInt32(comboBoxCustomerType.SelectedValue);
                objBAL.LoyaltyPercentage = Convert.ToDecimal(textBoxLoyaltyPercentage.Text);
                objBAL.LoyaltyAmount = Convert.ToDecimal(textBoxLoyaltyAmount.Text);
                if (comboBoxContactPerson.SelectedIndex == -1)
                {
                    comboBoxContactPerson.SelectedValue = 0;
                }
                objBAL.EmployeeID = Convert.ToInt32(comboBoxContactPerson.SelectedValue);
                
                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertCustomer(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Customer Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (AllowSMS == true)
                    {
                        DialogResult result1 = MessageBox.Show("Do you want to send thanking message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1 == DialogResult.Yes && textBoxTel.Text != "")
                        {
                            //sendThankingSMS();
                            if (textBoxTel.Text != "")
                            {
                                sendCustomerMessage();
                            }
                        }
                    }
                    Reset();
                    fillGridAllCustomers();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void sendCustomerMessage()
        {
            try
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    try
                    {
                        string message2;
                        to = Convert.ToInt64(textBoxTel.Text).ToString();
                        message2 = "Dear " + textBoxCustomerName.Text + " Thank you for registering with us. You are welcome to " + " " + companyname.ToString() + ". Thank you.";

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

                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

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

        private void Reset()
        {
            textBoxCustomerID.Text = "0";
            textBoxCustomerName.Clear();
            textBoxAddress.Clear();
            textBoxTel.Clear();
            textBoxFax.Clear();
            textBoxEmail.Clear();
            textBoxNIC.Clear();
            textBoxRemarks.Clear();
            textBoxCustomerID.Clear();
            checkBoxVATCustomer.Checked = false;
            textBoxContactPerson.Clear();
            textBoxOpenCredit.Text = "0";
            ButtonUpdate.Enabled = false;
            ButtonDelete.Enabled = false;
            buttonUpdateOB.Enabled = false;
            button2.Enabled = false;
            ButtonSave.Enabled = true;
            comboBoxArea.SelectedIndex = 0;
            textBoxDiscRate.Text = "0.00";
            textBoxCreditLimit.Text = "0.00";
            comboBoxNewArea.SelectedIndex = 0;
            textBoxAdvance.Text = "0.00";
            textBoxLoyaltyPercentage.Text = "0.00";
            textBoxLoyaltyAmount.Text = "0";
            comboBoxContactPerson.SelectedIndex = -1;
            fillImage();
        }

        private void UpdateCustomer()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.CustomerName = textBoxCustomerName.Text.Trim();
                objBAL.CustomerAddress = textBoxAddress.Text.Trim();
                objBAL.CustomerTelNo = textBoxTel.Text.Trim();
                objBAL.CustomerFaxNo = textBoxFax.Text.Trim();
                objBAL.CustomerEmail = textBoxEmail.Text.Trim();
                objBAL.CustomerNICNo = textBoxNIC.Text.Trim();
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                if (checkBoxVATCustomer.Checked == true)
                {
                    objBAL.VATCustomer = true;
                }
                if (checkBoxVATCustomer.Checked == false)
                {
                    objBAL.VATCustomer = false;
                }
                objBAL.ModifiedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.CustomerId = Convert.ToInt32(textBoxCustomerID.Text);
                objBAL.ContactPerson = textBoxContactPerson.Text;
                objBAL.BalanceAmount = Convert.ToDecimal(textBoxOpenCredit.Text);
                objBAL.PriceMode = comboBoxPriceMode.Text;                

                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);

                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] data = ms.GetBuffer();
                //MySqlParameter p = new MySqlParameter("@d22", SqlDbType.Image);
                //p.Value = data;
                //cmd.Parameters.Add(p);
                objBAL.CustomerImage = data;
                objBAL.AreaId = Convert.ToInt32(comboBoxArea.SelectedValue.ToString());
                objBAL.NewAreaId = Convert.ToInt32(comboBoxNewArea.SelectedValue.ToString());
                objBAL.CreditLimit = Convert.ToDecimal(textBoxCreditLimit.Text);
                if (comboBoxCustomerType.SelectedIndex == -1)
                {
                    comboBoxCustomerType.SelectedValue = 0;
                }
                objBAL.CustomerTypeId = Convert.ToInt32(comboBoxCustomerType.SelectedValue);
                objBAL.LoyaltyPercentage = Convert.ToDecimal(textBoxLoyaltyPercentage.Text);
                objBAL.LoyaltyAmount = Convert.ToDecimal(textBoxLoyaltyAmount.Text);
                if (comboBoxContactPerson.SelectedIndex == -1)
                {
                    comboBoxContactPerson.SelectedValue = 0;
                }
                objBAL.EmployeeID = Convert.ToInt32(comboBoxContactPerson.SelectedValue);

                objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateCustomer(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Customer Updated Susccessfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGridAllCustomers();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCustomerOB()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(textBoxCustomerID.Text);
                objBAL.BalanceAmount = Convert.ToDecimal(textBoxOpenCredit.Text);

                objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateCustomerOB(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Customer Opening Balance Updated Susccessfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxOpenCredit.Text = "0.00";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCustomerAdvance()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(textBoxCustomerID.Text);
                objBAL.AdvanceDate = DateAdv.Value;
                objBAL.AdvanceAmount = Convert.ToDecimal(textBoxAdvance.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateCustomerAdvance(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Customer Advance Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxAdvance.Text = "0.00";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteCustomer()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(textBoxCustomerID.Text);
                objDAL = new ClassMasterDAL();
                int count = objDAL.DeleteCustomer(objBAL);
                if (count != 0)
                {
                    Reset();
                    fillGridAllCustomers();
                    MessageBox.Show("Customer Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //dataGridView1.DataSource = null;
                //objBAL.DtDataSet = objDAL.retreiveAllCustomers(objBAL);
                //if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                //{
                //    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                //    dataGridView1.Columns["BalanceAmount"].Visible = false;
                //}
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllCustomers(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView1.Columns["CustomerId"].Visible = false;
                    gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["CustomerTypeId"].Visible = false;
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

        #endregion


        #region Events

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateCustName() && ValidateArea() && ValidateSelectedArea();
            if (isValid)
            {
                //textBoxContactPerson.Text = "";
                //if (textBoxContactPerson.Text == "")
                //{
                //    createCustomerCode();
                //}
                if (textBoxContactPerson.Text == "")
                {
                    createCustomerCode();
                }
                
                InsertCustomer();
                Reset();
                //fillGridAllCustomers();
            }

        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Update this Customer Record?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                errorProvider1.Clear();
                bool isValid = ValidateCustId() && ValidateCustName() && ValidateArea() && ValidateSelectedArea();
                if (isValid)
                {
                    UpdateCustomer();
                    Reset();
                    //fillGridAllCustomers();
                    ButtonUpdate.Enabled = false;
                    ButtonDelete.Enabled = false;
                    buttonUpdateOB.Enabled = false;
                    button2.Enabled = false;
                    ButtonSave.Enabled = true;
                }
            }
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            loadStatus = true;
            fillGridAllCustomers();
            loadArea();
            loadNewArea();
            fillImage();
            loadCustomerType();
            loadCustomercontact();
            SelectCompanyData();
            loadStatus = false;
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
            createCustomerCode();
            textBoxCustomerName.Select();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewRow dr = dataGridView1.SelectedRows[0];
            //textBoxCustomerID.Text = dr.Cells[0].Value.ToString();
            //textBoxCustomerName.Text = dr.Cells[1].Value.ToString();
            //textBoxAddress.Text = dr.Cells[2].Value.ToString();
            //textBoxTel.Text = dr.Cells[3].Value.ToString();
            //textBoxFax.Text = dr.Cells[4].Value.ToString();
            //textBoxEmail.Text = dr.Cells[5].Value.ToString();
            //textBoxNIC.Text = dr.Cells[6].Value.ToString();
            //textBoxOpenCredit.Text = dr.Cells[7].Value.ToString();
            //if (dr.Cells[8].Value.ToString() == "Yes")
            //{
            //    checkBoxVATCustomer.Checked = true;
            //}
            //else
            //{
            //    checkBoxVATCustomer.Checked = false;
            //}
            //textBoxRemarks.Text = dr.Cells[9].Value.ToString();
            //textBoxContactPerson.Text = dr.Cells[10].Value.ToString();

        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Do you want to Delete this Customer Record?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {
                 errorProvider1.Clear();
                 bool isValid = ValidateCustId();
                 if (isValid)
                 {
                     DeleteCustomer();
                     Reset();
                     fillGridAllCustomers();
                     ButtonUpdate.Enabled = false;
                     ButtonDelete.Enabled = false;
                     buttonUpdateOB.Enabled = false;
                     button2.Enabled = false;
                     ButtonSave.Enabled = true;
                 }
             }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //string strRowNumber = (e.RowIndex + 1).ToString();
            //SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            //if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            //{
            //    dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            //}
            //Brush b = SystemBrushes.ControlText;
            //e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            //Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Validation Methods

        private bool ValidateCustId()
        {
            textBoxCustomerID.Text = textBoxCustomerID.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxCustomerID.Text)) || (textBoxCustomerID.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select a Customer.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxCustomerID, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCustName()
        {
            textBoxCustomerName.Text = textBoxCustomerName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxCustomerName.Text)) || (textBoxCustomerName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Customer Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxCustomerName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateAreaName()
        {
            textBoxArea.Text = textBoxArea.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxArea.Text)) || (textBoxArea.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Billing Type Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxArea, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateNewAreaName()
        {
            textBoxNewArea.Text = textBoxNewArea.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxNewArea.Text)) || (textBoxNewArea.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Area Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxNewArea, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateArea()
        {
            comboBoxArea.Text = comboBoxArea.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxArea.Text)) || (comboBoxArea.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Area.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxArea, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSelectedArea()
        {
            comboBoxNewArea.Text = comboBoxNewArea.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxNewArea.Text)) || (comboBoxNewArea.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select an Area.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxNewArea, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateNewCustomerType()
        {
            textBoxNewCustomerType.Text = textBoxNewCustomerType.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxNewCustomerType.Text)) || (textBoxNewCustomerType.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter New Supplier Type.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxNewCustomerType, message);
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

        private void Browse_Click(object sender, EventArgs e)
        {
            var _with1 = openFileDialog1;

            _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
            _with1.FilterIndex = 4;

            //Clear the file name
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("CustomerId") == null)
                return;
            fillCustomer();
            ButtonUpdate.Enabled = true;
            ButtonDelete.Enabled = true;
            buttonUpdateOB.Enabled = true;
            button2.Enabled = true;
            ButtonSave.Enabled = false;
        }

        private void buttonExpCatSave_Click(object sender, EventArgs e)
        {
            //decimal decamt = 0;
            //decamt = Math.Round(Convert.ToDecimal(textBoxDisc.Text) * 2, MidpointRounding.ToEven) / 2;
            //MessageBox.Show(decamt.ToString());
            bool isValid = ValidateAreaName();
            if (isValid)
            {
                insertCategory();
                textBoxArea.Select();
            }
        }

        private void comboBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxArea.SelectedIndex != -1)
            {
                fillDiscRate();
                ButtonSave.Select();
            }
        }

        private void textBoxArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBoxDisc.Select();
            }
        }

        private void textBoxDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                buttonExpCatSave.Select();
            }
        }

        private void textBoxCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBoxNIC.Select();
            }
        }

        private void textBoxNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBoxTel.Select();
            }
        }

        private void textBoxTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBoxFax.Select();
            }
        }

        private void textBoxFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBoxAddress.Select();
            }
        }

        private void textBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBoxRemarks.Select();
            }
        }

        private void textBoxRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBoxEmail.Select();
            }
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                comboBoxArea.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateNewAreaName();
            if (isValid)
            {
                insertArea();
                textBoxNewArea.Select();
            }
        }

        private void buttonUpdateOB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Update this Customer Opening Balance?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateCustomerOB();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCustomerAdvance();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //string FileName = "C:\\ExportData\\Commision.xls";
                //gridControl1.ExportToXls(FileName);
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl1.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl1.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl1.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl1.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl1.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl1.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNewCustType_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateNewCustomerType();
            if (isValid)
            {
                insertNewCustomerType();
                textBoxNewCustomerType.Select();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Reset This Customer Loyalty Points?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                errorProvider1.Clear();
                bool isValid = ValidateCustId();
                if (isValid)
                {
                    ResetCustomerLoyalty();
                    fillGridAllCustomers();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Reset All Customers Loyalty Points?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetAllCustomerLoyalty();
                fillGridAllCustomers();
            }
        }

       

    }
}
