namespace ShopHelperAsp.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        private string applicationName = null;
        private List<string> applicationRoles = new List<string>();
        private string applicationRolesString = null;

        public string ApplicationName
        {
            get { return this.applicationName; }
            set { this.applicationName = value; }
        }

        public List<string> ApplicationRoles
        {
            get { return this.applicationRoles; }
            set { this.applicationRoles = value; }
        }

        public string ApplicationRolesString
        {
            get
            {
                if (String.IsNullOrEmpty(this.applicationRolesString))
                {
                    this.applicationRolesString = "NULL";
                }
                return this.applicationRolesString;
            }
            set { this.applicationRolesString = value; }
        }
    }
}
