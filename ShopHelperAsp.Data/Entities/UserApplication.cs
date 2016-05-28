namespace ShopHelperAsp.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Security;
    using ShopHelperAsp;
    using System.Configuration;
    using System.Web.Profile;
    using System.Xml;
    using System.Reflection;

    public class UserApplication
    {
        private MembershipUser user;
        private string appName = null;
        private string username = null;
        private string oldUsernameForUpdate = null;
        private string newUsernameForUpdate = null;
        private string password = null;
        private string profileImageURL = null;
        private string resetPassword = null;
        private List<string> userRoles = new List<string>();
        private string userRolesString = null;

        public UserApplication()
        {
        }

        public UserApplication(MembershipUser user, string appName, string profileImageURL)
        {
            this.user = user;
            this.AppName = appName;
            this.ProfileImageURL = profileImageURL;
        }

        public UserApplication(MembershipUser user, string appName, string profileImageURL, List<string> userRoles)
            : this(user, appName, profileImageURL)
        {
            this.userRoles = userRoles;
        }

        public UserApplication(MembershipUser user, string appName, string profileImageURL, string userRolesString)
            : this(user, appName, profileImageURL)
        {
            this.userRolesString = userRolesString;
        }

        public UserApplication(MembershipUser user, string appName, string profileImageURL, string userRolesString, List<string> userRoles)
            : this(user, appName, profileImageURL, userRolesString)
        {
            this.userRoles = userRoles;
        }


        public string ProfileImageURL
        {
            get { return this.profileImageURL; }
            set { this.profileImageURL = value; }
        }

        public string UserName
        {
            get
            {
                if (this.username == null)
                {
                    return this.user.UserName;
                }
                else
                {
                    return this.username;
                }
            }
            set { this.username = value; }
        }

        public string OldUsernameForUpdate
        {
            get { return this.oldUsernameForUpdate; }
            set { this.oldUsernameForUpdate = value; }
        }

        public string NewUsernameForUpdate
        {
            get { return this.newUsernameForUpdate; }
            set { this.newUsernameForUpdate = value; }
        }

        public string Password
        {
            get
            {
                if (this.password == null)
                {
                    return "TODO";
                }
                else
                {
                    return this.password;
                }
            }
            set { this.password = value; }
        }

        public DateTime LastActivityDate
        { get { return this.user.LastActivityDate; } }

        public bool IsOnline
        { get { return this.user.IsOnline; } }

        public string AppName
        {
            get { return this.appName; }
            set { this.appName = value; }
        }

        public DateTime CreationDate
        { get { return this.user.CreationDate; } }

        public string ResetUserPassword
        {
            get { return this.resetPassword; }
            set { this.resetPassword = value; }
        }
       
        public List<string> UserRoles
        {
            get 
            {
                if (this.userRoles.Count==0 )
                {
                    this.userRoles.Add("The user isn't in roles");
                }
                return this.userRoles; 
            }
            set { this.userRoles = value; }
        }

        public string UserRolesString
        {
            get
            {
                if (String.IsNullOrEmpty(this.userRolesString))
                {
                    this.userRolesString = "The user isn't in roles";
                }
                return this.userRolesString;
            }
            set { this.userRolesString = value; }
        }
    }
}
