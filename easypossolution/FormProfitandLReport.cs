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
    public partial class FormProfitandLReport : Form
    {
        public FormProfitandLReport()
        {
            InitializeComponent();
        }

        private void LoadBranches()
        {
            try
            {
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                if (objDAL.retreiveAllBranches(objBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxBranch.DataSource = objDAL.retreiveAllBranches(objBAL).Tables[0];
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.ValueMember = "BranchId";
                    comboBoxBranch.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonViewReport1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportPandL rpt = new CrystalReportPandL();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveProfitLostbyDate(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportPandL rpt = new CrystalReportPandL();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveProfitLostbyDateBranch(objBAL);
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

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormProfitandLReport_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportPandL rpt = new CrystalReportPandL();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveProfitLostbyDateAvgCost(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportPandL rpt = new CrystalReportPandL();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom.Value;
                    objBAL.date2 = dateTimePickerTo.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveProfitLostbyDateBranchAvgCost(objBAL);
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
    }
}
