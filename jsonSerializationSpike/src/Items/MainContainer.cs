namespace jsonSerializationSpike.Items {
	public class MainContainer {
		public int Health { get; set; }
		public string Name { get; set; }

		// Auto property :)
		public PropertyContainer Container { get; set; } = new PropertyContainer();

		// [JsonConverter()]
		public PropertyListContainer ListContainer { get; set; } = new PropertyListContainer();
	}
}