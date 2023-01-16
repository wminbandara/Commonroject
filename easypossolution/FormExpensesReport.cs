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
    public partial class FormExpensesReport : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        #endregion

        #region Constructor
        public FormExpensesReport()
        {
            InitializeComponent();
        }

        #endregion

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewReport1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportExpenses rpt = new CrystalReportExpenses();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveExpensesDatabyDate(objBAL);
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

        private void buttonViewReport3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportExpenses rpt = new CrystalReportExpenses();
            objBAL = new ClassPOBAL();
            objBAL.date1 = dateTimePickerFrom3.Value;
            objBAL.date2 = dateTimePickerTo3.Value;
            objBAL.PayCatId = Convert.ToInt32(comboBoxExpensesCat.SelectedValue.ToString());
            objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreiveExpensesByCategory(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer3.ReportSource = rpt;
            crystalReportViewer3.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void buttonExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormExpensesReport_Load(object sender, EventArgs e)
        {
            objBAL = new ClassPOBAL();
            objDAL = new ClassPODAL();
            comboBoxExpensesCat.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[4];
            comboBoxExpensesCat.DisplayMember = "CatDescription";
            comboBoxExpensesCat.ValueMember = "PayCatId";
            comboBoxExpensesCat.SelectedIndex = -1;
        }

        private void buttonViewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                    Cursor.Current = Cursors.WaitCursor;
                    objBAL.date1 = dateTimePickerFromCust.Value;
                    objBAL.date2 = dateTimePickerToCust.Value;
                    gridControl4.DataSource = null;
                    if (objDAL.retreiveSalaryAdvance(objBAL).Tables[0].Rows.Count > 0)
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

        #region Methods


        #endregion

        #region Events


        #endregion

        #region Validation Methods

        #endregion

    }
}
