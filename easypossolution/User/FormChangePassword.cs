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
    public partial class FormChangePassword : Form
    {
        #region Local Variables

        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();
        ArrayList alistForm = new ArrayList();

        #endregion

        #region Constructor

        public FormChangePassword()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        private void changePassword()
        {
            objUser = new BALUser();
            objUser.USER_NAME = textBoxUserName.Text.Trim();
            objUser.PASSWORD = textBoxNewPassword.Text.Trim();
            dalUser = new DALUser();
            int count = dalUser.updatePassword(objUser);
            if (count != 0)
            {
                MessageBox.Show("Successfully changed your Password.", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Events

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = ValidateUserName() &&
                           ValidateOldPassword() &&
                           ValidateNewPassword() &&
                           ValidateConfirmPassword() &&
                           ValidateExistPassword();
                if (isValid)
                {

                    changePassword();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                textBoxOldPassword.Select();
            }
        }

        private void textBoxOldPassword_KeyDown(object sender, KeyEventArgs e)
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

        private bool ValidateOldPassword()
        {
            textBoxOldPassword.Text = textBoxOldPassword.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxOldPassword.Text)) || (textBoxOldPassword.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter Old Password.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxOldPassword, message);
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
            else if (textBoxOldPassword.Text.Trim() == textBoxNewPassword.Text.Trim())
            {
                errorCode = "Old password and new password is same.";
            }
            else if ((textBoxNewPassword.TextLength < 5))
            {
                errorCode = "The New Password should be of atleast 5 characters.";
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

        private bool ValidateExistPassword()
        {
            //string clearText1 = textBoxOldPassword.Text.Trim();
            //string cipherText1 = CryptorEngine.Encrypt(clearText1, true);

            string errorCode = string.Empty;
            objUser = new BALUser();
            objUser.USER_ID = Convert.ToInt32(lblUserId.Text.Trim());
            objUser.PASSWORD = textBoxOldPassword.Text.Trim();
            dalUser = new DALUser();
            if (!(dalUser.existOldPass(objUser)))
            {
                errorCode = "Old password do not mach.";

            }
            string message = errorCode;
            errorProvider1.SetError(textBoxOldPassword, message);
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
