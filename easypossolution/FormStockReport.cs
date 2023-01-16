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
    public partial class FormStockReport : Form
    {
        public FormStockReport()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllBranchStocksReport(objPOBAL);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStockReport_Load(object sender, EventArgs e)
        {

        }
    }
}
