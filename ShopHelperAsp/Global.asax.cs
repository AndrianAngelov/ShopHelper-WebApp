using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.IO;

namespace ShopHelperAsp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            //SiteMap.CurrentNode.Url=
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("login", "Login", "~/UI/Login.aspx");
            routes.MapPageRoute("home", "Home", "~/UI/Home.aspx");

            routes.MapPageRoute("topSeller", "Employees/TopSeller", "~/UI/Employees/TopSeller.aspx");

            routes.MapPageRoute("products", "Manager/Products", "~/UI/Manager/Products.aspx");
            routes.MapPageRoute("categories", "Manager/Categories", "~/UI/Manager/Categories.aspx");
            routes.MapPageRoute("vendors", "Manager/Vendors", "~/UI/Manager/Vendors.aspx");
            routes.MapPageRoute("stores", "Manager/Stores", "~/UI/Manager/Stores.aspx");
            routes.MapPageRoute("towns", "Manager/Towns", "~/UI/Manager/Towns.aspx");

            routes.MapPageRoute("users", "Admin/UsersAccountsManagment", "~/UI/Admin/UsersAccounts.aspx");
            routes.MapPageRoute("roles", "Admin/RolesManagment", "~/UI/Admin/RolesCenter.aspx");
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}