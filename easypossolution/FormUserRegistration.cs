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
    public partial class FormUserRegistration : Form
    {
        #region Local Variables
        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        #endregion

        #region Constructor

        public FormUserRegistration()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void loadcomport()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxPort.DataSource = objDAL.retreiveports(objBAL).Tables[0];
                comboBoxPort.DisplayMember = "Comport";
                comboBoxPort.ValueMember = "ComportId";
                comboBoxPort.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadGRNOptions()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxGRNPrint.DataSource = objDAL.retreiveGRNPrintOptions(objBAL).Tables[0];
                comboBoxGRNPrint.DisplayMember = "OptionName";
                comboBoxGRNPrint.ValueMember = "GRNPrintId";
                comboBoxGRNPrint.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadOptions()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxPrintOption.DataSource = objDAL.retreivePrintOptions(objBAL).Tables[0];
                comboBoxPrintOption.DisplayMember = "OptionName";
                comboBoxPrintOption.ValueMember = "OptionId";
                comboBoxPrintOption.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            textBoxUserId.Clear();
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            textBoxName.Clear();
            comboBoxPrintOption.SelectedIndex = 0;
            comboBoxGRNPrint.SelectedIndex = 0;
            comboBoxUserType.Text = "";
        }

        private void insertUser()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.UserName = textBoxUserName.Text.Trim();
                objBAL.Password = textBoxPassword.Text.Trim();
                objBAL.Fullname = textBoxName.Text.Trim();
                objBAL.UserType = comboBoxUserType.Text.Trim();
                objBAL.Comport = comboBoxPort.Text.Trim();
                objBAL.OptionId = Convert.ToInt32(comboBoxPrintOption.SelectedValue.ToString());
                objBAL.GRNPrintId = Convert.ToInt32(comboBoxGRNPrint.SelectedValue.ToString());
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertUser(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("User Created Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGridAllUsers();
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateUser()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.UserName = textBoxUserName.Text.Trim();
                objBAL.Password = textBoxPassword.Text.Trim();
                objBAL.Fullname = textBoxName.Text.Trim();
                objBAL.UserType = comboBoxUserType.Text.Trim();
                objBAL.UserID = Convert.ToInt32(textBoxUserId.Text);
                objBAL.Comport = comboBoxPort.Text.Trim();
                objBAL.OptionId = Convert.ToInt32(comboBoxPrintOption.SelectedValue.ToString());
                objBAL.GRNPrintId = Convert.ToInt32(comboBoxGRNPrint.SelectedValue.ToString());
                objBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateUser(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("User Updated Successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGridAllUsers();
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteUser()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                objBAL.UserID = Convert.ToInt32(textBoxUserId.Text);
                objDAL = new ClassMasterDAL();
                int count = objDAL.DeleteUser(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("User Deleted Successfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGridAllUsers();
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillGridAllUsers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllUsers(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["Password"].Visible = false;
                    dataGridView1.Columns["OptionId"].Visible = false;
                    dataGridView1.Columns["GRNPrintId"].Visible = false;
                    dataGridView1.Columns["BranchId"].Visible = false;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadBranch()
        {
            try
            {
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                comboBoxBranch.DataSource = objPODAL.retreiveBranches(objPOBAL).Tables[0];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedIndex = 0;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void btnRegister_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateUserName() && ValidatePassword() && ValidateName() && ValidateUserType();
            if (isValid)
            {
                insertUser();
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateID() && ValidateUserName() && ValidatePassword() && ValidateName() && ValidateUserType();
            if (isValid)
            {
                DialogResult result = MessageBox.Show("Do you want to Update this User?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    updateUser();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateID();
            if (isValid)
            {
                deleteUser();
            }

        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
        }

        private void FormUserRegistration_Load(object sender, EventArgs e)
        {
            fillGridAllUsers();
            loadcomport();
            loadOptions();
            loadGRNOptions();
            loadBranch();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                textBoxUserId.Text = dataGridView1["UserID", e.RowIndex].Value.ToString();
                textBoxUserName.Text = dataGridView1["UserName", e.RowIndex].Value.ToString();
                textBoxPassword.Text = dataGridView1["Password", e.RowIndex].Value.ToString();
                textBoxName.Text = dataGridView1["Fullname", e.RowIndex].Value.ToString();
                comboBoxUserType.Text = dataGridView1["UserType", e.RowIndex].Value.ToString();
                comboBoxPrintOption.SelectedValue = dataGridView1["OptionId", e.RowIndex].Value.ToString();
                comboBoxGRNPrint.SelectedValue = dataGridView1["GRNPrintId", e.RowIndex].Value.ToString();
                comboBoxBranch.SelectedValue = dataGridView1["BranchId", e.RowIndex].Value.ToString();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Validation Methods

        private bool ValidateID()
        {
            textBoxUserId.Text = textBoxUserId.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUserId.Text)) || (textBoxUserId.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select a User.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUserId, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateUserName()
        {
            textBoxUserName.Text = textBoxUserName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUserName.Text)) || (textBoxUserName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Username.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxUserName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePassword()
        {
            textBoxPassword.Text = textBoxPassword.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxPassword.Text)) || (textBoxPassword.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Password.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxPassword, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateName()
        {
            textBoxName.Text = textBoxName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxName.Text)) || (textBoxName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter Name.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxName, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateUserType()
        {
            comboBoxUserType.Text = comboBoxUserType.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxUserType.Text)) || (comboBoxUserType.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select User Type.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxUserType, message);
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

        

    }
}
