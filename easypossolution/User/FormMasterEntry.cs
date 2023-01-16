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

namespace easyPOSSolution
{
    public partial class FormMasterEntry : Form
    {
        #region Local Variables
        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();

        #endregion

        #region Constructor

        public FormMasterEntry()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void fillGrid()
        {
            try
            {
                objUser = new BALUser();
                dalUser = new DALUser();
                dataGridViewUserType.DataSource = null;
                dataGridViewRoles.DataSource = null;
                dataGridViewProfile.DataSource = null;
                objUser.DtDataSet = dalUser.retreiveMasterGrid(objUser);
                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridViewUserType.DataSource = objUser.DtDataSet.Tables[0];
                }
                if (objUser.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridViewRoles.DataSource = objUser.DtDataSet.Tables[1];
                }
                if (objUser.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    dataGridViewProfile.DataSource = objUser.DtDataSet.Tables[2];
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void fillControlls()
        {
            try
            {
                objUser = new BALUser();
                dalUser = new DALUser();
                comboBoxFName.DataSource = dalUser.retreiveMasterControlls(objUser).Tables[0];
                comboBoxFName.DisplayMember = "FORM_NAME";
                //comboBoxFName.ValueMember = "ROLE_ID";

                comboBoxPFormName.DataSource = dalUser.retreiveMasterControlls(objUser).Tables[0];
                comboBoxPFormName.DisplayMember = "FORM_NAME";
                //comboBoxPFormName.ValueMember = "ROLE_ID";

                comboBoxPUserType.DataSource = dalUser.retreiveMasterControlls(objUser).Tables[1];
                comboBoxPUserType.DisplayMember = "USER_TYPE";
                comboBoxPUserType.ValueMember = "USER_TYPE_ID";

                if (comboBoxFName.SelectedIndex != 0)
                {
                    objUser = new BALUser();
                    objUser.FORM_NAME = comboBoxFName.Text.Trim();
                    dalUser = new DALUser();
                    comboBoxCName.DataSource = dalUser.retreiveMasterControlls2(objUser).Tables[0];
                    comboBoxCName.DisplayMember = "ROLE_TITLE";
                    comboBoxCName.ValueMember = "ROLE_ID";
                }

                if (comboBoxPFormName.SelectedIndex != 0)
                {
                    objUser = new BALUser();
                    objUser.FORM_NAME = comboBoxPFormName.Text.Trim();
                    dalUser = new DALUser();
                    comboBoxPControlName.DataSource = dalUser.retreiveMasterControlls2(objUser).Tables[0];
                    comboBoxPControlName.DisplayMember = "ROLE_TITLE";
                    comboBoxPControlName.ValueMember = "ROLE_ID";
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void FormMasterEntry_Load(object sender, EventArgs e)
        {
            try
            {
                fillGrid();
                fillControlls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxFName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (comboBoxFName.SelectedIndex != 0)
                //{
                    objUser = new BALUser();
                    objUser.FORM_NAME = comboBoxFName.Text.Trim();
                    dalUser = new DALUser();
                    comboBoxCName.DataSource = dalUser.retreiveMasterControlls2(objUser).Tables[0];
                    comboBoxCName.DisplayMember = "ROLE_TITLE";
                    comboBoxCName.ValueMember = "ROLE_ID";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxPFormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (comboBoxPFormName.SelectedIndex != 0)
                //{
                    objUser = new BALUser();
                    objUser.FORM_NAME = comboBoxPFormName.Text.Trim();
                    dalUser = new DALUser();
                    comboBoxPControlName.DataSource = dalUser.retreiveMasterControlls2(objUser).Tables[0];
                    comboBoxPControlName.DisplayMember = "ROLE_TITLE";
                    comboBoxPControlName.ValueMember = "ROLE_ID";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNewUserType_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            textBoxUserType.Clear();
        }

        private void buttonNewDepartment_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            comboBoxCName.SelectedIndex = -1;
            comboBoxCName.Text = "";
            comboBoxFName.SelectedIndex = -1;
            comboBoxFName.Text = "";
        }

        private void buttonNewProfile_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            comboBoxPControlName.SelectedIndex = -1;
            comboBoxPControlName.Text = "";
            comboBoxPFormName.SelectedIndex = -1;
            comboBoxPFormName.Text = "";
            comboBoxPUserType.SelectedIndex = -1;
            comboBoxPUserType.Text = "";
        }

        private void buttonSaveUserType_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateUserType() && ValidateExistUserType();
                if (isValid)
                {
                    objUser = new BALUser();
                    objUser.USER_TYPE = textBoxUserType.Text.Trim();
                    dalUser = new DALUser();
                    int count = dalUser.insertUserType(objUser);
                    if (count != 0)
                    {
                        MessageBox.Show("User Type Successfully Saved.", "Save Success.");
                        fillGrid();
                        fillControlls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonDeleteUserType_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateUserType() && ValidateExistUserType1();
                if (isValid)
                {
                    objUser = new BALUser();
                    objUser.USER_TYPE = textBoxUserType.Text.Trim();
                    dalUser = new DALUser();
                    int count = dalUser.deleteUserType(objUser);
                    if (count != 0)
                    {
                        MessageBox.Show("User Type Deleted.", "Delete Success.");
                        fillGrid();
                        fillControlls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRoleSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateFormName() && ValidateControlName() && ValidateExistFormRole();
                if (isValid)
                {
                    objUser = new BALUser();
                    objUser.FORM_NAME = comboBoxFName.Text.Trim();
                    objUser.ROLE_TITLE = comboBoxCName.Text.Trim();
                    dalUser = new DALUser();
                    int count = dalUser.insertRole(objUser);
                    if (count != 0)
                    {
                        MessageBox.Show("Roles Successfully Saved.", "Save Success.");
                        fillGrid();
                        //fillControlls();
                        try
                        {
                            objUser = new BALUser();
                            objUser.FORM_NAME = comboBoxFName.Text.Trim();
                            dalUser = new DALUser();
                            comboBoxCName.DataSource = dalUser.retreiveMasterControlls2(objUser).Tables[0];
                            comboBoxCName.DisplayMember = "ROLE_TITLE";
                            comboBoxCName.ValueMember = "ROLE_ID";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool isValid = ValidateProfUserType() && ValidateFormName1() && ValidateControlName1() && ValidateExistProfile();
                if (isValid)
                {
                    objUser = new BALUser();
                    objUser.USER_TYPE_ID = Convert.ToInt32(comboBoxPUserType.SelectedValue.ToString());
                    objUser.ROLE_ID = Convert.ToInt32(comboBoxPControlName.SelectedValue.ToString());
                    dalUser = new DALUser();
                    int count = dalUser.insertProfile(objUser);
                    if (count != 0)
                    {
                        MessageBox.Show("Profile Successfully Saved.", "Save Success.");
                        fillGrid();
                        //fillControlls();
                        try
                        {
                            objUser = new BALUser();
                            objUser.FORM_NAME = comboBoxPFormName.Text.Trim();
                            dalUser = new DALUser();
                            comboBoxPControlName.DataSource = dalUser.retreiveMasterControlls2(objUser).Tables[0];
                            comboBoxPControlName.DisplayMember = "ROLE_TITLE";
                            comboBoxPControlName.ValueMember = "ROLE_ID";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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

        

        #region Validation Methods

        private bool ValidateExistUserType()
        {
            string errorCode = string.Empty;
            objUser = new BALUser();
            objUser.USER_TYPE = textBoxUserType.Text.Trim();
            dalUser = new DALUser();
            if ((dalUser.existUserType(objUser)))
            {
                errorCode = "This is an exixting User type.";

            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUserType, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateExistUserType1()
        {
            string errorCode = string.Empty;
            objUser = new BALUser();
            objUser.USER_TYPE = textBoxUserType.Text.Trim();
            dalUser = new DALUser();
            if (!(dalUser.existUserType(objUser)))
            {
                errorCode = "This User type is not exist.";

            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUserType, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateUserType()
        {
            textBoxUserType.Text = textBoxUserType.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUserType.Text)) || (textBoxUserType.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter User type.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUserType, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateFormName()
        {
            comboBoxFName.Text = comboBoxFName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxFName.Text)) || (comboBoxFName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please select Form Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxFName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateFormName1()
        {
            comboBoxPFormName.Text = comboBoxPFormName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxPFormName.Text)) || (comboBoxPFormName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please select Form Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxPFormName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateControlName()
        {
            comboBoxCName.Text = comboBoxCName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxCName.Text)) || (comboBoxCName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please select Control Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxCName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateControlName1()
        {
            comboBoxPControlName.Text = comboBoxPControlName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxPControlName.Text)) || (comboBoxPControlName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please select Control Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxPControlName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateProfUserType()
        {
            comboBoxPUserType.Text = comboBoxPUserType.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxPUserType.Text)) || (comboBoxPUserType.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please select User Type.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxPUserType, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateExistFormRole()
        {
            string errorCode = string.Empty;
            objUser = new BALUser();
            objUser.FORM_NAME = comboBoxFName.Text.Trim();
            objUser.ROLE_TITLE = comboBoxCName.Text.Trim();
            dalUser = new DALUser();
            if ((dalUser.existFormRole(objUser)))
            {
                errorCode = "This is an exixting Role.";

            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxCName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateExistProfile()
        {
            string errorCode = string.Empty;
            objUser = new BALUser();
            objUser.USER_TYPE_ID = Convert.ToInt32(comboBoxPUserType.SelectedValue.ToString());
            objUser.ROLE_ID = Convert.ToInt32(comboBoxPControlName.SelectedValue.ToString());
            dalUser = new DALUser();
            if ((dalUser.existProfile(objUser)))
            {
                errorCode = "This is an exixting Profile.";

            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxPUserType, message);
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











    }
}
