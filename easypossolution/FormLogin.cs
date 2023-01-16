using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormLogin : Form
    {
        #region Local Variables
        ClassLoginBAL objBAL = new ClassLoginBAL();
        ClassLoginDAL objDAL = new ClassLoginDAL();

        public string userId, days, ExpDate, BranchId, DevKey, SellerCode;
        private int ActBillNo, Invoice, Sohdid;
        private DateTime ActDate;
        private bool ActStatus = false;

        #endregion

        #region Constructor

        public FormLogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void checkActivation()
        {
            try
            {
                BALUser objUser = new BALUser();
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveActivationInfo(objUser);
                if (objUser.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objUser.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        ActBillNo = Convert.ToInt32(values[0].ToString());
                        ActDate = Convert.ToDateTime(values[1]);
                        DevKey = (values[2].ToString());
                        SellerCode = (values[3].ToString());
                        ActStatus = Convert.ToBoolean(values[4]);
                    }

                    if (Sohdid >= 1000000)
                    {
                        txtUserName.ReadOnly = true;
                        txtUserName.Text = "Activation Required.";
                        txtPassword.ReadOnly = true;
                        txtPassword.Text = "Contact Software Vendors.";
                        FrmSystemActivation frm = new FrmSystemActivation();
                        this.Hide();
                        frm.Show();
                    }

                    if ((SellerCode != DevKey) && (Convert.ToDateTime("2023-02-10") <= DateTime.Today))
                    {
                        txtUserName.ReadOnly = true;
                        txtUserName.Text = "Activation Required.";
                        txtPassword.ReadOnly = true;
                        txtPassword.Text = "Contact Software Vendors.";
                        FrmSystemActivation frm = new FrmSystemActivation();
                        this.Hide();
                        frm.Show();
                    }
                    if (ActStatus == false)
                    {
                        if (Sohdid >= ActBillNo)
                        {
                            txtUserName.ReadOnly = true;
                            txtUserName.Text = "Activation Required.";
                            txtPassword.ReadOnly = true;
                            txtPassword.Text = "Contact Software Vendors.";
                            FrmSystemActivation frm = new FrmSystemActivation();
                            this.Hide();
                            frm.Show();
                        }
                        else if (ActDate <= DateTime.Today)
                        {
                            txtUserName.ReadOnly = true;
                            txtUserName.Text = "Activation Required.";
                            txtPassword.ReadOnly = true;
                            txtPassword.Text = "Contact Software Vendors.";
                            FrmSystemActivation frm = new FrmSystemActivation();
                            this.Hide();
                            frm.Show();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateInvoice()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                Invoice = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]) + 1;
                Sohdid = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[0].Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayClear()
        {
            try
            {
                SerialPort sp = new SerialPort();
                sp.PortName = "COM1";
                sp.BaudRate = 9600;
                sp.Parity = Parity.None;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.Open();
                sp.Write(Convert.ToString((char)12));
                sp.WriteLine("< YOU ARE WELCOME >");
                sp.WriteLine((char)13 + "NEXT CUSTOMER PLEASE");

                sp.Close();
                sp.Dispose();
                sp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void FormLogin_Load(object sender, EventArgs e)
        {
            GenerateInvoice();
            checkActivation();

            txtUserName.Focus();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //DateTime ExpDate;
            
            errorProvider1.Clear();
            try
            {
                bool isValid = validateUserName() && validatePassword();
                if (isValid)
                {
                    objBAL = new ClassLoginBAL();
                    //objBAL.UserType1 = cmbUsertype.Text.Trim();
                    objBAL.UserName1 = txtUserName.Text.Trim();
                    objBAL.Password1 = txtPassword.Text.Trim();
                    objDAL = new ClassLoginDAL();
                    if (objDAL.checkLoginUser(objBAL))
                    {
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
                                userId = (values[0].ToString().Trim());
                                ExpDate = (values[2].ToString().Trim());
                                days = (values[3].ToString().Trim());
                                BranchId = (values[4].ToString().Trim());
                            }


                            this.Hide();
                            FormMain frm = new FormMain();
                            frm.lblUser.Text = txtUserName.Text;
                            frm.lblUserId.Text = userId.ToString();
                            frm.lblRenueDate.Text = ExpDate.ToString();
                            frm.toolStripStatusDays.Text = days.ToString();
                            frm.lblBranchID.Text = BranchId.ToString();
                            frm.Show();
                            //displayClear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter correct Login details.", "Invalid Data.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUserName.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void cmbUsertype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Validation Methods

        private bool validateUserName()
        {
            txtUserName.Text = txtUserName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(txtUserName.Text)) || (txtUserName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter user name";
            }
            else if (!FieldValidationHelper.IsValidString(txtUserName.Text))
            {
                errorCode = "Please enter a correct user name";
            }
            string message = errorCode;
            errorProvider1.SetError(txtUserName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validatePassword()
        {
            txtPassword.Text = txtPassword.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(txtPassword.Text)) || (txtPassword.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter Password.";
            }
            else if (!FieldValidationHelper.IsValidString(txtPassword.Text))
            {
                errorCode = "Please enter a correct Password.";
            }
            string message = errorCode;
            errorProvider1.SetError(txtPassword, message);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FrmSystemActivation frm = new FrmSystemActivation();
            //this.Hide();
            //frm.Show();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSystemActivation frm = new FrmSystemActivation();
            this.Hide();
            frm.Show();
        }



    }
}
