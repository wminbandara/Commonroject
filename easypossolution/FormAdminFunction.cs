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
        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9, Option10, Option11, Option12, Option13, Option14, Option15, Option16, Option17, Option18, Option19, Option20;
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
            try
            {
                DialogResult result = MessageBox.Show("If you want to print summary select Yes, To view select No.?", "Printing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (comboBoxUser.SelectedIndex == -1)
                    {
                        if (Option6 == true || Option7 == true )
                        {
                            if (comboBoxBranch.SelectedIndex == -1)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                                ClassPOBAL objBAL = new ClassPOBAL();
                                objBAL.date1 = dateTimePickerChqExpDate.Value;
                                ClassPODAL objDAL = new ClassPODAL();
                                objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
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
                                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                                ClassPODAL objDAL = new ClassPODAL();
                                objBAL.DtDataSet = objDAL.retreiveSummaryDataNewBranch(objBAL);
                                rpt.SetDataSource(objBAL.DtDataSet);
                                crystalReportViewer1.ReportSource = rpt;
                                crystalReportViewer1.Refresh();
                                rpt.PrintOptions.PrinterName = "";
                                rpt.PrintToPrinter(1, false, 0, 0);
                                Cursor.Current = Cursors.Default;
                            }
                            
                        }
                        else if (Option14 == true || Option15 == true)
                        {
                            if (comboBoxBranch.SelectedIndex == -1)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                                ClassPOBAL objBAL = new ClassPOBAL();
                                objBAL.date1 = dateTimePickerChqExpDate.Value;
                                ClassPODAL objDAL = new ClassPODAL();
                                objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
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
                                CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                                ClassPOBAL objBAL = new ClassPOBAL();
                                objBAL.date1 = dateTimePickerChqExpDate.Value;
                                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                                ClassPODAL objDAL = new ClassPODAL();
                                objBAL.DtDataSet = objDAL.retreiveSummaryDataNewBranch(objBAL);
                                rpt.SetDataSource(objBAL.DtDataSet);
                                crystalReportViewer1.ReportSource = rpt;
                                crystalReportViewer1.Refresh();
                                rpt.PrintOptions.PrinterName = "";
                                rpt.PrintToPrinter(1, false, 0, 0);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else
                        {
                            if (comboBoxBranch.SelectedIndex == -1)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                                //CrystalReportSummary5in rpt = new CrystalReportSummary5in();
                                ClassPOBAL objBAL = new ClassPOBAL();
                                objBAL.date1 = dateTimePickerChqExpDate.Value;
                                ClassPODAL objDAL = new ClassPODAL();
                                objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
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
                                CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                                //CrystalReportSummary5in rpt = new CrystalReportSummary5in();
                                ClassPOBAL objBAL = new ClassPOBAL();
                                objBAL.date1 = dateTimePickerChqExpDate.Value;
                                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                                ClassPODAL objDAL = new ClassPODAL();
                                objBAL.DtDataSet = objDAL.retreiveSummaryDataNewBranch(objBAL);
                                rpt.SetDataSource(objBAL.DtDataSet);
                                crystalReportViewer1.ReportSource = rpt;
                                crystalReportViewer1.Refresh();
                                rpt.PrintOptions.PrinterName = "";
                                rpt.PrintToPrinter(1, false, 0, 0);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    else
                    {
                        if (Option6 == true || Option7 == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            CrystalReportSummary3in rpt = new CrystalReportSummary3in();
                            ClassPOBAL objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerChqExpDate.Value;
                            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                            ClassPODAL objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                            rpt.SetDataSource(objBAL.DtDataSet);
                            crystalReportViewer1.ReportSource = rpt;
                            crystalReportViewer1.Refresh();
                            rpt.PrintOptions.PrinterName = "";
                            rpt.PrintToPrinter(1, false, 0, 0);
                            Cursor.Current = Cursors.Default;
                        }
                        else if (Option14 == true || Option15 == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            CrystalReportSummary2in rpt = new CrystalReportSummary2in();
                            ClassPOBAL objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerChqExpDate.Value;
                            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                            ClassPODAL objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
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
                            CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                            ClassPOBAL objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerChqExpDate.Value;
                            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                            ClassPODAL objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                            rpt.SetDataSource(objBAL.DtDataSet);
                            crystalReportViewer1.ReportSource = rpt;
                            crystalReportViewer1.Refresh();
                            rpt.PrintOptions.PrinterName = "";
                            rpt.PrintToPrinter(1, false, 0, 0);
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    
                }
                else
                {
                    if (comboBoxUser.SelectedIndex == -1)
                    {
                        if (Option4 == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            FormReport REPORT = new FormReport();
                            REPORT.Show();
                            CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                            ClassPOBAL objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerChqExpDate.Value;

                            ClassPODAL objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
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

                            ClassPODAL objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSummaryDataNew(objBAL);
                            rpt.SetDataSource(objBAL.DtDataSet);
                            REPORT.crystalReportViewer1.ReportSource = rpt;
                            REPORT.crystalReportViewer1.Refresh();
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else
                    {
                        if (Option4 == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            FormReport REPORT = new FormReport();
                            REPORT.Show();
                            CrystalReport5InSummary rpt = new CrystalReport5InSummary();
                            ClassPOBAL objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerChqExpDate.Value;
                            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                            ClassPODAL objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
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
                            objBAL.UserID = Convert.ToInt32(comboBoxUser.SelectedValue.ToString());
                            ClassPODAL objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSummaryDataNewByUser(objBAL);
                            rpt.SetDataSource(objBAL.DtDataSet);
                            REPORT.crystalReportViewer1.ReportSource = rpt;
                            REPORT.crystalReportViewer1.Refresh();
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }

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
                        if (alistOption[i].ToString().Trim() == "1")
                        {
                            //PrintInvoiceStatus = true;
                            Option1 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "2")
                        {
                            Option2 = true;
                            //PrintDetailWithLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "3")
                        {
                            Option3 = true;
                            //PrintDetailWithoutLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "4")
                        {
                            Option4 = true;
                            //PrintDetailWithLogoSinhala = true;
                        }
                        if (alistOption[i].ToString().Trim() == "5")
                        {
                            Option5 = true;
                            //PrintDetailWithoutLogoSinhala = true;
                        }
                        if (alistOption[i].ToString().Trim() == "6")
                        {
                            Option6 = true;
                            //PrintwithoutDetailWithLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "7")
                        {
                            Option7 = true;
                            //PrintwithoutDetailWithoutLogo = true;
                        }
                        if (alistOption[i].ToString().Trim() == "8")
                        {
                            Option8 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "9")
                        {
                            Option9 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "10")
                        {
                            Option10 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "11")
                        {
                            Option11 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "12")
                        {
                            Option12 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "13")
                        {
                            Option13 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "14")
                        {
                            Option14 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "15")
                        {
                            Option15 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "16")
                        {
                            Option16 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "17")
                        {
                            Option17 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "18")
                        {
                            Option18 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "19")
                        {
                            Option19 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "20")
                        {
                            Option20 = true;
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
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDate(objBAL);
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
                    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDateBranch(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.PrintOptions.PrinterName = "";
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                if (comboBoxBranch.SelectedIndex == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerChqExpDate.Value;

                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDate(objBAL);
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
                    CrystalReportSummary5inSales rpt = new CrystalReportSummary5inSales();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerChqExpDate.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesSummarybyDateBranch(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
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

    }
}
