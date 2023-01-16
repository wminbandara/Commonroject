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
    public partial class FrmSystemActivation : Form
    {
        #region Local Variables

        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();

        #endregion

        #region Constructor

        public FrmSystemActivation()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void UpdateActivation()
        {
            try
            {
                objUser = new BALUser();
                objUser.ActBillNo = Convert.ToInt32(textBoxActBillNo.Text);
                if (comboBoxActStatus.Text == "Activate")
                {
                    objUser.ActStatus = true;
                }
                else if (comboBoxActStatus.Text == "Deactivate")
                {
                    objUser.ActStatus = false;
                }
                objUser.ActivationType = comboBoxActivationType.Text;

                dalUser = new DALUser();
                int count = dalUser.UpdateSystemActivation(objUser);
                if (count != 0)
                {
                    MessageBox.Show("Successfully Saved.", "Save Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillActivationInfo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDevActivation()
        {
            try
            {
                objUser = new BALUser();
                objUser.ActivationType = "bl086532408452ms";

                dalUser = new DALUser();
                int count = dalUser.UpdateDecSystemActivation(objUser);
                if (count != 0)
                {
                    MessageBox.Show("Successfully Activated.", "Save Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillActivationInfo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillActivationInfo()
        {
            try
            {
                BALUser objUser = new BALUser();
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveActivationInfo(objUser);
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
                        textBoxCompName.Text = (values[0].ToString());
                        textBoxActBillNo.Text = (values[1].ToString());
                        if (Convert.ToBoolean(values[2]) == true)
                        {
                            comboBoxActStatus.Text = "Activate";
                        }
                        else if (Convert.ToBoolean(values[2]) == false)
                        {
                            comboBoxActStatus.Text = "Deactivate";
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

        

        #region Events

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateActivation();
        }

        private void FrmSystemActivation_Load(object sender, EventArgs e)
        {
            fillActivationInfo();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmSystemActivation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPassword.Text == "qwe@123")
                {
                    textBoxActBillNo.ReadOnly = false;
                    comboBoxActStatus.Enabled = true;
                    buttonSave.Enabled = true;
                    comboBoxActivationType.Enabled = true;
                }
                else if (textBoxPassword.Text == "asd@123")
                {
                    textBoxActBillNo.ReadOnly = false;
                    comboBoxActStatus.Enabled = true;
                    buttonSave.Enabled = true;
                    buttonActivation.Enabled = true;
                    buttonActivation.Visible = true;

                }
            }
        }

        #endregion

        private void buttonActivation_Click(object sender, EventArgs e)
        {
            UpdateDevActivation();
        }

        #region Validation Methods

        #endregion
    }
}
