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
    public partial class FormCreditPayCheques : Form
    {
        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        public FormSupplierCreditPayment frm { set; get; }
        bool loadStatus;

        public FormCreditPayCheques()
        {
            InitializeComponent();
        }

        private void FormCreditPayCheques_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxCustomer.DataSource = objDAL.retreiveAllCustomers(objBAL).Tables[0];
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerId";
                comboBoxCustomer.SelectedIndex = -1;

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxCustomer.SelectedIndex != -1)
            {
                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveCustomerChqDataByID(objBAL);
                gridControl1.DataSource = null;
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    gridView1.Columns["CustomerId"].Visible = false;
                }
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
                if (this.gridView1.GetFocusedRowCellValue("ChequeNo") == null)
                    return;
                frm.ChequeNo = this.gridView1.GetFocusedRowCellValue("ChequeNo").ToString();
                frm.ChqAmount = this.gridView1.GetFocusedRowCellValue("ChequeAmount").ToString();
                frm.CustomerID = this.gridView1.GetFocusedRowCellValue("CustomerId").ToString();
                frm.textBoxChequeAmount.Text = this.gridView1.GetFocusedRowCellValue("ChequeAmount").ToString();
                this.Close();
                //MessageBox.Show(this.gridView1.GetFocusedRowCellValue("ItemCode").ToString());
            }
        }

        private void simpleButtonAll_Click(object sender, EventArgs e)
        {
            try
            {
                objBAL = new ClassCommonBAL();
                //objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveAllCustomerChq(objBAL);
                gridControl1.DataSource = null;
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    gridView1.Columns["CustomerId"].Visible = false;

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
