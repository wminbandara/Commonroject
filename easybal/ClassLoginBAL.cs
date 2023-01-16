using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyBAL
{
    public class ClassLoginBAL
    {
        public DataSet DtDataSet { get; set; }
        public DataTable DtDataTable { get; set; }

        public string UserType1 { get; set; }
        public string UserName1 { get; set; }
        public string Password1 { get; set; }
    }
}
