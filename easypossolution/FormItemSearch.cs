using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
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
    public partial class FormItemSearch : Form
    {
        public frmInvoice frm { set; get; }
        public FormPurchaseInvoice frm1 { set; get; }
        public FormPO frm2 { set; get; }
        public FrmBarcode frm3 { set; get; }
        public FormSalesOrder frm4 { set; get; }
        public FormStockTransfer frm5 { set; get; }
        public FormSalesReport frm6 { set; get; }
        public FormSummaryReport frm7 { set; get; }
        public FRMItemSpoilage frm8 { set; get; }
        public FormProductConversion frm9 { set; get; }
        public FormGIN frm11 { set; get; }
        public FormFG frm12 { set; get; }
        public FormPriceUpdate frm13 { set; get; }
        public FormStockAdjustment frm14 { set; get; }
        public FormInvoiceTuch frm15 { set; get; }
        public StockDetails frm16 { set; get; }

        public int form;
        public int wh = 1;
        private TextBox lastTB = null;
        public bool load = false;


        public FormItemSearch()
        {
            InitializeComponent();
        }

        private void KeyEnterFunction()
        {
            try
            {
                if (this.gridView1.GetFocusedRowCellValue("ItemCode") == null)
                    return;
                    frm15.txtItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    //frm.ItemcodeKeyDown();
                    frm15.txtItemCode.Select();

                this.Close();
            }
            catch
            {
            }

        }

        private void fillGridAllCustomers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.BranchId = Convert.ToInt32(wh.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveStockAllitemData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //if (lblUserId.Text != "3")
                    //{
                    //    gridView1.Columns["BranchQty"].FilterInfo = new ColumnFilterInfo("[BranchQty] > '1'");
                    //}
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["PurchasePrice"].Visible = false;
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

        private void fillGriStockByCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxSearchItemCode.Text;
                objPOBAL.BranchId = Convert.ToInt32(wh.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveSearchStockByCode(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //if (lblUserId.Text != "3")
                    //{
                    //    gridView1.Columns["BranchQty"].FilterInfo = new ColumnFilterInfo("[BranchQty] > '1'");
                    //}
                    gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["PurchasePrice"].Visible = false;
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
                objPOBAL.BranchId = Convert.ToInt32(wh.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveSearchStockByName(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //if (lblUserId.Text != "3")
                    //{
                        //gridView1.Columns["BranchQty"].FilterInfo = new ColumnFilterInfo("[BranchQty] > '1'");
                    //}
                    gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["PurchasePrice"].Visible = false;
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

        private void loadCatData()
        {
            if (load == false && comboBoxCategorySearch.SelectedIndex != -1 && comboBoxCategorySearch.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemName = textBoxSearchName.Text;
                    objPOBAL.BranchId = Convert.ToInt32(wh.ToString());
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                    ClassPODAL objPODAL = new ClassPODAL();
                    gridControl1.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveSearchStockByCat(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //if (lblUserId.Text != "3")
                        //{
                        //gridView1.Columns["BranchQty"].FilterInfo = new ColumnFilterInfo("[BranchQty] > '1'");
                        //}
                        gridView1.Columns["ItemsId"].Visible = false;
                        gridView1.Columns["PurchasePrice"].Visible = false;
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
        }

        public static Control FindFocusedControl(Control control)
        {
            //try
            //{
            ContainerControl container = control as ContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as ContainerControl;
            }
            return control;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void FormItemSearch_Load(object sender, EventArgs e)
        {
            //fillGridAllCustomers();
            load = true;
            ClassPOBAL objPOBAL = new ClassPOBAL();
            ClassPODAL objPODAL = new ClassPODAL();
            comboBoxCategorySearch.DataSource = objPODAL.retreiveAllCategoryData(objPOBAL).Tables[0];
            comboBoxCategorySearch.DisplayMember = "ItemCatName";
            comboBoxCategorySearch.ValueMember = "ItemCatId";
            comboBoxCategorySearch.SelectedIndex = -1;
            textBoxSearchName.Select();
            load = false;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("ItemCode") == null)
                    return;
                if (form == 1)
                {
                    frm1.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm1.ItemCodeKeyDown();
                }
                else if (form == 2)
                {
                    frm2.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm2.ItemCodeKeyDown();
                }
                else if (form == 3)
                {
                    frm3.textBoxItemCode1.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm3.ItemCodeKeyDown();
                }
                else if (form == 4)
                {
                    frm4.txtItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm4.ItemcodeKeyDown();
                }
                else if (form == 5)
                {
                    frm5.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm5.ItemcodeKeyDown();
                }
                else if (form == 6)
                {
                    frm6.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    //frm6.ItemcodeKeyDown();
                }
                else if (form == 7)
                {
                    frm7.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    //frm6.ItemcodeKeyDown();
                }
                else if (form == 8)
                {
                    frm8.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    //frm6.ItemcodeKeyDown();
                }
                else if (form == 9)
                {
                    frm9.textBoxFromItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                    frm9.textBoxFromItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm9.textBoxFromItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                    frm9.textBoxFromQty.Text = this.gridView1.GetFocusedRowCellValue("BranchQty").ToString();
                }
                else if (form == 10)
                {
                    frm9.textBoxToItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                    frm9.textBoxToItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm9.textBoxToItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                    frm9.textBoxToQty.Text = this.gridView1.GetFocusedRowCellValue("BranchQty").ToString();
                }
                else if (form == 11)
                {
                    frm11.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm11.ItemCodeKeyDown();
                }
                else if (form == 12)
                {
                    frm12.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm12.ItemCodeKeyDown();
                }
                else if (form == 13)
                {
                    frm13.textBoxItemCode1.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm13.ItemCodeKeyDown();
                }
                else if (form == 14)
                {
                    frm14.textBoxFromItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                    frm14.textBoxFromItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm14.textBoxSearchItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    frm14.textBoxFromItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                    frm14.textBoxAvailableQty.Text = this.gridView1.GetFocusedRowCellValue("BranchQty").ToString();
                    frm14.textBoxFromNewQty.Select();
                }
                else if (form == 15)
                {
                    frm15.txtItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    //frm.ItemcodeKeyDown();
                    frm15.txtItemCode.Select();
                }
                else if (form == 16)
                {
                    frm16.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    //frm.ItemcodeKeyDown();
                    frm16.textBoxItemCode.Select();
                }
                else
                {
                    frm.txtItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                    //frm.ItemcodeKeyDown();
                    frm.txtItemCode.Select();
                }
                
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

        private void FormItemSearch_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F3)
            {
                comboBoxCategorySearch.Select();
            }
        }

        private void textBoxSearchItemCode_TextChanged(object sender, EventArgs e)
        {
            //fillGriStockByCode();
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            //fillGriStockByName();
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

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnA.Text.Trim();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnB.Text.Trim();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnC.Text.Trim();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnD.Text.Trim();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnE.Text.Trim();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnF.Text.Trim();
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnG.Text.Trim();
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnH.Text.Trim();
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnI.Text.Trim();
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnJ.Text.Trim();
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnK.Text.Trim();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnL.Text.Trim();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnM.Text.Trim();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnN.Text.Trim();
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnO.Text.Trim();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnP.Text.Trim();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnQ.Text.Trim();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnR.Text.Trim();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnS.Text.Trim();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnT.Text.Trim();
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnU.Text.Trim();
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnV.Text.Trim();
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnW.Text.Trim();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnX.Text.Trim();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnY.Text.Trim();
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            lastTB.Text += btnZ.Text.Trim();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn0.Text.Trim();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn1.Text.Trim();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn2.Text.Trim();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn3.Text.Trim();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn4.Text.Trim();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn5.Text.Trim();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn6.Text.Trim();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn7.Text.Trim();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn8.Text.Trim();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lastTB.Text += btn9.Text.Trim();
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            lastTB.Text += btndot.Text.Trim();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lastTB.Text += " ";
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if (lastTB.Text.Length > 0)
            {
                //CONTINUE TO CLEAR TEXT UNTIL NOTHING IS REMAIN
                lastTB.Text = lastTB.Text.Substring(0, lastTB.Text.Length - 1);

            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (lastTB == textBoxSearchItemCode)
            {
                fillGriStockByCode();
                textBox1.Select();
                gridControl1.Select();
            }
            else if (lastTB == textBoxSearchName)
            {
                fillGriStockByName();
                textBox1.Select();
                gridControl1.Select();
            }
            else
            {
                KeyEnterFunction();
            }
            //SendKeys.Send("{ENTER}");
            
        }

        private void textBoxSearchItemCode_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBoxSearchName_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            lastTB = (TextBox)sender;
        }

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCatData();
        }

        private void comboBoxCategorySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //loadCatData();

                gridControl1.Select();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("ItemCode") == null)
                return;
            if (form == 1)
            {
                frm1.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm1.ItemCodeKeyDown();
            }
            else if (form == 2)
            {
                frm2.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm2.ItemCodeKeyDown();
            }
            else if (form == 3)
            {
                frm3.textBoxItemCode1.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm3.ItemCodeKeyDown();
            }
            else if (form == 4)
            {
                frm4.txtItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm4.ItemcodeKeyDown();
            }
            else if (form == 5)
            {
                frm5.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm5.ItemcodeKeyDown();
            }
            else if (form == 6)
            {
                frm6.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                //frm6.ItemcodeKeyDown();
            }
            else if (form == 7)
            {
                frm7.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                //frm6.ItemcodeKeyDown();
            }
            else if (form == 8)
            {
                frm8.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                //frm6.ItemcodeKeyDown();
            }
            else if (form == 9)
            {
                frm9.textBoxFromItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                frm9.textBoxFromItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm9.textBoxFromItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                frm9.textBoxFromQty.Text = this.gridView1.GetFocusedRowCellValue("BranchQty").ToString();
            }
            else if (form == 10)
            {
                frm9.textBoxToItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                frm9.textBoxToItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm9.textBoxToItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                frm9.textBoxToQty.Text = this.gridView1.GetFocusedRowCellValue("BranchQty").ToString();
            }
            else if (form == 11)
            {
                frm11.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm11.ItemCodeKeyDown();
            }
            else if (form == 12)
            {
                frm12.textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm12.ItemCodeKeyDown();
            }
            else if (form == 13)
            {
                frm13.textBoxItemCode1.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm13.ItemCodeKeyDown();
            }
            else if (form == 14)
            {
                frm14.textBoxFromItemId.Text = this.gridView1.GetFocusedRowCellValue("ItemsId").ToString();
                frm14.textBoxFromItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm14.textBoxSearchItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                frm14.textBoxFromItemName.Text = this.gridView1.GetFocusedRowCellValue("ItemName").ToString();
                frm14.textBoxAvailableQty.Text = this.gridView1.GetFocusedRowCellValue("BranchQty").ToString();
                frm14.textBoxFromNewQty.Select();
            }
            else if (form == 15)
            {
                frm15.txtItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                //frm.ItemcodeKeyDown();
                frm15.txtItemCode.Select();
            }
            else
            {
                frm.txtItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
                //frm.ItemcodeKeyDown();
                frm.txtItemCode.Select();
            }

            this.Close();
        }
    }
}
