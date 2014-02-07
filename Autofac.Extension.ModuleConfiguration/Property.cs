using System.Configuration;

namespace Autofac.Extension.ModuleConfiguration {
	public class Property : ConfigurationElement {
		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name {
			get {
				return base["name"] as string;
			}
			set {
				base["name"] = value;
			}
		}

		[ConfigurationProperty("value", IsKey = false, IsRequired = false)]
		public string Value {
			get {
				return base["value"] as string;
			}
			set {
				base["value"] = value;
			}
		}

		[ConfigurationProperty("connectionString", IsKey = false, IsRequired = false)]
		public string ConnectionString {
			get {
				return base["connectionString"] as string;
			}
			set {
				base["connectionString"] = value;
			}
		}

		[ConfigurationProperty("appSetting", IsKey = false, IsRequired = false)]
		public string AppSetting {
			get {
				return base["appSetting"] as string;
			}
			set {
				base["appSetting"] = value;
			}
		}
	}
}