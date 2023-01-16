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
    public partial class FormPayMode : Form
    {
        #region Local Variables
        public frmInvoice frm { set; get; }
        public FormInvoiceTuch frm1 { set; get; }

        public int form;

        #endregion

        #region Constructor
        public FormPayMode()
        {
            InitializeComponent();
        }

        #endregion       

        #region Methods


        #endregion


        #region Events

        private void comboBoxPayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMode.Text == "Cheque")
            {
                label23.Visible = true;
                label23.Text = "Cheque No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Exp. Date";
                dateTimePickerChqExpDate.Visible = true;
                comboBoxCardType.Visible = false;
            }
            else if (comboBoxPayMode.Text == "Bank Transfer")
            {
                //label23.Visible = true;
                //label23.Text = "Cheque No";
                //textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                //label27.Visible = true;
                //label27.Text = "Exp. Date";
                //dateTimePickerChqExpDate.Visible = true;
                comboBoxCardType.Visible = false;
            }
            else if (comboBoxPayMode.Text == "Card")
            {
                label23.Visible = true;
                label23.Text = "Card No";
                textBoxChequeNo.Visible = true;
                label25.Visible = true;
                comboBoxBank.Visible = true;
                label27.Visible = true;
                label27.Text = "Card Type";
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = true;
            }
            else
            {
                label23.Visible = false;
                textBoxChequeNo.Visible = false;
                label25.Visible = false;
                comboBoxBank.Visible = false;
                label27.Visible = false;
                dateTimePickerChqExpDate.Visible = false;
                comboBoxCardType.Visible = false;
            }
        }

        private void FormPayMode_Load(object sender, EventArgs e)
        {
            try
            {
                ClassPOBAL objBAL = new ClassPOBAL();
                ClassPODAL objDAL = new ClassPODAL();
                if (objDAL.retreivePOLoadingData(objBAL).Tables[1].Rows.Count > 0)
                {
                    comboBoxPayMode.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[1];
                    comboBoxPayMode.DisplayMember = "PayMode";
                    comboBoxPayMode.ValueMember = "PayModeId";
                    comboBoxPayMode.SelectedIndex = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void comboBoxPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    textBoxChequeNo.Select();
                }
                else if (comboBoxPayMode.Text == "Card")
                {
                    textBoxChequeNo.Select();
                }
                else if (comboBoxPayMode.Text == "Bank Transfer")
                {
                    comboBoxBank.Select();
                }
                else if (comboBoxPayMode.Text == "Credit")
                {
                    frm.comboBoxPayMode.Text = "Credit";
                    frm.textBoxCustCode.Select();
                    this.Close();
                }
                else
                {
                    frm.lblCashTender.Select();
                    this.Close();
                }

            }
        }

        private void textBoxChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    comboBoxBank.Select();
                }
                else if (comboBoxPayMode.Text == "Card")
                {
                    comboBoxBank.Select();
                }

            }
        }

        private void comboBoxBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxPayMode.Text == "Cheque")
                {
                    dateTimePickerChqExpDate.Select();
                }
                else if (comboBoxPayMode.Text == "Card")
                {
                    comboBoxCardType.Select();
                }
                else if (comboBoxPayMode.Text == "Bank Transfer")
                {
                    if (form == 1)
                    {
                        frm1.comboBoxPayMode.Text = comboBoxPayMode.Text;
                        frm1.textBoxChequeNo.Text = textBoxChequeNo.Text;
                        frm1.comboBoxBank.Text = comboBoxBank.Text;
                        frm1.comboBoxCardType.Text = comboBoxCardType.Text;
                        frm1.textBoxCustCode.Select();
                    }
                    else
                    {
                        frm.comboBoxPayMode.Text = comboBoxPayMode.Text;
                        frm.textBoxChequeNo.Text = textBoxChequeNo.Text;
                        frm.comboBoxBank.Text = comboBoxBank.Text;
                        frm.comboBoxCardType.Text = comboBoxCardType.Text;
                        frm.textBoxCustCode.Select();
                    }
                }

            }
        }

        private void comboBoxCardType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (form == 1)
                {
                    frm1.comboBoxPayMode.Text = comboBoxPayMode.Text;
                    frm1.textBoxChequeNo.Text = textBoxChequeNo.Text;
                    frm1.comboBoxBank.Text = comboBoxBank.Text;
                    frm1.comboBoxCardType.Text = comboBoxCardType.Text;
                    frm1.textBoxCustCode.Select();
                }
                else
                {
                    frm.comboBoxPayMode.Text = comboBoxPayMode.Text;
                    frm.textBoxChequeNo.Text = textBoxChequeNo.Text;
                    frm.comboBoxBank.Text = comboBoxBank.Text;
                    frm.comboBoxCardType.Text = comboBoxCardType.Text;
                    frm.textBoxCustCode.Select();
                }
                
                this.Close();
            }
        }

        private void FormPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dateTimePickerChqExpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (form == 1)
                {
                    frm1.comboBoxPayMode.Text = "Cheque";
                    frm1.textBoxChequeNo.Text = textBoxChequeNo.Text;
                    frm1.comboBoxBank.Text = comboBoxBank.Text;
                    frm1.dateTimePickerChqExpDate.Value = dateTimePickerChqExpDate.Value;
                }
                else
                {
                    frm.comboBoxPayMode.Text = "Cheque";
                    frm.textBoxChequeNo.Text = textBoxChequeNo.Text;
                    frm.comboBoxBank.Text = comboBoxBank.Text;
                    frm.dateTimePickerChqExpDate.Value = dateTimePickerChqExpDate.Value;
                }
                frm.textBoxCustCode.Select();
                this.Close();
            }
        }


        #endregion

        private void simpleButtonEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonEnter_Click(object sender, EventArgs e)
        {
            if (form == 1)
            {
                frm1.comboBoxPayMode.Text = comboBoxPayMode.Text;
                frm1.textBoxChequeNo.Text = textBoxChequeNo.Text;
                frm1.comboBoxBank.Text = comboBoxBank.Text;
                frm1.dateTimePickerChqExpDate.Value = dateTimePickerChqExpDate.Value;
            }
            else
            {
                frm.comboBoxPayMode.Text = comboBoxPayMode.Text;
                frm.textBoxChequeNo.Text = textBoxChequeNo.Text;
                frm.comboBoxBank.Text = comboBoxBank.Text;
                frm.dateTimePickerChqExpDate.Value = dateTimePickerChqExpDate.Value;
            }
            //frm.textBoxCustCode.Select();
            this.Close();
        }

       

        #region Validation Methods



        #endregion

        
    }
}
