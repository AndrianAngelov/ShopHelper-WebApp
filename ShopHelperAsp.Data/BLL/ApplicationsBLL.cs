namespace ShopHelperAsp.Data.BLL
{
    using System;
    using System.Collections.Generic;
    using ShopHelperAsp.Data.Entities;
    using ShopHelperAsp.Data.DAL;

    public enum ApplicationsOptionAll
    {
        True,
        False,
    }

    public class ApplicationsBLL
    {
        public static List<Application> GetApplications(ApplicationsOptionAll includeOptionAll)
        {
            List<Application> allApplications = new List<Application>();

            switch (includeOptionAll)
            {
                case ApplicationsOptionAll.True:
                    {
                        Application optionSelectApp = new Application();
                        optionSelectApp.ApplicationName = "---Select Application---";
                        allApplications.Add(optionSelectApp);
                        Application optionAll = new Application();
                        optionAll.ApplicationName = "All";
                        allApplications.Add(optionAll);
                        foreach (Application application in ApplicationsDAL.GetApplications())
                        {
                            allApplications.Add(application);
                        }
                        break;
                    }
                case ApplicationsOptionAll.False:
                    {
                        //allApplications = ApplicationsDAL.GetApplications();
                        Application optionSelectApp = new Application();
                        optionSelectApp.ApplicationName = "---Select Application---";
                        allApplications.Add(optionSelectApp);
                        foreach (Application application in ApplicationsDAL.GetApplications())
                        {
                            allApplications.Add(application);
                        }
                        break;
                    }
            }

            return allApplications;
        }
    }
}
