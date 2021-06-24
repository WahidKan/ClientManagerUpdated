using Xamarin.Essentials;
using Xamarin.Forms;

namespace UserManager
{
    public static class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://YOURPROJECT.azurewebsites.net:8081/api/todoitems/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5001/api/todoitems/{0}" : "http://localhost:5000/api/todoitems/{0}";

        ////dpsIP
        static string IP = "http://192.168.100.40:80/";

        //iphoneIP
        //static string IP = "http://172.20.10.7:5000/";

        ////mtsIP
        //static string IP = "http://192.168.8.194:5000/";

        //dps localhost
        public static string GetAllIndustriesURL = IP + "getallindustries";
        public static string GetAllClientsURL = IP + "getallclients";
        public static string GetAllContactsURL = IP + "getallcontacts";
        public static string GetAllProjectsURL = IP + "getallprojects";

        public static string AddIndustryURL = IP + "addindustry";
        public static string AddClientURL = IP + "addclient";
        public static string AddContactURL = IP + "addcontact";
        public static string AddProjectURL = IP + "addproject";

        public static string UpdateIndustryURL = IP + "updateindustry";
        public static string UpdateClientURL = IP + "updateclient";
        public static string UpdateContactURL = IP + "updatecontact";
        public static string UpdateProjectURL = IP + "updateproject";

        public static string DeleteIndustryURL = IP + "deleteindustry";
        public static string DeleteClientURL = IP + "deleteclient";
        public static string DeleteContactURL = IP + "deletecontact";
        public static string DeleteProjectURL = IP + "deleteproject";
        

    }
}
