using easyBAL;
using easyDAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace easyPOSSolution
{
    public partial class FrmBarcode : Form
    {
        string InternalCode = "";
        decimal SelPrice = 0;
        int ItemId = 0;
        bool savestate, autocomplete;

        ArrayList alistForm = new ArrayList();

        public FrmBarcode()
        {
            InitializeComponent();
        }

        private void ExporttoCSV()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    csv += column.HeaderText + ',';
                }

                //Add new line.
                csv += "\r\n";

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //Add the Data rows.
                        csv += cell.Value.ToString().Replace(",", ";") + ',';
                    }

                    //Add new line.
                    csv += "\r\n";
                }

                //Exporting to CSV.
                string folderPath = "C:\\CSV\\";
                File.WriteAllText(folderPath + "BarcodeFile.csv", csv);
                MessageBox.Show("Ready to Print.");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FrmBarcode_Load(object sender, EventArgs e)
        {
            //Barcodes barcodeDetails = new Barcodes();
            //DataTable dataTable = barcodeDetails._Barcodes;

            //BarcodeReport Report = new BarcodeReport();

            //int blank_labels = 0;
            //int numberLabel = Convert.ToInt32(textBoxNumber.Text);
            //for (int i = 0; i < numberLabel; i++)
            //{
            //    DataRow drow = dataTable.NewRow();
            //    string ItemCode = textBox1.Text.Trim();
            //    if (blank_labels <= i)
            //    {
            //        drow["Barcode"] = "*";
            //        drow["Barcode"] += ItemCode;
            //        drow["Barcode"] += "*";

            //        drow["ProductId"] = ItemCode;
            //        drow["Cost"] = "Rs. " + tbPrice.Text;
            //        drow["ShopName"] = textBox_CompanyName.Text;
            //    }
            //    dataTable.Rows.Add(drow);
            //}

            //Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);


            //crystalReportViewer1.ReportSource = Report;
            //crystalReportViewer1.Refresh();
            //ItemAutoComplete();
            fillCompanyInfo();
            //textBox_CompanyName.Text = "MILLY";
            //textBoxNumber.Select();
            buttonStart.Select();
        }

        private void fillCompanyInfo()
        {
            try
            {
                BALUser objUser = new BALUser();
                DALUser dalUser = new DALUser();
                objUser.DtDataSet = dalUser.retreiveCompanyInfo(objUser);
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
                        textBox_CompanyName.Text = (values[1].ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ItemAutoComplete()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemName(objInvBAL);

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
                        textBoxItemCode1.AutoCompleteCustomSource.Add(values[1].ToString());
                        textBoxItemName1.AutoCompleteCustomSource.Add(values[2].ToString());
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; 
            Barcodes barcodeDetails = new Barcodes();
            DataTable dataTable = barcodeDetails._Barcodes;

            BarcodeReport1 Report = new BarcodeReport1();

            int blank_labels = 0;
            int numberLabel = Convert.ToInt32(textBoxNumber.Text);
            for (int i = 0; i < numberLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                string ItemCode = textBox1.Text.Trim();
                if (blank_labels <= i)
                {
                    drow["Barcode"] = "*";
                    drow["Barcode"] += ItemCode;
                    drow["Barcode"] += "*";

                    drow["ProductId"] = ItemCode;
                    drow["Cost"] = "Rs. " + tbPrice.Text;
                    drow["ShopName"] = textBox_CompanyName.Text;
                    drow["ItemName"] = textBoxItemName.Text;
                    drow["InternalCode"] = textBoxInternalCode.Text;
                }
                dataTable.Rows.Add(drow);
            }

            Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);


            crystalReportViewer1.ReportSource = Report;
            crystalReportViewer1.Refresh();

            Cursor.Current = Cursors.Default;
            textBoxNumber.Select();
        }

        private void textBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }
        }

        private void textBox_CompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Barcodes barcodeDetails = new Barcodes();
            DataTable dataTable = barcodeDetails._Barcodes;

            BarcodeReport Report = new BarcodeReport();

            int blank_labels = 0;
            int numberLabel = Convert.ToInt32(textBoxNumber.Text);
            for (int i = 0; i < numberLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                string ItemCode = textBox1.Text.Trim();
                if (blank_labels <= i)
                {
                    drow["Barcode"] = "*";
                    drow["Barcode"] += ItemCode;
                    drow["Barcode"] += "*";

                    drow["ProductId"] = ItemCode;
                    drow["Cost"] = "Rs. " + tbPrice.Text;
                    drow["ShopName"] = textBox_CompanyName.Text;
                }
                dataTable.Rows.Add(drow);
            }

            Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);


            crystalReportViewer1.ReportSource = Report;
            crystalReportViewer1.Refresh();

            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Barcodes barcodeDetails = new Barcodes();
            DataTable dataTable = barcodeDetails._Barcodes;

            BarcodeReport2 Report = new BarcodeReport2();

            int blank_labels = 0;
            int numberLabel = Convert.ToInt32(textBoxNumber.Text);
            for (int i = 0; i < numberLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                string ItemCode = textBox1.Text.Trim();
                if (blank_labels <= i)
                {
                    drow["Barcode"] = "*";
                    drow["Barcode"] += ItemCode;
                    drow["Barcode"] += "*";

                    drow["ProductId"] = ItemCode;
                    drow["Cost"] = "Rs. " + tbPrice.Text;
                    drow["ShopName"] = textBox_CompanyName.Text;
                    drow["ItemName"] = textBoxItemName.Text;
                    drow["InternalCode"] = textBoxInternalCode.Text;
                }
                dataTable.Rows.Add(drow);
            }

            Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);


            crystalReportViewer1.ReportSource = Report;
            crystalReportViewer1.Refresh();

            Cursor.Current = Cursors.Default;
            textBoxNumber.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBarCode frm = new FormBarCode();
            frm.comboBox1.Text = textBoxItemName.Text;
            frm.textBox1.Text = textBox1.Text;
            frm.tbPrice.Text = tbPrice.Text;
            frm.textBoxNumber.Text = textBoxNumber.Text;
            frm.frm = this;
            frm.ShowDialog(this);
        }

        private void textBoxItemCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                if (textBoxItemCode1.Text != "")
                {
                    textBoxItemName1.Text = "";
                    textBoxNoOfPeases1.Text = "0";
                    textBoxStart.Text = "0";
                    textBoxEnd.Text = "0";

                    SearchItem();
                }
                else if (textBoxItemCode1.Text == "" && dgView.Rows.Count > 0)
                {
                    //lblCashTender.Select();
                }
            }
        }

        void SearchItem()
        {
            try
            {
                textBoxItemName1.Clear();
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemCode = textBoxItemCode1.Text;
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsData(objInvBAL);
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

                        textBoxItemName1.Text = (values[0].ToString().Trim());
                        SelPrice = Convert.ToDecimal(values[1].ToString().Trim());
                        ItemId = Convert.ToInt32(values[2].ToString().Trim());
                        InternalCode = (values[18].ToString().Trim());
                    }
                }

                textBoxNoOfPeases1.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void SearchItemByName()
        {
            try
            {
                textBoxItemCode1.Clear();
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                objInvBAL.ItemName = textBoxItemName1.Text.Trim();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                objInvBAL.DtDataSet = objInvDAL.retreiveItemsDataByName(objInvBAL);
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
                        textBoxItemCode1.Text = (values[0].ToString().Trim());
                    }
                }
                textBoxNoOfPeases1.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AddtoGrid()
        {
            try
            {
                int n = dgView.Rows.Add();
                //int intQtyOrdered = int.Parse(txtQty.Text);

                dgView.Rows[n].Cells["ItemCode"].Value = textBoxItemCode1.Text;
                dgView.Rows[n].Cells["ItemName"].Value = textBoxItemName1.Text;
                dgView.Rows[n].Cells["InternalNo"].Value = InternalCode.ToString();
                dgView.Rows[n].Cells["BCQty"].Value = textBoxNoOfPeases1.Text;
                dgView.Rows[n].Cells["BCPrice"].Value = SelPrice.ToString();
                dgView.Rows[n].Cells["BCStart"].Value = textBoxStart.Text;
                dgView.Rows[n].Cells["BCEnd"].Value = textBoxEnd.Text;
                dgView.Rows[n].Cells["ItemsId"].Value = ItemId.ToString();
                dgView.FirstDisplayedScrollingRowIndex = n;
                dgView.CurrentCell = dgView.Rows[n].Cells[0];
                dgView.Rows[n].Selected = true;

                CalculateTotal();
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

                decimal TotQty = 0;

                int i = dgView.RowCount;

                for (int a = 0; a < i; a++)
                {
                    try
                    {
                        TotQty += Convert.ToDecimal(dgView.Rows[a].Cells["BCQty"].Value.ToString());

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                textBoxTotQty.Text = TotQty.ToString("0.00");

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

                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                    objInvBAL.ItemCode = dgView.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    objInvBAL.ItemName = (dgView.Rows[i].Cells["ItemName"].Value.ToString());
                    objInvBAL.InternalNo = (dgView.Rows[i].Cells["InternalNo"].Value.ToString());
                    objInvBAL.SalesQty = Convert.ToDecimal(dgView.Rows[i].Cells["BCQty"].Value);
                    objInvBAL.SalesPrice = Convert.ToDecimal(dgView.Rows[i].Cells["BCPrice"].Value);
                    objInvBAL.BCStart = Convert.ToInt32(dgView.Rows[i].Cells["BCStart"].Value);
                    objInvBAL.BCEnd = Convert.ToInt32(dgView.Rows[i].Cells["BCEnd"].Value);
                    objInvBAL.ItemsId = Convert.ToInt32(dgView.Rows[i].Cells["ItemsId"].Value);
                    ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                    int count = objInvDAL.InsertBarcodeItem(objInvBAL);
                    if (count != 0)
                    {
                        savestate = true;

                    }
                }

                if (savestate == true)
                {
                    //MessageBox.Show("Selection Success");
                    textBoxItemCode1.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillTempIdData()
        {
            try
            {
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.PIHDId = Convert.ToInt32(textBoxGRNNo.Text);
                ClassPODAL objPODAL = new ClassPODAL();
                objPOBAL.DtDataSet = objPODAL.retreiveGRNBCData(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    List<ArrayList> newval = new List<ArrayList>();
                    foreach (DataRow dRow in objPOBAL.DtDataSet.Tables[0].Rows)
                    {
                        ArrayList values = new ArrayList();
                        values.Clear();
                        foreach (object value in dRow.ItemArray)
                            values.Add(value);
                        newval.Add(values);

                        int n = dgView.Rows.Add();

                        dgView.Rows[n].Cells["ItemCode"].Value = (values[0].ToString().Trim());
                        dgView.Rows[n].Cells["ItemName"].Value = (values[1].ToString().Trim());
                        dgView.Rows[n].Cells["InternalNo"].Value = (values[2].ToString().Trim());
                        dgView.Rows[n].Cells["BCQty"].Value = (values[3].ToString().Trim());
                        dgView.Rows[n].Cells["BCPrice"].Value = (values[4].ToString().Trim());
                        dgView.Rows[n].Cells["BCStart"].Value = 1;
                        dgView.Rows[n].Cells["BCEnd"].Value = 1;
                        dgView.Rows[n].Cells["ItemsId"].Value = (values[5].ToString().Trim());
                        dgView.FirstDisplayedScrollingRowIndex = n;
                        dgView.CurrentCell = dgView.Rows[n].Cells[0];
                        dgView.Rows[n].Selected = true;

                        CalculateTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddtoGrid();
            }
        }

        private void textBoxNoOfPeases1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddtoGrid();
                textBoxItemCode1.Clear();
                textBoxItemName1.Clear();
                textBoxNoOfPeases1.Text = "0";
                //InternalCode = "";
                //SelPrice = 0;
                //textBoxNoOfPeases1.Text = "0";
                textBoxItemCode1.Select();
                
                //textBoxStart.Select();
            }
        }

        private void textBoxStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxEnd.Select();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveSODT();
            fillGrid();
            ExporttoCSV();
            DeleteAll();
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to remove this Item from list?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RemoveItem();
            }
        }

        void RemoveItem()
        {
            try
            {
                if (dgView.SelectedRows.Count > 0)
                {
                    dgView.Rows.RemoveAt(dgView.SelectedRows[0].Index);

                    if (dgView.SelectedRows.Count > 0)
                    {
                        CalculateTotal();
                    }
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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DeleteAll();
            textBoxItemCode1.Enabled = true;
            textBoxItemCode1.Select();
            dgView.Rows.Clear();
        }

        private void DeleteAll()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                int count = objInvDAL.DeleteAllBarcode(objInvBAL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Exporting to CSV.
            string folderPath = "C:\\CSV\\";
            File.WriteAllText(folderPath + "BarcodeFile.csv", csv);
            MessageBox.Show("Ready to Print.");
            Cursor.Current = Cursors.Default;

            //Cursor.Current = Cursors.WaitCursor;
            //fillGrid();
            //Barcodes barcodeDetails = new Barcodes();
            //DataTable dataTable = barcodeDetails._Barcodes;

            //BarcodeReport11 Report = new BarcodeReport11();

            //int blank_labels = 0;
            //int numberLabel = dataGridView1.RowCount;

            //for (int i = 0; i < numberLabel; i++)
            //{
            //    DataRow drow = dataTable.NewRow();
            //    string ItemCode = dataGridView1.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
            //    if (blank_labels <= i)
            //    {
            //        if (ItemCode == "")
            //        {
            //            drow["Barcode"] = "";
            //            drow["Barcode"] += ItemCode;
            //            drow["Barcode"] += "";

            //            drow["ProductId"] = ItemCode;
            //            drow["Cost"] = "";
            //            drow["ShopName"] = "";
            //            drow["ItemName"] = "";
            //            drow["InternalCode"] = "";
            //        }
            //        else
            //        {
            //            drow["Barcode"] = "*";
            //            drow["Barcode"] += ItemCode;
            //            drow["Barcode"] += "*";

            //            drow["ProductId"] = ItemCode;
            //            drow["Cost"] = "Rs. " + dataGridView1.Rows[i].Cells["BCPrice"].Value.ToString();
            //            drow["ShopName"] = textBox_CompanyName.Text;
            //            drow["ItemName"] = dataGridView1.Rows[i].Cells["ItemName"].Value.ToString();
            //            drow["InternalCode"] = dataGridView1.Rows[i].Cells["InternalNo"].Value.ToString();
            //        }
                    
            //    }
            //    dataTable.Rows.Add(drow);
            //}

            //Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);


            //crystalReportViewer1.ReportSource = Report;
            //crystalReportViewer1.Refresh();

            //Cursor.Current = Cursors.Default;
        }

        private void fillGrid()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView1.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveBarcodeItems(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = objInvBAL.DtDataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                try
                {
                    if (textBoxItemCode1.Text != "")
                    {
                        textBoxItemName1.Text = "";
                        textBoxNoOfPeases1.Text = "0";
                        textBoxStart.Text = "0";
                        textBoxEnd.Text = "0";

                        SearchItem();
                    }
                    else if (textBoxItemCode1.Text == "")
                    {
                        button5.Select();
                    }
                    else if (textBoxItemCode1.Text == "" && dgView.Rows.Count > 0)
                    {
                        //lblCashTender.Select();
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        private void textBoxItemName1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SearchItemByName();
                if (textBoxItemCode1.Text != "")
                {
                    textBoxItemName1.Text = "";
                    textBoxNoOfPeases1.Text = "0";
                    textBoxStart.Text = "0";
                    textBoxEnd.Text = "0";

                    SearchItem();
                }
                else
                {
                    button5.Select();
                }
            }
        }

        private void FrmBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode1.Select();
                FormItemSearch frm3 = new FormItemSearch();
                frm3.frm3 = this;
                frm3.form = 3;
                frm3.wh = 1;
                frm3.lblUser.Text = lblUser.Text;
                frm3.lblUserId.Text = "3";
                frm3.ShowDialog(this);
            }
        }

        public void ItemCodeKeyDown()
        {
            try
            {
                if (textBoxItemCode1.Text != "")
                {
                    textBoxItemName1.Text = "";
                    textBoxNoOfPeases1.Text = "0";
                    textBoxStart.Text = "0";
                    textBoxEnd.Text = "0";

                    SearchItem();
                }
                else if (textBoxItemCode1.Text == "")
                {
                    button5.Select();
                }
                else if (textBoxItemCode1.Text == "" && dgView.Rows.Count > 0)
                {
                    //lblCashTender.Select();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fillTempIdData();
            SaveSODT();
            fillGrid();
            ExporttoCSV();
            DeleteAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\CSV\Barcode.btw");
            //ExportDgvToXML();
            //BulkInsert();
            //insertXML();

        }

        //---------------------------------------------


        private void ExportDgvToXML()
        {
            DataTable dt = new DataTable();//create the data table
            dt.TableName = "tempsalesorderdt";//give it a name
            //create the appropriate number of columns
            for (int i = 0; i < dgView.Columns.Count; i++)
            {
                dt.Columns.Add(dgView.Columns[i].Name);
            }

            //loop through each row of the DataGridView
            foreach (DataGridViewRow currentRow in dgView.Rows)
            {
                dt.Rows.Add();
                int runningCount = 0;
                //loop trough each column of the row
                foreach (DataGridViewCell item in currentRow.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][runningCount] = item.FormattedValue;
                    runningCount++;
                }
            }

            if (dt != null)
            {
                dt.WriteXml(@"c:\CSV\salesorderdttest.xml");
            }
        }

        // Getting connection string from App.config file
        string StrCon = ConfigurationManager.ConnectionStrings["easyPOSSolution.Properties.Settings.easybookshopsolutionConnectionString"].ToString();

        private void BulkInsert()
        {
            try
            {
                string Query = "LOAD XML INFILE 'C:/CSV/salesorderdttest.xml' INTO TABLE tajopcsandarufashionbr1.tempsalesorderdt ROWS IDENTIFIED BY '<tempsalesorderdt>'";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(StrCon);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Save Data");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  


        private void insertXML()
        {
            //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string filePath = "C:\\CSV\\salesorderdttest.xml";
            //FileUpload1.SaveAs(filePath);
            string xml = File.ReadAllText(filePath);
            string constr = ConfigurationManager.ConnectionStrings["easyPOSSolution.Properties.Settings.easybookshopsolutionConnectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("InsertXML"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@xml", xml);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        //-----------------------------------------------------
        private void CreateTable()
        {
            string XMlFile = "C:\\CSV\\salesorderdttest.xml";
            if (File.Exists(XMlFile))
            {
                // Conversion Xml file to DataTable
                DataTable dt = CreateDataTableXML(XMlFile);
                if (dt.Columns.Count == 0)
                    dt.ReadXml(XMlFile);

                // Creating Query for Table Creation
                string Query = CreateTableQuery(dt);
                MySqlConnection con = new MySqlConnection(StrCon);
                con.Open();

                //// Deletion of Table if already Exist
                //MySqlCommand cmd = new MySqlCommand("IF OBJECT_ID('" + dt.TableName + "', 'U') IS NOT NULL DROP TABLE " + dt.TableName + ";", con);
                //cmd.ExecuteNonQuery();

                //// Table Creation
                //cmd = new MySqlCommand(Query, con);
                //int check = cmd.ExecuteNonQuery();
                //if (check != 0)
                //{
                    // Copy Data from DataTable to Sql Table
                    using (var bulkCopy = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                    {
                        // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                        foreach (DataColumn col in dt.Columns)
                        {
                            bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        }

                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.DestinationTableName = dt.TableName;
                        bulkCopy.WriteToServer(dt);
                    }

                    MessageBox.Show("Table Created Successfully");
                //}
                con.Close();
            }

        }

        private void userPermission()
        {
            try
            {
                autocomplete = false;
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
                        
                        //if (alistForm[i].ToString().Trim() == "Change Price Mode")
                        //{
                        //    comboBoxPriceMethod.Enabled = true;
                        //}
                        if (alistForm[i].ToString().Trim() == "Auto Complete")
                        {
                            autocomplete = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Conversion Xml file to DataTable
        public DataTable CreateDataTableXML(string XmlFile)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(XmlFile);

            DataTable Dt = new DataTable();

            try
            {
                Dt.TableName = GetTableName(XmlFile);
                XmlNode NodoEstructura = doc.DocumentElement.ChildNodes.Cast<XmlNode>().ToList()[0];
                progressBar1.Maximum = NodoEstructura.ChildNodes.Count;
                progressBar1.Value = 0;
                foreach (XmlNode columna in NodoEstructura.ChildNodes)
                {
                    Dt.Columns.Add(columna.Name, typeof(String));
                    Progress();
                }

                XmlNode Filas = doc.DocumentElement;
                progressBar1.Maximum = Filas.ChildNodes.Count;
                progressBar1.Value = 0;
                foreach (XmlNode Fila in Filas.ChildNodes)
                {
                    List<string> Valores = Fila.ChildNodes.Cast<XmlNode>().ToList().Select(x => x.InnerText).ToList();
                    Dt.Rows.Add(Valores.ToArray());
                    Progress();
                }
            }
            catch (Exception ex)
            {

            }
            return Dt;
        }

        // Getting Table Name as Per the Xml File Name
        public string GetTableName(string file)
        {
            FileInfo fi = new FileInfo(file);
            string TableName = fi.Name.Replace(fi.Extension, "");

            return TableName;
        }

        // Getting Query for Table Creation
        public string CreateTableQuery(DataTable table)
        {
            string sqlsc = "CREATE TABLE " + table.TableName + "(";
            progressBar1.Maximum = table.Columns.Count;
            progressBar1.Value = 0;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "[" + table.Columns[i].ColumnName + "]";
                string columnType = table.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sqlsc += " int ";
                        break;
                    case "System.Int64":
                        sqlsc += " bigint ";
                        break;
                    case "System.Int16":
                        sqlsc += " smallint";
                        break;
                    case "System.Byte":
                        sqlsc += " tinyint";
                        break;
                    case "System.Decimal":
                        sqlsc += " decimal ";
                        break;
                    case "System.DateTime":
                        sqlsc += " datetime ";
                        break;
                    case "System.String":
                    default:
                        sqlsc += string.Format(" nvarchar({0}) ", table.Columns[i].MaxLength == -1 ? "max" : table.Columns[i].MaxLength.ToString());
                        break;
                }
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," + table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";

                Progress();
            }
            return sqlsc.Substring(0, sqlsc.Length - 1) + "\n)";
        }

        // Show Progress Bar
        public void Progress()
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

                Application.DoEvents();
            }
        }

        private void lblUserId_TextChanged(object sender, EventArgs e)
        {
            userPermission();
            if (autocomplete == true)
            {
                ItemAutoComplete();
            }
        }


    }
}
