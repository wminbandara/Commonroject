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
    public partial class FormCustInvCreditPay : Form
    {
        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();
        public frmInvoice frm { set; get; }

        public int CustomerId;


        public FormCustInvCreditPay()
        {
            InitializeComponent();
        }

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
            string message = errorCode;
            errorProvider1.SetError(textBoxPayTotal, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateGridSetoff();
            if (isValid)
            {
                if ((Convert.ToDecimal(textBoxReturn.Text) > 0) && ((Convert.ToDecimal(textBoxReturn.Text)) != (Convert.ToDecimal(textBoxPayTotal.Text))))
                {
                    MessageBox.Show("Amount Missed Mach.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    insertCustomerCreditHD();
                    //insertCustomerCredit();
                    frm.CreditPay = Convert.ToDecimal(textBoxPayTotal.Text);
                    this.Close();
                }
                
            }
        }

        private void insertCustomerCreditHD()
        {
            try
            {
                //payment = "";
                //SMSmessage = "";
                //payment = textBoxPayment.Text;
                //SMSmessage = (Convert.ToDecimal(textBoxCreditAmount.Text) - Convert.ToDecimal(textBoxPayment.Text)).ToString();

                objBAL = new ClassCommonBAL();
                objBAL.CustomerId = CustomerId;
                objBAL.PaymentDate = DateTime.Today;
                objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayTotal.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.PayModeId = 3;
                objBAL.ReciptNo = "InvCRPay";
                objBAL.BankId = 0;

                objDAL = new ClassMasterDAL();

                string count = objDAL.InsertCustomerCredPayHD(objBAL);
                textBoxHDId.Text = count.ToString();
                if (count != "")
                {
                    insertCustomerCredit();

                    //if (AllowSMS == true && textBoxTel.Text != "")
                    //{
                    //    DialogResult result = MessageBox.Show("Do you want to send thanking message to this customer? ", "Message Sending Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (result == DialogResult.Yes)
                    //    {
                    //        sendThankingSMS();
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool savestate;
        private void insertCustomerCredit()
        {
            try
            {
                savestate = false;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value) > 0)
                    {
                        objBAL = new ClassCommonBAL();
                        objBAL.CustomerId = CustomerId;
                        objBAL.PaymentDate = DateTime.Today;
                        objBAL.PaymentAmount = Convert.ToDecimal(dataGridView3.Rows[i].Cells["PaymentAmount"].Value);
                        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objBAL.PIHDId = Convert.ToInt32(dataGridView3.Rows[i].Cells["BillNo"].Value);
                        objBAL.PayModeId = 3;
                        objBAL.CreditPayHDId = Convert.ToInt32(textBoxHDId.Text);
                        objBAL.ChequeNo = "";
                        objBAL.ReciptNo = "";
                        objBAL.BankId = 0;
                        objDAL = new ClassMasterDAL();
                        int count = objDAL.InsertCustomerCredPay(objBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }

                }
                if (savestate == true)
                {
                    MessageBox.Show("Customer Credit Payment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCustInvCreditPay_Load(object sender, EventArgs e)
        {
            FillSelectCustomerCreditData();
        }

        private void FillSelectCustomerCreditData()
        {
            try
            {
                if (CustomerId > 0)
                {
                    objBAL = new ClassCommonBAL();
                    objBAL.CustomerId = Convert.ToInt32(CustomerId.ToString());
                    objDAL = new ClassMasterDAL();
                    objBAL.DtDataSet = objDAL.retreiveCustomerDataByID(objBAL);
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
                            dataGridView3.Rows[n].Cells["CreditDate"].Value = Convert.ToDateTime(values[1].ToString().Trim()).ToString("yyyy/MM/dd");
                            dataGridView3.Rows[n].Cells["CreditAmount"].Value = (values[2].ToString().Trim());
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

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
                textBoxPayTotal.Text = CellSum().ToString();
                //textBoxPayment.Text = CellSum().ToString();
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
    }
}
