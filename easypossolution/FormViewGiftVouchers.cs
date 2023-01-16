using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class FormViewGiftVouchers : Form
    {
        public FrmIssueGiftVoucher frm { set; get; }

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        public FormViewGiftVouchers()
        {
            InitializeComponent();
        }

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
                if (objDAL.retreiveGiftVouchers(objBAL).Tables[0].Rows.Count > 0)
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

        private void gridControl4_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridView view = (sender as GridControl).FocusedView as GridView;
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            GridColumnInfoArgs ci1 = viewInfo.ColumnsInfo.FirstColumnInfo;
            GridColumnInfoArgs ci2 = viewInfo.ColumnsInfo.LastColumnInfo;
            if (e.Shift && e.KeyCode == Keys.Tab)
            {
                if (ci1.Column == view.FocusedColumn)
                {
                    view.UnselectRow(view.FocusedRowHandle);
                    view.FocusedColumn = ci2.Column;
                    view.FocusedRowHandle = view.FocusedRowHandle - 1;
                    e.Handled = true;
                }
            }
        }

        private void gridView4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView4.GetFocusedRowCellValue("VoucherNo") == null)
                    return;
                frm.txtVoucherNo.Text = this.gridView4.GetFocusedRowCellValue("VoucherNo").ToString();
                frm.searchvoucher();
                
                this.Close();
            }
        }
    }
}
