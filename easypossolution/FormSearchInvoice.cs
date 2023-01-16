using DevExpress.XtraGrid.Columns;
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
    public partial class FormSearchInvoice : Form
    {
        #region Local Variables
        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9, Option10, Option11, Option12, Option13, Option14, Option15, Option16, Option17, Option18, Option19, Option20, Option21, Option22;
        ArrayList alistOption = new ArrayList();
        int InvoiceNo = 0;

        #endregion

        #region Constructor
        public FormSearchInvoice()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void UpdateInvoiceStatus()
        {
            try
            {
                ClassInvoiceBAL objBAL = new ClassInvoiceBAL();
                objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                objBAL.InvoiceStatusId = Convert.ToInt32(comboBoxInvoiceStatus.SelectedValue);

                ClassInvoiveDAL objDAL = new ClassInvoiveDAL();
                int count = objDAL.UpdateInvStatus(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("InvoiceStatus Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadInvoiceStatus()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxInvoiceStatus.DataSource = objDAL.retreiveInvoiceStatus(objBAL).Tables[0];
                comboBoxInvoiceStatus.DisplayMember = "InvoiceStatus";
                comboBoxInvoiceStatus.ValueMember = "InvoiceStatusId";
                comboBoxInvoiceStatus.SelectedIndex = 0;

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
                        if (alistOption[i].ToString().Trim() == "21")
                        {
                            Option21 = true;
                        }
                        if (alistOption[i].ToString().Trim() == "22")
                        {
                            Option22 = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReprintInvoice()
        {
            try
            {
                if (Option2 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceCr rpt = new CrystalReportA4InvoiceCr();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option3 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceSCr rpt = new CrystalReportA4InvoiceSCr();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option4 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3 rpt = new CrystalReportInvoice5in3();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;

                }
                else if (Option5 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3S rpt = new CrystalReportInvoice5in3S();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option6 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3ex rpt = new CrystalReportInvoice3in3ex();
                    //CrystalReportInvoice3in3 rpt = new CrystalReportInvoice3in3();
                    //CrystalReportInvoice2inLogoE rpt = new CrystalReportInvoice2inLogoE();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option7 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //CrystalReportInvoice2inLogoS rpt = new CrystalReportInvoice2inLogoS();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    //CrystalReportInvoice2inch rpt = new CrystalReportInvoice2inch();
                    CrystalReportInvoice3in3exs rpt = new CrystalReportInvoice3in3exs();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option8 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3Lo rpt = new CrystalReportInvoice5in3Lo();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;

                }
                else if (Option9 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3SLo rpt = new CrystalReportInvoice5in3SLo();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option10 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3LF rpt = new CrystalReportInvoice5in3LF();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    //rpt.PrintOptions.PrinterName = "";
                    //rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;

                }
                else if (Option11 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3SLF rpt = new CrystalReportInvoice5in3SLF();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    //rpt.PrintOptions.PrinterName = "";
                    //rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option12 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceCrNLo rpt = new CrystalReportA4InvoiceCrNLo();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    //rpt.PrintOptions.PrinterName = "";
                    //rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;

                }
                else if (Option13 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceSCrNLo rpt = new CrystalReportA4InvoiceSCrNLo();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    //rpt.PrintOptions.PrinterName = "";
                    //rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                else if (Option14 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice2in2ex rpt = new CrystalReportInvoice2in2ex();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option15 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice2in2exs rpt = new CrystalReportInvoice2in2exs();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option16 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3ext rpt = new CrystalReportInvoice3in3ext();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option17 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3T rpt = new CrystalReportInvoice5in3T();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option18 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3exLogo rpt = new CrystalReportInvoice3in3exLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option19 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3exsLogo rpt = new CrystalReportInvoice3in3exsLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option20 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice3in3exTLogo rpt = new CrystalReportInvoice3in3exTLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option21 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReport5InInvoiceCr rpt = new CrystalReport5InInvoiceCr();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (Option22 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReport5InInvoiceCrS rpt = new CrystalReport5InInvoiceCrS();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
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

        public void Reset()
        {
            //textBoxBillNo.Clear();
            //crystalReportViewer1.da
            //dataGridView1.DataSource = null;
        }

        private void fillGrid()
        {
            objBAL = new ClassSOBAL();
            objBAL.date1 = dateTimePickerFromDate.Value;
            objBAL.date2 = dateTimePickerToDate.Value;
            objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllInvoices(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                gridView1.Columns["CreatedDate"].DisplayFormat.FormatString = "yyyy/MM/dd hh:mm tt";
                //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                //gridView1.Columns["CustAccountId"].Visible = false;
                //gridView1.Columns["BranchId"].Visible = false;
                //gridView1.Columns["Status"].Visible = false;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
            }
        }

        private void fillCustomerGrid()
        {
            //string filterValue = textBoxBillNo.Text;
            //if(!String.IsNullOrEmpty(filterValue))
            //    gridControl1.Columns["Text"].AutoFilterValue = filterValue; 
            objBAL = new ClassSOBAL();
            //objCustBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllInvoices(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                //gridView1.Columns["ShipCountry"].FilterInfo = new ColumnFilterInfo("[CustomerName] LIKE ' " + textBoxBillNo.Text + "'%'");
                //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                //gridView1.Columns["CustAccountId"].Visible = false;
                //gridView1.Columns["BranchId"].Visible = false;
                //gridView1.Columns["Status"].Visible = false;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.BestFitColumns();
            }
        }

        private void fillInv()
        {
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("BillNo").ToString());
            txtInvoiceNo.Text = (this.gridView1.GetFocusedRowCellValue("BillNo").ToString());
            FindNetAmount();
            ReprintInvoice();
            fillRemarksrGrid();
            //DialogResult result = MessageBox.Show("Do you want view Sinhala Invoice?", "Invoice Type Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    //FormReport REPORT = new FormReport();
            //    //REPORT.Show();
            //    CrystalReportInvoice5in3S rpt = new CrystalReportInvoice5in3S();
            //    //CrystalReportInvoice3in3 rpt = new CrystalReportInvoice3in3();
            //    ClassPOBAL objBAL = new ClassPOBAL();
            //    objBAL.SOHDId = Convert.ToInt32(this.gridView1.GetFocusedRowCellValue("BillNo").ToString());
            //    ClassPODAL objDAL = new ClassPODAL();
            //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
            //    rpt.SetDataSource(objBAL.DtDataSet);
            //    crystalReportViewer1.ReportSource = rpt;
            //    crystalReportViewer1.Refresh();
            //    Cursor.Current = Cursors.Default;
            //}
            //else
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    //FormReport REPORT = new FormReport();
            //    //REPORT.Show();
            //    CrystalReportInvoice5in3 rpt = new CrystalReportInvoice5in3();
            //    //CrystalReportInvoice3in3 rpt = new CrystalReportInvoice3in3();
            //    ClassPOBAL objBAL = new ClassPOBAL();
            //    objBAL.SOHDId = Convert.ToInt32(this.gridView1.GetFocusedRowCellValue("BillNo").ToString());
            //    ClassPODAL objDAL = new ClassPODAL();
            //    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
            //    rpt.SetDataSource(objBAL.DtDataSet);
            //    crystalReportViewer1.ReportSource = rpt;
            //    crystalReportViewer1.Refresh();
            //    Cursor.Current = Cursors.Default;
            //}
            

            //Cursor.Current = Cursors.WaitCursor;
            ////CrystalReportInvoice5in31 rpt = new CrystalReportInvoice5in31();
            //CrystalReportInvoice2in1 rpt = new CrystalReportInvoice2in1();
            //objBAL = new ClassPOBAL();
            //objBAL.SOHDId = Convert.ToInt32(Sohdid);
            //objDAL = new ClassPODAL();
            //objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
            //rpt.SetDataSource(objBAL.DtDataSet);
            //crystalReportViewer1.ReportSource = rpt;
            //crystalReportViewer1.Refresh();
            ////crystalReportViewer1.PrintReport();
            //rpt.PrintOptions.PrinterName = "";
            //rpt.PrintToPrinter(1, false, 0, 0);
            //Cursor.Current = Cursors.Default;
        }

        public void FindNetAmount()
        {
            try
            {
                lblGrossTot.Text = "0.00";
                txtTotDiscRate.Text = "0.00";
                //textBoxTransport.Text = "0.00";
                textBoxNetAmount.Text = "0.00";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                objInvBAL.DocTypeId = 1;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveInvDisc(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        lblGrossTot.Text = (values[0].ToString().Trim());
                        txtTotDiscRate.Text = (values[1].ToString().Trim());
                        //textBoxTransport.Text = (values[2].ToString().Trim());
                        textBoxCharges.Text = (values[4].ToString().Trim());
                        textBoxNetAmount.Text = (values[2].ToString().Trim());
                        dateTimePickerCompletedDate.Value = Convert.ToDateTime(values[3].ToString());
                        comboBoxInvoiceStatus.SelectedValue = (values[5].ToString());
                    }

                    textBoxNetAmount.Text = ((Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxCharges.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void FormSearchInvoice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'easyposelpitiyaDataSet.AllCustomerInvoice' table. You can move, or remove it, as needed.
            //this.allCustomerInvoiceTableAdapter.Fill(this.easyposelpitiyaDataSet.AllCustomerInvoice);
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            loadInvoiceStatus();
            //fillOptions();
            Cursor.Current = Cursors.Default;
            //fillCustomerGrid();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("BillNo") == null)
                return;
            fillInv();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            //fillOptions();
            Cursor.Current = Cursors.Default;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("BillNo") == null)
                return;
            fillInv();
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            fillOptions();
        }

        private void txtReprint_TextChanged(object sender, EventArgs e)
        {
            FindNetAmount();
        }

        private void txtTotDiscRate_TextChanged(object sender, EventArgs e)
        {
            if (txtTotDiscRate.Text != "")
            {
                textBoxNetAmount.Text = ((Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxCharges.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertDisc();
        }

        private void insertDisc()
        {
            try
            {
                ClassInvoiceBAL objBAL = new ClassInvoiceBAL();
                objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                objBAL.SOGrossTotal = Convert.ToDecimal(lblGrossTot.Text);
                objBAL.SODiscount = Convert.ToDecimal(txtTotDiscRate.Text);
                objBAL.Charges = Convert.ToDecimal(textBoxCharges.Text);
                //objBAL.TransportOther = Convert.ToDecimal(textBoxTransport.Text);
                objBAL.SONetTotal = Convert.ToDecimal(textBoxNetAmount.Text);

                ClassInvoiveDAL objDAL = new ClassInvoiveDAL();
                int count = objDAL.UpdateInvDisc(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Discount Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UpdateFinishDate();
        }

        private void UpdateFinishDate()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                objInvBAL.CompletedDate = dateTimePickerCompletedDate.Value;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.UpdateFinishDate(objInvBAL);
                if (count != 0)
                {
                    MessageBox.Show("Complete Date Updated Successfully.");
                    //fillRemarksrGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UpdateRemarks();
        }

        private void UpdateRemarks()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
                objInvBAL.Remarks = txtRemarks.Text;
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.UpdateRemarks(objInvBAL);
                if (count != 0)
                {
                    MessageBox.Show("Remarks Saved Successfully.");
                    fillRemarksrGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillRemarksrGrid()
        {
            objBAL = new ClassSOBAL();
            objBAL.SOHDId = Convert.ToInt32(txtInvoiceNo.Text);
            objDAL = new ClassSODAL();
            gridControl2.DataSource = null;
            if (objDAL.retreiveRemarks(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl2.DataSource = objBAL.DtDataSet.Tables[0];
                gridView2.OptionsView.ColumnAutoWidth = false;
                gridView2.BestFitColumns();
            }
        }

        private void textBoxCharges_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCharges.Text != "")
            {
                textBoxNetAmount.Text = ((Convert.ToDecimal(lblGrossTot.Text) + Convert.ToDecimal(textBoxCharges.Text)) - Convert.ToDecimal(txtTotDiscRate.Text)).ToString("0.00");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateInvoiceStatus();
        }

        #region Events



        #endregion



        #region Validation Methods



        #endregion
       
    }
}
