using System;

namespace jsonSerializationSpike
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Program started");

			var simulator = new Simulator();
			simulator.Run();
		}
	}
}