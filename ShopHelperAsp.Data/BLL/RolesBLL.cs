namespace ShopHelperAsp.Data.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Web.Security;
    using System.Text;
    using ShopHelperAsp.Data.Entities;

    public class RolesBLL
    {
        //RolesForApplications
        public static List<string> GetRolesByApplication(string applicationName)
        {
            List<string> applicationRolesList;
            if (!String.IsNullOrEmpty(applicationName))
            {
                Roles.ApplicationName = applicationName;
                string[] applicationRoles = Roles.GetAllRoles();
                applicationRolesList = new List<string>(applicationRoles);
                Roles.ApplicationName = "ShopHelperAsp"; 
            }
            else
            {
                applicationRolesList = new List<string>();
            }
            return applicationRolesList;
        }

        public static List<Application> GetRolesApplications()
        {
            List<Application> allApplicationsRolesList = new List<Application>();
            foreach (Application application in ApplicationsBLL.GetApplications(ApplicationsOptionAll.False))
            {
                if (application.ApplicationName!="---Select Application---")
                {
                    Application appRolse = new Application();
                    appRolse.ApplicationName = application.ApplicationName;
                    Roles.ApplicationName = application.ApplicationName;
                    string[] applicationRoles = Roles.GetAllRoles();
                    appRolse.ApplicationRoles = new List<string>(applicationRoles);
                    allApplicationsRolesList.Add(appRolse); 
                }
            }
            Roles.ApplicationName = "ShopHelperAsp"; 
            return allApplicationsRolesList;
        }

        public static bool CreateRoleForApplication(string applicationName,string roleName)
        {
            bool isRoleCreated = false;
            Roles.ApplicationName = applicationName;
            if (!Roles.RoleExists(roleName))
            {
                Roles.CreateRole(roleName);
                if (Roles.RoleExists(roleName))
                {
                    isRoleCreated=true;
                }
            }
            Roles.ApplicationName = "ShopHelperAsp"; 
            return isRoleCreated;
        }

        public static bool DeleteRoleForApplication(string applicationName, List<string> checkedRoles)
        {
            bool isRoleDeleted = false;
            Roles.ApplicationName = applicationName;
            int counter = 0;

            for (int i = 0; i < checkedRoles.Count; i++)
            {
                try
                {
                    string[] usersInRole = Roles.GetUsersInRole(checkedRoles[i]);

                    if (usersInRole.Length > 0)
                    {
                        Roles.RemoveUsersFromRole(usersInRole, checkedRoles[i]);
                    }

                    if (Roles.DeleteRole(checkedRoles[i], true))
                    {
                        counter++;
                    }

                }
                catch (Exception ex)
                {
                    //
                }
            }

            if (counter != 0)
            {
                isRoleDeleted = true;
            }
            Roles.ApplicationName = "ShopHelperAsp";
            return isRoleDeleted;
        }

        //RolesForUsers
        public static List<string> GetRolesForUserByApplication(string applicationName, string username)
        {
            Roles.ApplicationName = applicationName;
            string[] userRoles = Roles.GetRolesForUser(username);
            List<string> userRolesList = new List<string>(userRoles);
            Roles.ApplicationName = "ShopHelperAsp";
            return userRolesList;
        }

        public static string GetRolesForUserInOneString(string applicationName,string username)
        {
            Roles.ApplicationName = applicationName;
            string[] userRoles = Roles.GetRolesForUser(username);
            StringBuilder concatUserRoles = new StringBuilder();

            for (int i = 0; i < userRoles.Length; i++)
            {
                if (i == 0 || userRoles.Length == 1)
                {
                    concatUserRoles.Append(userRoles[i]);
                }
                else
                {
                    concatUserRoles.Append(" ,");
                    concatUserRoles.Append(userRoles[i]);
                }
            }
            Roles.ApplicationName = "ShopHelperAsp";
            return concatUserRoles.ToString();
        }

    }
}
