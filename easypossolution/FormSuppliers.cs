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
    public partial class FormSuppliers : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        #endregion

        #region Constructor
        public FormSuppliers()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        private void insertNewSuplierType()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.SupplierType = textBoxNewSupplierType.Text.Trim();

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertNewSupplierType(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("New Area Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadNewSupplierType();
                    textBoxNewSupplierType.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadNewSupplierType()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxSupplierType.DataSource = objDAL.retreiveAllSupplierTypes(objBAL).Tables[0];
                comboBoxSupplierType.DisplayMember = "SupplierType";
                comboBoxSupplierType.ValueMember = "SupplierTypeId";
                comboBoxSupplierType.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveSupplier()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.SupplierName = textBoxName.Text.Trim();
                objBAL.ContactPerson = textBoxContactPerson.Text.Trim();
                objBAL.BusinessNo = textBoxBusinessNo.Text.Trim();
                objBAL.MobileNo = textBoxMobile.Text.Trim();
                objBAL.Email = textBoxEmail.Text.Trim();
                objBAL.Address = TextBoxAddress.Text.Trim();
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.BalanceAmount = Convert.ToDecimal(textBoxOpenCredit.Text);
                if (comboBoxSupplierType.SelectedIndex == -1)
                {
                    comboBoxSupplierType.SelectedValue = 0;
                }
                objBAL.SupplierTypeId = Convert.ToInt32(comboBoxSupplierType.SelectedValue);
                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertSupplier(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Supplier Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveSupplierAccount()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.SupplierId = Convert.ToInt32(textBoxID.Text.Trim());
                objBAL.BankName = textBoxBank.Text.Trim();
                objBAL.AccountNo = textBoxAccountNo.Text.Trim();

                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertSupplierAccount(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Supplier Account added Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSupplier()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.SupplierName = textBoxName.Text.Trim();
                objBAL.ContactPerson = textBoxContactPerson.Text.Trim();
                objBAL.BusinessNo = textBoxBusinessNo.Text.Trim();
                objBAL.MobileNo = textBoxMobile.Text.Trim();
                objBAL.Email = textBoxEmail.Text.Trim();
                objBAL.Address = TextBoxAddress.Text.Trim();
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.ModifiedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.SupplierId = Convert.ToInt32(textBoxID.Text);
                if (comboBoxSupplierType.SelectedIndex == -1)
                {
                    comboBoxSupplierType.SelectedValue = 0;
                }
                objBAL.SupplierTypeId = Convert.ToInt32(comboBoxSupplierType.SelectedValue);
                objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateSupplier(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Supplier Updated Susccessfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteSupplierAccount()
        {
            if (dataGridView2.Rows.Count > 0)
            {
                try
                {
                    objBAL = new ClassCommonBAL();
                    objBAL.SupAccId = Convert.ToInt32(textBoxAccId.Text.Trim());

                    objDAL = new ClassMasterDAL();
                    int count = objDAL.DeleteSupplierAccount(objBAL);
                    if (count != 0)
                    {
                        MessageBox.Show("Supplier Account Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void deleteSupplier()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.SupplierId = Convert.ToInt32(textBoxID.Text.Trim());

                objDAL = new ClassMasterDAL();
                int count = objDAL.DeleteSupplier(objBAL);
                if (count != 0)
                {
                    deleteSupplierAccount();
                    MessageBox.Show("Supplier Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGridAllSuppliers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllSuppliers(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["BalanceAmount"].Visible = false;
                    dataGridView1.Columns["SupplierTypeId"].Visible = false;

                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGridSearchSupplier()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassCommonBAL();
                objBAL.SupplierName = textBoxSearchName.Text.Trim();
                objDAL = new ClassMasterDAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveSupplierByName(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["BalanceAmount"].Visible = false;
                    dataGridView1.Columns["SupplierTypeId"].Visible = false;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGridSupplierAccount()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassCommonBAL();
                objBAL.SupplierId = Convert.ToInt32(textBoxID.Text);
                objDAL = new ClassMasterDAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveSupplierAccounts(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            textBoxID.Clear();
            textBoxName.Clear();
            textBoxContactPerson.Clear();
            textBoxBusinessNo.Clear();
            textBoxMobile.Clear();
            textBoxEmail.Clear();
            TextBoxAddress.Clear();
            textBoxRemarks.Clear();
            textBoxAccId.Clear();
            textBoxBank.Clear();
            textBoxAccountNo.Clear();
            dataGridView2.DataSource = null;
            fillGridAllSuppliers();
            DisableControlls();
            textBoxOpenCredit.Text = "0";
            comboBoxSupplierType.SelectedIndex = -1;
        }

        private void EnableControlls()
        {
            ButtonSave.Enabled = false;
            ButtonUpdate.Enabled = true;
            ButtonDelete.Enabled = true;
            ButtonAdd.Enabled = true;
        }

        private void DisableControlls()
        {
            ButtonSave.Enabled = true;
            ButtonUpdate.Enabled = false;
            ButtonDelete.Enabled = false;
            ButtonAdd.Enabled = false;
            ButtonDeleteLine.Enabled = false;
        }


        #endregion

        #region Events

        private void FormSuppliers_Load(object sender, EventArgs e)
        {
            fillGridAllSuppliers();
            loadNewSupplierType();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateSuppName();
            if (isValid)
            {
                saveSupplier();
                fillGridAllSuppliers();
                Reset();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateSuppId() && ValidateSuppName();
            if (isValid)
            {
                UpdateSupplier();
                fillGridAllSuppliers();
                Reset();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                textBoxID.Text = dr.Cells[0].Value.ToString();
                textBoxName.Text = dr.Cells[1].Value.ToString();
                textBoxContactPerson.Text = dr.Cells[2].Value.ToString();
                textBoxBusinessNo.Text = dr.Cells[3].Value.ToString();
                textBoxMobile.Text = dr.Cells[4].Value.ToString();
                textBoxEmail.Text = dr.Cells[5].Value.ToString();
                TextBoxAddress.Text = dr.Cells[6].Value.ToString();
                textBoxRemarks.Text = dr.Cells[7].Value.ToString();
                comboBoxSupplierType.SelectedValue = dr.Cells[10].Value.ToString();

                EnableControlls();
                fillGridSupplierAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateSuppId() && ValidateSuppBank() && ValidateSuppBankAcount();
            if (isValid)
            {
                saveSupplierAccount();
                fillGridSupplierAccount();
            }

        }

        private void ButtonDeleteLine_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
             bool isValid = ValidateSuppAccId() && ValidateSuppBank() && ValidateSuppBankAcount();
             if (isValid)
             {
                 deleteSupplierAccount();
                 fillGridSupplierAccount();
             }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateSuppId();
            if (isValid)
            {
                deleteSupplier();
                fillGridAllSuppliers();
                Reset();
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            textBoxAccId.Text = dr.Cells[0].Value.ToString();
            textBoxBank.Text = dr.Cells[1].Value.ToString();
            textBoxAccountNo.Text = dr.Cells[2].Value.ToString();

            ButtonDeleteLine.Enabled = true;
            ButtonAdd.Enabled = false;
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            textBoxAccId.Clear();
            textBoxBank.Clear();
            textBoxAccountNo.Clear();
            ButtonAdd.Enabled = true;

        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            fillGridSearchSupplier();

        }
       

        #endregion

        #region Validation Methods

        private bool ValidateSuppId()
        {
            textBoxID.Text = textBoxID.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxID.Text)) || (textBoxID.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select a Supplier.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxID, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSuppName()
        {
            textBoxName.Text = textBoxName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxName.Text)) || (textBoxName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Supplier Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSuppAccId()
        {
            textBoxAccId.Text = textBoxAccId.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxAccId.Text)) || (textBoxAccId.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select an Account.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxAccId, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSuppBank()
        {
            textBoxBank.Text = textBoxBank.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxBank.Text)) || (textBoxBank.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Bank Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxBank, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSuppBankAcount()
        {
            textBoxAccountNo.Text = textBoxAccountNo.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxAccountNo.Text)) || (textBoxAccountNo.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Bank Account No.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxAccountNo, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateNewSupplierType()
        {
            textBoxNewSupplierType.Text = textBoxNewSupplierType.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxNewSupplierType.Text)) || (textBoxNewSupplierType.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter New Supplier Type.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxNewSupplierType, message);
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

        private void buttonNewSupplierType_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateNewSupplierType();
            if (isValid)
            {
                insertNewSuplierType();
                textBoxNewSupplierType.Select();
            }
        }

       


    }
}
