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
    public partial class FreeIssueReport : Form
    {
        public FreeIssueReport()
        {
            InitializeComponent();
        }

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                CrystalReportFreeIssue rpt = new CrystalReportFreeIssue();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveFreeIssueDatabyDate(objBAL);
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
    }
}
