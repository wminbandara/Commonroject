using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using easyBAL;
using easyDAL;

namespace easyPOSSolution
{
    public partial class FormFixedAssetDepreciation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormFixedAssetDepreciation()
        {
            InitializeComponent();
        }

        private void FillGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                //objBAL.date1 = dateTimePickerFrom1.Value;
                //objBAL.date2 = dateTimePickerTo1.Value;
                ClassPODAL objDAL = new ClassPODAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllDepreciatePendingFixedAssets(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    //gridView1.Columns["CustomerId"].Visible = false;
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

        private void FormFixedAssetDepreciation_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FillGrid();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you need to Depreciate these Assets?", "Depreciation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UpdateAll();
            }
        }

        bool insertDTStatus = false;
        private void UpdateAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    Fixedasset objPOBAL = new Fixedasset();
                    objPOBAL.AssetId = Convert.ToInt32(gridView1.GetRowCellValue(i, "FAId").ToString());
                    objPOBAL.DepreciationDate = Convert.ToDateTime(gridView1.GetRowCellValue(i, "NextDepreciationDate").ToString());
                    objPOBAL.DepreciationAmount = Convert.ToDecimal(gridView1.GetRowCellValue(i, "DepreciationPerPeriod").ToString());
                    objPOBAL.NetValue = Convert.ToDecimal(gridView1.GetRowCellValue(i, "NetAmount").ToString());
                    objPOBAL.DepreciatedUserId = Convert.ToInt32(lblUserId.Text);
                    ClassPODAL objPODAL = new ClassPODAL();
                    int count = objPODAL.UpdateDepreciation(objPOBAL);

                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }
                }
                if (insertDTStatus == true)
                {
                    MessageBox.Show("Depreciation Updated Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}