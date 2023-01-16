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
    public partial class EmployeeRecords : Form
    {
        BALClass objBAL = new BALClass();
        DALClass objDAL = new DALClass();

        public EmployeeRegistration frm { set; get; }
        bool loadStatus;
        public EmployeeRecords()
        {
            InitializeComponent();
        }

        private void fillGridAllEmployeeByDOB()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new BALClass();
                objBAL.DOB = dateTimePickerDOB.Value;
                objDAL = new DALClass();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveEmployeeByDOB(objBAL);
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

        private void fillGridAllEmployee()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new BALClass();
                objDAL = new DALClass();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllEmployees(objBAL);
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

        private void fillGridAllEmployeeByID()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new BALClass();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeName.SelectedValue.ToString());
                objDAL = new DALClass();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveEmployeeByID(objBAL);
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

        private void EmployeeRecords_Load(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            fillGridAllEmployee();
        }

        private void EmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false)
            {
                fillGridAllEmployeeByID();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataGridView1.DataSource = null;
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                //EmployeeRegistration frm = new EmployeeRegistration();
                //frm.Show();
                this.Close();
                frm.EmployeeID.Text = dr.Cells[0].Value.ToString();
                frm.EmployeeName.Text = dr.Cells[1].Value.ToString();
                frm.Address.Text = dr.Cells[2].Value.ToString();
                frm.MobileNo.Text = dr.Cells[3].Value.ToString();
                frm.Email.Text = dr.Cells[4].Value.ToString();
                frm.BloodGroup.Text = dr.Cells[5].Value.ToString();
                frm.Designation.Text = dr.Cells[6].Value.ToString();
                frm.DateOfJoining.Text = Convert.ToDateTime(dr.Cells[7].Value).ToString("yyyy/MM/dd");
                frm.Salary.Text = dr.Cells[8].Value.ToString();
                frm.BasicWorkingTime.Text = dr.Cells[9].Value.ToString();
                frm.textBoxHourlyRate.Text = dr.Cells[10].Value.ToString();
                frm.textBoxOTRate.Text = dr.Cells[11].Value.ToString();
                frm.textBoxLeaveDeduction.Text = dr.Cells[12].Value.ToString();
                frm.dateTimePickerDOB.Text = Convert.ToDateTime(dr.Cells[13].Value).ToString("yyyy/MM/dd");

                frm.Update_Record.Enabled = true;
                frm.Delete.Enabled = true;
                frm.Save.Enabled = false;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception s)
            {
                MessageBox.Show(s.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillGridAllEmployeeByDOB();
        }
    }
}
