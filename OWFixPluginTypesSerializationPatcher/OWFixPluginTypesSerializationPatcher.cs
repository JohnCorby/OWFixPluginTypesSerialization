using System;
using System.IO;

namespace OWFixPluginTypesSerializationPatcher;

// based on nomaivr and qsb patcher
public static class OWFixPluginTypesSerializationPatcher
{
	//Called by OWML
	public static void Main()
	{
		var gamePath = AppDomain.CurrentDomain.BaseDirectory;

		// delete bepinex entirely since it lying around can brick the game
		if (Directory.Exists(Path.Combine(gamePath, "BepInEx")))
			Directory.Delete(Path.Combine(gamePath, "BepInEx"), true);
		File.Delete(Path.Combine(gamePath, "doorstop_config.ini"));
		File.Delete(Path.Combine(gamePath, "winhttp.dll"));
		Console.WriteLine("deleted all bep stuff in game path");
	}
}
