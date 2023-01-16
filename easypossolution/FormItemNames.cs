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
    public partial class FormItemNames : Form
    {
        public frmInvoice frm { set; get; }
        public FormStockTransfer frm1 { set; get; }
        public FrmBarcode frm2 { set; get; }
        public FormPurchaseInvoice frm3 { set; get; }
        public FRMItemSpoilage frm4 { set; get; }
        public FormInvoiceTuch frm5 { set; get; }

        public int form;
        public string ItemCode;

        public FormItemNames()
        {
            InitializeComponent();
        }

        private void fillItemNamesGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemCode = ItemCode.ToString();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                gridControl1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveItemVariantData(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objInvBAL.DtDataSet.Tables[0];
                   
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

        private void FormItemNames_Load(object sender, EventArgs e)
        {
            fillItemNamesGrid();
        }

        private void FormItemNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("ItemsId") == null)
                    return;
                if (form == 1)
                {
                    frm1.textBoxItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                    frm1.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                }
                //else if (form == 2)
                //{
                //    frm2.txtItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                //    frm2.textBoxItemName1.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                //}
                else if (form == 3)
                {
                    frm3.textBoxItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                    frm3.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                }
                //else if (form == 4)
                //{
                //    frm4.textBoxItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                //    frm4.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                //}
                else if (form == 5)
                {
                    frm5.txtItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                    //frm5.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                }
                else
                {
                    frm.txtItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                    //frm.txtItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                }
                

                this.Close();
            } 
        }

        private void FormItemNames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("ItemsId") == null)
                return;
            if (form == 1)
            {
                frm1.textBoxItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                frm1.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
            }
            //else if (form == 2)
            //{
            //    frm2.txtItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
            //    frm2.textBoxItemName1.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
            //}
            else if (form == 3)
            {
                frm3.textBoxItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                frm3.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
            }
            //else if (form == 4)
            //{
            //    frm4.textBoxItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
            //    frm4.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
            //}
            else if (form == 5)
            {
                frm5.txtItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                //frm5.textBoxItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
            }
            else
            {
                frm.txtItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                //frm.txtItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
            }


            this.Close();
        }

    }
}
