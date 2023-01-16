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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FrmCompanyInfo : Form
    {
        #region Local Variables

        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();
        int CompanyInfoId = 0;
        bool loadStatus = false;

        #endregion

        #region Constructor

        public FrmCompanyInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void loadArea()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
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

        private void InsertCompanyInfo()
        {
            try
            {
                objUser = new BALUser();
                objUser.CompanyInfoId = CompanyInfoId;
                objUser.CompanyName = textBoxCompName.Text.Trim();
                objUser.CompanyAddress1 = textBoxAdd1.Text.Trim();
                objUser.CompanyAddress2 = textBoxAdd2.Text.Trim();
                objUser.ContactNo1 = textBoxCon1.Text.Trim();
                objUser.ContactNo2 = textBoxCon2.Text.Trim();
                objUser.FooterMsg1 = textBoxFMsg1.Text.Trim();
                objUser.FooterMsg2 = textBoxFMsg2.Text.Trim();
                objUser.VATNo = textBoxVAT.Text.Trim();
                objUser.CompRegNo = textBoxBRNo.Text.Trim();
                objUser.Web = textBoxWeb.Text.Trim();
                objUser.Email = textBoxEmail.Text.Trim();

                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);

                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] data = ms.GetBuffer();
                //MySqlParameter p = new MySqlParameter("@d22", SqlDbType.Image);
                //p.Value = data;
                //cmd.Parameters.Add(p);
                objUser.CompanyLogo = data;
                objUser.DiscTypeId = Convert.ToInt32(comboBoxArea.SelectedValue.ToString());
                objUser.DiscRate = Convert.ToDecimal(textBoxDiscRate.Text.Trim());
                objUser.SMSUrl = textBoxSMSUrl.Text.Trim();
                objUser.APIKey = textBoxAPIKey.Text.Trim();
                objUser.APIToken = textBoxAPIToken.Text.Trim();
                objUser.SenderId = textBoxSenderId.Text.Trim();
                objUser.CommissionRate = Convert.ToDecimal(textBoxCommissionRate.Text.Trim());
                if (checkBoxAllowSMS.Checked == true)
                {
                    objUser.AllowSMS = true;
                }
                if (checkBoxAllowSMS.Checked == false)
                {
                    objUser.AllowSMS = false;
                }

                dalUser = new DALUser();
                int count = dalUser.insertCompanyInfo(objUser);
                if (count != 0)
                {
                    MessageBox.Show("Successfully Saved.", "Save Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
                        CompanyInfoId = Convert.ToInt32(values[0].ToString());
                        textBoxCompName.Text = (values[1].ToString());
                        textBoxAdd1.Text = (values[2].ToString());
                        textBoxAdd2.Text = (values[3].ToString());
                        textBoxCon1.Text = (values[4].ToString());
                        textBoxCon2.Text = (values[5].ToString());
                        textBoxFMsg1.Text = (values[7].ToString());
                        textBoxFMsg2.Text = (values[9].ToString());
                        textBoxVAT.Text = (values[8].ToString());
                        textBoxBRNo.Text = (values[10].ToString());
                        textBoxWeb.Text = (values[11].ToString());
                        textBoxEmail.Text = (values[12].ToString());
                        byte[] data = (byte[])(values[6]);
                        MemoryStream ms = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(ms);
                        comboBoxArea.SelectedValue = (values[13].ToString());
                        textBoxDiscRate.Text = (values[14].ToString());
                        textBoxSMSUrl.Text = (values[15].ToString());
                        textBoxAPIKey.Text = (values[16].ToString());
                        textBoxAPIToken.Text = (values[17].ToString());
                        textBoxSenderId.Text = (values[18].ToString());
                        textBoxCommissionRate.Text = (values[19].ToString());
                        checkBoxAllowSMS.Checked = false;
                        if (Convert.ToBoolean(values[20]) == true)
                        {
                            checkBoxAllowSMS.Checked = true;
                        }
                    }
                    
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
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.AreaId = Convert.ToInt32(comboBoxArea.SelectedValue.ToString());
                ClassMasterDAL objDAL = new ClassMasterDAL();
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

        #endregion

        #region Events

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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            InsertCompanyInfo();
        }

        private void FrmCompanyInfo_Load(object sender, EventArgs e)
        {
            loadStatus = true;
            loadArea();
            fillCompanyInfo();
            loadStatus = false;
        }
        #endregion        

        private void comboBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxArea.SelectedIndex != -1)
            {
                fillDiscRate();
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            if (lblUserId.Text == "1")
            {
                textBoxSMSUrl.Enabled = true;
                textBoxAPIKey.Enabled = true;
                textBoxAPIToken.Enabled = true;
                textBoxSenderId.Enabled = true;
                textBoxCommissionRate.Enabled = true;
                checkBoxAllowSMS.Enabled = true;
            }
        }

        #region Validation Methods

        #endregion

    }
}
