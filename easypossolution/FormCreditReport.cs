using easyBAL;
using easyDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormCreditReport : Form
    {
        #region Local Variables
        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();
        #endregion

        #region Constructor
        public FormCreditReport()
        {
            InitializeComponent();
        }
        #endregion

        

        #region Methods

        #endregion

        #region Events

        private void FormCreditReport_Load(object sender, EventArgs e)
        {
            try
            {
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                comboBoxSupplier.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierId";
                comboBoxSupplier.SelectedIndex = -1;

                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerId";
                comboBoxCustomer.SelectedIndex = -1;

                ClassCommonBAL objCBAL = new ClassCommonBAL();
                ClassMasterDAL objCDAL = new ClassMasterDAL();
                comboBoxNewArea.DataSource = objCDAL.retreiveAllareas(objCBAL).Tables[1];
                comboBoxNewArea.DisplayMember = "AreaName";
                comboBoxNewArea.ValueMember = "AreaId";
                comboBoxNewArea.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSupplier.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSupplierCredit rpt = new CrystalReportSupplierCredit();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSuppCreditSupp(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSupplierCredit rpt = new CrystalReportSupplierCredit();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSuppCreditAll(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomer.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportCustomerCredit rpt = new CrystalReportCustomerCredit();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom1.Value;
                    objBAL.date2 = dateTimePickerTo1.Value;
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveCustCreditCustomer(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer2.ReportSource = rpt;
                    crystalReportViewer2.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportCustomerCredit rpt = new CrystalReportCustomerCredit();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom1.Value;
                    objBAL.date2 = dateTimePickerTo1.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveCustCreditAll(objBAL);
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

        private void buttonExit2_Click_1(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedIndex != -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportCustomerCreditPaymentsNew rpt = new CrystalReportCustomerCreditPaymentsNew();
                objBAL = new ClassPOBAL();
                objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveCustCreditPaymentDetail(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer2.ReportSource = rpt;
                crystalReportViewer2.Refresh();
                Cursor.Current = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedIndex != -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportCustOutstanging rpt = new CrystalReportCustOutstanging();
                objBAL = new ClassPOBAL();
                objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveCustCreditAnalysis(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer2.ReportSource = rpt;
                crystalReportViewer2.Refresh();
                Cursor.Current = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxNewArea.SelectedIndex != -1)
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportCustomerCredit rpt = new CrystalReportCustomerCredit();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom1.Value;
                objBAL.date2 = dateTimePickerTo1.Value;
                objBAL.NewAreaId = Convert.ToInt32(comboBoxNewArea.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveCustCreditByArea(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer2.ReportSource = rpt;
                crystalReportViewer2.Refresh();
                Cursor.Current = Cursors.Default;
            }
        }

        private void buttonViewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL.date1 = dateTimePickerFromCust.Value;
                objBAL.date2 = dateTimePickerToCust.Value;
                gridControl4.DataSource = null;
                if (objDAL.retreiveCustomerSummary(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView4.OptionsView.ColumnAutoWidth = false;
                    gridView4.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL.date1 = dateTimePickerFromCust.Value;
                objBAL.date2 = dateTimePickerToCust.Value;
                gridControl4.DataSource = null;
                if (objDAL.retreiveSupplierSummary(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView4.OptionsView.ColumnAutoWidth = false;
                    gridView4.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //string FileName = "C:\\ExportData\\Commision.xls";
                //gridControl1.ExportToXls(FileName);
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl4.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl4.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl4.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl4.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl4.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl4.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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

        private void button7_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportCustomerCreditSummary rpt = new CrystalReportCustomerCreditSummary();
            objBAL = new ClassPOBAL();
            objBAL.date1 = dateTimePickerFrom1.Value;
            objBAL.date2 = dateTimePickerTo1.Value;
            //objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreiveCustCreditReport(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer2.ReportSource = rpt;
            crystalReportViewer2.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreiveCustomerTemplate(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView4.OptionsView.ColumnAutoWidth = false;
                    gridView4.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreiveSupplierTemplate(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView4.OptionsView.ColumnAutoWidth = false;
                    gridView4.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSupplier.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSupplierCreditPaymentsNew rpt = new CrystalReportSupplierCreditPaymentsNew();
                    objBAL = new ClassPOBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSuppCreditPaySupp(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
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
