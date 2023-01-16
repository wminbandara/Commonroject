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
    public partial class FormGrossProfitReport : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        #endregion

        #region Constructor

        public FormGrossProfitReport()
        {
            InitializeComponent();
        }

        #endregion

       

        #region Methods

        #endregion

        #region Events

        private void FormGrossProfitReport_Load(object sender, EventArgs e)
        {
            ClassPOBAL objBAL = new ClassPOBAL();
            ClassPODAL objDAL = new ClassPODAL();
            if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
            {
                comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedIndex = 0;
            }

            ClassPOBAL objPOBAL = new ClassPOBAL();
            ClassPODAL objPODAL = new ClassPODAL();

            comboBoxItemCategory.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[3];
            comboBoxItemCategory.DisplayMember = "ItemCatName";
            comboBoxItemCategory.ValueMember = "ItemCatId";
            comboBoxItemCategory.SelectedIndex = -1;

            //objBAL = new ClassPOBAL();
            //objDAL = new ClassPODAL();
            //comboBoxItemCategory.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[3];
            //comboBoxItemCategory.DisplayMember = "ItemCatName";
            //comboBoxItemCategory.ValueMember = "ItemCatId";
            //comboBoxItemCategory.SelectedIndex = -1;
        }

        #endregion

        private void buttonViewReport1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportNewGrossProfit rpt = new CrystalReportNewGrossProfit();
                //CrystalReportGrossProfit rpt = new CrystalReportGrossProfit();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveProfitDatabyDate(objBAL);
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

        private void buttonViewReport2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //CrystalReportGrossProfit rpt = new CrystalReportGrossProfit();
                CrystalReportNewGrossProfit rpt = new CrystalReportNewGrossProfit();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom2.Value;
                objBAL.date2 = dateTimePickerTo2.Value;
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveGrossProfitItemCode(objBAL);
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

        private void buttonViewReport3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (comboBoxItemCategory.SelectedIndex != -1)
            //    {
            //        //if (comboBoxItemCategory.SelectedValue.ToString() == "6")
            //        //{
            //        //    Cursor.Current = Cursors.WaitCursor;
            //        //    CrystalReportReloadProfit rpt = new CrystalReportReloadProfit();
            //        //    objBAL = new ClassPOBAL();
            //        //    objBAL.date1 = dateTimePickerFrom3.Value;
            //        //    objBAL.date2 = dateTimePickerTo3.Value;
            //        //    objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
            //        //    objDAL = new ClassPODAL();
            //        //    objBAL.DtDataSet = objDAL.retreiveReloadProfitbyItemCategory(objBAL);
            //        //    rpt.SetDataSource(objBAL.DtDataSet);
            //        //    crystalReportViewer3.ReportSource = rpt;
            //        //    crystalReportViewer3.Refresh();
            //        //    Cursor.Current = Cursors.Default;
            //        //}
            //        //else
            //        //{
            //            Cursor.Current = Cursors.WaitCursor;
            //            CrystalReportGrossProfit rpt = new CrystalReportGrossProfit();
            //            objBAL = new ClassPOBAL();
            //            objBAL.date1 = dateTimePickerFrom3.Value;
            //            objBAL.date2 = dateTimePickerTo3.Value;
            //            objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
            //            objDAL = new ClassPODAL();
            //            objBAL.DtDataSet = objDAL.retreiveProfitbyItemCategory(objBAL);
            //            rpt.SetDataSource(objBAL.DtDataSet);
            //            crystalReportViewer3.ReportSource = rpt;
            //            crystalReportViewer3.Refresh();
            //            Cursor.Current = Cursors.Default;
            //        //}
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
                Cursor.Current = Cursors.WaitCursor;
                //CrystalReportGrossProfit rpt = new CrystalReportGrossProfit();
                CrystalReportNewGrossProfit rpt = new CrystalReportNewGrossProfit();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker2.Value;
                objBAL.date2 = dateTimePicker1.Value;
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveGrossProfitBranch(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
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
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportNewGrossProfitSumm rpt = new CrystalReportNewGrossProfitSumm();
                //CrystalReportGrossProfit rpt = new CrystalReportGrossProfit();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveProfitDatabyDate(objBAL);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxItemCategory.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportNewGrossProfit rpt = new CrystalReportNewGrossProfit();
                    //CrystalReportGrossProfit rpt = new CrystalReportGrossProfit();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePicker4.Value;
                    objBAL.date2 = dateTimePicker3.Value;
                    objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveProfitCatDatabyDate(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer4.ReportSource = rpt;
                    crystalReportViewer4.Refresh();
                    Cursor.Current = Cursors.Default;
                }
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
                if (comboBoxItemCategory.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportNewGrossProfitSumm rpt = new CrystalReportNewGrossProfitSumm();
                    //CrystalReportGrossProfit rpt = new CrystalReportGrossProfit();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePicker4.Value;
                    objBAL.date2 = dateTimePicker3.Value;
                    objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveProfitCatDatabyDate(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer4.ReportSource = rpt;
                    crystalReportViewer4.Refresh();
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
