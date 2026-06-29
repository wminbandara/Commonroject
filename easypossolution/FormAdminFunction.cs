using easyBAL;
using easyDAL;
using System;
using System.Collections;
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
    public partial class FormAdminFunction : Form
    {
        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9, Option10, Option11, Option12, Option13, Option14, Option15, Option16, Option17, Option18, Option19, Option20, Option21, Option22, Option23, Option24, Option25, Option26, Option27;
        ArrayList alistOption = new ArrayList();
        ArrayList alistForm = new ArrayList();

        public FormAdminFunction()
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PrintSummary();
        }

        private void PrintSummary()
        {
            try
            {
                DialogResult result = MessageBox.Show("If you want to print summary select Yes, To view select No.?", "Printing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (Option4 == true || Option5 == true || Option8 == true || Option9 == true || Option10 == true || Option11 == true || Option17 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                        ClassPOBAL objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerChqExpDate.Value;
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                        if (comboBoxUser.SelectedIndex == -1)
                        {
                            comboBoxUser.SelectedValue = 0;
                        }
                        objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                        ClassPODAL objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                        ClassPOBAL objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerChqExpDate.Value;
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                        if (comboBoxUser.SelectedIndex == -1)
                        {
                            comboBoxUser.SelectedValue = 0;
                        }
                        objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                        ClassPODAL objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                        rpt.PrintOptions.PrinterName = "";
                        rpt.PrintToPrinter(1, false, 0, 0);
                        Cursor.Current = Cursors.Default;
                    }
                    //else if (Option14 == true || Option15 == true)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                    //    ClassPOBAL objBAL = new ClassPOBAL();
                    //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    //    if (comboBoxBranch.SelectedIndex == -1)
                    //    {
                    //        comboBoxBranch.SelectedValue = 0;
                    //    }
                    //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    //    if (comboBoxUser.SelectedIndex == -1)
                    //    {
                    //        comboBoxUser.SelectedValue = 0;
                    //    }
                    //    objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                    //    ClassPODAL objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    crystalReportViewer1.ReportSource = rpt;
                    //    crystalReportViewer1.Refresh();
                    //    rpt.PrintOptions.PrinterName = "";
                    //    rpt.PrintToPrinter(1, false, 0, 0);
                    //    Cursor.Current = Cursors.Default;
                    //}
                    //else
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                    //    ClassPOBAL objBAL = new ClassPOBAL();
                    //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    //    if (comboBoxBranch.SelectedIndex == -1)
                    //    {
                    //        comboBoxBranch.SelectedValue = 0;
                    //    }
                    //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    //    if (comboBoxUser.SelectedIndex == -1)
                    //    {
                    //        comboBoxUser.SelectedValue = 0;
                    //    }
                    //    objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                    //    ClassPODAL objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    crystalReportViewer1.ReportSource = rpt;
                    //    crystalReportViewer1.Refresh();
                    //    rpt.PrintOptions.PrinterName = "";
                    //    rpt.PrintToPrinter(1, false, 0, 0);
                    //    Cursor.Current = Cursors.Default;
                    //}
                }
                else
                {
                    if (Option4 == true || Option5 == true || Option8 == true || Option9 == true || Option10 == true || Option11 == true || Option17 == true)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                        ClassPOBAL objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerChqExpDate.Value;
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                        if (comboBoxUser.SelectedIndex == -1)
                        {
                            comboBoxUser.SelectedValue = 0;
                        }
                        objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                        ClassPODAL objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        FormReport REPORT = new FormReport();
                        REPORT.Show();
                        CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                        ClassPOBAL objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerChqExpDate.Value;
                        if (comboBoxBranch.SelectedIndex == -1)
                        {
                            comboBoxBranch.SelectedValue = 0;
                        }
                        objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                        if (comboBoxUser.SelectedIndex == -1)
                        {
                            comboBoxUser.SelectedValue = 0;
                        }
                        objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                        ClassPODAL objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                        rpt.SetDataSource(objBAL.DtDataSet);
                        REPORT.crystalReportViewer1.ReportSource = rpt;
                        REPORT.crystalReportViewer1.Refresh();
                        Cursor.Current = Cursors.Default;
                    }
                    //else if (Option14 == true || Option15 == true)
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    FormReport REPORT = new FormReport();
                    //    REPORT.Show();
                    //    CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                    //    ClassPOBAL objBAL = new ClassPOBAL();
                    //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    //    if (comboBoxBranch.SelectedIndex == -1)
                    //    {
                    //        comboBoxBranch.SelectedValue = 0;
                    //    }
                    //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    //    if (comboBoxUser.SelectedIndex == -1)
                    //    {
                    //        comboBoxUser.SelectedValue = 0;
                    //    }
                    //    objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                    //    ClassPODAL objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    REPORT.crystalReportViewer1.ReportSource = rpt;
                    //    REPORT.crystalReportViewer1.Refresh();
                    //    Cursor.Current = Cursors.Default;
                    //}
                    //else
                    //{
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    FormReport REPORT = new FormReport();
                    //    REPORT.Show();
                    //    CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                    //    ClassPOBAL objBAL = new ClassPOBAL();
                    //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    //    if (comboBoxBranch.SelectedIndex == -1)
                    //    {
                    //        comboBoxBranch.SelectedValue = 0;
                    //    }
                    //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    //    if (comboBoxUser.SelectedIndex == -1)
                    //    {
                    //        comboBoxUser.SelectedValue = 0;
                    //    }
                    //    objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                    //    ClassPODAL objDAL = new ClassPODAL();
                    //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                    //    rpt.SetDataSource(objBAL.DtDataSet);
                    //    REPORT.crystalReportViewer1.ReportSource = rpt;
                    //    REPORT.crystalReportViewer1.Refresh();
                    //    Cursor.Current = Cursors.Default;
                    //}
                }

                //DialogResult result = MessageBox.Show("If you want to print summary select Yes, To view select No.?", "Printing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{
                //    //if (comboBoxUser.SelectedIndex == -1)
                //    //{
                //        if (Option6 == true || Option7 == true )
                //        {
                //            Cursor.Current = Cursors.WaitCursor;
                //            CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                //            ClassPOBAL objBAL = new ClassPOBAL();
                //            objBAL.date1 = dateTimePickerChqExpDate.Value;
                //            if (comboBoxBranch.SelectedIndex == -1)
                //            {
                //                comboBoxBranch.SelectedValue = 0;
                //            }
                //            objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                //            if (comboBoxUser.SelectedIndex == -1)
                //            {
                //                comboBoxUser.SelectedValue = 0;
                //            }
                //            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                //            ClassPODAL objDAL = new ClassPODAL();
                //            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                //            rpt.SetDataSource(objBAL.DtDataSet);
                //            crystalReportViewer1.ReportSource = rpt;
                //            crystalReportViewer1.Refresh();
                //            rpt.PrintOptions.PrinterName = "";
                //            rpt.PrintToPrinter(1, false, 0, 0);
                //            Cursor.Current = Cursors.Default;

                //            //if (comboBoxBranch.SelectedIndex == -1)
                //            //{
                //            //    Cursor.Current = Cursors.WaitCursor;
                //            //    CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                //            //    ClassPOBAL objBAL = new ClassPOBAL();
                //            //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                //            //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                //            //    ClassPODAL objDAL = new ClassPODAL();
                //            //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
                //            //    rpt.SetDataSource(objBAL.DtDataSet);
                //            //    crystalReportViewer1.ReportSource = rpt;
                //            //    crystalReportViewer1.Refresh();
                //            //    rpt.PrintOptions.PrinterName = "";
                //            //    rpt.PrintToPrinter(1, false, 0, 0);
                //            //    Cursor.Current = Cursors.Default;
                //            //}
                //            //else
                //            //{
                //            //    Cursor.Current = Cursors.WaitCursor;
                //            //    CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                //            //    ClassPOBAL objBAL = new ClassPOBAL();
                //            //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                //            //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                //            //    ClassPODAL objDAL = new ClassPODAL();
                //            //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNewBranch(objBAL);
                //            //    rpt.SetDataSource(objBAL.DtDataSet);
                //            //    crystalReportViewer1.ReportSource = rpt;
                //            //    crystalReportViewer1.Refresh();
                //            //    rpt.PrintOptions.PrinterName = "";
                //            //    rpt.PrintToPrinter(1, false, 0, 0);
                //            //    Cursor.Current = Cursors.Default;
                //            //}

                //        }
                //        else if (Option14 == true || Option15 == true)
                //        {
                //            //if (comboBoxBranch.SelectedIndex == -1)
                //            //{
                //                Cursor.Current = Cursors.WaitCursor;
                //                CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                //                ClassPOBAL objBAL = new ClassPOBAL();
                //                objBAL.date1 = dateTimePickerChqExpDate.Value;
                //                if (comboBoxBranch.SelectedIndex == -1)
                //                {
                //                    comboBoxBranch.SelectedValue = 0;
                //                }
                //                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                //                if (comboBoxUser.SelectedIndex == -1)
                //                {
                //                    comboBoxUser.SelectedValue = 0;
                //                }
                //                objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                //                ClassPODAL objDAL = new ClassPODAL();
                //                objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                //                rpt.SetDataSource(objBAL.DtDataSet);
                //                crystalReportViewer1.ReportSource = rpt;
                //                crystalReportViewer1.Refresh();
                //                rpt.PrintOptions.PrinterName = "";
                //                rpt.PrintToPrinter(1, false, 0, 0);
                //                Cursor.Current = Cursors.Default;
                //            //}
                //            //else
                //            //{
                //            //    Cursor.Current = Cursors.WaitCursor;
                //            //    CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                //            //    ClassPOBAL objBAL = new ClassPOBAL();
                //            //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                //            //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                //            //    ClassPODAL objDAL = new ClassPODAL();
                //            //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNewBranch(objBAL);
                //            //    rpt.SetDataSource(objBAL.DtDataSet);
                //            //    crystalReportViewer1.ReportSource = rpt;
                //            //    crystalReportViewer1.Refresh();
                //            //    rpt.PrintOptions.PrinterName = "";
                //            //    rpt.PrintToPrinter(1, false, 0, 0);
                //            //    Cursor.Current = Cursors.Default;
                //            //}
                //        }
                //        else
                //        {
                //            //if (comboBoxBranch.SelectedIndex == -1)
                //            //{
                //                Cursor.Current = Cursors.WaitCursor;
                //                CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                //                //CrystalReportSummary5in rpt = new CrystalReportSummary5in();
                //                ClassPOBAL objBAL = new ClassPOBAL();
                //                objBAL.date1 = dateTimePickerChqExpDate.Value;
                //                if (comboBoxBranch.SelectedIndex == -1)
                //                {
                //                    comboBoxBranch.SelectedValue = 0;
                //                }
                //                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                //                if (comboBoxUser.SelectedIndex == -1)
                //                {
                //                    comboBoxUser.SelectedValue = 0;
                //                }
                //                objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue);
                //                ClassPODAL objDAL = new ClassPODAL();
                //                objBAL.DtDataSet = objDAL.retreiveSummaryDataNewCommon(objBAL);
                //                rpt.SetDataSource(objBAL.DtDataSet);
                //                crystalReportViewer1.ReportSource = rpt;
                //                crystalReportViewer1.Refresh();
                //                rpt.PrintOptions.PrinterName = "";
                //                rpt.PrintToPrinter(1, false, 0, 0);
                //                Cursor.Current = Cursors.Default;
                //            //}
                //            //else
                //            //{
                //            //    Cursor.Current = Cursors.WaitCursor;
                //            //    CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                //            //    //CrystalReportSummary5in rpt = new CrystalReportSummary5in();
                //            //    ClassPOBAL objBAL = new ClassPOBAL();
                //            //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                //            //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                //            //    ClassPODAL objDAL = new ClassPODAL();
                //            //    objBAL.DtDataSet = objDAL.retreiveSummaryDataNewBranch(objBAL);
                //            //    rpt.SetDataSource(objBAL.DtDataSet);
                //            //    crystalReportViewer1.ReportSource = rpt;
                //            //    crystalReportViewer1.Refresh();
                //            //    rpt.PrintOptions.PrinterName = "";
                //            //    rpt.PrintToPrinter(1, false, 0, 0);
                //            //    Cursor.Current = Cursors.Default;
                //            //}
                //        }
                //    }
                //    //else
                //    //{
                //    //    if (Option6 == true || Option7 == true)
                //    //    {
                //    //        Cursor.Current = Cursors.WaitCursor;
                //    //        CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                //    //        ClassPOBAL objBAL = new ClassPOBAL();
                //    //        objBAL.date1 = dateTimePickerChqExpDate.Value;
                //    //        objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                //    //        ClassPODAL objDAL = new ClassPODAL();
                //    //        objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                //    //        rpt.SetDataSource(objBAL.DtDataSet);
                //    //        crystalReportViewer1.ReportSource = rpt;
                //    //        crystalReportViewer1.Refresh();
                //    //        rpt.PrintOptions.PrinterName = "";
                //    //        rpt.PrintToPrinter(1, false, 0, 0);
                //    //        Cursor.Current = Cursors.Default;
                //    //    }
                //    //    else if (Option14 == true || Option15 == true)
                //    //    {
                //    //        Cursor.Current = Cursors.WaitCursor;
                //    //        CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                //    //        ClassPOBAL objBAL = new ClassPOBAL();
                //    //        objBAL.date1 = dateTimePickerChqExpDate.Value;
                //    //        objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                //    //        ClassPODAL objDAL = new ClassPODAL();
                //    //        objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                //    //        rpt.SetDataSource(objBAL.DtDataSet);
                //    //        crystalReportViewer1.ReportSource = rpt;
                //    //        crystalReportViewer1.Refresh();
                //    //        rpt.PrintOptions.PrinterName = "";
                //    //        rpt.PrintToPrinter(1, false, 0, 0);
                //    //        Cursor.Current = Cursors.Default;
                //    //    }
                //    //    else
                //    //    {
                //    //        Cursor.Current = Cursors.WaitCursor;
                //    //        CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                //    //        ClassPOBAL objBAL = new ClassPOBAL();
                //    //        objBAL.date1 = dateTimePickerChqExpDate.Value;
                //    //        objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                //    //        ClassPODAL objDAL = new ClassPODAL();
                //    //        objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                //    //        rpt.SetDataSource(objBAL.DtDataSet);
                //    //        crystalReportViewer1.ReportSource = rpt;
                //    //        crystalReportViewer1.Refresh();
                //    //        rpt.PrintOptions.PrinterName = "";
                //    //        rpt.PrintToPrinter(1, false, 0, 0);
                //    //        Cursor.Current = Cursors.Default;
                //    //    }
                //    //}


                //}
                //else
                //{
                //    if (comboBoxUser.SelectedIndex == -1)
                //    {
                //        if (Option4 == true)
                //        {
                //            Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                //            CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                //            ClassPOBAL objBAL = new ClassPOBAL();
                //            objBAL.date1 = dateTimePickerChqExpDate.Value;

                //            ClassPODAL objDAL = new ClassPODAL();
                //            objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
                //            rpt.SetDataSource(objBAL.DtDataSet);
                //REPORT.crystalReportViewer1.ReportSource = rpt;
                //REPORT.crystalReportViewer1.Refresh();
                //Cursor.Current = Cursors.Default;
                //        }
                //        else
                //        {
                //            Cursor.Current = Cursors.WaitCursor;
                //            FormReport REPORT = new FormReport();
                //            REPORT.Show();
                //            CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                //            ClassPOBAL objBAL = new ClassPOBAL();
                //            objBAL.date1 = dateTimePickerChqExpDate.Value;

                //            ClassPODAL objDAL = new ClassPODAL();
                //            objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
                //            rpt.SetDataSource(objBAL.DtDataSet);
                //            REPORT.crystalReportViewer1.ReportSource = rpt;
                //            REPORT.crystalReportViewer1.Refresh();
                //            Cursor.Current = Cursors.Default;
                //        }
                //    }
                //    else
                //    {
                //        if (Option4 == true)
                //        {
                //            Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                //            CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                //            ClassPOBAL objBAL = new ClassPOBAL();
                //            objBAL.date1 = dateTimePickerChqExpDate.Value;
                //            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                //            ClassPODAL objDAL = new ClassPODAL();
                //            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                //            rpt.SetDataSource(objBAL.DtDataSet);
                //            REPORT.crystalReportViewer1.ReportSource = rpt;
                //            REPORT.crystalReportViewer1.Refresh();
                //            Cursor.Current = Cursors.Default;
                //        }
                //        else
                //        {
                //            Cursor.Current = Cursors.WaitCursor;
                //            FormReport REPORT = new FormReport();
                //            REPORT.Show();
                //            CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                //            ClassPOBAL objBAL = new ClassPOBAL();
                //            objBAL.date1 = dateTimePickerChqExpDate.Value;
                //            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                //            ClassPODAL objDAL = new ClassPODAL();
                //            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                //            rpt.SetDataSource(objBAL.DtDataSet);
                //            REPORT.crystalReportViewer1.ReportSource = rpt;
                //            REPORT.crystalReportViewer1.Refresh();
                //            Cursor.Current = Cursors.Default;
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormAdminFunction_Load(object sender, EventArgs e)
        {
            ClassPOBAL objBAL = new ClassPOBAL();
            ClassPODAL objDAL = new ClassPODAL();
            if (objDAL.retreiveAllUsers(objBAL).Tables[0].Rows.Count > 0)
            {
                comboBoxUser.DataSource = objDAL.retreiveAllUsers(objBAL).Tables[0];
                comboBoxUser.DisplayMember = "UserName";
                comboBoxUser.ValueMember = "UserID";
                comboBoxUser.SelectedIndex = -1;
            }
            LoadBranches();
            fillDtRec();
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            fillOptions();
            userPermission();
        }

        private void userPermission()
        {
            try
            {
                simpleButtonReturn.Enabled = false;
                //buttonDelete.Enabled = false;
                BALUser objUser = new BALUser();
                //objUser.FORM_NAME = "User Registration";
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveUserPermission(objUser);
                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objUser.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        alistForm.Add(values[0].ToString());

                    }
                    for (int i = 0; i < alistForm.Count; i++)
                    {
                        //if (alistForm[i].ToString().Trim() == "ChangePrice")
                        //{
                        //    txtSellingPrice.ReadOnly = false;
                        //}
                        if (alistForm[i].ToString().Trim() == "Update Day End")
                        {
                            simpleButtonReturn.Enabled = true;
                            //buttonDelete.Enabled = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Discount")
                        //{
                        //    txtDisc.ReadOnly = false;
                        //    textBoxLDiscAmt.ReadOnly = false;
                        //    textBoxUnitDisc.ReadOnly = false;
                        //}
                        //if (alistForm[i].ToString().Trim() == "VisibleCost")
                        //{
                        //    label58.Visible = true;
                        //    textBoxCostPrice.Visible = true;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillOptions()
        {
            try
            {
                BALUser objUser = new BALUser();
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveAllOptions(objUser);
                if (objUser.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objUser.DtDataSet.Tables[1].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        alistOption.Add(values[0].ToString());

                    }
                    for (int i = 0; i < alistOption.Count; i++)
                    {
                        //if (alistOption[i].ToString().Trim() == "1")
                        //{
                        //    //PrintInvoiceStatus = true;
                        //    Option1 = true;
                        //}
                        if (alistOption[i].ToString().Trim() == "2")
                        {
                            Option2 = true;
                            //PrintDetailWithLogo = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "3")
                        {
                            Option3 = true;
                            //PrintDetailWithoutLogo = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "4")
                        {
                            Option4 = true;
                            //PrintDetailWithLogoSinhala = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "5")
                        {
                            Option5 = true;
                            //PrintDetailWithoutLogoSinhala = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "6")
                        {
                            Option6 = true;
                            //PrintwithoutDetailWithLogo = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "7")
                        {
                            Option7 = true;
                            //PrintwithoutDetailWithoutLogo = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "8")
                        {
                            Option8 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "9")
                        {
                            Option9 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "10")
                        {
                            Option10 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "11")
                        {
                            Option11 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "12")
                        {
                            Option12 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "13")
                        {
                            Option13 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "14")
                        {
                            Option14 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "15")
                        {
                            Option15 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "16")
                        {
                            Option16 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "17")
                        {
                            Option17 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "18")
                        {
                            Option18 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "19")
                        {
                            Option19 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "20")
                        {
                            Option20 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "21")
                        {
                            Option21 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "22")
                        {
                            Option22 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "23")
                        {
                            Option23 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "24")
                        {
                            Option24 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "25")
                        {
                            Option25 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "26")
                        {
                            Option26 = true;
                        }
                        else if (alistOption[i].ToString().Trim() == "27")
                        {
                            Option27 = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("If you want to print summary select Yes, To view select No.?", "Printing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //if (comboBoxBranch.SelectedIndex == -1)
                //{
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    if (comboBoxBranch.SelectedIndex == -1)
                    {
                        comboBoxBranch.SelectedValue = 0;
                    }
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDateCommon(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                //}
                //else
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                //    ClassPOBAL objBAL = new ClassPOBAL();
                //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                //    ClassPODAL objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDateBranch(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //    rpt.PrintOptions.PrinterName = "";
                //    rpt.PrintToPrinter(1, false, 0, 0);
                //    Cursor.Current = Cursors.Default;
                //}
            }
            else
            {
                //if (comboBoxBranch.SelectedIndex == -1)
                //{
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    if (comboBoxBranch.SelectedIndex == -1)
                    {
                        comboBoxBranch.SelectedValue = 0;
                    }
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDateCommon(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                //}
                //else
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    FormReport REPORT = new FormReport();
                //    REPORT.Show();
                //    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                //    ClassPOBAL objBAL = new ClassPOBAL();
                //    objBAL.date1 = dateTimePickerChqExpDate.Value;
                //    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                //    ClassPODAL objDAL = new ClassPODAL();
                //    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDateBranch(objBAL);
                //    rpt.SetDataSource(objBAL.DtDataSet);
                //    REPORT.crystalReportViewer1.ReportSource = rpt;
                //    REPORT.crystalReportViewer1.Refresh();
                //    Cursor.Current = Cursors.Default;
                //}
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedIndex = -1;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormReport REPORT = new FormReport();
            REPORT.Show();
            CrystalReportStockSummary rpt = new CrystalReportStockSummary();
            ClassPOBAL objBAL = new ClassPOBAL();
            objBAL.date1 = dateTimePickerChqExpDate.Value;
            ClassPODAL objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreiveStockSummarybyDate(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            REPORT.crystalReportViewer1.ReportSource = rpt;
            REPORT.crystalReportViewer1.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void simpleButtonReturn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to complete Day End?", "Day End Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateDayEnd();
            }
        }

        private void UpdateDayEnd()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    comboBoxBranch.SelectedValue = 1;
                }
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue);
                ClassMasterDAL objDAL = new ClassMasterDAL();


                int count = objDAL.UpdateDayEnd(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Day End Completed Susccessfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            insertCashHD();
        }

        bool insertDTStatus = false;
        private void insertCashHD()
        {
            try
            {

                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.CollectionDate = dateTimePickerChqExpDate.Value;
                objBAL.POGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.CreatedBy = Convert.ToInt32(comboBoxUser.SelectedValue);

                ClassPODAL objDAL = new ClassPODAL();
                string count = objDAL.InsertNewCashReturn(objBAL);
                textBoxPOID.Text = count.ToString();
                if (count != "")
                {
                    insertCashDT();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertCashDT()
        {
            try
            {
                if (dgView.Rows.Count > 0)
                {
                    for (int i = 0; i < dgView.Rows.Count; i++)
                    {

                        ClassPOBAL objBAL = new ClassPOBAL();
                        objBAL.CashCollectionhdId = Convert.ToInt32(textBoxPOID.Text);
                        objBAL.CashCollectionId = Convert.ToInt32(dgView.Rows[i].Cells["CashCollectionId"].Value);
                        objBAL.CollectionDate = dateTimePickerChqExpDate.Value;
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.CashAmount = Convert.ToDecimal(dgView.Rows[i].Cells["CashAmount"].Value);
                        objBAL.NoOfPieces = Convert.ToInt32(dgView.Rows[i].Cells["Quantity"].Value);
                        objBAL.GrossAmount = Convert.ToDecimal(dgView.Rows[i].Cells["NetAmount"].Value);

                        ClassPODAL objDAL = new ClassPODAL();
                        int count = objDAL.InsertCashRtnDT(objBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }


                    }


                }

                if (insertDTStatus == true)
                {
                    insertExpenses();
                    MessageBox.Show("Cash Amounts Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PrintSummary();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertExpenses()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.PayCatId = 10;
                objBAL.PaymentDate = dateTimePickerChqExpDate.Value;
                objBAL.PaymentAmount = Convert.ToDecimal(textBoxTotGrosse.Text);
                objBAL.Remarks = "Cash Handover by " + comboBoxUser.Text + " from Admin function";
                if (comboBoxUser.SelectedIndex == -1)
                {
                    objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                }
                else
                {
                    objBAL.CreatedBy = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                }

                objBAL.Status1 = 1;
                objBAL.BranchId = 1;
                objBAL.PayModeId = 1;
                objBAL.BankId = 0;
                objBAL.VehicleId = 0;
                ClassMasterDAL objDAL = new ClassMasterDAL();

                string count = objDAL.InsertNewExpenses(objBAL);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double CellQtyChange()
        {
            double sum = 0;
            for (int i = 0; i < dgView.Rows.Count; ++i)
            {
                //dgView.Rows[i].Cells["Amount"].Value = (Convert.ToDecimal(dgView.Rows[i].Cells["Qty"].Value) * Convert.ToDecimal(dgView.Rows[i].Cells["Price"].Value)).ToString("0.00");
                dgView.Rows[i].Cells["NetAmount"].Value = (Convert.ToDecimal(dgView.Rows[i].Cells["CashAmount"].Value) * Convert.ToDecimal(dgView.Rows[i].Cells["Quantity"].Value)).ToString("0.00");

                double d = 0;
                Double.TryParse(dgView.Rows[i].Cells["NetAmount"].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        void CalculateTotal()
        {
            try
            {

                decimal GrossTot = 0;

                int i = dgView.RowCount;

                if (dgView.Rows.Count > 0)
                {
                    for (int a = 0; a < i; a++)
                    {
                        try
                        {

                            GrossTot += Convert.ToDecimal(dgView.Rows[a].Cells["NetAmount"].Value.ToString());

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                textBoxTotGrosse.Text = GrossTot.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dgView.Rows.Count > 0)
            {

                textBoxTotGrosse.Text = CellQtyChange().ToString("0.00");
                CalculateTotal();
            }
            else if (e.ColumnIndex == 2 && dgView.Rows.Count > 0)
            {

                textBoxTotGrosse.Text = CellQtyChange().ToString("0.00");
                //lblGrossTot.Text = CellQtyChange().ToString("0.00");
                CalculateTotal();
            }
        }

        public void fillDtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                dgView.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveCashReturn(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        int n = dgView.Rows.Add();

                        dgView.Rows[n].Cells["CashAmount"].Value = (values[0].ToString().Trim());
                        dgView.Rows[n].Cells["Quantity"].Value = "0";
                        dgView.Rows[n].Cells["NetAmount"].Value = "0";
                        dgView.Rows[n].Cells["CashCollectionId"].Value = (values[3].ToString().Trim());


                        //dgView.FirstDisplayedScrollingRowIndex = n;
                        //dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        //dgView.Rows[n].Selected = true;
                        CalculateTotal();
                    }

                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
