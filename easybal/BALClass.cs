using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace easyBAL
{
    public class BALClass
    {
        public DataSet DtDataSet { get; set; }
        public DataTable DtDataTable { get; set; }
        public string dataTable { get; set; }

        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Bloodgroup { get; set; }
        public string Designation { get; set; }
        public string BasicWorkingTime { get; set; }
        public string ModeOfPayment { get; set; }
        public string PaymentModeDetails { get; set; }
        public int CreatedBy { get; set; }
        public decimal SalesAllowance { get; set; }
        public decimal OtherAllowance { get; set; }

        public DateTime DateOfJoining { get; set; }
        public DateTime AdvanceDate { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime PaymentDate { get; set; }

        public decimal Salary { get; set; }
        public int EmployeeID { get; set; }
        public decimal Amount { get; set; }
        public decimal Advance { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetPay { get; set; }
        public int PaymentID { get; set; }
        public int DSId { get; set; }

        public decimal HourlyRate { get; set; }
        public decimal OTRate { get; set; }

        public decimal WorkingHours { get; set; }
        public decimal WorkingHourPayment { get; set; }
        public decimal OTHours { get; set; }
        public decimal OTPayment { get; set; }

        public decimal LeaveDeductionPerDay { get; set; }
        public DateTime DOB { get; set; }

        public DateTime LeaveDate { get; set; }
        public decimal LeaveCount { get; set; }
        public string LeaveReason { get; set; }
        //public DateTime DOB { get; set; }
        public decimal Bonus { get; set; }
        public decimal PhoneAllowance { get; set; }
        public decimal TransportAllowance { get; set; }
        public decimal Holidays { get; set; }
        public decimal HolidayDeduction { get; set; }

        public int PayModeId { get; set; }
        public int BankId { get; set; }

    }
}
