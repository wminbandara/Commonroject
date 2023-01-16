using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class BALUser
    {
        public DataTable DtDataTabe { get; set; }
        public DataSet DtDataSet { get; set; }

        public string dataTable { get; set; }

        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }
        public string CONTACT_NO { get; set; }
        public string EMAIL { get; set; }
        public string Status { get; set; }
        public string ENT_USER { get; set; }
        public string FORM_NAME { get; set; }
        public string ROLE_TITLE { get; set; }
        public string APPLICATION_NAME { get; set; }
        public string APPLICATION_VERSION { get; set; }
        public string LOGIN_MACHINE { get; set; }
        public string LOGIN_MACHINE_IP { get; set; }
        public string LOGOUT_BY { get; set; }
        public string USER_TYPE { get; set; }
        public string DEPARTMENT_NAME { get; set; }

        public int EntUser { get; set; }
        public int USER_ID { get; set; }
        public int USER_TYPE_ID { get; set; }
        public int DEPARTMENT_ID { get; set; }
        public int APPLICATION_ID { get; set; }
        public int USER_LOG_ID { get; set; }
        public int ROLE_ID { get; set; }
        public int USER_ROLE_ID { get; set; }
        public int USER_PROFILE_ID { get; set; }
        public int OptionId { get; set; }
        public bool OptionStatus { get; set; }

        public bool LOGIN_STATUS { get; set; }
        public bool PERMISSION_STATUS { get; set; }

        public int CompanyInfoId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string FooterMsg1 { get; set; }
        public string FooterMsg2 { get; set; }
        public string VATNo { get; set; }

        public int ActBillNo { get; set; }
        public bool ActStatus { get; set; }
        public string CompRegNo { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }

        public int DiscTypeId { get; set; }
        public decimal DiscRate { get; set; }

        public string SMSUrl { get; set; }
        public string APIKey { get; set; }
        public string APIToken { get; set; }
        public string SenderId { get; set; }
        public decimal CommissionRate { get; set; }
        public bool AllowSMS { get; set; }
        public string ActivationType { get; set; }
    }
}
