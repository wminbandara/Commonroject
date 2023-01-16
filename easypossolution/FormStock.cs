using DevExpress.XtraGrid.Views.Grid;
using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormStock : Form
    {
        #region Local Variables

        ClassPOBAL objPOBAL = new ClassPOBAL();
        ClassPODAL objPODAL = new ClassPODAL();

        ArrayList alistForm = new ArrayList();

        bool loadStatus;
        int TempId = 0;

        #endregion

        #region Constructor

        public FormStock()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void DeleteBarcode()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.BarcodeId = TempId;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteBarcode(objInvBAL);
                if (count != 0)
                {
                    fillBarcodeGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertBarcode()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.ItemCode = textBoxItemCode.Text;
                objBAL.Barcode = textBoxBarcode.Text;
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertBarcode(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Barcode Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillBarcodeGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillBarcodeGrid()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveBarcodes(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objInvBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["BarcodeId"].Visible = false;
                    //dataGridView1.Columns["ItemsId"].Visible = false;
                    //dataGridView1.Columns["ItemCode"].Visible = false;
                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBarcode()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objPOBAL.ItemCode = textBoxItemCode.Text;

                objPODAL = new ClassPODAL();
                int count = objPODAL.UpdateBarcode(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Code Updated Successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetDetail();
                    //fillItemsGridAll();
                }
                else
                {
                    MessageBox.Show("Item code can not update.", "Update Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    if (radioButtonOpen.Checked == true)
                    {
                        objPOBAL.OpenStates = 1;
                    }
                    else
                    {
                        objPOBAL.OpenStates = 0;
                    }
                    objPOBAL.ItemStatus = "Open";
                    objPOBAL.ItemsId = Convert.ToInt32(gridView1.GetRowCellValue(i, "ItemsId").ToString());
                    objPOBAL.ItemCode = gridView1.GetRowCellValue(i, "ItemCode").ToString();
                    objPOBAL.BranchId = Convert.ToInt32(gridView1.GetRowCellValue(i, "BranchId").ToString());
                    objPOBAL.ItemName = gridView1.GetRowCellValue(i, "ItemName").ToString();
                    objPOBAL.CostPrice = Convert.ToDecimal(gridView1.GetRowCellValue(i, "CostPrice").ToString());
                    objPOBAL.DefaultCostPrice = Convert.ToDecimal(gridView1.GetRowCellValue(i, "CostPrice").ToString());
                    objPOBAL.SellingPrice = Convert.ToDecimal(gridView1.GetRowCellValue(i, "RetailPrice").ToString());
                    objPOBAL.SellingPrice2 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "WholesalePrice").ToString());
                    objPOBAL.ShopPrice = Convert.ToDecimal(gridView1.GetRowCellValue(i, "ShopPrice").ToString());
                    objPOBAL.MinQty = Convert.ToDecimal(gridView1.GetRowCellValue(i, "MinQty").ToString());
                    objPOBAL.AvailableQty = Convert.ToDecimal(gridView1.GetRowCellValue(i, "BranchQty").ToString());
                    objPOBAL.RackNo = gridView1.GetRowCellValue(i, "RackNo").ToString();
                    ClassPODAL objPODAL = new ClassPODAL();
                    int count = objPODAL.UpdateAllStock(objPOBAL);

                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }
                }
                if (insertDTStatus == true)
                {
                    MessageBox.Show("Items Updated Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridControl1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userPermission()
        {
            try
            {
                buttonUpdateAll.Enabled = false;
                buttonDelete.Enabled = false;

                BALUser objUser = new BALUser();
                //objUser.FORM_NAME = "User Registration";
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveUserPermission(objUser);
                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objUser.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        alistForm.Add(values[0].ToString());

                    }
                    for (int i = 0; i < alistForm.Count; i++)
                    {
                        //if (alistForm[i].ToString().Trim() == "ChangePrice")
                        //{
                        //    txtSellingPrice.ReadOnly = false;
                        //}
                        if (alistForm[i].ToString().Trim() == "UpdateStock")
                        {
                            buttonUpdateAll.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "DeleteStock")
                        {
                            buttonDelete.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertSubCategory()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ItemCatId = Convert.ToInt32(textBoxCategory.SelectedValue.ToString());
                objBAL.CatDescription = textBoxSubCat.Text.Trim();

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertItemSubCategory(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Sub Category Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategory();
                    textBoxSubCat.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createItemCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string ID = "";

                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveMaxItemId(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        if (comboBoxItemCategory.SelectedIndex == -1)
                        {
                            ID = (Convert.ToInt32(values[0])).ToString("0000000");
                        }
                        else if (comboBoxItemCategory.SelectedIndex != -1 && comboBoxSubCat.SelectedIndex == -1)
                        {
                            ID = comboBoxItemCategory.Text.Substring(0, 2) + (Convert.ToInt32(values[0])).ToString("00000");
                        }
                        else if (comboBoxItemCategory.SelectedIndex != -1 && comboBoxSubCat.SelectedIndex != -1)
                        {
                            ID = comboBoxItemCategory.Text.Substring(0, 2) + (Convert.ToInt32(values[0])).ToString("0000") + comboBoxSubCat.Text.Substring(0, 1);
                        }
                    }
                }
                textBoxItemCode.Text = (ID).ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxSubCat.SelectedIndex = -1;
            comboBoxBranch.SelectedIndex = 0;
            textBoxItemId.Clear();
            textBoxItemName.Clear();
            textBoxItemNameS.Clear();
            textBoxDiscount.Text = "0.00";
            textBoxWholesaleDisc.Text = "0.00";
            comboBoxUnit.Text = "Nos";
            textBoxWarranty.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxDefPurchasePrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxMinSellingPrice.Text = "0.00";
            textBoxPrice2.Text = "0.00";
            textBoxSPPriceEffectFrom.Text = "0.00";
            textBoxMinQty.Text = "0";
            textBoxMaintainQty.Text = "0";
            textBoxQty.Text = "0";
            comboBoxItemMode.Text = "";
            labelNet.Text = "0";
            labelQty.Text = "0";
            labelQtyDiff.Text = "0";
            labelNetDiff.Text = "0";
            textBoxFreeIssue.Text = "0";
            //comboBoxWharehouse.Text = "";
            comboBoxSupplier.SelectedIndex = 0;
            textBoxRackNo.Text = "0";
            textBoxShopPrice.Text = "0.00";
            textBoxRetailDiscPer.Text = "0";
            textBoxWholesaleDiscPer.Text = "0";
            textBoxItemNameT.Clear();
            checkBoxBundleItem.Checked = false;
            checkBoxScaleItem.Checked = false;
            checkBoxRawMaterial.Checked = false;
        }

        private void resetItemCodeDataV()
        {
            comboBoxItemCategoryV.SelectedIndex = -1;
            comboBoxSubCatV.SelectedIndex = -1;
            textBoxItemIdV.Clear();
            textBoxItemNameV.Clear();
            textBoxItemNameSV.Clear();
            textBoxDiscountV.Text = "0.00";
            textBoxWholesaleDiscV.Text = "0.00";
            comboBoxUnitV.Text = "Nos";
            //textBoxWarranty.Text = "";
            textBoxUnitCostPriceV.Text = "0.00";
            //textBoxDefPurchasePriceV.Text = "0.00";
            textBoxSellingPriceV.Text = "0.00";
            textBoxMinSellingPriceV.Text = "0.00";
            textBoxPrice2V.Text = "0.00";
            //textBoxSPPriceEffectFromV.Text = "0.00";
            textBoxMinQtyV.Text = "0";
            textBoxMaintainQty.Text = "0";
            textBoxQtyV.Text = "0";
            //comboBoxItemModeV.Text = "";
            //labelNet.Text = "0";
            //labelQty.Text = "0";
            //labelQtyDiff.Text = "0";
            //labelNetDiff.Text = "0";
            textBoxFreeIssueV.Text = "0";
            //comboBoxWharehouse.Text = "";
            //comboBoxSupplierV.SelectedIndex = 0;
            textBoxRackNoV.Text = "0";
            textBoxShopPriceV.Text = "0.00";
            textBoxRetailDiscPerV.Text = "0";
            textBoxWholesaleDiscPerV.Text = "0";
            textBoxConvertionQty.Text = "0.00";
        }


        //private void checkMinQty()
        //{
        //    try
        //    {
        //        if (dataGridView1.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //            {
        //                if (Convert.ToDecimal(dataGridView1["AvailableQty", i].Value.ToString()) <= Convert.ToDecimal(dataGridView1["MinQty", i].Value.ToString()))
        //                {
        //                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
        //                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void fillItemsGridAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;                
                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["Purchasing"].Visible = false;
                    //gridView1.Columns["Discount"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }
                //dataGridView1.DataSource = null;
                //objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                //if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                //{
                //    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                //    //dataGridView1.Columns["ItemLocation"].Visible = false;
                //    //dataGridView1.Columns["Wharehouse"].Visible = false;
                //    dataGridView1.Columns["Purchasing"].Visible = false;
                //    dataGridView1.Columns["Discount"].Visible = false;
                //    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                //    checkMinQty();
                //}
                
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillMinItemsGridAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[3].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[3];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    gridView1.Columns["Purchasing"].Visible = false;
                    //gridView1.Columns["Discount"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }
                //dataGridView1.DataSource = null;
                //objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                //if (objPOBAL.DtDataSet.Tables[3].Rows.Count > 0)
                //{
                //    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[3];
                //    //dataGridView1.Columns["ItemLocation"].Visible = false;
                //    //dataGridView1.Columns["Wharehouse"].Visible = false;
                //    //dataGridView1.Columns["SellingPrice"].Visible = false;
                //    dataGridView1.Columns["Purchasing"].Visible = false;
                //    dataGridView1.Columns["Discount"].Visible = false;
                //    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                //}

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridByCat()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByCat(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["Purchasing"].Visible = false;
                    //gridView1.Columns["Discount"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }
                //dataGridView1.DataSource = null;
                //objPOBAL.DtDataSet = objPODAL.retreiveItemsByCat(objPOBAL);
                //if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                //{
                //    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                //    //dataGridView1.Columns["ItemLocation"].Visible = false;
                //    //dataGridView1.Columns["ItemUnit"].Visible = false;
                //    //dataGridView1.Columns["Wharehouse"].Visible = false;
                //    //dataGridView1.Columns["SellingPrice"].Visible = false;
                //    dataGridView1.Columns["Purchasing"].Visible = false;
                //    dataGridView1.Columns["Discount"].Visible = false;
                //    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                //    checkMinQty();
                //}

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridByCode()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
                objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByCode(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["Purchasing"].Visible = false;
                    //gridView1.Columns["Discount"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }
                //dataGridView1.DataSource = null;
                //objPOBAL.DtDataSet = objPODAL.retreiveItemsByCode(objPOBAL);
                //if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                //{
                //    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                //    //dataGridView1.Columns["ItemLocation"].Visible = false;
                //    //dataGridView1.Columns["ItemUnit"].Visible = false;
                //    //dataGridView1.Columns["Wharehouse"].Visible = false;
                //    //dataGridView1.Columns["SellingPrice"].Visible = false;
                //    dataGridView1.Columns["Purchasing"].Visible = false;
                //    dataGridView1.Columns["Discount"].Visible = false;
                //    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                //    checkMinQty();
                //}

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridByName()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemName = textBoxSearchName.Text.Trim();
                objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByName(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    //gridView1.Columns["Purchasing"].Visible = false;
                    //gridView1.Columns["Discount"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }
                //dataGridView1.DataSource = null;
                //objPOBAL.DtDataSet = objPODAL.retreiveItemsByName(objPOBAL);
                //if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                //{
                //    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                //    //dataGridView1.Columns["ItemLocation"].Visible = false;
                //    //dataGridView1.Columns["ItemUnit"].Visible = false;
                //    //dataGridView1.Columns["Wharehouse"].Visible = false;
                //    //dataGridView1.Columns["SellingPrice"].Visible = false;
                //    dataGridView1.Columns["Purchasing"].Visible = false;
                //    dataGridView1.Columns["Discount"].Visible = false;
                //    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                //    checkMinQty();
                //}

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            textBoxItemNameS.Clear();
            comboBoxUnit.Text = "Nos";
            textBoxWarranty.Text = "";
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxSubCat.SelectedIndex = -1;
            comboBoxBranch.SelectedIndex = 0;
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxMaintainQty.Text = "0";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxDefPurchasePrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxMinSellingPrice.Text = "0.00";
            textBoxPrice2.Text = "0.00";
            textBoxSPPriceEffectFrom.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            comboBoxItemMode.Text = "";
            labelNet.Text = "0";
            labelQty.Text = "0";
            labelQtyDiff.Text = "0";
            labelNetDiff.Text = "0";
            textBoxFreeIssue.Text = "0";
            comboBoxSupplier.SelectedIndex = 0;
            textBoxRackNo.Text = "0";
            textBoxShopPrice.Text = "0.00";
            textBoxItemNameT.Clear();
            checkBoxScaleItem.Checked = false;
            checkBoxBundleItem.Checked = false;
            checkBoxRawMaterial.Checked = false;

            checkBoxAllowSales.Checked = true;
            checkBoxAllowPurchase.Checked = true;
            checkBoxAllowInventory.Checked = true;
        }

        private void resetDetailV()
        {
            textBoxItemIdV.Clear();
            textBoxItemCodeV.Clear();
            textBoxItemNameV.Clear();
            textBoxItemNameSV.Clear();
            comboBoxUnitV.Text = "Nos";
            comboBoxItemCategoryV.SelectedIndex = -1;
            comboBoxSubCatV.SelectedIndex = -1;
            comboBoxBranch.SelectedIndex = 0;
            textBoxQtyV.Text = "0";
            textBoxMinQtyV.Text = "0";
            textBoxUnitCostPriceV.Text = "0.00";
            //textBoxDefPurchasePriceV.Text = "0.00";
            textBoxSellingPriceV.Text = "0.00";
            textBoxMinSellingPriceV.Text = "0.00";
            textBoxPrice2V.Text = "0.00";
            //textBoxSPPriceEffectFromV.Text = "0.00";
            textBoxNetAmountV.Text = "0.00";
            //comboBoxItemMode.Text = "";
            //labelNetV.Text = "0";
            //labelQtyV.Text = "0";
            //labelQtyDiff.Text = "0";
            //labelNetDiff.Text = "0";
            textBoxFreeIssueV.Text = "0";
            //comboBoxSupplier.SelectedIndex = 0;
            textBoxRackNoV.Text = "0";
            textBoxShopPriceV.Text = "0.00";
            textBoxConvertionQty.Text = "0.00";
        }

        private void fillItemNetValue()
        {
            labelNetDiff.Text = "0";
            textBoxNetAmount.Text = "0.00";
            labelNetDiff.Text = "0.00";
            textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
            labelNetDiff.Text = (Convert.ToDecimal(textBoxNetAmount.Text) - Convert.ToDecimal(labelNet.Text)).ToString("0.00");
            labelQtyDiff.Text = (Convert.ToDecimal(textBoxQty.Text) - Convert.ToDecimal(labelQty.Text)).ToString("0.00");
        }

        private void fillItemNetValueV()
        {
            textBoxNetAmountV.Text = (Convert.ToDecimal(textBoxQtyV.Text) * Convert.ToDecimal(textBoxUnitCostPriceV.Text)).ToString("0.00");
        }

        private void insertPODTV()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemStatus = "Open";
                objPOBAL.ItemCode = textBoxItemCodeV.Text.Trim();
                objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategoryV.SelectedValue.ToString());
                if (comboBoxSubCatV.SelectedIndex == -1)
                {
                    comboBoxSubCatV.SelectedValue = 0;
                }
                objPOBAL.ItemSubCatId = Convert.ToInt32(comboBoxSubCatV.SelectedValue);
                objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objPOBAL.ItemName = textBoxItemNameV.Text.Trim();
                objPOBAL.SItemName = textBoxItemNameSV.Text.Trim();
                objPOBAL.Discount = Convert.ToDecimal(textBoxDiscountV.Text);
                objPOBAL.WholeSaleDiscount = Convert.ToDecimal(textBoxWholesaleDiscV.Text);
                objPOBAL.ItemUnit = comboBoxUnitV.Text.Trim();
                objPOBAL.CostPrice = Convert.ToDecimal(textBoxUnitCostPriceV.Text);
                //if (Convert.ToDecimal(textBoxDefPurchasePriceV.Text) == 0)
                //{
                objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxUnitCostPriceV.Text);
                //}
                //else
                //{
                //    objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxDefPurchasePrice.Text);
                //}

                objPOBAL.SellingPrice = Convert.ToDecimal(textBoxSellingPriceV.Text);
                objPOBAL.SellingPrice2 = Convert.ToDecimal(textBoxPrice2V.Text);
                objPOBAL.SPPRiceEffectFrom = 0;
                objPOBAL.MinQty = Convert.ToDecimal(textBoxMinQtyV.Text);
                objPOBAL.MaintainQty = Convert.ToDecimal(textBoxMaintainQtyV.Text);
                objPOBAL.AvailableQty = Convert.ToDecimal(textBoxQtyV.Text);
                objPOBAL.ItemMode = "COMMON STOCK";
                objPOBAL.OpenBalDate = dateTimePickerTranDate.Value;
                objPOBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objPOBAL.SupplierId = 1;
                objPOBAL.WarrantyPeriod = textBoxWarranty.Text.Trim();
                objPOBAL.FreeIssueEffectFrom = Convert.ToInt32(textBoxFreeIssueV.Text);
                //if (Convert.ToDecimal(labelNetDiff.Text) > 0)
                //{
                //    objPOBAL.InValue = Convert.ToDecimal(labelNetDiff.Text);
                    objPOBAL.OutValue = 0;
                //}
                //if (Convert.ToDecimal(labelNetDiff.Text) < 0)
                //{
                //    objPOBAL.OutValue = (Convert.ToDecimal(labelNetDiff.Text) * -1);
                    objPOBAL.InValue = 0;
                //}
                //if (Convert.ToDecimal(labelQtyDiff.Text) > 0)
                //{
                //    objPOBAL.InQty = Convert.ToDecimal(labelQtyDiff.Text);
                    objPOBAL.OutQty = 0;
                //}
                //if (Convert.ToDecimal(labelQtyDiff.Text) < 0)
                //{
                //    objPOBAL.OutQty = (Convert.ToDecimal(labelQtyDiff.Text) * -1);
                    objPOBAL.InQty = 0;
                //}
                if (radioButtonOpen.Checked == true)
                {
                    objPOBAL.OpenStates = 1;
                }
                if (radioButtonNew.Checked == true || radioButtonAdjust.Checked == true)
                {
                    objPOBAL.OpenStates = 0;
                }
                objPOBAL.RackNo = textBoxRackNoV.Text;
                objPOBAL.MinSellingPrice = Convert.ToDecimal(textBoxMinSellingPriceV.Text);
                objPOBAL.ShopPrice = Convert.ToDecimal(textBoxShopPriceV.Text);
                objPOBAL.RetailDiscPer = Convert.ToDecimal(textBoxRetailDiscPerV.Text);
                objPOBAL.WholesaleDiscPer = Convert.ToDecimal(textBoxWholesaleDiscPerV.Text);
                //if (textBoxItemIdV.Text == "" || Convert.ToInt32(textBoxItemIdV.Text) == 0)
                //{
                //    objPOBAL.ItemsId2 = 0;
                //}
                //else
                //{
                //    objPOBAL.ItemsId2 = Convert.ToInt32(textBoxItemIdV.Text);
                //}
                objPOBAL.MItemsId = Convert.ToInt32(textBoxItemId.Text);
                objPOBAL.MItemCode = textBoxItemCode.Text.Trim();
                objPOBAL.ConvertionQty = Convert.ToDecimal(textBoxConvertionQty.Text);
                objPODAL = new ClassPODAL();
                string count = objPODAL.InsertItemSummary(objPOBAL);
                textBoxItemIdV.Text = count.ToString();
                if (count != "")
                {
                    MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //resetDetailV();
                }
                //objPODAL = new ClassPODAL();
                //int count = objPODAL.InsertUpdateStock(objPOBAL);
                //if (count != 0)
                //{
                //    MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    resetDetail();

                //}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertItemBarcode()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                objPODAL = new ClassPODAL();
                int count = objPODAL.InsertUpdateStockBarcode(objPOBAL);
                if (count != 0)
                {
                    fillItemBarcodeGrid();
                    ExporttoCSV();
                    DeleteAllBarcodes();
                    dataGridView1.DataSource = null;
                    //System.Diagnostics.Process.Start(@"C:\CSV\Barcode.btw");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemBarcodeGrid()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveBarcodeItems(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objInvBAL.DtDataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExporttoCSV()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    csv += column.HeaderText + ',';
                }

                //Add new line.
                csv += "\r\n";

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //Add the Data rows.
                        csv += cell.Value.ToString().Replace(",", ";") + ',';
                    }

                    //Add new line.
                    csv += "\r\n";
                }

                //Exporting to CSV.
                string folderPath = "C:\\CSV\\";
                File.WriteAllText(folderPath + "BarcodeFile.csv", csv);
                MessageBox.Show("Ready to Print.");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAllBarcodes()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteAllBarcode(objInvBAL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPODT()
        {
            try
            {
                if (radioButtonOpen.Checked == true)
                {
                    objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemStatus = "Open";
                    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    if (comboBoxSubCat.SelectedIndex == -1)
                    {
                        comboBoxSubCat.SelectedValue = 0;
                    }
                    objPOBAL.ItemSubCatId = Convert.ToInt32(comboBoxSubCat.SelectedValue);
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemName = textBoxItemName.Text.Trim();
                    objPOBAL.SItemName = textBoxItemNameS.Text.Trim();
                    objPOBAL.Discount = Convert.ToDecimal(textBoxDiscount.Text);
                    objPOBAL.WholeSaleDiscount = Convert.ToDecimal(textBoxWholesaleDisc.Text);
                    objPOBAL.ItemUnit = comboBoxUnit.Text.Trim();
                    objPOBAL.CostPrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                    if (Convert.ToDecimal(textBoxDefPurchasePrice.Text) == 0)
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                    }
                    else
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxDefPurchasePrice.Text);
                    }
                    
                    objPOBAL.SellingPrice = Convert.ToDecimal(textBoxSellingPrice.Text);
                    objPOBAL.SellingPrice2 = Convert.ToDecimal(textBoxPrice2.Text);
                    objPOBAL.SPPRiceEffectFrom = Convert.ToDecimal(textBoxSPPriceEffectFrom.Text);
                    objPOBAL.MinQty = Convert.ToDecimal(textBoxMinQty.Text);
                    objPOBAL.MaintainQty = Convert.ToDecimal(textBoxMaintainQty.Text);
                    objPOBAL.AvailableQty = Convert.ToDecimal(textBoxQty.Text);
                    // objPOBAL.ItemMode = comboBoxItemMode.Text.Trim();
                    objPOBAL.ItemMode = "COMMON STOCK";
                    objPOBAL.OpenBalDate = dateTimePickerTranDate.Value;
                    objPOBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    //objPOBAL.Wharehouse = "Wharehouse1";
                    objPOBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    //objPOBAL.SupplierId = 1;
                    objPOBAL.WarrantyPeriod = textBoxWarranty.Text.Trim();
                    objPOBAL.FreeIssueEffectFrom = Convert.ToInt32(textBoxFreeIssue.Text);
                    if (Convert.ToDecimal(labelNetDiff.Text) > 0)
                    {
                        objPOBAL.InValue = Convert.ToDecimal(labelNetDiff.Text);
                        objPOBAL.OutValue = 0;
                    }
                    if (Convert.ToDecimal(labelNetDiff.Text) < 0)
                    {
                        objPOBAL.OutValue = (Convert.ToDecimal(labelNetDiff.Text) * -1);
                        objPOBAL.InValue = 0;
                    }
                    if (Convert.ToDecimal(labelQtyDiff.Text) > 0)
                    {
                        objPOBAL.InQty = Convert.ToDecimal(labelQtyDiff.Text);
                        objPOBAL.OutQty = 0;
                    }
                    if (Convert.ToDecimal(labelQtyDiff.Text) < 0)
                    {
                        objPOBAL.OutQty = (Convert.ToDecimal(labelQtyDiff.Text) * -1);
                        objPOBAL.InQty = 0;
                    }
                    if (radioButtonOpen.Checked == true)
                    {
                        objPOBAL.OpenStates = 1;
                    }
                    if (radioButtonNew.Checked == true || radioButtonAdjust.Checked == true)
                    {
                        objPOBAL.OpenStates = 0;
                    }
                    objPOBAL.RackNo = textBoxRackNo.Text;
                    objPOBAL.MinSellingPrice = Convert.ToDecimal(textBoxMinSellingPrice.Text);
                    objPOBAL.ShopPrice = Convert.ToDecimal(textBoxShopPrice.Text);
                    objPOBAL.RetailDiscPer = Convert.ToDecimal(textBoxRetailDiscPer.Text);
                    objPOBAL.WholesaleDiscPer = Convert.ToDecimal(textBoxWholesaleDiscPer.Text);
                    if (checkBoxScaleItem.Checked == true)
                    {
                        objPOBAL.ScaleItem = true;
                    }
                    if (checkBoxScaleItem.Checked == false)
                    {
                        objPOBAL.ScaleItem = false;
                    }
                    if (checkBoxBundleItem.Checked == true)
                    {
                        objPOBAL.BundleItem = true;
                    }
                    if (checkBoxBundleItem.Checked == false)
                    {
                        objPOBAL.BundleItem = false;
                    }
                    if (checkBoxRawMaterial.Checked == true)
                    {
                        objPOBAL.RawMaterial = true;
                    }
                    if (checkBoxRawMaterial.Checked == false)
                    {
                        objPOBAL.RawMaterial = false;
                    }

                    if (checkBoxAllowSales.Checked == true)
                    {
                        objPOBAL.AllowSales = true;
                    }
                    if (checkBoxAllowSales.Checked == false)
                    {
                        objPOBAL.AllowSales = false;
                    }

                    if (checkBoxAllowPurchase.Checked == true)
                    {
                        objPOBAL.AllowPurchase = true;
                    }
                    if (checkBoxAllowPurchase.Checked == false)
                    {
                        objPOBAL.AllowPurchase = false;
                    }

                    if (checkBoxAllowInventory.Checked == true)
                    {
                        objPOBAL.AllowInventory = true;
                    }
                    if (checkBoxAllowInventory.Checked == false)
                    {
                        objPOBAL.AllowInventory = false;
                    }
                    objPOBAL.TItemName = textBoxItemNameT.Text.Trim();
                    objPODAL = new ClassPODAL();
                    int count = objPODAL.InsertUpdateStock(objPOBAL);
                    if (count != 0)
                    {
                        MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (textBoxItemId.Text == "" || Convert.ToInt32(textBoxItemId.Text) == 0)
                        //{
                        //    DialogResult result = MessageBox.Show("Do you want to Print Barcode for this Item", "Print Barcode Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //    if (result == DialogResult.Yes)
                        //    {
                        //        insertItemBarcode();
                        //    }
                        //}
                        resetDetail();

                        //if (textBoxSearchItemCode.Text != "")
                        //{
                        //    fillItemsGridByCode();
                        //}
                        //else if (comboBoxCategorySearch.Text != "")
                        //{
                        //    fillItemsGridByCat();
                        //}
                        //else if (textBoxSearchName.Text != "")
                        //{
                        //    fillItemsGridByName();
                        //}
                        //else
                        //{
                        //    fillItemsGridAll();
                        //}
                        
                    }
                }
                else if (radioButtonNew.Checked == true)
                {
                    objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemStatus = "New";
                    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    if (comboBoxSubCat.SelectedIndex == -1)
                    {
                        comboBoxSubCat.SelectedValue = 0;
                    }
                    objPOBAL.ItemSubCatId = Convert.ToInt32(comboBoxSubCat.SelectedValue);
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemName = textBoxItemName.Text.Trim();
                    objPOBAL.SItemName = textBoxItemNameS.Text.Trim();
                    objPOBAL.Discount = Convert.ToDecimal(textBoxDiscount.Text);
                    objPOBAL.WholeSaleDiscount = Convert.ToDecimal(textBoxWholesaleDisc.Text);
                    objPOBAL.ItemUnit = comboBoxUnit.Text.Trim();
                    objPOBAL.CostPrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                    if (Convert.ToDecimal(textBoxDefPurchasePrice.Text) == 0)
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                    }
                    else
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxDefPurchasePrice.Text);
                    }
                    objPOBAL.SellingPrice = Convert.ToDecimal(textBoxSellingPrice.Text);
                    objPOBAL.SellingPrice2 = Convert.ToDecimal(textBoxPrice2.Text);
                    objPOBAL.SPPRiceEffectFrom = Convert.ToDecimal(textBoxSPPriceEffectFrom.Text);
                    objPOBAL.MinQty = Convert.ToDecimal(textBoxMinQty.Text);
                    objPOBAL.MaintainQty = Convert.ToDecimal(textBoxMaintainQty.Text);
                    objPOBAL.AvailableQty = Convert.ToDecimal(textBoxQty.Text);
                    // objPOBAL.ItemMode = comboBoxItemMode.Text.Trim();
                    objPOBAL.ItemMode = "COMMON STOCK";
                    objPOBAL.OpenBalDate = dateTimePickerTranDate.Value;
                    objPOBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    //objPOBAL.Wharehouse = "Wharehouse1";
                    objPOBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    //objPOBAL.SupplierId = 1;
                    objPOBAL.WarrantyPeriod = textBoxWarranty.Text.Trim();
                    objPOBAL.FreeIssueEffectFrom = Convert.ToInt32(textBoxFreeIssue.Text);
                    if (Convert.ToDecimal(labelNetDiff.Text) > 0)
                    {
                        objPOBAL.InValue = Convert.ToDecimal(labelNetDiff.Text);
                        objPOBAL.OutValue = 0;
                    }
                    if (Convert.ToDecimal(labelNetDiff.Text) < 0)
                    {
                        objPOBAL.OutValue = (Convert.ToDecimal(labelNetDiff.Text) * -1);
                        objPOBAL.InValue = 0;
                    }
                    if (Convert.ToDecimal(labelQtyDiff.Text) > 0)
                    {
                        objPOBAL.InQty = Convert.ToDecimal(labelQtyDiff.Text);
                        objPOBAL.OutQty = 0;
                    }
                    if (Convert.ToDecimal(labelQtyDiff.Text) < 0)
                    {
                        objPOBAL.OutQty = (Convert.ToDecimal(labelQtyDiff.Text) * -1);
                        objPOBAL.InQty = 0;
                    }
                    if (radioButtonOpen.Checked == true)
                    {
                        objPOBAL.OpenStates = 1;
                    }
                    if (radioButtonNew.Checked == true || radioButtonAdjust.Checked == true)
                    {
                        objPOBAL.OpenStates = 0;
                    }
                    objPOBAL.RackNo = textBoxRackNo.Text;
                    objPOBAL.MinSellingPrice = Convert.ToDecimal(textBoxMinSellingPrice.Text);
                    objPOBAL.ShopPrice = Convert.ToDecimal(textBoxShopPrice.Text);
                    objPOBAL.RetailDiscPer = Convert.ToDecimal(textBoxRetailDiscPer.Text);
                    objPOBAL.WholesaleDiscPer = Convert.ToDecimal(textBoxWholesaleDiscPer.Text);
                    if (checkBoxScaleItem.Checked == true)
                    {
                        objPOBAL.ScaleItem = true;
                    }
                    if (checkBoxScaleItem.Checked == false)
                    {
                        objPOBAL.ScaleItem = false;
                    }
                    if (checkBoxBundleItem.Checked == true)
                    {
                        objPOBAL.BundleItem = true;
                    }
                    if (checkBoxBundleItem.Checked == false)
                    {
                        objPOBAL.BundleItem = false;
                    }
                    if (checkBoxRawMaterial.Checked == true)
                    {
                        objPOBAL.RawMaterial = true;
                    }
                    if (checkBoxRawMaterial.Checked == false)
                    {
                        objPOBAL.RawMaterial = false;
                    }
                    objPOBAL.TItemName = textBoxItemNameT.Text.Trim();

                    if (checkBoxAllowSales.Checked == true)
                    {
                        objPOBAL.AllowSales = true;
                    }
                    if (checkBoxAllowSales.Checked == false)
                    {
                        objPOBAL.AllowSales = false;
                    }

                    if (checkBoxAllowPurchase.Checked == true)
                    {
                        objPOBAL.AllowPurchase = true;
                    }
                    if (checkBoxAllowPurchase.Checked == false)
                    {
                        objPOBAL.AllowPurchase = false;
                    }

                    if (checkBoxAllowInventory.Checked == true)
                    {
                        objPOBAL.AllowInventory = true;
                    }
                    if (checkBoxAllowInventory.Checked == false)
                    {
                        objPOBAL.AllowInventory = false;
                    }

                    objPODAL = new ClassPODAL();
                    int count = objPODAL.InsertUpdateStock(objPOBAL);
                    if (count != 0)
                    {
                        MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //if (textBoxItemId.Text == "" || Convert.ToInt32(textBoxItemId.Text) == 0)
                        //{
                        //    DialogResult result = MessageBox.Show("Do you want to Print Barcode for this Item", "Print Barcode Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //    if (result == DialogResult.Yes)
                        //    {
                        //        insertItemBarcode();
                        //    }
                        //}

                        resetDetail();
                        //if (textBoxSearchItemCode.Text != "")
                        //{
                        //    fillItemsGridByCode();
                        //}
                        //else if (comboBoxCategorySearch.Text != "")
                        //{
                        //    fillItemsGridByCat();
                        //}
                        //else if (textBoxSearchName.Text != "")
                        //{
                        //    fillItemsGridByName();
                        //}
                        //else
                        //{
                        //    fillItemsGridAll();
                        //}
                    }
                }
                else if (radioButtonAdjust.Checked == true)
                {
                    objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemStatus = "Adj";
                    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    if (comboBoxSubCat.SelectedIndex == -1)
                    {
                        comboBoxSubCat.SelectedValue = 0;
                    }
                    objPOBAL.ItemSubCatId = Convert.ToInt32(comboBoxSubCat.SelectedValue);
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemName = textBoxItemName.Text.Trim();
                    objPOBAL.SItemName = textBoxItemNameS.Text.Trim();
                    objPOBAL.Discount = Convert.ToDecimal(textBoxDiscount.Text);
                    objPOBAL.WholeSaleDiscount = Convert.ToDecimal(textBoxWholesaleDisc.Text);
                    objPOBAL.ItemUnit = comboBoxUnit.Text.Trim();
                    objPOBAL.CostPrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                    if (Convert.ToDecimal(textBoxDefPurchasePrice.Text) == 0)
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                    }
                    else
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(textBoxDefPurchasePrice.Text);
                    }
                    objPOBAL.SellingPrice = Convert.ToDecimal(textBoxSellingPrice.Text);
                    objPOBAL.SellingPrice2 = Convert.ToDecimal(textBoxPrice2.Text);
                    objPOBAL.SPPRiceEffectFrom = Convert.ToDecimal(textBoxSPPriceEffectFrom.Text);
                    objPOBAL.MinQty = Convert.ToDecimal(textBoxMinQty.Text);
                    objPOBAL.MaintainQty = Convert.ToDecimal(textBoxMaintainQty.Text);
                    objPOBAL.AvailableQty = Convert.ToDecimal(textBoxQty.Text);
                    // objPOBAL.ItemMode = comboBoxItemMode.Text.Trim();
                    objPOBAL.ItemMode = "COMMON STOCK";
                    objPOBAL.OpenBalDate = dateTimePickerTranDate.Value;
                    objPOBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    //objPOBAL.Wharehouse = "Wharehouse1";
                    objPOBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    //objPOBAL.SupplierId = 1;
                    objPOBAL.WarrantyPeriod = textBoxWarranty.Text.Trim();
                    objPOBAL.FreeIssueEffectFrom = Convert.ToInt32(textBoxFreeIssue.Text);
                    if (Convert.ToDecimal(labelNetDiff.Text) > 0)
                    {
                        objPOBAL.InValue = Convert.ToDecimal(labelNetDiff.Text);
                        objPOBAL.OutValue = 0;
                    }
                    if (Convert.ToDecimal(labelNetDiff.Text) < 0)
                    {
                        objPOBAL.OutValue = (Convert.ToDecimal(labelNetDiff.Text) * -1);
                        objPOBAL.InValue = 0;
                    }
                    if (Convert.ToDecimal(labelQtyDiff.Text) > 0)
                    {
                        objPOBAL.InQty = Convert.ToDecimal(labelQtyDiff.Text);
                        objPOBAL.OutQty = 0;
                    }
                    if (Convert.ToDecimal(labelQtyDiff.Text) < 0)
                    {
                        objPOBAL.OutQty = (Convert.ToDecimal(labelQtyDiff.Text) * -1);
                        objPOBAL.InQty = 0;
                    }
                    if (radioButtonOpen.Checked == true)
                    {
                        objPOBAL.OpenStates = 1;
                    }
                    if (radioButtonNew.Checked == true || radioButtonAdjust.Checked == true)
                    {
                        objPOBAL.OpenStates = 0;
                    }
                    objPOBAL.RackNo = textBoxRackNo.Text;
                    objPOBAL.MinSellingPrice = Convert.ToDecimal(textBoxMinSellingPrice.Text);
                    objPOBAL.ShopPrice = Convert.ToDecimal(textBoxShopPrice.Text);
                    objPOBAL.RetailDiscPer = Convert.ToDecimal(textBoxRetailDiscPer.Text);
                    objPOBAL.WholesaleDiscPer = Convert.ToDecimal(textBoxWholesaleDiscPer.Text);
                    if (checkBoxScaleItem.Checked == true)
                    {
                        objPOBAL.ScaleItem = true;
                    }
                    if (checkBoxScaleItem.Checked == false)
                    {
                        objPOBAL.ScaleItem = false;
                    }
                    if (checkBoxBundleItem.Checked == true)
                    {
                        objPOBAL.BundleItem = true;
                    }
                    if (checkBoxBundleItem.Checked == false)
                    {
                        objPOBAL.BundleItem = false;
                    }
                    if (checkBoxRawMaterial.Checked == true)
                    {
                        objPOBAL.RawMaterial = true;
                    }
                    if (checkBoxRawMaterial.Checked == false)
                    {
                        objPOBAL.RawMaterial = false;
                    }
                    objPOBAL.TItemName = textBoxItemNameT.Text.Trim();

                    if (checkBoxAllowSales.Checked == true)
                    {
                        objPOBAL.AllowSales = true;
                    }
                    if (checkBoxAllowSales.Checked == false)
                    {
                        objPOBAL.AllowSales = false;
                    }

                    if (checkBoxAllowPurchase.Checked == true)
                    {
                        objPOBAL.AllowPurchase = true;
                    }
                    if (checkBoxAllowPurchase.Checked == false)
                    {
                        objPOBAL.AllowPurchase = false;
                    }

                    if (checkBoxAllowInventory.Checked == true)
                    {
                        objPOBAL.AllowInventory = true;
                    }
                    if (checkBoxAllowInventory.Checked == false)
                    {
                        objPOBAL.AllowInventory = false;
                    }

                    objPODAL = new ClassPODAL();
                    int count = objPODAL.InsertUpdateStock(objPOBAL);
                    if (count != 0)
                    {
                        MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //if (textBoxItemId.Text == "" || Convert.ToInt32(textBoxItemId.Text) == 0)
                        //{
                        //    DialogResult result = MessageBox.Show("Do you want to Print Barcode for this Item", "Print Barcode Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //    if (result == DialogResult.Yes)
                        //    {
                        //        insertItemBarcode();
                        //    }
                        //}

                        resetDetail();
                        //if (textBoxSearchItemCode.Text != "")
                        //{
                        //    fillItemsGridByCode();
                        //}
                        //else if (comboBoxCategorySearch.Text != "")
                        //{
                        //    fillItemsGridByCat();
                        //}
                        //else if (textBoxSearchName.Text != "")
                        //{
                        //    fillItemsGridByName();
                        //}
                        //else
                        //{
                        //    fillItemsGridAll();
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemCodeData()
        {
            try
            {
                resetItemCodeData();
                resetDetailV();
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                //objPOBAL.Wharehouse = "Wharehouse1";
                objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveItemCodeSelectedData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                        textBoxItemName.Text = (values[1].ToString().Trim());
                        textBoxDiscount.Text = (values[2].ToString().Trim());
                        comboBoxUnit.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxMinQty.Text = (values[6].ToString().Trim());
                        textBoxItemId.Text = (values[7].ToString().Trim());
                        textBoxQty.Text = (values[8].ToString().Trim());
                        labelQty.Text = (values[8].ToString().Trim());
                        comboBoxItemMode.Text = (values[9].ToString().Trim());
                        textBoxItemNameS.Text = (values[10].ToString().Trim());
                        textBoxWarranty.Text = (values[11].ToString().Trim());
                        textBoxFreeIssue.Text = (values[12].ToString().Trim());
                        textBoxPrice2.Text = (values[13].ToString().Trim());
                        textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                        textBoxRackNo.Text = (values[15].ToString().Trim());
                        comboBoxSubCat.SelectedValue = (values[16].ToString().Trim());
                        textBoxDefPurchasePrice.Text = (values[17].ToString().Trim());
                        textBoxMinSellingPrice.Text = (values[18].ToString().Trim());
                        textBoxWholesaleDisc.Text = (values[19].ToString().Trim());
                        textBoxPrice2.Text = (values[20].ToString().Trim());
                        textBoxShopPrice.Text = (values[21].ToString().Trim());
                        textBoxRetailDiscPer.Text = (values[22].ToString().Trim());
                        textBoxWholesaleDiscPer.Text = (values[23].ToString().Trim());
                        textBoxMaintainQty.Text = (values[26].ToString().Trim());
                        //comboBoxSupplier.SelectedValue = (values[13].ToString().Trim());
                        textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                        labelNet.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                        //textBoxItemIdV.Text = (values[24].ToString().Trim());
                        //textBoxItemCodeV.Text = (values[25].ToString().Trim());
                        checkBoxScaleItem.Checked = false;
                        if (Convert.ToBoolean(values[27]) == true)
                        {
                            checkBoxScaleItem.Checked = true;
                        }
                        textBoxItemNameT.Text = (values[28].ToString().Trim());
                        checkBoxBundleItem.Checked = false;
                        if (Convert.ToBoolean(values[29]) == true)
                        {
                            checkBoxBundleItem.Checked = true;
                        }
                        comboBoxSupplier.SelectedValue = (values[30].ToString().Trim());
                        checkBoxRawMaterial.Checked = false;
                        if (Convert.ToBoolean(values[31]) == true)
                        {
                            checkBoxRawMaterial.Checked = true;
                        }

                        checkBoxAllowSales.Checked = false;
                        if (Convert.ToBoolean(values[32]) == true)
                        {
                            checkBoxAllowSales.Checked = true;
                        }
                        checkBoxAllowPurchase.Checked = false;
                        if (Convert.ToBoolean(values[33]) == true)
                        {
                            checkBoxAllowPurchase.Checked = true;
                        }
                        checkBoxAllowInventory.Checked = false;
                        if (Convert.ToBoolean(values[34]) == true)
                        {
                            checkBoxAllowInventory.Checked = true;
                        }

                        comboBoxItemCategoryV.SelectedValue = (values[0].ToString().Trim());
                        textBoxItemNameV.Text = (values[1].ToString().Trim());
                        textBoxDiscountV.Text = (values[2].ToString().Trim());
                        comboBoxUnitV.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPriceV.Text = (values[4].ToString().Trim());
                        textBoxSellingPriceV.Text = (values[5].ToString().Trim());
                        textBoxMinQtyV.Text = (values[6].ToString().Trim());
                        textBoxQtyV.Text = (values[8].ToString().Trim());
                        //labelQtyV.Text = (values[8].ToString().Trim());
                        //comboBoxItemModeV.Text = (values[9].ToString().Trim());
                        textBoxItemNameSV.Text = (values[10].ToString().Trim());
                        //textBoxWarrantyV.Text = (values[11].ToString().Trim());
                        textBoxFreeIssueV.Text = (values[12].ToString().Trim());
                        textBoxPrice2V.Text = (values[13].ToString().Trim());
                        //textBoxSPPriceEffectFromV.Text = (values[14].ToString().Trim());
                        textBoxRackNoV.Text = (values[15].ToString().Trim());
                        comboBoxSubCatV.SelectedValue = (values[16].ToString().Trim());
                        //textBoxDefPurchasePriceV.Text = (values[17].ToString().Trim());
                        textBoxMinSellingPriceV.Text = (values[18].ToString().Trim());
                        textBoxWholesaleDiscV.Text = (values[19].ToString().Trim());
                        textBoxPrice2V.Text = (values[20].ToString().Trim());
                        textBoxShopPriceV.Text = (values[21].ToString().Trim());
                        textBoxRetailDiscPerV.Text = (values[22].ToString().Trim());
                        textBoxWholesaleDiscPerV.Text = (values[23].ToString().Trim());
                        textBoxMaintainQtyV.Text = (values[26].ToString().Trim());
                        //comboBoxSupplier.SelectedValue = (values[13].ToString().Trim());
                        textBoxNetAmountV.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                        //labelNetV.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                        textBoxItemIdV.Text = (values[24].ToString().Trim());
                        textBoxItemCodeV.Text = (values[25].ToString().Trim());
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void fillItemCodeVariantData()
        //{
        //    try
        //    {
        //        textBoxItemIdV.Clear();
        //        textBoxItemCodeV.Clear();
        //        objPOBAL = new ClassPOBAL();
        //        objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
        //        //objPOBAL.Wharehouse = "Wharehouse1";
        //        objPODAL = new ClassPODAL();
        //        objPOBAL.DtDataSet = objPODAL.retreiveItemCodeVarientData(objPOBAL);
        //        if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            List<ArrayList> newval = new List<ArrayList>();
        //            foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
        //            {
        //                ArrayList values = new ArrayList();
        //                values.Clear();
        //                foreach (object value in dRow.ItemArray)
        //                    values.Add(value);
        //                newval.Add(values);
                        
        //                textBoxItemIdV.Text = (values[0].ToString().Trim());
        //                textBoxItemCodeV.Text = (values[1].ToString().Trim());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void fillItemCodeDataV()
        {
            try
            {
                resetItemCodeDataV();
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                //objPOBAL.Wharehouse = "Wharehouse1";
                objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveItemCodeVarientData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        comboBoxItemCategoryV.SelectedValue = (values[0].ToString().Trim());
                        textBoxItemNameV.Text = (values[1].ToString().Trim());
                        textBoxDiscountV.Text = (values[2].ToString().Trim());
                        comboBoxUnitV.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPriceV.Text = (values[4].ToString().Trim());
                        textBoxSellingPriceV.Text = (values[5].ToString().Trim());
                        textBoxMinQtyV.Text = (values[6].ToString().Trim());
                        textBoxItemIdV.Text = (values[7].ToString().Trim());
                        textBoxQtyV.Text = (values[8].ToString().Trim());
                        //labelQtyV.Text = (values[8].ToString().Trim());
                        //comboBoxItemModeV.Text = (values[9].ToString().Trim());
                        textBoxItemNameSV.Text = (values[10].ToString().Trim());
                        //textBoxWarrantyV.Text = (values[11].ToString().Trim());
                        textBoxFreeIssueV.Text = (values[12].ToString().Trim());
                        textBoxPrice2V.Text = (values[13].ToString().Trim());
                        //textBoxSPPriceEffectFromV.Text = (values[14].ToString().Trim());
                        textBoxRackNoV.Text = (values[15].ToString().Trim());
                        comboBoxSubCatV.SelectedValue = (values[16].ToString().Trim());
                        //textBoxDefPurchasePriceV.Text = (values[17].ToString().Trim());
                        textBoxMinSellingPriceV.Text = (values[18].ToString().Trim());
                        textBoxWholesaleDiscV.Text = (values[19].ToString().Trim());
                        textBoxPrice2V.Text = (values[20].ToString().Trim());
                        textBoxShopPriceV.Text = (values[21].ToString().Trim());
                        textBoxRetailDiscPerV.Text = (values[22].ToString().Trim());
                        textBoxWholesaleDiscPerV.Text = (values[23].ToString().Trim());
                        textBoxMaintainQtyV.Text = (values[27].ToString().Trim());
                        //comboBoxSupplier.SelectedValue = (values[13].ToString().Trim());
                        textBoxNetAmountV.Text = (Convert.ToDecimal(textBoxQtyV.Text) * Convert.ToDecimal(textBoxUnitCostPriceV.Text)).ToString("0.00");
                        //labelNetV.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                        textBoxItemIdV.Text = (values[24].ToString().Trim());
                        textBoxItemCodeV.Text = (values[25].ToString().Trim());
                        textBoxConvertionQty.Text = (values[26].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteItem()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);

                objPODAL = new ClassPODAL();
                int count = objPODAL.DeleteItem(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Deleted Successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetDetail();
                    //fillItemsGridAll();
                }
                else
                {
                    MessageBox.Show("This Item can not be deleted.", "Delete Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteItemCategory()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(textBoxCategory.SelectedValue.ToString());

                objPODAL = new ClassPODAL();
                int count = objPODAL.DeleteItemCat(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Category Deleted Successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxCategory.SelectedIndex = -1;
                    loadCategory();
                    //fillItemsGridAll();
                }
                else
                {
                    MessageBox.Show("This Item can not be deleted.", "Delete Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteItemSubCategory()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(textBoxCategory.SelectedValue.ToString());
                objPOBAL.ItemSubCatId = Convert.ToInt32(textBoxSubCat.SelectedValue.ToString());

                objPODAL = new ClassPODAL();
                int count = objPODAL.DeleteItemSubCat(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Sub Category Deleted Successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxCategory.SelectedIndex = -1;
                    textBoxSubCat.SelectedIndex = -1;
                    loadCategory();
                    //fillItemsGridAll();
                }
                else
                {
                    MessageBox.Show("This Item can not be deleted.", "Delete Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertSerial()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.SerialNo = textBoxSerialNo.Text.Trim();

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertItemSerial(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Serial Added Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxSerialNo.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertCategory()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CatDescription = textBoxCategory.Text.Trim();

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertItemCategory1(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Category Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategory();
                    textBoxCategory.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadCategory()
        {
            try
            {
                loadStatus = true;
                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                comboBoxItemCategory.DataSource = objPODAL.retreiveAllCategoryData(objPOBAL).Tables[0];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

                comboBoxItemCategoryV.DataSource = objPODAL.retreiveAllCategoryData(objPOBAL).Tables[0];
                comboBoxItemCategoryV.DisplayMember = "ItemCatName";
                comboBoxItemCategoryV.ValueMember = "ItemCatId";
                comboBoxItemCategoryV.SelectedIndex = -1;

                comboBoxCategorySearch.DataSource = objPODAL.retreiveAllCategoryData(objPOBAL).Tables[0];
                comboBoxCategorySearch.DisplayMember = "ItemCatName";
                comboBoxCategorySearch.ValueMember = "ItemCatId";
                comboBoxCategorySearch.SelectedIndex = -1;

                textBoxCategory.DataSource = objPODAL.retreiveAllCategoryData(objPOBAL).Tables[0];
                textBoxCategory.DisplayMember = "ItemCatName";
                textBoxCategory.ValueMember = "ItemCatId";
                textBoxCategory.SelectedIndex = -1;

                comboBoxSupplier.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[0];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierId";
                comboBoxSupplier.SelectedIndex = 0;

                comboBoxBranch.DataSource = objPODAL.retreiveAllBranches(objPOBAL).Tables[0];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedIndex = 0;

                comboBoxSearchWH.DataSource = objPODAL.retreiveAllBranches(objPOBAL).Tables[0];
                comboBoxSearchWH.DisplayMember = "BranchName";
                comboBoxSearchWH.ValueMember = "BranchId";
                comboBoxSearchWH.SelectedIndex = 0;

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void FormStock_Load(object sender, EventArgs e)
        {
            loadCategory();
            radioButtonOpen.Checked = true;
            radioButtonAdjust.Checked = true;

            checkBoxAllowSales.Checked = true;
            checkBoxAllowPurchase.Checked = true;
            checkBoxAllowInventory.Checked = true;
            comboBoxSupplier.Select();
        }

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                //errorProvider1.Clear();
                //bool isValid = ValidateWharehouse();
                //if (isValid)
                //{
                    if (radioButtonOpen.Checked == true)
                    {
                        try
                        {
                            resetItemCodeData();
                            objPOBAL = new ClassPOBAL();
                            objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                            //objPOBAL.Wharehouse = "Wharehouse1";
                            objPODAL = new ClassPODAL();
                            objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                            if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                            {
                                MessageBox.Show("You have allready entered this item to the stock. Please select the correct stock status.", "Wrong Stock Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBoxItemCode.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else if (radioButtonNew.Checked == true)
                    {
                        try
                        {
                            resetItemCodeData();
                            objPOBAL = new ClassPOBAL();
                            objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                            //objPOBAL.Wharehouse = "Wharehouse1";
                            objPODAL = new ClassPODAL();
                            objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                            if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                            {
                                List<ArrayList> newval = new List<ArrayList>();
                                foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[1].Rows)
                                {
                                    ArrayList values = new ArrayList();
                                    values.Clear();
                                    foreach (object value in dRow.ItemArray)
                                        values.Add(value);
                                    newval.Add(values);
                                    comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                                    textBoxItemName.Text = (values[1].ToString().Trim());
                                    textBoxDiscount.Text = (values[2].ToString().Trim());
                                    comboBoxUnit.Text = (values[3].ToString().Trim());
                                    textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                                    textBoxSellingPrice.Text = (values[5].ToString().Trim());
                                    textBoxMinQty.Text = (values[6].ToString().Trim());
                                    textBoxItemId.Text = (values[7].ToString().Trim());
                                    textBoxQty.Text = "0";
                                    labelQty.Text = (values[8].ToString().Trim());
                                    comboBoxItemMode.Text = (values[9].ToString().Trim());
                                    textBoxItemNameS.Text = (values[10].ToString().Trim());
                                    textBoxWarranty.Text = (values[11].ToString().Trim());
                                    textBoxFreeIssue.Text = (values[12].ToString().Trim());
                                    textBoxPrice2.Text = (values[13].ToString().Trim());
                                    textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                                    textBoxRackNo.Text = (values[15].ToString().Trim());
                                    comboBoxSubCat.SelectedValue = (values[16].ToString().Trim());
                                    textBoxDefPurchasePrice.Text = (values[17].ToString().Trim());
                                    textBoxMinSellingPrice.Text = (values[18].ToString().Trim());
                                    textBoxWholesaleDisc.Text = (values[19].ToString().Trim());
                                    textBoxRetailDiscPer.Text = (values[22].ToString().Trim());
                                    textBoxWholesaleDiscPer.Text = (values[23].ToString().Trim());
                                    textBoxMaintainQty.Text = (values[24].ToString().Trim());
                                    textBoxItemNameT.Text = (values[25].ToString().Trim());
                                    checkBoxScaleItem.Checked = false;
                                    if (Convert.ToBoolean(values[26]) == true)
                                    {
                                        checkBoxScaleItem.Checked = true;
                                    }
                                    checkBoxBundleItem.Checked = false;
                                    if (Convert.ToBoolean(values[27]) == true)
                                    {
                                        checkBoxBundleItem.Checked = true;
                                    }
                                    comboBoxSupplier.SelectedValue = (values[28].ToString().Trim());

                                    checkBoxRawMaterial.Checked = false;
                                    if (Convert.ToBoolean(values[29]) == true)
                                    {
                                        checkBoxRawMaterial.Checked = true;
                                    }

                                    checkBoxAllowSales.Checked = false;
                                    if (Convert.ToBoolean(values[30]) == true)
                                    {
                                        checkBoxAllowSales.Checked = true;
                                    }
                                    checkBoxAllowPurchase.Checked = false;
                                    if (Convert.ToBoolean(values[31]) == true)
                                    {
                                        checkBoxAllowPurchase.Checked = true;
                                    }
                                    checkBoxAllowInventory.Checked = false;
                                    if (Convert.ToBoolean(values[32]) == true)
                                    {
                                        checkBoxAllowInventory.Checked = true;
                                    }

                                    //  textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                                    //  labelNet.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString();
                                }
                                textBoxQty.Select();
                            }
                            else
                            {
                                comboBoxItemCategory.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (radioButtonAdjust.Checked == true)
                    {
                        try
                        {
                            resetItemCodeData();
                            objPOBAL = new ClassPOBAL();
                            objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                            //objPOBAL.Wharehouse = "Wharehouse1";
                            objPODAL = new ClassPODAL();
                            objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                            if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                            {
                                List<ArrayList> newval = new List<ArrayList>();
                                foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[1].Rows)
                                {
                                    ArrayList values = new ArrayList();
                                    values.Clear();
                                    foreach (object value in dRow.ItemArray)
                                        values.Add(value);
                                    newval.Add(values);
                                    comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                                    textBoxItemName.Text = (values[1].ToString().Trim());
                                    textBoxDiscount.Text = (values[2].ToString().Trim());
                                    comboBoxUnit.Text = (values[3].ToString().Trim());
                                    textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                                    textBoxSellingPrice.Text = (values[5].ToString().Trim());
                                    textBoxMinQty.Text = (values[6].ToString().Trim());
                                    textBoxItemId.Text = (values[7].ToString().Trim());
                                    textBoxQty.Text = (values[8].ToString().Trim());
                                    labelQty.Text = (values[8].ToString().Trim());
                                    comboBoxItemMode.Text = (values[9].ToString().Trim());
                                    textBoxItemNameS.Text = (values[10].ToString().Trim());
                                    textBoxWarranty.Text = (values[11].ToString().Trim());
                                    textBoxFreeIssue.Text = (values[12].ToString().Trim());
                                    textBoxPrice2.Text = (values[13].ToString().Trim());
                                    textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                                    textBoxRackNo.Text = (values[15].ToString().Trim());
                                    comboBoxSubCat.SelectedValue = (values[16].ToString().Trim());
                                    textBoxDefPurchasePrice.Text = (values[17].ToString().Trim());
                                    textBoxMinSellingPrice.Text = (values[18].ToString().Trim());
                                    textBoxWholesaleDisc.Text = (values[19].ToString().Trim());
                                    textBoxRetailDiscPer.Text = (values[22].ToString().Trim());
                                    textBoxWholesaleDiscPer.Text = (values[23].ToString().Trim());
                                    textBoxMaintainQty.Text = (values[24].ToString().Trim());
                                    textBoxItemNameT.Text = (values[25].ToString().Trim());
                                    checkBoxScaleItem.Checked = false;
                                    if (Convert.ToBoolean(values[26]) == true)
                                    {
                                        checkBoxScaleItem.Checked = true;
                                    }
                                    checkBoxBundleItem.Checked = false;
                                    if (Convert.ToBoolean(values[27]) == true)
                                    {
                                        checkBoxBundleItem.Checked = true;
                                    }
                                    comboBoxSupplier.SelectedValue = (values[28].ToString().Trim());
                                    checkBoxRawMaterial.Checked = false;
                                    if (Convert.ToBoolean(values[29]) == true)
                                    {
                                        checkBoxRawMaterial.Checked = true;
                                    }
                                    checkBoxAllowSales.Checked = false;
                                    if (Convert.ToBoolean(values[30]) == true)
                                    {
                                        checkBoxAllowSales.Checked = true;
                                    }
                                    checkBoxAllowPurchase.Checked = false;
                                    if (Convert.ToBoolean(values[31]) == true)
                                    {
                                        checkBoxAllowPurchase.Checked = true;
                                    }
                                    checkBoxAllowInventory.Checked = false;
                                    if (Convert.ToBoolean(values[32]) == true)
                                    {
                                        checkBoxAllowInventory.Checked = true;
                                    }
                                    //     comboBoxModel.SelectedValue = (values[11].ToString().Trim());
                                    textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                                    labelNet.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString();
                                }
                                textBoxQty.Select();
                            }
                            else
                            {
                                comboBoxItemCategory.Select();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    comboBoxItemCategory.Select();
                }
                
            //}
        }

        private void textBoxItemCode_Validating(object sender, CancelEventArgs e)
        {
            //errorProvider1.Clear();
            //    bool isValid = ValidateWharehouse();
            //    if (isValid)
            //    {
                    //if (radioButtonOpen.Checked == true)
                    //{
                    //    try
                    //    {
                    //        resetItemCodeData();
                    //        objPOBAL = new ClassPOBAL();
                    //        objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    //        //objPOBAL.Wharehouse = "Wharehouse1";
                    //        objPODAL = new ClassPODAL();
                    //        objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                    //        if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    //        {
                    //            MessageBox.Show("You have allready entered this item to the stock. Please select the correct stock status.", "Wrong Stock Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //            textBoxItemCode.Select();
                    //        }
                    //        else
                    //        {
                    //            comboBoxItemCategory.Select();
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //    }
                    //}

                    //else if (radioButtonNew.Checked == true)
                    //{
                    //    try
                    //    {
                    //        resetItemCodeData();
                    //        objPOBAL = new ClassPOBAL();
                    //        objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    //        //objPOBAL.Wharehouse = "Wharehouse1";
                    //        objPODAL = new ClassPODAL();
                    //        objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                    //        if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    //        {
                    //            List<ArrayList> newval = new List<ArrayList>();
                    //            foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[1].Rows)
                    //            {
                    //                ArrayList values = new ArrayList();
                    //                values.Clear();
                    //                foreach (object value in dRow.ItemArray)
                    //                    values.Add(value);
                    //                newval.Add(values);
                    //                comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                    //                textBoxItemName.Text = (values[1].ToString().Trim());
                    //                textBoxDiscount.Text = (values[2].ToString().Trim());
                    //                comboBoxUnit.Text = (values[3].ToString().Trim());
                    //                textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                    //                textBoxSellingPrice.Text = (values[5].ToString().Trim());
                    //                textBoxMinQty.Text = (values[6].ToString().Trim());
                    //                textBoxItemId.Text = (values[7].ToString().Trim());
                    //                textBoxQty.Text = "0";
                    //                labelQty.Text = (values[8].ToString().Trim());
                    //                comboBoxItemMode.Text = (values[9].ToString().Trim());
                    //                textBoxItemNameS.Text = (values[10].ToString().Trim());
                    //                textBoxWarranty.Text = (values[11].ToString().Trim());
                    //                textBoxFreeIssue.Text = (values[12].ToString().Trim());
                    //                textBoxPrice2.Text = (values[13].ToString().Trim());
                    //                textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                    //                textBoxRackNo.Text = (values[15].ToString().Trim());
                    //                comboBoxSubCat.SelectedValue = (values[16].ToString().Trim());
                    //                textBoxDefPurchasePrice.Text = (values[17].ToString().Trim());
                    //                //comboBoxSupplier.SelectedValue = (values[13].ToString().Trim());
                    //                //comboBoxModel.SelectedValue = (values[11].ToString().Trim());
                    //                //  textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    //                // labelNet.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    //            }
                    //            textBoxQty.Select();
                    //        }
                    //        else
                    //        {
                    //            comboBoxItemCategory.Select();
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //    }
                    //}
                    //else if (radioButtonAdjust.Checked == true)
                    //{
                    //    try
                    //    {
                    //        resetItemCodeData();
                    //        objPOBAL = new ClassPOBAL();
                    //        objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    //        //objPOBAL.Wharehouse = "Wharehouse1";
                    //        objPODAL = new ClassPODAL();
                    //        objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                    //        if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    //        {
                    //            List<ArrayList> newval = new List<ArrayList>();
                    //            foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[1].Rows)
                    //            {
                    //                ArrayList values = new ArrayList();
                    //                values.Clear();
                    //                foreach (object value in dRow.ItemArray)
                    //                    values.Add(value);
                    //                newval.Add(values);
                    //                comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                    //                textBoxItemName.Text = (values[1].ToString().Trim());
                    //                textBoxDiscount.Text = (values[2].ToString().Trim());
                    //                comboBoxUnit.Text = (values[3].ToString().Trim());
                    //                textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                    //                textBoxSellingPrice.Text = (values[5].ToString().Trim());
                    //                textBoxMinQty.Text = (values[6].ToString().Trim());
                    //                textBoxItemId.Text = (values[7].ToString().Trim());
                    //                textBoxQty.Text = (values[8].ToString().Trim());
                    //                labelQty.Text = (values[8].ToString().Trim());
                    //                comboBoxItemMode.Text = (values[9].ToString().Trim());
                    //                textBoxItemNameS.Text = (values[10].ToString().Trim());
                    //                textBoxWarranty.Text = (values[11].ToString().Trim());
                    //                textBoxFreeIssue.Text = (values[12].ToString().Trim());
                    //                textBoxPrice2.Text = (values[13].ToString().Trim());
                    //                textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                    //                textBoxRackNo.Text = (values[15].ToString().Trim());
                    //                comboBoxSubCat.SelectedValue = (values[16].ToString().Trim());
                    //                textBoxDefPurchasePrice.Text = (values[17].ToString().Trim());
                    //                //comboBoxModel.SelectedValue = (values[11].ToString().Trim());
                    //                textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    //                labelNet.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
                    //            }
                    //            textBoxQty.Select();
                    //        }
                    //        else
                    //        {
                    //            comboBoxItemCategory.Select();
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //    }
                    //}
                //}
        }

        private void textBoxSearchItemCode_TextChanged(object sender, EventArgs e)
        {
            //if (comboBoxSearchWH.SelectedIndex != -1)
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        objPOBAL = new ClassPOBAL();
            //        objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
            //        objPOBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
            //        objPODAL = new ClassPODAL();
            //        gridControl1.DataSource = null;
            //        objPOBAL.DtDataSet = objPODAL.retreiveAllStockByBranchItmCode(objPOBAL);
            //        if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
            //        {
            //            gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
            //            //gridView1.Columns["Discount"].Visible = false;
            //            //gridView1.Columns["ItemsId"].Visible = false;
            //            gridView1.Columns["BranchId"].Visible = false;
            //            gridView1.OptionsView.ColumnAutoWidth = false;
            //            gridView1.BestFitColumns();
            //        }
            //        Cursor.Current = Cursors.Default;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            
        }

        private void comboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxSearchWH.SelectedIndex != -1 && comboBoxCategorySearch.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objPOBAL = new ClassPOBAL();
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                    objPODAL = new ClassPODAL();
                    gridControl1.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllStockByBranchItmCat(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView1.Columns["Discount"].Visible = false;
                        //gridView1.Columns["ItemsId"].Visible = false;
                        gridView1.Columns["BranchId"].Visible = false;
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

            //if (loadStatus == false && comboBoxCategorySearch.SelectedIndex != -1)
            //{
            //    fillItemsGridByCat();
            //}
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            //if (comboBoxSearchWH.SelectedIndex != -1)
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        objPOBAL = new ClassPOBAL();
            //        objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
            //        objPOBAL.ItemName = textBoxSearchName.Text.Trim();
            //        objPODAL = new ClassPODAL();
            //        gridControl1.DataSource = null;
            //        objPOBAL.DtDataSet = objPODAL.retreiveAllStockByBranchItmName(objPOBAL);
            //        if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
            //        {
            //            gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
            //            //gridView1.Columns["Discount"].Visible = false;
            //            //gridView1.Columns["ItemsId"].Visible = false;
            //            gridView1.Columns["BranchId"].Visible = false;
            //            gridView1.OptionsView.ColumnAutoWidth = false;
            //            gridView1.BestFitColumns();
            //        }
            //        Cursor.Current = Cursors.Default;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}

            
        }

        private void textBoxQty_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValue();
        }

        private void textBoxUnitCostPrice_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValue();
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            resetDetail();
            createItemCode();
            comboBoxSupplier.Select();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateIteBranch() &&
                            ValidateItemCode() &&
                            ValidateItemName() &&
                            //ValidateIteCategory() &&
                            ValidateQty() &&
                            ValidateMinQty() &&
                            ValidateCostPrice() &&
                            ValidateSellPrice() &&
                            ValidateMinSellPrice();
            if (isValid)
            {
                insertPODT();
                buttonNew1.Select();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateItemId();
            if (isValid)
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this Item", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteItem();
                }
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            //fillItemsGridAll();
            //if (comboBoxSearchWH.SelectedIndex != -1)
            //{
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objPOBAL = new ClassPOBAL();
                    //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                    objPODAL = new ClassPODAL();
                    gridControl1.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllBranchStock(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView1.Columns["Discount"].Visible = false;
                        //gridView1.Columns["ItemsId"].Visible = false;
                        gridView1.Columns["BranchId"].Visible = false;
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            //}
           
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //string strRowNumber = (e.RowIndex + 1).ToString();
            //SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            //if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            //{
            //    dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            //}
            //Brush b = SystemBrushes.ControlText;
            //e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            //Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checkMinQty();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //errorProvider1.Clear();
            //if (e.RowIndex != -1 && e.ColumnIndex != -1)
            //{
            //    //comboBoxWharehouse.Text = dataGridView1["Wharehouse", e.RowIndex].Value.ToString();
            //    textBoxItemCode.Text = dataGridView1["ItemCode", e.RowIndex].Value.ToString();
            //    fillItemCodeData();
            //}
        }

        private void buttonExpCatSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateCategoryName();
            if (isValid)
            {
                insertCategory();
            }
        }

        private void radioButtonOpen_CheckedChanged(object sender, EventArgs e)
        {
            picPurchase.Enabled = true;
        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            picPurchase.Enabled = true;
        }

        private void textBoxItemCode_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    resetItemCodeData();
            //    objPOBAL = new ClassPOBAL();
            //    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
            //    objPODAL = new ClassPODAL();
            //    objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
            //    if (objPOBAL.DtDataSet.Tables[1].Rows.Count > 0)
            //    {
            //        List<ArrayList> newval = new List<ArrayList>();
            //        foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[1].Rows)
            //        {
            //            ArrayList values = new ArrayList();
            //            values.Clear();
            //            foreach (object value in dRow.ItemArray)
            //                values.Add(value);
            //            newval.Add(values);
            //            comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
            //            textBoxItemName.Text = (values[1].ToString().Trim());
            //            textBoxDiscount.Text = (values[2].ToString().Trim());
            //            comboBoxUnit.Text = (values[3].ToString().Trim());
            //            textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
            //            textBoxSellingPrice.Text = (values[5].ToString().Trim());
            //            textBoxMinQty.Text = (values[6].ToString().Trim());
            //            textBoxItemId.Text = (values[7].ToString().Trim());
            //            textBoxQty.Text = (values[8].ToString().Trim());
            //            labelQty.Text = (values[8].ToString().Trim());
            //            comboBoxItemMode.Text = (values[9].ToString().Trim());
            //            textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
            //            labelNet.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void buttonBarcode_Click(object sender, EventArgs e)
        {
            //FormBarCode frm = new FormBarCode();
            //frm.comboBox1.Text = textBoxItemName.Text;
            //frm.textBox1.Text = textBoxItemCode.Text;
            //frm.tbPrice.Text = textBoxSellingPrice.Text;
            //frm.frm = this;
            //frm.ShowDialog(this);
            FrmBarcode bcode = new FrmBarcode();
            bcode.textBox1.Text = textBoxItemCode.Text;
            bcode.textBoxItemName.Text = textBoxItemName.Text;
            bcode.textBoxInternalCode.Text = textBoxWarranty.Text;
            //bcode.textBoxNumber.Text = textBoxNumber.Text;
            //bcode.textBox_CompanyName.Text = textBox_CompanyName.Text;
            bcode.tbPrice.Text = textBoxSellingPrice.Text;
            bcode.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fillMinItemsGridAll();
            try
            {
                //string FileName = "C:\\ExportData\\Commision.xls";
                //gridControl1.ExportToXls(FileName);
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl1.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl1.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl1.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl1.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl1.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl1.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxItemNameS.Select();
                //textBoxQty.Select();
            }
        }

        private void textBoxItemNameS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxItemNameT.Select();
            }
        }

        private void textBoxFreeIssue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonSave.Select();
            }
        }

        private void textBoxWarranty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxUnit.Select();
            }
        }

        private void textBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxMinQty.Select();
            }
        }

        private void textBoxMinQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxMaintainQty.Select();
            }
        }

        private void textBoxUnitCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxMinSellingPrice.Select();
            }
        }

        private void textBoxSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxRetailDiscPer.Select();
                
            }
        }

        private void comboBoxItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxSubCat.Select();
            }
        }

        private void comboBoxSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxUnit.Select();
            }
        }

        private void comboBoxUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxItemName.Select();
            }
        }

        private void textBoxSPPriceEffectFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxWarranty.Select();
            }
        }

        private void textBoxPrice2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxWholesaleDiscPer.Select();
            }
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUnit.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.SupplierName = comboBoxSupplier.Text.Trim();
                objBAL.ContactPerson = "";
                objBAL.BusinessNo = "";
                objBAL.MobileNo = "";
                objBAL.Email = "";
                objBAL.Address = "";
                objBAL.Remarks = "";
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.BalanceAmount = 0;
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertSupplier(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Supplier Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxItemName.Select();
        }

        private void textBoxDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPrice2.Select();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("ItemCode") == null)
                return;
            textBoxItemCode.Text = this.gridView1.GetFocusedRowCellValue("ItemCode").ToString();
            fillItemCodeData();
            
            //if (textBoxItemCodeV.Text != "")
            //{
                fillItemCodeDataV();
            //}
            comboBoxBranch.SelectedValue = this.gridView1.GetFocusedRowCellValue("BranchId").ToString();
            textBoxQty.Text = this.gridView1.GetFocusedRowCellValue("BranchQty").ToString();

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    //string BookStatus = View.GetRowCellDisplayText(e.RowHandle, View.Columns["BookStatus"]);
                    decimal AvailableQty = Convert.ToDecimal(View.GetRowCellDisplayText(e.RowHandle, View.Columns["TotalQty"]));
                    decimal MinQty = Convert.ToDecimal(View.GetRowCellDisplayText(e.RowHandle, View.Columns["MinQty"]));
                    if (MinQty >= AvailableQty)
                    {
                        e.Appearance.BackColor = Color.LightCoral;
                        //e.Appearance.BackColor2 = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Validation Methods

        private bool ValidateItemId()
        {
            textBoxItemId.Text = textBoxItemId.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemId.Text)) || (textBoxItemId.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Correct Item Code.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemCode, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private bool ValidateWharehouse()
        //{
        //    comboBoxWharehouse.Text = comboBoxWharehouse.Text.Trim();
        //    string errorCode = string.Empty;
        //    if ((string.IsNullOrEmpty(comboBoxWharehouse.Text)) || (comboBoxWharehouse.Text.Trim().Equals(string.Empty)))
        //    {
        //        errorCode = "Please Select Wharehouse.";
        //    }
        //    string message = errorCode;
        //    errorProvider1.SetError(comboBoxWharehouse, message);
        //    if (message.Equals(string.Empty))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private bool ValidateItemCode()
        {
            textBoxItemCode.Text = textBoxItemCode.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemCode.Text)) || (textBoxItemCode.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Item Code.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemCode, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateItemCodeV()
        {
            textBoxItemCodeV.Text = textBoxItemCodeV.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemCodeV.Text)) || (textBoxItemCodeV.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Variant Item Code.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemCodeV, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateItemName()
        {
            textBoxItemName.Text = textBoxItemName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemName.Text)) || (textBoxItemName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Item Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateItemNameV()
        {
            textBoxItemNameV.Text = textBoxItemNameV.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxItemNameV.Text)) || (textBoxItemNameV.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Variant Item Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemNameV, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateIteCategory()
        {
            comboBoxItemCategory.Text = comboBoxItemCategory.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxItemCategory.Text)) || (comboBoxItemCategory.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Item Category.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxItemCategory, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateIteCategoryV()
        {
            comboBoxItemCategoryV.Text = comboBoxItemCategoryV.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxItemCategoryV.Text)) || (comboBoxItemCategoryV.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Variant Item Category.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxItemCategoryV, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateIteBranch()
        {
            comboBoxBranch.Text = comboBoxBranch.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxBranch.Text)) || (comboBoxBranch.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Branch.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxBranch, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateQty()
        {
            textBoxQty.Text = textBoxQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxQty.Text)) || (textBoxQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Quentity.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxQty.Text))
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxQty.Text) < 0)
            {
                errorCode = "Invalid Quentity.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxQty, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateMinQty()
        {
            textBoxMinQty.Text = textBoxMinQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxMinQty.Text)) || (textBoxMinQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Minimum Quentity.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxMinQty.Text))
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxMinQty.Text) < 0)
            {
                errorCode = "Invalid Quentity.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxMinQty, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCostPrice()
        {
            textBoxUnitCostPrice.Text = textBoxUnitCostPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUnitCostPrice.Text)) || (textBoxUnitCostPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Cost Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxUnitCostPrice.Text))
            {
                errorCode = "Invalid Price.";
            }
            else if (Convert.ToDecimal(textBoxUnitCostPrice.Text) < 0)
            {
                errorCode = "Invalid Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUnitCostPrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSellPrice()
        {
            textBoxSellingPrice.Text = textBoxSellingPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxSellingPrice.Text)) || (textBoxSellingPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Selling Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxSellingPrice.Text))
            {
                errorCode = "Invalid Price.";
            }
            else if (Convert.ToDecimal(textBoxSellingPrice.Text) < 0)
            {
                errorCode = "Invalid Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxSellingPrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateMinSellPrice()
        {
            textBoxMinSellingPrice.Text = textBoxMinSellingPrice.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxMinSellingPrice.Text)) || (textBoxMinSellingPrice.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Min Selling Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxMinSellingPrice.Text))
            {
                errorCode = "Invalid Min Selling Price.";
            }
            else if (Convert.ToDecimal(textBoxMinSellingPrice.Text) < 0)
            {
                errorCode = "Invalid Min Selling Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxMinSellingPrice, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateCategoryName()
        {
            textBoxCategory.Text = textBoxCategory.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxCategory.Text)) || (textBoxCategory.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Category.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxCategory, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonSubCat_Click(object sender, EventArgs e)
        {
            insertSubCategory();
        }

        private void textBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && textBoxCategory.SelectedIndex != -1)
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(textBoxCategory.SelectedValue.ToString());
                objPODAL = new ClassPODAL();
                textBoxSubCat.DataSource = objPODAL.retreiveItemSubCategory(objPOBAL).Tables[0];
                textBoxSubCat.DisplayMember = "ItemSubCatName";
                textBoxSubCat.ValueMember = "ItemSubCatId";
                textBoxSubCat.SelectedIndex = -1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxCategory.SelectedIndex = -1;
            textBoxSubCat.SelectedIndex = -1;
        }

        private void comboBoxItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxItemCategory.SelectedIndex != -1)
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objPODAL = new ClassPODAL();
                comboBoxSubCat.DataSource = objPODAL.retreiveItemSubCategory(objPOBAL).Tables[0];
                comboBoxSubCat.DisplayMember = "ItemSubCatName";
                comboBoxSubCat.ValueMember = "ItemSubCatId";
                comboBoxSubCat.SelectedIndex = -1;
            }
        }

        private void comboBoxSubCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxRackNo.Select();
            }
        }

        private void textBoxRackNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxWarranty.Select();
            }
        }

        private void textBoxDefPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxSellingPrice.Select();
            }
        }

        bool insertDTStatus;

        private void buttonUpdateAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonOpen.Checked == true)
                {
                    DialogResult result = MessageBox.Show("Are you sure you need to Update Opening Stock?", "Update Opening Stock Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        UpdateAll();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you need to adjust the Stock?", "Stock Adjustment Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        UpdateAll();
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
        }

        private void comboBoxSearchWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxSearchWH.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;                
                    objPOBAL = new ClassPOBAL();
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                    objPODAL = new ClassPODAL();
                    gridControl1.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllStockByBranch(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView1.Columns["Discount"].Visible = false;
                        //gridView1.Columns["ItemsId"].Visible = false;
                        gridView1.Columns["BranchId"].Visible = false;
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

        private void textBoxMinSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxFreeIssue.Select();
            }
        }

        private void textBoxWholesaleDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxShopPrice.Select();
            }
        }

        private void textBoxShopPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxUnitCostPrice.Select();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllROLevelStock(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["BranchId"].Visible = false;
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveLast100AllBranchStock(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    gridView1.Columns["BranchId"].Visible = false;
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

        private void textBoxRetailDiscPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxDiscount.Select();

            }
        }

        private void textBoxWholesaleDiscPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxWholesaleDisc.Select();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateItemCodeV() &&
                            ValidateItemNameV();
            if (isValid)
            {
                insertPODTV();
                buttonNew1.Select();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            resetDetailV();
        }

        private void comboBoxItemCategoryV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxItemCategoryV.SelectedIndex != -1)
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategoryV.SelectedValue.ToString());
                objPODAL = new ClassPODAL();
                comboBoxSubCatV.DataSource = objPODAL.retreiveItemSubCategory(objPOBAL).Tables[0];
                comboBoxSubCatV.DisplayMember = "ItemSubCatName";
                comboBoxSubCatV.ValueMember = "ItemSubCatId";
                comboBoxSubCatV.SelectedIndex = -1;
            }
        }

        private void textBoxItemCodeV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxItemCategoryV.Select();
            }
        }

        private void comboBoxItemCategoryV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxSubCatV.Select();
            }
        }

        private void comboBoxSubCatV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxRackNoV.Select();
            }
        }

        private void textBoxRackNoV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxUnitV.Select();
            }
        }

        private void comboBoxUnitV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxItemNameV.Select();
            }
        }

        private void textBoxItemNameV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxItemNameSV.Select();
            }
        }

        private void textBoxItemNameSV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxQtyV.Select();
            }
        }

        private void textBoxQtyV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxMinQtyV.Select();
            }
        }

        private void textBoxMinQtyV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxSellingPriceV.Select();
            }
        }

        private void textBoxSellingPriceV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxRetailDiscPerV.Select();
            }
        }

        private void textBoxRetailDiscPerV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxDiscountV.Select();
            }
        }

        private void textBoxDiscountV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPrice2V.Select();
            }
        }

        private void textBoxPrice2V_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxWholesaleDiscPerV.Select();
            }
        }

        private void textBoxWholesaleDiscPerV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxWholesaleDiscV.Select();
            }
        }

        private void textBoxWholesaleDiscV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxShopPriceV.Select();
            }
        }

        private void textBoxShopPriceV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxUnitCostPriceV.Select();
            }
        }

        private void textBoxUnitCostPriceV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxMinSellingPriceV.Select();
            }
        }

        private void textBoxMinSellingPriceV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxFreeIssueV.Select();
            }
        }

        private void textBoxFreeIssueV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxConvertionQty.Select();
            }
        }

        private void textBoxConvertionQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button8.Select();
            }
        }

        private void textBoxQtyV_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValueV();
        }

        private void textBoxUnitCostPriceV_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValueV();
        }

        private void buttonDeleteCat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this Item Category", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteItemCategory();
            }
        }

        private void buttonDeleteSubCat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this Item Category", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteItemSubCategory();
            }
        }

        private void textBoxMaintainQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxSellingPrice.Select();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBoxItemId.Text != "" && textBoxSerialNo.Text != "")
            {
                insertSerial();
            }
            
        }

        private void textBoxItemNameT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxQty.Select();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            createItemCode();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Update the existing code", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateBarcode();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text != "" && textBoxItemId.Text != "")
            {
                insertBarcode();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this Barcode?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    TempId = Convert.ToInt32(dataGridView1["BarcodeId", e.RowIndex].Value.ToString());
                    DeleteBarcode();
                }
            }
        }

        private void textBoxItemId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxItemId.Text != "" && Convert.ToInt32(textBoxItemId.Text) != 0)
            {
                fillBarcodeGrid();
            }
        }

        private void textBoxSearchItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxSearchWH.SelectedIndex != -1)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        objPOBAL = new ClassPOBAL();
                        objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                        objPOBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
                        objPODAL = new ClassPODAL();
                        gridControl1.DataSource = null;
                        objPOBAL.DtDataSet = objPODAL.retreiveAllStockByBranchItmCode(objPOBAL);
                        if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                        {
                            gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                            //gridView1.Columns["Discount"].Visible = false;
                            //gridView1.Columns["ItemsId"].Visible = false;
                            gridView1.Columns["BranchId"].Visible = false;
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
        }

        private void textBoxSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxSearchWH.SelectedIndex != -1)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        objPOBAL = new ClassPOBAL();
                        objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                        objPOBAL.ItemName = textBoxSearchName.Text.Trim();
                        objPODAL = new ClassPODAL();
                        gridControl1.DataSource = null;
                        objPOBAL.DtDataSet = objPODAL.retreiveAllStockByBranchItmName(objPOBAL);
                        if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                        {
                            gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                            //gridView1.Columns["Discount"].Visible = false;
                            //gridView1.Columns["ItemsId"].Visible = false;
                            gridView1.Columns["BranchId"].Visible = false;
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
        }

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedValue = lblBranchID.Text;
        }

        

        //private bool ValidateModelName()
        //{
        //    textBoxNewModel.Text = textBoxNewModel.Text.Trim();
        //    string errorCode = string.Empty;
        //    if ((string.IsNullOrEmpty(textBoxNewModel.Text)) || (textBoxNewModel.Text.Trim().Equals(string.Empty)))
        //    {
        //        errorCode = "Please Enter Model.";
        //    }
        //    string message = errorCode;
        //    errorProvider1.SetError(textBoxNewModel, message);
        //    if (message.Equals(string.Empty))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        #endregion

    }
}
