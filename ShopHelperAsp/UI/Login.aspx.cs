using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Principal;
using System.Web.UI.HtmlControls;

namespace ShopHelperAsp
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HtmlGenericControl obj = new HtmlGenericControl("object");
            //HtmlGenericControl embedTag = new HtmlGenericControl("img");
            //obj.Attributes["type"] = "application/x-oleobject";
            //obj.Attributes["data"] = "../SVG/ShopHelper_Architecture.svg";
            //obj.Attributes["width"] = "350";
            //obj.Attributes["height"] = "230";
            //obj.ID = "object";
            //embedTag.Attributes["src"] = "../SVG/ShopHelper_Architecture.svg";
            //embedTag.Attributes["runat"] = "server";
            //obj.Controls.Add(embedTag);
            //this.SVGContainer.Controls.Add(obj);
            //Response.ContentType = "image/svg+xml";
            //Response.ContentType = "application/xhtml+xml";
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            //Membership.CreateUser("a", "aaaaaa");
            //FormsAuthentication.RedirectFromLoginPage(textBox_Username.Text, false);
            //textBox_Username.Text = "admin";
            //textBox_Password.Text = "admin";

            if (Membership.ValidateUser(Server.HtmlEncode(textBox_Username.Text), Server.HtmlEncode(textBox_Password.Text)))
            {
                FormsAuthentication.RedirectFromLoginPage(textBox_Username.Text, false);
            }
            else
            {
                LabelErrorMsg.Text = "Invalid login!Wrong pass or username or Stop cheating stupid bot";
            }

        }
    }
}