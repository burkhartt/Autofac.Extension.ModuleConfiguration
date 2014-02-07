using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Autofac.Extension.ModuleConfiguration {
	[ConfigurationCollection(typeof(ModuleElement), AddItemName = "module")]
	public class ModulesCollection : ConfigurationElementCollection, IEnumerable<ModuleElement> {

		protected override ConfigurationElement CreateNewElement() {
			return new ModuleElement();
		}

		protected override object GetElementKey(ConfigurationElement element) {
			var lConfigElement = element as ModuleElement;
			return lConfigElement != null ? lConfigElement.Name : null;
		}

		public ModuleElement this[int index] {
			get {
				return BaseGet(index) as ModuleElement;
			}
		}
		
		IEnumerator<ModuleElement> IEnumerable<ModuleElement>.GetEnumerator() {
			return (from i in Enumerable.Range(0, this.Count)
			        select this[i])
				.GetEnumerator();
		}
	}
}