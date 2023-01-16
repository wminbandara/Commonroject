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
    public partial class FormSummaryReport : Form
    {
        #region Local Variables
        bool loadStatus;
        #endregion

        #region Constructor
        public FormSummaryReport()
        {
            InitializeComponent();
        }

        #endregion

        private void FormSummaryReport_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                if (objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                    comboBoxCustomer.DisplayMember = "CustomerName";
                    comboBoxCustomer.ValueMember = "CustomerId";
                    comboBoxCustomer.SelectedIndex = -1;
                }

                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                comboBoxSupplierName.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
                comboBoxSupplierName.DisplayMember = "SupplierName";
                comboBoxSupplierName.ValueMember = "SupplierId";
                comboBoxSupplierName.SelectedIndex = -1;
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExitCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomer.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportCustHistory rpt = new CrystalReportCustHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFromCust.Value;
                    objBAL.date2 = dateTimePickerToCust.Value;
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerHistorybyCust(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer5.ReportSource = rpt;
                    crystalReportViewer5.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportCustHistory rpt = new CrystalReportCustHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFromCust.Value;
                    objBAL.date2 = dateTimePickerToCust.Value;
                    //objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerHistoryAll(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer5.ReportSource = rpt;
                    crystalReportViewer5.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBoxCustomer.SelectedIndex = -1;
        }

        private void buttonViewReport3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSupplierName.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSuppHistory rpt = new CrystalReportSuppHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom3.Value;
                    objBAL.date2 = dateTimePickerTo3.Value;
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplierName.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSupplierHistoryBySupplier(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSuppHistory rpt = new CrystalReportSuppHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom3.Value;
                    objBAL.date2 = dateTimePickerTo3.Value;
                    //objBAL.SupplierId = Convert.ToInt32(comboBoxSupplierName.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSupplierHistoryAll(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBoxSupplierName.SelectedIndex = -1;
        }

        private void buttonExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewReport2_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit2_Click(object sender, EventArgs e)
        {

        }

        private void buttonViewReport2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBoxItemCode.Text == "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportItemHistory rpt = new CrystalReportItemHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    //objBAL.ItemCode = textBoxItemCode.Text.Trim();
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveItrmHistoryAll(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportItemHistory rpt = new CrystalReportItemHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.ItemCode = textBoxItemCode.Text.Trim();
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveItrmHistorybyItemCode(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormSummaryReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm7 = new FormItemSearch();
                frm7.frm7 = this;
                frm7.form = 7;
                frm7.wh = 1;
                frm7.lblUser.Text = "admin";
                frm7.lblUserId.Text = "3";
                frm7.ShowDialog(this);
            }
        }

        private void buttonView4_Click(object sender, EventArgs e)
        {
            try
            {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportCashBookHist rpt = new CrystalReportCashBookHist();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom4.Value;
                    objBAL.date2 = dateTimePickerTo4.Value;
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveCashbookHistory(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer4.ReportSource = rpt;
                    crystalReportViewer4.Refresh();
                    Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomer.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportCustAdvHistory rpt = new CrystalReportCustAdvHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFromCust.Value;
                    objBAL.date2 = dateTimePickerToCust.Value;
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerAdvAll(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer5.ReportSource = rpt;
                    crystalReportViewer5.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportCustAdvHistory rpt = new CrystalReportCustAdvHistory();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFromCust.Value;
                    objBAL.date2 = dateTimePickerToCust.Value;
                    //objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerHistoryAll(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer5.ReportSource = rpt;
                    crystalReportViewer5.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Methods


        #endregion


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}
