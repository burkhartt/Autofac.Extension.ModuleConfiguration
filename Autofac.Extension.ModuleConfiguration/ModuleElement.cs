using System.Configuration;

namespace Autofac.Extension.ModuleConfiguration {
	public class ModuleElement : ConfigurationElement {

		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name {
			get {
				return base["name"] as string;
			}
			set {
				base["name"] = value;
			}
		}

		[ConfigurationProperty("properties")]
		public PropertiesCollection ModuleProperties {
			get {
				return base["properties"] as PropertiesCollection;
			}
		}

	}
}