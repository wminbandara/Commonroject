using easyBAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace easyDAL
{
    public class DALClass
    {
        BALClass objBAL = new BALClass();
        ClassDataAccess objclsDataAccess = new ClassDataAccess();
        MySqlParameter[] param;

        #region Select

        public DataSet retreiveEmployeeByDOB(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("DOB1", objApp.DOB);
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectEmployeeByDOB", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        public DataSet retreiveAllEmployees(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectAllEmployees", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        public DataSet retreiveDesignations(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectDesignation", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        public DataSet retreiveEmployeeName(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectEmployeeName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        public DataSet retreiveEmployeeByID(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectEmployeeId", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        public DataSet retreiveEmployeeByName(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("EmployeeName1", objApp.EmployeeName);
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectEmployeeByName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        public DataSet retreiveAdvance(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);
                param[1] = new MySqlParameter("Date1", objApp.Date1);
                param[2] = new MySqlParameter("Date2", objApp.Date2);
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectEmployeeAdv", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        public DataSet retreiveEmployeeSalaryByDate(BALClass objApp)
        {
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("Date1", objApp.Date1);
                param[1] = new MySqlParameter("Date2", objApp.Date2);
                objApp.DtDataSet = objclsDataAccess.executeReturnDataset("SelectEmployeeSalaryByDate", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objApp.DtDataSet;
        }

        #endregion

        #region Insert

        public int UpdateEmployeeLeave(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                param[0] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);
                param[1] = new MySqlParameter("LeaveDate1", objApp.LeaveDate);
                param[2] = new MySqlParameter("LeaveCount1", objApp.LeaveCount);
                param[3] = new MySqlParameter("LeaveReason1", objApp.LeaveReason);
                param[4] = new MySqlParameter("CreatedBy1", objApp.CreatedBy);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateEmployeeLeave", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertEmployee(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[13];
                param[0] = new MySqlParameter("EmployeeName1", objApp.EmployeeName);
                param[1] = new MySqlParameter("Address1", objApp.Address);
                param[2] = new MySqlParameter("MobileNo1", objApp.MobileNo);
                param[3] = new MySqlParameter("Email1", objApp.Email);
                param[4] = new MySqlParameter("Bloodgroup1", objApp.Bloodgroup);
                param[5] = new MySqlParameter("DSId1", objApp.DSId);
                param[6] = new MySqlParameter("DateOfJoining1", objApp.DateOfJoining);
                param[7] = new MySqlParameter("Salary1", objApp.Salary);
                param[8] = new MySqlParameter("BasicWorkingTime1", objApp.BasicWorkingTime);
                param[9] = new MySqlParameter("HourlyRate1", objApp.HourlyRate);
                param[10] = new MySqlParameter("OTRate1", objApp.OTRate);
                param[11] = new MySqlParameter("LeaveDeductionPerDay1", objApp.LeaveDeductionPerDay);
                param[12] = new MySqlParameter("DOB1", objApp.DOB);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("RegisterEmployee", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertEmployeeSalary(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[26];
                param[0] = new MySqlParameter("DateFrom1", objApp.DateFrom);
                param[1] = new MySqlParameter("DateTo1", objApp.DateTo);
                param[2] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);
                param[3] = new MySqlParameter("Salary1", objApp.Salary);
                param[4] = new MySqlParameter("Advance1", objApp.Advance);
                param[5] = new MySqlParameter("Deduction1", objApp.Deduction);
                param[6] = new MySqlParameter("PaymentDate1", objApp.PaymentDate);
                param[7] = new MySqlParameter("ModeOfPayment1", objApp.ModeOfPayment);
                param[8] = new MySqlParameter("PaymentModeDetails1", objApp.PaymentModeDetails);
                param[9] = new MySqlParameter("SalesAllowance1", objApp.SalesAllowance);
                param[10] = new MySqlParameter("OtherAllowance1", objApp.OtherAllowance);
                param[11] = new MySqlParameter("HourlyRate1", objApp.HourlyRate);
                param[12] = new MySqlParameter("WorkingHours1", objApp.WorkingHours);
                param[13] = new MySqlParameter("WorkingHourPayment1", objApp.WorkingHourPayment);
                param[14] = new MySqlParameter("OTRate1", objApp.OTRate);
                param[15] = new MySqlParameter("OTHours1", objApp.OTHours);
                param[16] = new MySqlParameter("OTPayment1", objApp.OTPayment);
                param[17] = new MySqlParameter("NetPay1", objApp.NetPay);
                param[18] = new MySqlParameter("CreatedBy1", objApp.CreatedBy);
                param[19] = new MySqlParameter("Bonus1", objApp.Bonus);
                param[20] = new MySqlParameter("PhoneAllowance1", objApp.PhoneAllowance);
                param[21] = new MySqlParameter("TransportAllowance1", objApp.TransportAllowance);
                param[22] = new MySqlParameter("Holidays1", objApp.Holidays);
                param[23] = new MySqlParameter("HolidayDeduction1", objApp.HolidayDeduction);
                param[24] = new MySqlParameter("PayModeId1", objApp.PayModeId);
                param[25] = new MySqlParameter("BankId1", objApp.BankId);
                
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertEmployeeSalary", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertAdvance(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[4];
                param[0] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);
                param[1] = new MySqlParameter("Amount1", objApp.Amount);
                param[2] = new MySqlParameter("AdvanceDate1", objApp.AdvanceDate);
                param[3] = new MySqlParameter("CreatedBy1", objApp.CreatedBy);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertAdvance", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int InsertDesignation(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("Designation1", objApp.Designation);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertDesignation", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        #endregion

        #region Update

        public int UpdateEmployee(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[14];
                param[0] = new MySqlParameter("EmployeeName1", objApp.EmployeeName);
                param[1] = new MySqlParameter("Address1", objApp.Address);
                param[2] = new MySqlParameter("MobileNo1", objApp.MobileNo);
                param[3] = new MySqlParameter("Email1", objApp.Email);
                param[4] = new MySqlParameter("Bloodgroup1", objApp.Bloodgroup);
                param[5] = new MySqlParameter("DSId1", objApp.DSId);
                param[6] = new MySqlParameter("DateOfJoining1", objApp.DateOfJoining);
                param[7] = new MySqlParameter("Salary1", objApp.Salary);
                param[8] = new MySqlParameter("BasicWorkingTime1", objApp.BasicWorkingTime);
                param[9] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);
                param[10] = new MySqlParameter("HourlyRate1", objApp.HourlyRate);
                param[11] = new MySqlParameter("OTRate1", objApp.OTRate);
                param[12] = new MySqlParameter("LeaveDeductionPerDay1", objApp.LeaveDeductionPerDay);
                param[13] = new MySqlParameter("DOB1", objApp.DOB);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateEmployee", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateEmployeeSalary(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[27];
                param[0] = new MySqlParameter("DateFrom1", objApp.DateFrom);
                param[1] = new MySqlParameter("DateTo1", objApp.DateTo);
                param[2] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);
                param[3] = new MySqlParameter("Salary1", objApp.Salary);
                param[4] = new MySqlParameter("Advance1", objApp.Advance);
                param[5] = new MySqlParameter("Deduction1", objApp.Deduction);
                param[6] = new MySqlParameter("PaymentDate1", objApp.PaymentDate);
                param[7] = new MySqlParameter("ModeOfPayment1", objApp.ModeOfPayment);
                param[8] = new MySqlParameter("PaymentModeDetails1", objApp.PaymentModeDetails);
                param[9] = new MySqlParameter("SalesAllowance1", objApp.SalesAllowance);
                param[10] = new MySqlParameter("OtherAllowance1", objApp.OtherAllowance);
                param[11] = new MySqlParameter("HourlyRate1", objApp.HourlyRate);
                param[12] = new MySqlParameter("WorkingHours1", objApp.WorkingHours);
                param[13] = new MySqlParameter("WorkingHourPayment1", objApp.WorkingHourPayment);
                param[14] = new MySqlParameter("OTRate1", objApp.OTRate);
                param[15] = new MySqlParameter("OTHours1", objApp.OTHours);
                param[16] = new MySqlParameter("OTPayment1", objApp.OTPayment);
                param[17] = new MySqlParameter("NetPay1", objApp.NetPay);
                param[18] = new MySqlParameter("CreatedBy1", objApp.CreatedBy);
                param[19] = new MySqlParameter("Bonus1", objApp.Bonus);
                param[20] = new MySqlParameter("PhoneAllowance1", objApp.PhoneAllowance);
                param[21] = new MySqlParameter("TransportAllowance1", objApp.TransportAllowance);
                param[22] = new MySqlParameter("Holidays1", objApp.Holidays);
                param[23] = new MySqlParameter("HolidayDeduction1", objApp.HolidayDeduction);
                param[24] = new MySqlParameter("PaymentID1", objApp.PaymentID);
                param[25] = new MySqlParameter("PayModeId1", objApp.PayModeId);
                param[26] = new MySqlParameter("BankId1", objApp.BankId);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateEmployeeSalary", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        #endregion

        #region Delete

        public int DeleteEmployee(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("EmployeeID1", objApp.EmployeeID);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("DeleteEmployee", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int DeleteEmployeeSalary(BALClass objApp)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("PaymentID1", objApp.PaymentID);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("DeleteEmployeeSalary", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }


        #endregion

    }
}
