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
    public partial class FormPaidIn : Form
    {
        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        public FormPaidIn()
        {
            InitializeComponent();
        }

        public void formLoad()
        {
            try
            {
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                if (objDAL.retreiveAllBranches(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxBranch.DataSource = objDAL.retreiveAllBranches(objBAL).Tables[0];
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.ValueMember = "BranchId";
                    comboBoxBranch.SelectedValue = lblBranchID.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            textBoxAmount.Text = "0";
            textBoxRemarks.Text = "";
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.PaymentAmount = Convert.ToDecimal(textBoxAmount.Text);
                objBAL.Remarks = textBoxRemarks.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());

                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertPaidIn(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Cash In Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxAmount.Text = "0";
                    textBoxRemarks.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPaidIn_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedValue = lblBranchID.Text;
        }
    }
}
