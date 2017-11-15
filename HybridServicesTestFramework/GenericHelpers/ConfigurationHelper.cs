using NUnit.Framework;
using System.Configuration;

namespace HybridServicesTestFramework.GenericHelpers
{
	public class ConfigurationHelper
	{
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
