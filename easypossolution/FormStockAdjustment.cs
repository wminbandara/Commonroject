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
    public partial class FormStockAdjustment : Form
    {
        #region Local Variables

        ClassPOBAL objPOBAL = new ClassPOBAL();
        ClassPODAL objPODAL = new ClassPODAL();

        bool loadStatus, autocomplete;

        ArrayList alistOption = new ArrayList();
        ArrayList alistForm = new ArrayList();

        #endregion

        #region Constructor
        public FormStockAdjustment()
        {
            InitializeComponent();
        }

        #endregion

        private void ResetNew()
        {
            textBoxItemId.Text = "0";
            textBoxSearchItemCode.Text = "";
            textBoxItemName.Text = "";
            textBoxQty.Text = "0";
            textBoxSystemQty.Text = "0";
            textBoxRate.Text = "0.00";
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            textBoxAdjustmentNo.Clear();
            textBoxVarianceTotal.Text = "0.00";
        }

        private void userPermission()
        {
            try
            {
                autocomplete = false;
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

                        if (alistForm[i].ToString().Trim() == "Auto Complete")
                        {
                            autocomplete = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemAutoComplete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemName(objInvBAL);

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
                        textBoxSearchItemCode.AutoCompleteCustomSource.Add(values[1].ToString());
                        textBoxItemName.AutoCompleteCustomSource.Add(values[2].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormStockAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxSearchItemCode.Select();
                FormItemSearch frm14 = new FormItemSearch();
                frm14.frm14 = this;
                frm14.form = 14;
                frm14.wh = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                frm14.ShowDialog(this);
                textBoxSearchItemCode.Select();
            }
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this Selected Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    RemoveItem();
                }
            }
        }

        void RemoveItem()
        {
            try
            {
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    dataGridView3.Rows.RemoveAt(dataGridView3.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Select one item to remove!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormStockAdjustment_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                comboBoxBranch.DataSource = objDAL.retreiveAllBranches(objBAL).Tables[0];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedValue = lblBranchID.Text;
                textBoxSearchItemCode.Select();

                //ClassPOBAL objPOBAL = new ClassPOBAL();
                //ClassPODAL objPODAL = new ClassPODAL();
                //comboBoxCategorySearch.DataSource = objPODAL.retreiveAllCategoryData(objPOBAL).Tables[0];
                //comboBoxCategorySearch.DisplayMember = "ItemCatName";
                //comboBoxCategorySearch.ValueMember = "ItemCatId";
                //comboBoxCategorySearch.SelectedIndex = -1;
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxFromNewQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxFromItemCode.Text != "" && textBoxFromNewQty.Text != "" && Convert.ToDecimal(textBoxFromNewQty.Text) > 0)
                {
                    textBoxVariance.Text = (Convert.ToDecimal(textBoxFromNewQty.Text) - Convert.ToDecimal(textBoxAvailableQty.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        #region Methods

        private void InsertAdjustmentHD()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objPOBAL.TotalVariance = Convert.ToDecimal(textBoxVarianceTotal.Text);
                objPOBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objPODAL = new ClassPODAL();
                string count = objPODAL.InsertAdjustemtHD(objPOBAL);
                textBoxAdjustmentNo.Text = count.ToString();
                if (count != "")
                {
                    InsertAdjustemtDT();
                    //MessageBox.Show("Product Qty Updated Successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //objPODAL = new ClassPODAL();
                //int count = objPODAL.UpdateAdjustemt(objPOBAL);
                //if (count != 0)
                //{
                //    MessageBox.Show("Product Qty Updated Successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Reset();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool savestate;
        private void InsertAdjustemtDT()
        {
            try
            {
                savestate = false;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["VarrienceQty"].Value) != 0)
                    {
                        objPOBAL = new ClassPOBAL();
                        objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                        objPOBAL.StkAdjHDId = Convert.ToInt32(textBoxAdjustmentNo.Text);
                        objPOBAL.ItemsId = Convert.ToInt32(dataGridView3.Rows[i].Cells["ItemsId"].Value);
                        objPOBAL.ItemCode = (dataGridView3.Rows[i].Cells["ItemCode"].Value.ToString());
                        objPOBAL.SystemQty = Convert.ToDecimal(dataGridView3.Rows[i].Cells["AvailableQty"].Value);
                        objPOBAL.PhisicalQty = Convert.ToDecimal(dataGridView3.Rows[i].Cells["PhisicalQty"].Value);
                        objPOBAL.VarrienceQty = Convert.ToDecimal(dataGridView3.Rows[i].Cells["VarrienceQty"].Value);
                        objPOBAL.AvgCost = Convert.ToDecimal(dataGridView3.Rows[i].Cells["AvgCost"].Value);
                        objPOBAL.VarrienceValue = Convert.ToDecimal(dataGridView3.Rows[i].Cells["VarrienceValue"].Value);
                        objPOBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objPODAL = new ClassPODAL();
                        int count = objPODAL.InsertAdjustemtDT(objPOBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }

                }
                if (savestate == true)
                {
                    MessageBox.Show("Stock Adjustment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result = MessageBox.Show("Do you want to print this Stock Adjustment ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        printInvoice();
                    }
                    ResetNew();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printInvoice()
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportStkAdg rpt = new CrystalReportStkAdg();
                //CrystalReportCustCreditPay2in rpt = new CrystalReportCustCreditPay2in();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.StkAdjHDId = Convert.ToInt32(textBoxAdjustmentNo.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveStockAdjustmentData(objPOBAL);
                rpt.SetDataSource(objPOBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                //REPORT.crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateAdjustment()
        {
            try
            {
                objPOBAL = new ClassPOBAL();
                objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objPOBAL.ItemsId = Convert.ToInt32(textBoxFromItemId.Text);
                objPOBAL.ItemCode = textBoxFromItemCode.Text;
                objPOBAL.ExistingQty = Convert.ToDecimal(textBoxAvailableQty.Text);
                objPOBAL.NewQty = Convert.ToDecimal(textBoxFromNewQty.Text);
                objPOBAL.AdjustedQty = Convert.ToDecimal(textBoxVariance.Text);
                
                objPODAL = new ClassPODAL();
                int count = objPODAL.UpdateAdjustemt(objPOBAL);
                if (count != 0)
                {
                    MessageBox.Show("Product Qty Updated Successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchItem()
        {
            try
            {
                textBoxFromItemName.Clear();
                textBoxFromItemId.Text = "";
                textBoxAvailableQty.Text = "0";
                textBoxAvailableQty.Text = "0.00";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemCode = textBoxFromItemCode.Text;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsData(objInvBAL);
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

                        textBoxFromItemName.Text = (values[0].ToString().Trim());
                        textBoxFromItemId.Text = (values[2].ToString().Trim());
                        textBoxAvailableQty.Text = (values[3].ToString().Trim());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            InsertAdjustmentHD();
        }


        #region Events

        private void Reset()
        {
            try
            {
                textBoxFromItemId.Text = "0";
                textBoxFromItemCode.Clear();
                textBoxAvailableQty.Text = "0";
                textBoxVariance.Text = "0";
                textBoxFromItemName.Clear();
                textBoxFromNewQty.Text = "0";
                textBoxSearchItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void textBoxFromItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SearchItem();
            }
        }

        private void comboBoxCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false && comboBoxBranch.SelectedIndex != -1 && comboBoxCategorySearch.SelectedIndex != -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    objPOBAL = new ClassPOBAL();
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemCatId = Convert.ToInt32(comboBoxCategorySearch.SelectedValue.ToString());
                    objPODAL = new ClassPODAL();
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    objPOBAL.DtDataSet = objPODAL.retreiveAdjStockByItmCat(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        List<ArrayList> newval = new List<ArrayList>();
                        foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                        {
                            ArrayList values = new ArrayList();
                            values.Clear();
                            foreach (object value in dRow.ItemArray)
                                values.Add(value);
                            newval.Add(values);
                            int n = dataGridView3.Rows.Add();

                            dataGridView3.Rows[n].Cells["ItemCode"].Value = (values[0].ToString().Trim());
                            dataGridView3.Rows[n].Cells["ItemName"].Value = (values[1].ToString().Trim());
                            dataGridView3.Rows[n].Cells["AvailableQty"].Value = (values[2].ToString().Trim());
                            dataGridView3.Rows[n].Cells["PhisicalQty"].Value = (values[3].ToString().Trim());
                            dataGridView3.Rows[n].Cells["VarrienceQty"].Value = (values[4].ToString().Trim());
                            dataGridView3.Rows[n].Cells["AvgCost"].Value = (values[5].ToString().Trim());
                            dataGridView3.Rows[n].Cells["VarrienceValue"].Value = (values[6].ToString().Trim());
                            dataGridView3.Rows[n].Cells["ItemsId"].Value = (values[7].ToString().Trim());

                            //dataGridView3.Rows[n].Cells["PhisicalQty"].ReadOnly = false;
                            dataGridView3.FirstDisplayedScrollingRowIndex = n;
                            dataGridView3.CurrentCell = dataGridView3.Rows[n].Cells[0];
                            dataGridView3.Rows[n].Selected = true;
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

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && dataGridView3.Rows.Count > 0)
                {
                    textBoxVarianceTotal.Text = CellQtyChange().ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private double CellQtyChange()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; ++i)
            {
                dataGridView3.Rows[i].Cells["VarrienceQty"].Value = (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PhisicalQty"].Value) - Convert.ToDecimal(dataGridView3.Rows[i].Cells["AvailableQty"].Value)).ToString("0.00");
                dataGridView3.Rows[i].Cells["VarrienceValue"].Value = (Convert.ToDecimal(dataGridView3.Rows[i].Cells["VarrienceQty"].Value) * Convert.ToDecimal(dataGridView3.Rows[i].Cells["AvgCost"].Value)).ToString("0.00");

                double d = 0;
                Double.TryParse(dataGridView3.Rows[i].Cells["VarrienceValue"].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private void textBoxSearchItemCode_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    objPOBAL = new ClassPOBAL();
            //    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
            //    objPOBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
            //    objPODAL = new ClassPODAL();
            //    dataGridView3.DataSource = null;
            //    dataGridView3.Rows.Clear();
            //    objPOBAL.DtDataSet = objPODAL.retreiveStockAdjByBranchItmCode(objPOBAL);
            //    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
            //    {
            //        List<ArrayList> newval = new List<ArrayList>();
            //        foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
            //        {
            //            ArrayList values = new ArrayList();
            //            values.Clear();
            //            foreach (object value in dRow.ItemArray)
            //                values.Add(value);
            //            newval.Add(values);
            //            int n = dataGridView3.Rows.Add();

            //            dataGridView3.Rows[n].Cells["ItemCode"].Value = (values[0].ToString().Trim());
            //            dataGridView3.Rows[n].Cells["ItemName"].Value = (values[1].ToString().Trim());
            //            dataGridView3.Rows[n].Cells["AvailableQty"].Value = (values[2].ToString().Trim());
            //            dataGridView3.Rows[n].Cells["PhisicalQty"].Value = (values[3].ToString().Trim());
            //            dataGridView3.Rows[n].Cells["VarrienceQty"].Value = (values[4].ToString().Trim());
            //            dataGridView3.Rows[n].Cells["AvgCost"].Value = (values[5].ToString().Trim());
            //            dataGridView3.Rows[n].Cells["VarrienceValue"].Value = (values[6].ToString().Trim());
            //            dataGridView3.Rows[n].Cells["ItemsId"].Value = (values[7].ToString().Trim());

            //            //dataGridView3.Rows[n].Cells["PhisicalQty"].ReadOnly = false;
            //            dataGridView3.FirstDisplayedScrollingRowIndex = n;
            //            dataGridView3.CurrentCell = dataGridView3.Rows[n].Cells[0];
            //            dataGridView3.Rows[n].Selected = true;
            //        }
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportStkAdg rpt = new CrystalReportStkAdg();
                //CrystalReportCustCreditPay2in rpt = new CrystalReportCustCreditPay2in();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.StkAdjHDId = Convert.ToInt32(textBoxReprint.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveStockAdjustmentData(objPOBAL);
                rpt.SetDataSource(objPOBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                //REPORT.crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblBranchID_TextChanged(object sender, EventArgs e)
        {
            comboBoxBranch.SelectedValue = lblBranchID.Text;
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
            if (autocomplete == true)
            {
                ItemAutoComplete();
                textBoxSearchItemCode.Select();
            }
        }

        private void textBoxItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxItemName.Text != "")
                {
                    SearchItemByName();
                    textBoxSearchItemCode_KeyDown(sender, e);
                }
            }
        }

        void SearchItemByName()
        {
            try
            {
                textBoxSearchItemCode.Clear();
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemName = textBoxItemName.Text.Trim();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsDataByName(objInvBAL);
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
                        textBoxSearchItemCode.Text = (values[0].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSearchItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxSearchItemCode.Text != "")
                {
                    try
                    {
                        textBoxItemId.Text = "0";
                        //textBoxSearchItemCode.Text = "";
                        textBoxItemName.Text = "";
                        textBoxQty.Text = "0";
                        textBoxSystemQty.Text = "0";
                        textBoxRate.Text = "0.00";

                        ClassPOBAL objPOBAL = new ClassPOBAL();
                        objPOBAL.ItemCode = textBoxSearchItemCode.Text.Trim();
                        ClassPODAL objPODAL = new ClassPODAL();
                        objPOBAL.DtDataSet = objPODAL.retreiveItemCodeData(objPOBAL);
                        if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                        {
                            List<ArrayList> newval = new List<ArrayList>();
                            foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                            {
                                ArrayList values = new ArrayList();
                                values.Clear();
                                foreach (object value in dRow.ItemArray)
                                    values.Add(value);
                                newval.Add(values);

                                textBoxItemName.Text = (values[1].ToString().Trim());
                                textBoxRate.Text = (values[4].ToString().Trim());
                                textBoxItemId.Text = (values[7].ToString().Trim());

                                SearchBranchQty();
                            }
                            textBoxQty.Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void SearchBranchQty()
        {
            try
            {
                textBoxQty.Text = "0.00";
                textBoxSystemQty.Text = "0.00";
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objInvBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveBranchQty(objInvBAL);
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

                        textBoxQty.Text = (values[0].ToString().Trim());
                        textBoxSystemQty.Text = (values[0].ToString().Trim());

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (textBoxSearchItemCode.Text != "")
                {
                    AddtoGrid();
                }
                
            }
        }

        private void AddtoGrid()
        {
            try
            {
                int n = dataGridView3.Rows.Add();

                dataGridView3.Rows[n].Cells["ItemsId"].Value = textBoxItemId.Text;
                dataGridView3.Rows[n].Cells["ItemCode"].Value = textBoxSearchItemCode.Text;
                dataGridView3.Rows[n].Cells["ItemName"].Value = textBoxItemName.Text;
                dataGridView3.Rows[n].Cells["VarrienceQty"].Value = "0";
                dataGridView3.Rows[n].Cells["VarrienceValue"].Value = "0";
                dataGridView3.Rows[n].Cells["AvailableQty"].Value = textBoxSystemQty.Text;
                dataGridView3.Rows[n].Cells["AvgCost"].Value = textBoxRate.Text;
                dataGridView3.Rows[n].Cells["PhisicalQty"].Value = textBoxQty.Text;



                dataGridView3.FirstDisplayedScrollingRowIndex = n;
                dataGridView3.CurrentCell = dataGridView3.Rows[n].Cells[0];
                dataGridView3.Rows[n].Selected = true;

                textBoxItemId.Text = "0";
                textBoxSearchItemCode.Text = "";
                textBoxItemName.Text = "";
                textBoxQty.Text = "0";
                textBoxSystemQty.Text = "0";
                textBoxRate.Text = "0.00";
                textBoxSearchItemCode.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (textBoxSearchItemCode.Text != "")
            {
                AddtoGrid();
            }
        }


        #region Validation Methods



        #endregion
        
    }
}
