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
    public class ClassMasterDAL
    {
        ClassDataAccess objDataAccess = new ClassDataAccess();
        MySqlParameter[] param;

        #region Insert

        public int InsertOpeningStock(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertStockOB", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertBarcode(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("Barcode1", obj.Barcode);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertBarcode", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int ResetCustomerLoyaltyPoints(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("ResetCustomerLoyaltyPoints", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int ResetAllCustomersLoyaltyPoints(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("ResetAllCustomerLoyaltyPoints", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertNewPurpose(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("Purpose1", obj.Purpose);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPurpose", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertVehicleLogDT(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[14];
                param[0] = new MySqlParameter("VehicleMilageHDId1", obj.VehicleMilageHDId);
                param[1] = new MySqlParameter("MilageDate1", obj.MilageDate);
                param[2] = new MySqlParameter("PurposeId1", obj.PurposeId);
                param[3] = new MySqlParameter("StartingPlace1", obj.StartingPlace);
                param[4] = new MySqlParameter("Destination1", obj.Destination);
                param[5] = new MySqlParameter("StartMile1", obj.StartMile);
                param[6] = new MySqlParameter("EndMile1", obj.EndMile);
                param[7] = new MySqlParameter("Milage1", obj.Milage);
                param[8] = new MySqlParameter("RatePerMile1", obj.RatePerMile);
                param[9] = new MySqlParameter("Rate1", obj.Rate);
                param[10] = new MySqlParameter("VehicleId1", obj.VehicleId);
                param[11] = new MySqlParameter("FuelCost1", obj.FuelCost);
                param[12] = new MySqlParameter("RefInvNo1", obj.RefInvNo);
                param[13] = new MySqlParameter("FuelLeters1", obj.FuelLeters);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertVehicleMilageDT", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public string InsertMilageHD(ClassCommonBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "VehicleMilageHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("VehicleId1", obj.VehicleId),
                    new MySqlParameter("VehicleNo1", obj.VehicleNo),
                    new MySqlParameter("RatePerMile1", obj.RatePerMile),
                    new MySqlParameter("EmployeeID1", obj.EmployeeID),
                    new MySqlParameter("FromDate1", obj.FromDate),
                    new MySqlParameter("ToDate1", obj.ToDate),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("TotalMilage1", obj.TotalMilage),
                    new MySqlParameter("TotalRate1", obj.TotalRate),
                    new MySqlParameter("FuelCostPerMile1", obj.FuelCostPerMile),
                    new MySqlParameter("TotalFuelCost1", obj.TotalFuelCost),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertVehicleMilageHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertVehile(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("VehicleTypeId1", obj.VehicleTypeId);
                param[1] = new MySqlParameter("VehicleNo1", obj.VehicleNo);
                param[2] = new MySqlParameter("LicenceExpiryDate1", obj.LicenceExpiryDate);
                param[3] = new MySqlParameter("InsuranceExpiryDate1", obj.InsuranceExpiryDate);
                param[4] = new MySqlParameter("RatePerMile1", obj.RatePerMile);
                param[5] = new MySqlParameter("CurrentMeeter1", obj.CurrentMeeter);
                param[6] = new MySqlParameter("NextService1", obj.NextService);
                param[7] = new MySqlParameter("FuelCostPerMile1", obj.FuelCostPerMile);


                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertVehicle", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public string InsertNewExpenses(ClassCommonBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "ExpensesId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("PayCatId1", obj.PayCatId),
                    new MySqlParameter("PaymentDate1", obj.PaymentDate),
                    new MySqlParameter("PaymentAmount1", obj.PaymentAmount),
                    new MySqlParameter("Remarks1", obj.Remarks),
                    new MySqlParameter("CreatedBy1", obj.CreatedBy),
                    new MySqlParameter("Status1", obj.Status1),
                    new MySqlParameter("BranchId1", obj.BranchId),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("BankId1", obj.BankId),
                    new MySqlParameter("VehicleId1", obj.VehicleId),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertNewExpenses", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertPaidIn(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[4];
                param[0] = new MySqlParameter("PaymentAmount1", obj.PaymentAmount);
                param[1] = new MySqlParameter("Remarks1", obj.Remarks);
                param[2] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[3] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertPaidIn", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertItemSubCategory(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[1] = new MySqlParameter("ItemSubCatName1", obj.CatDescription);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InserItemSubCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateCategoryPriceIncrease(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[1] = new MySqlParameter("PriceMode1", obj.PriceMode);
                param[2] = new MySqlParameter("RetailPrice1", obj.RetailPrice);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdatePriceCategoryIncrease", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateCategoryPriceDecrease(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[1] = new MySqlParameter("PriceMode1", obj.PriceMode);
                param[2] = new MySqlParameter("RetailPrice1", obj.RetailPrice);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdatePriceCategoryDecrease", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateCategoryPricePercentageIncrease(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[1] = new MySqlParameter("PriceMode1", obj.PriceMode);
                param[2] = new MySqlParameter("RetailPrice1", obj.RetailPrice);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdatePriceCategoryPerIncrease", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateCategoryPricePercentageDecrease(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[1] = new MySqlParameter("PriceMode1", obj.PriceMode);
                param[2] = new MySqlParameter("RetailPrice1", obj.RetailPrice);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdatePriceCategoryPerDecrease", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSupplier(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("SupplierName1", obj.SupplierName);
                param[1] = new MySqlParameter("ContactPerson1", obj.ContactPerson);
                param[2] = new MySqlParameter("BusinessNo1", obj.BusinessNo);
                param[3] = new MySqlParameter("MobileNo1", obj.MobileNo);
                param[4] = new MySqlParameter("Email1", obj.Email);
                param[5] = new MySqlParameter("Address1", obj.Address);
                param[6] = new MySqlParameter("Remarks1", obj.Remarks);
                param[7] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[8] = new MySqlParameter("BalanceAmount1", obj.BalanceAmount);
                param[9] = new MySqlParameter("SupplierTypeId1", obj.SupplierTypeId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("SaveSupplier", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSuppCredPay(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("PaymentDate1", obj.PaymentDate);
                param[2] = new MySqlParameter("PaymentAmount1", obj.PaymentAmount);
                param[3] = new MySqlParameter("UserId1", obj.CreatedBy);
                param[4] = new MySqlParameter("PIHDId1", obj.PIHDId);
                param[5] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[6] = new MySqlParameter("CardChequeNo1", obj.ChequeNo);
                param[7] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSuppCreditPay", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertSuppCredPayChq(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("PaymentDate1", obj.PaymentDate);
                param[2] = new MySqlParameter("PaymentAmount1", obj.PaymentAmount);
                param[3] = new MySqlParameter("UserId1", obj.CreatedBy);
                param[4] = new MySqlParameter("PIHDId1", obj.PIHDId);
                param[5] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[6] = new MySqlParameter("CardChequeNo1", obj.ChequeNo);
                param[7] = new MySqlParameter("CustomerId1", obj.CustomerId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSuppCreditPayCheque", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public string InsertCustomerCredPayHD(ClassCommonBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "CreditPayHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("CustomerId1", obj.CustomerId),
                    new MySqlParameter("PaymentDate1", obj.PaymentDate),
                    new MySqlParameter("PaymentAmount1", obj.PaymentAmount),
                    new MySqlParameter("UserId1", obj.CreatedBy),
                    new MySqlParameter("BillNo1", obj.PIHDId),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("ReciptNo1", obj.ReciptNo),
                    new MySqlParameter("BankId1", obj.BankId),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertCustCreditPayHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public string InsertSupplierCredPayHD(ClassCommonBAL obj)
        {
            try
            {
                MySqlParameter outParam = new MySqlParameter
                {
                    ParameterName = "CreditPayHDId1",
                    MySqlDbType = MySqlDbType.Int32,
                    Direction = ParameterDirection.Output
                };
                MySqlParameter[] sqlParams = new MySqlParameter[] {
                    new MySqlParameter("SupplierId1", obj.SupplierId),
                    new MySqlParameter("PaymentDate1", obj.PaymentDate),
                    new MySqlParameter("PaymentAmount1", obj.PaymentAmount),
                    new MySqlParameter("UserId1", obj.CreatedBy),
                    new MySqlParameter("BillNo1", obj.PIHDId),
                    new MySqlParameter("PayModeId1", obj.PayModeId),
                    new MySqlParameter("BankId1", obj.BankId),

                    outParam };

                objDataAccess.beginTransaction();
                objDataAccess.executeReturnInt("InsertSupplierCreditPayHD", sqlParams);
                objDataAccess.commitTransaction();
                return Convert.ToString(outParam.Value, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
        }

        public int InsertloanHD(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("LoanName1", obj.LoanName);
                param[1] = new MySqlParameter("LoanAmount1", obj.LoanAmount);
                param[2] = new MySqlParameter("InterestAmount1", obj.InterestAmount);
                param[3] = new MySqlParameter("TotalAmount1", obj.TotalAmount);
                param[4] = new MySqlParameter("PIHDId1", obj.PIHDId);
                param[5] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertLoanHd", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertloanDt(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                param[0] = new MySqlParameter("LoanHDId1", obj.LoanHDId);
                param[1] = new MySqlParameter("PaymentDate1", obj.PaymentDate);
                param[2] = new MySqlParameter("PaymentAmount1", obj.PaymentAmount);
                param[3] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[4] = new MySqlParameter("Remarks1", obj.Remarks);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertLoanDt", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCustomerCredPay(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("PaymentDate1", obj.PaymentDate);
                param[2] = new MySqlParameter("PaymentAmount1", obj.PaymentAmount);
                param[3] = new MySqlParameter("UserId1", obj.CreatedBy);
                param[4] = new MySqlParameter("BillNo1", obj.PIHDId);
                param[5] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[6] = new MySqlParameter("CardChequeNo1", obj.ChequeNo);
                param[7] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);
                param[8] = new MySqlParameter("ReciptNo1", obj.ReciptNo);
                param[9] = new MySqlParameter("BankId1", obj.BankId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertCustCreditPay", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }


        public int InsertSupplierAccount(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[1] = new MySqlParameter("BankName1", obj.BankName);
                param[2] = new MySqlParameter("AccountNo1", obj.AccountNo);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("IsertSupplierAccount", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCustomer(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[20];
                param[0] = new MySqlParameter("CustomerName1", obj.CustomerName);
                param[1] = new MySqlParameter("CustomerAddress1", obj.CustomerAddress);
                param[2] = new MySqlParameter("CustomerTelNo1", obj.CustomerTelNo);
                param[3] = new MySqlParameter("CustomerFaxNo1", obj.CustomerFaxNo);
                param[4] = new MySqlParameter("CustomerEmail1", obj.CustomerEmail);
                param[5] = new MySqlParameter("CustomerNICNo1", obj.CustomerNICNo);
                param[6] = new MySqlParameter("Remarks1", obj.Remarks);
                param[7] = new MySqlParameter("VATCustomer1", obj.VATCustomer);
                param[8] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[9] = new MySqlParameter("ContactPerson1", obj.ContactPerson);
                param[10] = new MySqlParameter("BalanceAmount1", obj.BalanceAmount);
                param[11] = new MySqlParameter("CustomerImage1", obj.CustomerImage);
                param[12] = new MySqlParameter("AreaId1", obj.AreaId);
                param[13] = new MySqlParameter("NewAreaId1", obj.NewAreaId);
                param[14] = new MySqlParameter("CreditLimit1", obj.CreditLimit);
                param[15] = new MySqlParameter("PriceMode1", obj.PriceMode);
                param[16] = new MySqlParameter("CustomerTypeId1", obj.CustomerTypeId);
                param[17] = new MySqlParameter("LoyaltyPercentage1", obj.LoyaltyPercentage);
                param[18] = new MySqlParameter("LoyaltyAmount1", obj.LoyaltyAmount);
                param[19] = new MySqlParameter("EmployeeID1", obj.EmployeeID);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertCustomer", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertBranch(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("BranchName1", obj.BranchName);
                param[1] = new MySqlParameter("BranchCode1", obj.BranchCode);
                param[2] = new MySqlParameter("BranchAddress1", obj.BranchAddress);
                param[3] = new MySqlParameter("BranchAddress21", obj.BranchAddress2);
                param[4] = new MySqlParameter("BranchTelNo1", obj.BranchTelNo);
                param[5] = new MySqlParameter("BranchTelNo21", obj.BranchTelNo2);
                param[6] = new MySqlParameter("BranchFaxNo1", obj.BranchFaxNo);
                param[7] = new MySqlParameter("BranchEmail1", obj.BranchEmail);
                param[8] = new MySqlParameter("Remarks1", obj.Remarks);
                param[9] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertBranch", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertUser(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[8];
                param[0] = new MySqlParameter("UserName1", obj.UserName);
                param[1] = new MySqlParameter("Password1", obj.Password);
                param[2] = new MySqlParameter("Fullname1", obj.Fullname);
                param[3] = new MySqlParameter("UserType1", obj.UserType);
                param[4] = new MySqlParameter("Comport1", obj.Comport);
                param[5] = new MySqlParameter("OptionId1", obj.OptionId);
                param[6] = new MySqlParameter("GRNPrintId1", obj.GRNPrintId);
                param[7] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertUser", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertCategory(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("CatDescription1", obj.CatDescription);
                param[1] = new MySqlParameter("PNLStatus1", obj.PNLStatus);
                param[2] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertEmpCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertBank(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BankName1", obj.BankName);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertBank", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertArea(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("AreaName1", obj.AreaName);
                param[1] = new MySqlParameter("DiscRate1", obj.DiscRate);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertArea", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertNewArea(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("AreaName1", obj.AreaName);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertNewArea", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertNewSupplierType(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierType1", obj.SupplierType);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertNewSupplierType", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertNewCustomerType(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerType1", obj.CustomerType);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertNewCustomerType", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertItemCategory(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatName1", obj.CatDescription);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertMenuItemCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertItemCategory1(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ItemCatName1", obj.CatDescription);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InserItemCategory", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertItemSerial(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("SerialNo1", obj.SerialNo);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertSerial", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertRetailPRice(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("RetailPrice1", obj.RetailPrice);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InserRetailPrice", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertWholesalePrice(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("WholesalePrice1", obj.WholesalePrice);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InserWholesalePrice", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertShopPrice(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[1] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[2] = new MySqlParameter("ShopPrice1", obj.ShopPrice);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InserShopPrice", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertExpenses(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("PayCatId1", obj.PayCatId);
                param[1] = new MySqlParameter("PaymentDate1", obj.PaymentDate);
                param[2] = new MySqlParameter("PaymentAmount1", obj.PaymentAmount);
                param[3] = new MySqlParameter("Remarks1", obj.Remarks);
                param[4] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[5] = new MySqlParameter("Status1", obj.Status1);
                param[6] = new MySqlParameter("BranchId1", obj.BranchId);
                param[7] = new MySqlParameter("PayModeId1", obj.PayModeId);
                param[8] = new MySqlParameter("BankId1", obj.BankId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertExpenses", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteExpenses(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ExpensesId1", obj.ExpensesId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteExpense", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateDayEnd(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[1] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateDayEnd", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertOpeningBalance(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[4];
                param[0] = new MySqlParameter("BalanceDate1", obj.BalanceDate);
                param[1] = new MySqlParameter("BalanceAmount1", obj.BalanceAmount);
                param[2] = new MySqlParameter("CreatedBy1", obj.CreatedBy);
                param[3] = new MySqlParameter("BankId1", obj.BankId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertBankOB", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertProPercen(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("ProfitPerId1", obj.ProfitPerId);
                param[1] = new MySqlParameter("ItemCatId1", obj.ItemCatId);
                param[2] = new MySqlParameter("ItemsId1", obj.ItemsId);
                param[3] = new MySqlParameter("ItemCode1", obj.ItemCode);
                param[4] = new MySqlParameter("ProfitPercentage1", obj.ProfitPercentage);
                param[5] = new MySqlParameter("Status1", obj.Status1);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertProfitPercen", param);
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

        public int UpateAttendance(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("AttendanceDate1", obj.AttendanceDate);
                param[1] = new MySqlParameter("EmployeeID1", obj.EmployeeID);
                param[2] = new MySqlParameter("AttendanceStatus1", obj.AttendanceStatus);
                param[3] = new MySqlParameter("AttendanceType1", obj.AttendanceType);
                param[4] = new MySqlParameter("AttendanceDate2", obj.AttendanceDate);
                param[5] = new MySqlParameter("DayType1", obj.DayType);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateAttendance", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateVehile(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("VehicleTypeId1", obj.VehicleTypeId);
                param[1] = new MySqlParameter("VehicleNo1", obj.VehicleNo);
                param[2] = new MySqlParameter("LicenceExpiryDate1", obj.LicenceExpiryDate);
                param[3] = new MySqlParameter("InsuranceExpiryDate1", obj.InsuranceExpiryDate);
                param[4] = new MySqlParameter("RatePerMile1", obj.RatePerMile);
                param[5] = new MySqlParameter("CurrentMeeter1", obj.CurrentMeeter);
                param[6] = new MySqlParameter("NextService1", obj.NextService);
                param[7] = new MySqlParameter("VehicleId1", obj.VehicleId);
                param[8] = new MySqlParameter("FuelCostPerMile1", obj.FuelCostPerMile);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateVehicle", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updateVehicleLogCancel(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("VehicleMilageHDId1", obj.VehicleMilageHDId);
                param[1] = new MySqlParameter("ModifiedBy1", obj.ModifiedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateVehicleLogCancel", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updateCustomerCredPayCancel(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateCustCreditPayCancel", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updateStockTransferCancel(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("TransferHDId1", obj.TransferHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateStockTransferCancel", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updateSupplierCredPayCancel(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CreditPayHDId1", obj.CreditPayHDId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateSuppCreditPayCancel", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateSupplier(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("SupplierName1", obj.SupplierName);
                param[1] = new MySqlParameter("ContactPerson1", obj.ContactPerson);
                param[2] = new MySqlParameter("BusinessNo1", obj.BusinessNo);
                param[3] = new MySqlParameter("MobileNo1", obj.MobileNo);
                param[4] = new MySqlParameter("Email1", obj.Email);
                param[5] = new MySqlParameter("Address1", obj.Address);
                param[6] = new MySqlParameter("Remarks1", obj.Remarks);
                param[7] = new MySqlParameter("ModifiedBy1", obj.ModifiedBy);
                param[8] = new MySqlParameter("SupplierId1", obj.SupplierId);
                param[9] = new MySqlParameter("SupplierTypeId1", obj.SupplierTypeId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateSupplier", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateCustomer(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[21];
                param[0] = new MySqlParameter("CustomerName1", obj.CustomerName);
                param[1] = new MySqlParameter("CustomerAddress1", obj.CustomerAddress);
                param[2] = new MySqlParameter("CustomerTelNo1", obj.CustomerTelNo);
                param[3] = new MySqlParameter("CustomerFaxNo1", obj.CustomerFaxNo);
                param[4] = new MySqlParameter("CustomerEmail1", obj.CustomerEmail);
                param[5] = new MySqlParameter("CustomerNICNo1", obj.CustomerNICNo);
                param[6] = new MySqlParameter("Remarks1", obj.Remarks);
                param[7] = new MySqlParameter("VATCustomer1", obj.VATCustomer);
                param[8] = new MySqlParameter("ModifiedBy1", obj.ModifiedBy);
                param[9] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[10] = new MySqlParameter("ContactPerson1", obj.ContactPerson);
                param[11] = new MySqlParameter("BalanceAmount1", obj.BalanceAmount);
                param[12] = new MySqlParameter("CustomerImage1", obj.CustomerImage);
                param[13] = new MySqlParameter("AreaId1", obj.AreaId);
                param[14] = new MySqlParameter("NewAreaId1", obj.NewAreaId);
                param[15] = new MySqlParameter("CreditLimit1", obj.CreditLimit);
                param[16] = new MySqlParameter("PriceMode1", obj.PriceMode);
                param[17] = new MySqlParameter("CustomerTypeId1", obj.CustomerTypeId);
                param[18] = new MySqlParameter("LoyaltyPercentage1", obj.LoyaltyPercentage);
                param[19] = new MySqlParameter("LoyaltyAmount1", obj.LoyaltyAmount);
                param[20] = new MySqlParameter("EmployeeID1", obj.EmployeeID);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateCustomer", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateCustomerAdvance(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[4];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("AdvanceDate1", obj.AdvanceDate);
                param[2] = new MySqlParameter("AdvanceAmount1", obj.AdvanceAmount);
                param[3] = new MySqlParameter("CreatedBy1", obj.CreatedBy);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("InsertCustomerAdvance", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateCustomerOB(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                param[1] = new MySqlParameter("BalanceAmount1", obj.BalanceAmount);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateCustomerOB", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateBranch(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[10];
                param[0] = new MySqlParameter("BranchName1", obj.BranchName);
                param[1] = new MySqlParameter("BranchAddress1", obj.BranchAddress);
                param[2] = new MySqlParameter("BranchAddress21", obj.BranchAddress2);
                param[3] = new MySqlParameter("BranchTelNo1", obj.BranchTelNo);
                param[4] = new MySqlParameter("BranchTelNo21", obj.BranchTelNo2);
                param[5] = new MySqlParameter("BranchFaxNo1", obj.BranchFaxNo);
                param[6] = new MySqlParameter("BranchEmail1", obj.BranchEmail);
                param[7] = new MySqlParameter("Remarks1", obj.Remarks);
                param[8] = new MySqlParameter("ModifiedBy1", obj.ModifiedBy);
                param[9] = new MySqlParameter("BranchId1", obj.BranchId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateBranch", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateUser(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[9];
                param[0] = new MySqlParameter("UserName1", obj.UserName);
                param[1] = new MySqlParameter("Password1", obj.Password);
                param[2] = new MySqlParameter("Fullname1", obj.Fullname);
                param[3] = new MySqlParameter("UserType1", obj.UserType);
                param[4] = new MySqlParameter("UserID1", obj.UserID);
                param[5] = new MySqlParameter("Comport1", obj.Comport);
                param[6] = new MySqlParameter("OptionId1", obj.OptionId);
                param[7] = new MySqlParameter("GRNPrintId1", obj.GRNPrintId);
                param[8] = new MySqlParameter("BranchId1", obj.BranchId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("UpdateUser", param);
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

        public int DeleteVehile(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("VehicleId1", obj.VehicleId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteVehicle", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteSupplierAccount(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupAccId1", obj.SupAccId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteSuppAccount", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteSupplier(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);

                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteSupplier", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteCustomer(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteCustomer", param);
                objDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteUser(ClassCommonBAL obj)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("UserID1", obj.UserID);
                objDataAccess.beginTransaction();
                count = objDataAccess.executeReturnInt("DeleteUser", param);
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

        #region Select

        public DataSet retreiveAllEmployeeLeaves(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("EmployeeID1", obj.EmployeeID);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectEmployeeLeave", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllAttendanceCustomers(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllAttendEmployees", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveEmployees(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectEmployees", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicles(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectVehicles", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }


        public DataSet retreivePurpose(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPurpose", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveEmployeeDesignation(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("EmployeeID1", obj.EmployeeID);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectEmployeeDesignation", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicleRate(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("VehicleId1", obj.VehicleId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectVehicleRate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveVehicleTypes(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectVehicleTypes", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllVehicles(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllVehicles", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveInvoiceStatus(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectInvoiceStatus", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllAssets(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllAssets", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivePrintOptions(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectPrintOptions", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveports(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("Selectcomport", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveGRNPrintOptions(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectGRNPrintOptions", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllExpenses(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("date1", obj.date1);
                param[1] = new MySqlParameter("date2", obj.date2);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllExpenses", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerBillRecord(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerBillRecord", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveNewStock(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectNewProduct", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBanks(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBanks", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllData(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAll", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveExpenseCat(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectExpCat", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllareas(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllAreas", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSupplierTypes(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllSupplierTypes", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomerTypes(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustomerTypes", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomercontactper(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllEmpContPerson", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveMaxCustIdData(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectMaxCustomerId", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveMaxBranchIdData(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectMaxBranchId", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllSuppliers(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllAuppliers", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierByName(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierName1", obj.SupplierName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSupplierByName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierAccounts(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSupplierAccount", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveSupplierDataByID(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("SupplierId1", obj.SupplierId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectSupplierIdData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerDataByID(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerIDData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreivecompanydata(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCompanyData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveLoanDataByID(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("LoanHDId1", obj.LoanHDId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectLoansById", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerChqDataByID(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerIDChequeData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomerChq(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustomerCheq", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerData(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveDiscRate(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("AreaId1", obj.AreaId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectDiscRate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveCustomerDiscRate(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerId1", obj.CustomerId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectCustomerDiscRate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveBranchData(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectBranchData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllBranchData(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("BranchId1", obj.BranchId);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllBranchData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomers(ClassCommonBAL obj)
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

        public DataSet retreiveAllLoans(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllLoans", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllCustomersByName(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("CustomerName1", obj.CustomerName);
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllCustomersByName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllChequeCustomers(ClassCommonBAL obj)
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

        public DataSet retreiveProfitPercentage(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectAllProPercentage", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj.DtDataSet;
        }

        public DataSet retreiveAllUsers(ClassCommonBAL obj)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                obj.DtDataSet = objDataAccess.executeReturnDataset("SelectUsers", param);
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
