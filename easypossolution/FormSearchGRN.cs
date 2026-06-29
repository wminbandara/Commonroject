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
    public partial class FormSearchGRN : Form
    {
        public FormSearchGRN()
        {
            InitializeComponent();
        }

        private void fillGrid()
        {
            ClassSOBAL objBAL = new ClassSOBAL();
            //objCustBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            ClassSODAL objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllSupplierGRN(objBAL).Tables[0].Rows.Count > 0)
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
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("PIHDId").ToString());
            ReprintInvoice();

        }

        private void ReprintInvoice()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                CrystalReportA4GRNCr rpt = new CrystalReportA4GRNCr();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.PIHDId = Convert.ToInt32(txtReprint.Text);
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                //rpt.Dispose();
                //if (rpt != null)
                //{
                //    rpt.Close();
                //    rpt.Dispose();
                //}
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
            if (this.gridView1.GetFocusedRowCellValue("PIHDId") == null)
                return;
            fillInv();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Confirm This GRN ", "GRN Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                updateGRNConfirm();
            }
        }

        private void updateGRNConfirm()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.PIHDId = Convert.ToInt32(txtReprint.Text);
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.updateGRNConfirm(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("GRN Confirmed Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
