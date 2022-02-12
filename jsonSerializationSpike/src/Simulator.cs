using System;
using System.Text.Json;
using jsonSerializationSpike.Items;

namespace jsonSerializationSpike {
	public class Simulator {
		public void Run()
		{
			var container = new MainContainer { Health = 5, Name = "Conan", Container = { Intelligence = 2, Vitality = 19 } };
			container.ListContainer.Add(new PropertyListContainer.ListItem { Stealth = -2, Strength = 9 })
				.Add(new PropertyListContainer.ListItem { Stealth = -2, Strength = 9 })
				.Add(new PropertyListContainer.ListItem { Stealth = 0, Strength = 11 })
				.Add(new PropertyListContainer.ListItem { Stealth = 5, Strength = 4 })
				.Add(new PropertyListContainer.ListItem { Stealth = 7, Strength = 2 });

			Console.WriteLine($"Stealth: {container.ListContainer.Stealth.ToString()}");
			Console.WriteLine($"Strength: {container.ListContainer.Strength.ToString()}");

			var json = JsonSerializer.Serialize(container,
				new JsonSerializerOptions
					{ IgnoreReadOnlyProperties = true, WriteIndented = true });

			Console.WriteLine(json);

			var deSerialized = JsonSerializer.Deserialize<MainContainer>(json);
			if (deSerialized == null)
			{
				throw new Exception("Container could not been deserialized");
			}

			Console.WriteLine($"Intelligence: {deSerialized.Container.Intelligence.ToString()}");
			Console.WriteLine($"Vitality: {deSerialized.Container.Vitality.ToString()}");
			Console.WriteLine($"Stealth: {deSerialized.ListContainer.Stealth.ToString()}");
			Console.WriteLine($"Strength: {deSerialized.ListContainer.Strength.ToString()}");
		}
	}
}