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
    public partial class FormGINReprint : Form
    {
        #region Local Variables
        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();
        int InvoiceNo = 0;

        #endregion

        #region Constructor
        public FormGINReprint()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void ReprintInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportGINRPrint rpt = new CrystalReportGINRPrint();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.CreditPayHDId = Convert.ToInt32(txtReprint.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveGINData(objPOBAL);
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
            if (objDAL.retreiveAllFG(objBAL).Tables[1].Rows.Count > 0)
            {
                gridControl1.DataSource = objBAL.DtDataSet.Tables[1];
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
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("BOMNo").ToString());
            ReprintInvoice();
        }

        #endregion

        private void FormGINReprint_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("BOMNo") == null)
                return;
            fillInv();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
