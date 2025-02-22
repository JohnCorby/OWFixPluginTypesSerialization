using OWML.Common;
using OWML.ModHelper;
using System.IO;

namespace OWFixPluginTypesSerialization;

public class OWFixPluginTypesSerialization : ModBehaviour
{
	private void Start()
	{
		// sanity check: verify bepinex exists
		if (!File.Exists(Path.Combine(ModHelper.OwmlConfig.GamePath, "doorstop_config.ini")))
			ModHelper.Console.WriteLine("OWFixPluginTypesSerialization: BepInEx is not installed. Please run the game via the RUN GAME button in Outer Wilds Mod Manager.", MessageType.Fatal);
	}
}
