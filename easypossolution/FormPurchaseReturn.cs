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
    public partial class FormPurchaseReturn : Form
    {

        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        bool loadStatus;

        #endregion

        #region Constructor

        public FormPurchaseReturn()
        {
            InitializeComponent();
        }
        #endregion

        private void FormPurchaseReturn_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                comboBoxSupplier.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierId";
                comboBoxSupplier.SelectedIndex = -1;

                comboBoxPayMode.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[1];
                comboBoxPayMode.DisplayMember = "PayMode";
                comboBoxPayMode.ValueMember = "PayModeId";
                comboBoxPayMode.SelectedIndex = -1;

                comboBoxItemCategory.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                try
                {
                    resetItemCodeData();
                    objBAL = new ClassPOBAL();
                    objBAL.ItemCode = textBoxItemCode.Text.Trim();
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveItemCodeData(objBAL);
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
                            comboBoxItemCategory.SelectedValue = (values[0].ToString().Trim());
                            textBoxItemName.Text = (values[1].ToString().Trim());
                            comboBoxUnit.Text = (values[3].ToString().Trim());
                            textBoxUnitCostPrice.Text = (values[4].ToString().Trim());
                        }
                    }
                    if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    {
                        List<ArrayList> newval = new List<ArrayList>();
                        foreach (DataRow dRow in objBAL.DtDataSet.Tables[1].Rows)
                        {
                            ArrayList values = new ArrayList();
                            values.Clear();
                            foreach (object value in dRow.ItemArray)
                                values.Add(value);
                            newval.Add(values);
                            textBoxPOID.Text = (values[0].ToString().Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region Methods

        public void Reset()
        {
            textBoxPOID.Clear();
            //textBoxPONo.Clear();
            dateTimePickerPODate.Value = DateTime.Today;
            dateTimePickerChqExpDate.Value = DateTime.Today;
            comboBoxSupplier.SelectedIndex = -1;
            textBoxInvoiceNo.Clear();
            comboBoxPayMode.SelectedIndex = -1;
            textBoxAddress.Clear();
            textBoxRemarks.Clear();
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            textBoxRtnReason.Clear();
            comboBoxItemCategory.SelectedIndex = -1;
            comboBoxBank.Text = "";
            textBoxChequeNo.Text = "";
            comboBoxUnit.Text = "";
            textBoxQty.Text = "0";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            dataGridView1.DataSource = null;
        }

        private void resetDetail()
        {
            textBoxItemId.Clear();
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            comboBoxUnit.Text = "";
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxQty.Text = "0";
            textBoxUnitCostPrice.Text = "0.00";
            textBoxNetAmount.Text = "0.00";
            textBoxRtnReason.Clear();
        }

        private void resetItemCodeData()
        {
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxItemName.Clear();
            comboBoxUnit.Text = "";
            textBoxUnitCostPrice.Text = "0.00";
        }

        private void fillPOHDIdData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreivePOHDIdData(objBAL);
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
                        //textBoxPONo.Text = (values[0].ToString().Trim());
                        textBoxInvoiceNo.Text = (values[1].ToString().Trim());
                        dateTimePickerPODate.Value = Convert.ToDateTime(values[2].ToString());
                        comboBoxSupplier.SelectedValue = (values[3]);
                        comboBoxPayMode.SelectedValue = (values[4]);
                        comboBoxBank.Text = (values[5].ToString().Trim());
                        textBoxChequeNo.Text = (values[6].ToString().Trim());
                        if (comboBoxBank.Text != "")
                        {
                            dateTimePickerChqExpDate.Value = Convert.ToDateTime(values[7].ToString());
                        }
                        textBoxRemarks.Text = (values[8].ToString().Trim());
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillPODtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objDAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePOHDIdData(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                    dataGridView1.Columns["PODTId"].Visible = false;
                    dataGridView1.Columns["POHDId"].Visible = false;
                    dataGridView1.Columns["ItemCatId"].Visible = false;
                    dataGridView1.Columns["ItemUnit"].Visible = false;
                    dataGridView1.Columns["ItemLocation"].Visible = false;
                    dataGridView1.Columns["PurchaseQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["PurchasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SellingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["GrossAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["NetAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.Columns["GrossAmount"].DefaultCellStyle.Format = "0.00";
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
            textBoxNetAmount.Text = ((Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxUnitCostPrice.Text))).ToString("0.00");
        }

        private void insertReturn()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                objBAL.PODTId = Convert.ToInt32(textBoxItemId.Text);
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objBAL.RtnReason = textBoxRtnReason.Text.Trim(); ;
                objBAL.ReturnQty = Convert.ToDecimal(textBoxQty.Text);
                objBAL.PurchasePrice = Convert.ToDecimal(textBoxUnitCostPrice.Text);
                objBAL.NetAmount = Convert.ToDecimal(textBoxNetAmount.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassPODAL();
                int count = objDAL.InsertReturn(objBAL);
                if (count != 0)
                {
                    UpdateSupplierCredit();
                    MessageBox.Show("Item Return Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetDetail();
                    fillPODtRec();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSupplierCredit()
        {
            if (comboBoxPayMode.Text == "Credit")
            {
                try
                {
                    objBAL = new ClassPOBAL();
                    objBAL.POHDId = Convert.ToInt32(textBoxPOID.Text);
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objBAL.CreditAmount = Convert.ToDecimal(textBoxNetAmount.Text);

                    objDAL = new ClassPODAL();
                    int count = objDAL.UpdateSupplierRtnCredit(objBAL);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        private void textBoxPOID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPOID.Text != "")
            {
                fillPOHDIdData();
                fillPODtRec();
            }
        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            FormPurchaseRecord frm1 = new FormPurchaseRecord();
            frm1.frm1 = this;
            frm1.ReturnStatus = true;
            frm1.ShowDialog(this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                resetDetail();
                textBoxItemId.Text = dataGridView1["PODTId", e.RowIndex].Value.ToString();
                textBoxItemCode.Text = dataGridView1["ItemCode", e.RowIndex].Value.ToString();
                textBoxItemName.Text = dataGridView1["ItemName", e.RowIndex].Value.ToString();
                comboBoxUnit.Text = dataGridView1["ItemUnit", e.RowIndex].Value.ToString();
                comboBoxItemCategory.SelectedValue = dataGridView1["ItemCatId", e.RowIndex].Value.ToString();
                textBoxQty.Text = dataGridView1["PurchaseQty", e.RowIndex].Value.ToString();
                textBoxUnitCostPrice.Text = dataGridView1["PurchasePrice", e.RowIndex].Value.ToString();
                textBoxNetAmount.Text = Convert.ToDecimal(dataGridView1["NetAmount", e.RowIndex].Value.ToString()).ToString("0.00");
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

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateQty();
            if (isValid)
            {
                insertReturn();
            }
        }

        #region Events


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

    }
}
