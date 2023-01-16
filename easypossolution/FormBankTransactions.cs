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
    public partial class FormBankTransactions : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        #endregion

        #region Constructor
        public FormBankTransactions()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void insertOB()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.BalanceDate = dateTimePickerBalanceDate.Value;
                objBAL.BalanceAmount = Convert.ToDecimal(textBoxBalance.Text);
                if (comboBoxBank.SelectedIndex == -1)
                {
                    comboBoxBank.SelectedValue = 0;
                }
                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertOpeningBalance(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Opening Balance Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadBank()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxBank.DataSource = objDAL.retreiveBanks(objBAL).Tables[0];
                comboBoxBank.DisplayMember = "BankName";
                comboBoxBank.ValueMember = "BankId";
                comboBoxBank.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            insertOB();
        }

        #endregion

        private void FormBankTransactions_Load(object sender, EventArgs e)
        {
            loadBank();
        }

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewReport1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportBankBalance rpt = new CrystalReportBankBalance();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBankBalance(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #region Validation Methods



        #endregion
        

       
    }
}
