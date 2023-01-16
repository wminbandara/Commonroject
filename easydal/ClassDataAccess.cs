using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using easyBAL;

namespace easyDAL
{
    public class ClassDataAccess
    {
        //Creating objects for sql transaction process
        public MySqlTransaction objSqlTrn;
        public MySqlCommand objSqlCmnd = new MySqlCommand();
        public MySqlConnection objSqlCon = null;

        MySqlDataAdapter objDataAdap = new MySqlDataAdapter();

        //Open Database connection
        public void OpenDB()
        {
            try
            {
                objSqlCon = new MySqlConnection();
                objSqlCon = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["easyPOSSolution.Properties.Settings.easybookshopsolutionConnectionString"].ConnectionString);

                // objSqlCon.ConnectionString = ConnectionString;
                objSqlCmnd.Connection = objSqlCon;
                objSqlCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Close Database connection
        public void closeDB()
        {
            try
            {
                objSqlCon.Close();
                objSqlCon.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Close Database connection
        public void beginTransaction()
        {
            try
            {
                OpenDB();
                objSqlTrn = objSqlCon.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Close Database connection
        public void commitTransaction()
        {
            try
            {

                objSqlCmnd.Transaction = objSqlTrn;
                objSqlTrn.Commit();
                closeDB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Close Database connection
        public void rollBAckTransaction()
        {
            try
            {
                objSqlTrn.Rollback();
                objSqlTrn.Dispose();
                closeDB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet executeReturnDataset(string sp, MySqlParameter[] param)
        {
            DataSet DtDataSet = new DataSet();
            //DtDataSet.Clear();
            try
            {
                OpenDB();
                objSqlCmnd.CommandType = CommandType.StoredProcedure;
                objSqlCmnd.CommandText = sp;
                objSqlCmnd.Transaction = objSqlTrn;
                objDataAdap = new MySqlDataAdapter();

                objSqlCmnd.Parameters.Clear();
                if (param.Length > 0)
                {
                    objSqlCmnd.Parameters.AddRange(param);
                }
                
                objDataAdap.SelectCommand = objSqlCmnd;
                objDataAdap.Fill(DtDataSet);
                closeDB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DtDataSet;
        }

        public DataTable executeReturnDataTable(string sp, MySqlParameter[] param)
        {
            DataTable DtDataTabe = new DataTable();
            try
            {
                objSqlCmnd.CommandType = CommandType.StoredProcedure;
                objSqlCmnd.CommandText = sp;
                objSqlCmnd.Transaction = objSqlTrn;
                objDataAdap = new MySqlDataAdapter();

                objSqlCmnd.Parameters.Clear();
                if (param.Length > 0)
                {
                    objSqlCmnd.Parameters.AddRange(param);
                }
                objDataAdap.SelectCommand = objSqlCmnd;
                objDataAdap.Fill(DtDataTabe);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DtDataTabe;
        }

        public object executeReturnObject(string sp, MySqlParameter[] param)
        {
            object obj = null;
            try
            {
                objSqlCmnd.CommandType = CommandType.StoredProcedure;
                objSqlCmnd.CommandText = sp;
                objSqlCmnd.Transaction = objSqlTrn;

                objSqlCmnd.Parameters.Clear();
                if (param.Length > 0)
                {
                    objSqlCmnd.Parameters.AddRange(param);
                }
                obj = objSqlCmnd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public int executeReturnInt(string sp, MySqlParameter[] param)
        {
            int obj;
            try
            {
                objSqlCmnd.CommandType = CommandType.StoredProcedure;
                objSqlCmnd.CommandText = sp;
                objSqlCmnd.Transaction = objSqlTrn;

                objSqlCmnd.Parameters.Clear();
                if (param.Length > 0)
                {
                    objSqlCmnd.Parameters.AddRange(param);
                }
                obj = objSqlCmnd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public DataSet executeReturnReportDataset(string sp, MySqlParameter[] param, ClassPOBAL obj)
        {
            DataSet DtDataSet = new DataSet();
            try
            {
                OpenDB();
                objSqlCmnd.CommandType = CommandType.StoredProcedure;
                objSqlCmnd.CommandText = sp;
                objSqlCmnd.Transaction = objSqlTrn;
                objDataAdap = new MySqlDataAdapter();

                objSqlCmnd.Parameters.Clear();
                if (param.Length > 0)
                {
                    objSqlCmnd.Parameters.AddRange(param);
                }
                objDataAdap.SelectCommand = objSqlCmnd;
                objDataAdap.Fill(DtDataSet, obj.dataTable);
                closeDB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DtDataSet;
        }
    }
}
