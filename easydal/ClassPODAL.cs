using easyBAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyDAL
{
    public class ClassPODAL
    {
        ClassDataAccess objDataAccess = new ClassDataAccess();
        MySqlParameter[] param;

        #region Select


        public DataSet retreiveCustomerDepositChequesByCust(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerDepositChequesByCust", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomerDepositedCheques(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustomerDepositCheques", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAvailableVouchers(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAvailableGiftVoucher", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerTemplate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerTemplate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierTemplate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSupplierTemplate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllAttendance(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllAttendance", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTAWInvoiceHoldData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.SOHDId);
                obj.dataTable = "TKAInvoice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportTAWInvoiceHold", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAvailableSerial(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAvailableSerial", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllBranchSerialSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportSerialSummary", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseSalesWithStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSalesWithStock", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchStockTransfer(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchStockTransfer", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchProduction(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchProduction", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseStockMovement(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchStockMovement", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveGRNBCData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PIHDId1", obj.PIHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectGRNBarcodeData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllRemarks(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("DocTypeId1", obj.DocTypeId);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSOHDInvoiceRemarks", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivSearchInvoiceStatusReport(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSearchInvoiceStatus", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllInvoiceStatusReport(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllInvoiceStatus", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public int UpdateBarcode(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateItemBarcode", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveCustCreditReport(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                //param[2] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "DataTableCustCredit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportCustomerCreditSummary", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllFixedAssets(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllFixedAssets", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTrialBalance(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportTrialBalance", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllDepreciatePendingFixedAssets(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPendingDepriaciationFixedAssets", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllBranchStocksReport(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchStocksReport", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllBranchSerialReport(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSerial", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveDailyCollectionGrid(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportDayCollection", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllBranchStocks(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchStocks", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockMaintain(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectStockMaintainReport", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockTemplateStocks(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportStockTemplate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVarientStockTemplateStocks(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportStockTemplateVarient", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseDamage(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSpoilage", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwisePayments(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSupplierPayment", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseSupplierCredit(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSupplierCreditData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvoiceWiseSupplierCredit(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSupplierCreditData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }


        public DataSet retreiveBranchwiseCustomerPayments(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchCustomerPayment", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseCustomerCreditData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchCustomerCreditData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseCustomerPaymentsCollection(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchCreditCollection", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwisePurchase(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchPurchase", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwisePurchaseSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchPurchaseSummary", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseSalesRtn(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSalesRtn", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseSales(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSales", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseSalesCard(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSalesCard", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseSalesCardRefNo(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ReferanceNo1", obj.ReferanceNo);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSalesCardRefNo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockAdjustments(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportStockAdjustment", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerSales(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportCustomerSales", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveGiftVouchers(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectGiftVouchers", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSalesSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportSalesSummaryByDate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSupplierHistory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerHistory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePurchaseSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportPurchaseSummary", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalaryAdvance(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportSalaryAdvance", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllBranchStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllBranchesStock", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveLast100AllBranchStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectLast100AllBranchesStock", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllROLevelStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllROLevelStock", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomerCheques(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustomerCheques", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSupplierCheques(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllSupplierCheques", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierChequesBySupplier(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSupplierChequesBySupp", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerChequesByCust(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustomerChequesByCust", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStockByBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllStockByBranch", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStockByBranchItmCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllStockByBranchItmCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockAdjByBranchItmCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAdjustStockByCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStockByBranchItmName(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[1] = new MySqlParameter("ItemName1", obj.ItemName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllStockByBranchItmName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStockByBranchItmCat(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[1] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllStockByBranchItmCat", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStockByItmCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllStockByItmCategory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAdjStockByItmCat(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[1] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAdjStockByItmCat", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllOptions(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectTaxInvoice", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public int ImportItemCategory(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCategory1", obj.ItemCategory);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("ImportItemCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int ImportItemSubCategory(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemCategory1", obj.ItemCategory);
                param[1] = new MySqlParameter("ItemSubCateory1", obj.ItemSubCateory);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("ImportItemSubCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveSearchBOMByName(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemName1", obj.ItemName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSearchBOMByName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSearchBOMByCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSearchBOMByCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSearchStockByName(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemName1", obj.ItemName);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSearchItemsByName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSearchStockByCat(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[1] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSearchItemsByCat", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSearchStockByCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSearchItemsByCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemSubCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemSubCategory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockAllitemData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllItems", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicleInvoiceData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("VehicleNo1", obj.VehicleNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectVehicleInvoive", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBalanceSheetbyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableBalanceSheet";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBalanceSheet", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitLostbyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTablePAndL";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportProfitLost", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitLostbyDateAvgCost(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTablePAndL";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportProfitLostAvgCost", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitLostbyDateBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTablePAndL";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportProfitLostByBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitLostbyDateBranchAvgCost(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTablePAndL";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportProfitLostByBranchAvgCost", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIDatabyDateSupplier(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPIByDateSupplier", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPIByDate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIReturnDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPIRetuenByDate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIDTIdData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPIHDIdData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIHDIdData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPIHDIdData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIId(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPIID", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePODatabyDateSupplier(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOByDateSupplier", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePODatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOByDate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePOrerId(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOrderID", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePOrderHDIdData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOrderHDIdData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePOHeaderIdData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOrderData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveMaxItemId(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectMaxItem", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveHoldData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectHoldSelectedData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveDayEndData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSummaryReport", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemName(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectFinishGoods", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public int InsertSpoilage(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[3] = new MySqlParameter("Qty1", obj.Qty);
                param[4] = new MySqlParameter("BranchId1", obj.BranchId);
                param[5] = new MySqlParameter("Remarks1", obj.Remarks);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSpoilage", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveExpensesDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableExpenses";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportExpensesByDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBankBalance(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BankId1", obj.BankId);
                obj.dataTable = "DataTableBankBalance";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBankBalance", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveExpensesByCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("PayCatId1", obj.PayCatId);
                obj.dataTable = "DataTableExpenses";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportExpensesByCategory", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAll", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSalesOrders(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSalesOrders", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSalesInvoices(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSalesInvois", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllOrders(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllSalesOrders", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllInvoices(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllSalesInvoices", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePaymentModes(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllPaymentMods", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSupplierCombo(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllSupplierCombo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePOLoadingData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOLoad", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllBranches(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllBranchNames", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCategoryData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCategories", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivesSuppliers(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSuppliers", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranches(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllBranches", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllUsers(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllUsers", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePaymodes(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPaymodes", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomers(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustomers", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePOHDIdData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOHDIdData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTableData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("TblNo1", obj.TblNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectTableData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsByCat(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemsByCat", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsByCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemsByCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsByName(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemName1", obj.ItemName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemByName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierAddress(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSupplierAddress", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveFreeIssueDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableFreeIssue";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportFreeIssue", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBOMData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PIHDId1", obj.PIHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBOMIdData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCodeData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemCodeData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsIdData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemsIdData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCodeSelectedData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemCodeSelectedData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCodeVarientData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemCodeVariantData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCodeTransData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemCodeTransData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsIdTransData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemsIdTransData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePOId(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPOID", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePODataDateRange(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPODataDateRange", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePODataSupplier(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPODataSupplier", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePODataCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPODataCategory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        #endregion

        #region Insert

        public string InsertFixedAsset(Fixedasset obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "FAId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    
                    new MySqlParameter("AssetCode1", obj.AssetCode),
                    new MySqlParameter("AssetDescription1", obj.AssetDescription),
                    new MySqlParameter("Qty1", obj.Qty),
                    new MySqlParameter("UnitPrice1", obj.UnitPrice),
                    new MySqlParameter("Amount1", obj.Amount),
                    new MySqlParameter("NetAmount1", obj.NetAmount),
                    new MySqlParameter("DepreciationPerPeriod1", obj.DepreciationPerPeriod),
                    new MySqlParameter("TotalDepreciationPeriod1", obj.TotalDepreciationPeriod),
                    new MySqlParameter("WarrantyPeriod1", obj.WarrantyPeriod),
                    new MySqlParameter("DepreciationStartDate1", obj.DepreciationStartDate),
                    new MySqlParameter("NextDepreciationDate1", obj.NextDepreciationDate),
                    new MySqlParameter("CreatedUserId1", obj.CreatedUserId),
                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertFixedAsset", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertStockTransfer(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[3] = new MySqlParameter("BranchId1", obj.BranchId);
                param[4] = new MySqlParameter("ToBranchId1", obj.ToBranchId);
                param[5] = new MySqlParameter("TransferHDId1", obj.TransferHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertStockTransfer", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPIHD(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[15];
                param[0] = new MySqlParameter("PINo1", obj.PONo);
                param[1] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[3] = new MySqlParameter("ContactPerson1", obj.ContactPerson);
                param[4] = new MySqlParameter("PIGrossTotal1", obj.POGrossTotal);
                param[5] = new MySqlParameter("PINetTotal1", obj.PONetTotal);
                param[6] = new MySqlParameter("Remarks1", obj.Remarks);
                param[7] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[8] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[9] = new MySqlParameter("PIDiscount1", obj.PODiscount);
                param[10] = new MySqlParameter("PICash1", obj.POCash);
                param[11] = new MySqlParameter("PIBalance1", obj.POBalance);
                param[12] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[13] = new MySqlParameter("SupplierInvoiceNo1", obj.SupplierInvoiceNo);
                param[14] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPIHD", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public string InsertNewFGHD(ClassPOBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "PIHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    
                    new MySqlParameter("PINetTotal1", obj.POGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("BranchId1", obj.BranchId),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewFGHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewProductionHD(ClassPOBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "PIHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    
                    new MySqlParameter("PINetTotal1", obj.POGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ItemsId1", obj.ItemsId),
                    new MySqlParameter("ItemCode1", obj.ItemCode),
                    new MySqlParameter("Qty1", obj.Qty),
                    new MySqlParameter("PurchasePrice1", obj.PurchasePrice),
                    new MySqlParameter("SellingPrice1", obj.SellingPrice),
                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewProductionHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewGINHD(ClassPOBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "PIHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    
                    new MySqlParameter("PINetTotal1", obj.POGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ItemsId1", obj.ItemsId),
                    new MySqlParameter("ItemCode1", obj.ItemCode),
                    new MySqlParameter("Qty1", obj.Qty),
                    new MySqlParameter("PurchasePrice1", obj.PurchasePrice),
                    new MySqlParameter("SellingPrice1", obj.SellingPrice),
                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewGINHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewPIHD(ClassPOBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "PIHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("PINo1", obj.PONo),
                    new MySqlParameter("PurchaseDate1", obj.PurchaseDate),
                    new MySqlParameter("SupplierId1", obj.SupplierId),
                    new MySqlParameter("ContactPerson1", obj.ContactPerson),
                    new MySqlParameter("PIGrossTotal1", obj.POGrossTotal),
                    new MySqlParameter("PINetTotal1", obj.PONetTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("PIDiscount1", obj.PODiscount),
                    new MySqlParameter("PICash1", obj.POCash),
                    new MySqlParameter("PIBalance1", obj.POBalance),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("SupplierInvoiceNo1", obj.SupplierInvoiceNo),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditDueDays1", obj.CreditDueDays),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewPIHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewPIHDReturn(ClassPOBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "PIHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("PINo1", obj.PONo),
                    new MySqlParameter("PurchaseDate1", obj.PurchaseDate),
                    new MySqlParameter("SupplierId1", obj.SupplierId),
                    new MySqlParameter("ContactPerson1", obj.ContactPerson),
                    new MySqlParameter("PIGrossTotal1", obj.POGrossTotal),
                    new MySqlParameter("PINetTotal1", obj.PONetTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("PIDiscount1", obj.PODiscount),
                    new MySqlParameter("PICash1", obj.POCash),
                    new MySqlParameter("PIBalance1", obj.POBalance),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("SupplierInvoiceNo1", obj.SupplierInvoiceNo),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewPIHDReturn", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertPIDT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[22];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[4] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[5] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[6] = new MySqlParameter("MinQty1", obj.MinQty);
                param[7] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[8] = new MySqlParameter("Discount1", obj.Discount);
                param[9] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[10] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[11] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[12] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[13] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                param[14] = new MySqlParameter("BranchId1", obj.BranchId);
                param[15] = new MySqlParameter("AddBarcode1", obj.AddBarcode);
                param[16] = new MySqlParameter("WholesalePrice1", obj.WholesalePrice);
                param[17] = new MySqlParameter("ShopPrice1", obj.ShopPrice);
                param[18] = new MySqlParameter("ItemName1", obj.ItemName);
                param[19] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[20] = new MySqlParameter("TransferHDId1", obj.TransferHDId);
                param[21] = new MySqlParameter("FromBranchId1", obj.FromBranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPIDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPIDTRtn(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[17];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[4] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[5] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[6] = new MySqlParameter("MinQty1", obj.MinQty);
                param[7] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[8] = new MySqlParameter("Discount1", obj.Discount);
                param[9] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[10] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[11] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[12] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[13] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                param[14] = new MySqlParameter("BranchId1", obj.BranchId);
                param[15] = new MySqlParameter("ItemName1", obj.ItemName);
                param[16] = new MySqlParameter("SerialNo1", obj.SerialNo);
               

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPIDTRtn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPIDTReturn(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[18];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[4] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[5] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[6] = new MySqlParameter("MinQty1", obj.MinQty);
                param[7] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[8] = new MySqlParameter("Discount1", obj.Discount);
                param[9] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[10] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[11] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[12] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[13] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                param[14] = new MySqlParameter("BranchId1", obj.BranchId);
                param[15] = new MySqlParameter("AddBarcode1", obj.AddBarcode);
                param[16] = new MySqlParameter("ItemName1", obj.ItemName);
                param[17] = new MySqlParameter("SerialNo1", obj.SerialNo);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPIDTReturn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int ImportPIDT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                //param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                //param[3] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                //param[2] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[2] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                //param[6] = new MySqlParameter("MinQty1", obj.MinQty);
                //param[7] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[3] = new MySqlParameter("Discount1", obj.Discount);
                param[4] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                //param[10] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                param[8] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("ImportPIDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertProductionDT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[4] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertProductionDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertGINDT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[4] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertGINDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertFGDT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[4] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[5] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[6] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[7] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[8] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertFGDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPOrderHD(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("PONo1", obj.PONo);
                param[1] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[3] = new MySqlParameter("ContactPerson1", obj.ContactPerson);
                param[4] = new MySqlParameter("POGrossTotal1", obj.POGrossTotal);
                param[5] = new MySqlParameter("PONetTotal1", obj.PONetTotal);
                param[6] = new MySqlParameter("Remarks1", obj.Remarks);
                param[7] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[8] = new MySqlParameter("POHDId1", obj.POHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPOrderHD", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPOrderDT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[13];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[4] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[5] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[6] = new MySqlParameter("MinQty1", obj.MinQty);
                param[7] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[8] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[9] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[10] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[11] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[12] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPOrderDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSupplierCheque1(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("POHDId1", obj.POHDId);
                param[2] = new MySqlParameter("ChequeBank1", obj.ChequeBank);
                param[3] = new MySqlParameter("ChequeNo1", obj.ChequeNo);
                param[4] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("CashDepositStatus1", obj.CashDepositStatus);
                param[8] = new MySqlParameter("IssueDate1", obj.IssueDate);
                param[9] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSupplierCheque1", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPOHD(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[13];
                param[0] = new MySqlParameter("PONo1", obj.PONo);
                param[1] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[2] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                param[3] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[4] = new MySqlParameter("InvoiceNo1", obj.InvoiceNo);
                param[5] = new MySqlParameter("POGrossTotal1", obj.POGrossTotal);
                param[6] = new MySqlParameter("PODiscount1", obj.PODiscount);
                param[7] = new MySqlParameter("PONetTotal1", obj.PONetTotal);
                param[8] = new MySqlParameter("POCash1", obj.POCash);
                param[9] = new MySqlParameter("POBalance1", obj.POBalance);
                param[10] = new MySqlParameter("Remarks1", obj.Remarks);
                param[11] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[12] = new MySqlParameter("POHDId1", obj.POHDId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPOHD", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPODT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[14];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[3] = new MySqlParameter("ItemName1", obj.ItemName);
                param[4] = new MySqlParameter("ItemLocation1", obj.ItemLocation);
                param[5] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);
                param[6] = new MySqlParameter("MinQty1", obj.MinQty);
                param[7] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[8] = new MySqlParameter("Discount1", obj.Discount);
                param[9] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[10] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[11] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[12] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[13] = new MySqlParameter("PurchaseDate1", obj.PurchaseDate);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPODT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public string InsertItemSummary(ClassPOBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "ItemsId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("ItemCode1", obj.ItemCode),
                new MySqlParameter("ItemCatId1", obj.ItemCatId),
                new MySqlParameter("ItemName1", obj.ItemName),
                new MySqlParameter("Discount1", obj.Discount),
                new MySqlParameter("ItemUnit1", obj.ItemUnit),
                new MySqlParameter("CostPrice1", obj.CostPrice),
                new MySqlParameter("SellingPrice1", obj.SellingPrice),
                new MySqlParameter("MinQty1", obj.MinQty),
                new MySqlParameter("AvailableQty1", obj.AvailableQty),
                new MySqlParameter("ItemMode1", obj.ItemMode),
                new MySqlParameter("OpenBalDate1", obj.OpenBalDate),
                new MySqlParameter("CreatedBy1", obj.CreatedBy),
                new MySqlParameter("OpenStates", obj.OpenStates),
                new MySqlParameter("InValue1", obj.InValue),
                new MySqlParameter("InQty1", obj.InQty),
                new MySqlParameter("OutQty1", obj.OutQty),
                new MySqlParameter("OutValue1", obj.OutValue),
                new MySqlParameter("SItemName1", obj.SItemName),
                new MySqlParameter("ItemStatus", obj.ItemStatus),
                new MySqlParameter("SupplierId1", obj.SupplierId),
                new MySqlParameter("WarrantyPeriod1", obj.WarrantyPeriod),
                new MySqlParameter("FreeIssueEffectFrom1", obj.FreeIssueEffectFrom),
                new MySqlParameter("SellingPrice2", obj.SellingPrice2),
                new MySqlParameter("SPPRiceEffectFrom1", obj.SPPRiceEffectFrom),
                new MySqlParameter("BranchId1", obj.BranchId),
                new MySqlParameter("RackNo1", obj.RackNo),
                new MySqlParameter("ItemSubCatId1", obj.ItemSubCatId),
                new MySqlParameter("DefaultCostPrice1", obj.DefaultCostPrice),
                new MySqlParameter("MinSellingPrice1", obj.MinSellingPrice),
                new MySqlParameter("WholeSaleDiscount1", obj.WholeSaleDiscount),
                new MySqlParameter("ShopPrice1", obj.ShopPrice),
                new MySqlParameter("RetailDiscPer1", obj.RetailDiscPer),
                new MySqlParameter("WholesaleDiscPer1", obj.WholesaleDiscPer),
                //new MySqlParameter("ItemsId21", obj.ItemsId2),
                new MySqlParameter("MItemsId1", obj.MItemsId),
                new MySqlParameter("MItemCode1", obj.MItemCode),
                new MySqlParameter("ConvertionQty1", obj.ConvertionQty),
                new MySqlParameter("MaintainQty1", obj.MaintainQty),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertUpdateItemSummary", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertUpdateStockBarcode(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertBarcodeItems", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertUpdateStock(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[41];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[2] = new MySqlParameter("ItemName1", obj.ItemName);
                param[3] = new MySqlParameter("Discount1", obj.Discount);
                param[4] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[5] = new MySqlParameter("CostPrice1", obj.CostPrice);
                param[6] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[7] = new MySqlParameter("MinQty1", obj.MinQty);
                param[8] = new MySqlParameter("AvailableQty1", obj.AvailableQty);
                param[9] = new MySqlParameter("ItemMode1", obj.ItemMode);
                param[10] = new MySqlParameter("OpenBalDate1", obj.OpenBalDate);
                param[11] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[12] = new MySqlParameter("OpenStates", obj.OpenStates);
                param[13] = new MySqlParameter("InValue1", obj.InValue);
                param[14] = new MySqlParameter("InQty1", obj.InQty);
                param[15] = new MySqlParameter("OutQty1", obj.OutQty);
                param[16] = new MySqlParameter("OutValue1", obj.OutValue);
                param[17] = new MySqlParameter("SItemName1", obj.SItemName);
                param[18] = new MySqlParameter("ItemStatus", obj.ItemStatus);
                //param[19] = new MySqlParameter("Wharehouse1", obj.Wharehouse);
                param[19] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[20] = new MySqlParameter("WarrantyPeriod1", obj.WarrantyPeriod);
                param[21] = new MySqlParameter("FreeIssueEffectFrom1", obj.FreeIssueEffectFrom);
                param[22] = new MySqlParameter("SellingPrice2", obj.SellingPrice2);
                param[23] = new MySqlParameter("SPPRiceEffectFrom1", obj.SPPRiceEffectFrom);
                param[24] = new MySqlParameter("BranchId1", obj.BranchId);
                param[25] = new MySqlParameter("RackNo1", obj.RackNo);
                param[26] = new MySqlParameter("ItemSubCatId1", obj.ItemSubCatId);
                param[27] = new MySqlParameter("DefaultCostPrice1", obj.DefaultCostPrice);
                param[28] = new MySqlParameter("MinSellingPrice1", obj.MinSellingPrice);
                param[29] = new MySqlParameter("WholeSaleDiscount1", obj.WholeSaleDiscount);
                param[30] = new MySqlParameter("ShopPrice1", obj.ShopPrice);
                param[31] = new MySqlParameter("RetailDiscPer1", obj.RetailDiscPer);
                param[32] = new MySqlParameter("WholesaleDiscPer1", obj.WholesaleDiscPer);
                param[33] = new MySqlParameter("MaintainQty1", obj.MaintainQty);
                param[34] = new MySqlParameter("ScaleItem1", obj.ScaleItem);
                param[35] = new MySqlParameter("TItemName1", obj.TItemName);
                param[36] = new MySqlParameter("BundleItem1", obj.BundleItem);
                param[37] = new MySqlParameter("RawMaterial1", obj.RawMaterial);
                param[38] = new MySqlParameter("AllowSales1", obj.AllowSales);
                param[39] = new MySqlParameter("AllowPurchase1", obj.AllowPurchase);
                param[40] = new MySqlParameter("AllowInventory1", obj.AllowInventory);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertUpdateStock", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int ImportStock(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[43];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("ItemCategory1", obj.ItemCategory);
                param[2] = new MySqlParameter("ItemName1", obj.ItemName);
                param[3] = new MySqlParameter("Discount1", obj.Discount);
                param[4] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[5] = new MySqlParameter("CostPrice1", obj.CostPrice);
                param[6] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[7] = new MySqlParameter("MinQty1", obj.MinQty);
                param[8] = new MySqlParameter("AvailableQty1", obj.AvailableQty);
                param[9] = new MySqlParameter("ItemMode1", obj.ItemMode);
                param[10] = new MySqlParameter("OpenBalDate1", obj.OpenBalDate);
                param[11] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[12] = new MySqlParameter("OpenStates", obj.OpenStates);
                param[13] = new MySqlParameter("InValue1", obj.InValue);
                param[14] = new MySqlParameter("InQty1", obj.InQty);
                param[15] = new MySqlParameter("OutQty1", obj.OutQty);
                param[16] = new MySqlParameter("OutValue1", obj.OutValue);
                param[17] = new MySqlParameter("SItemName1", obj.SItemName);
                param[18] = new MySqlParameter("ItemStatus", obj.ItemStatus);
                param[19] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[20] = new MySqlParameter("WarrantyPeriod1", obj.WarrantyPeriod);
                param[21] = new MySqlParameter("FreeIssueEffectFrom1", obj.FreeIssueEffectFrom);
                param[22] = new MySqlParameter("SellingPrice2", obj.SellingPrice2);
                param[23] = new MySqlParameter("SPPRiceEffectFrom1", obj.SPPRiceEffectFrom);
                param[24] = new MySqlParameter("BranchId1", obj.BranchId);
                param[25] = new MySqlParameter("RackNo1", obj.RackNo);
                param[26] = new MySqlParameter("ItemSubCateory1", obj.ItemSubCateory);
                param[27] = new MySqlParameter("DefaultCostPrice1", obj.DefaultCostPrice);
                param[28] = new MySqlParameter("AddBarcode1", obj.AddBarcode);
                param[29] = new MySqlParameter("WholeSaleDiscount1", obj.WholeSaleDiscount);
                param[30] = new MySqlParameter("ShopPrice1", obj.ShopPrice);
                param[31] = new MySqlParameter("MinSellingPrice1", obj.MinSellingPrice);
                param[32] = new MySqlParameter("RetailDiscPer1", obj.RetailDiscPer);
                param[33] = new MySqlParameter("WholesaleDiscPer1", obj.WholesaleDiscPer);
                param[34] = new MySqlParameter("MaintainQty1", obj.MaintainQty);
                param[35] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[36] = new MySqlParameter("TItemName1", obj.TItemName);

                param[37] = new MySqlParameter("ScaleItem1", obj.ScaleItem);
                param[38] = new MySqlParameter("BundleItem1", obj.BundleItem);
                param[39] = new MySqlParameter("RawMaterial1", obj.RawMaterial);
                param[40] = new MySqlParameter("AllowSales1", obj.AllowSales);
                param[41] = new MySqlParameter("AllowPurchase1", obj.AllowPurchase);
                param[42] = new MySqlParameter("AllowInventory1", obj.AllowInventory);
                

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("ImportStock", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int ImportVarientStock(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[45];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("ItemCategory1", obj.ItemCategory);
                param[2] = new MySqlParameter("ItemName1", obj.ItemName);
                param[3] = new MySqlParameter("Discount1", obj.Discount);
                param[4] = new MySqlParameter("ItemUnit1", obj.ItemUnit);
                param[5] = new MySqlParameter("CostPrice1", obj.CostPrice);
                param[6] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[7] = new MySqlParameter("MinQty1", obj.MinQty);
                param[8] = new MySqlParameter("AvailableQty1", obj.AvailableQty);
                param[9] = new MySqlParameter("ItemMode1", obj.ItemMode);
                param[10] = new MySqlParameter("OpenBalDate1", obj.OpenBalDate);
                param[11] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[12] = new MySqlParameter("OpenStates", obj.OpenStates);
                param[13] = new MySqlParameter("InValue1", obj.InValue);
                param[14] = new MySqlParameter("InQty1", obj.InQty);
                param[15] = new MySqlParameter("OutQty1", obj.OutQty);
                param[16] = new MySqlParameter("OutValue1", obj.OutValue);
                param[17] = new MySqlParameter("SItemName1", obj.SItemName);
                param[18] = new MySqlParameter("ItemStatus", obj.ItemStatus);
                param[19] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[20] = new MySqlParameter("WarrantyPeriod1", obj.WarrantyPeriod);
                param[21] = new MySqlParameter("FreeIssueEffectFrom1", obj.FreeIssueEffectFrom);
                param[22] = new MySqlParameter("SellingPrice2", obj.SellingPrice2);
                param[23] = new MySqlParameter("SPPRiceEffectFrom1", obj.SPPRiceEffectFrom);
                param[24] = new MySqlParameter("BranchId1", obj.BranchId);
                param[25] = new MySqlParameter("RackNo1", obj.RackNo);
                param[26] = new MySqlParameter("ItemSubCateory1", obj.ItemSubCateory);
                param[27] = new MySqlParameter("DefaultCostPrice1", obj.DefaultCostPrice);
                param[28] = new MySqlParameter("AddBarcode1", obj.AddBarcode);
                param[29] = new MySqlParameter("WholeSaleDiscount1", obj.WholeSaleDiscount);
                param[30] = new MySqlParameter("ShopPrice1", obj.ShopPrice);
                param[31] = new MySqlParameter("MinSellingPrice1", obj.MinSellingPrice);
                param[32] = new MySqlParameter("RetailDiscPer1", obj.RetailDiscPer);
                param[33] = new MySqlParameter("WholesaleDiscPer1", obj.WholesaleDiscPer);
                param[34] = new MySqlParameter("MaintainQty1", obj.MaintainQty);
                param[35] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[36] = new MySqlParameter("TItemName1", obj.TItemName);
                param[37] = new MySqlParameter("MItemCode1", obj.MItemCode);
                param[38] = new MySqlParameter("ConvertionQty1", obj.ConvertionQty);
                param[39] = new MySqlParameter("ScaleItem1", obj.ScaleItem);
                param[40] = new MySqlParameter("BundleItem1", obj.BundleItem);
                param[41] = new MySqlParameter("RawMaterial1", obj.RawMaterial);
                param[42] = new MySqlParameter("AllowSales1", obj.AllowSales);
                param[43] = new MySqlParameter("AllowPurchase1", obj.AllowPurchase);
                param[44] = new MySqlParameter("AllowInventory1", obj.AllowInventory);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("ImportVarientStock", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateAllStock(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[13];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("ItemName1", obj.ItemName);
                param[2] = new MySqlParameter("CostPrice1", obj.CostPrice);
                param[3] = new MySqlParameter("SellingPrice1", obj.SellingPrice);
                param[4] = new MySqlParameter("MinQty1", obj.MinQty);
                param[5] = new MySqlParameter("AvailableQty1", obj.AvailableQty);
                param[6] = new MySqlParameter("SellingPrice2", obj.SellingPrice2);
                param[7] = new MySqlParameter("BranchId1", obj.BranchId);
                param[8] = new MySqlParameter("RackNo1", obj.RackNo);
                param[9] = new MySqlParameter("DefaultCostPrice1", obj.DefaultCostPrice);
                param[10] = new MySqlParameter("OpenStates", obj.OpenStates);
                param[11] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[12] = new MySqlParameter("ShopPrice1", obj.ShopPrice);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateAllStock", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateIssueChqReturn(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("SuppChqId1", obj.SuppChqId);
                param[1] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[2] = new MySqlParameter("POHDId1", obj.POHDId);
                param[3] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[4] = new MySqlParameter("RtnRemark1", obj.RtnRemark);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateIssueChqRtn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateIssueChqRealize(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("SuppChqId1", obj.SuppChqId);
                param[1] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[2] = new MySqlParameter("POHDId1", obj.POHDId);
                param[3] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[4] = new MySqlParameter("RtnRemark1", obj.RtnRemark);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[6] = new MySqlParameter("BankId1", obj.BankId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateIssueChqRealize", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateReceivedChqReturn(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("CustChqId1", obj.CustChqId);
                param[1] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[2] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[3] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[4] = new MySqlParameter("RtnRemark1", obj.RtnRemark);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateReceivedChqRtn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateReceivedChqRealize(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("CustChqId1", obj.CustChqId);
                param[1] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[2] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[3] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[4] = new MySqlParameter("RtnRemark1", obj.RtnRemark);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[6] = new MySqlParameter("BankId1", obj.BankId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateReceivedChqRealize", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateDiscount(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[4];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("DiscEffectFrom1", obj.date1);
                param[2] = new MySqlParameter("DiscEffectTo1", obj.date2);
                param[3] = new MySqlParameter("Discount1", obj.Discount);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateDiscount", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertUpdateMenu(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[3] = new MySqlParameter("ItemName1", obj.ItemName);
                param[4] = new MySqlParameter("Portion1", obj.Portion);
                param[5] = new MySqlParameter("CostPrice1", obj.CostPrice);
                param[6] = new MySqlParameter("SellingPrice1", obj.SellingPrice);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertMenu", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertReturn(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                param[1] = new MySqlParameter("PODTId1", obj.PODTId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("RtnReason1", obj.RtnReason);
                param[4] = new MySqlParameter("ReturnQty1", obj.ReturnQty);
                param[5] = new MySqlParameter("PurchasePrice1", obj.PurchasePrice);
                param[6] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[7] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPurchaseReturn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSupplierBankDeposit(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("POHDId1", obj.POHDId);
                param[2] = new MySqlParameter("ChequeBank1", obj.ChequeBank);
                //param[3] = new MySqlParameter("ChequeNo1", obj.ChequeNo);
                param[3] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                //param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
                param[4] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[5] = new MySqlParameter("BankId1", obj.BankId);
                param[6] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSupplierBankDeposit", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSupplierCheque(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("POHDId1", obj.POHDId);
                param[2] = new MySqlParameter("ChequeBank1", obj.ChequeBank);
                param[3] = new MySqlParameter("ChequeNo1", obj.ChequeNo);
                param[4] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("BankId1", obj.BankId);
                param[8] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSupplierCheque", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSupplierCredit(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("POHDId1", obj.POHDId);
                param[2] = new MySqlParameter("CreditAmount1", obj.CreditAmount);
                param[3] = new MySqlParameter("BalanceAmount1", obj.BalanceAmount);
                param[4] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[5] = new MySqlParameter("CreditDueDays1", obj.CreditDueDays);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertUpdateSupCredit", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        #endregion

        #region Update

        public int UpdateReceivedChqDeosit(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("CustChqId1", obj.CustChqId);
                param[1] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[2] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[3] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[4] = new MySqlParameter("RtnRemark1", obj.RtnRemark);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[6] = new MySqlParameter("BankId1", obj.BankId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateReceivedChqDeposit", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateUsedVoucher(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("VoucherNo1", obj.VoucherNo);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateusedVoucher", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateDepreciation(Fixedasset obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                param[0] = new MySqlParameter("AssetId1", obj.AssetId);
                param[1] = new MySqlParameter("DepreciationDate1", obj.DepreciationDate);
                param[2] = new MySqlParameter("DepreciationAmount1", obj.DepreciationAmount);
                param[3] = new MySqlParameter("NetValue1", obj.NetValue);
                param[4] = new MySqlParameter("DepreciatedUserId1", obj.DepreciatedUserId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertFixedAssetDepreciation", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public string InsertAdjustemtHD(ClassPOBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "StkAdjHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("TotalVariance1", obj.TotalVariance),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertStockAdjestmentHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertAdjustemtDT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("StkAdjHDId1", obj.StkAdjHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[3] = new MySqlParameter("SystemQty1", obj.SystemQty);
                param[4] = new MySqlParameter("PhisicalQty1", obj.PhisicalQty);
                param[5] = new MySqlParameter("BranchId1", obj.BranchId);
                param[6] = new MySqlParameter("VarrienceQty1", obj.VarrienceQty);
                param[7] = new MySqlParameter("AvgCost1", obj.AvgCost);
                param[8] = new MySqlParameter("VarrienceValue1", obj.VarrienceValue);
                param[9] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertStockAdjustmentDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateAdjustemt(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("ExistingQty1", obj.ExistingQty);
                param[3] = new MySqlParameter("NewQty1", obj.NewQty);
                param[4] = new MySqlParameter("AdjustedQty1", obj.AdjustedQty);
                param[5] = new MySqlParameter("BranchId1", obj.BranchId);
                param[6] = new MySqlParameter("UserID1", obj.UserID);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateStockAdjustment", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateStockAdjustment(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("FromItemId1", obj.FromItemId);
                param[1] = new MySqlParameter("ToItemId1", obj.ToItemId);
                param[2] = new MySqlParameter("FromItemCode1", obj.FromItemCode);
                param[3] = new MySqlParameter("ToItemCode1", obj.ToItemCode);
                param[4] = new MySqlParameter("FromQty1", obj.FromQty);
                param[5] = new MySqlParameter("ToQty1", obj.ToQty);
                param[6] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateProductConvert", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateProductConversion(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("FromItemId1", obj.FromItemId);
                param[1] = new MySqlParameter("ToItemId1", obj.ToItemId);
                param[2] = new MySqlParameter("FromItemCode1", obj.FromItemCode);
                param[3] = new MySqlParameter("ToItemCode1", obj.ToItemCode);
                param[4] = new MySqlParameter("FromQty1", obj.FromQty);
                param[5] = new MySqlParameter("ToQty1", obj.ToQty);
                param[6] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateProductConvert", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateSOHDTax(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("TaxStatus1", obj.TaxStatus);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateSOHDTax", param);
                objDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateSumaryToDeletePO(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("PODTId1", obj.PODTId);
                param[1] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateSumaryToDeletePO", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateSupplierRtnCredit(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                param[1] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[2] = new MySqlParameter("CreditAmount1", obj.CreditAmount);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateSuppReturnCredit", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }
        #endregion

        #region Delete

        public int DeletePODT(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                param[0] = new MySqlParameter("PODTId1", obj.PODTId);
                param[1] = new MySqlParameter("POHDId1", obj.POHDId);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[3] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[4] = new MySqlParameter("PurchaseQty1", obj.PurchaseQty);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeletePODT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeletePOHD(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                param[1] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[2] = new MySqlParameter("BalanceAmount1", obj.BalanceAmount);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeletePOHD", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteTableData(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("TblNo1", obj.TblNo);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteTableData", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteItem(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteItem", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteItemCat(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteItemCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteItemSubCat(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[1] = new MySqlParameter("ItemSubCatId1", obj.ItemSubCatId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteItemSubCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteMenuItem(ClassPOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteMenuItem", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        #endregion

        #region Exist
        
        #endregion

        #region Report

        public DataSet retreiveAllItemSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                //obj.DtDataSet = objDataAccess.executeReturnDataset("ReportDayCollection", param);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportItemHistoryAll", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllItemSummaryItemcode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                //obj.DtDataSet = objDataAccess.executeReturnDataset("ReportDayCollection", param);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportItemHistoryAllItemCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllItemSummaryBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                //obj.DtDataSet = objDataAccess.executeReturnDataset("ReportDayCollection", param);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportItemHistoryAllBranch", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllItemSummaryBranchItemcode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                //obj.DtDataSet = objDataAccess.executeReturnDataset("ReportDayCollection", param);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportItemHistoryAllBranchItemCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAvailableItemStockBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                //param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAvailableItemStockBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSuppCreditPaySupp(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.dataTable = "DataTableCustCreditPayments";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SupplierCreditPaySupp", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustCreditPaymentDetail(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "DataTableCustCreditPayments";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("CustomerOutstandingPaymentReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveExpensesReport(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportExpenses", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicleLogDetail(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportVehicleLogDetail", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicleLogSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportVehicleLogSummary", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicleLogData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("VehicleMilageHDId1", obj.VehicleMilageHDId);
                obj.dataTable = "DataTableVehicleLog";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportVehicleLogPrint", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchwiseSalesSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReportBranchSalesSummary", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyItemCategoryAll(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                //param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableAllCat";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByCategorySalesDateAll", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesSummarybyDateBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateSummaryPrintBrnch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesSummarybyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateSummaryPrint", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockSummarybyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableStockSummaryDayEnd";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportDayEndStockBalance", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveExpensePrintData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ExpensesId1", obj.ExpensesId);
                obj.dataTable = "DataTableExpenseReprint";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReprintExpenses", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBillDatabyDateUser(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("UserID1", obj.UserID);
                obj.dataTable = "DataTableBillDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAllBillsUser", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesRtnDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesRtnDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierPaymentData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[2] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);
                obj.dataTable = "DataTableSuppCreditPay";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportSupplierCreditPayNew", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateBranchTaxSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableTaxSummary";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("TaxReportBySalesDateSummaryBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateTaxSummary(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableTaxSummary";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("TaxReportBySalesDateSummary", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateBranchTax(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateBranchTax", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateTax(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateTax", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSummaryDataNew(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("date1", obj.date1);
                obj.dataTable = "DataTableDayEnd";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectNewSummaryReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSummaryDataNewBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableDayEnd";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectNewSummaryReportByBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSummaryDataNewByUser(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("UserID1", obj.UserID);

                obj.dataTable = "DataTableDayEnd";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectNewSummaryByUserReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDatePaymodeWithRtn(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("PayModeId1", obj.PayModeId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDatePayModeWithRtn", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateWithRtn(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateWithRtn", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesPriceBase(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTablePrice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDatePrice", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateRtn(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateRtn", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDatePaymodeRtn(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("PayModeId1", obj.PayModeId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDatePayModeRtn", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustCreditAnalysis(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "DataTableCustAutstanding";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("CustomerOutstandingReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                obj.dataTable = "DataTablePI";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportPIReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePIReturnData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                obj.dataTable = "DataTablePI";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportPIReturnReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTransferData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("TransferHDId1", obj.TransferHDId);
                obj.dataTable = "DataTableStockTransfer";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("PrintStockTransfer", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePOData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                obj.dataTable = "DataTablePO";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportPOReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesRtnData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.dataTable = "DataTableSalesRtn";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportSalesRtn", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvoiceData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.SOHDId);
                obj.dataTable = "DataTableInvoice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportInvoice", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTableRptData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("TblNo1", obj.TblNo);
                obj.dataTable = "resttable";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportKOT", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTakeawayRptData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.dataTable = "salesorderdt";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportTakeawayKOT", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTAWInvoiceDataReturn(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.SOHDId);
                obj.dataTable = "TKAInvoice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportTAWInvoiceReturn", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTAWInvoiceData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.SOHDId);
                obj.dataTable = "TKAInvoice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportTAWInvoice", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTAWGiftVoucherData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("VoucherNo1", obj.VoucherNo);
                obj.dataTable = "DataTableGiftVoucher";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("PrintGiftVoucher", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }


        public DataSet retreivePIPrint(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PIHDId1", obj.PIHDId);
                obj.dataTable = "DataTablePIPrintNew";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportPIPrint", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTAWQuotationData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.SOHDId);
                obj.dataTable = "TKAInvoice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportTAWQuotation", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTAWSOData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.SOHDId);
                obj.dataTable = "TKAInvoice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportTAWSO", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSummaryData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.dataTable = "DataTableDayEnd";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectSummaryReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVATInvoiceData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.dataTable = "TaxInvoice";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectVATInvioce", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePurchaseData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                obj.dataTable = "DataTablePOData";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectPOReportData", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateByBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDatePaymode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("PayModeId1", obj.PayModeId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDatePayMode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDatePaymodeBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[4];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[3] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDatePayModeBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesSummaryDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSalesSummary";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectSalesSummaryReport", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTaxSalesDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableTaxSales";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("TaxReportBySalesDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePurchasingDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTablePurchase";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByPurchaseDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePurchaseReturnDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTablePurchaseRtn";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportPurchaseRtnByDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSpoilageDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableDamage";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportSpoilageByDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveFGDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableFGPrint";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportFGByDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveGINDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableFGPrint";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportGINByDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDate3in(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "ItemSalesSummary";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDate3in", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyItemCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByItemCode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyDateCollection(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                //param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableSalesCollection";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBySalesDateCollection", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItrmHistorybyItemCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableItemSummary";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ItemHistoryByCode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItrmHistoryAll(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableItemSummary";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ItemHistoryAll", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTaxSalesDatabyItemCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableTaxSales";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("TaxSalesReportByItemCode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyItemCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByItemCategory", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierHistoryBySupplier(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.dataTable = "DataTableSupplierHistory";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SupplierHistoryBySupp", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierHistoryAll(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                //param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.dataTable = "DataTableSupplierHistory";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SupplierHistoryAll", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveTaxSalesDatabyItemCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableTaxSales";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("TaxSalesReportByItemCategory", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabySteward(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("RepId1", obj.RepId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByRep", param, obj);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyAllRep(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                //param[2] = new MySqlParameter("RepId1", obj.RepId);
                obj.dataTable = "DataTableRepSales";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportSalesByAllRep", param, obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDataSummarybyRep(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("RepId1", obj.RepId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByRep", param, obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCashbookHistory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableCashBookHistory";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("CashHistory", param, obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        //public DataSet retreiveSalesDatabyC(ClassPOBAL obj)
        //{
        //    try
        //    {
        //        param = new MySqlParameter[3];
        //        param[0] = new MySqlParameter("date1", obj.date1);
        //        param[1] = new MySqlParameter("date2", obj.date2);
        //        param[2] = new MySqlParameter("RepId1", obj.RepId);
        //        obj.dataTable = "DataTableSales";
        //        obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByRep", param, obj);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return obj.DtDataSet;
        //}

        public DataSet retreiveSalesDatabyCust(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "DataTableSalesSP";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportSalesByCustomer", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerHistorybyCust(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "DataTableCustomerHistory";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("CustomerHistoryByCust", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerAdvbyCust(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "DataTableAdv";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("CustomerAdvanceByCust", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerAdvAll(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableAdv";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("CustomerAdvAll", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerHistoryAll(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableCustomerHistory";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("CustomerHistoryAll", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSalesDatabyBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableNewSales";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportSalesByBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePurchasingDatabySup(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.dataTable = "DataTablePurchase";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportByPurchaseDateSupp", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePurchaseReturnbySup(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.dataTable = "DataTablePurchaseRtn";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportPurchaseRtnByDateSupp", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveEmpSalSlipData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PaymentID1", obj.PaymentID);
                obj.dataTable = "EmployeeSalarySlip";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SelectEmpSalSlip", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerPaymentData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[2] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);
                obj.dataTable = "DataTableCreditPay";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportCustomerCreditPay", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockAdjustmentData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("StkAdjHDId1", obj.StkAdjHDId);
                obj.dataTable = "DataTableStkAdgPrint";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportSTKAdgPrint", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveFGData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);
                obj.dataTable = "DataTableFGPrint";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportFGPrint", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveGINData(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);
                obj.dataTable = "DataTableFGPrint";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportGINPrint", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAllStock", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveStockCount(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStockCount", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveDailyCollection(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataSetCredit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportDayCollection", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCodeStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStockByItemCode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCategoryAllStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStockByItemCategory", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCodeBranchStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStockByBranchItemCode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCatBranchStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStockByBranchItemCat", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveNewDailyCollection(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataSetReport";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportDayCollection", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCat3Intock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStockByItemCat3In", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreive3inchAllStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStock3InAll", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchItemCodeStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableBranchStock";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBranchStockByItemCode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreive0ItemStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("Report0ItemStock", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranch0ItemStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                //param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBranchStock0Items", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAvailableItemStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAvailableItemStock", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchAvailableItemStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                //param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBranchAvailableStock", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemCategoryStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportStockByCategory", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchAllStock(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAllBranchStock", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchAllStockByCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                //param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableStockDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBranchAllStock", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBillDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableBillDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAllBills", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBillDatabyCash(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableBillDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAllCashBills", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBillDatabyCredit(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);

                obj.dataTable = "DataTableBillDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportAllCreditBills", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBillDatabyBillNo(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.BillNo);

                obj.dataTable = "DataTableBillDetails";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportBillsByBillNo", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveIssueChequeBYIssDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSupplierCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportIssChekIssDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveIssueChequeBYIssDateBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableSupplierCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportIssChekIssDateBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveIssueChequeBYeXPDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSupplierCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportIssCheqExpDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveIssueChequeBYeXPDateBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableSupplierCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportIssCheqExpDateBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveIssueChequeBYSupplier(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.dataTable = "DataTableSupplierCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportIssCheqSupp", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveIssueChequeBYSupplierBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableSupplierCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportIssCheqSuppBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReceivedChequeBYIssDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "CustomerCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportReceChequeByIssDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReceivedChequeBYIssDateBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "CustomerCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportReceChequeByIssDateBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReceivedChequeBYExpDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "CustomerCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportReceChequeByExpDate", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReceivedChequeBYExpDateBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "CustomerCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportReceChequeByExpDateBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReceivedChequeBYCustomer(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "CustomerCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportReceChequeByCustomer", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReceivedChequeBYCustomerBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "CustomerCheque";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportReceChequeByCustomerBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustCreditAll(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableCustCredit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportCustomerCredit", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustCreditCustomer(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.dataTable = "DataTableCustCredit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportCustomerCreditByCust", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustCreditByArea(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("NewAreaId1", obj.NewAreaId);
                obj.dataTable = "DataTableCustCredit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportCustomerCreditByArea", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSuppCreditAll(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableSupplierCredit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SupplierCreditAll", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSuppCreditSupp(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.dataTable = "DataTableSupplierCredit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("SupplierCreditSupp", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.dataTable = "DataTableGrossProfitData";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportGrossProfit", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitCatDatabyDate(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableGrossProfitData";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportGrossProfitByCat", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveGrossProfitItemCode(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.dataTable = "DataTableGrossProfitData";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportGrossProfitItMCode", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveGrossProfitBranch(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.dataTable = "DataTableGrossProfitData";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportGrossProfitBranch", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitbyItemCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableGrossProfit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportGrossProfitItmCat", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReloadProfitbyItemCategory(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                param[2] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.dataTable = "DataTableReloadProfit";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportReloadProfit", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveProfitLost(ClassPOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("POHDId1", obj.POHDId);
                obj.dataTable = "DataTableProfitLost";
                obj.DtDataSet = objDataAccess.executeReturnReportDataset("ReportProfitLost", param, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        #endregion
    }
}
