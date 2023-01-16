using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
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
    public partial class FormExpenses : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        ArrayList alistForm = new ArrayList();

        #endregion

        #region Constructor
        public FormExpenses()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void userPermission()
        {
            try
            {
                buttonView.Enabled = false;
                buttonDelete.Enabled = false;
                BALUser objUser = new BALUser();
                //objUser.FORM_NAME = "User Registration";
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveUserPermission(objUser);
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
                        alistForm.Add(values[0].ToString());

                    }
                    for (int i = 0; i < alistForm.Count; i++)
                    {
                        //if (alistForm[i].ToString().Trim() == "ChangePrice")
                        //{
                        //    txtSellingPrice.ReadOnly = false;
                        //}
                        if (alistForm[i].ToString().Trim() == "Delete Expense")
                        {
                            buttonView.Enabled = true;
                            buttonDelete.Enabled = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Discount")
                        //{
                        //    txtDisc.ReadOnly = false;
                        //    textBoxLDiscAmt.ReadOnly = false;
                        //    textBoxUnitDisc.ReadOnly = false;
                        //}
                        //if (alistForm[i].ToString().Trim() == "VisibleCost")
                        //{
                        //    label58.Visible = true;
                        //    textBoxCostPrice.Visible = true;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            comboBoxUser.SelectedIndex = -1;
            dateTimePickerDate.Value = DateTime.Today;
            comboBoxCategory.SelectedIndex = -1;
            textBoxAmount.Text = "0";
            textBoxRemarks.Clear();
            textBoxCategory.Clear();
            errorProvider1.Clear();
            checkBoxPnl.Checked = true;
            comboBoxPayMode.SelectedValue = 1;
            textBoxChequeNo.Clear();
            comboBoxBank.SelectedIndex = -1;
            comboBoxVehicle.SelectedIndex = -1;
        }

        private void insertCategory()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.CatDescription = textBoxCategory.Text.Trim();
                if (checkBoxPnl.Checked == false)
                {
                    objBAL.PNLStatus = false; 
                }
                else
                {
                    objBAL.PNLStatus = true; 
                }
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertCategory(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Expenses Category Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategory();
                    textBoxCategory.Clear();
                    checkBoxPnl.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertBank()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.BankName = comboBoxBank.Text.Trim();
                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertBank(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("New Bank Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBank();
                    comboBoxBank.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertExpenses()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.PayCatId = Convert.ToInt32(comboBoxCategory.SelectedValue.ToString());
                objBAL.PaymentDate = dateTimePickerDate.Value;
                objBAL.PaymentAmount = Convert.ToDecimal(textBoxAmount.Text);
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                //if (comboBoxUser.Text == "Owner")
                //{
                //    objBAL.Status1 = 0;
                //}
                //else
                //{
                    objBAL.Status1 = 1;
                //}
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                if (comboBoxBank.SelectedIndex == -1)
                {
                    comboBoxBank.SelectedValue = 0;
                }
                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
                if (comboBoxVehicle.SelectedIndex == -1)
                {
                    comboBoxVehicle.SelectedValue = 0;
                }
                objBAL.VehicleId = Convert.ToInt32(comboBoxVehicle.SelectedValue);
                objDAL = new ClassMasterDAL();

                string count = objDAL.InsertNewExpenses(objBAL);
                textBoxID.Text = count.ToString();

                if (count != "")
                {


                    //int count = objDAL.InsertExpenses(objBAL);
                    //if (count != 0)
                    //{
                    MessageBox.Show("Expenses Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result = MessageBox.Show("Do you want to print this Voucher ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        printInvoice();
                    }
                    Reset();
                }

                //int count = objDAL.InsertExpenses(objBAL);
                //if (count != 0)
                //{
                //    MessageBox.Show("Expenses Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Reset();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printInvoice()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportPrintExpenses rpt = new CrystalReportPrintExpenses();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ExpensesId = Convert.ToInt32(textBoxID.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveExpensePrintData(objPOBAL);
                rpt.SetDataSource(objPOBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                //REPORT.crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteExpenses()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.ExpensesId = Convert.ToInt32(textBoxID.Text);
                
                objDAL = new ClassMasterDAL();


                int count = objDAL.DeleteExpenses(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Expense Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadCategory()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxCategory.DataSource = objDAL.retreiveExpenseCat(objBAL).Tables[0];
                comboBoxCategory.DisplayMember = "CatDescription";
                comboBoxCategory.ValueMember = "PayCatId";
                comboBoxCategory.SelectedIndex = -1;

                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                comboBoxBranch.DataSource = objPODAL.retreiveBranches(objPOBAL).Tables[0];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedValue = lblBranchID.Text;

                if (objPODAL.retreivePaymentModes(objPOBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objPODAL.retreivePaymentModes(objPOBAL).Tables[0];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadVehicles()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxVehicle.DataSource = objDAL.retreiveVehicles(objBAL).Tables[0];
                comboBoxVehicle.DisplayMember = "VehicleNo";
                comboBoxVehicle.ValueMember = "VehicleId";
                comboBoxVehicle.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadBank()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxBank.DataSource = objDAL.retreiveBanks(objBAL).Tables[0];
                comboBoxBank.DisplayMember = "BankName";
                comboBoxBank.ValueMember = "BankId";
                comboBoxBank.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertSupplierCheque()
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                try
                {
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SupplierId = 2;
                    objBAL.POHDId = 0;
                    objBAL.ChequeBank = comboBoxBank.Text.Trim();
                    objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                    objBAL.ChequeNo = textBoxChequeNo.Text.Trim();
                    objBAL.ChequeAmount = Convert.ToDecimal(textBoxAmount.Text);
                    objBAL.ChequeExpDate = dateTimePickerChqExpDate.Value;
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    int count = objDAL.InsertSupplierCheque(objBAL);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        #endregion


        #region Events

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonExpCatSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateCategoryName();
            if (isValid)
            {
                insertCategory();
            }
        }

        private void FormExpenses_Load(object sender, EventArgs e)
        {
            loadCategory();
            loadBank();
            loadVehicles();
            checkBoxPnl.Checked = true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateExpensesCategory() && ValidatePaymentAmount();
            if (isValid)
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    insertSupplierCheque();
                }
                insertExpenses();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        #region Validation Methods

        private bool ValidatePaymentUser()
        {
            comboBoxUser.Text = comboBoxUser.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxUser.Text)) || (comboBoxUser.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Payment User.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxUser, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateExpensesCategory()
        {
            comboBoxCategory.Text = comboBoxCategory.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxCategory.Text)) || (comboBoxCategory.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Expenses Category.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxCategory, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePaymentAmount()
        {
            textBoxAmount.Text = textBoxAmount.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxAmount.Text)) || (textBoxAmount.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Cash amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxAmount.Text))
            {
                errorCode = "Invalid Cash Amount.";
            }
            else if (Convert.ToDecimal(textBoxAmount.Text) < 0)
            {
                errorCode = "Invalid Cash Amount.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxAmount, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCategoryName()
        {
            textBoxCategory.Text = textBoxCategory.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxCategory.Text)) || (textBoxCategory.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Category.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxCategory, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateBankName()
        {
            comboBoxBank.Text = comboBoxBank.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxBank.Text)) || (comboBoxBank.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Bank Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxBank, message);
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

        private void simpleButtonNewBank_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateBankName();
            if (isValid)
            {
                insertBank();
            }
        }

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                label10.Visible = true;
                textBoxChequeNo.Visible = true;
                label27.Visible = true;
                comboBoxBank.Visible = true;
                label7.Visible = true;
                dateTimePickerChqExpDate.Visible = true;
                simpleButtonNewBank.Visible = true;
            }
            else if (comboBoxPayMode.Text == "Bank Transfer")
            {
                //label10.Visible = true;
                //textBoxChequeNo.Visible = true;
                label27.Visible = true;
                comboBoxBank.Visible = true;
                //label7.Visible = true;
                //dateTimePickerChqExpDate.Visible = true;
                simpleButtonNewBank.Visible = true;
            }
            
            else
            {
                label10.Visible = false;
                textBoxChequeNo.Visible = false;
                label27.Visible = false;
                comboBoxBank.Visible = false;
                label7.Visible = false;
                dateTimePickerChqExpDate.Visible = false;
                simpleButtonNewBank.Visible = false;
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.Text == "BANK DEPOSIT")
            {
                comboBoxBank.Visible = true;
                label7.Visible = true;
                simpleButtonNewBank.Visible = true;
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            FormViewExpenses frm = new FormViewExpenses();
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want Delete this Expense?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteExpenses();
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
        }

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedValue = lblBranchID.Text;
        }

        
    }
}
