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
    public partial class FRMItemSpoilage : Form
    {
        #region Local Variables

        ClassPOBAL objPOBAL = new ClassPOBAL();
        ClassPODAL objPODAL = new ClassPODAL();

        private bool loadStatus = false;

        #endregion

        #region Constructor

        public FRMItemSpoilage()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void loadCategory()
        {
            try
            {
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();

                comboBoxItemCategory.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

                comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion        

        #region Events

        private void FRMItemSpoilage_Load(object sender, EventArgs e)
        {
            loadStatus = true;
            loadCategory();
            textBoxItemCode.Select();
            loadStatus = false;
        }

        private void comboBoxItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxQty.Text == "")
                {
                    MessageBox.Show("Please Enter qty.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text.Trim());
                    objPOBAL.ItemCode = textBoxItemCode.Text.Trim();
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    objPOBAL.Qty = Convert.ToDecimal(textBoxQty.Text);
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.Remarks = textBoxRemarks.Text.Trim();
                    objPODAL = new ClassPODAL();
                    int count1 = objPODAL.InsertSpoilage(objPOBAL);
                    if (count1 != 0)
                    {
                       MessageBox.Show("Item Spoilage Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       textBoxItemId.Text = "0";
                       textBoxItemCode.Text = "";
                       comboBoxItemCategory.SelectedIndex = -1;
                       textBoxQty.Text = "";
                       comboBoxBranch.SelectedIndex = 0;
                       textBoxRemarks.Text = "";
                       textBoxItemCode.Select();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void FRMItemSpoilage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm8 = new FormItemSearch();
                frm8.frm8 = this;
                frm8.form = 8;
                frm8.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                frm8.lblUser.Text = lblUser.Text.Trim();
                frm8.lblUserId.Text = lblUserId.Text;
                frm8.ShowDialog(this);
            }
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
                            textBoxItemId.Text = (values[7].ToString().Trim());
                            textBoxQty.Text = "";
                        }
                        textBoxQty.Select();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region Validation Methods



        #endregion

    }
}
