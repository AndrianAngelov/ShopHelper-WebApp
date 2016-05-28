using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHelperAsp.UI
{
    public partial class NestedMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (e.Item.Text == "Users Accounts")
            {
                e.Item.ImageUrl = @"~/Images/SubMenu/user-password.png";
            }
            if (e.Item.Text == "Roles")
            {
                e.Item.ImageUrl = @"~/Images/SubMenu/RolesCenterIcon.png";
            }

            if (e.Item.Selected)
            {
                e.Item.Enabled = false;
            }
        }

        //protected void SubMenu_MenuItemClick(object sender, MenuEventArgs e)
        //{
        //    Label lbl = (Label)this.Master.FindControl("TestLabelMainForm");
        //    lbl.Text = "uuuuuuuu";
        //    string str = ((Menu)sender).SelectedItem.Target;
        //    this.Literal1.Text = e.Item.NavigateUrl;
        //    this.Literal1.Text = "str";
        //    //UpdatePanel mainContent = (UpdatePanel)this.Master.FindControl("MainContentUpdatePanel");
        //    //mainContent.Update();
        //    this.UpadatePanelSubFormsContent.Update();
        //}
        //protected void SubMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        //{
        //    count++;
        //    if (SiteMap.CurrentNode != null)
        //    {
        //        if (e.Item.Text == SiteMap.CurrentNode.Title)
        //        {
        //            e.Item.Selected = true;
        //            Label lbl = (Label)this.Master.FindControl("TestLabelMainForm");
        //            lbl.Text = count.ToString();
        //            ContentPlaceHolder contentPH = (ContentPlaceHolder)this.Page.Master.Master.FindControl("MainFormContentPlaceHolder");
        //            UpdatePanel up = (UpdatePanel)contentPH.FindControl("UpadatePanelSubFormsContent");
        //            up.Update();
        //        }
        //    }
        //}
    }
}