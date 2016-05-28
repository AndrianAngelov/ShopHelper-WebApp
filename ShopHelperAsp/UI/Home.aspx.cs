using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHelperAsp.UI
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //(Master as Site).MainMenu.Visible = true;
            //SiteMap.CurrentNode.Url = Page.GetRouteUrl("home", null);
            //SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(this.ExpandForumPaths);

            this.homeContent.InnerHtml = @"Здравейте вие сте в home старницата ";
        }

        private SiteMapNode ExpandForumPaths(Object sender, SiteMapResolveEventArgs e)
        {
            SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
            SiteMapNode tempNode = currentNode;
            tempNode.Url = "Some";
            return currentNode;
        }
    }
}