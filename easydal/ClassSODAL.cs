using easyBAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyDAL
{
    public class ClassSODAL
    {
        ClassDataAccess objDataAccess = new ClassDataAccess();
        MySqlParameter[] param;

        #region Select

        public DataSet retreiveStockAdjustmentData(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ReprintStockAdjustment", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllPendingInvoices(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("date1", obj.date1);
                //param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("AllCustomerPendingInvoice", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStockTransferByID(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("TransferHDId1", obj.TransferHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectStockTransferData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllVehicleLog(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllVehicleLog", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveRemarks(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectRemarks", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveExpenseData(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllExpensesReport", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllAvbleStk(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPendingStock", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllInvoices(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("AllCustomerInvoice", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllQuotations(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("AllCustomerQuotation", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCreditPay(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustCreditPay", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSuppCreditPay(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllSuppCreditPay", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllFG(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllFG", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllStockTransfer(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllStockTransfers", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomers(ClassSOBAL obj)
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

        public DataSet retreiveSOLoadingData(ClassSOBAL obj)
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

        public DataSet retreiveBillData(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBillRecords", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicleNoData(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBillRecords", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSODataDateRange(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSODataDateRange", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveIssueChq(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectIssuedChqs", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReceivedChq(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectReceivedChqs", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSODataCustomer(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSODataCustomer", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSODataCategory(ClassSOBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSODataCategory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        #endregion

        #region Insert

        public int InsertReturn(ClassSOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[11];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("SODTId1", obj.SODTId);
                param[2] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[3] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[4] = new MySqlParameter("RtnReason1", obj.RtnReason);
                param[5] = new MySqlParameter("ReturnQty1", obj.ReturnQty);
                param[6] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[7] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[8] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[9] = new MySqlParameter("CreditStatus", obj.CreditStatus);
                param[10] = new MySqlParameter("FreeIssue1", obj.FreeIssue);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSalesReturn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCancellation(ClassSOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ModifiedBy1", obj.CreatedBy);
                param[2] = new MySqlParameter("RtnReason1", obj.RtnReason);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceCancellation", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertPurchaseCancellation(ClassSOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("PIHDId1", obj.POHDId);
                param[1] = new MySqlParameter("ModifiedBy1", obj.CreatedBy);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPurchaseCancellation", param);
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

        public int UpdateCustomerRtnCredit(ClassSOBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("BillNo1", obj.BillNo);
                param[1] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[2] = new MySqlParameter("CreditAmount1", obj.CreditAmount);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateCustReturnCredit", param);
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
    }
}
