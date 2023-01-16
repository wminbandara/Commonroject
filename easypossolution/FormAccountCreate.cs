using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using easyDAL;
using easyBAL;

namespace easyPOSSolution
{
    public partial class FormAccountCreate : DevExpress.XtraEditors.XtraForm
    {
        #region Local Variables

        ClassAccount objBAL = new ClassAccount();
        ClassAccountDAL objDAL = new ClassAccountDAL();

        #endregion

        #region Constructor
        public FormAccountCreate()
        {
            InitializeComponent();
        }

        #endregion

        private void FormAccountCreate_Load(object sender, EventArgs e)
        {

        }

        #region Methods

        private void FillHDAccounts()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region Events



        #endregion



        #region Validation Methods



        #endregion
        
    }
}