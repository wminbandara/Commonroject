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
    public partial class FormBranch : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        #endregion

        #region Constructor
        public FormBranch()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void fillCustomer()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.BranchId = Convert.ToInt32(this.gridView1.GetFocusedRowCellValue("BranchId").ToString());
                objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveBranchData(objBAL);
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
                        textBoxBranchID.Text = (values[0].ToString());
                        textBoxBranchName.Text = (values[1].ToString());
                        textBoxBranchCode.Text = (values[2].ToString());
                        textBoxAddress.Text = (values[3].ToString());
                        textBoxAddress2.Text = (values[4].ToString());
                        textBoxTel.Text = (values[5].ToString());
                        textBoxTel2.Text = (values[6].ToString());
                        textBoxFax.Text = (values[7].ToString());
                        textBoxEmail.Text = (values[8].ToString());
                        textBoxRemarks.Text = (values[9].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createCustomerCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string ID = "";

                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveMaxBranchIdData(objBAL);
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
                        ID = (Convert.ToInt32(values[0])).ToString("000");
                    }
                }
                string str = (textBoxBranchName.Text.Substring(0, 2)).ToUpper();
                textBoxBranchCode.Text = str + (ID).ToString();
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
                objBAL.BranchName = textBoxBranchName.Text.Trim();
                objBAL.BranchAddress = textBoxAddress.Text.Trim();
                objBAL.BranchAddress2 = textBoxAddress2.Text.Trim();
                objBAL.BranchTelNo = textBoxTel.Text.Trim();
                objBAL.BranchTelNo2 = textBoxTel2.Text.Trim();
                objBAL.BranchFaxNo = textBoxFax.Text.Trim();
                objBAL.BranchEmail = textBoxEmail.Text.Trim();
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.BranchCode = textBoxBranchCode.Text;
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);

                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertBranch(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Branch Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGridAllCustomers();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            textBoxBranchID.Text = "0";
            textBoxBranchName.Clear();
            textBoxAddress.Clear();
            textBoxTel.Clear();
            textBoxFax.Clear();
            textBoxEmail.Clear();
            textBoxRemarks.Clear();
            textBoxBranchID.Clear();
            textBoxBranchCode.Clear();
            textBoxAddress2.Clear();
            textBoxTel2.Clear();
            ButtonUpdate.Enabled = false;
            ButtonSave.Enabled = true;
        }

        private void UpdateCustomer()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.BranchName = textBoxBranchName.Text.Trim();
                objBAL.BranchAddress = textBoxAddress.Text.Trim();
                objBAL.BranchAddress2 = textBoxAddress2.Text.Trim();
                objBAL.BranchTelNo = textBoxTel.Text.Trim();
                objBAL.BranchTelNo2 = textBoxTel2.Text.Trim();
                objBAL.BranchFaxNo = textBoxFax.Text.Trim();
                objBAL.BranchEmail = textBoxEmail.Text.Trim();
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.ModifiedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.BranchId = Convert.ToInt32(textBoxBranchID.Text);
                objBAL.ContactPerson = textBoxBranchCode.Text;

                objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateBranch(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Branch Updated Susccessfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGridAllCustomers();
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
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllBranchData(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView1.Columns["BranchId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["BalanceAmount"].Visible = false;
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
            bool isValid = ValidateCustName();
            if (isValid)
            {
                if (textBoxBranchCode.Text == "")
                {
                   createCustomerCode(); 
                }
                InsertCustomer();
                Reset();
                fillGridAllCustomers();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Update this Branch Record?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                errorProvider1.Clear();
                bool isValid = ValidateCustId() && ValidateCustName();
                if (isValid)
                {
                    UpdateCustomer();
                    Reset();
                    fillGridAllCustomers();
                    ButtonUpdate.Enabled = false;
                    ButtonSave.Enabled = true;
                }
            }
        }

        private void FormBranch_Load(object sender, EventArgs e)
        {
            fillGridAllCustomers();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
            
            //createCustomerCode();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("BranchId") == null)
                return;
            fillCustomer();
            ButtonUpdate.Enabled = true;
            ButtonSave.Enabled = false;
        }

        #endregion

        #region Validation Methods

        private bool ValidateCustId()
        {
            textBoxBranchID.Text = textBoxBranchID.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxBranchID.Text)) || (textBoxBranchID.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select a Branch.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxBranchID, message);
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
            textBoxBranchName.Text = textBoxBranchName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxBranchName.Text)) || (textBoxBranchName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Branch Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxBranchName, message);
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
