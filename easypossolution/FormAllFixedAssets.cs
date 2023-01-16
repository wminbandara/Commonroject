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
    public partial class FormAllFixedAssets : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Local Variables

        #endregion

        #region Constructor
        public FormAllFixedAssets()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods




        #endregion


        #region Events



        #endregion



        #region Validation Methods



        #endregion

       

        private void FormAllFixedAssets_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                //objBAL.date1 = dateTimePickerFrom1.Value;
                //objBAL.date2 = dateTimePickerTo1.Value;
                ClassPODAL objDAL = new ClassPODAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllFixedAssets(objBAL).Tables[0].Rows.Count > 0)
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

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objBAL = new ClassPOBAL();
                //objBAL.date1 = dateTimePickerFrom1.Value;
                //objBAL.date2 = dateTimePickerTo1.Value;
                ClassPODAL objDAL = new ClassPODAL();
                gridControl1.DataSource = null;
                if (objDAL.retreiveAllFixedAssets(objBAL).Tables[0].Rows.Count > 0)
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
    }
}