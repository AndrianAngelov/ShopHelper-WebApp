namespace ShopHelperAsp.Data.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Data;
    using ShopHelperAsp.Data.Entities;

    public class UsersAppsDAL:BaseDAL
    {
        public static bool UpdateUserName(string oldUsername, string newUsername)
        {
            SqlConnection dbConnection = GetConnection("ShopHelperMembershipDb");
            bool isSuccsesfullyUpdate=false;
            try
            {
                OpenSqlConnection(dbConnection);
                SqlCommand cmd = GetSqlCommand(dbConnection);
                SqlParameterCollection parameters = cmd.Parameters;
                try
                {
                    Guid userID = (Guid)Membership.GetUser(oldUsername).ProviderUserKey;

                    cmd.CommandText = @"UPDATE aspnet_Users 
                                        SET UserName=@NewUserName,LoweredUserName=@NewLoweredUserName
                                        WHERE UserId=@UserID";
                    parameters.AddWithValue("@NewUserName", newUsername);
                    parameters.AddWithValue("@NewLoweredUserName", newUsername.ToLower());
                    parameters.AddWithValue("@UserID", userID);
                    int record = (int)cmd.ExecuteNonQuery();

                    if (record > 0)
                    {
                        isSuccsesfullyUpdate=true;
                    }
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    //this.resultMessageCategories = Messages(MessageFor.TransactionCancel) + ex.Message;
                }
            }
            finally
            {
                CloseSqlConnection(dbConnection);
            }

            return isSuccsesfullyUpdate;
        }

        //public static List<Application> GetApplications()
        //{
        //    List<Application> applications = new List<Application>();
        //    DataTable dtApplications = new DataTable("Applications");

        //    SqlConnection dbConnection = GetConnection("ShopHelperMembershipDb");

        //    SqlCommand selectCommand = GetSqlCommand(dbConnection);
        //    selectCommand.CommandText = "SELECT ApplicationName FROM aspnet_Applications";
            
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //    dataAdapter.SelectCommand = selectCommand;
        //    dataAdapter.Fill(dtApplications);

        //    foreach (DataRow row in dtApplications.Rows)
        //    {
        //        Application currentApplication = new Application()
        //        {
        //            ApplicationName = row["ApplicationName"].ToString(),
        //        };
        //        applications.Add(currentApplication);
        //    }

        //    return applications;
        //}
    }
}
