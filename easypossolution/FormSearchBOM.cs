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
    public partial class FormSearchBOM : Form
    {
        public FormProduction frm { set; get; }
        public int form;

        public FormSearchBOM()
        {
            InitializeComponent();
        }

        private void fillGriStockByCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxSearchItemCode.Text;
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveSearchBOMByCode(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //if (lblUserId.Text != "3")
                    //{
                    //    gridView1.Columns["BranchQty"].FilterInfo = new ColumnFilterInfo("[BranchQty] > '1'");
                    //}
                    gridView1.Columns["ItemsId"].Visible = false;
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

        private void fillGriStockByName()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemName = textBoxSearchName.Text;
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveSearchBOMByName(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //if (lblUserId.Text != "3")
                    //{
                    //gridView1.Columns["BranchQty"].FilterInfo = new ColumnFilterInfo("[BranchQty] > '1'");
                    //}
                    gridView1.Columns["ItemsId"].Visible = false;
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

        private void FormSearchBOM_Load(object sender, EventArgs e)
        {
            textBoxSearchName.Select();
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

        private void FormSearchBOM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                textBoxSearchItemCode.Select();
            }
            else if (e.KeyCode == Keys.F2)
            {
                textBoxSearchName.Select();
            }
        }

        private void textBoxSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillGriStockByName();
                gridControl1.Select();
            }
        }

        private void textBoxSearchItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillGriStockByCode();
                gridControl1.Select();
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("BOMId") == null)
                    return;
                if (form == 1)
                {
                    frm.textBoxPOID.Text = this.gridView1.GetFocusedRowCellValue("BOMId").ToString();
                    frm.BOMIdKeyDown();
                    frm.BOMIDDetailKeyDown();
                }
                this.Close();
            }
        }
    }
}
