using easyBAL;
using easyDAL;
using System;
using System.Collections;
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
    public partial class FormPO : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        string FYear, ID;

        bool loadStatus, insertDTStatus, newStatus;

        #endregion

        #region Constructor

        public FormPO()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void ItemCodeKeyDown()
        {
            try
            {

                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                //objPOBAL.Wharehouse = "Wharehouse1";
                ClassPODAL objPODAL = new ClassPODAL();
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
                        //textBoxDiscount.Text = (values[2].ToString().Trim());
                        comboBoxUnit.Text = (values[3].ToString().Trim());
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
                        textBoxMinQty.Text = (values[6].ToString().Trim());
                        textBoxItemId.Text = (values[7].ToString().Trim());
                        textBoxQty.Text = "0";
                        //labelQty.Text = (values[8].ToString().Trim());
                        //comboBoxItemMode.Text = (values[9].ToString().Trim());
                        //textBoxItemNameS.Text = (values[10].ToString().Trim());
                        //textBoxWarranty.Text = (values[11].ToString().Trim());
                        textBoxFreeIssue.Text = (values[12].ToString().Trim());
                        //textBoxPrice2.Text = (values[13].ToString().Trim());
                        //textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                        //dateTimePickerInWarrStart.Value = Convert.ToDateTime(values[15]);
                        //dateTimePickerInWarrEnd.Value = Convert.ToDateTime(values[16]);
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

        private void ItemAutoComplete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemName(objInvBAL);

                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxItemCode.AutoCompleteCustomSource.Add(values[1].ToString());
                        //txtItemName.AutoCompleteCustomSource.Add(values[2].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Reset()
        {
            textBoxPOID.Clear();
            textBoxPONo.Clear();
            dateTimePickerPODate.Value = DateTime.Today;
            comboBoxSupplier.SelectedIndex = -1;
            textBoxContactPerson.Clear();
            textBoxAddress.Clear();
            textBoxRemarks.Clear();
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxFreeIssue.Text = "0.00";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxLocation.Clear();
            textBoxTotGrosse.Text = "0.00";
            ButtonSave.Enabled = true;
            dgView.Rows.Clear();
        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxMinQty.Text = "0";
            textBoxFreeIssue.Text = "0.00";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxLocation.Clear();   
            
        }

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemName.Clear();
            textBoxLocation.Clear();
            comboBoxUnit.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            textBoxMinQty.Text = "0.00";
            textBoxFreeIssue.Text = "0.00";
        }

        private void insertPOHD()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                objBAL.PONo = textBoxPONo.Text.Trim();
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objBAL.PurchaseDate = dateTimePickerPODate.Value;
                objBAL.ContactPerson = textBoxContactPerson.Text.Trim();
                objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.PONetTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassPODAL();
                int count = objDAL.InsertPOrderHD(objBAL);
                if (count != 0)
                {
                    insertPODT();
                }
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
                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    objBAL = new ClassPOBAL();
                    objBAL.POHDId = Convert.ToInt64(textBoxPOID.Text);
                    objBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                    objBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    objBAL.ItemCatId = Convert.ToInt32(dgView.Rows[i].Cells["ItemCatID"].Value);
                    objBAL.ItemUnit = dgView.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();
                    //objBAL.ItemLocation = dgView["ItemLocation", i].Value.ToString();
                    objBAL.PurchaseQty = Convert.ToDecimal(dgView.Rows[i].Cells["PurchaseQty"].Value);
                    objBAL.MinQty = Convert.ToDecimal(dgView.Rows[i].Cells["MinQty"].Value);
                    objBAL.FreeIssue = Convert.ToDecimal(dgView.Rows[i].Cells["FreeIssue"].Value.ToString());
                    objBAL.PurchasePrice = Convert.ToDecimal(dgView.Rows[i].Cells["PurchasePrice"].Value);
                    objBAL.SellingPrice = Convert.ToDecimal(dgView.Rows[i].Cells["SellingPrice"].Value);
                    //objBAL.Discount = Convert.ToDecimal(dgView["Discount", i].Value.ToString());
                    objBAL.NetAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objBAL.PurchaseDate = dateTimePickerPODate.Value;
                    objDAL = new ClassPODAL();
                    int count = objDAL.InsertPOrderDT(objBAL);
                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }

                }

                if (insertDTStatus == true)
                {
                    resetDetail();
                    MessageBox.Show("Purchasing Order Details Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ButtonSave.Enabled = false;
                    Reset();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemNetValue()
        {
            textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
        }

        private void fillPODtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                dgView.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePOHeaderIdData(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        int n = dgView.Rows.Add();
                        //int intQtyOrdered = int.Parse(txtQty.Text);

                        dgView.Rows[n].Cells["ItemsId"].Value = (values[2].ToString().Trim());
                        dgView.Rows[n].Cells["ItemCode"].Value = (values[3].ToString().Trim());
                        dgView.Rows[n].Cells["ItemCatId"].Value = (values[4].ToString().Trim());
                        dgView.Rows[n].Cells["ItemUnit"].Value = (values[5].ToString().Trim());
                        dgView.Rows[n].Cells["PurchaseQty"].Value = (values[6].ToString().Trim());
                        dgView.Rows[n].Cells["MinQty"].Value = (values[7].ToString().Trim());
                        dgView.Rows[n].Cells["PurchasePrice"].Value = (values[8].ToString().Trim());
                        dgView.Rows[n].Cells["SellingPrice"].Value = (values[9].ToString().Trim());
                        dgView.Rows[n].Cells["FreeIssue"].Value = (values[10].ToString().Trim());
                        dgView.Rows[n].Cells["NetAmount"].Value = (values[11].ToString().Trim());
                        dgView.Rows[n].Cells["ItemName"].Value = (values[12].ToString().Trim());
                        dgView.FirstDisplayedScrollingRowIndex = n;
                        dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        dgView.Rows[n].Selected = true;

                        textBoxItemCode.Text = "";
                        textBoxItemName.Text = "";
                        comboBoxUnit.Text = "";
                        textBoxQty.Text = "1";
                        textBoxMinQty.Text = "0";
                        textBoxFreeIssue.Text = "0";
                        textBoxUnitCostPrice.Text = "0.00";
                        textBoxSellingPrice.Text = "0";
                        textBoxNetAmount.Text = "0.00";                        
                        textBoxItemId.Text = "0";
                        comboBoxItemCategory.SelectedIndex = -1;
                        CalculateTotal();
                    }

                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void CalculateTotal()
        {
            try
            {
                
                decimal GrossTot = 0;

                int i = dgView.RowCount;

                for (int a = 0; a < i; a++)
                {
                    try
                    {
                        GrossTot += Convert.ToDecimal(dgView.Rows[a].Cells["NetAmount"].Value.ToString());
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                textBoxTotGrosse.Text = GrossTot.ToString("0.00");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillPOHDIdData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePOrderHDIdData(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxPOID.Text = (values[0].ToString().Trim());
                        textBoxPONo.Text = (values[1].ToString().Trim());
                        dateTimePickerPODate.Value = Convert.ToDateTime(values[2].ToString());
                        comboBoxSupplier.SelectedValue = (values[3]);
                        textBoxAddress.Text = (values[4].ToString().Trim());
                        textBoxContactPerson.Text = (values[5].ToString().Trim());
                        textBoxTotGrosse.Text = (values[6].ToString().Trim());
                        textBoxRemarks.Text = (values[7].ToString().Trim());
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createPONo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePOrerId(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxPOID.Text = (values[0]).ToString();
                        ID = (Convert.ToInt32(values[0])).ToString("00000");
                    }
                }
                FYear = DateTime.Now.Year.ToString();
                textBoxPONo.Text = ("PO/" + FYear + "/" + ID).ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemsGridAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                }

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
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[3].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[3];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                }

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
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByCat(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["ItemUnit"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                }

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
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByCode(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["ItemUnit"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;

                }

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
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.ItemName = textBoxSearchName.Text.Trim();
                ClassPODAL objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveItemsByName(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns["ItemLocation"].Visible = false;
                    //dataGridView1.Columns["ItemUnit"].Visible = false;
                    //dataGridView1.Columns["Wharehouse"].Visible = false;
                    //dataGridView1.Columns["SellingPrice"].Visible = false;
                    dataGridView1.Columns["Discount"].Visible = false;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["AvailableQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AddtoGrid()
        {
            try
            {
                    int n = dgView.Rows.Add();

                    dgView.Rows[n].Cells["ItemsId"].Value = textBoxItemId.Text;
                    dgView.Rows[n].Cells["ItemCode"].Value = textBoxItemCode.Text;
                    dgView.Rows[n].Cells["ItemCatId"].Value = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    dgView.Rows[n].Cells["ItemUnit"].Value = comboBoxUnit.Text;
                    dgView.Rows[n].Cells["PurchaseQty"].Value = textBoxQty.Text;
                    dgView.Rows[n].Cells["MinQty"].Value = textBoxMinQty.Text;
                    dgView.Rows[n].Cells["PurchasePrice"].Value = textBoxUnitCostPrice.Text;
                    dgView.Rows[n].Cells["SellingPrice"].Value = textBoxSellingPrice.Text;
                    dgView.Rows[n].Cells["FreeIssue"].Value = textBoxFreeIssue.Text;
                    dgView.Rows[n].Cells["NetAmount"].Value = textBoxNetAmount.Text;
                    dgView.Rows[n].Cells["ItemName"].Value = textBoxItemName.Text;

                    dgView.FirstDisplayedScrollingRowIndex = n;
                    dgView.CurrentCell = dgView.Rows[n].Cells[0];
                    dgView.Rows[n].Selected = true;

                    textBoxItemId.Text = "0";
                    textBoxItemCode.Text = "";
                    comboBoxItemCategory.SelectedIndex = -1;
                    comboBoxUnit.Text = "";
                    textBoxQty.Text = "0";
                    textBoxMinQty.Text = "0";
                    textBoxUnitCostPrice.Text= "0";
                    textBoxSellingPrice.Text= "0.00";
                    textBoxFreeIssue.Text= "0.00";
                    textBoxNetAmount.Text= "0.00";
                    textBoxItemName.Text = "";
                    CalculateTotal();
                textBoxItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void RemoveItem()
        {
            try
            {
                if (dgView.SelectedRows.Count > 0)
                {
                    dgView.Rows.RemoveAt(dgView.SelectedRows[0].Index);
                    //CalculateTotal();
                }
                else
                {
                    MessageBox.Show("Select one item to remove!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Events

        private void textBoxSearchItemCode_TextChanged(object sender, EventArgs e)
        {
            comboBoxCategorySearch.SelectedIndex = -1;
            if (textBoxSearchItemCode.Text == "")
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                fillItemsGridByCode();
            }
        }

        private void comboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxCategorySearch.SelectedIndex != -1)
            {
                fillItemsGridByCat();
            }
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            comboBoxCategorySearch.SelectedIndex = -1;
            if (textBoxSearchName.Text == "")
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                fillItemsGridByName();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillMinItemsGridAll();
        }

        private void FormPO_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                comboBoxSupplier.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierId";
                comboBoxSupplier.SelectedIndex = -1;

                comboBoxItemCategory.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

                //comboBoxCategorySearch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                //comboBoxCategorySearch.DisplayMember = "ItemCatName";
               // comboBoxCategorySearch.ValueMember = "ItemCatId";
               // comboBoxCategorySearch.SelectedIndex = -1;

                //ItemAutoComplete();

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            resetDetail();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            newStatus = true;
            Reset();
            //if (textBoxPOID.Text == "")
            //{
                createPONo();
            //}
                newStatus = false;
                comboBoxSupplier.Select();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddtoGrid();
        }

        #endregion

        private void ButtonDeleteLine_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Do you want to Delete this PO Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {
                 RemoveItem();
             }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxPOID.Text == "")
            {
                createPONo();
            }
            insertPOHD();

        }

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    //objPOBAL.Wharehouse = "Wharehouse1";
                    ClassPODAL objPODAL = new ClassPODAL();
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
                            //textBoxDiscount.Text = (values[2].ToString().Trim());
                            comboBoxUnit.Text = (values[3].ToString().Trim());
                            textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                            textBoxSellingPrice.Text = (values[5].ToString().Trim());
                            textBoxMinQty.Text = (values[6].ToString().Trim());
                            textBoxItemId.Text = (values[7].ToString().Trim());
                            textBoxQty.Text = "0";
                            //labelQty.Text = (values[8].ToString().Trim());
                            //comboBoxItemMode.Text = (values[9].ToString().Trim());
                            //textBoxItemNameS.Text = (values[10].ToString().Trim());
                            //textBoxWarranty.Text = (values[11].ToString().Trim());
                            textBoxFreeIssue.Text = (values[12].ToString().Trim());
                            //textBoxPrice2.Text = (values[13].ToString().Trim());
                            //textBoxSPPriceEffectFrom.Text = (values[14].ToString().Trim());
                            //dateTimePickerInWarrStart.Value = Convert.ToDateTime(values[15]);
                            //dateTimePickerInWarrEnd.Value = Convert.ToDateTime(values[16]);
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
        }

        private void textBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxUnitCostPrice.Select();
            }
        }

        private void textBoxMinQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxFreeIssue.Select();
            }
        }

        private void textBoxFreeIssue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxUnitCostPrice.Select();
            }
        }

        private void textBoxUnitCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxSellingPrice.Select();
            }
        }

        private void textBoxSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAdd.Select();
            }
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");
        }

        private void textBoxUnitCostPrice_TextChanged(object sender, EventArgs e)
        {
            textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text)).ToString("0.00");

        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (loadStatus == false && comboBoxSupplier.SelectedIndex != -1)
                {
                    textBoxAddress.Clear();
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSupplierAddress(objBAL);
                    if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        List<ArrayList> newval = new List<ArrayList>();
                        foreach (DataRow dRow in objBAL.DtDataSet.Tables[0].Rows)
                        {
                            ArrayList values = new ArrayList();
                            values.Clear();
                            foreach (object value in dRow.ItemArray)
                                values.Add(value);
                            newval.Add(values);
                            textBoxAddress.Text = (values[0].ToString().Trim());
                            textBoxContactPerson.Text = (values[1].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            FormPORecord frm = new FormPORecord();
            frm.ReturnStatus = false;
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxPOID_TextChanged(object sender, EventArgs e)
        {
            if (newStatus == false && textBoxPOID.Text != "")
            {
                fillPOHDIdData();
                fillPODtRec();
            }
            
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportPOrder rpt = new CrystalReportPOrder();
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePOData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (textBoxPOID.Text != "")
            {
                FormPurchaseInvoice frm = new FormPurchaseInvoice();
                bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPurchaseInvoice");

                if (formOpen)
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name.Equals("FormPurchaseInvoice"))
                        {
                            f.WindowState = FormWindowState.Normal;
                            f.BringToFront();
                            f.Activate();
                        }
                    }
                }
                else
                {
                    frm.lblUser.Text = lblUser.Text.Trim();
                    frm.lblUserId.Text = lblUserId.Text.Trim();
                    frm.lblBranchID.Text = lblBranchID.Text.Trim();
                    frm.POID = Convert.ToInt32(textBoxPOID.Text);
                    frm.resettoNew();
                    frm.fillPOHDIdData();
                    frm.fillPODtRec();
                    //frm.textBoxPOID.Text = textBoxPOID.Text;
                    frm.Show();
                }
            }
            
        }

        private void comboBoxSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxContactPerson.Select();
            }
        }

        private void textBoxContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxRemarks.Select();
            }
        }

        private void textBoxRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxItemCode.Select();
            }
        }

        private void FormPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm2 = new FormItemSearch();
                frm2.frm2 = this;
                frm2.form = 2;
                frm2.wh = 1;
                frm2.lblUser.Text = lblUser.Text.Trim();
                frm2.lblUserId.Text = "3";
                frm2.ShowDialog(this);
            }
        }

        



        #region Validation Methods



        #endregion
        
    }
}
