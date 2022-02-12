using System.Text.Json;
using jsonSerializationSpike.Items;
using NUnit.Framework;

namespace UnitTesting {
	[TestFixture]
	public class PropertyListContainerConverterTest {
		private readonly PropertyListContainer _container = new PropertyListContainer();

		private const string Serialized = "[{\"Stealth\":-2,\"Strength\":9},{\"Stealth\":-2,\"Strength\":9}," +
		                                  "{\"Stealth\":0,\"Strength\":11},{\"Stealth\":5,\"Strength\":4}," +
		                                  "{\"Stealth\":7,\"Strength\":2}]";

		public PropertyListContainerConverterTest()
		{
			_container.Add(new PropertyListContainer.ListItem { Stealth = -2, Strength = 9 })
				.Add(new PropertyListContainer.ListItem { Stealth = -2, Strength = 9 })
				.Add(new PropertyListContainer.ListItem { Stealth = 0, Strength = 11 })
				.Add(new PropertyListContainer.ListItem { Stealth = 5, Strength = 4 })
				.Add(new PropertyListContainer.ListItem { Stealth = 7, Strength = 2 });
		}

		[Test]
		public void Serialize()
		{
			var json = JsonSerializer.Serialize(_container);
			Assert.AreEqual(json, Serialized);
		}

		[Test]
		public void DeSerialize()
		{
			var containerObj = JsonSerializer.Deserialize<PropertyListContainer>(Serialized);
			if (containerObj == null)
			{
				Assert.Fail("Container object could not been deserialized.");
			}

			Assert.AreEqual(8, containerObj.Stealth);
			Assert.AreEqual(35, containerObj.Strength);
		}
	}
}