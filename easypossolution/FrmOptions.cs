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
    public partial class FrmOptions : Form
    {
        #region Local Variables

        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();

        #endregion

        #region Constructor

        public FrmOptions()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void fillAllOptions()
        {
            try
            {
                objUser = new BALUser();
                dalUser = new DALUser();
                dataGridView1.DataSource = null;
                objUser.DtDataSet = dalUser.retreiveAllOptions(objUser);
                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objUser.DtDataSet.Tables[0];
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].ReadOnly = true;
                    
                    //dataGridViewNewPermission.Columns[2].ReadOnly = true;
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
                    objUser = new BALUser();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //if (Convert.ToBoolean(dataGridView1["OptionStatus", i].Value) == true)
                        //{
                            objUser.OptionId = Convert.ToInt32(dataGridView1["OptionId", i].Value);
                            objUser.OptionStatus = Convert.ToBoolean(dataGridView1["OptionStatus", i].Value);
                            dalUser = new DALUser();
                            int count = dalUser.updateOptionPermission(objUser);
                            if (count != 0)
                            {
                                permissionStatus = true;
                            }
                        //}
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

        private void FrmOptions_Load(object sender, EventArgs e)
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

        #endregion

        
        #region Validation Methods

        #endregion

    }
}
