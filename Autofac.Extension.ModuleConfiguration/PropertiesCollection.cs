using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Autofac.Extension.ModuleConfiguration {
	[ConfigurationCollection(typeof(Property), AddItemName = "property")]
	public class PropertiesCollection : ConfigurationElementCollection, IEnumerable<Property> {

		protected override ConfigurationElement CreateNewElement() {
			return new Property();
		}

		protected override object GetElementKey(ConfigurationElement element) {
			var l_configElement = element as Property;
			if (l_configElement != null)
				return l_configElement.Name;
			else
				return null;
		}

		public Property this[int index] {
			get {
				return BaseGet(index) as Property;
			}
		}

		IEnumerator<Property> IEnumerable<Property>.GetEnumerator() {
			return (from i in Enumerable.Range(0, this.Count)
			        select this[i])
				.GetEnumerator();
		}
	}
}