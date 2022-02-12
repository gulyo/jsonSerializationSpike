using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace jsonSerializationSpike.Items {
	[JsonConverter(typeof(PropertyListContainerConverter))]
	public class PropertyListContainer {
		private readonly List<ListItem> _items = new List<ListItem>();

		public int Strength => _items.Sum(item => item.Strength);
		public int Stealth => _items.Sum(item => item.Stealth);

		public IEnumerable<ListItem> Items => _items
			.Select(item => new ListItem { Stealth = item.Stealth, Strength = item.Strength })
			.ToArray();

		public PropertyListContainer Add(ListItem item)
		{
			_items.Add(item);
			return this;
		}

		public class ListItem {
			public int Strength { get; set; }
			public int Stealth { get; set; }
		}
	}
}