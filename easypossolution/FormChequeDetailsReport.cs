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
    public partial class FormChequeDetailsReport : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        #endregion

        #region Constructor

        public FormChequeDetailsReport()
        {
            InitializeComponent();
        }

        #endregion

        private void FormChequeDetailsReport_Load(object sender, EventArgs e)
        {
            try
            {
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                comboBoxSupplier.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierId";
                comboBoxSupplier.SelectedIndex = -1;

                comboBoxBranchReport1.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxBranchReport1.DisplayMember = "BranchName";
                comboBoxBranchReport1.ValueMember = "BranchId";
                comboBoxBranchReport1.SelectedIndex = -1;

                comboBoxBranchReport.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxBranchReport.DisplayMember = "BranchName";
                comboBoxBranchReport.ValueMember = "BranchId";
                comboBoxBranchReport.SelectedIndex = -1;

                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerId";
                comboBoxCustomer.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxBranchReport.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportIssueCheque rpt = new CrystalReportIssueCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveIssueChequeBYIssDateBranch(objBAL);
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
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportIssueCheque rpt = new CrystalReportIssueCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveIssueChequeBYIssDate(objBAL);
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
            
        }

        private void buttonIssueExp_Click(object sender, EventArgs e)
        {
            if (comboBoxBranchReport.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportIssueCheque rpt = new CrystalReportIssueCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerIssExFrom.Value;
                    objBAL.date2 = dateTimePickerIssExTo.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveIssueChequeBYeXPDateBranch(objBAL);
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
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportIssueCheque rpt = new CrystalReportIssueCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerIssExFrom.Value;
                    objBAL.date2 = dateTimePickerIssExTo.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveIssueChequeBYeXPDate(objBAL);
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxBranchReport.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportIssueCheque rpt = new CrystalReportIssueCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveIssueChequeBYSupplierBranch(objBAL);
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
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportIssueCheque rpt = new CrystalReportIssueCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveIssueChequeBYSupplier(objBAL);
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
            
        }

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBoxBranchReport1.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReceivedCheque rpt = new CrystalReportReceivedCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom1.Value;
                    objBAL.date2 = dateTimePickerTo1.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport1.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveReceivedChequeBYIssDateBranch(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReceivedCheque rpt = new CrystalReportReceivedCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom1.Value;
                    objBAL.date2 = dateTimePickerTo1.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveReceivedChequeBYIssDate(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBoxBranchReport1.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReceivedCheque rpt = new CrystalReportReceivedCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom2.Value;
                    objBAL.date2 = dateTimePickerTo2.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport1.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveReceivedChequeBYExpDateBranch(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReceivedCheque rpt = new CrystalReportReceivedCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom2.Value;
                    objBAL.date2 = dateTimePickerTo2.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveReceivedChequeBYExpDate(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxBranchReport1.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReceivedCheque rpt = new CrystalReportReceivedCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport1.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveReceivedChequeBYCustomerBranch(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReceivedCheque rpt = new CrystalReportReceivedCheque();
                    objBAL = new ClassPOBAL();
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveReceivedChequeBYCustomer(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void buttonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Methods

        #endregion

        #region Events

        #endregion

        #region Validation Methods

        #endregion

    }
}
