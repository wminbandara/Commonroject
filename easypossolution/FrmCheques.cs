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
    public partial class FrmCheques : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        bool loadStatus;
        #endregion

        #region Constructor

        public FrmCheques()
        {
            InitializeComponent();
        }

        #endregion



        #region Methods

        public void loadControlls()
        {
            try
            {
                if (loadStatus == false)
                {
                    ClassPOBAL objBALNew = new ClassPOBAL();
                    ClassPODAL objDALNew = new ClassPODAL();
                    comboBoxSupplier.DataSource = objDALNew.retreivePOLoadingData(objBALNew).Tables[0];
                    comboBoxSupplier.DisplayMember = "SupplierName";
                    comboBoxSupplier.ValueMember = "SupplierId";
                    comboBoxSupplier.SelectedIndex = -1;

                    if (objDALNew.retreivePOLoadingData(objBALNew).Tables[5].Rows.Count > 0)
                    {
                        comboBoxBranch.DataSource = objDALNew.retreivePOLoadingData(objBALNew).Tables[5];
                        comboBoxBranch.DisplayMember = "BranchName";
                        comboBoxBranch.ValueMember = "BranchId";
                        comboBoxBranch.SelectedIndex = 0;
                    }

                    ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                    ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                    if (objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1].Rows.Count > 0)
                    {
                        comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                        comboBoxCustomer.DisplayMember = "CustomerName";
                        comboBoxCustomer.ValueMember = "CustomerId";
                        comboBoxCustomer.SelectedIndex = -1;
                    }
                    
                }
                loadStatus = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void FrmCheques_Load(object sender, EventArgs e)
        {
            loadControlls();
        }

        private void insertIssueCheque()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objBAL.POHDId = 0;
                objBAL.ChequeBank = comboBoxBank.Text.Trim();
                objBAL.ChequeNo = textBoxChequeNo.Text.Trim();
                objBAL.ChequeAmount = Convert.ToDecimal(textBoxAmount.Text);
                objBAL.ChequeExpDate = dateTimePickerChqExpDate.Value;
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                if (checkBoxCashDepStatus.Checked == true)
                {
                    objBAL.CashDepositStatus = true;
                }
                if (checkBoxCashDepStatus.Checked == false)
                {
                    objBAL.CashDepositStatus = false;
                }
                objBAL.IssueDate = dateTimePickerIssueDate.Value;
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    comboBoxBranch.SelectedValue = 0;
                }
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                objDAL = new ClassPODAL();
                int count = objDAL.InsertSupplierCheque1(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Successfully Saved Issue Cheque.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertReceivedCheque()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                if (textBoxBillNo.Text == "")
                {
                    objInvBAL.SOHDId = 0;
                }
                if (textBoxBillNo.Text != "")
                {
                    objInvBAL.SOHDId = Convert.ToInt32(textBoxBillNo.Text);
                }
                objInvBAL.ChequeBank = comboBoxBank.Text.Trim();
                objInvBAL.ChequeNo = textBoxChequeNo.Text;
                objInvBAL.ChequeAmount = Convert.ToDecimal(textBoxAmount.Text);
                objInvBAL.ChequeExpDate = Convert.ToDateTime(dateTimePickerChqExpDate.Text);
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    comboBoxBranch.SelectedValue = 0;
                }
                objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.InsertCustomerCheque1(objInvBAL);
                if (count != 0)
                {
                    MessageBox.Show("Successfully Saved Received Cheque.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Reset()
        {
            try
            {
                comboBoxSupplier.SelectedIndex = -1;
                comboBoxCustomer.SelectedIndex = -1;
                textBoxChequeNo.Clear();
                dateTimePickerChqExpDate.Value = DateTime.Today;
                comboBoxBank.Text = "";
                textBoxAmount.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void radioButtonIssue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIssue.Checked == true)
            {
                comboBoxCustomer.Enabled = false;
                comboBoxSupplier.Enabled = true;
                checkBoxCashDepStatus.Enabled = true;
                textBoxBillNo.Enabled = false;
            }
        }

        private void radioButtonReceived_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonReceived.Checked == true)
            {
                comboBoxCustomer.Enabled = true;
                comboBoxSupplier.Enabled = false;
                checkBoxCashDepStatus.Enabled = false;
                textBoxBillNo.Enabled = true;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (radioButtonIssue.Checked == true)
            {
                insertIssueCheque();
            }
            else if (radioButtonReceived.Checked == true)
            {
                insertReceivedCheque();
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGetChq_Click(object sender, EventArgs e)
        {
            FormCheqDetails Chq = new FormCheqDetails();
            Chq.Show();
        }

        #region Validation Methods

        #endregion
    }
}
