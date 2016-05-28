namespace ShopHelperAsp.Data.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Reflection;
    using ShopHelperAsp.Data.Entities;
    using System.Web.Security;
    using System.Web.Profile;
    using System.Configuration;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using System.Web.UI.HtmlControls;
    using DAL;

    public enum SelectApplications
    {
        All,
        SpecifucApplication
    }
    public class UsersApplicationsBLL
    {
        static string cloudinaryAccount = ConfigurationManager.AppSettings["CLOUDINARY_URL"];
        static string cloudinaryStoreURL = ConfigurationManager.AppSettings["AccountsStoreURL"];
        static string cloudinaryAccountsFolder = ConfigurationManager.AppSettings["AccountsFolderName"];

        public static List<UserApplication> GetAllUsersApps(SelectApplications selectApplications, string applicationName = null)
        {
            List<UserApplication> allUsers = new List<UserApplication>();
            MembershipUserCollection tempUsers = new MembershipUserCollection();

            switch (selectApplications)
            {
                case SelectApplications.All:
                    {
                        //foreach (string appName in GetAllApplicationNames())
                        foreach (Application application in ApplicationsBLL.GetApplications(ApplicationsOptionAll.False))
                        {
                            string appName = application.ApplicationName;
                            Membership.ApplicationName = appName;
                            Roles.ApplicationName = appName;
                            tempUsers = Membership.GetAllUsers();

                            foreach (MembershipUser user in tempUsers)
                            {
                                string version = user.Comment;
                                string imageURL = String.Format(@"{0}/{1}/{2}/{3}/{4}.jpg", cloudinaryStoreURL, version, cloudinaryAccountsFolder, appName, user.UserName);
                                string userRolestring = RolesBLL.GetRolesForUserInOneString(appName, user.UserName);
                                List<string> userRoles = RolesBLL.GetRolesForUserByApplication(appName, user.UserName);
                                allUsers.Add(new UserApplication(user, appName, imageURL, userRolestring, userRoles));
                            }
                        }

                        Membership.ApplicationName = "ShopHelperAsp";
                        Roles.ApplicationName = "ShopHelperAsp";
                        break;
                    }
                case SelectApplications.SpecifucApplication:
                    {
                        Membership.ApplicationName = applicationName;
                        tempUsers = Membership.GetAllUsers();

                        foreach (MembershipUser user in tempUsers)
                        {
                            string version = user.Comment;
                            string imageURL = String.Format(@"{0}/{1}/{2}/{3}/{4}.jpg", cloudinaryStoreURL, version, cloudinaryAccountsFolder, applicationName, user.UserName);
                            string userRoles = RolesBLL.GetRolesForUserInOneString(applicationName, user.UserName);
                            allUsers.Add(new UserApplication(user, applicationName, imageURL, userRoles));
                        }

                        Membership.ApplicationName = "ShopHelperAsp";
                        break;
                    }

            }
            return allUsers;
        }

        public static bool CreateNewUserApp(UserApplication newUser, HtmlInputFile imageUploader )
        {
            string applicationName = newUser.AppName;
            string username = newUser.UserName;
            string password = newUser.Password;
            string[] userRoles = newUser.UserRoles.ToArray();
            bool isNewUserCreated = false;

            Membership.ApplicationName = applicationName;
            Roles.ApplicationName = applicationName;

            Membership.CreateUser(username, password);

            if (Membership.ValidateUser(username, password))
            {
                Roles.AddUserToRoles(username, userRoles);

                string profileImageVersion = UploadCloudinaryProfileImage(imageUploader, applicationName, username);

                Membership.ApplicationName = applicationName;
                MembershipUser currentUser = Membership.GetUser(username);
                currentUser.Comment = profileImageVersion;
                Membership.UpdateUser(currentUser);
                Membership.ApplicationName = "ShopHelperAsp";

                isNewUserCreated = true;
            }
            Membership.ApplicationName = "ShopHelperAsp";
            Roles.ApplicationName = "ShopHelperAsp";

            return isNewUserCreated;
        }

        public static bool DeleteUserApp(UserApplication deleteUser)
        {
            string username = deleteUser.UserName;
            string applicationName = deleteUser.AppName;
            bool isUserDeleted = false;


            Membership.ApplicationName = applicationName;
            Roles.ApplicationName = applicationName;

            bool isUserDeletedFromDb = Membership.DeleteUser(username);

            if (isUserDeletedFromDb)
            {
                DeleteCloudinaryProfileImage(username, applicationName);
                isUserDeleted = true;
            }
            Membership.ApplicationName = "ShopHelperAsp";
            Roles.ApplicationName = "ShopHelperAsp";

            return isUserDeleted;
        }

        public static bool UpdateUserApp(UserApplication updateUser, HtmlInputFile imageUploader)
        {

            bool isSuccsesfullyUpdate = false;
            bool isSuccsesfullyUpdateUsername = false;
            bool isSuccsesfullyRenameImage = false;
            bool isSuccsesfullyUploadNewImage = false;
            bool isSuccsesfullyDeleteUserRoles=false;
            bool isSuccsesfullyAddUserRoles=false;
            bool isSuccsesfullyUpdateUserRoles = false; 

            string oldUserName = updateUser.OldUsernameForUpdate;
            string newUserName = updateUser.NewUsernameForUpdate;
            string applicationName = updateUser.AppName;
            string profileImageVersion = null;
            string resetPassword = updateUser.ResetUserPassword;
            List<string> userRoles = updateUser.UserRoles;

            Membership.ApplicationName = applicationName;
            Roles.ApplicationName = applicationName;

            //UpdateUsername
            if (!oldUserName.Equals(newUserName))
            {
                isSuccsesfullyUpdateUsername = UsersAppsDAL.UpdateUserName(oldUserName, newUserName);

                if (imageUploader.PostedFile == null || imageUploader.PostedFile.FileName == "")
                {
                    Cloudinary cloudinary = new Cloudinary(cloudinaryAccount);

                    string oldProfileImageName = String.Format(@"{0}/{1}/{2}", cloudinaryAccountsFolder, applicationName, oldUserName);
                    string newProfileImageName = String.Format(@"{0}/{1}/{2}", cloudinaryAccountsFolder, applicationName, newUserName);
                    RenameResult result = cloudinary.Rename(oldProfileImageName, newProfileImageName, true);
                    profileImageVersion = "v" + result.Version;

                    isSuccsesfullyRenameImage = true;
                }
            }

            //UploadNewImage
            if (imageUploader.PostedFile != null && imageUploader.PostedFile.FileName != "")
            {
                DeleteCloudinaryProfileImage(oldUserName, applicationName);

                profileImageVersion = UploadCloudinaryProfileImage(imageUploader, applicationName, newUserName);
                isSuccsesfullyUploadNewImage = true;
            }

            //ResetPassword
            if (!String.IsNullOrEmpty(resetPassword))
            {
                if (!oldUserName.Equals(newUserName))
                {
                    ResetUserPassword(newUserName, resetPassword);
                }
                else
                {
                    ResetUserPassword(oldUserName, resetPassword);
                }
            }

            //UpdateUserRoles
            if (oldUserName.Equals(newUserName))
            {
                foreach (string oldRole in Roles.GetRolesForUser(oldUserName))
                {
                    foreach (string newRole in userRoles)
                    {
                        if (!oldRole.Equals(newRole))
                        {
                            Roles.RemoveUserFromRole(oldUserName, oldRole);
                            isSuccsesfullyDeleteUserRoles=true;
                        }
                    }
                }
            }
            else
            {
                foreach (string oldRole in Roles.GetRolesForUser(newUserName))
                {
                    foreach (string newRole in userRoles)
                    {
                        if (!oldRole.Equals(newRole))
                        {
                            Roles.RemoveUserFromRole(newUserName, oldRole);
                            isSuccsesfullyDeleteUserRoles=true;
                        }
                    }
                }
            }

            foreach (string role in userRoles)
            {
                if (!userRoles[0].Equals("The user isn't in roles"))
                {
                    if (oldUserName.Equals(newUserName))
                    {
                        if (!Roles.IsUserInRole(oldUserName, role))
                        {
                            Roles.AddUserToRole(oldUserName, role);
                        }
                    }
                    else
                    {
                        if (!Roles.IsUserInRole(newUserName, role))
                        {
                            Roles.AddUserToRole(newUserName, role);
                        }
                    }
                    isSuccsesfullyAddUserRoles=true;
                }
            }
            isSuccsesfullyUpdateUserRoles = (isSuccsesfullyDeleteUserRoles || isSuccsesfullyAddUserRoles); 


            if (((isSuccsesfullyUpdateUsername && isSuccsesfullyRenameImage) || isSuccsesfullyUploadNewImage) || isSuccsesfullyUpdateUserRoles)
            {
                isSuccsesfullyUpdate = true;
            }

            MembershipUser currentUser = Membership.GetUser(newUserName);
            currentUser.Comment = profileImageVersion;
            Membership.UpdateUser(currentUser);
            Membership.ApplicationName = "ShopHelperAsp";
            Roles.ApplicationName = "ShopHelperAsp";

            return isSuccsesfullyUpdate;
        }

        //public static bool CreateNewUserApp(string applicationName,string username,string password,HtmlInputFile imageUploader)
        //{
        //    Cloudinary cloudinary = new Cloudinary(cloudinaryAccount);

        //    Membership.ApplicationName = applicationName;
        //    Membership.CreateUser(username, password);

        //    bool isNewUserCreated = false;

        //    if (Membership.ValidateUser(username, password))
        //    {
        //        var uploadParams = new ImageUploadParams()
        //        {
        //            File = new FileDescription(imageUploader.PostedFile.FileName, imageUploader.PostedFile.InputStream),
        //            Folder = cloudinaryAccountsFolder + "/" + applicationName,
        //            PublicId = username,
        //            Invalidate = true
        //        };
        //        var uploadResult = cloudinary.Upload(uploadParams);

        //        Membership.ApplicationName = applicationName;
        //        MembershipUser currentUser = Membership.GetUser(username);
        //        currentUser.Comment = "v" + uploadResult.Version;
        //        Membership.UpdateUser(currentUser);
        //        Membership.ApplicationName = "ShopHelperAsp";

        //        isNewUserCreated = true;
        //    }
        //    Membership.ApplicationName = "ShopHelperAsp";

        //    return isNewUserCreated;
        //}

        //private static List<string> GetAllApplicationNames()
        //{
        //    List<string> appsNamesList = new List<string>();
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("ShopHelperAsp.Data.Applications.xml"));
        //    XmlNode rootNode = doc.DocumentElement;

        //    foreach (XmlNode app in rootNode.ChildNodes)
        //    {
        //        string appName = app.Attributes["text"].Value;
        //        appsNamesList.Add(appName);

        //    }
        //    return appsNamesList;
        //}

        private static string UploadCloudinaryProfileImage(HtmlInputFile imageUploader, string applicationName, string username)
        {
            Cloudinary cloudinary = new Cloudinary(cloudinaryAccount);
            string profileImageVersion = null;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageUploader.PostedFile.FileName, imageUploader.PostedFile.InputStream),
                Folder = cloudinaryAccountsFolder + "/" + applicationName,
                PublicId = username,
                Invalidate = true
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            profileImageVersion = "v" + uploadResult.Version;
            return profileImageVersion;
        }

        private static void DeleteCloudinaryProfileImage(string username, string applicationName)
        {
            Cloudinary cloudinaryDelete = new Cloudinary(cloudinaryAccount);
            string profileImageURL = String.Format(@"{0}/{1}/{2}", cloudinaryAccountsFolder, applicationName, username);

            var delParams = new DelResParams()
            {
                PublicIds = new List<string>() { profileImageURL },
                Invalidate = true
            };
            DelResResult result = cloudinaryDelete.DeleteResources(delParams);
        }

        private static void ResetUserPassword(string username, string newPassword)
        {
            MembershipUser selectedUser = Membership.GetUser(username);
            selectedUser.ChangePassword(selectedUser.ResetPassword(), newPassword);
        }
    }
}
