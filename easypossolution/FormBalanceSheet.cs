using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using easyBAL;
using easyDAL;

namespace easyPOSSolution
{
    public partial class FormBalanceSheet : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormBalanceSheet()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportBalanceSheet rpt = new CrystalReportBalanceSheet();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker1.Value;
                objBAL.date2 = dateTimePicker2.Value;
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBalanceSheetbyDate(objBAL);
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