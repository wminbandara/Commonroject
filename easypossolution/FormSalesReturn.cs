using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
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
    public partial class FormSalesReturn : Form
    {
        #region Local Variables

        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        #endregion

        #region Constructor

        public FormSalesReturn()
        {
            InitializeComponent();
        }

        #endregion

        private void FormSalesReturn_Load(object sender, EventArgs e)
        {
            try
            {
                objBAL = new ClassSOBAL();
                objDAL = new ClassSODAL();
                //comboBoxCustomer.DataSource = objDAL.retreiveAllCustomers(objBAL).Tables[0];
                //comboBoxCustomer.DisplayMember = "CustomerName";
                //comboBoxCustomer.ValueMember = "CustomerId";
                //comboBoxCustomer.SelectedIndex = -1;

                //comboBoxPayMode.DataSource = objDAL.retreiveSOLoadingData(objBAL).Tables[1];
                //comboBoxPayMode.DisplayMember = "PayMode";
                //comboBoxPayMode.ValueMember = "PayModeId";
                //comboBoxPayMode.SelectedIndex = -1;

                comboBoxItemCategory.DataSource = objDAL.retreiveSOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Methods

        public void Reset()
        {
            textBoxSOID.Clear();
            dateTimePickerSalesDate.Value = DateTime.Today;
            //textBoxBillNo.Clear();
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            textBoxRtnReason.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            //comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxSalesPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            labelSODT.Text = "0";
            textBoxFree.Text = "0";
            dataGridView1.DataSource = null;
        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            //comboBoxUnit.Text = "";
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxQty.Text = "0";
            textBoxSalesPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxRtnReason.Clear();
            labelSODT.Text = "0";
            textBoxFree.Text = "0";
        }

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemName.Clear();
            //comboBoxUnit.Text = "";
            textBoxSalesPrice.Text = "0.00";
        }

        private void fillBillData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.BillNo = Convert.ToInt32(textBoxBillNo.Text);
                objDAL = new ClassSODAL();
                objBAL.DtDataSet = objDAL.retreiveBillData(objBAL);
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
                        textBoxSOID.Text = (values[0].ToString().Trim());
                        dateTimePickerSalesDate.Value = Convert.ToDateTime(values[1].ToString());
                        textBoxCustomer.Text = (values[2].ToString().Trim());
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillVehicleNoData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.VehicleNo = textBoxCustomer.Text;
                objDAL = new ClassSODAL();
                objBAL.DtDataSet = objDAL.retreiveVehicleNoData(objBAL);
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
                        textBoxSOID.Text = (values[0].ToString().Trim());
                        dateTimePickerSalesDate.Value = Convert.ToDateTime(values[1].ToString());
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillSODtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.BillNo = Convert.ToInt32(textBoxBillNo.Text);
                objDAL = new ClassSODAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveBillData(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                    dataGridView1.Columns["BillNo"].Visible = false;
                    dataGridView1.Columns["SODTId"].Visible = false;
                    dataGridView1.Columns["SOHDId"].Visible = false;
                    dataGridView1.Columns["ItemsId"].Visible = false;
                    dataGridView1.Columns["ItemCatId"].Visible = false;
                    dataGridView1.Columns["SalesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["NetAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["FreeIssue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    
                    dataGridView1.Columns["NetAmount"].DefaultCellStyle.Format = "0.00";
                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemNetValue()
        {
            textBoxNetAmount.Text = ((Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxSalesPrice.Text))).ToString("0.00");
        }

        private void insertReturn()
        {
            try
            {
                objBAL = new ClassSOBAL();
                objBAL.SOHDId = Convert.ToInt32(textBoxSOID.Text);
                objBAL.SODTId = Convert.ToInt32(labelSODT.Text);
                objBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objBAL.RtnReason = textBoxRtnReason.Text.Trim(); ;
                objBAL.ReturnQty = Convert.ToDecimal(textBoxQty.Text);
                objBAL.SalesPrice = Convert.ToDecimal(textBoxSalesPrice.Text);
                objBAL.NetAmount = Convert.ToDecimal(textBoxNetAmount.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.FreeIssue = Convert.ToDecimal(textBoxFree.Text);
                objDAL = new ClassSODAL();
                int count = objDAL.InsertReturn(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Item Return Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DialogResult result = MessageBox.Show("Do you want to print this Return Recipt ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{
                    //    printInvoice();
                    //}
                    resetDetail();
                    fillSODtRec();
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
                CrystalReportSalesRtn3in rpt = new CrystalReportSalesRtn3in();
                ClassPOBAL objBAL = new ClassPOBAL();
                objBAL.SOHDId = Convert.ToInt32(textBoxSOID.Text);
                objBAL.ItemsId = Convert.ToInt32(textBoxItemId.Text);
                ClassPODAL objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveSalesRtnData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                //crystalReportViewer1.PrintReport();
                rpt.PrintOptions.PrinterName = "";
                rpt.PrintToPrinter(1, false, 0, 0);
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion        

        #region Events

        private void textBoxBillNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBillNo.Text != "")
            {
                Reset();
                fillBillData();
                fillSODtRec();
            }
            else if (textBoxBillNo.Text == "")
            {
                Reset();
            }
        }

        private void textBoxQty_Validating(object sender, CancelEventArgs e)
        {
            fillItemNetValue();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            textBoxBillNo.Clear();
            Reset();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                resetDetail();
                textBoxItemId.Text = dataGridView1["ItemsId", e.RowIndex].Value.ToString();
                labelSODT.Text = dataGridView1["SODTId", e.RowIndex].Value.ToString();
                textBoxItemCode.Text = dataGridView1["ItemCode", e.RowIndex].Value.ToString();
                textBoxItemName.Text = dataGridView1["ItemName", e.RowIndex].Value.ToString();
                comboBoxItemCategory.SelectedValue = dataGridView1["ItemCatId", e.RowIndex].Value.ToString();
                textBoxQty.Text = dataGridView1["SalesQty", e.RowIndex].Value.ToString();
                textBoxSalesPrice.Text = dataGridView1["SalesPrice", e.RowIndex].Value.ToString();
                textBoxNetAmount.Text = Convert.ToDecimal(dataGridView1["NetAmount", e.RowIndex].Value.ToString()).ToString("0.00");
                textBoxFree.Text = dataGridView1["FreeIssue", e.RowIndex].Value.ToString();
            }
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateQty();
            if (isValid)
            {
                DialogResult result = MessageBox.Show("Are you sure, Do you want to return this invoice item?", "Item return Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    insertReturn();
                }
            }
        }

        #endregion

        #region Validation Methods

        private bool ValidateQty()
        {
            textBoxQty.Text = textBoxQty.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxQty.Text)) || (textBoxQty.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Quentity.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxQty.Text))
            {
                errorCode = "Invalid Quentity.";
            }
            else if (Convert.ToDecimal(textBoxQty.Text) < 0)
            {
                errorCode = "Invalid Quentity.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxQty, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            //FrmSalesRecord frm = new FrmSalesRecord();
            //frm.frm = this;
            ////frm.ReturnStatus = true;
            //frm.ShowDialog(this);
        }

        private void textBoxVehicleNo_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxVehicleNo.Text != "")
            //{
            //    Reset();
            //    fillVehicleNoData();
            //    fillSODtRec();
            //}
            //else if (textBoxVehicleNo.Text == "")
            //{
            //    Reset();
            //}
        }

        private void textBoxVehicleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormFindInvoice frm = new FormFindInvoice();
                frm.frm = this;
                frm.VehicleNo = textBoxCustomer.Text;
                frm.fillGridVehicleInvoice();
                frm.ShowDialog(this);
            }
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            if (textBoxQty.Text != "" && textBoxSalesPrice.Text != "")
            {
                textBoxNetAmount.Text = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxSalesPrice.Text)).ToString("0.00"); 
            }
            
        }
    }
}
