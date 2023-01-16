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
    public partial class FormPurchaseRecord : Form
    {
        #region Local Variables
        public FormPurchaseOrder frm { set; get; }
        public FormPurchaseReturn frm1 { set; get; }

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();
        bool loadStatus;
        public bool ReturnStatus;

        #endregion

        #region Constructor

        public FormPurchaseRecord()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        

        #endregion

        

        #region Events

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                CrystalReportPurchasing rpt = new CrystalReportPurchasing();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePurchasingDatabyDate(objBAL);
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void ButtonReset1_Click(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today;
        }

        private void FormPurchaseRecord_Load(object sender, EventArgs e)
        {
            loadStatus = true;
            objBAL = new ClassPOBAL();
            objDAL = new ClassPODAL();
            comboBoxSupplierName.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
            comboBoxSupplierName.DisplayMember = "SupplierName";
            comboBoxSupplierName.ValueMember = "SupplierId";
            comboBoxSupplierName.SelectedIndex = -1;

            loadStatus = false;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void buttonGetData2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSupplierName.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportPurchasing rpt = new CrystalReportPurchasing();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePicker2.Value;
                    objBAL.date2 = dateTimePicker1.Value;
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplierName.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePurchasingDatabySup(objBAL);
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

        private void buttonReset2_Click(object sender, EventArgs e)
        {
            comboBoxSupplierName.SelectedValue = -1;
        }

        private void buttonGetdata3_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                CrystalReportPurchaseRtn rpt = new CrystalReportPurchaseRtn();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePurchaseReturnDatabyDate(objBAL);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSupplierName.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportPurchaseRtn rpt = new CrystalReportPurchaseRtn();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePicker2.Value;
                    objBAL.date2 = dateTimePicker1.Value;
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplierName.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePurchaseReturnbySup(objBAL);
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

        private void buttonViewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL.date1 = dateTimePickerFromCust.Value;
                objBAL.date2 = dateTimePickerToCust.Value;
                gridControl4.DataSource = null;
                if (objDAL.retreivePurchaseSummary(objBAL).Tables[0].Rows.Count > 0)
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

        #region Validation Methods

        #endregion

    }
}
