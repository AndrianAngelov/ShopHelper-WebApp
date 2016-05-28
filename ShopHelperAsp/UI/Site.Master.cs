using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Routing;
using System.Web.Profile;
using System.Web.Configuration;

namespace ShopHelperAsp
{
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //Response.Redirect(Page.GetRouteUrl("login", null));
            //Response.Redirect("~/Login.aspx");

            //this.SiteMapDataSource.GetRouteUrl(RouteTable.Routes);

            MembershipUser currentUser = Membership.GetUser();
            if (currentUser != null)
            {
                this.MainMenuWrapper.Visible = true;
                this.ButtonLogout.Visible = true;
                string cloudinaryStoreURL = WebConfigurationManager.AppSettings["AccountsStoreURL"];
                string accountsFolder = WebConfigurationManager.AppSettings["AccountsFolderName"];
                this.LoginUserProfileImage.ImageUrl = String.Format(@"{0}/{1}/{2}/{3}/{4}.jpg", cloudinaryStoreURL, currentUser.Comment, accountsFolder, Membership.ApplicationName, currentUser.UserName);
                this.LoginUserProfileImage.Visible = true;
                this.BreadcrumpWrapper.Visible = true;
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void MainMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            //this.BreadcrumpWrapper.Visible = false;
            //this.MainContentUpdatePanel.Update();
            //if (e.Item.Selected)
            //{
            //    e.Item.Enabled = false;
            //    e.Item.Text = "selected";
            //}
            //if (e.Item.Text == "Admin" )
            //{
            //    e.Item.Enabled = false;
            //}

        }

        protected void MainMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            //if (e.Item.Text=="Home")
            //{

            //}
            //if (e.Item.Text == "Employees")
            //{

            //}
            //if (e.Item.Text == "Manager")
            //{

            //}
            //if (e.Item.Text == "Admin")
            //{
            //    e.Item.ImageUrl = @"~/Images/MainMenu/adminIcon.png";
            //}
            //if (SiteMap.CurrentNode != null)
            //{
            //    if (e.Item.Text == SiteMap.CurrentNode.Title)
            //    {
            //        e.Item.Selected = true;
            //    }
            //}
            string pageURL = Request.Url.AbsolutePath;
            if (pageURL.Contains("Admin"))
            {
                e.Item.Value = "selected";
            }
        }

        private void SetCurrentPage()
        {
            //Grab the Menu in the Master page
            Menu menu = (Menu)Master.FindControl("MainMenu");

            //Get the current name of your Page
            //var pageName = Request.Url.AbsolutePath.Split('/').LastOrDefault();
            string pageURL = Request.Url.AbsolutePath;

            //if (pageURL.Contains("Admin"))
            //{
            //    MenuItem menuItem = menu.FindControl("Menu_A") as MenuItem;
            //    menuItem.Attributes["class"] = "current";
            //}
            //Apply the class based on your page name
            //switch (pageName)
            //{
            //    case "A.aspx":
            //        //Target the appropriate menu item
            //        MenuItem menuItem = menu.FindControl("Menu_A") as MenuItem;
            //        menuItem.Attributes["class"] = "current";
            //        break;
            //    case "B.aspx":
            //        //Target the appropriate menu item
            //        MenuItem menuItem = menu.FindControl("Menu_B") as MenuItem;
            //        menuItem.Attributes["class"] = "current";
            //        break;
            //    case "C.aspx":
            //        //Target the appropriate menu item
            //        MenuItem menuItem = menu.FindControl("Menu_C") as MenuItem;
            //        menuItem.Attributes["class"] = "current";
            //        break;
            //    default:
            //        //Page was not found
            //        break;
            //}
        }
    }
}