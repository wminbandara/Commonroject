using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class ClassPOBAL
    {
        public DataSet DtDataSet { get; set; }
        public DataTable DtDataTable { get; set; }
        public string dataTable { get; set; }

        public int ItemsId { get; set; }
        public int FromItemId { get; set; }
        public int ToItemId { get; set; }
        public string ItemCode { get; set; }
        public string MItemCode { get; set; }
        public string FromItemCode { get; set; }
        public string ToItemCode { get; set; }
        public int ItemCatId { get; set; }
        public int ItemSubCatId { get; set; }
        public string ItemName { get; set; }
        public string ItemLocation { get; set; }
        public string ItemUnit { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DefaultCostPrice { get; set; }
        
        public decimal SellingPrice { get; set; }
        public decimal SellingPrice2 { get; set; }
        public decimal MinSellingPrice { get; set; }
        public decimal SPPRiceEffectFrom { get; set; }
        public decimal MinQty { get; set; }
        public decimal Qty { get; set; }
        public decimal FromQty { get; set; }
        public decimal ToQty { get; set; }
        public decimal AvailableQty { get; set; }
        public string TblNo { get; set; }
        public string ItemMode { get; set; }
        public DateTime OpenBalDate { get; set; }
        public int OpenStates { get; set; }
        public decimal InValue { get; set; }
        public decimal InQty { get; set; }
        public decimal OutQty { get; set; }
        public decimal OutValue { get; set; }
        public string SItemName { get; set; }
        public string ItemStatus { get; set; }
        public string Wharehouse { get; set; }
        public string WarrantyPeriod { get; set; }
        public int FreeIssueEffectFrom { get; set; }

        public long POHDId { get; set; }
        public string PONo { get; set; }
        public int SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PayModeId { get; set; }
        public string InvoiceNo { get; set; }
        public decimal POGrossTotal { get; set; }
        public decimal PODiscount { get; set; }
        public decimal PONetTotal { get; set; }
        public decimal POCash { get; set; }
        public decimal POBalance { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool CashDepositStatus { get; set; }
        public DateTime IssueDate { get; set; }
            
        public int PODTId { get; set; }
        public int ItemId { get; set; }
        public decimal PurchaseQty { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Discount { get; set; }
        public decimal WholeSaleDiscount { get; set; }
        public decimal NetAmount { get; set; }

        public string ChequeBank { get; set; }
        public string ChequeNo { get; set; }
        public decimal ChequeAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime ChequeExpDate { get; set; }

        public DateTime date1 { get; set; }
        public DateTime date2 { get; set; }
        public string RtnReason { get; set; }
        public decimal ReturnQty { get; set; }
        public int RepId { get; set; }

        public int PaymentID { get; set; }
        public int SOHDId { get; set; }
        public int CustomerId { get; set; }
        public int BillNo { get; set; }
        public bool TaxStatus { get; set; }

        public string Portion { get; set; }
        public int PayCatId { get; set; }
        public string ContactPerson { get; set; }
        public decimal FreeIssue { get; set; }
        public string SupplierInvoiceNo { get; set; }

        public int BranchId { get; set; }
        public int ToBranchId { get; set; }
        public string RackNo { get; set; }
        public string VehicleNo { get; set; }
        public string ItemCategory { get; set; }
        public string ItemSubCateory { get; set; }
        public decimal ReturnTotal { get; set; }
        public int CreditPayHDId { get; set; }
        public int TransferHDId { get; set; }
        public bool AddBarcode { get; set; }
        public int CreditDueDays { get; set; }

        public int SuppChqId { get; set; }
        public string RtnRemark { get; set; }
        public int CustChqId { get; set; }
        public int NewAreaId { get; set; }
        public decimal ShopPrice { get; set; }
        public decimal WholesalePrice { get; set; }

        public int UserID { get; set; }
        public int BankId { get; set; }

        public decimal RetailDiscPer { get; set; }
        public decimal WholesaleDiscPer { get; set; }
        public decimal ExistingQty { get; set; }
        public decimal NewQty { get; set; }
        public decimal AdjustedQty { get; set; }
        public int PIHDId { get; set; }

        public decimal ConvertionQty { get; set; }
        public int MItemsId { get; set; }

        public decimal TotalVariance { get; set; }
        public int StkAdjHDId { get; set; }
        public decimal SystemQty { get; set; }
        public decimal PhisicalQty { get; set; }
        public decimal VarrienceQty { get; set; }
        public decimal AvgCost { get; set; }
        public decimal VarrienceValue { get; set; }

        public decimal MaintainQty { get; set; }
        public bool ScaleItem { get; set; }
        public bool BundleItem { get; set; }
        public string SerialNo { get; set; }

        public int ExpensesId { get; set; }
        public string TItemName { get; set; }

        public string ReferanceNo { get; set; }
        public int VoucherNo { get; set; }

        public int InvoiceStatusId { get; set; }
        public int DocTypeId { get; set; }

        public int VehicleMilageHDId { get; set; }
        public bool RawMaterial { get; set; }
        public int FromBranchId { get; set; }

        public bool AllowSales { get; set; }
        public bool AllowPurchase { get; set; }
        public bool AllowInventory { get; set; }
        
    }
}
