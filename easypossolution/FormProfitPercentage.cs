using easyBAL;
using easyDAL;
using easyPOSSolution.Utility;
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
    public partial class FormProfitPercentage : Form
    {
        #region Local Variables

        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        bool loadStatus;
        #endregion

        #region Constructor

        public FormProfitPercentage()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void Reset()
        {
            labelId.Text = "0";
            comboBoxItemCode.SelectedIndex = -1;
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxAmount.Text = "0";
        }

        private void fillGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassCommonBAL();
                objDAL = new ClassMasterDAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveProfitPercentage(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["ProfitPerId"].Visible = false;
                    dataGridView1.Columns["ItemCatId"].Visible = false;
                    dataGridView1.Columns["ItemsId"].Visible = false;
                    dataGridView1.Columns["ProfitPercentage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    comboBoxItemCode.DataSource = objDAL.retreiveProfitPercentage(objBAL).Tables[1];
                    comboBoxItemCode.DisplayMember = "ItemCode";
                    comboBoxItemCode.ValueMember = "ItemsId";
                    comboBoxItemCode.SelectedIndex = -1;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPercentage()
        {
            try
            {
                objBAL = new ClassCommonBAL();
                if (labelId.Text == "0")
                {
                    objBAL.ProfitPerId = 0;
                }
                else
                {
                    objBAL.ProfitPerId = Convert.ToInt32(labelId.Text);
                }
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objBAL.ItemsId = Convert.ToInt32(comboBoxItemCode.SelectedValue.ToString());
                objBAL.ItemCode = comboBoxItemCode.Text.Trim();
                objBAL.ProfitPercentage = Convert.ToDecimal(textBoxAmount.Text);
                if (labelId.Text == "0")
                {
                    objBAL.Status1 = 1;
                }
                else
                {
                    objBAL.Status1 = 0;
                }

                objDAL = new ClassMasterDAL();
                int count = objDAL.InsertProPercen(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Percentage Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void FormProfitPercentage_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                comboBoxItemCategory.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;
                fillGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Reset();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateItemCode() && ValidateItemCategory() && ValidatePercentage();
            if (isValid)
            {
                insertPercentage();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                labelId.Text = dataGridView1["ProfitPerId", e.RowIndex].Value.ToString();
                comboBoxItemCode.SelectedValue = dataGridView1["ItemsId", e.RowIndex].Value;
                comboBoxItemCategory.SelectedValue = dataGridView1["ItemCatId", e.RowIndex].Value;
                textBoxAmount.Text = dataGridView1["ProfitPercentage", e.RowIndex].Value.ToString();
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion
        

        #region Validation Methods

        private bool ValidateItemCode()
        {
            comboBoxItemCode.Text = comboBoxItemCode.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxItemCode.Text)) || (comboBoxItemCode.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Item Code.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxItemCode, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateItemCategory()
        {
            comboBoxItemCategory.Text = comboBoxItemCategory.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxItemCategory.Text)) || (comboBoxItemCategory.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Item Category;.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxItemCategory, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidatePercentage()
        {
            textBoxAmount.Text = textBoxAmount.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxAmount.Text)) || (textBoxAmount.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Enter valid Percentage.";
            }
            else if (!FieldValidationHelper.IsValidDecimal(textBoxAmount.Text))
            {
                errorCode = "Invalid Cash Amount.";
            }
            else if (Convert.ToDecimal(textBoxAmount.Text) < 0)
            {
                errorCode = "Invalid Cash Amount.";
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxAmount, message);
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
