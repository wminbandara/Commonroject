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
    public partial class FormCheqDetails : Form
    {
        #region Local Variables

        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        #endregion

        #region Constructor

        public FormCheqDetails()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void ReceivedChq()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.date1 = dateTimePicker2.Value;
                objBAL.date2 = dateTimePicker1.Value;
                objDAL = new ClassSODAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveReceivedChq(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView2.Columns["CustChqId"].Visible = false;
                    dataGridView2.Columns["ChequeAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.Columns["ChequeAmount"].DefaultCellStyle.Format = "0.00";
                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IssueChq()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassSODAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveIssueChq(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["SuppChqId"].Visible = false;
                    dataGridView1.Columns["ChequeAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.Columns["ChequeAmount"].DefaultCellStyle.Format = "0.00";
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

        #endregion

        private void buttonGetData2_Click(object sender, EventArgs e)
        {
            ReceivedChq();
        }

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            IssueChq();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Do you want delete this Cheque record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.CustChqId = Convert.ToInt32(dataGridView2["CustChqId", e.RowIndex].Value.ToString());
                        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.DeleteCustomerCheque(objInvBAL);
                        if (count != 0)
                        {
                            ReceivedChq();
                            MessageBox.Show("Successfully Deleted.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Do you want delete this Cheque record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.SuppChqId = Convert.ToInt32(dataGridView1["SuppChqId", e.RowIndex].Value.ToString());
                        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.DeleteSupplierCheque(objInvBAL);
                        if (count != 0)
                        {
                            IssueChq();
                            MessageBox.Show("Successfully Deleted.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion
    }
}
