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
    public partial class FormUserPermission : Form
    {
        #region Local Variables

        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();

        bool loadUserName = false;

        #endregion

        #region Constructor

        public FormUserPermission()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        //private void fillProfileControllsGrid()
        //{
        //    try
        //    {
        //        objUser = new BALUser();
        //        dalUser = new DALUser();
        //        dataGridViewPrifilePermission.DataSource = null;
        //        objUser.DtDataSet = dalUser.retreiveProfilePermission(objUser);
        //        if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            dataGridViewPrifilePermission.DataSource = objUser.DtDataSet.Tables[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void deletePermission()
        {
            try
            {
                objUser = new BALUser();
                objUser.USER_ROLE_ID = Convert.ToInt32(dataGridViewUser[0, 0].Value);
                dalUser = new DALUser();

                if (dataGridViewUserPermission.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dataGridViewUserPermission.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridViewUserPermission["PermStatus", i].Value) == false)
                        {
                            objUser = new BALUser();
                            objUser.USER_ROLE_ID = Convert.ToInt32(dataGridViewUserPermission["USER_ROLE_ID", i].Value);
                            dalUser = new DALUser();
                            int count = dalUser.deletePermission(objUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillAllControlls()
        {
            try
            {
                objUser = new BALUser();
                objUser.USER_ID = Convert.ToInt32(dataGridViewUser[0, 0].Value);
                dalUser = new DALUser();
                dataGridViewNewPermission.DataSource = null;
                objUser.DtDataSet = dalUser.retreiveAllControlls(objUser);
                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridViewNewPermission.DataSource = objUser.DtDataSet.Tables[0];
                    dataGridViewNewPermission.Columns[0].Visible = false;
                    dataGridViewNewPermission.Columns[1].ReadOnly = true;
                    dataGridViewNewPermission.Columns[2].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void fillAllControllsProfile()
        //{
        //    try
        //    {
                
        //        for (int i = 0; i < dataGridViewProfiles.Rows.Count; i++)
        //        {
        //            if (Convert.ToBoolean(dataGridViewProfiles["SelectProfile", i].Value) == true)
        //            {
        //                objUser = new BALUser();
        //                objUser.USER_ID = Convert.ToInt32(dataGridViewUser[0, 0].Value);
        //                objUser.USER_TYPE_ID = Convert.ToInt32(dataGridViewProfiles["USER_TYPE_ID", i].Value);
        //                dalUser = new DALUser();
        //                dataGridViewNewPermission.DataSource = null;
        //                objUser.DtDataSet = dalUser.retreiveAllControllsProfile(objUser);
        //                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
        //                {
        //                    dataGridViewNewPermission.DataSource = objUser.DtDataSet.Tables[0];
        //                    dataGridViewNewPermission.Columns[0].Visible = false;
        //                    dataGridViewNewPermission.Columns[1].ReadOnly = true;
        //                    dataGridViewNewPermission.Columns[2].ReadOnly = true;
        //                }
        //            }
                    
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void insertUserPermission()
        {
            bool permissionStatus = false;
            try
            {
                if (dataGridViewNewPermission.Rows.Count > 0)
                {
                    objUser = new BALUser();
                    objUser.USER_ID = Convert.ToInt32(dataGridViewUser[0,0].Value);
                    for (int i = 0; i < dataGridViewNewPermission.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridViewNewPermission["PerStatus", i].Value) == true)
                        {                            
                            objUser.ROLE_ID = Convert.ToInt32(dataGridViewNewPermission["ROLE_ID", i].Value);                            
                            dalUser = new DALUser();
                            int count = dalUser.insertUserPermission(objUser);
                            if (count != 0)
                            {
                                permissionStatus = true;
                            }
                        }
                    }
                    if (permissionStatus == true)
                    {
                        MessageBox.Show("Successfully Granted permissions to this user.", "Save Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        permissionStatus = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void profilePermision()
        //{
        //    try
        //    {
        //        for (int i = 0; i < dataGridViewPrifilePermission.Rows.Count; i++)
        //        {
        //            objUser = new BALUser();
        //            objUser.USER_PROFILE_ID = Convert.ToInt32(dataGridViewPrifilePermission["USER_PROFILE_ID", i].Value);
        //            objUser.PERMISSION_STATUS = Convert.ToBoolean(dataGridViewPrifilePermission["Permission Status", i].Value);
        //            dalUser = new DALUser();
        //            int count = dalUser.updateProfilePermission(objUser);
        //        }
        //        fillPrifileGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void completeUserName()
        {
            try
            {
                objUser = new BALUser();
                dalUser = new DALUser();
                AutoCompleteStringCollection namecollection = new AutoCompleteStringCollection();
                objUser.DtDataSet = dalUser.retreiveUserName(objUser);

                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objUser.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        namecollection.Add(values[0].ToString());
                    }

                    textBoxUserName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    textBoxUserName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBoxUserName.AutoCompleteCustomSource = namecollection;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void fillUserGrid()
        {
            try
            {
                objUser = new BALUser();
                objUser.USER_NAME = textBoxUserName.Text.Trim();
                dalUser = new DALUser();
                dataGridViewUser.DataSource = null;
                dataGridViewUserPermission.DataSource = null;
                //dataGridViewProfiles.DataSource = null;
                objUser.DtDataSet = dalUser.retreiveUserData(objUser);
                if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridViewUser.DataSource = objUser.DtDataSet.Tables[0];
                    dataGridViewUser.Columns[0].Visible = false;
                }

                if (objUser.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    dataGridViewUserPermission.DataSource = objUser.DtDataSet.Tables[1];
                    dataGridViewUserPermission.Columns[0].Visible = false;
                    dataGridViewUserPermission.Columns[0].ReadOnly = true;
                    dataGridViewUserPermission.Columns[1].ReadOnly = true;
                    dataGridViewUserPermission.Columns[2].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void fillProfileGrid()
        //{
        //    try
        //    {
        //        objUser = new BALUser();
        //        objUser.USER_NAME = textBoxUserName.Text.Trim();
        //        dalUser = new DALUser();
        //        dataGridViewProfiles.DataSource = null;
        //        objUser.DtDataSet = dalUser.retreiveUserData(objUser);
        //        if (objUser.DtDataSet.Tables[2].Rows.Count > 0)
        //        {
        //            dataGridViewProfiles.DataSource = objUser.DtDataSet.Tables[2];
        //            dataGridViewProfiles.Columns[0].Visible = false;
        //            dataGridViewProfiles.Columns[1].ReadOnly = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void reset()
        {
            radioButtonAll.Checked = false;
            //radioButtonProfile.Checked = false;
            dataGridViewUser.DataSource = null;
            //dataGridViewProfiles.DataSource = null;
            dataGridViewUserPermission.DataSource = null;
            dataGridViewNewPermission.DataSource = null;
        }

        #endregion



        #region Events

        private void FormUserPermission_Load(object sender, EventArgs e)
        {
            //fillProfileControllsGrid();
            if (loadUserName == false)
            {
                completeUserName();
                loadUserName = true;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //profilePermision();
            if (loadUserName == false)
            {
                completeUserName();
                loadUserName = true;
            }
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            errorProvider1.Clear();
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                reset();
                fillUserGrid();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonProfile_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonProfile.Checked == true)
            //{
            //    bool isValid = ValidateUserName();
            //    if (isValid)
            //    {
            //        objUser = new BALUser();
            //        objUser.USER_NAME = textBoxUserName.Text.Trim();
            //        dalUser = new DALUser();
            //        if (dalUser.existUser(objUser))
            //        {
            //            fillProfileGrid();
            //        }
            //    }
            //}
            //else
            //{
            //    dataGridViewProfiles.DataSource = null;
            //}
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true)
            {
                bool isValid = ValidateUserName();
                if (isValid)
                {
                    objUser = new BALUser();
                    objUser.USER_NAME = textBoxUserName.Text.Trim();
                    dalUser = new DALUser();
                    if (dalUser.existUser(objUser))
                    {
                        fillAllControlls();
                    }
                }
            }
            else
            {
                dataGridViewNewPermission.DataSource = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
                bool isValid = ValidateUserName();
                if (isValid)
                {
                    objUser = new BALUser();
                    objUser.USER_NAME = textBoxUserName.Text.Trim();
                    dalUser = new DALUser();
                    if (dalUser.existUser(objUser))
                    {
                        insertUserPermission();
                        deletePermission();
                        fillUserGrid();
                        dataGridViewNewPermission.DataSource = null;
                        radioButtonAll.Checked = false;
                        //radioButtonProfile.Checked = false;
                    }
                }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            //if (dataGridViewProfiles.Rows.Count > 0)
            //{
            //    bool isValid = ValidateUserName();
            //    if (isValid)
            //    {
            //        objUser = new BALUser();
            //        objUser.USER_NAME = textBoxUserName.Text.Trim();
            //        dalUser = new DALUser();
            //        if (dalUser.existUser(objUser))
            //        {
            //            fillAllControllsProfile();
            //        }
            //    }
            //}
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxUserName.Clear();
            reset();
        }


        #endregion



        #region Validation Methods

        private bool ValidateUserName()
        {
            textBoxUserName.Text = textBoxUserName.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(textBoxUserName.Text)) || (textBoxUserName.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please enter username.";
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
        #endregion

    }
}
