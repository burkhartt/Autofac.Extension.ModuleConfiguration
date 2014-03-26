using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Autofac.Extension.ModuleConfiguration {
	public class ConfigurableModule : Module {
		public ConfigurableModule() {
			var section = (ModulesSection)ConfigurationManager.GetSection("autofacModules");
			var moduleName = GetType().Name.Replace("Module", "");

			var moduleConfiguration = section.Modules.SingleOrDefault(m => m.Name.Equals(moduleName, StringComparison.OrdinalIgnoreCase));
			if (moduleConfiguration == null)
				return;

			foreach (var configProperty in moduleConfiguration.ModuleProperties.ToArray()) {
				var moduleProperty = GetType().GetProperty(configProperty.Name);

				if (ConnectionStringSpecified(configProperty)) {
					SetPropertyWithConnectionStringValue(moduleProperty, configProperty);
					continue;
				}

				if (AppSettingsStringSpecified(configProperty)) {
					SetPropertyWithAppSettingValue(moduleProperty, configProperty);
					continue;
				}
				
				SetPropertyValue(moduleProperty, configProperty.Value);
			}
		}

		private void SetPropertyWithAppSettingValue(PropertyInfo moduleProperty, Property configProperty) {
			var appSetting = ConfigurationManager.AppSettings[configProperty.AppSetting];
			SetPropertyValue(moduleProperty, appSetting);
		}

		private void SetPropertyWithConnectionStringValue(PropertyInfo moduleProperty, Property configProperty) {
			var connectionString = ConfigurationManager.ConnectionStrings[configProperty.ConnectionString].ConnectionString;
			SetPropertyValue(moduleProperty, connectionString);
		}

		private void SetPropertyValue(PropertyInfo moduleProperty, string value) {
			var newValue = Convert.ChangeType(value, moduleProperty.PropertyType);
			moduleProperty.SetValue(this, newValue);
		}

		private bool AppSettingsStringSpecified(Property configProperty) {
			return !string.IsNullOrEmpty(configProperty.AppSetting);
		}

		private static bool ConnectionStringSpecified(Property configProperty) {
			return !string.IsNullOrEmpty(configProperty.ConnectionString);
		}
	}
}