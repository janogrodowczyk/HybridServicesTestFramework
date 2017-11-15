using System.Security.Principal;

namespace HybridServicesTestFramework.SystemConstants
{
    public class SystemConstants
    {
        public const string SenseLogPath = "C:\\ProgramData\\Qlik\\Sense\\Log\\";
        public const string StaticContentTestDataPath = "\\\\testcontent.rdlund.qliktech.com\\share\\server\\test_data\\StaticContentFw";
        public const string TestDataLocation = "\\\\testcontent.rdlund.qliktech.com\\share\\server\\test_data\\";
        public const string TestAppsLocation = "\\\\testcontent.rdlund.qliktech.com\\share\\server\\test_data\\Apps\\";
        public const string SenseRepositoryPath = "C:\\ProgramData\\Qlik\\Sense\\Repository\\";
        public const string ExportedAppViaSyncToCloudPath = @"D:\GitSource\CloudApiSimulator\";
        public const string CloudHost = "staging.qlikcloud.com";
        public const string CloudBaseUrl = "https://staging.qlikcloud.com/api/v1";
        
        public const string ServiceAccountProxy = "sa_proxy";
        public const string ServiceAccountRepository = "sa_repository";
        public const string ServiceAccountScheduler = "sa_scheduler";
        public const string ServiceAccountDirectory = "INTERNAL";
        
        //App names for upload
        public const string EmptyApp = "EmptyApp.qvf";
        public const string AppWithSheets = "AppWithSheets.qvf";
        public const string Ctrl00App = "ctrl00.qvf";
        public const string BrokenScriptApp = "brokenscriptapp.qvf";
        public const string AppWithSheetsPlusOne = "AppWithSheetsPlusOne.qvf";
        public const string AppWith10SecReload = "ctrl00_with10secreload.qvf";
        public const string AppWithObjectsAndDataConnection = "AppWithDataConnection.qvf";
        public const string AppWithAppInternals = "AppContainingAppInternal.qvf";
        public const string ExecutiveDashBoardApp = "ExecutiveDashboard.qvf";
        public const string EveryoneStream = "Everyone";
        public const string MonitoringAppsStream = "Monitoring apps";
        public const string DbProviderContentService = "ContentService";
        public static string CurrentUserId = WindowsIdentity.GetCurrent().Name.Split('\\')[1].ToLower();
        public static string CurrentUserDirectory = WindowsIdentity.GetCurrent().Name.Split('\\')[0].ToUpper();

        // Services flags
        public const string DefaultRepositoryFlag = "\"C:\\Program Files\\Qlik\\Sense\\Repository\\Repository.exe\" -iscentral";
        public const string DefaultEngineFlag = "\"C:\\Program Files\\Qlik\\Sense\\Engine\\Engine.exe";
        public const string DefaultPrintingFlag = "\"C:\\Program Files\\Qlik\\Sense\\Printing\\Printing.exe";
        public const string DefaultProxyFlag = "\"C:\\Program Files\\Qlik\\Sense\\Proxy\\Proxy.exe";
        public const string DefaultSchedulerFlag = "\"C:\\Program Files\\Qlik\\Sense\\Scheduler\\Scheduler.exe";
        public const string DefaultServicedispatcherFlag = "\"C:\\Program Files\\Qlik\\Sense\\ServiceDispatcher\\ServiceDispatcher.exe";

        //Services
        public const string RepositoryServiceName = "Qlik Sense Repository Service";
        public const string ProxyServiceName = "Qlik Sense Proxy Service";
        public const string SchedulerServiceName = "Qlik Sense Scheduler Service";
        public const string EngineServiceName = "Qlik Sense Engine Service";
        public const string RepositoryDatabaseServiceName = "Qlik Sense Repository Database";
        public const string ServiceDispatcherName = "Qlik Sense Service Dispatcher";
        public const string PrintingServiceName = "Qlik Sense Printing Service";

        //Headers
        public const string HeaderUserDir = "QT";
        public const string XrefKeyValue = "ichbineinberlinR";
        public const string JwtCapabilityHeaderValues = "jwt-authentication";
        public const string JwtBearer = "Bearer ";
        public const string AuthorizationHeader = "Authorization";
        public const string AcceptHeader = "Accept";
        public const string HeaderApplicationJsonValue = "application/json";
        public const string FeatureConnectParameter = "feature=ent-connect";
        public const string SetCookieName = "Set-Cookie";

        // Config files
        public const string HybridHost = "HybridHost";

        //Parameter
        public const string XrfkeyQuerystringName = "xrfkey";

		//Cloud
		public const string AuthenticationUrl = "https://login-dev-us-east-1.dev.qlikcloud.com";
		public const string ServiceUrl = "https://develop.qlikcloud.com/api/v1";
	    public const string HawkId = "59aea078d2e75d003cb97b5e";
	    public const string HawkKey = "eDBmZkEvcXhDdm1DL2hSVkUzOFkydz09";
	    public const string ClientId = "HVzsWgyJE7OICFQSgoH1h2hjbU7O2W6Y";
	    public const string ClientSecret = "VbLCgMdxak4d4KuUyfBvp385Io9Ly2KLXP6BhebhBk-eJQJuxBSwqK249oUvTVi0";
	    public const string ProxyPath = "C:\\Program Files\\Qlik\\Sense\\Proxy\\Proxy.exe";

    }
}
