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
    public partial class EmployeeAdvance : Form
    {
        BALClass objBAL = new BALClass();
        DALClass objDAL = new DALClass();
        public EmployeeAdvance()
        {
            InitializeComponent();
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
                    DataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
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

        private void reset()
        {
            EmployeeID.Text = "";
            EmployeeName.Text = "";
            Amount.Text = "";
            txtEmployee.Text = "";
            EntryDate.Value = DateTime.Today;
            fillGridAllEmployee();
            Save.Enabled = true;
        }

        private void SaveAdvance()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeID.Text.Trim());
                objBAL.Amount = Convert.ToInt32(Amount.Text.Trim());
                objBAL.AdvanceDate = EntryDate.Value;
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);

                objDAL = new DALClass();
                int count = objDAL.InsertAdvance(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Advance Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            fillGridAllEmployeeByName();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //------ FILL RELATED ROW DATA TO THE CONTROLS ------//
            DataGridViewRow dr = DataGridView1.SelectedRows[0];
            EmployeeID.Text = dr.Cells[0].Value.ToString();
            EmployeeName.Text = dr.Cells[1].Value.ToString();
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
                SaveAdvance();
            }
        }

        private void EmployeeAdvance_Load(object sender, EventArgs e)
        {
            fillGridAllEmployee();
        }
    }
}
