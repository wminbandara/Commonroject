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
    public partial class FormFixedAsset : Form
    {
        #region Local Variables
        Fixedasset objBAL = new Fixedasset();
        ClassPODAL objDAL = new ClassPODAL();

        #endregion

        #region Constructor
        public FormFixedAsset()
        {
            InitializeComponent();
        }

        #endregion

        private void buttonNew_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        #region Methods

        private void ResetAll()
        {
            textBoxAssetId.Text = "0";
            textBoxAssetCode.Clear();
            textBoxAssetName.Clear();
            textBoxQty.Text = "0";
            textBoxCost.Text = "0";
            textBoxWarrantyPeriad.Text = "0";
            textBoxNetValue.Text = "0";
            textBoxDepriciationPerPeriad.Text = "0";
            textBoxRemainingDepriationPeriod.Text = "0";
            dateTimePickerDepriationStart.Value = DateTime.Today;
            dateTimePickerLastDepreciationDate.Value = DateTime.Today;
        }

        private void insertFixedAsset()
        {
            try
            {
                objBAL = new Fixedasset();
                objBAL.AssetCode = textBoxAssetCode.Text.Trim();
                objBAL.AssetDescription = textBoxAssetName.Text.Trim();
                objBAL.Qty = Convert.ToDecimal(textBoxQty.Text);
                objBAL.UnitPrice = Convert.ToDecimal(textBoxCost.Text);
                objBAL.Amount = Convert.ToDecimal(textBoxNetValue.Text);
                objBAL.NetAmount = Convert.ToDecimal(textBoxNetValue.Text);
                objBAL.DepreciationPerPeriod = Convert.ToDecimal(textBoxDepriciationPerPeriad.Text);
                objBAL.TotalDepreciationPeriod = Convert.ToInt32(textBoxRemainingDepriationPeriod.Text);
                objBAL.WarrantyPeriod = Convert.ToInt32(textBoxRemainingDepriationPeriod.Text);
                objBAL.DepreciationStartDate = dateTimePickerDepriationStart.Value;
                objBAL.NextDepreciationDate = dateTimePickerLastDepreciationDate.Value;
                objBAL.CreatedUserId = Convert.ToInt32(lblUserId.Text);

                objDAL = new ClassPODAL();
                string count = objDAL.InsertFixedAsset(objBAL);
                textBoxAssetId.Text = count.ToString();

                if (count != "")
                {
                    MessageBox.Show("Fixed Asset Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            insertFixedAsset();
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBoxQty.Text)) || (textBoxQty.Text.Trim().Equals(string.Empty)))
            {
                textBoxQty.Text = "0.00";
            }
            else if ((string.IsNullOrEmpty(textBoxCost.Text)) || (textBoxCost.Text.Trim().Equals(string.Empty)))
            {
                textBoxCost.Text = "0.00";
            }
            else if (Convert.ToDecimal(textBoxQty.Text) > 0 && Convert.ToDecimal(textBoxCost.Text) > 0)
            {
                textBoxNetValue.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxCost.Text)).ToString();
            }
        }

        private void textBoxCost_TextChanged(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBoxQty.Text)) || (textBoxQty.Text.Trim().Equals(string.Empty)))
            {
                textBoxQty.Text = "0.00";
            }
            else if ((string.IsNullOrEmpty(textBoxCost.Text)) || (textBoxCost.Text.Trim().Equals(string.Empty)))
            {
                textBoxCost.Text = "0.00";
            }
            else if (Convert.ToDecimal(textBoxQty.Text) > 0 && Convert.ToDecimal(textBoxCost.Text) > 0)
            {
                textBoxNetValue.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxCost.Text)).ToString();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            FormSearchAsset frm = new FormSearchAsset();
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void textBoxWarrantyPeriad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxAssetId.Text == "" || Convert.ToInt32(textBoxAssetId.Text) == 0)
                {
                    textBoxRemainingDepriationPeriod.Text = textBoxWarrantyPeriad.Text;
                }
                textBoxDepriciationPerPeriad.Text = (Convert.ToDecimal(textBoxNetValue.Text) / Convert.ToDecimal(textBoxWarrantyPeriad.Text)).ToString("0.00");
            }
            catch
            {
            }
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}
