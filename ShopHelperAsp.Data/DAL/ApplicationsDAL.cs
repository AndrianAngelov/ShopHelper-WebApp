namespace ShopHelperAsp.Data.DAL
{
    using System;
    using System.Collections.Generic;
    using ShopHelperAsp.Data.Entities;
    using System.Data;
    using System.Data.SqlClient;

    public class ApplicationsDAL:BaseDAL
    {
        public static List<Application> GetApplications()
        {
            List<Application> applications = new List<Application>();
            DataTable dtApplications = new DataTable("Applications");

            SqlConnection dbConnection = GetConnection("ShopHelperMembershipDb");

            SqlCommand selectCommand = GetSqlCommand(dbConnection);
            selectCommand.CommandText = "SELECT ApplicationName FROM aspnet_Applications";

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = selectCommand;
            dataAdapter.Fill(dtApplications);

            foreach (DataRow row in dtApplications.Rows)
            {
                Application currentApplication = new Application()
                {
                    ApplicationName = row["ApplicationName"].ToString(),
                };
                applications.Add(currentApplication);
            }

            return applications;
        }
    }
}
