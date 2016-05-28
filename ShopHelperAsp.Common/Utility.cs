namespace ShopHelperAsp.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public enum StatusMessages
    {
        SuccessfullInsertNewUser,
        SuccessfullUpdateUser,
        SuccessfullDeleteUser,
        SuccessfullInsertNewRole,
        SuccessfullUpdateRole,
        SuccessfullDeleteRole,
        UserAlreadyExist,
        RoleAlreadyExist
    } 

    public class Utility
    {
        public static void ShowMessageAfterPOST(Page currentPage , string message)
        {
            string confirmscript = @"<script language='javascript'>function f(){showStatusMessage(" + "'" + message + "'" + ");$('.dialog.ui-dialog').hide(); Sys.Application.remove_load(f) ;}; Sys.Application.add_load (f);</script>";
            currentPage.ClientScript.RegisterStartupScript(currentPage.GetType(), "confirm", confirmscript);
        }

        public static void ShowMessageAfterAsync(Page currentPage , string message)
        {
            string script = String.Format(@"alert('','{0}');", message);
            ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "delUserAlert", script, true);
        }

        public static void Clear(ControlCollection conatainerControlsCollection)
        {
            foreach (Control control in conatainerControlsCollection)
            {
                Clear((ControlCollection)control.Controls);
                if (control is TextBox)
                {
                    (control as TextBox).Text = "";
                }
                if (control is DropDownList)
                {
                    ((DropDownList)control).SelectedIndex = 0;
                }
                if (control is CheckBoxList)
                {
                    ((CheckBoxList)control).Items.Clear();
                }
            }
        }

        public static string GetStatusMessage(StatusMessages status)
        {
            string statusMessage = "";

            switch (status)
            {
                case StatusMessages.SuccessfullInsertNewUser:
                    statusMessage = "Successfull insert new user";
                    break;
                case StatusMessages.SuccessfullUpdateUser:
                    statusMessage = "Successfull update user";
                    break;
                case StatusMessages.SuccessfullDeleteUser:
                    statusMessage = "Successfull delete user";
                    break;
                case StatusMessages.SuccessfullInsertNewRole:
                    statusMessage = "Successfull insert new role";
                    break;
                case StatusMessages.SuccessfullUpdateRole:
                    statusMessage = "Successfull update role";
                    break;
                case StatusMessages.SuccessfullDeleteRole:
                    statusMessage = "Successfull delete role";
                    break;
                case StatusMessages.UserAlreadyExist:
                    statusMessage = "This user already exist.";
                    break;
                case StatusMessages.RoleAlreadyExist:
                    statusMessage = "This role already exist in this application.";
                    break;
            }
            return statusMessage;
        } 
    }
}
