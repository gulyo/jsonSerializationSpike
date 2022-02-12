using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace jsonSerializationSpike.Items {
	public class PropertyListContainerConverter : JsonConverter<PropertyListContainer> {
		public override PropertyListContainer Read(ref Utf8JsonReader reader, Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException();
			}

			var container = new PropertyListContainer();

			for (reader.Read(); reader.TokenType != JsonTokenType.EndArray; reader.Read())
			{
				container.Add(readListItem(ref reader));
			}

			return container;
		}

		private static PropertyListContainer.ListItem readListItem(ref Utf8JsonReader reader)
		{
			var item = new PropertyListContainer.ListItem();
			if (reader.TokenType != JsonTokenType.StartObject)
			{
				throw new JsonException();
			}

			for (reader.Read(); reader.TokenType != JsonTokenType.EndObject; reader.Read())
			{
				var propName = reader.GetString();
				reader.Read();
				switch (propName)
				{
					case "Stealth":
						item.Stealth = reader.GetInt32();
						break;
					case "Strength":
						item.Strength = reader.GetInt32();
						break;
					default:
						throw new JsonException($"Unknown property name: {propName}");
				}
			}

			return item;
		}

		public override void Write(Utf8JsonWriter writer, PropertyListContainer value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			foreach (var item in value.Items)
			{
				writer.WriteStartObject();
				writer.WritePropertyName("Stealth");
				writer.WriteNumberValue(item.Stealth);
				writer.WritePropertyName("Strength");
				writer.WriteNumberValue(item.Strength);
				writer.WriteEndObject();
			}

			writer.WriteEndArray();
		}
	}
}