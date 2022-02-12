using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace jsonSerializationSpike.Items {
	public class PropertyContainerConverter : JsonConverter<PropertyContainer> {
		public override PropertyContainer Read(ref Utf8JsonReader reader, Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject) { throw new JsonException(); }

			var container = new PropertyContainer();

			for (reader.Read(); reader.TokenType != JsonTokenType.EndObject; reader.Read())
			{
				// Get the key.
				if (reader.TokenType != JsonTokenType.PropertyName)
				{
					throw new JsonException();
				}

				var propName = reader.GetString();
				reader.Read();
				switch (propName)
				{
					case "Vitality":
						container.Vitality = reader.GetInt32();
						break;
					case "Intelligence":
						container.Intelligence = reader.GetInt32();
						break;
					default:
						throw new JsonException($"Unknown property name: {propName}");
				}
			}

			return container;
		}

		public override void Write(Utf8JsonWriter writer, PropertyContainer value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();
			writer.WritePropertyName("Vitality");
			writer.WriteNumberValue(value.Vitality);
			writer.WritePropertyName("Intelligence");
			writer.WriteNumberValue(value.Intelligence);
			writer.WriteEndObject();
		}
	}
}