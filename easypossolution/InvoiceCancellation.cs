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
    public partial class InvoiceCancellation : Form
    {
        #region Local Variables

        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        #endregion

        #region Constructor

        public InvoiceCancellation()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void Reset()
        {
            textBoxSOID.Clear();
            dateTimePickerSalesDate.Value = DateTime.Today;
            dataGridView1.DataSource = null;
        }

        private void fillBillData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.BillNo = Convert.ToInt32(textBoxBillNo.Text);
                objDAL = new ClassSODAL();
                objBAL.DtDataSet = objDAL.retreiveBillData(objBAL);
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
                        textBoxSOID.Text = (values[0].ToString().Trim());
                        dateTimePickerSalesDate.Value = Convert.ToDateTime(values[1].ToString());
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillSODtRec()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.BillNo = Convert.ToInt32(textBoxBillNo.Text);
                objDAL = new ClassSODAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveBillData(objBAL);
                if (objBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[1];
                    dataGridView1.Columns["BillNo"].Visible = false;
                    dataGridView1.Columns["SODTId"].Visible = false;
                    dataGridView1.Columns["SOHDId"].Visible = false;
                    dataGridView1.Columns["ItemsId"].Visible = false;
                    dataGridView1.Columns["ItemCatId"].Visible = false;
                    dataGridView1.Columns["SalesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["NetAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView1.Columns["NetAmount"].DefaultCellStyle.Format = "0.00";
                    dataGridView1.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertCamcellation()
        {
            try
            {
                objBAL = new ClassSOBAL();
                objBAL.SOHDId = Convert.ToInt32(textBoxBillNo.Text);
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.RtnReason = textBoxRemark.Text;
                objDAL = new ClassSODAL();
                int count = objDAL.InsertCancellation(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Invoice Cancellation Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxRemark.Clear();
                    fillSODtRec();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void textBoxBillNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBillNo.Text != "")
            {
                Reset();
                fillBillData();
                fillSODtRec();
            }
            else if (textBoxBillNo.Text == "")
            {
                Reset();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            textBoxBillNo.Clear();
            Reset();
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

        private void buttonCanellation_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure, Do you want to cancell this invoice?", "Invoice Cancellation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                insertCamcellation();
            }
        }


        #region Events



        #endregion



        #region Validation Methods



        #endregion

    }
}
