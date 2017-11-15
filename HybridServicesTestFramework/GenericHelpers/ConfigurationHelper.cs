using NUnit.Framework;
using System.Configuration;
using System.IO;
using static HybridServicesTestFramework.SystemConstants.SystemConstants;

namespace HybridServicesTestFramework.GenericHelpers
{
	public class ConfigurationHelper
	{
	    public string GetHybridHost(string path)
	    {
	       string hybridHost = GetRow(Path.GetFullPath(path), HybridHost);
	       return hybridHost.Split(':')[0];
        }

		public void AddToConfigFile(string path, string key, string value)
		{
			var configFile = ConfigurationManager.OpenExeConfiguration(path);
			if (configFile.AppSettings.Settings[key] == null || !configFile.AppSettings.Settings[key].Value.Contains(value))
			{
				configFile.AppSettings.Settings.Add(key, value);
				configFile.Save();
				Assert.IsTrue(configFile.AppSettings.Settings[key].Value.Contains(value));
			}
		}

		public void DeleteRow(string path, string key)
		{
			var configFile = ConfigurationManager.OpenExeConfiguration(path);
			if (configFile.AppSettings.Settings[key] != null)
			{
				configFile.AppSettings.Settings.Remove(key);
				configFile.Save();
			}
		}

		public dynamic GetRow(string path, string key)
		{
			var configFile = ConfigurationManager.OpenExeConfiguration(path);
			dynamic value = null;
			if (configFile.AppSettings.Settings[key] != null)
			{
				value= configFile.AppSettings.Settings[key].Value;
			}
			return value;
		}
	}
}
