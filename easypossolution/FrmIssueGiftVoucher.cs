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
using System.Collections;

namespace easyPOSSolution
{
    public partial class FrmIssueGiftVoucher : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ClassCommonBAL objBAL = new ClassCommonBAL();
        ClassMasterDAL objDAL = new ClassMasterDAL();

        ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();

        int VoucherNo = 0;

        public FrmIssueGiftVoucher()
        {
            InitializeComponent();
        }

        private void GenerateId()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                VoucherNo = Convert.ToInt32(objInvDAL.SelectMaxVoucherNO(objInvBAL).Tables[0].Rows[0][0]) + 1;
                txtVoucherNo.Text = VoucherNo.ToString();
                textBoxVoucherId.Text = VoucherNo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetAll()
        {
            GenerateId();
            //comboBoxCustomer.SelectedIndex = -1;
            dateEditIssueDate.EditValue = DateTime.Today;
            dateEditExpireDate.EditValue = DateTime.Today;
            txtAmount.Text = "0.00";

        }


        private void insertVoucher()
        {
                try
                {
                    objInvBAL = new ClassInvoiceBAL();
                    //if (comboBoxCustomer.SelectedIndex == -1)
                    //{
                    //    comboBoxCustomer.SelectedValue = 0;
                    //}
                    objInvBAL.CustomerId = 0;
                    objInvBAL.IssueDate = Convert.ToDateTime(dateEditIssueDate.EditValue);
                    objInvBAL.ExpireDate = Convert.ToDateTime(dateEditExpireDate.EditValue);
                    objInvBAL.VoucherAmount = Convert.ToDecimal(txtAmount.Text);
                    objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                    objInvBAL.VoucherCode = txtVoucherNo.Text;

                    objInvDAL = new ClassInvoiveDAL();
                    string count = objInvDAL.InsertGiftVoucher(objInvBAL);
                    textBoxVoucherId.Text = count.ToString();
                    if (count != "")
                    {

                        MessageBox.Show("GiftVoucher Issued.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult result = MessageBox.Show("Do you want to Print this Voucher?", "Printing Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            PrintGiftVucher();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }

        private void PrintGiftVucher()
        {
            Cursor.Current = Cursors.WaitCursor;
            CrystalReportGiftVoucher5in3 rpt = new CrystalReportGiftVoucher5in3();
            //CrystalReportInvoice3inLogo rpt = new CrystalReportInvoice3inLogo();
            ClassPOBAL objBAL = new ClassPOBAL();
            objBAL.VoucherNo = Convert.ToInt32(textBoxVoucherId.Text);
            ClassPODAL objDAL = new ClassPODAL();
            objBAL.DtDataSet = objDAL.retreiveTAWGiftVoucherData(objBAL);
            rpt.SetDataSource(objBAL.DtDataSet);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            rpt.PrintOptions.PrinterName = "";
            rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Dispose();
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void cancelVoucher()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.VoucherNo = Convert.ToInt32(textBoxVoucherId.Text);
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);

                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.CancelGiftVoucher(objInvBAL);
                if (count != 0)
                {
                    MessageBox.Show("GiftVoucher Cancelled Successfully.", "Cancell Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void searchvoucher()
        {
            try
            {
                dateEditIssueDate.EditValue = DateTime.Today;
                dateEditExpireDate.EditValue = DateTime.Today;
                txtAmount.Text = "0.00";
                objInvBAL = new ClassInvoiceBAL();
                //objInvBAL.VoucherNo = Convert.ToInt32(textBoxVoucherId.Text);
                objInvBAL.VoucherCode = txtVoucherNo.Text;
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreivevaucherCodeData(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objInvBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        textBoxVoucherId.Text = (values[0].ToString().Trim());
                        dateEditIssueDate.EditValue = Convert.ToDateTime(values[1]);
                        dateEditExpireDate.EditValue = Convert.ToDateTime(values[2]);
                        txtAmount.Text = (values[4].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmIssueGiftVoucher_Load(object sender, EventArgs e)
        {
            //ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
            //ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
            //if (objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1].Rows.Count > 0)
            //{
            //    comboBoxCustomer.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[1];
            //    comboBoxCustomer.DisplayMember = "CustomerName";
            //    comboBoxCustomer.ValueMember = "CustomerId";
            //    comboBoxCustomer.SelectedIndex = -1;
            //}
            resetAll();
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            resetAll();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            insertVoucher();
            resetAll();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormViewGiftVouchers frm = new FormViewGiftVouchers();
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchvoucher();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Cancel this Gift Voucher?", "Cancel Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cancelVoucher();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintGiftVucher();
        }


    }
}