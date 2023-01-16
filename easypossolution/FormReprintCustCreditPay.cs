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
    public partial class FormReprintCustCreditPay : Form
    {
        #region Local Variables
        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7;
        ArrayList alistOption = new ArrayList();
        int InvoiceNo = 0;

        #endregion

        #region Constructor
        public FormReprintCustCreditPay()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void updatecreditpaycancel()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CreditPayHDId = Convert.ToInt32(txtReprint.Text);
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.updateCustomerCredPayCancel(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Customer Credit Payment cancelled Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReprintInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportCustomerCreditPay rpt = new CrystalReportCustomerCreditPay();
                //CrystalReportCustCreditPay2in rpt = new CrystalReportCustCreditPay2in();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.CustomerId = 0;
                objPOBAL.PayModeId = 0;
                objPOBAL.CreditPayHDId = Convert.ToInt32(txtReprint.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveCustomerPaymentData(objPOBAL);
                rpt.SetDataSource(objPOBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGrid()
        {
            objBAL = new ClassSOBAL();
            //objCustBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllCreditPay(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                //gridView1.Columns["CustAccountId"].Visible = false;
                //gridView1.Columns["BranchId"].Visible = false;
                //gridView1.Columns["Status"].Visible = false;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
            }
        }

        private void fillInv()
        {
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("CreditPayHDId").ToString());
            ReprintInvoice();
        }

        #endregion

        private void FormReprintCustCreditPay_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("CreditPayHDId") == null)
                return;
            fillInv();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Cancel this payment ", "Cancellation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                updatecreditpaycancel();
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            Cursor.Current = Cursors.Default;
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}
