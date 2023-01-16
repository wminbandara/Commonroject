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
    public partial class frmOpeningBalance : Form
    {
        ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
        public frmInvoice frm { set; get; }

        public frmOpeningBalance()
        {
            InitializeComponent();
        }

        private void SaveOpenBalance()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();

                objInvBAL.UserId = Convert.ToInt32(lblUserId.Text);//lblUserId.Text
                objInvBAL.OpeningBalance = Convert.ToDecimal(textBoxOpeningBalance.Text);
                objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.InsertOpeningBalance(objInvBAL);
                if (count != 0)
                {
                    MessageBox.Show("Opening Balance Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.fillCashBalance();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveOpenBalance();

        }

        private void textBoxOpeningBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                SaveOpenBalance();
            }
        }

        private void frmOpeningBalance_Load(object sender, EventArgs e)
        {
            formLoad();
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

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedValue = lblBranchID.Text;
        }
    }
}
