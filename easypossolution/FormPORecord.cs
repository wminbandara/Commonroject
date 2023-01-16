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
    public partial class FormPORecord : Form
    {
        #region Local Variables

        public FormPO frm { set; get; }
        //public FormPurchaseReturn frm1 { set; get; }

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();
        bool loadStatus;
        public bool ReturnStatus;

        #endregion

        #region Constructor

        public FormPORecord()
        {
            InitializeComponent();
        }
        #endregion

        private void ButtonGetData1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePickerFrom.Value;
                objBAL.date2 = dateTimePickerTo.Value;
                objDAL = new ClassPODAL();
                DataGridView1.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePODatabyDate(objBAL);
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

        private void FormPORecord_Load(object sender, EventArgs e)
        {
            loadStatus = true;
            objBAL = new ClassPOBAL();
            objDAL = new ClassPODAL();
            comboBoxSupplierName.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[0];
            comboBoxSupplierName.DisplayMember = "SupplierName";
            comboBoxSupplierName.ValueMember = "SupplierId";
            comboBoxSupplierName.SelectedIndex = -1;

            loadStatus = false;
        }

        private void buttonGetData2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                objBAL = new ClassPOBAL();
                objBAL.date1 = dateTimePicker2.Value;
                objBAL.date2 = dateTimePicker1.Value;
                objBAL.SupplierId = Convert.ToInt32(comboBoxSupplierName.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                dataGridView2.DataSource = null;
                objBAL.DtDataSet = objDAL.retreivePODatabyDateSupplier(objBAL);
                if (objBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[0];
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = DataGridView1.SelectedRows[0];
            frm.Reset();
            frm.textBoxPOID.Text = dr.Cells["POHDId"].Value.ToString();
            //frm.ButtonSave.Enabled = false;
            //frm.existPOStatus = true;
            this.Close();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            frm.Reset();
            frm.textBoxPOID.Text = dr.Cells["POHDId"].Value.ToString();
            //frm.ButtonSave.Enabled = false;
            //frm.existPOStatus = true;
            this.Close();
        }

        #region Methods


        #endregion


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}
