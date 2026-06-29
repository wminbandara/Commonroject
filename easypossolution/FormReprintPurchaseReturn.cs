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
    public partial class FormReprintPurchaseReturn : Form
    {
        #region Local Variables
        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7;
        ArrayList alistOption = new ArrayList();
        int InvoiceNo = 0;

        #endregion

        public FormReprintPurchaseReturn()
        {
            InitializeComponent();
        }

        private void fillGrid()
        {
            objBAL = new ClassSOBAL();
            //objCustBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllPurchaseReturn(objBAL).Tables[0].Rows.Count > 0)
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
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("ReturnId").ToString());
            PrintPIReturn();
        }

        public void PrintPIReturn()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                CrystalReportPInvoiceReturn rpt = new CrystalReportPInvoiceReturn();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(txtReprint.Text);
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePIReturnData(objBAL);
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

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("ReturnId") == null)
                return;
            fillInv();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            Cursor.Current = Cursors.Default;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
