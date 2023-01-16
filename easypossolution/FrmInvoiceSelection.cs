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
    public partial class FrmInvoiceSelection : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        #endregion

        #region Constructor

        public FrmInvoiceSelection()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void fillAllOptions()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFromDate.Value;
                objBAL.date2 = dateTimePickerToDate.Value;
                objDAL = new ClassPODAL();
                dataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreiveAllOptions(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objBAL.DtDataSet.Tables[0];
                    //dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns["InvoiceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    findTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void findTotal()
        {
            decimal total = 0;
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView1["TaxStatus", i].Value) == true)
                        {
                            total = decimal.Parse(dataGridView1["GrossAmount", i].Value.ToString().Trim()) + total;
                        }
                    }
                    textBoxTotal.Text = total.ToString("0.00");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateOptionStatus()
        {
            bool permissionStatus = false;
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    objBAL = new ClassPOBAL();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        objBAL.SOHDId = Convert.ToInt32(dataGridView1["InvoiceNo", i].Value);
                        objBAL.TaxStatus = Convert.ToBoolean(dataGridView1["TaxStatus", i].Value);
                            objDAL = new ClassPODAL();
                            int count = objDAL.UpdateSOHDTax(objBAL);
                            if (count != 0)
                            {
                                permissionStatus = true;
                            }
                    }
                    if (permissionStatus == true)
                    {
                        MessageBox.Show("Successfully Saved.", "Save Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillAllOptions();
                        permissionStatus = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        #endregion

        private void FrmInvoiceSelection_Load(object sender, EventArgs e)
        {
            fillAllOptions();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            updateOptionStatus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            fillAllOptions();
        }


        #region Validation Methods

        #endregion

    }
}
