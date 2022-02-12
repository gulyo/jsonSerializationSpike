using System.Text.Json.Serialization;

namespace jsonSerializationSpike.Items {
	[JsonConverter(typeof(PropertyContainerConverter))]
	public class PropertyContainer {
		public int Vitality { get; set; }
		public int Intelligence { get; set; }
	}
}