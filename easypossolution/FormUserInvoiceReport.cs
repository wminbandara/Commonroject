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
    public partial class FormUserInvoiceReport : Form
    {

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        public FormUserInvoiceReport()
        {
            InitializeComponent();
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportBillDetailsSummary rpt = new CrystalReportBillDetailsSummary();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objBAL.UserID = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBillDatabyDateUser(objBAL);
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
    }
}
