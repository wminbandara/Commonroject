using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
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
    public partial class FormProductConversion : Form
    {
        #region Local Variables

        ClassPOBAL objPOBAL = new ClassPOBAL();
        ClassPODAL objPODAL = new ClassPODAL();

        #endregion

        #region Constructor

        public FormProductConversion()
        {
            InitializeComponent();
        }
        #endregion

        private void FormProductConversion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxFromItemCode.Select();
                FormItemSearch frm9 = new FormItemSearch();
                frm9.frm9 = this;
                frm9.form = 9;
                frm9.ShowDialog(this);
            }
            else if (e.KeyCode == Keys.F3)
            {
                textBoxToItemCode.Select();
                FormItemSearch frm9 = new FormItemSearch();
                frm9.frm9 = this;
                frm9.form = 10;
                frm9.ShowDialog(this);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateBalQty() &&
                            ValidateToQty();
            if (isValid)
            {
                updateConversion();
            }
        }

        #region Methods

        private void updateConversion()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objPOBAL.FromItemId = Convert.ToInt32(textBoxFromItemId.Text);
                objPOBAL.FromItemCode = textBoxFromItemCode.Text;
                objPOBAL.ToItemCode = textBoxToItemCode.Text;
                objPOBAL.ToItemId = Convert.ToInt32(textBoxToItemId.Text);
                objPOBAL.FromQty = Convert.ToDecimal(textBoxFromConvertQty.Text);
                objPOBAL.ToQty = Convert.ToDecimal(textBoxToConvertQty.Text);
                objPODAL = new ClassPODAL();
                int count = objPODAL.UpdateProductConversion(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Product Converted Successfully.", "Convert Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void reset()
        {
            textBoxFromItemId.Text = "0";
            textBoxFromItemCode.Text = "";
            textBoxFromQty.Text = "0";
            textBoxFromItemName.Text = "";
            textBoxFromConvertQty.Text = "0";

            textBoxToItemId.Text = "0";
            textBoxToItemCode.Text = "";
            textBoxToQty.Text = "0";
            textBoxToItemName.Text = "";
            textBoxToConvertQty.Text = "0";
        }

        #endregion


        #region Events



        #endregion



        #region Validation Methods

        private bool ValidateBalQty()
        {
            textBoxFromConvertQty.Text = textBoxFromConvertQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxFromConvertQty.Text)) || (textBoxFromConvertQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Valid Quentity.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxFromConvertQty.Text))
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxFromConvertQty.Text) < 0)
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxFromConvertQty.Text) > Convert.ToDecimal(textBoxFromQty.Text))
            {
                errorCode = "Balance Quentity Not Enough.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxFromConvertQty, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateToQty()
        {
            textBoxToConvertQty.Text = textBoxToConvertQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxToConvertQty.Text)) || (textBoxToConvertQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Valid Quentity.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxToConvertQty.Text))
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxToConvertQty.Text) < 0)
            {
                errorCode = "Invalid Quentity.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxToConvertQty, message);
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

        private void FormProductConversion_Load(object sender, EventArgs e)
        {
            ClassPOBAL objBAL = new ClassPOBAL();
            ClassPODAL objDAL = new ClassPODAL();
            comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
            comboBoxBranch.DisplayMember = "BranchName";
            comboBoxBranch.ValueMember = "BranchId";
            comboBoxBranch.SelectedIndex = 0;
        }
       
    }
}
