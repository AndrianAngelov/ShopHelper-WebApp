namespace ShopHelperAsp.UI.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ShopHelperAsp.Data.BLL;
    using System.Web.UI.HtmlControls;
    using ShopHelperAsp.Common;

    public partial class RolesCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //PopulateGridViewApplicationsRoles();
            }
            PopulateGridViewApplicationsRoles();
        }

        protected void DropDownApplicationsInsertRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.CheckBoxListApplicationRoles
            //this.ObjectDataSourceApplications.Select();

        }

        protected void DropDownApplicationsDeleteRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string applicationName = this.DropDownApplicationsDeleteRole.SelectedValue;
            this.CheckBoxListApplicationRoles.DataSource = RolesBLL.GetRolesByApplication(applicationName);
            this.CheckBoxListApplicationRoles.DataBind();

            //if (this.DropDownApplicationsDeleteRole.SelectedValue != "---Select Application---")
            //{
            //    this.CheckBoxListApplicationRoles.DataSourceID = "ObjectDataSourceApplicationRoles";
            //    this.ObjectDataSourceApplicationRoles.Select();
            //}
            //else
            //{
            //    this.CheckBoxListApplicationRoles.DataSourceID = null;
            //}
            ////this.ObjectDataSourceApplicationRoles.Select();
        }

        protected void DropDownApplicationsEditRole_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        protected void TestBtn_Click(object sender, EventArgs e)
        {
            string confirmscript1 = "<script language='javascript'>function f(){alert('test');$('.dialog.ui-dialog').hide(); Sys.Application.remove_load(f) ;}; Sys.Application.add_load (f);</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "confirm1", confirmscript1);

            string script = "alert('s','test1')";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "del", script, true);
        }

        protected void ButtonInsertRole_Click(object sender, EventArgs e)
        {
            bool isRoleCreated = false;
            string applicationName = this.DropDownApplicationsInsertRole.SelectedValue;
            string roleName = this.TextBoxRoleName.Text;
            isRoleCreated = RolesBLL.CreateRoleForApplication(applicationName, roleName);
            if (isRoleCreated)
            {
                Utility.Clear(this.UpdatePanelInsertNewRole.Controls);
                Utility.ShowMessageAfterPOST(Page, Utility.GetStatusMessage(StatusMessages.SuccessfullInsertNewRole));
                PopulateGridViewApplicationsRoles();
            }
        }

        protected void ButtonDeleteRole_Click(object sender, EventArgs e)
        {
            bool isRoleDeleted = false;
            string applicationName = this.DropDownApplicationsDeleteRole.SelectedValue;
            List<string> checkedRoles = new List<string>();
            foreach (ListItem role in this.CheckBoxListApplicationRoles.Items)
            {
                if (role.Selected)
                {
                    checkedRoles.Add(role.Value);
                }
            }

            isRoleDeleted = RolesBLL.DeleteRoleForApplication(applicationName, checkedRoles);

            if (isRoleDeleted)
            {
                Utility.Clear(this.UpdatePanelDeleteRole.Controls);
                Utility.ShowMessageAfterPOST(Page, Utility.GetStatusMessage(StatusMessages.SuccessfullDeleteRole));
                PopulateGridViewApplicationsRoles();
            }
        }

        protected void ButtonEditRole_Click(object sender, EventArgs e)
        { 
        }

        protected void ButtonCancelInsertRole_Click(object sender, EventArgs e)
        {
            Utility.Clear(this.UpdatePanelInsertNewRole.Controls);
        }

        protected void ButtonCancelDeleteRole_Click(object sender, EventArgs e)
        {
            Utility.Clear(this.UpdatePanelDeleteRole.Controls);
        }

        protected void ButtonCancelEditRole_Click(object sender, EventArgs e)
        {
 
        }

        private void PopulateGridViewApplicationsRoles()
        {
            this.GridViewApplicationsRoles.DataSource = RolesBLL.GetRolesApplications();
            this.GridViewApplicationsRoles.DataBind();
        }

        //protected void ObjectDataSourceApplications_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        //{
        //    //e.InputParameters["applicationName"] = "ShopHelper_Sofia";
        //}

        //protected void ObjectDataSourceApplicationRoles_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        //{
        //    if (this.DropDownApplicationsInsertRole.SelectedValue != "---Select Application---")
        //    {
        //        e.InputParameters["applicationName"] = this.DropDownApplicationsInsertRole.SelectedValue;
        //    }
        //    else
        //    {
        //        //this.CheckBoxListApplicationRoles.Items
        //    }
        //    //e.InputParameters["applicationName"] = "ShopHelper_Sofia";
        //}

        /*//DataList dList;
            //foreach (GridViewRow row in GridViewApplicationsRoles.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        DataList dList = (DataList)row.FindControl("DataListRoles");
            //        Literal lit = (Literal)row.FindControl("AppName");
            //        //dList.DataSource = RolesBLL.GetRolesByApplication(lit.Text);
            //        dList.DataSource = RolesBLL.GetRolesByApplication(lit.Text);
            //        dList.DataBind();
            //    }
            //}*/
    }
}