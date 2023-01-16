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
    public partial class FormRetailPrices : Form
    {
        public frmInvoice frm { set; get; }
        public FormInvoiceTuch frm1 { set; get; }
        public int ItemId, PriceMode;
        public int form;
        

        public FormRetailPrices()
        {
            InitializeComponent();
        }

        private void fillRetailPriceGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = ItemId;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                gridControl1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveRetailPrices(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objInvBAL.DtDataSet.Tables[0];

                    gridView1.Columns["ItemRtPriceId"].Visible = false;
                    gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["ItemCode"].Visible = false;
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

        private void fillWholesalePriceGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = ItemId;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                gridControl1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveWholesalePrices(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objInvBAL.DtDataSet.Tables[0];

                    gridView1.Columns["ItemWHPriceId"].Visible = false;
                    gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["ItemCode"].Visible = false;
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

        private void fillShopPriceGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = ItemId;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                gridControl1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveShopPrices(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objInvBAL.DtDataSet.Tables[0];

                    gridView1.Columns["ShopPriceId"].Visible = false;
                    gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["ItemCode"].Visible = false;
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

        private void FormRetailPrices_Load(object sender, EventArgs e)
        {
            if (PriceMode == 1)
            {
                fillRetailPriceGrid();
            }
            else if (PriceMode == 2)
            {
                fillWholesalePriceGrid();
            }
            else
            {
                fillShopPriceGrid();
            }
        }

        private void FormRetailPrices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("ItemCode") == null)
                    return;
                if (PriceMode == 1)
                {
                    if (form == 1)
                    {
                        frm1.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("RetailPrice").ToString();
                    }
                    else
                    {
                        frm.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("RetailPrice").ToString();
                    }
                    
                }
                else if (PriceMode == 2)
                {
                    if (form == 1)
                    {
                        frm1.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("WholesalePrice").ToString();
                    }
                    else
                    {
                        frm.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("WholesalePrice").ToString();
                    }
                    
                }
                else
                {
                    if (form == 1)
                    {
                        frm1.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("ShopPrice").ToString();
                    }
                    else
                    {
                        frm.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("ShopPrice").ToString();
                    }
                    
                }

                this.Close();
            }     
        }

        private void FormRetailPrices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("ItemCode") == null)
                return;
            if (PriceMode == 1)
            {
                if (form == 1)
                {
                    frm1.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("RetailPrice").ToString();
                }
                else
                {
                    frm.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("RetailPrice").ToString();
                }

            }
            else if (PriceMode == 2)
            {
                if (form == 1)
                {
                    frm1.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("WholesalePrice").ToString();
                }
                else
                {
                    frm.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("WholesalePrice").ToString();
                }

            }
            else
            {
                if (form == 1)
                {
                    frm1.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("ShopPrice").ToString();
                }
                else
                {
                    frm.txtSellingPrice.Text = this.gridView1.GetFocusedRowCellValue("ShopPrice").ToString();
                }

            }

            this.Close();
        }
    }
}
