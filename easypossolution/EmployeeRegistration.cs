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
    public partial class EmployeeRegistration : Form
    {
        BALClass objBAL = new BALClass();
        DALClass objDAL = new DALClass();

        public EmployeeRegistration()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            EmployeeID.Clear();
            EmployeeName.Clear();
            Address.Clear();
            MobileNo.Clear();
            Email.Clear();
            Designation.SelectedIndex = -1;
            DateOfJoining.Value = DateTime.Today;
            Salary.Text = "0.00";
            BloodGroup.Text = "";
            BasicWorkingTime.Clear();
            textBoxHourlyRate.Text = "0.00";
            textBoxOTRate.Text = "0.00";
            textBoxLeaveDeduction.Text = "0.00";
            dateTimePickerDOB.Value = DateTime.Today;
            Update_Record.Enabled = false;
            Delete.Enabled = false;
            Save.Enabled = true;
            EmployeeName.Focus();
        }

        private void RegisterEmployee()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.EmployeeName = EmployeeName.Text.Trim();
                objBAL.Address = Address.Text.Trim();
                objBAL.MobileNo = MobileNo.Text.Trim();
                objBAL.Email = Email.Text.Trim();
                objBAL.Bloodgroup = BloodGroup.Text.Trim();
                objBAL.DSId = Convert.ToInt32 (Designation.SelectedValue.ToString());
                objBAL.DateOfJoining = DateOfJoining.Value;
                objBAL.Salary = Convert.ToDecimal(Salary.Text);
                objBAL.BasicWorkingTime = BasicWorkingTime.Text.Trim();
                objBAL.HourlyRate = Convert.ToDecimal(textBoxHourlyRate.Text);
                objBAL.OTRate = Convert.ToDecimal(textBoxOTRate.Text);
                objBAL.LeaveDeductionPerDay = Convert.ToDecimal(textBoxLeaveDeduction.Text);
                objBAL.DOB = dateTimePickerDOB.Value;

                objDAL = new DALClass();
                int count = objDAL.InsertEmployee(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Registered Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateEmployee()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeID.Text);
                objBAL.EmployeeName = EmployeeName.Text.Trim();
                objBAL.Address = Address.Text.Trim();
                objBAL.MobileNo = MobileNo.Text.Trim();
                objBAL.Email = Email.Text.Trim();
                objBAL.Bloodgroup = BloodGroup.Text.Trim();
                objBAL.DSId = Convert.ToInt32(Designation.SelectedValue.ToString());
                objBAL.DateOfJoining = DateOfJoining.Value;
                objBAL.Salary = Convert.ToDecimal(Salary.Text);
                objBAL.BasicWorkingTime = BasicWorkingTime.Text.Trim();
                objBAL.HourlyRate = Convert.ToDecimal(textBoxHourlyRate.Text);
                objBAL.OTRate = Convert.ToDecimal(textBoxOTRate.Text);
                objBAL.LeaveDeductionPerDay = Convert.ToDecimal(textBoxLeaveDeduction.Text);
                objBAL.DOB = dateTimePickerDOB.Value;

                objDAL = new DALClass();
                int count = objDAL.UpdateEmployee(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Details Updated Susccessfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteEmployee()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeID.Text);
                objDAL = new DALClass();
                int count = objDAL.DeleteEmployee(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmployeeName.Text == "")
                {
                    MessageBox.Show("Please enter employee name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmployeeName.Focus();
                    return;
                }
                else
                {
                    RegisterEmployee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Update_Record_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmployeeID.Text == "")
                {
                    MessageBox.Show("Please Select employee to Update", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmployeeID.Focus();
                    return;
                }
                else
                {
                    UpdateEmployee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmployeeID.Text == "")
                {
                    MessageBox.Show("Please Select employee to Delete", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmployeeID.Focus();
                    return;
                }
                else
                {
                    DeleteEmployee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EmployeeRecords frm = new EmployeeRecords();
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void EmployeeRegistration_Load(object sender, EventArgs e)
        {
            loadDesignation();
        }

        private void loadDesignation()
        {
            objBAL = new BALClass();
            objDAL = new DALClass();
            Designation.DataSource = objDAL.retreiveDesignations(objBAL).Tables[0];
            Designation.DisplayMember = "Designation";
            Designation.ValueMember = "DSId";
            Designation.SelectedIndex = -1;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateDesignation();
            if (isValid)
            {
                insertDesignation();
            }
        }

        private void insertDesignation()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.Designation = textBoxNewDesignation.Text.Trim();

                objDAL = new DALClass();
                int count = objDAL.InsertDesignation(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Designation Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDesignation();
                    textBoxNewDesignation.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateDesignation()
        {
            textBoxNewDesignation.Text = textBoxNewDesignation.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxNewDesignation.Text)) || (textBoxNewDesignation.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Designation.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxNewDesignation, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BasicWorkingTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EmployeeName.Select();
            }
        }

        private void EmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Address.Select();
            }
        }

        private void Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MobileNo.Select();
            }
        }

        private void MobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Email.Select();
            }
        }

        private void Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BloodGroup.Select();
            }
        }

        private void BloodGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateOfJoining.Select();
            }
        }

        private void DateOfJoining_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Designation.Select();
            }
        }

        private void Designation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxHourlyRate.Select();
            }
        }

        private void textBoxHourlyRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxOTRate.Select();
            }
        }

        private void textBoxOTRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Salary.Select();
            }
        }

        private void Salary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save.Select();
            }
        }
    }
}
