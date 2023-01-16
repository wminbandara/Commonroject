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
    public partial class FormPIRecord : Form
    {
        #region Local Variables

        public FormPurchaseInvoice frm { set; get; }
        //public FormPurchaseReturn frm1 { set; get; }

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();
        bool loadStatus;
        public bool ReturnStatus;
        int POHDId = 0;

        #endregion

        #region Constructor
        public FormPIRecord()
        {
            InitializeComponent();
        }

        #endregion

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePIDatabyDate(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    DataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormPIRecord_Load(object sender, EventArgs e)
        {
            loadStatus = true;
            objBAL = new ClassPOBAL();
            objDAL = new ClassPODAL();
            comboBoxSupplierName.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
            comboBoxSupplierName.DisplayMember = "SupplierName";
            comboBoxSupplierName.ValueMember = "SupplierId";
            comboBoxSupplierName.SelectedIndex = -1;

            //loadGRNOptions();
            loadStatus = false;
        }

        private void loadGRNOptions()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxGRNPrint.DataSource = objDAL.retreiveGRNPrintOptions(objBAL).Tables[0];
                comboBoxGRNPrint.DisplayMember = "OptionName";
                comboBoxGRNPrint.ValueMember = "GRNPrintId";
                comboBoxGRNPrint.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGetData2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker2.Value;
                objBAL.date2 = dateTimePicker1.Value;
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplierName.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePIDatabyDateSupplier(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = DataGridView1.SelectedRows[0];
            POHDId = Convert.ToInt32(dr.Cells["PIHDId"].Value.ToString());
            PrintPI();
            frm.Reset();
            frm.textBoxPOID.Text = dr.Cells["PIHDId"].Value.ToString();
            frm.button2.Enabled = false;
            this.Close();

            //DataGridViewRow dr = DataGridView1.SelectedRows[0];
            //frm.Reset();
            //frm.textBoxPOID.Text = dr.Cells["PIHDId"].Value.ToString();
            ////frm.ButtonSave.Enabled = false;
            ////frm.existPOStatus = true;
            //frm.PrintPI();
            //this.Close();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            POHDId = Convert.ToInt32(dr.Cells["PIHDId"].Value.ToString());
            PrintPI();
            frm.Reset();
            frm.textBoxPOID.Text = dr.Cells["PIHDId"].Value.ToString();
            frm.button2.Enabled = false;
            //frm.ButtonSave.Enabled = false;
            //frm.existPOStatus = true;
            this.Close();

            //DataGridViewRow dr = dataGridView2.SelectedRows[0];
            //frm.Reset();
            //frm.textBoxPOID.Text = dr.Cells["PIHDId"].Value.ToString();
            ////frm.ButtonSave.Enabled = false;
            ////frm.existPOStatus = true;
            //frm.PrintPI();
            //this.Close();
        }

        #region Methods

        public void PrintPI()
        {
            try
            {
                if (comboBoxGRNPrint.SelectedValue.ToString() == "1")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportA4GRNCr rpt = new CrystalReportA4GRNCr();
                    objBAL = new ClassPOBAL();
                    objBAL.PIHDId = Convert.ToInt32(POHDId.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (comboBoxGRNPrint.SelectedValue.ToString() == "2")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportA4GRNCrS rpt = new CrystalReportA4GRNCrS();
                    objBAL = new ClassPOBAL();
                    objBAL.PIHDId = Convert.ToInt32(POHDId.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (comboBoxGRNPrint.SelectedValue.ToString() == "3")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportGRN4in rpt = new CrystalReportGRN4in();
                    objBAL = new ClassPOBAL();
                    objBAL.PIHDId = Convert.ToInt32(POHDId.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (comboBoxGRNPrint.SelectedValue.ToString() == "4")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportGRN4inS rpt = new CrystalReportGRN4inS();
                    objBAL = new ClassPOBAL();
                    objBAL.PIHDId = Convert.ToInt32(POHDId.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (comboBoxGRNPrint.SelectedValue.ToString() == "5")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportPI3in3ex rpt = new CrystalReportPI3in3ex();
                    objBAL = new ClassPOBAL();
                    objBAL.PIHDId = Convert.ToInt32(POHDId.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else if (comboBoxGRNPrint.SelectedValue.ToString() == "6")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    FormReport REPORT = new FormReport();
                    REPORT.Show();
                    CrystalReportPI5in3 rpt = new CrystalReportPI5in3();
                    objBAL = new ClassPOBAL();
                    objBAL.PIHDId = Convert.ToInt32(POHDId.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreivePIPrint(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    REPORT.crystalReportViewer1.ReportSource = rpt;
                    REPORT.crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                //Cursor.Current = Cursors.WaitCursor;
                //FormReport REPORT = new FormReport();
                //REPORT.Show();
                //CrystalReportPInvoice rpt = new CrystalReportPInvoice();
                //objBAL = new ClassPOBAL();
                //objBAL.POHDId = Convert.ToInt32(POHDId.ToString());
                //objDAL = new ClassPODAL();
                //objBAL.DtDataSet = objDAL.retreivePIData(objBAL);
                //rpt.SetDataSource(objBAL.DtDataSet);
                //REPORT.crystalReportViewer1.ReportSource = rpt;
                //REPORT.crystalReportViewer1.Refresh();
                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void PrintPIReturn()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportPInvoiceReturn rpt = new CrystalReportPInvoiceReturn();
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(POHDId.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePIReturnData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker4.Value;
                objBAL.date2 = dateTimePicker3.Value;
                objDAL = new ClassPODAL();
                dataGridView3.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePIReturnDatabyDate(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView3.DataSource = objBAL.DtDataSet.Tables[0];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            POHDId = Convert.ToInt32(dr.Cells["PIHDId"].Value.ToString());
            PrintPIReturn();
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            loadGRNOptions();
            SelectuserGRNPrint();
        }

        private void SelectuserGRNPrint()
        {
            try
            {
                //comboBoxGRNPrint.Text = "No";
                BALUser objUser = new BALUser();
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveuserGRNPrint(objUser);
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
                        comboBoxGRNPrint.SelectedValue = (values[0].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion
      
    }
}
