using easyBAL;
using easyDAL;
using System;
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
    public partial class FormEmployeeLeave : Form
    {
        BALClass objBAL = new BALClass();
        DALClass objDAL = new DALClass();

        bool loadStatus;

        public FormEmployeeLeave()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            //EmployeeName.SelectedIndex = -1;
            textBoxLeaveEffectCount.Text = "1";
            textBoxLeaveReason.Clear();
        }

        private void UpdateEmployeeLeave()
        {
            try
            {
                objBAL = new BALClass();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeName.SelectedValue.ToString());
                objBAL.LeaveDate = LeaveDate.Value;
                objBAL.LeaveCount = Convert.ToDecimal(textBoxLeaveEffectCount.Text);
                objBAL.LeaveReason = textBoxLeaveReason.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);

                objDAL = new DALClass();
                int count = objDAL.UpdateEmployeeLeave(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Employee Leave Updated Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGridAllLeaves();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGridAllLeaves()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.EmployeeID = Convert.ToInt32(EmployeeName.SelectedValue.ToString());
                ClassMasterDAL objDAL = new ClassMasterDAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllEmployeeLeaves(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    ////gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    ////gridView1.Columns["BalanceAmount"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormEmployeeLeave_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonDayEnd_Click(object sender, EventArgs e)
        {
            UpdateEmployeeLeave();
        }

        private void EmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadStatus == false)
            {
                fillGridAllLeaves();
            }
            
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
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
    }
}
