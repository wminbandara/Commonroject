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
    public partial class FormMenu : Form
    {
        #region Local Variables
        ClassPOBAL objPOBAL = new ClassPOBAL();
        ClassPODAL objPODAL = new ClassPODAL();
        #endregion

        #region Constructor
        public FormMenu()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemId.Text = "0";
            textBoxItemName.Clear();
            comboBoxPortion.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
        }

        private void fillItemsGridAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objPOBAL.DtDataSet.Tables[2];
                    dataGridView1.Columns["ItemsId"].Visible = false;
                    dataGridView1.Columns["ItemCatId"].Visible = false;
                    dataGridView1.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        private void resetDetail()
        {
            textBoxItemId.Text = "0";
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxPortion.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
        }

        private void insertMenu()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objPOBAL.ItemName = textBoxItemName.Text.Trim();
                if (comboBoxPortion.Text == "Small")
                {
                    objPOBAL.Portion = "S";
                }
                if (comboBoxPortion.Text == "Medium")
                {
                    objPOBAL.Portion = "M";
                }
                if (comboBoxPortion.Text == "Large")
                {
                    objPOBAL.Portion = "L";
                }
                objPOBAL.CostPrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                objPOBAL.SellingPrice = Convert.ToDecimal(textBoxSellingPrice.Text);

                objPODAL = new ClassPODAL();
                int count = objPODAL.InsertUpdateMenu(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Menu Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetDetail();
                    fillItemsGridAll();
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
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[2].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxItemId.Text = (values[0].ToString().Trim());
                        comboBoxItemCategory.SelectedValue = (values[1].ToString());
                        textBoxItemName.Text = (values[2].ToString().Trim());
                        if ((values[3].ToString()) == "S")
                        {
                            comboBoxPortion.Text = "Small";
                        }
                        if ((values[3].ToString()) == "M")
                        {
                            comboBoxPortion.Text = "Medium";
                        }
                        if ((values[3].ToString()) == "L")
                        {
                            comboBoxPortion.Text = "Large";
                        }
                        textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
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
                int count = objPODAL.DeleteMenuItem(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Deleted Successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetDetail();
                    fillItemsGridAll();
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
                int count = objDAL.InsertItemCategory(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Category Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCategory();
                    textBoxCategory.Clear();
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
                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                comboBoxItemCategory.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[3];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Events

        private void FormMenu_Load(object sender, EventArgs e)
        {
            loadCategory();
            fillItemsGridAll();
        }

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                fillItemCodeData();
            }
        }

        private void textBoxItemCode_Validating(object sender, CancelEventArgs e)
        {
            fillItemCodeData();
        }

        #endregion

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            resetDetail();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateItemCode() &&
                            ValidateItemName() &&
                            ValidateIteCategory() &&
                            ValidateCostPrice() &&
                            ValidateSellPrice();
            if (isValid)
            {
                insertMenu();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateItemId();
            if (isValid)
            {
                DeleteItem();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                textBoxItemCode.Text = dataGridView1["MenuCode", e.RowIndex].Value.ToString();
                fillItemCodeData();
            }
        }

        private void buttonExpCatSave_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateCategoryName();
            if (isValid)
            {
                insertCategory();
            }
        }

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
        #endregion

        
    }
}
