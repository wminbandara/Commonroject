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
    public partial class FormReturnCheque : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        bool loadStatus;

        #endregion

        #region Constructor
        public FormReturnCheque()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void loadBank()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
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

        public void loadControlls()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                if (objDAL.retreivePOLoadingData(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxSupplier.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
                    comboBoxSupplier.DisplayMember = "SupplierName";
                    comboBoxSupplier.ValueMember = "SupplierId";
                    comboBoxSupplier.SelectedIndex = -1;
                }

                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                if (objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                    comboBoxCustomer.DisplayMember = "CustomerName";
                    comboBoxCustomer.ValueMember = "CustomerId";
                    comboBoxCustomer.SelectedIndex = -1;

                    comboBoxReturnCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                    comboBoxReturnCustomer.DisplayMember = "CustomerName";
                    comboBoxReturnCustomer.ValueMember = "CustomerId";
                    comboBoxReturnCustomer.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        


        #region Events

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReturnCheque_Load(object sender, EventArgs e)
        {
            loadStatus = true;
            //loadControlls();
            loadBank();
            loadStatus = false;
        }

        #endregion

        private void simpleButtonAllReceived_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                gridControl2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllCustomerCheques(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl2.DataSource = objBAL.DtDataSet.Tables[0];
                    gridView2.Columns["CustChqId"].Visible = false;
                    gridView2.Columns["CustomerId"].Visible = false;
                    gridView2.Columns["ReturnStatus"].Visible = false;
                    gridView2.OptionsView.ColumnAutoWidth = false;
                    gridView2.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((loadStatus == false) && (comboBoxCustomer.SelectedIndex != -1))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objBAL = new ClassPOBAL();
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    gridControl2.DataSource = null;
                    objBAL.DtDataSet = objDAL.retreiveCustomerChequesByCust(objBAL);
                    if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl2.DataSource = objBAL.DtDataSet.Tables[0];
                        gridView2.Columns["CustChqId"].Visible = false;
                        gridView2.Columns["CustomerId"].Visible = false;
                        gridView2.Columns["ReturnStatus"].Visible = false;
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void simpleButtonAllIssued_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllSupplierCheques(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    gridView1.Columns["SuppChqId"].Visible = false;
                    gridView1.Columns["SupplierId"].Visible = false;
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

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((loadStatus == false) && (comboBoxSupplier.SelectedIndex != -1))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    gridControl1.DataSource = null;
                    objBAL.DtDataSet = objDAL.retreiveSupplierChequesBySupplier(objBAL);
                    if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                        gridView1.Columns["SuppChqId"].Visible = false;
                        gridView1.Columns["SupplierId"].Visible = false;
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
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you need to Return These Cheques?", "Cheque Return Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    bool insertDTStatus = false;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, "ReturnStatus")) == true)
                        {
                            objBAL = new ClassPOBAL();
                            objBAL.SuppChqId = Convert.ToInt32(gridView1.GetRowCellValue(i, "SuppChqId").ToString());
                            objBAL.SupplierId = Convert.ToInt32(gridView1.GetRowCellValue(i, "SupplierId").ToString());
                            objBAL.POHDId = Convert.ToInt32(gridView1.GetRowCellValue(i, "PurInvNo").ToString());
                            objBAL.ChequeAmount = Convert.ToDecimal(gridView1.GetRowCellValue(i, "ChequeAmount").ToString());
                            objBAL.RtnRemark = textBoxIssRemarks.Text;
                            objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                            objDAL = new ClassPODAL();
                            int count = objDAL.UpdateIssueChqReturn(objBAL);

                            if (count != 0)
                            {
                                insertDTStatus = true;
                            }
                        }
                        
                    }
                    if (insertDTStatus == true)
                    {
                        MessageBox.Show("Cheque Returned Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridControl1.DataSource = null;
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if ((comboBoxBank.SelectedIndex == -1))
            {
                MessageBox.Show("Please Select the Bank.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxBank.Focus();
                comboBoxBank.Select();
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you need to Deposit selected Cheques?", "Cheque Deposit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes && comboBoxBank.SelectedIndex != -1)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        bool insertDTStatus = false;
                        for (int i = 0; i < gridView2.RowCount; i++)
                        {
                            if (Convert.ToBoolean(gridView2.GetRowCellValue(i, "DepositStatus")) == true)
                            {
                                objBAL = new ClassPOBAL();
                                objBAL.CustChqId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustChqId").ToString());
                                objBAL.CustomerId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustomerId").ToString());
                                objBAL.SOHDId = Convert.ToInt32(gridView2.GetRowCellValue(i, "BillNo").ToString());
                                objBAL.ChequeAmount = Convert.ToDecimal(gridView2.GetRowCellValue(i, "ChequeAmount").ToString());
                                objBAL.RtnRemark = textBoxRecRemarks.Text;
                                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
                                objDAL = new ClassPODAL();
                                int count = objDAL.UpdateReceivedChqDeosit(objBAL);

                                if (count != 0)
                                {
                                    insertDTStatus = true;
                                }
                            }
                        }
                        if (insertDTStatus == true)
                        {
                            MessageBox.Show("Cheque Deposited Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControl2.DataSource = null;
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            //DialogResult result = MessageBox.Show("Are you sure you need to Return These Cheques?", "Cheque Return Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        bool insertDTStatus = false;
            //        for (int i = 0; i < gridView2.RowCount; i++)
            //        {
            //            if (Convert.ToBoolean(gridView2.GetRowCellValue(i, "ReturnStatus")) == true)
            //            {
            //                objBAL = new ClassPOBAL();
            //                objBAL.CustChqId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustChqId").ToString());
            //                objBAL.CustomerId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustomerId").ToString());
            //                objBAL.SOHDId = Convert.ToInt32(gridView2.GetRowCellValue(i, "BillNo").ToString());
            //                objBAL.ChequeAmount = Convert.ToDecimal(gridView2.GetRowCellValue(i, "ChequeAmount").ToString());
            //                objBAL.RtnRemark = textBoxRecRemarks.Text;
            //                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
            //                objDAL = new ClassPODAL();
            //                int count = objDAL.UpdateReceivedChqReturn(objBAL);

            //                if (count != 0)
            //                {
            //                    insertDTStatus = true;
            //                }
            //            }
            //        }
            //        if (insertDTStatus == true)
            //        {
            //            MessageBox.Show("Cheque Returned Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            gridControl2.DataSource = null;
            //        }
            //        Cursor.Current = Cursors.Default;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you need to Realize These Cheques?", "Cheque Realize Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    bool insertDTStatus = false;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, "ReturnStatus")) == true)
                        {
                            objBAL = new ClassPOBAL();
                            objBAL.SuppChqId = Convert.ToInt32(gridView1.GetRowCellValue(i, "SuppChqId").ToString());
                            objBAL.SupplierId = Convert.ToInt32(gridView1.GetRowCellValue(i, "SupplierId").ToString());
                            objBAL.POHDId = Convert.ToInt32(gridView1.GetRowCellValue(i, "PurInvNo").ToString());
                            objBAL.ChequeAmount = Convert.ToDecimal(gridView1.GetRowCellValue(i, "ChequeAmount").ToString());
                            objBAL.RtnRemark = textBoxIssRemarks.Text;
                            objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                            objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
                            objDAL = new ClassPODAL();
                            int count = objDAL.UpdateIssueChqRealize(objBAL);

                            if (count != 0)
                            {
                                insertDTStatus = true;
                            }
                        }

                    }
                    if (insertDTStatus == true)
                    {
                        MessageBox.Show("Cheque Realized Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridControl1.DataSource = null;
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if ((comboBoxBank.SelectedIndex == -1))
            {
                MessageBox.Show("Please Select the Bank.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBoxBank.Focus();
                comboBoxBank.Select();
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you need to Deposit All Cheques?", "Cheque Deposit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes && comboBoxBank.SelectedIndex != -1)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        bool insertDTStatus = false;
                        for (int i = 0; i < gridView2.RowCount; i++)
                        {
                            //if (Convert.ToBoolean(gridView2.GetRowCellValue(i, "DepositStatus")) == true)
                            //{
                            objBAL = new ClassPOBAL();
                            objBAL.CustChqId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustChqId").ToString());
                            objBAL.CustomerId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustomerId").ToString());
                            objBAL.SOHDId = Convert.ToInt32(gridView2.GetRowCellValue(i, "BillNo").ToString());
                            objBAL.ChequeAmount = Convert.ToDecimal(gridView2.GetRowCellValue(i, "ChequeAmount").ToString());
                            objBAL.RtnRemark = textBoxRecRemarks.Text;
                            objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                            objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
                            objDAL = new ClassPODAL();
                            int count = objDAL.UpdateReceivedChqDeosit(objBAL);

                            if (count != 0)
                            {
                                insertDTStatus = true;
                            }
                            //}
                        }
                        if (insertDTStatus == true)
                        {
                            MessageBox.Show("Cheque Deposited Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControl2.DataSource = null;
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            //DialogResult result = MessageBox.Show("Are you sure you need to Realize These Cheques?", "Cheque Realize Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        bool insertDTStatus = false;
            //        for (int i = 0; i < gridView2.RowCount; i++)
            //        {
            //            if (Convert.ToBoolean(gridView2.GetRowCellValue(i, "ReturnStatus")) == true)
            //            {
            //                objBAL = new ClassPOBAL();
            //                objBAL.CustChqId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustChqId").ToString());
            //                objBAL.CustomerId = Convert.ToInt32(gridView2.GetRowCellValue(i, "CustomerId").ToString());
            //                objBAL.SOHDId = Convert.ToInt32(gridView2.GetRowCellValue(i, "BillNo").ToString());
            //                objBAL.ChequeAmount = Convert.ToDecimal(gridView2.GetRowCellValue(i, "ChequeAmount").ToString());
            //                objBAL.RtnRemark = textBoxRecRemarks.Text;
            //                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
            //                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
            //                objDAL = new ClassPODAL();
            //                int count = objDAL.UpdateReceivedChqRealize(objBAL);

            //                if (count != 0)
            //                {
            //                    insertDTStatus = true;
            //                }
            //            }
            //        }
            //        if (insertDTStatus == true)
            //        {
            //            MessageBox.Show("Cheque Realized Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            gridControl2.DataSource = null;
            //        }
            //        Cursor.Current = Cursors.Default;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            loadStatus = true;
            loadControlls();
            loadStatus = false;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                gridControl3.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllCustomerDepositedCheques(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl3.DataSource = objBAL.DtDataSet.Tables[0];
                    gridView3.Columns["CustChqId"].Visible = false;
                    gridView3.Columns["CustomerId"].Visible = false;
                    //gridView3.Columns["ReturnStatus"].Visible = false;
                    gridView3.OptionsView.ColumnAutoWidth = false;
                    gridView3.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxReturnCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((loadStatus == false) && (comboBoxReturnCustomer.SelectedIndex != -1))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objBAL = new ClassPOBAL();
                    objBAL.CustomerId = Convert.ToInt32(comboBoxReturnCustomer.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    gridControl3.DataSource = null;
                    objBAL.DtDataSet = objDAL.retreiveCustomerDepositChequesByCust(objBAL);
                    if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl3.DataSource = objBAL.DtDataSet.Tables[0];
                        gridView3.Columns["CustChqId"].Visible = false;
                        gridView3.Columns["CustomerId"].Visible = false;
                        //gridView3.Columns["ReturnStatus"].Visible = false;
                        gridView3.OptionsView.ColumnAutoWidth = false;
                        gridView3.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you need to Return These Cheques?", "Cheque Return Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    bool insertDTStatus = false;
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView3.GetRowCellValue(i, "ReturnStatus")) == true)
                        {
                            objBAL = new ClassPOBAL();
                            objBAL.CustChqId = Convert.ToInt32(gridView3.GetRowCellValue(i, "CustChqId").ToString());
                            objBAL.CustomerId = Convert.ToInt32(gridView3.GetRowCellValue(i, "CustomerId").ToString());
                            objBAL.SOHDId = Convert.ToInt32(gridView3.GetRowCellValue(i, "BillNo").ToString());
                            objBAL.ChequeAmount = Convert.ToDecimal(gridView3.GetRowCellValue(i, "ChequeAmount").ToString());
                            objBAL.RtnRemark = textBoxReturnRemarks.Text;
                            objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                            objDAL = new ClassPODAL();
                            int count = objDAL.UpdateReceivedChqReturn(objBAL);

                            if (count != 0)
                            {
                                insertDTStatus = true;
                            }
                        }
                    }
                    if (insertDTStatus == true)
                    {
                        MessageBox.Show("Cheque Returned Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridControl3.DataSource = null;
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        



        #region Validation Methods



        #endregion
        
    }
}
