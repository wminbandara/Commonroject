using easyBAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyDAL
{
    public class ClassLoginDAL
    {
        ClassDataAccess objDataAccess = new ClassDataAccess();
        MySqlParameter[] param;

        public bool checkLoginUser(ClassLoginBAL obj)
        {
            param = new MySqlParameter[2];
            //param[0] = new MySqlParameter("UserType1", obj.UserType1);
            param[0] = new MySqlParameter("UserName1", obj.UserName1);
            param[1] = new MySqlParameter("Password1", obj.Password1);
            obj.DtDataSet = objDataAccess.executeReturnDataset("LoginUser", param);
            if (obj.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
