using easyBAL;
using easyDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class Invoice : Form
    {
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
        ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();

        bool loadStatus;
        int invoiceNo;
        int row = 0;
        decimal total = 0;
        decimal availableQty;
        int sohdid;
        bool savestate = false;

        #endregion

        #region Constructor

        public Invoice()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void sets()
        {
            //for (int m = 0; m < dataGridView1.Rows.Count; m++)
            //{
            //    noOfPcs = noOfPcs + Convert.ToDouble(lbQty.Items[m].ToString());
            //}

            //laItems.Text = "No of Items : " + lbItem.Items.Count.ToString();
            //laPcs.Text = "No of Pcs : " + noOfPcs.ToString();

            int i = dataGridView1.Rows.Count;
            int y, k = 0;
            for (int j = 0; j < i; j++)
            {
                //50 say's header height
                y = 109 + (j * 20) + (j * 18);
                k = 124 + (j * 20) + (j * 18);

                ////////////////////////////////////////
                TextBox tbDes = new TextBox();
                tbDes.Location = new Point(10, y);
                tbDes.Name = "tbDes" + j;
                tbDes.Size = new Size(200, 20);
                tbDes.Text = dataGridView1.Rows[j].Cells[1].Value.ToString();
                //tbDes.Visible = false;
                Controls.Add(tbDes);
                tbDes.BackColor = Color.FromArgb(255, 255, 128);

                //////////////////////////////////////////////////////////
                TextBox tbQty = new TextBox();
                tbQty.Location = new Point(20, k);
                tbQty.Name = "tbQty" + j;
                tbQty.Size = new Size(60, 20);
                tbQty.Text = dataGridView1.Rows[j].Cells[3].Value.ToString() + " x";
                //tbQty.Visible = false;
                Controls.Add(tbQty);
                tbQty.BackColor = Color.FromArgb(192, 255, 192);
                tbQty.MaxLength = 10;

                /////////////////////////////////////////////////////////////////
                TextBox tbPrice = new TextBox();
                tbPrice.Location = new Point(90, k);
                tbPrice.Name = "tbPrice" + j;
                tbPrice.Size = new Size(120, 20);
                tbPrice.Text = correction(dataGridView1.Rows[j].Cells[2].Value.ToString());
                //tbPrice.Visible = false;
                Controls.Add(tbPrice);
                tbPrice.BackColor = Color.FromArgb(192, 255, 255);
                tbPrice.MaxLength = 10;
                ////////////////////////////////////////////////  


                /////////////////////////////////////////////////////////////////
                TextBox tbAmt = new TextBox();
                tbAmt.Location = new Point(190, k);
                tbAmt.Name = "tbAmt" + j;
                tbAmt.Size = new Size(120, 20);
                tbAmt.Text = correction(dataGridView1.Rows[j].Cells[4].Value.ToString());
                //tbAmt.Visible = false;
                Controls.Add(tbAmt);
                tbAmt.BackColor = Color.FromArgb(192, 255, 255);
                tbAmt.MaxLength = 10;
                ///////////////////////////////////////////////////////////////////             


                laLine.Location = new Point(3, k + 15);

                laTotal.Location = new Point(7, k + 30);
                laDiscount.Location = new Point(7, k + 50);
                laNetTotla.Location = new Point(7, k + 70);
                laCash.Location = new Point(7, k + 90);
                laBalance.Location = new Point(7, k + 110);

                laDot.Location = new Point(3, k + 125);

                //laItems.Location = new Point(5, k + 135);
                //laPcs.Location = new Point(175, k + 135);

                laThank.Location = new Point(50, k + 140);
                laDot1.Location = new Point(3, k + 155);
                laBy.Location = new Point(50, k + 165);
                //laBy2.Location = new Point(74, k + 200);
                //laDot2.Location = new Point(3, k + 215);
                //laShan.Location = new Point(7, k + 225);

                textBox1.Location = new Point(190, k + 28);
                textBox2.Location = new Point(190, k + 48);
                textBox3.Location = new Point(190, k + 68);
                textBox4.Location = new Point(190, k + 88);
                textBox5.Location = new Point(190, k + 108);


                textBox1.Text = correction(Convert.ToDecimal(textBoxTotGrosse.Text).ToString("0.00"));
                textBox2.Text = correction(Convert.ToDecimal(textBoxTotDiscount.Text).ToString("0.00"));
                textBox3.Text = correction(Convert.ToDecimal(textBoxTotNet.Text).ToString("0.00"));
                textBox4.Text = correction(Convert.ToDecimal(textBoxCash.Text).ToString("0.00"));
                textBox5.Text = correction(Convert.ToDecimal(textBoxBalance.Text).ToString("0.00"));
            }
        }


        void DrawForm(Graphics g, int resX, int resY)
        {

            g.DrawRectangle(new Pen(Color.Green), -1, -1, this.Width + 500, this.Height + 1000);

            foreach (Control c in Controls)
            {
                string strType = c.GetType().ToString().Substring(c.GetType().ToString().LastIndexOf(".") + 1);
                switch (strType)
                {
                    case "TextBox":
                        TextBox t = (TextBox)c;
                        g.DrawString(t.Text, t.Font, new SolidBrush(t.ForeColor), t.Left, t.Top + t.Height / 2 - g.MeasureString("a", t.Font).Height / 2, new StringFormat());
                        break;
                    case "Label":
                        Label b = (Label)c;
                        g.DrawString(b.Text, b.Font, new SolidBrush(b.ForeColor), b.Left + b.Width / 2 - g.MeasureString(b.Text, b.Font).Width / 2, b.Top + b.Height / 2 - g.MeasureString("a", b.Font).Height / 2, new StringFormat());
                        break;
                }
            }
        }

        public string correction(string str)
        {
            string[] word = str.Split('.');
            int a = word[0].Length;
            if (a == 1)
            {
                str = "        " + str;
            }
            if (a == 2)
            {
                str = "      " + str;
            }
            if (a == 3)
            {
                str = "    " + str;
            }
            if (a == 4)
            {
                str = "  " + str;
            }
            if (a == 5)
            {
                str = "" + str;
            }
            return str;
        }

        private void SaveSOHD()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                if (radioButtonTA.Checked == true)
                {
                    objInvBAL.BillMode = "Takeaway";
                    objInvBAL.Steward = 0;
                }
                if (radioButtonTable.Checked == true)
                {
                    objInvBAL.BillMode = "Table";
                }
                if (radioButtonTable.Checked == true && comboBoxSteward.SelectedIndex != -1)
                {
                    objInvBAL.Steward = Convert.ToInt32(comboBoxSteward.SelectedValue.ToString());
                }
                objInvBAL.BillNo = Convert.ToInt32(textBoxInvoiceNo.Text);
                objInvBAL.SOGrossTotal = Convert.ToDecimal(textBoxTotGrosse.Text);
                objInvBAL.ServiceCharges = Convert.ToDecimal(textBoxServiceChgs.Text);
                objInvBAL.SODiscount = Convert.ToDecimal(textBoxTotDiscount.Text);
                objInvBAL.SONetTotal = Convert.ToDecimal(textBoxTotNet.Text);
                objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.Insertsohd(objInvBAL);
                if (count != 0)
                {
                    SaveSODT();
                    fillBillNo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillBillNo()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                invoiceNo = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]) + 1;
                sohdid = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[0].Rows[0][0]);
                textBoxInvoiceNo.Text = invoiceNo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSODT()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                sohdid = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[0].Rows[0][0]);
                if (radioButtonTA.Checked == true)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.SOHDId = Convert.ToInt32(sohdid);//lblUserId.Tex
                        objInvBAL.ItemCode = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                        objInvBAL.SalesQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                        objInvBAL.SalesPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                        objInvBAL.Discount = Convert.ToDecimal(0);
                        objInvBAL.NetAmount = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objInvBAL.ItemsId = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                        objInvBAL.ItemCatId = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertSoDt(objInvBAL);
                        if (count != 0)
                        {
                            savestate = true;

                        }
                    }

                    if (savestate == true)
                    {
                        //MessageBox.Show("Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //buttonPrint.Enabled = true;
                        ReprintTakeawayKOT();
                    }
                }
                else if (radioButtonTable.Checked == true)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        objInvBAL = new ClassInvoiceBAL();
                        objInvBAL.SOHDId = Convert.ToInt32(sohdid);//lblUserId.Tex
                        objInvBAL.ItemCode = dataGridView2.Rows[i].Cells[0].Value.ToString().Trim();
                        objInvBAL.SalesQty = Convert.ToDecimal(dataGridView2.Rows[i].Cells[2].Value);
                        objInvBAL.SalesPrice = Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value);
                        objInvBAL.Discount = Convert.ToDecimal(0);
                        objInvBAL.NetAmount = Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value);
                        objInvBAL.CreatedBy = Convert.ToInt32(lblUserId.Text);
                        objInvBAL.ItemsId = Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
                        objInvBAL.ItemCatId = Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value);
                        objInvDAL = new ClassInvoiveDAL();
                        int count = objInvDAL.InsertSoDt(objInvBAL);
                        if (count != 0)
                        {
                            savestate = true;
                        }
                    }

                    if (savestate == true)
                    {
                        //MessageBox.Show("Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //buttonPrint.Enabled = true;
                        DeleteTableData();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveOpenBalance()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();

                objInvBAL.UserId = Convert.ToInt32(lblUserId.Text);//lblUserId.Text
                objInvBAL.OpeningBalance = Convert.ToDecimal(textBoxOpeningBalance.Text);
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.InsertOpeningBalance(objInvBAL);
                if (count != 0)
                {

                    MessageBox.Show("Opening Balance Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonopening.Enabled = false;
                    buttonPrint.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printInvoice()
        {
            if (radioButtonTA.Checked == true)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportTAWInvoice rpt = new CrystalReportTAWInvoice();
                    objBAL = new ClassPOBAL();
                    objBAL.SOHDId = Convert.ToInt32(sohdid);
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    //crystalReportViewer1.PrintReport();
                    rpt.PrintToPrinter(1, false, 0, 0);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButtonTable.Checked == true)
            {
                try
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    //CrystalReportTableInvoice rpt = new CrystalReportTableInvoice();
                    //objBAL = new ClassPOBAL();
                    //objBAL.SOHDId = Convert.ToInt32(sohdid);
                    //objDAL = new ClassPODAL();
                    //objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                    //rpt.SetDataSource(objBAL.DtDataSet);
                    //crystalReportViewer1.ReportSource = rpt;
                    //crystalReportViewer1.Refresh();
                    ////crystalReportViewer1.PrintReport();
                    //rpt.PrintToPrinter(1, false, 0, 0);

                    //Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ReprintInvoice()
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //CrystalReportTableInvoice rpt = new CrystalReportTableInvoice();
                //objBAL = new ClassPOBAL();
                //objBAL.SOHDId = Convert.ToInt32(textBoxReprint.Text);
                //objDAL = new ClassPODAL();
                //objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //rpt.SetDataSource(objBAL.DtDataSet);
                //crystalReportViewer1.ReportSource = rpt;
                //crystalReportViewer1.Refresh();
                ////crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);

                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReprintTableKOT()
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //CrystalReportKOT rpt = new CrystalReportKOT();
                //objBAL = new ClassPOBAL();
                //objBAL.TblNo = comboBoxTblNo.Text;
                //objDAL = new ClassPODAL();
                //objBAL.DtDataSet = objDAL.retreiveTableRptData(objBAL);
                //rpt.SetDataSource(objBAL.DtDataSet);
                //crystalReportViewer1.ReportSource = rpt;
                //crystalReportViewer1.Refresh();
                ////crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);

                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReprintTakeawayKOT()
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //CrystalReportTAWKOT rpt = new CrystalReportTAWKOT();
                //objBAL = new ClassPOBAL();
                //objBAL.SOHDId = Convert.ToInt32(sohdid);
                //objDAL = new ClassPODAL();
                //objBAL.DtDataSet = objDAL.retreiveTakeawayRptData(objBAL);
                //rpt.SetDataSource(objBAL.DtDataSet);
                //crystalReportViewer1.ReportSource = rpt;
                //crystalReportViewer1.Refresh();
                ////crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);

                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printTakeAwayInvoice()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportTAWInvoice rpt = new CrystalReportTAWInvoice();
                objBAL = new ClassPOBAL();
                objBAL.SOHDId = Convert.ToInt32(sohdid);
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                //crystalReportViewer1.PrintReport();
                rpt.PrintToPrinter(1, false, 0, 0);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printTableInvoice()
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //CrystalReportTableInvoice rpt = new CrystalReportTableInvoice();
                //objBAL = new ClassPOBAL();
                //objBAL.SOHDId = Convert.ToInt32(sohdid);
                //objDAL = new ClassPODAL();
                //objBAL.DtDataSet = objDAL.retreiveTAWInvoiceData(objBAL);
                //rpt.SetDataSource(objBAL.DtDataSet);
                //crystalReportViewer1.ReportSource = rpt;
                //crystalReportViewer1.Refresh();
                ////crystalReportViewer1.PrintReport();
                //rpt.PrintToPrinter(1, false, 0, 0);

                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            textBoxItemCode.Clear();
            textBoxItemName.Clear();
            textBoxQty.Text = "0";
            textBoxSellingPrice.Text = "0";
            comboBoxItemCat.SelectedIndex = -1;
            labelItemId.Text = "0";
        }

        private void TakeAwNetTotal()
        {
            try
            {
                textBoxTotNet.Text = ((Convert.ToDecimal(textBoxTotGrosse.Text)) - (Convert.ToDecimal(textBoxTotDiscount.Text))).ToString("0.00");
                //textBoxBalance.Text = (Convert.ToDecimal(textBoxCash.Text) - Convert.ToDecimal(textBoxTotNet.Text)).ToString("0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TableNetTotal()
        {
            try
            {
                if (comboBoxTblCat.Text == "Drinks")
                {
                    textBoxServiceChgs.Text = (Convert.ToDecimal(textBoxTotGrosse.Text) * 10 / 100).ToString("0.00");
                }
                textBoxTotNet.Text = ((Convert.ToDecimal(textBoxTotGrosse.Text) + Convert.ToDecimal(textBoxServiceChgs.Text)) - (Convert.ToDecimal(textBoxTotDiscount.Text))).ToString("0.00");
                //textBoxBalance.Text = (Convert.ToDecimal(textBoxCash.Text) - Convert.ToDecimal(textBoxTotNet.Text)).ToString("0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void fillCashBalance()
        {
            try
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.UserId = Convert.ToInt32(lblUserId.Text.Trim());
                objInvBAL.DtDataSet = objInvDAL.SelectCashBalnce(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    lblopenbalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][0].ToString()).ToString("0.00");
                    lblreciveAmount.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][1].ToString()).ToString("0.00");
                    lblPayments.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][2].ToString()).ToString("0.00");
                    lblCashBalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][3].ToString()).ToString("0.00");

                    if (Convert.ToDecimal(lblCashBalance.Text) > 0)
                    {
                        buttonopening.Enabled = false;
                        buttonPrint.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetItemCodeData()
        {
            comboBoxItemCat.SelectedIndex = -1;
            labelItemId.Text = "0";
            textBoxItemName.Clear();
            comboBoxPortion.Text = "";
            textBoxSellingPrice.Text = "0.00";
        }

        private void fillItemCodeData()
        {
            try
            {
                resetItemCodeData();
                objBAL = new ClassPOBAL();
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCodeData(objBAL);
                if (objBAL.DtDataSet.Tables[2].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objBAL.DtDataSet.Tables[2].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);
                        labelItemId.Text = (values[0].ToString().Trim());
                        comboBoxItemCat.SelectedValue = (values[1].ToString());
                        textBoxItemName.Text = (values[2].ToString().Trim());
                        if ((values[3].ToString()) == "S")
                        {
                            comboBoxPortion.Text = "Small";
                        }
                        if ((values[3].ToString()) == "M")
                        {
                            comboBoxPortion.Text = "Medium";
                        }
                        if ((values[3].ToString()) == "L")
                        {
                            comboBoxPortion.Text = "Large";
                        }
                        textBoxSellingPrice.Text = (values[5].ToString().Trim());
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrinterResolution pr = e.PageSettings.PrinterResolution;
            DrawForm(e.Graphics, pr.X, pr.Y);
        }

        private void textBoxItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    fillItemCodeData();
                    textBoxQty.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonAdd_Click(sender, e);
            }
        }

        private void comboBoxPayMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Exit this Invoice Window", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                objInvBAL = new ClassInvoiceBAL();
                objInvBAL.UserId = Convert.ToInt32(lblUserId.Text);
                objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteCashBalance(objInvBAL);
                if (count != 0)
                {
                    this.Close();

                }
            }
        }

        private void radioButtonTable_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTable.Checked == true)
            {
                textBoxItemCode.Enabled = true;
                ButtonAdd.Enabled = true;
                buttonAddToTable.Enabled = true;
                groupBox3.Enabled = true;

                comboBoxTblNo.Text = "";
                comboBoxTblCat.Text = "";
                textBoxNoOfCust.Clear();
                comboBoxSteward.SelectedIndex = -1;
                textBoxTblStatus.Clear();
                textBoxTblStatus.BackColor = Color.White;
                dataGridView2.DataSource = null;
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                row = 0;
                textBoxTotGrosse.Text = "0.00";
                textBoxServiceChgs.Text = "0.00";
                textBoxTotDiscount.Text = "0.00";
                textBoxTotNet.Text = "0.00";
                textBoxCash.Text = "0.00";
                textBoxBalance.Text = "0.00";
                row = 0;
                total = 0;
            }
        }

        private void radioButtonTA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTA.Checked == true)
            {
                textBoxItemCode.Enabled = true;
                ButtonAdd.Enabled = true;
                buttonAddToTable.Enabled = false;
                groupBox3.Enabled = false;

                comboBoxTblNo.Text = "";
                comboBoxTblCat.Text = "";
                textBoxNoOfCust.Clear();
                comboBoxSteward.SelectedIndex = -1;
                textBoxTblStatus.Clear();
                textBoxTblStatus.BackColor = Color.White;
                dataGridView2.DataSource = null;
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                row = 0;
                textBoxTotGrosse.Text = "0.00";
                textBoxServiceChgs.Text = "0.00";
                textBoxTotDiscount.Text = "0.00";
                textBoxTotNet.Text = "0.00";
                textBoxCash.Text = "0.00";
                textBoxBalance.Text = "0.00";
                row = 0;
                total = 0;
            }
        }

        private void textBoxTotDiscount_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonTA.Checked == true)
            {
                TakeAwNetTotal();
            }
            else if (radioButtonTable.Checked == true)
            {
                TableNetTotal();
            }
        }

        private void buttonAddToTable_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool isValid = ValidateTableNo() &&
                ValidateTableCategory() &&
                ValidateTableSteward();
            if (isValid)
            {
                SaveTable();
                fillTableData();
                ReprintTableKOT();
                UpdateTableKOT();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                row = 0;
                textBoxTotGrosse.Text = "0.00";
                textBoxServiceChgs.Text = "0.00";
                textBoxTotDiscount.Text = "0.00";
                textBoxTotNet.Text = "0.00";
                textBoxCash.Text = "0.00";
                textBoxBalance.Text = "0.00";
                Clear();
            }
        }

        private void SaveTable()
        {
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.TblNo = comboBoxTblNo.Text.Trim();
                    objInvBAL.TblCategory = comboBoxTblCat.Text.Trim();
                    objInvBAL.NoOfCustomers = Convert.ToInt32(textBoxNoOfCust.Text);
                    objInvBAL.Steward = Convert.ToInt32(comboBoxSteward.SelectedValue.ToString());
                    objInvBAL.ItemsId = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    objInvBAL.ItemCode = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                    objInvBAL.ItemCatId = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                    objInvBAL.Price = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    objInvBAL.SalesQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    objInvBAL.SalesAmount = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);

                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertTable(objInvBAL);
                    if (count != 0)
                    {
                        savestate = true;

                    }
                }

                if (savestate == true)
                {
                    //MessageBox.Show("Saved Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //buttonPrint.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTableKOT()
        {
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.TblNo = comboBoxTblNo.Text.Trim();
                    objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.UpdateTableKOT(objInvBAL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillTableData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                comboBoxTblCat.Text = "";
                textBoxNoOfCust.Clear();
                comboBoxSteward.SelectedIndex = -1;
                textBoxTblStatus.Clear();
                textBoxTblStatus.BackColor = Color.White;
                dataGridView2.DataSource = null;

                objBAL = new ClassPOBAL();
                objBAL.TblNo = comboBoxTblNo.Text.Trim();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveTableData(objBAL);
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
                        comboBoxTblCat.Text = (values[0].ToString().Trim());
                        textBoxNoOfCust.Text = (values[1].ToString().Trim());
                        comboBoxSteward.SelectedValue = (values[2].ToString());
                        if ((values[2].ToString()) == "1")
                        {
                            textBoxTblStatus.Text = "Fill";
                            textBoxTblStatus.BackColor = Color.Red;
                        }

                    }

                    dataGridView2.DataSource = objBAL.DtDataSet.Tables[1];
                    dataGridView2.Columns["Price"].Visible = false;
                    dataGridView2.Columns["ItemsId"].Visible = false;
                    dataGridView2.Columns["ItemCatId"].Visible = false;
                    dataGridView2.Columns["SalesQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView2.Columns["SalesAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dataGridView2.DefaultCellStyle.BackColor = Color.Empty;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
                else
                {
                    textBoxTblStatus.Text = "Free";
                    textBoxTblStatus.BackColor = Color.Green;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillTableTotal()
        {
            try
            {
                textBoxTotGrosse.Text = "0.00";
                textBoxServiceChgs.Text = "0.00";
                textBoxTotDiscount.Text = "0.00";
                textBoxTotNet.Text = "0.00";
                textBoxCash.Text = "0.00";
                textBoxBalance.Text = "0.00";

                if (dataGridView2.Rows.Count > 0)
                {
                    
                    decimal total = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        total = Convert.ToDecimal(dataGridView2["SalesAmount", i].Value.ToString()) + total;
                    }
                    textBoxTotGrosse.Text = total.ToString();
                    TableNetTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteTableData()
        {
            try
            {
                objBAL = new ClassPOBAL();
                objBAL.TblNo = comboBoxTblNo.Text;
                objDAL = new ClassPODAL();
                int count = objDAL.DeleteTableData(objBAL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            textBoxBalance.Text = (Convert.ToDecimal(textBoxCash.Text) - Convert.ToDecimal(textBoxTotNet.Text)).ToString("0.00");
        }

        private void buttonNew1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            row = 0;
            textBoxTotGrosse.Text = "0.00";
            textBoxServiceChgs.Text = "0.00";
            textBoxTotDiscount.Text = "0.00";
            textBoxTotNet.Text = "0.00";
            textBoxCash.Text = "0.00";
            textBoxBalance.Text = "0.00";
            Clear();
        }

        private void textBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonTA.Checked == true)
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("Please add items.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {


                        sohdid = 0;
                        SaveSOHD();

                        DialogResult result = MessageBox.Show("Print this Invoice ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {

                            laDate.Text = DateTime.Now.ToShortDateString();
                            laTime.Text = DateTime.Now.ToLongTimeString();
                            lblbillno.Text = textBoxInvoiceNo.Text;
                            //sets();
                            //printDocument1.PrintPage += printDocument1_PrintPage;
                            //printDocument1.Print();

                            printInvoice();
                        }

                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        row = 0;
                        textBoxTotGrosse.Text = "0.00";
                        textBoxServiceChgs.Text = "0.00";
                        textBoxTotDiscount.Text = "0.00";
                        textBoxTotNet.Text = "0.00";
                        textBoxCash.Text = "0.00";
                        textBoxBalance.Text = "0.00";
                        row = 0;
                        total = 0;

                        objInvBAL = new ClassInvoiceBAL();
                        objInvDAL = new ClassInvoiveDAL();
                        invoiceNo = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]) + 1;
                        textBoxInvoiceNo.Text = invoiceNo.ToString();



                        objInvBAL = new ClassInvoiceBAL();
                        objInvDAL = new ClassInvoiveDAL();
                        objInvBAL.UserId = Convert.ToInt32(lblUserId.Text.Trim());
                        objInvBAL.DtDataSet = objInvDAL.SelectCashBalnce(objInvBAL);
                        if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                        {
                            lblopenbalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][0].ToString()).ToString("0.00");
                            lblreciveAmount.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][1].ToString()).ToString("0.00");
                            lblPayments.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][2].ToString()).ToString("0.00");
                            lblCashBalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][3].ToString()).ToString("0.00");
                        }
                    }
                }
                else if (radioButtonTable.Checked == true)
                {
                    if (dataGridView2.Rows.Count == 0)
                    {
                        MessageBox.Show("Please add items.", "Invalid Null", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {


                        sohdid = 0;
                        SaveSOHD();

                        DialogResult result = MessageBox.Show("Print this Invoice ", "Print Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {

                            //laDate.Text = DateTime.Now.ToShortDateString();
                            //laTime.Text = DateTime.Now.ToLongTimeString();
                            //lblbillno.Text = textBoxInvoiceNo.Text;
                            //sets();


                            //printDocument1.PrintPage += printDocument1_PrintPage;
                            //printDocument1.Print();

                            printInvoice();
                        }

                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        row = 0;
                        textBoxTotGrosse.Text = "0.00";
                        textBoxServiceChgs.Text = "0.00";
                        textBoxTotDiscount.Text = "0.00";
                        textBoxTotNet.Text = "0.00";
                        textBoxCash.Text = "0.00";
                        textBoxBalance.Text = "0.00";
                        row = 0;
                        total = 0;

                        objInvBAL = new ClassInvoiceBAL();
                        objInvDAL = new ClassInvoiveDAL();
                        invoiceNo = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]) + 1;
                        textBoxInvoiceNo.Text = invoiceNo.ToString();



                        objInvBAL = new ClassInvoiceBAL();
                        objInvDAL = new ClassInvoiveDAL();
                        objInvBAL.UserId = Convert.ToInt32(lblUserId.Text.Trim());
                        objInvBAL.DtDataSet = objInvDAL.SelectCashBalnce(objInvBAL);
                        if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                        {
                            lblopenbalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][0].ToString()).ToString("0.00");
                            lblreciveAmount.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][1].ToString()).ToString("0.00");
                            lblPayments.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][2].ToString()).ToString("0.00");
                            lblCashBalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][3].ToString()).ToString("0.00");
                        }
                    }
                    comboBoxTblNo.Text = "";
                    comboBoxTblCat.Text = "";
                    textBoxNoOfCust.Clear();
                    comboBoxSteward.SelectedIndex = -1;
                    textBoxTblStatus.Clear();
                    textBoxTblStatus.BackColor = Color.White;
                    dataGridView2.DataSource = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if ((textBoxItemCode.Text == "") || (textBoxQty.Text == "") || (textBoxItemName.Text == "") || (textBoxSellingPrice.Text == ""))
            {
                MessageBox.Show("Please Check Invoice Items", "Check the Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                bool isvalid = ValidateDuplicate();
                if (isvalid)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Cells[0].Value = textBoxItemCode.Text;
                    dataGridView1.Rows[row].Cells[1].Value = textBoxItemName.Text;
                    dataGridView1.Rows[row].Cells[2].Value = Convert.ToDecimal(textBoxSellingPrice.Text).ToString("0.00");
                    dataGridView1.Rows[row].Cells[3].Value = Convert.ToDecimal(textBoxQty.Text).ToString("0.00");
                    dataGridView1.Rows[row].Cells[4].Value = (Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxSellingPrice.Text)).ToString("0.00");
                    dataGridView1.Rows[row].Cells[5].Value = labelItemId.Text;
                    dataGridView1.Rows[row].Cells[6].Value = comboBoxItemCat.SelectedValue.ToString();
                    textBoxItemCode.Select();
                    if (radioButtonTA.Checked == true)
                    {
                        total = total + Convert.ToDecimal(textBoxQty.Text) * Convert.ToDecimal(textBoxSellingPrice.Text);
                        textBoxTotGrosse.Text = total.ToString("0.00");
                        TakeAwNetTotal();
                    }
                    row++;
                    Clear();
                }
            }

        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                loadStatus = true;
                textBoxItemCode.Select();
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();

                comboBoxItemCat.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[3];
                comboBoxItemCat.DisplayMember = "ItemCatName";
                comboBoxItemCat.ValueMember = "ItemCatId";
                comboBoxItemCat.SelectedIndex = -1;

                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                comboBoxSteward.DataSource = objInvDAL.retreiveInvoiceLoadingData(objInvBAL).Tables[0];
                comboBoxSteward.DisplayMember = "EmployeeName";
                comboBoxSteward.ValueMember = "EmployeeID";
                comboBoxSteward.SelectedIndex = -1;

                objInvBAL = new ClassInvoiceBAL();
                objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.SelectMaxSOHDandBillNO(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[1].Rows.Count > 0)
                {
                    invoiceNo = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]) + 1;
                    textBoxInvoiceNo.Text = invoiceNo.ToString();
                }

                fillCashBalance();
                loadStatus = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.reportViewer1.RefreshReport();
        }

        private void textBoxItemCode_Validating(object sender, CancelEventArgs e)
        {
            fillItemCodeData();
            textBoxQty.Select();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            total = total - Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            textBoxTotGrosse.Text = total.ToString("0.00");
            if (radioButtonTA.Checked == true)
            {
                TakeAwNetTotal();
            }
            dataGridView1.Rows.RemoveAt(e.RowIndex);
            row--;
        }

        private void buttonopening_Click(object sender, EventArgs e)
        {
            SaveOpenBalance();

            objInvBAL = new ClassInvoiceBAL();
            objInvDAL = new ClassInvoiveDAL();
            objInvBAL.UserId = Convert.ToInt32(lblUserId.Text.Trim());
            objInvBAL.DtDataSet = objInvDAL.SelectCashBalnce(objInvBAL);
            if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
            {
                lblopenbalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][0].ToString()).ToString("0.00");
                lblreciveAmount.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][1].ToString()).ToString("0.00");
                lblPayments.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][2].ToString()).ToString("0.00");
                lblCashBalance.Text = Convert.ToDecimal(objInvDAL.SelectCashBalnce(objInvBAL).Tables[0].Rows[0][3].ToString()).ToString("0.00");
            }
            textBoxOpeningBalance.Clear();
        }

        #endregion

        #region Validation Methods

        private bool ValidateDuplicate()
        {
            textBoxItemCode.Text = textBoxItemCode.Text.Trim();
            string errorCode = string.Empty;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Trim() == textBoxItemCode.Text.Trim())
                {
                    errorCode = "This item already Added to this invoice";
                }
            }
            string message = errorCode;
            errorProvider1.SetError(textBoxItemCode, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateTableNo()
        {
            comboBoxTblNo.Text = comboBoxTblNo.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxTblNo.Text)) || (comboBoxTblNo.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Table No.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxTblNo, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateTableCategory()
        {
            comboBoxTblCat.Text = comboBoxTblCat.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxTblCat.Text)) || (comboBoxTblCat.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Category.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxTblCat, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateTableSteward()
        {
            comboBoxSteward.Text = comboBoxSteward.Text.Trim();
            string errorCode = string.Empty;
            if ((string.IsNullOrEmpty(comboBoxSteward.Text)) || (comboBoxSteward.Text.Trim().Equals(string.Empty)))
            {
                errorCode = "Please Select Steward.";
            }
            string message = errorCode;
            errorProvider1.SetError(comboBoxSteward, message);
            if (message.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void comboBoxTblNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTblNo.Text != "")
            {
                fillTableData();
                fillTableTotal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReprintInvoice();
        }

        private void textBoxTotDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxReprint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxNoOfCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            Cursor.Current = Cursors.Default;
        }

    }
}
