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
    public partial class FormLoan : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        bool loadStatus;

        #endregion

        #region Constructor
        public FormLoan()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void FillLoanIdData()
        {
            if (comboBoxLoan.SelectedIndex != -1 && loadStatus == false)
            {
                try
                {
                    objBAL = new ClassCommonBAL();
                    objBAL.LoanHDId = Convert.ToInt32(comboBoxLoan.SelectedValue.ToString());
                    objDAL = new ClassMasterDAL();
                    objBAL.DtDataSet = objDAL.retreiveLoanDataByID(objBAL);
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
                            textBoxLoanTotal.Text = (values[5].ToString().Trim());
                        }
                    }
                    if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                    {
                        dataGridView2.DataSource = objBAL.DtDataSet.Tables[1];
                        dataGridView2.Columns["PaymentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (objBAL.DtDataSet.Tables[2].Rows.Count > 0)
                    {
                        List<ArrayList> newval1 = new List<ArrayList>();
                        foreach (DataRow dRow in objBAL.DtDataSet.Tables[2].Rows)
                        {
                            ArrayList values1 = new ArrayList();
                            values1.Clear();
                            foreach (object value in dRow.ItemArray)
                                values1.Add(value);
                            newval1.Add(values1);
                            textBoxPayTotal.Text = (values1[0].ToString().Trim());
                        }
                    }
                    textBoxBalance.Text = (Convert.ToDecimal(textBoxLoanTotal.Text) - Convert.ToDecimal(textBoxPayTotal.Text)).ToString("0.00");
                    //FillSelectCustomerCreditData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void insertLoanHD()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.LoanName = txtLoanName.Text;
                objBAL.LoanAmount = Convert.ToDecimal(txtloanamount.Text);
                objBAL.InterestAmount = Convert.ToDecimal(txtInterest.Text);
                objBAL.TotalAmount = Convert.ToDecimal(textBoxPayble.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objDAL = new ClassMasterDAL();

                int count = objDAL.InsertloanHD(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Loan Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLoanName.Text = "";
                    txtloanamount.Text = "0.00";
                    txtInterest.Text = "0.00";
                    textBoxPayble.Text = "0.00";
                    fillAllLoans();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertLoanDT()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.LoanHDId = Convert.ToInt32(comboBoxLoan.SelectedValue.ToString());
                objBAL.PaymentDate = dateTimePickerPayDate.Value;
                objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayAmount.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.Remarks = textBoxRemarks.Text;

                objDAL = new ClassMasterDAL();

                int count = objDAL.InsertloanDt(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Loan Payment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBoxPayAmount.Text = "0.00";
                    textBoxRemarks.Text = "";
                    FillLoanIdData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void insertLoanHD()
        //{
        //    try
        //    {
        //        objBAL = new ClassCommonBAL();
        //        objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
        //        objBAL.LoanDate = dateTimePickerPaymentDate.Value;
        //        objBAL.PaymentAmount = Convert.ToDecimal(textBoxPayment.Text);
        //        objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
        //        objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
        //        objDAL = new ClassMasterDAL();

        //        string count = objDAL.InsertCustomerCredPayHD(objBAL);
        //        textBoxHDId.Text = count.ToString();
        //        if (count != "")
        //        {
        //            insertCustomerCredit();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void Calculate()
        {
            try
            {
                if (txtloanamount.Text != "" && txtInterest.Text != "")
                {
                    textBoxPayble.Text = (Convert.ToDecimal(txtloanamount.Text) + Convert.ToDecimal(txtInterest.Text)).ToString("0.00");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void fillAllLoans()
        {
            try
            {
                loadStatus = true;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                comboBoxLoan.DataSource = objDAL.retreiveAllLoans(objBAL).Tables[0];
                comboBoxLoan.DisplayMember = "LoanName";
                comboBoxLoan.ValueMember = "LoanHDId";
                comboBoxLoan.SelectedIndex = -1;
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        


        #region Events

        private void txtloanamount_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtInterest_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            insertLoanHD();
        }

        private void FormLoan_Load(object sender, EventArgs e)
        {
            fillAllLoans();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertLoanDT();
        }

        private void comboBoxLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillLoanIdData();
        }



        #region Validation Methods



        #endregion
        
    }
}
