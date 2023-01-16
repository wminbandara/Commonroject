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
    public partial class FrmSalesRecord : Form
    {
        #region Local Variables

        ClassSOBAL objBAL = new ClassSOBAL();
        ClassSODAL objDAL = new ClassSODAL();

        public FormSalesReturn frm { set; get; }

        #endregion

        #region Constructor

        public FrmSalesRecord()
        {
            InitializeComponent();
        }

        #endregion        

        #region Methods

        private void fillSODataDateRange()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassSODAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveSODataDateRange(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView1.Columns["CustomerId"].Visible = false;
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


        private void fillTotal()
        {
            decimal total = 0;
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        total = decimal.Parse(dataGridView1["NetAmount", i].Value.ToString().Trim()) + total;
                    }
                    textBoxTotalQty.Text = total.ToString("0.00");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void fillSODataCustomer()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue.ToString());
                objDAL = new ClassSODAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveSODataCustomer(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView2.Columns["CustomerId"].Visible = false;
                    dataGridView2.Columns["ItemCatId"].Visible = false;
                    dataGridView2.Columns["SalesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["NetAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.Columns["NetAmount"].DefaultCellStyle.Format = "0.00";
                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void fillTotal1()
        {
            decimal total = 0;
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        total = decimal.Parse(dataGridView2["NetAmount", i].Value.ToString().Trim()) + total;
                    }
                    textBoxTotalQty1.Text = total.ToString("0.00");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillSODataCategory()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassSOBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objDAL = new ClassSODAL();
                dataGridView3.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveSODataCategory(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView3.DataSource = objBAL.DtDataSet.Tables[0];
                    dataGridView3.Columns["CustomerId"].Visible = false;
                    dataGridView3.Columns["ItemCatId"].Visible = false;
                    dataGridView3.Columns["SalesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView3.Columns["NetAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView3.Columns["NetAmount"].DefaultCellStyle.Format = "0.00";
                    dataGridView3.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void fillTotal2()
        {
            decimal total = 0;
            try
            {
                if (dataGridView3.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        total = decimal.Parse(dataGridView3["NetAmount", i].Value.ToString().Trim()) + total;
                    }
                    textBoxTotalQty2.Text = total.ToString("0.00");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void FrmSalesRecord_Load(object sender, EventArgs e)
        {
            try
            {
                objBAL = new ClassSOBAL();
                objDAL = new ClassSODAL();
                comboBoxCustomer.DataSource = objDAL.retreiveAllCustomers(objBAL).Tables[0];
                comboBoxCustomer.DisplayMember = "CustomerName";
                comboBoxCustomer.ValueMember = "CustomerId";
                comboBoxCustomer.SelectedIndex = -1;

                comboBoxItemCategory.DataSource = objDAL.retreiveSOLoadingData(objBAL).Tables[2];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView3.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView3.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        #endregion

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBoxTotalQty.Clear();
            fillSODataDateRange();
            fillTotal();
        }

        private void ButtonReset1_Click(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today;
            dataGridView1.DataSource = null;
            textBoxTotalQty.Clear();
        }

        private void buttonGetData2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            textBoxTotalQty1.Clear();
            fillSODataCustomer();
            fillTotal1();
        }

        private void buttonReset2_Click(object sender, EventArgs e)
        {
            comboBoxCustomer.SelectedValue = -1;
            dataGridView2.DataSource = null;
            textBoxTotalQty1.Clear();
        }

        private void buttonGetdata3_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            textBoxTotalQty2.Clear();
            fillSODataCategory();
            fillTotal2();
        }

        private void buttonReset3_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            comboBoxItemCategory.SelectedIndex = -1;
            textBoxTotalQty2.Clear();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            frm.Reset();
            frm.textBoxBillNo.Text = dr.Cells["BillNo"].Value.ToString();
            this.Close();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            frm.Reset();
            frm.textBoxBillNo.Text = dr.Cells["BillNo"].Value.ToString();
            this.Close();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView3.SelectedRows[0];
            frm.Reset();
            frm.textBoxBillNo.Text = dr.Cells["BillNo"].Value.ToString();
            this.Close();
        }

        #region Validation Methods

        #endregion

    }
}
