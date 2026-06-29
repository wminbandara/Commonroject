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
        bool insertDTStatus;

        public FormImportDatacs()
        {
            InitializeComponent();
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Cursor.Current = Cursors.Default;
            return csvData;
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                List<ClassPOBAL> itemsToImport = new List<ClassPOBAL>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue;
                    
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemStatus = "Open";
                    objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    
                    string cat = dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim();
                    objPOBAL.ItemCategory = string.IsNullOrEmpty(cat) ? "OTHER" : cat;
                    
                    string sub = dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString().Trim();
                    objPOBAL.ItemSubCateory = string.IsNullOrEmpty(sub) ? "OTHER" : sub;
                    
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemName = dataGridView1.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                    objPOBAL.SItemName = dataGridView1.Rows[i].Cells["SinhalaItemName"].Value.ToString().Trim();
                    
                    string disc = dataGridView1.Rows[i].Cells["RetailDiscountAmount"].Value.ToString().Trim();
                    objPOBAL.Discount = string.IsNullOrEmpty(disc) ? 0 : Convert.ToDecimal(disc);
                    
                    string wdisc = dataGridView1.Rows[i].Cells["WholesaleDiscountAmount"].Value.ToString().Trim();
                    objPOBAL.WholeSaleDiscount = string.IsNullOrEmpty(wdisc) ? 0 : Convert.ToDecimal(wdisc);
                    
                    objPOBAL.ItemUnit = dataGridView1.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();
                    
                    string cost = dataGridView1.Rows[i].Cells["CostPrice"].Value.ToString().Trim();
                    objPOBAL.CostPrice = string.IsNullOrEmpty(cost) ? 0 : Convert.ToDecimal(cost);
                    objPOBAL.DefaultCostPrice = objPOBAL.CostPrice;
                    
                    string retail = dataGridView1.Rows[i].Cells["RetailPrice"].Value.ToString().Trim();
                    objPOBAL.SellingPrice = string.IsNullOrEmpty(retail) ? 0 : Convert.ToDecimal(retail);
                    
                    string wholesale = dataGridView1.Rows[i].Cells["WholesalePrice"].Value.ToString().Trim();
                    objPOBAL.SellingPrice2 = string.IsNullOrEmpty(wholesale) ? 0 : Convert.ToDecimal(wholesale);
                    
                    objPOBAL.SPPRiceEffectFrom = 0;
                    
                    string reorder = dataGridView1.Rows[i].Cells["ReOrderLevel"].Value.ToString().Trim();
                    objPOBAL.MinQty = string.IsNullOrEmpty(reorder) ? 0 : Convert.ToDecimal(reorder);
                    
                    string avail = dataGridView1.Rows[i].Cells["AvailableQty"].Value.ToString().Trim();
                    objPOBAL.AvailableQty = string.IsNullOrEmpty(avail) ? 0 : Convert.ToDecimal(avail);
                    
                    string shop = dataGridView1.Rows[i].Cells["ShopPrice"].Value.ToString().Trim();
                    objPOBAL.ShopPrice = string.IsNullOrEmpty(shop) ? 0 : Convert.ToDecimal(shop);
                    
                    objPOBAL.ItemMode = "COMMON STOCK";
                    objPOBAL.OpenBalDate = DateTime.Today;
                    objPOBAL.CreatedBy = 1;
                    objPOBAL.SupplierId = 1;
                    objPOBAL.WarrantyPeriod = dataGridView1.Rows[i].Cells["WarrantyPeriod"].Value.ToString().Trim();
                    objPOBAL.FreeIssueEffectFrom = 0;
                    objPOBAL.InValue = 0;
                    objPOBAL.OutValue = 0;
                    objPOBAL.InQty = 0;
                    objPOBAL.OutQty = 0;
                    objPOBAL.OpenStates = 1;
                    objPOBAL.RackNo = dataGridView1.Rows[i].Cells["RackNo"].Value.ToString().Trim();
                    
                    string minsel = dataGridView1.Rows[i].Cells["MinSellingPrice"].Value.ToString().Trim();
                    objPOBAL.MinSellingPrice = string.IsNullOrEmpty(minsel) ? 0 : Convert.ToDecimal(minsel);
                    
                    objPOBAL.AddBarcode = AddtoBarcode;
                    
                    string retdisc = dataGridView1.Rows[i].Cells["RetailDiscountPer"].Value.ToString().Trim();
                    objPOBAL.RetailDiscPer = string.IsNullOrEmpty(retdisc) ? 0 : Convert.ToDecimal(retdisc);
                    
                    string whodisc = dataGridView1.Rows[i].Cells["WholesaleDiscountPer"].Value.ToString().Trim();
                    objPOBAL.WholesaleDiscPer = string.IsNullOrEmpty(whodisc) ? 0 : Convert.ToDecimal(whodisc);
                    
                    string maintain = dataGridView1.Rows[i].Cells["MaintainQty"].Value.ToString().Trim();
                    objPOBAL.MaintainQty = string.IsNullOrEmpty(maintain) ? 0 : Convert.ToDecimal(maintain);
                    
                    objPOBAL.SerialNo = dataGridView1.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                    objPOBAL.TItemName = dataGridView1.Rows[i].Cells["TamilItemName"].Value.ToString().Trim();
                    
                    string scale = dataGridView1.Rows[i].Cells["ScaleItem"].Value.ToString().Trim();
                    objPOBAL.ScaleItem = scale == "1";
                    
                    string bundle = dataGridView1.Rows[i].Cells["BundleItem"].Value.ToString().Trim();
                    objPOBAL.BundleItem = bundle == "1";
                    
                    string raw = dataGridView1.Rows[i].Cells["RawMaterial"].Value.ToString().Trim();
                    objPOBAL.RawMaterial = raw == "1";
                    
                    string sales = dataGridView1.Rows[i].Cells["AllowSales"].Value.ToString().Trim();
                    objPOBAL.AllowSales = sales == "1";
                    
                    string purch = dataGridView1.Rows[i].Cells["AllowPurchase"].Value.ToString().Trim();
                    objPOBAL.AllowPurchase = purch == "1";
                    
                    string inv = dataGridView1.Rows[i].Cells["AllowInventory"].Value.ToString().Trim();
                    objPOBAL.AllowInventory = inv == "1";
                    
                    objPOBAL.SearchText = dataGridView1.Rows[i].Cells["SearchText"].Value.ToString().Trim();
                    objPOBAL.CostCode = dataGridView1.Rows[i].Cells["CostCode"].Value.ToString().Trim();
                    
                    itemsToImport.Add(objPOBAL);
                }

                insertDTStatus = false;
                await Task.Run(() =>
                {
                    insertItemCategory(itemsToImport);
                    insertItemSubCategory(itemsToImport);
                    
                    ClassPODAL objPODAL = new ClassPODAL();
                    foreach (var objPOBAL in itemsToImport)
                    {
                        int count = objPODAL.ImportStock(objPOBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }
                });

                if (insertDTStatus == true)
                {
                    MessageBox.Show("Items Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                List<ClassCommonBAL> listToImport = new List<ClassCommonBAL>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue;
                    
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
                    
                    string bal = dataGridView1.Rows[i].Cells["CreditBalance"].Value.ToString().Trim();
                    objBAL.BalanceAmount = string.IsNullOrEmpty(bal) ? 0 : Convert.ToDecimal(bal);
                    
                    objBAL.CreatedBy = 1;
                    objBAL.PriceMode = "Retail";

                    MemoryStream ms = new MemoryStream();
                    if (pictureBox1.Image != null)
                    {
                        Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                        bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    byte[] data = ms.GetBuffer();
                    objBAL.CustomerImage = data;
                    objBAL.AreaId = 1;
                    objBAL.NewAreaId = 1;
                    
                    string limit = dataGridView1.Rows[i].Cells["CreditLimit"].Value.ToString().Trim();
                    objBAL.CreditLimit = string.IsNullOrEmpty(limit) ? 0 : Convert.ToDecimal(limit);
                    
                    listToImport.Add(objBAL);
                }

                insertDTStatus = false;
                await Task.Run(() =>
                {
                    ClassMasterDAL objDAL = new ClassMasterDAL();
                    foreach (var objBAL in listToImport)
                    {
                        int count = objDAL.InsertCustomer(objBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }
                });

                if (insertDTStatus == true)
                {
                    MessageBox.Show("Customers Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void insertItemCategory(List<ClassPOBAL> list)
        {
            try
            {
                ClassPODAL objPODAL = new ClassPODAL();
                HashSet<string> insertedCategories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (var item in list)
                {
                    string category = string.IsNullOrEmpty(item.ItemCategory) ? "Other" : item.ItemCategory;
                    if (insertedCategories.Add(category))
                    {
                        ClassPOBAL objPOBAL = new ClassPOBAL();
                        objPOBAL.ItemCategory = category;
                        objPODAL.ImportItemCategory(objPOBAL);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertItemSubCategory(List<ClassPOBAL> list)
        {
            try
            {
                ClassPODAL objPODAL = new ClassPODAL();
                HashSet<string> insertedSubCategories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (var item in list)
                {
                    string category = string.IsNullOrEmpty(item.ItemCategory) ? "Other" : item.ItemCategory;
                    string subcategory = string.IsNullOrEmpty(item.ItemSubCateory) ? "Other" : item.ItemSubCateory;
                    string key = category + "|||" + subcategory;

                    if (insertedSubCategories.Add(key))
                    {
                        ClassPOBAL objPOBAL = new ClassPOBAL();
                        objPOBAL.ItemCategory = category;
                        objPOBAL.ItemSubCateory = subcategory;
                        objPODAL.ImportItemSubCategory(objPOBAL);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<ClassPOBAL> itemsToImport = new List<ClassPOBAL>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue;

                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemStatus = "Open";
                    objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["ItemCode"].Value.ToString().Trim();

                    string cat = dataGridView1.Rows[i].Cells["ItemCategory"].Value.ToString().Trim();
                    objPOBAL.ItemCategory = string.IsNullOrEmpty(cat) ? "OTHER" : cat;

                    string sub = dataGridView1.Rows[i].Cells["ItemSubCateory"].Value.ToString().Trim();
                    objPOBAL.ItemSubCateory = string.IsNullOrEmpty(sub) ? "OTHER" : sub;

                    objPOBAL.BranchId = Convert.ToInt32(comboBoxBranch.SelectedValue.ToString());
                    objPOBAL.ItemName = dataGridView1.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                    objPOBAL.SItemName = dataGridView1.Rows[i].Cells["SinhalaItemName"].Value.ToString().Trim();

                    string disc = dataGridView1.Rows[i].Cells["RetailDiscountAmount"].Value.ToString().Trim();
                    objPOBAL.Discount = string.IsNullOrEmpty(disc) ? 0 : Convert.ToDecimal(disc);

                    string wdisc = dataGridView1.Rows[i].Cells["WholesaleDiscountAmount"].Value.ToString().Trim();
                    objPOBAL.WholeSaleDiscount = string.IsNullOrEmpty(wdisc) ? 0 : Convert.ToDecimal(wdisc);

                    objPOBAL.ItemUnit = dataGridView1.Rows[i].Cells["ItemUnit"].Value.ToString().Trim();

                    string cost = dataGridView1.Rows[i].Cells["CostPrice"].Value.ToString().Trim();
                    objPOBAL.CostPrice = string.IsNullOrEmpty(cost) ? 0 : Convert.ToDecimal(cost);
                    objPOBAL.DefaultCostPrice = objPOBAL.CostPrice;

                    string retail = dataGridView1.Rows[i].Cells["RetailPrice"].Value.ToString().Trim();
                    objPOBAL.SellingPrice = string.IsNullOrEmpty(retail) ? 0 : Convert.ToDecimal(retail);

                    string wholesale = dataGridView1.Rows[i].Cells["WholesalePrice"].Value.ToString().Trim();
                    objPOBAL.SellingPrice2 = string.IsNullOrEmpty(wholesale) ? 0 : Convert.ToDecimal(wholesale);

                    objPOBAL.SPPRiceEffectFrom = 0;

                    string reorder = dataGridView1.Rows[i].Cells["ReOrderLevel"].Value.ToString().Trim();
                    objPOBAL.MinQty = string.IsNullOrEmpty(reorder) ? 0 : Convert.ToDecimal(reorder);

                    string avail = dataGridView1.Rows[i].Cells["AvailableQty"].Value.ToString().Trim();
                    objPOBAL.AvailableQty = string.IsNullOrEmpty(avail) ? 0 : Convert.ToDecimal(avail);

                    string shop = dataGridView1.Rows[i].Cells["ShopPrice"].Value.ToString().Trim();
                    objPOBAL.ShopPrice = string.IsNullOrEmpty(shop) ? 0 : Convert.ToDecimal(shop);

                    objPOBAL.ItemMode = "COMMON STOCK";
                    objPOBAL.OpenBalDate = DateTime.Today;
                    objPOBAL.CreatedBy = 1;
                    objPOBAL.SupplierId = 1;
                    objPOBAL.WarrantyPeriod = dataGridView1.Rows[i].Cells["WarrantyPeriod"].Value.ToString().Trim();
                    objPOBAL.FreeIssueEffectFrom = 0;
                    objPOBAL.InValue = 0;
                    objPOBAL.OutValue = 0;
                    objPOBAL.InQty = 0;
                    objPOBAL.OutQty = 0;
                    objPOBAL.OpenStates = 1;
                    objPOBAL.RackNo = dataGridView1.Rows[i].Cells["RackNo"].Value.ToString().Trim();

                    string minsel = dataGridView1.Rows[i].Cells["MinSellingPrice"].Value.ToString().Trim();
                    objPOBAL.MinSellingPrice = string.IsNullOrEmpty(minsel) ? 0 : Convert.ToDecimal(minsel);

                    objPOBAL.AddBarcode = AddtoBarcode;

                    string retdisc = dataGridView1.Rows[i].Cells["RetailDiscountPer"].Value.ToString().Trim();
                    objPOBAL.RetailDiscPer = string.IsNullOrEmpty(retdisc) ? 0 : Convert.ToDecimal(retdisc);

                    string whodisc = dataGridView1.Rows[i].Cells["WholesaleDiscountPer"].Value.ToString().Trim();
                    objPOBAL.WholesaleDiscPer = string.IsNullOrEmpty(whodisc) ? 0 : Convert.ToDecimal(whodisc);

                    string maintain = dataGridView1.Rows[i].Cells["MaintainQty"].Value.ToString().Trim();
                    objPOBAL.MaintainQty = string.IsNullOrEmpty(maintain) ? 0 : Convert.ToDecimal(maintain);

                    objPOBAL.SerialNo = dataGridView1.Rows[i].Cells["SerialNo"].Value.ToString().Trim();
                    objPOBAL.TItemName = dataGridView1.Rows[i].Cells["TamilItemName"].Value.ToString().Trim();

                    string scale = dataGridView1.Rows[i].Cells["ScaleItem"].Value.ToString().Trim();
                    objPOBAL.ScaleItem = scale == "1";

                    string bundle = dataGridView1.Rows[i].Cells["BundleItem"].Value.ToString().Trim();
                    objPOBAL.BundleItem = bundle == "1";

                    string raw = dataGridView1.Rows[i].Cells["RawMaterial"].Value.ToString().Trim();
                    objPOBAL.RawMaterial = raw == "1";

                    string sales = dataGridView1.Rows[i].Cells["AllowSales"].Value.ToString().Trim();
                    objPOBAL.AllowSales = sales == "1";

                    string purch = dataGridView1.Rows[i].Cells["AllowPurchase"].Value.ToString().Trim();
                    objPOBAL.AllowPurchase = purch == "1";

                    string inv = dataGridView1.Rows[i].Cells["AllowInventory"].Value.ToString().Trim();
                    objPOBAL.AllowInventory = inv == "1";

                    objPOBAL.SearchText = dataGridView1.Rows[i].Cells["SearchText"].Value.ToString().Trim();
                    objPOBAL.CostCode = dataGridView1.Rows[i].Cells["CostCode"].Value.ToString().Trim();

                    itemsToImport.Add(objPOBAL);
                }

                // 2. Perform DB operations on a background thread
                insertDTStatus = false;
                await Task.Run(() =>
                {
                    insertItemCategory(itemsToImport);
                    insertItemSubCategory(itemsToImport);

                    ClassPODAL objPODAL = new ClassPODAL();
                    foreach (var objPOBAL in itemsToImport)
                    {
                        int count = objPODAL.ImportVarientStock(objPOBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }
                });

                if (insertDTStatus == true)
                {
                    MessageBox.Show("Varient Items Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
        }

        private async Task InsertSupplierAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                List<ClassCommonBAL> listToImport = new List<ClassCommonBAL>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue;
                    
                    ClassCommonBAL objBAL = new ClassCommonBAL();
                    objBAL.SupplierName = dataGridView1.Rows[i].Cells["SupplierName"].Value.ToString().Trim();
                    objBAL.ContactPerson = dataGridView1.Rows[i].Cells["ContactPerson"].Value.ToString().Trim();
                    objBAL.BusinessNo = dataGridView1.Rows[i].Cells["BusinessNo"].Value.ToString().Trim();
                    objBAL.MobileNo = dataGridView1.Rows[i].Cells["MobileNo"].Value.ToString().Trim();
                    objBAL.Email = dataGridView1.Rows[i].Cells["Email"].Value.ToString().Trim();
                    objBAL.Address = dataGridView1.Rows[i].Cells["Address"].Value.ToString().Trim();
                    objBAL.Remarks = dataGridView1.Rows[i].Cells["Remarks"].Value.ToString().Trim();
                    objBAL.CreatedBy = 1;
                    
                    string bal = dataGridView1.Rows[i].Cells["CreditBalance"].Value.ToString().Trim();
                    objBAL.BalanceAmount = string.IsNullOrEmpty(bal) ? 0 : Convert.ToDecimal(bal);
                    
                    listToImport.Add(objBAL);
                }

                insertDTStatus = false;
                await Task.Run(() =>
                {
                    ClassMasterDAL objDAL = new ClassMasterDAL();
                    foreach (var objBAL in listToImport)
                    {
                        int count = objDAL.InsertSupplier(objBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }
                });

                if (insertDTStatus == true)
                {
                    MessageBox.Show("Suppliers Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
        }

        private void FormImportDatacs_Load(object sender, EventArgs e)
        {
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

        private async void simpleButton6_Click(object sender, EventArgs e)
        {
            await InsertSupplierAsync();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
        }

        private async void simpleButton9_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                List<ClassPOBAL> listToImport = new List<ClassPOBAL>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue;
                    
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    
                    string cost = dataGridView1.Rows[i].Cells["CostPrice"].Value.ToString().Trim();
                    objPOBAL.CostPrice = string.IsNullOrEmpty(cost) ? -1 : Convert.ToDecimal(cost);
                    objPOBAL.DefaultCostPrice = objPOBAL.CostPrice;
                    
                    string retail = dataGridView1.Rows[i].Cells["RetailPrice"].Value.ToString().Trim();
                    objPOBAL.SellingPrice = string.IsNullOrEmpty(retail) ? -1 : Convert.ToDecimal(retail);
                    
                    string wholesale = dataGridView1.Rows[i].Cells["WholesalePrice"].Value.ToString().Trim();
                    objPOBAL.SellingPrice2 = string.IsNullOrEmpty(wholesale) ? -1 : Convert.ToDecimal(wholesale);
                    
                    string shop = dataGridView1.Rows[i].Cells["ShopPrice"].Value.ToString().Trim();
                    objPOBAL.ShopPrice = string.IsNullOrEmpty(shop) ? -1 : Convert.ToDecimal(shop);
                    
                    string disc = dataGridView1.Rows[i].Cells["RetailDiscountAmount"].Value.ToString().Trim();
                    objPOBAL.Discount = string.IsNullOrEmpty(disc) ? -1 : Convert.ToDecimal(disc);
                    
                    string wdisc = dataGridView1.Rows[i].Cells["WholesaleDiscountAmount"].Value.ToString().Trim();
                    objPOBAL.WholeSaleDiscount = string.IsNullOrEmpty(wdisc) ? -1 : Convert.ToDecimal(wdisc);
                    
                    listToImport.Add(objPOBAL);
                }

                insertDTStatus = false;
                await Task.Run(() =>
                {
                    ClassPODAL objPODAL = new ClassPODAL();
                    foreach (var objPOBAL in listToImport)
                    {
                        int count = objPODAL.UpdateImportStock(objPOBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }
                });

                if (insertDTStatus == true)
                {
                    MessageBox.Show("Items Prices Updated Successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private async void simpleButton10_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                List<ClassPOBAL> listToImport = new List<ClassPOBAL>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].IsNewRow) continue;
                    
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.ItemCode = dataGridView1.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                    
                    string avail = dataGridView1.Rows[i].Cells["AvailableQty"].Value.ToString().Trim();
                    objPOBAL.AvailableQty = string.IsNullOrEmpty(avail) ? 0 : Convert.ToDecimal(avail);
                    
                    listToImport.Add(objPOBAL);
                }

                insertDTStatus = false;
                await Task.Run(() =>
                {
                    ClassPODAL objPODAL = new ClassPODAL();
                    foreach (var objPOBAL in listToImport)
                    {
                        int count = objPODAL.ImportStockQty(objPOBAL);
                        if (count != 0)
                        {
                            insertDTStatus = true;
                        }
                    }
                });

                if (insertDTStatus == true)
                {
                    MessageBox.Show("Items Qty Imported Successfully.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
