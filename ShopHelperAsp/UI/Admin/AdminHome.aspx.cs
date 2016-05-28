using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopHelperAsp.UI.Admin
{
    public class Product1
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public partial class AdminHome : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownListCountries.DataSource = products;
                DropDownListCountries.DataBind();
                RebindTowns();

            }

        }
        protected void DropDownListCountries_Changed(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            RebindTowns();
        }

        private void RebindTowns()
        {
            DropDownListCountries.DataSource = products;
            DropDownListCountries.DataBind();
            //int countryId = int.Parse(DropDownListCountries.SelectedValue);
            //CountriesDataContext context = new CountriesDataContext();
            //var towns =
            //    from town in context.Towns
            //    where town.CountryID == countryId
            //    select town;
            //DropDownListTowns.DataSource = towns;
            //DropDownListTowns.DataBind();
        }
        private List<Product1> products = new List<Product1>()
		{ 
			new Product1() { Name="Beer Ariana", Price = 0.86m },
			new Product1() { Name="Vodka Sobieski", Price = 24.20m },
			new Product1() { Name="Rakiya Grozdova", Price = 8.50m },
			new Product1() { Name="Jack Daniel's", Price = 36.40m },
			new Product1() { Name="Beer Zagorka", Price = 1.16m },
			new Product1() { Name="Beer Tuborg", Price = 1.24m },
			new Product1() { Name="Vodka Absolute", Price = 13.70m },
		};
    }
}