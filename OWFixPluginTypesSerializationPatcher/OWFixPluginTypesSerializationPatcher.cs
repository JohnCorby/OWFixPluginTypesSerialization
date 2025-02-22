using Newtonsoft.Json;
using System;
using System.IO;

namespace OWFixPluginTypesSerializationPatcher;

// based on nomaivr and qsb patcher
public static class OWFixPluginTypesSerializationPatcher
{
	// https://github.com/ow-mods/owml/blob/master/src/OWML.Common/OwmlConfig.cs
	private class OwmlConfig
	{
		[JsonProperty("owmlPath")]
		public string OWMLPath { get; set; }
	}

	// https://github.com/ow-mods/owml/blob/master/src/OWML.Common/ModManifest.cs
	private class ModManifest
	{
		[JsonProperty("dependencies")]
		public string[] Dependencies { get; private set; } = { };
	}

	// https://github.com/ow-mods/owml/blob/master/src/OWML.ModHelper/ModConfig.cs
	private class ModConfig
	{
		[JsonProperty("enabled")]
		public bool Enabled { get; set; } = true;
	}


	//Called by OWML
	public static void Main(string[] args)
	{
		var basePath = args.Length > 0 ? args[0] : ".";
		var gamePath = AppDomain.CurrentDomain.BaseDirectory;
		var managedPath = Path.Combine(gamePath, GetDataPath(gamePath), "Managed");

		// delete all the existing bep stuff just in case user still has old version
		if (Directory.Exists(Path.Combine(gamePath, "BepInEx")))
			Directory.Delete(Path.Combine(gamePath, "BepInEx"), true);
		File.Delete(Path.Combine(gamePath, "doorstop_config.ini"));
		File.Delete(Path.Combine(gamePath, "winhttp.dll"));
		Console.WriteLine("deleted all bep stuff in game path");

		// have to delete this owml dll so as to not conflict with a bepinex one of the same name
		File.Delete(Path.Combine(managedPath, "MonoMod.Utils.dll"));
		Console.WriteLine("deleted monomod");

		// copy over the right bep stuff to the game folder
		File.Copy(Path.Combine(basePath, "BepFiles", "doorstop_config.ini"), Path.Combine(gamePath, "doorstop_config.ini"), true);
		Console.WriteLine("copied doorstop config");

		// edit the config to point to the right file in our mod folder
		var text = File.ReadAllText(Path.Combine(gamePath, "doorstop_config.ini"));
		text = text.Replace("%BepFilesPath%", Path.Combine(basePath, "BepFiles"));
		File.WriteAllText(Path.Combine(gamePath, "doorstop_config.ini"), text);
		Console.WriteLine("update config path");
	}

	private static string GetExecutableName(string gamePath)
	{
		var executableNames = new[] { "Outer Wilds.exe", "OuterWilds.exe" };
		foreach (var executableName in executableNames)
		{
			var executablePath = Path.Combine(gamePath, executableName);
			if (File.Exists(executablePath))
			{
				return Path.GetFileNameWithoutExtension(executablePath);
			}
		}

		throw new FileNotFoundException($"Outer Wilds exe file not found in {gamePath}");
	}

	private static string GetDataDirectoryName()
	{
		var gamePath = AppDomain.CurrentDomain.BaseDirectory;
		return $"{GetExecutableName(gamePath)}_Data";
	}

	private static string GetDataPath(string gamePath)
	{
		return Path.Combine(gamePath, $"{GetDataDirectoryName()}");
	}
}
