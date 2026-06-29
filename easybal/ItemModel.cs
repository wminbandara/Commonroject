using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class ItemModel
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameSinhala { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string NetAmount { get; set; }
        public string FreeIssue { get; set; }
        public string Warranty { get; set; }
        public string SerialNo { get; set; }
        public string OurPrice { get; set; }
        public string Rtn { get; set; }
        public bool ShowSinhalaName { get; set; }
    }

}
