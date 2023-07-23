using OWML.Common;
using OWML.ModHelper;
using System.IO;

namespace OWFixPluginTypesSerialization;

public class OWFixPluginTypesSerialization : ModBehaviour
{
	private void Start()
	{
		// verify bepinex exists
		if (!File.Exists(Path.Combine(ModHelper.OwmlConfig.GamePath, "doorstop_config.ini")))
			ModHelper.Console.WriteLine("BepInEx is not installed. Please run the game via the mod manager.", MessageType.Fatal);
	}

	private void OnApplicationQuit()
	{
		// uninstall bepinex by deleting one of the three files and copying back owml monomod
		File.Delete(Path.Combine(ModHelper.OwmlConfig.GamePath, "doorstop_config.ini"));
		File.Copy(Path.Combine(ModHelper.OwmlConfig.OWMLPath, "MonoMod.Utils.dll"), Path.Combine(ModHelper.OwmlConfig.ManagedPath, "MonoMod.Utils.dll"));
	}
}
