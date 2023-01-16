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
    public partial class FormVehicle : Form
    {
        public FormVehicle()
        {
            InitializeComponent();
        }

        private void fillGridAllVehicles()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllVehicles(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView1.Columns["VehicleTypeId"].Visible = false;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.BestFitColumns();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadVehicleType()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                comboBoxVehicleType.DataSource = objDAL.retreiveVehicleTypes(objBAL).Tables[0];
                comboBoxVehicleType.DisplayMember = "VehicleType";
                comboBoxVehicleType.ValueMember = "VehicleTypeId";
                comboBoxVehicleType.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            textEditVehicleId.Text = "0";
            comboBoxVehicleType.SelectedIndex = -1;
            textEditVehicleNo.Text = "";
            textEditRatePerMile.Text = "0.00";
            textEditCurrentMeeter.Text = "0";
            textEditNextService.Text = "0";
            textEditFuelCost.Text = "0.00";
        }

        private void InsertVehicle()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.VehicleTypeId = Convert.ToInt32(comboBoxVehicleType.SelectedValue.ToString());
                objBAL.VehicleNo = textEditVehicleNo.Text.Trim();
                objBAL.LicenceExpiryDate = Convert.ToDateTime(dateEditLicenceExp.EditValue.ToString());
                objBAL.InsuranceExpiryDate = Convert.ToDateTime(dateEditInsuranceExp.EditValue.ToString());
                objBAL.RatePerMile = Convert.ToDecimal(textEditRatePerMile.Text);
                objBAL.CurrentMeeter = Convert.ToInt32(textEditCurrentMeeter.Text);
                objBAL.NextService = Convert.ToInt32(textEditNextService.Text);
                objBAL.FuelCostPerMile = Convert.ToDecimal(textEditFuelCost.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertVehile(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Vehicle Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGridAllVehicles();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateVehicle()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.VehicleTypeId = Convert.ToInt32(comboBoxVehicleType.SelectedValue.ToString());
                objBAL.VehicleNo = textEditVehicleNo.Text.Trim();
                objBAL.LicenceExpiryDate = Convert.ToDateTime(dateEditLicenceExp.EditValue.ToString());
                objBAL.InsuranceExpiryDate = Convert.ToDateTime(dateEditInsuranceExp.EditValue.ToString());
                objBAL.RatePerMile = Convert.ToDecimal(textEditRatePerMile.Text);
                objBAL.CurrentMeeter = Convert.ToInt32(textEditCurrentMeeter.Text);
                objBAL.NextService = Convert.ToInt32(textEditNextService.Text);
                objBAL.NextService = Convert.ToInt32(textEditNextService.Text);
                objBAL.VehicleId = Convert.ToInt32(textEditVehicleId.Text);
                objBAL.FuelCostPerMile = Convert.ToDecimal(textEditFuelCost.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.UpdateVehile(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Vehicle Saved Susccessfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGridAllVehicles();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteVehicle()
        {
            try
            {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.VehicleId = Convert.ToInt32(textEditVehicleId.Text);

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.DeleteVehile(objBAL);
                if (count != 0)
                {
                    MessageBox.Show("Vehicle Deleted Susccessfully.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    fillGridAllVehicles();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void FormVehicle_Load(object sender, EventArgs e)
        {
            fillGridAllVehicles();
            loadVehicleType();
        }

        private void simpleButtonNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            InsertVehicle();
        }

        private void simpleButtonUpdate_Click(object sender, EventArgs e)
        {
            if (textEditVehicleId.Text != "0")
            {
                DialogResult result = MessageBox.Show("Do you want to Update this Vehicle Record?", "Update Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UpdateVehicle();
                }
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            if (textEditVehicleId.Text != "0")
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this Vehicle Record?", "Delete Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteVehicle();
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gridView1.GetFocusedRowCellValue("VehicleId") == null)
                return;
            textEditVehicleId.Text = (this.gridView1.GetFocusedRowCellValue("VehicleId").ToString());
            comboBoxVehicleType.SelectedValue = (this.gridView1.GetFocusedRowCellValue("VehicleTypeId").ToString());
            textEditVehicleNo.Text = (this.gridView1.GetFocusedRowCellValue("VehicleNo").ToString());
            dateEditLicenceExp.EditValue = (this.gridView1.GetFocusedRowCellValue("LicenceExpiryDate").ToString());
            dateEditInsuranceExp.EditValue = (this.gridView1.GetFocusedRowCellValue("InsuranceExpiryDate").ToString());
            textEditRatePerMile.Text = (this.gridView1.GetFocusedRowCellValue("RatePerMile").ToString());
            textEditCurrentMeeter.Text = (this.gridView1.GetFocusedRowCellValue("CurrentMeeter").ToString());
            textEditNextService.Text = (this.gridView1.GetFocusedRowCellValue("NextService").ToString());
            textEditFuelCost.Text = (this.gridView1.GetFocusedRowCellValue("FuelCostPerMile").ToString());
        }


    }
}
