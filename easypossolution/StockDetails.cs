using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Windows.Forms.Design;
using easyPOSSolution;
using easyBAL;
using easyDAL;
using System.IO;

namespace easyPOSSolution
{
    public partial class StockDetails : Form
    {
        
        #region Local Variables

        ClassPOBAL objBAL = new ClassPOBAL();
        ClassPODAL objDAL = new ClassPODAL();

        #endregion

        #region Constructor

        public StockDetails()
        {
            InitializeComponent();
        }

        #endregion


        #region Methods

        private void loadCategory()
        {
            try
            {
                ClassPOBAL objPOBAL = new ClassPOBAL();
                ClassPODAL objPODAL = new ClassPODAL();
                comboBoxItemCategory.DataSource = objPODAL.retreivePOLoadingData(objPOBAL).Tables[3];
                comboBoxItemCategory.DisplayMember = "ItemCatName";
                comboBoxItemCategory.ValueMember = "ItemCatId";
                comboBoxItemCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadItemCodeStock()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCodeStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadItemCaegoryStock()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCategoryAllStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadItemCodeStockByBranch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCodeBranchStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadItemCategoryStockByBranch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCatBranchStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadItemCatStockByBranch()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport3In rpt = new CrystalReportStockReport3In();
                objBAL = new ClassPOBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCat3Intock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Stock3inchAll()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport3In rpt = new CrystalReportStockReport3In();
                objBAL = new ClassPOBAL();
                //objBAL.ItemCatId = Convert.ToInt32(comboBoxItemCategory.SelectedValue.ToString());
                //objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreive3inchAllStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadBranchItemCodeStock()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportBranchStockReport rpt = new CrystalReportBranchStockReport();
                objBAL = new ClassPOBAL();
                objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBranchItemCodeStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadItemCategoryStock()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                objBAL.ItemCatId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveItemCategoryStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAllBranchStock()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //CrystalReportBranchStockReport rpt = new CrystalReportBranchStockReport();
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                //objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBranchAllStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadBranchAllStock()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //CrystalReportBranchStockReport rpt = new CrystalReportBranchStockReport();
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                //objBAL.ItemCode = textBoxItemCode.Text.Trim();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveBranchAllStockByCode(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        private void StockDetails_Load(object sender, EventArgs e)
        {
            ClassPOBAL objBAL = new ClassPOBAL();
            ClassPODAL objDAL = new ClassPODAL();

            if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
            {
                comboBoxWarehouse.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxWarehouse.DisplayMember = "BranchName";
                comboBoxWarehouse.ValueMember = "BranchId";
                comboBoxWarehouse.SelectedIndex = 0;
            }
            if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
            {
                comboBoxDCWarehouse.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxDCWarehouse.DisplayMember = "BranchName";
                comboBoxDCWarehouse.ValueMember = "BranchId";
                comboBoxDCWarehouse.SelectedIndex = 0;
            }
            if (objDAL.retreivePOLoadingData(objBAL).Tables[5].Rows.Count > 0)
            {
                comboBoxDCWarehouseH.DataSource = objDAL.retreivePOLoadingData(objBAL).Tables[5];
                comboBoxDCWarehouseH.DisplayMember = "BranchName";
                comboBoxDCWarehouseH.ValueMember = "BranchId";
                comboBoxDCWarehouseH.SelectedIndex = 0;
            }
            loadCategory();

        }

        private void buttonAllStock_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockReport rpt = new CrystalReportStockReport();
                objBAL = new ClassPOBAL();
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveAllStock(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedIndex != -1)
            {
                textBoxItemCode.Clear();
            }
        }

        private void buttonViewReport_Click(object sender, EventArgs e)
        {
            if (textBoxItemCode.Text != "")
            {
                if (comboBoxWarehouse.SelectedIndex != -1)
                {
                    loadItemCodeStockByBranch();
                }
                else
                {
                    loadItemCodeStock();
                }
                
            }
            else if (comboBoxItemCategory.SelectedIndex != -1)
            {
                if (comboBoxWarehouse.SelectedIndex != -1)
                {
                    loadItemCategoryStockByBranch();
                }
                else
                {
                    loadItemCaegoryStock();
                }
            }
            else
            {
                if (comboBoxWarehouse.SelectedIndex != -1)
                {
                    loadBranchAllStock();
                }
                else
                {
                    
                    loadAllBranchStock();
                }

            }
        }

        #endregion

        private void buttonExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxWarehouse.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //CrystalReportBranchStockReport rpt = new CrystalReportBranchStockReport();
                    CrystalReportStockReport rpt = new CrystalReportStockReport();
                    objBAL = new ClassPOBAL();
                    objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveBranch0ItemStock(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportStockReport rpt = new CrystalReportStockReport();
                    objBAL = new ClassPOBAL();
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreive0ItemStock(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxWarehouse.SelectedIndex != -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //CrystalReportBranchStockReport rpt = new CrystalReportBranchStockReport();
                    CrystalReportStockReport rpt = new CrystalReportStockReport();
                    objBAL = new ClassPOBAL();
                    objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveBranchAvailableItemStock(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportStockReport rpt = new CrystalReportStockReport();
                    objBAL = new ClassPOBAL();
                    objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveAvailableItemStock(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer3.ReportSource = rpt;
                    crystalReportViewer3.Refresh();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBoxWarehouse.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxItemCode.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //comboBoxBranch.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedIndex != -1)
            {
                loadItemCatStockByBranch();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stock3inchAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                CrystalReportStockCount rpt = new CrystalReportStockCount();
                objBAL = new ClassPOBAL();
                objBAL.BranchId = Convert.ToInt32(comboBoxWarehouse.SelectedValue.ToString());
                objDAL = new ClassPODAL();
                objBAL.DtDataSet = objDAL.retreiveStockCount(objBAL);
                rpt.SetDataSource(objBAL.DtDataSet);
                crystalReportViewer3.ReportSource = rpt;
                crystalReportViewer3.Refresh();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllBranchStocksReport(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl5.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    //gridView5.Columns["BranchId"].Visible = false;
                    gridView5.OptionsView.ColumnAutoWidth = false;
                    gridView5.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                //string FileName = "C:\\ExportData\\Commision.xls";
                //gridControl1.ExportToXls(FileName);
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl5.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl5.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl5.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl5.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl5.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl5.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    CrystalReportDailyCollection rpt = new CrystalReportDailyCollection();
            //    objBAL = new ClassPOBAL();
            //    objBAL.BranchId = Convert.ToInt32(comboBoxDCWarehouse.SelectedValue.ToString());
            //    objDAL = new ClassPODAL();
            //    objBAL.DtDataSet = objDAL.retreiveDailyCollection(objBAL);
            //    rpt.SetDataSource(objBAL.DtDataSet);
            //    crystalReportViewer1.ReportSource = rpt;
            //    crystalReportViewer1.Refresh();
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    CrystalReportDC rpt = new CrystalReportDC();
            //    objBAL = new ClassPOBAL();
            //    objBAL.BranchId = Convert.ToInt32(comboBoxDCWarehouse.SelectedValue.ToString());
            //    objDAL = new ClassPODAL();
            //    objBAL.DtDataSet = objDAL.retreiveNewDailyCollection(objBAL);
            //    rpt.SetDataSource(objBAL.DtDataSet);
            //    crystalReportViewer3.ReportSource = rpt;
            //    crystalReportViewer3.Refresh();
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                objPOBAL.BranchId = Convert.ToInt32(comboBoxDCWarehouse.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl1.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveDailyCollectionGrid(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl1.DataSource = objPOBAL.DtDataSet.Tables[0];
                    gridView1.Columns["ShortExces"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    //gridView5.Columns["BranchId"].Visible = false;
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

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                //string FileName = "C:\\ExportData\\Commision.xls";
                //gridControl1.ExportToXls(FileName);
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                gridControl1.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                gridControl1.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                gridControl1.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                gridControl1.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                gridControl1.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                gridControl1.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBoxItemCategory.SelectedIndex = -1;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClassPOBAL objPOBAL = new ClassPOBAL();
                //objPOBAL.BranchId = Convert.ToInt32(comboBoxSearchWH.SelectedValue.ToString());
                ClassPODAL objPODAL = new ClassPODAL();
                gridControl5.DataSource = null;
                objPOBAL.DtDataSet = objPODAL.retreiveAllBranchSerialReport(objPOBAL);
                if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControl5.DataSource = objPOBAL.DtDataSet.Tables[0];
                    //gridView1.Columns["Discount"].Visible = false;
                    //gridView1.Columns["ItemsId"].Visible = false;
                    //gridView5.Columns["BranchId"].Visible = false;
                    gridView5.OptionsView.ColumnAutoWidth = false;
                    gridView5.BestFitColumns();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            comboBoxDCWarehouseH.SelectedIndex = -1;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBoxItemCodeRpt.Clear();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBoxDCWarehouseH.SelectedIndex == -1 && textBoxItemCodeRpt.Text == "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    //objPOBAL.BranchId = Convert.ToInt32(comboBoxDCWarehouseH.SelectedValue.ToString());
                    ClassPODAL objPODAL = new ClassPODAL();
                    gridControl2.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllItemSummary(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl2.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView2.Columns["ShortExces"].Visible = false;
                        //gridView2.Columns["ItemsId"].Visible = false;
                        //gridView5.Columns["BranchId"].Visible = false;
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBoxDCWarehouseH.SelectedIndex == -1 && textBoxItemCodeRpt.Text != "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    //objPOBAL.BranchId = Convert.ToInt32(comboBoxDCWarehouseH.SelectedValue.ToString());
                    objPOBAL.ItemCode = textBoxItemCodeRpt.Text;
                    ClassPODAL objPODAL = new ClassPODAL();
                    gridControl2.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllItemSummaryItemcode(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl2.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView2.Columns["ShortExces"].Visible = false;
                        //gridView2.Columns["ItemsId"].Visible = false;
                        //gridView5.Columns["BranchId"].Visible = false;
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBoxDCWarehouseH.SelectedIndex != -1 && textBoxItemCodeRpt.Text == "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxDCWarehouseH.SelectedValue.ToString());
                    //objPOBAL.ItemCode = textBoxItemCodeRpt.Text;
                    ClassPODAL objPODAL = new ClassPODAL();
                    gridControl2.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllItemSummaryBranch(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl2.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView2.Columns["ShortExces"].Visible = false;
                        //gridView2.Columns["ItemsId"].Visible = false;
                        //gridView5.Columns["BranchId"].Visible = false;
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBoxDCWarehouseH.SelectedIndex != -1 && textBoxItemCodeRpt.Text != "")
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ClassPOBAL objPOBAL = new ClassPOBAL();
                    objPOBAL.BranchId = Convert.ToInt32(comboBoxDCWarehouseH.SelectedValue.ToString());
                    objPOBAL.ItemCode = textBoxItemCodeRpt.Text;
                    ClassPODAL objPODAL = new ClassPODAL();
                    gridControl2.DataSource = null;
                    objPOBAL.DtDataSet = objPODAL.retreiveAllItemSummaryBranchItemcode(objPOBAL);
                    if (objPOBAL.DtDataSet.Tables[0].Rows.Count > 0)
                    {
                        gridControl2.DataSource = objPOBAL.DtDataSet.Tables[0];
                        //gridView2.Columns["ShortExces"].Visible = false;
                        //gridView2.Columns["ItemsId"].Visible = false;
                        //gridView5.Columns["BranchId"].Visible = false;
                        gridView2.OptionsView.ColumnAutoWidth = false;
                        gridView2.BestFitColumns();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void StockDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                textBoxItemCode.Select();
                FormItemSearch frm16 = new FormItemSearch();
                frm16.frm16 = this;
                frm16.form = 16;
                frm16.wh = 1;
                frm16.lblUser.Text = lblUser.Text.Trim();
                frm16.lblUserId.Text = lblUserId.Text;
                frm16.ShowDialog(this);
            }
        }

        

        #region Validation Methods

        #endregion


    }
}
