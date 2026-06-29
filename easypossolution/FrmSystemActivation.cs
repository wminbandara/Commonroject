using easyBAL;
using easyDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FrmSystemActivation : Form
    {
        #region Local Variables

        BALUser objUser = new BALUser();
        DALUser dalUser = new DALUser();

        private DataSet dtaSet;
        string extPassword = "";
        int extPasswordId = 0;
        int curPasswordId = 0;


        #endregion

        #region Constructor

        public FrmSystemActivation()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void PasswordChecker()
        {
            CreatePasswordsTable();
            CheckPasswordData();

        }

        // Creating the Password table

        private void CreatePasswordsTable()
        {

            // Creating a new DataTable.

            DataTable custTable = new DataTable("passwords");
            DataColumn dtaColumn;
            DataRow myDataRow;

            // Create id column

            dtaColumn = new DataColumn();
            dtaColumn.DataType = typeof(Int32);
            dtaColumn.ColumnName = "RawId";
            dtaColumn.Caption = "RawId";
            dtaColumn.ReadOnly = false;
            dtaColumn.Unique = true;

            // Add column to the DataColumnCollection.

            custTable.Columns.Add(dtaColumn);

            // Create Name column.

            dtaColumn = new DataColumn();
            dtaColumn.DataType = typeof(Int32);
            dtaColumn.ColumnName = "Months";
            dtaColumn.Caption = "Months";
            dtaColumn.AutoIncrement = false;
            dtaColumn.ReadOnly = false;
            dtaColumn.Unique = false;

            /// Add column to the DataColumnCollection.

            custTable.Columns.Add(dtaColumn);

            // Create Password column.

            dtaColumn = new DataColumn();

            dtaColumn.DataType = typeof(String);
            dtaColumn.ColumnName = "Password";
            dtaColumn.Caption = "Password";
            dtaColumn.ReadOnly = false;
            dtaColumn.Unique = false;

            // Add column to the DataColumnCollection.

            custTable.Columns.Add(dtaColumn);

            // Make id column the primary key column.

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];

            PrimaryKeyColumns[0] = custTable.Columns["RawId"];

            custTable.PrimaryKey = PrimaryKeyColumns;

            // Create a new DataSet

            dtaSet = new DataSet();

            // Add custTable to the DataSet.

            dtaSet.Tables.Add(custTable);

            // Add data rows to the custTable using NewRow method

            // I add three Purchasers with their addresses, names and ids

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 1;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "9G4GE9J2VA";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 2;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "RJZXB6GL1K";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 3;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "UG6IUKLDY7";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 4;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "CEIID6H27W";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 5;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "45AXA1R91G";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 6;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "5ZRFY02I25";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 7;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "Z8KCD2PPXL";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 8;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "VDC1RQSXXM";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 9;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "DQ4RG3QNUO";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 10;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "RPVR969VYO";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 11;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "94AB1TFEAL";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 12;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "TXK17YHJP3";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 13;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "HU8IBNE0SZ";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 14;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "I5AKC9N56B";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 15;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "KBLCF9EW59";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 16;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "8WGFXR9D55";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 17;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "48N26SPDEO";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 18;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "H2ZDRKWF5F";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 19;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "9PV0LR0RN5";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 20;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "M42WPBJ829";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 21;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "B604OJ2RP4";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 22;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "C4QS5PVL78";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 23;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "DYE0MWG0D9";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 24;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "7DN1MAQFHW";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 25;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "KC05SEM1F3";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 26;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "Q4W82XMQCX";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 27;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "47LJ2EVAY9";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 28;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "OUM1J5N6LS";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 29;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "QYTM7P6ZQS";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 30;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "GF4XNQRKGQ";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 31;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "TS09M3AZ6F";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 32;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "R4TGNMIC8R";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 33;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "0EB9ZDRELG";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 34;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "XN82P04645";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 35;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "PE073J85HF";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 36;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "L772ZTQ0HS";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 37;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "361LAH3JUT";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 38;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "GZRRKQT3BM";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 39;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "7LR2DIB1DX";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 40;
            myDataRow["Months"] = 1;
            myDataRow["Password"] = "RSUY0FEV0O";
            custTable.Rows.Add(myDataRow);

            // 6 Months

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 100;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "J6TLXJZMM1UH";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 101;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "7U40DNZOR79V";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 102;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "NZDEP9UBGXVV";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 103;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "972IJ5E6LIBA";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 104;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "3G0MKGY9P8O5";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 105;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "SSO69B51QBXM";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 106;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "3JZQXMZA8QEO";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 107;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "CR9OSTKB3CMP";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 108;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "JL1Y528KT54H";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 109;
            myDataRow["Months"] = 6;
            myDataRow["Password"] = "80P9JTUXFTLH";
            custTable.Rows.Add(myDataRow);

            // 12 Months

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 200;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "NKVY4K4MWD97BIV";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 201;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "ZF150V7QAEVRDY8";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 202;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "3DYF15O4UG3SJLF";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 203;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "8P3MMOJC3W2EMN4";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 204;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "A27UXGPCU09MDN6";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 205;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "VZLHFAM58UHNMOQ";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 206;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "7EQB323363E1PER";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 207;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "58UQWCM6QEFW0SH";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 208;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "CQSWJUIH95T60BX";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 209;
            myDataRow["Months"] = 12;
            myDataRow["Password"] = "ZIJJCV9BXD1995D";
            custTable.Rows.Add(myDataRow);

            // 30 Months

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 300;
            myDataRow["Months"] = 30;
            myDataRow["Password"] = "B1JB2RPTNIM6VEX66V";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 301;
            myDataRow["Months"] = 30;
            myDataRow["Password"] = "MYQJ439IP4R8RMJ77P";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 302;
            myDataRow["Months"] = 30;
            myDataRow["Password"] = "CCGR46834HFNPE813J";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 303;
            myDataRow["Months"] = 30;
            myDataRow["Password"] = "V7ME0LO6B443A4D630";
            custTable.Rows.Add(myDataRow);

            myDataRow = custTable.NewRow();
            myDataRow["RawId"] = 304;
            myDataRow["Months"] = 30;
            myDataRow["Password"] = "D6VH1SNIMH5VEZT0ZT";
            custTable.Rows.Add(myDataRow);


        }

        private void CheckPasswordData()
        {
            bool isextPasswordValue = false;
            bool iscurPasswordValue = false;
            extPasswordId = 0;
            curPasswordId = 0;


            List<ArrayList> newval = new List<ArrayList>();
            foreach (DataRow dRow in dtaSet.Tables[0].Rows)
            {
                ArrayList values = new ArrayList();
                values.Clear();
                foreach (object value in dRow.ItemArray)
                    values.Add(value);
                newval.Add(values);

                

                if (((values[2].ToString().Trim()) == extPassword.ToString()) && (extPassword.ToString() != "") && (isextPasswordValue == false))
                {
                    extPasswordId = Convert.ToInt32(values[0].ToString().Trim());
                    isextPasswordValue = true;
                }
                if ((values[2].ToString().Trim()) == textBoxPassword.Text.Trim() && (iscurPasswordValue == false))
                {
                    curPasswordId = Convert.ToInt32(values[0].ToString().Trim());
                    iscurPasswordValue = true;
                }


                if ((extPasswordId >= curPasswordId) && (extPasswordId > 0) && (curPasswordId > 0))
                {
                    MessageBox.Show("This is an Old password.");
                    textBoxPassword.Focus();
                    return;
                }
                else if (((values[2].ToString().Trim()) == textBoxPassword.Text.Trim()) && ((values[1].ToString().Trim()) == "1"))
                {
                    comboBoxActivationType.Text = "1 Month";
                    comboBoxActStatus.Text = "Activate";
                    buttonSave.Enabled = true;
                    buttonSave.Select();
                    return;

                    //    textBoxActBillNo.ReadOnly = false;
                    //    comboBoxActStatus.Enabled = true;
                    //    buttonSave.Enabled = true;
                    //    comboBoxActivationType.Enabled = true;
                }
                else if (((values[2].ToString().Trim()) == textBoxPassword.Text.Trim()) && ((values[1].ToString().Trim()) == "6"))
                {
                    comboBoxActivationType.Text = "6 Months";
                    comboBoxActStatus.Text = "Activate";
                    buttonSave.Enabled = true;
                    buttonSave.Select();
                    return;
                }
                else if (((values[2].ToString().Trim()) == textBoxPassword.Text.Trim()) && ((values[1].ToString().Trim()) == "12"))
                {
                    comboBoxActivationType.Text = "1 Year";
                    comboBoxActStatus.Text = "Activate";
                    buttonSave.Enabled = true;
                    buttonSave.Select();
                    return;
                }
                else if (((values[2].ToString().Trim()) == textBoxPassword.Text.Trim()) && ((values[1].ToString().Trim()) == "30"))
                {
                    comboBoxActivationType.Text = "Life time";
                    comboBoxActStatus.Text = "Activate";
                    buttonSave.Enabled = true;
                    buttonSave.Select();
                    return;
                }
                else
                {
                    comboBoxActivationType.Text = "";
                    //MessageBox.Show("Incorrect password.");
                    textBoxPassword.Focus();
                    //return;
                }

            }

        }



        private void UpdateActivation()
        {
            try
            {
                objUser = new BALUser();
                objUser.ActBillNo = Convert.ToInt32(textBoxActBillNo.Text);
                if (comboBoxActStatus.Text == "Activate")
                {
                    objUser.ActStatus = true;
                }
                else if (comboBoxActStatus.Text == "Deactivate")
                {
                    objUser.ActStatus = false;
                }
                objUser.ActivationType = comboBoxActivationType.Text;
                objUser.DevKey = textBoxPassword.Text;

                dalUser = new DALUser();
                int count = dalUser.UpdateSystemActivation(objUser);
                if (count != 0)
                {
                    MessageBox.Show("Successfully Saved.", "Save Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillActivationInfo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDevActivation()
        {
            try
            {
                objUser = new BALUser();
                objUser.ActivationType = "bl086532408452ms";

                dalUser = new DALUser();
                int count = dalUser.UpdateDecSystemActivation(objUser);
                if (count != 0)
                {
                    MessageBox.Show("Successfully Activated.", "Save Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillActivationInfo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillActivationInfo()
        {
            try
            {
                BALUser objUser = new BALUser();
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveActivationInfo(objUser);
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
                        textBoxCompName.Text = (values[0].ToString());
                        textBoxActBillNo.Text = (values[1].ToString());
                        extPassword = (values[3].ToString());

                        if (Convert.ToBoolean(values[2]) == true)
                        {
                            comboBoxActStatus.Text = "Activate";
                        }
                        else if (Convert.ToBoolean(values[2]) == false)
                        {
                            comboBoxActStatus.Text = "Deactivate";
                        }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateActivation();
        }

        private void FrmSystemActivation_Load(object sender, EventArgs e)
        {
            fillActivationInfo();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void FrmSystemActivation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PasswordChecker();
                //if (textBoxPassword.Text == "qwe@123")
                //{
                //    textBoxActBillNo.ReadOnly = false;
                //    comboBoxActStatus.Enabled = true;
                //    buttonSave.Enabled = true;
                //    comboBoxActivationType.Enabled = true;
                //}
                //else if (textBoxPassword.Text == "asd@123")
                //{
                //    textBoxActBillNo.ReadOnly = false;
                //    comboBoxActStatus.Enabled = true;
                //    buttonSave.Enabled = true;
                //    buttonActivation.Enabled = true;
                //    buttonActivation.Visible = true;

                //}
            }
        }

        #endregion

        private void buttonActivation_Click(object sender, EventArgs e)
        {
            
            //checkpasswordtyped();
            UpdateDevActivation();
        }

        #region Validation Methods

        #endregion
    }
}
