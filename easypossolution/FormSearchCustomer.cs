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
    public partial class FormSearchCustomer : Form
    {
        #region Local Variables

        public frmInvoice frm { set; get; }
        public FormSalesOrder frm1 { set; get; }
        public FormCustomerCreditPayment frm2 { set; get; }
        public FormInvoiceTuch frm3 { set; get; }

        public int form;

        #endregion

        #region Constructor
        public FormSearchCustomer()
        {
            InitializeComponent();
        }

        #endregion

        private void FormSearchCustomer_Load(object sender, EventArgs e)
        {
            fillGridAllCustomers();
            textBoxSearchCustomer.Select();
        }

        #region Methods

        private void fillGridAllCustomers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllCustomers(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView1.Columns["CustomerId"].Visible = false;
                    gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["CustomerFaxNo"].Visible = false;
                    gridView1.Columns["CustomerEmail"].Visible = false;
                    gridView1.Columns["CustomerNICNo"].Visible = false;
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

        private void fillGridAllCustomersByName()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CustomerName = textBoxSearchCustomer.Text;
                ClassMasterDAL objDAL = new ClassMasterDAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllCustomersByName(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView1.Columns["CustomerId"].Visible = false;
                    gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["CustomerFaxNo"].Visible = false;
                    gridView1.Columns["CustomerEmail"].Visible = false;
                    gridView1.Columns["CustomerNICNo"].Visible = false;
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

        private void FormSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //frm.lblCashTender.Select();
                this.Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                textBoxSearchCustomer.Select();
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("CustomerCode") == null)
                    return;
                if (form == 1)
                {
                    frm1.textBoxCustCode.Text = this.gridView1.GetFocusedRowCellValue("CustomerCode").ToString();
                    frm1.searchCustomer();
                    frm1.txtItemCode.Select();
                }
                else if (form == 2)
                {
                    frm2.comboBoxCustomer.SelectedValue = this.gridView1.GetFocusedRowCellValue("CustomerId").ToString();
                    //frm2.searchCustomer();
                    //frm2.txtItemCode.Select();
                }
                else if (form == 3)
                {
                    frm3.textBoxCustCode.Text = this.gridView1.GetFocusedRowCellValue("CustomerCode").ToString();
                    frm3.searchCustomer();
                    frm3.lblCashTender.Select();
                }
                else
                {
                    frm.textBoxCustCode.Text = this.gridView1.GetFocusedRowCellValue("CustomerCode").ToString();
                    frm.searchCustomer();
                    frm.lblCashTender.Select();
                }
                
                this.Close();
                //MessageBox.Show(this.gridView1.GetFocusedRowCellValue("ItemCode").ToString());
            }
        }

        private void textBoxSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            fillGridAllCustomersByName();
        }

        private void textBoxSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridControl1.Select();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
                if (this.gridView1.GetFocusedRowCellValue("CustomerCode") == null)
                    return;
                if (form == 1)
                {
                    frm1.textBoxCustCode.Text = this.gridView1.GetFocusedRowCellValue("CustomerCode").ToString();
                    frm1.searchCustomer();
                    frm1.txtItemCode.Select();
                }
                else if (form == 2)
                {
                    frm2.comboBoxCustomer.SelectedValue = this.gridView1.GetFocusedRowCellValue("CustomerId").ToString();
                    //frm2.searchCustomer();
                    //frm2.txtItemCode.Select();
                }
                else if (form == 3)
                {
                    frm3.textBoxCustCode.Text = this.gridView1.GetFocusedRowCellValue("CustomerCode").ToString();
                    frm3.searchCustomer();
                    frm3.lblCashTender.Select();
                }
                else
                {
                    frm.textBoxCustCode.Text = this.gridView1.GetFocusedRowCellValue("CustomerCode").ToString();
                    frm.searchCustomer();
                    frm.lblCashTender.Select();
                }

                this.Close();
                //MessageBox.Show(this.gridView1.GetFocusedRowCellValue("ItemCode").ToString());
            //}
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}
