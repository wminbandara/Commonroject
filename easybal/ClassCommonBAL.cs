using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class ClassCommonBAL
    {
        public DataSet DtDataSet { get; set; }
        public DataTable DtDataTable { get; set; }
        public string dataTable { get; set; }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string BusinessNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int SupAccId { get; set; }

        //public string BankName { get; set; }
        public string AccountNo { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTelNo { get; set; }
        public string CustomerFaxNo { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerNICNo { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string UserType { get; set; }
        public int UserID { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string CatDescription { get; set; }
        public int PayCatId { get; set; }
        public int Status1 { get; set; }

        public int ProfitPerId { get; set; }
        public int ItemCatId { get; set; }
        public int ItemsId { get; set; }
        public string ItemCode { get; set; }
        public decimal ProfitPercentage { get; set; }
        public int PIHDId { get; set; }
        public bool VATCustomer { get; set; }
        public decimal BalanceAmount { get; set; }
        public int PayModeId { get; set; }
        public string ChequeNo { get; set; }
        public byte[] CustomerImage { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string BranchAddress { get; set; }
        public string BranchAddress2 { get; set; }
        public string BranchTelNo { get; set; }
        public string BranchTelNo2 { get; set; }
        public string BranchFaxNo { get; set; }
        public string BranchEmail { get; set; }

        public string AreaName { get; set; }
        public int AreaId { get; set; }
        public int NewAreaId { get; set; }
        public decimal DiscRate { get; set; }
        public int CreditPayHDId { get; set; }
        public bool PNLStatus { get; set; }
        public string LoanName { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public int LoanHDId { get; set; }
        public decimal CreditLimit { get; set; }

        public decimal RetailPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal ShopPrice { get; set; }
        //public decimal PaymentAmount { get; set; }

        public string PriceMode { get; set; }
        public string BankName { get; set; }
        public int BankId { get; set; }

        public DateTime BalanceDate { get; set; }
        public decimal AdvanceAmount { get; set; }
        public DateTime AdvanceDate { get; set; }

        public DateTime date1 { get; set; }
        public DateTime date2 { get; set; }
        public int ExpensesId { get; set; }
        public string ReciptNo { get; set; }
        public string Comport { get; set; }
        public int OptionId { get; set; }
        public int GRNPrintId { get; set; }

        public string SerialNo { get; set; }

        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNo { get; set; }
        public DateTime LicenceExpiryDate { get; set; }
        public DateTime InsuranceExpiryDate { get; set; }
        public decimal RatePerMile { get; set; }
        public int CurrentMeeter { get; set; }
        public int NextService { get; set; }

        public string Purpose { get; set; }
        public int EmployeeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int VehicleMilageHDId { get; set; }
        public DateTime MilageDate { get; set; }
        public int PurposeId { get; set; }
        public string StartingPlace { get; set; }
        public string Destination { get; set; }
        public int StartMile { get; set; }
        public int EndMile { get; set; }
        public int Milage { get; set; }
        public decimal Rate { get; set; }

        public int TotalMilage { get; set; }
        public decimal TotalRate { get; set; }

        public decimal FuelCostPerMile { get; set; }
        public decimal TotalFuelCost { get; set; }
        public decimal FuelCost { get; set; }

        public string SupplierType { get; set; }
        public int SupplierTypeId { get; set; }

        public string CustomerType { get; set; }
        public int CustomerTypeId { get; set; }

        public decimal LoyaltyPercentage { get; set; }
        public decimal LoyaltyAmount { get; set; }

        public int TransferHDId { get; set; }
        public string Barcode { get; set; }

        public DateTime AttendanceDate { get; set; }
        public bool AttendanceStatus { get; set; }
        public string AttendanceType { get; set; }
        public string DayType { get; set; }
        public int RefInvNo { get; set; }
        public decimal FuelLeters { get; set; }
    }
}
