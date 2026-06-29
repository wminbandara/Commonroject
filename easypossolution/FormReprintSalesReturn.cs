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
    public partial class FormReprintSalesReturn : Form
    {
        public FormReprintSalesReturn()
        {
            InitializeComponent();
        }

        #region Local Variables
        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        bool Option1, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9;
        ArrayList alistOption = new ArrayList();
        int InvoiceNo = 0;

        #endregion

        #region Methods

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
                        //if (alistOption[i].ToString().Trim() == "10")
                        //{
                        //    Option10 = true;
                        //}
                        //if (alistOption[i].ToString().Trim() == "11")
                        //{
                        //    Option11 = true;
                        //}
                        //if (alistOption[i].ToString().Trim() == "12")
                        //{
                        //    Option12 = true;
                        //}
                        //if (alistOption[i].ToString().Trim() == "13")
                        //{
                        //    Option13 = true;
                        //}
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
                    //if (PrintBalance == true)
                    //{
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceCrRtn rpt = new CrystalReportA4InvoiceCrRtn();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.Dispose();
                    if (rpt != null)
                    {
                        rpt.Close();
                        rpt.Dispose();
                    }
                    Cursor.Current = Cursors.Default;


                }
                else if (Option3 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportA4InvoiceCrRtn rpt = new CrystalReportA4InvoiceCrRtn();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.Dispose();
                    if (rpt != null)
                    {
                        rpt.Close();
                        rpt.Dispose();
                    }
                    Cursor.Current = Cursors.Default;
                }
                else if (Option4 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3Rtn rpt = new CrystalReportInvoice5in3Rtn();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.Dispose();
                    if (rpt != null)
                    {
                        rpt.Close();
                        rpt.Dispose();
                    }
                    Cursor.Current = Cursors.Default;

                }
                else if (Option5 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportInvoice5in3Rtn rpt = new CrystalReportInvoice5in3Rtn();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.Dispose();
                    if (rpt != null)
                    {
                        rpt.Close();
                        rpt.Dispose();
                    }
                    Cursor.Current = Cursors.Default;
                }
                else if (Option6 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReturn3in3ex rpt = new CrystalReportReturn3in3ex();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.Dispose();
                    if (rpt != null)
                    {
                        rpt.Close();
                        rpt.Dispose();
                    }
                    Cursor.Current = Cursors.Default;
                }
                else if (Option7 == true)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportReturn3in3ex rpt = new CrystalReportReturn3in3ex();
                    //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(txtReprint.Text);
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceDataReturn(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    rpt.Dispose();
                    if (rpt != null)
                    {
                        rpt.Close();
                        rpt.Dispose();
                    }
                    Cursor.Current = Cursors.Default;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGrid()
        {
            objBAL = new ClassSOBAL();
            //objCustBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            objDAL = new ClassSODAL();
            gridControl1.DataSource = null;
            if (objDAL.retreiveAllDirectSalesReturn(objBAL).Tables[0].Rows.Count > 0)
            {
                gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
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
            txtReprint.Text = (this.gridView1.GetFocusedRowCellValue("ReturnNo").ToString());
            ReprintInvoice();

        }

        #endregion

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            fillOptions();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("ReturnNo") == null)
                return;
            fillInv();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillGrid();
            fillOptions();
            Cursor.Current = Cursors.Default;
        }
    }
}
