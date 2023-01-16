using easyBAL;
using easyDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class EmployeePaymentRecord : Form
    {
        BALClass objBAL = new BALClass();
        DALClass objDAL = new DALClass();
        public EmployeePayment frm { set; get; }

        bool loadStatus;

        public EmployeePaymentRecord()
        {
            InitializeComponent();
        }

        private void fillGridEmployeeSalaryByID()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new BALClass();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeName.SelectedValue.ToString());
                objDAL = new DALClass();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveEmployeeByID(objBAL);
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

        private void fillGridEmployeeSalaryByDate()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new BALClass();
                objBAL.Date1 = DateFrom.Value;
                objBAL.Date2 = DateTo.Value;
                objDAL = new DALClass();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveEmployeeSalaryByDate(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    DataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmployeePaymentRecord_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                objBAL = new BALClass();
                objDAL = new DALClass();

                EmployeeName.DataSource = objDAL.retreiveEmployeeName(objBAL).Tables[0];
                EmployeeName.DisplayMember = "EmployeeName";
                EmployeeName.ValueMember = "EmployeeID";
                EmployeeName.SelectedIndex = -1;
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataGridView1.DataSource = null;
        }

        private void EmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false)
            {
                fillGridEmployeeSalaryByID();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fillGridEmployeeSalaryByDate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridView2.DataSource = null;
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewRow dr = DataGridView1.SelectedRows[0];
            //EmployeePayment frm = new EmployeePayment();
            //frm.Show();
            //this.Hide();
            frm.PaymentID.Text = dr.Cells[0].Value.ToString();
            frm.EmployeeID.Text = dr.Cells[1].Value.ToString();
            frm.EmployeeName.Text = dr.Cells[2].Value.ToString();
            frm.Designation.Text = dr.Cells[3].Value.ToString();
            frm.Salary.Text = dr.Cells[4].Value.ToString();
            frm.Advance.Text = dr.Cells[5].Value.ToString();
            frm.Deduction.Text = dr.Cells[6].Value.ToString();
            frm.PaymentDate.Text = Convert.ToDateTime(dr.Cells[7].Value).ToString("yyyy/MM/dd");
            frm.comboBoxPayMode.Text = dr.Cells[8].Value.ToString();
            frm.PaymentModeDetails.Text = dr.Cells[9].Value.ToString();
            frm.textBoxAllowAmount.Text = dr.Cells[10].Value.ToString();
            frm.textBoxOtherAllowance.Text = dr.Cells[11].Value.ToString();
            frm.NetPay.Text = dr.Cells[12].Value.ToString();

            frm.textBoxHourlyRate.Text = dr.Cells[13].Value.ToString();
            frm.textBoxHours.Text = dr.Cells[14].Value.ToString();
            frm.textBoxHourlyPay.Text = dr.Cells[15].Value.ToString();
            frm.textBoxOtRate.Text = dr.Cells[16].Value.ToString();
            frm.textBoxOTHours.Text = dr.Cells[17].Value.ToString();
            frm.textBoxOTAmount.Text = dr.Cells[18].Value.ToString();
            frm.textBoxBonus.Text = dr.Cells[19].Value.ToString();
            frm.textBoxPhoneAll.Text = dr.Cells[20].Value.ToString();
            frm.textBoxTransport.Text = dr.Cells[21].Value.ToString();
            frm.textBoxHolodays.Text = dr.Cells[22].Value.ToString();
            frm.textBoxHolidayDeduction.Text = dr.Cells[23].Value.ToString();

            frm.Update_Record.Enabled = true;
            frm.Delete.Enabled = true;
            frm.Save.Enabled = false;
            frm.btnSlip.Enabled = true;
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void DataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewRow dr = DataGridView2.SelectedRows[0];
            //EmployeePayment frm = new EmployeePayment();
            //frm.Show();
            //this.Hide();
            frm.PaymentID.Text = dr.Cells[0].Value.ToString();
            frm.EmployeeID.Text = dr.Cells[1].Value.ToString();
            frm.EmployeeName.Text = dr.Cells[2].Value.ToString();
            frm.Designation.Text = dr.Cells[3].Value.ToString();
            frm.Salary.Text = dr.Cells[4].Value.ToString();
            frm.Advance.Text = dr.Cells[5].Value.ToString();
            frm.Deduction.Text = dr.Cells[6].Value.ToString();
            frm.PaymentDate.Text = Convert.ToDateTime(dr.Cells[7].Value).ToString("yyyy/MM/dd");
            frm.comboBoxPayMode.Text = dr.Cells[8].Value.ToString();
            frm.PaymentModeDetails.Text = dr.Cells[9].Value.ToString();
            frm.textBoxAllowAmount.Text = dr.Cells[10].Value.ToString();
            frm.textBoxOtherAllowance.Text = dr.Cells[11].Value.ToString();
            frm.NetPay.Text = dr.Cells[12].Value.ToString();
            frm.textBoxHourlyRate.Text = dr.Cells[13].Value.ToString();
            frm.textBoxHours.Text = dr.Cells[14].Value.ToString();
            frm.textBoxHourlyPay.Text = dr.Cells[15].Value.ToString();
            frm.textBoxOtRate.Text = dr.Cells[16].Value.ToString();
            frm.textBoxOTHours.Text = dr.Cells[17].Value.ToString();
            frm.textBoxOTAmount.Text = dr.Cells[18].Value.ToString();
            frm.textBoxBonus.Text = dr.Cells[19].Value.ToString();
            frm.textBoxPhoneAll.Text = dr.Cells[20].Value.ToString();
            frm.textBoxTransport.Text = dr.Cells[21].Value.ToString();
            frm.textBoxHolodays.Text = dr.Cells[22].Value.ToString();
            frm.textBoxHolidayDeduction.Text = dr.Cells[23].Value.ToString();
            frm.Update_Record.Enabled = true;
            frm.Delete.Enabled = true;
            frm.Save.Enabled = false;
            frm.btnSlip.Enabled = true;
            this.Close();
            Cursor.Current = Cursors.Default;
        }
    }
}
