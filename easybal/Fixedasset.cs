using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class Fixedasset
    {
        public int FAId { get; set; }
        public string AssetCode { get; set; }
        public string AssetDescription { get; set; }
        public Nullable<int> AssetGroupId { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> DepreciatedAmount { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public Nullable<decimal> DepreciationPerPeriod { get; set; }
        public Nullable<int> TotalDepreciationPeriod { get; set; }
        public Nullable<int> RemainingDepreciationPeriod { get; set; }
        public Nullable<int> WarrantyPeriod { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<System.DateTime> DepreciationStartDate { get; set; }
        public Nullable<System.DateTime> NextDepreciationDate { get; set; }
        public Nullable<System.DateTime> LastDepreciationDate { get; set; }
        public Nullable<int> CreatedUserId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedUserId { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public int FixedAssetDepreciationId { get; set; }
        public Nullable<int> AssetId { get; set; }
        public Nullable<int> LineId { get; set; }
        public Nullable<System.DateTime> DepreciationDate { get; set; }
        public Nullable<decimal> DepreciationAmount { get; set; }
        public Nullable<decimal> NetValue { get; set; }
        public Nullable<int> DepreciatedUserId { get; set; }
        public Nullable<System.DateTime> DepreciatedDate { get; set; }
    }
}
