using easyBAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyDAL
{
    public class DALUser
    {
        clsUserDataAccess objclsDataAccess = new clsUserDataAccess();
        MySqlParameter[] param;
        public MySqlConnection connection = null;

        #region Insert
        public int insertUser(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[6];
                param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                param[1] = new MySqlParameter("PASWORD1", objUser.PASSWORD);
                param[2] = new MySqlParameter("NAME1", objUser.NAME);
                param[3] = new MySqlParameter("CONTACTNO1", objUser.CONTACT_NO);
                param[4] = new MySqlParameter("EMAIL1", objUser.EMAIL);
                param[5] = new MySqlParameter("ENTUSER1", objUser.ENT_USER);
                    objclsDataAccess.beginTransaction();
                    count = objclsDataAccess.executeReturnInt("InsertUser", param);
                    objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int insertUserLog(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[5];
                //param[0] = new MySqlParameter("Action", "InsertUserLog");
                param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                param[1] = new MySqlParameter("LOGINSTATUS1", objUser.LOGIN_STATUS);
                param[2] = new MySqlParameter("LOGINMACHINE1", objUser.LOGIN_MACHINE);
                param[3] = new MySqlParameter("LOGINMACHINEIP1", objUser.LOGIN_MACHINE_IP);
                param[4] = new MySqlParameter("LOGOUTBY1", objUser.LOGOUT_BY);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertUserLog", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int insertUserType(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "InsertUserType");
                param[0] = new MySqlParameter("USERTYPE1", objUser.USER_TYPE);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertUserType", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int insertDepartment(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "InsertDepartment");
                param[0] = new MySqlParameter("DEPARTMENTNAME1", objUser.DEPARTMENT_NAME);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertDepartment", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int insertRole(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                //param[0] = new MySqlParameter("Action", "InsertRole");
                param[0] = new MySqlParameter("FORMNAME1", objUser.FORM_NAME);
                param[1] = new MySqlParameter("ROLETITLE1", objUser.ROLE_TITLE);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertRole", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int insertProfile(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                //param[0] = new MySqlParameter("Action", "InsertProfile");
                param[0] = new MySqlParameter("USERTYPEID1", objUser.USER_TYPE_ID);
                param[1] = new MySqlParameter("ROLEID1", objUser.ROLE_ID);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertProfile", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int insertUserPermission(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                //param[0] = new MySqlParameter("Action", "InsertUserPermissions");
                param[0] = new MySqlParameter("ROLEID1", objUser.ROLE_ID);
                param[1] = new MySqlParameter("USERID1", objUser.USER_ID);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertUserPermissions", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int insertCompanyInfo(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[21];
                param[0] = new MySqlParameter("CompanyInfoId1", objUser.CompanyInfoId);
                param[1] = new MySqlParameter("CompanyName1", objUser.CompanyName);
                param[2] = new MySqlParameter("CompanyAddress11", objUser.CompanyAddress1);
                param[3] = new MySqlParameter("CompanyAddress21", objUser.CompanyAddress2);
                param[4] = new MySqlParameter("ContactNo11", objUser.ContactNo1);
                param[5] = new MySqlParameter("ContactNo21", objUser.ContactNo2);
                param[6] = new MySqlParameter("FooterMsg11", objUser.FooterMsg1);
                param[7] = new MySqlParameter("FooterMsg21", objUser.FooterMsg2);
                param[8] = new MySqlParameter("CompanyLogo1", objUser.CompanyLogo);
                param[9] = new MySqlParameter("VATNo1", objUser.VATNo);
                param[10] = new MySqlParameter("CompRegNo1", objUser.CompRegNo);
                param[11] = new MySqlParameter("Web1", objUser.Web);
                param[12] = new MySqlParameter("Email1", objUser.Email);
                param[13] = new MySqlParameter("DiscTypeId1", objUser.DiscTypeId);
                param[14] = new MySqlParameter("DiscRate1", objUser.DiscRate);
                param[15] = new MySqlParameter("SMSUrl1", objUser.SMSUrl);
                param[16] = new MySqlParameter("APIKey1", objUser.APIKey);
                param[17] = new MySqlParameter("APIToken1", objUser.APIToken);
                param[18] = new MySqlParameter("SenderId1", objUser.SenderId);
                param[19] = new MySqlParameter("CommissionRate1", objUser.CommissionRate);
                param[20] = new MySqlParameter("AllowSMS1", objUser.AllowSMS);
                
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("InsertCompanyInfo", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateSystemActivation(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[3];
                param[0] = new MySqlParameter("ActBillNo1", objUser.ActBillNo);
                param[1] = new MySqlParameter("ActStatus1", objUser.ActStatus);
                param[2] = new MySqlParameter("ActivationType1", objUser.ActivationType);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateSystemActivation", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int UpdateDecSystemActivation(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("ActivationType1", objUser.ActivationType);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateDevSystemActivation", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updateOptionPermission(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                param[0] = new MySqlParameter("OptionId1", objUser.OptionId);
                param[1] = new MySqlParameter("OptionStatus1", objUser.OptionStatus);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateOptions", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int logoutUser(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                //param[0] = new MySqlParameter("Action", "UpdateUserLog");
                param[0] = new MySqlParameter("LOGINSTATUS1", objUser.LOGIN_STATUS);
                param[1] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateUserLog", param);
                objclsDataAccess.commitTransaction();
            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }
        #endregion

        #region Update

        public int updateUser(BALUser objUser)
        {
            int count = 0;
            try
            {                
                    param = new MySqlParameter[7];
                    //param[0] = new MySqlParameter("Action", "UpdateUser");
                    param[0] = new MySqlParameter("USERID1", objUser.USER_ID);
                    param[1] = new MySqlParameter("USERTYPEID1", objUser.USER_TYPE_ID);
                    param[2] = new MySqlParameter("DEPARTMENTID1", objUser.DEPARTMENT_ID);
                    param[3] = new MySqlParameter("CONTACTNO1", objUser.CONTACT_NO);
                    param[4] = new MySqlParameter("EMAIL1", objUser.EMAIL);
                    param[5] = new MySqlParameter("Status1", objUser.Status);
                    param[6] = new MySqlParameter("ModUser1", objUser.ENT_USER);
                    objclsDataAccess.beginTransaction();
                    count = objclsDataAccess.executeReturnInt("UpdateUser", param);
                    objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updateUserLog(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                //param[0] = new MySqlParameter("Action", "UpdateUserLog");
                param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                param[1] = new MySqlParameter("LOGINSTATUS1", objUser.LOGIN_STATUS);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateUserLog", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updateUserLogByAdmin(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "UpdateAdminLogout");
                param[0] = new MySqlParameter("USERLOGID1", objUser.USER_LOG_ID);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdateAdminLogout", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int updatePassword(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[2];
                //param[0] = new MySqlParameter("Action", "UpdatePassword");
                param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                param[1] = new MySqlParameter("PASWORD1", objUser.PASSWORD);
                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("UpdatePassword", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        #endregion

        #region Delete

        public int deleteUserType(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "DeleteUserType");
                param[0] = new MySqlParameter("USERTYPE1", objUser.USER_TYPE);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("DeleteUserType", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int deleteDepartment(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "DeleteDepartment");
                param[0] = new MySqlParameter("DEPARTMENTNAME1", objUser.DEPARTMENT_NAME);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("DeleteDepartment", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        public int deletePermission(BALUser objUser)
        {
            int count = 0;
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "DeletePermission");
                param[0] = new MySqlParameter("USERROLEID1", objUser.USER_ROLE_ID);

                objclsDataAccess.beginTransaction();
                count = objclsDataAccess.executeReturnInt("DeletePermission", param);
                objclsDataAccess.commitTransaction();

            }
            catch (Exception ex)
            {
                objclsDataAccess.rollBAckTransaction();
                throw ex;
            }
            return count;
        }

        #endregion

        #region Select

        public DataSet retreiveuserGRNPrint(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("USERID1", objUser.EntUser);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectUserGRNPrint", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveusercomport(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("USERID1", objUser.EntUser);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectUserPort", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveUserPermission(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "SelectPermission");
                //param[0] = new MySqlParameter("FORMNAME1", objUser.FORM_NAME);
                param[0] = new MySqlParameter("USERID1", objUser.EntUser);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectPermission", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveCompanyInfo(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectCompanyInfo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveActivationInfo(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectActivationDetails", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveLoginUserPermission(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "SelectLogUserPermision");
                param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectLogUserPermision", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        //public DataTable retreiveConnection(BALUser objUser)
        //{
        //    try
        //    {
        //        param = new MySqlParameter[1];
        //        param[0] = new MySqlParameter("Action", "SELECT");
        //        objUser.DtDataSet = objclsDataAccess.executeReturnDataset("spConnectionStringManager", param);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objUser.DtDataSet.Tables[0];
        //}

        public DataSet retreiveUserName(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectUserName");
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectUserName", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveLoginUsers(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectLoginUsers");
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectLoginUsers", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveDepartment(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectDepartment");
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectDepartment", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveUserType(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectUserType");
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectUserType", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveUserRecord(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "SelectUserRec");
                param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectUserRec", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveMasterGrid(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "MasterGrid");
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("MasterGrid", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveProfilePermission(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectProfileRoles");
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectProfileRoles", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveUserData(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "SelectUserData");
                param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectUserData", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveAllControlls(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "SelectAllControlls");
                param[0] = new MySqlParameter("USERID1", objUser.USER_ID);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectAllControlls", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveAllOptions(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                param[0] = new MySqlParameter("USERID1", objUser.EntUser);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectAllOptions", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveAllControllsProfile(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[2];
                //param[0] = new MySqlParameter("Action", "SelectProfileControlls");
                param[0] = new MySqlParameter("USERID1", objUser.USER_ID);
                param[1] = new MySqlParameter("USERTYPEID1", objUser.USER_TYPE_ID);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectProfileControlls", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveMasterControlls(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[0];
                //param[0] = new MySqlParameter("Action", "SelectControlls");
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectControlls", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        public DataSet retreiveMasterControlls2(BALUser objUser)
        {
            try
            {
                param = new MySqlParameter[1];
                //param[0] = new MySqlParameter("Action", "SelectControlls2");
                param[0] = new MySqlParameter("FORMNAME1", objUser.FORM_NAME);
                objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectControlls2", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUser.DtDataSet;
        }

        #endregion

        #region Exist

        public bool existUser(BALUser objUser)
        {
            param = new MySqlParameter[1];
            //param[0] = new MySqlParameter("Action", "ExistUser");
            param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("ExistUser", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existLoginUser(BALUser objUser)
        {
            param = new MySqlParameter[1];
            //param[0] = new MySqlParameter("Action", "SelectLogUser");
            param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectLogUser", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existApplicationVersion(BALUser objUser)
        {
            param = new MySqlParameter[3];
            //param[0] = new MySqlParameter("Action", "SelectAppVersion");
            param[0] = new MySqlParameter("APPLICATIONID1", objUser.APPLICATION_ID);
            param[1] = new MySqlParameter("APPLICATIONNAME1", objUser.APPLICATION_NAME);
            param[2] = new MySqlParameter("APPLICATIONVERSION1", objUser.APPLICATION_VERSION);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectAppVersion", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existUserNamePass(BALUser objUser)
        {
            param = new MySqlParameter[2];
            //param[0] = new MySqlParameter("Action", "SelectUNPW");
            param[0] = new MySqlParameter("USERNAME1", objUser.USER_NAME);
            param[1] = new MySqlParameter("PASWORD1", objUser.PASSWORD);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectUNPW", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existOldPass(BALUser objUser)
        {
            param = new MySqlParameter[2];
            //param[0] = new MySqlParameter("Action", "SelectOldPassword");
            param[0] = new MySqlParameter("USERID1", objUser.USER_ID);
            param[1] = new MySqlParameter("PASWORD1", objUser.PASSWORD);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectOldPassword", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existUserType(BALUser objUser)
        {
            param = new MySqlParameter[1];
            //param[0] = new MySqlParameter("Action", "SelectExUserType");
            param[0] = new MySqlParameter("USERTYPE1", objUser.USER_TYPE);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectExUserType", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existDepartment(BALUser objUser)
        {
            param = new MySqlParameter[1];
            //param[0] = new MySqlParameter("Action", "SelectExDepartment");
            param[0] = new MySqlParameter("DEPARTMENTNAME1", objUser.DEPARTMENT_NAME);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectExDepartment", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existFormRole(BALUser objUser)
        {
            param = new MySqlParameter[2];
            //param[0] = new MySqlParameter("Action", "SelectExFormContr");
            param[0] = new MySqlParameter("FORMNAME1", objUser.FORM_NAME);
            param[1] = new MySqlParameter("ROLETITLE1", objUser.ROLE_TITLE);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectExFormContr", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existProfile(BALUser objUser)
        {
            param = new MySqlParameter[2];
            //param[0] = new MySqlParameter("Action", "SelectExProfile");
            param[0] = new MySqlParameter("USERTYPEID1", objUser.USER_TYPE_ID);
            param[1] = new MySqlParameter("ROLEID1", objUser.ROLE_ID);
            objUser.DtDataSet = objclsDataAccess.executeReturnDataset("SelectExProfile", param);
            if (objUser.DtDataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
