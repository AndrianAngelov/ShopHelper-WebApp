namespace ShopHelperAsp.UI.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System.Resources;
    using System.Globalization;
    using System.Collections;
    using System.Xml;
    using System.Drawing;
    using System.Web.Profile;
    using ShopHelperAsp.Data;
    using ShopHelperAsp.Data.BLL;
    using System.IO;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using System.Web.Configuration;
    using System.Web.UI.HtmlControls;
    using ShopHelperAsp.Data.Entities;
    using ShopHelperAsp.Common;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.Diagnostics;
    using System.Configuration;
    using iTextSharp.text.pdf.draw;
    using ShopHelperAsp.Data.ExportToPDF;
    using System.Text;

    public partial class UsersAccounts : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.UsersHeaderTitle.Text = "All Users";
            }
            //this.rolesIsValid.Visible = false;
            //if (Page.IsPostBack)
            //{
            //    //string hideValdationErrorMsg = "hideValidationMsg();";
            //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "hideValidMsg", hideValdationErrorMsg, true);
            //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "hideValidMsg1", "aler('is postback');", true);
            //}
            string hideValdationErrorMsg = "hideValidationMsg()";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "hideValidMsg", hideValdationErrorMsg, true);
        }

        protected void DataPagerUsers_PreRender(object sender, EventArgs e)
        {
            if (this.ListViewUsers.EditIndex == -1)
            {
                PopulateListViewUsers();
            }
            //string hideValdationErrorMsg = "alert()";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "hideValidMsg1", hideValdationErrorMsg, true);
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "AKey", "alert();", true);
        }

        protected void DropDownApplicationNewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string applicationName = this.DropDownApplicationNewUser.SelectedValue;
            string applicationName = this.DropDownApplicationNewUser.SelectedItem.Text;
            this.CheckBoxListApplicationRoles.DataSource = RolesBLL.GetRolesByApplication(applicationName);
            this.CheckBoxListApplicationRoles.DataBind();

        }

        protected void DropDownApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.DataPagerUsers.QueryStringField = "page=1";
            //string url = Request.Url.AbsolutePath;
            //PopulateListViewUsers();

            this.DataPagerUsers.SetPageProperties(0, 6, false);

            if (!this.DropDownApplications.SelectedItem.Text.Equals("---Select Application---"))
            {
                this.UsersHeaderTitle.Text = this.DropDownApplications.SelectedItem.Text + " Users";
            }
            else
            {
                this.UsersHeaderTitle.Text = "All Users";
            }
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            //this.rolesIsValid.Visible = false;
            bool isInsertSuccsessfully = false;
            this.Page.Validate("ValidationGroupNames");
            if (this.Page.IsValid)
            {
                HideValidationMessages();
                try
                {
                    List<string> checkedRoles = new List<string>();
                    foreach (System.Web.UI.WebControls.ListItem role in this.CheckBoxListApplicationRoles.Items)
                    {
                        if (role.Selected)
                        {
                            checkedRoles.Add(role.Value);
                            this.rolesIsValid.Visible = false;
                        }
                        else
                        {
                            this.rolesIsValid.Visible = true;
                        }
                    }
                    if (checkedRoles.Count==0)
                    {
                        this.rolesIsValid.Visible = true;
                    }
                    UserApplication newUser = new UserApplication();
                    newUser.AppName = this.DropDownApplicationNewUser.SelectedItem.Text;
                    newUser.UserName = this.TextBoxUsername.Text;
                    newUser.Password = this.TextBoxPassword.Text;
                    newUser.UserRoles = checkedRoles;
                    isInsertSuccsessfully = UsersApplicationsBLL.CreateNewUserApp(newUser, this.UploadProfileImage);

                    if (isInsertSuccsessfully)
                    {
                        Utility.Clear(this.InsertUserContent.Controls);
                        PopulateListViewUsers();
                        Utility.ShowMessageAfterPOST(Page, Utility.GetStatusMessage(StatusMessages.SuccessfullInsertNewUser));
                    }
                }
                catch (MembershipCreateUserException)
                {
                    Utility.ShowMessageAfterPOST(Page, Utility.GetStatusMessage(StatusMessages.UserAlreadyExist));
                }
            }
            else
            {
                ShowValidationMessages();
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            //HideValidationMessages();
           
            Utility.Clear(this.InsertUserContent.Controls);
        }
        
        protected void ListViewUsers_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            ListViewUsers.EditIndex = e.NewEditIndex;
            PopulateListViewUsers();

            if (this.ListViewUsers.EditIndex != -1)
            {
                Panel validationMsg = (Panel)this.ListViewUsers.Items[this.ListViewUsers.EditIndex].FindControl("editNameContainerIsValid");
                UpdatePanel updatePanel = (UpdatePanel)this.ListViewUsers.Items[this.ListViewUsers.EditIndex].FindControl("UpdatePanelEdit");
                TextBox TextBoxUserNameEdit = (TextBox)updatePanel.FindControl("TextBoxUsernameEdit");
                CheckBoxList CheckBoxListRolesOfUser = (CheckBoxList)updatePanel.FindControl("CheckBoxListRolesOfUser");
                Literal ListeralApplicationName = (Literal)updatePanel.FindControl("LiteralAppNameEdit");
                List<String> userRolesList = RolesBLL.GetRolesForUserByApplication(ListeralApplicationName.Text, TextBoxUserNameEdit.Text);
                List<String> applicationRolesList = RolesBLL.GetRolesByApplication(ListeralApplicationName.Text);

                validationMsg.Visible = false;

                foreach (string applicationRole in applicationRolesList)
                {
                    System.Web.UI.WebControls.ListItem listItem = new System.Web.UI.WebControls.ListItem(applicationRole, "", true);
                    
                    foreach (string userRole in userRolesList)
                    {
                        if (applicationRole == userRole)
                        {
                            listItem.Selected = true;
                        }
                    }

                    CheckBoxListRolesOfUser.Items.Add(listItem);
                }
            }
        }

        protected void ListViewUsers_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            bool isSuccsesfullyUpdate = false;
            Panel validationMsg = (Panel)this.ListViewUsers.Items[e.ItemIndex].FindControl("editNameContainerIsValid");
            HtmlInputFile uploadEditImage = (HtmlInputFile)this.ListViewUsers.Items[e.ItemIndex].FindControl("UploadProfileImageEdit");
            TextBox textBoxUsername = (TextBox)this.ListViewUsers.Items[e.ItemIndex].FindControl("TextBoxUsernameEdit");
            TextBox textBoxResetPassword = (TextBox)this.ListViewUsers.Items[e.ItemIndex].FindControl("TextBoxResetPassword");
            Literal literalAppName = (Literal)this.ListViewUsers.Items[e.ItemIndex].FindControl("LiteralAppNameEdit");
            Literal literalOldUserName = (Literal)this.ListViewUsers.Items[e.ItemIndex].FindControl("LiteralOldUserName");
            CheckBoxList CheckBoxListRolesOfUser = (CheckBoxList)this.ListViewUsers.Items[e.ItemIndex].FindControl("CheckBoxListRolesOfUser");

            
            UserApplication updateUser = new UserApplication();
            updateUser.AppName = literalAppName.Text;
            updateUser.OldUsernameForUpdate = literalOldUserName.Text;
            updateUser.NewUsernameForUpdate = textBoxUsername.Text;
            updateUser.ResetUserPassword = textBoxResetPassword.Text;

            foreach (System.Web.UI.WebControls.ListItem role in CheckBoxListRolesOfUser.Items)
            {
                if (role.Selected == true && !updateUser.UserRoles[0].Equals("The user isn't in roles"))
                {
                    updateUser.UserRoles.Add(role.Text);
                }
                if (role.Selected == true && updateUser.UserRoles[0].Equals("The user isn't in roles"))
                {
                    updateUser.UserRoles[0] = role.Text;
                }
            }

            //this.Page.Validate("ValidationGroupEditUser");
            if (!String.IsNullOrEmpty(updateUser.NewUsernameForUpdate))
            {

                isSuccsesfullyUpdate = UsersApplicationsBLL.UpdateUserApp(updateUser, uploadEditImage);

                if (isSuccsesfullyUpdate)
                {
                    Utility.ShowMessageAfterPOST(Page, Utility.GetStatusMessage(StatusMessages.SuccessfullUpdateUser) + " " + updateUser.NewUsernameForUpdate);
                    ListViewUsers.EditIndex = -1;
                }
                //else
                //{
                //    Utility.ShowMessageAfterPOST(Page, "Something wrongs");
                //}
                PopulateListViewUsers();
                validationMsg.Visible = false;
            }
            if (String.IsNullOrEmpty(updateUser.NewUsernameForUpdate))
            {
                validationMsg.Visible = true;
            }
        }

        protected void ListViewUsers_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            bool isDeleteSuccsessfully = false;
            Label literalUsername = (Label)this.ListViewUsers.Items[e.ItemIndex].FindControl("LiteralUserName");
            Literal literalAppName = (Literal)this.ListViewUsers.Items[e.ItemIndex].FindControl("LiteralAppName");

            UserApplication deleteUser = new UserApplication();
            deleteUser.AppName = literalAppName.Text;
            deleteUser.UserName = literalUsername.Text;

            isDeleteSuccsessfully = UsersApplicationsBLL.DeleteUserApp(deleteUser);

            if (isDeleteSuccsessfully)
            {
                Utility.ShowMessageAfterAsync(Page, Utility.GetStatusMessage(StatusMessages.SuccessfullDeleteUser));
            }
            else
            {
                Utility.ShowMessageAfterAsync(Page, "Something wrongs with delete user");
            }
            PopulateListViewUsers();
        }

        protected void ListViewUsers_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            ListViewUsers.EditIndex = -1;
            PopulateListViewUsers();
            e.Cancel = true;
        }

        protected void ButtonExportToPDF_Click(object sender, EventArgs e)
        {
            List<UserApplication> users = new List<UserApplication>();
            string officeUsers = "";
            if (this.DropDownApplications.SelectedValue == "---Select Application---" || this.DropDownApplications.SelectedValue == "All" || this.DropDownApplications.SelectedValue == "")
            {
                users = UsersApplicationsBLL.GetAllUsersApps(SelectApplications.All);
                officeUsers = "All";
            }
            else
            {
                users = UsersApplicationsBLL.GetAllUsersApps(SelectApplications.SpecifucApplication, this.DropDownApplications.SelectedItem.Text);
                officeUsers = this.DropDownApplications.SelectedValue;
            }
            ExportToPDF.Users(Page.Server, users, officeUsers, this.savePdfVersion);
         
            string pdfName = "http://res.cloudinary.com/hzgrm4rdh/image/upload/" + this.savePdfVersion.Value + "/PDFs/Users_" + officeUsers + ".pdf";

            Response.Redirect(pdfName);
        }

        #endregion

        #region Methods
        private void PopulateListViewUsers()
        {
            if (this.DropDownApplications.SelectedValue == "---Select Application---" || this.DropDownApplications.SelectedValue == "All" || this.DropDownApplications.SelectedValue == "")
            {
                this.ListViewUsers.DataSource = UsersApplicationsBLL.GetAllUsersApps(SelectApplications.All);
                this.ListViewUsers.DataBind();
            }
            else
            {
                this.ListViewUsers.DataSource = UsersApplicationsBLL.GetAllUsersApps(SelectApplications.SpecifucApplication, this.DropDownApplications.SelectedItem.Text);
                this.ListViewUsers.DataBind();
            }
        }

        private void ShowValidationMessages()
        {
            string showValdationErrorMsg = "function f(){showValidationMsg()}; Sys.Application.remove_load(f) ;}; Sys.Application.add_load (f);";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "showValidMsg", showValdationErrorMsg, true);
        }

        private void HideValidationMessages()
        {
            string hideValdationErrorMsg = "hideValidationMsg();";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "hideValidMsg", hideValdationErrorMsg);
        }

        private void HideUsersListViewLoader()
        {
            string hideListViewLoader = "hideListViewLoader();";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "hideListViewLoader", hideListViewLoader);
        }
        #endregion

        #region FOR TEST
        protected void testBtn_Click(object sender, EventArgs e)
        {
            //CreatePDF();
            List<UserApplication> users = new List<UserApplication>();
            string officeUsers = "";
            if (this.DropDownApplications.SelectedValue == "---Select Application---" || this.DropDownApplications.SelectedValue == "All" || this.DropDownApplications.SelectedValue == "")
            {
                users = UsersApplicationsBLL.GetAllUsersApps(SelectApplications.All);
                officeUsers = "All";
            }
            else
            {
                users = UsersApplicationsBLL.GetAllUsersApps(SelectApplications.SpecifucApplication, this.DropDownApplications.SelectedItem.Text);
                officeUsers = this.DropDownApplications.SelectedValue;
            }
            ExportToPDF.Users(Page.Server, users, officeUsers,this.savePdfVersion);

            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Users.pdf");
            Response.TransmitFile(Server.MapPath("~/App_Data/Users.pdf"));
            Response.End();
        }
        #endregion
    }
}