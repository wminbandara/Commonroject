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
    public partial class FormItemDiscount : Form
    {
        #region Local Variables

        ClassPOBAL objPOBAL = new ClassPOBAL();
        ClassPODAL objPODAL = new ClassPODAL();

        bool loadStatus;

        #endregion

        #region Constructor
        public FormItemDiscount()
        {
            InitializeComponent();
        }

        #endregion
        

        #region Methods

        private void loadCategory()
        {
            try
            {
                loadStatus = true;
                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                comboBoxItemCategory.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[2];
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

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemId.Clear();
            textBoxItemName.Clear();
            textBoxItemNameS.Clear();
            textBoxDiscount.Text = "0.00";
            comboBoxUnit.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxSellingPrice.Text = "0.00";
            comboBoxItemMode.Text = "";
        }

        private void fillData()
        {
            try
            {
                resetItemCodeData();
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
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
                        textBoxItemId.Text = (values[7].ToString().Trim());
                        comboBoxItemMode.Text = (values[9].ToString().Trim());
                        textBoxItemNameS.Text = (values[10].ToString().Trim());
                    }
                    textBoxDiscount.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertDiscount()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objPOBAL.date1 = dateTimePickerFromDate.Value;
                objPOBAL.date2 = dateTimePickerToDate.Value;
                objPOBAL.Discount = Convert.ToDecimal(textBoxDiscount.Text);             

                objPODAL = new ClassPODAL();
                int count = objPODAL.UpdateDiscount(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxItemCode.Clear();
                    resetItemCodeData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Events

        private void FormItemDiscount_Load(object sender, EventArgs e)
        {
            loadCategory();
        }


        #endregion

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                fillData();
            }
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {
            textBoxItemCode.Clear();
            resetItemCodeData();
        }

        private void textBoxItemCode_Validating(object sender, CancelEventArgs e)
        {
            fillData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateItemCode();
            if (isValid)
            {
                insertDiscount();
            }
        }



        #region Validation Methods

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

        #endregion
    }
}
