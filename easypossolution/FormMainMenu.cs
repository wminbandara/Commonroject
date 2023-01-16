using easyBAL;
using easyDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormMainMenu : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        ArrayList alistForm = new ArrayList();

        int fCount = Directory.GetFiles("C:\\Images", "*", SearchOption.AllDirectories).Length;
        string txtFileName;

        #endregion

        #region Constructor
        public FormMainMenu()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        private void userPermission()
        {
            try
            {
                BALUser objUser = new BALUser();
                //objUser.FORM_NAME = "User Registration";
                objUser.EntUser = Convert.ToInt32(lblUserId.Text.Trim());
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveUserPermission(objUser);
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
                        alistForm.Add(values[0].ToString());

                    }
                    for (int i = 0; i < alistForm.Count; i++)
                    {
                        if (alistForm[i].ToString().Trim() == "Customers")
                        {
                            customerToolStripMenuItem.Visible = true;
                            customersToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Credit Payment")
                        {
                            customerToolStripMenuItem.Visible = true;
                            creditPaymentToolStripMenuItem1.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Suppliers")
                        {
                            toolStripMenuItemSuppliers.Visible = true;
                            suppliersToolStripMenuItem.Visible = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Credit Payment")
                        //{
                        //    toolStripMenuItemSuppliers.Visible = true;
                        //    creditPaymentToolStripMenuItem.Visible = true;
                        //}
                        if (alistForm[i].ToString().Trim() == "Purchasing")
                        {
                            stockToolStripMenuItem.Visible = true;
                            stockEnteringToolStripMenuItem.Visible = true;
                            btnStock.Enabled = true;
                            //toolStripMenuItemPurchase.Visible = true;
                            //purchasingToolStripMenuItem.Visible = true;
                            //btnPurchasing.Enabled = true;
                        }
                        //if (alistForm[i].ToString().Trim() == "Purchase Return")
                        //{
                        //    toolStripMenuItemPurchase.Visible = true;
                        //    purchaseReturnToolStripMenuItem.Visible = true;
                        //}
                        if (alistForm[i].ToString().Trim() == "Invoicing")
                        {
                            butonInvoice.Visible = true;
                            btnInvoice.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Sales Return")
                        {
                            SalestoolStripMenuItem.Visible = true;
                            salesReturnToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Stock Entering")
                        {
                            stockToolStripMenuItem.Visible = true;
                            stockEnteringToolStripMenuItem.Visible = true;
                            btnStock.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Stock Report")
                        {
                            stockToolStripMenuItem.Visible = true;
                            stockReportToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Sales Reports")
                        {
                            toolStripMenuItemReport.Visible = true;
                            salesReportsToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Stock Reports")
                        {
                            toolStripMenuItemReport.Visible = true;
                            stockReportsToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Bill Details")
                        {
                            toolStripMenuItemReport.Visible = true;
                            billDetailsToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Cheque Details")
                        {
                            toolStripMenuItemReport.Visible = true;
                            chequeDetailsToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Credit Detail")
                        {
                            toolStripMenuItemReport.Visible = true;
                            creditDetailToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Gross Profit")
                        {
                            toolStripMenuItemReport.Visible = true;
                            grossPRofitToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Register")
                        {
                            toolStripMenuItemUsers.Visible = true;
                            regieterToolStripMenuItem.Visible = true;
                            btnUsers.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Change Password")
                        {
                            toolStripMenuItemUsers.Visible = true;
                            changePasswordToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Reset Password")
                        {
                            toolStripMenuItemUsers.Visible = true;
                            resetPasswordToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Master Entry")
                        {
                            toolStripMenuItemUsers.Visible = true;
                            masterEntryToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "User Permission")
                        {
                            toolStripMenuItemUsers.Visible = true;
                            userPermissionToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "EmployeeRegister")
                        {
                            toolStripMenuItemEmployees.Visible = true;
                            registerToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Advance")
                        {
                            toolStripMenuItemEmployees.Visible = true;
                            advanceToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Salary Payment")
                        {
                            toolStripMenuItemEmployees.Visible = true;
                            salaryPaymentToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Backup")
                        {
                            btnBackup.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Expenses")
                        {
                            btnExpenses.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "Options")
                        {
                            btnOptions.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "CompanyInfo")
                        {
                            btnCompanyInfo.Enabled = true;
                        }
                        if (alistForm[i].ToString().Trim() == "ItemDiscount")
                        {
                            stockToolStripMenuItem.Visible = true;
                            itemDiscountToolStripMenuItem.Visible = true;
                        }
                        if (alistForm[i].ToString().Trim() == "ItemSpoilage")
                        {
                            stockToolStripMenuItem.Visible = true;
                            itemSpoilageToolStripMenuItem.Visible = true;
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

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FormStock frm = new FormStock();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormStock");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormStock"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                lblTime.Text = DateTime.Now.ToString();
                pictureBox1.Image = Image.FromFile(@"C:\\Images\\" + fCount + ".jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                comboBoxBGColour.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[0];
                comboBoxBGColour.DisplayMember = "SupplierName";
                comboBoxBGColour.ValueMember = "SupplierId";
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormAbout");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormAbout"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.Show();
            }
        }

        private void toolStripMenuItemUsers_Click(object sender, EventArgs e)
        {
            
        }

        private void butonInvoice_Click(object sender, EventArgs e)
        {
            frmInvoice frm = new frmInvoice();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "frmInvoice");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("frmInvoice"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmOptions frm = new FrmOptions();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmOptions");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmOptions"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmCompanyInfo frm = new FrmCompanyInfo();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmCompanyInfo");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmCompanyInfo"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormUserRegistration frm = new FormUserRegistration();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormUserRegistration");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormUserRegistration"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            frmInvoice frm = new frmInvoice();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "frmInvoice");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("frmInvoice"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
        }

        private void purchasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPurchaseOrder frm = new FormPurchaseOrder();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPurchaseOrder");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPurchaseOrder"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPurchaseReturn frm = new FormPurchaseReturn();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPurchaseReturn");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPurchaseReturn"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSuppliers frm = new FormSuppliers();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSuppliers");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSuppliers"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void creditPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSupplierCreditPayment frm = new FormSupplierCreditPayment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSupplierCreditPayment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSupplierCreditPayment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomer frm = new FormCustomer();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCustomer");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormCustomer"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        
        private void stockEnteringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStock frm = new FormStock();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormStock");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormStock"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            FormExpenses frm = new FormExpenses();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormExpenses");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormExpenses"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeRegistration frm = new EmployeeRegistration();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "EmployeeRegistration");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("EmployeeRegistration"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeAdvance frm = new EmployeeAdvance();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "EmployeeAdvance");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("EmployeeAdvance"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void salaryPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeePayment frm = new EmployeePayment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "EmployeePayment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("EmployeePayment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void profitPercentageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMenu frm = new FormMenu();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormMenu");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormMenu"))
                    {
                        f.WindowState = FormWindowState.Maximized;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSalesReport frm = new FormSalesReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSalesReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSalesReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockDetails frm = new StockDetails();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "StockDetails");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("StockDetails"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            FormStock frm = new FormStock();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormStock");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormStock"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void stockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockDetails frm = new StockDetails();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "StockDetails");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("StockDetails"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void billDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillDetails frm = new BillDetails();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "BillDetails");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("BillDetails"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void chequeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChequeDetailsReport frm = new FormChequeDetailsReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormChequeDetailsReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormChequeDetailsReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Process.Start(@"Release\\MySqlBackupTestApp.exe");
        }

        private void creditDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreditReport frm = new FormCreditReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCreditReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormCreditReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void grossPRofitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrossProfitReport frm = new FormGrossProfitReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormGrossProfitReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormGrossProfitReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSalesReturn frm = new FormSalesReturn();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSalesReturn");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSalesReturn"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void profitLossReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FormReport REPORT = new FormReport();
                REPORT.Show();
                CrystalReportProfitLost rpt = new CrystalReportProfitLost();
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveProfitLost(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                REPORT.crystalReportViewer1.ReportSource = rpt;
                REPORT.crystalReportViewer1.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void creditPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCustomerCreditPayment frm = new FormCustomerCreditPayment();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormCustomerCreditPayment");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormCustomerCreditPayment"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "image files |*.jpg;";
                DialogResult dr = ofd.ShowDialog();
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                txtFileName = ofd.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n2 = fCount + 1;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            pictureBox1.Image.Save("C:\\Images\\" + n2 + ".jpg");
            MessageBox.Show("Image Changed Successfully.", "Image Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion        

        private void regieterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserRegistration frm = new FormUserRegistration();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormUserRegistration");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormUserRegistration"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword frm = new FormChangePassword();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormChangePassword");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormChangePassword"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormResetPassword frm = new FormResetPassword();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormResetPassword");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormResetPassword"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void masterEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMasterEntry frm = new FormMasterEntry();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormMasterEntry");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormMasterEntry"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void userPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserPermission frm = new FormUserPermission();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormUserPermission");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormUserPermission"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void expensesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExpensesReport frm = new FormExpensesReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormExpensesReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormExpensesReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void receiveChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCheques frm = new FrmCheques();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmCheques");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmCheques"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void issueChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCheques frm = new FrmCheques();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FrmCheques");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FrmCheques"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void purchasingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPurchaseRecord frm = new FormPurchaseRecord();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormPurchaseRecord");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormPurchaseRecord"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void itemSpoilageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpoilageReport frm = new FormSpoilageReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormSpoilageReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormSpoilageReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void itemSpoilageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMItemSpoilage frm = new FRMItemSpoilage();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FRMItemSpoilage");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FRMItemSpoilage"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void itemDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormItemDiscount frm = new FormItemDiscount();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FormItemDiscount");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FormItemDiscount"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void invoiceCancellationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceCancellation frm = new InvoiceCancellation();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "InvoiceCancellation");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("InvoiceCancellation"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                frm.lblUser.Text = lblUser.Text.Trim();
                frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

        private void freeIssueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FreeIssueReport frm = new FreeIssueReport();
            bool formOpen = Application.OpenForms.Cast<Form>().Any(form => form.Name == "FreeIssueReport");

            if (formOpen)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name.Equals("FreeIssueReport"))
                    {
                        f.WindowState = FormWindowState.Normal;
                        f.BringToFront();
                        f.Activate();
                    }
                }
            }
            else
            {
                //frm.lblUser.Text = lblUser.Text.Trim();
                //frm.lblUserId.Text = lblUserId.Text.Trim();
                frm.Show();
            }
        }

       

        #region Validation Methods

        #endregion



    }
}
