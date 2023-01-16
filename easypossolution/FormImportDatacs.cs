using easyBAL;
using easyDAL;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormImportDatacs : Form
    {
        bool AddtoBarcode;

        public FormImportDatacs()
        {
            InitializeComponent();
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // To list only csv files, we need to add this filter
            openFileDialog.Filter = "|*.csv";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxPath.Text = openFileDialog.FileName;
            }
        }

        private void simpleButtonImport_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = GetDataTableFromCSVFile(textBoxPath.Text);
                //CalculateTotal();
                //CalculateImportTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private static DataTable GetDataTableFromCSVFile(string csvfilePath)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable csvData = new DataTable();
            using (TextFieldParser csvReader = new TextFieldParser(csvfilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                //Read columns from CSV file, remove this line if columns not exits  
                string[] colFields = csvReader.ReadFields();

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            return csvData;
            Cursor.Current = Cursors.Default;
        }
        bool insertDTStatus;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //DialogResult result = MessageBox.Show("Do you want to Add these Items to Print Barcode?", "Print Barcode Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{
                //    AddtoBarcode = true;
                //    DeleteAllBarcode();
                //}
                insertItemCategory();
                insertItemSubCategory();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemStatus = "Open";
                    objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString() == "")
                    {
                        objPOBAL.ItemCategory = "OTHER";
                    }
                    else
                    {
                        objPOBAL.ItemCategory = dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim();
                    }
                    if (dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString() == "")
                    {
                        objPOBAL.ItemSubCateory = "OTHER";
                    }
                    else
                    {
                        objPOBAL.ItemSubCateory = dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString().Trim();
                    }
                    
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemName = dataGridView1.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                    objPOBAL.SItemName = dataGridView1.Rows[i].Cells["SinhalaItemName"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["RetailDiscountAmount"].Value.ToString() == "")
                    {
                        objPOBAL.Discount = 0;
                    }
                    else
                    {
                        objPOBAL.Discount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["RetailDiscountAmount"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["WholesaleDiscountAmount"].Value.ToString() == "")
                    {
                        objPOBAL.WholeSaleDiscount = 0;
                    }
                    else
                    {
                        objPOBAL.WholeSaleDiscount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["WholesaleDiscountAmount"].Value);
                    }
                    
                    objPOBAL.ItemUnit = dataGridView1.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["CostPrice"].Value.ToString() == "")
                    {
                        objPOBAL.CostPrice = 0;
                    }
                    else
                    {
                        objPOBAL.CostPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["CostPrice"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["CostPrice"].Value.ToString() == "")
                    {
                        objPOBAL.DefaultCostPrice = 0;
                    }
                    else
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["CostPrice"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["RetailPrice"].Value.ToString() == "")
                    {
                        objPOBAL.SellingPrice = 0;
                    }
                    else
                    {
                        objPOBAL.SellingPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["RetailPrice"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["WholesalePrice"].Value.ToString() == "")
                    {
                        objPOBAL.SellingPrice2 = 0;
                    }
                    else
                    {
                        objPOBAL.SellingPrice2 = Convert.ToDecimal(dataGridView1.Rows[i].Cells["WholesalePrice"].Value);
                    }
                    
                    objPOBAL.SPPRiceEffectFrom = 0;
                    if (dataGridView1.Rows[i].Cells["ReOrderLevel"].Value.ToString() == "")
                    {
                        objPOBAL.MinQty = 0;
                    }
                    else
                    {
                        objPOBAL.MinQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ReOrderLevel"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["AvailableQty"].Value.ToString() == "")
                    {
                        objPOBAL.AvailableQty = 0;
                    }
                    else
                    {
                        objPOBAL.AvailableQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["AvailableQty"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["ShopPrice"].Value.ToString() == "")
                    {
                        objPOBAL.ShopPrice = 0;
                    }
                    else
                    {
                        objPOBAL.ShopPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ShopPrice"].Value);
                    }
                    
                    objPOBAL.ItemMode = "COMMON STOCK";
                    objPOBAL.OpenBalDate = DateTime.Today;
                    objPOBAL.CreatedBy = 1;
                    objPOBAL.SupplierId = 1;
                    objPOBAL.WarrantyPeriod = dataGridView1.Rows[i].Cells["WarrantyPeriod"].Value.ToString().Trim(); ;
                    objPOBAL.FreeIssueEffectFrom = 0;
                    objPOBAL.InValue = 0;
                    objPOBAL.OutValue = 0;
                    objPOBAL.InQty = 0;
                    objPOBAL.OutQty = 0;
                    objPOBAL.OpenStates = 1;
                    objPOBAL.RackNo = dataGridView1.Rows[i].Cells["RackNo"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["MinSellingPrice"].Value.ToString() == "")
                    {
                        objPOBAL.MinSellingPrice = 0;
                    }
                    else
                    {
                        objPOBAL.MinSellingPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["MinSellingPrice"].Value);
                    }
                    if (AddtoBarcode == true)
                    {
                        objPOBAL.AddBarcode = true;
                    }
                    else
                    {
                        objPOBAL.AddBarcode = false;
                    }
                    if (dataGridView1.Rows[i].Cells["RetailDiscountPer"].Value.ToString() == "")
                    {
                        objPOBAL.RetailDiscPer = 0;
                    }
                    else
                    {
                        objPOBAL.RetailDiscPer = Convert.ToDecimal(dataGridView1.Rows[i].Cells["RetailDiscountPer"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["WholesaleDiscountPer"].Value.ToString() == "")
                    {
                        objPOBAL.WholesaleDiscPer = 0;
                    }
                    else
                    {
                        objPOBAL.WholesaleDiscPer = Convert.ToDecimal(dataGridView1.Rows[i].Cells["WholesaleDiscountPer"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["MaintainQty"].Value.ToString() == "")
                    {
                        objPOBAL.MaintainQty = 0;
                    }
                    else
                    {
                        objPOBAL.MaintainQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["MaintainQty"].Value);
                    }
                    objPOBAL.SerialNo = dataGridView1.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                    objPOBAL.TItemName = dataGridView1.Rows[i].Cells["TamilItemName"].Value.ToString().Trim();

                    if (dataGridView1.Rows[i].Cells["ScaleItem"].Value.ToString() == "")
                    {
                        objPOBAL.ScaleItem = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["ScaleItem"].Value.ToString() == "1")
                        {
                            objPOBAL.ScaleItem = true;
                        }
                        else
                        {
                            objPOBAL.ScaleItem = false;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells["BundleItem"].Value.ToString() == "")
                    {
                        objPOBAL.BundleItem = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["BundleItem"].Value.ToString() == "1")
                        {
                            objPOBAL.BundleItem = true;
                        }
                        else
                        {
                            objPOBAL.BundleItem = false;
                        }

                    }

                    if (dataGridView1.Rows[i].Cells["RawMaterial"].Value.ToString() == "")
                    {
                        objPOBAL.RawMaterial = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["RawMaterial"].Value.ToString() == "1")
                        {
                            objPOBAL.RawMaterial = true;
                        }
                        else
                        {
                            objPOBAL.RawMaterial = false;
                        }

                    }

                    if (dataGridView1.Rows[i].Cells["AllowSales"].Value.ToString() == "")
                    {
                        objPOBAL.AllowSales = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["AllowSales"].Value.ToString() == "1")
                        {
                            objPOBAL.AllowSales = true;
                        }
                        else
                        {
                            objPOBAL.AllowSales = false;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells["AllowPurchase"].Value.ToString() == "")
                    {
                        objPOBAL.AllowPurchase = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["AllowPurchase"].Value.ToString() == "1")
                        {
                            objPOBAL.AllowPurchase = true;
                        }
                        else
                        {
                            objPOBAL.AllowPurchase = false;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells["AllowInventory"].Value.ToString() == "")
                    {
                        objPOBAL.AllowInventory = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["AllowInventory"].Value.ToString() == "1")
                        {
                            objPOBAL.AllowInventory = true;
                        }
                        else
                        {
                            objPOBAL.AllowInventory = false;
                        }
                    }
                    
                    
                    ClassPODAL objPODAL = new ClassPODAL();
                    int count = objPODAL.ImportStock(objPOBAL);

                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }
                }
                if (insertDTStatus == true)
                {
                    MessageBox.Show("Items Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                    //if (AddtoBarcode == true)
                    //{
                    //    fillBarcodeGrid();
                    //    ExporttoCSV();
                    //    dataGridView2.DataSource = null;
                    //}
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void fillBarcodeGrid()
        {
            try
            {
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                dataGridView2.DataSource = null;
                objInvBAL.DtDataSet = objInvDAL.retreiveBarcodeItems(objInvBAL);
                if (objInvBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = objInvBAL.DtDataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExporttoCSV()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                //Add the Header row for CSV file.
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    csv += column.HeaderText + ',';
                }

                //Add new line.
                csv += "\r\n";

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridView2.Rows)
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

        private void insertItemCategory()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    if (dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim() == "")
                    {
                        objPOBAL.ItemCategory = "Other";
                    }
                    else
                    {
                        objPOBAL.ItemCategory = dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim();
                    }                 
                    ClassPODAL objPODAL = new ClassPODAL();
                    int count = objPODAL.ImportItemCategory(objPOBAL);
                    
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertItemSubCategory()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    if (dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim() == "")
                    {
                        objPOBAL.ItemCategory = "Other";
                    }
                    else
                    {
                        objPOBAL.ItemCategory = dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim();
                    }
                    if (dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString().Trim() == "")
                    {
                        objPOBAL.ItemSubCateory = "Other";
                    }
                    else
                    {
                        objPOBAL.ItemSubCateory = dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString().Trim();
                    }  
                    ClassPODAL objPODAL = new ClassPODAL();
                    int count = objPODAL.ImportItemSubCategory(objPOBAL);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                ClassCommonBAL objBAL = new ClassCommonBAL();
                objBAL.CustomerName = dataGridView1.Rows[i].Cells["CustomerName"].Value.ToString().Trim();
                objBAL.CustomerAddress = dataGridView1.Rows[i].Cells["CustomerAddress"].Value.ToString().Trim();
                objBAL.CustomerTelNo = dataGridView1.Rows[i].Cells["CustomerTelephone"].Value.ToString().Trim();
                objBAL.CustomerFaxNo = dataGridView1.Rows[i].Cells["CustomerFax"].Value.ToString().Trim();
                objBAL.CustomerEmail = dataGridView1.Rows[i].Cells["CustomerEmail"].Value.ToString().Trim();
                objBAL.CustomerNICNo = dataGridView1.Rows[i].Cells["CustomerNIC"].Value.ToString().Trim();
                objBAL.Remarks = dataGridView1.Rows[i].Cells["Remarks"].Value.ToString().Trim();
                objBAL.VATCustomer = false;
                objBAL.ContactPerson = dataGridView1.Rows[i].Cells["CustomerCode"].Value.ToString().Trim();
                if (dataGridView1.Rows[i].Cells["CreditBalance"].Value.ToString() == "")
                {
                    objBAL.BalanceAmount = 0;
                }
                else
                {
                    objBAL.BalanceAmount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["CreditBalance"].Value);
                }
                objBAL.CreatedBy = 1;
                objBAL.PriceMode = "Retail";

                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);

                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] data = ms.GetBuffer();
                objBAL.CustomerImage = data;
                objBAL.AreaId = 1;
                objBAL.NewAreaId = 1;
                if (dataGridView1.Rows[i].Cells["CreditLimit"].Value.ToString() == "")
                {
                    objBAL.CreditLimit = 0;
                }
                else
                {
                    objBAL.CreditLimit = Convert.ToDecimal(dataGridView1.Rows[i].Cells["CreditLimit"].Value);
                }

                ClassMasterDAL objDAL = new ClassMasterDAL();
                int count = objDAL.InsertCustomer(objBAL);
                if (count != 0)
                {
                    insertDTStatus = true;
                }
                }
                if (insertDTStatus == true)
                {
                    MessageBox.Show("Customers Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        ClassPOBAL objPOBAL = new ClassPOBAL();
            //        objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["ITEMCODE"].Value.ToString().Trim();
            //        objPOBAL.ItemName = dataGridView1.Rows[i].Cells["TYPECODE"].Value.ToString().Trim();

            //        ClassPODAL objPODAL = new ClassPODAL();
            //        int count = objPODAL.ImportCategory(objPOBAL);
            //        if (count != 0)
            //        {
            //            insertDTStatus = true;
            //        }
            //    }
            //    if (insertDTStatus == true)
            //    {
            //        MessageBox.Show("Items Category Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dataGridView1.DataSource = null;
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        ClassPOBAL objPOBAL = new ClassPOBAL();
            //        objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["itemcode"].Value.ToString().Trim();
            //        objPOBAL.PIHDId = 0;
            //        objPOBAL.ItemsId = 0;
            //        objPOBAL.ItemSerialId = 0;
            //        objPOBAL.SerialNo = dataGridView1.Rows[i].Cells["serno"].Value.ToString().Trim();
            //        objPOBAL.AvailableQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["quantity"].Value);

            //        ClassPODAL objPODAL = new ClassPODAL();
            //        int count = objPODAL.ImportSerial(objPOBAL);
            //        if (count != 0)
            //        {
            //            insertDTStatus = true;
            //        }
            //    }
            //    if (insertDTStatus == true)
            //    {
            //        MessageBox.Show("Items Serials Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dataGridView1.DataSource = null;
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //DialogResult result = MessageBox.Show("Do you want to Add these Items to Print Barcode?", "Print Barcode Confirmation.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{
                //    AddtoBarcode = true;
                //    DeleteAllBarcode();
                //}
                insertItemCategory();
                insertItemSubCategory();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemStatus = "Open";
                    objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString() == "")
                    {
                        objPOBAL.ItemCategory = "OTHER";
                    }
                    else
                    {
                        objPOBAL.ItemCategory = dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim();
                    }
                    if (dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString() == "")
                    {
                        objPOBAL.ItemSubCateory = "OTHER";
                    }
                    else
                    {
                        objPOBAL.ItemSubCateory = dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString().Trim();
                    }

                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemName = dataGridView1.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                    objPOBAL.SItemName = dataGridView1.Rows[i].Cells["SinhalaItemName"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["RetailDiscountAmount"].Value.ToString() == "")
                    {
                        objPOBAL.Discount = 0;
                    }
                    else
                    {
                        objPOBAL.Discount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["RetailDiscountAmount"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["WholesaleDiscountAmount"].Value.ToString() == "")
                    {
                        objPOBAL.WholeSaleDiscount = 0;
                    }
                    else
                    {
                        objPOBAL.WholeSaleDiscount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["WholesaleDiscountAmount"].Value);
                    }

                    objPOBAL.ItemUnit = dataGridView1.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["CostPrice"].Value.ToString() == "")
                    {
                        objPOBAL.CostPrice = 0;
                    }
                    else
                    {
                        objPOBAL.CostPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["CostPrice"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["CostPrice"].Value.ToString() == "")
                    {
                        objPOBAL.DefaultCostPrice = 0;
                    }
                    else
                    {
                        objPOBAL.DefaultCostPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["CostPrice"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["RetailPrice"].Value.ToString() == "")
                    {
                        objPOBAL.SellingPrice = 0;
                    }
                    else
                    {
                        objPOBAL.SellingPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["RetailPrice"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["WholesalePrice"].Value.ToString() == "")
                    {
                        objPOBAL.SellingPrice2 = 0;
                    }
                    else
                    {
                        objPOBAL.SellingPrice2 = Convert.ToDecimal(dataGridView1.Rows[i].Cells["WholesalePrice"].Value);
                    }

                    objPOBAL.SPPRiceEffectFrom = 0;
                    if (dataGridView1.Rows[i].Cells["ReOrderLevel"].Value.ToString() == "")
                    {
                        objPOBAL.MinQty = 0;
                    }
                    else
                    {
                        objPOBAL.MinQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ReOrderLevel"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["AvailableQty"].Value.ToString() == "")
                    {
                        objPOBAL.AvailableQty = 0;
                    }
                    else
                    {
                        objPOBAL.AvailableQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["AvailableQty"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["ShopPrice"].Value.ToString() == "")
                    {
                        objPOBAL.ShopPrice = 0;
                    }
                    else
                    {
                        objPOBAL.ShopPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ShopPrice"].Value);
                    }

                    objPOBAL.ItemMode = "COMMON STOCK";
                    objPOBAL.OpenBalDate = DateTime.Today;
                    objPOBAL.CreatedBy = 1;
                    objPOBAL.SupplierId = 1;
                    objPOBAL.WarrantyPeriod = dataGridView1.Rows[i].Cells["WarrantyPeriod"].Value.ToString().Trim(); ;
                    objPOBAL.FreeIssueEffectFrom = 0;
                    objPOBAL.InValue = 0;
                    objPOBAL.OutValue = 0;
                    objPOBAL.InQty = 0;
                    objPOBAL.OutQty = 0;
                    objPOBAL.OpenStates = 1;
                    objPOBAL.RackNo = dataGridView1.Rows[i].Cells["RackNo"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["MinSellingPrice"].Value.ToString() == "")
                    {
                        objPOBAL.MinSellingPrice = 0;
                    }
                    else
                    {
                        objPOBAL.MinSellingPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["MinSellingPrice"].Value);
                    }
                    if (AddtoBarcode == true)
                    {
                        objPOBAL.AddBarcode = true;
                    }
                    else
                    {
                        objPOBAL.AddBarcode = false;
                    }
                    if (dataGridView1.Rows[i].Cells["RetailDiscountPer"].Value.ToString() == "")
                    {
                        objPOBAL.RetailDiscPer = 0;
                    }
                    else
                    {
                        objPOBAL.RetailDiscPer = Convert.ToDecimal(dataGridView1.Rows[i].Cells["RetailDiscountPer"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["WholesaleDiscountPer"].Value.ToString() == "")
                    {
                        objPOBAL.WholesaleDiscPer = 0;
                    }
                    else
                    {
                        objPOBAL.WholesaleDiscPer = Convert.ToDecimal(dataGridView1.Rows[i].Cells["WholesaleDiscountPer"].Value);
                    }
                    if (dataGridView1.Rows[i].Cells["MaintainQty"].Value.ToString() == "")
                    {
                        objPOBAL.MaintainQty = 0;
                    }
                    else
                    {
                        objPOBAL.MaintainQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["MaintainQty"].Value);
                    }
                    objPOBAL.SerialNo = dataGridView1.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                    objPOBAL.TItemName = dataGridView1.Rows[i].Cells["TamilItemName"].Value.ToString().Trim();
                    objPOBAL.MItemCode = dataGridView1.Rows[i].Cells["MainProductCode"].Value.ToString().Trim();
                    if (dataGridView1.Rows[i].Cells["ConvertionQty"].Value.ToString() == "")
                    {
                        objPOBAL.ConvertionQty = 0;
                    }
                    else
                    {
                        objPOBAL.ConvertionQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ConvertionQty"].Value);
                    }

                    if (dataGridView1.Rows[i].Cells["ScaleItem"].Value.ToString() == "")
                    {
                        objPOBAL.ScaleItem = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["ScaleItem"].Value.ToString() == "1")
                        {
                            objPOBAL.ScaleItem = true;
                        }
                        else
                        {
                            objPOBAL.ScaleItem = false;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells["BundleItem"].Value.ToString() == "")
                    {
                        objPOBAL.BundleItem = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["BundleItem"].Value.ToString() == "1")
                        {
                            objPOBAL.BundleItem = true;
                        }
                        else
                        {
                            objPOBAL.BundleItem = false;
                        }

                    }

                    if (dataGridView1.Rows[i].Cells["RawMaterial"].Value.ToString() == "")
                    {
                        objPOBAL.RawMaterial = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["RawMaterial"].Value.ToString() == "1")
                        {
                            objPOBAL.RawMaterial = true;
                        }
                        else
                        {
                            objPOBAL.RawMaterial = false;
                        }

                    }

                    if (dataGridView1.Rows[i].Cells["AllowSales"].Value.ToString() == "")
                    {
                        objPOBAL.AllowSales = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["AllowSales"].Value.ToString() == "1")
                        {
                            objPOBAL.AllowSales = true;
                        }
                        else
                        {
                            objPOBAL.AllowSales = false;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells["AllowPurchase"].Value.ToString() == "")
                    {
                        objPOBAL.AllowPurchase = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["AllowPurchase"].Value.ToString() == "1")
                        {
                            objPOBAL.AllowPurchase = true;
                        }
                        else
                        {
                            objPOBAL.AllowPurchase = false;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells["AllowInventory"].Value.ToString() == "")
                    {
                        objPOBAL.AllowInventory = false;
                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["AllowInventory"].Value.ToString() == "1")
                        {
                            objPOBAL.AllowInventory = true;
                        }
                        else
                        {
                            objPOBAL.AllowInventory = false;
                        }
                    }

                    ClassPODAL objPODAL = new ClassPODAL();
                    int count = objPODAL.ImportVarientStock(objPOBAL);

                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }
                }
                if (insertDTStatus == true)
                {
                    MessageBox.Show("Varient Items Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                    //if (AddtoBarcode == true)
                    //{
                    //    fillBarcodeGrid();
                    //    ExporttoCSV();
                    //    dataGridView2.DataSource = null;
                    //}
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        ClassCommonBAL objBAL = new ClassCommonBAL();
            //        objBAL.CustomerCode = dataGridView1.Rows[i].Cells["debnam"].Value.ToString().Trim();
            //        objBAL.BalanceAmount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["total"].Value); ;

            //        ClassMasterDAL objDAL = new ClassMasterDAL();
            //        int count = objDAL.ImportTempCustCredit(objBAL);
            //        if (count != 0)
            //        {
            //            insertDTStatus = true;
            //        }
            //    }
            //    if (insertDTStatus == true)
            //    {
            //        MessageBox.Show("Customers Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dataGridView1.DataSource = null;
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            
        }

        //private void InsertCustomer()
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            ClassCommonBAL objBAL = new ClassCommonBAL();
        //            objBAL.CustomerName = dataGridView1.Rows[i].Cells["debname"].Value.ToString().Trim();
        //            objBAL.CustomerAddress = dataGridView1.Rows[i].Cells["debadd1"].Value.ToString().Trim();
        //            objBAL.CustomerAddress2 = dataGridView1.Rows[i].Cells["debadd2"].Value.ToString().Trim();
        //            objBAL.CustomerAddress3 = dataGridView1.Rows[i].Cells["debadd3"].Value.ToString().Trim();
        //            objBAL.CustomerTelNo = dataGridView1.Rows[i].Cells["debtel2"].Value.ToString().Trim();
        //            objBAL.CustomerFaxNo = dataGridView1.Rows[i].Cells["debfax"].Value.ToString().Trim();
        //            objBAL.CustomerEmail = dataGridView1.Rows[i].Cells["debmail"].Value.ToString().Trim();
        //            objBAL.CustomerNICNo = "";
        //            objBAL.Remarks = "";
        //                objBAL.VATCustomer = false;
        //                objBAL.ContactPerson = dataGridView1.Rows[i].Cells["debcper"].Value.ToString().Trim();
        //            objBAL.BalanceAmount = 0;
        //            objBAL.CreatedBy = 1;

        //            MemoryStream ms = new MemoryStream();
        //            Bitmap bmpImage = new Bitmap(pictureBox1.Image);

        //            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

        //            byte[] data = ms.GetBuffer();
        //            //MySqlParameter p = new MySqlParameter("@d22", SqlDbType.Image);
        //            //p.Value = data;
        //            //cmd.Parameters.Add(p);
        //            objBAL.CustomerImage = data;
        //            objBAL.AreaId = 1;
        //            objBAL.CustomerCode = dataGridView1.Rows[i].Cells["CustomerCode"].Value.ToString().Trim();
        //            objBAL.CreditLimit = 0;
        //            objBAL.CreditPeriod = 0;

        //            ClassMasterDAL objDAL = new ClassMasterDAL();
        //            int count = objDAL.ImportCustomer(objBAL);
        //            if (count != 0)
        //            {
        //                insertDTStatus = true;
        //            }
        //        }
        //        if (insertDTStatus == true)
        //        {
        //            MessageBox.Show("Customers Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            dataGridView1.DataSource = null;
        //        }
        //        Cursor.Current = Cursors.Default;
        //        }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void InsertSupplier()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ClassCommonBAL objBAL = new ClassCommonBAL();
                    objBAL.SupplierName = dataGridView1.Rows[i].Cells["SupplierName"].Value.ToString().Trim();
                    objBAL.ContactPerson = dataGridView1.Rows[i].Cells["ContactPerson"].Value.ToString().Trim();
                    objBAL.BusinessNo = dataGridView1.Rows[i].Cells["BusinessNo"].Value.ToString().Trim();
                    objBAL.MobileNo = dataGridView1.Rows[i].Cells["MobileNo"].Value.ToString().Trim();
                    objBAL.Email = dataGridView1.Rows[i].Cells["Email"].Value.ToString().Trim();
                    objBAL.Address = dataGridView1.Rows[i].Cells["Address"].Value.ToString().Trim();
                    objBAL.Remarks = dataGridView1.Rows[i].Cells["Remarks"].Value.ToString().Trim();
                    objBAL.CreatedBy = 1;
                    if (dataGridView1.Rows[i].Cells["CreditBalance"].Value.ToString() == "")
                    {
                        objBAL.BalanceAmount = 0;
                    }
                    else
                    {
                        objBAL.BalanceAmount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["CreditBalance"].Value);
                    }
                    ClassMasterDAL objDAL = new ClassMasterDAL();
                    int count = objDAL.InsertSupplier(objBAL);
                    if (count != 0)
                    {
                        insertDTStatus = true;
                    }
                }
                if (insertDTStatus == true)
                {
                    MessageBox.Show("Suppliers Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    InsertCustomer();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        private void FormImportDatacs_Load(object sender, EventArgs e)
        {
            //fillImage();
            ClassPOBAL objBAL = new ClassPOBAL();
            ClassPODAL objDAL = new ClassPODAL();
            if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
            {
                comboBoxBranch.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxBranch.DisplayMember = "BranchName";
                comboBoxBranch.ValueMember = "BranchId";
                comboBoxBranch.SelectedIndex = 0;
            }
            pictureBox1.Image = Properties.Resources.Person;
        }

        private void fillImage()
        {
            pictureBox1.Image = Properties.Resources.Person;
        }

        private void DeleteAllBarcode()
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

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        ClassCommonBAL objBAL = new ClassCommonBAL();
            //        objBAL.CustomerCode = dataGridView1.Rows[i].Cells["supname"].Value.ToString().Trim();
            //        objBAL.BalanceAmount = Convert.ToDecimal(dataGridView1.Rows[i].Cells["total"].Value); ;

            //        ClassMasterDAL objDAL = new ClassMasterDAL();
            //        int count = objDAL.ImportTempSupCredit(objBAL);
            //        if (count != 0)
            //        {
            //            insertDTStatus = true;
            //        }
            //    }
            //    if (insertDTStatus == true)
            //    {
            //        MessageBox.Show("Supplier Credit Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dataGridView1.DataSource = null;
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            InsertSupplier();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        ClassPOBAL objPOBAL = new ClassPOBAL();
            //        objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["itemcode"].Value.ToString().Trim();
            //        objPOBAL.CostPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["unitcost"].Value);
                    
            //        ClassPODAL objPODAL = new ClassPODAL();
            //        int count = objPODAL.ImportCostPrice(objPOBAL);
            //        if (count != 0)
            //        {
            //            insertDTStatus = true;
            //        }
            //    }
            //    if (insertDTStatus == true)
            //    {
            //        MessageBox.Show("Items Cost Price Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dataGridView1.DataSource = null;
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
