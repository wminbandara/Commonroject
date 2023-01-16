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
    public partial class FormTaxSalesReport : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        bool loadStatus;
        #endregion

        #region Constructor

        public FormTaxSalesReport()
        {
            InitializeComponent();
        }

        #endregion
    

        #region Methods


        #endregion


        #region Events

        private void FormTaxSalesReport_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
                {
                    comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.ValueMember = "BranchId";
                    comboBoxBranch.SelectedIndex = -1;
                }

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void buttonViewReport1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //FormReport REPORT = new FormReport();
                    //REPORT.Show();
                    CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateTax(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //FormReport REPORT = new FormReport();
                    //REPORT.Show();
                    CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateBranchTax(objBAL);
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

            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    //FormReport REPORT = new FormReport();
            //    //REPORT.Show();
            //    CrystalReportTaxSalesByDate rpt = new CrystalReportTaxSalesByDate();
            //    objBAL = new ClassPOBAL();
            //    objBAL.date1 = dateTimePickerFrom.Value;
            //    objBAL.date2 = dateTimePickerTo.Value;
            //    objDAL = new ClassPODAL();
            //    objBAL.DtDataSet = objDAL.retreiveTaxSalesDatabyDate(objBAL);
            //    rpt.SetDataSource(objBAL.DtDataSet);
            //    crystalReportViewer1.ReportSource = rpt;
            //    crystalReportViewer1.Refresh();
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void buttonViewReport2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    CrystalReportTaxSalesByDate rpt = new CrystalReportTaxSalesByDate();
            //    objBAL = new ClassPOBAL();
            //    objBAL.date1 = dateTimePickerFrom2.Value;
            //    objBAL.date2 = dateTimePickerTo2.Value;
            //    objBAL.ItemCode = textBoxItemCode.Text.Trim();
            //    objDAL = new ClassPODAL();
            //    objBAL.DtDataSet = objDAL.retreiveTaxSalesDatabyItemCode(objBAL);
            //    rpt.SetDataSource(objBAL.DtDataSet);
            //    crystalReportViewer2.ReportSource = rpt;
            //    crystalReportViewer2.Refresh();
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void buttonViewReport3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (comboBoxItemCategory.SelectedIndex != -1)
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        CrystalReportTaxSalesByDate rpt = new CrystalReportTaxSalesByDate();
            //        objBAL = new ClassPOBAL();
            //        objBAL.date1 = dateTimePickerFrom3.Value;
            //        objBAL.date2 = dateTimePickerTo3.Value;
            //        objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
            //        objDAL = new ClassPODAL();
            //        objBAL.DtDataSet = objDAL.retreiveTaxSalesDatabyItemCategory(objBAL);
            //        rpt.SetDataSource(objBAL.DtDataSet);
            //        crystalReportViewer3.ReportSource = rpt;
            //        crystalReportViewer3.Refresh();
            //        Cursor.Current = Cursors.Default;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //FormReport REPORT = new FormReport();
                    //REPORT.Show();
                    CrystalReportTaxSummary rpt = new CrystalReportTaxSummary();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateTaxSummary(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //FormReport REPORT = new FormReport();
                    //REPORT.Show();
                    CrystalReportTaxSummary rpt = new CrystalReportTaxSummary();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateBranchTaxSummary(objBAL);
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
