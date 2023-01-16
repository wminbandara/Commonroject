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
    public partial class FormViewExpenses : Form
    {
        public FormExpenses frm { set; get; }

        public FormViewExpenses()
        {
            InitializeComponent();
        }

        private void fillGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                ClassMasterDAL objDAL = new ClassMasterDAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllExpenses(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustAccountId"].Visible = false;
                    gridView1.Columns["PayCatId"].Visible = false;
                    gridView1.Columns["ExpensesId"].Visible = false;
                    gridView1.Columns["BranchId"].Visible = false;
                    gridView1.Columns["VehicleId"].Visible = false;
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (this.gridView1.GetFocusedRowCellValue("ExpensesId") == null)
                    return;
                frm.textBoxID.Text = this.gridView1.GetFocusedRowCellValue("ExpensesId").ToString();
                frm.dateTimePickerDate.Value = Convert.ToDateTime(this.gridView1.GetFocusedRowCellValue("PaymentDate").ToString());
                frm.comboBoxCategory.SelectedValue = this.gridView1.GetFocusedRowCellValue("PayCatId").ToString();
                frm.textBoxAmount.Text = this.gridView1.GetFocusedRowCellValue("PaymentAmount").ToString();
                frm.textBoxRemarks.Text = this.gridView1.GetFocusedRowCellValue("Remarks").ToString();
                frm.comboBoxBranch.SelectedValue = this.gridView1.GetFocusedRowCellValue("BranchId").ToString();
                frm.comboBoxVehicle.SelectedValue = this.gridView1.GetFocusedRowCellValue("VehicleId").ToString();

                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

    }

}
