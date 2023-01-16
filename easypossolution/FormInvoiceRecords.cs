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
    public partial class FormInvoiceRecords : Form
    {
        public frmInvoice frm { set; get; }

        public FormInvoiceRecords()
        {
            InitializeComponent();
        }

        private void GetAllSalesOrders()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.date1 = dateTimePickerFrom.Value;
                objPOBAL.date2 = dateTimePickerTo.Value;
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllSalesInvoices(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Purchasing"].Visible = false;
                    //gridView1.Columns["Discount"].Visible = false;
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

        private void GetAllOrders()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllInvoices(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Purchasing"].Visible = false;
                    //gridView1.Columns["Discount"].Visible = false;
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

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            GetAllSalesOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllOrders();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("InvoiceNo") == null)
                    return;
                frm.txtInvoiceNo.Text = this.gridView1.GetFocusedRowCellValue("InvoiceNo").ToString();
                frm.textBoxExInvoiceNo.Text = this.gridView1.GetFocusedRowCellValue("InvoiceNo").ToString();
                this.Close();
                //MessageBox.Show(this.gridView1.GetFocusedRowCellValue("ItemCode").ToString());
            }
        }
    }
}
