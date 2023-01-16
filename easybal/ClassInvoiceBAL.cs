using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class ClassInvoiceBAL
    {
        public DataSet DtDataSet { get; set; }
        public DataTable DtDataTable { get; set; }
        public string dataTable { get; set; }

        public string TblNo { get; set; }
        public string TblCategory { get; set; }
        public int NoOfCustomers { get; set; }
        public decimal Price { get; set; }
        public decimal SalesAmount { get; set; }

        public int CustomerId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ItemCatId { get; set; }
        public string BillMode { get; set; }
        public int Steward { get; set; }
            public int UserId {get;set;}
            public decimal OpeningBalance { get; set; }
            public int PayModeId { get; set; }
            public int BillNo { get; set; }
            public decimal SOGrossTotal { get; set; }
            public decimal ServiceCharges { get; set; }
            public decimal SODiscount { get; set; }
            public decimal SONetTotal { get; set; }
            public string Remarks { get; set; }
            public int CreatedBy { get; set; }
            public int SOHDId { get; set; }
            public decimal SalesQty {get;set; }
            public decimal SalesPrice { get; set; }
            public decimal Discount { get; set; }
            public decimal NetAmount { get; set; }
            public int ItemsId { get; set; }
            public decimal CreditAmount { get; set; }
            public decimal BalanceAmount { get; set; }
            public DateTime IssueDate { get; set; }
            public string ChequeBank { get; set; }
            public string ChequeNo { get; set; }
            public decimal ChequeAmount { get; set; }
            public DateTime ChequeExpDate { get; set; }
            public DateTime CreatedOn { get; set; }
            public decimal Cash { get; set; }
            public decimal PaymentAmount { get; set; }
            public string CustomerName { get; set; }
            public decimal Qty { get; set; }
            public decimal CostAmount { get; set; }
            public int itemcatid { get; set; }
            public int RepId { get; set; }
            public decimal AdditionalChgs { get; set; }
            public decimal VAT { get; set; }
            public decimal NBT { get; set; }
            public string InternalNo { get; set; }
            public string CardType { get; set; }
            public int FreeIssue { get; set; }
            public int SuppChqId { get; set; }
            public int CustChqId { get; set; }
            public string CustomerCode { get; set; }
            public string Warranty { get; set; }
            public int BCStart { get; set; }
            public int BCEnd { get; set; }
            public int BranchId { get; set; }
            public decimal ReturnTotal { get; set; }
            public decimal CreditPay { get; set; }
            public decimal CreditTotal { get; set; }
            public int RefNo { get; set; }
            public int FromBranchId { get; set; }
            public int ToBranchId { get; set; }
            public string ReferanceNo { get; set; }

            public int ItemRtPriceId { get; set; }
            public int ItemWHPriceId { get; set; }
            public int ShopPriceId { get; set; }
            public int BankId { get; set; }
            public int TerminalNo { get; set; }
            public int VoucherNo { get; set; }
            public decimal VoucherAmount { get; set; }
            public decimal ReceivableAmount { get; set; }
            public DateTime ExpireDate { get; set; }
            public string VoucherStatus { get; set; }
            public int Damage { get; set; }
            public string SerialNo { get; set; }
            public decimal Charges { get; set; }
            public int CreditDueDays { get; set; }
            public DateTime CompletedDate { get; set; }
            public int InvoiceStatusId { get; set; }
            public int DocTypeId { get; set; }
            public bool RepairBill { get; set; }
            public string CustomerTelNo { get; set; }

            public decimal LoyaltyPoints { get; set; }
            public decimal LoyaltyBalance { get; set; }

            public int ReturnNoteNo { get; set; }
            public int ReturnNo { get; set; }
            public decimal ReturnNoteAmount { get; set; }
            public decimal CashBalance { get; set; }
            public int BarcodeId { get; set; }
            public string PriceMethod { get; set; }
            public decimal DiscPer { get; set; }
            public string VoucherCode { get; set; }
            public int CreditPayHDId { get; set; }

    }
}
