using easyBAL;
using easyDAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class EmployeePayment : Form
    {
        BALClass objBAL = new BALClass();
        DALClass objDAL = new DALClass();

        //decimal payments = 0;
        //decimal deductions = 0;

        public EmployeePayment()
        {
            InitializeComponent();
        }

        private void insertSupplierCheque()
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                try
                {
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.SupplierId = 2;
                    objBAL.POHDId = 0;
                    objBAL.ChequeBank = comboBoxBank.Text.Trim();
                    objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue.ToString());
                    objBAL.ChequeNo = textBoxChequeNo.Text.Trim();
                    objBAL.ChequeAmount = Convert.ToDecimal(NetPay.Text);
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

        private void loadPaymode()
        {
            try
            {

                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                if (objPODAL.retreivePaymentModes(objPOBAL).Tables[0].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objPODAL.retreivePaymentModes(objPOBAL).Tables[0];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 0;
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
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
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

        private void fillHolidayDeduction()
        {
            try
            {
                textBoxHolidayDeduction.Text = (Convert.ToDecimal(textBoxHolodays.Text) * Convert.ToDecimal(textBoxHolidayPerday.Text)).ToString("0.00");
            }
            catch
            {
            }
        }

        private void calcnetsalary()
        {
            try
            {
                decimal inamount = Convert.ToDecimal(Salary.Text) + Convert.ToDecimal(textBoxHourlyPay.Text) + Convert.ToDecimal(textBoxOTAmount.Text) + Convert.ToDecimal(textBoxAllowAmount.Text) + Convert.ToDecimal(textBoxOtherAllowance.Text) + Convert.ToDecimal(textBoxBonus.Text) + Convert.ToDecimal(textBoxPhoneAll.Text) + Convert.ToDecimal(textBoxTransport.Text);
                decimal outamount = Convert.ToDecimal(Advance.Text) + Convert.ToDecimal(Deduction.Text) + Convert.ToDecimal(textBoxHolidayDeduction.Text);
                decimal netamount = (inamount - outamount);
                NetPay.Text = netamount.ToString("0.00");

            }
            catch
            {
            }
        }


        private void Reset()
        {
            DateFrom.Value = DateTime.Today;
            DateTo.Value = DateTime.Today;
            EmployeeID.Text = "";
            EmployeeName.Text = "";
            Designation.Text = "";
            Salary.Text = "0";
            Advance.Text = "0";
            Deduction.Text = "0";
            PaymentDate.Value = DateTime.Today;
            comboBoxPayMode.SelectedIndex = 0;
            PaymentModeDetails.Text = "";
            NetPay.Text = "0";
            PaymentID.Text = "";
            txtEmployee.Text = "";
            textBoxTotalSales.Text = "0";
            textBoxAllowancePer.Text = "0";
            textBoxAllowAmount.Text = "0";
            textBoxOtherAllowance.Text = "0";
            textBoxBonus.Text = "0";
            textBoxPhoneAll.Text = "0";
            textBoxTransport.Text = "0";
            textBoxHolodays.Text = "0";
            textBoxHolidayPerday.Text = "0";
            textBoxHolidayDeduction.Text = "0";
            textBoxHourlyRate.Text = "0";
            textBoxHours.Text = "0";
            textBoxHourlyPay.Text = "0";
            textBoxOtRate.Text = "0";
            textBoxOTHours.Text = "0";
            textBoxOTAmount.Text = "0";
            //textBoxHourlyRate.Text = "0";
            //textBoxHourlyRate.Text = "0";

            fillGridAllEmployee();
            Save.Enabled = true;
            Delete.Enabled = false;
            Update_Record.Enabled = false;
            btnSlip.Enabled = false;
        }

        private void fillGridAllEmployee()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new BALClass();
                objDAL = new DALClass();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllEmployees(objBAL);
                if (objBAL.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    DataGridView1.DataSource = objBAL.DtDataSet.Tables[2];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGridAllEmployeeByName()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new BALClass();
                objBAL.EmployeeName = txtEmployee.Text.Trim();
                objDAL = new DALClass();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveEmployeeByName(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    DataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillAdvance()
        {
            try
            {
                Advance.Text = "0.00";
                textBoxHours.Text = "0.00";
                textBoxOTHours.Text = "0.00";
                objBAL = new BALClass();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeID.Text);
                objBAL.Date1 = DateFrom.Value;
                objBAL.Date2 = DateTo.Value;
                objDAL = new DALClass();
                objBAL.DtDataSet = objDAL.retreiveAdvance(objBAL);

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
                        Advance.Text = (values[0].ToString());
                        textBoxHours.Text = (values[1].ToString());
                        textBoxOTHours.Text = (values[2].ToString());
                    }
                }
                if (objBAL.DtDataSet.Tables[0].Rows.Count == 0)
                {
                    Advance.Text = "0";
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
                        textBoxTotalSales.Text = (values[0].ToString());
                    }
                }
                if (objBAL.DtDataSet.Tables[1].Rows.Count == 0)
                {
                    textBoxTotalSales.Text = "0";
                }
                if (objBAL.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[2].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        textBoxHolodays.Text = (values[0].ToString());
                        textBoxHolidayPerday.Text = (values[1].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSalary()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.DateFrom = DateFrom.Value;
                objBAL.DateTo = DateTo.Value;
                objBAL.EmployeeID = Convert.ToInt32(EmployeeID.Text.Trim());
                objBAL.Salary = Convert.ToDecimal(Salary.Text.Trim());
                objBAL.HourlyRate = Convert.ToDecimal(textBoxHourlyRate.Text);
                objBAL.WorkingHours = Convert.ToDecimal(textBoxHours.Text);
                objBAL.WorkingHourPayment = Convert.ToDecimal(textBoxHourlyPay.Text);
                objBAL.OTRate = Convert.ToDecimal(textBoxOtRate.Text);
                objBAL.OTHours = Convert.ToDecimal(textBoxOTHours.Text);
                objBAL.OTPayment = Convert.ToDecimal(textBoxOTAmount.Text);
                objBAL.SalesAllowance = Convert.ToDecimal(textBoxAllowAmount.Text);
                objBAL.OtherAllowance = Convert.ToDecimal(textBoxOtherAllowance.Text);
                objBAL.Bonus = Convert.ToDecimal(textBoxBonus.Text);
                objBAL.PhoneAllowance = Convert.ToDecimal(textBoxPhoneAll.Text);
                objBAL.TransportAllowance = Convert.ToDecimal(textBoxTransport.Text);
                objBAL.Advance = Convert.ToDecimal(Advance.Text);
                objBAL.Deduction = Convert.ToDecimal(Deduction.Text);
                objBAL.Holidays = Convert.ToDecimal(textBoxHolodays.Text);
                objBAL.HolidayDeduction = Convert.ToDecimal(textBoxHolidayDeduction.Text);
                objBAL.PaymentDate = PaymentDate.Value;
                objBAL.ModeOfPayment = comboBoxPayMode.Text.Trim();
                objBAL.PaymentModeDetails = PaymentModeDetails.Text.Trim();    
                objBAL.NetPay = Convert.ToDecimal(NetPay.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                if (comboBoxBank.SelectedIndex == -1)
                {
                    comboBoxBank.SelectedValue = 0;
                }
                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);

                objDAL = new DALClass();
                int count = objDAL.InsertEmployeeSalary(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Salary Payment Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSalary()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.PaymentID = Convert.ToInt32(PaymentID.Text);
                objBAL.DateFrom = DateFrom.Value;
                objBAL.DateTo = DateTo.Value;
                objBAL.EmployeeID = Convert.ToInt32(EmployeeID.Text.Trim());
                objBAL.Salary = Convert.ToDecimal(Salary.Text.Trim());
                objBAL.HourlyRate = Convert.ToDecimal(textBoxHourlyRate.Text);
                objBAL.WorkingHours = Convert.ToDecimal(textBoxHours.Text);
                objBAL.WorkingHourPayment = Convert.ToDecimal(textBoxHourlyPay.Text);
                objBAL.OTRate = Convert.ToDecimal(textBoxOtRate.Text);
                objBAL.OTHours = Convert.ToDecimal(textBoxOTHours.Text);
                objBAL.OTPayment = Convert.ToDecimal(textBoxOTAmount.Text);
                objBAL.SalesAllowance = Convert.ToDecimal(textBoxAllowAmount.Text);
                objBAL.OtherAllowance = Convert.ToDecimal(textBoxOtherAllowance.Text);
                objBAL.Bonus = Convert.ToDecimal(textBoxBonus.Text);
                objBAL.PhoneAllowance = Convert.ToDecimal(textBoxPhoneAll.Text);
                objBAL.TransportAllowance = Convert.ToDecimal(textBoxTransport.Text);
                objBAL.Advance = Convert.ToDecimal(Advance.Text);
                objBAL.Deduction = Convert.ToDecimal(Deduction.Text);
                objBAL.Holidays = Convert.ToDecimal(textBoxHolodays.Text);
                objBAL.HolidayDeduction = Convert.ToDecimal(textBoxHolidayDeduction.Text);
                objBAL.PaymentDate = PaymentDate.Value;
                objBAL.ModeOfPayment = comboBoxPayMode.Text.Trim();
                objBAL.PaymentModeDetails = PaymentModeDetails.Text.Trim();
                objBAL.NetPay = Convert.ToDecimal(NetPay.Text);
                objBAL.PayModeId = Convert.ToInt32(comboBoxPayMode.SelectedValue.ToString());
                if (comboBoxBank.SelectedIndex == -1)
                {
                    comboBoxBank.SelectedValue = 0;
                }
                objBAL.BankId = Convert.ToInt32(comboBoxBank.SelectedValue);

                objDAL = new DALClass();
                int count = objDAL.UpdateEmployeeSalary(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Salary Payment Updated Susccessfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteSalary()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.PaymentID = Convert.ToInt32(PaymentID.Text);

                objDAL = new DALClass();
                int count = objDAL.DeleteEmployeeSalary(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Salary Payment Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void EmployeePayment_Load(object sender, EventArgs e)
        {
            fillGridAllEmployee();
            loadPaymode();
            loadBank();
        }

        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            fillGridAllEmployeeByName();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                EmployeeID.Text = dr.Cells[0].Value.ToString();
                EmployeeName.Text = dr.Cells[1].Value.ToString();
                Designation.Text = dr.Cells[2].Value.ToString();
                Salary.Text = dr.Cells[3].Value.ToString();
                textBoxHourlyRate.Text = dr.Cells[4].Value.ToString();
                textBoxOtRate.Text = dr.Cells[5].Value.ToString();
                fillAdvance();
                calcnetsalary();
                //NetPay.Text = ((Convert.ToDecimal(Salary.Text)) - ((Convert.ToDecimal(Advance.Text) + (Convert.ToDecimal(Deduction.Text))))).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Deduction_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    NetPay.Text = ((Convert.ToDecimal(Salary.Text) - ((Convert.ToDecimal(Advance.Text) + Convert.ToDecimal(Deduction.Text))))).ToString("0.00");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (EmployeeID.Text == "")
            {
                MessageBox.Show("Please Select employee.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmployeeID.Focus();
                return;
            }
            else
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    insertSupplierCheque();
                }
                SaveSalary();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EmployeePaymentRecord frm = new EmployeePaymentRecord();
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void Update_Record_Click(object sender, EventArgs e)
        {
            if (PaymentID.Text == "")
            {
                MessageBox.Show("Please Select a Payment.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PaymentID.Focus();
                return;
            }
            else
            {
                UpdateSalary();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (PaymentID.Text == "")
            {
                MessageBox.Show("Please Select a Payment.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PaymentID.Focus();
                return;
            }
            else
            {
                DeleteSalary();
            }
        }

        private void btnSlip_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //SalarySlip frm = new SalarySlip();
            //rptSalarySlip rpt = new rptSalarySlip();
            ////The report you created.
            //MySqlConnection myConnection = default(MySqlConnection);
            //MySqlCommand MyCommand = new MySqlCommand();
            //MySqlDataAdapter myDA = new MySqlDataAdapter();
            //DataSetReport myDS = new DataSetReport();
            ////The DataSet you created.

            //myConnection = new MySqlConnection("server=localhost;user=root;database=fashionboys;port=3306;password=root;");
            //MyCommand.Connection = myConnection;
            //MyCommand.CommandText = "SELECT employeepayment.PaymentID, employeeregistration.EmployeeID, employeeregistration.EmployeeName, employeepayment.DateFrom, employeepayment.DateTo, employeepayment.PaymentDate, employeeregistration.Designation, employeepayment.ModeOfPayment, employeeregistration.Salary, employeepayment.Advance, employeepayment.Deduction, employeepayment.NetPay FROM employeepayment INNER JOIN employeeregistration ON employeepayment.EmployeeID = employeeregistration.EmployeeID WHERE (employeepayment.PaymentID = '" + PaymentID.Text.Trim() + "')";

            //MyCommand.CommandType = CommandType.Text;
            //myDA.SelectCommand = MyCommand;
            //myDA.Fill(myDS, "EmployeeSalarySlip");
            //rpt.SetDataSource(myDS);

            //frm.CrystalReportViewer1.ReportSource = rpt;
            //frm.Show();
            //Cursor = Cursors.Default;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SalarySlip REPORT = new SalarySlip();
                REPORT.Show();
                CrystalReportA4EmpSalary rpt = new CrystalReportA4EmpSalary();
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.PaymentID = Convert.ToInt32(PaymentID.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveEmpSalSlipData(objPOBAL);
                rpt.SetDataSource(objPOBAL.DtDataSet);
                REPORT.CrystalReportViewer1.ReportSource = rpt;
                REPORT.CrystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxAllowancePer_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (Convert.ToDecimal(textBoxAllowancePer.Text) > 0)
                {
                    decimal SalesAll = 0;

                    SalesAll = Convert.ToDecimal((Convert.ToDecimal(textBoxTotalSales.Text)) * (Convert.ToDecimal(textBoxAllowancePer.Text)/100));
                    textBoxAllowAmount.Text = SalesAll.ToString("0.00");
                    //fillNetPay();
                }

            }
            catch
            {
            }
        }

        private void fillNetPay()
        {
            try
            {
                //if (Convert.ToDecimal(textBoxAllowancePer.Text) > 0)
                //{
                    NetPay.Text = (((Convert.ToDecimal(Salary.Text) + Convert.ToDecimal(textBoxAllowAmount.Text) + Convert.ToDecimal(textBoxOtherAllowance.Text)) - ((Convert.ToDecimal(Advance.Text) + Convert.ToDecimal(Deduction.Text))))).ToString("0.00");
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxOtherAllowance_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (Convert.ToDecimal(textBoxOtherAllowance.Text) > 0)
            //    {
            //        fillNetPay();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void textBoxHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxHourlyPay.Text = (Convert.ToDecimal(textBoxHours.Text) * Convert.ToDecimal(textBoxHourlyRate.Text)).ToString();
            }
            catch
            {
            }
        }

        private void textBoxOTHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxOTAmount.Text = (Convert.ToDecimal(textBoxOTHours.Text) * Convert.ToDecimal(textBoxOtRate.Text)).ToString();
            }
            catch
            {
            }
        }

        private void textBoxHourlyPay_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void textBoxOTAmount_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void textBoxAllowAmount_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void textBoxOtherAllowance_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void Advance_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void Deduction_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void textBoxHolidayPerday_TextChanged(object sender, EventArgs e)
        {
            fillHolidayDeduction();
        }

        private void textBoxHolodays_TextChanged(object sender, EventArgs e)
        {
            fillHolidayDeduction();
        }

        private void textBoxBonus_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void textBoxPhoneAll_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void textBoxTransport_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void textBoxHolidayDeduction_TextChanged(object sender, EventArgs e)
        {
            calcnetsalary();
        }

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                label31.Visible = true;
                textBoxChequeNo.Visible = true;
                label4.Visible = true;
                comboBoxBank.Visible = true;
                label33.Visible = true;
                dateTimePickerChqExpDate.Visible = true;
            }
            else if (comboBoxPayMode.Text == "Bank Transfer")
            {
                //label10.Visible = true;
                //textBoxChequeNo.Visible = true;
                label33.Visible = true;
                comboBoxBank.Visible = true;
                //label7.Visible = true;
                //dateTimePickerChqExpDate.Visible = true;
            }

            else
            {
                label31.Visible = false;
                textBoxChequeNo.Visible = false;
                label4.Visible = false;
                comboBoxBank.Visible = false;
                label33.Visible = false;
                dateTimePickerChqExpDate.Visible = false;
            }
        }

        private void textBoxAllowancePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBoxAllowancePer.Text) > 0)
                {
                    decimal SalesAll = 0;

                    SalesAll = Convert.ToDecimal((Convert.ToDecimal(textBoxTotalSales.Text)) * (Convert.ToDecimal(textBoxAllowancePer.Text) / 100));
                    textBoxAllowAmount.Text = SalesAll.ToString("0.00");
                    //fillNetPay();
                }

            }
            catch
            {
            }
        }
    }
}
