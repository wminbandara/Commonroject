using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class FormFindInvoice : Form
    {
        public FormSalesReturn frm { set; get; }
        public string VehicleNo;

        public FormFindInvoice()
        {
            InitializeComponent();
        }

        public void fillGridVehicleInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.VehicleNo = VehicleNo.ToString();
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveVehicleInvoiceData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("BillNo") == null)
                    return;
                frm.textBoxBillNo.Text = this.gridView1.GetFocusedRowCellValue("BillNo").ToString();
                    //frm.ItemcodeKeyDown();
                this.Close();
                //MessageBox.Show(this.gridView1.GetFocusedRowCellValue("ItemCode").ToString());
            }
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridView view = (sender as GridControl).FocusedView as GridView;
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            GridColumnInfoArgs ci1 = viewInfo.ColumnsInfo.FirstColumnInfo;
            GridColumnInfoArgs ci2 = viewInfo.ColumnsInfo.LastColumnInfo;
            if (e.Shift && e.KeyCode == Keys.Tab)
            {
                if (ci1.Column == view.FocusedColumn)
                {
                    view.UnselectRow(view.FocusedRowHandle);
                    view.FocusedColumn = ci2.Column;
                    view.FocusedRowHandle = view.FocusedRowHandle - 1;
                    e.Handled = true;
                }
            }
        }

        private void FormFindInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
