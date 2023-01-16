using easyBAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyDAL
{
    public class ClassInvoiveDAL
    {
        ClassDataAccess objDataAccess = new ClassDataAccess();
        MySqlParameter[] param;

        public int InsertCustomerChequeCreditPay(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[2] = new MySqlParameter("ChequeBank1", obj.ChequeBank);
                param[3] = new MySqlParameter("ChequeNo1", obj.ChequeNo);
                param[4] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("BankId1", obj.BankId);
                param[8] = new MySqlParameter("BranchId1", obj.BranchId);
                param[9] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertCreditPayCustomerCheck", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreivevaucherCodeData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("VoucherCode1", obj.VoucherCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectVoucherCodeData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvExistDH(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                //param[1] = new MySqlParameter("DocTypeId1", obj.DocTypeId);

                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSOHDExistData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvExistDT(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                //param[1] = new MySqlParameter("DocTypeId1", obj.DocTypeId);

                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSOExistDT", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvHoldDH(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                //param[1] = new MySqlParameter("DocTypeId1", obj.DocTypeId);

                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSOHDHoldHD", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvHoldDT(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                //param[1] = new MySqlParameter("DocTypeId1", obj.DocTypeId);

                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSOHDHoldDT", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public string UpdateHoldNewhd(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("RefNo1", obj.RefNo),
                    new MySqlParameter("ReferanceNo1", obj.ReferanceNo),
                    new MySqlParameter("TerminalNo1", obj.TerminalNo),
                    new MySqlParameter("VoucherNo1", obj.VoucherNo),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("ReceivableAmount1", obj.ReceivableAmount),
                    new MySqlParameter("CustomerName1", obj.CustomerName),
                    new MySqlParameter("Charges1", obj.Charges),
                    new MySqlParameter("CreditDueDays1", obj.CreditDueDays),
                    new MySqlParameter("CompletedDate1", obj.CompletedDate),
                    new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId),
                    new MySqlParameter("RepairBill1", obj.RepairBill),
                    new MySqlParameter("LoyaltyPoints1", obj.LoyaltyPoints),
                    new MySqlParameter("LoyaltyBalance1", obj.LoyaltyBalance),
                    new MySqlParameter("ReturnNoteNo1", obj.ReturnNoteNo),
                    new MySqlParameter("ReturnNoteAmount1", obj.ReturnNoteAmount),
                    new MySqlParameter("CashBalance1", obj.CashBalance),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("UpdateNewHoldSOHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertHoldNewsohd(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("RefNo1", obj.RefNo),
                    new MySqlParameter("ReferanceNo1", obj.ReferanceNo),
                    new MySqlParameter("TerminalNo1", obj.TerminalNo),
                    new MySqlParameter("VoucherNo1", obj.VoucherNo),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("ReceivableAmount1", obj.ReceivableAmount),
                    new MySqlParameter("CustomerName1", obj.CustomerName),
                    new MySqlParameter("Charges1", obj.Charges),
                    new MySqlParameter("CreditDueDays1", obj.CreditDueDays),
                    new MySqlParameter("CompletedDate1", obj.CompletedDate),
                    new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId),
                    new MySqlParameter("RepairBill1", obj.RepairBill),
                    new MySqlParameter("LoyaltyPoints1", obj.LoyaltyPoints),
                    new MySqlParameter("LoyaltyBalance1", obj.LoyaltyBalance),
                    new MySqlParameter("ReturnNoteNo1", obj.ReturnNoteNo),
                    new MySqlParameter("ReturnNoteAmount1", obj.ReturnNoteAmount),
                    new MySqlParameter("CashBalance1", obj.CashBalance),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("UpdateNewHoldInvoiceSOHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewsohdHold(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("RefNo1", obj.RefNo),
                    new MySqlParameter("ReferanceNo1", obj.ReferanceNo),
                    new MySqlParameter("TerminalNo1", obj.TerminalNo),
                    new MySqlParameter("VoucherNo1", obj.VoucherNo),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("ReceivableAmount1", obj.ReceivableAmount),
                    new MySqlParameter("CustomerName1", obj.CustomerName),
                    new MySqlParameter("Charges1", obj.Charges),
                    new MySqlParameter("CreditDueDays1", obj.CreditDueDays),
                    new MySqlParameter("CompletedDate1", obj.CompletedDate),
                    new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId),
                    new MySqlParameter("RepairBill1", obj.RepairBill),
                    new MySqlParameter("LoyaltyPoints1", obj.LoyaltyPoints),
                    new MySqlParameter("LoyaltyBalance1", obj.LoyaltyBalance),
                    new MySqlParameter("ReturnNoteNo1", obj.ReturnNoteNo),
                    new MySqlParameter("ReturnNoteAmount1", obj.ReturnNoteAmount),
                    new MySqlParameter("CashBalance1", obj.CashBalance),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewInvoiceSOHDHold", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertSoDtHold(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[17];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[14] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[15] = new MySqlParameter("PriceMethod1", obj.PriceMethod);
                param[16] = new MySqlParameter("DiscPer1", obj.DiscPer);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceSODTHold", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteHoldData(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteHoldData", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteDTData(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteDTData", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveCustomerInvoiceData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerByInvoice", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        //public DataSet retreiveCustomerContactData(ClassInvoiceBAL obj)
        //{
        //    try
        //    {
        //        param = new MySqlParameter[1];
        //        param[0] = new MySqlParameter("CustomerTelNo1", obj.CustomerTelNo);
        //        obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerContactCode", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return obj.DtDataSet;
        //}

        public int DeleteBarcode(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BarcodeId1", obj.BarcodeId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteBarcode", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveBarcodes(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBarcodes", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSerialItemCode(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SerialNo1", obj.SerialNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSerialItemCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveReturnnoData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ReturnNo1", obj.ReturnNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectReturnNoData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public int UpdateInvRemarks(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId);
                param[2] = new MySqlParameter("Remarks1", obj.Remarks);
                param[3] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[4] = new MySqlParameter("DocTypeId1", obj.DocTypeId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateInvoiceRemarks", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateInvStatus(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateInvoiceStatus", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateRemarks(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("Remarks1", obj.Remarks);
                param[2] = new MySqlParameter("CreatedBy1", obj.CreatedBy);                

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertRemarks", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateFinishDate(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("CompletedDate1", obj.CompletedDate);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateFinishDate", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateInvDisc(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal);
                param[2] = new MySqlParameter("SODiscount1", obj.SODiscount);
                param[3] = new MySqlParameter("Charges1", obj.Charges);
                //param[3] = new MySqlParameter("TransportOther1", obj.TransportOther);
                param[4] = new MySqlParameter("SONetTotal1", obj.SONetTotal);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvDisc", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveInvDisc(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("DocTypeId1", obj.DocTypeId);
                
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSOHDDisc", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet SelectMaxVoucherNO(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectMaxVoucherNo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public string InsertGiftVoucher(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "VoucherNo1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };

                 MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("IssueDate1", obj.IssueDate),
                    new MySqlParameter("ExpireDate1", obj.ExpireDate),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("VoucherCode1", obj.VoucherCode),

                    outParam };

                 objDataAccess.beginTransaction();
                 objDataAccess.executeReturnInt("InsertGiftVoucher", sqlParams);
                 objDataAccess.commitTransaction();
                 return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int CancelGiftVoucher(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("VoucherNo1", obj.VoucherNo);
                param[1] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("CancellVoucher", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateNextDueDays(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateNextDueDate", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateNewStock(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateNewProduct", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateDueDays(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[0];
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateDueDays", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveBarcodeItems(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBarcodeItems", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public int DeleteAllBarcode(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[0];

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteAllBarcode", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertBarcodeItem(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[1] = new MySqlParameter("ItemName1", obj.ItemName);
                param[2] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[3] = new MySqlParameter("BCQty1", obj.SalesQty);
                param[4] = new MySqlParameter("BCPrice1", obj.SalesPrice);
                param[5] = new MySqlParameter("BCStart1", obj.BCStart);
                param[6] = new MySqlParameter("BCEnd1", obj.BCEnd);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("IsertBarcodeItem", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertTempSoDt(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("ItemName1", obj.ItemName);
                param[3] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[4] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[5] = new MySqlParameter("Discount1", obj.Discount);
                param[6] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[7] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[8] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[9] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                //param[10] = new MySqlParameter("Warranty1", obj.Warranty);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertHold", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteTemp(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[0];
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteTemp", param);
                objDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteTempId(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteTempSelected", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteRetailPrice(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemRtPriceId1", obj.ItemRtPriceId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteRetailPrice", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteWholesalePrice(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemWHPriceId1", obj.ItemWHPriceId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteWholesalePrice", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteShopPrice(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ShopPriceId1", obj.ShopPriceId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteShopPrice", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public DataSet retreiveHoldBills(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectHoldBills", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveRetailPrices(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectRetailPrices", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveWholesalePrices(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectWholesalePrices", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveShopPrices(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectShopPrices", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemName(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemNames", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePurchaseItemName(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemNamesPurchaseInvoice", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemNameInvoice(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemNamesInvoice", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustContacts(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerContactNo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsDataByName(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemName1", obj.ItemName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemNameData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSOrderHeader(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSOHeader", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveQuotationHeader(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectQuotationHeader", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvoiceLoadingData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectInvoiceAll", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerComboData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerCombo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsLoading(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectInvoiceAllItems", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        //public DataSet retreiveInkCost(ClassInvoiceBAL obj)
        //{
        //    try
        //    {
        //        param = new MySqlParameter[1];
        //        param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
        //        obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPrintCost", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return obj.DtDataSet;
        //}


        public DataSet retreiveCustomerData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerInvData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }


        public DataSet retreiveItemsData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ItemInvData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemsIdDataInv(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("ItemIdInvData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemVariantData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemCodeVariantDataInv", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveExistItemVariantData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectExistItemCodeVariantDataInv", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchQty(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBranchQty", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveItemIDData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemsByID", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerCodeData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerCode1", obj.CustomerCode);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerCodeData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerContactData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerTelNo1", obj.CustomerTelNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerContactCode", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivevauchernoData(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("VoucherNo1", obj.VoucherNo);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectVoucherNoData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }


        public DataSet retreiveItemsName(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemName1", obj.ItemName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemInvoiceByName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }


        public DataSet retreiveItemByCategory(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectItemInviceByCategory", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public int DeleteCustomerCheque(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustChqId1", obj.CustChqId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteCustomerChq", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteSupplierCheque(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SuppChqId1", obj.SuppChqId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteSuppChq", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCustomerCheque1(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[2] = new MySqlParameter("ChequeBank1", obj.ChequeBank);
                param[3] = new MySqlParameter("ChequeNo1", obj.ChequeNo);
                param[4] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertCustomerCheck", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertOpeningBalance(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("UserId1", obj.UserId);
                param[1] = new MySqlParameter("OpeningBalance1", obj.OpeningBalance);
                param[2] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertOpeningBalance", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteCashBalance(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("UserId1", obj.UserId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteInvoiceCashBalance", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }


        public int Insertsohd(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[15];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("BillNo1", obj.BillNo);
                param[2] = new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal);
                param[3] = new MySqlParameter("Remarks1", obj.Remarks);
                param[4] = new MySqlParameter("SODiscount1", obj.SODiscount);
                param[5] = new MySqlParameter("SONetTotal1", obj.SONetTotal);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("Cash1", obj.Cash);
                param[8] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[9] = new MySqlParameter("RepId1", obj.RepId);
                param[10] = new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs);
                param[11] = new MySqlParameter("VAT1", obj.VAT);
                param[12] = new MySqlParameter("NBT1", obj.NBT);
                param[13] = new MySqlParameter("BranchId1", obj.BranchId);
                param[14] = new MySqlParameter("ReturnTotal1", obj.ReturnTotal);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceSOHD", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public string InsertStockTransferhd(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "TransferHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("FromBranchId1", obj.FromBranchId),
                    new MySqlParameter("ToBranchId1", obj.ToBranchId),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertTransferHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewsohdReturn(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("RefNo1", obj.RefNo),
                    new MySqlParameter("ReferanceNo1", obj.ReferanceNo),
                     new MySqlParameter("TerminalNo1", obj.TerminalNo),
                    new MySqlParameter("VoucherNo1", obj.VoucherNo),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("ReceivableAmount1", obj.ReceivableAmount),
                    

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewInvoiceSOHDReturn", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewsohd(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("RefNo1", obj.RefNo),
                    new MySqlParameter("ReferanceNo1", obj.ReferanceNo),
                    new MySqlParameter("TerminalNo1", obj.TerminalNo),
                    new MySqlParameter("VoucherNo1", obj.VoucherNo),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("ReceivableAmount1", obj.ReceivableAmount),
                    new MySqlParameter("CustomerName1", obj.CustomerName),
                    new MySqlParameter("Charges1", obj.Charges),
                    new MySqlParameter("CreditDueDays1", obj.CreditDueDays),
                    new MySqlParameter("CompletedDate1", obj.CompletedDate),
                    new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId),
                    new MySqlParameter("RepairBill1", obj.RepairBill),
                    new MySqlParameter("LoyaltyPoints1", obj.LoyaltyPoints),
                    new MySqlParameter("LoyaltyBalance1", obj.LoyaltyBalance),
                    new MySqlParameter("ReturnNoteNo1", obj.ReturnNoteNo),
                    new MySqlParameter("ReturnNoteAmount1", obj.ReturnNoteAmount),
                    new MySqlParameter("CashBalance1", obj.CashBalance),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewInvoiceSOHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertNewQuotationhd(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("RefNo1", obj.RefNo),
                    new MySqlParameter("ReferanceNo1", obj.ReferanceNo),
                    new MySqlParameter("TerminalNo1", obj.TerminalNo),
                    new MySqlParameter("VoucherNo1", obj.VoucherNo),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("ReceivableAmount1", obj.ReceivableAmount),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewQuotationSOHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string Insertsorderhd(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("CompletedDate1", obj.CompletedDate),
                    new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId),
                    new MySqlParameter("RepairBill1", obj.RepairBill),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewSOHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string UpdateNewsohd(ClassInvoiceBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "SOHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("BillNo1", obj.BillNo),
                    new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("SODiscount1", obj.SODiscount),
                    new MySqlParameter("SONetTotal1", obj.SONetTotal),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Cash1", obj.Cash),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("RepId1", obj.RepId),
                    new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs),
                    new MySqlParameter("VAT1", obj.VAT),
                    new MySqlParameter("NBT1", obj.NBT),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("ReturnTotal1", obj.ReturnTotal),
                    new MySqlParameter("CreditPay1", obj.CreditPay),
                    new MySqlParameter("CreditTotal1", obj.CreditTotal),
                    new MySqlParameter("RefNo1", obj.RefNo),
                    new MySqlParameter("ReferanceNo1", obj.ReferanceNo),
                    new MySqlParameter("TerminalNo1", obj.TerminalNo),
                    new MySqlParameter("VoucherNo1", obj.VoucherNo),
                    new MySqlParameter("VoucherAmount1", obj.VoucherAmount),
                    new MySqlParameter("ReceivableAmount1", obj.ReceivableAmount),
                    new MySqlParameter("CustomerName1", obj.CustomerName),
                    new MySqlParameter("Charges1", obj.Charges),
                    new MySqlParameter("CreditDueDays1", obj.CreditDueDays),
                    new MySqlParameter("CompletedDate1", obj.CompletedDate),
                    new MySqlParameter("InvoiceStatusId1", obj.InvoiceStatusId),
                    new MySqlParameter("RepairBill1", obj.RepairBill),
                    new MySqlParameter("LoyaltyPoints1", obj.LoyaltyPoints),
                    new MySqlParameter("LoyaltyBalance1", obj.LoyaltyBalance),
                    new MySqlParameter("ReturnNoteNo1", obj.ReturnNoteNo),
                    new MySqlParameter("ReturnNoteAmount1", obj.ReturnNoteAmount),
                    new MySqlParameter("CashBalance1", obj.CashBalance),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("UpdateNewInvoiceSOHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertSales(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[12];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("SOGrossTotal1", obj.SOGrossTotal);
                param[2] = new MySqlParameter("Remarks1", obj.Remarks);
                param[3] = new MySqlParameter("SODiscount1", obj.SODiscount);
                param[4] = new MySqlParameter("SONetTotal1", obj.SONetTotal);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[6] = new MySqlParameter("Cash1", obj.Cash);
                param[7] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[8] = new MySqlParameter("RepId1", obj.RepId);
                param[9] = new MySqlParameter("AdditionalChgs1", obj.AdditionalChgs);
                param[10] = new MySqlParameter("VAT1", obj.VAT);
                param[11] = new MySqlParameter("NBT1", obj.NBT);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSales", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        //public int InsertSales(ClassInvoiceBAL obj)
        //{
        //    int count = 0;
        //    try
        //    {
        //        objDataAccess.OpenDB();
        //        MySqlCommand cmd = null;
        //        cmd = new MySqlCommand("InsertSales", objDataAccess.objSqlCon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("CustomerId1", SqlDbType.Int).Value = obj.CustomerId;
        //        cmd.Parameters.Add("SOGrossTotal1", SqlDbType.Decimal).Value = obj.SOGrossTotal;
        //        cmd.Parameters.Add("Remarks1", SqlDbType.NVarChar).Value = obj.Remarks;
        //        cmd.Parameters.Add("SODiscount1", SqlDbType.Decimal).Value = obj.SODiscount;
        //        cmd.Parameters.Add("SONetTotal1", SqlDbType.Decimal).Value = obj.SONetTotal;
        //        cmd.Parameters.Add("CreatedBy1", SqlDbType.Int).Value = obj.CreatedBy;
        //        cmd.Parameters.Add("Cash1", SqlDbType.Decimal).Value = obj.Cash;
        //        cmd.Parameters.Add("PayModeId1", SqlDbType.Int).Value = obj.PayModeId;
        //        cmd.Parameters.Add("RepId1", SqlDbType.Int).Value = obj.RepId;
        //        cmd.Parameters.Add("AdditionalChgs1", SqlDbType.Decimal).Value = obj.AdditionalChgs;
        //        cmd.Parameters.Add("VAT1", SqlDbType.NVarChar).Value = obj.VAT;
        //        cmd.Parameters.Add("NBT1", SqlDbType.NVarChar).Value = obj.NBT;
        //        cmd.Parameters.Add("ScopeId1", SqlDbType.Int).Direction = ParameterDirection.Output;

        //        count = cmd.ExecuteNonQuery();
        //        obj.ChequeNo = cmd.Parameters["ScopeId1"].Value.ToString();
        //        objDataAccess.closeDB();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return count;
        //}

        public int DeleteTempSales(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteTempSales", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateTaxSales(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[0];
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateTAXSales", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSoDtReturn(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[15];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("Damage1", obj.Damage);
                param[14] = new MySqlParameter("SerialNo1", obj.SerialNo);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceSODTReturn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }


        public int InsertSoDt(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[17];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[14] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[15] = new MySqlParameter("PriceMethod1", obj.PriceMethod);
                param[16] = new MySqlParameter("DiscPer1", obj.DiscPer);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceSODT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateSoDt(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[16];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("FreeIssue1", obj.FreeIssue);
                param[14] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[15] = new MySqlParameter("PriceMethod1", obj.PriceMethod);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateInvoiceSODT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertQuotationDt(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[14];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("FreeIssue1", obj.FreeIssue);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertQuotationDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSorderDt(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[14];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("SerialNo1", obj.SerialNo);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSOrderDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSalesRtn(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[17];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("Damage1", obj.Damage);
                param[14] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[15] = new MySqlParameter("PriceMethod1", obj.PriceMethod);
                param[16] = new MySqlParameter("DiscPer1", obj.DiscPer);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceReturn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateSalesRtn(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[16];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("Damage1", obj.Damage);
                param[14] = new MySqlParameter("SerialNo1", obj.SerialNo);
                param[15] = new MySqlParameter("PriceMethod1", obj.PriceMethod);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateInvoiceReturn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSORtn(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[14];
                param[0] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[3] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[4] = new MySqlParameter("Discount1", obj.Discount);
                param[5] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[8] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[9] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[10] = new MySqlParameter("Warranty1", obj.Warranty);
                param[11] = new MySqlParameter("BranchId1", obj.BranchId);
                param[12] = new MySqlParameter("ItemName1", obj.ItemName);
                param[13] = new MySqlParameter("SerialNo1", obj.SerialNo);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSOReturn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertTempSales(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[2] = new MySqlParameter("SalesPrice1", obj.SalesPrice);
                param[3] = new MySqlParameter("Discount1", obj.Discount);
                param[4] = new MySqlParameter("NetAmount1", obj.NetAmount);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[6] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[7] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[8] = new MySqlParameter("InternalNo1", obj.InternalNo);
                param[9] = new MySqlParameter("FreeIssue1", obj.FreeIssue);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertTempSODT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertTable(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("TblNo1", obj.TblNo);
                param[1] = new MySqlParameter("TblCategory1", obj.TblCategory);
                param[2] = new MySqlParameter("NoOfCustomers1", obj.NoOfCustomers);
                param[3] = new MySqlParameter("Steward1", obj.Steward);
                param[4] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[5] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[6] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[7] = new MySqlParameter("Price1", obj.Price);
                param[8] = new MySqlParameter("SalesQty1", obj.SalesQty);
                param[9] = new MySqlParameter("SalesAmount1", obj.SalesAmount);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertTable", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateTableKOT(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("TblNo1", obj.TblNo);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateKOTPrint", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }


        public int InsertCustomerCredit(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("BillNo1", obj.BillNo);
                param[2] = new MySqlParameter("CreditAmount1", obj.CreditAmount);
                param[3] = new MySqlParameter("CreditDueDays1", obj.CreditDueDays);
                param[4] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("CustomerInvoiceCredit", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCustomerCheque(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[2] = new MySqlParameter("ChequeBank1", obj.ChequeBank);
                param[3] = new MySqlParameter("ChequeNo1", obj.ChequeNo);
                param[4] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("BankId1", obj.BankId);
                param[8] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceCustomerCheck", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCustomerCard(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[2] = new MySqlParameter("CardBank1", obj.ChequeBank);
                param[3] = new MySqlParameter("CardNo1", obj.ChequeNo);
                param[4] = new MySqlParameter("CardAmount1", obj.ChequeAmount);
                param[5] = new MySqlParameter("CardType1", obj.CardType);
                param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[7] = new MySqlParameter("BankId1", obj.BankId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceCustomerCard", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCustomerBankDeposit(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[7];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[2] = new MySqlParameter("ChequeBank1", obj.ChequeBank);
                //param[3] = new MySqlParameter("ChequeNo1", obj.ChequeNo);
                param[3] = new MySqlParameter("ChequeAmount1", obj.ChequeAmount);
                //param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
                param[4] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[5] = new MySqlParameter("BankId1", obj.BankId);
                param[6] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertInvoiceCustomerBankDeposit", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }


        //public int InsertInkAmount(ClassInvoiceBAL obj)
        //{
        //    int count = 0;
        //    try
        //    {
        //        param = new MySqlParameter[5];
        //        param[0] = new MySqlParameter("ItemCode1", obj.ItemCode);
        //        param[1] = new MySqlParameter("BillNo1", obj.BillNo);
        //        param[2] = new MySqlParameter("Qty1", obj.Qty);
        //        param[3] = new MySqlParameter("CostAmount1", obj.CostAmount);
        //        param[4] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
        //        //param[5] = new MySqlParameter("ChequeExpDate1", obj.ChequeExpDate);
        //        //param[6] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
        //        objDataAccess.beginTransaction();
        //        count = objDataAccess.executeReturnInt("InsertPrintDetails", param);
        //        objDataAccess.commitTransaction();

        //    }
        //    catch (Exception ex)
        //    {
        //        objDataAccess.rollBAckTransaction();
        //        throw ex;
        //    }
        //    return count;
        //}


        public DataSet SelectMaxSOHDandBillNO(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectMaxInvoiceSOHDid", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet SelectMaxSOHD(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectMaxSOHDid", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet SelectCashBalnce(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("UserId1", obj.UserId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectInvoiceBalances", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet SelectInvoice(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectUserInvoice", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }


        ////////////////////////////////////////////////Customer Credit Payment /////////////////////////

        public DataSet retreiveCreditCustomers(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerName1", obj.CustomerName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("Select_CustomerCreditAmount", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCreditDetailsCustomers(ClassInvoiceBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("Select_Customer_CreditDetails", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public int InsertAndUpdateCustomerCredit(ClassInvoiceBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[4];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("SOHDId1", obj.SOHDId);
                param[2] = new MySqlParameter("PaymentAmount1", obj.PaymentAmount);
                param[3] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("CustomerCreditInsertAndUpdate", param);
                objDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }
    }
}
