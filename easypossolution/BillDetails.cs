using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Windows.Forms.Design;
using easyPOSSolution;
using easyDAL;
using easyBAL;

namespace easyPOSSolution
{
    public partial class BillDetails : Form
    {

        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();
        #endregion

        #region Constructor

        public BillDetails()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #endregion

        #region Events

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportBillDetails rpt = new CrystalReportBillDetails();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBillDatabyDate(objBAL);
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

        private void buttonCash_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportBillDetails rpt = new CrystalReportBillDetails();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBillDatabyCash(objBAL);
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

        private void buttonCredit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportBillDetails rpt = new CrystalReportBillDetails();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBillDatabyCredit(objBAL);
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

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewReport2_Click(object sender, EventArgs e)
        {
            if (textBoxBillNo.Text != "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportBillDetails rpt = new CrystalReportBillDetails();
                    objBAL = new ClassPOBAL();
                    objBAL.BillNo = Convert.ToInt32(textBoxBillNo.Text);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveBillDatabyBillNo(objBAL);
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

        #endregion

        #region Validation Methods

        #endregion

    }
}
