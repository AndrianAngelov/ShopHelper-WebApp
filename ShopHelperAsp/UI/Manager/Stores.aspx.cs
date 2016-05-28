using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHelperAsp.UI.Manager
{
    public partial class Stores : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.storesContent.InnerHtml = @"Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата
                                            Здравейте вие сте в Stores старницата";

            //Menu masterPageMenu;
            //TextBox mpTextBox;
            //masterPageMenu = (Menu)Master.FindControl("StoresMenu");
            //masterPageMenu.DataSource = this.SiteMapDataSourceT;
            //if (mpContentPlaceHolder != null)
            //{
            //    mpTextBox = (TextBox)mpContentPlaceHolder.FindControl("TextBox1");
            //    if (mpTextBox != null)
            //    {
            //        mpTextBox.Text = "TextBox found!";
            //    }
            //}
        }

        private SiteMapDataSource GetSiteMapDataSource()
        {
            XmlSiteMapProvider xmlSiteMap = new XmlSiteMapProvider();
            System.Collections.Specialized.NameValueCollection
                   myCollection = new
                   System.Collections.Specialized.NameValueCollection(1);
            myCollection.Add("siteMapFile", "Web.sitemap");
            xmlSiteMap.Initialize("provider", myCollection);
            xmlSiteMap.BuildSiteMap();
            SiteMapDataSource siteMap = new SiteMapDataSource();
            return siteMap;
        }
    }
}