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

        int AdvanceID = 0;
        int AttendanceID = 0;
        int PaymentID = 0;

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
            GetAdvance();
        }

        private void GetAdvance()
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

        private void button63_Click(object sender, EventArgs e)
        {
            getAttendance();
        }

        private void getAttendance()
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

        private void button64_Click(object sender, EventArgs e)
        {
            this.Close();
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

        
        private void gridView4_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            

            //if (this.gridView4.GetFocusedRowCellValue("AdvanceID") == null)
            //    return;

            //AdvanceID = Convert.ToInt32(this.gridView4.GetFocusedRowCellValue("AdvanceID"));

            //DialogResult result = MessageBox.Show("Do you want Delete this Advance?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    DeleteById();
            //}
        }

        #region Methods

        private void DeleteById()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.Id = AdvanceID;

                ClassMasterDAL objDAL = new ClassMasterDAL();


                int count = objDAL.DeleteAdvance(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Advance record Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetAdvance();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAttendanceById()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.Id = AttendanceID;

                ClassMasterDAL objDAL = new ClassMasterDAL();


                int count = objDAL.DeleteAttendance(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Attendance Record Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getAttendance();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteSalaryById()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.Id = PaymentID;

                ClassMasterDAL objDAL = new ClassMasterDAL();


                int count = objDAL.DeleteSalaryRecord(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Salary Record Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSalary();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView4.GetFocusedRowCellValue("AdvanceID") == null)
                return;

            AdvanceID = Convert.ToInt32(this.gridView4.GetFocusedRowCellValue("AdvanceID"));

            DialogResult result = MessageBox.Show("Do you want Delete this Advance?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteById();
            }
        }

        private void gridView18_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView18.GetFocusedRowCellValue("EmployeeAttendanceId") == null)
                return;

            AttendanceID = Convert.ToInt32(this.gridView18.GetFocusedRowCellValue("EmployeeAttendanceId"));

            DialogResult result = MessageBox.Show("Do you want Delete this Attendance Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteAttendanceById();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetSalary();
        }

        #region Events

        private void GetSalary()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL.date1 = dateTimePicker2.Value;
                objBAL.date2 = dateTimePicker1.Value;
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllSalaryPayment(objBAL).Tables[0].Rows.Count > 0)
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

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("PaymentID") == null)
                return;

            PaymentID = Convert.ToInt32(this.gridView1.GetFocusedRowCellValue("PaymentID"));

            DialogResult result = MessageBox.Show("Do you want Delete this Salary Payment?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteSalaryById();
            }
        }

        #region Validation Methods

        #endregion

    }
}
