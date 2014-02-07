using System.Configuration;

namespace Autofac.Extension.ModuleConfiguration {
	public class ModulesSection : ConfigurationSection {

		[ConfigurationProperty("modules", IsRequired = true)]
		public ModulesCollection Modules {
			get {
				return base["modules"] as ModulesCollection;
			}
		}

	}
}