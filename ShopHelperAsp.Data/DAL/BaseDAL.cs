namespace ShopHelperAsp.Data.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data;

    public class BaseDAL
    {
        protected static string connectionString;
        protected static SqlConnection newConnection;

        public BaseDAL()
        {
        }

        //static BaseDAL(string connectionStringAlise)
        //{
        //    //ShopHelperMembershipDb
            
        //}

        protected static SqlConnection GetConnection(string connectionStringAlise)
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings[connectionStringAlise].ConnectionString;
                newConnection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return newConnection;
        }

        protected static void OpenSqlConnection(SqlConnection connectionName)
        {
            try
            {
                if (connectionName.State == ConnectionState.Closed)
                {
                    connectionName.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected static void CloseSqlConnection(SqlConnection connectionName)
        {
            try
            {
                if (connectionName != null)
                {
                    connectionName.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected static SqlCommand GetSqlCommand(SqlConnection connectionName)
        {
            SqlCommand newCommand = connectionName.CreateCommand();
            //newCommand.Transaction = transactionName;
            return newCommand;
        }
    }
}
