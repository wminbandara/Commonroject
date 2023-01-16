using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
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
    public partial class FormPriceUpdate : Form
    {
        public FormPriceUpdate()
        {
            InitializeComponent();
        }

        int TempId = 0;
        bool loadStatus = false;

        void SearchItemByName()
        {
            try
            {
                textBoxItemCode1.Clear();
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemName = textBoxItemName1.Text.Trim();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsDataByName(objInvBAL);
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
                        textBoxItemCode1.Text = (values[0].ToString().Trim());
                    }
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
                        textBoxItemCode1.AutoCompleteCustomSource.Add(values[1].ToString());
                        textBoxItemName1.AutoCompleteCustomSource.Add(values[2].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormPriceUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode1.Select();
                FormItemSearch frm13 = new FormItemSearch();
                frm13.frm13 = this;
                frm13.form = 13;
                frm13.wh = 1;
                frm13.lblUser.Text = lblUser.Text;
                frm13.lblUserId.Text = "13";
                frm13.ShowDialog(this);
            }
        }

        public void ItemCodeKeyDown()
        {
            try
            {
                if (textBoxItemCode1.Text != "")
                {
                    textBoxItemName1.Text = "";

                    SearchItem();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SearchItem()
        {
            try
            {
                textBoxItemName1.Clear();
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemCode = textBoxItemCode1.Text;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsData(objInvBAL);
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

                        textBoxItemName1.Text = (values[0].ToString().Trim());
                        textBoxItemId.Text = (values[2].ToString().Trim());
                    }

                    fillRetailPriceGrid();
                    fillWholesalePriceGrid();
                    fillShopPriceGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillRetailPriceGrid()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveRetailPrices(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objInvBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["ItemRtPriceId"].Visible = false;
                    dataGridView1.Columns["ItemsId"].Visible = false;
                    dataGridView1.Columns["ItemCode"].Visible = false;
                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
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
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView2.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveWholesalePrices(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objInvBAL.DtDataSet.Tables[0];
                    dataGridView2.Columns["ItemWHPriceId"].Visible = false;
                    dataGridView2.Columns["ItemsId"].Visible = false;
                    dataGridView2.Columns["ItemCode"].Visible = false;
                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
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
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView3.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveShopPrices(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView3.DataSource = objInvBAL.DtDataSet.Tables[0];
                    dataGridView3.Columns["ShopPriceId"].Visible = false;
                    dataGridView3.Columns["ItemsId"].Visible = false;
                    dataGridView3.Columns["ItemCode"].Visible = false;
                    dataGridView3.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxItemCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                try
                {
                    if (textBoxItemCode1.Text != "")
                    {
                        textBoxItemName1.Text = "";

                        SearchItem();
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void buttonRP_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateRetailPrice();
            if (isValid)
            {
                insertRetailPrice();
            }
        }

        private void insertRetailPrice()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.RetailPrice = Convert.ToDecimal(textBoxRetail.Text);
                objBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.ItemCode = textBoxItemCode1.Text;
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertRetailPRice(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Retail Price Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillRetailPriceGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonWP_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateWholeSalePrice();
            if (isValid)
            {
                insertWholesalePrice();
            }
        }

        private void insertWholesalePrice()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.WholesalePrice = Convert.ToDecimal(textBoxWholesale.Text);
                objBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.ItemCode = textBoxItemCode1.Text;
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertWholesalePrice(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Wholesale Price Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillWholesalePriceGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSP_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateShopPrice();
            if (isValid)
            {
                insertShopPrice();
            }
        }

        private void insertShopPrice()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ShopPrice = Convert.ToDecimal(textBoxShop.Text);
                objBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.ItemCode = textBoxItemCode1.Text;
                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertShopPrice(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Shop Price Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillShopPriceGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateRetailPrice()
        {
            textBoxRetail.Text = textBoxRetail.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxRetail.Text)) || (textBoxRetail.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Retail Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxRetail.Text))
            {
                errorCode = "Invalid Retail Price.";
            }
            else if (Convert.ToDecimal(textBoxRetail.Text) < 0)
            {
                errorCode = "Invalid Retail Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxRetail, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateWholeSalePrice()
        {
            textBoxWholesale.Text = textBoxWholesale.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxWholesale.Text)) || (textBoxWholesale.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Wholesale Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxWholesale.Text))
            {
                errorCode = "Invalid Wholesale Price.";
            }
            else if (Convert.ToDecimal(textBoxWholesale.Text) < 0)
            {
                errorCode = "Invalid Wholesale Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxWholesale, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateShopPrice()
        {
            textBoxShop.Text = textBoxShop.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxShop.Text)) || (textBoxShop.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Shop Price.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxShop.Text))
            {
                errorCode = "Invalid Shop Price.";
            }
            else if (Convert.ToDecimal(textBoxShop.Text) < 0)
            {
                errorCode = "Invalid Shop Price.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxShop, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void loadCategory()
        {
            try
            {
                loadStatus = true;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                comboBoxItemCategory.DataSource = objPODAL.retreiveAllCategoryData(objPOBAL).Tables[0];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormPriceUpdate_Load(object sender, EventArgs e)
        {
            textBoxItemCode1.Select();
            loadCategory();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this Price?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    TempId = Convert.ToInt32(dataGridView1["ItemRtPriceId", e.RowIndex].Value.ToString());
                    DeleteRetailPrice();
                }
            }
        }

        private void DeleteRetailPrice()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemRtPriceId = TempId;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteRetailPrice(objInvBAL);
                if (count != 0)
                {
                    fillRetailPriceGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this Price?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    TempId = Convert.ToInt32(dataGridView2["ItemWHPriceId", e.RowIndex].Value.ToString());
                    DeleteWholesalePrice();
                }
            }
        }

        private void DeleteWholesalePrice()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemWHPriceId = TempId;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteWholesalePrice(objInvBAL);
                if (count != 0)
                {
                    fillWholesalePriceGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this Price?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    TempId = Convert.ToInt32(dataGridView3["ShopPriceId", e.RowIndex].Value.ToString());
                    DeleteShopPrice();
                }
            }
        }

        private void DeleteShopPrice()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ShopPriceId = TempId;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteShopPrice(objInvBAL);
                if (count != 0)
                {
                    fillShopPriceGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxItemCategory.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    ClassPODAL objPODAL = new ClassPODAL();
                    gridControl1.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllStockByItmCategory(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView1.Columns["Discount"].Visible = false;
                        //gridView1.Columns["ItemsId"].Visible = false;
                        //gridView1.Columns["BranchId"].Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you need to Increase the Prices?", "Price Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (textBoxCategoryAmount.Text != "")
                {
                    UpdateCategoryPriceIncrease();
                }
                else if (textBoxPricePercentage.Text != "")
                {
                    UpdateCategoryPricePercentageIncrease();
                }
                
            }
        }

        private void UpdateCategoryPriceIncrease()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objBAL.PriceMode = comboBoxPriceMethod.Text;
                objBAL.RetailPrice = Convert.ToDecimal(textBoxCategoryAmount.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateCategoryPriceIncrease(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Price Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxItemCategory.SelectedIndex = -1;
                    textBoxCategoryAmount.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCategoryPriceDecrease()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objBAL.PriceMode = comboBoxPriceMethod.Text;
                objBAL.RetailPrice = Convert.ToDecimal(textBoxCategoryAmount.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateCategoryPriceDecrease(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Price Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxItemCategory.SelectedIndex = -1;
                    textBoxCategoryAmount.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCategoryPricePercentageIncrease()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objBAL.PriceMode = comboBoxPriceMethod.Text;
                objBAL.RetailPrice = Convert.ToDecimal(textBoxPricePercentage.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateCategoryPricePercentageIncrease(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Price Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxItemCategory.SelectedIndex = -1;
                    textBoxPricePercentage.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCategoryPricePercentageDecrease()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objBAL.PriceMode = comboBoxPriceMethod.Text;
                objBAL.RetailPrice = Convert.ToDecimal(textBoxPricePercentage.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateCategoryPricePercentageDecrease(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Price Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxItemCategory.SelectedIndex = -1;
                    textBoxCategoryAmount.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you need to Decrease the Prices?", "Price Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (textBoxCategoryAmount.Text != "")
                {
                    UpdateCategoryPriceDecrease();
                }
                else if (textBoxPricePercentage.Text != "")
                {
                    UpdateCategoryPricePercentageDecrease();
                }

                
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            ItemAutoComplete();
        }

        private void textBoxItemName1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxItemName1.Text != "")
                {
                    SearchItemByName();
                    textBoxItemCode1_KeyDown(sender, e);
                }
            }
        }
       

    }
}
