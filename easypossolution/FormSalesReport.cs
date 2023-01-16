using easyBAL;
using easyDAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormSalesReport : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        bool loadStatus;
        #endregion

        #region Constructor

        public FormSalesReport()
        {
            InitializeComponent();
        }

        #endregion



        #region Methods


        #endregion

        #region Events

        private void buttonViewReport1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("If you want to view Detail report press Yes, If Summary Report press No", "Report Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (comboBoxPayMode.SelectedIndex == -1)
                {
                    if (comboBoxBranchReport.SelectedIndex == -1)
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDate(objBAL);
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
                    else
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport.SelectedValue.ToString());
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateBranch(objBAL);
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
                else
                {
                    if (comboBoxBranchReport.SelectedIndex == -1)
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymode(objBAL);
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
                    else
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                            objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport.SelectedValue.ToString());
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymodeBranch(objBAL);
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
            else
            {
                if (comboBoxPayMode.SelectedIndex == -1)
                {
                    if (comboBoxBranchReport.SelectedIndex == -1)
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesSummary rpt = new CrystalReportSalesSummary();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDate(objBAL);
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
                    else
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesSummary rpt = new CrystalReportSalesSummary();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport.SelectedValue.ToString());
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateBranch(objBAL);
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
                else
                {
                    if (comboBoxBranchReport.SelectedIndex == -1)
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesSummary rpt = new CrystalReportSalesSummary();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymode(objBAL);
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
                    else
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            //FormReport REPORT = new FormReport();
                            //REPORT.Show();
                            CrystalReportSalesSummary rpt = new CrystalReportSalesSummary();
                            objBAL = new ClassPOBAL();
                            objBAL.date1 = dateTimePickerFrom.Value;
                            objBAL.date2 = dateTimePickerTo.Value;
                            objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                            objBAL.BranchId = Convert.ToInt32(comboBoxBranchReport.SelectedValue.ToString());
                            objDAL = new ClassPODAL();
                            objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymodeBranch(objBAL);
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
            
            
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
            //    //The report you created.
            //    MySqlConnection myConnection = default(MySqlConnection);
            //    MySqlCommand MyCommand = new MySqlCommand();
            //    MySqlDataAdapter myDA = new MySqlDataAdapter();
            //    TransportationFacility_DBDataSet myDS = new TransportationFacility_DBDataSet();
            //    //The DataSet you created.


            //    myConnection = new SqlConnection("Data Source=(localDB)\\v11.0; Integrated Security=True; AttachDbFilename=|DataDirectory|\\CMS_DB.mdf;");
            //    MyCommand.Connection = myConnection;
            //    MyCommand.CommandText = "select *  from BusFeePayment,Student,Transportation,BusHolders where Student.scholarNo=BusHolders.ScholarNo and BusFeePayment.ScholarNo=Student.ScholarNo and Transportation.SourceLocation=BusHolders.SourceLocation and DateOfPayment between @date1 and @date2 and Course= '" + Course.Text + "'and branch='" + Branch.Text + "' order by DateOfPayment";
            //    MyCommand.Parameters.Add("@date1", SqlDbType.DateTime, 30, "DateOfPayment").Value = Date_from.Value.Date;
            //    MyCommand.Parameters.Add("@date2", SqlDbType.DateTime, 30, "DateOfPayment").Value = Date_to.Value.Date;

            //    MyCommand.CommandType = CommandType.Text;
            //    myDA.SelectCommand = MyCommand;
            //    myDA.Fill(myDS, "BusFeePayment");
            //    myDA.Fill(myDS, "Transportation");
            //    myDA.Fill(myDS, "BusHolders");
            //    myDA.Fill(myDS, "Student");
            //    rpt.SetDataSource(myDS);

            //    crystalReportViewer1.ReportSource = rpt;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ButtonExit1_Click(object sender, EventArgs e)
        {
            //this.Close();
            //if (comboBoxPayMode.SelectedIndex == -1)
            //{
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                CrystalReportPrice rpt = new CrystalReportPrice();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesPriceBase(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //}
            //else
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        //FormReport REPORT = new FormReport();
            //        //REPORT.Show();
            //        CrystalReportSalesSummary rpt = new CrystalReportSalesSummary();
            //        objBAL = new ClassPOBAL();
            //        objBAL.date1 = dateTimePickerFrom.Value;
            //        objBAL.date2 = dateTimePickerTo.Value;
            //        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
            //        objDAL = new ClassPODAL();
            //        objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymodeWithRtn(objBAL);
            //        rpt.SetDataSource(objBAL.DtDataSet);
            //        crystalReportViewer1.ReportSource = rpt;
            //        crystalReportViewer1.Refresh();
            //        Cursor.Current = Cursors.Default;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void buttonViewReport2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom2.Value;
                objBAL.date2 = dateTimePickerTo2.Value;
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesDatabyItemCode(objBAL);
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

        private void buttonExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewReport3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxItemCategory.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom3.Value;
                    objBAL.date2 = dateTimePickerTo3.Value;
                    objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyItemCategory(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormSalesReport_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();

                comboBoxItemCategory.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[3];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

                BALClass objUSBAL = new BALClass();
                DALClass objUSDAL = new DALClass();
                if (objUSDAL.retreiveEmployeeName(objUSBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxRep.DataSource = objUSDAL.retreiveEmployeeName(objUSBAL).Tables[1];
                    comboBoxRep.DisplayMember = "EmployeeName";
                    comboBoxRep.ValueMember = "EmployeeID";
                    comboBoxRep.SelectedIndex = -1;
                }

                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                if (objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
                    comboBoxCustomer.DisplayMember = "CustomerName";
                    comboBoxCustomer.ValueMember = "CustomerId";
                    comboBoxCustomer.SelectedIndex = -1;
                }

                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
                {
                    comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                    comboBoxBranch.DisplayMember = "BranchName";
                    comboBoxBranch.ValueMember = "BranchId";
                    comboBoxBranch.SelectedIndex = -1;

                    comboBoxBranchReport.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                    comboBoxBranchReport.DisplayMember = "BranchName";
                    comboBoxBranchReport.ValueMember = "BranchId";
                    comboBoxBranchReport.SelectedIndex = -1;
                }

                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                if (objDAL.retreivePOLoadingData(objBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[1];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = -1;
                }

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void buttonExit4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonView4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRep.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom4.Value;
                    objBAL.date2 = dateTimePickerTo4.Value;
                    objBAL.RepId = Convert.ToInt32(comboBoxRep.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabySteward(objBAL);
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

        private void buttonExitCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomer.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFromCust.Value;
                    objBAL.date2 = dateTimePickerToCust.Value;
                    objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyCust(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer5.ReportSource = rpt;
                    crystalReportViewer5.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3inchReport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportSales5in1 rpt = new CrystalReportSales5in1();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesDatabyDate3in(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                rpt.PrintOptions.PrinterName = "";
                rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSummary_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("If you want to view Detail report press Yes, If Summary Report press No", "Report Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {
                 if (comboBoxPayMode.SelectedIndex == -1)
                 {
                     try
                     {
                         Cursor.Current = Cursors.WaitCursor;
                         //FormReport REPORT = new FormReport();
                         //REPORT.Show();
                         CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                         objBAL = new ClassPOBAL();
                         objBAL.date1 = dateTimePickerFrom.Value;
                         objBAL.date2 = dateTimePickerTo.Value;
                         objDAL = new ClassPODAL();
                         objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateWithRtn(objBAL);
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
                 else
                 {
                     try
                     {
                         Cursor.Current = Cursors.WaitCursor;
                         //FormReport REPORT = new FormReport();
                         //REPORT.Show();
                         CrystalReportSalesByDate rpt = new CrystalReportSalesByDate();
                         objBAL = new ClassPOBAL();
                         objBAL.date1 = dateTimePickerFrom.Value;
                         objBAL.date2 = dateTimePickerTo.Value;
                         objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                         objDAL = new ClassPODAL();
                         objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymodeWithRtn(objBAL);
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
             else
             {
                 if (comboBoxPayMode.SelectedIndex == -1)
                 {
                     try
                     {
                         Cursor.Current = Cursors.WaitCursor;
                         //FormReport REPORT = new FormReport();
                         //REPORT.Show();
                         CrystalReportSalesSummary rpt = new CrystalReportSalesSummary();
                         objBAL = new ClassPOBAL();
                         objBAL.date1 = dateTimePickerFrom.Value;
                         objBAL.date2 = dateTimePickerTo.Value;
                         objDAL = new ClassPODAL();
                         objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateWithRtn(objBAL);
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
                 else
                 {
                     try
                     {
                         Cursor.Current = Cursors.WaitCursor;
                         //FormReport REPORT = new FormReport();
                         //REPORT.Show();
                         CrystalReportSalesSummary rpt = new CrystalReportSalesSummary();
                         objBAL = new ClassPOBAL();
                         objBAL.date1 = dateTimePickerFrom.Value;
                         objBAL.date2 = dateTimePickerTo.Value;
                         objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                         objDAL = new ClassPODAL();
                         objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymodeWithRtn(objBAL);
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
            
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    //FormReport REPORT = new FormReport();
            //    //REPORT.Show();
            //    CrystalReportSalesSummaryByDate rpt = new CrystalReportSalesSummaryByDate();
            //    objBAL = new ClassPOBAL();
            //    objBAL.date1 = dateTimePickerFrom.Value;
            //    objBAL.date2 = dateTimePickerTo.Value;
            //    objDAL = new ClassPODAL();
            //    objBAL.DtDataSet = objDAL.retreiveSalesSummaryDatabyDate(objBAL);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxBranch.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSalesByDateBranch rpt = new CrystalReportSalesByDateBranch();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePicker2.Value;
                    objBAL.date2 = dateTimePicker1.Value;
                    objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyBranch(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer6.ReportSource = rpt;
                    crystalReportViewer6.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            comboBoxPayMode.SelectedIndex = -1;
        }

        private void FormSalesReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm6 = new FormItemSearch();
                frm6.frm6 = this;
                frm6.form = 6;
                frm6.wh = 1;
                frm6.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("If you want to view Detail report press Yes, If Summary Report press No", "Report Option", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (comboBoxPayMode.SelectedIndex == -1)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //FormReport REPORT = new FormReport();
                        //REPORT.Show();
                        CrystalReportSalesByDateRtn rpt = new CrystalReportSalesByDateRtn();
                        objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerFrom.Value;
                        objBAL.date2 = dateTimePickerTo.Value;
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateRtn(objBAL);
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
                else
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //FormReport REPORT = new FormReport();
                        //REPORT.Show();
                        CrystalReportSalesByDateRtn rpt = new CrystalReportSalesByDateRtn();
                        objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerFrom.Value;
                        objBAL.date2 = dateTimePickerTo.Value;
                        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymodeRtn(objBAL);
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
            else
            {
                if (comboBoxPayMode.SelectedIndex == -1)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //FormReport REPORT = new FormReport();
                        //REPORT.Show();
                        CrystalReportSalesSummaryRtn rpt = new CrystalReportSalesSummaryRtn();
                        objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerFrom.Value;
                        objBAL.date2 = dateTimePickerTo.Value;
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateRtn(objBAL);
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
                else
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //FormReport REPORT = new FormReport();
                        //REPORT.Show();
                        CrystalReportSalesSummaryRtn rpt = new CrystalReportSalesSummaryRtn();
                        objBAL = new ClassPOBAL();
                        objBAL.date1 = dateTimePickerFrom.Value;
                        objBAL.date2 = dateTimePickerTo.Value;
                        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                        objDAL = new ClassPODAL();
                        objBAL.DtDataSet = objDAL.retreiveSalesDatabyDatePaymodeRtn(objBAL);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRep.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportRepSalesSumm rpt = new CrystalReportRepSalesSumm();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom4.Value;
                    objBAL.date2 = dateTimePickerTo4.Value;
                    //objBAL.RepId = Convert.ToInt32(comboBoxRep.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyAllRep(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer4.ReportSource = rpt;
                    crystalReportViewer4.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportRepSales rpt = new CrystalReportRepSales();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom4.Value;
                    objBAL.date2 = dateTimePickerTo4.Value;
                    //objBAL.RepId = Convert.ToInt32(comboBoxRep.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyAllRep(objBAL);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            comboBoxRep.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker4.Value;
                objBAL.date2 = dateTimePicker3.Value;
                objDAL = new ClassPODAL();
                gridControl4.DataSource = null;
                if (objDAL.retreiveAllSalesSummary(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl4.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    gridView4.OptionsView.ColumnAutoWidth = false;
                    gridView4.BestFitColumns();
                }
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
                //string FileName = "C:\\ExportData\\Commision.xls";
                //gridControl4.ExportToXls(FileName);
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl4.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl4.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl4.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl4.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl4.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl4.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                CrystalReportSalesRtnByDate rpt = new CrystalReportSalesRtnByDate();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker6.Value;
                objBAL.date2 = dateTimePicker5.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesRtnDatabyDate(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer7.ReportSource = rpt;
                crystalReportViewer7.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                //if (comboBoxItemCategory.SelectedIndex != -1)
                //{
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportSalesCat rpt = new CrystalReportSalesCat();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom3.Value;
                objBAL.date2 = dateTimePickerTo3.Value;
                //objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesDatabyItemCategoryAll(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                CrystalReportSalesWithDate rpt = new CrystalReportSalesWithDate();
                //CrystalReportNewSalesByDate rpt = new CrystalReportNewSalesByDate();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesDatabyDate(objBAL);
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

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxItemCategory.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportSalesWithDate rpt = new CrystalReportSalesWithDate();
                    objBAL = new ClassPOBAL();
                    objBAL.date1 = dateTimePickerFrom3.Value;
                    objBAL.date2 = dateTimePickerTo3.Value;
                    objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveSalesDatabyItemCategory(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportSalesByDateCollection rpt = new CrystalReportSalesByDateCollection();
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom2.Value;
                objBAL.date2 = dateTimePickerTo2.Value;
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesDatabyDateCollection(objBAL);
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

        #region Validation Methods

        #endregion

    }
}
