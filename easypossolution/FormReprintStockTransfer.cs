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
    public partial class FormReprintStockTransfer : Form
    {
        #region Local Variables

        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        #endregion

        #region Constructor
        public FormReprintStockTransfer()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void fillTransferGrid()
        {
            ClassSOBAL objBAL = new ClassSOBAL();
            objBAL.TransferHDId = Convert.ToInt32(txtReprint.Text);
            ClassSODAL objDAL = new ClassSODAL();
            gridControl2.DataSource = null;
            if (objDAL.retreiveAllStockTransferByID(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl2.DataSource = objBAL.DtDataSet.Tables[0];
                //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                //gridView1.Columns["CustAccountId"].Visible = false;
                //gridView1.Columns["BranchId"].Visible = false;
                //gridView1.Columns["Status"].Visible = false;
                gridView2.OptionsView.ColumnAutoWidth = false;
                gridView2.BestFitColumns();
            }
        }

        private void ExportToExcell()
        {
            string exportFilePath = "C:\\CSV\\StockTransfer\\ExcelTransferTemplate.xls";
            gridControl2.ExportToXls(exportFilePath);
            System.Diagnostics.Process.Start(exportFilePath);
        }

        private void updatecancel()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.TransferHDId = Convert.ToInt32(txtReprint.Text);
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.updateStockTransferCancel(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Stock transfer cancelled Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                CrystalReportStockTransfer rpt = new CrystalReportStockTransfer();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.TransferHDId = Convert.ToInt32(txtReprint.Text);
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveTransferData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
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
            if (objDAL.retreiveAllStockTransfer(objBAL).Tables[0].Rows.Count > 0)
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
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("TransferHDId").ToString());
            ReprintInvoice();
        }

        #endregion

        private void FormReprintStockTransfer_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("TransferHDId") == null)
                return;
            fillInv();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Cancel this Stock transfer ", "Cancellation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                updatecancel();
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillTransferGrid();
            ExportToExcell();
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}
