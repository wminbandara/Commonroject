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
    public partial class FormVehicleMilageLog : Form
    {
        bool loadstatus = false;

        public FormVehicleMilageLog()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            comboBoxVehicle.SelectedIndex = -1;
            textEditRatePerMile.Text = "0.00";
            comboBoxEmployee.SelectedIndex = -1;
            textEditDesignation.Text = "";
            textEditStartingPlace.Text = "";
            textEditDestination.Text = "";
            textEditStartMilage.Text = "0";
            textEditEndMile.Text = "0";
            textEditMilage.Text = "0";
            textEditRate.Text = "0";
            textEditTotalMilage.Text = "0";
            textEditTotalRate.Text = "0.00";
            txtLogId.Text = "0";
            textEditFuelCost.Text = "0.00";
            textEditTotalFuelCost.Text = "0.00";
            textEditFuelDt.Text = "0.00";
            textEditRefInvNo.Text = "0";
            textEditFuelLeters.Text = "0";
            dgView.Rows.Clear();
            txtComment.Clear();

        }

        private void insertHD()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.VehicleId = Convert.ToInt32(comboBoxVehicle.SelectedValue.ToString());
                objBAL.VehicleNo = comboBoxVehicle.Text;
                objBAL.RatePerMile = Convert.ToDecimal(textEditRatePerMile.Text);
                objBAL.EmployeeID = Convert.ToInt32(comboBoxEmployee.SelectedValue.ToString());
                objBAL.FromDate = Convert.ToDateTime(dateEditFrom.EditValue);
                objBAL.ToDate = Convert.ToDateTime(dateEditTo.EditValue);
                objBAL.Remarks = txtComment.Text.Trim();
                objBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objBAL.TotalMilage = Convert.ToInt32(textEditTotalMilage.Text);
                objBAL.TotalRate = Convert.ToDecimal(textEditTotalRate.Text);
                objBAL.FuelCostPerMile = Convert.ToDecimal(textEditFuelCost.Text);
                objBAL.TotalFuelCost = Convert.ToDecimal(textEditTotalFuelCost.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();

                string count = objDAL.InsertMilageHD(objBAL);
                txtLogId.Text = count.ToString();

                if (count != "")
                {
                    SaveDT();
                    MessageBox.Show("Vehicle log Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveDT()
        {
            try
            {

                for (int i = 0; i < dgView.Rows.Count; i++)
                {

                    ClassCommonBAL objInvBAL = new ClassCommonBAL();
                    objInvBAL.VehicleMilageHDId = Convert.ToInt32(txtLogId.Text);
                    objInvBAL.MilageDate = Convert.ToDateTime(dgView.Rows[i].Cells["Date"].Value.ToString());
                    objInvBAL.PurposeId = Convert.ToInt32(dgView.Rows[i].Cells["PurposeId"].Value.ToString());
                    objInvBAL.StartingPlace = (dgView.Rows[i].Cells["StartingPlace"].Value.ToString());
                    objInvBAL.Destination = (dgView.Rows[i].Cells["Destination"].Value.ToString());
                    objInvBAL.StartMile = Convert.ToInt32(dgView.Rows[i].Cells["StartMile"].Value);
                    objInvBAL.EndMile = Convert.ToInt32(dgView.Rows[i].Cells["EndMile"].Value);
                    objInvBAL.Milage = Convert.ToInt32(dgView.Rows[i].Cells["Milage"].Value);
                    objInvBAL.RatePerMile = Convert.ToDecimal(textEditRatePerMile.Text);
                    objInvBAL.Rate = Convert.ToDecimal(dgView.Rows[i].Cells["Rate"].Value);
                    objInvBAL.FuelCost = Convert.ToDecimal(dgView.Rows[i].Cells["FuelCost"].Value);
                    objInvBAL.RefInvNo = Convert.ToInt32(dgView.Rows[i].Cells["RefInvNo"].Value);
                    objInvBAL.FuelLeters = Convert.ToDecimal(dgView.Rows[i].Cells["FuelLeters"].Value);
                    objInvBAL.VehicleId = Convert.ToInt32(comboBoxVehicle.SelectedValue);
                    ClassMasterDAL objInvDAL = new ClassMasterDAL();
                    int count = objInvDAL.InsertVehicleLogDT(objInvBAL);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveItem()
        {
            try
            {
                if (dgView.SelectedRows.Count > 0)
                {
                    dgView.Rows.RemoveAt(dgView.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Select one item to remove!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillVehicleRate()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.VehicleId = Convert.ToInt32(comboBoxVehicle.SelectedValue.ToString());
                ClassMasterDAL objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveVehicleRate(objBAL);
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
                        textEditRatePerMile.Text = (values[0].ToString());
                        textEditFuelCost.Text = (values[1].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillEmployeeDesignation()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.EmployeeID = Convert.ToInt32(comboBoxEmployee.SelectedValue.ToString());
                ClassMasterDAL objDAL = new ClassMasterDAL();
                objBAL.DtDataSet = objDAL.retreiveEmployeeDesignation(objBAL);
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
                        textEditDesignation.Text = (values[0].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalculateMilage()
        {
            try
            {
                textEditMilage.Text = (Convert.ToInt32(textEditEndMile.Text) - Convert.ToInt32(textEditStartMilage.Text)).ToString();
                textEditRate.Text = (Convert.ToDecimal(textEditMilage.Text) * Convert.ToDecimal(textEditRatePerMile.Text)).ToString();
                textEditFuelDt.Text = (Convert.ToDecimal(textEditMilage.Text) * Convert.ToDecimal(textEditFuelCost.Text)).ToString();
            }
            catch
            {
            }
        }

        private void AddtoGrid()
        {
            try
            {
                if (comboBoxPurpose.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Purpose.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBoxPurpose.Select();
                    return;
                }
                else if (textEditStartingPlace.Text == "")
                {
                    MessageBox.Show("Please enter Starting Place.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textEditStartingPlace.Select();
                    return;
                }
                else if (textEditDestination.Text == "")
                {
                    MessageBox.Show("Please enter Destination.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textEditDestination.Select();
                    return;
                }
                else if (textEditStartMilage.Text == "")
                {
                    MessageBox.Show("Please enter Starting Mile.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textEditStartMilage.Select();
                    return;
                }
                else if (textEditEndMile.Text == "")
                {
                    MessageBox.Show("Please enter End Mile.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textEditEndMile.Select();
                    return;
                }

                else
                {

                    int n = dgView.Rows.Add();

                    dgView.Rows[n].Cells["Date"].Value = dateEditDate.EditValue;
                    dgView.Rows[n].Cells["PurposeId"].Value = comboBoxPurpose.SelectedValue.ToString();
                    dgView.Rows[n].Cells["Purpose"].Value = comboBoxPurpose.Text;
                    dgView.Rows[n].Cells["StartingPlace"].Value = textEditStartingPlace.Text;
                    dgView.Rows[n].Cells["Destination"].Value = textEditDestination.Text;
                    dgView.Rows[n].Cells["StartMile"].Value = textEditStartMilage.Text;
                    dgView.Rows[n].Cells["EndMile"].Value = textEditEndMile.Text;
                    dgView.Rows[n].Cells["Milage"].Value = textEditMilage.Text;
                    dgView.Rows[n].Cells["Rate"].Value = textEditRate.Text;
                    dgView.Rows[n].Cells["FuelCost"].Value = textEditFuelDt.Text;
                    dgView.Rows[n].Cells["RefInvNo"].Value = textEditRefInvNo.Text;
                    dgView.Rows[n].Cells["FuelLeters"].Value = textEditFuelLeters.Text;
                    

                    dgView.FirstDisplayedScrollingRowIndex = n;
                    dgView.CurrentCell = dgView.Rows[n].Cells[0];
                    dgView.Rows[n].Selected = true;

                    textEditStartingPlace.Text = "";
                    textEditDestination.Text = "";
                    textEditStartMilage.Text = "0";
                    textEditEndMile.Text = "0";
                    textEditMilage.Text = "0";
                    textEditRate.Text = "0";
                    textEditFuelDt.Text = "0";
                    textEditRefInvNo.Text = "0";
                    textEditFuelLeters.Text = "0";
                    CalculateTotal();
                }
                textEditStartingPlace.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalculateTotal()
        {
            try
            {
                int MilageTotal = 0;
                decimal RateTotal = 0;
                decimal FuelTotal = 0;

                int i = dgView.RowCount;

                for (int a = 0; a < i; a++)
                {
                    try
                    {
                            MilageTotal += Convert.ToInt32(dgView.Rows[a].Cells["Milage"].Value.ToString());
                            RateTotal += Convert.ToDecimal(dgView.Rows[a].Cells["Rate"].Value.ToString());
                            FuelTotal += Convert.ToDecimal(dgView.Rows[a].Cells["FuelCost"].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                textEditTotalMilage.Text = MilageTotal.ToString();
                textEditTotalRate.Text = RateTotal.ToString("0.00");
                textEditTotalFuelCost.Text = FuelTotal.ToString("0.00");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPurpose()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.Purpose = textEditPerpose.Text.Trim();

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertNewPurpose(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("New Purpose Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadVehicles();
                    textEditPerpose.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadPurpose()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxPurpose.DataSource = objDAL.retreivePurpose(objBAL).Tables[0];
                comboBoxPurpose.DisplayMember = "Purpose";
                comboBoxPurpose.ValueMember = "PurposeId";
                comboBoxPurpose.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadVehicles()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxVehicle.DataSource = objDAL.retreiveVehicles(objBAL).Tables[0];
                comboBoxVehicle.DisplayMember = "VehicleNo";
                comboBoxVehicle.ValueMember = "VehicleId";
                comboBoxVehicle.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadEmployees()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxEmployee.DataSource = objDAL.retreiveEmployees(objBAL).Tables[0];
                comboBoxEmployee.DisplayMember = "EmployeeName";
                comboBoxEmployee.ValueMember = "EmployeeID";
                comboBoxEmployee.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButtonPurpose_Click(object sender, EventArgs e)
        {
            if (textEditPerpose.Text != "")
            {
                insertPurpose();
            }
        }

        private void FormVehicleMilageLog_Load(object sender, EventArgs e)
        {
            loadstatus = true;
            loadVehicles();
            loadPurpose();
            loadEmployees();
            loadstatus = false;
        }

        private void textEditStartingPlace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textEditDestination.Select();
            }
        }

        private void textEditDestination_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textEditStartMilage.Select();
            }
        }

        private void textEditStartMilage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textEditEndMile.Select();
            }
        }

        private void textEditEndMile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textEditFuelLeters.Select();
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            AddtoGrid();
        }

        private void textEditStartMilage_EditValueChanged(object sender, EventArgs e)
        {
            CalculateMilage();
        }

        private void textEditEndMile_EditValueChanged(object sender, EventArgs e)
        {
            CalculateMilage();
        }

        private void comboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadstatus == false && comboBoxVehicle.SelectedIndex != -1)
            {
                fillVehicleRate();
            }
        }

        

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadstatus == false && comboBoxEmployee.SelectedIndex != -1)
            {
                fillEmployeeDesignation();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete this Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RemoveItem();
                CalculateTotal();
            }
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            insertHD();
        }

        private void simpleButtonNew_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset?", "Reset Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Reset();
            }
            
        }

        private void textEditRefInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                simpleButtonAdd.Select();
            }
        }

        private void textEditFuelLeters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textEditRefInvNo.Select();
            }
        }

        
        
    }
}
