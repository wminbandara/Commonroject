using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class ClassSOBAL
    {
        public DataSet DtDataSet { get; set; }
        public DataTable DtDataTable { get; set; }
        public string dataTable { get; set; }

        public int BillNo { get; set; }
        public int SODTId { get; set; }
        public int ItemsId { get; set; }
        public string RtnReason { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal ReturnQty { get; set; }
        public decimal NetAmount { get; set; }
        public int CreatedBy { get; set; }
        public int CustomerId { get; set; }
        public decimal CreditAmount { get; set; }
        public int SOHDId { get; set; }
        public string ItemCode { get; set; }
        public int CreditStatus { get; set; }
        public DateTime date1 { get; set; }
        public DateTime date2 { get; set; }
        public int ItemCatId { get; set; }

        public int BranchId { get; set; }
        public string VehicleNo { get; set; }
        public int POHDId { get; set; }

        public decimal FreeIssue { get; set; }
        public int TransferHDId { get; set; }
        
    }
}
