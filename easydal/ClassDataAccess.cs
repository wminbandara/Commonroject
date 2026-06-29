using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using easyBAL;
using System.Threading;
using System.Security.Cryptography;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

namespace easyDAL
{
    public class ClassDataAccess
    {
        private const int MaxRetryCount = 3;
        private const int RetryDelayMs = 2000;
        private const string EncryptionKey = "My$tr0ngKey12345";

        private const string ConnectionKey = "ClassDataAccess_Connection";
        private const string TransactionKey = "ClassDataAccess_Transaction";

        private MySqlConnection ActiveConnection
        {
            get { return CallContext.LogicalGetData(ConnectionKey) as MySqlConnection; }
            set { CallContext.LogicalSetData(ConnectionKey, value); }
        }

        private MySqlTransaction ActiveTransaction
        {
            get { return CallContext.LogicalGetData(TransactionKey) as MySqlTransaction; }
            set { CallContext.LogicalSetData(TransactionKey, value); }
        }

        // Maintain compatibility with legacy fields/properties
        public MySqlTransaction objSqlTrn
        {
            get { return ActiveTransaction; }
            set { ActiveTransaction = value; }
        }

        public MySqlConnection objSqlCon
        {
            get { return ActiveConnection; }
            set { ActiveConnection = value; }
        }

        private string _connectionString
        {
            get
            {
                string encrypted = ConfigurationManager
                    .ConnectionStrings["easyPOSSolution.Properties.Settings.easybookshopsolutionConnectionString"]
                    .ConnectionString;

                return DecryptString(encrypted);
            }
        }

        public static string DecryptString(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aes.IV = new byte[16]; // same IV used during encryption

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] buffer = Convert.FromBase64String(cipherText);
                return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(buffer, 0, buffer.Length));
            }
        }

        private MySqlConnection GetConnectionWithRetry()
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    var conn = new MySqlConnection(_connectionString);
                    conn.Open();
                    return conn;
                }
                catch (MySqlException)
                {
                    attempts++;
                    if (attempts >= MaxRetryCount)
                        throw;
                    Thread.Sleep(RetryDelayMs);
                }
            }
        }

        private async Task<MySqlConnection> GetConnectionWithRetryAsync()
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    var conn = new MySqlConnection(_connectionString);
                    await conn.OpenAsync();
                    return conn;
                }
                catch (MySqlException)
                {
                    attempts++;
                    if (attempts >= MaxRetryCount)
                        throw;
                }

                await Task.Delay(RetryDelayMs);
            }
        }

        public void OpenDB()
        {
            if (ActiveConnection == null || ActiveConnection.State != ConnectionState.Open)
            {
                ActiveConnection = GetConnectionWithRetry();
            }
        }

        public async Task OpenDBAsync()
        {
            if (ActiveConnection == null || ActiveConnection.State != ConnectionState.Open)
            {
                ActiveConnection = await GetConnectionWithRetryAsync();
            }
        }

        public void closeDB()
        {
            try
            {
                var conn = ActiveConnection;
                if (conn != null)
                {
                    ActiveConnection = null;
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch
            {
                throw;
            }
        }

        public void beginTransaction()
        {
            OpenDB();
            ActiveTransaction = ActiveConnection.BeginTransaction();
        }

        public void commitTransaction()
        {
            var trans = ActiveTransaction;
            try
            {
                if (trans != null)
                {
                    trans.Commit();
                    trans.Dispose();
                }
            }
            finally
            {
                ActiveTransaction = null;
                closeDB();
            }
        }

        public void rollBAckTransaction()
        {
            var trans = ActiveTransaction;
            try
            {
                if (trans != null)
                {
                    trans.Rollback();
                    trans.Dispose();
                }
            }
            finally
            {
                ActiveTransaction = null;
                closeDB();
            }
        }

        public DataSet executeReturnDataset(string sp, MySqlParameter[] param)
        {
            DataSet ds = new DataSet();
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = GetConnectionWithRetry();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return ds;
        }

        public DataTable executeReturnDataTable(string sp, MySqlParameter[] param)
        {
            DataTable dt = new DataTable();
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = GetConnectionWithRetry();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;
        }

        public object executeReturnObject(string sp, MySqlParameter[] param)
        {
            object result = null;
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = GetConnectionWithRetry();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    result = cmd.ExecuteScalar();
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        public int executeReturnInt(string sp, MySqlParameter[] param)
        {
            int result;
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = GetConnectionWithRetry();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    result = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        public int executeReturnIntOnline(string sp, MySqlParameter[] param)
        {
            int result;
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = GetConnectionWithRetry();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    result = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        public DataSet executeReturnReportDataset(string sp, MySqlParameter[] param, ClassPOBAL obj)
        {
            DataSet ds = new DataSet();
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = GetConnectionWithRetry();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds, obj.dataTable);
                    }
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return ds;
        }

        public void WarmUpDatabase()
        {
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);
            try
            {
                if (isLocalConn)
                {
                    conn = GetConnectionWithRetry();
                }
                using (var cmd = new MySqlCommand("SELECT 1;", conn))
                {
                    cmd.ExecuteScalar();
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        #region New Async Methods

        public async Task<DataSet> executeReturnDatasetAsync(string sp, MySqlParameter[] param)
        {
            DataSet ds = new DataSet();
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = await GetConnectionWithRetryAsync();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        await Task.Run(() => adapter.Fill(ds));
                    }
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return ds;
        }

        public async Task<DataTable> executeReturnDataTableAsync(string sp, MySqlParameter[] param)
        {
            DataTable dt = new DataTable();
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = await GetConnectionWithRetryAsync();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        await Task.Run(() => adapter.Fill(dt));
                    }
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;
        }

        public async Task<object> executeReturnObjectAsync(string sp, MySqlParameter[] param)
        {
            object result;
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = await GetConnectionWithRetryAsync();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    result = await cmd.ExecuteScalarAsync();
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        public async Task<int> executeReturnIntAsync(string sp, MySqlParameter[] param)
        {
            int result;
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = await GetConnectionWithRetryAsync();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    result = await cmd.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        public async Task<DataSet> executeReturnReportDatasetAsync(string sp, MySqlParameter[] param, ClassPOBAL obj)
        {
            DataSet ds = new DataSet();
            var trans = ActiveTransaction;
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);

            try
            {
                if (isLocalConn)
                {
                    conn = await GetConnectionWithRetryAsync();
                }

                using (var cmd = new MySqlCommand(sp, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 360;
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        await Task.Run(() => adapter.Fill(ds, obj.dataTable));
                    }
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return ds;
        }

        public async Task WarmUpDatabaseAsync()
        {
            var conn = ActiveConnection;
            bool isLocalConn = (conn == null);
            try
            {
                if (isLocalConn)
                {
                    conn = await GetConnectionWithRetryAsync();
                }
                using (var cmd = new MySqlCommand("SELECT 1;", conn))
                {
                    await cmd.ExecuteScalarAsync();
                }
            }
            finally
            {
                if (isLocalConn && conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        #endregion
    }
}
