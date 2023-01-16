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
    public partial class FormSearchAsset : Form
    {
        public FormFixedAsset frm { set; get; }

        public FormSearchAsset()
        {
            InitializeComponent();
        }

        private void FormSearchAsset_Load(object sender, EventArgs e)
        {
            fillGridAllCustomers();
        }

        private void fillGridAllCustomers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassCommonBAL objBAL = new ClassCommonBAL();
                ClassMasterDAL objDAL = new ClassMasterDAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllAssets(objBAL).Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Status"].FilterInfo = new ColumnFilterInfo("[Status] = '1'");
                    gridView1.Columns["FAId"].Visible = false;
                    //gridView1.Columns["IsVATCustomer"].Visible = false;
                    ////gridView1.Columns["CustomerFaxNo"].Visible = false;
                    //gridView1.Columns["CustomerEmail"].Visible = false;
                    //gridView1.Columns["CustomerNICNo"].Visible = false;
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.gridView1.GetFocusedRowCellValue("AssetCode") == null)
                    return;

                frm.textBoxAssetId.Text = this.gridView1.GetFocusedRowCellValue("FAId").ToString();
                frm.textBoxAssetCode.Text = this.gridView1.GetFocusedRowCellValue("AssetCode").ToString();
                frm.textBoxAssetName.Text = this.gridView1.GetFocusedRowCellValue("AssetDescription").ToString();
                frm.textBoxQty.Text = this.gridView1.GetFocusedRowCellValue("Qty").ToString();
                frm.textBoxCost.Text = this.gridView1.GetFocusedRowCellValue("UnitPrice").ToString();
                frm.textBoxWarrantyPeriad.Text = this.gridView1.GetFocusedRowCellValue("WarrantyPeriod").ToString();
                
                
                

                this.Close();
                //MessageBox.Show(this.gridView1.GetFocusedRowCellValue("ItemCode").ToString());
            }
        }

    }
}
