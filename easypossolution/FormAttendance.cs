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
    public partial class FormAttendance : Form
    {
        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        public FormAttendance()
        {
            InitializeComponent();
        }

        private void fillGridAllCustomers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllAttendanceCustomers(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["CustomerId"].Visible = false;
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

        private void FormAttendance_Load(object sender, EventArgs e)
        {
            fillGridAllCustomers();
        }

        private void buttonDayEnd_Click(object sender, EventArgs e)
        {
            updateStatus();
        }

        private void updateStatus()
        {
            bool save = false;
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, "SelectEmp")) == true)
                    {
                        objBAL = new ClassCommonBAL();
                        objBAL.AttendanceDate = dateTimePickerAttDate.Value;
                        objBAL.EmployeeID = Convert.ToInt32(gridView1.GetRowCellValue(i, "EmployeeID").ToString());
                        objBAL.AttendanceStatus = Convert.ToBoolean(gridView1.GetRowCellValue(i, "SelectEmp"));
                        objBAL.AttendanceType = comboBoxType.Text;
                        objBAL.DayType = comboBoxDayType.Text;
                        objDAL = new ClassMasterDAL();
                        int count = objDAL.UpateAttendance(objBAL);
                        if (count != 0)
                        {
                            save = true;
                        }
                    }


                }
                if (save == true)
                {
                    MessageBox.Show("Updated Successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormViewAttendance frm = new FormViewAttendance();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormViewAttendance");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormViewAttendance"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }
    }
}
