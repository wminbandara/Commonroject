using DevExpress.XtraGrid.Columns;
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
    public partial class FormBranchwiseReports : Form
    {

        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        #endregion

        #region Constructor

        public FormBranchwiseReports()
        {
            InitializeComponent();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom1.Value;
                objBAL.date2 = dateTimePickerTo1.Value;
                objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreiveBranchwiseSales(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    gridView4.Columns["CancelStatus"].FilterInfo = new ColumnFilterInfo("[CancelStatus] = '0'");
                    gridView4.Columns["CreatedDate"].DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom2.Value;
                objBAL.date2 = dateTimePickerTo2.Value;
                objDAL = new ClassPODAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveBranchwiseSalesRtn(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
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
                                gridControl1.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl1.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl1.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl1.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl1.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl1.ExportToMht(exportFilePath);
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom3.Value;
                objBAL.date2 = dateTimePickerTo3.Value;
                objDAL = new ClassPODAL();
                gridControl2.DataSource = null;
                if (objDAL.retreiveBranchwisePurchase(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl2.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView2.OptionsView.ColumnAutoWidth = false;
                    gridView2.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
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
                                gridControl2.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl2.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl2.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl2.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl2.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl2.ExportToMht(exportFilePath);
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

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom4.Value;
                objBAL.date2 = dateTimePickerTo4.Value;
                objDAL = new ClassPODAL();
                gridControl3.DataSource = null;
                if (objDAL.retreiveBranchwiseDamage(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl3.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView3.OptionsView.ColumnAutoWidth = false;
                    gridView3.BestFitColumns();
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
                                gridControl3.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl3.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl3.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl3.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl3.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl3.ExportToMht(exportFilePath);
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

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllBranchStocks(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl5.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    //gridView5.Columns["BranchId"].Visible = false;
                    gridView5.OptionsView.ColumnAutoWidth = false;
                    gridView5.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
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
                                gridControl5.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl5.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl5.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl5.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl5.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl5.ExportToMht(exportFilePath);
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

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerPaymentFrom.Value;
                objBAL.date2 = dateTimePickerPaymentTo.Value;
                objDAL = new ClassPODAL();
                gridControl6.DataSource = null;
                if (objDAL.retreiveBranchwisePayments(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl6.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView6.OptionsView.ColumnAutoWidth = false;
                    gridView6.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
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
                                gridControl6.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl6.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl6.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl6.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl6.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl6.ExportToMht(exportFilePath);
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

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerCustPayFrom.Value;
                objBAL.date2 = dateTimePickerCustPayTo.Value;
                objDAL = new ClassPODAL();
                gridControl7.DataSource = null;
                if (objDAL.retreiveBranchwiseCustomerPayments(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl7.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView7.OptionsView.ColumnAutoWidth = false;
                    gridView7.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button19_Click(object sender, EventArgs e)
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
                                gridControl7.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl7.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl7.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl7.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl7.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl7.ExportToMht(exportFilePath);
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

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerCollectionFrom.Value;
                objBAL.date2 = dateTimePickerCollectionTo.Value;
                objDAL = new ClassPODAL();
                gridControl8.DataSource = null;
                if (objDAL.retreiveBranchwiseCustomerPaymentsCollection(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl8.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView8.OptionsView.ColumnAutoWidth = false;
                    gridView8.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button22_Click(object sender, EventArgs e)
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
                                gridControl8.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl8.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl8.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl8.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl8.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl8.ExportToMht(exportFilePath);
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

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom3.Value;
                objBAL.date2 = dateTimePickerTo3.Value;
                objDAL = new ClassPODAL();
                gridControl2.DataSource = null;
                if (objDAL.retreiveBranchwisePurchaseSummary(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl2.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView2.OptionsView.ColumnAutoWidth = false;
                    gridView2.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFromStkAdj.Value;
                objBAL.date2 = dateTimePickerToStkAdj.Value;
                objDAL = new ClassPODAL();
                gridControl9.DataSource = null;
                if (objDAL.retreiveStockAdjustments(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl9.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView9.OptionsView.ColumnAutoWidth = false;
                    gridView9.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
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
                                gridControl9.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl9.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl9.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl9.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl9.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl9.ExportToMht(exportFilePath);
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

        private void button28_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker2.Value;
                objBAL.date2 = dateTimePicker1.Value;
                objDAL = new ClassPODAL();
                gridControl10.DataSource = null;
                if (objDAL.retreiveCustomerSales(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl10.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView10.OptionsView.ColumnAutoWidth = false;
                    gridView10.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button29_Click(object sender, EventArgs e)
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
                                gridControl10.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl10.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl10.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl10.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl10.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl10.ExportToMht(exportFilePath);
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

        private void button31_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveStockTemplateStocks(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl5.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    //gridView5.Columns["BranchId"].Visible = false;
                    gridView5.OptionsView.ColumnAutoWidth = false;
                    gridView5.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveStockMaintain(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl5.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    //gridView5.Columns["BranchId"].Visible = false;
                    gridView5.OptionsView.ColumnAutoWidth = false;
                    gridView5.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerPaymentFrom.Value;
                objBAL.date2 = dateTimePickerPaymentTo.Value;
                objDAL = new ClassPODAL();
                gridControl6.DataSource = null;
                if (objDAL.retreiveBranchwiseSupplierCredit(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl6.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView6.OptionsView.ColumnAutoWidth = false;
                    gridView6.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerCustPayFrom.Value;
                objBAL.date2 = dateTimePickerCustPayTo.Value;
                objDAL = new ClassPODAL();
                gridControl7.DataSource = null;
                if (objDAL.retreiveBranchwiseCustomerCreditData(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl7.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView7.OptionsView.ColumnAutoWidth = false;
                    gridView7.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxRefNo.Text == "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePicker4.Value;
                    objBAL.date2 = dateTimePicker3.Value;
                    objDAL = new ClassPODAL();
                    gridControl11.DataSource = null;
                    if (objDAL.retreiveBranchwiseSalesCard(objBAL).Tables[0].Rows.Count > 0)
                    {
                        gridControl11.DataSource = objBAL.DtDataSet.Tables[0];
                        //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                        //gridView1.Columns["CustomerId"].Visible = false;
                        gridView11.OptionsView.ColumnAutoWidth = false;
                        gridView11.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objBAL = new ClassPOBAL();
                    objBAL.ReferanceNo = textBoxRefNo.Text;
                    //objBAL.date2 = dateTimePicker3.Value;
                    objDAL = new ClassPODAL();
                    gridControl11.DataSource = null;
                    if (objDAL.retreiveBranchwiseSalesCardRefNo(objBAL).Tables[0].Rows.Count > 0)
                    {
                        gridControl11.DataSource = objBAL.DtDataSet.Tables[0];
                        //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                        //gridView1.Columns["CustomerId"].Visible = false;
                        gridView11.OptionsView.ColumnAutoWidth = false;
                        gridView11.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerPaymentFrom.Value;
                objBAL.date2 = dateTimePickerPaymentTo.Value;
                objDAL = new ClassPODAL();
                gridControl6.DataSource = null;
                if (objDAL.retreiveInvoiceWiseSupplierCredit(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl6.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView6.OptionsView.ColumnAutoWidth = false;
                    gridView6.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom1.Value;
                objBAL.date2 = dateTimePickerTo1.Value;
                objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreiveBranchwiseSalesSummary(objBAL).Tables[0].Rows.Count > 0)
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

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker6.Value;
                objBAL.date2 = dateTimePicker5.Value;
                objDAL = new ClassPODAL();
                gridControl12.DataSource = null;
                if (objDAL.retreiveBranchwiseStockMovement(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl12.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView12.OptionsView.ColumnAutoWidth = false;
                    gridView12.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button41_Click(object sender, EventArgs e)
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
                                gridControl12.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl12.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl12.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl12.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl12.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl12.ExportToMht(exportFilePath);
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

        private void button43_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker8.Value;
                objBAL.date2 = dateTimePicker7.Value;
                objDAL = new ClassPODAL();
                gridControl13.DataSource = null;
                if (objDAL.retreiveVehicleLogDetail(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl13.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView13.OptionsView.ColumnAutoWidth = false;
                    gridView13.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker8.Value;
                objBAL.date2 = dateTimePicker7.Value;
                objDAL = new ClassPODAL();
                gridControl13.DataSource = null;
                if (objDAL.retreiveVehicleLogSummary(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl13.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView13.OptionsView.ColumnAutoWidth = false;
                    gridView13.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button45_Click(object sender, EventArgs e)
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
                                gridControl13.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl13.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl13.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl13.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl13.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl13.ExportToMht(exportFilePath);
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

        private void button48_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker10.Value;
                objBAL.date2 = dateTimePicker9.Value;
                objDAL = new ClassPODAL();
                gridControl14.DataSource = null;
                if (objDAL.retreiveExpensesReport(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl14.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView14.OptionsView.ColumnAutoWidth = false;
                    gridView14.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button49_Click(object sender, EventArgs e)
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
                                gridControl14.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl14.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl14.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl14.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl14.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl14.ExportToMht(exportFilePath);
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

        private void button50_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker12.Value;
                objBAL.date2 = dateTimePicker11.Value;
                objDAL = new ClassPODAL();
                gridControl15.DataSource = null;
                if (objDAL.retreiveBranchwiseSalesWithStock(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl15.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView15.OptionsView.ColumnAutoWidth = false;
                    gridView15.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button51_Click(object sender, EventArgs e)
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
                                gridControl15.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl15.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl15.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl15.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl15.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl15.ExportToMht(exportFilePath);
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

        private void button53_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveVarientStockTemplateStocks(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl5.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    //gridView5.Columns["BranchId"].Visible = false;
                    gridView5.OptionsView.ColumnAutoWidth = false;
                    gridView5.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllBranchSerialSummary(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl5.DataSource = objPOBAL.DtDataSet.Tables[0];
                    gridView5.OptionsView.ColumnAutoWidth = false;
                    gridView5.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker14.Value;
                objBAL.date2 = dateTimePicker13.Value;
                objDAL = new ClassPODAL();
                gridControl16.DataSource = null;
                if (objDAL.retreiveBranchStockTransfer(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl16.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView16.OptionsView.ColumnAutoWidth = false;
                    gridView16.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button56_Click(object sender, EventArgs e)
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
                                gridControl16.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl16.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl16.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl16.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl16.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl16.ExportToMht(exportFilePath);
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

        private void button60_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker16.Value;
                objBAL.date2 = dateTimePicker15.Value;
                objDAL = new ClassPODAL();
                gridControl17.DataSource = null;
                if (objDAL.retreiveBranchProduction(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl17.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView17.OptionsView.ColumnAutoWidth = false;
                    gridView17.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button59_Click(object sender, EventArgs e)
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
                                gridControl17.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl17.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl17.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl17.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl17.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl17.ExportToMht(exportFilePath);
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

        private void button63_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker18.Value;
                objBAL.date2 = dateTimePicker17.Value;
                ClassPODAL objDAL = new ClassPODAL();
                gridControl18.DataSource = null;
                if (objDAL.retreiveAllAttendance(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl18.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView18.Columns["AttendanceIn"].DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
                    gridView18.Columns["AttendanceOut"].DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
                    gridView18.OptionsView.ColumnAutoWidth = false;
                    gridView18.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button62_Click(object sender, EventArgs e)
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
                                gridControl18.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl18.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl18.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl18.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl18.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl18.ExportToMht(exportFilePath);
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

        private void button64_Click(object sender, EventArgs e)
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
