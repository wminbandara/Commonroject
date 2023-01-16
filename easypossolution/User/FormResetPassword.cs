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

namespace easyPOSSolution
{
    public partial class FormResetPassword : Form
    {
        #region Local Variables

        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();
        ArrayList alistForm = new ArrayList();

        #endregion

        #region Constructor

        public FormResetPassword()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void completeUserName()
        {
            try
            {
                objUser = new BALUser();
                dalUser = new DALUser();
                AutoCompleteStringCollection namecollection = new AutoCompleteStringCollection();
                objUser.DtDataSet = dalUser.retreiveUserName(objUser);

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
                        namecollection.Add(values[0].ToString());
                    }

                    textBoxUserName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    textBoxUserName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBoxUserName.AutoCompleteCustomSource = namecollection;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetPassword()
        {
            try
            {
                // Encrypt the password.
                //string clearText2 = textBoxConfirmPassword.Text.Trim();
                //string cipherText2 = CryptorEngine.Encrypt(clearText2, true);

                //string clearText = textBoxNewPassword.Text.Trim();
                //string cipherText = CryptorEngine.Encrypt(clearText, true);

                objUser = new BALUser();
                objUser.USER_NAME = textBoxUserName.Text.Trim();
                objUser.PASSWORD = textBoxNewPassword.Text.Trim(); ;
                dalUser = new DALUser();
                int count = dalUser.updatePassword(objUser);
                if (count != 0)
                {
                    MessageBox.Show("Successfully reset Password.", "Password Reset.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNewPassword.Text = "";
                    textBoxConfirmPassword.Text = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Events

        private void FormResetPassword_Load(object sender, EventArgs e)
        {
            completeUserName();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateUserName() &&
                ValidateNewPassword() &&
                ValidateConfirmPassword() &&
                ValidateExistUserName();
            if (isValid)
            {
                resetPassword();
            }
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                textBoxNewPassword.Select();
            }
        }

        private void textBoxNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                textBoxConfirmPassword.Select();
            }
        }

        private void textBoxConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                buttonChangePassword_Click(sender, e);
            }
        }

        #endregion

        #region Validation Methods

        private bool ValidateUserName()
        {
            textBoxUserName.Text = textBoxUserName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUserName.Text)) || (textBoxUserName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter Username.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUserName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateNewPassword()
        {
            textBoxNewPassword.Text = textBoxNewPassword.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxNewPassword.Text)) || (textBoxNewPassword.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter New Password.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxNewPassword, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateConfirmPassword()
        {
            textBoxConfirmPassword.Text = textBoxConfirmPassword.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxConfirmPassword.Text)) || (textBoxConfirmPassword.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter Confirm Password.";
            }
            else if (textBoxConfirmPassword.Text.Trim() != textBoxNewPassword.Text.Trim())
            {
                errorCode = "New password and confirm password do not mach.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxConfirmPassword, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateExistUserName()
        {
            string errorCode = string.Empty;
            objUser = new BALUser();
            objUser.USER_NAME = textBoxUserName.Text.Trim();
            dalUser = new DALUser();
            if (!(dalUser.existUser(objUser)))
            {
                errorCode = "Username couldn't find.";

            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUserName, message);
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
