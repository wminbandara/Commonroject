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
    public partial class FormSpoilageReport : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();
        bool loadStatus;

        #endregion

        #region Constructor

        public FormSpoilageReport()
        {
            InitializeComponent();
        }

        #endregion

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                CrystalReportDamageN rpt = new CrystalReportDamageN();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSpoilageDatabyDate(objBAL);
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

        #region Methods


        #endregion


        #region Events



        #endregion



        #region Validation Methods



        #endregion

    }
}
