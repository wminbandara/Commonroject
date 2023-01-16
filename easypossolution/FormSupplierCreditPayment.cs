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
    public partial class FormSupplierCreditPayment : Form
    {
        #region Local Variables

        ClassPOBAL objPOBAL = new ClassPOBAL();
        ClassPODAL objPODAL = new ClassPODAL();

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        string FYear, ID;

        bool loadStatus;
        public string ChequeNo, CustomerID,ChqAmount;

        #endregion

        #region Constructor

        public FormSupplierCreditPayment()
        {
            InitializeComponent();
        }

        #endregion        

        #region Methods

        private void insertSupplierCheque()
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                    try
                    {
                        ClassPOBAL objBAL = new ClassPOBAL();
                        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                        objBAL.POHDId = 0;
                        objBAL.ChequeBank = comboBoxBank.Text.Trim();
                        objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                        objBAL.ChequeNo = textBoxChequeNo.Text.Trim();
                        objBAL.ChequeAmount = Convert.ToDecimal(textBoxPayment.Text);
                        objBAL.ChequeExpDate = dateTimePickerChqExpDate.Value;
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        ClassPODAL objDAL = new ClassPODAL();
                        int count = objDAL.InsertSupplierCheque(objBAL);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

            }
        }

        private void Reset()
        {
            textBoxID.Clear();
            textBoxName.Clear();
            textBoxContactPerson.Clear();
            textBoxBusinessNo.Clear();
            textBoxMobile.Clear();
            textBoxEmail.Clear();
            TextBoxAddress.Clear();
            textBoxRemarks.Clear();
            textBoxCreditAmount.Text = "0.00";
            textBoxTotalPayment.Text = "0.00";
            textBoxBalance.Text = "0.00";
            label14.Visible = false;
            textBoxChequeAmount.Visible = false;
            textBoxChequeAmount.Text = "0.00";
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }

        private void SelectSupplierData()
        {
            try
            {
                if (loadStatus == false && comboBoxSupplier.SelectedIndex != -1)
                {
                    objBAL = new ClassCommonBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassMasterDAL();
                    objBAL.DtDataSet = objDAL.retreiveSupplierDataByID(objBAL);
                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = null;
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
                            textBoxID.Text = (values[0].ToString().Trim());
                            textBoxName.Text = (values[1].ToString().Trim());
                            textBoxContactPerson.Text = (values[2].ToString().Trim());
                            textBoxBusinessNo.Text = (values[3].ToString().Trim());
                            textBoxMobile.Text = (values[4].ToString().Trim());
                            textBoxEmail.Text = (values[5].ToString().Trim());
                            TextBoxAddress.Text = (values[6].ToString().Trim());
                            textBoxRemarks.Text = (values[7].ToString().Trim());
                        }
                    }
                    if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    {
                        dataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                        //dataGridView1.Columns["PIHDId"].Visible = false;
                        dataGridView1.Columns["SupplierId"].Visible = false;
                        dataGridView1.Columns["CreditAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (objBAL.DtDataSet.Tables[2].Rows.Count > 0)
                    {
                        dataGridView2.DataSource = objBAL.DtDataSet.Tables[2];
                        dataGridView2.Columns["PaymentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    SelectSupplierCreditData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectSupplierCreditData()
        {
            try
            {
                if (loadStatus == false && comboBoxSupplier.SelectedIndex != -1)
                {
                    objBAL = new ClassCommonBAL();
                    objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                    objDAL = new ClassMasterDAL();
                    objBAL.DtDataSet = objDAL.retreiveSupplierDataByID(objBAL);
                    dataGridView3.DataSource = null;
                    dataGridView3.Rows.Clear();
                    textBoxPayTotal.Text = "0.00";
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
                            int n = dataGridView3.Rows.Add();

                            dataGridView3.Rows[n].Cells["BillNo"].Value = (values[0].ToString().Trim());
                            dataGridView3.Rows[n].Cells["CreditDate"].Value = Convert.ToDateTime(values[2].ToString().Trim()).ToString("yyyy/MM/dd");
                            dataGridView3.Rows[n].Cells["CreditAmount"].Value = (values[3].ToString().Trim());
                            dataGridView3.Rows[n].Cells["PaymentAmount"].Value = "0";

                            dataGridView3.FirstDisplayedScrollingRowIndex = n;
                            dataGridView3.CurrentCell = dataGridView3.Rows[n].Cells[0];
                            dataGridView3.Rows[n].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillItemTotalBalanceValue()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    decimal total = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        total = Convert.ToDecimal(dataGridView1["CreditAmount", i].Value.ToString()) + total;
                    }
                    textBoxCreditAmount.Text = total.ToString();
                    textBoxBalance.Text = (Convert.ToDecimal(textBoxCreditAmount.Text) - Convert.ToDecimal(textBoxTotalPayment.Text)).ToString("0.00");
                }
                if (dataGridView2.Rows.Count > 0)
                {
                    decimal total = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        total = Convert.ToDecimal(dataGridView2["PaymentAmount", i].Value.ToString()) + total;
                    }
                    textBoxTotalPayment.Text = total.ToString();
                    textBoxBalance.Text = (Convert.ToDecimal(textBoxCreditAmount.Text) - Convert.ToDecimal(textBoxTotalPayment.Text)).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertSupplierCreditHD()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayment.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                if (comboBoxBank.SelectedIndex == -1)
                {
                    comboBoxBank.SelectedValue = 0;
                }
                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);
                objDAL = new ClassMasterDAL();

                string count = objDAL.InsertSupplierCredPayHD(objBAL);
                textBoxHDId.Text = count.ToString();
                if (count != "")
                {
                    insertSupplierCredit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool savestate;
        private void insertSupplierCredit()
        {
            try
            {
                savestate = false;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value) > 0)
                    {
                        objBAL = new ClassCommonBAL();
                        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                        objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                        objBAL.PaymentAmount = Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value);
                        objBAL.PIHDId = Convert.ToInt32(dataGridView3.Rows[i].Cells["BillNo"].Value);
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                        objBAL.ChequeNo = textBoxChequeNo.Text;
                        objBAL.CreditPayHDId = Convert.ToInt32(textBoxHDId.Text);
                        objDAL = new ClassMasterDAL();
                        int count = objDAL.InsertSuppCredPay(objBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }
                }
                //objBAL = new ClassCommonBAL();
                //objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                //objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                //objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayment.Text);
                //objBAL.PIHDId = Convert.ToInt32(textBoxInvoiceNo.Text);
                //objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                //objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                //objBAL.ChequeNo = textBoxChequeNo.Text;
                //objDAL = new ClassMasterDAL();
                //int count = objDAL.InsertSuppCredPay(objBAL);
                //if (count != 0)
                //{
                if (savestate == true)
                {
                    MessageBox.Show("Supplier Credit Payment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result = MessageBox.Show("Do you want to print this Payment Recipt ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        printInvoice();
                    }
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
                CrystalReportSupplierCreditPay rpt = new CrystalReportSupplierCreditPay();
                //CrystalReportSuppCreditPay2in rpt = new CrystalReportSuppCreditPay2in();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                objPOBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                objPOBAL.CreditPayHDId = Convert.ToInt32(textBoxHDId.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveSupplierPaymentData(objPOBAL);
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

        private void insertSupplierChequeCredit()
        {
            try
            {
                savestate = false;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value) > 0)
                    {
                        objBAL = new ClassCommonBAL();
                        objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                        objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                        objBAL.PaymentAmount = Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value);
                        objBAL.PIHDId = Convert.ToInt32(dataGridView3.Rows[i].Cells["BillNo"].Value);
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                        objBAL.ChequeNo = ChequeNo;
                        objBAL.CustomerId = Convert.ToInt32(CustomerID.ToString());
                        objDAL = new ClassMasterDAL();
                        int count = objDAL.InsertSuppCredPayChq(objBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }
                }
                //objBAL = new ClassCommonBAL();
                //objBAL.SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue.ToString());
                //objBAL.PaymentDate = dateTimePickerPaymentDate.Value;
                //objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayment.Text);
                //objBAL.PIHDId = Convert.ToInt32(textBoxInvoiceNo.Text);
                //objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                //objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                //objBAL.ChequeNo = textBoxChequeNo.Text;
                //objDAL = new ClassMasterDAL();
                //int count = objDAL.InsertSuppCredPay(objBAL);
                //if (count != 0)
                //{
                if (savestate == true)
                {
                    MessageBox.Show("Supplier Credit Payment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadBank()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxBank.DataSource = objDAL.retreiveBanks(objBAL).Tables[0];
                comboBoxBank.DisplayMember = "BankName";
                comboBoxBank.ValueMember = "BankId";
                comboBoxBank.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Events

        private void FormSupplierCreditPayment_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                comboBoxSupplier.DataSource = objPODAL.retreivesSuppliers(objPOBAL).Tables[0];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierId";
                comboBoxSupplier.SelectedIndex = -1;

                objPOBAL = new ClassPOBAL();
                objPODAL = new ClassPODAL();
                if (objPODAL.retreivePaymodes(objPOBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objPODAL.retreivePaymodes(objPOBAL).Tables[0];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 0;
                }
                loadBank();
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
            SelectSupplierData();
            fillItemTotalBalanceValue();
        }


        private void ButtonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            comboBoxSupplier.SelectedIndex = -1;
            Reset();
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateSupplier() && ValidatePaymentAmount() && ValidatChqPaymentAmount() && ValidateGridSetoff();
            if (isValid)
            {
                if (Convert.ToDecimal(textBoxOutofBalance.Text) == 0)
                {
                    if (comboBoxPayMode.Text == "CheckInHand")
                    {
                        insertSupplierChequeCredit();
                        SelectSupplierData();
                        fillItemTotalBalanceValue();
                    }
                    else
                    {
                        //insertSupplierCredit();
                        insertSupplierCreditHD();
                        if (comboBoxPayMode.Text == "Cheque")
                        {
                            insertSupplierCheque();
                        }
                        SelectSupplierData();
                        fillItemTotalBalanceValue();
                    }
                    label14.Visible = false;
                    textBoxChequeAmount.Visible = false;
                    textBoxChequeAmount.Text = "0.00";
                }
                else
                {
                    MessageBox.Show("Please setoff full amount.", "Invalid Setoff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                
            }
            
        }

        #endregion
        
        #region Validation Methods

        private bool ValidateGridSetoff()
        {
            //comboBoxCustomer.Text = comboBoxCustomer.Text.Trim();
            string errorCode = string.Empty;
            if (dataGridView3.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value) > Convert.ToDecimal(dataGridView3.Rows[i].Cells["CreditAmount"].Value))
                    {
                        errorCode = ("Invalid Payment Amount Contain");
                    }
                }
            }
            //if ((string.IsNullOrEmpty(comboBoxCustomer.Text)) || (comboBoxCustomer.Text.Trim().Equals(string.Empty)))
            //{
            //    errorCode = "Please Select Customer.";
            //}
            string message = errorCode;
            errorProvider1.SetError(textBoxPayment, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateSupplier()
        {
            comboBoxSupplier.Text = comboBoxSupplier.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxSupplier.Text)) || (comboBoxSupplier.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Supplier.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxSupplier, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePaymentAmount()
        {
            textBoxPayment.Text = textBoxPayment.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxPayment.Text)) || (textBoxPayment.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Cash amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxPayment.Text))
            {
                errorCode = "Invalid Cash Amount.";
            }
            else if (Convert.ToDecimal(textBoxPayment.Text) < 0)
            {
                errorCode = "Invalid Cash Amount.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxPayment, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatChqPaymentAmount()
        {
            textBoxPayment.Text = textBoxPayment.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxPayment.Text)) || (textBoxPayment.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Payment amount.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxPayment.Text))
            {
                errorCode = "Invalid Payment Amount.";
            }
            else if (Convert.ToDecimal(textBoxPayment.Text) < 0)
            {
                errorCode = "Invalid Payment Amount.";
            }
            else if ((comboBoxPayMode.Text == "CheckInHand") && (Convert.ToDecimal(textBoxPayment.Text) != Convert.ToDecimal(textBoxChequeAmount.Text)))
            {
                errorCode = "Selected Cheque Amount and Payment amount Not Maching.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxPayment, message);
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

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                label10.Visible = true;
                label10.Text = "Cheque No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Cheq. Date";
                dateTimePickerChqExpDate.Visible = true;
                comboBoxCardType.Visible = false;
                //label11.Visible = true;
                //label11.Text = "Cheque Amount";
                //textBoxChqCardAmount.Visible = true;
                label14.Visible = false;
                textBoxChequeAmount.Visible = false;
                simpleButtonCheckPay.Enabled = false;
            }
            else if (comboBoxPayMode.Text == "Bank Transfer")
            {
                //label10.Visible = true;
                //label10.Text = "Cheque No";
                //textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                //label27.Visible = true;
                //label27.Text = "Exp. Date";
                //dateTimePickerChqExpDate.Visible = true;
                comboBoxCardType.Visible = false;
                //label11.Visible = true;
                //label11.Text = "Cheque Amount";
                //textBoxChqCardAmount.Visible = true;
                label14.Visible = false;
                textBoxChequeAmount.Visible = false;
                simpleButtonCheckPay.Enabled = false;
            }
            else if (comboBoxPayMode.Text == "Card")
            {
                label10.Visible = true;
                label10.Text = "Card No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Card Type";
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = true;
                //label11.Visible = true;
                //label11.Text = "Card Amount";
                //textBoxChqCardAmount.Visible = true;
                label14.Visible = false;
                textBoxChequeAmount.Visible = false;
                simpleButtonCheckPay.Enabled = false;
            }
            else if (comboBoxPayMode.Text == "CheckInHand")
            {
                label10.Visible = false;
                textBoxChequeNo.Visible = false;
                label25.Visible = false;
                comboBoxBank.Visible = false;
                label27.Visible = false;
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = false;
                label11.Visible = false;
                textBoxChqCardAmount.Visible = false;
                label14.Visible = true;
                textBoxChequeAmount.Visible = true;
                simpleButtonCheckPay.Enabled = true;
            }
            else
            {
                label10.Visible = false;
                textBoxChequeNo.Visible = false;
                label25.Visible = false;
                comboBoxBank.Visible = false;
                label27.Visible = false;
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = false;
                label11.Visible = false;
                textBoxChqCardAmount.Visible = false;
                label14.Visible = false;
                textBoxChequeAmount.Visible = false;
                simpleButtonCheckPay.Enabled = false;
            }
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
                textBoxPayTotal.Text = CellSum().ToString();
        }

        private double CellSum()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView3.Rows.Count; ++i)
            {
                double d = 0;
                Double.TryParse(dataGridView3.Rows[i].Cells[3].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private void textBoxPayTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //textBoxPayment.Text = textBoxPayTotal.Text;
                textBoxOutofBalance.Text = (Convert.ToDecimal(textBoxPayment.Text) - Convert.ToDecimal(textBoxPayTotal.Text)).ToString();

            }
            catch
            {
            }
            //textBoxPayment.Text = textBoxPayTotal.Text;
        }

        private void simpleButtonCheckPay_Click(object sender, EventArgs e)
        {
            ChqAmount = "0";
            CustomerID = "0";
            FormCreditPayCheques frm = new FormCreditPayCheques();
            frm.frm = this;
            //frm.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
            frm.lblUser.Text = lblUser.Text.Trim();
            frm.lblUserId.Text = lblUserId.Text.Trim();
            frm.ShowDialog(this);
        }

        private void textBoxPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxOutofBalance.Text = (Convert.ToDecimal(textBoxPayment.Text) - Convert.ToDecimal(textBoxPayTotal.Text)).ToString();

            }
            catch
            {
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBoxOutofBalance.Text) >= Convert.ToDecimal(dataGridView3.CurrentRow.Cells[2].Value))
                {
                    if (Convert.ToDecimal(dataGridView3.CurrentRow.Cells[3].Value) == 0)
                    {
                        dataGridView3.CurrentRow.Cells[3].Value = dataGridView3.CurrentRow.Cells[2].Value.ToString();

                    }

                }
                else if (Convert.ToDecimal(textBoxOutofBalance.Text) < Convert.ToDecimal(dataGridView3.CurrentRow.Cells[2].Value))
                {
                    if (Convert.ToDecimal(dataGridView3.CurrentRow.Cells[3].Value) == 0)
                    {
                        dataGridView3.CurrentRow.Cells[3].Value = textBoxOutofBalance.Text;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
